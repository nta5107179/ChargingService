using System;
namespace Model
{
	/// <summary>
	/// ʵ����G_District ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class G_District
	{
		public G_District()
		{}
		#region Model
		private int? _d_id;
		private string _d_name;
		private int? _c_id;
		private string _d_phone;
		private bool? _d_examine;
		/// <summary>
		/// ��ţ����꣩
		/// </summary>
		public int? d_id
		{
			set{ _d_id=value;}
			get{return _d_id;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string d_name
		{
			set{ _d_name=value;}
			get{return _d_name;}
		}
		/// <summary>
		/// �����У���ӦG_City�еı�ţ�
		/// </summary>
		public int? c_id
		{
			set{ _c_id=value;}
			get{return _c_id;}
		}
		/// <summary>
		/// �绰
		/// </summary>
		public string d_phone
		{
			set{ _d_phone=value;}
			get{return _d_phone;}
		}
		/// <summary>
		/// �Ƿ���ˣ�0��1�ǣ�Ĭ��0��
		/// </summary>
		public bool? d_examine
		{
			set{ _d_examine=value;}
			get{return _d_examine;}
		}
		#endregion Model

	}
}

