using System;
namespace Model
{
    /// <summary>
    /// 实体类User_SystemMessage 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class User_SystemMessage
    {
        public User_SystemMessage()
        { }
        #region Model
        private long? _user_sm_id;
        private int? _sm_id;
        private long? _u_id;
        private bool? _user_sm_isred;
        private bool? _user_sm_isdel;
        private DateTime? _user_sm_addtime;
        /// <summary>
        /// 编号
        /// </summary>
        public long? user_sm_id
        {
            set { _user_sm_id = value; }
            get { return _user_sm_id; }
        }
        /// <summary>
        /// 所属消息（对应G_Message中的编号）
        /// </summary>
        public int? sm_id
        {
            set { _sm_id = value; }
            get { return _sm_id; }
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
        /// 是否已读（0否1是，默认1）
        /// </summary>
        public bool? user_sm_isred
        {
            set { _user_sm_isred = value; }
            get { return _user_sm_isred; }
        }
        /// <summary>
        /// 是否删除（0否1是，默认0）
        /// </summary>
        public bool? user_sm_isdel
        {
            set { _user_sm_isdel = value; }
            get { return _user_sm_isdel; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? user_sm_addtime
        {
            set { _user_sm_addtime = value; }
            get { return _user_sm_addtime; }
        }
        #endregion Model

    }
}

