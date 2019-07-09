using System;
namespace Model
{
    /// <summary>
    /// 实体类CS_SystemMessage 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class CS_SystemMessage
    {
        public CS_SystemMessage()
        { }
        #region Model
        private long? _cs_sm_id;
        private int? _sm_id;
        private long? _cs_id;
        private bool? _cs_sm_isred;
        private DateTime? _cs_sm_addtime;
        /// <summary>
        /// 编号
        /// </summary>
        public long? cs_sm_id
        {
            set { _cs_sm_id = value; }
            get { return _cs_sm_id; }
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
        /// 所属充电站（对应G_User中的编号）
        /// </summary>
        public long? cs_id
        {
            set { _cs_id = value; }
            get { return _cs_id; }
        }
        /// <summary>
        /// 是否已读（0否1是，默认1）
        /// </summary>
        public bool? cs_sm_isred
        {
            set { _cs_sm_isred = value; }
            get { return _cs_sm_isred; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? cs_sm_addtime
        {
            set { _cs_sm_addtime = value; }
            get { return _cs_sm_addtime; }
        }
        #endregion Model

    }
}

