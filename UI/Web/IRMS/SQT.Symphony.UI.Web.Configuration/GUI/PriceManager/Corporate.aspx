<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true" CodeBehind="Corporate.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.PriceManager.Corporate" %>
<%@ Register src="~/UIControls/PriceManager/CtrlCorporate.ascx" tagname="CtrlCorporate" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="../../Javascript/jquery-1.4.1.min.js" type="text/javascript"></script>
<script src="../../Javascript/jquery.autocomplete.js" type="text/javascript"></script>
<link href="../../Javascript/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlCorporate ID="CtrlCorporate" runat="server" />
</asp:Content>
