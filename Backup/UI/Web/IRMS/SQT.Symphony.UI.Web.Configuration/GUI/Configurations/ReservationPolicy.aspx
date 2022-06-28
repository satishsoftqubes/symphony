<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true" CodeBehind="ReservationPolicy.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.Configurations.ReservationPolicy" %>
<%@ Register src="~/UIControls/Configurations/CtrlReservationPolicy.ascx" tagname="CtrlReservationPolicy" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlReservationPolicy ID="CtrlReservationPolicySetup" runat="server" />
</asp:Content>
