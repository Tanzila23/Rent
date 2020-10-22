using FIXED_ASSET.DAL;
using POSX.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
namespace FIXED_ASSET.Report
{
    public partial class View_Outlet_Wise_Asset_Details : System.Web.UI.Page
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

            dt_Sales_Details = (DataTable)Session[POSxSession.Outlet_Wise_Asset_Details_Report];// 


            // DataTable dt_Outlet_Wise_Sales_Details = (DataTable)Session[POSxSession.Outlet_Wise_Sales_Details];// _Report.Transfer_Request_Report(QuotationNo, 1);

            //ReportDataSource
            rdc = new ReportDataSource("DataSet", dt_Sales_Details);

            FinalReport.Enabled = true;
          
            //RPT_Sales_Challan_Report.rdlc
            FinalReport.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
            FinalReport.LocalReport.ReportPath = Server.MapPath("../Report/RPT_") + Report_Name + ".rdlc";
            FinalReport.LocalReport.DataSources.Clear();
            FinalReport.LocalReport.DataSources.Add(rdc);
            FinalReport.LocalReport.EnableExternalImages = true;

            /* begin added part */

            // get absolute path to Project folder
            //(Server.MapPath("/Images/Products/" + fname))
            string path = new Uri(Server.MapPath("/Images/Products/")).AbsoluteUri; // adjust path to Project folder here

            // set above path to report parameter
            var parameter = new ReportParameter[1];
            parameter[0] = new ReportParameter("ImagePath", path); // adjust parameter name here
            FinalReport.LocalReport.SetParameters(parameter);
          
          

            FinalReport.LocalReport.Refresh();
            FinalReport.DataBind();



        }
    }
}