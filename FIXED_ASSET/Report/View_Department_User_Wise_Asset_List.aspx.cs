using FIXED_ASSET.DAL;
using Microsoft.Reporting.WebForms;
using POSX.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FIXED_ASSET.Report
{
    public partial class View_Department_User_Wise_Asset_List : System.Web.UI.Page
    {
        BasicUtilities _BasicUtilities = new BasicUtilities();
        ReportDAL _Report = new ReportDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ViewReport();
            }

        }
        public void ViewReport()
        {

            string Report_Name = string.Empty;
            //Session[POSxSession.Report_Name] = null;

            Report_Name = Session[POSxSession.Report_Name].ToString();
            // string QuotationNo = Session[POSxSession.PendingDeliveryNO].ToString();// Session["PendingDeliveryNO"].ToString();
            DataTable dt_Sales_Details = new DataTable();
            ReportDataSource rdc = new ReportDataSource();

            dt_Sales_Details = (DataTable)Session[POSxSession.Department_User_Wise_Asset_List_Report];// 


            // DataTable dt_Outlet_Wise_Sales_Details = (DataTable)Session[POSxSession.Outlet_Wise_Sales_Details];// _Report.Transfer_Request_Report(QuotationNo, 1);

            //ReportDataSource
            rdc = new ReportDataSource("DataSet", dt_Sales_Details);

            FinalReport.Enabled = true;

            //RPT_Sales_Challan_Report.rdlc
            FinalReport.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
            FinalReport.LocalReport.ReportPath = Server.MapPath("../Report/RPT_") + Report_Name + ".rdlc";
            FinalReport.LocalReport.DataSources.Clear();
            FinalReport.LocalReport.DataSources.Add(rdc);

            //Server.MapPath("~/Report/RDLC/InventoryReport.rdlc");

            FinalReport.LocalReport.Refresh();
            FinalReport.DataBind();


        }
    }
}