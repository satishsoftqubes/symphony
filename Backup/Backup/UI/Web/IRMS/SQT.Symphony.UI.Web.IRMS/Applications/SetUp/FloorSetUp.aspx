<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="FloorSetUp.aspx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.Applications.SetUp.FloorSetUp" %>
<%@ Register src="~/UIControls/Configurations/CtrlFloor.ascx" tagname="CtrlFloor" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../../Scripts/jquery.ui.core.css">
    <link rel="stylesheet" href="../../Scripts/jquery.ui.tabs.css">	
    <link rel="stylesheet" href="../../Scripts/jquery.ui.theme.css">	
    <script src="../../Scripts/jquery-1.7.1.js"></script>
	<script src="../../Scripts/jquery.ui.core.js"></script>
	<script src="../../Scripts/jquery.ui.widget.js"></script>
	<script src="../../Scripts/jquery.ui.tabs.js"></script>
	<%--<link rel="stylesheet" href="../../Scripts/demos.css">--%>
<script src="../../Javascript/jquery.autocomplete.js" type="text/javascript"></script>
<link href="../../Javascript/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
    <uc1:CtrlFloor ID="CtrlFloor1" runat="server" />
</asp:Content>
