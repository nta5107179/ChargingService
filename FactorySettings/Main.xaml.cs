using Listener.App_Code;
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
        public Main()
        {
            InitializeComponent();
            Init();
        }
        #region 定义
        /// <summary>
        /// tcp对象
        /// </summary>
        TcpListener m_tcpListener = null;
        /// <summary>
        /// tcp线程
        /// </summary>
        Thread m_thread = null;
        /// <summary>
        /// tcp有效客户端
        /// </summary>
        Socket m_socket = null;
        /// <summary>
        /// 统计线程
        /// </summary>
        System.Threading.Timer m_tcpTimer = null;
        #endregion

        #region 函数
        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        void Init()
        {
            //读网页传递过来的参数
            string[] CmdArgs = System.Environment.GetCommandLineArgs();
            if (CmdArgs.Length > 1)
            {
                string[] t = CmdArgs[1].Split(':')[1].Split('|');
                text_version.Text = t[0];
                text_cs_id.Text = t[1];
                text_cp_code.Text = t[2];
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
                m_thread = new Thread(delegate()
                {
                    try
                    {
                        m_socket = m_tcpListener.AcceptSocket();
                        try
                        {
                            //设置检测间隔
                            //byte[] inValue = new byte[] { 1, 0, 0, 0, 0x20, 0x4e, 0, 0, 0xd0, 0x07, 0, 0 };// 首次探测时间20 秒, 间隔侦测时间2 秒
                            byte[] inValue = new byte[] { 1, 0, 0, 0, 0x88, 0x13, 0, 0, 0xd0, 0x07, 0, 0 };// 首次探测时间5 秒, 间隔侦测时间2 秒
                            m_socket.IOControl(IOControlCode.KeepAliveValues, inValue, null);
                            //添加socket队列
                            m_socket.BeginReceive(new byte[0], 0, 0, SocketFlags.None, new AsyncCallback(TCPRun), m_socket);

                            this.Dispatcher.Invoke(new Action(delegate()
                            {
                                text_content.AppendText("TCP连接已建立。\r\n");
                                but_tcpIn.IsEnabled = true;
                            }));
                        }
                        catch
                        {
                            TCPStop();
                        }
                    }
                    catch { }
                });
                m_thread.Start();
                text_content.AppendText("TCP已打开，正在等待连接进入。\r\n");
                but_tcpStar.IsEnabled = false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "错误", MessageBoxButton.OK, MessageBoxImage.Error);
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
                                        if (parity == CRC16.GetString(number + bodyData) && number == "UP0255")
                                        {
                                            MatchCollection arr = Regex.Matches(bodyData, @"(?<=\[)[^\]]*(?=\])");
                                            string UP_0 = arr[0].Value;//协议版本
                                            string UP_1 = arr[1].Value;//充电站编号
                                            string UP_2 = arr[2].Value;//充电桩编码
                                            this.Dispatcher.Invoke(new Action(delegate()
                                            {
                                                text_content.AppendText(string.Format("收到TCP数据，协议版本：{0} 充电站编号：{1} 充电桩编码：{2}\r\n",
                                                    UP_0, UP_1, UP_2));
                                            }));
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
                    TCPStop();
                }
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
            try
            {
                m_socket.Shutdown(SocketShutdown.Both);
                m_socket.Disconnect(false);
                m_socket.Dispose();
                m_socket.Close();
            }
            catch { }
            this.Dispatcher.Invoke(new Action(delegate()
            {
                try
                {
                    text_content.AppendText("TCP连接已断开。\r\n");
                    but_tcpIn.IsEnabled = false;
                    but_tcpStar.IsEnabled = true;
                }
                catch { }
            }));
        }
        #endregion

        #endregion

        #region 事件
        /// <summary>
        /// 开始tcp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_tcpStar_Click(object sender, RoutedEventArgs e)
        {
            TCPStart();
        }
        /// <summary>
        /// 写入TCP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_tcpIn_Click(object sender, RoutedEventArgs e)
        {
            string checkbody = "DW0255" +
                "[" + text_version.Text + "]" +
                "[" + text_cs_id.Text + "]" +
                "[" + text_cp_code.Text + "]";
            string sendData = "(" +
                text_version.Text +
                text_cs_id.Text +
                text_cp_code.Text +
                "00000000000000000000000000000000" +
                CRC16.GetString(checkbody) +
                checkbody + 
                ")";
            m_socket.Send(Encoding.UTF8.GetBytes(sendData));
            text_content.AppendText("TCP数据已发送。\r\n");
        }
        /// <summary>
        /// 打开串口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_serialStar_Click(object sender, RoutedEventArgs e)
        {

        }
        /// <summary>
        /// 写入串口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_serialIn_Click(object sender, RoutedEventArgs e)
        {

        }
        /// <summary>
        /// 窗口关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TCPStop();
            Environment.Exit(0);
        }
        #endregion



    }
}
