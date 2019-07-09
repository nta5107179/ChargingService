using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Client.App_Code.Include.TCP
{
    public class IncludeTCPReceive001
    {
        /// <summary>
        /// 响应心跳
        /// </summary>
        public bool DW0001(string bodyData)
        {
            bool b = false;
            MatchCollection arr = Regex.Matches(bodyData, @"(?<=\[)[^\]]*(?=\])");
            string UP_0 = arr[0].Value;//是否正常
            b = true;
            return b;
        }
        /// <summary>
        /// 响应登录
        /// </summary>
        public bool DW0002(string bodyData, ref string code)
        {
            bool b = false;
            //功能请求
            MatchCollection arr = Regex.Matches(bodyData, @"(?<=\[)[^\]]*(?=\])");
            //登录
            string UP_0 = arr[0].Value;//是否成功
            string UP_1 = arr[1].Value;//成功或失败码
            if (UP_0 == "1")
            {
                b = true;
            }
            code = UP_1;
            return b;
        }
    }
}
