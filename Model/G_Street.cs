using System;
namespace Model
{
	/// <summary>
	/// ʵ����G_Street ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class G_Street
	{
		public G_Street()
		{}
		#region Model
		private int? _s_id;
		private string _s_name;
		private int? _d_id;
		private string _s_phone;
		private bool? _s_examine;
		/// <summary>
		/// ���
		/// </summary>
		public int? s_id
		{
			set{ _s_id=value;}
			get{return _s_id;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string s_name
		{
			set{ _s_name=value;}
			get{return _s_name;}
		}
		/// <summary>
		/// ����������ӦG_District�еı�ţ�
		/// </summary>
		public int? d_id
		{
			set{ _d_id=value;}
			get{return _d_id;}
		}
		/// <summary>
		/// �绰
		/// </summary>
		public string s_phone
		{
			set{ _s_phone=value;}
			get{return _s_phone;}
		}
		/// <summary>
		/// �Ƿ���ˣ�0��1�ǣ�Ĭ��0��
		/// </summary>
		public bool? s_examine
		{
			set{ _s_examine=value;}
			get{return _s_examine;}
		}
		#endregion Model

	}
}

