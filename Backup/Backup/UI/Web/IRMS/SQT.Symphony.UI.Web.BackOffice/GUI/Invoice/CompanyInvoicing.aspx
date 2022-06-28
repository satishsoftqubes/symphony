<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true"
    CodeBehind="CompanyInvoicing.aspx.cs" Inherits="SQT.Symphony.UI.Web.BackOffice.GUI.Invoice.CompanyInvoicing" %>
<%@ Register src="../../UIControls/Invoice/CompanyInvoicing.ascx" tagname="CompanyInvoicing" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CompanyInvoicing ID="CtrlCompanyInvoicing" runat="server" />
</asp:Content>