<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="FolioDetailsOld.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Folio.FolioDetailsOld" %>
<%@ Register src="../../UIControls/Folio/CtrlFolioDetailsOld.ascx" tagname="CtrlFolioDetailsOld" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlFolioDetailsOld ID="CtrlFolioDetailsOld1" runat="server" />
</asp:Content>
