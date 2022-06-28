<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="EmailTemplateSetup.aspx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.Applications.Activity.EmailTemplateSetup" %>
<%@ Register src="~/UIControls/Activity/CtrlEmailTemplate.ascx" tagname="CtrlEmailTemplate" tagprefix="uc1" %>
<asp:content id="Content1" contentplaceholderid="head" runat="server">
</asp:content>
<asp:content id="Content2" contentplaceholderid="ContentPlaceHolder1" runat="server">
    <uc1:CtrlEmailTemplate ID="ucEmailTemplate" runat="server" />
</asp:content>
