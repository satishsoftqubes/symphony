<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/Site.Master" CodeBehind="RoomReservationList.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Reservation.RoomReservationList" %>

<%@ Register Src="~/UIControls/Reservation/CtrlRoomReservationList.ascx" TagName="CtrlRoomReservationList"
    TagPrefix="uc1" %>
<asp:content id="Content1" contentplaceholderid="head" runat="server">
</asp:content>
<asp:content id="Content2" contentplaceholderid="ContentPlaceHolder1" runat="server">
<uc1:CtrlRoomReservationList ID="ucCtrlRoomReservationList" runat="server" />
</asp:content>

