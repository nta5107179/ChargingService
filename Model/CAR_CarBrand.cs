using System;
namespace Model
{
    /// <summary>
    /// 实体类CAR_CarBrand 。(属性说明自动提取数据库字段的描述信息)
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
        /// 编号
        /// </summary>
        public int? car_cb_id
        {
            set { _car_cb_id = value; }
            get { return _car_cb_id; }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string car_cb_name
        {
            set { _car_cb_name = value; }
            get { return _car_cb_name; }
        }
        /// <summary>
        /// 是否审核（0否1是，默认0）
        /// </summary>
        public bool? car_cb_examine
        {
            set { _car_cb_examine = value; }
            get { return _car_cb_examine; }
        }
        #endregion Model

    }
}

