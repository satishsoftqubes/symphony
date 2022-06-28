<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="RPTOccupancyChartByBlockAndRoomType.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Report.RPTOccupancyChartByBlockAndRoomType" EnableEventValidation="false" %>
<%@ Register src="~/UIControls/Report/CtrlOccupancyChartByBlockAndRoomType.ascx" tagname="CtrlOccupancyChartByBlockAndRoomType" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
    <uc1:CtrlOccupancyChartByBlockAndRoomType ID="ucCtrlOccupancyChartByBlockAndRoomType" runat="server" />
</asp:Content>

