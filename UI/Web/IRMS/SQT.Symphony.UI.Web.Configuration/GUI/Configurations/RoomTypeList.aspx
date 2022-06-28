<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true" CodeBehind="RoomTypeList.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.Configurations.RoomTypeList" %>

<%@ Register src="../../UIControls/Configurations/CtrlRoomTypeList.ascx" tagname="CtrlRoomTypeList" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <uc1:CtrlRoomTypeList ID="CtrlRoomTypeList1" runat="server" />
    
</asp:Content>
