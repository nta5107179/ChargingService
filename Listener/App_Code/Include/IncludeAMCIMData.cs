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
    public class IncludeAMCIMData : AppCode
    {
        GetModelList m_gml = new GetModelList();

        /// <summary>
        /// 初始化IncludeAMCIMData类型的新实例
        /// </summary>
        public IncludeAMCIMData()
        {

        }

        #region 充电监控数据管理
        /// <summary>
        /// 添加充电监控数据
        /// </summary>	
        public bool AddAMCIMData(AM_CIMData mod)
        {
            bool b = false;
            OpSql.Open();
            try
            {
                DataSet ds = new DataSet();
                object[] obj = new object[] {
                mod.cs_id,
                mod.t_id,
                mod.v_id,
                mod.cp_id,
                mod.cp_code,
                mod.cb_id,
                mod.cb_code,
                mod.am_cimd_begintime,
                mod.am_cimd_endtime,
                mod.am_cimd_kwh,
                mod.am_cimd_unitmoney,
                mod.am_cimd_money,
                mod.am_cimd_health,
                mod.am_cimd_chargenum,
                mod.u_id};
                b = OpSql.Selectproce("Listener_IncludeCIMTCPReceive_UP0006", obj, ref ds);
            }
            catch { }
            finally { OpSql.Close(); }
            return b;
        }
        #endregion

    }
}
