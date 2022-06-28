<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="RateCardList.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Reservation.RateCardList" %>
<%@ Register src="~/UIControls/Reservation/CtrlRateCardList.ascx" tagname="CtrlRateCardList" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<uc1:CtrlRateCardList ID="ucCtrlRateCardList" runat="server" />
</asp:Content>
