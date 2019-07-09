using System;
namespace Model
{
	/// <summary>
	/// 实体类G_Community 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class G_Community
	{
		public G_Community()
		{}
		#region Model
		private int? _cm_id;
		private string _cm_name;
		private int? _s_id;
		private string _cm_phone;
		private bool? _cm_examine;
		/// <summary>
		/// 编号
		/// </summary>
		public int? cm_id
		{
			set{ _cm_id=value;}
			get{return _cm_id;}
		}
		/// <summary>
		/// 名称
		/// </summary>
		public string cm_name
		{
			set{ _cm_name=value;}
			get{return _cm_name;}
		}
		/// <summary>
		/// 所属街道（对应G_Street中的编号）
		/// </summary>
		public int? s_id
		{
			set{ _s_id=value;}
			get{return _s_id;}
		}
		/// <summary>
		/// 电话
		/// </summary>
		public string cm_phone
		{
			set{ _cm_phone=value;}
			get{return _cm_phone;}
		}
		/// <summary>
		/// 是否审核（0否1是，默认0）
		/// </summary>
		public bool? cm_examine
		{
			set{ _cm_examine=value;}
			get{return _cm_examine;}
		}
		#endregion Model

	}
}

