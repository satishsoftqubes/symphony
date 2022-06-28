<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="RPTOccupancyChartByBlockType.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Report.RPTOccupancyChartByBlockType" EnableEventValidation="false"  %>
<%@ Register src="~/UIControls/Report/CtrlOccupancyChartByBlockType.ascx" tagname="CtrlOccupancyChartByBlockType" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
    <uc1:CtrlOccupancyChartByBlockType ID="ucCtrlOccupancyChartByBlockType" runat="server" />
</asp:Content>
