using System;
namespace Model
{
    /// <summary>
    /// 实体类AM_CIMPolice 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class AM_CIMPolice
    {
        public AM_CIMPolice()
        { }
        #region Model
        private long? _am_cimp_id;
        private long? _cs_id;
        private int? _t_id;
        private int? _v_id;
        private long? _cp_id;
        private string _cp_code;
        private int? _cp_guncode;
        private long? _cb_id;
        private string _cb_code;
        private int? _am_cimp_condition;
        private int? _am_cimp_type;
        private bool? _am_cimp_examine;
        private DateTime? _am_d_addtime;
        /// <summary>
        /// 编号
        /// </summary>
        public long? am_cimp_id
        {
            set { _am_cimp_id = value; }
            get { return _am_cimp_id; }
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
        /// 所属充电桩（对应G_ChargePile中的编号）
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
        /// 充电状态（0未连接、1未充电、2已充电）
        /// </summary>
        public int? am_cimp_condition
        {
            set { _am_cimp_condition = value; }
            get { return _am_cimp_condition; }
        }
        /// <summary>
        /// 报警类型（对应协议内容）
        /// </summary>
        public int? am_cimp_type
        {
            set { _am_cimp_type = value; }
            get { return _am_cimp_type; }
        }
        /// <summary>
        /// 是否处理（0否1是，默认0）
        /// </summary>
        public bool? am_cimp_examine
        {
            set { _am_cimp_examine = value; }
            get { return _am_cimp_examine; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? am_d_addtime
        {
            set { _am_d_addtime = value; }
            get { return _am_d_addtime; }
        }
        #endregion Model

    }
}

