<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/Site.Master"
    CodeBehind="CancelReservationList.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Reservation.CancelReservationList" %>

<%@ Register Src="~/UIControls/Reservation/CtrlCancelReservationList.ascx" TagName="CtrlCancelReservationList"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="../../Scripts/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlCancelReservationList ID="ucCtrlCancelReservationList" runat="server" />
</asp:Content>
