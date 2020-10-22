using FIXED_ASSET.DAL;
using FIXED_ASSET.DTO;
using POSX.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FIXED_ASSET.Controllers
{
    public class UserController : BaseController
    {
		BasicUtilities _BasicUtilities = new BasicUtilities();
		UserDAL _UserDAL = new UserDAL();


		public ActionResult Index()
		{
			if (Session[POSxSession.LoggedUser] == null)
			{
				return Redirect("/User/Login");

			}
			else
			{
				return Redirect("~/Home");
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
                return Redirect("~/RentHome");
            }

        }
        // Login Screen
        public ActionResult Login()
		{




			if (Session[POSxSession.LoggedUser] == null)
			{
				// return Redirect("/User/Login");
				ViewBag.Message = "ELPL- LOGIN";
				return View();
			}
			else
			{

				return Redirect("~/RentHome/RentIndex");

			}
		}
		[HttpPost]
		public ActionResult Login(string _UName, string _Pass) //string Username,string Password)
		{
			bool _Msg = false;
			try
			{
				DataTable _result = _UserDAL.UserLogin_Check(_UName, _Pass, "0", _OutLetRegNo);
				if (_result.Rows.Count > 0)
				{
					_Msg = true;
					Session[POSxSession.LoggedUser] = _result;

					string _Created_By = GetLoggedUserID();

					int _BusinessUnit_ID = _UserDAL.GetBusinessUnit_ID(_OutLetRegNo);
					Session[_Created_By + POSxSession.BusinessUnit_ID] = _BusinessUnit_ID;

				}

				return Json(_Msg);
			}
			catch (Exception ex)
			{

				return Json(ex.Message);
			}
		}

		public ActionResult LockedOut()
		{
			//if (Session[POSxSession.LoggedUser] != null)
			//{

			//    Session.RemoveAll();

			//}
			//else
			//{
			//    return Redirect("/User/Login");
			//}
			return View();

		}

		public ActionResult LogOut()
		{

			FormsAuthentication.SignOut();
			Session.Abandon();
			Session.Clear();
			ModelState.Clear();
			return RedirectToAction("Login");

		}


		/// <summary>
		/// //////////////////////////////////Ashiqur Vai ///////////////////////////////////////
		/// </summary>
		/// <returns></returns>

		public ActionResult Users()
		{
			ViewBag.userList = _UserDAL.GetEmplyees();
			ViewBag.RoleList = _UserDAL.GetRoles();
			return View();
		}

		public ActionResult Roles()
		{
			ViewBag.RoleList = _UserDAL.GetRoles();

			return View();
		}

		public JsonResult RoleList()
		{
			return Json(_UserDAL.GetRoles(), JsonRequestBehavior.AllowGet);
		}

		[HttpPost]
		public JsonResult CreateRole(RoleDTO role)
		{

			try
			{

				bool result = false;
				string message = "";

				int count = _UserDAL.DuplicateCount(role);

				if (count > 0)
				{
					message += "Already Exists!!";
				}
				else
				{
					if (role != null)
					{

						var insert = _UserDAL.AddRole(role);
						if (!string.IsNullOrEmpty(result.ToString()))
						{
							message += "Inserted Data Successfully";
							result = true;
						}
						else
						{
							message += "Data Not Inserted";
							result = false;
						}
						//message = "Insert Data Successfully";


					}

				}

				// var message = "";

				return Json(new { result = result, message = message });

			}
			catch (System.Exception ex)
			{
				return Json(ex.Message);
			}

		}

		[HttpPost]
		public JsonResult UpdateUser(RoleEmpDTO roleEmp)
		{

			try
			{

				bool result = false;
				string message = "";

				if (roleEmp != null)
				{
					var insert = _UserDAL.UpdateUserRole(roleEmp);
					if (!string.IsNullOrEmpty(result.ToString()))
					{
						message += "Inserted Data Successfully";
						result = true;
					}
					else
					{
						message += "Data Not Inserted";
						result = false;
					}
				}
				return Json(new { result = result, message = message });

			}
			catch (System.Exception ex)
			{
				return Json(ex.Message);
			}

		}

		public ActionResult MenuPermission()
		{
			ViewBag.Roles = new SelectList(_UserDAL.GetRoles(), "R_ID", "RNAME");
			return View();
		}

		[HttpPost]
		public JsonResult GetMenuPermission(int roleId)
		{

			int _ParentCount, _childCount, _child_childCount;
			// StringBuilder _subMenu = new StringBuilder();
			string _result = " <ul class='checktree'>";
			DataTable _MenueTable = _UserDAL.UserMenuRoleDetails(roleId);
			DataRow[] foundRows, foundRows2, foundRows3;
			int parentId = 0;
			if (_MenueTable.Rows.Count > 0)
			{

				string strExpr = "PARENT_ID =" + parentId;

				//_childCount = dbContext.t_Menu.Count(m => m.MENU_PARENT_ID == obj.MENU_ID);
				foundRows = _MenueTable.Select(strExpr, "");
				// _MenueTable.RowFilter = "ProductID = 35";
				_ParentCount = foundRows.Count();


				if (foundRows.Length > 0)
				{
					for (int i = 0; i < foundRows.Length; i++)
					{
						int ME_ID = Convert.ToInt32(foundRows[i]["ME_ID"].ToString());
						string ME_Name = foundRows[i]["MENAME"].ToString();
						string strExpr2 = "PARENT_ID =" + ME_ID;
						foundRows2 = _MenueTable.Select(strExpr2, "");
						_childCount = foundRows2.Count();
						bool flag = Convert.ToBoolean(foundRows[i]["R_STATUS"]);



						if (_childCount > 0)
						{
							//for=" + foundRows[i]["ME_ID"].ToString() + "
							_result += "<li><label class='container'> ";
							if (flag)
							{
								ME_Name = foundRows[i]["MENAME"].ToString();
								_result += "<input id='" + foundRows[i]["ME_ID"].ToString() + "' type='checkbox' onclick='GetParentID(" + foundRows[i]["ME_ID"].ToString() + ");' name='menu' class='checkbox parent " + foundRows[i]["ME_ID"].ToString() + "' data-parent=" + foundRows[i]["ME_ID"].ToString() + " data-id=" + foundRows[i]["ME_ID"].ToString() + "  checked>" + foundRows[i]["MENAME"].ToString();

							}
							else
							{
								ME_Name = foundRows[i]["MENAME"].ToString();
								_result += "<input id='" + foundRows[i]["ME_ID"].ToString() + "' type='checkbox' onclick='GetParentID(" + foundRows[i]["ME_ID"].ToString() + ");'  name='menu' class='checkbox parent " + foundRows[i]["ME_ID"].ToString() + "' data-parent=" + foundRows[i]["ME_ID"].ToString() + " data-id=" + foundRows[i]["ME_ID"].ToString() + ">" + foundRows[i]["MENAME"].ToString();
							}
							_result += " <span class='checkmark'></span></label>";
							_result += "<ul>";

							foreach (DataRow row in foundRows2)
							{
								bool flag2 = Convert.ToBoolean(row["R_STATUS"]);
								string strExpr3 = "PARENT_ID =" + row["ME_ID"];

								foundRows3 = _MenueTable.Select(strExpr3, "");
								_child_childCount = foundRows3.Count();
								//for=" + foundRows[i]["ME_ID"].ToString() + "
								_result += "<li><label class='container'>";


								if (flag2)
								{
									ME_Name = row["MENAME"].ToString();
									_result += "<input id='" + row["ME_ID"].ToString() + "' type='checkbox' onclick='GetChildID(" + row["ME_ID"].ToString() + ");' name='menu' class='checkbox " + foundRows[i]["ME_ID"].ToString() + "' data-parent=" + foundRows[i]["ME_ID"].ToString() + " data-id=" + row["ME_ID"].ToString() + " checked>" + row["MENAME"].ToString();
									_result += "<span class='checkmark'></span>";



									if (_child_childCount > 0)
									{

										_result += "<ul>";
										foreach (DataRow rowss in foundRows3)
										{
											bool flag3 = Convert.ToBoolean(rowss["R_STATUS"]);

											if (flag3)
											{
												ME_Name = rowss["MENAME"].ToString();
												_result += "<li><label class='container'>";
												_result += "<input id='" + rowss["ME_ID"].ToString() + "' type='checkbox' onclick='GetChildID(" + rowss["ME_ID"].ToString() + ");' name='menu' class='checkbox " + foundRows[i]["ME_ID"].ToString() + "' data-parent=" + foundRows[i]["ME_ID"].ToString() + " data-id=" + rowss["ME_ID"].ToString() + " checked>" + rowss["MENAME"].ToString();
												_result += "<span class='checkmark'></span>";
											}
											else
											{
												ME_Name = rowss["MENAME"].ToString();
												_result += "<li><label class='container'>";
												_result += "<input id='" + rowss["ME_ID"].ToString() + "' type='checkbox' onclick='GetChildID(" + rowss["ME_ID"].ToString() + ");' name='menu' class='checkbox " + foundRows[i]["ME_ID"].ToString() + "' data-parent=" + foundRows[i]["ME_ID"].ToString() + " data-id=" + rowss["ME_ID"].ToString() + ">" + rowss["MENAME"].ToString();
												_result += "<span class='checkmark'></span>";

											}


										}
										_result += " </ul></li></label>";

									}




								}
								else
								{
									ME_Name = row["MENAME"].ToString();
									_result += "<input  id='" + row["ME_ID"].ToString() + "' type='checkbox' onclick='GetChildID(" + row["ME_ID"].ToString() + ");' name='menu' class='checkbox " + foundRows[i]["ME_ID"].ToString() + "' data-parent=" + foundRows[i]["ME_ID"].ToString() + " data-id=" + row["ME_ID"].ToString() + ">" + row["MENAME"].ToString();
									_result += "<span class='checkmark'></span>";


									if (_child_childCount > 0)
									{

										_result += "<ul>";
										foreach (DataRow rowss in foundRows3)
										{
											bool flag3 = Convert.ToBoolean(rowss["R_STATUS"]);

											if (flag3)
											{
												ME_Name = rowss["MENAME"].ToString();
												_result += "<li><label class='container'>";
												_result += "<input id='" + rowss["ME_ID"].ToString() + "' type='checkbox' onclick='GetChildID(" + row["ME_ID"].ToString() + ");' name='menu' class='checkbox " + foundRows[i]["ME_ID"].ToString() + "' data-parent=" + foundRows[i]["ME_ID"].ToString() + " data-id=" + rowss["ME_ID"].ToString() + " checked>" + rowss["MENAME"].ToString();
												_result += "<span class='checkmark'></span>";
											}
											else
											{
												ME_Name = rowss["MENAME"].ToString();
												_result += "<li><label class='container'>";
												_result += "<input id='" + rowss["ME_ID"].ToString() + "' type='checkbox' onclick='GetChildID(" + row["ME_ID"].ToString() + ");' name='menu' class='checkbox " + foundRows[i]["ME_ID"].ToString() + "' data-parent=" + foundRows[i]["ME_ID"].ToString() + " data-id=" + rowss["ME_ID"].ToString() + ">" + rowss["MENAME"].ToString();
												_result += "<span class='checkmark'></span>";

											}


										}
										_result += "</li></label>";

									}






									//_result += "<input  id='" + row["ME_ID"].ToString() + "' type='checkbox' onclick='GetChildID(" + row["ME_ID"].ToString() + ");' name='menu' class='checkbox " + foundRows[i]["ME_ID"].ToString() + "' data-parent=" + foundRows[i]["ME_ID"].ToString() + " data-id=" + row["ME_ID"].ToString() + ">" + row["MENAME"].ToString();
									//_result += "<span class='checkmark'></span>";
								}
								_result += "</li></label>";
							}
							_result += "</ul>";

						}
						else
						{

							_result += "<li><label class='container' >";
							if (flag)
							{
								_result += "<input id='" + foundRows[i]["ME_ID"].ToString() + "' type='checkbox' onclick='GetParentID(" + foundRows[i]["ME_ID"].ToString() + ");' name='menu' class='checkbox " + foundRows[i]["ME_ID"].ToString() + "' data-parent=" + foundRows[i]["ME_ID"].ToString() + " data-id=" + foundRows[i]["ME_ID"].ToString() + " checked>" + foundRows[i]["MENAME"].ToString();

							}
							else
							{
								_result += "<input id='" + foundRows[i]["ME_ID"].ToString() + "' type='checkbox' onclick='GetParentID(" + foundRows[i]["ME_ID"].ToString() + ");' name='menu' class='checkbox " + foundRows[i]["ME_ID"].ToString() + "' data-parent=" + foundRows[i]["ME_ID"].ToString() + " data-id=" + foundRows[i]["ME_ID"].ToString() + ">" + foundRows[i]["MENAME"].ToString();
							}
							_result += " <span class='checkmark'></span> </label>";
						}

					}

				}
				_result += "</ul>";
			}





			return Json(_result);
		}

		[HttpPost]
		public JsonResult SetMenuPermission(int roleId, string menuID)
		{
			string _result = "";
			// string[] ps = menuID.Split(',');
			// StringBuilder _subMenu = new StringBuilder();
			var updatemenu = _UserDAL.UpdateMenupermission(roleId, menuID);


			if (updatemenu)
			{
				_result += "Update Menu Successfully";
			}
			else
			{
				_result += "Menu not updated";
			}

			return Json(_result);
		}


		[HttpPost]
		public JsonResult SalesforceAssign(int EmpID, int BusinessUnitID, string StartDt)
		{
			try
			{

				bool result = false;
				string message = "";

				if (EmpID > 0)
				{
					var dateTime = DateTime.Parse(StartDt).ToString("MM/dd/yyyy");// Convert.ToDateTime(StartDt);
					string _Created_By = GetLoggedUserID();
					var insert = _UserDAL.Salesforce_Assign(EmpID, BusinessUnitID, dateTime, _Created_By);
					if (!string.IsNullOrEmpty(insert.ToString()))
					{
						message += "Inserted Data Successfully";
						result = true;
					}
					else
					{
						message += "Data Not Inserted";
						result = false;
					}
					//message = "Insert Data Successfully";

				}
				// var message = "";

				return Json(new { result = result, message = message });

			}
			catch (System.Exception ex)
			{
				return Json(ex);
			}
		}

		public ActionResult SalesForce()
		{
			//string employeeNameID = "EMP_ID" +"--"+ "NAME";
			//List<OrganizationDTO> organization = new List<OrganizationDTO>();

			foreach (var item in _UserDAL.GetBusinessUnitList())
			{
				ViewBag.OrganizationID = item.Organization_ID;
			}
			// organization = _UserDAL.GetBusinessUnitList().Select(b => b.Organization_ID).ToList();
			//ViewBag.Employees = new SelectList(_UserDAL.GetEmplyees(), "EMP_ID", "NAME");
			// ViewBag.OrganizationID = _UserDAL.GetBusinessUnitList().Select(b => b.Organization_ID) ;
			ViewBag.Employees = _UserDAL.GetEmplyees();
			// ViewBag.EmployeesList = _UserDAL.GetEmplyees().ToList();
			ViewBag.BusinessUnitList = _UserDAL.GetBusinessUnitList();
			// ViewBag.BusinessUnitList = new SelectList(_UserDAL.GetBusinessUnitList(), "Organization_ID", "Organization_Name");
			return View();
		}

		[HttpPost]
		public JsonResult SalseForceList()
		{
			var data = _UserDAL.GetEmplyees();
			return Json(new { data = data }, JsonRequestBehavior.AllowGet);
		}

		[HttpPost]
		public JsonResult BusinessUnitList()
		{

			//GetBusinessUnitList
			var data = _UserDAL.GetBusinessUnitList();
			return Json(_UserDAL.GetBusinessUnitList(), JsonRequestBehavior.AllowGet);
		}

		[HttpPost]
		public JsonResult Employee_Lookup(int employeeID)
		{
			//GetBusinessUnitList
			// var data = _UserDAL.Employee_Lookup(employeeID);
			return Json(_UserDAL.Employee_Lookup(employeeID), JsonRequestBehavior.AllowGet);
		}
	}
}