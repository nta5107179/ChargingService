using System;
namespace Model
{
    /// <summary>
    /// ʵ����AM_CIMPolice ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
        /// ���
        /// </summary>
        public long? am_cimp_id
        {
            set { _am_cimp_id = value; }
            get { return _am_cimp_id; }
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
        /// �������׮����ӦG_ChargePile�еı�ţ�
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
        /// ���״̬��0δ���ӡ�1δ��硢2�ѳ�磩
        /// </summary>
        public int? am_cimp_condition
        {
            set { _am_cimp_condition = value; }
            get { return _am_cimp_condition; }
        }
        /// <summary>
        /// �������ͣ���ӦЭ�����ݣ�
        /// </summary>
        public int? am_cimp_type
        {
            set { _am_cimp_type = value; }
            get { return _am_cimp_type; }
        }
        /// <summary>
        /// �Ƿ���0��1�ǣ�Ĭ��0��
        /// </summary>
        public bool? am_cimp_examine
        {
            set { _am_cimp_examine = value; }
            get { return _am_cimp_examine; }
        }
        /// <summary>
        /// ���ʱ��
        /// </summary>
        public DateTime? am_d_addtime
        {
            set { _am_d_addtime = value; }
            get { return _am_d_addtime; }
        }
        #endregion Model

    }
}

