<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/Site.Master"
    CodeBehind="CardRecharge.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Card.CardRecharge" %>

<%@ Register Src="~/UIControls/Card/CtrlCardRecharge.ascx" TagName="CardRecharge"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CardRecharge ID="ucCtrlCardRecharge" runat="server" />
</asp:Content>
