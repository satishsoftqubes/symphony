<%@ Page Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.Inventory.Category" %>

<%@ Register src="~/UIControls/Inventory/CtrlCategory.ascx" tagname="CtrlCategory" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Javascript/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../../Javascript/jquery.autocomplete.js" type="text/javascript"></script>
    <link href="../../Javascript/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
    <uc1:CtrlCategory ID="ucCtrlCategory" runat="server" />
</asp:Content>