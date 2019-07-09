using System;
using System.Collections.Generic;
using System.Web;
using System.Xml;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using CoreClass;
using System.Data;
using System.Collections.ObjectModel;
using Model.Project;

namespace Client.App_Code
{
    /// <summary>
    /// 全局配置静态类
    /// </summary>
    public static class Config
    {
        #region 静态配置变量
        /// <summary>
        /// 应用名
        /// </summary>
        public static string g_title = "充电桩电子管理系统";
        /// <summary>
        /// 版本
        /// </summary>
        public static string g_version = "0.2";
        /// <summary>
        /// 客户端tcp连接字
        /// </summary>
        public static string g_hostname = GetWebconfig("g_tcpIp");
        public static int g_port = int.Parse(GetWebconfig("g_tcpPort"));

        /// <summary>
        /// 客户端http连接地址
        /// </summary>
        public static string g_httpUrl = GetWebconfig("g_httpUrl");
        /// <summary>
        /// 客户端连接类
        /// </summary>
        public static TcpClient g_tcpClient = null;
        /// <summary>
        /// 客户端套接字
        /// </summary>
        public static Socket g_socket = null;
        /// <summary>
        /// 应用程序根目录
        /// </summary>
        public static string g_root = AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>
        /// 充电监控tcp有效客户端队列
        /// </summary>
        public static Dictionary<string, Dictionary<string, object>> g_cimTcpClientDic = new Dictionary<string, Dictionary<string, object>>();
        /// <summary>
        /// 充电监控充电桩数据列表
        /// </summary>
        public static List<Dictionary<string, object>> g_cimDataList = new List<Dictionary<string, object>>();

        /// <summary>
        /// 充电站编号
        /// </summary>
        public static long cs_id = 0;
        /// <summary>
        /// 用户名
        /// </summary>
        public static string cs_uname = "";
        /// <summary>
        /// 密码（密文）
        /// </summary>
        public static string cs_pwd = "";
        /// <summary>
        /// 非法字符
        /// </summary>
        public static string g_illegal = ",|\"|'";
        /// <summary>
        /// 设备报警
        /// </summary>
        public static string[] g_police = SystemFramework.SYSConfig.g_police;

        const double m_pi = 3.14159265358979324;
        const double m_a = 6378245.0;
        const double m_ee = 0.00669342162296594323;

        #endregion

        #region 坐标转换算法
        /// <summary>
        /// 地球坐标转换火星坐标
        /// </summary>
        /// <param name="lat">纬度</param>
        /// <param name="lng">经度</param>
        /// <returns></returns>
        public static Dictionary<string, double> WGtoMG(double lat, double lng)
        {
            double wglat = lat;
            double wglng = lng;
            double mglat, mglng;
            if (OutOfChina(wglat, wglng))
            {
                mglat = wglat;
                mglng = wglng;
            }
            else
            {
                double dlat = TransFormLat(wglng - 105.0, wglat - 35.0);
                double dlng = TransFormLng(wglng - 105.0, wglat - 35.0);
                double radlat = wglat / 180.0 * m_pi;
                double magic = Math.Sin(radlat);
                magic = 1 - m_ee * magic * magic;
                double sqrtMagic = Math.Sqrt(magic);
                dlat = (dlat * 180.0) / ((m_a * (1 - m_ee)) / (magic * sqrtMagic) * m_pi);
                dlng = (dlng * 180.0) / (m_a / sqrtMagic * Math.Cos(radlat) * m_pi);
                mglat = wglat + dlat;
                mglng = wglng + dlng;
            }
            return new Dictionary<string, double>() { { "lat", mglat }, { "lng", mglng } };
        }
        /// <summary>
        /// 判断是否中国坐标
        /// </summary>
        /// <param name="lat">纬度</param>
        /// <param name="lng">经度</param>
        /// <returns></returns>
        static bool OutOfChina(double lat, double lng)
        {
            if (lng < 72.004 || lng > 137.8347)
                return true;
            if (lat < 0.8293 || lat > 55.8271)
                return true;
            return false;
        }
        static double TransFormLat(double x, double y)
        {
            double ret = -100.0 + 2.0 * x + 3.0 * y + 0.2 * y * y + 0.1 * x * y + 0.2 * Math.Sqrt(Math.Abs(x));
            ret += (20.0 * Math.Sin(6.0 * x * m_pi) + 20.0 * Math.Sin(2.0 * x * m_pi)) * 2.0 / 3.0;
            ret += (20.0 * Math.Sin(y * m_pi) + 40.0 * Math.Sin(y / 3.0 * m_pi)) * 2.0 / 3.0;
            ret += (160.0 * Math.Sin(y / 12.0 * m_pi) + 320 * Math.Sin(y * m_pi / 30.0)) * 2.0 / 3.0;
            return ret;
        }
        static double TransFormLng(double x, double y)
        {
            var ret = 300.0 + x + 2.0 * y + 0.1 * x * x + 0.1 * x * y + 0.1 * Math.Sqrt(Math.Abs(x));
            ret += (20.0 * Math.Sin(6.0 * x * m_pi) + 20.0 * Math.Sin(2.0 * x * m_pi)) * 2.0 / 3.0;
            ret += (20.0 * Math.Sin(x * m_pi) + 40.0 * Math.Sin(x / 3.0 * m_pi)) * 2.0 / 3.0;
            ret += (150.0 * Math.Sin(x / 12.0 * m_pi) + 300.0 * Math.Sin(x / 30.0 * m_pi)) * 2.0 / 3.0;
            return ret;
        }
        /// <summary>
        /// 火星坐标转成百度经度标准
        /// </summary>
        /// <param name="lat">纬度</param>
        /// <param name="lng">经度</param>
        /// <returns></returns>
        public static Dictionary<string, double> MGtoBD(double lat, double lng)
        {
            double x_pi = 3.14159265358979324 * 3000.0 / 180.0;
            double x = lng, y = lat;
            double z = Math.Sqrt(x * x + y * y) + 0.00002 * Math.Sin(y * x_pi);
            double theta = Math.Atan2(y, x) + 0.000003 * Math.Cos(x * x_pi);
            lng = z * Math.Cos(theta) + 0.0065;
            lat = z * Math.Sin(theta) + 0.006;
            return new Dictionary<string, double>() { { "lat", lat }, { "lng", lng } };
        }
        /// <summary>
        /// 将度分格式转为度格式
        /// </summary>
        /// <param name="hm">度分字符串</param>
        /// <returns></returns>
        public static double HMtoH(string hm)
        {
            //获取分
            double m = double.Parse(Regex.Match(hm, @"\d{2}\.\d*$").ToString());
            //获取度
            double h = double.Parse(Regex.Match(hm, @"\d*(?=\d{2}\.\d*$)").ToString());

            return h + m / 60;
        }

        #endregion

        /// <summary>
        /// 获取web.config文件appSettings配置节中的Add里的value属性
        /// </summary>
        public static string GetWebconfig(string key)
        {
            string XPath = "/configuration/appSettings/add[@key='?']";
            XmlDocument domWebConfig = new XmlDocument();

            domWebConfig.Load(AppDomain.CurrentDomain.BaseDirectory + "Client.exe.config");
            XmlNode addKey = domWebConfig.SelectSingleNode((XPath.Replace("?", key)));
            if (addKey == null)
            {
                throw new ArgumentException("没有找到<add key='" + key + "' value=/>的配置节");
            }
            return addKey.Attributes["value"].InnerText;
        }

    }
}