<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="ChannelPartnerUserStatus.aspx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.Applications.Investors.ChannelPartnerUserStatus" %>

<%@ Register Src="~/UIControls/InvestorSetUp/CtrlChannelPartnerUserStatus.ascx" TagName="CtrlChannelPartnerUserStatus"
    TagPrefix="uc1" %>
<asp:content id="Content1" contentplaceholderid="head" runat="server">
</asp:content>
<asp:content id="Content2" contentplaceholderid="ContentPlaceHolder1" runat="server">
<script src="../../Javascript/jquery-1.4.1.min.js" type="text/javascript"></script>
<script src="../../Javascript/jquery.autocomplete.js" type="text/javascript"></script>
<link href="../../Javascript/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
<uc1:CtrlChannelPartnerUserStatus ID="ucChannelPartnerUserStatus" runat="server" />
</asp:content>
