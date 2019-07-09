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
    public partial class Listener_ChargePile_GunData_DC
    {
        public Listener_ChargePile_GunData_DC()
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

        
        /// <summary>
        /// 枪是否充电状态
        /// </summary>
        public bool? guncondition
        {
            set { _guncondition = value; }
            get { return _guncondition; }
        }
        /// <summary>
        /// 充电用户
        /// </summary>
        public long? useruname
        {
            set { _useruname = value; }
            get { return _useruname; }
        }
        /// <summary>
        /// 是否报警
        /// </summary>
        public bool? ispolice
        {
            set { _ispolice = value; }
            get { return _ispolice; }
        }
        /// <summary>
        /// 报警内容
        /// </summary>
        public string police
        {
            set { _police = value; }
            get { return _police; }
        }
        /// <summary>
        /// 报警码
        /// </summary>
        public int? policecode
        {
            set { _policecode = value; }
            get { return _policecode; }
        }
        /// <summary>
        /// 充电开始时间
        /// </summary>
        public DateTime? begintime
        {
            set { _begintime = value; }
            get { return _begintime; }
        }

        /// <summary>
        /// 已充电量
        /// </summary>
        public double? kwh
        {
            set { _kwh = value; }
            get { return _kwh; }
        }

        /// <summary>
        /// 剩余时间
        /// </summary>
        public TimeSpan? timeleft
        {
            set { _timeleft = value; }
            get { return _timeleft; }
        }

        /// <summary>
        /// 充电模式，1按时间、2按金额、3按电量、4自动充满
        /// </summary>
        public int? chargemod
        {
            set { _chargemod = value; }
            get { return _chargemod; }
        }

        /// <summary>
        /// 数值（当2为4时，此值为0）
        /// </summary>
        public double? chargemodcontent
        {
            set { _chargemodcontent = value; }
            get { return _chargemodcontent; }
        }
        /// <summary>
        /// 电池编码
        /// </summary>
        public string cb_code
        {
            set { _cb_code = value; }
            get { return _cb_code; }
        }
        #endregion
    }
}

