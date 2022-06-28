<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="GuestAllMsgList.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Guest.GuestAllMsgList" %>
<%@ Register src="../../UIControls/CommonControls/CtrlGuestAllMsgList.ascx" tagname="CtrlGuestAllMsgList" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlGuestAllMsgList ID="CtrlGuestAllMsgList1" runat="server" />
</asp:Content>
