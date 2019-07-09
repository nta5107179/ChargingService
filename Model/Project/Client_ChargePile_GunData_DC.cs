using System;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Media;
namespace Model.Project
{
    /// <summary>
    /// 表示交流充电桩数据
    /// </summary>
    [Serializable]
    public partial class Client_ChargePile_GunData_DC : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Client_ChargePile_GunData_DC()
        { }
        #region Model

        //以下内容需要在心跳时变更
        private DateTime? _begintime = null;//充电开始时间

        //以下内容需要在报警时变更
        private bool? _ispolice = false;//0未报警，1报警
        private string _police = null;//报警内容
        private int? _policecode = 0;//报警码

        //以下内容需要在获取充电数据时变更
        private bool? _guncondition = false;//枪是否充电状态
        private long? _useruname = 0;//充电用户
        private double? _kwh = 0;//已充电量
        private TimeSpan? _timeleft = new TimeSpan(0);//剩余时间
        private int? _chargemod = 0;//充电模式，1按时间、2按金额、3按电量、4自动充满
        private double? _chargemodcontent = 0;//数值（当2为4时，此值为0）
        private string _cb_code = "00000000000000000000000000000000";//电池编码
        private int _guncode = 0;//枪编号
        private double _uab = 0;//1相电压
        private double _ubc = 0;//2相电压
        private double _uca = 0;//3相电压
        private double _ia = 0;//1相电流
        private double _ib = 0;//2相电流
        private double _ic = 0;//3相电流
        private double _pw = 0;//有功功率
        private double _qw = 0;//无功功率
        private double _cos = 0;//功率因数

        
        /// <summary>
        /// 枪是否充电状态
        /// </summary>
        public bool? guncondition
        {
            set { _guncondition = value; prochanged("guncondition"); }
            get { return _guncondition; }
        }
        /// <summary>
        /// 充电用户
        /// </summary>
        public long? useruname
        {
            set { _useruname = value; prochanged("useruname"); }
            get { return _useruname; }
        }
        /// <summary>
        /// 是否报警
        /// </summary>
        public bool? ispolice
        {
            set { _ispolice = value; prochanged("ispolice"); }
            get { return _ispolice; }
        }
        /// <summary>
        /// 报警内容
        /// </summary>
        public string police
        {
            set { _police = value; prochanged("police"); }
            get { return _police; }
        }
        /// <summary>
        /// 报警码
        /// </summary>
        public int? policecode
        {
            set { _policecode = value; prochanged("policecode"); }
            get { return _policecode; }
        }
        /// <summary>
        /// 充电开始时间
        /// </summary>
        public DateTime? begintime
        {
            set { _begintime = value; prochanged("begintime"); }
            get { return _begintime; }
        }

        /// <summary>
        /// 已充电量
        /// </summary>
        public double? kwh
        {
            set { _kwh = value; prochanged("kwh"); }
            get { return _kwh; }
        }

        /// <summary>
        /// 剩余时间
        /// </summary>
        public TimeSpan? timeleft
        {
            set { _timeleft = value; prochanged("timeleft"); }
            get { return _timeleft; }
        }

        /// <summary>
        /// 充电模式，1按时间、2按金额、3按电量、4自动充满
        /// </summary>
        public int? chargemod
        {
            set { _chargemod = value; prochanged("chargemod"); }
            get { return _chargemod; }
        }

        /// <summary>
        /// 数值（当2为4时，此值为0）
        /// </summary>
        public double? chargemodcontent
        {
            set { _chargemodcontent = value; prochanged("chargemodcontent"); }
            get { return _chargemodcontent; }
        }
        /// <summary>
        /// 电池编码
        /// </summary>
        public string cb_code
        {
            set { _cb_code = value; prochanged("cb_code"); }
            get { return _cb_code; }
        }/// <summary>
        /// 枪编号
        /// </summary>
        public int guncode
        {
            set { _guncode = value; prochanged("guncode"); }
            get { return _guncode; }
        }
        /// <summary>
        /// 电压uab
        /// </summary>
        public double uab
        {
            set { _uab = value; prochanged("uab"); }
            get { return _uab; }
        }
        /// <summary>
        /// 电压ubc
        /// </summary>
        public double ubc
        {
            set { _ubc = value; prochanged("ubc"); }
            get { return _ubc; }
        }
        /// <summary>
        /// 电压uca
        /// </summary>
        public double uca
        {
            set { _uca = value; prochanged("uca"); }
            get { return _uca; }
        }
        /// <summary>
        /// 电流ia
        /// </summary>
        public double ia
        {
            set { _ia = value; prochanged("ia"); }
            get { return _ia; }
        }
        /// <summary>
        /// 电流ib
        /// </summary>
        public double ib
        {
            set { _ib = value; prochanged("ib"); }
            get { return _ib; }
        }
        /// <summary>
        /// 电流ic
        /// </summary>
        public double ic
        {
            set { _ic = value; prochanged("ic"); }
            get { return _ic; }
        }
        /// <summary>
        /// 有功功率
        /// </summary>
        public double pw
        {
            set { _pw = value; prochanged("pw"); }
            get { return _pw; }
        }
        /// <summary>
        /// 无功功率
        /// </summary>
        public double qw
        {
            set { _qw = value; prochanged("qw"); }
            get { return _qw; }
        }
        /// <summary>
        /// 功率因数
        /// </summary>
        public double cos
        {
            set { _cos = value; prochanged("cos"); }
            get { return _cos; }
        }
        #endregion
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

