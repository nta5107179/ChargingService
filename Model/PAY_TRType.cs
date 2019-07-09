using System;
namespace Model
{
    /// <summary>
    /// 实体类PAY_TRType 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class PAY_TRType
    {
        public PAY_TRType()
        { }
        #region Model
        private int? _pay_trt_id;
        private string _pay_trt_name;
        /// <summary>
        /// 编号
        /// </summary>
        public int? pay_trt_id
        {
            set { _pay_trt_id = value; }
            get { return _pay_trt_id; }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string pay_trt_name
        {
            set { _pay_trt_name = value; }
            get { return _pay_trt_name; }
        }
        #endregion Model

    }
}

