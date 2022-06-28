<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="RPTRevenueDetail.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Report.RPTRevenueDetail" %>
<%@ Register src="~/UIControls/Report/CtrlRevenueDetail.ascx" tagname="CtrlRevenueDetail" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlRevenueDetail ID="ucCtrlRevenueDetail" runat="server" />
</asp:Content>

