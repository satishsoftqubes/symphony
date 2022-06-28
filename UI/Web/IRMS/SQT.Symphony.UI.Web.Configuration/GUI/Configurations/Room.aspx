<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true" CodeBehind="Room.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.Configurations.Room" %>
<%@ Register src="~/UIControls/Configurations/CtrlRoom.ascx" tagname="CtrlRoom" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="../../Javascript/jquery.min.js"></script>
    <link rel="stylesheet" href="../../Scripts/jquery.ui.core.css"/>
    <link rel="stylesheet" href="../../Scripts/jquery.ui.tabs.css"/>	
    <link rel="stylesheet" href="../../Scripts/jquery.ui.theme.css"/>	
    <script src="../../Scripts/jquery-1.7.1.js"></script>
	<script src="../../Scripts/jquery.ui.core.js"></script>
	<script src="../../Scripts/jquery.ui.widget.js"></script>
	<script src="../../Scripts/jquery.ui.tabs.js"></script>	    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">                     
    <uc1:CtrlRoom ID="CtrlRoom" runat="server" />  
</asp:Content>
