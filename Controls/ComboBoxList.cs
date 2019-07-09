using Model.Project;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
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

namespace Controls
{
    /// <summary>
    /// 按照步骤 1a 或 1b 操作，然后执行步骤 2 以在 XAML 文件中使用此自定义控件。
    ///
    /// 步骤 1a) 在当前项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根 
    /// 元素中: 
    ///
    ///     xmlns:MyNamespace="clr-namespace:Controls"
    ///
    ///
    /// 步骤 1b) 在其他项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根 
    /// 元素中: 
    ///
    ///     xmlns:MyNamespace="clr-namespace:Controls;assembly=Controls"
    ///
    /// 您还需要添加一个从 XAML 文件所在的项目到此项目的项目引用，
    /// 并重新生成以避免编译错误: 
    ///
    ///     在解决方案资源管理器中右击目标项目，然后依次单击
    ///     “添加引用”->“项目”->[浏览查找并选择此项目]
    ///
    ///
    /// 步骤 2)
    /// 继续操作并在 XAML 文件中使用控件。
    ///
    ///     <MyNamespace:ThreeLinkage/>
    ///
    /// </summary>
    public class ComboBoxList : Control
    {
        static ComboBoxList()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ComboBoxList), new FrameworkPropertyMetadata(typeof(ComboBoxList)));
        }

        int m_count = 0;
        ObservableCollection<ObservableCollection<Controls_ComboBoxList>> m_datacontext = new ObservableCollection<ObservableCollection<Controls_ComboBoxList>>();

        /// <summary>
        /// 获取或设置控件中绑定的数据，根据第一维的数组长度判断下拉框的个数
        /// </summary>
        [Description("获取或设置控件中绑定的数据，数组长度与Count相同")]
        [Category("Common Properties")]
        public new ObservableCollection<ObservableCollection<Controls_ComboBoxList>> DataContext
        {
            get
            {
                return m_datacontext;
            }
            set
            {
                m_datacontext = value;
                m_count = m_datacontext.Count;
            }
        }
        /// <summary>
        /// 获取所选择的值，该值为一个数组，长度与DataContext长度相同
        /// </summary>
        [Description("获取所选择的值，该值为一个数组，长度与DataContext长度相同")]
        [Category("Common Properties")]
        public string[] SelectedValue
        {
            get
            {
                StackPanel sp = (StackPanel)this.GetTemplateChild("sp_box");
                string[] arr = new string[m_count];
                for (int i = 0; i < m_count; i++)
                {
                    arr[i] = ((ComboBox)sp.Children[i]).SelectedValue.ToString();
                }
                return arr;
            }
        }
        /// <summary>
        /// 获取所选择的值对象，该值为一个数组，长度与DataContext长度相同
        /// </summary>
        [Description("获取所选择的值对象，该值为一个数组，长度与DataContext长度相同")]
        [Category("Common Properties")]
        public ObservableCollection<Controls_ComboBoxList> SelectedItem
        {
            get
            {
                StackPanel sp = (StackPanel)this.GetTemplateChild("sp_box");
                ObservableCollection<Controls_ComboBoxList> list = new ObservableCollection<Controls_ComboBoxList>();
                for (int i = 0; i < m_count; i++)
                {
                    list.Add((Controls_ComboBoxList)((ComboBox)sp.Children[i]).SelectedItem);
                }
                return list;
            }
        }
        /// <summary>
        /// 匹配模板事件
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            if (m_count > 0)
            {
                StackPanel sp = (StackPanel)this.GetTemplateChild("sp_box");
                for (int i = 0; i < m_count; i++)
                {
                    ComboBox cbb = new ComboBox();
                    if (i != 0)
                        cbb.Margin = new Thickness(5, 0, 0, 0);
                    ObservableCollection<Controls_ComboBoxList> dataContext = new ObservableCollection<Controls_ComboBoxList>() {
                         new Controls_ComboBoxList() { pvalue = "", text = "--请选择--", value = "" }
                    };
                    ObservableCollection<Controls_ComboBoxList> cbbTag = m_datacontext[i];
                    cbb.Tag = cbbTag;
                    cbb.DisplayMemberPath = "text";
                    cbb.SelectedValuePath = "value";
                    cbb.ItemsSource = dataContext;
                    cbb.DataContext = cbb.ItemsSource;
                    sp.Children.Add(cbb);
                    cbb.SelectedIndex = 0;
                    if (i == 0)
                    {
                        for(int j = 0;j<cbbTag.Count;j++)
                        {
                            dataContext.Add(cbbTag[i]);
                        }
                    }
                }
                for (int i = 0; i < sp.Children.Count; i++)
                {
                    ComboBox cbb = (ComboBox)sp.Children[i];
                    new Action<int>(delegate(int n)
                    {
                        cbb.SelectionChanged += delegate(object sender, SelectionChangedEventArgs e)
                        {
                            try
                            {
                                ComboBox cbb2 = (ComboBox)sp.Children[n + 1];
                                ObservableCollection<Controls_ComboBoxList> cbbTag2 = (ObservableCollection<Controls_ComboBoxList>)cbb2.Tag;
                                ObservableCollection<Controls_ComboBoxList> cbbDataContext2 = (ObservableCollection<Controls_ComboBoxList>)cbb2.DataContext;
                                cbbDataContext2.Clear();
                                cbbDataContext2.Add(new Controls_ComboBoxList() { pvalue = "", text = "--请选择--", value = "" });
                                for (int j = 0; j < cbbTag2.Count; j++)
                                {
                                    if (cbb.SelectedValue.ToString() == cbbTag2[j].pvalue)
                                    {
                                        cbbDataContext2.Add(cbbTag2[j]);
                                    }
                                }
                                cbb2.SelectedIndex = 0;
                            }
                            catch { }
                        };
                    })(i);
                }

            }
        }
    }
}
