<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="CashCardList.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Guest.CashCardList" %>
<%@ Register Src="~/UIControls/Card/CtrlCashCardList.ascx" TagName="CtrlCashCardList" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<uc1:CtrlCashCardList ID="CtrlCashCardList" runat="server" />
</asp:Content>
