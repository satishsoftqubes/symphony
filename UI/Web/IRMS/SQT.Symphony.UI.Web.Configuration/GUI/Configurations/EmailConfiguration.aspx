<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true" CodeBehind="EmailConfiguration.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.Configurations.EmailConfiguration" %>
<%@ Register src="~/UIControls/Configurations/CtrlEmailConfiguration.ascx" tagname="CtrlEmailConfiguration" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlEmailConfiguration ID="CtrlEmailConfigurationstup" runat="server" />
</asp:Content>
