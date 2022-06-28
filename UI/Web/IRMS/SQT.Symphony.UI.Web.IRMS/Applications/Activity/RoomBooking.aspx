<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true"
    CodeBehind="RoomBooking.aspx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.Applications.Activity.RoomBooking" %>

<%@ Register Src="../../UIControls/Activity/CtrlRoomBooking.ascx" TagName="CtrlRoomBooking"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../Javascript/jquery-1.4.1.min.js" type="text/javascript"></script>
    <uc1:CtrlRoomBooking ID="CtrlRoomBooking" runat="server" />
</asp:Content>
