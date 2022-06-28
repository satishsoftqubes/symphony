<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="ReprintPaymentInvoice.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Billing.ReprintPaymentInvoice" %>
<%@ Register Src="~/UIControls/Billing/CtrlReprintPaymentInvoice.ascx" TagName="ReprintPaymentInvoice" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../Scripts/jquery-1.4.2.min.js" type="text/javascript"></script>
    <link href="../../Scripts/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery.autocomplete.js" type="text/javascript"></script>
    <uc1:ReprintPaymentInvoice ID="ucReprintPaymentInvoice" runat="server" />
</asp:Content>
