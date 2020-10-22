using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FIXED_ASSET.DAL;
using POSX.Utilities;

namespace FIXED_ASSET.Controllers
{
    public class ReportController : Controller
    {
        BasicUtilities _BasicUtilities = new BasicUtilities();
        ReportDAL _Report = new ReportDAL();
        // GET: Report
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Outlet_Wise_Aset_Details_Report()
        {

            if (Session[POSxSession.LoggedUser] == null)
            {
                return Redirect("/User/Login");
            }
         //   string _Created_By = GetLoggedUserID();


            //  bool _Parmited = isPageParmited(_Created_By);
            //if (!_Parmited)
            //{
            //    return Redirect("/Home/");
            //}

            ViewBag.Title = "Asset Details Report";
            ViewBag.ReportName = "Asset Details Report";
            ViewBag.ChannelReport = true;
            ViewBag.MonthWise_Sales = false;
            ViewBag.TopArticle = false;
            ViewBag.OutletWiseChannelReport = false;
            return View();

        }
        public ActionResult Department_User_Wise_Asset_List_Report()
        {

            if (Session[POSxSession.LoggedUser] == null)
            {
                return Redirect("/User/Login");
            }
            //   string _Created_By = GetLoggedUserID();


            //  bool _Parmited = isPageParmited(_Created_By);
            //if (!_Parmited)
            //{
            //    return Redirect("/Home/");
            //}

            ViewBag.Title = "Department User Wise Asset List";
            ViewBag.ReportName = "Department Use Wise Asset List";
            ViewBag.ChannelReport = true;
            ViewBag.MonthWise_Sales = false;
            ViewBag.TopArticle = false;
            ViewBag.OutletWiseChannelReport = false;
            return View();

        }

        public ActionResult Unit_Wise_Agreement_Report()
        {

            if (Session[POSxSession.LoggedUser] == null)
            {
                return Redirect("/User/Login");
            }
            //   string _Created_By = GetLoggedUserID();


            //  bool _Parmited = isPageParmited(_Created_By);
            //if (!_Parmited)
            //{
            //    return Redirect("/Home/");
            //}

            ViewBag.Title = "Unit Wise Agreement Report";
            ViewBag.ReportName = "Unit Wise Agreement Report";
            ViewBag.ChannelReport = true;
            ViewBag.MonthWise_Sales = false;
            ViewBag.TopArticle = false;
            ViewBag.OutletWiseChannelReport = false;
            return View();

        }
        [HttpPost]
        public JsonResult Outlet_Wise_Aset_Details(string _outletSelect, string _ClassList)

        {
            //ViewBag.ReportViewer = MakeAccountDetailsInfoReport(_StartDt, _EndDt, _CustomerList, _HdnStartDt, _HdnEndDt, _HdnCustomerList);
            //  ViewBag.menuList = HomeController.globalMenuList;
            //  return View("_ReportViewer");
            //string _Created_By = GetLoggedUserID();
            //return Json(true);
            try
            {
                //Session["StartDt"] = null;
                //Session["EndDt"] = null;
                //Session["Customer"] = null;
                DataTable _Outlet_Wise_Asset_Report = new DataTable();

                _Outlet_Wise_Asset_Report = _Report.Outlet_Wise_Asset_Details_Report(_outletSelect, _ClassList);
                Session[POSxSession.Report_Name] = "Outlet_Wise_Asset_Details_Report";

                Session[POSxSession.Outlet_Wise_Asset_Details_Report] = _Outlet_Wise_Asset_Report;
                //Session["StartDt"] = _StartDt;
                //Session["EndDt"] = _EndDt;
                //Session["Customer"] = _CustomerList;

                return Json(true);
            }
            catch (Exception)
            {

                return Json(false);

            }
        }
        [HttpPost]
        public JsonResult Department_User_Wise_Asset_List(string _department_Id, string _user_Code)

        {
           
            try
            {
               
                DataTable _Department_User_Wise_Asset_List_Report = new DataTable();

                _Department_User_Wise_Asset_List_Report = _Report.Department_User_Wise_Asset_List_Report(_department_Id, _user_Code);
                Session[POSxSession.Report_Name] = "Department_User_Wise_Asset_List_Report";

                Session[POSxSession.Department_User_Wise_Asset_List_Report] = _Department_User_Wise_Asset_List_Report;
                
                return Json(true);
            }
            catch (Exception)
            {

                return Json(false);

            }
        }
        [HttpPost]
        public JsonResult Unit_Wise_Agreement_Report(string _ProjectList, string _UnitList,string _AgreementList)

        {

            try
            {

                DataTable _Unit_Wise_Agreement_Report = new DataTable();

                _Unit_Wise_Agreement_Report = _Report.Unit_Wise_Agreement_Report(_ProjectList, _UnitList, _AgreementList);
                Session[POSxSession.Report_Name] = "Unit_Wise_Agreement_Report";

                Session[POSxSession.Unit_Wise_Agreement_Report] = _Unit_Wise_Agreement_Report;

                return Json(true);
            }
            catch (Exception)
            {


                return Json(false);

            }
        }
    }
}