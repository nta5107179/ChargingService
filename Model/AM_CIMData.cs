using System;
namespace Model
{
    /// <summary>
    /// 实体类AM_CIMData 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class AM_CIMData
    {
        public AM_CIMData()
        { }
        #region Model
        private long? _am_cimd_id;
        private long? _cs_id;
        private int? _t_id;
        private int? _v_id;
        private long? _cp_id;
        private string _cp_code;
        private int? _cp_guncode;
        private long? _cb_id;
        private string _cb_code;
        private DateTime? _am_cimd_begintime;
        private DateTime? _am_cimd_endtime;
        private double? _am_cimd_kwh;
        private double? _am_cimd_kwhf;
        private double? _am_cimd_kwhg;
        private double? _am_cimd_kwhp;
        private double? _am_cimd_kwhj;
        private decimal? _am_cimd_unitmoney;
        private decimal? _am_cimd_money;
        private int? _am_cimd_health;
        private int? _am_cimd_chargenum;
        private long? _u_id;
        private DateTime? _am_cimd_addtime;
        /// <summary>
        /// 编号
        /// </summary>
        public long? am_cimd_id
        {
            set { _am_cimd_id = value; }
            get { return _am_cimd_id; }
        }
        /// <summary>
        /// 所属充电站（对应G_ChargeStation中的编号,默认0）
        /// </summary>
        public long? cs_id
        {
            set { _cs_id = value; }
            get { return _cs_id; }
        }
        /// <summary>
        /// 设备类型（对应G_Type中的编号）
        /// </summary>
        public int? t_id
        {
            set { _t_id = value; }
            get { return _t_id; }
        }
        /// <summary>
        /// 协议（对应G_Version中的编号）
        /// </summary>
        public int? v_id
        {
            set { _v_id = value; }
            get { return _v_id; }
        }
        /// <summary>
        /// 所属充电桩（对应G_Equipment中的编号）
        /// </summary>
        public long? cp_id
        {
            set { _cp_id = value; }
            get { return _cp_id; }
        }
        /// <summary>
        /// 设备序列号
        /// </summary>
        public string cp_code
        {
            set { _cp_code = value; }
            get { return _cp_code; }
        }
        /// <summary>
        /// 枪编码
        /// </summary>
        public int? cp_guncode
        {
            set { _cp_guncode = value; }
            get { return _cp_guncode; }
        }
        /// <summary>
        /// 所属电池（对应G_Battery中的编号）
        /// </summary>
        public long? cb_id
        {
            set { _cb_id = value; }
            get { return _cb_id; }
        }
        /// <summary>
        /// 电池序列号
        /// </summary>
        public string cb_code
        {
            set { _cb_code = value; }
            get { return _cb_code; }
        }
        /// <summary>
        /// 充电开始时间
        /// </summary>
        public DateTime? am_cimd_begintime
        {
            set { _am_cimd_begintime = value; }
            get { return _am_cimd_begintime; }
        }
        /// <summary>
        /// 充电结束时间
        /// </summary>
        public DateTime? am_cimd_endtime
        {
            set { _am_cimd_endtime = value; }
            get { return _am_cimd_endtime; }
        }
        /// <summary>
        /// 电度
        /// </summary>
        public double? am_cimd_kwh
        {
            set { _am_cimd_kwh = value; }
            get { return _am_cimd_kwh; }
        }
        /// <summary>
        /// 峰电度
        /// </summary>
        public double? am_cimd_kwhf
        {
            set { _am_cimd_kwhf = value; }
            get { return _am_cimd_kwhf; }
        }
        /// <summary>
        /// 谷电度
        /// </summary>
        public double? am_cimd_kwhg
        {
            set { _am_cimd_kwhg = value; }
            get { return _am_cimd_kwhg; }
        }
        /// <summary>
        /// 平电度
        /// </summary>
        public double? am_cimd_kwhp
        {
            set { _am_cimd_kwhp = value; }
            get { return _am_cimd_kwhp; }
        }
        /// <summary>
        /// 尖电度
        /// </summary>
        public double? am_cimd_kwhj
        {
            set { _am_cimd_kwhj = value; }
            get { return _am_cimd_kwhj; }
        }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal? am_cimd_unitmoney
        {
            set { _am_cimd_unitmoney = value; }
            get { return _am_cimd_unitmoney; }
        }
        /// <summary>
        /// 总价
        /// </summary>
        public decimal? am_cimd_money
        {
            set { _am_cimd_money = value; }
            get { return _am_cimd_money; }
        }
        /// <summary>
        /// 电池健康度
        /// </summary>
        public int? am_cimd_health
        {
            set { _am_cimd_health = value; }
            get { return _am_cimd_health; }
        }
        /// <summary>
        /// 电池充电次数
        /// </summary>
        public int? am_cimd_chargenum
        {
            set { _am_cimd_chargenum = value; }
            get { return _am_cimd_chargenum; }
        }
        /// <summary>
        /// 扣费账号（对应G_User中的编号）
        /// </summary>
        public long? u_id
        {
            set { _u_id = value; }
            get { return _u_id; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? am_cimd_addtime
        {
            set { _am_cimd_addtime = value; }
            get { return _am_cimd_addtime; }
        }
        #endregion Model

    }
}

