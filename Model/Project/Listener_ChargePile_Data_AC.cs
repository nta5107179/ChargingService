using System;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Media;
namespace Model.Project
{
    /// <summary>
    /// 表示交流充电桩数据
    /// </summary>
    [Serializable]
    public partial class Listener_ChargePile_Data_AC
    {
        public Listener_ChargePile_Data_AC()
        { }
        #region Model
        private long _cp_id = 0;//充电桩编号
        private long _cs_id = 0;//充电站编号
        private string _cp_code = "";//充电桩编码
        private int _gunnum = 0;//枪数量
        private int _chargemod = 0;//充电模式，1交流、2直流
        private int _t_id = 0;//充电桩类型
        private int _v_id = 0;//协议类型
        private Listener_ChargePile_GunData_AC[] _gundata = null;//充电枪数据

        //以下内容需要在获取充电数据、充电结束时变更
        private int _condition = 0;//0未连接未充电，1已连接未充电，2已连接已充电

        //以下内容需要在刷卡、充电请求时变更
        private decimal _unitmoney = 0;//电价

        /// <summary>
        /// 充电桩编号
        /// </summary>
        public long cp_id
        {
            set { _cp_id = value; }
            get { return _cp_id; }
        }
        /// <summary>
        /// 充电站编号
        /// </summary>
        public long cs_id
        {
            set { _cs_id = value; }
            get { return _cs_id; }
        }
        /// <summary>
        /// 充电桩编码
        /// </summary>
        public string cp_code
        {
            set { _cp_code = value; }
            get { return _cp_code; }
        }
        /// <summary>
        /// 枪数量
        /// </summary>
        public int gunnum
        {
            set { _gunnum = value; }
            get { return _gunnum; }
        }
        /// <summary>
        /// 充电模式，1交流、2直流
        /// </summary>
        public int chargemod
        {
            set { _chargemod = value; }
            get { return _chargemod; }
        }
        /// <summary>
        /// 充电桩类型
        /// </summary>
        public int t_id
        {
            set { _t_id = value; }
            get { return _t_id; }
        }
        /// <summary>
        /// 协议类型
        /// </summary>
        public int v_id
        {
            set { _v_id = value; }
            get { return _v_id; }
        }
        /// <summary>
        /// 电价
        /// </summary>
        public decimal unitmoney
        {
            set { _unitmoney = value; }
            get { return _unitmoney; }
        }
        /// <summary>
        /// 状态0、未连接未充电，1、已连接未充电，2、已连接已充电
        /// </summary>
        public int condition
        {
            set { _condition = value; }
            get { return _condition; }
        }
        /// <summary>
        /// 充电枪数据
        /// </summary>
        public Listener_ChargePile_GunData_AC[] gundata
        {
            set { _gundata = value; }
            get { return _gundata; }
        }
        #endregion
    }
}

