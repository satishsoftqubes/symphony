<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true"
    CodeBehind="CompanyInvoices.aspx.cs" Inherits="SQT.Symphony.UI.Web.BackOffice.GUI.Invoice.CompanyInvoices" %>

<%@ Register src="../../UIControls/Invoice/CtrlNewCompanyInvoices.ascx" tagname="CtrlNewCompanyInvoices" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlNewCompanyInvoices ID="CtrlNewCompanyInvoices" runat="server" />
</asp:Content>