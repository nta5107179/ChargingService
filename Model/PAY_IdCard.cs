using System;
namespace Model
{
    /// <summary>
    /// 实体类PAY_IdCard 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class PAY_IdCard
    {
        public PAY_IdCard()
        { }
        #region Model
        private long? _pay_ic_id;
        private long? _u_id;
        private long? _pay_ic_pid;
        private int? _p_id;
        private int? _c_id;
        private int? _d_id;
        private int? _s_id;
        private int? _cm_id;
        private string _pcdscm_address;
        private DateTime? _pay_ic_addtime;
        /// <summary>
        /// 编号/卡号
        /// </summary>
        public long? pay_ic_id
        {
            set { _pay_ic_id = value; }
            get { return _pay_ic_id; }
        }
        /// <summary>
        /// 所属用户（对应G_User中的编号）
        /// </summary>
        public long? u_id
        {
            set { _u_id = value; }
            get { return _u_id; }
        }
        /// <summary>
        /// 父卡号
        /// </summary>
        public long? pay_ic_pid
        {
            set { _pay_ic_pid = value; }
            get { return _pay_ic_pid; }
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
        /// 添加时间
        /// </summary>
        public DateTime? pay_ic_addtime
        {
            set { _pay_ic_addtime = value; }
            get { return _pay_ic_addtime; }
        }
        #endregion Model

    }
}

