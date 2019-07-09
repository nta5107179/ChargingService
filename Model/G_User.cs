using System;
namespace Model
{
    /// <summary>
    /// ʵ����G_User ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
        /// ���
        /// </summary>
        public long? u_id
        {
            set { _u_id = value; }
            get { return _u_id; }
        }
        /// <summary>
        /// �û���/�ֻ���
        /// </summary>
        public long? u_uname
        {
            set { _u_uname = value; }
            get { return _u_uname; }
        }
        /// <summary>
        /// ���루DES���ܣ�
        /// </summary>
        public string u_pwd
        {
            set { _u_pwd = value; }
            get { return _u_pwd; }
        }
        /// <summary>
        /// ֧�����루DES���ܣ�
        /// </summary>
        public string u_paypwd
        {
            set { _u_paypwd = value; }
            get { return _u_paypwd; }
        }
        /// <summary>
        /// �ļ���
        /// </summary>
        public string u_filename
        {
            set { _u_filename = value; }
            get { return _u_filename; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string u_email
        {
            set { _u_email = value; }
            get { return _u_email; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string u_tname
        {
            set { _u_tname = value; }
            get { return _u_tname; }
        }
        /// <summary>
        /// ��ַ-ʡ
        /// </summary>
        public int? p_id
        {
            set { _p_id = value; }
            get { return _p_id; }
        }
        /// <summary>
        /// ��ַ-��
        /// </summary>
        public int? c_id
        {
            set { _c_id = value; }
            get { return _c_id; }
        }
        /// <summary>
        /// ��ַ-��
        /// </summary>
        public int? d_id
        {
            set { _d_id = value; }
            get { return _d_id; }
        }
        /// <summary>
        /// ��ַ-�ֵ�
        /// </summary>
        public int? s_id
        {
            set { _s_id = value; }
            get { return _s_id; }
        }
        /// <summary>
        /// ��ַ-����
        /// </summary>
        public int? cm_id
        {
            set { _cm_id = value; }
            get { return _cm_id; }
        }
        /// <summary>
        /// ��ַ-��ϸ��ַ
        /// </summary>
        public string pcdscm_address
        {
            set { _pcdscm_address = value; }
            get { return _pcdscm_address; }
        }
        /// <summary>
        /// ���
        /// </summary>
        public decimal? u_money
        {
            set { _u_money = value; }
            get { return _u_money; }
        }
        /// <summary>
        /// �Ƿ���ˣ�0��1�ǣ�Ĭ��1��
        /// </summary>
        public bool? u_examine
        {
            set { _u_examine = value; }
            get { return _u_examine; }
        }
        /// <summary>
        /// ���ʱ��
        /// </summary>
        public DateTime? u_addtime
        {
            set { _u_addtime = value; }
            get { return _u_addtime; }
        }
        #endregion Model

    }
}

