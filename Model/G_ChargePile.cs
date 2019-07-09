using System;
namespace Model
{
    /// <summary>
    /// ʵ����G_ChargePile ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
        /// ��ţ��Զ���
        /// </summary>
        public long? cp_id
        {
            set { _cp_id = value; }
            get { return _cp_id; }
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
        /// ���ģʽ��1������2ֱ����3��ֱ����
        /// </summary>
        public int? cp_chargemod
        {
            set { _cp_chargemod = value; }
            get { return _cp_chargemod; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string cp_name
        {
            set { _cp_name = value; }
            get { return _cp_name; }
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
        /// ���ȣ�ԭʼ��
        /// </summary>
        public double? cp_lng
        {
            set { _cp_lng = value; }
            get { return _cp_lng; }
        }
        /// <summary>
        /// ���ȱ�־��E������W������
        /// </summary>
        public string cp_lng_mark
        {
            set { _cp_lng_mark = value; }
            get { return _cp_lng_mark; }
        }
        /// <summary>
        /// γ�ȣ�ԭʼ��
        /// </summary>
        public double? cp_lat
        {
            set { _cp_lat = value; }
            get { return _cp_lat; }
        }
        /// <summary>
        /// γ�ȱ�־��N��γ��S��γ��
        /// </summary>
        public string cp_lat_mark
        {
            set { _cp_lat_mark = value; }
            get { return _cp_lat_mark; }
        }
        /// <summary>
        /// ���ȣ��ȸ裩
        /// </summary>
        public double? cp_gglng
        {
            set { _cp_gglng = value; }
            get { return _cp_gglng; }
        }
        /// <summary>
        /// γ�ȣ��ȸ裩
        /// </summary>
        public double? cp_gglat
        {
            set { _cp_gglat = value; }
            get { return _cp_gglat; }
        }
        /// <summary>
        /// ���ȣ��ٶȣ�
        /// </summary>
        public double? cp_bdlng
        {
            set { _cp_bdlng = value; }
            get { return _cp_bdlng; }
        }
        /// <summary>
        /// γ�ȣ��ٶȣ�
        /// </summary>
        public double? cp_bdlat
        {
            set { _cp_bdlat = value; }
            get { return _cp_bdlat; }
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
        /// ����
        /// </summary>
        public decimal? cp_money
        {
            set { _cp_money = value; }
            get { return _cp_money; }
        }
        /// <summary>
        /// ��Ӫģʽ��0��Ӫ��1����Ӫ��
        /// </summary>
        public int? cp_operation
        {
            set { _cp_operation = value; }
            get { return _cp_operation; }
        }
        /// <summary>
        /// ǹ����
        /// </summary>
        public int? cp_gunnum
        {
            set { _cp_gunnum = value; }
            get { return _cp_gunnum; }
        }
        /// <summary>
        /// �Ƿ���ˣ�0��1�ǣ�Ĭ��1��
        /// </summary>
        public bool? cp_examine
        {
            set { _cp_examine = value; }
            get { return _cp_examine; }
        }
        /// <summary>
        /// ���ʱ��
        /// </summary>
        public DateTime? cp_addtime
        {
            set { _cp_addtime = value; }
            get { return _cp_addtime; }
        }
        /// <summary>
        /// �豸����
        /// </summary>
        public string cp_type
        {
            set { _cp_type = value; }
            get { return _cp_type; }
        }
        /// <summary>
        /// �豸�ͺ�
        /// </summary>
        public string cp_model
        {
            set { _cp_model = value; }
            get { return _cp_model; }
        }
        /// <summary>
        /// ������ҵ
        /// </summary>
        public string cp_company
        {
            set { _cp_company = value; }
            get { return _cp_company; }
        }
        /// <summary>
        /// �������ģʽ
        /// </summary>
        public string cp_amod
        {
            set { _cp_amod = value; }
            get { return _cp_amod; }
        }
        /// <summary>
        /// �����ѹ
        /// </summary>
        public string cp_v
        {
            set { _cp_v = value; }
            get { return _cp_v; }
        }
        /// <summary>
        /// �������
        /// </summary>
        public string cp_a
        {
            set { _cp_a = value; }
            get { return _cp_a; }
        }
        /// <summary>
        /// ��ˮ��
        /// </summary>
        public int? cp_wid
        {
            set { _cp_wid = value; }
            get { return _cp_wid; }
        }
        #endregion Model

    }
}

