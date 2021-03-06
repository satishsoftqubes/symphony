<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InvestorPaymentList.aspx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.Applications.Investors.InvestorPaymentList" %>
<%@ Register src="~/UIControls/InvestorSetUp/CtrlInvestorPaymentList.ascx" tagname="CtrlInvestorProfile" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" href="../../Scripts/jquery.ui.core.css">
    <link rel="stylesheet" href="../../Scripts/jquery.ui.tabs.css">	
    <link rel="stylesheet" href="../../Scripts/jquery.ui.theme.css">	
    <script src="../../Scripts/jquery-1.7.1.js"></script>
	<script src="../../Scripts/jquery.ui.core.js"></script>
	<script src="../../Scripts/jquery.ui.widget.js"></script>
	<script src="../../Scripts/jquery.ui.tabs.js"></script>
<%--<script src="../../Javascript/jquery-1.4.1.min.js" type="text/javascript"></script>--%>
<script src="../../Javascript/jquery.autocomplete.js" type="text/javascript"></script>
<link href="../../Javascript/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<uc1:CtrlInvestorProfile ID="Paylist" runat="server" />
</asp:Content>
