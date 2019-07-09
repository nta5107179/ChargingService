using Model.Project;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Media;
using SystemFramework;

namespace Listener.App_Code.Include.TCP
{
    public class IncludeTCPReceive001
    {
        IncludeChargeStation m_incChargeStation = new IncludeChargeStation();

        /// <summary>
        /// 心跳
        /// </summary>
        public string UP0001(string cs_id, string bodyData, Listener_ChargeStation_Data mod)
        {
            string sendData = "";
            Dictionary<string, object> tcpClientDic = Config.g_tcpCSClientDic[cs_id];
            Listener_ChargeStation_Data data = (Listener_ChargeStation_Data)tcpClientDic["data"];

            MatchCollection arr = Regex.Matches(bodyData, @"(?<=\[)[^\]]*(?=\])");
            string UP_1 = arr[0].Value;//是否正常
            string UP_5 = arr[1].Value;//充电监控状态
            string UP_6 = arr[2].Value;//配电监控状态
            string UP_7 = arr[3].Value;//安防监控状态
            string UP_8 = arr[4].Value;//消防监控状态

            mod.hascs = "是";
            mod.brush = Brushes.Green;

            sendData = "[0]";

            string checkbody = "DW0001" + sendData;
            sendData = 
                tcpClientDic["version"].ToString() +
                tcpClientDic["cs_id"].ToString() +
                CRC16.GetString(checkbody) +
                checkbody;
            return sendData;
        }
        /// <summary>
        /// 登录
        /// </summary>
        public Dictionary<string, object> UP0002(ref string cs_id, ref string sendData, string version, string bodyData)
        {
            sendData = "";
            MatchCollection arr = Regex.Matches(bodyData, @"(?<=\[)[^\]]*(?=\])");
            string UP_0 = arr[0].Value;//用户名
            string UP_1 = arr[1].Value;//密码
            Dictionary<string, object> dic = m_incChargeStation.LoginChargeStation(UP_0, UP_1);
            cs_id = dic["cs_id"].ToString();
            if ((int)dic["condition"] == 1)
            {
                //登录成功
                sendData = "[1][LOGIN000]";
                string checkbody = "DW0002" + sendData;
                sendData = 
                    version +
                    cs_id +
                    CRC16.GetString(checkbody) +
                    checkbody;
            }
            else if ((int)dic["condition"] == 0)
            {
                //登录失败
                sendData = "[0][LOGIN003]";
                string checkbody = "DW0002" + sendData;
                sendData = 
                    version +
                    "0000000000" +
                    CRC16.GetString(checkbody) +
                    checkbody;
            }
            else if ((int)dic["condition"] == -1)
            {
                //账号过期
                sendData = "[0][LOGIN004]";
                string checkbody = "DW0002" + sendData;
                sendData = 
                    version +
                    "0000000000" +
                    CRC16.GetString(checkbody) +
                    checkbody;
            }
            else if ((int)dic["condition"] == -2)
            {
                //账号未激活
                sendData = "[0][LOGIN005]";
                string checkbody = "DW0002" + sendData;
                sendData = 
                    version +
                    "0000000000" +
                    CRC16.GetString(checkbody) +
                    checkbody;
            }
            return dic;
        }
    }
}
