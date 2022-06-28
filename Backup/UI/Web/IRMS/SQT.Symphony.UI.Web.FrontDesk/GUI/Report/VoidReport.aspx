<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="VoidReport.aspx.cs"
 Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Report.VoidReport" %>

<%@ Register Src="~/UIControls/Report/CtrlVoidReport.ascx" TagName="CtrlVoidReport" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlVoidReport ID="ucVoidReport" runat="server" />
</asp:Content>
