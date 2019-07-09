using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemFramework;

namespace Client.App_Code.Include.TCP
{
    public class IncludeTCPSend001
    {
        /// <summary>
        /// 心跳
        /// </summary>
        public void UP0001(long cs_id, int cimcondition, int pdmcondition, int semcondition, int ffmcondition)
        {
            string sendData = string.Format("[{0}][{1}][{2}][{3}][{4}]",
                                0, cimcondition, pdmcondition, semcondition, ffmcondition);
            string checkbody = "UP0001" + sendData;
            Config.g_socket.Send(Encoding.UTF8.GetBytes(
                "(001" +
                cs_id.ToString() +
                CRC16.GetString(checkbody) +
                checkbody +
                ")"));
        }
        /// <summary>
        /// 登录
        /// </summary>
        public void UP0002(string cs_uname, string cs_pwd)
        {
            string sendData = string.Format("[{0}][{1}]", cs_uname, cs_pwd);
            string checkbody = "UP0002" + sendData;
            Config.g_socket.Send(Encoding.UTF8.GetBytes(
                "(0010000000000" +
                CRC16.GetString(checkbody) +
                checkbody +
                ")"));
        }
    }
}
