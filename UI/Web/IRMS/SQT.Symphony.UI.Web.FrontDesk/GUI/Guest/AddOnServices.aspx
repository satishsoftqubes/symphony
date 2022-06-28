<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="AddOnServices.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Guest.AddOnServices" %>
<%@ Register Src="~/UIControls/Guest/CtrlAddOnServices.ascx" TagName="CtrlAddOnServices" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<uc1:CtrlAddOnServices ID="ucCtrlAddOnServices" runat="server" />
</asp:Content>