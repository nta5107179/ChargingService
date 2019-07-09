using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Media;
namespace Model.Project
{
    /// <summary>
    /// 表示交流充电桩数据
    /// </summary>
    [Serializable]
    public partial class Client_ChargePile_Data_AC : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Client_ChargePile_Data_AC()
        { }
        #region Model
        private string _t_name = "";//设备类型
        private string _v_name = "";//协议类型
        private string _cp_name = "";//充电桩名称
        private long _cp_id = 0;//充电桩编号
        private long _cs_id = 0;//充电站编号
        private string _cp_code = "";//充电桩编码
        private int _gunnum = 0;//枪数量
        private int _chargemod = 0;//充电模式，1交流、2直流
        private bool _ispolice = false;//0未报警，1报警
        private ObservableCollection<Client_ChargePile_GunData_AC> _gundata = null;//充电枪数据

        //以下内容需要在获取充电数据、充电结束时变更
        private int _condition = 0;//0未连接未充电，1已连接未充电，2已连接已充电

        //以下内容需要在刷卡、充电请求时变更
        private decimal _unitmoney = 0;//电价

        /// <summary>
        /// 设备类型
        /// </summary>
        public string t_name
        {
            set { _t_name = value; prochanged("t_name"); }
            get { return _t_name; }
        }
        /// <summary>
        /// 协议类型
        /// </summary>
        public string v_name
        {
            set { _v_name = value; prochanged("v_name"); }
            get { return _v_name; }
        }
        /// <summary>
        /// 充电桩名称
        /// </summary>
        public string cp_name
        {
            set { _cp_name = value; prochanged("cp_name"); }
            get { return _cp_name; }
        }
        /// <summary>
        /// 充电桩编号
        /// </summary>
        public long cp_id
        {
            set { _cp_id = value; prochanged("cp_id"); }
            get { return _cp_id; }
        }
        /// <summary>
        /// 充电站编号
        /// </summary>
        public long cs_id
        {
            set { _cs_id = value; prochanged("cs_id"); }
            get { return _cs_id; }
        }
        /// <summary>
        /// 充电桩编码
        /// </summary>
        public string cp_code
        {
            set { _cp_code = value; prochanged("cp_code"); }
            get { return _cp_code; }
        }
        /// <summary>
        /// 枪数量
        /// </summary>
        public int gunnum
        {
            set { _gunnum = value; prochanged("gunnum"); }
            get { return _gunnum; }
        }
        /// <summary>
        /// 充电模式，1交流、2直流
        /// </summary>
        public int chargemod
        {
            set { _chargemod = value; prochanged("chargemod"); }
            get { return _chargemod; }
        }
        /// <summary>
        /// 电价
        /// </summary>
        public decimal unitmoney
        {
            set { _unitmoney = value; prochanged("unitmoney"); }
            get { return _unitmoney; }
        }
        /// <summary>
        /// 状态0、未连接未充电，1、已连接未充电，2、已连接已充电
        /// </summary>
        public int condition
        {
            set { _condition = value; prochanged("condition"); }
            get { return _condition; }
        }
        /// <summary>
        /// 充电枪数据
        /// </summary>
        public ObservableCollection<Client_ChargePile_GunData_AC> gundata
        {
            set { _gundata = value; prochanged("gundata"); }
            get { return _gundata; }
        }
        /// <summary>
        /// 是否报警
        /// </summary>
        public bool ispolice
        {
            set { _ispolice = value; prochanged("ispolice"); }
            get { return _ispolice; }
        }
        #endregion
        private void prochanged(string info)
        {
            if (PropertyChanged != null)
            {
                //是不是很奇怪，这个事件发起后，处理函数在哪里？
                //我也不知道在哪里，我只知道，绑定成功后WPF会帮我们决定怎么处理。
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

    }
}

