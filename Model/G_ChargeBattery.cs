using System;
namespace Model
{
	/// <summary>
	/// 实体类G_ChargeBattery 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class G_ChargeBattery
	{
		public G_ChargeBattery()
		{}
		#region Model
		private long? _cb_id;
		private string _cb_code;
		private bool? _cb_examine;
		private DateTime? _cb_addtime;
		/// <summary>
		/// 编号
		/// </summary>
		public long? cb_id
		{
			set{ _cb_id=value;}
			get{return _cb_id;}
		}
		/// <summary>
		/// 序列号
		/// </summary>
		public string cb_code
		{
			set{ _cb_code=value;}
			get{return _cb_code;}
		}
		/// <summary>
		/// 是否审核（0否1是，默认1）
		/// </summary>
		public bool? cb_examine
		{
			set{ _cb_examine=value;}
			get{return _cb_examine;}
		}
		/// <summary>
		/// 添加时间
		/// </summary>
		public DateTime? cb_addtime
		{
			set{ _cb_addtime=value;}
			get{return _cb_addtime;}
		}
		#endregion Model

	}
}

