<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true" CodeBehind="UnitResell.aspx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.Applications.Investors.UnitResell" %>
<%@ Register src="~/UIControls/InvestorSetUp/CtrlUnitResell.ascx" tagname="CtrlUnitResell" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<uc1:CtrlUnitResell ID="ucCtrlUnitResell" runat="server" />
</asp:Content>
