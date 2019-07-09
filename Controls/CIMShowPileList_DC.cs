using Model.Project;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
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
    ///     <MyNamespace:CIMDetialPileList/>
    ///
    /// </summary>
    public class CIMShowPileList_DC : ItemsControl
    {
        static CIMShowPileList_DC()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CIMShowPileList_DC), new FrameworkPropertyMetadata(typeof(CIMShowPileList_DC)));
        }

        ObservableCollection<Client_ChargePile_Data_DC> m_datacontext = new ObservableCollection<Client_ChargePile_Data_DC>();
        Thickness m_InternalElementMargin = new Thickness();
        List<MouseButtonEventHandler> m_InternalElementMouseUpList = new List<MouseButtonEventHandler>();
        
        /// <summary>
        /// 获取或设置控件中绑定的数据
        /// </summary>
        [Description("获取或设置控件中绑定的数据")]
        [Category("自定义")]
        public new ObservableCollection<Client_ChargePile_Data_DC> DataContext
        {
            get
            {
                return m_datacontext;
            }
            set
            {
                m_datacontext = value;
            }
        }
        /// <summary>
        /// 内部元素外边距
        /// </summary>
        [Description("内部元素外边距")]
        [Category("自定义")]
        public Thickness InternalElementMargin
        {
            get
            {
                return m_InternalElementMargin;
            }
            set
            {
                m_InternalElementMargin = value;
            }
        }
        /// <summary>
        /// 内部元素鼠标抬起事件
        /// </summary>
        [Description("内部元素鼠标抬起事件")]
        [Category("自定义")]
        public event MouseButtonEventHandler InternalElementMouseUp
        {
            add
            {
                m_InternalElementMouseUpList.Add(value);
            }
            remove
            {
                m_InternalElementMouseUpList.Remove(value);
            }
        }
        /// <summary>
        /// 匹配模板事件
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            WrapPanel box = (WrapPanel)this.GetTemplateChild("box");
            for (int i = 0; i < m_datacontext.Count; i++)
            {
                switch (m_datacontext[i].gunnum)
                {
                    case 1:
                        //1枪
                        {

                            CIMShowPile1Gun detial = new CIMShowPile1Gun();
                            detial.DataContext = m_datacontext[i];
                            detial.Margin = m_InternalElementMargin;
                            detial.Number = (i + 1).ToString("000");
                            box.Children.Add(detial);
                            for (int j = 0; j < m_InternalElementMouseUpList.Count; j++)
                            {
                                detial.MouseUp += m_InternalElementMouseUpList[j];
                            }
                            this.Items.Add(m_datacontext[i]);
                        }
                        break;
                    case 2:
                        //2枪
                        {

                            CIMShowPile2Gun detial = new CIMShowPile2Gun();
                            detial.DataContext = m_datacontext[i];
                            detial.Margin = m_InternalElementMargin;
                            detial.Number = (i + 1).ToString("000");
                            box.Children.Add(detial);
                            for (int j = 0; j < m_InternalElementMouseUpList.Count; j++)
                            {
                                detial.MouseUp += m_InternalElementMouseUpList[j];
                            }
                            this.Items.Add(m_datacontext[i]);
                        }
                        break;
                    case 4:
                        //4枪
                        {

                            CIMShowPile4Gun detial = new CIMShowPile4Gun();
                            detial.DataContext = m_datacontext[i];
                            detial.Margin = m_InternalElementMargin;
                            detial.Number = (i + 1).ToString("000");
                            box.Children.Add(detial);
                            for (int j = 0; j < m_InternalElementMouseUpList.Count; j++)
                            {
                                detial.MouseUp += m_InternalElementMouseUpList[j];
                            }
                            this.Items.Add(m_datacontext[i]);
                        }
                        break;
                }
            }
        }
    }
}
