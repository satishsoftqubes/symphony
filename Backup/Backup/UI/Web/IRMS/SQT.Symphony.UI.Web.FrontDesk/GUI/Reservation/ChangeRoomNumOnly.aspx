<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="ChangeRoomNumOnly.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Reservation.ChangeRoomNumOnly" %>

<%@ Register Src="~/UIControls/Reservation/ChangeRoomNumOnly.ascx" TagName="CtrlChangeRoomNumOnly"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlChangeRoomNumOnly ID="ucCtrlChangeRoomNumOnly" runat="server" />
</asp:Content>