using System;
namespace Model
{
    /// <summary>
    /// 实体类G_SystemMessage 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class G_SystemMessage
    {
        public G_SystemMessage()
        { }
        #region Model
        private int? _sm_id;
        private int? _smt_id;
        private int? _sa_id;
        private string _sm_title;
        private string _sm_content;
        private string _sm_filename;
        private string _sm_url;
        private int? _sm_top;
        private bool? _sm_examine;
        private DateTime? _sm_addtime;
        /// <summary>
        /// 编号
        /// </summary>
        public int? sm_id
        {
            set { _sm_id = value; }
            get { return _sm_id; }
        }
        /// <summary>
        /// 所属类型（对应G_SystemMessageType中的编号）
        /// </summary>
        public int? smt_id
        {
            set { _smt_id = value; }
            get { return _smt_id; }
        }
        /// <summary>
        /// 发布人（对应G_Admin中的编号）
        /// </summary>
        public int? sa_id
        {
            set { _sa_id = value; }
            get { return _sa_id; }
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string sm_title
        {
            set { _sm_title = value; }
            get { return _sm_title; }
        }
        /// <summary>
        /// 内容
        /// </summary>
        public string sm_content
        {
            set { _sm_content = value; }
            get { return _sm_content; }
        }
        /// <summary>
        /// 文件名
        /// </summary>
        public string sm_filename
        {
            set { _sm_filename = value; }
            get { return _sm_filename; }
        }
        /// <summary>
        /// 连接地址
        /// </summary>
        public string sm_url
        {
            set { _sm_url = value; }
            get { return _sm_url; }
        }
        /// <summary>
        /// 排序（越大越靠上，默认0）
        /// </summary>
        public int? sm_top
        {
            set { _sm_top = value; }
            get { return _sm_top; }
        }
        /// <summary>
        /// 是否审核（0否1是，默认0）
        /// </summary>
        public bool? sm_examine
        {
            set { _sm_examine = value; }
            get { return _sm_examine; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? sm_addtime
        {
            set { _sm_addtime = value; }
            get { return _sm_addtime; }
        }
        #endregion Model

    }
}

