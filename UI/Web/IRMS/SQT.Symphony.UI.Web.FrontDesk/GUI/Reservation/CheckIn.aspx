<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/Site.Master"
    CodeBehind="CheckIn.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Reservation.CheckIn" %>

<%@ Register Src="~/UIControls/Reservation/CtrlCheckIn.ascx" TagName="CheckIn"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CheckIn ID="ctrlCommonCheckIn" runat="server" />
</asp:Content>
