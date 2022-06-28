<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/Site.Master"
    CodeBehind="NewCheckInList.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Reservation.NewCheckInList" %>

<%@ Register Src="~/UIControls/Reservation/ctrlNewCheckInList.ascx" TagName="NewCheckInList"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:NewCheckInList ID="ctrlCommonCheckInList" runat="server" />
</asp:Content>
