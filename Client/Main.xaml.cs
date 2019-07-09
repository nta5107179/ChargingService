using Client.App_Code;
using Client.App_Code.Include;
using Client.App_Code.Include.TCP;
using Client.CIM;
using Client.FFM;
using Client.PDM;
using Client.SEM;
using Model;
using Model.Project;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Client
{
    /// <summary>
    /// Main.xaml 的交互逻辑
    /// </summary>
    public partial class Main : Window
    {
        IncludeChargePile m_incChargePile = new IncludeChargePile();
        IncludeTCPSend001 m_incTCPSend001 = new IncludeTCPSend001();
        IncludeTCPReceive001 m_incTCPReceive001 = new IncludeTCPReceive001();

        public Main()
        {
            InitializeComponent();
            Init();
        }

        #region 定义
        CIMMain m_cim = new CIMMain();
        PDMMain m_pdm = new PDMMain();
        FFMMain m_ffm = new FFMMain();
        SEMMain m_sem = new SEMMain();

        /// <summary>
        /// 是否主动关闭
        /// </summary>
        bool m_isActiveClose = false;
        /// <summary>
        /// tcp线程
        /// </summary>
        Thread m_tcpThread = null;
        /// <summary>
        /// tcp心跳间隔
        /// </summary>
        int m_tcpHeartInterval = 2000;
        #endregion

        #region 函数
        #region 开始
        /// <summary>
        /// 初始化
        /// </summary>
        void Init()
        {
            this.Title = Config.g_title;//标题
            WindowHook.RepairWindowBehavior(this);

            //充电监控
            Frame cim = (Frame)FindName("frame_cim");
            cim.Content = m_cim;
            OpenCIM();
            //配电监控
            Frame pdm = (Frame)FindName("frame_pdm");
            pdm.Content = m_pdm;
            //安防监控
            Frame sem = (Frame)FindName("frame_sem");
            sem.Content = m_sem;
            //消防监控
            Frame ffm = (Frame)FindName("frame_ffm");
            ffm.Content = m_ffm;

            TCPStar();
        }
        /// <summary>
        /// 开始tcp连接
        /// </summary>
        void TCPStar()
        {
            //开始监听
            if (Config.g_tcpClient.Connected)
            {
                m_tcpThread = new Thread(delegate()
                {
                    try
                    {
                        while (true)
                        {
                            //发送心跳
                            m_incTCPSend001.UP0001(Config.cs_id,
                                m_cim.condition, m_pdm.condition, m_sem.condition, m_ffm.condition);
                            
                            if (Config.g_socket.Poll(-1, SelectMode.SelectRead))
                            {
                                byte[] receiveBytes = new byte[Config.g_socket.Available];
                                int nRead = Config.g_socket.Receive(receiveBytes);
                                if (nRead == 0)
                                {
                                    throw new Exception("远程连接主动断开");
                                }
                                else if (nRead != receiveBytes.Length)
                                {
                                    throw new Exception("出现丢包，主动断开连接");
                                }
                                else
                                {
                                    //解析成文本
                                    string data = Encoding.UTF8.GetString(receiveBytes);
                                    //获取命令
                                    string[] dataArr = Regex.Split(data, "\\)\\(", RegexOptions.IgnoreCase);
                                    for (int i = 0; i < dataArr.Length; i++)
                                    {
                                        //删除包头和包尾
                                        string receiveData = dataArr[i].Trim('(', ')');
                                        //取得协议版本号
                                        string version = Regex.Match(receiveData, "^.{3}").ToString();
                                        //取得充电站编号
                                        string csid = Regex.Match(receiveData, "(?<=^.{3}).{10}").ToString();
                                        switch (version)
                                        {
                                            case "001":
                                                {
                                                    #region 协议1的处理代码，充电站与服务器通信数据
                                                    //取得校验位
                                                    string parity = Regex.Match(receiveData, "(?<=^.{13}).{4}").ToString();
                                                    //取得命令字
                                                    string number = Regex.Match(receiveData, "(?<=^.{17}).{6}").ToString();
                                                    //取得消息体
                                                    string bodyData = Regex.Match(receiveData, "(?<=^.{23}).*").ToString();
                                                    //校验
                                                    if (parity == CRC16.GetString(number + bodyData))
                                                    {
                                                        //解析消息体
                                                        switch (number)
                                                        {
                                                            case "DW0001":
                                                                {
                                                                    //响应心跳
                                                                    if (m_incTCPReceive001.DW0001(bodyData))
                                                                    {
                                                                        this.Dispatcher.Invoke(new Action(delegate()
                                                                        {
                                                                            text_isol.Text = "在线";
                                                                            text_isol.Foreground = Brushes.Green;
                                                                        }));
                                                                    }
                                                                }
                                                                break;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        //丢包
                                                    } 
                                                    #endregion
                                                }
                                                break;
                                            case "002":
                                                {
                                                    #region 协议2的处理代码，服务器转发的交流充电桩的数据
                                                    m_cim.TCPRun002(receiveData);
                                                    #endregion
                                                }
                                                break;
                                            case "003":
                                                {
                                                    #region 协议3的处理代码，服务器转发的直流充电桩的数据
                                                    m_cim.TCPRun003(receiveData);
                                                    #endregion
                                                }
                                                break;
                                            default:
                                                //错误的协议
                                                break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                throw new Exception("远程连接主动断开");
                            }
                            Thread.Sleep(m_tcpHeartInterval);
                        }
                    }
                    catch
                    {
                        TCPStop();
                        this.Dispatcher.Invoke(new Action(delegate()
                        {
                            MessageBox.Show(this, "与服务器连接断开，请重新登录！", "错误", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                            WindowClose();
                        }));
                        //重新连接
                        /*this.Dispatcher.Invoke(new Action(delegate()
                        {
                            text_isol.Text = "离线，正在尝试重新连接...";
                            text_isol.Foreground = Brushes.Red;
                        }));
                        #region 重新登录
                        while (Config.g_tcpClient == null || Config.g_socket == null)
                        {
                            Thread.Sleep(10000);
                            //连接远程服务器
                            try
                            {
                                Config.g_tcpClient = new TcpClient();
                                Config.g_tcpClient.Connect(Config.g_tcpIpendpoint);
                                Config.g_socket = Config.g_tcpClient.Client;
                            }
                            catch { }
                            //开始监听
                            if (Config.g_socket != null)
                            {
                                m_incTCPSend001.UP0002(Config.cs_uname, Config.cs_pwd);
                                try
                                {
                                    if (Config.g_socket.Poll(-1, SelectMode.SelectRead))
                                    {
                                        byte[] receiveBytes = new byte[Config.g_socket.Available];
                                        int nRead = Config.g_socket.Receive(receiveBytes);
                                        if (nRead == 0)
                                        {
                                            throw new Exception("远程连接主动断开");
                                        }
                                        else if (nRead != receiveBytes.Length)
                                        {
                                            throw new Exception("出现丢包，主动断开连接");
                                        }
                                        else
                                        {
                                            //解析成文本
                                            string data = Encoding.UTF8.GetString(receiveBytes);
                                            //获取命令
                                            string[] dataArr = Regex.Split(data, "\\)\\(", RegexOptions.IgnoreCase);
                                            for (int i = 0; i < dataArr.Length; i++)
                                            {
                                                //删除包头和包尾
                                                string receiveData = dataArr[i].Trim('(', ')');
                                                //取得协议版本号
                                                string version = Regex.Match(receiveData, "^.{3}").ToString();
                                                //取得充电站编号
                                                string csid = Regex.Match(receiveData, "(?<=^.{3}).{10}").ToString();
                                                if (version == "001")
                                                {
                                                    //取得校验位
                                                    string parity = Regex.Match(receiveData, "(?<=^.{13}).{4}").ToString();
                                                    //取得命令字
                                                    string number = Regex.Match(receiveData, "(?<=^.{17}).{6}").ToString();
                                                    //取得消息体
                                                    string bodyData = Regex.Match(receiveData, "(?<=^.{23}).*").ToString();
                                                    if (parity == CRC16.GetString(number + bodyData))
                                                    {
                                                        if (number == "DW0002")
                                                        {
                                                            //功能请求
                                                            MatchCollection arr = Regex.Matches(bodyData, @"(?<=\[)[^\]]*(?=\])");
                                                            //登录
                                                            string UP_0 = arr[0].Value;//是否成功
                                                            string UP_1 = arr[1].Value;//成功或失败码
                                                            if (UP_0 == "1")
                                                            {
                                                                //登录成功
                                                                Config.cs_id = long.Parse(csid);
                                                            }
                                                            else
                                                            {
                                                                //登录失败
                                                                throw new Exception("登录失败");
                                                            }
                                                        }
                                                        else
                                                        {
                                                            throw new Exception("错误的命令");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        throw new Exception("丢包");
                                                    }
                                                }
                                                else
                                                {
                                                    throw new Exception("错误的协议");
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        throw new Exception("远程连接主动断开");
                                    }
                                }
                                catch
                                {
                                    TCPStop();
                                }
                            }
                        } 
                        #endregion
                        TCPStar();*/
                    }
                });
                m_tcpThread.Start();
            }
        }
        #endregion

        #region 停止
        /// <summary>
        /// 停止tcp连接
        /// </summary>
        void TCPStop()
        {
            try
            {
                Config.g_socket.Shutdown(SocketShutdown.Both);
                Config.g_socket.Disconnect(false);
                Config.g_socket.Dispose();
                Config.g_socket.Close();
            }
            catch { }
            try
            {
                Config.g_tcpClient.Close();
            }
            catch { }
            Config.g_socket = null;
            Config.g_tcpClient = null;
        }
        #endregion

        #region 充电监控
        /// <summary>
        /// 打开充电监控
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void img_intcim_MouseUp(object sender, MouseButtonEventArgs e)
        {
            OpenCIM();
        }
        void OpenCIM()
        {
            Frame f = (Frame)FindName("frame_cim");
            f.Visibility = System.Windows.Visibility.Visible;
            f.Content = m_cim;
        }
        #endregion
        #endregion

        #region 事件
        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            MessageBoxResult mbr = MessageBox.Show("是否要关闭该程序？", "警告", MessageBoxButton.OKCancel, MessageBoxImage.Warning, MessageBoxResult.Cancel);
            
            if (mbr == MessageBoxResult.OK)
            {
                WindowClose();
            }
        }
        /// <summary>
        /// 关闭窗口
        /// </summary>
        private void WindowClose()
        {
            m_cim.CIMMain_Close();
            m_ffm.FFMMain_Close();
            m_pdm.PDMMain_Close();
            m_sem.SEMMain_Close();
            TCPStop();
            Environment.Exit(0);
        }
        /// <summary>
        /// 主页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dockpanel_backmain_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            /*Frame cim = (Frame)FindName("frame_cim");
            cim.Visibility = System.Windows.Visibility.Hidden;
            Frame pdm = (Frame)FindName("frame_pdm");
            pdm.Visibility = System.Windows.Visibility.Hidden;
            Frame sem = (Frame)FindName("frame_sem");
            sem.Visibility = System.Windows.Visibility.Hidden;
            Frame ffm = (Frame)FindName("frame_ffm");
            ffm.Visibility = System.Windows.Visibility.Hidden;*/
        } 
        #endregion
    }
}
