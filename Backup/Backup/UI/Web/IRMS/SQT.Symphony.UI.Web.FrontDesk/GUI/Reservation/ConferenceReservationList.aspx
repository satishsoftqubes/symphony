<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="ConferenceReservationList.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Reservation.ConferenceReservationList" %>
<%@ Register Src="~/UIControls/Reservation/CtrlConferenceReservationList.ascx" TagName="CtrlConferenceReservationList"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<uc1:CtrlConferenceReservationList ID="ucCtrlConferenceReservationList" runat="server" />
</asp:Content>
