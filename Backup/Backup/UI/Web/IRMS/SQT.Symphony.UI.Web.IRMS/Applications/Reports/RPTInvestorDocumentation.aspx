<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RPTInvestorDocumentation.aspx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.Applications.Reports.RPTInvestorDocumentation" %>

<%@ Register src="~/UIControls/Reports/CtrlInvestorDocumentation.ascx" tagname="CtrlRPTInvestorDocumetation" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlRPTInvestorDocumetation ID="ucInvestorDocumentaion" runat="server" />
</asp:Content>

