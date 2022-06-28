<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="RPTRoomHistory.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Report.RPTRoomHistory" %>
<%@ Register src="~/UIControls/Report/CtrlRoomHistory.ascx" tagname="CtrlRoomHistory" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlRoomHistory ID="ucCtrlRoomHistory" runat="server" />
</asp:Content>
