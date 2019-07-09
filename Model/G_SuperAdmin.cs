using System;
namespace Model
{
	/// <summary>
	/// 实体类G_SuperAdmin 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class G_SuperAdmin
	{
		public G_SuperAdmin()
		{}
		#region Model
		private int? _sa_id;
		private string _sa_uname;
		private string _sa_pwd;
		private string _sa_tname;
		private string _a_phone;
		private int? _p_id;
		private int? _c_id;
		private int? _d_id;
		private int? _s_id;
		private int? _cm_id;
		private string _pcdscm_address;
		private DateTime? _a_addtime;
		/// <summary>
		/// 编号
		/// </summary>
		public int? sa_id
		{
			set{ _sa_id=value;}
			get{return _sa_id;}
		}
		/// <summary>
		/// 用户名
		/// </summary>
		public string sa_uname
		{
			set{ _sa_uname=value;}
			get{return _sa_uname;}
		}
		/// <summary>
		/// 密码
		/// </summary>
		public string sa_pwd
		{
			set{ _sa_pwd=value;}
			get{return _sa_pwd;}
		}
		/// <summary>
		/// 姓名
		/// </summary>
		public string sa_tname
		{
			set{ _sa_tname=value;}
			get{return _sa_tname;}
		}
		/// <summary>
		/// 电话
		/// </summary>
		public string a_phone
		{
			set{ _a_phone=value;}
			get{return _a_phone;}
		}
		/// <summary>
		/// 地址-省
		/// </summary>
		public int? p_id
		{
			set{ _p_id=value;}
			get{return _p_id;}
		}
		/// <summary>
		/// 地址-市
		/// </summary>
		public int? c_id
		{
			set{ _c_id=value;}
			get{return _c_id;}
		}
		/// <summary>
		/// 地址-区
		/// </summary>
		public int? d_id
		{
			set{ _d_id=value;}
			get{return _d_id;}
		}
		/// <summary>
		/// 地址-街道
		/// </summary>
		public int? s_id
		{
			set{ _s_id=value;}
			get{return _s_id;}
		}
		/// <summary>
		/// 地址-社区
		/// </summary>
		public int? cm_id
		{
			set{ _cm_id=value;}
			get{return _cm_id;}
		}
		/// <summary>
		/// 地址-详细地址
		/// </summary>
		public string pcdscm_address
		{
			set{ _pcdscm_address=value;}
			get{return _pcdscm_address;}
		}
		/// <summary>
		/// 添加时间
		/// </summary>
		public DateTime? a_addtime
		{
			set{ _a_addtime=value;}
			get{return _a_addtime;}
		}
		#endregion Model

	}
}

