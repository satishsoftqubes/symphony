<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true"
    CodeBehind="UserSetting.aspx.cs" Inherits="SQT.Symphony.UI.Web.BackOffice.GUI.UserSetup.UserSetting" %>

<%@ Register Src="../../UIControls/CommonControls/CtrlUserSetting.ascx" TagName="CtrlUserSetting"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlUserSetting ID="ucUserSetting" runat="server" />
</asp:Content>
