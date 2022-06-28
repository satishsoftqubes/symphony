<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="RPTRoomDeposit.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Report.RPTRoomDeposit" %>
<%@ Register src="~/UIControls/Report/CtrlRoomDeposit.ascx" tagname="CtrlRoomDeposit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlRoomDeposit ID="ucCtrlRoomDeposit" runat="server" />
</asp:Content>
