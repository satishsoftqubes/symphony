<%@ Page Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true" 
    CodeBehind="PropertyPaymentList.aspx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.Applications.SetUp.PropertyPaymentList" %>
<%@ Register src="~/UIControls/Configurations/CtrlPropertyPaymentList.ascx" tagname="CtrlPropertyPaymentList" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="../../Javascript/jquery-1.4.1.min.js" type="text/javascript"></script>
<script src="../../Javascript/jquery.autocomplete.js" type="text/javascript"></script>
<link href="../../Javascript/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlPropertyPaymentList ID="CtrlPropertyPaymentList1" runat="server" />
</asp:Content>