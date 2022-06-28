<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true" CodeBehind="GuestType.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.Configurations.GuestType" %>
<%@ Register src="../../UIControls/Configurations/CtrlGuestType.ascx" tagname="CtrlGuestType" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlGuestType ID="CtrlGuestType1" runat="server" />
</asp:Content>
