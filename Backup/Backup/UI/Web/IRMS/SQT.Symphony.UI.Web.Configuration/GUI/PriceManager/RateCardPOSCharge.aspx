<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true" CodeBehind="RateCardPOSCharge.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.PriceManager.RateCardPOSCharge" %>
<%@ Register Src="~/UIControls/PriceManager/RateCardPOSCharge.ascx" TagName="CtrlRateCardPOSCharge"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlRateCardPOSCharge ID="ucRateCardPOSCharge" runat="server" />
</asp:Content>
