<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true"
    CodeBehind="InvoiceSettlement.aspx.cs" Inherits="SQT.Symphony.UI.Web.BackOffice.GUI.Invoice.InvoiceSettlement" %>

<%@ Register Src="../../UIControls/Invoice/CtrlNewInvoiceSettlement.ascx" TagName="CtrlNewInvoiceSettlement"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlNewInvoiceSettlement ID="CtrlNewInvoiceSettlement" runat="server" />
</asp:Content>
