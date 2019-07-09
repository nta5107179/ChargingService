using System;
namespace Model
{
    /// <summary>
    /// 实体类User_CollectClip 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class User_CollectClip
    {
        public User_CollectClip()
        { }
        #region Model
        private long? _user_cc_id;
        private long? _cs_id;
        private long? _u_id;
        private DateTime? _user_cc_addtime;
        /// <summary>
        /// 编号
        /// </summary>
        public long? user_cc_id
        {
            set { _user_cc_id = value; }
            get { return _user_cc_id; }
        }
        /// <summary>
        /// 所属充电站（对应G_ChargeStation中的编号）
        /// </summary>
        public long? cs_id
        {
            set { _cs_id = value; }
            get { return _cs_id; }
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
        /// 添加时间
        /// </summary>
        public DateTime? user_cc_addtime
        {
            set { _user_cc_addtime = value; }
            get { return _user_cc_addtime; }
        }
        #endregion Model

    }
}

