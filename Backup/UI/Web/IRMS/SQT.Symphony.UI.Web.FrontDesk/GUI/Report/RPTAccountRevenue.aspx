<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="RPTAccountRevenue.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Report.RPTAccountRevenue" %>
<%@ Register src="~/UIControls/Report/CtrlAccountRevenueDetail.ascx" tagname="CtrlAccountRevenueDetail" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlAccountRevenueDetail ID="ucCtrlAccountRevenueDetail" runat="server" />
</asp:Content>
