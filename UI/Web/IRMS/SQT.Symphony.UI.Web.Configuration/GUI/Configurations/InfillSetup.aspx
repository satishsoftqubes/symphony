<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true" CodeBehind="InfillSetup.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.Configurations.InfillSetup" %>
<%@ Register src="~/UIControls/Configurations/CtrlInfillSetup.ascx" tagname="CtrlInfillSetup" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlInfillSetup ID="CtrlInfillSetupStup" runat="server" />
</asp:Content>
