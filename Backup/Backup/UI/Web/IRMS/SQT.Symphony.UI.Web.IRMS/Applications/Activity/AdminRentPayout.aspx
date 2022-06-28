<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true"
    CodeBehind="AdminRentPayout.aspx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.Applications.Activity.AdminRentPayout" %>

<%@ Register Src="../../UIControls/Activity/CtrlAdminRentPayout.ascx" TagName="CtrlAdminRentPayout"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../../Scripts/jquery.ui.core.css">
    <link rel="stylesheet" href="../../Scripts/jquery.ui.tabs.css">
    <link rel="stylesheet" href="../../Scripts/jquery.ui.theme.css">
    <link href="../../Javascript/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
    <script src="../../Javascript/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../../Javascript/jquery.autocomplete.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-1.7.1.js"></script>
    <script src="../../Scripts/jquery.ui.core.js"></script>
    <script src="../../Scripts/jquery.ui.widget.js"></script>
    <script src="../../Scripts/jquery.ui.tabs.js"></script>
    <script src="../../Javascript/jquery.autocomplete.js" type="text/javascript"></script>
    <link href="../../Javascript/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
    <uc1:CtrlAdminRentPayout ID="CtrlAdminRentPayout1" runat="server" />
</asp:Content>
