using System;
namespace Model
{
	/// <summary>
	/// 实体类AM_MUpLecture 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class AM_MUpLecture
	{
		public AM_MUpLecture()
		{}
		#region Model
		private long? _am_mul_id;
		private long? _cs_id;
		private int? _v2_id;
		private string _am_mul_content;
		private string _am_mul_number;
		private string _am_mul_body;
		private DateTime? _am_mul_addtime;
		/// <summary>
		/// 编号
		/// </summary>
		public long? am_mul_id
		{
			set{ _am_mul_id=value;}
			get{return _am_mul_id;}
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
		public string am_mul_content
		{
			set{ _am_mul_content=value;}
			get{return _am_mul_content;}
		}
		/// <summary>
		/// 指令编号
		/// </summary>
		public string am_mul_number
		{
			set{ _am_mul_number=value;}
			get{return _am_mul_number;}
		}
		/// <summary>
		/// 消息体
		/// </summary>
		public string am_mul_body
		{
			set{ _am_mul_body=value;}
			get{return _am_mul_body;}
		}
		/// <summary>
		/// 添加时间
		/// </summary>
		public DateTime? am_mul_addtime
		{
			set{ _am_mul_addtime=value;}
			get{return _am_mul_addtime;}
		}
		#endregion Model

	}
}

