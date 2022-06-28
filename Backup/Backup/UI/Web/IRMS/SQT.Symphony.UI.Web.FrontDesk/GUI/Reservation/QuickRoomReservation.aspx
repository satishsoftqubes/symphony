<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="QuickRoomReservation.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Reservation.QuickRoomReservation" %>
<%@ Register src="~/UIControls/Reservation/CtrlQuickRoomReservation.ascx" tagname="CtrlQuickRoomReservation" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<uc1:CtrlQuickRoomReservation ID="CtrlQuickRoomReservation" runat="server" />
</asp:Content>
