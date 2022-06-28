<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="AccessIsDenied.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.AccessIsDenied" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlAccessIsDenied.ascx" TagName="CtrlAccessIsDenied"
    TagPrefix="ucCtrlAccessDenied" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ucCtrlAccessDenied:CtrlAccessIsDenied ID="ctrlCommonCtrlAccessIsDenied" runat="server" />
</asp:Content>