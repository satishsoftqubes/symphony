<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/Site.Master" CodeBehind="FolioList.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Folio.FolioList" %>
<%@ Register Src="~/UIControls/Folio/CtrlFolioList.ascx" TagName="CtrlFolioList"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<uc1:CtrlFolioList ID="ucCtrlFolioList" runat="server" />
</asp:Content>

