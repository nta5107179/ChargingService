using System;
namespace Model
{
    /// <summary>
    /// ʵ����CAR_CarBrand ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public class CAR_CarBrand
    {
        public CAR_CarBrand()
        { }
        #region Model
        private int? _car_cb_id;
        private string _car_cb_name;
        private bool? _car_cb_examine;
        /// <summary>
        /// ���
        /// </summary>
        public int? car_cb_id
        {
            set { _car_cb_id = value; }
            get { return _car_cb_id; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string car_cb_name
        {
            set { _car_cb_name = value; }
            get { return _car_cb_name; }
        }
        /// <summary>
        /// �Ƿ���ˣ�0��1�ǣ�Ĭ��0��
        /// </summary>
        public bool? car_cb_examine
        {
            set { _car_cb_examine = value; }
            get { return _car_cb_examine; }
        }
        #endregion Model

    }
}

