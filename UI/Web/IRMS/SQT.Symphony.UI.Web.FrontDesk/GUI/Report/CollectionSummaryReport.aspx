<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="CollectionSummaryReport.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Report.CollectionSummaryReport" %>
<%@ Register src="~/UIControls/Report/CtrlCollectionReport.ascx" tagname="CtrlCollectionReport" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlCollectionReport ID="ucCollectionSummary" runat="server" />
</asp:Content>
