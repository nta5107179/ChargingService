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
    /// IncludeUser
    /// </summary>
    public class IncludeUser : AppCode
    {
        GetModelList m_gml = new GetModelList();

        /// <summary>
        /// 初始化IncludeIdCard类型的新实例
        /// </summary>
        public IncludeUser()
        {

        }

        #region 用户管理
        /// <summary>
        /// 获取充电桩
        /// </summary>
        /// <param name="u_uname">用户名</param>
        /// <returns></returns>
        public List<G_User> GetUser(long u_uname)
        {
            List<G_User> list = new List<G_User>();
            OpSql.Open();
            try
            {
                string sql = string.Format("" +
                    "select * from G_User where u_uname={0} and u_examine = 1" +
                    "", u_uname);
                DataSet ds = OpSql.Select(sql);
                if (ds != null && ds.Tables.Count > 0)
                {
                    list = m_gml.G_User(ds.Tables[0]);
                }
            }
            catch { }
            finally { OpSql.Close(); }
            return list;
        }
        #endregion

    }
}
