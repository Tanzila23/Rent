using FIXED_ASSET.DAL;
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
    public class BaseController : Controller
    {
		public string _ActionName, _CntrollerName;
		//public BaseController()
		//{
		//    try
		//    {
		//        _BusinessUnit_ID = _UserDAL.GetBusinessUnit_ID(_OutLetRegNo);
		//    }
		//    catch (Exception)
		//    {


		//    }

		//}

		//SalesDAL _SalesDAL = new SalesDAL();
		UserDAL _UserDAL = new UserDAL();

		public static string _OutLetRegNo = WebConfigurationManager.AppSettings["OutLetRegNo"];
		public static string _Device_ID = WebConfigurationManager.AppSettings["Device_ID"];
		public static string _Version = WebConfigurationManager.AppSettings["Version"];
		public static string _Customer_ID;

		public string GetLoggedUserID()
		{
			string _Created_By = "0";
			if (Session[POSxSession.LoggedUser] != null)
			{

				DataTable dt = (DataTable)Session[POSxSession.LoggedUser];
				_Created_By = dt.Rows[0]["emp_id"].ToString();

			}


			return _Created_By;
		}

		public int GetBusinessUnit_ID()
		{
			int _BusinessUnit_ID = 0;
			string _Created_By = GetLoggedUserID();
			if (Session[_Created_By + POSxSession.BusinessUnit_ID] != null)
			{

				_BusinessUnit_ID = Convert.ToInt16(Session[_Created_By + POSxSession.BusinessUnit_ID].ToString());
				//_Created_By = dt.Rows[0]["emp_id"].ToString();

			}


			return _BusinessUnit_ID;
		}




		public int GetCareByID()
		{
			int _CareById = 0;
			if (Session[POSxSession.CareByList] != null)
			{
				DataTable dt_CareByList = (DataTable)Session[POSxSession.CareByList];
				_CareById = Convert.ToInt32(dt_CareByList.Rows[0]["CareByID"].ToString());// Convert.ToInt32(dt.Rows[0]["CareByID"].ToString());

			}
			return _CareById;
		}

		public int GetCustomer_ID()
		{
			int _Customer_ID = 0;
			if (Session[POSxSession.CustomerInfo] != null)
			{
				DataTable dt = (DataTable)Session[POSxSession.CustomerInfo];
				_Customer_ID = Convert.ToInt32(dt.Rows[0]["External_ID"].ToString());
			}
			return _Customer_ID;
		}



		public string GetMAC()
		{
			string macAddresses = "";

			foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
			{
				if (nic.OperationalStatus == OperationalStatus.Up)
				{
					macAddresses += nic.GetPhysicalAddress().ToString();
					break;
				}
			}
			return macAddresses;
		}

		public string GetIPaddress()
		{
			string ipaddress;
			ipaddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
			if (ipaddress == "" || ipaddress == null)
				ipaddress = Request.ServerVariables["REMOTE_ADDR"];
			return ipaddress;
		}
		public string GetCapabilities()
		{
			string Capabilities = "Browser Name: " + Request.Browser.Browser + ";" +
				"Browser Version: " + Request.Browser.Version + ";" +
				"Platform: " + Request.Browser.Platform + ";" +
				"EcmaScriptVersion: " + Request.Browser.EcmaScriptVersion;
			return Capabilities;
		}

		public void SalesClear()
		{
			Session[POSxSession.CareByList] = null;
			Session[POSxSession.SalesItemList] = null;
			Session[POSxSession.CustomerInfo] = null;
			Session["PRCODE"] = null;
			Session["PROMONAME"] = null;
		}
		public void Single_Channel_SalesClear()
		{
			Session[POSxSession.SingleBarcode_CareByList] = null;
			//  Session[POSxSession.ChannelMasterItemList] = null;
			Session[POSxSession.ChannelSingleItemList] = null;
			Session[POSxSession.SingleBarcode_CustomerInfo] = null;
			//  Session[POSxSession.Master_Channel_Customer] =null;
			Session[POSxSession.Single_Channel_Customer] = null;
			Session[POSxSession.SingleBarcode_GiftVoucher] = null;
			Session["PRCODE"] = null;

		}

		public void Master_Channel_SalesClear()
		{
			Session[POSxSession.MasterBarcode_CareByList] = null;
			Session[POSxSession.ChannelMasterItemList] = null;
			/// Session[POSxSession.ChannelSingleItemList] = null;
			Session[POSxSession.MasterBarcode_CustomerInfo] = null;
			Session[POSxSession.Master_Channel_Customer] = null;
			// Session[POSxSession.Single_Channel_Customer] = null;
			Session[POSxSession.MasterBarcode_GiftVoucher] = null;
			Session["PRCODE"] = null;
		}



		public bool isPageParmited(string _Created_By, string _Device_ID)
		{
			bool result = false;
			_ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
			_CntrollerName = this.ControllerContext.RouteData.Values["controller"].ToString();

			DataTable _MenueTable = new DataTable(); //_UserDAL.UserMenuDetails(_Created_By, _Device_ID, _OutLetRegNo);
			if (Session[POSxSession.UserMenuDetails] == null)
			{
				_MenueTable = _UserDAL.UserMenuDetails(_Created_By, _Device_ID, _OutLetRegNo);
				Session[POSxSession.UserMenuDetails] = _MenueTable;
			}
			else
			{
				_MenueTable = (DataTable)Session[POSxSession.UserMenuDetails];
			}



			DataRow[] foundRows;
			string strExpr = "CONTROLLER LIKE '%" + _CntrollerName + "%' AND ACTION_URL ='" + _ActionName + "'";
			foundRows = _MenueTable.Select(strExpr, "");

			if (foundRows.Count() == 1)
			{
				result = true;

			}
			return result;
		}
	}
}