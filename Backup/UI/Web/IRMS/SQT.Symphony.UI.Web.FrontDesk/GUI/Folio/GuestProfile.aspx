<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/Site.Master" CodeBehind="FolioList.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Folio.FolioList" %>

<%@ Register src="../../UIControls/CommonControls/CtrGuestProfile.ascx" tagname="CtrGuestProfile" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <uc2:CtrGuestProfile ID="CtrGuestProfile1" runat="server" />
    
</asp:Content>
