using System;
namespace Model
{
    /// <summary>
    /// 实体类CAR_BelongsTo 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class CAR_BelongsTo
    {
        public CAR_BelongsTo()
        { }
        #region Model
        private int? _car_bt_id;
        private string _car_bt_name;
        private string _car_bt_allname;
        /// <summary>
        /// 编号
        /// </summary>
        public int? car_bt_id
        {
            set { _car_bt_id = value; }
            get { return _car_bt_id; }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string car_bt_name
        {
            set { _car_bt_name = value; }
            get { return _car_bt_name; }
        }
        /// <summary>
        /// 全称
        /// </summary>
        public string car_bt_allname
        {
            set { _car_bt_allname = value; }
            get { return _car_bt_allname; }
        }
        #endregion Model

    }
}

