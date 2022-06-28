<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RPTProspectsList.aspx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.Applications.Reports.RPTProspectsList" %>
<%@ Register src="~/UIControls/Reports/CtrlProspectsList.ascx" tagname="CtrlRPTProspectsList" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlRPTProspectsList ID="ucProspectsList" runat="server" />
</asp:Content>