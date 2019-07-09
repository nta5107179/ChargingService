using System;
namespace Model
{
    /// <summary>
    /// 实体类G_User 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class G_User
    {
        public G_User()
        { }
        #region Model
        private long? _u_id;
        private long? _u_uname;
        private string _u_pwd;
        private string _u_paypwd;
        private string _u_filename;
        private string _u_email;
        private string _u_tname;
        private int? _p_id;
        private int? _c_id;
        private int? _d_id;
        private int? _s_id;
        private int? _cm_id;
        private string _pcdscm_address;
        private decimal? _u_money;
        private bool? _u_examine;
        private DateTime? _u_addtime;
        /// <summary>
        /// 编号
        /// </summary>
        public long? u_id
        {
            set { _u_id = value; }
            get { return _u_id; }
        }
        /// <summary>
        /// 用户名/手机号
        /// </summary>
        public long? u_uname
        {
            set { _u_uname = value; }
            get { return _u_uname; }
        }
        /// <summary>
        /// 密码（DES加密）
        /// </summary>
        public string u_pwd
        {
            set { _u_pwd = value; }
            get { return _u_pwd; }
        }
        /// <summary>
        /// 支付密码（DES加密）
        /// </summary>
        public string u_paypwd
        {
            set { _u_paypwd = value; }
            get { return _u_paypwd; }
        }
        /// <summary>
        /// 文件名
        /// </summary>
        public string u_filename
        {
            set { _u_filename = value; }
            get { return _u_filename; }
        }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string u_email
        {
            set { _u_email = value; }
            get { return _u_email; }
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string u_tname
        {
            set { _u_tname = value; }
            get { return _u_tname; }
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
        /// 余额
        /// </summary>
        public decimal? u_money
        {
            set { _u_money = value; }
            get { return _u_money; }
        }
        /// <summary>
        /// 是否审核（0否1是，默认1）
        /// </summary>
        public bool? u_examine
        {
            set { _u_examine = value; }
            get { return _u_examine; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? u_addtime
        {
            set { _u_addtime = value; }
            get { return _u_addtime; }
        }
        #endregion Model

    }
}

