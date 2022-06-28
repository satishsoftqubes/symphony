<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RPTInvestorBankDetail.aspx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.Applications.Reports.RPTInvestorBankDetail" %>

<%@ Register src="~/UIControls/Reports/CtrlInvestorBankDetail.ascx" tagname="CtrlRPTInvestorBankDetail" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlRPTInvestorBankDetail ID="ucInvestorBankDetail" runat="server" />
</asp:Content>

