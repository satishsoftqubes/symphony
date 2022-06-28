<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true"
    CodeBehind="SendEmailToGuest.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Guest.SendEmailToGuest" %>
<%@ Register Src="../../UIControls/Guest/CtrlSendEmailToGuest.ascx" TagName="CtrlSendEmailToGuest"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlSendEmailToGuest ID="ucCtrlSendEmailToGuest" runat="server" />
</asp:Content>
