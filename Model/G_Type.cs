using System;
namespace Model
{
	/// <summary>
	/// ʵ����G_Type ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class G_Type
	{
		public G_Type()
		{}
		#region Model
		private int? _t_id;
		private string _t_name;
		private string _t_path;
		/// <summary>
		/// ���
		/// </summary>
		public int? t_id
		{
			set{ _t_id=value;}
			get{return _t_id;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string t_name
		{
			set{ _t_name=value;}
			get{return _t_name;}
		}
		/// <summary>
		/// ·������������ͬ��ϵͳ��
		/// </summary>
		public string t_path
		{
			set{ _t_path=value;}
			get{return _t_path;}
		}
		#endregion Model

	}
}

