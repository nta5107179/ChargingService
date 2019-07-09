using System;
using Model;

namespace Model
{
	/// <summary>
	/// 实体集合
	/// </summary>
	[Serializable]
	public class Models
	{
		public Models()
		{ }
		#region Model
        private AM_CIMData _AM_CIMData;
        private AM_CIMPolice _AM_CIMPolice;
        private AM_DownLecture _AM_DownLecture;
        private AM_MDownLecture _AM_MDownLecture;
        private AM_MUpLecture _AM_MUpLecture;
        private AM_UpLecture _AM_UpLecture;
        private CAR_CarBrand _CAR_CarBrand;
        private CAR_CarType _CAR_CarType;
        private CS_SystemMessage _CS_SystemMessage;
        private G_ChargeBattery _G_ChargeBattery;
        private G_ChargePile _G_ChargePile;
        private G_ChargeStation _G_ChargeStation;
        private G_City _G_City;
        private G_Community _G_Community;
        private G_District _G_District;
        private G_Province _G_Province;
        private G_Street _G_Street;
        private G_SuperAdmin _G_SuperAdmin;
        private G_SystemMessage _G_SystemMessage;
        private G_SystemMessageType _G_SystemMessageType;
        private G_Type _G_Type;
        private G_User _G_User;
        private G_UserCar _G_UserCar;
        private G_Version _G_Version;
        private G_Version2 _G_Version2;
        private LOG_SystemError _LOG_SystemError;
        private PAY_IdCard _PAY_IdCard;
        private User_CollectClip _User_CollectClip;
        private User_SystemMessage _User_SystemMessage;
        private CAR_BelongsTo _CAR_BelongsTo;
        private PAY_Alipay _PAY_Alipay;
        private PAY_TransactionRecord _PAY_TransactionRecord;
        private PAY_TRFrom _PAY_TRFrom;
        private PAY_TRType _PAY_TRType;
		#endregion

		/// <summary>
        /// 
		/// </summary>
        public AM_CIMData AM_CIMData
		{
            set { _AM_CIMData = value; }
            get { return _AM_CIMData; }
		}
        /// <summary>
        /// 
        /// </summary>
        public AM_CIMPolice AM_CIMPolice
        {
            set { _AM_CIMPolice = value; }
            get { return _AM_CIMPolice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public AM_DownLecture AM_DownLecture
        {
            set { _AM_DownLecture = value; }
            get { return _AM_DownLecture; }
        }
        /// <summary>
        /// 
        /// </summary>
        public AM_MDownLecture AM_MDownLecture
        {
            set { _AM_MDownLecture = value; }
            get { return _AM_MDownLecture; }
        }
        /// <summary>
        /// 
        /// </summary>
        public AM_MUpLecture AM_MUpLecture
        {
            set { _AM_MUpLecture = value; }
            get { return _AM_MUpLecture; }
        }
        /// <summary>
        /// 
        /// </summary>
        public AM_UpLecture AM_UpLecture
        {
            set { _AM_UpLecture = value; }
            get { return _AM_UpLecture; }
        }
        /// <summary>
        /// 
        /// </summary>
        public CAR_CarBrand CAR_CarBrand
        {
            set { _CAR_CarBrand = value; }
            get { return _CAR_CarBrand; }
        }
        /// <summary>
        /// 
        /// </summary>
        public CAR_CarType CAR_CarType
        {
            set { _CAR_CarType = value; }
            get { return _CAR_CarType; }
        }
        /// <summary>
        /// 
        /// </summary>
        public CS_SystemMessage CS_SystemMessage
        {
            set { _CS_SystemMessage = value; }
            get { return _CS_SystemMessage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public G_ChargeBattery G_ChargeBattery
        {
            set { _G_ChargeBattery = value; }
            get { return _G_ChargeBattery; }
        }
        /// <summary>
        /// 
        /// </summary>
        public G_ChargePile G_ChargePile
        {
            set { _G_ChargePile = value; }
            get { return _G_ChargePile; }
        }
        /// <summary>
        /// 
        /// </summary>
        public G_ChargeStation G_ChargeStation
        {
            set { _G_ChargeStation = value; }
            get { return _G_ChargeStation; }
        }
        /// <summary>
        /// 
        /// </summary>
        public G_City G_City
        {
            set { _G_City = value; }
            get { return _G_City; }
        }
        /// <summary>
        /// 
        /// </summary>
        public G_Community G_Community
        {
            set { _G_Community = value; }
            get { return _G_Community; }
        }
        /// <summary>
        /// 
        /// </summary>
        public G_District G_District
        {
            set { _G_District = value; }
            get { return _G_District; }
        }
        /// <summary>
        /// 
        /// </summary>
        public G_Province G_Province
        {
            set { _G_Province = value; }
            get { return _G_Province; }
        }
        /// <summary>
        /// 
        /// </summary>
        public G_Street G_Street
        {
            set { _G_Street = value; }
            get { return _G_Street; }
        }
        /// <summary>
        /// 
        /// </summary>
        public G_SuperAdmin G_SuperAdmin
        {
            set { _G_SuperAdmin = value; }
            get { return _G_SuperAdmin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public G_SystemMessage G_SystemMessage
        {
            set { _G_SystemMessage = value; }
            get { return _G_SystemMessage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public G_SystemMessageType G_SystemMessageType
        {
            set { _G_SystemMessageType = value; }
            get { return _G_SystemMessageType; }
        }
        /// <summary>
        /// 
        /// </summary>
        public G_Type G_Type
        {
            set { _G_Type = value; }
            get { return _G_Type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public G_User G_User
        {
            set { _G_User = value; }
            get { return _G_User; }
        }
        /// <summary>
        /// 
        /// </summary>
        public G_UserCar G_UserCar
        {
            set { _G_UserCar = value; }
            get { return _G_UserCar; }
        }
        /// <summary>
        /// 
        /// </summary>
        public G_Version G_Version
        {
            set { _G_Version = value; }
            get { return _G_Version; }
        }
        /// <summary>
        /// 
        /// </summary>
        public G_Version2 G_Version2
        {
            set { _G_Version2 = value; }
            get { return _G_Version2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public LOG_SystemError LOG_SystemError
        {
            set { _LOG_SystemError = value; }
            get { return _LOG_SystemError; }
        }
        /// <summary>
        /// 
        /// </summary>
        public PAY_IdCard PAY_IdCard
        {
            set { _PAY_IdCard = value; }
            get { return _PAY_IdCard; }
        }
        /// <summary>
        /// 
        /// </summary>
        public User_CollectClip User_CollectClip
        {
            set { _User_CollectClip = value; }
            get { return _User_CollectClip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public User_SystemMessage User_SystemMessage
        {
            set { _User_SystemMessage = value; }
            get { return _User_SystemMessage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public CAR_BelongsTo CAR_BelongsTo
        {
            set { _CAR_BelongsTo = value; }
            get { return _CAR_BelongsTo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public PAY_Alipay PAY_Alipay
        {
            set { _PAY_Alipay = value; }
            get { return _PAY_Alipay; }
        }
        /// <summary>
        /// 
        /// </summary>
        public PAY_TransactionRecord PAY_TransactionRecord
        {
            set { _PAY_TransactionRecord = value; }
            get { return _PAY_TransactionRecord; }
        }
        /// <summary>
        /// 
        /// </summary>
        public PAY_TRFrom PAY_TRFrom
        {
            set { _PAY_TRFrom = value; }
            get { return _PAY_TRFrom; }
        }
        /// <summary>
        /// 
        /// </summary>
        public PAY_TRType PAY_TRType
        {
            set { _PAY_TRType = value; }
            get { return _PAY_TRType; }
        }
	}
}
