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
    public class RentHomeController : BaseController
    {
		BasicUtilities _BasicUtilities = new BasicUtilities();
		DashboardDAL _Dashboard = new DashboardDAL();
		
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
                var dtVAT = _Dashboard.VAT();
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
                if (dtVAT.Rows.Count > 0)
                {
                    DataRow row = dtVAT.Rows[0];

                    ViewBag.Total_VAT = row["Total_VAT"].ToString();
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


        [HttpPost]
        public JsonResult MONTH_WISE_RENT(string _FrmDate)

        {

            DataTable dt_AREA_ORG_ART_MARGIN = _Dashboard.MONTH_WISE_RENT(_FrmDate);
            List<Dictionary<string, object>> _AREA_ORG_ART_MARGIN = _BasicUtilities.GetTableRows(dt_AREA_ORG_ART_MARGIN);

            return Json(new { Currentdata = _AREA_ORG_ART_MARGIN }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult RENT_NOTICE_PERIOD(string _vYear,string _vMonth)

        {

            DataTable dt_AREA_ORG_ART_MARGIN = _Dashboard.RENT_NOTICE_PERIOD(_vYear, _vMonth);
            List<Dictionary<string, object>> _AREA_ORG_ART_MARGIN = _BasicUtilities.GetTableRows(dt_AREA_ORG_ART_MARGIN);

            return Json(new { Currentdata = _AREA_ORG_ART_MARGIN }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult RENT_AGREEMENT_NOTICE_PERIOD(string _vYear, string _vMonth)

        {

            DataTable dt_AREA_ORG_ART_MARGIN = _Dashboard.RENT_AGREEMENT_NOTICE_PERIOD(_vYear, _vMonth);
            List<Dictionary<string, object>> _AREA_ORG_ART_MARGIN = _BasicUtilities.GetTableRows(dt_AREA_ORG_ART_MARGIN);

            return Json(new { Currentdata = _AREA_ORG_ART_MARGIN }, JsonRequestBehavior.AllowGet);
        }
    }
}