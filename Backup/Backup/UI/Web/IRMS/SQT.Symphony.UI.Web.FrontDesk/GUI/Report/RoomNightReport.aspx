<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="RoomNightReport.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Report.RoomNightReport" %>
<%@ Register src="~/UIControls/Report/CtrlRoomNightReport.ascx" tagname="CtrlRoomNightReport" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<uc1:CtrlRoomNightReport ID="ucCtrlRoomNightReport" runat="server" />
</asp:Content>
