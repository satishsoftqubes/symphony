<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GeneralDocumentList.aspx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.Applications.Activity.GeneralDocumentList" %>
<%@ Register src="~/UIControls/Activity/CtrlGeneralDocumentList.ascx" tagname="GeneralDocumentList" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:GeneralDocumentList ID="CtrlGeneralDocumentList" runat="server" />
</asp:Content>
