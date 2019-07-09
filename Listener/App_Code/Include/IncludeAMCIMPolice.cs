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
    /// IncludeAMCIMPolice
    /// </summary>
    public class IncludeAMCIMPolice : AppCode
    {
        GetModelList m_gml = new GetModelList();

        /// <summary>
        /// 初始化IncludeAMCIMPolice类型的新实例
        /// </summary>
        public IncludeAMCIMPolice()
        {

        }

        #region 充电桩报警数据管理
        /// <summary>
        /// 添加充电桩报警数据
        /// </summary>	
        public bool AddAMCIMPolice(AM_CIMPolice mod)
        {
            bool b = false;
            OpSql.Open();
            try
            {
                b = OpSql.Insert(new object[] { mod });
            }
            catch { }
            finally { OpSql.Close(); }
            return b;
        }
        /// <summary>
        /// 修改充电桩报警数据
        /// </summary>	
        public bool EditAMCIMPolice(AM_CIMPolice mod, AM_CIMPolice mod2)
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
        /// 获取充电桩报警数据列表
        /// </summary>
        /// <param name="cs_id">充电站编号</param>
        /// <param name="cp_id">充电站编号(0为不限)</param>
        /// <param name="am_cimp_examine">是否处理</param>
        /// <returns></returns>
        public List<AM_CIMPolice> GetAMCIMPoliceList(long cs_id, long cp_id, bool am_cimp_examine)
        {
            List<AM_CIMPolice> list = new List<AM_CIMPolice>();
            OpSql.Open();
            try
            {
                string sql = "";
                if (cp_id > 0)
                {
                    sql = string.Format("" +
                        "select * from AM_CIMPolice where cs_id={0} and cp_id={1} and am_cimp_examine={2}" +
                        "", cs_id, cp_id, Convert.ToInt32(am_cimp_examine));
                }
                else
                {
                    sql = string.Format("" +
                        "select * from AM_CIMPolice where cs_id={0} and am_cimp_examine={1}" +
                        "", cs_id, Convert.ToInt32(am_cimp_examine));
                }
                DataSet ds = OpSql.Select(sql);
                if (ds != null && ds.Tables.Count > 0)
                {
                    list = m_gml.AM_CIMPolice(ds.Tables[0]);
                }
            }
            catch { }
            finally { OpSql.Close(); }
            return list;
        }
        #endregion

    }
}
