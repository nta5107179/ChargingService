using Listener.App_Code.Include.TCP;
using Model;
using Model.Project;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Threading;
using SystemFramework;

namespace Listener.App_Code.Include.HTTP
{
    public class IncludeHTTPReceive
    {
        AppCode m_appcode = new AppCode();
        IncludeUser m_incUser = new IncludeUser();
        IncludeChargePile m_incChargePile = new IncludeChargePile();
        IncludeIdCard m_incIdCard = new IncludeIdCard();
        IncludeChargeBattery m_incChargeBattery = new IncludeChargeBattery();
        IncludeAMCIMData m_incAMCIMData = new IncludeAMCIMData();
        IncludeAMCIMPolice m_incAMCIMPolice = new IncludeAMCIMPolice();
        IncludeChargeStation m_incChargeStation = new IncludeChargeStation();
        IncludeTCPReceive002 m_incTCPReceive002 = new IncludeTCPReceive002();
        IncludeTCPReceive003 m_incTCPReceive003 = new IncludeTCPReceive003();
        IncludeTCPSend002 m_incTCPSend002 = new IncludeTCPSend002();
        IncludeTCPSend003 m_incTCPSend003 = new IncludeTCPSend003();

        #region 充电站与服务器
        /// <summary>
        /// 获取充电桩列表
        /// </summary>
        /// <returns></returns>
        public string UP0001(long cs_id)
        {
            string outputData = "";
            List<Models> list = m_incChargePile.GetChargePileList(cs_id);
            outputData = Convert.ToBase64String(m_appcode.OpMemory.Serialize(list));
            return outputData;
        }
        /// <summary>
        /// 获取电池
        /// </summary>
        /// <returns></returns>
        public string UP0003(string cb_code)
        {
            string outputData = "";
            List<G_ChargeBattery> list = m_incChargeBattery.GetChargeBattery(cb_code);
            if (list.Count <= 0)
            {
                G_ChargeBattery mod = new G_ChargeBattery();
                mod.cb_code = cb_code;
                m_incChargeBattery.AddChargeBattery(mod);
                list = m_incChargeBattery.GetChargeBattery(cb_code);
            }
            outputData = Convert.ToBase64String(m_appcode.OpMemory.Serialize(list));
            return outputData;
        }
        /// <summary>
        /// 获取充电桩
        /// </summary>
        /// <returns></returns>
        public string UP0004(long cs_id, long cp_id)
        {
            string outputData = "";
            List<G_ChargePile> list = m_incChargePile.GetChargePile(cs_id, cp_id);
            outputData = Convert.ToBase64String(m_appcode.OpMemory.Serialize(list));
            return outputData;
        }
        /// <summary>
        /// 结束充电
        /// </summary>
        /// <returns></returns>
        public string UP0005(long cs_id, string cp_code, int cp_guncode)
        {
            Dictionary<string, object> tcpClientDic = Config.g_tcpClientDic[cp_code];

            string outputData = "False";
            try
            {
                int chargemod = (int)tcpClientDic["chargemod"];
                switch (chargemod)
                {
                    case 1:
                        {
                            m_incTCPSend002.DW0006(cs_id, cp_code, cp_guncode);
                        }
                        break;
                    case 2:
                        {
                            m_incTCPSend003.DW0006(cs_id, cp_code, cp_guncode);
                        }
                        break;
                    default:
                        throw new Exception();
                }
                outputData = "True";
            }
            catch (Exception e) { }
            return outputData;
        }
        /// <summary>
        /// 获取充电桩
        /// </summary>
        /// <returns></returns>
        public string UP0006(long cs_id, long cp_id, bool am_cimp_examine)
        {
            string outputData = "";
            List<AM_CIMPolice> list = m_incAMCIMPolice.GetAMCIMPoliceList(cs_id, cp_id, am_cimp_examine);
            outputData = Convert.ToBase64String(m_appcode.OpMemory.Serialize(list));
            return outputData;
        }/// <summary>
        /// 处理充电桩报警数据
        /// </summary>
        /// <returns></returns>
        public string UP0007(long cs_id, long cp_id, long am_cimp_id, bool am_cimp_examine)
        {
            string outputData = "";
            AM_CIMPolice mod = new AM_CIMPolice();
            mod.cs_id = cs_id;
            mod.cp_id = cp_id;
            mod.am_cimp_id = am_cimp_id;
            AM_CIMPolice mod2 = new AM_CIMPolice();
            mod2.am_cimp_examine = am_cimp_examine;
            outputData = m_incAMCIMPolice.EditAMCIMPolice(mod, mod2).ToString();
            return outputData;
        }
        #endregion

        #region 管理系统与服务器
        /// <summary>
        /// 添加充电站后更新充电站数据
        /// </summary>
        /// <returns></returns>
        public string WEB0001(long cs_id, Dispatcher dispatcher)
        {
            string outputData = "";
            try
            {
                List<Models> list = m_incChargeStation.GetChargeStation(cs_id);
                for (int i = 0; i < list.Count; i++)
                {
                    Listener_ChargeStation_Data mod = new Listener_ChargeStation_Data();
                    mod.name = list[i].G_ChargeStation.cs_name;
                    mod.csid = (long)list[i].G_ChargeStation.cs_id;
                    mod.pid = list[i].G_Province.p_id;
                    mod.cid = list[i].G_City.c_id;
                    mod.did = list[i].G_District.d_id;
                    mod.place = list[i].G_Province.p_name + list[i].G_City.c_name + list[i].G_District.d_name;
                    mod.cpsum_ac = "0";
                    mod.cpsum_dc = "0";
                    dispatcher.Invoke(new Action(delegate()
                    {
                        Config.g_dataList.Add(mod);
                    }));
                }
                outputData = "<error name=\"API000\">" + SysError.GetErrorString("API000") + "</error>" +
                    "<callback name=\"SYS000\">" + SysError.GetErrorString("SYS000") + "</callback>" +
                    "<condition name=\"MANAGE000\">" + SysError.GetErrorString("MANAGE000") + "</condition>";
            }
            catch (Exception e)
            {
                outputData = "<error name=\"API001\">" + SysError.GetErrorString("API001") + "</error>" +
                    "<callback name=\"SYS003\">" + SysError.GetErrorString("SYS003") + "</callback>" +
                    "<condition name=\"MANAGE001\">" + e.Message + "</condition>" +
                    "<exception>" + e.Message + "</exception>";
            }
            outputData = "<root>" + outputData + "</root>";
            return outputData;
        }
        /// <summary>
        /// 修改充电站后更新充电站数据
        /// </summary>
        /// <returns></returns>
        public string WEB0002(long cs_id)
        {
            string outputData = "";
            try
            {
                List<Models> list = m_incChargeStation.GetChargeStation(cs_id);
                for (int i = 0; i < list.Count; i++)
                {
                    Listener_ChargeStation_Data mod = GetChargeStation(cs_id);
                    mod.name = list[i].G_ChargeStation.cs_name;
                    mod.csid = (long)list[i].G_ChargeStation.cs_id;
                    mod.pid = list[i].G_Province.p_id;
                    mod.cid = list[i].G_City.c_id;
                    mod.did = list[i].G_District.d_id;
                    mod.place = list[i].G_Province.p_name + list[i].G_City.c_name + list[i].G_District.d_name;
                }
                outputData = "<error name=\"API000\">" + SysError.GetErrorString("API000") + "</error>" +
                    "<callback name=\"SYS000\">" + SysError.GetErrorString("SYS000") + "</callback>" +
                    "<condition name=\"MANAGE000\">" + SysError.GetErrorString("MANAGE000") + "</condition>";
            }
            catch (Exception e)
            {
                outputData = "<error name=\"API001\">" + SysError.GetErrorString("API001") + "</error>" +
                    "<callback name=\"SYS003\">" + SysError.GetErrorString("SYS003") + "</callback>" +
                    "<condition name=\"MANAGE001\">" + e.Message + "</condition>" +
                    "<exception>" + e.Message + "</exception>";
            }
            outputData = "<root>" + outputData + "</root>";
            return outputData;
        }
        /// <summary>
        /// 获取单条充电站数据
        /// </summary>
        Listener_ChargeStation_Data GetChargeStation(long cs_id)
        {
            Listener_ChargeStation_Data mod = null;
            for (int i = 0; i < Config.g_dataList.Count; i++)
            {
                if (Config.g_dataList[i].csid == cs_id)
                {
                    mod = Config.g_dataList[i];
                    break;
                }
            }
            return mod;
        } 
        #endregion

        #region APP与服务器
        /// <summary>
        /// 发送充电请求
        /// </summary>
        /// <returns></returns>
        public string APP0001(long cs_id, string cp_code, long u_uname, long u_id, int cp_guncode, int calmod, string cal)
        {
            string outputData = "";
            outputData = "<error name=\"API000\">" + SysError.GetErrorString("API000") + "</error>" +
                "<callback name=\"SYS000\">" + SysError.GetErrorString("SYS000") + "</callback>" +
                "<condition name=\"SEND002\">" + SysError.GetErrorString("SEND002") + "</condition>";
            try
            {
                Dictionary<string, object> tcpClientDic = Config.g_tcpClientDic[cp_code];
                if (Config.g_tcpClientDic.ContainsKey(cp_code))
                {
                    int chargemod = (int)tcpClientDic["chargemod"];
                    bool b = false;
                    switch (chargemod)
                    {
                        case 1:
                            {
                                Listener_ChargePile_Data_AC data = (Listener_ChargePile_Data_AC)tcpClientDic["data"];
                                if (!(bool)data.gundata[cp_guncode].guncondition)
                                    b = true;
                            }
                            break;
                        case 2:
                            {
                                Listener_ChargePile_Data_DC data = (Listener_ChargePile_Data_DC)tcpClientDic["data"];
                                if (!(bool)data.gundata[cp_guncode].guncondition)
                                    b = true;
                            }
                            break;
                    }
                    if (b)
                    {
                        bool b2 = false;
                        string version = tcpClientDic["version"].ToString();
                        switch (version)
                        {
                            case "002":
                                {
                                    b2 = m_incTCPSend002.DW0002(cs_id, cp_code, u_uname, u_id, cp_guncode, calmod, cal);
                                }
                                break;
                            case "003":
                                {
                                    b2 = m_incTCPSend003.DW0002(cs_id, cp_code, u_uname, u_id, cp_guncode, calmod, cal);
                                }
                                break;
                            default:
                                throw new Exception();
                        }
                        if (b2)
                        {
                            outputData = "<error name=\"API000\">" + SysError.GetErrorString("API000") + "</error>" +
                            "<callback name=\"SYS000\">" + SysError.GetErrorString("SYS000") + "</callback>" +
                            "<condition name=\"SEND000\">" + SysError.GetErrorString("SEND000") + "</condition>";
                        }
                    }
                    else
                    {
                        outputData = "<error name=\"API000\">" + SysError.GetErrorString("API000") + "</error>" +
                            "<callback name=\"SYS000\">" + SysError.GetErrorString("SYS000") + "</callback>" +
                            "<condition name=\"SEND004\">" + SysError.GetErrorString("SEND004") + "</condition>";
                    }
                }
            }
            catch (Exception e)
            {
                outputData = "<error name=\"API001\">" + SysError.GetErrorString("API001") + "</error>" +
                    "<callback name=\"SYS003\">" + SysError.GetErrorString("SYS003") + "</callback>" +
                    "<condition name=\"SEND002\">" + SysError.GetErrorString("SEND002") + "</condition>" +
                    "<exception>" + e.Message + "</exception>";
            }
            outputData = "<root>" + outputData + "</root>";
            return outputData;
        }
        /// <summary>
        /// 获取充电桩充电数据
        /// </summary>
        /// <returns></returns>
        public string APP0002(string cp_code, int cp_guncode, long u_uname)
        {
            string outputData = "";
            outputData = "<error name=\"API000\">" + SysError.GetErrorString("API000") + "</error>" +
                "<callback name=\"SYS000\">" + SysError.GetErrorString("SYS000") + "</callback>" +
                "<condition name=\"CP001\">" + SysError.GetErrorString("CP001") + "</condition>";
            if (Config.g_tcpClientDic.ContainsKey(cp_code))
            {
                try
                {
                    Dictionary<string, object> tcpClientDic = Config.g_tcpClientDic[cp_code];
                    if (tcpClientDic.ContainsKey("chargemod") && tcpClientDic.ContainsKey("data"))
                    {
                        int chargemod = (int)tcpClientDic["chargemod"];
                        switch (chargemod)
                        {
                            case 1:
                                {
                                    Listener_ChargePile_Data_AC data = (Listener_ChargePile_Data_AC)tcpClientDic["data"];
                                    outputData = "<error name=\"API000\">" + SysError.GetErrorString("API000") + "</error>" +
                                        "<callback name=\"SYS000\">" + SysError.GetErrorString("SYS000") + "</callback>" +
                                        "<condition name=\"SELECT000\">" + SysError.GetErrorString("SELECT000") + "</condition>" +
                                        "<list>" +
                                            "<timeleft>" + ((TimeSpan)data.gundata[cp_guncode].timeleft).TotalMilliseconds.ToString() + "</timeleft>" +
                                            "<money>" + (Convert.ToDouble(data.unitmoney) * (double)data.gundata[cp_guncode].kwh).ToString("0.00") + "</money>" +
                                            "<kwh>" + data.gundata[cp_guncode].kwh + "</kwh>" +
                                            "<chargemod>" + data.gundata[cp_guncode].chargemod + "</chargemod>" +
                                            "<chargemodcontent>" + data.gundata[cp_guncode].chargemodcontent + "</chargemodcontent>" +
                                        "</list>";
                                }
                                break;
                            case 2:
                                {
                                    Listener_ChargePile_Data_DC data = (Listener_ChargePile_Data_DC)tcpClientDic["data"];
                                    outputData = "<error name=\"API000\">" + SysError.GetErrorString("API000") + "</error>" +
                                        "<callback name=\"SYS000\">" + SysError.GetErrorString("SYS000") + "</callback>" +
                                        "<condition name=\"SELECT000\">" + SysError.GetErrorString("SELECT000") + "</condition>" +
                                        "<list>" +
                                            "<timeleft>" + ((TimeSpan)data.gundata[cp_guncode].timeleft).TotalMilliseconds.ToString() + "</timeleft>" +
                                            "<money>" + (Convert.ToDouble(data.unitmoney) * (double)data.gundata[cp_guncode].kwh).ToString("0.00") + "</money>" +
                                            "<kwh>" + data.gundata[cp_guncode].kwh + "</kwh>" +
                                            "<chargemod>" + data.gundata[cp_guncode].chargemod + "</chargemod>" +
                                            "<chargemodcontent>" + data.gundata[cp_guncode].chargemodcontent + "</chargemodcontent>" +
                                        "</list>";
                                }
                                break;
                        }

                    }
                }
                catch (Exception e)
                {
                    outputData = "<error name=\"API001\">" + SysError.GetErrorString("API001") + "</error>" +
                        "<callback name=\"SYS003\">" + SysError.GetErrorString("SYS003") + "</callback>" +
                        "<condition name=\"SELECT002\">" + SysError.GetErrorString("SELECT002") + "</condition>" +
                        "<exception>" + e.Message + "</exception>";
                }
            }
            outputData = "<root>" + outputData + "</root>";
            return outputData;
        }
        /// <summary>
        /// 获取充电桩枪状态
        /// </summary>
        /// <returns></returns>
        public string APP0003(string cp_code, long u_uname)
        {
            string outputData = "";
            outputData = "<error name=\"API000\">" + SysError.GetErrorString("API000") + "</error>" +
                "<callback name=\"SYS000\">" + SysError.GetErrorString("SYS000") + "</callback>" +
                "<condition name=\"CP001\">" + SysError.GetErrorString("CP001") + "</condition>";
            if (Config.g_tcpClientDic.ContainsKey(cp_code))
            {
                try
                {
                    Dictionary<string, object> tcpClientDic = Config.g_tcpClientDic[cp_code];
                    if (tcpClientDic.ContainsKey("chargemod") && tcpClientDic.ContainsKey("data"))
                    {
                        int chargemod = (int)tcpClientDic["chargemod"];
                        switch (chargemod)
                        {
                            case 1:
                                {
                                    Listener_ChargePile_Data_AC data = (Listener_ChargePile_Data_AC)tcpClientDic["data"];
                                    List<bool?> guncondition = data.gundata.Select(a => a.guncondition).ToList();
                                    guncondition.RemoveAt(0);
                                    outputData = "<error name=\"API000\">" + SysError.GetErrorString("API000") + "</error>" +
                                        "<callback name=\"SYS000\">" + SysError.GetErrorString("SYS000") + "</callback>" +
                                        "<condition name=\"SELECT000\">" + SysError.GetErrorString("SELECT000") + "</condition>" +
                                        "<list>" +
                                            "<guncondition>" + string.Join("|", guncondition) + "</guncondition>" +
                                        "</list>";
                                }
                                break;
                            case 2:
                                {
                                    Listener_ChargePile_Data_DC data = (Listener_ChargePile_Data_DC)tcpClientDic["data"];
                                    List<bool?> guncondition = data.gundata.Select(a => a.guncondition).ToList();
                                    guncondition.RemoveAt(0);
                                    outputData = "<error name=\"API000\">" + SysError.GetErrorString("API000") + "</error>" +
                                        "<callback name=\"SYS000\">" + SysError.GetErrorString("SYS000") + "</callback>" +
                                        "<condition name=\"SELECT000\">" + SysError.GetErrorString("SELECT000") + "</condition>" +
                                        "<list>" +
                                            "<guncondition>" + string.Join("|", guncondition) + "</guncondition>" +
                                        "</list>";
                                }
                                break;
                        }

                    }
                }
                catch (Exception e)
                {
                    outputData = "<error name=\"API001\">" + SysError.GetErrorString("API001") + "</error>" +
                        "<callback name=\"SYS003\">" + SysError.GetErrorString("SYS003") + "</callback>" +
                        "<condition name=\"SELECT002\">" + SysError.GetErrorString("SELECT002") + "</condition>" +
                        "<exception>" + e.Message + "</exception>";
                }
            }
            outputData = "<root>" + outputData + "</root>";
            return outputData;
        }
        /// <summary>
        /// 发送结束充电请求
        /// </summary>
        /// <returns></returns>
        public string APP0004(long cs_id, string cp_code, long u_uname, long u_id, int cp_guncode)
        {
            Dictionary<string, object> tcpClientDic = Config.g_tcpClientDic[cp_code];

            string outputData = "";
            outputData = "<error name=\"API000\">" + SysError.GetErrorString("API000") + "</error>" +
                "<callback name=\"SYS000\">" + SysError.GetErrorString("SYS000") + "</callback>" +
                "<condition name=\"SEND002\">" + SysError.GetErrorString("SEND002") + "</condition>";
            try
            {
                string version = tcpClientDic["version"].ToString();
                switch (version)
                {
                    case "002":
                        {
                            m_incTCPSend002.DW0006(cs_id, cp_code, cp_guncode);
                        }
                        break;
                    case "003":
                        {
                            m_incTCPSend003.DW0006(cs_id, cp_code, cp_guncode);
                        }
                        break;
                    default:
                        throw new Exception();
                }
                outputData = "<error name=\"API000\">" + SysError.GetErrorString("API000") + "</error>" +
                "<callback name=\"SYS000\">" + SysError.GetErrorString("SYS000") + "</callback>" +
                "<condition name=\"SEND000\">" + SysError.GetErrorString("SEND000") + "</condition>";
            }
            catch (Exception e)
            {
                outputData = "<error name=\"API001\">" + SysError.GetErrorString("API001") + "</error>" +
                    "<callback name=\"SYS003\">" + SysError.GetErrorString("SYS003") + "</callback>" +
                    "<condition name=\"SEND002\">" + SysError.GetErrorString("SEND002") + "</condition>" +
                    "<exception>" + e.Message + "</exception>";
            }
            outputData = "<root>" + outputData + "</root>";
            return outputData;
        }
        /// <summary>
        /// 获取用户充电状态
        /// </summary>
        /// <returns></returns>
        public string APP0005(long u_uname, long u_id)
        {
            string outputData = "";
            outputData = "<error name=\"API000\">" + SysError.GetErrorString("API000") + "</error>" +
                "<callback name=\"SYS000\">" + SysError.GetErrorString("SYS000") + "</callback>" +
                "<condition name=\"SELECT001\">" + SysError.GetErrorString("SELECT001") + "</condition>";
            Dictionary<string, Dictionary<string, object>> mdic = null;
            try
            {
                lock (Config.g_tcpClientDic)
                {
                    //深拷贝
                    mdic = new Dictionary<string, Dictionary<string, object>>(Config.g_tcpClientDic);
                }
                if (mdic != null)
                {
                    List<long> list = new List<long>();
                    string cs_id = null, cp_code = null, cp_guncode = null;
                    bool cp_guncondition = false;
                    foreach (Dictionary<string, object> dic in mdic.Values)
                    {
                        int chargemod = (int)dic["chargemod"];
                        switch (chargemod)
                        {
                            case 1:
                                {
                                    //交流
                                    Listener_ChargePile_Data_AC cp = (Listener_ChargePile_Data_AC)dic["data"];
                                    List<long?> list2 = cp.gundata.Select(a => a.useruname).ToList();
                                    if (cp.gundata.Select(a => a.useruname).ToArray().Contains(u_uname) &&
                                        (bool)cp.gundata.Select(a => a.guncondition).ToArray()[Array.IndexOf(cp.gundata.Select(a => a.useruname).ToArray(), u_uname)])
                                    {
                                        cs_id = cp.cs_id.ToString();
                                        cp_code = cp.cp_code;
                                        cp_guncode = Array.IndexOf(cp.gundata.Select(a => a.useruname).ToArray(), u_uname).ToString();
                                        cp_guncondition = (bool)cp.gundata.Select(a => a.guncondition).ToArray()[int.Parse(cp_guncode)];
                                        break;
                                    }
                                }
                                break;
                            case 2:
                                {
                                    //直流
                                    Listener_ChargePile_Data_DC cp = (Listener_ChargePile_Data_DC)dic["data"];
                                    if (cp.gundata.Select(a => a.useruname).ToArray().Contains(u_uname) &&
                                        (bool)cp.gundata.Select(a => a.guncondition).ToArray()[Array.IndexOf(cp.gundata.Select(a => a.useruname).ToArray(), u_uname)])
                                    {
                                        cs_id = cp.cs_id.ToString();
                                        cp_code = cp.cp_code;
                                        cp_guncode = Array.IndexOf(cp.gundata.Select(a => a.useruname).ToArray(), u_uname).ToString();
                                        cp_guncondition = (bool)cp.gundata.Select(a => a.guncondition).ToArray()[int.Parse(cp_guncode)];
                                        break;
                                    }
                                }
                                break;
                        }
                    }
                    if (cp_guncondition && cs_id != null && cp_code != null && cp_guncode != null)
                    {
                        outputData = "<error name=\"API000\">" + SysError.GetErrorString("API000") + "</error>" +
                        "<callback name=\"SYS000\">" + SysError.GetErrorString("SYS000") + "</callback>" +
                        "<condition name=\"SELECT000\">" + SysError.GetErrorString("SELECT000") + "</condition>"+
                        "<list>"+
                            "<cs_id>" + cs_id + "</cs_id>" +
                            "<cp_code>" + cp_code + "</cp_code>" +
                            "<cp_guncode>" + cp_guncode + "</cp_guncode>" +
                        "</list>";
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                string dic = "";
                if (mdic != null)
                {
                    foreach (string key in mdic.Keys)
                    {
                        dic += key + "|";
                    }
                }
                outputData = "<error name=\"API001\">" + SysError.GetErrorString("API001") + "</error>" +
                    "<callback name=\"SYS003\">" + SysError.GetErrorString("SYS003") + "</callback>" +
                    "<condition name=\"SELECT002\">" + SysError.GetErrorString("SELECT002") + "</condition>" +
                    "<exception>" + e.Message + e.StackTrace + "</exception>" +
                    "<dic>" + dic + "</dic>";
            }
            outputData = "<root>" + outputData + "</root>";
            return outputData;
        }
        /// <summary>
        /// 发送充电枪控制命令
        /// </summary>
        /// <returns></returns>
        public string APP0006(string cp_code, int cp_guncode, string condition)
        {
            Dictionary<string, object> tcpClientDic = Config.g_tcpClientDic[cp_code];

            string outputData = "";
            outputData = "<error name=\"API000\">" + SysError.GetErrorString("API000") + "</error>" +
                "<callback name=\"SYS000\">" + SysError.GetErrorString("SYS000") + "</callback>" +
                "<condition name=\"SEND002\">" + SysError.GetErrorString("SEND002") + "</condition>";
            try
            {
                if (m_incTCPSend003.DW0013(cp_code, cp_guncode, condition))
                {
                    outputData = "<error name=\"API000\">" + SysError.GetErrorString("API000") + "</error>" +
                        "<callback name=\"SYS000\">" + SysError.GetErrorString("SYS000") + "</callback>" +
                        "<condition name=\"SEND000\">" + SysError.GetErrorString("SEND000") + "</condition>";
                }
            }
            catch (Exception e)
            {
                outputData = "<error name=\"API001\">" + SysError.GetErrorString("API001") + "</error>" +
                    "<callback name=\"SYS003\">" + SysError.GetErrorString("SYS003") + "</callback>" +
                    "<condition name=\"SEND002\">" + SysError.GetErrorString("SEND002") + "</condition>" +
                    "<exception>" + e.Message + "</exception>";
            }
            outputData = "<root>" + outputData + "</root>";
            return outputData;
        }
        #endregion

    }
}
