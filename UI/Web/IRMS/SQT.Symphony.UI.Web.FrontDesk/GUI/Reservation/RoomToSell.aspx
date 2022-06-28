<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="RoomToSell.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Reservation.RoomToSell" %>
<%@ Register src="../../UIControls/Reservation/CtrlRoomsToSell.ascx" tagname="CtrlRoomsToSell" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlRoomsToSell ID="CtrlRoomsToSell1" runat="server" />
</asp:Content>
