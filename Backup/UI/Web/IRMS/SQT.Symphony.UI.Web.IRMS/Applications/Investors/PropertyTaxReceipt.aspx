<%@ Page Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true" CodeBehind="PropertyTaxReceipt.aspx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.Applications.Investors.PropertyTaxReceipt" %>
<%@ Register src="~/UIControls/InvestorSetUp/CtrlPropertyTax.ascx" tagname="CtrlPropertyTax" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../Javascript/jquery-1.4.1.min.js" type="text/javascript"></script>
<script src="../../Javascript/jquery.autocomplete.js" type="text/javascript"></script>
<link href="../../Javascript/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
    <uc1:CtrlPropertyTax ID="CtrlPropertyTax1Property" runat="server" />
</asp:Content>
