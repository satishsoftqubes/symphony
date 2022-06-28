<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/admin.Master" CodeBehind="AccountSetup.aspx.cs" Inherits="SQT.Symphony.UI.Web.BackOffice.GUI.AccountSetup.AccountSetup" %>
<%@ Register src="../../UIControls/AccountSetup/CtrlAccountSetup.ascx" tagname="CtrlAccount" tagprefix="uc1" %>
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
    <uc1:CtrlAccount ID="CtrlAccount1" runat="server" />
</asp:Content>