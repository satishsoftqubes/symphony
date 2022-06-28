<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="CloseCounter.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.CloseCounter" %>
<%@ Register src="~/UIControls/CommonControls/CtrlCounterClose.ascx" tagname="CtrlCounterClose" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlCounterClose ID="CtrlCounterClose1" runat="server" />
</asp:Content>
