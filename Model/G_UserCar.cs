using System;
namespace Model
{
    /// <summary>
    /// ʵ����G_UserCar ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public class G_UserCar
    {
        public G_UserCar()
        { }
        #region Model
        private long? _uc_id;
        private long? _u_id;
        private long? _cb_id;
        private string _cb_code;
        private int? _car_bt_id;
        private string _uc_bt;
        private string _uc_name;
        private int? _car_cb_id;
        private int? _car_ct_id;
        private string _uc_filename;
        private bool? _uc_examine;
        private DateTime? _uc_addtime;
        /// <summary>
        /// ���
        /// </summary>
        public long? uc_id
        {
            set { _uc_id = value; }
            get { return _uc_id; }
        }
        /// <summary>
        /// �����û�����ӦG_User�еı�ţ�
        /// </summary>
        public long? u_id
        {
            set { _u_id = value; }
            get { return _u_id; }
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
        /// ��������ʡ����ӦCAR_BelongsTo�еı�ţ�
        /// </summary>
        public int? car_bt_id
        {
            set { _car_bt_id = value; }
            get { return _car_bt_id; }
        }
        /// <summary>
        /// ���������У�A-Z��
        /// </summary>
        public string uc_bt
        {
            set { _uc_bt = value; }
            get { return _uc_bt; }
        }
        /// <summary>
        /// ���ƺ�
        /// </summary>
        public string uc_name
        {
            set { _uc_name = value; }
            get { return _uc_name; }
        }
        /// <summary>
        /// Ʒ��
        /// </summary>
        public int? car_cb_id
        {
            set { _car_cb_id = value; }
            get { return _car_cb_id; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public int? car_ct_id
        {
            set { _car_ct_id = value; }
            get { return _car_ct_id; }
        }
        /// <summary>
        /// �ļ���
        /// </summary>
        public string uc_filename
        {
            set { _uc_filename = value; }
            get { return _uc_filename; }
        }
        /// <summary>
        /// �Ƿ���ˣ�0��1�ǣ�Ĭ��1��
        /// </summary>
        public bool? uc_examine
        {
            set { _uc_examine = value; }
            get { return _uc_examine; }
        }
        /// <summary>
        /// ���ʱ��
        /// </summary>
        public DateTime? uc_addtime
        {
            set { _uc_addtime = value; }
            get { return _uc_addtime; }
        }
        #endregion Model

    }
}

