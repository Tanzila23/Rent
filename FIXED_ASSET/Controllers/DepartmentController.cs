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

namespace FIXED_ASSET.Controllers
{
    public class DepartmentController : BaseController
    {
        UserDAL userDAL = new UserDAL();
        CategoryDTO categoryDTO = new CategoryDTO();
        ClassificationDAL classificationDAL = new ClassificationDAL();
        BasicUtilities _BasicUtilities = new BasicUtilities();
        // GET: Department
        public ActionResult Department()
        {
            if (Session[POSxSession.LoggedUser] == null)
            {
                return Redirect("/User/Login");
            }
            else
            {
                return View("~/Views/Category/Department.cshtml");
            }
        }


      [HttpPost]
      public ActionResult Save(
      string departmentId,
      string departmentCode,
      string departmentName,
      bool activeStatus
      //int rowStatus
      )
        {
            string _msg = string.Empty;

            try
            {

                string _Created_By = "7500016";
                DataTable cat = classificationDAL.SaveDepartment(departmentId, departmentCode, departmentName, _Created_By, activeStatus);

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

            var category = classificationDAL.GetDepartment();

            return Json(new { data = category }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Edit_it(int deptId)
        {
            var dataGet = classificationDAL.getDepartmentData(deptId);
            return Json(new { data = dataGet });

        }

        public JsonResult updateDepartment(
          string departmentId,
          string departmentCode,
          string departmentName,
          bool activeStatus
      )
        {
            try
            {
                string _msg = string.Empty;

                string _Created_By = "7500016";

                DataTable cat = classificationDAL.UpdateDepartment(departmentId, departmentCode, departmentName, _Created_By, activeStatus);
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
        public ActionResult Saveperipheral(
       string peripheralList,
       string TypeId,
       string ClassList,
       string Quantity


      )
        {
            string _msg = string.Empty;

            try
            {
                string _Created_By = "7500016";
                DataTable cat = classificationDAL.SaveperipheralData(peripheralList, TypeId, ClassList, Quantity, _Created_By);

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

        public ActionResult SaveAssetTransfer(
   string asset, string initialTag, string externalTag


   )
        {
            string _msg = string.Empty;

            try
            {
                string _Created_By = "7500016";
                DataTable cat = classificationDAL.SaveAssetTransfer(asset, initialTag, externalTag, _Created_By);

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
        public ActionResult Deleteperipheral(
     string PeripheralCode

    )
        {
            string _msg = string.Empty;

            try
            {
                string _Created_By = "7500016";
                DataTable cat = classificationDAL.DeleteperipheralData(PeripheralCode, _Created_By);

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
        public ActionResult DeleteComponent(
   string PeripheralCode

  )
        {
            string _msg = string.Empty;

            try
            {
                string _Created_By = "7500016";
                DataTable cat = classificationDAL.DeleteperipheralData(PeripheralCode, _Created_By);

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
    }
}