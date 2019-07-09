using System;
namespace Model
{
    /// <summary>
    /// ʵ����AM_CIMData ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
        /// ���
        /// </summary>
        public long? am_cimd_id
        {
            set { _am_cimd_id = value; }
            get { return _am_cimd_id; }
        }
        /// <summary>
        /// �������վ����ӦG_ChargeStation�еı��,Ĭ��0��
        /// </summary>
        public long? cs_id
        {
            set { _cs_id = value; }
            get { return _cs_id; }
        }
        /// <summary>
        /// �豸���ͣ���ӦG_Type�еı�ţ�
        /// </summary>
        public int? t_id
        {
            set { _t_id = value; }
            get { return _t_id; }
        }
        /// <summary>
        /// Э�飨��ӦG_Version�еı�ţ�
        /// </summary>
        public int? v_id
        {
            set { _v_id = value; }
            get { return _v_id; }
        }
        /// <summary>
        /// �������׮����ӦG_Equipment�еı�ţ�
        /// </summary>
        public long? cp_id
        {
            set { _cp_id = value; }
            get { return _cp_id; }
        }
        /// <summary>
        /// �豸���к�
        /// </summary>
        public string cp_code
        {
            set { _cp_code = value; }
            get { return _cp_code; }
        }
        /// <summary>
        /// ǹ����
        /// </summary>
        public int? cp_guncode
        {
            set { _cp_guncode = value; }
            get { return _cp_guncode; }
        }
        /// <summary>
        /// ������أ���ӦG_Battery�еı�ţ�
        /// </summary>
        public long? cb_id
        {
            set { _cb_id = value; }
            get { return _cb_id; }
        }
        /// <summary>
        /// ������к�
        /// </summary>
        public string cb_code
        {
            set { _cb_code = value; }
            get { return _cb_code; }
        }
        /// <summary>
        /// ��翪ʼʱ��
        /// </summary>
        public DateTime? am_cimd_begintime
        {
            set { _am_cimd_begintime = value; }
            get { return _am_cimd_begintime; }
        }
        /// <summary>
        /// ������ʱ��
        /// </summary>
        public DateTime? am_cimd_endtime
        {
            set { _am_cimd_endtime = value; }
            get { return _am_cimd_endtime; }
        }
        /// <summary>
        /// ���
        /// </summary>
        public double? am_cimd_kwh
        {
            set { _am_cimd_kwh = value; }
            get { return _am_cimd_kwh; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public double? am_cimd_kwhf
        {
            set { _am_cimd_kwhf = value; }
            get { return _am_cimd_kwhf; }
        }
        /// <summary>
        /// �ȵ��
        /// </summary>
        public double? am_cimd_kwhg
        {
            set { _am_cimd_kwhg = value; }
            get { return _am_cimd_kwhg; }
        }
        /// <summary>
        /// ƽ���
        /// </summary>
        public double? am_cimd_kwhp
        {
            set { _am_cimd_kwhp = value; }
            get { return _am_cimd_kwhp; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public double? am_cimd_kwhj
        {
            set { _am_cimd_kwhj = value; }
            get { return _am_cimd_kwhj; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public decimal? am_cimd_unitmoney
        {
            set { _am_cimd_unitmoney = value; }
            get { return _am_cimd_unitmoney; }
        }
        /// <summary>
        /// �ܼ�
        /// </summary>
        public decimal? am_cimd_money
        {
            set { _am_cimd_money = value; }
            get { return _am_cimd_money; }
        }
        /// <summary>
        /// ��ؽ�����
        /// </summary>
        public int? am_cimd_health
        {
            set { _am_cimd_health = value; }
            get { return _am_cimd_health; }
        }
        /// <summary>
        /// ��س�����
        /// </summary>
        public int? am_cimd_chargenum
        {
            set { _am_cimd_chargenum = value; }
            get { return _am_cimd_chargenum; }
        }
        /// <summary>
        /// �۷��˺ţ���ӦG_User�еı�ţ�
        /// </summary>
        public long? u_id
        {
            set { _u_id = value; }
            get { return _u_id; }
        }
        /// <summary>
        /// ���ʱ��
        /// </summary>
        public DateTime? am_cimd_addtime
        {
            set { _am_cimd_addtime = value; }
            get { return _am_cimd_addtime; }
        }
        #endregion Model

    }
}

