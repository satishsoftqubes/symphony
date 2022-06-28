<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="WalkIn.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Reservation.WalkIn" %>
<%@ Register src="~/UIControls/Reservation/CtrlWalkIn.ascx" tagname="CtrlWalkIn" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlWalkIn ID="CtrlWalkIn" runat="server" />
</asp:Content>
