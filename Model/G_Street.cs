using System;
namespace Model
{
	/// <summary>
	/// 实体类G_Street 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class G_Street
	{
		public G_Street()
		{}
		#region Model
		private int? _s_id;
		private string _s_name;
		private int? _d_id;
		private string _s_phone;
		private bool? _s_examine;
		/// <summary>
		/// 编号
		/// </summary>
		public int? s_id
		{
			set{ _s_id=value;}
			get{return _s_id;}
		}
		/// <summary>
		/// 名称
		/// </summary>
		public string s_name
		{
			set{ _s_name=value;}
			get{return _s_name;}
		}
		/// <summary>
		/// 所属区（对应G_District中的编号）
		/// </summary>
		public int? d_id
		{
			set{ _d_id=value;}
			get{return _d_id;}
		}
		/// <summary>
		/// 电话
		/// </summary>
		public string s_phone
		{
			set{ _s_phone=value;}
			get{return _s_phone;}
		}
		/// <summary>
		/// 是否审核（0否1是，默认0）
		/// </summary>
		public bool? s_examine
		{
			set{ _s_examine=value;}
			get{return _s_examine;}
		}
		#endregion Model

	}
}

