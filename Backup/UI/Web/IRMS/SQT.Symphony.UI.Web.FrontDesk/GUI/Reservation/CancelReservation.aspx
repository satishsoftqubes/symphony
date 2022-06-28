<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true"
    CodeBehind="CancelReservation.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Reservation.CancelReservation" %>

<%@ Register Src="~/UIControls/Reservation/ctrlCancelReservation.ascx" TagName="CtrlCancelReservation"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<uc1:CtrlCancelReservation ID="ucCtrlCancelReservation" runat="server" />
</asp:Content>
