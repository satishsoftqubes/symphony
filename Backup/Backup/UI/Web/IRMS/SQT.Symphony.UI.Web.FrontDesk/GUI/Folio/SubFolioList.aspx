<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/Site.Master"
    CodeBehind="SubFolioList.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Folio.SubFolioList" %>

<%@ Register Src="~/UIControls/Folio/CtrlSubFolioList.ascx" TagName="CtrSubFolio"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc2:CtrSubFolio ID="CtrSubFolio1" runat="server" />
</asp:Content>
