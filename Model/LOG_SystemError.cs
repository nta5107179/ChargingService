using System;
namespace Model
{
	/// <summary>
	/// ʵ����LOG_SystemError ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class LOG_SystemError
	{
		public LOG_SystemError()
		{}
		#region Model
		private int? _log_se_id;
		private int? _t_id;
		private int? _v_id;
		private int? _log_se_stype;
		private string _log_se_content;
		private string _log_se_type;
		private string _log_se_information;
		private DateTime? _log_se_addtime;
		/// <summary>
		/// ���
		/// </summary>
		public int? log_se_id
		{
			set{ _log_se_id=value;}
			get{return _log_se_id;}
		}
		/// <summary>
		/// �����豸���ͣ���ӦG_Type�еı�ţ�
		/// </summary>
		public int? t_id
		{
			set{ _t_id=value;}
			get{return _t_id;}
		}
		/// <summary>
		/// �����豸Э�飨��ӦG_Version�еı�ţ�
		/// </summary>
		public int? v_id
		{
			set{ _v_id=value;}
			get{return _v_id;}
		}
		/// <summary>
		/// ����Ӧ�ó���1Ϊweb��2Ϊwin32��
		/// </summary>
		public int? log_se_stype
		{
			set{ _log_se_stype=value;}
			get{return _log_se_stype;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public string log_se_content
		{
			set{ _log_se_content=value;}
			get{return _log_se_content;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public string log_se_type
		{
			set{ _log_se_type=value;}
			get{return _log_se_type;}
		}
		/// <summary>
		/// ������Ϣ
		/// </summary>
		public string log_se_information
		{
			set{ _log_se_information=value;}
			get{return _log_se_information;}
		}
		/// <summary>
		/// ���ʱ��
		/// </summary>
		public DateTime? log_se_addtime
		{
			set{ _log_se_addtime=value;}
			get{return _log_se_addtime;}
		}
		#endregion Model

	}
}

