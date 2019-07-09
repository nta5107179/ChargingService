using Listener.App_Code.Include.HTTP;
using Model;
using Model.Project;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Media;
using SystemFramework;

namespace Listener.App_Code.Include.TCP
{
    public class IncludeTCPReceive002
    {
        AppCode m_appcode = new AppCode();
        IncludeIdCard m_incIdCard = new IncludeIdCard();
        IncludeChargePile m_incChargePile = new IncludeChargePile();
        IncludeAMCIMData m_incAMCIMData = new IncludeAMCIMData();
        IncludeUser m_incUser = new IncludeUser();
        IncludeAMCIMPolice m_incAMCIMPolice = new IncludeAMCIMPolice();
        IncludeChargeBattery m_incChargeBattery = new IncludeChargeBattery();
        IncludeTCPSend002 m_incTCPSend002 = new IncludeTCPSend002();

        /// <summary>
        /// 心跳
        /// </summary>
        /// <returns></returns>
        public string UP0001(string cp_code, string cb_code, string bodyData)
        {
            string sendData = "";
            Dictionary<string, object> tcpClientDic = Config.g_tcpClientDic[cp_code];
            Listener_ChargePile_Data_AC data = (Listener_ChargePile_Data_AC)tcpClientDic["data"];
            //解析包文体
            MatchCollection arr = Regex.Matches(bodyData, @"(?<=\[)[^\]]*(?=\])");
            string UP_0 = arr[0].Value;//是否在充电
            string UP_1 = arr[1].Value;//枪编号
            string[] UP_2 = arr[2].Value.Split('|');//电压
            string[] UP_3 = arr[3].Value.Split('|');//电流
            string UP_4 = arr[4].Value;//有功功率
            string UP_5 = arr[5].Value;//无功功率
            string UP_6 = arr[6].Value;//功率因数
            string UP_7 = double.Parse(arr[7].Value).ToString();//电度
            string UP_8 = arr[8].Value;//充电剩余时间
            string UP_9 = arr[9].Value;//用户名
            //枪编号大于0才执行
            if (int.Parse(UP_1) > 0)
            {
                if (int.Parse(UP_0) == 1)
                {
                    data.gundata[int.Parse(UP_1)].cb_code = cb_code;
                    m_incTCPSend002.DW0010(cp_code, cb_code, long.Parse(UP_9));
                }
            }

            string checkbody = "DW0001";
            sendData =
                tcpClientDic["version"].ToString() +
                data.cs_id +
                cp_code +
                cb_code +
                CRC16.GetString(checkbody) +
                checkbody;
            return sendData;
        }
        /// <summary>
        /// 报警
        /// </summary>
        /// <returns></returns>
        public string UP0003(string cp_code, string cb_code, string bodyData)
        {
            string sendData = "";
            Dictionary<string, object> tcpClientDic = Config.g_tcpClientDic[cp_code];
            Listener_ChargePile_Data_AC data = (Listener_ChargePile_Data_AC)tcpClientDic["data"];

            MatchCollection arr = Regex.Matches(bodyData, @"(?<=\[)[^\]]*(?=\])");
            string UP_0 = arr[0].Value;//枪编号
            string UP_1 = arr[1].Value;//报警码

            //更新充电桩报警状态
            if (int.Parse(UP_1) != 255)
            {
                data.gundata[int.Parse(UP_0)].ispolice = true;
                data.gundata[int.Parse(UP_0)].police = Config.g_police[int.Parse(UP_1)];
                data.gundata[int.Parse(UP_0)].policecode = int.Parse(UP_1);

                //将报警数据写入数据库
                AM_CIMPolice mod = new AM_CIMPolice();
                mod.cs_id = data.cs_id;
                mod.t_id = data.t_id;
                mod.v_id = data.v_id;
                mod.cp_id = data.cp_id;
                mod.cp_code = data.cp_code;
                mod.cp_guncode = int.Parse(UP_0);
                List<G_ChargeBattery> list = m_incChargeBattery.GetChargeBattery(cb_code);
                if (list.Count > 0)
                    mod.cb_id = list[0].cb_id;
                else
                    mod.cb_id = 0;
                mod.cb_code = cb_code;
                mod.am_cimp_condition = data.condition;
                mod.am_cimp_type = int.Parse(UP_1);
                mod.am_cimp_examine = false;
                m_incAMCIMPolice.AddAMCIMPolice(mod);
            }
            else
            {
                data.gundata[int.Parse(UP_0)].ispolice = false;
                data.gundata[int.Parse(UP_0)].police = "";
                data.gundata[int.Parse(UP_0)].policecode = 0;
            }

            string checkbody = "DW0003[1]";
            sendData =
                tcpClientDic["version"].ToString() +
                data.cs_id +
                cp_code +
                cb_code +
                CRC16.GetString(checkbody) +
                checkbody;
            return sendData;
        }
        /// <summary>
        /// 刷卡请求
        /// </summary>
        /// <returns></returns>
        public string UP0005(string cp_code, string cb_code, string bodyData)
        {
            string sendData = "";
            Dictionary<string, object> tcpClientDic = Config.g_tcpClientDic[cp_code];
            Listener_ChargePile_Data_AC data = (Listener_ChargePile_Data_AC)tcpClientDic["data"];
            
            MatchCollection arr = Regex.Matches(bodyData, @"(?<=\[)[^\]]*(?=\])");
            string UP_0 = arr[0].Value;//卡号
            List<Models> list = m_incIdCard.GetIcCardList(long.Parse(UP_0));
            List<G_ChargePile> list2 = m_incChargePile.GetChargePile(data.cs_id, data.cp_id);
            if (list.Count > 0 && list2.Count > 0)
            {
                //设置电价
                data.unitmoney = (decimal)list2[0].cp_money;

                sendData = "[1]"+
                    "[" + ((decimal)list[0].G_User.u_money).ToString("0.00") + "]"+
                    "[" + list[0].G_User.u_uname + "]"+
                    "[" + ((decimal)list2[0].cp_money).ToString("0.00") + "]";
            }
            else
            {
                sendData = "[0][0][0][0.00]";
            }

            string checkbody = "DW0005" + sendData;
            sendData =
                tcpClientDic["version"].ToString() +
                data.cs_id +
                cp_code +
                cb_code +
                CRC16.GetString(checkbody) +
                checkbody;
            
            return sendData;
        }
        /// <summary>
        /// 响应系统升级设置
        /// </summary>
        /// <returns></returns>
        public string UP0007(string cp_code, string cb_code, string bodyData)
        {
            string sendData = "";
            Dictionary<string, object> tcpClientDic = Config.g_tcpClientDic[cp_code];
            Listener_ChargePile_Data_AC data = (Listener_ChargePile_Data_AC)tcpClientDic["data"];

            MatchCollection arr = Regex.Matches(bodyData, @"(?<=\[)[^\]]*(?=\])");
            string UP_0 = arr[0].Value;//是否成功
            //成功
            if (UP_0 == "1")
            {

            }
            //失败
            else if (UP_0 == "0")
            {

            }
            return sendData;
        }
        /// <summary>
        /// 结束充电命令
        /// </summary>
        /// <returns></returns>
        public string UP0009(string cp_code, string cb_code, string bodyData)
        {
            string sendData = "";
            Dictionary<string, object> tcpClientDic = Config.g_tcpClientDic[cp_code];
            Listener_ChargePile_Data_AC data = (Listener_ChargePile_Data_AC)tcpClientDic["data"];
            
            MatchCollection arr = Regex.Matches(bodyData, @"(?<=\[)[^\]]*(?=\])");
            string UP_0 = arr[0].Value;//枪编号
            string UP_1 = arr[1].Value;//用户名
            string UP_2 = arr[2].Value;//已充电量
            string UP_3 = arr[3].Value;//充电开始时间

            //计算充电数据
            List<G_User> list = m_incUser.GetUser(long.Parse(UP_1));
            if (list.Count > 0)
            {
                //开始统计单次充电数据
                AM_CIMData mod = new AM_CIMData();
                mod.cs_id = data.cs_id;
                mod.t_id = data.t_id;
                mod.v_id = data.v_id;
                mod.cp_id = data.cp_id;
                mod.cp_code = cp_code;
                mod.cb_id = 0;
                mod.cb_code = cb_code;
                mod.am_cimd_begintime = DateTime.Parse(UP_3);
                mod.am_cimd_endtime = DateTime.Now;
                mod.am_cimd_kwh = double.Parse(UP_2);
                mod.am_cimd_unitmoney = data.unitmoney;
                mod.am_cimd_money = Convert.ToDecimal(Math.Ceiling(double.Parse(UP_2) * Convert.ToDouble(mod.am_cimd_unitmoney) * 100) / 100);
                mod.am_cimd_health = 0;
                mod.am_cimd_chargenum = 0;
                mod.u_id = list[0].u_id;
                mod.cp_guncode = int.Parse(UP_0);
                if (m_incAMCIMData.AddAMCIMData(mod))
                {
                    sendData = "[1][" + (((decimal)list[0].u_money) - (decimal)mod.am_cimd_money).ToString("0.00") + "]";

                    //重置充电桩数据
                    data.condition = 1;
                    data.unitmoney = 0;
                    data.gundata[int.Parse(UP_0)].guncondition = false;
                    data.gundata[int.Parse(UP_0)].useruname = 0;
                    data.gundata[int.Parse(UP_0)].kwh = 0;
                    data.gundata[int.Parse(UP_0)].timeleft = new TimeSpan(0);
                    data.gundata[int.Parse(UP_0)].chargemod = 0;
                    data.gundata[int.Parse(UP_0)].chargemodcontent = 0;
                }
                else
                {
                    sendData = "[0][0]";
                }
            }
            else
            {
                sendData = "[1][0]";
            }

            string checkbody = "DW0009" + sendData;
            sendData =
                tcpClientDic["version"].ToString() +
                data.cs_id +
                cp_code +
                cb_code +
                CRC16.GetString(checkbody) +
                checkbody;
            return sendData;
        }
        /// <summary>
        /// 响应获取充电状态请求
        /// </summary>
        /// <returns></returns>
        public string UP0010(string cp_code, string cb_code, string bodyData)
        {
            string sendData = "";
            Dictionary<string, object> tcpClientDic = Config.g_tcpClientDic[cp_code];
            Listener_ChargePile_Data_AC data = (Listener_ChargePile_Data_AC)tcpClientDic["data"];

            MatchCollection arr = Regex.Matches(bodyData, @"(?<=\[)[^\]]*(?=\])");
            string UP_0 = arr[0].Value;//枪编号
            string UP_1 = arr[1].Value;//用户名
            string UP_2 = arr[2].Value;//已充电量
            string UP_3 = arr[3].Value;//剩余时间
            string UP_4 = arr[4].Value;//单价，元/度
            string UP_5 = arr[5].Value;//充电模式，1按时间、2按金额、3按电量、4自动充满
            string UP_6 = arr[6].Value;//数值（当2为4时，此值为0）

            if (int.Parse(UP_0) > 0)
            {
                //更新充电桩状态
                data.condition = 2;
                data.gundata[int.Parse(UP_0)].useruname = long.Parse(UP_1);
                data.gundata[int.Parse(UP_0)].kwh = double.Parse(UP_2);
                data.gundata[int.Parse(UP_0)].timeleft = TimeSpan.FromSeconds(double.Parse(UP_3));
                data.unitmoney = decimal.Parse(UP_4);
                data.gundata[int.Parse(UP_0)].chargemod = int.Parse(UP_5);
                data.gundata[int.Parse(UP_0)].chargemodcontent = long.Parse(UP_6);
                data.gundata[int.Parse(UP_0)].guncondition = true;
            }

            string checkbody = "DW0011[1]";
            sendData =
                tcpClientDic["version"].ToString() +
                data.cs_id +
                cp_code +
                cb_code +
                CRC16.GetString(checkbody) +
                checkbody;
            return sendData;
        }
        /// <summary>
        /// 获取服务器时间
        /// </summary>
        /// <returns></returns>
        public string UP0012(string cp_code, string cb_code, string bodyData)
        {
            string sendData = "";
            Dictionary<string, object> tcpClientDic = Config.g_tcpClientDic[cp_code];
            Listener_ChargePile_Data_AC data = (Listener_ChargePile_Data_AC)tcpClientDic["data"];

            string checkbody = "DW0012[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "]";
            sendData =
                tcpClientDic["version"].ToString() +
                data.cs_id +
                cp_code +
                cb_code +
                CRC16.GetString(checkbody) +
                checkbody;
            return sendData;
        }

    }
}
