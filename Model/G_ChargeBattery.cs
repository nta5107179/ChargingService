using System;
namespace Model
{
	/// <summary>
	/// ʵ����G_ChargeBattery ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class G_ChargeBattery
	{
		public G_ChargeBattery()
		{}
		#region Model
		private long? _cb_id;
		private string _cb_code;
		private bool? _cb_examine;
		private DateTime? _cb_addtime;
		/// <summary>
		/// ���
		/// </summary>
		public long? cb_id
		{
			set{ _cb_id=value;}
			get{return _cb_id;}
		}
		/// <summary>
		/// ���к�
		/// </summary>
		public string cb_code
		{
			set{ _cb_code=value;}
			get{return _cb_code;}
		}
		/// <summary>
		/// �Ƿ���ˣ�0��1�ǣ�Ĭ��1��
		/// </summary>
		public bool? cb_examine
		{
			set{ _cb_examine=value;}
			get{return _cb_examine;}
		}
		/// <summary>
		/// ���ʱ��
		/// </summary>
		public DateTime? cb_addtime
		{
			set{ _cb_addtime=value;}
			get{return _cb_addtime;}
		}
		#endregion Model

	}
}

