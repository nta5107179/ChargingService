using System;
namespace Model
{
	/// <summary>
	/// ʵ����G_City ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class G_City
	{
		public G_City()
		{}
		#region Model
		private int? _c_id;
		private string _c_name;
		private int? _p_id;
		private string _c_phone;
		private bool? _c_examine;
		/// <summary>
		/// ��ţ����꣩
		/// </summary>
		public int? c_id
		{
			set{ _c_id=value;}
			get{return _c_id;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string c_name
		{
			set{ _c_name=value;}
			get{return _c_name;}
		}
		/// <summary>
		/// ����ʡ����ӦG_Province�еı�ţ�
		/// </summary>
		public int? p_id
		{
			set{ _p_id=value;}
			get{return _p_id;}
		}
		/// <summary>
		/// �绰
		/// </summary>
		public string c_phone
		{
			set{ _c_phone=value;}
			get{return _c_phone;}
		}
		/// <summary>
		/// �Ƿ���ˣ�0��1�ǣ�Ĭ��0��
		/// </summary>
		public bool? c_examine
		{
			set{ _c_examine=value;}
			get{return _c_examine;}
		}
		#endregion Model

	}
}

