<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/Site.Master"
    CodeBehind="Deposit.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Reservation.Deposit" %>

<%@ Register Src="~/UIControls/Folio/CtrlCommonAddDeposit.ascx" TagName="Deposit"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:Deposit ID="ctrlCommonCommonDeposit" runat="server" />
</asp:Content>
