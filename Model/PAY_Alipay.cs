using System;
namespace Model
{
    /// <summary>
    /// 实体类PAY_Alipay 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class PAY_Alipay
    {
        public PAY_Alipay()
        { }
        #region Model
        private long? _pay_a_id;
        private long? _u_id;
        private long? _u_uname;
        private DateTime? _notify_time;
        private string _notify_type;
        private string _notify_id;
        private string _sign_type;
        private string _sign;
        private long? _out_trade_no;
        private string _subject;
        private string _payment_type;
        private string _trade_no;
        private string _trade_status;
        private string _seller_id;
        private string _seller_email;
        private string _buyer_id;
        private string _buyer_email;
        private decimal? _total_fee;
        private DateTime? _gmt_create;
        private DateTime? _gmt_payment;
        private string _is_total_fee_adjust;
        private string _use_coupon;
        private decimal? _discount;
        private string _refund_status;
        private DateTime? _gmt_refund;
        private int? _quantity;
        private decimal? _price;
        private string _body;
        private DateTime? _pay_a_addtime;
        private string _notify_url;
        /// <summary>
        /// 编号
        /// </summary>
        public long? pay_a_id
        {
            set { _pay_a_id = value; }
            get { return _pay_a_id; }
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
        /// 用户名
        /// </summary>
        public long? u_uname
        {
            set { _u_uname = value; }
            get { return _u_uname; }
        }
        /// <summary>
        /// 通知时间
        /// </summary>
        public DateTime? notify_time
        {
            set { _notify_time = value; }
            get { return _notify_time; }
        }
        /// <summary>
        /// 通知类型
        /// </summary>
        public string notify_type
        {
            set { _notify_type = value; }
            get { return _notify_type; }
        }
        /// <summary>
        /// 通知校验ID
        /// </summary>
        public string notify_id
        {
            set { _notify_id = value; }
            get { return _notify_id; }
        }
        /// <summary>
        /// 签名方式
        /// </summary>
        public string sign_type
        {
            set { _sign_type = value; }
            get { return _sign_type; }
        }
        /// <summary>
        /// 签名
        /// </summary>
        public string sign
        {
            set { _sign = value; }
            get { return _sign; }
        }
        /// <summary>
        /// 商户网站唯一订单号
        /// </summary>
        public long? out_trade_no
        {
            set { _out_trade_no = value; }
            get { return _out_trade_no; }
        }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string subject
        {
            set { _subject = value; }
            get { return _subject; }
        }
        /// <summary>
        /// 支付类型
        /// </summary>
        public string payment_type
        {
            set { _payment_type = value; }
            get { return _payment_type; }
        }
        /// <summary>
        /// 支付宝交易号
        /// </summary>
        public string trade_no
        {
            set { _trade_no = value; }
            get { return _trade_no; }
        }
        /// <summary>
        /// 交易状态
        /// </summary>
        public string trade_status
        {
            set { _trade_status = value; }
            get { return _trade_status; }
        }
        /// <summary>
        /// 卖家支付宝用户号
        /// </summary>
        public string seller_id
        {
            set { _seller_id = value; }
            get { return _seller_id; }
        }
        /// <summary>
        /// 卖家支付宝账号
        /// </summary>
        public string seller_email
        {
            set { _seller_email = value; }
            get { return _seller_email; }
        }
        /// <summary>
        /// 买家支付宝用户号
        /// </summary>
        public string buyer_id
        {
            set { _buyer_id = value; }
            get { return _buyer_id; }
        }
        /// <summary>
        /// 买家支付宝账号
        /// </summary>
        public string buyer_email
        {
            set { _buyer_email = value; }
            get { return _buyer_email; }
        }
        /// <summary>
        /// 交易金额
        /// </summary>
        public decimal? total_fee
        {
            set { _total_fee = value; }
            get { return _total_fee; }
        }
        /// <summary>
        /// 交易创建时间
        /// </summary>
        public DateTime? gmt_create
        {
            set { _gmt_create = value; }
            get { return _gmt_create; }
        }
        /// <summary>
        /// 交易付款时间
        /// </summary>
        public DateTime? gmt_payment
        {
            set { _gmt_payment = value; }
            get { return _gmt_payment; }
        }
        /// <summary>
        /// 是否调整总价
        /// </summary>
        public string is_total_fee_adjust
        {
            set { _is_total_fee_adjust = value; }
            get { return _is_total_fee_adjust; }
        }
        /// <summary>
        /// 是否使用红包买家
        /// </summary>
        public string use_coupon
        {
            set { _use_coupon = value; }
            get { return _use_coupon; }
        }
        /// <summary>
        /// 折扣
        /// </summary>
        public decimal? discount
        {
            set { _discount = value; }
            get { return _discount; }
        }
        /// <summary>
        /// 退款状态
        /// </summary>
        public string refund_status
        {
            set { _refund_status = value; }
            get { return _refund_status; }
        }
        /// <summary>
        /// 退款时间
        /// </summary>
        public DateTime? gmt_refund
        {
            set { _gmt_refund = value; }
            get { return _gmt_refund; }
        }
        /// <summary>
        /// 购买数量
        /// </summary>
        public int? quantity
        {
            set { _quantity = value; }
            get { return _quantity; }
        }
        /// <summary>
        /// 商品单价
        /// </summary>
        public decimal? price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 商品描述
        /// </summary>
        public string body
        {
            set { _body = value; }
            get { return _body; }
        }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime? pay_a_addtime
        {
            set { _pay_a_addtime = value; }
            get { return _pay_a_addtime; }
        }
        /// <summary>
        /// 异步回调地址
        /// </summary>
        public string notify_url
        {
            set { _notify_url = value; }
            get { return _notify_url; }
        }
        #endregion Model

    }
}

