using System;
namespace Model
{
    /// <summary>
    /// 实体类PAY_TRFrom 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class PAY_TRFrom
    {
        public PAY_TRFrom()
        { }
        #region Model
        private int? _pay_trf_id;
        private string _pay_trf_name;
        /// <summary>
        /// 编号
        /// </summary>
        public int? pay_trf_id
        {
            set { _pay_trf_id = value; }
            get { return _pay_trf_id; }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string pay_trf_name
        {
            set { _pay_trf_name = value; }
            get { return _pay_trf_name; }
        }
        #endregion Model

    }
}

