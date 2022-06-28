<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true" CodeBehind="RoomService.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.Configurations.RoomService" %>
<%@ Register src="../../UIControls/Configurations/CtrlRoomService.ascx" tagname="CtrlRoomService" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlRoomService ID="CtrlRoomService1" runat="server" />
</asp:Content>
