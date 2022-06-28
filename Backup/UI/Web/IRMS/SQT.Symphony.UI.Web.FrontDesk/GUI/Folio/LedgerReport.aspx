<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/Site.Master"
    CodeBehind="LedgerReport.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Folio.LedgerReport" %>

<%@ Register Src="~/UIControls/Folio/CtrlLedgerReport.ascx" TagName="CtrlLedgerRpt"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlLedgerRpt ID="ucLedgerRpt" runat="server" />
</asp:Content>
