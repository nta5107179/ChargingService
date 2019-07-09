using System;
namespace Model
{
	/// <summary>
	/// 实体类G_Version 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class G_Version
	{
		public G_Version()
		{}
		#region Model
		private int? _v_id;
		private string _v_name;
		/// <summary>
		/// 编号
		/// </summary>
		public int? v_id
		{
			set{ _v_id=value;}
			get{return _v_id;}
		}
		/// <summary>
		/// 名称
		/// </summary>
		public string v_name
		{
			set{ _v_name=value;}
			get{return _v_name;}
		}
		#endregion Model

	}
}

