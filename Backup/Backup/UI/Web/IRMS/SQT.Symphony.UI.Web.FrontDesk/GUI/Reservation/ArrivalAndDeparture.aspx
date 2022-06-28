<%@ Page Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="ArrivalAndDeparture.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Reservation.ArrivalAndDeparture" %>

<%@ Register src="../../UIControls/Reservation/CtrlArrivalAndDeparture.ascx" tagname="CtrlArrivalAndDeparture" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlArrivalAndDeparture ID="CtrlArrivalAndDeparture1" runat="server" />
</asp:Content>
