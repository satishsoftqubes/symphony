<%@ Page Title="" Language="C#" MasterPageFile="~/Master/investor.Master" AutoEventWireup="true" CodeBehind="RPTUnitPurchaseInformation.aspx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.Applications.Reports.RPTUnitPurchaseInformation" %>
<%@ Register src="~/UIControls/Reports/CtrlUnitBookingList.ascx" tagname="CtrlRPTUnitBookingList" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlRPTUnitBookingList ID="ucUnitBookingList" runat="server" />
</asp:Content>
