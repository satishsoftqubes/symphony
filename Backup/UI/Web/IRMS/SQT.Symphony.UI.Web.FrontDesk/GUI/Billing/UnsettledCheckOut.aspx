<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true"
    CodeBehind="UnsettledCheckOut.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Billing.UnsettledCheckOut" %>

<%@ Register Src="~/UIControls/Billing/CtrlUnsettledCheckOut.ascx" TagName="UnsettledCheckOut" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UnsettledCheckOut ID="ucUnsettledCheckOut" runat="server" />
</asp:Content>
