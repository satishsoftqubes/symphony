<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="ChannelPartnerSetUp.aspx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.Applications.Investors.ChannelPartnerSetUp" %>
<%@ Register src="~/UIControls/InvestorSetUp/CtrlChannelPartner.ascx" tagname="CtrlChannelPartner" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../Javascript/jquery-1.4.1.min.js" type="text/javascript"></script>
<script src="../../Javascript/jquery.autocomplete.js" type="text/javascript"></script>
<link href="../../Javascript/jquery.autocomplete.css" rel="stylesheet" type="text/css" />

    <uc1:CtrlChannelPartner ID="CtrlChannelPartnerStup" runat="server" />
</asp:Content>
