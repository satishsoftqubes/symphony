<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/Site.Master"
    CodeBehind="ChangeRoom.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Guest.ChangeRoom" %>

<%@ Register Src="~/UIControls/Guest/CtrlChangeRoom.ascx" TagName="ChangeRoom"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ChangeRoom ID="ucChangeRoom" runat="server" />
</asp:Content>
