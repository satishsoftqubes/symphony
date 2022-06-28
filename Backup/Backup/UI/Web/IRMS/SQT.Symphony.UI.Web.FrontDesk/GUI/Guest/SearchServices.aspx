<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="SearchServices.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Guest.SearchServices" %>
<%@ Register Src="~/UIControls/Guest/CtrlSearchServices.ascx" TagName="CtrlSearchServices" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<uc1:CtrlSearchServices ID="ucCtrlSearchServices" runat="server" />
</asp:Content>
