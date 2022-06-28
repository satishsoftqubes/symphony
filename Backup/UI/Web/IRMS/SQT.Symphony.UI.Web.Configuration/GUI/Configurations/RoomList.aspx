<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true" CodeBehind="RoomList.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.Configurations.RoomList" %>
<%@ Register src="../../UIControls/Configurations/CtrlRoomList.ascx" tagname="CtrlRoomList" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<script src="../../Javascript/jquery-1.4.1.min.js" type="text/javascript"></script>--%>    
    <script type="text/javascript" src="../../Javascript/jquery.min.js"></script>
    <script src="../../Javascript/jquery-ui.min.js" type="text/javascript"></script>
    <link rel="stylesheet" href="../../Scripts/jquery.ui.core.css" />
    <link rel="stylesheet" href="../../Scripts/jquery.ui.tabs.css" />
    <link rel="stylesheet" href="../../Scripts/jquery.ui.theme.css" />
    <script src="../../Scripts/jquery-1.7.1.js"></script>
    <script src="../../Scripts/jquery.ui.core.js"></script>
    <script src="../../Scripts/jquery.ui.widget.js"></script>
    <script src="../../Scripts/jquery.ui.tabs.js"></script>
    <script src="../../Scripts/jquery.ui.mouse.js"></script>
	<script src="../../Scripts/jquery.ui.sortable.js"></script>        
    <script src="../../Javascript/jquery.autocomplete.js" type="text/javascript"></script>
    <link href="../../Javascript/jquery.autocomplete.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlRoomList ID="ucCtrlRoomList" runat="server" />
</asp:Content>
