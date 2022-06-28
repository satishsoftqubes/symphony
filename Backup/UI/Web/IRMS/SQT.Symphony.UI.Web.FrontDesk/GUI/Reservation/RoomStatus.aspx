<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/Site.Master" CodeBehind="RoomStatus.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Reservation.RoomStatus" %>
<%@ Register Src="~/UIControls/Reservation/CtrlRoomStatus.ascx" TagName="CtrlRoomStatus"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlRoomStatus ID="ucCtrlRoomStatus" runat="server" />
</asp:Content>

