<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true" CodeBehind="CurrencyType.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.Configurations.CurrencyType" %>
<%@ Register src="~/UIControls/Configurations/CtrlCurrencyType.ascx" tagname="CtrlCurrencyType" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="../../Javascript/jquery-1.4.1.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<uc1:CtrlCurrencyType ID="ucCtrlCurrencyType" runat="server" />
</asp:Content>
