using System;
namespace Model
{
	/// <summary>
	/// ʵ����G_Province ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class G_Province
	{
		public G_Province()
		{}
		#region Model
		private int? _p_id;
		private string _p_name;
		private string _p_phone;
		private bool? _p_examine;
		/// <summary>
		/// ��ţ����꣩
		/// </summary>
		public int? p_id
		{
			set{ _p_id=value;}
			get{return _p_id;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string p_name
		{
			set{ _p_name=value;}
			get{return _p_name;}
		}
		/// <summary>
		/// �绰
		/// </summary>
		public string p_phone
		{
			set{ _p_phone=value;}
			get{return _p_phone;}
		}
		/// <summary>
		/// �Ƿ���ˣ�0��1�ǣ�Ĭ��0��
		/// </summary>
		public bool? p_examine
		{
			set{ _p_examine=value;}
			get{return _p_examine;}
		}
		#endregion Model

	}
}

