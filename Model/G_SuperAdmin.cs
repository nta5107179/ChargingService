using System;
namespace Model
{
	/// <summary>
	/// ʵ����G_SuperAdmin ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class G_SuperAdmin
	{
		public G_SuperAdmin()
		{}
		#region Model
		private int? _sa_id;
		private string _sa_uname;
		private string _sa_pwd;
		private string _sa_tname;
		private string _a_phone;
		private int? _p_id;
		private int? _c_id;
		private int? _d_id;
		private int? _s_id;
		private int? _cm_id;
		private string _pcdscm_address;
		private DateTime? _a_addtime;
		/// <summary>
		/// ���
		/// </summary>
		public int? sa_id
		{
			set{ _sa_id=value;}
			get{return _sa_id;}
		}
		/// <summary>
		/// �û���
		/// </summary>
		public string sa_uname
		{
			set{ _sa_uname=value;}
			get{return _sa_uname;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string sa_pwd
		{
			set{ _sa_pwd=value;}
			get{return _sa_pwd;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string sa_tname
		{
			set{ _sa_tname=value;}
			get{return _sa_tname;}
		}
		/// <summary>
		/// �绰
		/// </summary>
		public string a_phone
		{
			set{ _a_phone=value;}
			get{return _a_phone;}
		}
		/// <summary>
		/// ��ַ-ʡ
		/// </summary>
		public int? p_id
		{
			set{ _p_id=value;}
			get{return _p_id;}
		}
		/// <summary>
		/// ��ַ-��
		/// </summary>
		public int? c_id
		{
			set{ _c_id=value;}
			get{return _c_id;}
		}
		/// <summary>
		/// ��ַ-��
		/// </summary>
		public int? d_id
		{
			set{ _d_id=value;}
			get{return _d_id;}
		}
		/// <summary>
		/// ��ַ-�ֵ�
		/// </summary>
		public int? s_id
		{
			set{ _s_id=value;}
			get{return _s_id;}
		}
		/// <summary>
		/// ��ַ-����
		/// </summary>
		public int? cm_id
		{
			set{ _cm_id=value;}
			get{return _cm_id;}
		}
		/// <summary>
		/// ��ַ-��ϸ��ַ
		/// </summary>
		public string pcdscm_address
		{
			set{ _pcdscm_address=value;}
			get{return _pcdscm_address;}
		}
		/// <summary>
		/// ���ʱ��
		/// </summary>
		public DateTime? a_addtime
		{
			set{ _a_addtime=value;}
			get{return _a_addtime;}
		}
		#endregion Model

	}
}

