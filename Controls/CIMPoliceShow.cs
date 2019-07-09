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
    ///     <MyNamespace:CIMShowDetialGun/>
    ///
    /// </summary>
    public class CIMPoliceShow : Control
    {
        static CIMPoliceShow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CIMPoliceShow), new FrameworkPropertyMetadata(typeof(CIMPoliceShow)));
        }

        List<MouseButtonEventHandler> m_InternalElementMouseUpList = new List<MouseButtonEventHandler>();
        string m_content = "";

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
        /// 获取或设置错误内容
        /// </summary>
        [Description("获取或设置错误内容")]
        [Category("自定义")]
        public string Text
        {
            get
            {
                return m_content;
            }
            set
            {
                m_content = value;
            }
        }
        /// <summary>
        /// 匹配模板事件
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            Label label = (Label)this.GetTemplateChild("lab_solve");
            for (int i = 0; i < m_InternalElementMouseUpList.Count; i++)
            {
                label.MouseUp += m_InternalElementMouseUpList[i];
            }
            TextBlock text = (TextBlock)this.GetTemplateChild("text_content");
            text.Text = m_content;
        }
    }
}
