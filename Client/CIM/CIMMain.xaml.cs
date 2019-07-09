using Client.App_Code;
using Client.App_Code.Include;
using Client.App_Code.Include.HTTP;
using Client.App_Code.Include.TCP;
using Controls;
using Microsoft.Windows.Themes;
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

namespace Client.CIM
{
    /// <summary>
    /// CIMMain.xaml 的交互逻辑
    /// </summary>
    public partial class CIMMain : Page
    {
        Include m_inc = new Include();
        IncludeHTTPSend m_incHTTPSend = new IncludeHTTPSend();
        IncludeCIMTCPReceive002 m_incCIMTCPReceive002 = new IncludeCIMTCPReceive002();
        IncludeCIMTCPReceive003 m_incCIMTCPReceive003 = new IncludeCIMTCPReceive003();

        public CIMMain()
        {
            InitializeComponent();
            Init();
            TCPGetClientDicCountStar();
        }
        #region 定义
        /// <summary>
        /// 状态（0正常）
        /// </summary>
        public int condition = 0;
        /// <summary>
        /// tcp有效客户端队列
        /// </summary>
        Dictionary<string, Dictionary<string, object>> m_tcpClientDic = Config.g_cimTcpClientDic;
        /// <summary>
        /// tcp获取客户端队列数
        /// </summary>
        System.Threading.Timer m_tcpGetClienDicCountTimer = null;

        #endregion

        #region 函数
        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        void Init()
        {
            this.Title = Config.g_title;//标题
            GetChargePileList();
        }
        /// <summary>
        /// 获取充电桩列表
        /// </summary>
        void GetChargePileList()
        {
            List<Models> list = m_incHTTPSend.UP001(Config.cs_id);
            Dictionary<long, ObservableCollection<Client_ChargePile_Data_AC>> dicAC = new Dictionary<long, ObservableCollection<Client_ChargePile_Data_AC>>();
            Dictionary<long, ObservableCollection<Client_ChargePile_Data_DC>> dicDC = new Dictionary<long, ObservableCollection<Client_ChargePile_Data_DC>>();
            for (int i = 0; i < list.Count; i++)
            {
                switch ((int)list[i].G_ChargePile.cp_chargemod)
                {
                    //交流
                    case 1:
                        {
                            Client_ChargePile_Data_AC cp = new Client_ChargePile_Data_AC();
                            cp.t_name = list[i].G_Type.t_name;
                            cp.v_name = list[i].G_Version.v_name;
                            cp.cp_name = list[i].G_ChargePile.cp_name;
                            cp.gunnum = (int)list[i].G_ChargePile.cp_gunnum;
                            cp.cs_id = (long)list[i].G_ChargePile.cs_id;
                            cp.cp_id = (long)list[i].G_ChargePile.cp_id;
                            cp.cp_code = list[i].G_ChargePile.cp_code;
                            cp.condition = 0;
                            cp.gunnum = (int)list[i].G_ChargePile.cp_gunnum;
                            cp.chargemod = (int)list[i].G_ChargePile.cp_chargemod;
                            cp.unitmoney = (decimal)list[i].G_ChargePile.cp_money;
                            cp.gundata = new ObservableCollection<Client_ChargePile_GunData_AC>();
                            for (int j = 0; j < cp.gunnum + 1; j++)
                            {
                                cp.gundata.Add(new Client_ChargePile_GunData_AC());
                            }
                            if (!dicAC.ContainsKey(cp.cs_id))
                            {
                                dicAC.Add(cp.cs_id, new ObservableCollection<Client_ChargePile_Data_AC>());
                            }
                            dicAC[cp.cs_id].Add(cp);

                            Dictionary<string, object> dic = new Dictionary<string, object>();
                            dic.Add("cp_code", list[i].G_ChargePile.cp_code);
                            dic.Add("chargemod", list[i].G_ChargePile.cp_chargemod);
                            dic.Add("data", cp);
                            m_tcpClientDic.Add(list[i].G_ChargePile.cp_code, dic);
                        }
                        break;
                    //直流
                    case 2:
                        {
                            Client_ChargePile_Data_DC cp = new Client_ChargePile_Data_DC();
                            cp.t_name = list[i].G_Type.t_name;
                            cp.v_name = list[i].G_Version.v_name;
                            cp.cp_name = list[i].G_ChargePile.cp_name;
                            cp.gunnum = (int)list[i].G_ChargePile.cp_gunnum;
                            cp.cs_id = (long)list[i].G_ChargePile.cs_id;
                            cp.cp_id = (long)list[i].G_ChargePile.cp_id;
                            cp.cp_code = list[i].G_ChargePile.cp_code;
                            cp.condition = 0;
                            cp.gunnum = (int)list[i].G_ChargePile.cp_gunnum;
                            cp.chargemod = (int)list[i].G_ChargePile.cp_chargemod;
                            cp.unitmoney = (decimal)list[i].G_ChargePile.cp_money;
                            cp.gundata = new ObservableCollection<Client_ChargePile_GunData_DC>();
                            for (int j = 0; j < cp.gunnum + 1; j++)
                            {
                                cp.gundata.Add(new Client_ChargePile_GunData_DC());
                            }
                            if (!dicDC.ContainsKey(cp.cs_id))
                            {
                                dicDC.Add(cp.cs_id, new ObservableCollection<Client_ChargePile_Data_DC>());
                            }
                            dicDC[cp.cs_id].Add(cp);

                            Dictionary<string, object> dic = new Dictionary<string, object>();
                            dic.Add("cp_code", list[i].G_ChargePile.cp_code);
                            dic.Add("chargemod", list[i].G_ChargePile.cp_chargemod);
                            dic.Add("data", cp);
                            m_tcpClientDic.Add(list[i].G_ChargePile.cp_code, dic);
                        }
                        break;
                }
            }
            //所有充电站编号
            List<long> csidList = new List<long>();
            //设置充电桩数据源
            int ac_count = 0;
            foreach (long key in dicAC.Keys)
            {
                ObservableCollection<Client_ChargePile_Data_AC> ac = dicAC[key];
                CIMShowPileList_AC cimdpl_ac_pilelist = new CIMShowPileList_AC();
                cimdpl_ac_pilelist.InternalElementMargin = new Thickness(0, 0, 38, 38);
                cimdpl_ac_pilelist.InternalElementMouseUp += cimdpl_ac_pilelist_InternalElementMouseUp;
                cimdpl_ac_pilelist.DataContext = ac;
                if (dicAC.Count > 1)
                {
                    TextBlock text = new TextBlock();
                    text.Text = "充电站编号：" + key;
                    text.FontSize = 16;
                    text.Foreground = Brushes.White;
                    text.Margin = new Thickness(0, 0, 0, 38);
                    sp_ac.Children.Add(text);
                }
                sp_ac.Children.Add(cimdpl_ac_pilelist);
                ac_count += ac.Count;

                csidList.Add(key);
            }
            text_acNum.Text = ac_count.ToString();
            int dc_count = 0;
            foreach (long key in dicDC.Keys)
            {
                ObservableCollection<Client_ChargePile_Data_DC> dc = dicDC[key];
                CIMShowPileList_DC cimdpl_dc_pilelist = new CIMShowPileList_DC();
                cimdpl_dc_pilelist.InternalElementMargin = new Thickness(0, 0, 38, 38);
                cimdpl_dc_pilelist.InternalElementMouseUp += cimdpl_dc_pilelist_InternalElementMouseUp;
                cimdpl_dc_pilelist.DataContext = dc;
                if (dicDC.Count > 1)
                {
                    TextBlock text = new TextBlock();
                    text.Text = "充电站编号：" + key;
                    text.FontSize = 16;
                    text.Foreground = Brushes.White;
                    text.Margin = new Thickness(0, 0, 0, 38);
                    sp_dc.Children.Add(text);
                }
                sp_dc.Children.Add(cimdpl_dc_pilelist);
                dc_count += dc.Count;

                csidList.Add(key);
            }
            text_dcNum.Text = dc_count.ToString();

            //设置报警状态
            if (m_tcpClientDic.Count > 0)
            {
                long[] csidArr = csidList.Distinct().ToArray();
                List<AM_CIMPolice> list2 = new List<AM_CIMPolice>();
                for (int i = 0; i < csidArr.Length; i++)
                {
                    list2.AddRange(m_incHTTPSend.UP006(csidArr[i], 0, false));
                }
                for (int i = 0; i < list2.Count; i++)
                {
                    if(m_tcpClientDic.ContainsKey(list2[i].cp_code))
                    {
                        Dictionary<string, object> tcpClientDic = m_tcpClientDic[list2[i].cp_code];
                        int chargemod = (int)tcpClientDic["chargemod"];
                        switch (chargemod)
                        {
                            case 1:
                                {
                                    Client_ChargePile_Data_AC data = (Client_ChargePile_Data_AC)tcpClientDic["data"];
                                    data.gundata[(int)list2[i].cp_guncode].ispolice = true;
                                    data.ispolice = true;
                                }
                                break;
                            case 2:
                                {
                                    Client_ChargePile_Data_DC data = (Client_ChargePile_Data_DC)tcpClientDic["data"];
                                    data.gundata[(int)list2[i].cp_guncode].ispolice = true;
                                    data.ispolice = true;
                                }
                                break;
                        }
                    }
                }
            }
        }
        #endregion
        #region 开始
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
        #endregion
        #region 运行
        /// <summary>
        /// 协议2的处理方法
        /// </summary>
        public void TCPRun002(string receiveData)
        {
            try
            {
                //取得充电站编号
                string cs_id = Regex.Match(receiveData, "(?<=^.{3}).{10}").ToString();
                //取得充电桩编码
                string cp_code = Regex.Match(receiveData, "(?<=^.{13}).{29}").ToString();
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
                    //只要充电桩存在就更新字典，每次都会执行
                    if (m_tcpClientDic.ContainsKey(cp_code) && m_tcpClientDic[cp_code].ContainsKey("data"))
                    {
                        //解析消息体
                        Client_ChargePile_Data_AC cimdplMod = (Client_ChargePile_Data_AC)m_tcpClientDic[cp_code]["data"];
                        try
                        {
                            if (cimdplMod != null)
                            {
                                switch (number)
                                {
                                    case "UP0001":
                                        {
                                            //心跳
                                            string sendData = "";
                                            sendData = m_incCIMTCPReceive002.UP0001(cp_code, cb_code, bodyData);
                                        }
                                        break;
                                    case "UP0003":
                                        {
                                            //报警
                                            string sendData = "";
                                            sendData = m_incCIMTCPReceive002.UP0003(cp_code, bodyData);
                                        }
                                        break;
                                    case "UP0004":
                                        {
                                            //设置断线
                                            string sendData = "";
                                            sendData = m_incCIMTCPReceive002.UP0004(cp_code, bodyData);
                                        }
                                        break;
                                    case "UP0009":
                                        {
                                            //结束充电命令
                                            string sendData = "";
                                            sendData = m_incCIMTCPReceive002.UP0009(cp_code, bodyData);
                                        }
                                        break;
                                    case "UP0010":
                                        {
                                            //响应获取充电状态请求
                                            string sendData = "";
                                            sendData = m_incCIMTCPReceive002.UP0010(cp_code, bodyData);
                                        }
                                        break;
                                    default:
                                        break;
                                }

                            }
                        }
                        catch
                        {
                            //将充电桩标示为断开连接
                            if (cimdplMod != null)
                                try
                                {
                                    cimdplMod.condition = 0;
                                    cimdplMod.ispolice = false;
                                }
                                catch { }
                        }
                    }
                }
            }
            catch
            {
                
            }
            
        }
        /// <summary>
        /// 协议3的处理方法
        /// </summary>
        public void TCPRun003(string receiveData)
        {
            try
            {
                //取得充电站编号
                string cs_id = Regex.Match(receiveData, "(?<=^.{3}).{10}").ToString();
                //取得充电桩编码
                string cp_code = Regex.Match(receiveData, "(?<=^.{13}).{29}").ToString();
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
                    //只要充电桩存在就更新字典，每次都会执行
                    if (m_tcpClientDic.ContainsKey(cp_code) && m_tcpClientDic[cp_code].ContainsKey("data"))
                    {
                        //解析消息体
                        Client_ChargePile_Data_DC cimdplMod = (Client_ChargePile_Data_DC)m_tcpClientDic[cp_code]["data"];
                        try
                        {
                            if (cimdplMod != null)
                            {
                                switch (number)
                                {
                                    case "UP0001":
                                        {
                                            //心跳
                                            string sendData = "";
                                            sendData = m_incCIMTCPReceive003.UP0001(cp_code, cb_code, bodyData);
                                        }
                                        break;
                                    case "UP0003":
                                        {
                                            //报警
                                            string sendData = "";
                                            sendData = m_incCIMTCPReceive003.UP0003(cp_code, bodyData);
                                        }
                                        break;
                                    case "UP0004":
                                        {
                                            //设置断线
                                            string sendData = "";
                                            sendData = m_incCIMTCPReceive003.UP0004(cp_code, bodyData);
                                        }
                                        break;
                                    case "UP0009":
                                        {
                                            //结束充电命令
                                            string sendData = "";
                                            sendData = m_incCIMTCPReceive003.UP0009(cp_code, bodyData);
                                        }
                                        break;
                                    case "UP0010":
                                        {
                                            //响应获取充电状态请求
                                            string sendData = "";
                                            sendData = m_incCIMTCPReceive003.UP0010(cp_code, bodyData);
                                        }
                                        break;
                                    default:
                                        break;
                                }

                            }
                        }
                        catch
                        {
                            //将充电桩标示为断开连接
                            if (cimdplMod != null)
                                try
                                {
                                    cimdplMod.condition = 0;
                                    cimdplMod.ispolice = false;
                                }
                                catch { }
                        }
                    }
                }
            }
            catch
            {

            }

        }
        /// <summary>
        /// 运行tcp获取客户端数据统计
        /// </summary>
        void TCPGetClientDicCountRun()
        {
            this.Dispatcher.Invoke(new Action(delegate()
            {
                Dictionary<string, int> m_pileinformation = new Dictionary<string, int>() { 
                    {"text_pilesum", 0},//充电桩总数
                    {"text_pileiscd", 0},//已连接已充电
                    {"text_pilenocd", 0},//已连接未充电
                    {"text_pilenolink", 0},//未连接未充电
                    {"text_pilepolice", 0}//异常
                };
                Dictionary<string, Dictionary<string, object>> tcpClientDic = null;
                lock (m_tcpClientDic)
                {
                    tcpClientDic = new Dictionary<string, Dictionary<string, object>>(m_tcpClientDic);
                }
                if (tcpClientDic != null)
                {
                    m_pileinformation["text_pilesum"] = tcpClientDic.Count;
                    foreach (Dictionary<string, object> dic in tcpClientDic.Values)
                    {
                        int chargemod = (int)dic["chargemod"];
                        int condition = 0;
                        bool ispolice = false;
                        switch (chargemod)
                        {
                            case 1:
                                {
                                    Client_ChargePile_Data_AC mod = (Client_ChargePile_Data_AC)dic["data"];
                                    condition = mod.condition;
                                    ispolice = mod.ispolice;
                                }
                                break;
                            case 2:
                                {
                                    Client_ChargePile_Data_DC mod = (Client_ChargePile_Data_DC)dic["data"];
                                    condition = mod.condition;
                                    ispolice = mod.ispolice;
                                }
                                break;
                        }
                        switch (condition)
                        {
                            case 0:
                                {
                                    ++m_pileinformation["text_pilenolink"];
                                    break;
                                }
                            case 1:
                                {
                                    ++m_pileinformation["text_pilenocd"];
                                    break;
                                }
                            case 2:
                                {
                                    ++m_pileinformation["text_pileiscd"];
                                    break;
                                }
                        }
                        if (ispolice)
                        {
                            ++m_pileinformation["text_pilepolice"];
                        }
                    }
                }
                text_pilesum.Text = m_pileinformation["text_pilesum"].ToString();
                text_pileiscd.Text = m_pileinformation["text_pileiscd"].ToString();
                text_pilenocd.Text = m_pileinformation["text_pilenocd"].ToString();
                text_pilenolink.Text = m_pileinformation["text_pilenolink"].ToString();
                text_pilepolice.Text = m_pileinformation["text_pilepolice"].ToString();
            }));
        }
        #endregion
        #region 停止
        /// <summary>
        /// tcp停止服务
        /// </summary>
        void TCPStop()
        {
            //清除客户端队列
            lock (m_tcpClientDic)
            {
                foreach (Dictionary<string, object> dic in m_tcpClientDic.Values)
                {
                    try
                    {
                        if (dic.ContainsKey("socket"))
                        {
                            Socket socket = (Socket)dic["socket"];
                            socket.Shutdown(SocketShutdown.Both);
                            socket.Disconnect(false);
                            socket.Dispose();
                            socket.Close();
                        }
                    }
                    catch { }
                }
                m_tcpClientDic.Clear();
            }
        }
        /// <summary>
        /// tcp停止服务
        /// </summary>
        void TCPStop(Socket socket)
        {
            //从客户端队列中清除已删除客户端
            lock (m_tcpClientDic)
            {
                List<string> keys = new List<string>(m_tcpClientDic.Keys);
                for (int i = 0; i < keys.Count; i++)
                {
                    if (m_tcpClientDic[keys[i]].ContainsValue(socket))
                    {
                        m_tcpClientDic.Remove(keys[i]);
                        break;
                    }
                }
            }
        }
        /// <summary>
        /// 关闭页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CIMMain_Close()
        {
            TCPStop();
        }
        #endregion
        #region 其他
        /// <summary>
        /// tcp发送
        /// </summary>
        void TCPSend(string cs1_cp_code, string cs1_number, string cs1_bodyData)
        {
            try
            {
                if (cs1_cp_code != null && m_tcpClientDic.ContainsKey(cs1_cp_code))
                {
                    if (!m_tcpClientDic[cs1_cp_code].ContainsKey("socket"))
                    {
                        throw new Exception("socket不存在");
                    }
                    if (!m_tcpClientDic[cs1_cp_code].ContainsKey("version"))
                    {
                        throw new Exception("版本号不存在");
                    }
                    if (!m_tcpClientDic[cs1_cp_code].ContainsKey("cs_id"))
                    {
                        throw new Exception("充电站编码不存在");
                    }
                    if (!m_tcpClientDic[cs1_cp_code].ContainsKey("cp_code"))
                    {
                        throw new Exception("充电桩编码不存在");
                    }
                    if (!m_tcpClientDic[cs1_cp_code].ContainsKey("cb_code"))
                    {
                        throw new Exception("电池编码不存在");
                    }
                    Socket socket = (Socket)m_tcpClientDic[cs1_cp_code]["socket"];
                    string sendData = m_tcpClientDic[cs1_cp_code]["version"].ToString() +
                        m_tcpClientDic[cs1_cp_code]["cs_id"] +
                        m_tcpClientDic[cs1_cp_code]["cp_code"] +
                        m_tcpClientDic[cs1_cp_code]["cb_code"] +
                        cs1_number + cs1_bodyData;
                    socket.Send(Encoding.UTF8.GetBytes(sendData));
                    MessageBox.Show("发送成功", "提示", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                }
                else
                {
                    throw new Exception("充电桩不存在");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "错误", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }
        }
        #endregion

        #endregion

        #region 事件
        /// <summary>
        /// 选项卡切换（直流）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dp_dc_MouseUp(object sender, MouseButtonEventArgs e)
        {
            dp_ac.Background = null;
            text_acNum.Foreground = new SolidColorBrush(Color.FromRgb(97, 97, 97));
            sv_ac.Visibility = System.Windows.Visibility.Hidden;

            dp_dc.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Client;component/Resources/cim_left_1.png")));
            text_dcNum.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            sv_dc.Visibility = System.Windows.Visibility.Visible;
        }
        /// <summary>
        /// 选项卡切换（交流）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dp_ac_MouseUp(object sender, MouseButtonEventArgs e)
        {
            dp_dc.Background = null;
            text_dcNum.Foreground = new SolidColorBrush(Color.FromRgb(97, 97, 97));
            sv_dc.Visibility = System.Windows.Visibility.Hidden;

            dp_ac.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Client;component/Resources/cim_left_1.png")));
            text_acNum.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            sv_ac.Visibility = System.Windows.Visibility.Visible;
        }
        /// <summary>
        /// 列表单个点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cimdpl_dc_pilelist_InternalElementMouseUp(object sender, MouseButtonEventArgs e)
        {
            CIMShow_DC cimshow = new CIMShow_DC();
            cimshow.Tag = ((Control)sender).DataContext;
            cimshow.Show();
        }
        /// <summary>
        /// 列表单个点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cimdpl_ac_pilelist_InternalElementMouseUp(object sender, MouseButtonEventArgs e)
        {
            CIMShow_AC cimshow = new CIMShow_AC();
            cimshow.Tag = ((Control)sender).DataContext;
            cimshow.Show();
        }
        /// <summary>
        /// 打开右键菜单事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_chargepile_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            /*if(dgv_chargepile.SelectedIndex!=-1){
                DataGridRow dgr = (DataGridRow)dgv_chargepile.ItemContainerGenerator.ContainerFromIndex(dgv_chargepile.SelectedIndex);
                if (dgr.IsMouseOver)
                {
                    Client_CIMMain_DataGrid mod = (Client_CIMMain_DataGrid)dgv_chargepile.SelectedItem;
                    if (mod.brush == Brushes.Gray)
                    {
                        for (int i = 0; i < dgv_chargepile.ContextMenu.Items.Count; i++)
                        {
                            ((MenuItem)dgv_chargepile.ContextMenu.Items[i]).IsEnabled = false;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < dgv_chargepile.ContextMenu.Items.Count; i++)
                        {
                            ((MenuItem)dgv_chargepile.ContextMenu.Items[i]).IsEnabled = true;
                        }
                    }
                }
                else
                {
                    e.Handled = true;
                }
            }else{
                e.Handled = true;
            }*/
        }
        #endregion
        

    }
}
