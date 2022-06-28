<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InvestorUnitList.aspx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.Applications.Investors.InvestorUnitList" %>
<%@ Register src="~/UIControls/InvestorSetUp/CtrlInvestorUnitList.ascx" tagname="CtrlInvestorProfile" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="../../Javascript/jquery-1.4.1.min.js" type="text/javascript"></script>
<script src="../../Javascript/jquery.autocomplete.js" type="text/javascript"></script>
<link href="../../Javascript/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlInvestorProfile ID="LstUnit" runat="server" />
</asp:Content>
