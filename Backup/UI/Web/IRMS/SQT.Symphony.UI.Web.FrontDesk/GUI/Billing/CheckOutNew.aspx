<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="CheckOutNew.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Billing.CheckOutNew" %>
<%@ Register Src="~/UIControls/Billing/CtrlCheckOutNew.ascx" TagName="CheckOutNew" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CheckOutNew ID="ucCtrlCheckOut" runat="server" />
</asp:Content>

