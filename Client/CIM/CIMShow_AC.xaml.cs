using Client.App_Code;
using Model.Project;
using Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Client.App_Code.Include;
using System.IO;
using System.Xml;
using System.Windows.Markup;
using System.Net.Sockets;
using System.Net;

namespace Client.CIM
{
    /// <summary>
    /// CIMShow.xaml 的交互逻辑
    /// </summary>
    public partial class CIMShow_AC : Window
    {
        public CIMShow_AC()
        {
            InitializeComponent();
        }

        Include m_inc = new Include();

        /// <summary>
        /// 当前充电桩数据
        /// </summary>
        Client_ChargePile_Data_AC m_mod = new Client_ChargePile_Data_AC();
        /// <summary>
        /// tcp有效客户端队列
        /// </summary>
        Dictionary<string, Dictionary<string, object>> m_tcpClientDic = Config.g_cimTcpClientDic;

        /// <summary>
        /// 窗口载入完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            m_mod = (Client_ChargePile_Data_AC)this.Tag;
            this.DataContext = m_mod;
            //确定枪数
            Border border = (Border)this.FindName("border_cim");
            switch (m_mod.gunnum)
            {
                case 1:
                    {
                        CIMShowPile1Gun cimdp = new CIMShowPile1Gun();
                        cimdp.DataContext = m_mod;
                        border.Child = cimdp;
                    }
                    break;
                case 2:
                    {
                        CIMShowPile2Gun cimdp = new CIMShowPile2Gun();
                        cimdp.DataContext = m_mod;
                        border.Child = cimdp;
                    }
                    break;
                case 4:
                    {
                        CIMShowPile4Gun cimdp = new CIMShowPile4Gun();
                        cimdp.DataContext = m_mod;
                        border.Child = cimdp;
                    }
                    break;
            }
            StackPanel sp = (StackPanel)FindName("guns");
            //获取枪数据
            ObservableCollection<Client_ChargePile_GunData_AC> gunlist = m_mod.gundata;
            for (int i = 1; i <= m_mod.gunnum; i++)
            {
                CIMShowGun_AC cimsdg = new CIMShowGun_AC();
                ObservableCollection<Client_ChargePile_GunData_AC> oc = new ObservableCollection<Client_ChargePile_GunData_AC>();
                Client_ChargePile_GunData_AC mod = gunlist[i];
                oc.Add(mod);
                cimsdg.DataContext = oc;
                cimsdg.Margin = new Thickness(0, 15, 0, 0);
                sp.Children.Add(cimsdg);
            }
        }
        /// <summary>
        /// 标题鼠标点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DockPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        /// <summary>
        /// 停止充电按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lab_quickstop_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (m_tcpClientDic.ContainsKey(m_mod.cp_code))
            {
                MessageBoxResult mbr = MessageBox.Show("是否要为\"" + m_mod.cp_name + "\"停止充电？", "消息提示", MessageBoxButton.OKCancel, MessageBoxImage.Warning, MessageBoxResult.Cancel);
                if (mbr == MessageBoxResult.OK)
                {
                    List<string> bList = new List<string>();
                    for (int i = 1; i < m_mod.gundata.Count; i++)
                    {
                        try
                        {
                            HttpWebRequest hwr = (HttpWebRequest)WebRequest.Create(Config.g_httpUrl +
                                string.Format("?type=UP0005&cs_id={0}&cp_code={1}&cp_guncode={2}", Config.cs_id, m_mod.cp_code, i));
                            hwr.Method = "get";
                            WebResponse wr = hwr.GetResponse();
                            using (StreamReader sr = new StreamReader(wr.GetResponseStream()))
                            {
                                bool b = bool.Parse(sr.ReadToEnd());
                                if (b)
                                    bList.Add("枪" + i + "停止充电命令发送成功\r\n");
                                else
                                    bList.Add("枪" + i + "停止充电命令发送失败（Error）\r\n");
                            }
                            wr.Close();
                        }
                        catch { bList.Add("枪" + i + "停止充电命令发送失败（Error）\r\n"); }
                    }
                    MessageBox.Show("执行结果：\r\n" + string.Join("", bList), "消息提示", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
                }
            }
            else
            {
                MessageBoxResult mbr = MessageBox.Show("充电桩未连接！", "消息提示", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
            }
        }
        /// <summary>
        /// 处理故障
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lab_solveMalfunction_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (m_tcpClientDic.ContainsKey(m_mod.cp_code))
            {
                CIMPolice cimpolice = new CIMPolice();
                cimpolice.Tag = new object[] { m_mod.cs_id, m_mod.cp_id, m_mod.cp_code };
                cimpolice.Owner = this;
                cimpolice.ShowDialog();
            }
            else
            {
                MessageBoxResult mbr = MessageBox.Show("充电桩未连接！", "消息提示", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
            }
        }
    }
}
