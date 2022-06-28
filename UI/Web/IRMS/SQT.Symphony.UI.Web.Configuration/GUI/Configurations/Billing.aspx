<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/admin.Master" CodeBehind="Billing.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.Configurations.Billing" %>
<%@ Register Src="~/UIControls/Configurations/CtrlBilling.ascx" TagName="Billing" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<uc1:Billing ID="ucCtrlBilling" runat="server"/>
</asp:Content>
