<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="AvailabilityByFloor.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Reservation.AvailabilityByFloor" %>
<%@ Register src="../../UIControls/Reservation/CtrlAvailabilityByFloor.ascx" tagname="CtrlAvailabilityByFloor" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlAvailabilityByFloor ID="CtrlAvailabilityByFloor1" runat="server" />
</asp:Content>
