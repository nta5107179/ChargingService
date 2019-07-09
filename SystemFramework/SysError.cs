using System;
using System.Collections.Generic;
using System.Web;
using CoreClass;
using System.Windows;

namespace SystemFramework
{
    /// <summary>
    /// 系统错误公共类
    /// </summary>
    public static class SysError
    {
        static Dictionary<string, string> dic = new Dictionary<string, string>();

        /// <summary>
        /// 错误提示配置
        /// </summary>
        static void SetError()
        {
            if (dic.Count <= 0)
            {
                //接口消息
                dic.Add("API000", "无系统错误！");
                dic.Add("API001", "系统错误！");
                //系统级消息
                dic.Add("SYS000", "传入数据正常！");
                dic.Add("SYS001", "系统检测到非法字符，请使用全角字符代替，以下字符为非法字符[,][']！");
                dic.Add("SYS002", "检测到必填字段，但没有提供值！");
                dic.Add("SYS003", "传入数据出错！");
                //登录消息
                dic.Add("LOGIN000", "登录成功！");
                dic.Add("LOGIN001", "服务器繁忙，请稍后再试！");
                dic.Add("LOGIN002", "参数错误，请稍后再试！");
                dic.Add("LOGIN003", "用户名或密码错误，登录失败！");
                dic.Add("LOGIN004", "帐号已过期，登录失败！");
                dic.Add("LOGIN005", "帐号未激活，请登录注册时填写的邮箱激活帐号！");
                //注册消息
                dic.Add("REGISTER000", "注册成功！");
                dic.Add("REGISTER001", "服务器繁忙，请稍后再试！");
                dic.Add("REGISTER002", "参数错误，请稍后再试！");
                dic.Add("REGISTER003", "用户名重复，注册失败！");
                dic.Add("REGISTER004", "两次输入的密码不符，注册失败！");
                dic.Add("REGISTER005", "{0}格式错误，正确的格式为{1}！");
                //找回密码
                dic.Add("LOSTPWD000", "新密码已发送至您注册时使用的邮箱！");
                dic.Add("LOSTPWD001", "服务器繁忙，请稍后再试！");
                dic.Add("LOSTPWD002", "参数错误，请稍后再试！");
                dic.Add("LOSTPWD003", "{0}格式错误，正确的格式为{1}！");
                //增、删、改等操作
                dic.Add("MANAGE000", "操作成功！");
                dic.Add("MANAGE001", "服务器繁忙，请稍后再试！");
                dic.Add("MANAGE002", "参数错误，请稍后再试！");
                dic.Add("MANAGE003", "{0}格式错误，正确的格式为{1}！");
                dic.Add("MANAGE004", "因缺少操作对象，未执行操作！");
                //查询操作
                dic.Add("SELECT000", "查询成功！");
                dic.Add("SELECT001", "没有更多数据！");
                dic.Add("SELECT002", "服务器繁忙，查询失败！");
                //发送数据
                dic.Add("SEND000", "命令发送成功！");
                dic.Add("SEND001", "命令发送失败！");
                dic.Add("SEND002", "服务器繁忙，请稍后再试！");
                dic.Add("SEND003", "参数错误，请稍后再试！");
                dic.Add("SEND004", "正在充电中，请稍后再试！");
                //连接服务器
                dic.Add("SERVERLINK000", "远程服务器连接成功！");
                dic.Add("SERVERLINK001", "远程服务器连接失败！");
                //启动服务
                dic.Add("SERVERSTAR000", "服务启动成功！");
                dic.Add("SERVERSTAR001", "服务启动失败！");
                //验证码
                dic.Add("YZM000", "验证码已发送，5分钟内有效！");
                dic.Add("YZM001", "验证码发送失败！");
                dic.Add("YZM002", "验证码正确！");
                dic.Add("YZM003", "验证码错误！");
                //充电桩相关
                dic.Add("CP001", "充电桩未连接！");
                //支付宝相关
                dic.Add("ALIPAY000", "操作成功！");
                dic.Add("ALIPAY002", "服务器繁忙，请稍后再试！");
            }
        }
        /// <summary>
        /// 获取错误代码对应的错误提示
        /// </summary>
        public static string GetErrorString(string key)
        {
            SetError();
            return dic[key];
        }
        /// <summary>
        /// 获取错误代码对应的错误提示
        /// </summary>
        public static void Error(string str)
        {
            MessageBox.Show(str, "错误", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.No);
        }
        /// <summary>
        /// 获取错误代码对应的错误提示
        /// </summary>
        public static void GetError(string key)
        {
            SetError();
            MessageBox.Show(GetErrorString(key), "错误", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.No);
        }
    }
}