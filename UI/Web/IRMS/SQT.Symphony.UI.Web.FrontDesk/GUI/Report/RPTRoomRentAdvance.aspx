<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="RPTRoomRentAdvance.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Report.RPTRoomRentAdvance" %>
<%@ Register src="~/UIControls/Report/CtrlRoomRentAdvance.ascx" tagname="CtrlRoomRentAdvance" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlRoomRentAdvance ID="ucCtrlRoomRentAdvance" runat="server" />
</asp:Content>

