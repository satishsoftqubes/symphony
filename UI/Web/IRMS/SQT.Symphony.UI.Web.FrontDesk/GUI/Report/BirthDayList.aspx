<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="BirthDayList.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Report.BirthDayList" %>
<%@ Register src="~/UIControls/Report/CtrlBirthDayList.ascx" tagname="CtrlBirthDayList" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlBirthDayList ID="ucCtrlBirthDayList" runat="server" />
</asp:Content>
