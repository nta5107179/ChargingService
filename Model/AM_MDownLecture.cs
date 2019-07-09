using System;
namespace Model
{
	/// <summary>
	/// 实体类AM_MDownLecture 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class AM_MDownLecture
	{
		public AM_MDownLecture()
		{}
		#region Model
		private long? _am_mdl_id;
		private long? _cs_id;
		private int? _v2_id;
		private string _am_mdl_content;
		private string _am_mdl_number;
		private string _am_mdl_body;
		private DateTime? _am_mdl_addtime;
		/// <summary>
		/// 编号
		/// </summary>
		public long? am_mdl_id
		{
			set{ _am_mdl_id=value;}
			get{return _am_mdl_id;}
		}
		/// <summary>
		/// 所属充电站（对应G_ChargeStation中的编号,默认0）
		/// </summary>
		public long? cs_id
		{
			set{ _cs_id=value;}
			get{return _cs_id;}
		}
		/// <summary>
		/// 协议（对应G_Version2中的编号）
		/// </summary>
		public int? v2_id
		{
			set{ _v2_id=value;}
			get{return _v2_id;}
		}
		/// <summary>
		/// 原始报文内容
		/// </summary>
		public string am_mdl_content
		{
			set{ _am_mdl_content=value;}
			get{return _am_mdl_content;}
		}
		/// <summary>
		/// 指令编号
		/// </summary>
		public string am_mdl_number
		{
			set{ _am_mdl_number=value;}
			get{return _am_mdl_number;}
		}
		/// <summary>
		/// 消息体
		/// </summary>
		public string am_mdl_body
		{
			set{ _am_mdl_body=value;}
			get{return _am_mdl_body;}
		}
		/// <summary>
		/// 添加时间
		/// </summary>
		public DateTime? am_mdl_addtime
		{
			set{ _am_mdl_addtime=value;}
			get{return _am_mdl_addtime;}
		}
		#endregion Model

	}
}

