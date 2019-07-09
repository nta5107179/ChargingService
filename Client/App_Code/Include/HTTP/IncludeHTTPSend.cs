using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Client.App_Code.Include.HTTP
{
    public class IncludeHTTPSend
    {
        AppCode m_appcode = new AppCode();

        /// <summary>
        /// 获取充电桩列表
        /// </summary>
        /// <returns></returns>
        public List<Models> UP001(long cs_id)
        {
            List<Models> list = new List<Models>();
            HttpWebRequest hwr = (HttpWebRequest)WebRequest.Create(Config.g_httpUrl +
                string.Format("?type=UP0001&cs_id={0}", cs_id));
            hwr.Method = "get";
            WebResponse wr = hwr.GetResponse();
            using (StreamReader sr = new StreamReader(wr.GetResponseStream()))
            {
                list = m_appcode.OpMemory.Deserialize(Convert.FromBase64String(sr.ReadToEnd()));
            }
            wr.Close();
            return list;
        }
        /// <summary>
        /// 获取ic卡
        /// </summary>
        /// <returns></returns>
        public List<Models> UP002(long pay_ic_id)
        {
            List<Models> list = new List<Models>();
            HttpWebRequest hwr = (HttpWebRequest)WebRequest.Create(Config.g_httpUrl + 
                string.Format("?type=UP0002&pay_ic_id={0}", pay_ic_id));
            hwr.Method = "get";
            WebResponse wr = hwr.GetResponse();
            using (StreamReader sr = new StreamReader(wr.GetResponseStream()))
            {
                list = m_appcode.OpMemory.Deserialize(Convert.FromBase64String(sr.ReadToEnd()));
            }
            wr.Close();
            return list;
        }
        /// <summary>
        /// 获取电池
        /// </summary>
        /// <returns></returns>
        public List<G_ChargeBattery> UP003(string cb_code)
        {
            List<G_ChargeBattery> list = new List<G_ChargeBattery>();
            HttpWebRequest hwr = (HttpWebRequest)WebRequest.Create(Config.g_httpUrl + 
                string.Format("?type=UP0003&cb_code={0}", cb_code));
            hwr.Method = "get";
            WebResponse wr = hwr.GetResponse();
            using (StreamReader sr = new StreamReader(wr.GetResponseStream()))
            {
                list = m_appcode.OpMemory.Deserialize(Convert.FromBase64String(sr.ReadToEnd()));
            }
            wr.Close();
            return list;
        }
        /// <summary>
        /// 获取充电桩
        /// </summary>
        /// <returns></returns>
        public List<G_ChargePile> UP004(long cs_id, long cp_id)
        {
            List<G_ChargePile> list = new List<G_ChargePile>();
            HttpWebRequest hwr = (HttpWebRequest)WebRequest.Create(Config.g_httpUrl +
                string.Format("?type=UP0004&cs_id={0}&cp_id={1}", cs_id, cp_id));
            hwr.Method = "get";
            WebResponse wr = hwr.GetResponse();
            using (StreamReader sr = new StreamReader(wr.GetResponseStream()))
            {
                list = m_appcode.OpMemory.Deserialize(Convert.FromBase64String(sr.ReadToEnd()));
            }
            wr.Close();
            return list;
        }
        /// <summary>
        /// 单次充电结束
        /// </summary>
        public bool UP005(AM_CIMData mod)
        {
            bool b = false;
            List<PAY_IdCard> list = new List<PAY_IdCard>();
            HttpWebRequest hwr = (HttpWebRequest)WebRequest.Create(Config.g_httpUrl +
                string.Format("?type=UP0005"));
            hwr.Method = "post";
            using (StreamWriter sw = new StreamWriter(hwr.GetRequestStream()))
            {
                sw.Write(Convert.ToBase64String(m_appcode.OpMemory.Serialize(mod)));
            }
            WebResponse wr = hwr.GetResponse();
            using (StreamReader sr = new StreamReader(wr.GetResponseStream()))
            {
                b = bool.Parse(sr.ReadToEnd());
            }
            wr.Close();
            return b;
        }
        /// <summary>
        /// 获取充电桩报警数据列表
        /// </summary>
        /// <returns></returns>
        public List<AM_CIMPolice> UP006(long cs_id, long cp_id, bool am_cimp_examine)
        {
            List<AM_CIMPolice> list = new List<AM_CIMPolice>();
            HttpWebRequest hwr = (HttpWebRequest)WebRequest.Create(Config.g_httpUrl +
                string.Format("?type=UP0006&cs_id={0}&cp_id={1}&am_cimp_examine={2}", cs_id, cp_id, am_cimp_examine));
            hwr.Method = "get";
            WebResponse wr = hwr.GetResponse();
            using (StreamReader sr = new StreamReader(wr.GetResponseStream()))
            {
                list = m_appcode.OpMemory.Deserialize(Convert.FromBase64String(sr.ReadToEnd()));
            }
            wr.Close();
            return list;
        }
    }
}
