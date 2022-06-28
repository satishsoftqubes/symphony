<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="RoomStatusView.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Reservation.RoomStatusView" %>
<%@ Register Src="~/UIControls/Reservation/CtrlRoomStatusView.ascx" TagName="CtrlRoomStatusView"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlRoomStatusView ID="ucCtrlRoomStatusView" runat="server" />
</asp:Content>
