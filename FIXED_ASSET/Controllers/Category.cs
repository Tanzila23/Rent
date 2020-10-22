using FIXED_ASSET.DAL;
using FIXED_ASSET.DTO;
using POSX.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FIXED_ASSET.Controllers
{
    public class CategoryController : BaseController
    {
		UserDAL userDAL = new UserDAL();
		CategoryDTO categoryDTO = new CategoryDTO();
		CategoryDAL categoryDAL = new CategoryDAL();
		BasicUtilities _BasicUtilities = new BasicUtilities();

		public CategoryController()
		{

		}


		// GET: Category
		public ActionResult frmCategory()
		{
			if (Session[POSxSession.LoggedUser] == null)
			{
				return Redirect("/User/Login");
			}
			else
			{
				string _Created_By = GetLoggedUserID();
				string _Device_ID = _Created_By;
				bool _Parmited = isPageParmited(_Created_By, _Device_ID);
				// bool _Parmited = isPageParmited(_Created_By);
				if (!_Parmited)
				{
					return Redirect("/Home/");
				}
				ViewBag.formTitle = "Category Information";
				ViewBag.CategoryList = categoryDAL.GetCategories();



				return View();
			}
		}

		public ActionResult frmOldCategory()
		{
			ViewBag.formTitle = "Category Information";
			var dtOldCategorylist = categoryDAL.GetOldCategories();
			//var count = dtChannellist.Rows.Count;

			//List<Dictionary<string, object>> _OldCategorylist = _BasicUtilities.GetTableRows(dtOldCategorylist);



			ViewBag.OldCategoryList = dtOldCategorylist;
			return View();
		}

		public JsonResult List()
		{
			var category = categoryDAL.GetCategories();

			return Json(new { data = category }, JsonRequestBehavior.AllowGet);
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Save(NewCategoryDTO category)
		{
			try
			{
				string _msg = string.Empty;

				string _Created_By = GetLoggedUserID();

				DataTable cat = categoryDAL.SaveCategory(category, _Created_By);
				if (cat.Rows.Count > 0)
				{

					//if (cat.Rows[0]["E_ID"].ToString() == category.eID)
					//{
					//    _msg = "Category ID" + cat.Rows[0]["result"].ToString();
					//}
					//if (cat.Rows[0]["SHNAME"].ToString() ==  category.sName)
					//{
					//    _msg = "Short Name" + cat.Rows[0]["result"].ToString();
					//}

					_msg = cat.Rows[0]["result"].ToString();

				}

				return Json(_msg);
			}
			catch (System.Exception ex)
			{
				return Json(ex.Message);
			}
		}

		public JsonResult GetbyID(int ID)
		{
			var category = categoryDAL.GetCategories().Find(x => x.C_ID.Equals(ID));

			ViewBag.CategoryID = category.C_ID;
			ViewBag.Category = category.Description;
			ViewBag.ShortName = category.SHNAME;
			//ViewBag.Active = category.Status;
			ViewBag.Active = false;
			if (category.Status == "Active")
			{
				ViewBag.Active = true;
			}

			ViewBag.Active1 = category.tST;
			ViewBag.InActive = category.Status;

			return Json(category, JsonRequestBehavior.AllowGet);
		}

		[HttpPost]
		public JsonResult Update(NewCategoryDTO category)
		{
			try
			{
				string _msg = string.Empty;

				string _Created_By = GetLoggedUserID();

				DataTable cat = categoryDAL.UpdateCategory(category, _Created_By);
				if (cat.Rows.Count > 0)
				{

					//if (cat.Rows[0]["E_ID"].ToString() == category.eID)
					//{
					//    _msg = "Category ID" + cat.Rows[0]["result"].ToString();
					//}
					//if (cat.Rows[0]["SHNAME"].ToString() ==  category.sName)
					//{
					//    _msg = "Short Name" + cat.Rows[0]["result"].ToString();
					//}

					_msg = cat.Rows[0]["result"].ToString();

				}

				return Json(_msg);
			}
			catch (System.Exception ex)
			{
				return Json(ex.Message);
			}
		}

		public JsonResult OldCategoryGetbyID(int ID)
		{
			var Categorylist = categoryDAL.GetOldCategories();

			var category = Categorylist.Find(x => x.C_ID.Equals(ID));

			return Json(category, JsonRequestBehavior.AllowGet);
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult OldCatSave(string _description)
		{
			try
			{
				string _msg = string.Empty;

				string _Created_By = GetLoggedUserID();

				DataTable cat = categoryDAL.SaveOldCategory(_description);
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

		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult OldCatUpdate(string _description, int _cid)
		{
			try
			{
				string _msg = string.Empty;

				string _Created_By = GetLoggedUserID();

				DataTable cat = categoryDAL.UpdateOldCategory(_description, _cid);
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
      
     
    }
}