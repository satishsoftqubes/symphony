<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true"
    CodeBehind="TroubleTicket.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Guest.TroubleTicket" %>

<%@ Register Src="~/UIControls/Guest/CtrlTroubleTicket.ascx" TagName="Ticket" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:Ticket ID="ucCtrlTroubleTicket" runat="server" />
</asp:Content>
