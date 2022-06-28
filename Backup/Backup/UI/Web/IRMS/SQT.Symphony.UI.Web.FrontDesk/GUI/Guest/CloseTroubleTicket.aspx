<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="CloseTroubleTicket.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Guest.CloseTroubleTicket" %>
<%@ Register src="../../UIControls/Guest/CtrlCloseTroubleTicket.ascx" tagname="CtrlCloseTroubleTicket" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlCloseTroubleTicket ID="CtrlCloseTroubleTicket1" runat="server" />
</asp:Content>
