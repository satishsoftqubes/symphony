<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RPTInvestorList.aspx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.Applications.Reports.RPTInvestorList" %>

<%@ Register src="~/UIControls/Reports/CtrlInvestorList.ascx" tagname="CtrlRPTInvestorList" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlRPTInvestorList ID="ucInvestorList" runat="server" />
</asp:Content>