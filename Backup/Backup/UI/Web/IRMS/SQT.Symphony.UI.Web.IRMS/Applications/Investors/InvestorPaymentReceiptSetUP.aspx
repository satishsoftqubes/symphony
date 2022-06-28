<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="InvestorPaymentReceiptSetUP.aspx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.Applications.Investors.InvestorPaymentReceiptSetUP" %>
<%@ Register src="~/UIControls/InvestorSetUp/CtrlInvestorPaymentReceipt.ascx" tagname="CtrlInvestorPaymentReceipt" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script src="../../Javascript/jquery-1.4.1.min.js" type="text/javascript"></script>
<script src="../../Javascript/jquery.autocomplete.js" type="text/javascript"></script>
<link href="../../Javascript/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
    <uc1:CtrlInvestorPaymentReceipt ID="CtrlInvestorPaymentReceipt1" 
        runat="server" />
</asp:Content>
