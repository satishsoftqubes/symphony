<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true" CodeBehind="CounterName.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.Configurations.CounterName" %>
<%@ Register src="../../UIControls/Configurations/CtrlCounterName.ascx" tagname="CtrlCounterName" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlCounterName ID="CtrlCounterName1" runat="server" />
</asp:Content>
