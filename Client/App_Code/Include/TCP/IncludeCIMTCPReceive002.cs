using Client.App_Code.Include.HTTP;
using Model;
using Model.Project;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Client.App_Code.Include.TCP
{
    public class IncludeCIMTCPReceive002
    {
        AppCode m_appcode = new AppCode();
        IncludeHTTPSend m_incHTTPSend = new IncludeHTTPSend();

        /// <summary>
        /// 心跳
        /// </summary>
        /// <returns></returns>
        public string UP0001(string cp_code, string cb_code, string bodyData)
        {
            string sendData = "";
            Dictionary<string, object> tcpClientDic = Config.g_cimTcpClientDic[cp_code];
            Client_ChargePile_Data_AC data = (Client_ChargePile_Data_AC)tcpClientDic["data"];

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

            if (int.Parse(UP_1) > 0)
            {
                data.gundata[int.Parse(UP_1)].cb_code = cb_code;
                data.gundata[int.Parse(UP_1)].guncode = int.Parse(UP_1);
                data.gundata[int.Parse(UP_1)].uab = double.Parse(UP_2[0]);
                data.gundata[int.Parse(UP_1)].ubc = double.Parse(UP_2[1]);
                data.gundata[int.Parse(UP_1)].uca = double.Parse(UP_2[2]);
                data.gundata[int.Parse(UP_1)].ia = double.Parse(UP_3[0]);
                data.gundata[int.Parse(UP_1)].ib = double.Parse(UP_3[1]);
                data.gundata[int.Parse(UP_1)].ic = double.Parse(UP_3[2]);
                data.gundata[int.Parse(UP_1)].pw = double.Parse(UP_4);
                data.gundata[int.Parse(UP_1)].qw = double.Parse(UP_5);
                data.gundata[int.Parse(UP_1)].cos = double.Parse(UP_6);
                data.gundata[int.Parse(UP_1)].kwh = double.Parse(UP_7);
                data.gundata[int.Parse(UP_1)].timeleft = TimeSpan.FromSeconds(double.Parse(UP_8));
            }

            //更新充电桩状态
            data.condition = GetCondition(data);

            return sendData;
        }
        /// <summary>
        /// 报警
        /// </summary>
        /// <returns></returns>
        public string UP0003(string cp_code, string bodyData)
        {
            string sendData = "";
            Dictionary<string, object> tcpClientDic = Config.g_cimTcpClientDic[cp_code];
            Client_ChargePile_Data_AC data = (Client_ChargePile_Data_AC)tcpClientDic["data"];
            ObservableCollection<Client_ChargePile_GunData_AC> gunDataList = data.gundata;

            MatchCollection arr = Regex.Matches(bodyData, @"(?<=\[)[^\]]*(?=\])");
            string UP_0 = arr[0].Value;//枪编号
            string UP_1 = arr[1].Value;//报警码

            //更新充电桩报警状态
            if (int.Parse(UP_1) != 255)
            {
                data.gundata[int.Parse(UP_0)].ispolice = true;
                data.gundata[int.Parse(UP_0)].police = Config.g_police[int.Parse(UP_1)];
                data.gundata[int.Parse(UP_0)].policecode = int.Parse(UP_1);
            }
            else
            {
                /*data.ispolice = false;
                data.gundata[int.Parse(UP_0)].ispolice = false;
                data.gundata[int.Parse(UP_0)].police = "";
                data.gundata[int.Parse(UP_0)].policecode = 0;*/
            }
            bool b = false;
            for (int i = 1; i < data.gundata.Count; i++)
            {
                if ((bool)data.gundata[int.Parse(UP_0)].ispolice)
                {
                    b = true;
                    break;
                }
            }
            data.ispolice = b;

            return sendData;
        }
        /// <summary>
        /// 设置断线
        /// </summary>
        /// <returns></returns>
        public string UP0004(string cp_code, string bodyData)
        {
            string sendData = "";
            Dictionary<string, object> tcpClientDic = Config.g_cimTcpClientDic[cp_code];
            Client_ChargePile_Data_AC data = (Client_ChargePile_Data_AC)tcpClientDic["data"];

            //更新充电桩状态
            data.condition = 0;
            //更新枪状态
            for (int i = 1; i < data.gundata.Count; i++)
            {
                data.gundata[i].guncondition = false;
            }

            return sendData;
        }
        /// <summary>
        /// 结束充电命令
        /// </summary>
        /// <returns></returns>
        public string UP0009(string cp_code, string bodyData)
        {
            string sendData = "";
            Dictionary<string, object> tcpClientDic = Config.g_cimTcpClientDic[cp_code];
            Client_ChargePile_Data_AC data = (Client_ChargePile_Data_AC)tcpClientDic["data"];

            MatchCollection arr = Regex.Matches(bodyData, @"(?<=\[)[^\]]*(?=\])");
            string UP_0 = arr[0].Value;//枪编号
            string UP_1 = arr[1].Value;//用户名
            string UP_2 = arr[2].Value;//已充电量
            string UP_3 = arr[3].Value;//充电开始时间

            //更新枪状态
            data.gundata[int.Parse(UP_0)].guncondition = false;
            //更新充电桩状态
            data.condition = GetCondition(data);

            return sendData;
        }
        /// <summary>
        /// 响应获取充电状态请求
        /// </summary>
        /// <returns></returns>
        public string UP0010(string cp_code, string bodyData)
        {
            string sendData = "";
            Dictionary<string, object> tcpClientDic = Config.g_cimTcpClientDic[cp_code];
            Client_ChargePile_Data_AC data = (Client_ChargePile_Data_AC)tcpClientDic["data"];

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
                //更新枪状态
                data.gundata[int.Parse(UP_0)].useruname = long.Parse(UP_1);
                data.gundata[int.Parse(UP_0)].kwh = double.Parse(UP_2);
                data.gundata[int.Parse(UP_0)].timeleft = TimeSpan.FromSeconds(double.Parse(UP_3));
                data.unitmoney = decimal.Parse(UP_4);
                data.gundata[int.Parse(UP_0)].chargemod = int.Parse(UP_5);
                data.gundata[int.Parse(UP_0)].chargemodcontent = long.Parse(UP_6);
                data.gundata[int.Parse(UP_0)].guncondition = true;
                //更新充电桩状态
                data.condition = GetCondition(data);
            }

            return sendData;
        }

        /// <summary>
        /// 获取充电桩充电状态
        /// </summary>
        /// <returns></returns>
        int GetCondition(Client_ChargePile_Data_AC data)
        {
            int condition = 1;
            bool?[] bArr = data.gundata.Select(a => a.guncondition).ToArray();
            for (int i = 0; i < bArr.Length; i++)
            {
                if ((bool)bArr[i])
                {
                    condition = 2;
                    break;
                }
            }
            return condition;
        }
        
    }
}
