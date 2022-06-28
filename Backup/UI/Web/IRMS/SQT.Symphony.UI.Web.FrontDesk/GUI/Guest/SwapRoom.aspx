<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/Site.Master"
    CodeBehind="SwapRoom.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Guest.SwapRoom" %>

<%@ Register Src="~/UIControls/Guest/CtrlSwapRoom.ascx" TagName="SwapRoom" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:SwapRoom ID="ucCtrlSwapRoom" runat="server" />
</asp:Content>
