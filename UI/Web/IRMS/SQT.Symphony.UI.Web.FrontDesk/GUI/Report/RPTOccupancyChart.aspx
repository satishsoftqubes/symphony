<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="RPTOccupancyChart.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Report.RPTOccupancyChart" %>
<%@ Register src="~/UIControls/Report/CtrlOccupancyChart.ascx" tagname="CtrlOccupancyChart" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlOccupancyChart ID="ucCtrlOccupancyChart" runat="server" />
</asp:Content>
