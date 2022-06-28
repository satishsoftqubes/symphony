<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="RPTBillFormat.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Report.RPTBillFormat" %>
<%@ Register src="~/UIControls/Report/CtrlBillFormat.ascx" tagname="CtrlBillFormat" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlBillFormat ID="ucCtrlBillFormat" runat="server" />
</asp:Content>
