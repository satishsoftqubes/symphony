<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InvestorPaymentDetilas.aspx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.Applications.Investors.InvestorPaymentDetilas" %>
<%@ Register src="~/UIControls/InvestorSetUp/CtrlInvestorPaymentDetails.ascx" tagname="CtrlInvestorProfile" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<uc1:CtrlInvestorProfile ID="Paylistddt" runat="server" />
</asp:Content>
