<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="ManageResourceFile.aspx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.GUI.Configurations.ManageResourceFile" %>

<%@ Register Src="~/UIControls/Configurations/CtrlManageResourceFile.ascx" TagName="CtrlManageResourceFile"
    TagPrefix="uc1" %>
<asp:content id="Content1" contentplaceholderid="head" runat="server">
</asp:content>
<asp:content id="Content2" contentplaceholderid="ContentPlaceHolder1" runat="server">
    <uc1:CtrlManageResourceFile ID="ucCtrlManageResourceFile" runat="server" />
</asp:content>
