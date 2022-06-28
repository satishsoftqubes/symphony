<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="GroupReservation.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Reservation.GroupReservation" %>
<%@ Register src="~/UIControls/Reservation/CtrlGroupReservation.ascx" tagname="CtrlGroupReservation" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<uc1:CtrlGroupReservation ID="CtrlGroupReservation" runat="server" />
</asp:Content>
