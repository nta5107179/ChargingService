using System;
namespace Model
{
	/// <summary>
	/// ʵ����AM_MUpLecture ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// ���
		/// </summary>
		public long? am_mul_id
		{
			set{ _am_mul_id=value;}
			get{return _am_mul_id;}
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
		public string am_mul_content
		{
			set{ _am_mul_content=value;}
			get{return _am_mul_content;}
		}
		/// <summary>
		/// ָ����
		/// </summary>
		public string am_mul_number
		{
			set{ _am_mul_number=value;}
			get{return _am_mul_number;}
		}
		/// <summary>
		/// ��Ϣ��
		/// </summary>
		public string am_mul_body
		{
			set{ _am_mul_body=value;}
			get{return _am_mul_body;}
		}
		/// <summary>
		/// ���ʱ��
		/// </summary>
		public DateTime? am_mul_addtime
		{
			set{ _am_mul_addtime=value;}
			get{return _am_mul_addtime;}
		}
		#endregion Model

	}
}

