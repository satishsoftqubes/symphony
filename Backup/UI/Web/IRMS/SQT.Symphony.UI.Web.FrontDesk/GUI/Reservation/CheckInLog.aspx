<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="CheckInLog.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Reservation.CheckInLog" %>
<%@ Register src="../../UIControls/Reservation/CtrlCheckInLog.ascx" tagname="CtrlCheckInLog" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlCheckInLog ID="CtrlCheckInLog1" runat="server" />
</asp:Content>
