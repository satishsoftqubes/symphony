<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="ConferenceReservation.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Reservation.ConferenceReservation" %>
<%@ Register Src="~/UIControls/Reservation/CtrlConferenceReservation.ascx" TagName="CtrlConferenceReservation"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<uc1:CtrlConferenceReservation ID="ucCtrlConferenceReservation" runat="server" />
</asp:Content>
