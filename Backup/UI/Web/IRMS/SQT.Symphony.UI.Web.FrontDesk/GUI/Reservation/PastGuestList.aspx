<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true"
    CodeBehind="PastGuestList.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Reservation.PastGuestList" %>

<%@ Register Src="~/UIControls/Reservation/CtrlPastGuestList.ascx" TagName="CtrlPastGuestList"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlPastGuestList ID="ucCtrlPastGuestList" runat="server" />
</asp:Content>