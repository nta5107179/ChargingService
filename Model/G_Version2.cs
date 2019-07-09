using System;
namespace Model
{
	/// <summary>
	/// 实体类G_Version2 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class G_Version2
	{
		public G_Version2()
		{}
		#region Model
		private int? _v2_id;
		private string _v2_name;
		/// <summary>
		/// 编号
		/// </summary>
		public int? v2_id
		{
			set{ _v2_id=value;}
			get{return _v2_id;}
		}
		/// <summary>
		/// 名称
		/// </summary>
		public string v2_name
		{
			set{ _v2_name=value;}
			get{return _v2_name;}
		}
		#endregion Model

	}
}

