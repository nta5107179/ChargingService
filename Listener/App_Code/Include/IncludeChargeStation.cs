using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using SystemFramework;
using System.Data;

namespace Listener.App_Code.Include
{
    /// <summary>
    /// Include
    /// </summary>
    public class IncludeChargeStation : AppCode
    {
        GetModelList m_gml = new GetModelList();

        /// <summary>
        /// 初始化IncludeChargeStation类型的新实例
        /// </summary>
        public IncludeChargeStation()
        {

        }

        #region 充电站管理
        /// <summary>
        /// 修改充电站
        /// </summary>
        /// <param name="mod">旧G_ChargeStation实体</param>
        /// <param name="mod2">新G_ChargeStation实体</param>
        public bool EditChargeStation(G_ChargeStation mod, G_ChargeStation mod2)
        {
            bool b = false;
            OpSql.Open();
            try
            {
                b = OpSql.Update(new object[] { mod }, new object[] { mod2 });
            }
            catch { }
            finally { OpSql.Close(); }
            return b;
        }
        /// <summary>
        /// 获取充电站列表
        /// </summary>
        /// <param name="cs_id">充电站编号</param>
        /// <returns></returns>
        public List<Models> GetChargeStationList()
        {
            List<Models> list = new List<Models>();
            OpSql.Open();
            try
            {
                string sql = string.Format("select * from G_ChargeStation as t1 " +
                    "left join (select cs_id,count(*) as cp_number from G_ChargePile group by cs_id) as t2 on t1.cs_id=t2.cs_id " +
                    "left join G_Province as gp on t1.p_id=gp.p_id " +
                    "left join G_City as gc on t1.c_id=gc.c_id " +
                    "left join G_District as gd on t1.d_id=gd.d_id "+
                    "order by t1.cs_id asc");
                DataSet ds = OpSql.Select(sql);
                if (ds != null && ds.Tables.Count > 0)
                {
                    List<G_ChargeStation> list1 = m_gml.G_ChargeStation(ds.Tables[0]);
                    List<G_Province> list2 = m_gml.G_Province(ds.Tables[0]);
                    List<G_City> list3 = m_gml.G_City(ds.Tables[0]);
                    List<G_District> list4 = m_gml.G_District(ds.Tables[0]);
                    for (int i = 0; i < list1.Count; i++)
                    {
                        Models mod = new Models();
                        mod.G_ChargeStation = list1[i];
                        mod.G_Province = list2[i];
                        mod.G_City = list3[i];
                        mod.G_District = list4[i];
                        list.Add(mod);
                    }
                }
            }
            catch { }
            finally { OpSql.Close(); }
            return list;
        }
        /// <summary>
        /// 获取充电站
        /// </summary>
        /// <param name="cs_id">充电站编号</param>
        /// <returns></returns>
        public List<Models> GetChargeStation(long cs_id)
        {
            List<Models> list = new List<Models>();
            OpSql.Open();
            try
            {
                string sql = string.Format("select * from (" +
                    "select * from G_ChargeStation where cs_id={0}" +
                    ") as t1 " +
                    "left join G_Province as gp on t1.p_id=gp.p_id " +
                    "left join G_City as gc on t1.c_id=gc.c_id " +
                    "left join G_District as gd on t1.d_id=gd.d_id", cs_id);
                DataSet ds = OpSql.Select(sql);
                if (ds != null && ds.Tables.Count > 0)
                {
                    List<G_ChargeStation> list1 = m_gml.G_ChargeStation(ds.Tables[0]);
                    List<G_Province> list2 = m_gml.G_Province(ds.Tables[0]);
                    List<G_City> list3 = m_gml.G_City(ds.Tables[0]);
                    List<G_District> list4 = m_gml.G_District(ds.Tables[0]);
                    for (int i = 0; i < list1.Count; i++)
                    {
                        Models mod = new Models();
                        mod.G_ChargeStation = list1[i];
                        mod.G_Province = list2[i];
                        mod.G_City = list3[i];
                        mod.G_District = list4[i];
                        list.Add(mod);
                    }
                }
            }
            catch { }
            finally { OpSql.Close(); }
            return list;
        }
        /// <summary>
        /// 登录充电站
        /// </summary>
        /// <param name="u_name">用户用户名</param>
        /// <param name="u_pwd">用户密码(密文)</param>
        public Dictionary<string, object> LoginChargeStation(string u_name, string u_pwd)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>()
            {
                {"condition", 0},
                {"cs_id", 0},
                {"isglobal", false}
            };
            OpSql.Open();
            try
            {
                string sql = string.Format("select * from G_ChargeStation where cs_uname='{0}' and cs_pwd='{1}' and cs_examine=1", u_name, u_pwd);
                DataSet ds = OpSql.Select(sql);
                if (ds != null && ds.Tables.Count > 0)
                {
                    List<G_ChargeStation> list = m_gml.G_ChargeStation(ds.Tables[0]);
                    if (list.Count > 0)
                    {
                        DateTime now = DateTime.Now;
                        if (now >= (DateTime)list[0].cs_endtime)
                        {
                            //账号过期
                            dic["condition"] = -1;
                        }
                        else if (!(bool)list[0].cs_examine)
                        {
                            //账号未激活
                            dic["condition"] = -2;
                        }
                        else
                        {
                            dic["cs_id"] = (long)list[0].cs_id;
                            //登录成功
                            dic["condition"] = 1;
                            dic["isglobal"] = (bool)list[0].cs_isglobal;
                        }
                    }
                }
            }
            catch { }
            finally { OpSql.Close(); }
            return dic;
        }
        #endregion

    }
}
