<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/Site.Master" CodeBehind="RerouteFolioSetup.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Folio.RerouteFolioSetup1" %>
<%@ Register Src="~/UIControls/Folio/CtrlReRouteFolioSetup.ascx" TagName="CtrlRerouteFolioSetup"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<uc1:CtrlRerouteFolioSetup ID="ucCtrlRerouteFolioSetup" runat="server" />
</asp:Content>