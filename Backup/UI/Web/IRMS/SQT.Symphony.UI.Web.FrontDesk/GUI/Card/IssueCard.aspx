<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IssueCard.aspx.cs" MasterPageFile="~/Master/Site.Master"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Card.IssueCard" %>

<%@ Register Src="~/UIControls/Card/ctrlIssueCard.ascx" TagName="IssueCard" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:IssueCard ID="ucCtrlIssueCard" runat="server" />
</asp:Content>
