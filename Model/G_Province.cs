using System;
namespace Model
{
	/// <summary>
	/// 实体类G_Province 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class G_Province
	{
		public G_Province()
		{}
		#region Model
		private int? _p_id;
		private string _p_name;
		private string _p_phone;
		private bool? _p_examine;
		/// <summary>
		/// 编号（国标）
		/// </summary>
		public int? p_id
		{
			set{ _p_id=value;}
			get{return _p_id;}
		}
		/// <summary>
		/// 名称
		/// </summary>
		public string p_name
		{
			set{ _p_name=value;}
			get{return _p_name;}
		}
		/// <summary>
		/// 电话
		/// </summary>
		public string p_phone
		{
			set{ _p_phone=value;}
			get{return _p_phone;}
		}
		/// <summary>
		/// 是否审核（0否1是，默认0）
		/// </summary>
		public bool? p_examine
		{
			set{ _p_examine=value;}
			get{return _p_examine;}
		}
		#endregion Model

	}
}

