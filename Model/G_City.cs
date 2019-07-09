using System;
namespace Model
{
	/// <summary>
	/// 实体类G_City 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class G_City
	{
		public G_City()
		{}
		#region Model
		private int? _c_id;
		private string _c_name;
		private int? _p_id;
		private string _c_phone;
		private bool? _c_examine;
		/// <summary>
		/// 编号（国标）
		/// </summary>
		public int? c_id
		{
			set{ _c_id=value;}
			get{return _c_id;}
		}
		/// <summary>
		/// 名称
		/// </summary>
		public string c_name
		{
			set{ _c_name=value;}
			get{return _c_name;}
		}
		/// <summary>
		/// 所属省（对应G_Province中的编号）
		/// </summary>
		public int? p_id
		{
			set{ _p_id=value;}
			get{return _p_id;}
		}
		/// <summary>
		/// 电话
		/// </summary>
		public string c_phone
		{
			set{ _c_phone=value;}
			get{return _c_phone;}
		}
		/// <summary>
		/// 是否审核（0否1是，默认0）
		/// </summary>
		public bool? c_examine
		{
			set{ _c_examine=value;}
			get{return _c_examine;}
		}
		#endregion Model

	}
}

