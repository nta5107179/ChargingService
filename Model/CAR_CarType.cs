using System;
namespace Model
{
    /// <summary>
    /// ʵ����CAR_CarType ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public class CAR_CarType
    {
        public CAR_CarType()
        { }
        #region Model
        private int? _car_ct_id;
        private string _car_ct_name;
        private int? _car_cb_id;
        private int? _car_ct_type;
        private bool? _car_ct_examine;
        /// <summary>
        /// ���
        /// </summary>
        public int? car_ct_id
        {
            set { _car_ct_id = value; }
            get { return _car_ct_id; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string car_ct_name
        {
            set { _car_ct_name = value; }
            get { return _car_ct_name; }
        }
        /// <summary>
        /// ����Ʒ�ƣ���ӦG_CarBrand�еı�ţ�
        /// </summary>
        public int? car_cb_id
        {
            set { _car_cb_id = value; }
            get { return _car_cb_id; }
        }
        /// <summary>
        /// ���ͣ�1���磬2�춯��
        /// </summary>
        public int? car_ct_type
        {
            set { _car_ct_type = value; }
            get { return _car_ct_type; }
        }
        /// <summary>
        /// �Ƿ���ˣ�0��1�ǣ�Ĭ��0��
        /// </summary>
        public bool? car_ct_examine
        {
            set { _car_ct_examine = value; }
            get { return _car_ct_examine; }
        }
        #endregion Model

    }
}

