<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MarketRate.aspx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.Applications.Activity.MarketRate" %>

<%@ Register Src="~/UIControls/Activity/MarketRate.ascx" TagName="ucMarketRate"
    TagPrefix="uc1" %>
<asp:content id="Content1" contentplaceholderid="head" runat="server">
</asp:content>
<asp:content id="Content2" contentplaceholderid="ContentPlaceHolder1" runat="server">
    <uc1:ucMarketRate ID="CtrlucMarketRate" runat="server" />
</asp:content>