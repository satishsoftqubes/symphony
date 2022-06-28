<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true"
    CodeBehind="AccessDenied.aspx.cs" Inherits="SQT.Symphony.UI.Web.BackOffice.GUI.AccessDenied" %>

<%@ Register Src="~/UIControls/CommonControls/CtrlAccessDenied.ascx" TagName="CtrlAccessDenied"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlAccessDenied ID="CtrlAccessDenied1" runat="server" />
</asp:Content>
