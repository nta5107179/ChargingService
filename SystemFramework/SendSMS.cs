using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemFramework
{
    /// <summary>
    /// 发送短信
    /// </summary>
    public static class SendSMS
    {
        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="backstr">反馈消息</param>
        /// <param name="to">短信接收端手机号码集合，用英文逗号分开，每批发送的手机号数量不得超过100个</param>
        /// <param name="templateId">模板Id</param>
        /// <param name="data">可选字段 内容数据，用于替换模板中{序号}</param>
        /// <exception cref="ArgumentNullException">参数不能为空</exception>
        /// <exception cref="Exception"></exception>
        /// <returns></returns>
        static bool Send(ref string backstr, string to, string templateId, string[] data)
        {
            bool b = false;

            CCPRestSDK.CCPRestSDK api = new CCPRestSDK.CCPRestSDK();
            //ip格式如下，不带https://
            bool isInit = api.init("app.cloopen.com", "8883");
            api.setAccount("8a48b551544cd73f01547f619c4e3068", "1c5ac6e9ea504ba6a1924e2df83f2551");
            api.setAppId("aaf98f89544cd9d901547f6cc2a22ecd");

            try
            {
                if (isInit)
                {
                    Dictionary<string, object> retData = api.SendTemplateSMS(to, templateId, data);
                    backstr = getDictionaryData(retData);
                    b = true;
                }
                else
                {
                    backstr = "初始化失败";
                }
            }
            catch (Exception exc)
            {
                backstr = exc.Message;
            }
            return b;
        }
        static string getDictionaryData(Dictionary<string, object> data)
        {
            string ret = null;
            foreach (KeyValuePair<string, object> item in data)
            {
                if (item.Value != null && item.Value.GetType() == typeof(Dictionary<string, object>))
                {
                    ret += item.Key.ToString() + "={";
                    ret += getDictionaryData((Dictionary<string, object>)item.Value);
                    ret += "};";
                }
                else
                {
                    ret += item.Key.ToString() + "=" + (item.Value == null ? "null" : item.Value.ToString()) + ";";
                }
            }
            return ret;
        }
        /// <summary>
        /// 发送验证码
        /// </summary>
        /// <param name="backstr">反馈消息</param>
        /// <param name="to">短信接收端手机号码集合，用英文逗号分开，每批发送的手机号数量不得超过100个</param>
        /// <param name="number">验证码</param>
        /// <param name="timespan">失效时间（分钟）</param>
        /// <returns></returns>
        public static bool SendYZM(ref string backstr, string to, string number, int timespan)
        {
            bool b = Send(ref backstr, to, "84330", new string[] { number, timespan.ToString() });
            return b;
        }

    }
}
