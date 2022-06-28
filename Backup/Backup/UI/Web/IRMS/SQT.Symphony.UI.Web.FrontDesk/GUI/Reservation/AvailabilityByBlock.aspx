<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="AvailabilityByBlock.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Reservation.AvailabilityByBlock" %>
<%@ Register src="../../UIControls/Reservation/AvailabilityByBlock.ascx" tagname="AvailabilityByBlock" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:AvailabilityByBlock ID="AvailabilityByBlock1" runat="server" />
</asp:Content>
