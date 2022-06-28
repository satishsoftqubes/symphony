<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true" CodeBehind="CompanyInvoice.aspx.cs" Inherits="SQT.Symphony.UI.Web.BackOffice.GUI.AccountSetup.CompanyInvoice" %>
<%@ Register Src ="../../UIControls/AccountSetup/CtrlCompanyInvoice.ascx" TagName ="CtrlCompanyInvoice" TagPrefix ="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <link rel="stylesheet" href="../../Scripts/jquery.ui.core.css"/>    
    <link rel="stylesheet" href="../../Scripts/jquery.ui.datepicker.css" />    
    <link rel="stylesheet" href="../../Scripts/jquery.ui.theme.css"/>    
    <script src="../../Scripts/jquery-1.7.1.js"></script>    
    <script src="../../Scripts/jquery.ui.core.js"></script>
    <script src="../../Scripts/jquery.ui.widget.js"></script>
    <script src="../../Scripts/jquery.ui.datepicker.js"></script>  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <uc1:CtrlCompanyInvoice ID="ctrlCompanyInvoice1" runat="server" />
</asp:Content>
