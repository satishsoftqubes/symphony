<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true" CodeBehind="LanguageSetup.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.Configurations.LanguageSetup" %>
<%@ Register src="~/UIControls/Configurations/CtrlLanguageSetup.ascx" tagname="CtrlLanguageSetup" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlLanguageSetup ID="ucCtrlLanguageSetup" runat="server" />
</asp:Content>
