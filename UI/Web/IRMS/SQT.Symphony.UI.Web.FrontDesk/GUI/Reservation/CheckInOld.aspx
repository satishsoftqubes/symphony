<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true"
    CodeBehind="CheckInOld.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Reservation.CheckInOld" %>

<%@ Register Src="~/UIControls/Reservation/ctrlCheckInListOld.ascx" TagName="CheckInList"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CheckInList ID="ctrlCommonCheckInList" runat="server" />
</asp:Content>
