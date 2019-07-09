using System;
namespace Model
{
	/// <summary>
	/// ʵ����AM_UpLecture ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// ���
		/// </summary>
		public long? am_ul_id
		{
			set{ _am_ul_id=value;}
			get{return _am_ul_id;}
		}
		/// <summary>
		/// �������վ����ӦG_ChargeStation�еı��,Ĭ��0��
		/// </summary>
		public long? cs_id
		{
			set{ _cs_id=value;}
			get{return _cs_id;}
		}
		/// <summary>
		/// �豸���ͣ���ӦG_Type�еı�ţ�
		/// </summary>
		public int? t_id
		{
			set{ _t_id=value;}
			get{return _t_id;}
		}
		/// <summary>
		/// Э�飨��ӦG_Version�еı�ţ�
		/// </summary>
		public int? v_id
		{
			set{ _v_id=value;}
			get{return _v_id;}
		}
		/// <summary>
		/// �����豸����ӦG_Equipment�еı�ţ�
		/// </summary>
		public long? cp_id
		{
			set{ _cp_id=value;}
			get{return _cp_id;}
		}
		/// <summary>
		/// �豸���к�
		/// </summary>
		public string cp_code
		{
			set{ _cp_code=value;}
			get{return _cp_code;}
		}
		/// <summary>
		/// ������أ���ӦG_Battery�еı�ţ�
		/// </summary>
		public long? cb_id
		{
			set{ _cb_id=value;}
			get{return _cb_id;}
		}
		/// <summary>
		/// ������к�
		/// </summary>
		public string cb_code
		{
			set{ _cb_code=value;}
			get{return _cb_code;}
		}
		/// <summary>
		/// ԭʼ��������
		/// </summary>
		public string am_ul_content
		{
			set{ _am_ul_content=value;}
			get{return _am_ul_content;}
		}
		/// <summary>
		/// ָ����
		/// </summary>
		public string am_ul_number
		{
			set{ _am_ul_number=value;}
			get{return _am_ul_number;}
		}
		/// <summary>
		/// ��Ϣ��
		/// </summary>
		public string am_ul_body
		{
			set{ _am_ul_body=value;}
			get{return _am_ul_body;}
		}
		/// <summary>
		/// ���ʱ��
		/// </summary>
		public DateTime? am_ul_addtime
		{
			set{ _am_ul_addtime=value;}
			get{return _am_ul_addtime;}
		}
		#endregion Model

	}
}

