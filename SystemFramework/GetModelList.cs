using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Model;

/// <summary>
/// 将数据集转化成实体数组
/// </summary>
public class GetModelList
{
	/// <summary>
	/// 初始化GetModelList类型的新
	/// </summary>
	public GetModelList()
	{

	}

    /// <summary>
    /// 获取AM_CIMData实体List
    /// </summary>
    /// <param name="dt">源数据表</param>
    /// <returns></returns>
    public List<AM_CIMData> AM_CIMData(DataTable dt)
    {
        List<AM_CIMData> modelList = new List<AM_CIMData>();
        AM_CIMData model;
        for (int n = 0; n < dt.Rows.Count; n++)
        {
            model = new AM_CIMData();
            try
            {
                model.am_cimd_id = (long)dt.Rows[n]["am_cimd_id"];
            }
            catch { }
            try{
                model.cs_id = (long)dt.Rows[n]["cs_id"];
            }
            catch { }
            try{
                model.t_id = (int)dt.Rows[n]["t_id"];
            }
            catch { }
            try{
                model.v_id = (int)dt.Rows[n]["v_id"];
            }
            catch { }
            try{
                model.cp_id = (long)dt.Rows[n]["cp_id"];
            }
            catch { }
            model.cp_code = dt.Rows[n]["cp_code"].ToString();
            try{
                model.cp_guncode = (int)dt.Rows[n]["cp_guncode"];
            }
            catch { }
            try{
                model.cb_id = (long)dt.Rows[n]["cb_id"];
            }
            catch { }
            model.cb_code = dt.Rows[n]["cb_code"].ToString();
            try{
                model.am_cimd_begintime = (DateTime)dt.Rows[n]["am_cimd_begintime"];
            }
            catch { }
            try{
                model.am_cimd_endtime = (DateTime)dt.Rows[n]["am_cimd_endtime"];
            }
            catch { }
            try{
                model.am_cimd_kwh = (double)dt.Rows[n]["am_cimd_kwh"];
            }
            catch { }
            try{
                model.am_cimd_kwhf = (double)dt.Rows[n]["am_cimd_kwhf"];
            }
            catch { }
            try{
                model.am_cimd_kwhg = (double)dt.Rows[n]["am_cimd_kwhg"];
            }
            catch { }
            try{
                model.am_cimd_kwhp = (double)dt.Rows[n]["am_cimd_kwhp"];
            }
            catch { }
            try{
                model.am_cimd_kwhj = (double)dt.Rows[n]["am_cimd_kwhj"];
            }
            catch { }
            try{
                model.am_cimd_unitmoney = (decimal)dt.Rows[n]["am_cimd_unitmoney"];
            }
            catch { }
            try{
                model.am_cimd_money = (decimal)dt.Rows[n]["am_cimd_money"];
            }
            catch { }
            try{
                model.am_cimd_health = (int)dt.Rows[n]["am_cimd_health"];
            }
            catch { }
            try{
                model.am_cimd_chargenum = (int)dt.Rows[n]["am_cimd_chargenum"];
            }
            catch { }
            try{
                model.u_id = (long)dt.Rows[n]["u_id"];
            }
            catch { }
            try{
                model.am_cimd_addtime = (DateTime)dt.Rows[n]["am_cimd_addtime"];
            }
            catch { }
            modelList.Add(model);
        }
        return modelList;
    }
    /// <summary>
    /// 获取AM_CIMPolice实体List
    /// </summary>
    /// <param name="dt">源数据表</param>
    /// <returns></returns>
    public List<AM_CIMPolice> AM_CIMPolice(DataTable dt)
    {
        List<AM_CIMPolice> modelList = new List<AM_CIMPolice>();
        AM_CIMPolice model;
        for (int n = 0; n < dt.Rows.Count; n++)
        {
            model = new AM_CIMPolice();
            try
            {
                model.am_cimp_id = (long)dt.Rows[n]["am_cimp_id"];
            }
            catch { }
            try
            {
                model.cs_id = (long)dt.Rows[n]["cs_id"];
            }
            catch { }
            try
            {
                model.t_id = (int)dt.Rows[n]["t_id"];
            }
            catch { }
            try
            {
                model.v_id = (int)dt.Rows[n]["v_id"];
            }
            catch { }
            try
            {
                model.cp_id = (long)dt.Rows[n]["cp_id"];
            }
            catch { }
            model.cp_code = dt.Rows[n]["cp_code"].ToString();
            try
            {
                model.cp_guncode = (int)dt.Rows[n]["cp_guncode"];
            }
            catch { }
            try
            {
                model.cb_id = (long)dt.Rows[n]["cb_id"];
            }
            catch { }
            model.cb_code = dt.Rows[n]["cb_code"].ToString();
            try
            {
                model.am_cimp_condition = (int)dt.Rows[n]["am_cimp_condition"];
            }
            catch { }
            try
            {
                model.am_cimp_type = (int)dt.Rows[n]["am_cimp_type"];
            }
            catch { }
            try
            {
                model.am_cimp_examine = (bool)dt.Rows[n]["am_cimp_examine"];
            }
            catch { }
            try
            {
                model.am_d_addtime = (DateTime)dt.Rows[n]["am_d_addtime"];
            }
            catch { }
            modelList.Add(model);
        }
        return modelList;
    }
    /// <summary>
    /// 获取AM_DownLecture实体List
    /// </summary>
    /// <param name="dt">源数据表</param>
    /// <returns></returns>
    public List<AM_DownLecture> AM_DownLecture(DataTable dt)
    {
        List<AM_DownLecture> modelList = new List<AM_DownLecture>();
        AM_DownLecture model;
        for (int n = 0; n < dt.Rows.Count; n++)
        {
            model = new AM_DownLecture();
            try{
                model.am_dl_id = (long)dt.Rows[n]["am_dl_id"];
            }
            catch { }
            try{
                model.cs_id = (long)dt.Rows[n]["cs_id"];
            }
            catch { }
            try{
                model.t_id = (int)dt.Rows[n]["t_id"];
            }
            catch { }
            try{
                model.v_id = (int)dt.Rows[n]["v_id"];
            }
            catch { }
            try{
                model.cp_id = (long)dt.Rows[n]["cp_id"];
            }
            catch { }
            model.cp_code = dt.Rows[n]["cp_code"].ToString();
            try{
                model.cb_id = (long)dt.Rows[n]["cb_id"];
            }
            catch { }
            model.cb_code = dt.Rows[n]["cb_code"].ToString();
            model.am_dl_content = dt.Rows[n]["am_dl_content"].ToString();
            model.am_dl_number = dt.Rows[n]["am_dl_number"].ToString();
            model.am_dl_body = dt.Rows[n]["am_dl_body"].ToString();
            try{
                model.am_dl_addtime = (DateTime)dt.Rows[n]["am_dl_addtime"];
            }
            catch { }
            modelList.Add(model);
        }
        return modelList;
    }
    /// <summary>
    /// 获取AM_MDownLecture实体List
    /// </summary>
    /// <param name="dt">源数据表</param>
    /// <returns></returns>
    public List<AM_MDownLecture> AM_MDownLecture(DataTable dt)
    {
        List<AM_MDownLecture> modelList = new List<AM_MDownLecture>();
        AM_MDownLecture model;
        for (int n = 0; n < dt.Rows.Count; n++)
        {
            model = new AM_MDownLecture();
            try{
                model.am_mdl_id = (long)dt.Rows[n]["am_mdl_id"];
            }
            catch { }
            try{
                model.cs_id = (long)dt.Rows[n]["cs_id"];
            }
            catch { }
            try{
                model.v2_id = (int)dt.Rows[n]["v2_id"];
            }
            catch { }
            model.am_mdl_content = dt.Rows[n]["am_mdl_content"].ToString();
            model.am_mdl_number = dt.Rows[n]["am_mdl_number"].ToString();
            model.am_mdl_body = dt.Rows[n]["am_mdl_body"].ToString();
            try{
                model.am_mdl_addtime = (DateTime)dt.Rows[n]["am_mdl_addtime"];
            }
            catch { }
            modelList.Add(model);
        }
        return modelList;
    }
    /// <summary>
    /// 获取AM_MUpLecture实体List
    /// </summary>
    /// <param name="dt">源数据表</param>
    /// <returns></returns>
    public List<AM_MUpLecture> AM_MUpLecture(DataTable dt)
    {
        List<AM_MUpLecture> modelList = new List<AM_MUpLecture>();
        AM_MUpLecture model;
        for (int n = 0; n < dt.Rows.Count; n++)
        {
            model = new AM_MUpLecture();
            try{
                model.am_mul_id = (long)dt.Rows[n]["am_mul_id"];
            }
            catch { }
            try{
                model.cs_id = (long)dt.Rows[n]["cs_id"];
            }
            catch { }
            try{
                model.v2_id = (int)dt.Rows[n]["v2_id"];
            }
            catch { }
            model.am_mul_content = dt.Rows[n]["am_mul_content"].ToString();
            model.am_mul_number = dt.Rows[n]["am_mul_number"].ToString();
            model.am_mul_body = dt.Rows[n]["am_mul_body"].ToString();
            try{
                model.am_mul_addtime = (DateTime)dt.Rows[n]["am_mul_addtime"];
            }
            catch { }
            modelList.Add(model);
        }
        return modelList;
    }
    /// <summary>
    /// 获取AM_UpLecture实体List
    /// </summary>
    /// <param name="dt">源数据表</param>
    /// <returns></returns>
    public List<AM_UpLecture> AM_UpLecture(DataTable dt)
    {
        List<AM_UpLecture> modelList = new List<AM_UpLecture>();
        AM_UpLecture model;
        for (int n = 0; n < dt.Rows.Count; n++)
        {
            model = new AM_UpLecture();
            try{
                model.am_ul_id = (long)dt.Rows[n]["am_ul_id"];
            }
            catch { }
            try{
                model.cs_id = (long)dt.Rows[n]["cs_id"];
            }
            catch { }
            try{
                model.t_id = (int)dt.Rows[n]["t_id"];
            }
            catch { }
            try{
                model.v_id = (int)dt.Rows[n]["v_id"];
            }
            catch { }
            try{
                model.cp_id = (long)dt.Rows[n]["cp_id"];
            }
            catch { }
            model.cp_code = dt.Rows[n]["cp_code"].ToString();
            try{
                model.cb_id = (long)dt.Rows[n]["cb_id"];
            }
            catch { }
            model.cb_code = dt.Rows[n]["cb_code"].ToString();
            model.am_ul_content = dt.Rows[n]["am_ul_content"].ToString();
            model.am_ul_number = dt.Rows[n]["am_ul_number"].ToString();
            model.am_ul_body = dt.Rows[n]["am_ul_body"].ToString();
            try{
                model.am_ul_addtime = (DateTime)dt.Rows[n]["am_ul_addtime"];
            }
            catch { }
            modelList.Add(model);
        }
        return modelList;
    }
    /// <summary>
    /// 获取CAR_CarBrand实体List
    /// </summary>
    /// <param name="dt">源数据表</param>
    /// <returns></returns>
    public List<CAR_CarBrand> CAR_CarBrand(DataTable dt)
    {
        List<CAR_CarBrand> modelList = new List<CAR_CarBrand>();
        CAR_CarBrand model;
        for (int n = 0; n < dt.Rows.Count; n++)
        {
            model = new CAR_CarBrand();
            try{
                model.car_cb_id = (int)dt.Rows[n]["car_cb_id"];
            }
            catch { }
            model.car_cb_name = dt.Rows[n]["car_cb_name"].ToString();
            try{
                model.car_cb_examine = (bool)dt.Rows[n]["car_cb_examine"];
            }
            catch { }
            modelList.Add(model);
        }
        return modelList;
    }
    /// <summary>
    /// 获取CS_SystemMessage实体List
    /// </summary>
    /// <param name="dt">源数据表</param>
    /// <returns></returns>
    public List<CS_SystemMessage> CS_SystemMessage(DataTable dt)
    {
        List<CS_SystemMessage> modelList = new List<CS_SystemMessage>();
        CS_SystemMessage model;
        for (int n = 0; n < dt.Rows.Count; n++)
        {
            model = new CS_SystemMessage();
            try{
                model.cs_sm_id = (long)dt.Rows[n]["cs_sm_id"];
            }
            catch { }
            try{
                model.sm_id = (int)dt.Rows[n]["sm_id"];
            }
            catch { }
            try{
                model.cs_id = (long)dt.Rows[n]["cs_id"];
            }
            catch { }
            try{
                model.cs_sm_isred = (bool)dt.Rows[n]["cs_sm_isred"];
            }
            catch { }
            try{
                model.cs_sm_addtime = (DateTime)dt.Rows[n]["cs_sm_addtime"];
            }
            catch { }
            modelList.Add(model);
        }
        return modelList;
    }
    /// <summary>
    /// 获取CAR_CarType实体List
    /// </summary>
    /// <param name="dt">源数据表</param>
    /// <returns></returns>
    public List<CAR_CarType> CAR_CarType(DataTable dt)
    {
        List<CAR_CarType> modelList = new List<CAR_CarType>();
        CAR_CarType model;
        for (int n = 0; n < dt.Rows.Count; n++)
        {
            model = new CAR_CarType();
            try{
                model.car_ct_id = (int)dt.Rows[n]["car_ct_id"];
            }
            catch { }
            model.car_ct_name = dt.Rows[n]["car_ct_name"].ToString();
            try{
                model.car_cb_id = (int)dt.Rows[n]["car_cb_id"];
            }
            catch { }
            try{
                model.car_ct_type = (int)dt.Rows[n]["car_ct_type"];
            }
            catch { }
            try{
                model.car_ct_examine = (bool)dt.Rows[n]["car_ct_examine"];
            }
            catch { }
            modelList.Add(model);
        }
        return modelList;
    }
    /// <summary>
    /// 获取G_ChargeBattery实体List
    /// </summary>
    /// <param name="dt">源数据表</param>
    /// <returns></returns>
    public List<G_ChargeBattery> G_ChargeBattery(DataTable dt)
    {
        List<G_ChargeBattery> modelList = new List<G_ChargeBattery>();
        G_ChargeBattery model;
        for (int n = 0; n < dt.Rows.Count; n++)
        {
            model = new G_ChargeBattery();
            try{
                model.cb_id = (long)dt.Rows[n]["cb_id"];
            }
            catch { }
            model.cb_code = dt.Rows[n]["cb_code"].ToString();
            try{
                model.cb_examine = (bool)dt.Rows[n]["cb_examine"];
            }
            catch { }
            try{
                model.cb_addtime = (DateTime)dt.Rows[n]["cb_addtime"];
            }
            catch { }
            modelList.Add(model);
        }
        return modelList;
    }
    /// <summary>
    /// 获取G_ChargePile实体List
    /// </summary>
    /// <param name="dt">源数据表</param>
    /// <returns></returns>
    public List<G_ChargePile> G_ChargePile(DataTable dt)
    {
        List<G_ChargePile> modelList = new List<G_ChargePile>();
        G_ChargePile model;
        for (int n = 0; n < dt.Rows.Count; n++)
        {
            model = new G_ChargePile();
            try{
                model.cp_id = (long)dt.Rows[n]["cp_id"];
            }
            catch { }
            try{
                model.cs_id = (long)dt.Rows[n]["cs_id"];
            }
            catch { }
            try{
                model.t_id = (int)dt.Rows[n]["t_id"];
            }
            catch { }
            try{
                model.v_id = (int)dt.Rows[n]["v_id"];
            }
            catch { }
            try{
                model.cp_chargemod = (int)dt.Rows[n]["cp_chargemod"];
            }
            catch { }
            model.cp_name = dt.Rows[n]["cp_name"].ToString();
            model.cp_code = dt.Rows[n]["cp_code"].ToString();
            try{
                model.cp_lng = (double)dt.Rows[n]["cp_lng"];
            }
            catch { }
            model.cp_lng_mark = dt.Rows[n]["cp_lng_mark"].ToString();
            try{
                model.cp_lat = (double)dt.Rows[n]["cp_lat"];
            }
            catch { }
            model.cp_lat_mark = dt.Rows[n]["cp_lat_mark"].ToString();
            try{
                model.cp_gglng = (double)dt.Rows[n]["cp_gglng"];
            }
            catch { }
            try{
                model.cp_gglat = (double)dt.Rows[n]["cp_gglat"];
            }
            catch { }
            try{
                model.cp_bdlng = (double)dt.Rows[n]["cp_bdlng"];
            }
            catch { }
            try{
                model.cp_bdlat = (double)dt.Rows[n]["cp_bdlat"];
            }
            catch { }
            try{
                model.p_id = (int)dt.Rows[n]["p_id"];
            }
            catch { }
            try{
                model.c_id = (int)dt.Rows[n]["c_id"];
            }
            catch { }
            try{
                model.d_id = (int)dt.Rows[n]["d_id"];
            }
            catch { }
            try{
                model.s_id = (int)dt.Rows[n]["s_id"];
            }
            catch { }
            try{
                model.cm_id = (int)dt.Rows[n]["cm_id"];
            }
            catch { }
            model.pcdscm_address = dt.Rows[n]["pcdscm_address"].ToString();
            try
            {
                model.cp_money = (decimal)dt.Rows[n]["cp_money"];
            }
            catch { }
            try{
                model.cp_operation = (int)dt.Rows[n]["cp_operation"];
            }
            catch { }
            try{
                model.cp_gunnum = (int)dt.Rows[n]["cp_gunnum"];
            }
            catch { }
            try{
                model.cp_examine = (bool)dt.Rows[n]["cp_examine"];
            }
            catch { }
            try{
                model.cp_addtime = (DateTime)dt.Rows[n]["cp_addtime"];
            }
            catch { }
            model.cp_type = dt.Rows[n]["cp_type"].ToString();
            model.cp_model = dt.Rows[n]["cp_model"].ToString();
            model.cp_company = dt.Rows[n]["cp_company"].ToString();
            model.cp_amod = dt.Rows[n]["cp_amod"].ToString();
            model.cp_v = dt.Rows[n]["cp_v"].ToString();
            model.cp_a = dt.Rows[n]["cp_a"].ToString();
            try
            {
                model.cp_wid = (int)dt.Rows[n]["cp_wid"];
            }
            catch { }
            modelList.Add(model);
        }
        return modelList;
    }
    /// <summary>
    /// 获取G_ChargeStation实体List
    /// </summary>
    /// <param name="dt">源数据表</param>
    /// <returns></returns>
    public List<G_ChargeStation> G_ChargeStation(DataTable dt)
    {
        List<G_ChargeStation> modelList = new List<G_ChargeStation>();
        G_ChargeStation model;
        for (int n = 0; n < dt.Rows.Count; n++)
        {
            model = new G_ChargeStation();
            try{
                model.cs_id = (long)dt.Rows[n]["cs_id"];
            }
            catch { }
            model.cs_uname = dt.Rows[n]["cs_uname"].ToString();
            model.cs_pwd = dt.Rows[n]["cs_pwd"].ToString();
            model.cs_name = dt.Rows[n]["cs_name"].ToString();
            model.cs_phone = dt.Rows[n]["cs_phone"].ToString();
            model.cs_appfilename = dt.Rows[n]["cs_appfilename"].ToString();
            try{
                model.cs_lng = (double)dt.Rows[n]["cs_lng"];
            }
            catch { }
            model.cs_lng_mark = dt.Rows[n]["cs_lng_mark"].ToString();
            try{
                model.cs_lat = (double)dt.Rows[n]["cs_lat"];
            }
            catch { }
            model.cs_lat_mark = dt.Rows[n]["cs_lat_mark"].ToString();
            try{
                model.cs_gglng = (double)dt.Rows[n]["cs_gglng"];
            }
            catch { }
            try{
                model.cs_gglat = (double)dt.Rows[n]["cs_gglat"];
            }
            catch { }
            try{
                model.cs_bdlng = (double)dt.Rows[n]["cs_bdlng"];
            }
            catch { }
            try{
                model.cs_bdlat = (double)dt.Rows[n]["cs_bdlat"];
            }
            catch { }
            try{
                model.p_id = (int)dt.Rows[n]["p_id"];
            }
            catch { }
            try{
                model.c_id = (int)dt.Rows[n]["c_id"];
            }
            catch { }
            try{
                model.d_id = (int)dt.Rows[n]["d_id"];
            }
            catch { }
            try{
                model.s_id = (int)dt.Rows[n]["s_id"];
            }
            catch { }
            try{
                model.cm_id = (int)dt.Rows[n]["cm_id"];
            }
            catch { }
            model.pcdscm_address = dt.Rows[n]["pcdscm_address"].ToString();
            try{
                model.cs_endtime = (DateTime)dt.Rows[n]["cs_endtime"];
            }
            catch { }
            try{
                model.cs_power = (double)dt.Rows[n]["cs_power"];
            }
            catch { }
            try{
                model.cs_operation = (int)dt.Rows[n]["cs_operation"];
            }
            catch { }
            try{
                model.cs_ispub = (bool)dt.Rows[n]["cs_ispub"];
            }
            catch { }
            try{
                model.cs_examine = (bool)dt.Rows[n]["cs_examine"];
            }
            catch { }
            try{
                model.cs_addtime = (DateTime)dt.Rows[n]["cs_addtime"];
            }
            catch { }
            try{
                model.cp_number = (int)dt.Rows[n]["cp_number"];
            }
            catch { }
            try{
                model.cs_isglobal = (bool)dt.Rows[n]["cs_isglobal"];
            }
            catch { }
            modelList.Add(model);
        }
        return modelList;
    }
    /// <summary>
    /// 获取G_City实体List
    /// </summary>
    /// <param name="dt">源数据表</param>
    /// <returns></returns>
    public List<G_City> G_City(DataTable dt)
    {
        List<G_City> modelList = new List<G_City>();
        G_City model;
        for (int n = 0; n < dt.Rows.Count; n++)
        {
            model = new G_City();
            try
            {
                model.c_id = (int)dt.Rows[n]["c_id"];
            }
            catch { }
            model.c_name = dt.Rows[n]["c_name"].ToString();
            try{
                model.p_id = (int)dt.Rows[n]["p_id"];
            }
            catch { }
            model.c_phone = dt.Rows[n]["c_phone"].ToString();
            try{
                model.c_examine = (bool)dt.Rows[n]["c_examine"];
            }
            catch { }
            modelList.Add(model);
        }
        return modelList;
    }
    /// <summary>
    /// 获取G_Community实体List
    /// </summary>
    /// <param name="dt">源数据表</param>
    /// <returns></returns>
    public List<G_Community> G_Community(DataTable dt)
    {
        List<G_Community> modelList = new List<G_Community>();
        G_Community model;
        for (int n = 0; n < dt.Rows.Count; n++)
        {
            model = new G_Community();
            try{
                model.cm_id = (int)dt.Rows[n]["cm_id"];
            }
            catch { }
            model.cm_name = dt.Rows[n]["cm_name"].ToString();
            try{
                model.s_id = (int)dt.Rows[n]["s_id"];
            }
            catch { }
            model.cm_phone = dt.Rows[n]["cm_phone"].ToString();
            try{
                model.cm_examine = (bool)dt.Rows[n]["cm_examine"];
            }
            catch { }
            modelList.Add(model);
        }
        return modelList;
    }
    /// <summary>
    /// 获取G_District实体List
    /// </summary>
    /// <param name="dt">源数据表</param>
    /// <returns></returns>
    public List<G_District> G_District(DataTable dt)
    {
        List<G_District> modelList = new List<G_District>();
        G_District model;
        for (int n = 0; n < dt.Rows.Count; n++)
        {
            model = new G_District();
            try{
                model.d_id = (int)dt.Rows[n]["d_id"];
            }
            catch { }
            model.d_name = dt.Rows[n]["d_name"].ToString();
            try{
                model.c_id = (int)dt.Rows[n]["c_id"];
            }
            catch { }
            model.d_phone = dt.Rows[n]["d_phone"].ToString();
            try{
                model.d_examine = (bool)dt.Rows[n]["d_examine"];
            }
            catch { }
            modelList.Add(model);
        }
        return modelList;
    }
    /// <summary>
    /// 获取G_Province实体List
    /// </summary>
    /// <param name="dt">源数据表</param>
    /// <returns></returns>
    public List<G_Province> G_Province(DataTable dt)
    {
        List<G_Province> modelList = new List<G_Province>();
        G_Province model;
        for (int n = 0; n < dt.Rows.Count; n++)
        {
            model = new G_Province();
            try{
                model.p_id = (int)dt.Rows[n]["p_id"];
            }
            catch { }
            model.p_name = dt.Rows[n]["p_name"].ToString();
            model.p_phone = dt.Rows[n]["p_phone"].ToString();
            try{
                model.p_examine = (bool)dt.Rows[n]["p_examine"];
            }
            catch { }
            modelList.Add(model);
        }
        return modelList;
    }
    /// <summary>
    /// 获取G_Street实体List
    /// </summary>
    /// <param name="dt">源数据表</param>
    /// <returns></returns>
    public List<G_Street> G_Street(DataTable dt)
    {
        List<G_Street> modelList = new List<G_Street>();
        G_Street model;
        for (int n = 0; n < dt.Rows.Count; n++)
        {
            model = new G_Street();
            try{
                model.s_id = (int)dt.Rows[n]["s_id"];
            }
            catch { }
            model.s_name = dt.Rows[n]["s_name"].ToString();
            try{
                model.d_id = (int)dt.Rows[n]["d_id"];
            }
            catch { }
            model.s_phone = dt.Rows[n]["s_phone"].ToString();
            try{
                model.s_examine = (bool)dt.Rows[n]["s_examine"];
            }
            catch { }
            modelList.Add(model);
        }
        return modelList;
    }
    /// <summary>
    /// 获取G_SuperAdmin实体List
    /// </summary>
    /// <param name="dt">源数据表</param>
    /// <returns></returns>
    public List<G_SuperAdmin> G_SuperAdmin(DataTable dt)
    {
        List<G_SuperAdmin> modelList = new List<G_SuperAdmin>();
        G_SuperAdmin model;
        for (int n = 0; n < dt.Rows.Count; n++)
        {
            model = new G_SuperAdmin();
            try{
                model.sa_id = (int)dt.Rows[n]["sa_id"];
            }
            catch { }
            model.sa_uname = dt.Rows[n]["sa_uname"].ToString();
            model.sa_pwd = dt.Rows[n]["sa_pwd"].ToString();
            model.sa_tname = dt.Rows[n]["sa_tname"].ToString();
            model.a_phone = dt.Rows[n]["a_phone"].ToString();
            try{
                model.p_id = (int)dt.Rows[n]["p_id"];
            }
            catch { }
            try{
                model.c_id = (int)dt.Rows[n]["c_id"];
            }
            catch { }
            try{
                model.d_id = (int)dt.Rows[n]["d_id"];
            }
            catch { }
            try{
                model.s_id = (int)dt.Rows[n]["s_id"];
            }
            catch { }
            try{
                model.cm_id = (int)dt.Rows[n]["cm_id"];
            }
            catch { }
            model.pcdscm_address = dt.Rows[n]["pcdscm_address"].ToString();
            try{
                model.a_addtime = (DateTime)dt.Rows[n]["a_addtime"];
            }
            catch { }
            modelList.Add(model);
        }
        return modelList;
    }
    /// <summary>
    /// 获取G_SystemMessage实体List
    /// </summary>
    /// <param name="dt">源数据表</param>
    /// <returns></returns>
    public List<G_SystemMessage> G_SystemMessage(DataTable dt)
    {
        List<G_SystemMessage> modelList = new List<G_SystemMessage>();
        G_SystemMessage model;
        for (int n = 0; n < dt.Rows.Count; n++)
        {
            model = new G_SystemMessage();
            try{
                model.sm_id = (int)dt.Rows[n]["sm_id"];
            }
            catch { }
            try{
                model.smt_id = (int)dt.Rows[n]["smt_id"];
            }
            catch { }
            try{
                model.sa_id = (int)dt.Rows[n]["sa_id"];
            }
            catch { }
            model.sm_title = dt.Rows[n]["sm_title"].ToString();
            model.sm_content = dt.Rows[n]["sm_content"].ToString();
            model.sm_filename = dt.Rows[n]["sm_filename"].ToString();
            model.sm_url = dt.Rows[n]["sm_url"].ToString();
            try{
                model.sm_top = (int)dt.Rows[n]["sm_top"];
            }
            catch { }
            try{
                model.sm_examine = (bool)dt.Rows[n]["sm_examine"];
            }
            catch { }
            try{
                model.sm_addtime = (DateTime)dt.Rows[n]["sm_addtime"];
            }
            catch { }
            modelList.Add(model);
        }
        return modelList;
    }
    /// <summary>
    /// 获取G_SystemMessageType实体List
    /// </summary>
    /// <param name="dt">源数据表</param>
    /// <returns></returns>
    public List<G_SystemMessageType> G_SystemMessageType(DataTable dt)
    {
        List<G_SystemMessageType> modelList = new List<G_SystemMessageType>();
        G_SystemMessageType model;
        for (int n = 0; n < dt.Rows.Count; n++)
        {
            model = new G_SystemMessageType();
            try{
                model.smt_id = (int)dt.Rows[n]["smt_id"];
            }
            catch { }
            model.smt_name = dt.Rows[n]["smt_name"].ToString();
            modelList.Add(model);
        }
        return modelList;
    }
    /// <summary>
    /// 获取G_Type实体List
    /// </summary>
    /// <param name="dt">源数据表</param>
    /// <returns></returns>
    public List<G_Type> G_Type(DataTable dt)
    {
        List<G_Type> modelList = new List<G_Type>();
        G_Type model;
        for (int n = 0; n < dt.Rows.Count; n++)
        {
            model = new G_Type();
            try{
                model.t_id = (int)dt.Rows[n]["t_id"];
            }
            catch { }
            model.t_name = dt.Rows[n]["t_name"].ToString();
            model.t_path = dt.Rows[n]["t_path"].ToString();
            modelList.Add(model);
        }
        return modelList;
    }
    /// <summary>
    /// 获取G_User实体List
    /// </summary>
    /// <param name="dt">源数据表</param>
    /// <returns></returns>
    public List<G_User> G_User(DataTable dt)
    {
        List<G_User> modelList = new List<G_User>();
        G_User model;
        for (int n = 0; n < dt.Rows.Count; n++)
        {
            model = new G_User();
            try{
                model.u_id = (long)dt.Rows[n]["u_id"];
            }
            catch { }
            try{
                model.u_uname = (long)dt.Rows[n]["u_uname"];
            }
            catch { }
            model.u_pwd = dt.Rows[n]["u_pwd"].ToString();
            model.u_paypwd = dt.Rows[n]["u_paypwd"].ToString();
            model.u_filename = dt.Rows[n]["u_filename"].ToString();
            model.u_email = dt.Rows[n]["u_email"].ToString();
            model.u_tname = dt.Rows[n]["u_tname"].ToString();
            try{
                model.p_id = (int)dt.Rows[n]["p_id"];
            }
            catch { }
            try{
                model.c_id = (int)dt.Rows[n]["c_id"];
            }
            catch { }
            try{
                model.d_id = (int)dt.Rows[n]["d_id"];
            }
            catch { }
            try{
                model.s_id = (int)dt.Rows[n]["s_id"];
            }
            catch { }
            try{
                model.cm_id = (int)dt.Rows[n]["cm_id"];
            }
            catch { }
            model.pcdscm_address = dt.Rows[n]["pcdscm_address"].ToString();
            try{
                model.u_money = (decimal)dt.Rows[n]["u_money"];
            }
            catch { }
            try{
                model.u_examine = (bool)dt.Rows[n]["u_examine"];
            }
            catch { }
            try{
                model.u_addtime = (DateTime)dt.Rows[n]["u_addtime"];
            }
            catch { }
            modelList.Add(model);
        }
        return modelList;
    }
    /// <summary>
    /// 获取G_UserConfig实体List
    /// </summary>
    /// <param name="dt">源数据表</param>
    /// <returns></returns>
    public List<G_UserCar> G_UserCar(DataTable dt)
    {
        List<G_UserCar> modelList = new List<G_UserCar>();
        G_UserCar model;
        for (int n = 0; n < dt.Rows.Count; n++)
        {
            model = new G_UserCar();
            try{
                model.uc_id = (long)dt.Rows[n]["uc_id"];
            }
            catch { }
            try{
                model.u_id = (long)dt.Rows[n]["u_id"];
            }
            catch { }
            try{
                model.cb_id = (long)dt.Rows[n]["cb_id"];
            }
            catch { }
            model.cb_code = dt.Rows[n]["cb_code"].ToString();
            try{
                model.car_bt_id = (int)dt.Rows[n]["car_bt_id"];
            }
            catch { }
            model.uc_bt = dt.Rows[n]["uc_bt"].ToString();
            model.uc_name = dt.Rows[n]["uc_name"].ToString();
            try{
                model.car_cb_id = (int)dt.Rows[n]["car_cb_id"];
            }
            catch { }
            try{
                model.car_ct_id = (int)dt.Rows[n]["car_ct_id"];
            }
            catch { }
            model.uc_filename = dt.Rows[n]["uc_filename"].ToString();
            try{
                model.uc_examine = (bool)dt.Rows[n]["uc_examine"];
            }
            catch { }
            try{
                model.uc_addtime = (DateTime)dt.Rows[n]["uc_addtime"];
            }
            catch { }
            modelList.Add(model);
        }
        return modelList;
    }
    /// <summary>
    /// 获取G_Version实体List
    /// </summary>
    /// <param name="dt">源数据表</param>
    /// <returns></returns>
    public List<G_Version> G_Version(DataTable dt)
    {
        List<G_Version> modelList = new List<G_Version>();
        G_Version model;
        for (int n = 0; n < dt.Rows.Count; n++)
        {
            model = new G_Version();
            try{
                model.v_id = (int)dt.Rows[n]["v_id"];
            }
            catch { }
            model.v_name = dt.Rows[n]["v_name"].ToString();
            modelList.Add(model);
        }
        return modelList;
    }
    /// <summary>
    /// 获取G_Version2实体List
    /// </summary>
    /// <param name="dt">源数据表</param>
    /// <returns></returns>
    public List<G_Version2> G_Version2(DataTable dt)
    {
        List<G_Version2> modelList = new List<G_Version2>();
        G_Version2 model;
        for (int n = 0; n < dt.Rows.Count; n++)
        {
            model = new G_Version2();
            try{
                model.v2_id = (int)dt.Rows[n]["v2_id"];
            }
            catch { }
            model.v2_name = dt.Rows[n]["v2_name"].ToString();
            modelList.Add(model);
        }
        return modelList;
    }
    /// <summary>
    /// 获取LOG_SystemError实体List
    /// </summary>
    /// <param name="dt">源数据表</param>
    /// <returns></returns>
    public List<LOG_SystemError> LOG_SystemError(DataTable dt)
    {
        List<LOG_SystemError> modelList = new List<LOG_SystemError>();
        LOG_SystemError model;
        for (int n = 0; n < dt.Rows.Count; n++)
        {
            model = new LOG_SystemError();
            try{
                model.log_se_id = (int)dt.Rows[n]["log_se_id"];
            }
            catch { }
            try{
                model.t_id = (int)dt.Rows[n]["t_id"];
            }
            catch { }
            try{
                model.v_id = (int)dt.Rows[n]["v_id"];
            }
            catch { }
            try{
                model.log_se_stype = (int)dt.Rows[n]["log_se_stype"];
            }
            catch { }
            model.log_se_content = dt.Rows[n]["log_se_content"].ToString();
            model.log_se_type = dt.Rows[n]["log_se_type"].ToString();
            model.log_se_information = dt.Rows[n]["log_se_information"].ToString();
            try{
                model.log_se_addtime = (DateTime)dt.Rows[n]["log_se_addtime"];
            }
            catch { }
            modelList.Add(model);
        }
        return modelList;
    }
    /// <summary>
    /// 获取PAY_IdCard实体List
    /// </summary>
    /// <param name="dt">源数据表</param>
    /// <returns></returns>
    public List<PAY_IdCard> PAY_IdCard(DataTable dt)
    {
        List<PAY_IdCard> modelList = new List<PAY_IdCard>();
        PAY_IdCard model;
        for (int n = 0; n < dt.Rows.Count; n++)
        {
            model = new PAY_IdCard();
            try{
                model.pay_ic_id = (long)dt.Rows[n]["pay_ic_id"];
            }
            catch { }
            try{
                model.u_id = (long)dt.Rows[n]["u_id"];
            }
            catch { };
            try{
                model.pay_ic_pid = (long)dt.Rows[n]["pay_ic_pid"];
            }
            catch { };
            try{
                model.p_id = (int)dt.Rows[n]["p_id"];
            }
            catch { }
            try{
                model.c_id = (int)dt.Rows[n]["c_id"];
            }
            catch { }
            try{
                model.d_id = (int)dt.Rows[n]["d_id"];
            }
            catch { }
            try{
                model.s_id = (int)dt.Rows[n]["s_id"];
            }
            catch { }
            try{
                model.cm_id = (int)dt.Rows[n]["cm_id"];
            }
            catch { }
            model.pcdscm_address = dt.Rows[n]["pcdscm_address"].ToString();
            try{
                model.pay_ic_addtime = (DateTime)dt.Rows[n]["pay_ic_addtime"];
            }
            catch { }
            modelList.Add(model);
        }
        return modelList;
    }
    /// <summary>
    /// 获取User_CollectClip实体List
    /// </summary>
    /// <param name="dt">源数据表</param>
    /// <returns></returns>
    public List<User_CollectClip> User_CollectClip(DataTable dt)
    {
        List<User_CollectClip> modelList = new List<User_CollectClip>();
        User_CollectClip model;
        for (int n = 0; n < dt.Rows.Count; n++)
        {
            model = new User_CollectClip();
            try{
                model.user_cc_id = (long)dt.Rows[n]["user_cc_id"];
            }
            catch { }
            try{
                model.cs_id = (long)dt.Rows[n]["cs_id"];
            }
            catch { }
            try{
                model.u_id = (long)dt.Rows[n]["u_id"];
            }
            catch { }
            try{
                model.user_cc_addtime = (DateTime)dt.Rows[n]["user_cc_addtime"];
            }
            catch { }
            modelList.Add(model);
        }
        return modelList;
    }
    /// <summary>
    /// 获取User_SystemMessage实体List
    /// </summary>
    /// <param name="dt">源数据表</param>
    /// <returns></returns>
    public List<User_SystemMessage> User_SystemMessage(DataTable dt)
    {
        List<User_SystemMessage> modelList = new List<User_SystemMessage>();
        User_SystemMessage model;
        for (int n = 0; n < dt.Rows.Count; n++)
        {
            model = new User_SystemMessage();
            try{
                model.user_sm_id = (long)dt.Rows[n]["user_sm_id"];
            }
            catch { }
            try{
                model.sm_id = (int)dt.Rows[n]["sm_id"];
            }
            catch { }
            try{
                model.u_id = (long)dt.Rows[n]["u_id"];
            }
            catch { }
            try{
                model.user_sm_isred = (bool)dt.Rows[n]["user_sm_isred"];
            }
            catch { }
            try
            {
                model.user_sm_isdel = (bool)dt.Rows[n]["user_sm_isdel"];
            }
            catch { }
            try{
                model.user_sm_addtime = (DateTime)dt.Rows[n]["user_sm_addtime"];
            }
            catch { }
            modelList.Add(model);
        }
        return modelList;
    }
    /// <summary>
    /// 获取CAR_BelongsTo实体List
    /// </summary>
    /// <param name="dt">源数据表</param>
    /// <returns></returns>
    public List<CAR_BelongsTo> CAR_BelongsTo(DataTable dt)
    {
        List<CAR_BelongsTo> modelList = new List<CAR_BelongsTo>();
        CAR_BelongsTo model;
        for (int n = 0; n < dt.Rows.Count; n++)
        {
            model = new CAR_BelongsTo();
            try{
                model.car_bt_id = (int)dt.Rows[n]["car_bt_id"];
            }
            catch { }
            model.car_bt_name = dt.Rows[n]["car_bt_name"].ToString();
            model.car_bt_allname = dt.Rows[n]["car_bt_allname"].ToString();
            modelList.Add(model);
        }
        return modelList;
    }
    /// <summary>
    /// 获取PAY_Alipay实体List
    /// </summary>
    /// <param name="dt">源数据表</param>
    /// <returns></returns>
    public List<PAY_Alipay> PAY_Alipay(DataTable dt)
    {
        List<PAY_Alipay> modelList = new List<PAY_Alipay>();
        PAY_Alipay model;
        for (int n = 0; n < dt.Rows.Count; n++)
        {
            model = new PAY_Alipay();
            try
            {
                model.pay_a_id = (long)dt.Rows[n]["pay_a_id"];
            }
            catch { }
            try
            {
                model.u_id = (long)dt.Rows[n]["u_id"];
            }
            catch { }
            try
            {
                model.u_uname = (long)dt.Rows[n]["u_uname"];
            }
            catch { }
            try
            {
                model.notify_time = (DateTime)dt.Rows[n]["notify_time"];
            }
            catch { }
            model.notify_type = dt.Rows[n]["notify_type"].ToString();
            model.notify_id = dt.Rows[n]["notify_id"].ToString();
            model.sign_type = dt.Rows[n]["sign_type"].ToString();
            model.sign = dt.Rows[n]["sign"].ToString();
            try
            {
                model.out_trade_no = (long)dt.Rows[n]["out_trade_no"];
            }
            catch { }
            model.subject = dt.Rows[n]["subject"].ToString();
            model.payment_type = dt.Rows[n]["payment_type"].ToString();
            model.trade_no = dt.Rows[n]["trade_no"].ToString();
            model.trade_status = dt.Rows[n]["trade_status"].ToString();
            model.seller_id = dt.Rows[n]["seller_id"].ToString();
            model.seller_email = dt.Rows[n]["seller_email"].ToString();
            model.buyer_id = dt.Rows[n]["buyer_id"].ToString();
            model.buyer_email = dt.Rows[n]["buyer_email"].ToString();
            try
            {
                model.total_fee = (decimal)dt.Rows[n]["total_fee"];
            }
            catch { }
            try
            {
                model.gmt_create = (DateTime)dt.Rows[n]["gmt_create"];
            }
            catch { }
            try
            {
                model.gmt_payment = (DateTime)dt.Rows[n]["gmt_payment"];
            }
            catch { }
            model.is_total_fee_adjust = dt.Rows[n]["is_total_fee_adjust"].ToString();
            model.use_coupon = dt.Rows[n]["use_coupon"].ToString();
            try
            {
                model.discount = (decimal)dt.Rows[n]["discount"];
            }
            catch { }
            model.refund_status = dt.Rows[n]["refund_status"].ToString();
            try{
                model.gmt_refund = (DateTime)dt.Rows[n]["gmt_refund"];
            }
            catch { }
            try{
                model.quantity = (int)dt.Rows[n]["quantity"];
            }
            catch { }
            try{
                model.price = (decimal)dt.Rows[n]["price"];
            }
            catch { }
            model.body = dt.Rows[n]["body"].ToString();
            try{
                model.pay_a_addtime = (DateTime)dt.Rows[n]["pay_a_addtime"];
            }
            catch { }
            model.notify_url = dt.Rows[n]["notify_url"].ToString();
            modelList.Add(model);
        }
        return modelList;
    }
    /// <summary>
    /// 获取PAY_TransactionRecord实体List
    /// </summary>
    /// <param name="dt">源数据表</param>
    /// <returns></returns>
    public List<PAY_TransactionRecord> PAY_TransactionRecord(DataTable dt)
    {
        List<PAY_TransactionRecord> modelList = new List<PAY_TransactionRecord>();
        PAY_TransactionRecord model;
        for (int n = 0; n < dt.Rows.Count; n++)
        {
            model = new PAY_TransactionRecord();
            try{
                model.pay_tr_id = (long)dt.Rows[n]["pay_tr_id"];
            }
            catch { }
            try{
                model.u_id = (long)dt.Rows[n]["u_id"];
            }
            catch { }
            try{
                model.pay_trt_id = (int)dt.Rows[n]["pay_trt_id"];
            }
            catch { }
            try{
                model.pay_trf_id = (int)dt.Rows[n]["pay_trf_id"];
            }
            catch { }
            try{
                model.pay_tr_money = (decimal)dt.Rows[n]["pay_tr_money"];
            }
            catch { }
            try{
                model.pay_tr_addtime = (DateTime)dt.Rows[n]["pay_tr_addtime"];
            }
            catch { }
            modelList.Add(model);
        }
        return modelList;
    }
    /// <summary>
    /// 获取PAY_TRFrom实体List
    /// </summary>
    /// <param name="dt">源数据表</param>
    /// <returns></returns>
    public List<PAY_TRFrom> PAY_TRFrom(DataTable dt)
    {
        List<PAY_TRFrom> modelList = new List<PAY_TRFrom>();
        PAY_TRFrom model;
        for (int n = 0; n < dt.Rows.Count; n++)
        {
            model = new PAY_TRFrom();
            try{
                model.pay_trf_id = (int)dt.Rows[n]["pay_trf_id"];
            }
            catch { }
            model.pay_trf_name = dt.Rows[n]["pay_trf_name"].ToString();
            modelList.Add(model);
        }
        return modelList;
    }
    /// <summary>
    /// 获取PAY_TRType实体List
    /// </summary>
    /// <param name="dt">源数据表</param>
    /// <returns></returns>
    public List<PAY_TRType> PAY_TRType(DataTable dt)
    {
        List<PAY_TRType> modelList = new List<PAY_TRType>();
        PAY_TRType model;
        for (int n = 0; n < dt.Rows.Count; n++)
        {
            model = new PAY_TRType();
            try{
                model.pay_trt_id = (int)dt.Rows[n]["pay_trt_id"];
            }
            catch { }
            model.pay_trt_name = dt.Rows[n]["pay_trt_name"].ToString();
            modelList.Add(model);
        }
        return modelList;
    }

	/*
	/// <summary>
	/// 获取G_Type实体List
	/// </summary>
	/// <param name="dt">源数据表</param>
	/// <returns></returns>
	public List<G_Type> G_Type(DataTable dt)
	{
		List<G_Type> modelList = new List<G_Type>();
		G_Type model;
		for (int n = 0; n < dt.Rows.Count; n++)
		{
			model = new G_Type();
			
			modelList.Add(model);
		}
		return modelList;
	}
	*/
}
