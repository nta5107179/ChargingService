using System;
namespace Model
{
	/// <summary>
	/// 实体类G_Type 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class G_Type
	{
		public G_Type()
		{}
		#region Model
		private int? _t_id;
		private string _t_name;
		private string _t_path;
		/// <summary>
		/// 编号
		/// </summary>
		public int? t_id
		{
			set{ _t_id=value;}
			get{return _t_id;}
		}
		/// <summary>
		/// 名称
		/// </summary>
		public string t_name
		{
			set{ _t_name=value;}
			get{return _t_name;}
		}
		/// <summary>
		/// 路径（导航到不同的系统）
		/// </summary>
		public string t_path
		{
			set{ _t_path=value;}
			get{return _t_path;}
		}
		#endregion Model

	}
}

