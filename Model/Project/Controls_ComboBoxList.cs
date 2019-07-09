using System;
using System.ComponentModel;
using System.Windows.Controls;
namespace Model.Project
{
    /// <summary>
    /// CIM_DataGrid，充电监控列表显示
    /// </summary>
    [Serializable]
    public partial class Controls_ComboBoxList : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Controls_ComboBoxList()
        { }
        #region Model
        private string _pvalue;
        private string _text;
        private string _value;

        /// <summary>
        /// text
        /// </summary>
        public string pvalue
        {
            set { _pvalue = value; prochanged("pvalue"); }
            get { return _pvalue; }
        }
        /// <summary>
        /// text
        /// </summary>
        public string text
        {
            set { _text = value; prochanged("text"); }
            get { return _text; }
        }
        /// <summary>
        /// value
        /// </summary>
        public string value
        {
            set { _value = value; prochanged("value"); }
            get { return _value; }
        }
        #endregion Model
        private void prochanged(string info)
        {
            if (PropertyChanged != null)
            {
                //是不是很奇怪，这个事件发起后，处理函数在哪里？
                //我也不知道在哪里，我只知道，绑定成功后WPF会帮我们决定怎么处理。
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}

