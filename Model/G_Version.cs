using System;
namespace Model
{
	/// <summary>
	/// ʵ����G_Version ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class G_Version
	{
		public G_Version()
		{}
		#region Model
		private int? _v_id;
		private string _v_name;
		/// <summary>
		/// ���
		/// </summary>
		public int? v_id
		{
			set{ _v_id=value;}
			get{return _v_id;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string v_name
		{
			set{ _v_name=value;}
			get{return _v_name;}
		}
		#endregion Model

	}
}

