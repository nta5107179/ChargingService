using System;
namespace Model
{
	/// <summary>
	/// ʵ����G_Community ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class G_Community
	{
		public G_Community()
		{}
		#region Model
		private int? _cm_id;
		private string _cm_name;
		private int? _s_id;
		private string _cm_phone;
		private bool? _cm_examine;
		/// <summary>
		/// ���
		/// </summary>
		public int? cm_id
		{
			set{ _cm_id=value;}
			get{return _cm_id;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string cm_name
		{
			set{ _cm_name=value;}
			get{return _cm_name;}
		}
		/// <summary>
		/// �����ֵ�����ӦG_Street�еı�ţ�
		/// </summary>
		public int? s_id
		{
			set{ _s_id=value;}
			get{return _s_id;}
		}
		/// <summary>
		/// �绰
		/// </summary>
		public string cm_phone
		{
			set{ _cm_phone=value;}
			get{return _cm_phone;}
		}
		/// <summary>
		/// �Ƿ���ˣ�0��1�ǣ�Ĭ��0��
		/// </summary>
		public bool? cm_examine
		{
			set{ _cm_examine=value;}
			get{return _cm_examine;}
		}
		#endregion Model

	}
}

