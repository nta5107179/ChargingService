using System;
namespace Model
{
    /// <summary>
    /// 实体类PAY_TransactionRecord 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class PAY_TransactionRecord
    {
        public PAY_TransactionRecord()
        { }
        #region Model
        private long? _pay_tr_id;
        private long? _u_id;
        private int? _pay_trt_id;
        private int? _pay_trf_id;
        private decimal? _pay_tr_money;
        private DateTime? _pay_tr_addtime;
        /// <summary>
        /// 编号
        /// </summary>
        public long? pay_tr_id
        {
            set { _pay_tr_id = value; }
            get { return _pay_tr_id; }
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
        /// 交易类型
        /// </summary>
        public int? pay_trt_id
        {
            set { _pay_trt_id = value; }
            get { return _pay_trt_id; }
        }
        /// <summary>
        /// 充值来源
        /// </summary>
        public int? pay_trf_id
        {
            set { _pay_trf_id = value; }
            get { return _pay_trf_id; }
        }
        /// <summary>
        /// 交易金额
        /// </summary>
        public decimal? pay_tr_money
        {
            set { _pay_tr_money = value; }
            get { return _pay_tr_money; }
        }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime? pay_tr_addtime
        {
            set { _pay_tr_addtime = value; }
            get { return _pay_tr_addtime; }
        }
        #endregion Model

    }
}

