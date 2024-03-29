﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/Site.Master"
    CodeBehind="RoomReservation.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Reservation.RoomReservation" %>

<%@ Register Src="~/UIControls/Reservation/CtrlRoomReservation.ascx" TagName="CtrlRoomReservation"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link type="text/css" href="../../Styles/jquery-ui-1.8.5.custom.css" rel="stylesheet" />
    <script type="text/javascript" src="../../Scripts/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery-ui-1.8.5.custom.min.js"></script>
    <link rel="stylesheet" href="../../Styles/jquery.ui.timepicker.css" type="text/css" />
    <script type="text/javascript" src="../../Scripts/jquery-ui-timepicker-addon.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlRoomReservation ID="ucCtrlRoomReservation" runat="server" />
</asp:Content>
