<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true"
    CodeBehind="TaxSetup1.aspx.cs" Inherits="SQT.Symphony.UI.Web.BackOffice.GUI.AccountSetup.TaxSetup1" %>
<%@ Register src="../../UIControls/AccountSetup/CtrlNewTaxSetup.ascx" tagname="NewTax" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<uc1:NewTax ID="CtrlNewTaxSetup" runat="server" />
</asp:Content>
