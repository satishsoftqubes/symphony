<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true"
    CodeBehind="CashierCheckOut.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Billing.CashierCheckOut" %>
<%@ Register Src="~/UIControls/Billing/CtrlCashierCheckOut.ascx" TagName="CashierCheckOut" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../Scripts/jquery-1.4.2.min.js" type="text/javascript"></script>
    <link href="../../Scripts/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery.autocomplete.js" type="text/javascript"></script>
    <uc1:CashierCheckOut ID="ucCashierCheckOut" runat="server" />
</asp:Content>
