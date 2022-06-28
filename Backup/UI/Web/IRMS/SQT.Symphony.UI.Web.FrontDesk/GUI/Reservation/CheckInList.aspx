<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/Site.Master" CodeBehind="CheckInList.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Reservation.CheckInList" %>
<%@ Register Src="~/UIControls/Reservation/ctrlCheckInList.ascx" TagName="CheckInList"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CheckInList ID="ctrlCommonCheckInList" runat="server" />
</asp:Content>
