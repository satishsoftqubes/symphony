<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InvestorDocumentList.aspx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.Applications.Investors.InvestorDocumentList" %>
<%@ Register src="~/UIControls/InvestorSetUp/CtrlDocumentList.ascx" tagname="CtrlProspects" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlProspects ID="dclist" runat="server" />
</asp:Content>
