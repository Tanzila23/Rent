using FIXED_ASSET.DAL;
using FIXED_ASSET.DTO;
using POSX.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.IO;
using System.Globalization;

namespace FIXED_ASSET.Controllers
{
    public class AssetCategoryController : BaseController
    {
        
        UserDAL userDAL = new UserDAL();
        ReportDAL _Report = new ReportDAL();
        CategoryDTO categoryDTO = new CategoryDTO();
        ClassificationDAL classificationDAL = new ClassificationDAL();
        BasicUtilities _BasicUtilities = new BasicUtilities();
        // GET: AssetCategory
        public ActionResult View()
        {
            if (Session[POSxSession.LoggedUser] == null)
            {
                return Redirect("/User/Login");
            }
            else
            {
                return View("~/Views/Category/View.cshtml");
            }
        }
        public ActionResult AssetCategory()
        {
            if (Session[POSxSession.LoggedUser] == null)
            {
                return Redirect("/User/Login");
            }
            else
            {
                return View("~/Views/Category/AssetCategory.cshtml");
            }
        }
        public ActionResult Segment()
        {
            if (Session[POSxSession.LoggedUser] == null)
            {
                return Redirect("/User/Login");
            }
            else
            {
                return View("~/Views/Category/Segment.cshtml");
            }
        }
        public ActionResult Manufacture()
        {
            if (Session[POSxSession.LoggedUser] == null)
            {
                return Redirect("/User/Login");
            }
            else
            {
                // DataTable dtTeacherGridInfo = new DataTable();
                ViewBag.ManufactureGridList = classificationDAL.GetManufacture();
                return View("~/Views/Category/Manufacture.cshtml");

            }
        }
        public ActionResult Supplier()
        {
            if (Session[POSxSession.LoggedUser] == null)
            {
                return Redirect("/User/Login");
            }
            else
            {
                return View("~/Views/Category/Supplier.cshtml");
            }
        }
        public ActionResult AllSupplier()
        {
            if (Session[POSxSession.LoggedUser] == null)
            {
                return Redirect("/User/Login");
            }
            else
            {
                return View("~/Views/Category/AllSupplier.cshtml");
            }
        }
        public ActionResult AssestSupplier()
        {
            if (Session[POSxSession.LoggedUser] == null)
            {
                return Redirect("/User/Login");
            }
            else
            {
                return View("~/Views/Category/AssestSupplier.cshtml");
            }
        }
        public ActionResult Model()
        {
            if (Session[POSxSession.LoggedUser] == null)
            {
                return Redirect("/User/Login");
            }
            else
            {
                return View("~/Views/Category/Model.cshtml");
            }
        }
        public ActionResult AssetItem()
        {
            if (Session[POSxSession.LoggedUser] == null)
            {
                return Redirect("/User/Login");
            }
            else
            {
                return View("~/Views/Category/AssetItem.cshtml");
            }
        }
        public ActionResult BillOfMaterial()
        {
            if (Session[POSxSession.LoggedUser] == null)
            {
                return Redirect("/User/Login");
            }
            else
            {
                //  ViewBag.ComponentGridList = classificationDAL.GetComponent();
                return View("~/Views/Category/BillOfMaterial.cshtml");
            }
        }
        public ActionResult Component()
        {
            if (Session[POSxSession.LoggedUser] == null)
            {
                return Redirect("/User/Login");
            }
            else
            {
                return View("~/Views/Category/Component.cshtml");
            }
        }
        public ActionResult Peripheral()
        {
            if (Session[POSxSession.LoggedUser] == null)
            {
                return Redirect("/User/Login");
            }
            else
            {
                return View("~/Views/Category/Peripheral.cshtml");
            }
        }
        public ActionResult AssetIndex()
        {
            if (Session[POSxSession.LoggedUser] == null)
            {
                return Redirect("/User/Login");
            }
            else
            {
                return View("~/Views/Category/AssetIndex.cshtml");
            }
        }
        public ActionResult AssetChildIndex()
        {
            if (Session[POSxSession.LoggedUser] == null)
            {
                return Redirect("/User/Login");
            }
            else
            {
                return View("~/Views/Category/AssetChildIndex.cshtml");
            }
        }
        public ActionResult AssetChildIndexDetailsView()
        {
            if (Session[POSxSession.LoggedUser] == null)
            {
                return Redirect("/User/Login");
            }
            else
            {
                return View("~/Views/Category/AssetChildIndexDetailsView.cshtml");
            }
        }
        public ActionResult AssetDetailsEdit()
        {
            if (Session[POSxSession.LoggedUser] == null)
            {
                return Redirect("/User/Login");
            }
            else
            {
                return View("~/Views/Category/AssetDetailsEdit.cshtml");
            }
        }
        public ActionResult LocationDepartment()
        {
            if (Session[POSxSession.LoggedUser] == null)
            {
                return Redirect("/User/Login");
            }
            else
            {
                return View("~/Views/Category/LocationDepartment.cshtml");
            }
        }
        public ActionResult PeripheralComponetUpdate()
        {
            if (Session[POSxSession.LoggedUser] == null)
            {
                return Redirect("/User/Login");
            }
            else
            {
                return View("~/Views/Category/PeripheralComponetUpdate.cshtml");
            }
        }
        public ActionResult AssetTransfer()
        {
            if (Session[POSxSession.LoggedUser] == null)
            {
                return Redirect("/User/Login");
            }
            else
            {
                return View("~/Views/Category/AssetTransfer.cshtml");
            }
        }
         public ActionResult AssetDetails()
        {
            if (Session[POSxSession.LoggedUser] == null)
            {
                return Redirect("/User/Login");
            }
            else
            {
                return View("~/Views/Category/AssetDetails.cshtml");
            }
        }
        public ActionResult AgreementSlot()
        {
            if (Session[POSxSession.LoggedUser] == null)
            {
                return Redirect("/User/Login");
            }
            else
            {
                return View("~/Views/Category/AgreementSlot.cshtml");
            }
        }

        public ActionResult RentPayee()
        {
            if (Session[POSxSession.LoggedUser] == null)
            {
                return Redirect("/User/Login");
            }
            else
            {
                Session["ProjectId"] = null;
                Session["UnitId"] = null;
                Session["LandlordId"] = null;
                Session["ProjectName"] = null;
                Session["UnitName"] = null;
                Session["LandlordName"] = null;
                var landId = Convert.ToInt32(Session["RentPayeeInfoDetailsView"]);
                List<ViewRentPayeeDTO> dataGet = new List<ViewRentPayeeDTO>();
                ViewRentPayeeDTO data = new ViewRentPayeeDTO();
                if (!string.IsNullOrEmpty(landId.ToString()))
                {
                    dataGet = classificationDAL.GetShareRentPayee(landId);
                    if (dataGet.Count > 0)
                    {
                        data = dataGet.FirstOrDefault();
                        Session["ProjectId"] = (string)data.PROJECT_ID;
                        Session["UnitId"] = (string)data.UNIT_ID;
                        Session["LandlordId"] = (string)data.LAND_ID;
                        Session["ProjectName"] = (string)data.Project_Name;
                        Session["UnitName"] = (string)data.UNIT_NAME;
                        Session["LandlordName"] = (string)data.LANDLORD_NAME;
                    }
                    return View("~/Views/Category/RentPayee.cshtml");
                }

                else
                {

                    return View("~/Views/Category/RentPayee.cshtml");
                }

            }
        }

        public ActionResult RentStamp()
        {
            if (Session[POSxSession.LoggedUser] == null)
            {
                return Redirect("/User/Login");
            }
            else
            {
                return View("~/Views/Category/RentStamp.cshtml");
            }
        }
        public ActionResult Class_Wise_Asset_Details_Report()
        {
            if (Session[POSxSession.LoggedUser] == null)
            {
                return Redirect("/User/Login");
            }
            else
            {
                return View("~/Views/Category/Class_Wise_Asset_Details_Report.cshtml");
            }
        }
        public ActionResult RawMatItem()
        {
            if (Session[POSxSession.LoggedUser] == null)
            {
                return Redirect("/User/Login");
            }
            else
            {
                return View("~/Views/Category/RawMatItem.cshtml");
            }
        }
        public ActionResult Outlet()
        {
            if (Session[POSxSession.LoggedUser] == null)
            {
                return Redirect("/User/Login");
            }
            else
            {
             return View("~/Views/Category/Outlet.cshtml");
            }
        }
        public ActionResult Unit()
        {
            if (Session[POSxSession.LoggedUser] == null)
            {
                return Redirect("/User/Login");
            }
            else
            {
                return View("~/Views/Category/Unit.cshtml");
            }
        }
        public ActionResult UnitEntry()
        {
            if (Session[POSxSession.LoggedUser] == null)
            {
                return Redirect("/User/Login");
            }
            else
            {
                Session["ProjectName"] = null;
                var projectId = Convert.ToInt32(Session["RentUnitInfoDetailsView"]);

                List<ViewRentUnitDTO> dataGet = new List<ViewRentUnitDTO>();
                ViewRentUnitDTO data = new ViewRentUnitDTO();

                if (!string.IsNullOrEmpty(projectId.ToString()))
                {
                    dataGet = classificationDAL.GetUnitView(projectId);
                    if (dataGet.Count > 0)
                    {
                        data = dataGet.FirstOrDefault();

                        Session["ProjectName"] = (string)data.Project_Name;                        
                    }
                    return View("~/Views/Category/UnitEntry.cshtml");
                }
                else
                {
                   // Session["ProjectName"] = (string)data.Project_Name;
                    return View("~/Views/Category/UnitEntry.cshtml");
                }

                
            }
        }
        public ActionResult LandlordEntry()
        {
            if (Session[POSxSession.LoggedUser] == null)
            {
                return Redirect("/User/Login");
            }
            else
            {
                return View("~/Views/Category/LandlordEntry.cshtml");
            }
        }
        public ActionResult RentShare()
        {
            if (Session[POSxSession.LoggedUser] == null)
            {
                return Redirect("/User/Login");
            }
            else
            {
                return View("~/Views/Category/RentShare.cshtml");
            }
        }
        public ActionResult RentVat()
        {
            if (Session[POSxSession.LoggedUser] == null)
            {
                return Redirect("/User/Login");
            }
            else
            {
                return View("~/Views/Category/RentVat.cshtml");
            }
        }
        public ActionResult RentAIT()
        {
            if (Session[POSxSession.LoggedUser] == null)
            {
                return Redirect("/User/Login");
            }
            else
            {
                return View("~/Views/Category/RentAIT.cshtml");
            }
        }
        public ActionResult RentIntervale()
        {
            if (Session[POSxSession.LoggedUser] == null)
            {
                return Redirect("/User/Login");
            }
            else
            {
                return View("~/Views/Category/RentIntervale.cshtml");
            }
        }
        public ActionResult RentDetails()
        {
            if (Session[POSxSession.LoggedUser] == null)
            {
                return Redirect("/User/Login");
            }
            else
            {
                return View("~/Views/Category/RentDetails.cshtml");
            }
        }
        public ActionResult RentDiscount()
        {
            if (Session[POSxSession.LoggedUser] == null)
            {
                return Redirect("/User/Login");
            }
            else
            {
                return View("~/Views/Category/RentDiscount.cshtml");
            }
        }
        public ActionResult RentDistribution()
        {
            if (Session[POSxSession.LoggedUser] == null)
            {
                return Redirect("/User/Login");
            }
            else
            {
                return View("~/Views/Category/RentDistribution.cshtml");
            }
        }
        public ActionResult Agreement()
        {
            if (Session[POSxSession.LoggedUser] == null)
            {
                return Redirect("/User/Login");
            }
            else
            {
                return View("~/Views/Category/Agreement.cshtml");
            }
        }
        public ActionResult NewAgreement()
        {
            if (Session[POSxSession.LoggedUser] == null)
            {
                return Redirect("/User/Login");
            }
            else
            {
                Session["UnitName"] = null;
                var unitId = Convert.ToInt32(Session["RentUnitAgreementIDetailsView"]);
                List<ViewAgreementDTO> dataGet = new List<ViewAgreementDTO>();
                ViewAgreementDTO data = new ViewAgreementDTO();
                if (!string.IsNullOrEmpty(unitId.ToString()))
                {
                     dataGet = classificationDAL.GetUnitAgreementView(unitId);
                    if (dataGet.Count > 0)
                    {
                        data = dataGet.FirstOrDefault();

                        Session["UnitName"] = (string)data.UNIT_NAME;
                    }
                    return View("~/Views/Category/NewAgreement.cshtml");
                }
                else
                {
                    return View("~/Views/Category/NewAgreement.cshtml");
                }
               
            }
        }
        public ActionResult Landlord()
        {
            if (Session[POSxSession.LoggedUser] == null)
            {
                return Redirect("/User/Login");
            }
            else
            {
                return View("~/Views/Category/Landlord.cshtml");
            }
        }
        public ActionResult PostRent()
        {
            if (Session[POSxSession.LoggedUser] == null)
            {
                return Redirect("/User/Login");
            }
            else
            {
                return View("~/Views/Category/PostRent.cshtml");
            }
        }
        public ActionResult RentPayment()
        {
            if (Session[POSxSession.LoggedUser] == null)
            {
                return Redirect("/User/Login");
            }
            else
            {
                return View("~/Views/Category/RentPayment .cshtml");
            }
        }

        public JsonResult ClassList()
        {
            try
            {
                string _Msg;
                DataTable dt_ChannelList = classificationDAL.GetClassList();

                if (dt_ChannelList.Rows.Count > 0)
                {
                    _Msg = "DONE";
                    List<Dictionary<string, object>> _ChannelList = _BasicUtilities.GetTableRows(dt_ChannelList);
                    return Json(_ChannelList);
                }
                else
                {
                    _Msg = "ERROR";
                    return Json(_Msg);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);

            }
        }
        public JsonResult ReasonList()
        {
            try
            {
                string _Msg;
                DataTable dt_ChannelList = classificationDAL.GetReasonList();

                if (dt_ChannelList.Rows.Count > 0)
                {
                    _Msg = "DONE";
                    List<Dictionary<string, object>> _ChannelList = _BasicUtilities.GetTableRows(dt_ChannelList);
                    return Json(_ChannelList);
                }
                else
                {
                    _Msg = "ERROR";
                    return Json(_Msg);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);

            }
        }
        public JsonResult UserList()
        {
            try
            {
                string _Msg;
                DataTable dt_ChannelList = classificationDAL.GetUserList();

                if (dt_ChannelList.Rows.Count > 0)
                {
                    _Msg = "DONE";
                    List<Dictionary<string, object>> _ChannelList = _BasicUtilities.GetTableRows(dt_ChannelList);
                    return Json(_ChannelList);
                }
                else
                {
                    _Msg = "ERROR";
                    return Json(_Msg);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);

            }
        }
        public JsonResult DepartmentList()
        {
            try
            {
                string _Msg;
                DataTable dt_ChannelList = classificationDAL.GetDepartmentList();

                if (dt_ChannelList.Rows.Count > 0)
                {
                    _Msg = "DONE";
                    List<Dictionary<string, object>> _ChannelList = _BasicUtilities.GetTableRows(dt_ChannelList);
                    return Json(_ChannelList);
                }
                else
                {
                    _Msg = "ERROR";
                    return Json(_Msg);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);

            }
        }
        public JsonResult LocationWiseDepartmentList(string _org_id)
        {
            try
            {
                string _Msg;
                DataTable dt_ChannelList = classificationDAL.GetLocationWiseDepartmentList(_org_id);

                if (dt_ChannelList.Rows.Count > 0)
                {
                    _Msg = "DONE";
                    List<Dictionary<string, object>> _ChannelList = _BasicUtilities.GetTableRows(dt_ChannelList);
                    return Json(_ChannelList);
                }
                else
                {
                    _Msg = "ERROR";
                    return Json(_Msg);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);

            }
        }
        public JsonResult SupplierList()
        {
            try
            {
                string _Msg;
                DataTable dt_ChannelList = classificationDAL.GetSupplierList();

                if (dt_ChannelList.Rows.Count > 0)
                {
                    _Msg = "DONE";
                    List<Dictionary<string, object>> _ChannelList = _BasicUtilities.GetTableRows(dt_ChannelList);
                    return Json(_ChannelList);
                }
                else
                {
                    _Msg = "ERROR";
                    return Json(_Msg);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);

            }
        }
        public JsonResult SupplierItemList(string _model_list)
        {
            try
            {
                string _Msg;
                DataTable dt_ChannelList = classificationDAL.GetSupplierItemList(_model_list);

                if (dt_ChannelList.Rows.Count > 0)
                {
                    _Msg = "DONE";
                    List<Dictionary<string, object>> _ChannelList = _BasicUtilities.GetTableRows(dt_ChannelList);
                    return Json(_ChannelList);
                }
                else
                {
                    _Msg = "ERROR";
                    return Json(_Msg);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);

            }
        }
        public JsonResult ManufactureItemList(string _model_list)
        {
            try
            {
                string _Msg;
                DataTable dt_ChannelList = classificationDAL.GetManufactureList(_model_list);

                if (dt_ChannelList.Rows.Count > 0)
                {
                    _Msg = "DONE";
                    List<Dictionary<string, object>> _ChannelList = _BasicUtilities.GetTableRows(dt_ChannelList);
                    return Json(_ChannelList);
                }
                else
                {
                    _Msg = "ERROR";
                    return Json(_Msg);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);

            }
        }
        public JsonResult ManufactureModelList()
        {
            try
            {
                string _Msg;
                DataTable dt_ChannelList = classificationDAL.GetManufactureModelList();

                if (dt_ChannelList.Rows.Count > 0)
                {
                    _Msg = "DONE";
                    List<Dictionary<string, object>> _ChannelList = _BasicUtilities.GetTableRows(dt_ChannelList);
                    return Json(_ChannelList);
                }
                else
                {
                    _Msg = "ERROR";
                    return Json(_Msg);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);

            }
        }
        [HttpPost]
        public JsonResult SizeDropDownList()
        {
            var result = classificationDAL.SizeDropDownList();
            return Json(result);
        }
        [HttpPost]
        public JsonResult ColorDropDownList()
        {
            var result = classificationDAL.ColorDropDownList();
            return Json(result);
        }
        public ActionResult bindConversionUnit()
        {
            List<Dictionary<string, object>> _List = new List<Dictionary<string, object>>();
            try
            {
                DataTable dt_result = classificationDAL.BindConversionUnit();
                List<Dictionary<string, object>> _DDL_List = _BasicUtilities.GetTableRows(dt_result);
                return Json(new { First = _DDL_List }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(false);
            }
        }
        [HttpPost]
        public ActionResult Save(
        string categoryId,
        string categoryName,
        string categoryCode,
        string ClassList,
         bool activeStatus

   )
        {
            string _msg = string.Empty;

            try
            {

                string _Created_By = "7500016";
                DataTable cat = classificationDAL.SaveAssetCategory(categoryId, ClassList, categoryCode, categoryName, _Created_By, activeStatus);

                if (cat.Rows.Count > 0)
                {
                    _msg = cat.Rows[0]["result"].ToString();

                }



            }
            catch (Exception ex)
            {

                throw ex;
            }

            return Json(_msg);
        }
        [HttpGet]
        public JsonResult List()
        {

            var category = classificationDAL.GetAssestsCategory();

            return Json(new { data = category }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Edit_it(int catId)
        {
            var dataGet = classificationDAL.getAssetCategoryData(catId);
            return Json(new { data = dataGet });

        }
        public JsonResult updateAssetCategory(
        string categoryId,
        string categoryName,
        string categoryCode,
        string ClassList,
        bool activeStatus
     )
        {
            try
            {
                string _msg = string.Empty;

                string _Created_By = "7500016";

                DataTable cat = classificationDAL.UpdateAssetCategory(categoryId, ClassList, categoryCode, categoryName, _Created_By, activeStatus);
                if (cat.Rows.Count > 0)
                {

                    _msg = cat.Rows[0]["result"].ToString();

                }

                return Json(_msg);
            }
            catch (System.Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public JsonResult CategoryList(string _classId)
        {
            try
            {
                string _Msg;
                DataTable dt_CategoryList = classificationDAL.GetCategoryList(_classId);

                if (dt_CategoryList.Rows.Count > 0)
                {
                    _Msg = "DONE";
                    List<Dictionary<string, object>> _CategorylList = _BasicUtilities.GetTableRows(dt_CategoryList);
                    return Json(_CategorylList);
                }
                else
                {
                    _Msg = "ERROR";
                    return Json(_Msg);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);

            }
        }
        public JsonResult AssetList(string _segmentId)
        {
            try
            {
                string _Msg;
                DataTable dt_CategoryList = classificationDAL.GetAssetList(_segmentId);

                if (dt_CategoryList.Rows.Count > 0)
                {
                    _Msg = "DONE";
                    List<Dictionary<string, object>> _CategorylList = _BasicUtilities.GetTableRows(dt_CategoryList);
                    return Json(_CategorylList);
                }
                else
                {
                    _Msg = "ERROR";
                    return Json(_Msg);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);

            }
        }
        public JsonResult AssetParentList(string _classId)
        {
            try
            {
                string _Msg;
                DataTable dt_CategoryList = classificationDAL.GetAssetParentList(_classId);

                if (dt_CategoryList.Rows.Count > 0)
                {
                    _Msg = "DONE";
                    List<Dictionary<string, object>> _CategorylList = _BasicUtilities.GetTableRows(dt_CategoryList);
                    return Json(_CategorylList);
                }
                else
                {
                    _Msg = "ERROR";
                    return Json(_Msg);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);

            }
        }
        public JsonResult AssetInitialTagList(string _asset_list)
        {
            try
            {
                string _Msg;
                DataTable dt_CategoryList = classificationDAL.GetAssetInitialTagList(_asset_list);

                if (dt_CategoryList.Rows.Count > 0)
                {
                    _Msg = "DONE";
                    List<Dictionary<string, object>> _CategorylList = _BasicUtilities.GetTableRows(dt_CategoryList);
                    return Json(_CategorylList);
                }
                else
                {
                    _Msg = "ERROR";
                    return Json(_Msg);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);

            }
        }
        public JsonResult AssetExternalTagList(string _asset_list)
        {
            try
            {
                string _Msg;
                DataTable dt_CategoryList = classificationDAL.GetAssetInitialTagList(_asset_list);

                if (dt_CategoryList.Rows.Count > 0)
                {
                    _Msg = "DONE";
                    List<Dictionary<string, object>> _CategorylList = _BasicUtilities.GetTableRows(dt_CategoryList);
                    return Json(_CategorylList);
                }
                else
                {
                    _Msg = "ERROR";
                    return Json(_Msg);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);

            }
        }
        public JsonResult PeripheralList(string _segmentId)
        {
            try
            {
                string _Msg;
                DataTable dt_CategoryList = classificationDAL.GetPeripheralList(_segmentId);

                if (dt_CategoryList.Rows.Count > 0)
                {
                    _Msg = "DONE";
                    List<Dictionary<string, object>> _CategorylList = _BasicUtilities.GetTableRows(dt_CategoryList);
                    return Json(_CategorylList);
                }
                else
                {
                    _Msg = "ERROR";
                    return Json(_Msg);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);

            }
        }
        public JsonResult ComponentList(string _segmentId)
        {
            try
            {
                string _Msg;
                DataTable dt_CategoryList = classificationDAL.GetComponentList(_segmentId);

                if (dt_CategoryList.Rows.Count > 0)
                {
                    _Msg = "DONE";
                    List<Dictionary<string, object>> _CategorylList = _BasicUtilities.GetTableRows(dt_CategoryList);
                    return Json(_CategorylList);
                }
                else
                {
                    _Msg = "ERROR";
                    return Json(_Msg);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);

            }
        }
        public JsonResult SegmentList(string _catId)
        {
            try
            {
                string _Msg;
                DataTable dt_CategoryList = classificationDAL.GetSegmentList(_catId);

                if (dt_CategoryList.Rows.Count > 0)
                {
                    _Msg = "DONE";
                    List<Dictionary<string, object>> _CategorylList = _BasicUtilities.GetTableRows(dt_CategoryList);
                    return Json(_CategorylList);
                }
                else
                {
                    _Msg = "ERROR";
                    return Json(_Msg);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);

            }
        }
        public JsonResult ModelList(string _segmentId)
        {
            try
            {
                string _Msg;
                DataTable dt_CategoryList = classificationDAL.GetModelList(_segmentId);

                if (dt_CategoryList.Rows.Count > 0)
                {
                    _Msg = "DONE";
                    List<Dictionary<string, object>> _CategorylList = _BasicUtilities.GetTableRows(dt_CategoryList);
                    return Json(_CategorylList);
                }
                else
                {
                    _Msg = "ERROR";
                    return Json(_Msg);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);

            }
        }

        [HttpPost]
        public ActionResult SaveSegment(
       string segmentId,
       string segmentName,
       string subCategoryCode,
       string CategoryList,
       string ClassList,
        bool activeStatus
  //int rowStatus
  )
        {
            string _msg = string.Empty;

            try
            {

                string _Created_By = "7500016";
                DataTable cat = classificationDAL.SaveSegment(segmentId, ClassList, CategoryList, subCategoryCode, segmentName, _Created_By, activeStatus);

                if (cat.Rows.Count > 0)
                {
                    _msg = cat.Rows[0]["result"].ToString();

                }



            }
            catch (Exception ex)
            {

                throw ex;
            }

            return Json(_msg);
        }
        [HttpGet]
        public JsonResult SegmentGridList()
        {

            var segment = classificationDAL.GetAssestsSegment();

            return Json(new { data = segment }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit_Segment_it(int segId)
        {
            var dataGet = classificationDAL.getSegmentData(segId);
            return Json(new { data = dataGet });

        }

        public JsonResult updateSegment(
       string segmentId,
       string segmentName,
       string subCategoryCode,
       string CategoryList,
       string ClassList,
       bool activeStatus
    )
        {
            try
            {
                string _msg = string.Empty;

                string _Created_By = "7500016";

                DataTable cat = classificationDAL.UpdateSegment(segmentId, ClassList, CategoryList, subCategoryCode, segmentName, _Created_By, activeStatus);
                if (cat.Rows.Count > 0)
                {

                    _msg = cat.Rows[0]["result"].ToString();

                }

                return Json(_msg);
            }
            catch (System.Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpPost]
        public JsonResult CountryList()
        {
            string Country_ID = string.Empty; int SpType = 0;

            var result = classificationDAL.GetCountryList(Country_ID, SpType);
            return Json(result);
        }

        [HttpPost]
        public JsonResult CityList(int Country_ID)
        {
            int SpType = 1;

            var result = classificationDAL.GetCityList(Country_ID, SpType);
            return Json(result);
        }
        [HttpPost]
        public JsonResult BankList()
        {
            string Bank_ID = string.Empty; string District_Code = string.Empty; int SpType = 0;

            var result = classificationDAL.GetBankList(Bank_ID, District_Code, SpType);
            return Json(result);
        }
        [HttpPost]
        public JsonResult DistrictList(int Bank_ID)
        {
            string District_Code = string.Empty; int SpType = 1;

            var result = classificationDAL.GetDistrictList(Bank_ID, District_Code, SpType);
            return Json(result);
        }
        [HttpPost]
        public JsonResult BranchList(int Bank_ID, int District_Code)
        {
            int SpType = 2;

            var result = classificationDAL.GetBranchList(Bank_ID, District_Code, SpType);
            return Json(result);
        }
        [HttpPost]
        public ActionResult SaveManufacture(
        string manufactureId,
        string manufactureName,
        string countryList,
        string mobile,
        string uploadImage,
        string uRL,
        string address,
        bool activeStatus
   //int rowStatus
   )
        {

            string _msg = string.Empty;

            try
            {

                string _Created_By = "7500016";
                DataTable cat = classificationDAL.SaveManufacture(manufactureId, manufactureName, countryList, uRL, uploadImage, mobile, address, _Created_By, activeStatus);

                if (cat.Rows.Count > 0)
                {
                    _msg = cat.Rows[0]["result"].ToString();

                }



            }
            catch (Exception ex)
            {

                throw ex;
            }

            return Json(_msg);
        }
        //public List<ViewManufactureDTO> makeTeacherGridListData(DataTable dtTeacherGridInfo)
        //{
        //    List<ViewManufactureDTO> dataBundle = new List<ViewManufactureDTO>();

        //    for (int i = 0; i < dtTeacherGridInfo.Rows.Count; i++)
        //    {
        //        ViewManufactureDTO ViewManufactureDTO = new ViewManufactureDTO();
        //        ViewManufactureDTO.MANF_ID = dtTeacherGridInfo.Rows[i]["TEACHER_ID"].ToString();
        //        ViewManufactureDTO.EXTERNAL_ID = dtTeacherGridInfo.Rows[i]["TEACHER_CODE"].ToString();
        //        ViewManufactureDTO.DESCRIPTION = dtTeacherGridInfo.Rows[i]["TEACHER_NAME"].ToString();
        //        ViewManufactureDTO.COUNTRY = dtTeacherGridInfo.Rows[i]["JOINING_DATE"].ToString();
        //        ViewManufactureDTO.COUNTRY_NAME = dtTeacherGridInfo.Rows[i]["GENDER_CODE"].ToString();
        //        ViewManufactureDTO.PHN_NO = dtTeacherGridInfo.Rows[i]["GENDER_NAME"].ToString();
        //        ViewManufactureDTO.URL = dtTeacherGridInfo.Rows[i]["CAMPUS_CODE"].ToString();
        //        ViewManufactureDTO.ADDRESS = dtTeacherGridInfo.Rows[i]["CAMPUS_NAME"].ToString();
        //        ViewManufactureDTO.LOGO_EXT = dtTeacherGridInfo.Rows[i]["SMS_MOBILE_NUM"].ToString();
        //        ViewManufactureDTO.STATUS = dtTeacherGridInfo.Rows[i]["FATHERS_NAME"].ToString();

        //    }
        //    return dataBundle;
        //}
        [HttpGet]
        public JsonResult ManufactureList(string _model_list)
        {

            var category = classificationDAL.GetManufacture();

            return Json(new { data = category }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit_Manufacture(int manfId)
        {
            var dataGet = classificationDAL.getManufactureData(manfId);
            return Json(new { data = dataGet });

        }
        public JsonResult updateManufacture(
        string manufactureId,
        string manufactureName,
        string countryList,
        string mobile,
        string uploadImage,
        string uRL,
        string address,
        bool activeStatus
    )
        {
            try
            {
                string _msg = string.Empty;

                string _Created_By = "7500016";

                DataTable cat = classificationDAL.UpdateManufacture(manufactureId, manufactureName, countryList, uRL, uploadImage, mobile, address, _Created_By, activeStatus);
                if (cat.Rows.Count > 0)
                {

                    _msg = cat.Rows[0]["result"].ToString();

                }

                return Json(_msg);
            }
            catch (System.Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public ActionResult SaveSupplier(
      string supplierId,
      string type,
      bool activeStatus
 //int rowStatus
 )
        {
            string _msg = string.Empty;

            try
            {

                string _Created_By = "7500016";
                DataTable cat = classificationDAL.SaveSupplier(supplierId, type, _Created_By, activeStatus);

                if (cat.Rows.Count > 0)
                {
                    _msg = cat.Rows[0]["result"].ToString();

                }



            }
            catch (Exception ex)
            {

                throw ex;
            }

            return Json(_msg);
        }
        [HttpGet]
        public JsonResult ListSupplier()
        {

            var category = classificationDAL.GetSupplier();

            return Json(new { data = category }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit_supplier(int supplierId)
        {
            var dataGet = classificationDAL.getSupplierData(supplierId);
            return Json(new { data = dataGet });

        }
        public JsonResult updateSupplier(
      string supplierId,
      string type,
      bool activeStatus
    )
        {
            try
            {
                string _msg = string.Empty;

                string _Created_By = "7500016";

                DataTable cat = classificationDAL.UpdateSupplier(supplierId, type, _Created_By, activeStatus);
                if (cat.Rows.Count > 0)
                {

                    _msg = cat.Rows[0]["result"].ToString();

                }

                return Json(_msg);
            }
            catch (System.Exception ex)
            {
                return Json(ex.Message);
            }
        }

        #region///////////////////////////////////////////////

        [HttpPost]
        public JsonResult AllInformationSave(
       string v_supplierId,
       string v_name,
       string v_typeList,
       string v_city,
       string v_state,
       string v_countryList,
       string v_zip,
       string v_uRL,
       string v_address,
       string v_activeStatus,
       string v_credit_period,
       string v_condition,
       string v_Bank_ID,
       string v_District_ID,
       string v_Branch_ID,
       string v_Acc_Holder,
       string v_Acc_Number,
       string v_Curren_cy,
       string v_Pri_mary,
       string v_Status,
       string v_Contact_Name,
       string v_Contact_Phone,
       string v_Contact_Email,
       string v_Contact_Notes,
       string v_Contact_Status
  //int rowStatus
  )
        {
            string _msg = string.Empty;
            string _category = string.Empty;
            string _bankAccount = string.Empty;
            string _contact = string.Empty;

            try
            {

                //
                string _Created_By = "7500016";

                string _Bank_ID = v_Bank_ID.TrimEnd(',');
                string _District_ID = v_District_ID.TrimEnd(',');
                string _Branch_ID = v_Branch_ID.TrimEnd(',');
                string _Acc_Holder = v_Acc_Holder.TrimEnd(',');
                string _Acc_Number = v_Acc_Number.TrimEnd(',');
                string _Curren_cy = v_Curren_cy.TrimEnd(',');
                string _Pri_mary = v_Pri_mary.TrimEnd(',');
                string _Status = v_Status.TrimEnd(',');
                string _vContact_Name = v_Contact_Name.TrimEnd(',');
                string _vContact_Phone = v_Contact_Phone.TrimEnd(',');
                string _vContact_Email = v_Contact_Email.TrimEnd(',');
                string _vContact_Notes = v_Contact_Notes.TrimEnd(',');
                string _vContact_Status = v_Contact_Status.TrimEnd(',');

                List<string> BankIdList = _Bank_ID.Split(',').ToList();
                List<string> DistrictIdList = _District_ID.Split(',').ToList();
                List<string> BranchIdList = _Branch_ID.Split(',').ToList();
                List<string> AccHolderList = _Acc_Holder.Split(',').ToList();
                List<string> AccNumberList = _Acc_Number.Split(',').ToList();
                List<string> CurrencyList = _Curren_cy.Split(',').ToList();
                List<string> PrimaryList = _Pri_mary.Split(',').ToList();
                List<string> StatusList = _Status.Split(',').ToList();
                List<string> vContactNameList = _vContact_Name.Split(',').ToList();
                List<string> vContactPhoneList = _vContact_Phone.Split(',').ToList();
                List<string> vContactEmailList = _vContact_Email.Split(',').ToList();
                List<string> vContactNotesList = _vContact_Notes.Split(',').ToList();
                List<string> vContactStatusList = _vContact_Status.Split(',').ToList();

                DataTable Supplier = classificationDAL.SaveSupplierDetails(v_supplierId, v_name, v_typeList, v_address, v_city, v_state, v_countryList, v_zip, v_uRL, v_credit_period, v_condition, _Created_By, v_activeStatus);

                var BankAccount = new DataTable();
                var Contact = new DataTable();

                if (!string.IsNullOrEmpty(_Bank_ID))
                {
                    for (int i = 0; i < BankIdList.Count; i++)
                    {
                        BankAccount = classificationDAL.SaveSupplierBankAccount("", v_supplierId, BankIdList[i], DistrictIdList[i], BranchIdList[i], AccHolderList[i], AccNumberList[i], CurrencyList[i], PrimaryList[i], _Created_By, StatusList[i]);
                    }
                }

                if (!string.IsNullOrEmpty(_vContact_Name))
                {
                    for (int i = 0; i < vContactNameList.Count; i++)
                    {
                        Contact = classificationDAL.SaveContact(v_supplierId, vContactNameList[i], vContactPhoneList[i], vContactEmailList[i], vContactNotesList[i], _Created_By, vContactStatusList[i]);
                    }
                }


                // var insert = classificationDAL.SaveSupplierBankAccount( _Bank_ID, _District_ID, _Branch_ID, _Acc_Holder, _Acc_Number, _Curren_cy, _Pri_mary, _Status);

                if (Supplier.Rows.Count > 0)
                {
                    _category = Supplier.Rows[0]["result"].ToString();

                    if (_category == "Success")
                    {
                        _bankAccount = BankAccount.Rows[0]["result"].ToString();

                        if (_bankAccount == "Success")
                        {
                            _msg = Contact.Rows[0]["result"].ToString();
                        }
                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;
            }

            return Json(_msg);
        }

        [HttpGet]
        public JsonResult SupplierDetailsList()
        {

            var category = classificationDAL.GetSupplierDetails();

            return Json(new { data = category }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit_SupplierDetails(int supId)
        {
            Session["supcode"] = supId;
            var assetCode = Convert.ToInt32(Session["supcode"]);
            var dataGet = classificationDAL.getSupplierDetailsData(supId);
            // ViewBag.COUNTRY_ID = dataGet.COUNTRY_ID;
            return Json(new { data = dataGet });

        }
        public JsonResult updateSupplierDetails(
       string v_supplierId,
       string v_name,
       string v_typeList,
       string v_city,
       string v_state,
       string v_countryList,
       string v_zip,
       string v_uRL,
       string v_address,
       string v_activeStatus,
       string v_credit_period,
       string v_condition,
       string v_Bank_ID,
       string v_District_ID,
       string v_Branch_ID,
       string v_Acc_Holder,
       string v_Acc_Number,
       string v_Curren_cy,
       string v_Pri_mary,
       string v_Status,
       string v_Contact_Name,
       string v_Contact_Phone,
       string v_Contact_Email,
       string v_Contact_Notes,
       string v_Contact_Status
        )
        {
            string _msg = string.Empty;
            string _category = string.Empty;
            string _bankAccount = string.Empty;
            string _contact = string.Empty;
            try
            {


                string _Created_By = "7500016";

                DataTable Supplier = classificationDAL.UpdateSupplierDetails(v_supplierId, v_name, v_typeList, v_address, v_city, v_state, v_countryList, v_zip, v_uRL, v_credit_period, v_condition, _Created_By, v_activeStatus);

                var BankAccount = new DataTable();
                var Contact = new DataTable();

                if (!string.IsNullOrEmpty(v_Bank_ID))
                {

                    BankAccount = classificationDAL.UpdateSupplierBankAccount("", v_supplierId, v_Bank_ID, v_District_ID, v_Branch_ID, v_Acc_Holder, v_Acc_Number, v_Curren_cy, v_Pri_mary, _Created_By, v_Status);
                }
                if (!string.IsNullOrEmpty(v_Contact_Name))
                {
                    Contact = classificationDAL.UpdateContact(v_supplierId, v_Contact_Name, v_Contact_Phone, v_Contact_Email, v_Contact_Notes, _Created_By, v_Contact_Status);
                }



                if (Supplier.Rows.Count > 0)
                {
                    _category = Supplier.Rows[0]["result"].ToString();

                    if (_category == "Success")
                    {
                        _bankAccount = BankAccount.Rows[0]["result"].ToString();
                    }
                    if (_bankAccount == "Success")
                    {
                        _msg = Contact.Rows[0]["result"].ToString();
                    }

                }

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return Json(_msg);
        }
        [HttpPost]
        public JsonResult TypeList()
        {


            var result = classificationDAL.GetSupTypeList();

            List<Dictionary<string, object>> _List = _BasicUtilities.GetTableRows(result);
            return Json(_List);
        }

        [HttpPost]
        public ActionResult Add(string username)
        {
            var user = username;
            return Json(user);
        }
        [HttpGet]
        public JsonResult SupplierAccountDetailsList()
        {
            var supId = Convert.ToInt32(Session["supcode"]);
            var segment = classificationDAL.GetBankAccount(supId);

            return Json(new { data = segment }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit_BankAccountDetails(int bankId)
        {
            var dataGet = classificationDAL.getBankAccountDetailsData(bankId);
            return Json(new { data = dataGet });

        }
        [HttpGet]
        public JsonResult ContactDetailsList()
        {
            var supId = Convert.ToInt32(Session["supcode"]);
            var segment = classificationDAL.GetContact(supId);

            return Json(new { data = segment }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit_ContactDetails(int contactId)
        {
            var dataGet = classificationDAL.getContactDetailsData(contactId);
            return Json(new { data = dataGet });

        }
        #endregion



        [HttpPost]
        public ActionResult SaveModel(
       string modelId,
       string name,
       string ClassList,
       string CategoryList,
       string SegmentList,
       string manufacture_list,
       string SupplierList,
       string modelNo,
       string notes,
       string uploadImage
  //int rowStatus
  )
        {
            string _msg = string.Empty;

            try
            {

                string _Created_By = "7500016";
                DataTable cat = classificationDAL.SaveModel(modelId, name, ClassList, CategoryList, SegmentList, manufacture_list, SupplierList, modelNo, notes, uploadImage, _Created_By);

                if (cat.Rows.Count > 0)
                {
                    _msg = cat.Rows[0]["result"].ToString();

                }



            }
            catch (Exception ex)
            {

                throw ex;
            }

            return Json(_msg);
        }

        [HttpPost]
        public ActionResult SaveLocationDepartment(
       string outletSelect,
       string department_Id

  //int rowStatus
  )
        {
            string _msg = string.Empty;

            try
            {

                string _Created_By = "7500016";
                DataTable cat = classificationDAL.SaveLocationDepartment(outletSelect, department_Id);

                if (cat.Rows.Count > 0)
                {
                    _msg = cat.Rows[0]["result"].ToString();

                }



            }
            catch (Exception ex)
            {

                throw ex;
            }

            return Json(_msg);
        }
        [HttpGet]
        public JsonResult ModelGridList()
        {

            var segment = classificationDAL.GetAssestsModel();

            return Json(new { data = segment }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult PeripheralGridList()
        {

            var segment = classificationDAL.GetPeripheral();

            return Json(new { data = segment }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult TransGridList()
        {

            var segment = classificationDAL.GetTransfer();

            return Json(new { data = segment }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult AssetGridList()
        {

            var segment = classificationDAL.GetAsset();

            return Json(new { data = segment }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AssetComponentGridList()
        {

            var segment = classificationDAL.GetComponent();

            return Json(new { data = segment }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AssetPackageGridList()
        {

            var segment = classificationDAL.GetAssetPackage();

            return Json(new { data = segment }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit_Model_it(int modelId)
        {
            var dataGet = classificationDAL.getModelData(modelId);
            return Json(new { data = dataGet });

        }
        public ActionResult Edit_Component_it(int masterTag)
        {
            var dataGet = classificationDAL.getComponentData(masterTag);
            return Json(new { data = dataGet });

        }
        public JsonResult updateModel(
       string modelId,
       string name,
       string ClassList,
       string CategoryList,
       string SegmentList,
       string manufacture_list,
       string SupplierList,
       string modelNo,
       string notes,
       string uploadImage
  )
        {
            try
            {
                string _msg = string.Empty;

                string _Created_By = "7500016";

                DataTable cat = classificationDAL.UpdateModel(modelId, name, ClassList, CategoryList, SegmentList, manufacture_list, SupplierList, modelNo, notes, uploadImage, _Created_By);
                if (cat.Rows.Count > 0)
                {

                    _msg = cat.Rows[0]["result"].ToString();

                }

                return Json(_msg);
            }
            catch (System.Exception ex)
            {
                return Json(ex.Message);
            }
        }
        public JsonResult ImageUpload(HttpPostedFileWrapper ImageFile)
        {

            var file = ImageFile;
            var fileUniqueName = Convert.ToString(Guid.NewGuid());
            string fname = string.Empty;
            if (file != null)
            {

                var fileName = Path.GetFileName(file.FileName);
                var extention = Path.GetExtension(file.FileName);
                var filenamewithoutextension = Path.GetFileNameWithoutExtension(file.FileName);

                //string articleMaster = "ARTICLEMASTER";

                //long generateArticle = itemDAL.GETSERILANO(articleMaster);

                fname = filenamewithoutextension + Path.GetExtension(file.FileName);

                file.SaveAs(Server.MapPath("/Images/Products/" + fname));
            }

            return Json(fname, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult SaveComponent(
  string articleInfo,
  string ClassList,
  string TypeId,
  string Modellist,
  string SupplierList,
  string Name,
  string Description,
  string Size,
  string DUOMId,
  string Color,
  string PurchaseCost,
  string AutoSl

)
        {
            string _msg = string.Empty;

            try
            {

                string articleMaster = "ASSET";

                long generateArticleMaster = classificationDAL.GETSERILANO(articleMaster);

                if (!generateArticleMaster.Equals(generateArticleMaster))
                { }
                string _Created_By = "7500016";
                DataTable cat = classificationDAL.SaveComponent(generateArticleMaster, articleInfo, ClassList, TypeId, Modellist, SupplierList, Name, Description, Size, DUOMId, Color, PurchaseCost, AutoSl, _Created_By);

                if (cat.Rows.Count > 0)
                {
                    _msg = cat.Rows[0]["result"].ToString();

                }



            }
            catch (Exception ex)
            {

                throw ex;
            }

            return Json(_msg);
        }

        public ActionResult SaveAsset(
        string articleInfo,
        string ClassList,
        string TypeId,
        string Modellist,
        string SupplierList,
        string Name,
        string Description,
        string Size,
        string DUOMId,
        string Color,
        string PurchaseCost,
        string AutoSl,
        string PeripheralList

      )
        {
            string _msg = string.Empty;

            try
            {

                string _Created_By = "7500016";
                DataTable cat = classificationDAL.SaveAsset(articleInfo, ClassList, TypeId, Modellist, SupplierList, Name, Description, Size, DUOMId, Color, PurchaseCost, PeripheralList, AutoSl, _Created_By);

                if (cat.Rows.Count > 0)
                {
                    _msg = cat.Rows[0]["result"].ToString();

                }



            }
            catch (Exception ex)
            {

                throw ex;
            }

            return Json(_msg);
        }
        [HttpGet]
        public JsonResult ComponentGridList()
        {

            var segment = classificationDAL.GetAssestsComponent();

            return Json(new { data = segment }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SavePeripheral(
        string peripheralId,
        string peripheralname,
        string ClassList,
        string CategoryList,
        string SegmentList,
        string Manufacturelist,
        string modellist,
        string SupplierList,
        string company,
        string Assetlocation,
        string serialNo,
        string description,
        string remark,
        string orderNumber,
        string purchaseDate,
        string purchaseCost,
        string department,
        string user,
        string uploadImage
       //int rowStatus
       )
        {
            string _msg = string.Empty;

            try
            {

                string _Created_By = "7500016";
                DataTable cat = classificationDAL.SavePeripheral(peripheralId, peripheralname, ClassList, CategoryList, SegmentList, modellist, Manufacturelist, SupplierList, serialNo, company, Assetlocation, description, remark, orderNumber, purchaseDate, purchaseCost, department, user, uploadImage, _Created_By);

                if (cat.Rows.Count > 0)
                {
                    _msg = cat.Rows[0]["result"].ToString();

                }



            }
            catch (Exception ex)
            {

                throw ex;
            }

            return Json(_msg);
        }
        public ActionResult SaveAssetCMaster(
        string asset_list


       //int rowStatus
       )
        {
            string _msg = string.Empty;

            try
            {
                string articleMaster = "ASSETCMASTER";

                long generateArticle = classificationDAL.GETSERILANO(articleMaster);

                if (!generateArticle.Equals(generateArticle))
                { }
                string _Created_By = "7500016";
                DataTable cat = classificationDAL.SaveAssetCMaster(generateArticle, asset_list, _Created_By);

                if (cat.Rows.Count > 0)
                {
                    _msg = cat.Rows[0]["result"].ToString();

                }



            }
            catch (Exception ex)
            {

                throw ex;
            }

            return Json(_msg);
        }

        [HttpPost]
        public ActionResult viewAssetDetails(int assetCode)
        {


            Session["AssetChildCode"] = assetCode;

            //return Json(new { data = dataGet }, JsonRequestBehavior.AllowGet);
            return Json(true);

            //}
        }
        [HttpGet]
        public JsonResult AssetChildList()
        {

            var assetCode = Convert.ToInt32(Session["AssetChildCode"]);
            var dataGet = classificationDAL.getAssetMasterDetailsData(assetCode);

            return Json(new { data = dataGet }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult viewAssetChildDetailsInfo(int assetDetailsCode)
        {


            Session["AssetChildDetailsCodeInfo"] = assetDetailsCode;

            //return Json(new { data = dataGet }, JsonRequestBehavior.AllowGet);
            return Json(true);

            //}
        }
        [HttpGet]
        public JsonResult AssetChildDetailsListView()
        {

            var assetDetailsCode = Convert.ToInt32(Session["AssetChildDetailsCodeInfo"]);
            var dataGet = classificationDAL.getAssetMasterDetailsChildData(assetDetailsCode);

            return Json(new { data = dataGet }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult viewUnitDetailsInfo(int projectId)
        {
           
            Session["RentUnitInfoDetailsView"] = projectId;

            //return Json(new { data = dataGet }, JsonRequestBehavior.AllowGet);
            return Json(true);

            //}
        }
        [HttpGet]
        public JsonResult RentUnitListView()
        {
            Session["ProjectName"] = null;
            var projectId = Convert.ToInt32(Session["RentUnitInfoDetailsView"]);
            var dataGet = classificationDAL.GetUnitView(projectId);
            //var data = dataGet.FirstOrDefault();
            
            //Session["ProjectName"] = (string)data.Project_Name;
           
            //ViewData["ProjectName"] = Session["ProjectName"];
            return Json(new { data = dataGet }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult viewRentPayeeInfo(int landId)
        {

            Session["RentPayeeInfoDetailsView"] = landId;

            //return Json(new { data = dataGet }, JsonRequestBehavior.AllowGet);
            return Json(true);

            //}
        }
        [HttpGet]
        public JsonResult RentLandlordWisePayeeList()
        {


            Session["ProjectName"] = null;
            Session["UnitName"] = null;
            Session["LandlordName"] = null;
            var landId = Convert.ToInt32(Session["RentPayeeInfoDetailsView"]);
            var dataGet = classificationDAL.GetShareRentPayee(landId);
            //var data = dataGet.FirstOrDefault();
            //Session["ProjectName"] = (string)data.Project_Name;
            //Session["UnitName"] = (string)data.UNIT_NAME;
            //Session["LandlordName"] = (string)data.LANDLORD_NAME;
            //ViewData["ProjectName"] = Session["ProjectName"];
            return Json(new { data = dataGet }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult viewUnitAgreementDetailsInfo(int unitId)
        {

            Session["RentUnitAgreementIDetailsView"] = unitId;

            //return Json(new { data = dataGet }, JsonRequestBehavior.AllowGet);
            return Json(true);

            //}
        }
        [HttpGet]
        public JsonResult RentAgreementListView()
        {
          //  Session["UnitName"] = null;
            var unitId = Convert.ToInt32(Session["RentUnitAgreementIDetailsView"]);
            var dataGet = classificationDAL.GetUnitAgreementView(unitId);
            //var data = dataGet.FirstOrDefault();
            //Session["ProjectName"] = (string)data.Project_Name;
            //Session["UnitName"] = (string)data.UNIT_NAME;
           // Session["UnitName"] = null;
           // ViewBag.ProjectName = Session["ProjectName"];
            return Json(new { data = dataGet }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AssetChildID(int assetDetailsCode)
        {
            Session["DetailsCode"] = assetDetailsCode;

            return Json(true);
        }


        [HttpPost]
        public ActionResult Edit_Asset_Data()
        {

            int detailsCode = Convert.ToInt32(Session["DetailsCode"]);
            //var dataGet;
            var dataGet = new AssetDetailsDTO();
            try
            {
                dataGet = classificationDAL.Edit_Asset_Data(detailsCode);



            }
            catch (Exception ex)
            {

                throw ex;
            }


            //  var dataGet = classificationDAL.Edit_Asset_Data(detailsCode);
            //  Session["AssetDetailsInfo"] = dataGet;
            //return Json(true);
            //return Json(new { data = dataGet });
            return Json(dataGet, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult EditAssetDetailsListView()
        {

            var assetDetailsCode = Convert.ToInt32(Session["AssetDetailsInfo"]);
            //  var dataGet = classificationDAL.Edit_Asset_Data(assetDetailsCode);
            // Session["Asset"] = dataGet.ASSET_CODE;
            // Session["Class"] = dataGet.ASSET_CLASS;
            //  Session[""] = _CustomerList;

            return Json(new { data = assetDetailsCode }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult OutletList()
        {
            try
            {
                string _Msg;
                DataTable dt_OutletList = classificationDAL.GetOutletList();

                if (dt_OutletList.Rows.Count > 0)
                {
                    _Msg = "DONE";
                    List<Dictionary<string, object>> _OutletList = _BasicUtilities.GetTableRows(dt_OutletList);
                    return Json(_OutletList);
                }
                else
                {
                    _Msg = "ERROR";
                    return Json(_Msg);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);

            }
        }
        public JsonResult updateAssetDetails(
      string parent_code,
      string serial_No,
      string order_No,
      string Order_Date,
      string challan_No,
      string Receive_Date,
      string warranty,
      string warranty_Type,
      string Efective_Date,
      string Disposed_Date,
      string condition_Id,
      string status,
      string outletSelect,
      string department_Id,
      string user_Code

 )
        {
            try
            {
                string _msg = string.Empty;

                string _Created_By = "7500016";

                DataTable cat = classificationDAL.UpdateAssetDetails(parent_code, serial_No, order_No, Order_Date, challan_No, Receive_Date, warranty, warranty_Type, Efective_Date, Disposed_Date, condition_Id, status, outletSelect, department_Id, user_Code, _Created_By);
                if (cat.Rows.Count > 0)
                {

                    _msg = cat.Rows[0].ToString();

                }

                return Json(_msg);
            }
            catch (System.Exception ex)
            {
                return Json(ex.Message);
            }
        }
        [HttpGet]
        public JsonResult AssetDetailsPeripheralList()
        {

            var assetCode = Convert.ToInt32(Session["DetailsCode"]);
            var dataGet = classificationDAL.getAssetPeripheralMasterDetailsData(assetCode);

            return Json(new { data = dataGet }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult MasterPeripheralList()
        {

            var segment = classificationDAL.MasterPeripheralList();

            return Json(new { data = segment }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult MasterComponentList()
        {

            var segment = classificationDAL.MasterComponentList();

            return Json(new { data = segment }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult AssetComponentPeripheralList()
        {

            var assetCode = Convert.ToInt32(Session["DetailsCode"]);
            var dataGet = classificationDAL.getAssetComponentMasterDetailsData(assetCode);

            return Json(new { data = dataGet }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getAssetDetailsPeripheralList(int parentCode, int peripheralCode)
        {
            var dataGet = new AssetDetailsDTO();
            try
            {
                dataGet = classificationDAL.getAssetDetailsPeripheralList(parentCode, peripheralCode);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            //var dataGet = classificationDAL.getAssetDetailsPeripheralList(peripheralCode);
            return Json(new { data = dataGet });

        }
        public ActionResult getAssetPeripheralList(int peripheralCode)
        {
            var dataGet = new AssetDetailsDTO();
            try
            {
                dataGet = classificationDAL.getAssetPeripheralList(peripheralCode);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            //var dataGet = classificationDAL.getAssetDetailsPeripheralList(peripheralCode);
            return Json(new { data = dataGet });

        }
        public ActionResult getAssetDetailsComponentList(int parentCode, int peripheralCode)
        {
            var dataGet = new AssetDetailsDTO();
            try
            {
                dataGet = classificationDAL.getAssetDetailsComponentList(parentCode, peripheralCode);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            //var dataGet = classificationDAL.getAssetDetailsPeripheralList(peripheralCode);
            return Json(new { data = dataGet });

        }
        public ActionResult getAssetDetailsComponent(int peripheralCode)
        {
            var dataGet = new AssetDetailsDTO();
            try
            {
                dataGet = classificationDAL.getAssetDetailsComponent(peripheralCode);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            //var dataGet = classificationDAL.getAssetDetailsPeripheralList(peripheralCode);
            return Json(new { data = dataGet });

        }
        public JsonResult UpdateMasterPeripheral(
      string parent_code,
      string peripheral_code,
      string p_serial_no,
      string p_external_tag

 )
        {
            try
            {
                string _msg = string.Empty;

                string _Created_By = "7500016";

                DataTable cat = classificationDAL.UpdateMasterPeripheral(peripheral_code, p_external_tag, p_serial_no, parent_code, _Created_By);
                if (cat.Rows.Count > 0)
                {

                    _msg = cat.Rows[0]["result"].ToString();

                }

                return Json(_msg);
            }
            catch (System.Exception ex)
            {
                return Json(ex.Message);
            }
        }
        public JsonResult UpdatePeripheralDetails(

    string peripheral_code,
    string p_serial_no,
    string p_external_tag

)
        {
            try
            {
                string _msg = string.Empty;

                string _Created_By = "7500016";

                DataTable cat = classificationDAL.UpdatePeripheralDetails(peripheral_code, p_external_tag, p_serial_no, _Created_By);
                if (cat.Rows.Count > 0)
                {

                    _msg = cat.Rows[0]["result"].ToString();

                }

                return Json(_msg);
            }
            catch (System.Exception ex)
            {
                return Json(ex.Message);
            }
        }
        [HttpPost]
        public JsonResult ArticleSlCheck(string _prifix)
        {
            List<Dictionary<string, object>> _ArticleSlCheck = new List<Dictionary<string, object>>();

            var result = classificationDAL.Article_Sl_Check(_prifix);

            _ArticleSlCheck = _BasicUtilities.GetTableRows(result);
            return Json(_ArticleSlCheck);
        }
        public JsonResult AreaList()
        {
            try
            {
                string _Msg;
                DataTable dt_ChannelList = classificationDAL.GetAreaList();

                if (dt_ChannelList.Rows.Count > 0)
                {
                    _Msg = "DONE";
                    List<Dictionary<string, object>> _ChannelList = _BasicUtilities.GetTableRows(dt_ChannelList);
                    return Json(_ChannelList);
                }
                else
                {
                    _Msg = "ERROR";
                    return Json(_Msg);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);

            }
        }

        public JsonResult ReferenceList()
        {
            try
            {
                string _Msg;
                DataTable dt_ChannelList = classificationDAL.GetReferenceList();

                if (dt_ChannelList.Rows.Count > 0)
                {
                    _Msg = "DONE";
                    List<Dictionary<string, object>> _ChannelList = _BasicUtilities.GetTableRows(dt_ChannelList);
                    return Json(_ChannelList);
                }
                else
                {
                    _Msg = "ERROR";
                    return Json(_Msg);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);

            }
        }

        public ActionResult SaveProject(
        string projectID,
        string projectName,
        string projectType,
        string Start_Date,
        string areaName,
        string address,
        string phoneNumber,
        string space,
        string referenceName,
        string referenceContact,
        bool activeStatus


      )
        {
            string _msg = string.Empty;

            try
            {
               
                string _Created_By = "7500016";
                string _dDname = "OUTLETCODE";
                long AllocationNo = classificationDAL.GETSERILANO(_dDname);
                if (!AllocationNo.Equals(AllocationNo))
                { }

                DataTable cat = classificationDAL.SaveProject(AllocationNo, projectName, projectType, Start_Date, areaName, address, phoneNumber, space, referenceName, referenceContact, activeStatus, _Created_By);

                if (cat.Rows.Count > 0)
                {
                    _msg = cat.Rows[0]["result"].ToString();

                }



            }
            catch (Exception ex)
            {

                throw ex;
            }

            return Json(_msg);
        }
        [HttpGet]
        public JsonResult ProjectList()
        {

            var category = classificationDAL.GetProject();

            return Json(new { data = category }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit_Project(int projectId)
        {
           
            var dataGet = classificationDAL.getProjectData(projectId);
            return Json(new { data = dataGet });
          

        }

        public JsonResult updateProject(
     string projectID,
        string projectName,
        string projectType,
        string Start_Date,
        string areaName,
        string address,
        string phoneNumber,
        string space,
        string referenceName,
        string referenceContact,
        bool activeStatus
                                                                                                                                              )
        {
            try
            {
                string _msg = string.Empty;

                string _Created_By = "7500016";

                DataTable cat = classificationDAL.UpdateProject(projectID, projectName, projectType, Start_Date, areaName, address, phoneNumber, space, referenceName, referenceContact, activeStatus, _Created_By);
                if (cat.Rows.Count > 0)
                {

                    _msg = cat.Rows[0]["result"].ToString();

                }

                return Json(_msg);
            }
            catch (System.Exception ex)
            {
                return Json(ex.Message);
            }
        }


        public ActionResult SaveUnit(
        string unitId,
        string ProjectList,
        string unitName,
        string address,
        string space,
        string spaceUnit,
        string unitType,
        string remarks,
         bool activeStatus


      )
        {
            string _msg = string.Empty;

            try
            {

                string _Created_By = "7500016";
                DataTable cat = classificationDAL.SaveUnit(unitId, ProjectList, unitName, address, space, spaceUnit, unitType, remarks, activeStatus, _Created_By);

                if (cat.Rows.Count > 0)
                {
                    _msg = cat.Rows[0]["result"].ToString();

                }



            }
            catch (Exception ex)
            {

                throw ex;
            }

            return Json(_msg);
        }
        [HttpGet]
        public JsonResult UnitListData()
        {

            var category = classificationDAL.GetUnit();

            return Json(new { data = category }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit_Unit(int unitId)
        {
           
            var dataGet = classificationDAL.getUnitData(unitId);
           
            return Json(new { data = dataGet });
         


        }
        public JsonResult updateUnit(
        string unitId,
        string ProjectList,
        string unitName,
        string address,
        string space,
        string spaceUnit,
        string unitType,
        string remarks,
        bool activeStatus
                                                                                                                                            )
        {
            try
            {
                string _msg = string.Empty;

                string _Created_By = "7500016";

                DataTable cat = classificationDAL.updateUnit(unitId, ProjectList, unitName, address, space, spaceUnit, unitType, remarks, activeStatus, _Created_By);
                if (cat.Rows.Count > 0)
                {

                    _msg = cat.Rows[0]["result"].ToString();

                }

                return Json(_msg);
            }
            catch (System.Exception ex)
            {
                return Json(ex.Message);
            }
        }
        public ActionResult SaveLandlord(
       string landlordName,
       string address,
       string email,
       string phone_1,
       string phone_2,
      bool activeStatus


     )
        {
            string _msg = string.Empty;

            try
            {

                string _Created_By = "7500016";
                int _instanceId = 0;
                DataTable cat = classificationDAL.SaveLandlord("", landlordName, phone_1, phone_2, address, email, _instanceId, activeStatus, _Created_By);

                if (cat.Rows.Count > 0)
                {
                    _msg = cat.Rows[0]["result"].ToString();

                }



            }
            catch (Exception ex)
            {

                throw ex;
            }

            return Json(_msg);
        }
        [HttpGet]
        public JsonResult LandlordList(string _model_list)
        {

            var category = classificationDAL.GetLandlord();

            return Json(new { data = category }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit_Landlord(int landlordId)
        {
            var dataGet = classificationDAL.getLandlordData(landlordId);
            return Json(new { data = dataGet });

        }
        public JsonResult updateLandlord(
            string landlordId,
       string landlordName,
       string address,
       string email,
       string phone_1,
       string phone_2,
       bool activeStatus
                                                                                                                                          )
        {
            try
            {
                string _msg = string.Empty;

                string _Created_By = "7500016";
                int _instanceId = 0;

                DataTable cat = classificationDAL.updateLandlord(landlordId, landlordName, phone_1, phone_2, address, email, _instanceId, activeStatus, _Created_By);
                if (cat.Rows.Count > 0)
                {

                    _msg = cat.Rows[0]["result"].ToString();

                }

                return Json(_msg);
            }
            catch (System.Exception ex)
            {
                return Json(ex.Message);
            }
        }
        public JsonResult RentProjectList()
        {
            try
            {
                string _Msg;
                DataTable dt_ChannelList = classificationDAL.GetRentProjectList();

                if (dt_ChannelList.Rows.Count > 0)
                {
                    _Msg = "DONE";
                    List<Dictionary<string, object>> _ChannelList = _BasicUtilities.GetTableRows(dt_ChannelList);
                    return Json(_ChannelList);
                }
                else
                {
                    _Msg = "ERROR";
                    return Json(_Msg);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);

            }
        }
        public JsonResult RentLandlordList()
        {
            try
            {
                string _Msg;
                DataTable dt_ChannelList = classificationDAL.GetRentLandlordList();

                if (dt_ChannelList.Rows.Count > 0)
                {
                    _Msg = "DONE";
                    List<Dictionary<string, object>> _ChannelList = _BasicUtilities.GetTableRows(dt_ChannelList);
                    return Json(_ChannelList);
                }
                else
                {
                    _Msg = "ERROR";
                    return Json(_Msg);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);

            }
        }
        public JsonResult UnitLandlordList(string _unitId)
        {
            try
            {
                string _Msg;
                DataTable dt_ChannelList = classificationDAL.GetUnitLandlordList(_unitId);

                if (dt_ChannelList.Rows.Count > 0)
                {
                    _Msg = "DONE";
                    List<Dictionary<string, object>> _ChannelList = _BasicUtilities.GetTableRows(dt_ChannelList);
                    return Json(_ChannelList);
                }
                else
                {
                    _Msg = "ERROR";
                    return Json(_Msg);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);

            }
        }
        public JsonResult UnitList(string _projectId)
        {
            try
            {
                string _Msg;
                DataTable dt_ChannelList = classificationDAL.GetUnitList(_projectId);

                if (dt_ChannelList.Rows.Count > 0)
                {
                    _Msg = "DONE";
                    List<Dictionary<string, object>> _ChannelList = _BasicUtilities.GetTableRows(dt_ChannelList);
                    return Json(_ChannelList);
                }
                else
                {
                    _Msg = "ERROR";
                    return Json(_Msg);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);

            }
        }
        public JsonResult Agreementist(string _unitId)
        {
            try
            {
                string _Msg;
                DataTable dt_ChannelList = classificationDAL.GetAgreementist(_unitId);

                if (dt_ChannelList.Rows.Count > 0)
                {
                    _Msg = "DONE";
                    List<Dictionary<string, object>> _ChannelList = _BasicUtilities.GetTableRows(dt_ChannelList);
                    return Json(_ChannelList);
                }
                else
                {
                    _Msg = "ERROR";
                    return Json(_Msg);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);

            }
        }
        public ActionResult SaveAgreement(
     string ProjectList,
     string UnitList,
     string agreementId,
     string contractType,
     string start_Date_of_Agreement,
     string Tenor,
     string end_Date_of_Agreement,
     string advance_Amount,
     string rent_Pay,
     string monthlyRentTaxBased,
     string agrement_Hand_Over_Date,
     string actual_Hand_Over_Date,
     string rent_Count,
     string actual_Rent_Start_Date,
     string actual_Rent_End_Date,
     string actual_Advance_Start_Date,
     string advance_Adjustment_Amount,
     string notice_Period,
     string aIT_Paid_By,
     string increment_Type,
     string rent_Increment,
     string increment_Intervale,
     string payment_Term,
     string Rent_Pay_Date,
     string remRent,
     string remTax,
     bool activeStatus


   )
        {
            string _msg = string.Empty;

            try
            {

                string _Created_By = "7500016";
                int _instanceId = 0;
                DataTable cat = classificationDAL.SaveAgreement(agreementId, ProjectList, UnitList, contractType, start_Date_of_Agreement, Tenor, end_Date_of_Agreement, advance_Amount, rent_Pay, monthlyRentTaxBased,
                    agrement_Hand_Over_Date, actual_Hand_Over_Date, rent_Count, actual_Rent_Start_Date, actual_Rent_End_Date, actual_Advance_Start_Date, advance_Adjustment_Amount,
                    notice_Period, aIT_Paid_By, increment_Type,rent_Increment, increment_Intervale, payment_Term, _instanceId, Rent_Pay_Date, remRent, remTax, activeStatus, _Created_By);

                if (cat.Rows.Count > 0)
                {
                    _msg = cat.Rows[0]["result"].ToString();

                }



            }
            catch (Exception ex)
            {


                throw ex;
            }

            return Json(_msg);
        }
        [HttpGet]
        public JsonResult AgreementList(string _model_list)
        {

            var category = classificationDAL.AgreementList();

            return Json(new { data = category }, JsonRequestBehavior.AllowGet);
        }
        //[HttpGet]
        //public JsonResult NewAgreementList(string _model_list)
        //{

        //    var category = classificationDAL.NewAgreementList();

        //    return Json(new { data = category }, JsonRequestBehavior.AllowGet);
        //}
        public ActionResult Edit_Agreement(int agreementId)
        {
            var dataGet = classificationDAL.getAgreementData(agreementId);
            return Json(new { data = dataGet });

        }
        public JsonResult updateAgreement(
      string ProjectList,
     string UnitList,
     string agreementId,
     string contractType,
     string start_Date_of_Agreement,
     string Tenor,
     string end_Date_of_Agreement,
     string advance_Amount,
     string rent_Pay,
     string monthlyRentTaxBased,
     string agrement_Hand_Over_Date,
     string actual_Hand_Over_Date,
     string rent_Count,
     string actual_Rent_Start_Date,
     string actual_Rent_End_Date,
     string actual_Advance_Start_Date,
     string advance_Adjustment_Amount,
     string notice_Period,
     string aIT_Paid_By,
     string increment_Type,
     string rent_Increment,
     string increment_Intervale,
     string payment_Term,
     string Rent_Pay_Date,
     string remRent,
     string remTax,
     bool activeStatus)
        {
            try
            {
                string _msg = string.Empty;
                int _instanceId = 0;
                string _Created_By = "7500016";

                DataTable cat = classificationDAL.UpdateAgreement(agreementId, ProjectList, UnitList, contractType, start_Date_of_Agreement, Tenor, end_Date_of_Agreement, advance_Amount, rent_Pay, monthlyRentTaxBased,
                    agrement_Hand_Over_Date, actual_Hand_Over_Date, rent_Count, actual_Rent_Start_Date, actual_Rent_End_Date, actual_Advance_Start_Date, advance_Adjustment_Amount,
                    notice_Period, aIT_Paid_By, increment_Type, rent_Increment, increment_Intervale, payment_Term, _instanceId, Rent_Pay_Date, remRent, remTax, activeStatus, _Created_By);
                if (cat.Rows.Count > 0)
                {

                    _msg = cat.Rows[0]["result"].ToString();

                }

                return Json(_msg);
            }
            catch (System.Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public ActionResult SaveRentShare(
   int ProjectList,
   int UnitList,
   int LandlordList,
   int share,
   bool activeStatus


 )
        {
            string _msg = string.Empty;

            try
            {

                string _Created_By = "7500016";
                int lndShareId = 0;
                //  int _instanceId = 0;
                DataTable cat = classificationDAL.SaveRentShare(lndShareId, ProjectList, UnitList, LandlordList, share, activeStatus, _Created_By);

                if (cat.Rows.Count > 0)
                {
                    _msg = cat.Rows[0]["result"].ToString();

                }



            }
            catch (Exception ex)
            {

                throw ex;
            }

            return Json(_msg);
        }
        [HttpGet]
        public JsonResult RentShareList(string _model_list)
        {

            var category = classificationDAL.GetRentShare();

            return Json(new { data = category }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit_Rent_Share(int landlordShareId)
        {
            var dataGet = classificationDAL.getRentShareData(landlordShareId);
            return Json(new { data = dataGet });

        }
        public JsonResult updateRentShare(
   int LandShare_Id,
   int ProjectList,
   int UnitList,
   int LandlordList,
   int share,
   bool activeStatus
                                                                                                                                        )
        {
            try
            {
                string _msg = string.Empty;

                string _Created_By = "7500016";

                DataTable cat = classificationDAL.updateRentShare(LandShare_Id, ProjectList, UnitList, LandlordList, share, activeStatus, _Created_By);
                if (cat.Rows.Count > 0)
                {

                    _msg = cat.Rows[0]["result"].ToString();

                }

                return Json(_msg);
            }
            catch (System.Exception ex)
            {
                return Json(ex.Message);
            }
        }
        public ActionResult SaveRentVat(
      string name,
      string description,
      string vat_Start_Date,
      string vat_End_Date,
      string vat_Percentage,
      string remarks,
      bool activeStatus


    )
        {
            string _msg = string.Empty;

            try
            {

                string _Created_By = "7500016";
                string vatId = "0";
                DataTable cat = classificationDAL.SaveRentVat(vatId, name, description, vat_Start_Date, vat_End_Date, vat_Percentage, remarks, activeStatus, _Created_By);

                if (cat.Rows.Count > 0)
                {
                    _msg = cat.Rows[0]["result"].ToString();

                }



            }
            catch (Exception ex)
            {

                throw ex;
            }

            return Json(_msg);
        }
        [HttpGet]
        public JsonResult RentVatList(string _model_list)
        {

            var category = classificationDAL.GetRentVat();

            return Json(new { data = category }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit_RentVat(int vatId)
        {
            var dataGet = classificationDAL.getRentVatData(vatId);
            return Json(new { data = dataGet });

        }
        public JsonResult updateRentVat(
      string vat_Id,
      string name,
      string description,
      string vat_Start_Date,
      string vat_End_Date,
      string vat_Percentage,
      string remarks,
      bool activeStatus

                                                                                                                                       )
        {
            try
            {
                string _msg = string.Empty;

                string _Created_By = "7500016";


                DataTable cat = classificationDAL.updateRentVat(vat_Id, name, description, vat_Start_Date, vat_End_Date, vat_Percentage, remarks, activeStatus, _Created_By);
                if (cat.Rows.Count > 0)
                {

                    _msg = cat.Rows[0]["result"].ToString();

                }

                return Json(_msg);
            }
            catch (System.Exception ex)
            {
                return Json(ex.Message);
            }
        }
        public ActionResult SaveRentAIT(
     string name,
     string description,
     string ait_Start_Date,
     string ait_End_Date,
     string ait_Percentage,
     string remarks,
     bool activeStatus


   )
        {
            string _msg = string.Empty;

            try
            {

                string _Created_By = "7500016";
                string aitId = "0";
                DataTable cat = classificationDAL.SaveRentAIT(aitId, name, description, ait_Start_Date, ait_End_Date, ait_Percentage, remarks, activeStatus, _Created_By);

                if (cat.Rows.Count > 0)
                {
                    _msg = cat.Rows[0]["result"].ToString();

                }



            }
            catch (Exception ex)
            {

                throw ex;
            }

            return Json(_msg);
        }
        [HttpGet]
        public JsonResult RentAITList(string _model_list)
        {

            var category = classificationDAL.GetRentAIT();

            return Json(new { data = category }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit_RentAIT(int AITId)
        {
            var dataGet = classificationDAL.getRentAITData(AITId);
            return Json(new { data = dataGet });

        }
        public JsonResult updateRentAIT(
     string art_id,
     string name,
     string description,
     string ait_Start_Date,
     string ait_End_Date,
     string ait_Percentage,
     string remarks,
     bool activeStatus

                                                                                                                                     )
        {
            try
            {
                string _msg = string.Empty;

                string _Created_By = "7500016";


                DataTable cat = classificationDAL.updateRentAIT(art_id, name, description, ait_Start_Date, ait_End_Date, ait_Percentage, remarks, activeStatus, _Created_By);
                if (cat.Rows.Count > 0)
                {

                    _msg = cat.Rows[0]["result"].ToString();

                }

                return Json(_msg);
            }
            catch (System.Exception ex)
            {
                return Json(ex.Message);
            }
        }
        public ActionResult SaveRentIntervale(
   string ProjectList,
   string UnitList,
   string AgreementList,
   string intervale_Count,
   string intervale_Start_Date,
   string intervale_End_Date,
   string intervale_Amount


 )
        {
            string _msg = string.Empty;

            try
            {

                string _Created_By = "7500016";
                DataTable cat = classificationDAL.SaveRentIntervale(ProjectList, UnitList, AgreementList, intervale_Count, intervale_Start_Date, intervale_End_Date, intervale_Amount, _Created_By);

                if (cat.Rows.Count > 0)
                {
                    _msg = cat.Rows[0]["result"].ToString();

                }



            }
            catch (Exception ex)
            {
                 
                throw ex;
            }

            return Json(_msg);
        }
        [HttpPost]
        public ActionResult GetSlotAgreement(string first_start_date, string next_Rent_intervale_Date,string last_day_ofnext_Rent_intervale_Date,  string rent_after_increment,string vat_after_increment)
        {
            //string _next_Rent_intervale_Date = next_Rent_intervale_Date.TrimEnd(',');
            //string _rent_after_increment = rent_after_increment.TrimEnd(',');
            List<Dictionary<string, object>> _JesonTabl = new List<Dictionary<string, object>>();
            //     |||||||||||||||||||||||||||||||||
            //_next_Rent_intervale_Date || rent_after_increment
            //|||9/1/ 2023 || 1333
            ////|||
            //List<string> next_Rent_intervale_DateList = _next_Rent_intervale_Date.Split(',').ToList();
            //List<string> rent_after_incrementList = _rent_after_increment.Split(',').ToList();
            Session["First_start_date"] = null;

            List<Dictionary<string, object>> _Temp_Bill = new List<Dictionary<string, object>>();// _BasicUtilities.GetTableRows(dt_result);
            DataTable _Temp = new DataTable();

            _Temp.Columns.Add("next_Rent_intervale_Date", typeof(string));
            _Temp.Columns.Add("last_day_ofnext_Rent_intervale_Date", typeof(string));
            _Temp.Columns.Add("rent_after_increment", typeof(string));
            _Temp.Columns.Add("vat_after_increment", typeof(string));

            string[] names = next_Rent_intervale_Date.Split(',');
            string[] lastday = last_day_ofnext_Rent_intervale_Date.Split(',');
            string[] values = rent_after_increment.Split(',');
            string[] vat = vat_after_increment.Split(',');
            Session["First_start_date"] = first_start_date;

            if (names.Length > 1)
            {
                for (int i = 0; i < names.Length - 1; i++)
                {
                    _Temp.Rows.Add(new object[] { names[i], lastday[i], values[i], vat[i] });
                }
            }
            else
            {
                for (int i = 0; i < names.Length; i++)
                {
                    _Temp.Rows.Add(new object[] { names[i], lastday[i], values[i], vat[i] });
                }
            }
            

            _JesonTabl = _BasicUtilities.GetTableRows(_Temp);


            return Json(_JesonTabl, JsonRequestBehavior.AllowGet);

        }
        //public ActionResult Get_Agreement_Details(int agreementId)
        //{
        //    var dataGet = classificationDAL.Get_Agreement_Details(agreementId);
        //    return Json(new { data = dataGet });

        // }
        [HttpPost]
        public ActionResult Get_Agreement_Details(int agreementId)
        {

            var category = classificationDAL.Get_Agreement_Details(agreementId);

            return Json(new { data = category }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Get_Payment_Details(string first_Day_Of_Month, string end_Day_Of_Month)
        {
            //DateTime date = DateTime.ParseExact(first_Day_Of_Month, "dd/MM/yyyy", null);
            //DateTime datef = DateTime.ParseExact(end_Day_Of_Month, "dd/MM/yyyy", null);
            var category = classificationDAL.Get_Payment_Details(first_Day_Of_Month, end_Day_Of_Month);

            return Json(new { data = category }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SaveAgreementIncrement(
  string ProjectList,
  string UnitList,
  string agreementId,
  string _Start_Date,
  string _End_Date,
  string _Increment_Amount,
  string _Increment_VAT
// bool activeStatus


)
        {
            string _msg = string.Empty;

            try
            {

                string _Created_By = "7500016";
                string status = "1";

                string v_Start_Date = _Start_Date.TrimEnd(',');
                string v_End_Date = _End_Date.TrimEnd(',');
                string v_Increment_Amount = _Increment_Amount.TrimEnd(',');
                string v_Increment_VAT = _Increment_VAT.TrimEnd(',');

                List<string> StartDateList = v_Start_Date.Split(',').ToList();
                List<string> EndDateList = v_End_Date.Split(',').ToList();
                List<string> Increment_AmountList = v_Increment_Amount.Split(',').ToList();
                List<string> Increment_VatList = v_Increment_VAT.Split(',').ToList();



                var RentIncrement = new DataTable();
              
                if (!string.IsNullOrEmpty(v_Start_Date))
                {

                    var rentIncrement = classificationDAL.checkRentIncrement(agreementId);
                    if (rentIncrement==0)
                    {
                        for (int i = 0; i < StartDateList.Count; i++)
                        {
                            RentIncrement = classificationDAL.SaveRentIncrement(agreementId, ProjectList, UnitList, StartDateList[i], EndDateList[i], Increment_AmountList[i], Increment_VatList[i], _Created_By, status);
                        }
                    }
                  
                }



            }
            catch (Exception ex)
            {


                throw ex;
            }

            return Json(_msg);
        }
        public ActionResult Agreement_increment(int agreementId)
        {
            var dataGet = classificationDAL.getAgreementIncrementData(agreementId);
            return Json(new { data = dataGet });

        }
             public ActionResult SaveRentDetails(
  string ProjectList,
  string UnitList,
  int agreementId,
  string _Expec_Rent_Pay_Date,
  string advance_Amount,
  string _Increment_Amount,
  string _Increment_VAT
// bool activeStatus


)
        {
            string _msg = string.Empty;

            try
            {

                string _Created_By = "7500016";
               string actual_Rent_Pay_Date = "";
                string monthly_advance_adjust = "0";
                string monthly_AIT_agree = "0";
                string monthly_AIT_not_agree = "0";
                string VAT = "0";
                string status = "1";

                string v_Expec_Rent_Pay_Date = _Expec_Rent_Pay_Date.TrimEnd(',');
                string v_Increment_Amount = _Increment_Amount.TrimEnd(',');
                string v_Increment_VAT = _Increment_VAT.TrimEnd(',');

                List<string> ExpecRentPayDateList = v_Expec_Rent_Pay_Date.Split(',').ToList();
                List<string> Increment_AmountList = v_Increment_Amount.Split(',').ToList();
                List<string> Increment_VatList = v_Increment_VAT.Split(',').ToList();



                var RentIncrement = new DataTable();
              
                if (!string.IsNullOrEmpty(v_Expec_Rent_Pay_Date))
                {
                    var rent = classificationDAL.checkRentDetails(agreementId);
                    if (rent == 0)
                    {
                        for (int i = 0; i < ExpecRentPayDateList.Count; i++)
                        {
                            RentIncrement = classificationDAL.SaveRentDetails(agreementId, ProjectList, UnitList, ExpecRentPayDateList[i], actual_Rent_Pay_Date, advance_Amount, Increment_AmountList[i], monthly_advance_adjust, Increment_VatList[i], monthly_AIT_agree, monthly_AIT_not_agree, VAT, _Created_By, status);
                        }
                    }
                  
                }



            }
            catch (Exception ex)
            
            {


                throw ex;
            }

            return Json(_msg);
        }
        public ActionResult SaveRentPayee(
 int ProjectList,
 int UnitList,
 int LandlordList,
 string payee_Name,
 string relation,
 string cash,
 string mobile_Banking_Type,
 string mobile_Banking_Amount,
 string BankName_0,
 string BankDistrict_0,
 string BranchName_0,
 string routing_Number,
 string account_Number,
 string amount
 
)
        {
            string _msg = string.Empty;
            bool activeStatus = true;
            try
            {

                string _Created_By = "7500016";
                int rentPayee_Id = 0;
                // int lndShareId = 0;
                //  int _instanceId = 0;
                DataTable cat = classificationDAL.SaveRentPayee(rentPayee_Id, ProjectList, UnitList, LandlordList, payee_Name, relation, cash, mobile_Banking_Type, mobile_Banking_Amount, BankName_0, BankDistrict_0, BranchName_0, routing_Number, account_Number, amount, activeStatus, _Created_By);

                if (cat.Rows.Count > 0)
                {
                    _msg = cat.Rows[0]["result"].ToString();

                }



            }
            catch (Exception ex)
            {

                throw ex;
            }

            return Json(_msg);
        }

        [HttpGet]
        public JsonResult RentPayeeList(string _model_list)
        {

            var category = classificationDAL.GetRentPayee();

            return Json(new { data = category }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit_Rent_Payee(int rentPayeeId)
        {
            var dataGet = classificationDAL.getRentPayeeData(rentPayeeId);
            return Json(new { data = dataGet });

        }
        public JsonResult updateRentPayee(
 int rentPayee_Id,
int ProjectList,
 int UnitList,
 int LandlordList,
 string payee_Name,
 string relation,
 string cash,
 string mobile_Banking_Type,
 string mobile_Banking_Amount,
 string BankName_0,
 string BankDistrict_0,
 string BranchName_0,
 string routing_Number,
 string account_Number,
 string amount

                                                                                                                                   )
        {
            try
            {
                string _msg = string.Empty;
                bool activeStatus = true;

                string _Created_By = "7500016";
                //int rentPayee_Id = 0;

                DataTable cat = classificationDAL.updateRentPayee(rentPayee_Id, ProjectList, UnitList, LandlordList, payee_Name, relation, cash, mobile_Banking_Type, mobile_Banking_Amount, BankName_0, BankDistrict_0, BranchName_0, routing_Number, account_Number, amount, activeStatus, _Created_By);
                if (cat.Rows.Count > 0)
                {

                    _msg = cat.Rows[0]["result"].ToString();

                }

                return Json(_msg);
            }
            catch (System.Exception ex)
            {
                return Json(ex.Message);
            }
        }
        public JsonResult RentYearList()
        {
            try
            {
                string _Msg;
                DataTable dt_ChannelList = classificationDAL.GetRentYearList();

                if (dt_ChannelList.Rows.Count > 0)
                {
                    _Msg = "DONE";
                    List<Dictionary<string, object>> _ChannelList = _BasicUtilities.GetTableRows(dt_ChannelList);
                    return Json(_ChannelList);
                }
                else
                {
                    _Msg = "ERROR";
                    return Json(_Msg);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);

            }
        }
        public JsonResult MonthList(string _yearId)
        {
            try
            {
                string _Msg;
                DataTable dt_ChannelList = classificationDAL.GetMonthList(_yearId);

                if (dt_ChannelList.Rows.Count > 0)
                {
                    _Msg = "DONE";
                    List<Dictionary<string, object>> _ChannelList = _BasicUtilities.GetTableRows(dt_ChannelList);
                    return Json(_ChannelList);
                }
                else
                {
                    _Msg = "ERROR";
                    return Json(_Msg);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);

            }
        }
        public JsonResult FirstDayOfMonthList()
        {
            try
            {
                string _Msg;
                DataTable dt_ChannelList = classificationDAL.GetFirstDayOfMonthList();

                if (dt_ChannelList.Rows.Count > 0)
                {
                    _Msg = "DONE";
                    List<Dictionary<string, object>> _ChannelList = _BasicUtilities.GetTableRows(dt_ChannelList);
                    return Json(_ChannelList);
                }
                else
                {
                    _Msg = "ERROR";
                    return Json(_Msg);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);

            }
        }
        public JsonResult EndDayOfMonthList()
        {
            try
            {
                string _Msg;
                DataTable dt_ChannelList = classificationDAL.GetEndDayOfMonthList();

                if (dt_ChannelList.Rows.Count > 0)
                {
                    _Msg = "DONE";
                    List<Dictionary<string, object>> _ChannelList = _BasicUtilities.GetTableRows(dt_ChannelList);
                    return Json(_ChannelList);
                }
                else
                {
                    _Msg = "ERROR";
                    return Json(_Msg);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);

            }
        }
        public ActionResult SaveRentPayment(
string first_Day_Of_Month,
string _Expec_Rent_Pay_Date,
string _Act_Rent_Pay_Date,
string _project,
string _unit,
string _agreement,
string _balance,
string _monthly_rent,
string _adv_adjust,
string _tax_rent,
string _ait_paid,
string _ait_per,
string _ait_amount,
string _vat_per,
string _vat_amt,
string _disc_rent,
string _disc_ait,
string _disc_vat,
string _disc_adv,
string _monthly_rent_payment,
string _monthly_rent_expense,
string _adjusted_balance,
string _rent_details_id
// bool activeStatus


)
        {
            string _msg = string.Empty;

            try
            {

                string _Created_By = "7500016";
                //string actual_Rent_Pay_Date = "";
                string rent_Discount = "0";
                //string monthly_AIT_agree = "0";
                //string monthly_AIT_not_agree = "0";
                //string VAT = "0";
                string status = "1";

                string v_Expec_Rent_Pay_Date = _Expec_Rent_Pay_Date.TrimEnd(',');
                string v_Act_Rent_Pay_Date = _Act_Rent_Pay_Date.TrimEnd(',');
                string v_project = _project.TrimEnd(',');
                string v_unit = _unit.TrimEnd(',');
                string v_agreement = _agreement.TrimEnd(',');
                string v_balance = _balance.TrimEnd(',');
                string v_monthly_rent = _monthly_rent.TrimEnd(',');
                string v_adv_adjust = _adv_adjust.TrimEnd(',');
                string v_tax_rent = _tax_rent.TrimEnd(',');
                string v_ait_paid = _ait_paid.TrimEnd(',');
                string v_ait_per = _ait_per.TrimEnd(',');
                string v_ait_amount = _ait_amount.TrimEnd(',');
                string v_vat_per = _vat_per.TrimEnd(',');
                string v_vat_amt = _vat_amt.TrimEnd(',');
                string v_disc_rent = _disc_rent.TrimEnd(',');
                string v_disc_ait = _disc_ait.TrimEnd(',');
                string v_disc_vat = _disc_vat.TrimEnd(',');
                string v_disc_adv = _disc_adv.TrimEnd(',');
                string v_monthly_rent_payment = _monthly_rent_payment.TrimEnd(',');
                string v_monthly_rent_expense = _monthly_rent_expense.TrimEnd(',');
                string v_adjusted_balance = _adjusted_balance.TrimEnd(',');
                string v_rent_details_id = _rent_details_id.TrimEnd(',');


                List<string> ExpecRentPayDateList = v_Expec_Rent_Pay_Date.Split(',').ToList();
                List<string> ActRentPayDateList = v_Act_Rent_Pay_Date.Split(',').ToList();
                List<string> ProjectList = v_project.Split(',').ToList();
                List<string> UnitList = v_unit.Split(',').ToList();
                List<string> AgreementList = v_agreement.Split(',').ToList();
                List<string> BalanceList = v_balance.Split(',').ToList();
                List<string> Monthly_rentList = v_monthly_rent.Split(',').ToList();
                List<string> AdvadjustList = v_adv_adjust.Split(',').ToList();
                List<string> TaxrentList = v_tax_rent.Split(',').ToList();
                List<string> AitpaidList = v_ait_paid.Split(',').ToList();
                List<string> AitperList = v_ait_per.Split(',').ToList();
                List<string> AitamountList = v_ait_amount.Split(',').ToList();
                List<string> VatperList = v_vat_per.Split(',').ToList();
                List<string> VatamtList = v_vat_amt.Split(',').ToList();
                List<string> DiscrentList = v_disc_rent.Split(',').ToList();
                List<string> DiscaitList = v_disc_ait.Split(',').ToList();
                List<string> DiscvatList = v_disc_vat.Split(',').ToList();
                List<string> DiscadvList = v_disc_adv.Split(',').ToList();
                List<string> MonthlyRentPaymentList = v_monthly_rent_payment.Split(',').ToList();
                List<string> MonthlyRentExpenseList = v_monthly_rent_expense.Split(',').ToList();
                List<string> AdjustedBalanceList = v_adjusted_balance.Split(',').ToList();
                List<string> RentDetailsIdList = v_rent_details_id.Split(',').ToList();




                var RentIncrement = new DataTable();

                if (!string.IsNullOrEmpty(v_Expec_Rent_Pay_Date))
                {
                    var rentPayment = classificationDAL.checkRentPayment(first_Day_Of_Month);
                    if (rentPayment==0)
                    {
                        for (int i = 0; i < ExpecRentPayDateList.Count; i++)
                        {
                            RentIncrement = classificationDAL.SaveRentPayment(first_Day_Of_Month, ExpecRentPayDateList[i], ActRentPayDateList[i], ProjectList[i], UnitList[i], AgreementList[i], BalanceList[i], Monthly_rentList[i], AdvadjustList[i], TaxrentList[i], AitpaidList[i], AitperList[i], AitamountList[i], VatperList[i],
                             VatamtList[i], DiscrentList[i], DiscaitList[i], DiscvatList[i], DiscadvList[i], MonthlyRentPaymentList[i], MonthlyRentExpenseList[i], AdjustedBalanceList[i], RentDetailsIdList[i], _Created_By, status);
                        }
                    }
                   
                }



            }
            catch (Exception ex)
            {


                throw ex;
            }

            return Json(_msg);
        }
        //[HttpPost]
        //public ActionResult GetEndOfAgreement(int Tenor, string start_Date_of_Agreement)
        //{

        //    var category = classificationDAL.Get_Tenor(Tenor, start_Date_of_Agreement);

        //    return Json(new { data = category }, JsonRequestBehavior.AllowGet);
        //}
        public ActionResult GetEndOfAgreement(int Tenor, string start_Date_of_Agreement)
        {
            var dataGet = classificationDAL.Get_Tenor(Tenor, start_Date_of_Agreement);
            return Json(new { data = dataGet });

        }
        public ActionResult GetRentStartDate(int rent_Count, string actual_Hand_Over_Date)
        {
            var dataGet = classificationDAL.GetRentStartDate(rent_Count, actual_Hand_Over_Date);
            return Json(new { data = dataGet });

        }
        public ActionResult GetEndOfRent(int Tenor, string actual_Rent_Start_Date)
        {
            var dataGet = classificationDAL.GetEndOfRent(Tenor, actual_Rent_Start_Date);
            return Json(new { data = dataGet });

        }
        public ActionResult SaveDiscount(
   string discountId,
   string ProjectList,
   string UnitList,
   string AgreementList,
   string discount_Rent_Start_Date,
   string discount_Rent_End_Date,
   string rent_Discount_Type,
   string rent_Amount,
   string advance_Calculate_Type,
   string advance_Amount,
   string aIT_Calculate_Type,
   string aIT_Amount,
   bool activeStatus


 )
        {
            string _msg = string.Empty;

            try
            {

                string _Created_By = "7500016";
              //  int _instanceId = 0;
                DataTable cat = classificationDAL.SaveDiscount(discountId,ProjectList, UnitList, AgreementList, discount_Rent_Start_Date, discount_Rent_End_Date, rent_Discount_Type, rent_Amount, advance_Calculate_Type, advance_Amount,
                    aIT_Calculate_Type, aIT_Amount, activeStatus, _Created_By);

                if (cat.Rows.Count > 0)
                {
                    _msg = cat.Rows[0]["result"].ToString();

                }



            }
            catch (Exception ex)
            {


                throw ex;
            }

            return Json(_msg);
        }
        [HttpGet]
        public JsonResult RentDiscountList(string _model_list)
        {

            var category = classificationDAL.GetRentDiscount();

            return Json(new { data = category }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit_RentDiscount(int discountId)
        {
            var dataGet = classificationDAL.getRentDiscountData(discountId);
            return Json(new { data = dataGet });

        }
        public JsonResult updateRentDiscount(
     string discountId,
   string ProjectList,
   string UnitList,
   string AgreementList,
   string discount_Rent_Start_Date,
   string discount_Rent_End_Date,
   string rent_Discount_Type,
   string rent_Amount,
   string advance_Calculate_Type,
   string advance_Amount,
   string aIT_Calculate_Type,
   string aIT_Amount,
   bool activeStatus
)
        {
            try
            {
                string _msg = string.Empty;
            //    int _instanceId = 0;
                string _Created_By = "7500016";

                DataTable cat = classificationDAL.UpdateRentDiscount(discountId, ProjectList, UnitList, AgreementList, discount_Rent_Start_Date, discount_Rent_End_Date, rent_Discount_Type, rent_Amount, advance_Calculate_Type, advance_Amount,
                    aIT_Calculate_Type, aIT_Amount, activeStatus, _Created_By);
                if (cat.Rows.Count > 0)
                {

                    _msg = cat.Rows[0]["result"].ToString();

                }

                return Json(_msg);
            }
            catch (System.Exception ex)
            {
                return Json(ex.Message);
            }
        }


        [HttpPost]
        public ActionResult Multiple(IEnumerable<HttpPostedFileBase> files)
        {
            foreach (var file in files)
            {
                if (file != null && file.ContentLength > 0)
                {
                    file.SaveAs(Path.Combine(Server.MapPath("~/uploads/"), Guid.NewGuid() + Path.GetExtension(file.FileName)));
                    //file.SaveAs(ServerSavePath);
                    //assigning file uploaded status to ViewBag for showing message to user.  
                    ViewBag.UploadStatus = files.Count().ToString() + " files uploaded successfully.";
                }
            }
            return View();
        }

















    }
}