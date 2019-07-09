using Client.App_Code;
using Client.App_Code.Include;
using Client.App_Code.Include.HTTP;
using Client.App_Code.Include.TCP;
using Controls;
using Model;
using Model.Project;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Client.CIM
{
    /// <summary>
    /// CIMPlice.xaml 的交互逻辑
    /// </summary>
    public partial class CIMPolice : Window
    {
        Include m_inc = new Include();
        IncludeHTTPSend m_incHTTPSend = new IncludeHTTPSend();

        List<AM_CIMPolice> m_list = new List<AM_CIMPolice>();

        public CIMPolice()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 充电站编号
        /// </summary>
        long m_cs_id = 0;
        /// <summary>
        /// 充电桩编号
        /// </summary>
        long m_cp_id = 0;
        /// <summary>
        /// 充电桩编码
        /// </summary>
        string m_cp_code = "";

        /// <summary>
        /// 窗口载入完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            m_cs_id = (long)((object[])this.Tag)[0];
            m_cp_id = (long)((object[])this.Tag)[1];
            m_cp_code = ((object[])this.Tag)[2].ToString();

            //获取充电桩报警数据列表
            m_list = m_incHTTPSend.UP006(m_cs_id, m_cp_id, false);
            for (int i = 0; i < m_list.Count; i++)
            {
                CIMPoliceShow control = new CIMPoliceShow();
                AM_CIMPolice mod = m_list[i];
                control.InternalElementMouseUp += new MouseButtonEventHandler(delegate(object sender2, MouseButtonEventArgs e2)
                {
                    Solve(control, mod);
                });
                control.Text = "充电桩第" + (int)m_list[i].cp_guncode + "枪：" + Config.g_police[(int)m_list[i].am_cimp_type] + "(" + m_list[i].am_d_addtime + ")";
                polices.Children.Add(control);
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
        /// 处理按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Solve(CIMPoliceShow control, AM_CIMPolice mod)
        {
            MessageBoxResult mbr = MessageBox.Show("是否处理该故障？", "消息提示", MessageBoxButton.OKCancel, MessageBoxImage.Warning, MessageBoxResult.OK);
            if (mbr == MessageBoxResult.OK)
            {
                try
                {
                    HttpWebRequest hwr = (HttpWebRequest)WebRequest.Create(Config.g_httpUrl +
                        string.Format("?type=UP0007&cs_id={0}&cp_id={1}&am_cimp_id={2}&am_cimp_examine=true", m_cs_id, m_cp_id, mod.am_cimp_id));
                    hwr.Method = "get";
                    WebResponse wr = hwr.GetResponse();
                    using (StreamReader sr = new StreamReader(wr.GetResponseStream()))
                    {
                        bool b = bool.Parse(sr.ReadToEnd());
                        if (b)
                        {
                            MessageBox.Show("处理成功！", "error", MessageBoxButton.OK, MessageBoxImage.Information);
                            m_list.Remove(mod);
                            control.Visibility = System.Windows.Visibility.Collapsed;
                            //判断该枪是否所有报警都已处理
                            AM_CIMPolice[] arr = m_list.Where(a => a.cp_guncode == mod.cp_guncode).ToArray();
                            if (arr.Length <= 0)
                            {
                                //设置该枪的报警状态为false
                                Dictionary<string, object> tcpClientDic = Config.g_cimTcpClientDic[m_cp_code];
                                Client_ChargePile_Data_AC data = (Client_ChargePile_Data_AC)tcpClientDic["data"];
                                data.gundata[(int)mod.cp_guncode].ispolice = false;
                                data.gundata[(int)mod.cp_guncode].police = "";
                                data.gundata[(int)mod.cp_guncode].policecode = 0;
                                //判断桩的报警状态
                                bool b2 = false;
                                for (int i = 1; i < data.gundata.Count; i++)
                                {
                                    if ((bool)data.gundata[(int)mod.cp_guncode].ispolice)
                                    {
                                        b2 = true;
                                        break;
                                    }
                                }
                                data.ispolice = b2;
                            }
                        }
                        else
                            MessageBox.Show("处理失败！", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    wr.Close();
                }
                catch
                {
                    MessageBox.Show("网络错误，处理失败！", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

    }
}
