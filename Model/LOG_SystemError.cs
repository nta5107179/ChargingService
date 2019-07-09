using System;
namespace Model
{
	/// <summary>
	/// 实体类LOG_SystemError 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class LOG_SystemError
	{
		public LOG_SystemError()
		{}
		#region Model
		private int? _log_se_id;
		private int? _t_id;
		private int? _v_id;
		private int? _log_se_stype;
		private string _log_se_content;
		private string _log_se_type;
		private string _log_se_information;
		private DateTime? _log_se_addtime;
		/// <summary>
		/// 编号
		/// </summary>
		public int? log_se_id
		{
			set{ _log_se_id=value;}
			get{return _log_se_id;}
		}
		/// <summary>
		/// 所属设备类型（对应G_Type中的编号）
		/// </summary>
		public int? t_id
		{
			set{ _t_id=value;}
			get{return _t_id;}
		}
		/// <summary>
		/// 所属设备协议（对应G_Version中的编号）
		/// </summary>
		public int? v_id
		{
			set{ _v_id=value;}
			get{return _v_id;}
		}
		/// <summary>
		/// 来自应用程序（1为web、2为win32）
		/// </summary>
		public int? log_se_stype
		{
			set{ _log_se_stype=value;}
			get{return _log_se_stype;}
		}
		/// <summary>
		/// 错误内容
		/// </summary>
		public string log_se_content
		{
			set{ _log_se_content=value;}
			get{return _log_se_content;}
		}
		/// <summary>
		/// 错误类型
		/// </summary>
		public string log_se_type
		{
			set{ _log_se_type=value;}
			get{return _log_se_type;}
		}
		/// <summary>
		/// 错误信息
		/// </summary>
		public string log_se_information
		{
			set{ _log_se_information=value;}
			get{return _log_se_information;}
		}
		/// <summary>
		/// 添加时间
		/// </summary>
		public DateTime? log_se_addtime
		{
			set{ _log_se_addtime=value;}
			get{return _log_se_addtime;}
		}
		#endregion Model

	}
}

