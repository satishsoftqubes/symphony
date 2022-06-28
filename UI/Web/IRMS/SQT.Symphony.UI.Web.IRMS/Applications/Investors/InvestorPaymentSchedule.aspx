<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="InvestorPaymentSchedule.aspx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.Applications.Investors.InvestorPaymentSchedule" %>

<%@ Register Src="~/UIControls/InvestorSetUp/CtrlInvestorPaymentSchedule.ascx" TagName="CtrlInvestorPaymentSchedule"
    TagPrefix="uc1" %>
<asp:content id="Content1" contentplaceholderid="ContentPlaceHolder1" runat="server">

    <script src="../../Javascript/jquery-1.4.1.min.js" type="text/javascript"></script>
<script src="../../Javascript/jquery.autocomplete.js" type="text/javascript"></script>
<link href="../../Javascript/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
    <uc1:CtrlInvestorPaymentSchedule ID="CtrlInvestorPaymentSchedule1" 
        runat="server" />
</asp:content>
