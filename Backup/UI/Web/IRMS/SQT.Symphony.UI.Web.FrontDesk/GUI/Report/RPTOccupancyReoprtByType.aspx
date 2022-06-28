<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RPTOccupancyReoprtByType.aspx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Report.RPTOccupancyReoprtByType" %>

<%@ Register Src="~/UIControls/Report/CtrlOccupancyReportByType.ascx" TagName="CtrlOccupancyReportByType"
    TagPrefix="uc1" %>
<head id="Head1" runat="server">
    <link href="../../Styles/style.css" rel="stylesheet" type="text/css" />
</head>
<form id="form1" runat="server">
<asp:scriptmanager id="scptInnerHTML" runat="server">
    </asp:scriptmanager>
<uc1:CtrlOccupancyReportByType ID="ucCtrlOccupancyReportByType" runat="server" />
</form>
