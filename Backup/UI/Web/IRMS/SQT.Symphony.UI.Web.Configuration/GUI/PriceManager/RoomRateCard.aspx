<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="RoomRateCard.aspx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.GUI.PriceManager.RoomRateCard" %>

<%@ Register Src="~/UIControls/PriceManager/CtrlRoomRateCard.ascx" TagName="CtrlRoomRateCard"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" href="../../Scripts/jquery.ui.core.css">
    <link rel="stylesheet" href="../../Scripts/jquery.ui.tabs.css">	
    <link rel="stylesheet" href="../../Scripts/jquery.ui.theme.css">	
    <script src="../../Scripts/jquery-1.7.1.js"></script>
	<script src="../../Scripts/jquery.ui.core.js"></script>
	<script src="../../Scripts/jquery.ui.widget.js"></script>
	<script src="../../Scripts/jquery.ui.tabs.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlRoomRateCard ID="ucRoomRateCard" runat="server" />
</asp:Content>
