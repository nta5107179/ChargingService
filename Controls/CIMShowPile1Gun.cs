using Model.Project;
using System;
using System.Collections.Generic;
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
    ///     xmlns:MyNamespace="clr-namespace:Controls.CIM"
    ///
    ///
    /// 步骤 1b) 在其他项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根 
    /// 元素中: 
    ///
    ///     xmlns:MyNamespace="clr-namespace:Controls.CIM;assembly=Controls.CIM"
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
    ///     <MyNamespace:DetialPile/>
    ///
    /// </summary>
    public class CIMShowPile1Gun : Control
    {
        public static readonly DependencyProperty PoliceVisibilityProperty;
        public static readonly DependencyProperty GunCondition0VisibilityProperty;
        public static readonly DependencyProperty GunCondition1VisibilityProperty;
        public static readonly DependencyProperty GunCondition2VisibilityProperty;
        public static readonly DependencyProperty GunCondition3VisibilityProperty;

        static CIMShowPile1Gun()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CIMShowPile1Gun), new FrameworkPropertyMetadata(typeof(CIMShowPile1Gun)));

            //为PoliceVisibility创建依赖
            var police = new FrameworkPropertyMetadata((Visibility)Visibility.Collapsed);
            PoliceVisibilityProperty = DependencyProperty.RegisterAttached("PoliceVisibility", typeof(Visibility), typeof(CIMShowPile1Gun), police);
            //为GunCondition0Visibility创建依赖
            var guncondition0 = new FrameworkPropertyMetadata((Visibility)Visibility.Hidden);
            GunCondition0VisibilityProperty = DependencyProperty.RegisterAttached("GunCondition0Visibility", typeof(Visibility), typeof(CIMShowPile1Gun), guncondition0);
            //为GunCondition1Visibility创建依赖
            var guncondition1 = new FrameworkPropertyMetadata((Visibility)Visibility.Hidden);
            GunCondition1VisibilityProperty = DependencyProperty.RegisterAttached("GunCondition1Visibility", typeof(Visibility), typeof(CIMShowPile1Gun), guncondition1);
            //为GunCondition2Visibility创建依赖
            var guncondition2 = new FrameworkPropertyMetadata((Visibility)Visibility.Hidden);
            GunCondition2VisibilityProperty = DependencyProperty.RegisterAttached("GunCondition2Visibility", typeof(Visibility), typeof(CIMShowPile1Gun), guncondition2);
            //为GunCondition3Visibility创建依赖
            var guncondition3 = new FrameworkPropertyMetadata((Visibility)Visibility.Hidden);
            GunCondition3VisibilityProperty = DependencyProperty.RegisterAttached("GunCondition3Visibility", typeof(Visibility), typeof(CIMShowPile1Gun), guncondition3);
        }

        Visibility m_PoliceVisibility = Visibility.Collapsed;
        Visibility m_GunCondition0Visibility = Visibility.Hidden;
        Visibility m_GunCondition1Visibility = Visibility.Hidden;
        Visibility m_GunCondition2Visibility = Visibility.Hidden;
        Visibility m_GunCondition3Visibility = Visibility.Hidden;
        string m_Number = "00";

        /// <summary>
        /// 报警图标的显示状态
        /// </summary>
        [Description("报警图标的显示状态")]
        [Category("自定义")]
        public Visibility PoliceVisibility
        {
            get
            {
                return m_PoliceVisibility;
            }
            set
            {
                m_PoliceVisibility = value;
            }
        }
        /// <summary>
        /// 枪0图标的显示状态
        /// </summary>
        [Description("枪1图标的显示状态")]
        [Category("自定义")]
        public Visibility GunCondition0Visibility
        {
            get
            {
                return m_GunCondition0Visibility;
            }
            set
            {
                m_GunCondition0Visibility = value;
            }
        }
        /// <summary>
        /// 枪1图标的显示状态
        /// </summary>
        [Description("枪1图标的显示状态")]
        [Category("自定义")]
        public Visibility GunCondition1Visibility
        {
            get
            {
                return m_GunCondition1Visibility;
            }
            set
            {
                m_GunCondition1Visibility = value;
            }
        }
        /// <summary>
        /// 枪2图标的显示状态
        /// </summary>
        [Description("枪2图标的显示状态")]
        [Category("自定义")]
        public Visibility GunCondition2Visibility
        {
            get
            {
                return m_GunCondition2Visibility;
            }
            set
            {
                m_GunCondition2Visibility = value;
            }
        }
        /// <summary>
        /// 枪3图标的显示状态
        /// </summary>
        [Description("枪3图标的显示状态")]
        [Category("自定义")]
        public Visibility GunCondition3Visibility
        {
            get
            {
                return m_GunCondition3Visibility;
            }
            set
            {
                m_GunCondition3Visibility = value;
            }
        }
        /// <summary>
        /// 编号
        /// </summary>
        [Description("编号")]
        [Category("自定义")]
        public string Number
        {
            get
            {
                return m_Number;
            }
            set
            {
                m_Number = value;
            }
        }
        /// <summary>
        /// 匹配模板事件
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            //绑定的数据
            Label lab = (Label)this.GetTemplateChild("lab_number");
            lab.Content = m_Number;
        }
    }
}
