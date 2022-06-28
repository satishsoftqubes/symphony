<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true" CodeBehind="ReprintCompanyInvoice.aspx.cs" Inherits="SQT.Symphony.UI.Web.BackOffice.GUI.Invoice.ReprintCompanyInvoice" %>
<%@ Register src="../../UIControls/Invoice/CtrlReprintCompanyInvoice.ascx" tagname="Reprintcmpinvoice" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:Reprintcmpinvoice ID="CtrlReprintCompanyInvoice" runat="server" />
</asp:Content>