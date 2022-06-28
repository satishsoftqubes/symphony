<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/Site.Master"
    CodeBehind="GuestMaster.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Guest.GuestMaster" %>

<%@ Register Src="~/UIControls/Guest/CtrlCommonGuestMaster.ascx" TagName="GuestMaster"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <uc1:GuestMaster ID="ucCtrlGuestMaster" runat="server" />
</asp:Content>
