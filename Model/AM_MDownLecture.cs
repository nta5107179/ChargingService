using System;
namespace Model
{
	/// <summary>
	/// ʵ����AM_MDownLecture ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// ���
		/// </summary>
		public long? am_mdl_id
		{
			set{ _am_mdl_id=value;}
			get{return _am_mdl_id;}
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
		/// Э�飨��ӦG_Version2�еı�ţ�
		/// </summary>
		public int? v2_id
		{
			set{ _v2_id=value;}
			get{return _v2_id;}
		}
		/// <summary>
		/// ԭʼ��������
		/// </summary>
		public string am_mdl_content
		{
			set{ _am_mdl_content=value;}
			get{return _am_mdl_content;}
		}
		/// <summary>
		/// ָ����
		/// </summary>
		public string am_mdl_number
		{
			set{ _am_mdl_number=value;}
			get{return _am_mdl_number;}
		}
		/// <summary>
		/// ��Ϣ��
		/// </summary>
		public string am_mdl_body
		{
			set{ _am_mdl_body=value;}
			get{return _am_mdl_body;}
		}
		/// <summary>
		/// ���ʱ��
		/// </summary>
		public DateTime? am_mdl_addtime
		{
			set{ _am_mdl_addtime=value;}
			get{return _am_mdl_addtime;}
		}
		#endregion Model

	}
}

