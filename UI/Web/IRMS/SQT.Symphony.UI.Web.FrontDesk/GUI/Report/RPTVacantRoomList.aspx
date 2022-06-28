<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="RPTVacantRoomList.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Report.RPTVacantRoomList" %>
<%@ Register src="~/UIControls/Report/CtrlVacantRoomList.ascx" tagname="CtrlVacantRoomList" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlVacantRoomList ID="ucCtrlVacantRoomList" runat="server" />
</asp:Content>

