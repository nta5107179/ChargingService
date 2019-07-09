using System;
namespace Model
{
    /// <summary>
    /// 实体类G_SystemMessageType 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class G_SystemMessageType
    {
        public G_SystemMessageType()
        { }
        #region Model
        private int? _smt_id;
        private string _smt_name;
        /// <summary>
        /// 编号
        /// </summary>
        public int? smt_id
        {
            set { _smt_id = value; }
            get { return _smt_id; }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string smt_name
        {
            set { _smt_name = value; }
            get { return _smt_name; }
        }
        #endregion Model

    }
}

