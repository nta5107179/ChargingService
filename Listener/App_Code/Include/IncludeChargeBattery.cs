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
    public class IncludeChargeBattery : AppCode
    {
        GetModelList m_gml = new GetModelList();

        /// <summary>
        /// 初始化IncludeChargeBattery类型的新实例
        /// </summary>
        public IncludeChargeBattery()
        {

        }

        #region 电池管理
        /// <summary>
        /// 添加电池
        /// </summary>	
        public bool AddChargeBattery(G_ChargeBattery mod)
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
        /// 获取电池
        /// </summary>
        /// <param name="cb_code">电池编码</param>
        /// <returns></returns>
        public List<G_ChargeBattery> GetChargeBattery(string cb_code)
        {
            List<G_ChargeBattery> list = new List<G_ChargeBattery>();
            OpSql.Open();
            try
            {
                string sql = string.Format("" +
                    "select * from G_ChargeBattery where cb_code='{0}'" +
                    "", cb_code);
                DataSet ds = OpSql.Select(sql);
                if (ds != null && ds.Tables.Count > 0)
                {
                    list = m_gml.G_ChargeBattery(ds.Tables[0]);
                }
            }
            catch { }
            finally { OpSql.Close(); }
            return list;
        }
        #endregion

    }
}
