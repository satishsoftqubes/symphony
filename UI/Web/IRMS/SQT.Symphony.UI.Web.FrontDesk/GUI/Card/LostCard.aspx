<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/Site.Master" CodeBehind="LostCard.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Card.LostCard" %>

<%@ Register Src="~/UIControls/Card/CtrlLostCard.ascx" TagName="LostCard" TagPrefix="uc1" %>
<asp:content id="Content1" contentplaceholderid="head" runat="server">
</asp:content>
<asp:content id="Content2" contentplaceholderid="ContentPlaceHolder1" runat="server">
    <uc1:LostCard ID="ucCtrlLostCard" runat="server" />
</asp:content>
