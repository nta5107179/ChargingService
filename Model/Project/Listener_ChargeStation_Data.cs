using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
namespace Model.Project
{
    /// <summary>
    /// CIM_DataGrid，充电监控列表显示
    /// </summary>
    [Serializable]
    public partial class Listener_ChargeStation_Data : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Listener_ChargeStation_Data()
        { }
        #region Model
        private Brush _brush = Brushes.Black;
        private Visibility _visibility = System.Windows.Visibility.Visible;
        private string _name;
        private long _csid;
        private string _linkcondition;
        private int? _pid;
        private int? _cid;
        private int? _did;
        private string _place;
        private string _wsum;
        private string _cpsum_ac;
        private string _cpsum_dc;
        private string _hascs = "否";

        /// <summary>
        /// 行颜色
        /// </summary>
        public Brush brush
        {
            set { _brush = value; prochanged("brush"); }
            get { return _brush; }
        }
        /// <summary>
        /// 行展示形式
        /// </summary>
        public Visibility visibility
        {
            set { _visibility = value; prochanged("visibility"); }
            get { return _visibility; }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string name
        {
            set { _name = value; prochanged("name"); }
            get { return _name; }
        }
        /// <summary>
        /// 充电站编号
        /// </summary>
        public long csid
        {
            set { _csid = value; prochanged("csid"); }
            get { return _csid; }
        }
        /// <summary>
        /// 省编号
        /// </summary>
        public int? pid
        {
            set { _pid = value; prochanged("pid"); }
            get { return _pid; }
        }
        /// <summary>
        /// 市编号
        /// </summary>
        public int? cid
        {
            set { _cid = value; prochanged("cid"); }
            get { return _cid; }
        }
        /// <summary>
        /// 区编号
        /// </summary>
        public int? did
        {
            set { _did = value; prochanged("did"); }
            get { return _did; }
        }
        /// <summary>
        /// 地址
        /// </summary>
        public string place
        {
            set { _place = value; prochanged("place"); }
            get { return _place; }
        }
        /// <summary>
        /// 交流充电桩连接数
        /// </summary>
        public string cpsum_ac
        {
            set { _cpsum_ac = value; prochanged("cpsum_ac"); }
            get { return _cpsum_ac; }
        }
        /// <summary>
        /// 直流充电桩连接数
        /// </summary>
        public string cpsum_dc
        {
            set { _cpsum_dc = value; prochanged("cpsum_dc"); }
            get { return _cpsum_dc; }
        }
        /// <summary>
        /// 充电站是否连接
        /// </summary>
        public string hascs
        {
            set { _hascs = value; prochanged("hascs"); }
            get { return _hascs; }
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

