using System;
namespace Model
{
	/// <summary>
	/// 实体类G_District 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class G_District
	{
		public G_District()
		{}
		#region Model
		private int? _d_id;
		private string _d_name;
		private int? _c_id;
		private string _d_phone;
		private bool? _d_examine;
		/// <summary>
		/// 编号（国标）
		/// </summary>
		public int? d_id
		{
			set{ _d_id=value;}
			get{return _d_id;}
		}
		/// <summary>
		/// 名称
		/// </summary>
		public string d_name
		{
			set{ _d_name=value;}
			get{return _d_name;}
		}
		/// <summary>
		/// 所属市（对应G_City中的编号）
		/// </summary>
		public int? c_id
		{
			set{ _c_id=value;}
			get{return _c_id;}
		}
		/// <summary>
		/// 电话
		/// </summary>
		public string d_phone
		{
			set{ _d_phone=value;}
			get{return _d_phone;}
		}
		/// <summary>
		/// 是否审核（0否1是，默认0）
		/// </summary>
		public bool? d_examine
		{
			set{ _d_examine=value;}
			get{return _d_examine;}
		}
		#endregion Model

	}
}

