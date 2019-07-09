using System;
namespace Model
{
    /// <summary>
    /// 实体类G_ChargePile 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class G_ChargePile
    {
        public G_ChargePile()
        { }
        #region Model
        private long? _cp_id;
        private long? _cs_id;
        private int? _t_id;
        private int? _v_id;
        private int? _cp_chargemod;
        private string _cp_name;
        private string _cp_code;
        private double? _cp_lng;
        private string _cp_lng_mark;
        private double? _cp_lat;
        private string _cp_lat_mark;
        private double? _cp_gglng;
        private double? _cp_gglat;
        private double? _cp_bdlng;
        private double? _cp_bdlat;
        private int? _p_id;
        private int? _c_id;
        private int? _d_id;
        private int? _s_id;
        private int? _cm_id;
        private string _pcdscm_address;
        private decimal? _cp_money;
        private int? _cp_operation;
        private int? _cp_gunnum;
        private bool? _cp_examine;
        private DateTime? _cp_addtime;
        private string _cp_type;
        private string _cp_model;
        private string _cp_company;
        private string _cp_amod;
        private string _cp_v;
        private string _cp_a;
        private int? _cp_wid;
        /// <summary>
        /// 编号（自订）
        /// </summary>
        public long? cp_id
        {
            set { _cp_id = value; }
            get { return _cp_id; }
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
        /// 充电模式（1交流，2直流，3交直流）
        /// </summary>
        public int? cp_chargemod
        {
            set { _cp_chargemod = value; }
            get { return _cp_chargemod; }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string cp_name
        {
            set { _cp_name = value; }
            get { return _cp_name; }
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
        /// 经度（原始）
        /// </summary>
        public double? cp_lng
        {
            set { _cp_lng = value; }
            get { return _cp_lng; }
        }
        /// <summary>
        /// 经度标志（E东经，W西经）
        /// </summary>
        public string cp_lng_mark
        {
            set { _cp_lng_mark = value; }
            get { return _cp_lng_mark; }
        }
        /// <summary>
        /// 纬度（原始）
        /// </summary>
        public double? cp_lat
        {
            set { _cp_lat = value; }
            get { return _cp_lat; }
        }
        /// <summary>
        /// 纬度标志（N北纬，S南纬）
        /// </summary>
        public string cp_lat_mark
        {
            set { _cp_lat_mark = value; }
            get { return _cp_lat_mark; }
        }
        /// <summary>
        /// 经度（谷歌）
        /// </summary>
        public double? cp_gglng
        {
            set { _cp_gglng = value; }
            get { return _cp_gglng; }
        }
        /// <summary>
        /// 纬度（谷歌）
        /// </summary>
        public double? cp_gglat
        {
            set { _cp_gglat = value; }
            get { return _cp_gglat; }
        }
        /// <summary>
        /// 经度（百度）
        /// </summary>
        public double? cp_bdlng
        {
            set { _cp_bdlng = value; }
            get { return _cp_bdlng; }
        }
        /// <summary>
        /// 纬度（百度）
        /// </summary>
        public double? cp_bdlat
        {
            set { _cp_bdlat = value; }
            get { return _cp_bdlat; }
        }
        /// <summary>
        /// 地址-省
        /// </summary>
        public int? p_id
        {
            set { _p_id = value; }
            get { return _p_id; }
        }
        /// <summary>
        /// 地址-市
        /// </summary>
        public int? c_id
        {
            set { _c_id = value; }
            get { return _c_id; }
        }
        /// <summary>
        /// 地址-区
        /// </summary>
        public int? d_id
        {
            set { _d_id = value; }
            get { return _d_id; }
        }
        /// <summary>
        /// 地址-街道
        /// </summary>
        public int? s_id
        {
            set { _s_id = value; }
            get { return _s_id; }
        }
        /// <summary>
        /// 地址-社区
        /// </summary>
        public int? cm_id
        {
            set { _cm_id = value; }
            get { return _cm_id; }
        }
        /// <summary>
        /// 地址-详细地址
        /// </summary>
        public string pcdscm_address
        {
            set { _pcdscm_address = value; }
            get { return _pcdscm_address; }
        }
        /// <summary>
        /// 峰电价
        /// </summary>
        public decimal? cp_money
        {
            set { _cp_money = value; }
            get { return _cp_money; }
        }
        /// <summary>
        /// 经营模式（0自营，1非自营）
        /// </summary>
        public int? cp_operation
        {
            set { _cp_operation = value; }
            get { return _cp_operation; }
        }
        /// <summary>
        /// 枪数量
        /// </summary>
        public int? cp_gunnum
        {
            set { _cp_gunnum = value; }
            get { return _cp_gunnum; }
        }
        /// <summary>
        /// 是否审核（0否1是，默认1）
        /// </summary>
        public bool? cp_examine
        {
            set { _cp_examine = value; }
            get { return _cp_examine; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? cp_addtime
        {
            set { _cp_addtime = value; }
            get { return _cp_addtime; }
        }
        /// <summary>
        /// 设备类型
        /// </summary>
        public string cp_type
        {
            set { _cp_type = value; }
            get { return _cp_type; }
        }
        /// <summary>
        /// 设备型号
        /// </summary>
        public string cp_model
        {
            set { _cp_model = value; }
            get { return _cp_model; }
        }
        /// <summary>
        /// 制造企业
        /// </summary>
        public string cp_company
        {
            set { _cp_company = value; }
            get { return _cp_company; }
        }
        /// <summary>
        /// 输出电流模式
        /// </summary>
        public string cp_amod
        {
            set { _cp_amod = value; }
            get { return _cp_amod; }
        }
        /// <summary>
        /// 输出电压
        /// </summary>
        public string cp_v
        {
            set { _cp_v = value; }
            get { return _cp_v; }
        }
        /// <summary>
        /// 输出电流
        /// </summary>
        public string cp_a
        {
            set { _cp_a = value; }
            get { return _cp_a; }
        }
        /// <summary>
        /// 流水号
        /// </summary>
        public int? cp_wid
        {
            set { _cp_wid = value; }
            get { return _cp_wid; }
        }
        #endregion Model

    }
}

