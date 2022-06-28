<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SMSTemplateSetUp.aspx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.Applications.Activity.SMSTemplateSetUp" %>
<%@ Register src="~/UIControls/Activity/CtrlSMSTemplate.ascx" tagname="CtrlSMSTemplate" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlSMSTemplate ID="CtrlSMSTemplateCtrl" runat="server" />
</asp:Content>
