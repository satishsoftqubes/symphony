<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/admin.Master"
    CodeBehind="BookingAgent.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.PriceManager.BookingAgent" %>

<%@ Register Src="~/UIControls/PriceManager/CtrlBookingAgent.ascx" TagName="CtrlBookingAgent"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="../../Javascript/jquery-1.4.1.min.js" type="text/javascript"></script>
<script src="../../Javascript/jquery.autocomplete.js" type="text/javascript"></script>
<link href="../../Javascript/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlBookingAgent ID="idCtrlBookingAgent" runat="server" />
</asp:Content>
