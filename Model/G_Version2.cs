using System;
namespace Model
{
	/// <summary>
	/// ʵ����G_Version2 ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class G_Version2
	{
		public G_Version2()
		{}
		#region Model
		private int? _v2_id;
		private string _v2_name;
		/// <summary>
		/// ���
		/// </summary>
		public int? v2_id
		{
			set{ _v2_id=value;}
			get{return _v2_id;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string v2_name
		{
			set{ _v2_name=value;}
			get{return _v2_name;}
		}
		#endregion Model

	}
}

