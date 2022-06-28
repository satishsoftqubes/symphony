<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true" CodeBehind="BlockRoom.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.Configurations.BlockRoom" %>
<%@ Register src="~/UIControls/Configurations/CtrlBlockRoom.ascx" tagname="CtrlBlockRoom" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="../../Javascript/jquery-1.4.1.min.js" type="text/javascript"></script>
<script src="../../Javascript/jquery.autocomplete.js" type="text/javascript"></script>
<link href="../../Javascript/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<uc1:CtrlBlockRoom ID="ucCtrlBlockRoom" runat="server" />
</asp:Content>
