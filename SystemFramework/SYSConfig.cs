using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemFramework
{
    public static class SYSConfig
    {
        /// <summary>
        /// 设备报警
        /// </summary>
        public static string[] g_police = new string[]
        {
            "未知错误",
            "过压",
            "过流",
            "欠压",
            "与汽车通信中断",
            "接地不良",
            "急停开关按下",
            "桩断电"
        };
    }
}
