using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Listener.App_Code.Include
{
    public class IncludePlace : AppCode
    {
        GetModelList m_gml = new GetModelList();

        /// <summary>
	    /// 初始化IncludeSeat类型的新实例
	    /// </summary>
        public IncludePlace()
	    {

	    }
        /*
	    ===========================================
	    城市管理
	    ===========================================
	    */
        #region 省
        /// <summary>
        /// 获取省列表
        /// </summary>
        /// <returns></returns>
        public List<G_Province> GetProvinceList()
        {
            List<G_Province> list = new List<G_Province>();
            DataSet ds = null;
            OpSql.Open();
            try
            {
                string sql = string.Format("select * from G_Province");
                ds = OpSql.Select(sql);
                if (ds != null && ds.Tables.Count > 0)
                {
                    list = m_gml.G_Province(ds.Tables[0]);
                }
            }
            catch { }
            finally { OpSql.Close(); }
            return list;
        }
        /// <summary>
        /// 获取省
        /// </summary>
        /// <param name="p_id">编号</param>
        /// <returns></returns>
        public List<G_Province> GetProvince(int? p_id)
        {
            List<G_Province> list = new List<G_Province>();
            DataSet ds = null;
            OpSql.Open();
            try
            {
                string sql = string.Format("select * from G_Province where p_id={0}", p_id);
                ds = OpSql.Select(sql);
                if (ds != null && ds.Tables.Count > 0)
                {
                    list = m_gml.G_Province(ds.Tables[0]);
                }
            }
            catch { }
            finally { OpSql.Close(); }
            return list;
        }
        #endregion
        #region 市
        /// <summary>
        /// 获取市列表
        /// </summary>
        /// <returns></returns>
        public List<G_City> GetCityList()
        {
            List<G_City> list = new List<G_City>();
            DataSet ds = null;
            OpSql.Open();
            try
            {
                string sql = string.Format("select * from G_City");
                ds = OpSql.Select(sql);
                if (ds != null && ds.Tables.Count > 0)
                {
                    list = m_gml.G_City(ds.Tables[0]);
                }
            }
            catch { }
            finally { OpSql.Close(); }
            return list;
        }
        /// <summary>
        /// 获取市
        /// </summary>
        /// <param name="c_id">编号</param>
        /// <returns></returns>
        public List<G_City> GetCity(int? c_id)
        {
            List<G_City> list = new List<G_City>();
            DataSet ds = null;
            OpSql.Open();
            try
            {
                string sql = string.Format("select * from G_City where c_id={0}", c_id);
                ds = OpSql.Select(sql);
                if (ds != null && ds.Tables.Count > 0)
                {
                    list = m_gml.G_City(ds.Tables[0]);
                }
            }
            catch { }
            finally { OpSql.Close(); }
            return list;
        }
        #endregion
        #region 区
        /// <summary>
        /// 获取区列表
        /// </summary>
        /// <returns></returns>
        public List<G_District> GetDistrictList()
        {
            List<G_District> list = new List<G_District>();
            DataSet ds = null;
            OpSql.Open();
            try
            {
                string sql = string.Format("select * from G_District");
                ds = OpSql.Select(sql);
                if (ds != null && ds.Tables.Count > 0)
                {
                    list = m_gml.G_District(ds.Tables[0]);
                }
            }
            catch { }
            finally { OpSql.Close(); }
            return list;
        }
        /// <summary>
        /// 获取区
        /// </summary>
        /// <param name="d_id">编号</param>
        /// <returns></returns>
        public List<G_District> GetDistrict(int? d_id)
        {
            List<G_District> list = new List<G_District>();
            DataSet ds = null;
            OpSql.Open();
            try
            {
                string sql = string.Format("select * from G_District where d_id={0}", d_id);
                ds = OpSql.Select(sql);
                if (ds != null && ds.Tables.Count > 0)
                {
                    list = m_gml.G_District(ds.Tables[0]);
                }
            }
            catch { }
            finally { OpSql.Close(); }
            return list;
        }
        #endregion
        #region 街道
        /// <summary>
        /// 删除街道
        /// </summary>
        /// <param name="mod">G_Street实体</param>
        public bool DelStreet(G_Street mod)
        {
            bool b = false;
            OpSql.Open();
            try
            {
                b = OpSql.Delete(new object[] { mod });
            }
            catch { }
            finally { OpSql.Close(); }
            return b;
        }
        /// <summary>
        /// 获取街道列表
        /// </summary>
        /// <returns></returns>
        public List<G_Street> GetStreetList()
        {
            List<G_Street> list = new List<G_Street>();
            DataSet ds = null;
            OpSql.Open();
            try
            {
                string sql = string.Format("select * from G_Street");
                ds = OpSql.Select(sql);
                if (ds != null && ds.Tables.Count > 0)
                {
                    list = m_gml.G_Street(ds.Tables[0]);
                }
            }
            catch { }
            finally { OpSql.Close(); }
            return list;
        }
        /// <summary>
        /// 获取街道
        /// </summary>
        /// <param name="s_id">编号</param>
        /// <returns></returns>
        public List<G_Street> GetStreet(int? s_id)
        {
            List<G_Street> list = new List<G_Street>();
            DataSet ds = null;
            OpSql.Open();
            try
            {
                string sql = string.Format("select * from G_Street where s_id={0}", s_id);
                ds = OpSql.Select(sql);
                if (ds != null && ds.Tables.Count > 0)
                {
                    list = m_gml.G_Street(ds.Tables[0]);
                }
            }
            catch { }
            finally { OpSql.Close(); }
            return list;
        }
        #endregion
        #region 社区
        /// <summary>
        /// 删除社区
        /// </summary>
        /// <param name="mod">G_Community实体</param>
        public bool DelCommunity(G_Community mod)
        {
            bool b = false;
            OpSql.Open();
            try
            {
                b = OpSql.Delete(new object[] { mod });
            }
            catch { }
            finally { OpSql.Close(); }
            return b;
        }
        /// <summary>
        /// 获取社区列表
        /// </summary>
        /// <returns></returns>
        public List<G_Community> GetCommunityList()
        {
            List<G_Community> list = new List<G_Community>();
            DataSet ds = null;
            OpSql.Open();
            try
            {
                string sql = string.Format("select * from G_Community");
                ds = OpSql.Select(sql);
                if (ds != null && ds.Tables.Count > 0)
                {
                    list = m_gml.G_Community(ds.Tables[0]);
                }
            }
            catch { }
            finally { OpSql.Close(); }
            return list;
        }
        /// <summary>
        /// 获取社区
        /// </summary>
        /// <param name="cm_id">编号</param>
        /// <returns></returns>
        public List<G_Community> GetCommunity(int? cm_id)
        {
            List<G_Community> list = new List<G_Community>();
            DataSet ds = null;
            OpSql.Open();
            try
            {
                string sql = string.Format("select * from G_Community where cm_id={0}", cm_id);
                ds = OpSql.Select(sql);
                if (ds != null && ds.Tables.Count > 0)
                {
                    list = m_gml.G_Community(ds.Tables[0]);
                }
            }
            catch { }
            finally { OpSql.Close(); }
            return list;
        }
        #endregion
        #region 其他
        /// <summary>
        /// 获取地区
        /// </summary>
        /// <param name="p_id">省编号</param>
        /// <param name="c_id">市编号</param>
        /// <param name="d_id">区编号</param>
        /// <param name="s_id">街道编号</param>
        /// <param name="cm_id">社区编号</param>
        /// <returns></returns>
        public List<string> GetPlace(int? p_id, int? c_id, int? d_id, int? s_id, int? cm_id)
        {
            List<string> arr = new List<string>();
            if (p_id != null && p_id != 0)
            {
                List<G_Province> list = GetProvince(p_id);
                arr.Add(list[0].p_name);
            }
            if (c_id != null && c_id != 0)
            {
                List<G_City> list = GetCity(c_id);
                arr.Add(list[0].c_name);
            }
            if (d_id != null && d_id != 0)
            {
                List<G_District> list = GetDistrict(d_id);
                arr.Add(list[0].d_name);
            }
            if (s_id != null && s_id != 0)
            {
                List<G_Street> list = GetStreet(s_id);
                arr.Add(list[0].s_name);
            }
            if (cm_id != null && cm_id != 0)
            {
                List<G_Community> list = GetCommunity(cm_id);
                arr.Add(list[0].cm_name);
            }
            return arr;
        }
        /// <summary>
        /// 获取地址
        /// </summary>
        /// <returns></returns>
        public string GetPlace(object u_province, object u_city, object u_district, object u_street, object u_community)
        {
            List<string> arr = new List<string>();
            try
            {
                arr = GetPlace((int?)u_province, (int?)u_city, (int?)u_district, (int?)u_street, (int?)u_community);
            }
            catch { arr = GetPlace(int.Parse(u_province.ToString()), int.Parse(u_city.ToString()), int.Parse(u_district.ToString()), int.Parse(u_street.ToString()), int.Parse(u_community.ToString())); }
            return string.Join("-", arr);
        }
        /// <summary>
        /// 获取街道
        /// </summary>
        /// <returns></returns>
        public string GetStreet(object u_street)
        {
            string temp = "";
            List<G_Street> arr = GetStreet((int?)u_street);
            if (arr.Count > 0)
            {
                temp = arr[0].s_phone;
            }
            return temp;
        }
        /// <summary>
        /// 获取社区
        /// </summary>
        /// <returns></returns>
        public string GetCommunity(object u_community)
        {
            string temp = "";
            List<G_Community> arr = GetCommunity((int?)u_community);
            if (arr.Count > 0)
            {
                temp = arr[0].cm_phone;
            }
            return temp;
        }
        #endregion
    }
}
