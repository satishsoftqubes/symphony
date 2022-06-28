<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/Site.Master"
    CodeBehind="AddGroupGuest.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Reservation.AddGroupGuest" %>

<%@ Register Src="~/UIControls/Reservation/ctrlAddGuest.ascx" TagName="AddGroupGuest"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:AddGroupGuest ID="CtrlAddGroupGuest" runat="server" />
</asp:Content>
