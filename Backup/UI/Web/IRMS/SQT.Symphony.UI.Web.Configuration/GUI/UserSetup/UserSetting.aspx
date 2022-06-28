<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true" CodeBehind="UserSetting.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.UserSetup.UserSetting" %>
<%@ Register src="../../UIControls/UserSetup/CtrlUserSetting.ascx" tagname="CtrlUserSetting" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlUserSetting ID="ucUserSetting" runat="server" />
</asp:Content>