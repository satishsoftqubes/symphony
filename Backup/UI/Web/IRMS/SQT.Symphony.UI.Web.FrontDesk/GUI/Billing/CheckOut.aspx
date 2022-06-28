<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckOut.aspx.cs" MasterPageFile="~/Master/Site.Master"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Billing.CheckOut" %>

<%@ Register Src="~/UIControls/Billing/CtrlCheckOut.ascx" TagName="CheckOut" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CheckOut ID="ucCtrlCheckOut" runat="server" />
</asp:Content>
