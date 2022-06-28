<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true"
    CodeBehind="CheckRoomAvailability.aspx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.Applications.Activity.CheckRoomAvailability" %>

<%@ Register Src="../../UIControls/Activity/CtrlCheckRoomAvailability.ascx" TagName="CtrlCheckRoomAvailability"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../Javascript/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../../Javascript/jquery.autocomplete.js" type="text/javascript"></script>
    <link href="../../Javascript/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
    <uc1:CtrlCheckRoomAvailability ID="CtrlCheckRoomAvailability1" runat="server" />
</asp:Content>
