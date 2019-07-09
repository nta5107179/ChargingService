using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ICCard
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Init();
        }

        #region 定义
        /// <summary>
        /// 串口资源
        /// </summary>
        SerialPort m_sp = new SerialPort();
        /// <summary>
        /// 发送格式
        /// </summary>
        int m_sFormat = 0;
        /// <summary>
        /// 接收格式
        /// </summary>
        int m_rFormat = 0;
        /// <summary>
        /// 发送间隔
        /// </summary>
        int m_sIntervial = 0;
        /// <summary>
        /// 定时发送定时器
        /// </summary>
        Timer m_timer = null;
        #endregion

        #region 函数
        /// <summary>
        /// 初始化
        /// </summary>
        void Init()
        {
            //检查是否含有串口  
            string[] str = SerialPort.GetPortNames();
            if (str == null)
            {
                MessageBox.Show("本机没有串口！", "Error");
            }
            else
            {
                //添加串口项目  
                foreach (string s in SerialPort.GetPortNames())
                {
                    //获取有多少个COM口
                    TextBlock tb = new TextBlock();
                    tb.Text = s;
                    tb.Tag = s;
                    combox_port.Items.Add(tb);
                }
            }
        }
        /// <summary>
        /// 发送数据
        /// </summary>
        void send()
        {
            if (m_sFormat == 1)//以字符串形式发送时 
            {
                byte[] bytes = Encoding.UTF8.GetBytes(text_sData.Text);
                m_sp.Write(bytes, 0, bytes.Length);//写入数据
            }
            else//以16进制形式发送
            {
                string sendBuf = text_sData.Text;
                //处理数字转换
                Regex regex = new Regex(@"^[0-9a-f]{2}(\s[0-9a-f]{2})*$", RegexOptions.IgnoreCase);
                if (regex.IsMatch(sendBuf))
                {
                    string[] strArray = sendBuf.Split(' ');
                    byte[] byteBuffer = new byte[strArray.Length];
                    for (int i = 0; i < strArray.Length; i++)//对获取的字符做相加运算
                    {
                        byteBuffer[i] = Convert.ToByte(strArray[i], 16);
                    }
                    m_sp.Write(byteBuffer, 0, byteBuffer.Length);
                }
                else
                {
                    MessageBox.Show("发送数据格式错误！", "Error");
                }
            }
        }
        /// <summary>
        /// 接收数据
        /// </summary>
        void receive(object sender, SerialDataReceivedEventArgs e)
        {
            if (m_sp.IsOpen)//此处可能没有必要判断是否打开串口，但为了严谨性，我还是加上了
            {
                byte[] byteRead = new byte[m_sp.BytesToRead];//BytesToRead接收的字符个数
                if (m_rFormat == 1)//以字符串形式输出
                {
                    byte[] receivedData = new byte[m_sp.BytesToRead];        //创建接收字节数组
                    m_sp.Read(receivedData, 0, receivedData.Length);         //读取数据
                    this.Dispatcher.Invoke(new Action(delegate()
                    {
                        text_rData.AppendText(Encoding.UTF8.GetString(receivedData)); //注意：回车换行必须这样写，单独使用"\r"和"\n"都不会有效果
                    }));
                    //m_sp.DiscardInBuffer();//清空SerialPort控件的Buffer 
                }
                else//以16进制形式输出
                {
                    try
                    {
                        byte[] receivedData = new byte[m_sp.BytesToRead];        //创建接收字节数组
                        string[] receivedData2 = new string[m_sp.BytesToRead];
                        m_sp.Read(receivedData, 0, receivedData.Length);         //读取数据
                        //m_sp.DiscardInBuffer();                                  //清空SerialPort控件的Buffer
                        for (int i = 0; i < receivedData.Length; i++)
                        {
                            string t = Convert.ToString(receivedData[i], 16);
                            receivedData2[i] = t.Length % 2 != 0 ? "0" + t : t;
                        }
                        this.Dispatcher.Invoke(new Action(delegate()
                        {
                            text_rData.AppendText(string.Join(" ", receivedData2)+" "); //注意：回车换行必须这样写，单独使用"\r"和"\n"都不会有效果
                        }));
                    }
                    catch (System.Exception ex)
                    {
                        this.Dispatcher.Invoke(new Action(delegate()
                        {
                            text_rData.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 16进制输出错误" + "\r\n"); 
                        }));
                    }
                }
            }
            else
            {
                MessageBox.Show("请打开某个串口", "错误提示");
            }
        }
        #endregion

        #region 事件
        /// <summary>
        /// 打开串口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_open_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!m_sp.IsOpen)
                {
                    string pName = ((TextBlock)combox_port.SelectedItem).Tag.ToString();
                    if (pName != "")
                    {
                        m_sp.PortName = pName;//设置串口号
                        m_sp.BaudRate = int.Parse(((TextBlock)combox_baudRate.SelectedItem).Tag.ToString());//波特率
                        m_sp.DataBits = int.Parse(((TextBlock)combox_dataBits.SelectedItem).Tag.ToString());//数据位
                        //停止位
                        switch (((TextBlock)combox_stopBits.SelectedItem).Tag.ToString())
                        {
                            case "1":
                                m_sp.StopBits = StopBits.One;
                                break;
                            case "1.5":
                                m_sp.StopBits = StopBits.OnePointFive;
                                break;
                            case "2":
                                m_sp.StopBits = StopBits.Two;
                                break;
                        }
                        //校验位
                        switch (((TextBlock)combox_parity.SelectedItem).Tag.ToString())
                        {
                            case "0":
                                m_sp.Parity = Parity.None;
                                break;
                            case "1":
                                m_sp.Parity = Parity.Odd;
                                break;
                            case "2":
                                m_sp.Parity = Parity.Even;
                                break;
                        }
                        //如果打开状态，则先关闭一下
                        if (m_sp.IsOpen == true)
                        {
                            m_sp.Close();
                        }
                        //打开串口
                        m_sp.Open();
                        //设置接收方法
                        m_sp.DataReceived += new SerialDataReceivedEventHandler(receive);
                        //设置按钮状态
                        but_open.Content = "关闭串口";
                        combox_port.IsEnabled = false;
                        combox_baudRate.IsEnabled = false;
                        combox_dataBits.IsEnabled = false;
                        combox_stopBits.IsEnabled = false;
                        combox_parity.IsEnabled = false;
                        check_continueSend.IsEnabled = true;
                        but_send.IsEnabled = true;
                    }
                    else
                    {
                        MessageBox.Show("请选择串口！", "Error");
                    }
                }
                else
                {
                    m_sp.Close();
                    //设置按钮状态
                    but_open.Content = "打开串口";
                    combox_port.IsEnabled = true;
                    combox_baudRate.IsEnabled = true;
                    combox_dataBits.IsEnabled = true;
                    combox_stopBits.IsEnabled = true;
                    combox_parity.IsEnabled = true;
                    check_continueSend.IsEnabled = false;
                    but_send.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        /// <summary>
        /// 设置发送方式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void combox_sFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                m_sFormat = int.Parse(((TextBlock)combox_sFormat.SelectedItem).Tag.ToString());
            }
            catch { m_sFormat = 1; }
        }
        /// <summary>
        /// 设置发送间隔
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void combox_sIntervial_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                m_sIntervial = int.Parse(((TextBlock)combox_sIntervial.SelectedItem).Tag.ToString()) * 1000;
            }
            catch { m_sIntervial = 1000; }
        }
        /// <summary>
        /// 设置接收格式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void combox_rFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                m_rFormat = int.Parse(((TextBlock)combox_rFormat.SelectedItem).Tag.ToString());
            }
            catch { m_rFormat = 1; }
        }
        /// <summary>
        /// 设置开始定时发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void check_continueSend_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)check_continueSend.IsChecked)
            {
                m_timer = new Timer(delegate(object obj)
                {
                    this.Dispatcher.Invoke(new Action(delegate()
                    {
                        send();
                    }));
                }, null, 0, m_sIntervial);
            }
            else
            {
                m_timer.Dispose();
            }
        }
        /// <summary>
        /// 发送按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_send_Click(object sender, RoutedEventArgs e)
        {
            if (!(bool)check_continueSend.IsChecked)
            {
                send();
            }
        }
        private void but_rClear_Click(object sender, RoutedEventArgs e)
        {
            text_rData.Clear();
        }
        #endregion


    }
}
