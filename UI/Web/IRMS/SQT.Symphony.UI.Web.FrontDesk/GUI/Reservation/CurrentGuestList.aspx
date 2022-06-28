<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/Site.Master"
    CodeBehind="CurrentGuestList.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Reservation.CurrentGuestList" %>

<%@ Register Src="~/UIControls/Reservation/CtrlCurrentGuestList.ascx" TagName="CtrlCurrentGuestList"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlCurrentGuestList ID="ucCtrlCurrentGuestList" runat="server" />
</asp:Content>
