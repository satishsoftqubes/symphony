<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/Site.Master"
    CodeBehind="AccessDenied.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.CommonControl.AccessDenied" %>

<%@ Register Src="~/UIControls/CommonControls/CtrlAccessDenied.ascx" TagName="CtrlAccessDenied"
    TagPrefix="ucCtrlAccessDenied" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ucCtrlAccessDenied:CtrlAccessDenied ID="ctrlCommonCtrlAccessDenied" runat="server" />
</asp:Content>
