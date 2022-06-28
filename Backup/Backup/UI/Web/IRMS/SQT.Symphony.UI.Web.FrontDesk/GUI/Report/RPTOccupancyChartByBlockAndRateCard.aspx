<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="RPTOccupancyChartByBlockAndRateCard.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Report.RPTOccupancyChartByBlockAndRateCard" %>
<%@ Register src="~/UIControls/Report/CtrlOccupancyChartByBlockAndRateCard.ascx" tagname="CtrlOccupancyChartByBlockAndRateCard" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
    <uc1:CtrlOccupancyChartByBlockAndRateCard ID="ucCtrlOccupancyChartByBlockAndRateCard" runat="server" />
</asp:Content>

