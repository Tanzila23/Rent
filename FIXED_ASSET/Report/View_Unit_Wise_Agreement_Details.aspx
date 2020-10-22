<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="View_Unit_Wise_Agreement_Details.aspx.cs" Inherits="FIXED_ASSET.Report.View_Unit_Wise_Agreement_Details" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=14.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>	
         <rsweb:ReportViewer ID="FinalReport" runat="server" Width="100%" Height="700px" ShowExportControls="True" ShowPrintButton="True" ShowRefreshButton="true" ToolbarForegroundColor="SeaGreen" SizeToReportContent="true" BorderStyle="None" ></rsweb:ReportViewer>
    </form>
</body>
</html>
