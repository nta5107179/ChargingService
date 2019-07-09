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
    public class IncludeTCPSend002
    {
        AppCode m_appcode = new AppCode();
        IncludeUser m_incUser = new IncludeUser();
        IncludeAMCIMData m_incAMCIMData = new IncludeAMCIMData();
        IncludeChargePile m_incChargePile = new IncludeChargePile();

        /// <summary>
        /// 充电请求
        /// </summary>
        /// <returns></returns>
        public bool DW0002(long cs_id, string cp_code, long u_uname, long u_id, int cp_guncode, int calmod, string cal)
        {
            bool b = false;
            string sendData = "";
            if (Config.g_tcpClientDic.ContainsKey(cp_code))
            {
                Dictionary<string, object> tcpClientDic = Config.g_tcpClientDic[cp_code];
                Listener_ChargePile_Data_AC data = (Listener_ChargePile_Data_AC)tcpClientDic["data"];
                Socket socket = (Socket)tcpClientDic["socket"];

                List<G_User> list = m_incUser.GetUser(u_uname);
                List<G_ChargePile> list2 = m_incChargePile.GetChargePile(data.cs_id, data.cp_id);
                if (list.Count > 0 && list2.Count > 0)
                {
                    //设置电价
                    data.unitmoney = (decimal)list2[0].cp_money;

                    sendData = "[" + cp_guncode + "][" + calmod + "][" + cal + "][" + ((decimal)list[0].u_money).ToString("0.00") + "][" + list[0].u_uname + "][" + ((decimal)list2[0].cp_money).ToString("0.00") + "]";

                    string checkbody = "DW0002" + sendData;
                    sendData =
                        tcpClientDic["version"].ToString() +
                        data.cs_id +
                        cp_code +
                        data.gundata[cp_guncode].cb_code +
                        CRC16.GetString(checkbody) +
                        checkbody;
                    socket.Send(Encoding.UTF8.GetBytes("(" + sendData + ")"));
                    b = true;
                }
            }
            return b;
        }
        /// <summary>
        /// 响应结束充电请求
        /// </summary>
        /// <returns></returns>
        public bool DW0006(long cs_id, string cp_code, int cp_guncode)
        {
            string sendData = "";
            bool b = false;
            if (Config.g_tcpClientDic.ContainsKey(cp_code))
            {
                Dictionary<string, object> tcpClientDic = Config.g_tcpClientDic[cp_code];
                Listener_ChargePile_Data_AC data = (Listener_ChargePile_Data_AC)tcpClientDic["data"];
                Socket socket = (Socket)tcpClientDic["socket"];

                sendData = "[" + cp_guncode + "]";

                string checkbody = "DW0006" + sendData;
                sendData =
                    tcpClientDic["version"].ToString() +
                    data.cs_id +
                    cp_code +
                    data.gundata[cp_guncode].cb_code +
                    CRC16.GetString(checkbody) +
                    checkbody;
                socket.Send(Encoding.UTF8.GetBytes("(" + sendData + ")"));

                b = true;
            }
            return b;
        }
        /// <summary>
        /// 获取充电状态请求
        /// </summary>
        /// <returns></returns>
        public bool DW0010(string cp_code, string cb_code, long u_uname)
        {
            string sendData = "";
            bool b = false;
            if (Config.g_tcpClientDic.ContainsKey(cp_code))
            {
                Dictionary<string, object> tcpClientDic = Config.g_tcpClientDic[cp_code];
                Listener_ChargePile_Data_AC data = (Listener_ChargePile_Data_AC)tcpClientDic["data"];
                Socket socket = (Socket)tcpClientDic["socket"];

                sendData = "[" + u_uname + "]";

                string checkbody = "DW0010" + sendData;
                sendData =
                    tcpClientDic["version"].ToString() +
                    data.cs_id +
                    cp_code +
                    cb_code +
                    CRC16.GetString(checkbody) +
                    checkbody;
                socket.Send(Encoding.UTF8.GetBytes("(" + sendData + ")"));

                b = true;
            }
            return b;
        }
        
    }
}
