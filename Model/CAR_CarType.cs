using System;
namespace Model
{
    /// <summary>
    /// 实体类CAR_CarType 。(属性说明自动提取数据库字段的描述信息)
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
        /// 编号
        /// </summary>
        public int? car_ct_id
        {
            set { _car_ct_id = value; }
            get { return _car_ct_id; }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string car_ct_name
        {
            set { _car_ct_name = value; }
            get { return _car_ct_name; }
        }
        /// <summary>
        /// 所属品牌（对应G_CarBrand中的编号）
        /// </summary>
        public int? car_cb_id
        {
            set { _car_cb_id = value; }
            get { return _car_cb_id; }
        }
        /// <summary>
        /// 类型（1纯电，2混动）
        /// </summary>
        public int? car_ct_type
        {
            set { _car_ct_type = value; }
            get { return _car_ct_type; }
        }
        /// <summary>
        /// 是否审核（0否1是，默认0）
        /// </summary>
        public bool? car_ct_examine
        {
            set { _car_ct_examine = value; }
            get { return _car_ct_examine; }
        }
        #endregion Model

    }
}

