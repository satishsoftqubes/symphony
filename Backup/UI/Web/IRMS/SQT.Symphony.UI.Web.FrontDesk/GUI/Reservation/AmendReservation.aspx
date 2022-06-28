<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true"
    CodeBehind="AmendReservation.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Reservation.AmendReservation" %>

<%@ Register Src="~/UIControls/Reservation/ctrlAmendReservation.ascx" TagName="CtrlAmendReservation"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link type="text/css" href="../../Styles/jquery-ui-1.8.5.custom.css" rel="stylesheet" />
<script type="text/javascript" src="../../Scripts/jquery-1.4.2.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<uc1:CtrlAmendReservation ID="ucCtrlAmendReservation" runat="server" />
</asp:Content>