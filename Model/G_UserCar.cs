using System;
namespace Model
{
    /// <summary>
    /// 实体类G_UserCar 。(属性说明自动提取数据库字段的描述信息)
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
        /// 编号
        /// </summary>
        public long? uc_id
        {
            set { _uc_id = value; }
            get { return _uc_id; }
        }
        /// <summary>
        /// 所属用户（对应G_User中的编号）
        /// </summary>
        public long? u_id
        {
            set { _u_id = value; }
            get { return _u_id; }
        }
        /// <summary>
        /// 所属电池（对应G_Battery中的编号）
        /// </summary>
        public long? cb_id
        {
            set { _cb_id = value; }
            get { return _cb_id; }
        }
        /// <summary>
        /// 电池序列号
        /// </summary>
        public string cb_code
        {
            set { _cb_code = value; }
            get { return _cb_code; }
        }
        /// <summary>
        /// 车牌所属省（对应CAR_BelongsTo中的编号）
        /// </summary>
        public int? car_bt_id
        {
            set { _car_bt_id = value; }
            get { return _car_bt_id; }
        }
        /// <summary>
        /// 车牌所属市（A-Z）
        /// </summary>
        public string uc_bt
        {
            set { _uc_bt = value; }
            get { return _uc_bt; }
        }
        /// <summary>
        /// 车牌号
        /// </summary>
        public string uc_name
        {
            set { _uc_name = value; }
            get { return _uc_name; }
        }
        /// <summary>
        /// 品牌
        /// </summary>
        public int? car_cb_id
        {
            set { _car_cb_id = value; }
            get { return _car_cb_id; }
        }
        /// <summary>
        /// 车型
        /// </summary>
        public int? car_ct_id
        {
            set { _car_ct_id = value; }
            get { return _car_ct_id; }
        }
        /// <summary>
        /// 文件名
        /// </summary>
        public string uc_filename
        {
            set { _uc_filename = value; }
            get { return _uc_filename; }
        }
        /// <summary>
        /// 是否审核（0否1是，默认1）
        /// </summary>
        public bool? uc_examine
        {
            set { _uc_examine = value; }
            get { return _uc_examine; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? uc_addtime
        {
            set { _uc_addtime = value; }
            get { return _uc_addtime; }
        }
        #endregion Model

    }
}

