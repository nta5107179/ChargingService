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
    public class IncludeIdCard : AppCode
    {
        GetModelList m_gml = new GetModelList();

        /// <summary>
        /// 初始化IncludeIdCard类型的新实例
        /// </summary>
        public IncludeIdCard()
        {

        }

        #region IC卡管理
        /// <summary>
        /// 获取ic卡
        /// </summary>
        /// <param name="pay_ic_id">卡号</param>
        /// <returns></returns>
        public List<Models> GetIcCardList(long pay_ic_id)
        {
            List<Models> list = new List<Models>();
            OpSql.Open();
            try
            {
                string sql = string.Format("select * from PAY_IdCard as a "+
                    "left join G_User as b on a.u_id=b.u_id "+
                    "where a.pay_ic_id={0}"
                    , pay_ic_id);
                DataSet ds = OpSql.Select(sql);
                if (ds != null && ds.Tables.Count > 0)
                {
                    List<PAY_IdCard> list1 = m_gml.PAY_IdCard(ds.Tables[0]);
                    List<G_User> list2 = m_gml.G_User(ds.Tables[0]);
                    for (int i = 0; i < list1.Count; i++)
                    {
                        Models mod = new Models();
                        mod.PAY_IdCard = list1[i];
                        mod.G_User = list2[i];
                        list.Add(mod);
                    }
                }
            }
            catch { }
            finally { OpSql.Close(); }
            return list;
        }
        #endregion

    }
}
