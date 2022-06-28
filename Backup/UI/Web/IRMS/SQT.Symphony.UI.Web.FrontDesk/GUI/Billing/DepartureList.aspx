<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true"
    CodeBehind="DepartureList.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Billing.DepartureList" %>

<%@ Register Src="~/UIControls/Billing/DepartureList.ascx" TagName="DepartureList" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:DepartureList ID="ucDepartureList" runat="server" />
</asp:Content>
