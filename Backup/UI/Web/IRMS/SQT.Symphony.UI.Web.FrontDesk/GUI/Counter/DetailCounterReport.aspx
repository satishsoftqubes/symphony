<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="DetailCounterReport.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.DetailCounterReport" %>
<%@ Register src="~/UIControls/CommonControls/CtrlDetailsCounterReport.ascx" tagname="CtrlDetailsCounterReport" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlDetailsCounterReport ID="CtrlDetailsCounterReport1" runat="server" />
</asp:Content>
