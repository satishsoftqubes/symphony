<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/Site.Master"
    CodeBehind="PrintStatement.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Card.PrintStatement" %>

<%@ Register Src="~/UIControls/Card/CtrlPrintStatement.ascx" TagName="PrintStatement"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:PrintStatement ID="ucCtrlPrintStatement" runat="server" />
</asp:Content>
