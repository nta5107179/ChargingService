using System;
namespace Model
{
	/// <summary>
	/// GPS数据
	/// </summary>
	[Serializable]
	public partial class GPS
	{
		public GPS()
		{ }
		#region Model

		private string _gglat;
		private string _gglng;
		private string _bdlat;
        private string _bdlng;
        private string _lat;
        private string _lat_mark;
        private string _lng;
        private string _lng_mark;
        private int? _p_id;
        private string _p_name;
        private int? _c_id;
        private string _c_name;
        private int? _d_id;
        private string _d_name;
        private int? _s_id;
        private string _s_name;
        private int? _cm_id;
        private string _cm_name;
        private string _pcdscm_address;
		
		/// <summary>
		/// 纬度
		/// </summary>
		public string lat
		{
			set { _lat = value; }
			get { return _lat; }
		}
		/// <summary>
		/// 纬度标志
		/// </summary>
		public string lat_mark
		{
			set { _lat_mark = value; }
			get { return _lat_mark; }
		}
		/// <summary>
		/// 经度
		/// </summary>
		public string lng
		{
			set { _lng = value; }
			get { return _lng; }
		}
		/// <summary>
		/// 经度标志
		/// </summary>
		public string lng_mark
		{
			set { _lng_mark = value; }
			get { return _lng_mark; }
		}
		/// <summary>
		/// 谷歌纬度
		/// </summary>
		public string gglat
		{
			set { _gglat = value; }
			get { return _gglat; }
		}
		/// <summary>
		/// 谷歌经度
		/// </summary>
		public string gglng
		{
			set { _gglng = value; }
			get { return _gglng; }
		}
		/// <summary>
		/// 百度纬度
		/// </summary>
		public string bdlat
		{
			set { _bdlat = value; }
			get { return _bdlat; }
		}
		/// <summary>
		/// 百度经度
		/// </summary>
		public string bdlng
		{
			set { _bdlng = value; }
			get { return _bdlng; }
		}
        /// <summary>
        /// 地址-省
        /// </summary>
        public int? p_id
        {
            set { _p_id = value; }
            get { return _p_id; }
        }
        /// <summary>
        /// 地址-省
        /// </summary>
        public string p_name
        {
            set { _p_name = value; }
            get { return _p_name; }
        }
        /// <summary>
        /// 地址-市
        /// </summary>
        public int? c_id
        {
            set { _c_id = value; }
            get { return _c_id; }
        }
        /// <summary>
        /// 地址-市
        /// </summary>
        public string c_name
        {
            set { _c_name = value; }
            get { return _c_name; }
        }
        /// <summary>
        /// 地址-区
        /// </summary>
        public int? d_id
        {
            set { _d_id = value; }
            get { return _d_id; }
        }
        /// <summary>
        /// 地址-区
        /// </summary>
        public string d_name
        {
            set { _d_name = value; }
            get { return _d_name; }
        }
        /// <summary>
        /// 地址-街道
        /// </summary>
        public int? s_id
        {
            set { _s_id = value; }
            get { return _s_id; }
        }
        /// <summary>
        /// 地址-街道
        /// </summary>
        public string s_name
        {
            set { _s_name = value; }
            get { return _s_name; }
        }
        /// <summary>
        /// 地址-社区
        /// </summary>
        public int? cm_id
        {
            set { _cm_id = value; }
            get { return _cm_id; }
        }
        /// <summary>
        /// 地址-社区
        /// </summary>
        public string cm_name
        {
            set { _cm_name = value; }
            get { return _cm_name; }
        }
        /// <summary>
        /// 地址-详细地址
        /// </summary>
        public string pcdscm_address
        {
            set { _pcdscm_address = value; }
            get { return _pcdscm_address; }
        }

		#endregion Model

	}
}

