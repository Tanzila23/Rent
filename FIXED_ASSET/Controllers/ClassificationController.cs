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
    public class ClassificationController : BaseController
    {
        UserDAL userDAL = new UserDAL();
        CategoryDTO categoryDTO = new CategoryDTO();
        ClassificationDAL classificationDAL = new ClassificationDAL();
        BasicUtilities _BasicUtilities = new BasicUtilities();
        // GET: Classification
        public ClassificationController()
        {

        }
        // GET: Classification
        public ActionResult Classification()
        {
            if (Session[POSxSession.LoggedUser] == null)
            {
                return Redirect("/User/Login");
            }
            else
            {

                //string _Created_By = GetLoggedUserID();
                //string _Device_ID = _Created_By;
                //bool _Parmited = isPageParmited(_Created_By, _Device_ID);
                //// bool _Parmited = isPageParmited(_Created_By);
                //if (!_Parmited)
                //{
                //    return Redirect("/Home/");
                //}
                //ViewBag.formTitle = "Category Information";
                //ViewBag.CategoryList = categoryDAL.GetCategories();



                //ViewBag.ClassificationGridList = classificationDAL.GetClassification();
                return View("~/Views/Category/Classification.cshtml");
            }
        }

       

        //public ActionResult Save(ClassificationDTO classification)
        //{
        //    try
        //    {
        //        string _msg = string.Empty;

        //        string _Created_By = "7500016";



        //        DataTable cat = classificationDAL.SaveClassification(classification, _Created_By);
        //        if (cat.Rows.Count > 0)
        //        {

        //            //if (cat.Rows[0]["E_ID"].ToString() == category.eID)
        //            //{
        //            //    _msg = "Category ID" + cat.Rows[0]["result"].ToString();
        //            //}
        //            //if (cat.Rows[0]["SHNAME"].ToString() ==  category.sName)
        //            //{
        //            //    _msg = "Short Name" + cat.Rows[0]["result"].ToString();
        //            //}

        //            _msg = cat.Rows[0]["result"].ToString();

        //        }

        //        return Json(_msg);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        return Json(ex.Message);
        //    }
        //}

        [HttpPost]
        public ActionResult Save(
        string classificationId,
        string classificationCode,
        string classificationName,
         bool activeStatus
        //int rowStatus
        )
        {
            string _msg = string.Empty;

            try
            {

                string _Created_By = "7500016";
                DataTable cat = classificationDAL.SaveClassification(classificationId, classificationCode, classificationName, _Created_By, activeStatus);

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

            var category = classificationDAL.GetClassification();

            return Json(new { data = category }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Edit_it(int classId)
        {
            var dataGet = classificationDAL.getData(classId);
            return Json(new { data = dataGet });

        }


        public JsonResult updateClassification(
        string classificationId,
        string classificationCode,
        string classificationName,
        bool activeStatus
    )
        {
            try
            {
                string _msg = string.Empty;

                string _Created_By = "7500016";

                DataTable cat = classificationDAL.UpdateClassification(classificationId, classificationCode, classificationName, _Created_By, activeStatus); 
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
        public JsonResult AllSave(
 string v_supplierId,
 string v_name,
 string v_typeList,
 string v_city,
 string v_state,
 string v_countryList,
 string v_zip,
 string v_uRL,
 string v_address,
 bool v_activeStatus,
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
            try
            {
                string _msg = string.Empty;

                string _Created_By = GetLoggedUserID();

                // DataTable cat = categoryDAL.SaveOldCategory(_description);
                //if (cat.Rows.Count > 0)
                //{

                //    _msg = cat.Rows[0]["result"].ToString();

                //}

                return Json(_msg);
            }
            catch (System.Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }
}