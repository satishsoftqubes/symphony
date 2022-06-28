<%@ Page Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true" CodeBehind="CurrencySetup.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.Configurations.CurrencySetup" %>
<%@ Register src="~/UIControls/Configurations/CtrlCurrencySetup.ascx" tagname="CtrlCurrencySetup" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlCurrencySetup ID="CtrlCurrencySetup1" runat="server" />
</asp:Content>
