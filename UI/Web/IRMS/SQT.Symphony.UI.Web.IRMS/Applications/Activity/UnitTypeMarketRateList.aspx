<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UnitTypeMarketRateList.aspx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.Applications.Activity.UnitTypeMarketRateList" %>

<%@ Register Src="~/UIControls/Activity/CtrlUnitTypeMarketRateList.ascx" TagName="ucUnitTypeMarketRateList"
    TagPrefix="uc1" %>
<asp:content id="Content1" contentplaceholderid="head" runat="server">
<link rel="stylesheet" href="../../Scripts/jquery.ui.core.css">
    <link rel="stylesheet" href="../../Scripts/jquery.ui.tabs.css">	
    <link rel="stylesheet" href="../../Scripts/jquery.ui.theme.css">	
    <script src="../../Scripts/jquery-1.7.1.js"></script>
	<script src="../../Scripts/jquery.ui.core.js"></script>
	<script src="../../Scripts/jquery.ui.widget.js"></script>
	<script src="../../Scripts/jquery.ui.tabs.js"></script>
</asp:content>
<asp:content id="Content2" contentplaceholderid="ContentPlaceHolder1" runat="server">
    <uc1:ucUnitTypeMarketRateList ID="CtrlucUnitTypeMarketRateList" runat="server" />
</asp:content>
