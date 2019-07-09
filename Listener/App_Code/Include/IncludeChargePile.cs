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
    public class IncludeChargePile : AppCode
    {
        GetModelList m_gml = new GetModelList();

        /// <summary>
        /// 初始化Include类型的新实例
        /// </summary>
        public IncludeChargePile()
        {

        }

        #region 充电桩管理
        /// <summary>
        /// 获取充电桩列表
        /// </summary>
        /// <param name="cs_id">充电站编号</param>
        /// <returns></returns>
        public List<Models> GetChargePileList(long cs_id)
        {
            List<Models> list = new List<Models>();
            OpSql.Open();
            try
            {
                string sql = string.Format("" +
                    "if (select cs_isglobal from G_ChargeStation where cs_id={0})=1 " +
                    "begin " +
                    "select * from G_ChargePile as t1 " +
                    "left join G_Type as t2 on t1.t_id=t2.t_id " +
                    "left join G_Version as t3 on t1.v_id=t3.v_id " +
                    "end " +
                    "else " +
                    "begin " +
                    "select * from(select * from G_ChargePile where cs_id={0}) as t1 " +
                    "left join G_Type as t2 on t1.t_id=t2.t_id " +
                    "left join G_Version as t3 on t1.v_id=t3.v_id " +
                    "end", cs_id);
                DataSet ds = OpSql.Select(sql);
                if (ds != null && ds.Tables.Count > 0)
                {
                    List<G_ChargePile> list1 = m_gml.G_ChargePile(ds.Tables[0]);
                    List<G_Type> list2 = m_gml.G_Type(ds.Tables[0]);
                    List<G_Version> list3 = m_gml.G_Version(ds.Tables[0]);
                    for (int i = 0; i < list1.Count; i++)
                    {
                        Models mod = new Models();
                        mod.G_ChargePile = list1[i];
                        mod.G_Type = list2[i];
                        mod.G_Version = list3[i];
                        list.Add(mod);
                    }
                }
            }
            catch { }
            finally { OpSql.Close(); }
            return list;
        }
        /// <summary>
        /// 获取充电桩
        /// </summary>
        /// <param name="cs_id">充电站编号</param>
        /// <param name="cp_id">充电桩编号</param>
        /// <returns></returns>
        public List<G_ChargePile> GetChargePile(long cs_id, long cp_id)
        {
            List<G_ChargePile> list = new List<G_ChargePile>();
            OpSql.Open();
            try
            {
                string sql = string.Format("" +
                    "select * from G_ChargePile where cs_id={0} and cp_id={1}" +
                    "", cs_id, cp_id);
                DataSet ds = OpSql.Select(sql);
                if (ds != null && ds.Tables.Count > 0)
                {
                    list = m_gml.G_ChargePile(ds.Tables[0]);
                }
            }
            catch { }
            finally { OpSql.Close(); }
            return list;
        }
        /// <summary>
        /// 获取充电桩
        /// </summary>
        /// <param name="cs_id">充电站编号</param>
        /// <param name="cp_code">充电桩编码</param>
        /// <returns></returns>
        public List<G_ChargePile> GetChargePile(long cs_id, string cp_code)
        {
            List<G_ChargePile> list = new List<G_ChargePile>();
            OpSql.Open();
            try
            {
                string sql = string.Format("" +
                    "select * from G_ChargePile where cs_id={0} and cp_code='{1}'" +
                    "", cs_id, cp_code);
                DataSet ds = OpSql.Select(sql);
                if (ds != null && ds.Tables.Count > 0)
                {
                    list = m_gml.G_ChargePile(ds.Tables[0]);
                }
            }
            catch { }
            finally { OpSql.Close(); }
            return list;
        }
        #endregion

    }
}
