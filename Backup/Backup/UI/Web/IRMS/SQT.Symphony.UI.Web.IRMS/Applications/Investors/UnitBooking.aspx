<%@ Page Title="" Language="C#" MasterPageFile="~/Master/investor.Master" AutoEventWireup="true" CodeBehind="UnitBooking.aspx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.Applications.Investors.UnitBooking" %>
<%@ Register src="../../UIControls/InvestorSetUp/CtrlUnitBooking.ascx" tagname="CtrlUnitBooking" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlUnitBooking ID="CtrlUnitBooking1" runat="server" />
</asp:Content>
