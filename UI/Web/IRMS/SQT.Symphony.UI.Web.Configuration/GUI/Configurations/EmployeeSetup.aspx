<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true" CodeBehind="EmployeeSetup.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.Configurations.EmployeeSetup" %>
<%@ Register src="../../UIControls/Configurations/CtrlEmployee.ascx" tagname="CtrlEmployee" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../../Scripts/jquery.ui.core.css"/>    
    <link rel="stylesheet" href="../../Scripts/jquery.ui.datepicker.css" />    
    <link rel="stylesheet" href="../../Scripts/jquery.ui.theme.css"/>    
    <script src="../../Scripts/jquery-1.7.1.js"></script>    
    <script src="../../Scripts/jquery.ui.core.js"></script>
    <script src="../../Scripts/jquery.ui.widget.js"></script>
    <script src="../../Scripts/jquery.ui.datepicker.js"></script>
    <script src="../../Javascript/jquery.autocomplete.js" type="text/javascript"></script>
    <link href="../../Javascript/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlEmployee ID="CtrlEmployee1" runat="server" />
</asp:Content>
