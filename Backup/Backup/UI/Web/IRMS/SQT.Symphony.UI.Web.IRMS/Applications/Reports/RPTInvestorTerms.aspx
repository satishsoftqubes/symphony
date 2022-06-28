<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RPTInvestorTerms.aspx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.Applications.Reports.RPTInvestorTerms" %>


<%@ Register src="~/UIControls/Reports/CtrlInvestorTerm.ascx" tagname="CtrlRPTInvestorTerm" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlRPTInvestorTerm ID="ucInvestorTerm" runat="server" />
</asp:Content>

