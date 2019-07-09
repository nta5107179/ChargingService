using System;
namespace Model
{
	/// <summary>
	/// 实体类AM_UpLecture 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class AM_UpLecture
	{
		public AM_UpLecture()
		{}
		#region Model
		private long? _am_ul_id;
		private long? _cs_id;
		private int? _t_id;
		private int? _v_id;
		private long? _cp_id;
		private string _cp_code;
		private long? _cb_id;
		private string _cb_code;
		private string _am_ul_content;
		private string _am_ul_number;
		private string _am_ul_body;
		private DateTime? _am_ul_addtime;
		/// <summary>
		/// 编号
		/// </summary>
		public long? am_ul_id
		{
			set{ _am_ul_id=value;}
			get{return _am_ul_id;}
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
		/// 设备类型（对应G_Type中的编号）
		/// </summary>
		public int? t_id
		{
			set{ _t_id=value;}
			get{return _t_id;}
		}
		/// <summary>
		/// 协议（对应G_Version中的编号）
		/// </summary>
		public int? v_id
		{
			set{ _v_id=value;}
			get{return _v_id;}
		}
		/// <summary>
		/// 所属设备（对应G_Equipment中的编号）
		/// </summary>
		public long? cp_id
		{
			set{ _cp_id=value;}
			get{return _cp_id;}
		}
		/// <summary>
		/// 设备序列号
		/// </summary>
		public string cp_code
		{
			set{ _cp_code=value;}
			get{return _cp_code;}
		}
		/// <summary>
		/// 所属电池（对应G_Battery中的编号）
		/// </summary>
		public long? cb_id
		{
			set{ _cb_id=value;}
			get{return _cb_id;}
		}
		/// <summary>
		/// 电池序列号
		/// </summary>
		public string cb_code
		{
			set{ _cb_code=value;}
			get{return _cb_code;}
		}
		/// <summary>
		/// 原始报文内容
		/// </summary>
		public string am_ul_content
		{
			set{ _am_ul_content=value;}
			get{return _am_ul_content;}
		}
		/// <summary>
		/// 指令编号
		/// </summary>
		public string am_ul_number
		{
			set{ _am_ul_number=value;}
			get{return _am_ul_number;}
		}
		/// <summary>
		/// 消息体
		/// </summary>
		public string am_ul_body
		{
			set{ _am_ul_body=value;}
			get{return _am_ul_body;}
		}
		/// <summary>
		/// 添加时间
		/// </summary>
		public DateTime? am_ul_addtime
		{
			set{ _am_ul_addtime=value;}
			get{return _am_ul_addtime;}
		}
		#endregion Model

	}
}

