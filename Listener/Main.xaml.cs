using Listener.App_Code;
using Listener.App_Code.Include;
using Listener.App_Code.Include.HTTP;
using Listener.App_Code.Include.TCP;
using Model;
using Model.Project;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SystemFramework;

namespace Listener
{
    /// <summary>
    /// Main.xaml 的交互逻辑
    /// </summary>
    public partial class Main : Window
    {
        Include m_inc = new Include();
        IncludeChargeStation m_incChargeStation = new IncludeChargeStation();
        IncludeChargePile m_incChargePile = new IncludeChargePile();
        IncludePlace m_incPlace = new IncludePlace();
        IncludeSystemError m_incSystemError = new IncludeSystemError();
        IncludeHTTPReceive m_incHTTPReceive = new IncludeHTTPReceive();
        IncludeTCPReceive001 m_incTCPReceive001 = new IncludeTCPReceive001();
        IncludeTCPReceive002 m_incTCPReceive002 = new IncludeTCPReceive002();
        IncludeTCPReceive003 m_incTCPReceive003 = new IncludeTCPReceive003();

        public Main()
        {
            InitializeComponent();
            Init();
        }
        #region 定义
        /// <summary>
        /// 充电站列表
        /// </summary>
        ObservableCollection<Listener_ChargeStation_Data> m_dataList = Config.g_dataList;
        /// <summary>
        /// 是否正常关闭
        /// </summary>
        bool m_isNormalClose = false;

        /// <summary>
        /// tcp对象
        /// </summary>
        TcpListener m_tcpListener = null;
        /// <summary>
        /// tcp子线程数量（最大100，根据服务器性能调节）
        /// </summary>
        int m_tcpThreadNumber = 50;
        /// <summary>
        /// tcp线程池
        /// </summary>
        List<Thread> m_tcpThreadList = new List<Thread>();
        /// <summary>
        /// tcp有效客户端队列
        /// </summary>
        Dictionary<string, Dictionary<string, object>> m_tcpClientDic = Config.g_tcpClientDic;
        /// <summary>
        /// tcp有效客户端队列（充电站）
        /// </summary>
        Dictionary<string, Dictionary<string, object>> m_tcpCSClientDic = Config.g_tcpCSClientDic;
        /// <summary>
        /// tcp获取客户端队列数
        /// </summary>
        System.Threading.Timer m_tcpGetClienDicCountTimer = null;
        /// <summary>
        /// tcp无效客户端队列
        /// </summary>
        List<Socket> m_tcpSocketList = new List<Socket>();

        /// <summary>
        /// http对象
        /// </summary>
        HttpListener m_httpLis = null;
        /// <summary>
        /// http子线程数量（最大100，根据服务器性能调节）
        /// </summary>
        int m_httpThreadNumber = 50;
        /// <summary>
        /// http线程池
        /// </summary>
        List<Thread> m_httpThreadList = new List<Thread>();
        #endregion

        #region 函数
        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        void Init()
        {
            this.Title = Config.g_title;//标题
            GetChargeStationList();
        }
        /// <summary>
        /// 获取充电站列表
        /// </summary>
        void GetChargeStationList()
        {
            m_dataList.Clear();
            List<Models> list = m_incChargeStation.GetChargeStationList();
            for (int i = 0; i < list.Count; i++)
            {
                Listener_ChargeStation_Data mod = new Listener_ChargeStation_Data();
                mod.name = list[i].G_ChargeStation.cs_name;
                mod.csid = (long)list[i].G_ChargeStation.cs_id;
                mod.pid = list[i].G_Province.p_id;
                mod.cid = list[i].G_City.c_id;
                mod.did = list[i].G_District.d_id;
                mod.place = list[i].G_Province.p_name + list[i].G_City.c_name + list[i].G_District.d_name;
                mod.cpsum_ac = "0";
                mod.cpsum_dc = "0";
                m_dataList.Add(mod);
            }
        }
        #endregion
        #region 开始
        /// <summary>
        /// 开始tcp服务
        /// </summary>
        void TCPStart()
        {
            try
            {
                m_tcpListener = new TcpListener(IPAddress.Any, int.Parse(text_tcpPort.Text));
                m_tcpListener.Start();
                //接受请求
                for (int i = 0; i < m_tcpThreadNumber; i++)
                {
                    Thread t = new Thread(delegate()
                    {
                        while (true)
                        {
                            try
                            {
                                Socket socket = m_tcpListener.AcceptSocket();
                                try
                                {
                                    //设置检测间隔
                                    //byte[] inValue = new byte[] { 1, 0, 0, 0, 0x20, 0x4e, 0, 0, 0xd0, 0x07, 0, 0 };// 首次探测时间20 秒, 间隔侦测时间2 秒
                                    byte[] inValue = new byte[] { 1, 0, 0, 0, 0x88, 0x13, 0, 0, 0xd0, 0x07, 0, 0 };// 首次探测时间5 秒, 间隔侦测时间2 秒
                                    socket.IOControl(IOControlCode.KeepAliveValues, inValue, null);
                                    //设置检测间隔第二种写法
                                    /*byte[] inOptionValues = new byte[12];
                                    BitConverter.GetBytes((uint)1).CopyTo(inOptionValues, 0);//是否启用Keep-Alive
                                    BitConverter.GetBytes((uint)5000).CopyTo(inOptionValues, 4);//多长时间开始第一次探测
                                    BitConverter.GetBytes((uint)5000).CopyTo(inOptionValues, 8);//探测时间间隔
                                    socket.IOControl(IOControlCode.KeepAliveValues, inOptionValues, null);*/
                                    //添加socket队列
                                    lock (m_tcpSocketList)
                                    {
                                        m_tcpSocketList.Add(socket);
                                    }
                                    socket.BeginReceive(new byte[0], 0, 0, SocketFlags.None, new AsyncCallback(TCPRun), socket);
                                }
                                catch
                                {
                                    TCPStop(socket);
                                }
                            }
                            catch { }
                        }
                    });
                    m_tcpThreadList.Add(t);
                    t.Start();
                }
            }
            catch (Exception e)
            {
                but_star.IsEnabled = true;
                but_stop.IsEnabled = false;
                HTTPStop();
                SysError.Error(e.Message);
            }
        }
        /// <summary>
        /// 开始tcp获取客户端数据统计
        /// </summary>
        void TCPGetClientDicCountStar()
        {
            m_tcpGetClienDicCountTimer = new System.Threading.Timer(delegate(object o)
            {
                try
                {
                    TCPGetClientDicCountRun();
                }
                catch { }
            });
            m_tcpGetClienDicCountTimer.Change(0, 1000);
        }
        /// <summary>
        /// 开始http线程
        /// </summary>
        void HTTPStart()
        {
            try
            {
                m_httpLis = new HttpListener();
                m_httpLis.Prefixes.Add(string.Format("http://+:{0}/", text_httpPort.Text));
                m_httpLis.Start();
                //接受请求
                for (int i = 0; i < m_httpThreadNumber; i++)
                {
                    Thread t = new Thread(delegate()
                    {
                        m_httpLis.BeginGetContext(new AsyncCallback(HTTPRun), null);
                    });
                    m_httpThreadList.Add(t);
                    t.Start();
                }
            }
            catch (Exception e)
            {
                but_star.IsEnabled = true;
                but_stop.IsEnabled = false;
                TCPStop();
                SysError.Error(e.Message);
            }
        }
        #endregion
        #region 运行
        /// <summary>
        /// 运行tcp服务
        /// </summary>
        void TCPRun(IAsyncResult iar)
        {
            Socket socket = (Socket)iar.AsyncState; ;
            if (socket != null)
            {
                try
                {
                    //定义全局数据字符串
                    string dataAll = "";
                    while (true)
                    {
                        if (socket.Poll(-1, SelectMode.SelectRead))
                        {
                            byte[] receiveBytes = new byte[socket.Available];
                            int nRead = socket.Receive(receiveBytes);
                            if (nRead == 0)
                            {
                                //远程连接主动断开
                                throw new SocketException();
                            }
                            else if (nRead != receiveBytes.Length)
                            {
                                //出现丢包，主动断开连接
                                throw new SocketException();
                            }
                            else
                            {
                                //解析成文本并拼到全局字符串中
                                dataAll += Encoding.UTF8.GetString(receiveBytes);
                                //删除“(”前的数据
                                int index = dataAll.IndexOf('(');
                                if (index < 0)
                                    dataAll = "";
                                else
                                    dataAll = dataAll.Substring(index);
                                //获取可处理的命令数组
                                string data = "";
                                MatchCollection mc = Regex.Matches(dataAll, "\\(.*?\\)", RegexOptions.IgnoreCase);
                                foreach(Match m in mc)
                                {
                                    data+=m.Value;
                                }
                                dataAll = dataAll.Substring(data.Length);
                                string[] dataArr = Regex.Split(data, "\\)\\(", RegexOptions.IgnoreCase);
                                //响应数据
                                List<string> sendDataList = new List<string>();
                                for (int i = 0; i < dataArr.Length; i++)
                                {
                                    //删除包头和包尾
                                    string receiveData = dataArr[i].Trim('(', ')');
                                    try
                                    {
                                        //取得协议版本号
                                        string version = Regex.Match(receiveData, "^.{3}").ToString();
                                        switch (version)
                                        {
                                            case "001":
                                                #region 协议1的处理代码（充电站）
                                                {
                                                    //取得充电站编号
                                                    string cs_id = Regex.Match(receiveData, "(?<=^.{3}).{10}").ToString();
                                                    if (!Regex.IsMatch(cs_id, @"^\d{6}\d{4}$"))
                                                    {
                                                        //数据出错，主动断开连接
                                                        throw new SocketException();
                                                    }
                                                    //取得校验位
                                                    string parity = Regex.Match(receiveData, "(?<=^.{13}).{4}").ToString();
                                                    //取得命令字
                                                    string number = Regex.Match(receiveData, "(?<=^.{17}).{6}").ToString();
                                                    //取得消息体
                                                    string bodyData = Regex.Match(receiveData, "(?<=^.{23}).*").ToString();
                                                    //校验
                                                    if (parity == CRC16.GetString(number + bodyData))
                                                    {
                                                        switch (number)
                                                        {
                                                            case "UP0001":
                                                                {
                                                                    //心跳
                                                                    string sendData = "";
                                                                    sendData = m_incTCPReceive001.UP0001(cs_id, bodyData, GetChargeStation(long.Parse(cs_id)));
                                                                    sendDataList.Add(sendData);
                                                                }
                                                                break;
                                                            case "UP0002":
                                                                {
                                                                    //登录
                                                                    string sendData = "";
                                                                    Dictionary<string, object> dic = m_incTCPReceive001.UP0002(ref cs_id, ref sendData, version, bodyData);
                                                                    if ((int)dic["condition"] == 1)
                                                                    {
                                                                        if (m_tcpCSClientDic.ContainsKey(cs_id))
                                                                        {
                                                                            TCPStop((Socket)m_tcpCSClientDic[cs_id]["socket"]);
                                                                        } 
                                                                        lock (m_tcpCSClientDic)
                                                                        {
                                                                            m_tcpCSClientDic.Add(cs_id, new Dictionary<string, object>());
                                                                        }
                                                                        m_tcpCSClientDic[cs_id].Add("socket", socket);//套接字
                                                                        m_tcpCSClientDic[cs_id].Add("version", version);//协议类型
                                                                        m_tcpCSClientDic[cs_id].Add("cs_id", cs_id);//充电站编号
                                                                        m_tcpCSClientDic[cs_id].Add("isglobal", dic["isglobal"]);//充电站是否全局账号
                                                                        m_tcpCSClientDic[cs_id].Add("data", GetChargeStation(long.Parse(cs_id)));//充电站数据
                                                                        //从socket队列中清除已使用socket
                                                                        lock (m_tcpSocketList)
                                                                        {
                                                                            m_tcpSocketList.Remove(socket);
                                                                        }
                                                                    }
                                                                    sendDataList.Add(sendData);
                                                                }
                                                                break;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        //丢包
                                                    }
                                                }
                                                break;
                                                #endregion
                                            case "002":
                                                #region 协议2的处理代码（交流桩）
                                                {
                                                    //取得充电站编号
                                                    string cs_id = Regex.Match(receiveData, "(?<=^.{3}).{10}").ToString();
                                                    if (!Regex.IsMatch(cs_id, @"^\d{6}\d{4}$"))
                                                    {
                                                        //数据出错，主动断开连接
                                                        throw new SocketException();
                                                    }
                                                    //取得充电桩编码
                                                    string cp_code = Regex.Match(receiveData, "(?<=^.{13}).{29}").ToString();
                                                    if (!Regex.IsMatch(cp_code, @"^EVC\d{2}JY[AD]\d{4}\d{4}\d{8}\d{5}$"))
                                                    {
                                                        //数据出错，主动断开连接
                                                        throw new SocketException();
                                                    }
                                                    //取得电池编码
                                                    string cb_code = Regex.Match(receiveData, "(?<=^.{42}).{32}").ToString();
                                                    //校验位
                                                    string parity = Regex.Match(receiveData, "(?<=^.{74}).{4}").ToString();
                                                    //取得命令字
                                                    string number = Regex.Match(receiveData, "(?<=^.{78}).{6}").ToString();
                                                    //取得消息体
                                                    string bodyData = Regex.Match(receiveData, "(?<=^.{84}).*").ToString();
                                                    //校验
                                                    if (parity == CRC16.GetString(number + bodyData))
                                                    {
                                                        //所有数据都会推送到全局账号的充电站中
                                                        Dictionary<string, Dictionary<string, object>> dic = new Dictionary<string, Dictionary<string, object>>();
                                                        lock (m_tcpCSClientDic)
                                                        {
                                                            dic = new Dictionary<string, Dictionary<string, object>>(m_tcpCSClientDic);
                                                        }
                                                        foreach (Dictionary<string, object> d in dic.Values)
                                                        {
                                                            if (d.ContainsKey("socket") && d.ContainsKey("isglobal") && (bool)d["isglobal"])
                                                                ((Socket)d["socket"]).Send(Encoding.UTF8.GetBytes("(" + receiveData + ")"));
                                                        }
                                                        //只要充电桩所在充电站连接存在，就将数据推送到充电站
                                                        if (m_tcpCSClientDic.ContainsKey(cs_id) && m_tcpCSClientDic[cs_id].ContainsKey("socket"))
                                                        {
                                                            ((Socket)m_tcpCSClientDic[cs_id]["socket"]).Send(Encoding.UTF8.GetBytes("(" + receiveData + ")"));
                                                        }
                                                        if (!string.IsNullOrEmpty(cs_id) && !string.IsNullOrEmpty(cp_code) && !string.IsNullOrEmpty(cb_code))
                                                        {
                                                            //初始化充电桩字典，只有当充电桩存在并且字典里没有该充电桩时才执行，只执行一次
                                                            if (!m_tcpClientDic.ContainsKey(cp_code))
                                                            {
                                                                lock (m_tcpClientDic)
                                                                {
                                                                    m_tcpClientDic.Add(cp_code, new Dictionary<string, object>());
                                                                }
                                                                m_tcpClientDic[cp_code].Add("version", version);//协议版本
                                                                m_tcpClientDic[cp_code].Add("socket", socket);//套接字
                                                                //获取充电桩数据
                                                                List<G_ChargePile> list = m_incChargePile.GetChargePile(long.Parse(cs_id), cp_code);
                                                                if (list.Count <= 0)
                                                                {
                                                                    throw new Exception("该充电桩不存在");
                                                                }
                                                                if (list[0].cp_chargemod != 1)
                                                                {
                                                                    throw new Exception("该充电桩不是交流桩");
                                                                }

                                                                Listener_ChargePile_Data_AC cp = new Listener_ChargePile_Data_AC();
                                                                cp.cs_id = long.Parse(cs_id);
                                                                cp.cp_id = (long)list[0].cp_id;
                                                                cp.cp_code = list[0].cp_code;
                                                                cp.t_id = (int)list[0].t_id;
                                                                cp.v_id = (int)list[0].v_id;
                                                                cp.condition = 1;
                                                                cp.gunnum = (int)list[0].cp_gunnum;
                                                                cp.chargemod = (int)list[0].cp_chargemod;
                                                                cp.unitmoney = (decimal)list[0].cp_money;
                                                                //根据枪数量定义数组长度，由于枪是1开始，所以加1
                                                                int length = (int)list[0].cp_gunnum+1;
                                                                cp.gundata = new Listener_ChargePile_GunData_AC[length];
                                                                for (int j = 0; j < length; j++)
                                                                {
                                                                    cp.gundata[j] = new Listener_ChargePile_GunData_AC();
                                                                }

                                                                m_tcpClientDic[cp_code].Add("data", cp);//充电桩数据
                                                                m_tcpClientDic[cp_code].Add("chargemod", cp.chargemod);//充电模式
                                                                //充电桩连接数+1
                                                                Listener_ChargeStation_Data mod = GetChargeStation(long.Parse(cs_id));
                                                                if (mod != null)
                                                                {
                                                                    mod.cpsum_ac = (int.Parse(mod.cpsum_ac) + 1).ToString();
                                                                }
                                                                else
                                                                {
                                                                    throw new Exception("充电站不存在");
                                                                }
                                                                //从socket队列中清除已使用socket
                                                                lock (m_tcpSocketList)
                                                                {
                                                                    m_tcpSocketList.Remove(socket);
                                                                }
                                                            }
                                                            //只要充电桩存在就更新字典，每次都会执行
                                                            if (m_tcpClientDic.ContainsKey(cp_code))
                                                            {
                                                                switch (number)
                                                                {
                                                                    case "UP0001":
                                                                        {
                                                                            //心跳
                                                                            string sendData = "";
                                                                            sendData = m_incTCPReceive002.UP0001(cp_code, cb_code, bodyData);
                                                                            if (!string.IsNullOrEmpty(sendData))
                                                                                sendDataList.Add(sendData);
                                                                        }
                                                                        break;
                                                                    case "UP0003":
                                                                        {
                                                                            //报警
                                                                            string sendData = "";
                                                                            sendData = m_incTCPReceive002.UP0003(cp_code, cb_code, bodyData);
                                                                            if (!string.IsNullOrEmpty(sendData))
                                                                                sendDataList.Add(sendData);
                                                                        }
                                                                        break;
                                                                    case "UP0005":
                                                                        {
                                                                            //刷卡请求
                                                                            string sendData = "";
                                                                            sendData = m_incTCPReceive002.UP0005(cp_code, cb_code, bodyData);
                                                                            if (!string.IsNullOrEmpty(sendData))
                                                                                sendDataList.Add(sendData);
                                                                        }
                                                                        break;
                                                                    case "UP0007":
                                                                        {
                                                                            //响应系统升级设置
                                                                            string sendData = "";
                                                                            sendData = m_incTCPReceive002.UP0007(cp_code, cb_code, bodyData);
                                                                            if (!string.IsNullOrEmpty(sendData))
                                                                                sendDataList.Add(sendData);
                                                                        }
                                                                        break;
                                                                    case "UP0009":
                                                                        {
                                                                            //结束充电命令
                                                                            string sendData = "";
                                                                            sendData = m_incTCPReceive002.UP0009(cp_code, cb_code, bodyData);
                                                                            if (!string.IsNullOrEmpty(sendData))
                                                                                sendDataList.Add(sendData);
                                                                        }
                                                                        break;
                                                                    case "UP0010":
                                                                        {
                                                                            //响应获取充电状态请求
                                                                            string sendData = "";
                                                                            sendData = m_incTCPReceive002.UP0010(cp_code, cb_code, bodyData);
                                                                            if (!string.IsNullOrEmpty(sendData))
                                                                                sendDataList.Add(sendData);
                                                                        }
                                                                        break;
                                                                    case "UP0012":
                                                                        {
                                                                            //获取服务器时间
                                                                            string sendData = "";
                                                                            sendData = m_incTCPReceive002.UP0012(cp_code, cb_code, bodyData);
                                                                            if (!string.IsNullOrEmpty(sendData))
                                                                                sendDataList.Add(sendData);
                                                                        }
                                                                        break;
                                                                    default:
                                                                        break;
                                                                }

                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        throw new Exception("校验失败");
                                                    }
                                                }
                                                break;
                                                #endregion
                                            case "003":
                                                #region 协议3的处理代码（直流桩）
                                                {
                                                    //取得充电站编号
                                                    string cs_id = Regex.Match(receiveData, "(?<=^.{3}).{10}").ToString();
                                                    if (!Regex.IsMatch(cs_id, @"^\d{6}\d{4}$"))
                                                    {
                                                        //数据出错，主动断开连接
                                                        throw new SocketException();
                                                    }
                                                    //取得充电桩编码
                                                    string cp_code = Regex.Match(receiveData, "(?<=^.{13}).{29}").ToString();
                                                    if (!Regex.IsMatch(cp_code, @"^EVC\d{2}JY[AD]\d{4}\\d{4}\d{8}\d{5}$"))
                                                    {
                                                        //数据出错，主动断开连接
                                                        throw new SocketException();
                                                    }
                                                    //取得电池编码
                                                    string cb_code = Regex.Match(receiveData, "(?<=^.{42}).{32}").ToString();
                                                    //校验位
                                                    string parity = Regex.Match(receiveData, "(?<=^.{74}).{4}").ToString();
                                                    //取得命令字
                                                    string number = Regex.Match(receiveData, "(?<=^.{78}).{6}").ToString();
                                                    //取得消息体
                                                    string bodyData = Regex.Match(receiveData, "(?<=^.{84}).*").ToString();
                                                    //校验
                                                    if (parity == CRC16.GetString(number + bodyData))
                                                    {
                                                        //所有数据都会推送到全局账号的充电站中
                                                        Dictionary<string, Dictionary<string, object>> dic = new Dictionary<string, Dictionary<string, object>>();
                                                        lock (m_tcpCSClientDic)
                                                        {
                                                            dic = new Dictionary<string, Dictionary<string, object>>(m_tcpCSClientDic);
                                                        }
                                                        foreach (Dictionary<string, object> d in dic.Values)
                                                        {
                                                            if (d.ContainsKey("socket") && d.ContainsKey("isglobal") && (bool)d["isglobal"])
                                                                ((Socket)d["socket"]).Send(Encoding.UTF8.GetBytes("(" + receiveData + ")"));
                                                        }
                                                        //只要充电桩所在充电站连接存在，就将数据推送到充电站
                                                        if (m_tcpCSClientDic.ContainsKey(cs_id) && m_tcpCSClientDic[cs_id].ContainsKey("socket"))
                                                        {
                                                            ((Socket)m_tcpCSClientDic[cs_id]["socket"]).Send(Encoding.UTF8.GetBytes("(" + receiveData + ")"));
                                                        }
                                                        if (!string.IsNullOrEmpty(cs_id) && !string.IsNullOrEmpty(cp_code) && !string.IsNullOrEmpty(cb_code))
                                                        {
                                                            //初始化充电桩字典，只有当充电桩存在并且字典里没有该充电桩时才执行，只执行一次
                                                            if (!m_tcpClientDic.ContainsKey(cp_code))
                                                            {
                                                                lock (m_tcpClientDic)
                                                                {
                                                                    m_tcpClientDic.Add(cp_code, new Dictionary<string, object>());
                                                                }
                                                                m_tcpClientDic[cp_code].Add("version", version);//协议版本
                                                                m_tcpClientDic[cp_code].Add("socket", socket);//套接字
                                                                //获取充电桩数据
                                                                List<G_ChargePile> list = m_incChargePile.GetChargePile(long.Parse(cs_id), cp_code);
                                                                if (list.Count <= 0)
                                                                {
                                                                    throw new Exception("该充电桩不存在");
                                                                }
                                                                if (list[0].cp_chargemod != 1)
                                                                {
                                                                    throw new Exception("该充电桩不是交流桩");
                                                                }

                                                                Listener_ChargePile_Data_DC cp = new Listener_ChargePile_Data_DC();
                                                                cp.cs_id = long.Parse(cs_id);
                                                                cp.cp_id = (long)list[0].cp_id;
                                                                cp.cp_code = list[0].cp_code;
                                                                cp.t_id = (int)list[0].t_id;
                                                                cp.v_id = (int)list[0].v_id;
                                                                cp.condition = 1;
                                                                cp.gunnum = (int)list[0].cp_gunnum;
                                                                cp.chargemod = (int)list[0].cp_chargemod;
                                                                cp.unitmoney = (decimal)list[0].cp_money;
                                                                //根据枪数量定义数组长度，由于枪是1开始，所以加1
                                                                int length = (int)list[0].cp_gunnum + 1;
                                                                cp.gundata = new Listener_ChargePile_GunData_DC[length];
                                                                for (int j = 0; j < length; j++)
                                                                {
                                                                    cp.gundata[j] = new Listener_ChargePile_GunData_DC();
                                                                }

                                                                m_tcpClientDic[cp_code].Add("data", cp);//充电桩数据
                                                                m_tcpClientDic[cp_code].Add("chargemod", cp.chargemod);//充电模式
                                                                //充电桩连接数+1
                                                                Listener_ChargeStation_Data mod = GetChargeStation(long.Parse(cs_id));
                                                                if (mod != null)
                                                                {
                                                                    mod.cpsum_dc = (int.Parse(mod.cpsum_dc) + 1).ToString();
                                                                }
                                                                else
                                                                {
                                                                    throw new Exception("充电站不存在");
                                                                }
                                                                //从socket队列中清除已使用socket
                                                                lock (m_tcpSocketList)
                                                                {
                                                                    m_tcpSocketList.Remove(socket);
                                                                }
                                                            }
                                                            //只要充电桩存在就更新字典，每次都会执行
                                                            if (m_tcpClientDic.ContainsKey(cp_code))
                                                            {
                                                                switch (number)
                                                                {
                                                                    case "UP0001":
                                                                        {
                                                                            //心跳
                                                                            string sendData = "";
                                                                            sendData = m_incTCPReceive003.UP0001(cp_code, cb_code, bodyData);
                                                                            if (!string.IsNullOrEmpty(sendData))
                                                                                sendDataList.Add(sendData);
                                                                        }
                                                                        break;
                                                                    case "UP0003":
                                                                        {
                                                                            //报警
                                                                            string sendData = "";
                                                                            sendData = m_incTCPReceive003.UP0003(cp_code, cb_code, bodyData);
                                                                            if (!string.IsNullOrEmpty(sendData))
                                                                                sendDataList.Add(sendData);
                                                                        }
                                                                        break;
                                                                    case "UP0005":
                                                                        {
                                                                            //刷卡请求
                                                                            string sendData = "";
                                                                            sendData = m_incTCPReceive003.UP0005(cp_code, cb_code, bodyData);
                                                                            if (!string.IsNullOrEmpty(sendData))
                                                                                sendDataList.Add(sendData);
                                                                        }
                                                                        break;
                                                                    case "UP0007":
                                                                        {
                                                                            //响应系统升级设置
                                                                            string sendData = "";
                                                                            sendData = m_incTCPReceive003.UP0007(cp_code, cb_code, bodyData);
                                                                            if (!string.IsNullOrEmpty(sendData))
                                                                                sendDataList.Add(sendData);
                                                                        }
                                                                        break;
                                                                    case "UP0009":
                                                                        {
                                                                            //结束充电命令
                                                                            string sendData = "";
                                                                            sendData = m_incTCPReceive003.UP0009(cp_code, cb_code, bodyData);
                                                                            if (!string.IsNullOrEmpty(sendData))
                                                                                sendDataList.Add(sendData);
                                                                        }
                                                                        break;
                                                                    case "UP0010":
                                                                        {
                                                                            //响应获取充电状态请求
                                                                            string sendData = "";
                                                                            sendData = m_incTCPReceive003.UP0010(cp_code, cb_code, bodyData);
                                                                            if (!string.IsNullOrEmpty(sendData))
                                                                                sendDataList.Add(sendData);
                                                                        }
                                                                        break;
                                                                    case "UP0012":
                                                                        {
                                                                            //获取服务器时间
                                                                            string sendData = "";
                                                                            sendData = m_incTCPReceive003.UP0012(cp_code, cb_code, bodyData);
                                                                            if (!string.IsNullOrEmpty(sendData))
                                                                                sendDataList.Add(sendData);
                                                                        }
                                                                        break;
                                                                    default:
                                                                        break;
                                                                }

                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        throw new Exception("校验失败");
                                                    }
                                                }
                                                break;
                                                #endregion
                                            default:
                                                //错误的协议版本号
                                                break;
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        throw e;
                                    }
                                }
                                //发送响应数据
                                if (sendDataList.Count > 0)
                                {
                                    socket.Send(Encoding.UTF8.GetBytes("(" + string.Join(")(", sendDataList) + ")"));
                                }
                            }
                        }
                        else
                        {
                            throw new SocketException();
                        }
                    }
                }
                catch (Exception e)
                {
                    //写日志
                    /*if (!m_isNormalClose)
                    {
                        AddSystemError(e, ((IPEndPoint)socket.RemoteEndPoint).Address.ToString(), ((IPEndPoint)socket.RemoteEndPoint).Port.ToString());
                    }*/
                    //断开连接
                    TCPStop(socket);
                }
            }
        }
        /// <summary>
        /// 运行tcp获取客户端数据统计
        /// </summary>
        void TCPGetClientDicCountRun()
        {
            //充电站连接数
            this.Dispatcher.Invoke(new Action(delegate()
            {
                lab_linknumCS.Text = m_tcpCSClientDic.Count.ToString();
            }));
            //充电桩连接数
            this.Dispatcher.Invoke(new Action(delegate()
            {
                lab_linknum.Text = m_tcpClientDic.Count.ToString();
            }));
            //无用socket连接数
            this.Dispatcher.Invoke(new Action(delegate()
            {
                lab_templinknum.Text = m_tcpSocketList.Count.ToString();
            }));
        }
        /// <summary>
        /// 运行http服务
        /// </summary>
        /// <param name="iar"></param>
        void HTTPRun(IAsyncResult iar)
        {
            try
            {
                HttpListenerContext hlc = m_httpLis.EndGetContext(iar);
                m_httpLis.BeginGetContext(new AsyncCallback(HTTPRun), null);
                //处理数据
                hlc.Response.StatusCode = 200;
                hlc.Response.AddHeader("Content-Type", "text/plain;charset=utf-8");
                string outputData = "";
                try
                {
                    string type = hlc.Request.QueryString["type"];
                    //处理下行命令
                    switch (type)
                    {
                        #region 充电站与服务器
                        //获取充电桩列表
                        case "UP0001":
                            {
                                string cs_id = hlc.Request.QueryString["cs_id"];
                                outputData = m_incHTTPReceive.UP0001(long.Parse(cs_id));
                            }
                            break;
                        //获取电池
                        case "UP0003":
                            {
                                string cb_code = hlc.Request.QueryString["cb_code"];
                                outputData = m_incHTTPReceive.UP0003(cb_code);
                            }
                            break;
                        //获取充电桩
                        case "UP0004":
                            {
                                string cs_id = hlc.Request.QueryString["cs_id"];
                                string cp_id = hlc.Request.QueryString["cp_id"];
                                outputData = m_incHTTPReceive.UP0004(long.Parse(cs_id), long.Parse(cp_id));
                            }
                            break;
                        //结束充电
                        case "UP0005":
                            {
                                string cs_id = hlc.Request.QueryString["cs_id"];
                                string cp_code = hlc.Request.QueryString["cp_code"];
                                string cp_guncode = hlc.Request.QueryString["cp_guncode"];
                                outputData = m_incHTTPReceive.UP0005(long.Parse(cs_id), cp_code, int.Parse(cp_guncode));
                            }
                            break;
                        //获取充电桩报警数据列表
                        case "UP0006":
                            {
                                string cs_id = hlc.Request.QueryString["cs_id"];
                                string cp_id = hlc.Request.QueryString["cp_id"];
                                string am_cimp_examine = hlc.Request.QueryString["am_cimp_examine"];
                                outputData = m_incHTTPReceive.UP0006(long.Parse(cs_id), long.Parse(cp_id), bool.Parse(am_cimp_examine));
                            }
                            break;
                        //处理充电桩报警数据
                        case "UP0007":
                            {
                                string cs_id = hlc.Request.QueryString["cs_id"];
                                string cp_id = hlc.Request.QueryString["cp_id"];
                                string am_cimp_id = hlc.Request.QueryString["am_cimp_id"];
                                string am_cimp_examine = hlc.Request.QueryString["am_cimp_examine"];
                                outputData = m_incHTTPReceive.UP0007(long.Parse(cs_id), long.Parse(cp_id), long.Parse(am_cimp_id), bool.Parse(am_cimp_examine));
                            }
                            break;
                        #endregion
                        #region 管理系统与服务器
                        //添加充电站后更新充电站数据
                        case "WEB0001":
                            {
                                string cs_id = hlc.Request.QueryString["cs_id"];
                                outputData = m_incHTTPReceive.WEB0001(long.Parse(cs_id), Dispatcher);
                            }
                            break;
                        //修改充电站后更新充电站数据
                        case "WEB0002":
                            {
                                string cs_id = hlc.Request.QueryString["cs_id"];
                                outputData = m_incHTTPReceive.WEB0002(long.Parse(cs_id));
                            }
                            break;
                        //删除/修改充电桩后断开连接
                        case "WEB0004":
                            {
                                string cp_code = hlc.Request.QueryString["cp_code"];
                                outputData = "<error name=\"API000\">" + SysError.GetErrorString("API000") + "</error>" +
                                    "<callback name=\"SYS000\">" + SysError.GetErrorString("SYS000") + "</callback>" +
                                    "<condition name=\"MANAGE004\">" + SysError.GetErrorString("MANAGE004") + "</condition>";
                                if (m_tcpClientDic.ContainsKey(cp_code) && m_tcpClientDic[cp_code].ContainsKey("socket"))
                                {
                                    TCPStop((Socket)m_tcpClientDic[cp_code]["socket"]);
                                    outputData = "<error name=\"API000\">" + SysError.GetErrorString("API000") + "</error>" +
                                        "<callback name=\"SYS000\">" + SysError.GetErrorString("SYS000") + "</callback>" +
                                        "<condition name=\"MANAGE000\">" + SysError.GetErrorString("MANAGE000") + "</condition>";
                                }
                                outputData = "<root>" + outputData + "</root>";
                            }
                            break;
                        //获取充电桩状态
                        case "WEB0005":
                            {
                                string cp_code = hlc.Request.QueryString["cp_code"];
                                outputData = "<error name=\"API000\">" + SysError.GetErrorString("API000") + "</error>" +
                                    "<callback name=\"SYS000\">" + SysError.GetErrorString("SYS000") + "</callback>" +
                                    "<condition name=\"SELECT001\">" + SysError.GetErrorString("SELECT001") + "</condition>";
                                if (m_tcpClientDic.ContainsKey(cp_code) && m_tcpClientDic[cp_code].ContainsKey("data"))
                                {
                                    try
                                    {
                                        Dictionary<string, object> tcpClientDic = m_tcpClientDic[cp_code];
                                        switch ((int)tcpClientDic["chargemod"])
                                        {
                                            case 1:
                                                {
                                                    Listener_ChargePile_Data_AC cp = (Listener_ChargePile_Data_AC)Config.g_tcpClientDic[cp_code]["data"];
                                                    outputData = "<error name=\"API000\">" + SysError.GetErrorString("API000") + "</error>" +
                                                        "<callback name=\"SYS000\">" + SysError.GetErrorString("SYS000") + "</callback>" +
                                                        "<condition name=\"SELECT000\">" + SysError.GetErrorString("SELECT000") + "</condition>" +
                                                        "<list>" +
                                                            "<cp_id>" + cp.cp_id + "</cp_id>" +
                                                            "<cp_code>" + cp.cp_code + "</cp_code>" +
                                                            "<condition>" + cp.condition + "</condition>" +
                                                            "<guncondition>" + string.Join("|", cp.gundata.Select(a => a.guncondition).ToArray()) + "</guncondition>" +
                                                            "<useruname>" + string.Join("|", cp.gundata.Select(a => a.useruname).ToArray()) + "</useruname>" +
                                                            "<chargemod>" + cp.chargemod + "</chargemod>" +
                                                            "<ispolice>" + string.Join("|", cp.gundata.Select(a => a.ispolice).ToArray()) + "</ispolice>" +
                                                            "<police>" + string.Join("|", cp.gundata.Select(a => a.police).ToArray()) + "</police>" +
                                                            "<policecode>" + string.Join("|", cp.gundata.Select(a => a.policecode).ToArray()) + "</policecode>" +
                                                            "<unitmoney>" + cp.unitmoney + "</unitmoney>" +
                                                        "</list>";
                                                }
                                                break;
                                            case 2:
                                                {
                                                    Listener_ChargePile_Data_DC cp = (Listener_ChargePile_Data_DC)Config.g_tcpClientDic[cp_code]["data"];
                                                    outputData = "<error name=\"API000\">" + SysError.GetErrorString("API000") + "</error>" +
                                                        "<callback name=\"SYS000\">" + SysError.GetErrorString("SYS000") + "</callback>" +
                                                        "<condition name=\"SELECT000\">" + SysError.GetErrorString("SELECT000") + "</condition>" +
                                                        "<list>" +
                                                            "<cp_id>" + cp.cp_id + "</cp_id>" +
                                                            "<cp_code>" + cp.cp_code + "</cp_code>" +
                                                            "<condition>" + cp.condition + "</condition>" +
                                                            "<guncondition>" + string.Join("|", cp.gundata.Select(a => a.guncondition).ToArray()) + "</guncondition>" +
                                                            "<useruname>" + string.Join("|", cp.gundata.Select(a => a.useruname).ToArray()) + "</useruname>" +
                                                            "<chargemod>" + cp.chargemod + "</chargemod>" +
                                                            "<ispolice>" + string.Join("|", cp.gundata.Select(a => a.ispolice).ToArray()) + "</ispolice>" +
                                                            "<police>" + string.Join("|", cp.gundata.Select(a => a.police).ToArray()) + "</police>" +
                                                            "<policecode>" + string.Join("|", cp.gundata.Select(a => a.policecode).ToArray()) + "</policecode>" +
                                                            "<unitmoney>" + cp.unitmoney + "</unitmoney>" +
                                                        "</list>";
                                                }
                                                break;
                                        }
                                    }
                                    catch(Exception e)
                                    {

                                        outputData = "<error name=\"API001\">" + SysError.GetErrorString("API001") + "</error>" +
                                            "<callback name=\"SYS003\">" + SysError.GetErrorString("SYS003") + "</callback>" +
                                            "<condition name=\"SELECT002\">" + e.Message + "</condition>";
                                    }
                                }
                                outputData = "<root>" + outputData + "</root>";
                            }
                            break;
                        #endregion
                        #region APP与服务器
                        //发送充电请求
                        case "APP0001":
                            {
                                string cs_id = hlc.Request.QueryString["cs_id"];
                                string cp_code = hlc.Request.QueryString["cp_code"];
                                string u_uname = hlc.Request.QueryString["u_uname"];
                                string u_id = hlc.Request.QueryString["u_id"];
                                string cp_guncode = hlc.Request.QueryString["cp_guncode"];
                                string calmod = hlc.Request.QueryString["calmod"];
                                string cal = hlc.Request.QueryString["cal"];
                                outputData = m_incHTTPReceive.APP0001(long.Parse(cs_id), cp_code, long.Parse(u_uname), long.Parse(u_id), int.Parse(cp_guncode), int.Parse(calmod), cal);
                            }
                            break;
                        //获取充电桩充电数据
                        case "APP0002":
                            {
                                string cp_code = hlc.Request.QueryString["cp_code"];
                                string cp_guncode = hlc.Request.QueryString["cp_guncode"];
                                string u_uname = hlc.Request.QueryString["u_uname"];
                                outputData = m_incHTTPReceive.APP0002(cp_code, int.Parse(cp_guncode), long.Parse(u_uname));
                            }
                            break;
                        //获取充电桩枪状态
                        case "APP0003":
                            {
                                string cp_code = hlc.Request.QueryString["cp_code"];
                                string u_uname = hlc.Request.QueryString["u_uname"];
                                outputData = m_incHTTPReceive.APP0003(cp_code, long.Parse(u_uname));
                            }
                            break;
                        //发送结束充电请求
                        case "APP0004":
                            {
                                string cs_id = hlc.Request.QueryString["cs_id"];
                                string cp_code = hlc.Request.QueryString["cp_code"];
                                string u_uname = hlc.Request.QueryString["u_uname"];
                                string u_id = hlc.Request.QueryString["u_id"];
                                string cp_guncode = hlc.Request.QueryString["cp_guncode"];
                                outputData = m_incHTTPReceive.APP0004(long.Parse(cs_id), cp_code, long.Parse(u_uname), long.Parse(u_id), int.Parse(cp_guncode));
                            }
                            break;
                        //获取用户充电状态
                        case "APP0005":
                            {
                                string u_uname = hlc.Request.QueryString["u_uname"];
                                string u_id = hlc.Request.QueryString["u_id"];
                                outputData = m_incHTTPReceive.APP0005(long.Parse(u_uname), long.Parse(u_id));
                            }
                            break;
                        //发送充电枪控制命令
                        case "APP0006":
                            {
                                string cp_code = hlc.Request.QueryString["cp_code"];
                                string cp_guncode = hlc.Request.QueryString["cp_guncode"];
                                string condition = hlc.Request.QueryString["condition"];
                                outputData = m_incHTTPReceive.APP0006(cp_code, int.Parse(cp_guncode), condition);
                            }
                            break;
                        //获取充电桩状态
                        case "APP0007":
                            {
                                string cp_code = hlc.Request.QueryString["cp_code"];
                                outputData = "<error name=\"API000\">" + SysError.GetErrorString("API000") + "</error>" +
                                    "<callback name=\"SYS000\">" + SysError.GetErrorString("SYS000") + "</callback>" +
                                    "<condition name=\"SELECT001\">" + SysError.GetErrorString("SELECT001") + "</condition>";
                                if (m_tcpClientDic.ContainsKey(cp_code) && m_tcpClientDic[cp_code].ContainsKey("data"))
                                {
                                    try
                                    {
                                        Dictionary<string, object> tcpClientDic = m_tcpClientDic[cp_code];
                                        switch ((int)tcpClientDic["chargemod"])
                                        {
                                            case 1:
                                                {
                                                    Listener_ChargePile_Data_AC cp = (Listener_ChargePile_Data_AC)Config.g_tcpClientDic[cp_code]["data"];
                                                    outputData = "<error name=\"API000\">" + SysError.GetErrorString("API000") + "</error>" +
                                                        "<callback name=\"SYS000\">" + SysError.GetErrorString("SYS000") + "</callback>" +
                                                        "<condition name=\"SELECT000\">" + SysError.GetErrorString("SELECT000") + "</condition>" +
                                                        "<list>" +
                                                            "<cp_id>" + cp.cp_id + "</cp_id>" +
                                                            "<cp_code>" + cp.cp_code + "</cp_code>" +
                                                            "<condition>" + cp.condition + "</condition>" +
                                                            "<guncondition>" + string.Join("|", cp.gundata.Select(a => a.guncondition).ToArray()) + "</guncondition>" +
                                                            "<useruname>" + string.Join("|", cp.gundata.Select(a => a.useruname).ToArray()) + "</useruname>" +
                                                            "<chargemod>" + cp.chargemod + "</chargemod>" +
                                                            "<ispolice>" + string.Join("|", cp.gundata.Select(a => a.ispolice).ToArray()) + "</ispolice>" +
                                                            "<police>" + string.Join("|", cp.gundata.Select(a => a.police).ToArray()) + "</police>" +
                                                            "<policecode>" + string.Join("|", cp.gundata.Select(a => a.policecode).ToArray()) + "</policecode>" +
                                                            "<unitmoney>" + cp.unitmoney + "</unitmoney>" +
                                                        "</list>";
                                                }
                                                break;
                                            case 2:
                                                {
                                                    Listener_ChargePile_Data_DC cp = (Listener_ChargePile_Data_DC)Config.g_tcpClientDic[cp_code]["data"];
                                                    outputData = "<error name=\"API000\">" + SysError.GetErrorString("API000") + "</error>" +
                                                        "<callback name=\"SYS000\">" + SysError.GetErrorString("SYS000") + "</callback>" +
                                                        "<condition name=\"SELECT000\">" + SysError.GetErrorString("SELECT000") + "</condition>" +
                                                        "<list>" +
                                                            "<cp_id>" + cp.cp_id + "</cp_id>" +
                                                            "<cp_code>" + cp.cp_code + "</cp_code>" +
                                                            "<condition>" + cp.condition + "</condition>" +
                                                            "<guncondition>" + string.Join("|", cp.gundata.Select(a => a.guncondition).ToArray()) + "</guncondition>" +
                                                            "<useruname>" + string.Join("|", cp.gundata.Select(a => a.useruname).ToArray()) + "</useruname>" +
                                                            "<chargemod>" + cp.chargemod + "</chargemod>" +
                                                            "<ispolice>" + string.Join("|", cp.gundata.Select(a => a.ispolice).ToArray()) + "</ispolice>" +
                                                            "<police>" + string.Join("|", cp.gundata.Select(a => a.police).ToArray()) + "</police>" +
                                                            "<policecode>" + string.Join("|", cp.gundata.Select(a => a.policecode).ToArray()) + "</policecode>" +
                                                            "<unitmoney>" + cp.unitmoney + "</unitmoney>" +
                                                        "</list>";
                                                }
                                                break;
                                        }
                                    }
                                    catch (Exception e)
                                    {

                                        outputData = "<error name=\"API001\">" + SysError.GetErrorString("API001") + "</error>" +
                                            "<callback name=\"SYS003\">" + SysError.GetErrorString("SYS003") + "</callback>" +
                                            "<condition name=\"SELECT002\">" + e.Message + "</condition>";
                                    }
                                }
                                outputData = "<root>" + outputData + "</root>";
                            }
                            break;
                        #endregion
                    }
                }
                catch { }
                //返回处理结果
                using (StreamWriter sw = new StreamWriter(hlc.Response.OutputStream))
                {
                    sw.Write(outputData);
                }
                hlc.Response.Close();
            }
            catch (Exception e)
            {
            }
        }
        #endregion
        #region 停止
        /// <summary>
        /// tcp停止服务
        /// </summary>
        void TCPStop()
        {
            //停止tcp
            try
            {
                m_tcpListener.Stop();
            }
            catch { }
            m_tcpListener = null;
            //清除线程池
            for (int i = 0; i < m_tcpThreadList.Count; i++)
            {
                try
                {
                    m_tcpThreadList[i].Abort();
                }
                catch { }
            }
            m_tcpThreadList.Clear();
            //清除客户端队列
            lock (m_tcpClientDic)
            {
                foreach (Dictionary<string, object> dic in m_tcpClientDic.Values)
                {
                    if (dic.ContainsKey("socket"))
                    {
                        Socket socket = (Socket)dic["socket"];
                        try
                        {
                            socket.Shutdown(SocketShutdown.Both);
                            socket.Disconnect(false);
                            socket.Dispose();
                            socket.Close();
                        }
                        catch { }
                    }
                    CleanTcpClientDic(dic);
                }
                m_tcpClientDic.Clear();
            }
            //清除充电站队列
            lock (m_tcpCSClientDic)
            {
                foreach (Dictionary<string, object> dic in m_tcpCSClientDic.Values)
                {
                    if (dic.ContainsKey("socket"))
                    {
                        Socket socket = (Socket)dic["socket"];
                        try
                        {
                            socket.Shutdown(SocketShutdown.Both);
                            socket.Disconnect(false);
                            socket.Dispose();
                            socket.Close();
                        }
                        catch { }
                    }
                    string cs_id = dic["cs_id"].ToString();
                    Listener_ChargeStation_Data mod = GetChargeStation(long.Parse(cs_id));
                    mod.hascs = "否";
                    mod.brush = Brushes.Black;
                }
                m_tcpCSClientDic.Clear();
            }
            //清除socket队列
            lock (m_tcpSocketList)
            {
                for (int i = 0; i < m_tcpSocketList.Count; i++)
                {
                    Socket socket = m_tcpSocketList[i];
                    try
                    {
                        socket.Shutdown(SocketShutdown.Both);
                        socket.Disconnect(false);
                        socket.Dispose();
                        socket.Close();
                    }
                    catch { }
                }
                m_tcpSocketList.Clear();
            }
        }
        /// <summary>
        /// tcp停止服务
        /// </summary>
        void TCPStop(Socket socket)
        {
            try
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Disconnect(false);
                socket.Dispose();
                socket.Close();
            }
            catch { }
            //从客户端队列中清除已删除客户端
            lock (m_tcpClientDic)
            {
                List<string> keys = new List<string>(m_tcpClientDic.Keys);
                for (int i = 0; i < keys.Count; i++)
                {
                    if (m_tcpClientDic[keys[i]].ContainsValue(socket))
                    {
                        CleanTcpClientDic(m_tcpClientDic[keys[i]]);
                    }
                    if (m_tcpClientDic[keys[i]].ContainsValue(socket))
                    {
                        m_tcpClientDic.Remove(keys[i]);
                        break;
                    }
                }
            }
            //从充电站队列中清除已删除充电站
            lock (m_tcpCSClientDic)
            {
                List<string> keys = new List<string>(m_tcpCSClientDic.Keys);
                for (int i = 0; i < keys.Count; i++)
                {
                    if (m_tcpCSClientDic[keys[i]].ContainsValue(socket))
                    {
                        string cs_id = m_tcpCSClientDic[keys[i]]["cs_id"].ToString();
                        Listener_ChargeStation_Data mod = GetChargeStation(long.Parse(cs_id));
                        mod.hascs = "否";
                        mod.brush = Brushes.Black;
                    }
                    if (m_tcpCSClientDic[keys[i]].ContainsValue(socket))
                    {
                        m_tcpCSClientDic.Remove(keys[i]);
                        break;
                    }
                }
            }
            //从socket队列中清除已删除socket
            lock (m_tcpSocketList)
            {
                m_tcpSocketList.Remove(socket);
            }
        }
        /// <summary>
        /// 清理m_tcpClientDic单条数据
        /// </summary>
        /// <param name="obj">单条m_tcpClientDic</param>
        void CleanTcpClientDic(Dictionary<string, object> dic)
        {
            try
            {
                int chargemod = (int)dic["chargemod"];
                switch (chargemod)
                {
                    //交流充电桩连接数-1
                    case 1:
                        {
                            Listener_ChargePile_Data_AC data = (Listener_ChargePile_Data_AC)dic["data"];
                            //控制服务器中充电站的数据，及将充电桩断线数据推送给充电站
                            bool b = false;
                            if (m_tcpCSClientDic.ContainsKey(data.cs_id.ToString()) && m_tcpCSClientDic[data.cs_id.ToString()].ContainsKey("socket"))
                            {
                                b = true;
                            }
                            Listener_ChargeStation_Data mod = GetChargeStation(data.cs_id);
                            mod.cpsum_ac = (int.Parse(mod.cpsum_ac) - 1).ToString();
                            if (b)
                            {
                                //通知充电站管理系统该桩断线
                                string sendData =
                                    "002" +
                                    data.cs_id +
                                    data.cp_code +
                                    "00000000000000000000000000000000" +
                                    "d6ca" +
                                    "UP0004";
                                ((Socket)m_tcpCSClientDic[data.cs_id.ToString()]["socket"]).Send(Encoding.UTF8.GetBytes("(" + sendData + ")"));
                            }
                        }
                        break;
                    //直流充电桩连接数-1
                    case 2:
                        {
                            Listener_ChargePile_Data_DC data = (Listener_ChargePile_Data_DC)dic["data"];
                            //控制服务器中充电站的数据，及将充电桩断线数据推送给充电站
                            bool b = false;
                            if (m_tcpCSClientDic.ContainsKey(data.cs_id.ToString()) && m_tcpCSClientDic[data.cs_id.ToString()].ContainsKey("socket"))
                            {
                                b = true;
                            }
                            Listener_ChargeStation_Data mod = GetChargeStation(data.cs_id);
                            mod.cpsum_dc = (int.Parse(mod.cpsum_dc) - 1).ToString();
                            if (b)
                            {
                                //通知充电站管理系统该桩断线
                                string sendData =
                                    "003" +
                                    data.cs_id +
                                    data.cp_code +
                                    "00000000000000000000000000000000" +
                                    "d6ca" +
                                    "UP0004";
                                ((Socket)m_tcpCSClientDic[data.cs_id.ToString()]["socket"]).Send(Encoding.UTF8.GetBytes("(" + sendData + ")"));
                            }
                        }
                        break;
                }
            }
            catch { }
        }
        /// <summary>
        /// 停止tcp获取客户端连接数
        /// </summary>
        void TCPGetClientDicCountStop()
        {
            if (m_tcpGetClienDicCountTimer != null)
            {
                m_tcpGetClienDicCountTimer.Dispose();
                m_tcpGetClienDicCountTimer = null;
            }
        }
        /// <summary>
        /// http停止服务
        /// </summary>
        void HTTPStop()
        {
            //停止http
            try
            {
                m_httpLis.Close();
            }
            catch { }
            m_httpLis = null;
            //清除http线程池
            for (int i = 0; i < m_httpThreadList.Count; i++)
            {
                try
                {
                    m_httpThreadList[i].Abort();
                }
                catch { }
            }
            m_httpThreadList.Clear();
        }
        #endregion
        #region 其他
        /// <summary>
        /// 获取单条充电站数据
        /// </summary>
        Listener_ChargeStation_Data GetChargeStation(long cs_id)
        {
            Listener_ChargeStation_Data mod = null;
            for (int i = 0; i < m_dataList.Count; i++)
            {
                if (m_dataList[i].csid == cs_id)
                {
                    mod = m_dataList[i];
                    break;
                }
            }
            return mod;
        }
        /// <summary>
        /// 写错误日志
        /// </summary>
        void AddSystemError(Exception e, params string[] arr)
        {
            LOG_SystemError mod = new LOG_SystemError();
            mod.log_se_stype = 2;
            mod.log_se_content = e.Message + " " + string.Join(" ", arr);
            mod.log_se_type = e.GetType().ToString();
            mod.log_se_information = e.TargetSite.ToString() + " " + e.StackTrace;
            m_incSystemError.AddSystemError(mod);
        }
        /// <summary>
        /// tcp发送
        /// </summary>
        void TCPSend(string cs1_e_code, string cs1_number, string cs1_bodyData)
        {
            
        }
        #endregion

        #endregion

        #region 事件
        /// <summary>
        /// 服务启动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_star_Click(object sender, RoutedEventArgs e)
        {
            m_isNormalClose = false;

            but_star.IsEnabled = false;
            but_stop.IsEnabled = true;
            TCPStart();
            TCPGetClientDicCountStar();
            HTTPStart();
        }
        /// <summary>
        /// 服务停止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_stop_Click(object sender, RoutedEventArgs e)
        {
            m_isNormalClose = true;

            but_star.IsEnabled = true;
            but_stop.IsEnabled = false;
            TCPStop();
            TCPGetClientDicCountStop();
            HTTPStop();
        }
        /// <summary>
        /// 窗口关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            MessageBoxResult mbr = MessageBox.Show("是否要关闭该程序？", "警告", MessageBoxButton.OKCancel, MessageBoxImage.Warning, MessageBoxResult.Cancel);
            if (mbr == MessageBoxResult.OK)
            {
                m_isNormalClose = true;

                TCPStop();
                TCPGetClientDicCountStop();
                Environment.Exit(0);
            }
        }
        /// <summary>
        /// 程序载入完成事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            but_star_Click(sender, e);
        }
        #endregion


    }
}
