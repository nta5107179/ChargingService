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
        /// 串口接收委托
        /// </summary>
        /// <param name="received"></param>
        delegate void SerialPortReceive(string received);
        SerialPortReceive m_spr = null;
        /// <summary>
        /// 修改秘钥委托
        /// </summary>
        /// <param name="received"></param>
        delegate void DeleageEditPwd();
        DeleageEditPwd deleageEditPwd = null;
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
            //读网页传递过来的参数
            string[] CmdArgs = System.Environment.GetCommandLineArgs();
            if (CmdArgs.Length > 1)
            {
                text_write.Text = CmdArgs[1].Split(':')[1];
            }
        }
        /// <summary>
        /// 发送数据
        /// </summary>
        void send(byte[] byteArr)
        {
            m_sp.Write(byteArr, 0, byteArr.Length);
        }
        /// <summary>
        /// 接收数据
        /// </summary>
        void receive(object sender, SerialDataReceivedEventArgs e)
        {
            if (m_sp.IsOpen)//此处可能没有必要判断是否打开串口，但为了严谨性，我还是加上了
            {
                Thread.Sleep(100);
                if (m_sp.BytesToRead > 0)
                {
                    byte[] byteRead = new byte[m_sp.BytesToRead];//BytesToRead接收的字符个数
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
                        m_spr(string.Join(" ", receivedData2));
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

        #region 打开控制
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
                        m_sp.BaudRate = 19200;//波特率
                        m_sp.DataBits = 8;//数据位
                        //停止位
                        m_sp.StopBits = StopBits.One;
                        //校验位
                        m_sp.Parity = Parity.None;
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
                        but_reset.IsEnabled = true;
                        but_set.IsEnabled = true;
                        but_read.IsEnabled = true;
                        but_write.IsEnabled = true;
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
                    but_reset.IsEnabled = false;
                    but_set.IsEnabled = false;
                    but_read.IsEnabled = false;
                    but_write.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        #endregion

        #region 读卡器设置模式

        #region 恢复出厂设置
        /// <summary>
        /// 恢复出厂
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_reset_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mbr = MessageBox.Show("确定将读卡器恢复出厂设置吗？", "消息提示", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
            if (mbr == MessageBoxResult.OK)
            {
                List<byte> byteList = new List<byte>();
                //长度字
                byteList.Add(0x00);
                byteList.Add(0x09);
                //通讯地址
                byteList.Add(0x00);
                //命令字
                byteList.Add(0x0F);
                //数据域
                byteList.Add(0x52);
                byteList.Add(0x45);
                byteList.Add(0x53);
                byteList.Add(0x45);
                byteList.Add(0x54);
                //校验字
                byteList.Add(XOR.GetByte(byteList.ToArray()));

                text_rData.AppendText(string.Join(" ", byteList.ConvertAll(new Converter<byte, string>(delegate(byte t)
                {
                    string str = Convert.ToString(t, 16);
                    return str.Length % 2 != 0 ? "0" + str : str;
                }))) + "\r\n");

                //实现接收委托
                m_spr = new SerialPortReceive(delegate(string received)
                {
                    this.Dispatcher.Invoke(new Action(delegate()
                    {
                        text_rData.AppendText(received + "\r\n"); //注意：回车换行必须这样写，单独使用"\r"和"\n"都不会有效果
                        string[] arr = received.Split(' ');
                        if (Convert.ToByte(arr[3], 16) != byteList[3])
                        {
                            MessageBox.Show("恢复出厂设置执行失败！", "error");
                        }
                        else
                        {
                            MessageBox.Show("恢复出厂设置成功，请重新上电后点击“设置模块”！", "information");
                        }
                    }));
                });

                send(byteList.ToArray());
            }
        }
        /// <summary>
        /// 设置模块
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_set_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mbr = MessageBox.Show("确定设置模块吗？", "消息提示", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
            if (mbr == MessageBoxResult.OK)
            {
                Thread t = new Thread(delegate()
                {
                    this.Dispatcher.Invoke(new Action(delegate()
                    {
                        SetLed();
                    }));
                    Thread.Sleep(500);
                    this.Dispatcher.Invoke(new Action(delegate()
                    {
                        SetBuzzer();
                    }));
                    Thread.Sleep(500);
                    this.Dispatcher.Invoke(new Action(delegate()
                    {
                        SetBaudrate();
                    }));
                    Thread.Sleep(500);
                    this.Dispatcher.Invoke(new Action(delegate()
                    {
                        SetRF();
                    }));
                    Thread.Sleep(500);
                    this.Dispatcher.Invoke(new Action(delegate()
                    {
                        SetRCM();
                    }));
                    Thread.Sleep(500);
                    this.Dispatcher.Invoke(new Action(delegate()
                    {
                        SetMorecard();
                    }));
                    Thread.Sleep(500);
                    this.Dispatcher.Invoke(new Action(delegate()
                    {
                        SetOnFindcard();
                    }));
                    Thread.Sleep(500);
                    this.Dispatcher.Invoke(new Action(delegate()
                    {
                        SetOnFindcardAndOut();
                    }));
                    Thread.Sleep(500);
                    this.Dispatcher.Invoke(new Action(delegate()
                    {
                        MessageBox.Show("模块设置成功！", "information");
                    }));
                });
                t.Start();
            }
        }
        #endregion

        #region 设置LED
        void SetLed()
        {
            List<byte> byteList = new List<byte>();
            //长度字
            byteList.Add(0x00);
            byteList.Add(0x05);
            //通讯地址
            byteList.Add(0x00);
            //命令字
            byteList.Add(0x13);
            //数据域
            byteList.Add(0x03);
            //校验字
            byteList.Add(XOR.GetByte(byteList.ToArray()));

            text_rData.AppendText(string.Join(" ", byteList.ConvertAll(new Converter<byte, string>(delegate(byte t)
            {
                string str = Convert.ToString(t, 16);
                return str.Length % 2 != 0 ? "0" + str : str;
            }))) + "\r\n");

            //实现接收委托
            m_spr = new SerialPortReceive(delegate(string received)
            {
                this.Dispatcher.Invoke(new Action(delegate()
                {
                    text_rData.AppendText(received + "\r\n"); //注意：回车换行必须这样写，单独使用"\r"和"\n"都不会有效果
                    string[] arr = received.Split(' ');
                    if (Convert.ToByte(arr[3], 16) != byteList[3])
                    {
                        MessageBox.Show("设置LED失败！", "error");
                    }
                }));
            });

            send(byteList.ToArray());
        }
        #endregion

        #region 设置蜂鸣器
        void SetBuzzer()
        {
            List<byte> byteList = new List<byte>();
            //长度字
            byteList.Add(0x00);
            byteList.Add(0x05);
            //通讯地址
            byteList.Add(0x00);
            //命令字
            byteList.Add(0x14);
            //数据域
            byteList.Add(0x015);
            //校验字
            byteList.Add(XOR.GetByte(byteList.ToArray()));

            text_rData.AppendText(string.Join(" ", byteList.ConvertAll(new Converter<byte, string>(delegate(byte t)
            {
                string str = Convert.ToString(t, 16);
                return str.Length % 2 != 0 ? "0" + str : str;
            }))) + "\r\n");

            //实现接收委托
            m_spr = new SerialPortReceive(delegate(string received)
            {
                this.Dispatcher.Invoke(new Action(delegate()
                {
                    text_rData.AppendText(received + "\r\n"); //注意：回车换行必须这样写，单独使用"\r"和"\n"都不会有效果
                    string[] arr = received.Split(' ');
                    if (Convert.ToByte(arr[3], 16) != byteList[3])
                    {
                        MessageBox.Show("设置蜂鸣器失败！", "error");
                    }
                }));
            });

            send(byteList.ToArray());
        }
        #endregion

        #region 设置波特率
        void SetBaudrate()
        {
            List<byte> byteList = new List<byte>();
            //长度字
            byteList.Add(0x00);
            byteList.Add(0x05);
            //通讯地址
            byteList.Add(0x00);
            //命令字
            byteList.Add(0x17);
            //数据域
            byteList.Add(0x00);
            //校验字
            byteList.Add(XOR.GetByte(byteList.ToArray()));

            text_rData.AppendText(string.Join(" ", byteList.ConvertAll(new Converter<byte, string>(delegate(byte t)
            {
                string str = Convert.ToString(t, 16);
                return str.Length % 2 != 0 ? "0" + str : str;
            }))) + "\r\n");

            //实现接收委托
            m_spr = new SerialPortReceive(delegate(string received)
            {
                this.Dispatcher.Invoke(new Action(delegate()
                {
                    text_rData.AppendText(received + "\r\n"); //注意：回车换行必须这样写，单独使用"\r"和"\n"都不会有效果
                    string[] arr = received.Split(' ');
                    if (Convert.ToByte(arr[3], 16) != byteList[3])
                    {
                        MessageBox.Show("设置波特率失败！", "error");
                    }
                }));
            });

            send(byteList.ToArray());
        }
        #endregion

        #region 设置射频输出功率
        void SetRF()
        {
            List<byte> byteList = new List<byte>();
            //长度字
            byteList.Add(0x00);
            byteList.Add(0x05);
            //通讯地址
            byteList.Add(0x00);
            //命令字
            byteList.Add(0x02);
            //数据域
            byteList.Add(0x01);
            //校验字
            byteList.Add(XOR.GetByte(byteList.ToArray()));

            text_rData.AppendText(string.Join(" ", byteList.ConvertAll(new Converter<byte, string>(delegate(byte t)
            {
                string str = Convert.ToString(t, 16);
                return str.Length % 2 != 0 ? "0" + str : str;
            }))) + "\r\n");

            //实现接收委托
            m_spr = new SerialPortReceive(delegate(string received)
            {
                this.Dispatcher.Invoke(new Action(delegate()
                {
                    text_rData.AppendText(received + "\r\n"); //注意：回车换行必须这样写，单独使用"\r"和"\n"都不会有效果
                    string[] arr = received.Split(' ');
                    if (Convert.ToByte(arr[3], 16) != byteList[3])
                    {
                        MessageBox.Show("设置射频输出功率失败！", "error");
                    }
                }));
            });

            send(byteList.ToArray());
        }
        #endregion

        #region 设置读卡模式
        void SetRCM()
        {
            List<byte> byteList = new List<byte>();
            //长度字
            byteList.Add(0x00);
            byteList.Add(0x05);
            //通讯地址
            byteList.Add(0x00);
            //命令字
            byteList.Add(0x70);
            //数据域
            byteList.Add(0x00);
            //校验字
            byteList.Add(XOR.GetByte(byteList.ToArray()));

            text_rData.AppendText(string.Join(" ", byteList.ConvertAll(new Converter<byte, string>(delegate(byte t)
            {
                string str = Convert.ToString(t, 16);
                return str.Length % 2 != 0 ? "0" + str : str;
            }))) + "\r\n");

            //实现接收委托
            m_spr = new SerialPortReceive(delegate(string received)
            {
                this.Dispatcher.Invoke(new Action(delegate()
                {
                    text_rData.AppendText(received + "\r\n"); //注意：回车换行必须这样写，单独使用"\r"和"\n"都不会有效果
                    string[] arr = received.Split(' ');
                    if (Convert.ToByte(arr[3], 16) != byteList[3])
                    {
                        MessageBox.Show("设置读卡模式失败！", "error");
                    }
                }));
            });

            send(byteList.ToArray());
        }
        #endregion

        #region 设置多卡模式
        void SetMorecard()
        {
            List<byte> byteList = new List<byte>();
            //长度字
            byteList.Add(0x00);
            byteList.Add(0x05);
            //通讯地址
            byteList.Add(0x00);
            //命令字
            byteList.Add(0x1A);
            //数据域
            byteList.Add(0x00);
            //校验字
            byteList.Add(XOR.GetByte(byteList.ToArray()));

            text_rData.AppendText(string.Join(" ", byteList.ConvertAll(new Converter<byte, string>(delegate(byte t)
            {
                string str = Convert.ToString(t, 16);
                return str.Length % 2 != 0 ? "0" + str : str;
            }))) + "\r\n");

            //实现接收委托
            m_spr = new SerialPortReceive(delegate(string received)
            {
                this.Dispatcher.Invoke(new Action(delegate()
                {
                    text_rData.AppendText(received + "\r\n"); //注意：回车换行必须这样写，单独使用"\r"和"\n"都不会有效果
                    string[] arr = received.Split(' ');
                    if (Convert.ToByte(arr[3], 16) != byteList[3])
                    {
                        MessageBox.Show("设置多卡模式失败！", "error");
                    }
                }));
            });

            send(byteList.ToArray());
        }
        #endregion

        #region 设置开机寻卡
        void SetOnFindcard()
        {
            List<byte> byteList = new List<byte>();
            //长度字
            byteList.Add(0x00);
            byteList.Add(0x05);
            //通讯地址
            byteList.Add(0x00);
            //命令字
            byteList.Add(0x1D);
            //数据域
            byteList.Add(0x01);
            //校验字
            byteList.Add(XOR.GetByte(byteList.ToArray()));

            text_rData.AppendText(string.Join(" ", byteList.ConvertAll(new Converter<byte, string>(delegate(byte t)
            {
                string str = Convert.ToString(t, 16);
                return str.Length % 2 != 0 ? "0" + str : str;
            }))) + "\r\n");

            //实现接收委托
            m_spr = new SerialPortReceive(delegate(string received)
            {
                this.Dispatcher.Invoke(new Action(delegate()
                {
                    text_rData.AppendText(received + "\r\n"); //注意：回车换行必须这样写，单独使用"\r"和"\n"都不会有效果
                    string[] arr = received.Split(' ');
                    if (Convert.ToByte(arr[3], 16) != byteList[3])
                    {
                        MessageBox.Show("设置开机寻卡失败！", "error");
                    }
                }));
            });

            send(byteList.ToArray());
        }
        #endregion

        #region 设置开机寻卡及输出
        void SetOnFindcardAndOut()
        {
            List<byte> byteList = new List<byte>();
            //长度字
            byteList.Add(0x00);
            byteList.Add(0x05);
            //通讯地址
            byteList.Add(0x00);
            //命令字
            byteList.Add(0x1E);
            //数据域
            byteList.Add(0x0C);
            //校验字
            byteList.Add(XOR.GetByte(byteList.ToArray()));

            text_rData.AppendText(string.Join(" ", byteList.ConvertAll(new Converter<byte, string>(delegate(byte t)
            {
                string str = Convert.ToString(t, 16);
                return str.Length % 2 != 0 ? "0" + str : str;
            }))) + "\r\n");

            //实现接收委托
            m_spr = new SerialPortReceive(delegate(string received)
            {
                this.Dispatcher.Invoke(new Action(delegate()
                {
                    text_rData.AppendText(received + "\r\n"); //注意：回车换行必须这样写，单独使用"\r"和"\n"都不会有效果
                    string[] arr = received.Split(' ');
                    if (Convert.ToByte(arr[3], 16) != byteList[3])
                    {
                        MessageBox.Show("设置开机寻卡及输出失败！", "error");
                    }
                }));
            });

            send(byteList.ToArray());
        }
        #endregion

        #endregion

        #region IC卡设置模式

        #region 修改秘钥
        /// <summary>
        /// 修改秘钥
        /// </summary>
        void EditPwd()
        {
            List<byte> byteList = new List<byte>();
            //长度字
            byteList.Add(0x00);
            byteList.Add(0x1C);
            //通讯地址
            byteList.Add(0x00);
            //命令字
            byteList.Add(0x22);
            //数据域
            byteList.Add(0x00);//秘钥标示
            byteList.Add(0x13);//第4区第3块区域(尾块)
            byteList.AddRange(new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF });//秘钥A的旧秘钥
            byteList.AddRange(new byte[] { 0xF0, 0xE1, 0xD2, 0xC3, 0xB4, 0xA5 });//秘钥A的新秘钥
            byteList.AddRange(new byte[] { 0xFF, 0x07, 0x80, 0x69 });//控制位
            byteList.AddRange(new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF });//秘钥B
            //校验字
            byteList.Add(XOR.GetByte(byteList.ToArray()));

            //实现接收委托
            m_spr = new SerialPortReceive(delegate(string received)
            {
                this.Dispatcher.Invoke(new Action(delegate()
                {
                    deleageEditPwd();
                }));
            });

            send(byteList.ToArray());
        }
        #endregion

        #region 读卡
        /// <summary>
        /// 读卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_readcard_Click(object sender, RoutedEventArgs e)
        {
            deleageEditPwd = new DeleageEditPwd(delegate()
            {
                List<byte> byteList = new List<byte>();
                //长度字
                byteList.Add(0x00);
                byteList.Add(0x0D);
                //通讯地址
                byteList.Add(0x00);
                //命令字
                byteList.Add(0x2A);
                //数据域
                byteList.Add(0x00);
                byteList.Add(0x10);
                byteList.Add(0x02);
                byteList.Add(0xF0);
                byteList.Add(0xE1);
                byteList.Add(0xD2);
                byteList.Add(0xC3);
                byteList.Add(0xB4);
                byteList.Add(0xA5);
                //校验字
                byteList.Add(XOR.GetByte(byteList.ToArray()));

                text_rData.AppendText(string.Join(" ", byteList.ConvertAll(new Converter<byte, string>(delegate(byte t)
                {
                    string str = Convert.ToString(t, 16);
                    return str.Length % 2 != 0 ? "0" + str : str;
                }))) + "\r\n");

                //实现接收委托
                m_spr = new SerialPortReceive(delegate(string received)
                {
                    this.Dispatcher.Invoke(new Action(delegate()
                    {
                        text_rData.AppendText(received + "\r\n"); //注意：回车换行必须这样写，单独使用"\r"和"\n"都不会有效果
                        string[] arr = received.Split(' ');
                        if (Convert.ToByte(arr[3], 16) != byteList[3])
                        {
                            MessageBox.Show("读卡失败！", "error");
                        }
                        else
                        {
                            string[] number = new string[18];
                            Array.Copy(arr, 4, number, 0, 18);
                            byte[] bytes = number.ToList().ConvertAll(new Converter<string, byte>(delegate(string t)
                            {
                                return Convert.ToByte(t, 16);
                            })).ToArray();
                            text_read.Text = ASCIIEncoding.ASCII.GetString(bytes);
                        }
                    }));
                });

                send(byteList.ToArray());
            });
            EditPwd();
        }
        #endregion

        #region 写卡
        /// <summary>
        /// 写卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_writecard_Click(object sender, RoutedEventArgs e)
        {
            deleageEditPwd = new DeleageEditPwd(delegate()
            {
                List<byte> byteList = new List<byte>();
                //长度字
                byteList.Add(0x00);
                byteList.Add(0x2D);
                //通讯地址
                byteList.Add(0x00);
                //命令字
                byteList.Add(0x2B);
                //数据域
                byteList.Add(0x00);
                byteList.Add(0x10);
                byteList.Add(0x02);
                byteList.Add(0xF0);
                byteList.Add(0xE1);
                byteList.Add(0xD2);
                byteList.Add(0xC3);
                byteList.Add(0xB4);
                byteList.Add(0xA5);
                byte[] bytes = ASCIIEncoding.UTF8.GetBytes(text_write.Text.ToString());
                byteList.AddRange(bytes);
                for (int i = bytes.Length; i < 32; i++)
                {
                    byteList.Add(0x00);
                }
                //校验字
                byteList.Add(XOR.GetByte(byteList.ToArray()));

                text_rData.AppendText(string.Join(" ", byteList.ConvertAll(new Converter<byte, string>(delegate(byte t)
                {
                    string str = Convert.ToString(t, 16);
                    return str.Length % 2 != 0 ? "0" + str : str;
                }))) + "\r\n");

                //实现接收委托
                m_spr = new SerialPortReceive(delegate(string received)
                {
                    this.Dispatcher.Invoke(new Action(delegate()
                    {
                        text_rData.AppendText(received + "\r\n"); //注意：回车换行必须这样写，单独使用"\r"和"\n"都不会有效果
                        string[] arr = received.Split(' ');
                        if (Convert.ToByte(arr[3], 16) != byteList[3])
                        {
                            MessageBox.Show("命令执行失败！", "error");
                        }
                        else
                        {
                            MessageBox.Show("写卡成功！", "information");
                        }
                    }));
                });

                send(byteList.ToArray());
            });
            EditPwd();
        }
        #endregion

        #endregion

        #region 接收控制
        /// <summary>
        /// 清空接收框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_rClear_Click(object sender, RoutedEventArgs e)
        {
            text_rData.Clear();
        }
        #endregion

        #endregion


    }
}
