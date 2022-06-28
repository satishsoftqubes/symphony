<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/Site.Master"
    CodeBehind="BanquetManagement.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Banquet.BanquetManagement" %>

<%@ Register Src="~/UIControls/Banquet/ctrlBanquetManagement.ascx" TagName="BanquetManagement"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%-- <link rel="stylesheet" href="../../Scripts/jquery.ui.core.css">
    <link rel="stylesheet" href="../../Scripts/jquery.ui.tabs.css">	
    <link rel="stylesheet" href="../../Scripts/jquery.ui.theme.css">	
    <script src="../../Scripts/jquery-1.7.1.js"></script>
	<script src="../../Scripts/jquery.ui.core.js"></script>
	<script src="../../Scripts/jquery.ui.widget.js"></script>
	<script src="../../Scripts/jquery.ui.tabs.js"></script>--%>
    <link type="text/css" href="../../Styles/jquery-ui-1.8.5.custom.css" rel="stylesheet" />
    <script type="text/javascript" src="../../Scripts/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery-ui-1.8.5.custom.min.js"></script>
    <link rel="stylesheet" href="../../Styles/jquery.ui.timepicker.css" type="text/css" />
    <script type="text/javascript" src="../../Scripts/jquery-ui-timepicker-addon.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:BanquetManagement ID="ucCtrlBanquetManagement" runat="server" />
</asp:Content>
