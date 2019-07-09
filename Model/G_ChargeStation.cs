using System;
namespace Model
{
    /// <summary>
    /// ʵ����G_ChargeStation ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public class G_ChargeStation
    {
        public G_ChargeStation()
        { }
        #region Model
        private long? _cs_id;
        private string _cs_uname;
        private string _cs_pwd;
        private string _cs_name;
        private string _cs_phone;
        private string _cs_appfilename;
        private double? _cs_lng;
        private string _cs_lng_mark;
        private double? _cs_lat;
        private string _cs_lat_mark;
        private double? _cs_gglng;
        private double? _cs_gglat;
        private double? _cs_bdlng;
        private double? _cs_bdlat;
        private int? _p_id;
        private int? _c_id;
        private int? _d_id;
        private int? _s_id;
        private int? _cm_id;
        private string _pcdscm_address;
        private DateTime? _cs_endtime;
        private double? _cs_power;
        private int? _cs_operation;
        private bool? _cs_ispub;
        private bool? _cs_examine;
        private DateTime? _cs_addtime;
        private bool? _cs_isglobal;

        private int? _cp_number;
        /// <summary>
        /// ��ţ��Զ���
        /// </summary>
        public long? cs_id
        {
            set { _cs_id = value; }
            get { return _cs_id; }
        }
        /// <summary>
        /// �û���
        /// </summary>
        public string cs_uname
        {
            set { _cs_uname = value; }
            get { return _cs_uname; }
        }
        /// <summary>
        /// ���루DES���ܣ�
        /// </summary>
        public string cs_pwd
        {
            set { _cs_pwd = value; }
            get { return _cs_pwd; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string cs_name
        {
            set { _cs_name = value; }
            get { return _cs_name; }
        }
        /// <summary>
        /// �绰
        /// </summary>
        public string cs_phone
        {
            set { _cs_phone = value; }
            get { return _cs_phone; }
        }
        /// <summary>
        /// appʹ���ļ���
        /// </summary>
        public string cs_appfilename
        {
            set { _cs_appfilename = value; }
            get { return _cs_appfilename; }
        }
        /// <summary>
        /// ���ȣ�ԭʼ��
        /// </summary>
        public double? cs_lng
        {
            set { _cs_lng = value; }
            get { return _cs_lng; }
        }
        /// <summary>
        /// ���ȱ�־��E������W������
        /// </summary>
        public string cs_lng_mark
        {
            set { _cs_lng_mark = value; }
            get { return _cs_lng_mark; }
        }
        /// <summary>
        /// γ�ȣ�ԭʼ��
        /// </summary>
        public double? cs_lat
        {
            set { _cs_lat = value; }
            get { return _cs_lat; }
        }
        /// <summary>
        /// γ�ȱ�־��N��γ��S��γ��
        /// </summary>
        public string cs_lat_mark
        {
            set { _cs_lat_mark = value; }
            get { return _cs_lat_mark; }
        }
        /// <summary>
        /// ���ȣ��ȸ裩
        /// </summary>
        public double? cs_gglng
        {
            set { _cs_gglng = value; }
            get { return _cs_gglng; }
        }
        /// <summary>
        /// γ�ȣ��ȸ裩
        /// </summary>
        public double? cs_gglat
        {
            set { _cs_gglat = value; }
            get { return _cs_gglat; }
        }
        /// <summary>
        /// ���ȣ��ٶȣ�
        /// </summary>
        public double? cs_bdlng
        {
            set { _cs_bdlng = value; }
            get { return _cs_bdlng; }
        }
        /// <summary>
        /// γ�ȣ��ٶȣ�
        /// </summary>
        public double? cs_bdlat
        {
            set { _cs_bdlat = value; }
            get { return _cs_bdlat; }
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
        /// ��Ч�ڵ�
        /// </summary>
        public DateTime? cs_endtime
        {
            set { _cs_endtime = value; }
            get { return _cs_endtime; }
        }
        /// <summary>
        /// ��������ʣ�W��
        /// </summary>
        public double? cs_power
        {
            set { _cs_power = value; }
            get { return _cs_power; }
        }
        /// <summary>
        /// ��Ӫģʽ��1��Ӫ��2����Ӫ��
        /// </summary>
        public int? cs_operation
        {
            set { _cs_operation = value; }
            get { return _cs_operation; }
        }
        /// <summary>
        /// �Ƿ񹫿�
        /// </summary>
        public bool? cs_ispub
        {
            set { _cs_ispub = value; }
            get { return _cs_ispub; }
        }
        /// <summary>
        /// �Ƿ���ˣ�0��1�ǣ�Ĭ��1��
        /// </summary>
        public bool? cs_examine
        {
            set { _cs_examine = value; }
            get { return _cs_examine; }
        }
        /// <summary>
        /// ���ʱ��
        /// </summary>
        public DateTime? cs_addtime
        {
            set { _cs_addtime = value; }
            get { return _cs_addtime; }
        }

        /// <summary>
        /// ���׮����
        /// </summary>
        public int? cp_number
        {
            set { _cp_number = value; }
            get { return _cp_number; }
        }
        /// <summary>
        /// �Ƿ�ȫ���˺ţ�0��1�ǣ�Ĭ��0��
        /// </summary>
        public bool? cs_isglobal
        {
            set { _cs_isglobal = value; }
            get { return _cs_isglobal; }
        }
        #endregion Model

    }
}

