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
    /// IncludeSystemError
    /// </summary>
    public class IncludeSystemError : AppCode
    {
        GetModelList m_gml = new GetModelList();

        /// <summary>
        /// 初始化IncludeSystemError类型的新实例
        /// </summary>
        public IncludeSystemError()
        {

        }

        #region 日志
        /// <summary>
        /// 添加日志
        /// </summary>
        /// <returns></returns>
        public bool AddSystemError(LOG_SystemError mod)
        {
            //记录上行内容
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
        #endregion

    }
}
