<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="GroupReservationList.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Reservation.GroupReservationList" %>
<%@ Register src="~/UIControls/Reservation/CtrlGroupReservationList.ascx" tagname="CtrlGroupReservationList" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="../../Scripts/jquery.min.js"></script>
    <link rel="stylesheet" href="../../Styles/jquery.ui.core.css"/>
    <link rel="stylesheet" href="../../Styles/jquery.ui.tabs.css"/>	
    <link rel="stylesheet" href="../../Styles/jquery.ui.theme.css"/>	
    <script src="../../Scripts/jquery-1.7.1.js"></script>
	<script src="../../Scripts/jquery.ui.core.js"></script>
	<script src="../../Scripts/jquery.ui.widget.js"></script>
	<script src="../../Scripts/jquery.ui.tabs.js"></script>	    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<uc1:CtrlGroupReservationList ID="CtrlGroupReservationList" runat="server" />
</asp:Content>
