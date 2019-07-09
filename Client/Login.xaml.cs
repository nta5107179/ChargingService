using Client.App_Code;
using Client.App_Code.Include;
using Client.App_Code.Include.TCP;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;
using SystemFramework;

namespace Client
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window
    {
        Include m_inc = new Include();
        IncludeTCPSend001 m_incTCPSend001 = new IncludeTCPSend001();
        IncludeTCPReceive001 m_incTCPReceive001 = new IncludeTCPReceive001();

        public Login()
        {
            InitializeComponent();
            Init();
        }
        #region 定义
        /// <summary>
        /// 是否记住账号
        /// </summary>
        bool m_check_remember_checked = false;
        /// <summary>
        /// 登录用户名
        /// </summary>
        string m_text_name_text = "";
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

            if (!File.Exists(Config.g_root + "\\config.ini"))
            {
                using (StreamWriter sw = File.CreateText(Config.g_root + "\\config.ini"))
                {

                }
            }
            else
            {
                List<string> list = new List<string>();
                using (StreamReader sr = new StreamReader(Config.g_root + "\\config.ini"))
                {
                    while (!sr.EndOfStream)
                    {
                        list.Add(sr.ReadLine());
                    }
                }
                for (int i = 0; i < list.Count; i++)
                {
                    string[] arr = list[i].Split(':');
                    switch (arr[0])
                    {
                        case "check_remember_checked":
                            m_check_remember_checked = bool.Parse(arr[1]);
                            break;
                        case "text_name_text":
                            m_text_name_text = arr[1];
                            break;
                    }
                }
            }
            check_remember.IsChecked = m_check_remember_checked;
            text_name.Text = m_text_name_text;
        }
        /// <summary>
        /// 开始tcp连接
        /// </summary>
        void TCPStar()
        {
            //连接远程服务器
            try
            {
                Config.g_tcpClient = new TcpClient();
                Config.g_tcpClient.Connect(Config.g_hostname, Config.g_port);
                Config.g_socket = Config.g_tcpClient.Client;
            }
            catch
            {
                SysError.GetError("SERVERLINK001");
            }
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
                            SysError.GetError("SERVERLINK001");
                            throw new Exception("远程连接主动断开");
                        }
                        else if (nRead != receiveBytes.Length)
                        {
                            SysError.GetError("SERVERLINK001");
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
                                            string code = "";
                                            if (m_incTCPReceive001.DW0002(bodyData, ref code))
                                            {
                                                try
                                                {
                                                    //登录成功
                                                    if ((bool)check_remember.IsChecked)
                                                    {
                                                        using (StreamWriter sw = new StreamWriter(Config.g_root + "\\config.ini"))
                                                        {
                                                            sw.WriteLine("check_remember_checked:true");
                                                            sw.WriteLine("text_name_text:" + text_name.Text);
                                                        }
                                                    }
                                                    Config.cs_id = long.Parse(csid);
                                                    new Main().Show();
                                                    this.Close();
                                                }
                                                catch
                                                {
                                                    //登录失败
                                                    SysError.GetError("LOGIN001");
                                                    throw new Exception("系统错误，登录失败");
                                                }
                                            }
                                            else
                                            {
                                                //登录失败
                                                SysError.GetError(code);
                                                throw new Exception("登录失败");
                                            }
                                        }
                                        else
                                        {
                                            SysError.GetError("SERVERLINK001");
                                            throw new Exception("错误的命令");
                                        }
                                    }
                                    else
                                    {
                                        SysError.GetError("SERVERLINK001");
                                        throw new Exception("丢包");
                                    }
                                }
                                else
                                {
                                    SysError.GetError("SERVERLINK001");
                                    throw new Exception("错误的协议");
                                }
                            }
                        }
                    }
                    else
                    {
                        SysError.GetError("SERVERLINK001");
                        throw new Exception("远程连接主动断开");
                    }
                }
                catch
                {
                    //SysError.GetError("SERVERLINK001");
                    TCPStop();
                }
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
        #endregion

        #region 事件
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void img_login_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Config.cs_uname = text_name.Text;
            Config.cs_pwd = m_inc.OpString.DESEncryption(text_pwd.Password);
            TCPStar();
        }
        /// <summary>
        /// 窗体键盘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Config.cs_uname = text_name.Text;
                Config.cs_pwd = m_inc.OpString.DESEncryption(text_pwd.Password);
                TCPStar();
            }
        }
        /// <summary>
        /// 窗体移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_outside_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        #endregion


    }
}
