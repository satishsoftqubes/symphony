<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="CounterCloseHistoryOnThisMachine.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.CounterCloseHistoryOnThisMachine" %>
<%@ Register src="~/UIControls/CommonControls/CtrlCounterCloseHistoryOnThisMachine.ascx" tagname="CtrlCounterCloseHistoryOnThisMachine" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlCounterCloseHistoryOnThisMachine ID="CtrlCounterCloseHistoryOnThisMachine1" 
        runat="server" />
</asp:Content>
