<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true" CodeBehind="ExchangeRate.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.Configurations.ExchangeRate" %>

<%@ Register Src="~/UIControls/Configurations/CtrlExchangeRate.ascx" TagName="CtrlExchangeRate" TagPrefix="uc1"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder1">
 
 <uc1:CtrlExchangeRate ID="ucCtrlExchangeRate" runat="server"/>
</asp:Content>

