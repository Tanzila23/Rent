using FIXED_ASSET.DAL;
using POSX.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FIXED_ASSET.Controllers
{
    public class HomeController : BaseController
    {
		BasicUtilities _BasicUtilities = new BasicUtilities();
		DashboardDAL _Dashboard = new DashboardDAL();
		// DeviceInfo DV = new DeviceInfo();
		//public static string _Created_By = "";
		public ActionResult Index()
		{
			if (Session[POSxSession.LoggedUser] == null)
			{
				return Redirect("/User/Login");
			}
			else
			{
				var dtMain = _Dashboard.MainAsset();
				var dtPERIPHERAL = _Dashboard.PERIPHERAL();
				var dtCOMPONENT = _Dashboard.COMPONENT();

				if (dtMain.Rows.Count > 0)
				{
					DataRow row = dtMain.Rows[0];

					ViewBag.MainAsset = row["TOTAL_ASSET"].ToString();
				}

				if (dtPERIPHERAL.Rows.Count > 0)
				{
					DataRow row = dtPERIPHERAL.Rows[0];

					ViewBag.TOTAL_PERIPHERAL = row["TOTAL_PERIPHERAL"].ToString();
				}

				if (dtCOMPONENT.Rows.Count > 0)
				{
					DataRow row = dtCOMPONENT.Rows[0];

					ViewBag.TOTAL_COMPONENT = row["TOTAL_COMPONENT"].ToString();
				}

				return View();
			}
		}

        public ActionResult RentIndex()
        {
            if (Session[POSxSession.LoggedUser] == null)
            {
                return Redirect("/User/Login");
            }
            else
            {
                var dtMain = _Dashboard.MainAsset();
                var dtRent = _Dashboard.RENT();
                var dtTax = _Dashboard.Tax();
                var dtAIT = _Dashboard.AIT();
                var dtCOMPONENT = _Dashboard.COMPONENT();
                var dtOutlet = _Dashboard.Outlet();

                if (dtMain.Rows.Count > 0)
                {
                    DataRow row = dtMain.Rows[0];

                    ViewBag.MainAsset = row["TOTAL_ASSET"].ToString();
                }

                if (dtRent.Rows.Count > 0)
                {
                    DataRow row = dtRent.Rows[0];

                    ViewBag.Total_Rent = row["Total_Rent"].ToString();
                }
                if (dtTax.Rows.Count > 0)
                {
                    DataRow row = dtTax.Rows[0];

                    ViewBag.Total_Tax = row["Total_Tax"].ToString();
                }
                if (dtAIT.Rows.Count > 0)
                {
                    DataRow row = dtAIT.Rows[0];

                    ViewBag.Total_AIT = row["Total_AIT"].ToString();
                }
                if (dtCOMPONENT.Rows.Count > 0)
                {
                    DataRow row = dtCOMPONENT.Rows[0];

                    ViewBag.TOTAL_COMPONENT = row["TOTAL_COMPONENT"].ToString();
                }
                if (dtOutlet.Rows.Count > 0)
                {
                    DataRow row = dtOutlet.Rows[0];

                    ViewBag.TOTAL_OUTLET = row["TOTAL_OUTLET"].ToString();
                }

                return View();
            }
        }
        //[HttpPost]
        //public ActionResult Get_Dashboard_Sales_Summary()
        //{
        //	if (Session[POSxSession.LoggedUser] == null)
        //	{
        //		return Redirect("/User/Login");
        //	}
        //	try
        //	{
        //		string _Created_By = GetLoggedUserID();
        //		int _BusinessUnit_ID = GetBusinessUnit_ID();

        //		// USP_Dashboard_Sales_Summary
        //		DataTable _DashboardList = _Dashboard.Dashboard_Sales_Summary(_BusinessUnit_ID, _Created_By);
        //		List<Dictionary<string, object>> DashboardList = _BasicUtilities.GetTableRows(_DashboardList);
        //		//   return Json(DashboardList);
        //		return Json(new { FirstList = DashboardList }, JsonRequestBehavior.AllowGet);
        //	}
        //	catch (Exception ex)
        //	{
        //		return Json(ex.Message);
        //	}
        //}

        //[HttpPost]
        //public ActionResult Get_Outlet_Daily_Closing(string _StartDate, string _EndDate)
        //{
        //	if (Session[POSxSession.LoggedUser] == null)
        //	{
        //		return Redirect("/User/Login");
        //	}
        //	try
        //	{
        //		string _Created_By = GetLoggedUserID();
        //		int _BusinessUnit_ID = GetBusinessUnit_ID();
        //		DataTable Outlet_Daily_List = _Dashboard.Outlet_Daily_Closing(_BusinessUnit_ID, _StartDate, _EndDate);
        //		List<Dictionary<string, object>> _Outlet_Daily_List = _BasicUtilities.GetTableRows(Outlet_Daily_List);

        //		DataTable dt_Outlet_Daily_Closing = new DataTable();
        //		dt_Outlet_Daily_Closing.Clear();
        //		dt_Outlet_Daily_Closing.Columns.Add("Category");
        //		dt_Outlet_Daily_Closing.Columns.Add("Sold_Quantity");
        //		dt_Outlet_Daily_Closing.Columns.Add("Net_Amount");
        //		foreach (DataRow row in Outlet_Daily_List.Rows)
        //		{
        //			DataRow rows = dt_Outlet_Daily_Closing.NewRow();
        //			rows["Category"] = row["Category"].ToString(); // want to use form.XYZ?
        //			rows["Sold_Quantity"] = row["Sold_Quantity"].ToString();
        //			rows["Net_Amount"] = row["Net_Amount"].ToString();
        //			dt_Outlet_Daily_Closing.Rows.Add(rows);
        //		}
        //		List<Dictionary<string, object>> Outlet_Daily_ClosingList = _BasicUtilities.GetTableRows(dt_Outlet_Daily_Closing);
        //		return Json(new { FirstList = Outlet_Daily_ClosingList }, JsonRequestBehavior.AllowGet);
        //	}
        //	catch (Exception ex)
        //	{
        //		return Json(ex.Message);
        //	}
        //}

        ////[HttpPost]
        ////public ActionResult Get_Retail_Margin_LINECHART()
        ////{
        ////    if (Session[POSxSession.LoggedUser] == null)
        ////    {
        ////        return Redirect("/User/Login");
        ////    }
        ////    try
        ////    {
        ////        _Created_By = GetLoggedUserID();
        ////        DataTable dt_Retail_Margin = _Dashboard.Get_Retail_Margin_LINECHART(1);
        ////        List<Dictionary<string, object>> _Outlet_Daily_List = _BasicUtilities.GetTableRows(dt_Retail_Margin);

        ////        return Json(new { FirstList = _Outlet_Daily_List }, JsonRequestBehavior.AllowGet);
        ////    }
        ////    catch (Exception ex)
        ////    {

        ////        return Json(ex.Message);
        ////    }
        ////}


        //[HttpPost]
        //public ActionResult Get_Retail_Margin_LINECHART(string _FrmDate, string _ToDate)
        //{
        //	if (Session[POSxSession.LoggedUser] == null)
        //	{
        //		return Redirect("/User/Login");
        //	}
        //	try
        //	{
        //		string _Created_By = GetLoggedUserID();
        //		int _BusinessUnit_ID = GetBusinessUnit_ID();
        //		DataTable dt_Dashboard = _Dashboard.Get_Retail_Margin_LINECHART(_FrmDate, _ToDate, 1);
        //		DataTable dt_SalesTrend = _Dashboard.Get_Retail_Margin_LINECHART(_FrmDate, _ToDate, 2);

        //		//--------------------------------------
        //		List<Dictionary<string, object>> _SalesTrend = _BasicUtilities.GetTableRows(dt_SalesTrend);
        //		List<Dictionary<string, object>> dt_Dashboard_List = _BasicUtilities.GetTableRows(dt_Dashboard);
        //		return Json(new { First = _SalesTrend, Second = dt_Dashboard_List }, JsonRequestBehavior.AllowGet);
        //	}
        //	catch (Exception ex)
        //	{
        //		return Json(ex.Message);
        //	}
        //}

        //[HttpPost]
        //public ActionResult Get_Dashboard_Stockfigure()
        //{
        //	int _BusinessUnit_ID = GetBusinessUnit_ID();
        //	DataTable dt_totalStock = _Dashboard.Get_Dashboard_Stockfigure(_BusinessUnit_ID, 0, 1);
        //	List<Dictionary<string, object>> _totalStock_List = _BasicUtilities.GetTableRows(dt_totalStock);
        //	return Json(_totalStock_List);
        //}

        //[HttpPost]
        //public ActionResult Get_Channel_Dashboard_Stockfigure()
        //{
        //	int _BusinessUnit_ID = GetBusinessUnit_ID();
        //	DataTable dt_allChannelStock = _Dashboard.Get_Dashboard_Stockfigure(_BusinessUnit_ID, 0, 0);
        //	List<Dictionary<string, object>> _allChannelStock_List = _BasicUtilities.GetTableRows(dt_allChannelStock);
        //	return Json(_allChannelStock_List);
        //}

        //[HttpPost]
        //public ActionResult Get_Dashboard_Dlvfigure()
        //{
        //	int _BusinessUnit_ID = GetBusinessUnit_ID();
        //	DataTable dt_totalStock = _Dashboard.Get_Dashboard_Dlvfigure(_BusinessUnit_ID, 0, 0);
        //	List<Dictionary<string, object>> _totalStock_List = _BasicUtilities.GetTableRows(dt_totalStock);
        //	return Json(_totalStock_List);
        //}

        //[HttpPost]
        //public ActionResult Get_Channel_Dashboard_Dlvfigure()
        //{
        //	int _BusinessUnit_ID = GetBusinessUnit_ID();
        //	DataTable dt_totalStock = _Dashboard.Get_Dashboard_Dlvfigure(_BusinessUnit_ID, 0, 1);
        //	List<Dictionary<string, object>> _totalStock_List = _BasicUtilities.GetTableRows(dt_totalStock);
        //	return Json(_totalStock_List);
        //}

        //[HttpPost]
        //public ActionResult Get_Dashboard_Rcvfigure()
        //{
        //	int _BusinessUnit_ID = GetBusinessUnit_ID();
        //	DataTable dt_totalStock = _Dashboard.Get_Dashboard_Rcvfigure(_BusinessUnit_ID, 0, 0);
        //	List<Dictionary<string, object>> _totalStock_List = _BasicUtilities.GetTableRows(dt_totalStock);
        //	return Json(_totalStock_List);
        //}

        //[HttpPost]
        //public ActionResult Get_Channel_Dashboard_Rcvfigure()
        //{
        //	int _BusinessUnit_ID = GetBusinessUnit_ID();
        //	DataTable dt_totalStock = _Dashboard.Get_Dashboard_Rcvfigure(_BusinessUnit_ID, 0, 1);
        //	List<Dictionary<string, object>> _totalStock_List = _BasicUtilities.GetTableRows(dt_totalStock);
        //	return Json(_totalStock_List);
        //}

        ////RPT_DASHBOARD_STOCKFIGURECAT
        //[HttpPost]
        //public ActionResult Get_Dashboard_Stock_Figure_Category(int _Channel)
        //{
        //	int _BusinessUnit_ID = GetBusinessUnit_ID();
        //	var list = _Dashboard.Get_Dashboard_Stock_Figure(_BusinessUnit_ID, _Channel, 0);
        //	List<Dictionary<string, object>> _totalStock_List = _BasicUtilities.GetTableRows(list);
        //	return Json(_totalStock_List);
        //}

        ////[HttpPost]
        ////public JsonResult BarChart()
        ////{
        ////	var barChartModel = new ChartModel<int>
        ////	{
        ////		XAxisCategories = new string[] { "Africa", "America", "Asia", "Europe", "Oceania" },
        ////		XAxisTitle = "Region",
        ////		YAxisTitle = "Population (millions)",
        ////		YAxisTooltipValueSuffix = " millions",
        ////		Series = new List<SeriesModel<int>> {
        ////			new SeriesModel<int>{ name = "Year 1800", data = new int[]{ 107, 31, 635, 203, 2 }},
        ////			new SeriesModel<int>{ name = "Year 1900", data = new int[]{ 133, 156, 947, 408, 6 }},
        ////			new SeriesModel<int>{ name = "Year 2012", data = new int[]{ 1052, 954, 4250, 740, 38 }}
        ////		}
        ////	};

        ////	return Json(barChartModel, JsonRequestBehavior.AllowGet);
        ////}


        //[HttpPost]
        //public JsonResult ChanelList()
        //{
        //	try
        //	{
        //		string _Msg;
        //		DataTable dt_ChannelList = _Dashboard.GetChannelList();

        //		if (dt_ChannelList.Rows.Count > 0)
        //		{
        //			_Msg = "DONE";
        //			List<Dictionary<string, object>> _ChannelList = _BasicUtilities.GetTableRows(dt_ChannelList);
        //			return Json(_ChannelList);
        //		}
        //		else
        //		{
        //			_Msg = "ERROR";
        //			return Json(_Msg);
        //		}
        //	}
        //	catch (Exception ex)
        //	{
        //		return Json(ex.Message);

        //	}
        //}

        //[HttpPost]
        //public ActionResult Get_Dashboard_Order_Delivery_Status(int _Channel, string _Start_Date, string _End_Date)
        //{
        //	var list = _Dashboard.Get_Dashboard_Order_Delivery_Status(_Channel, _Start_Date, _End_Date);
        //	List<Dictionary<string, object>> _totalStock_List = _BasicUtilities.GetTableRows(list);
        //	return Json(_totalStock_List);
        //}


    }
}