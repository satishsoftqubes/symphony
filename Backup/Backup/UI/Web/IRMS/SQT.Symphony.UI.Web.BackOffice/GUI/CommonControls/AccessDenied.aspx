<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/admin.Master" CodeBehind="AccessDenied.aspx.cs" Inherits="SQT.Symphony.UI.Web.BackOffice.GUI.CommonControls.AccessDenied" %>

<%@ Register Src="~/UIControls/CommonControls/CtrlAccessDenied.ascx" TagName="CtrlAccessDenied"
    TagPrefix="uc1" %>
<asp:content id="Content1" contentplaceholderid="head" runat="server">
    
</asp:content>
<asp:content id="Content2" contentplaceholderid="ContentPlaceHolder1" runat="server">
    <uc1:CtrlAccessDenied ID="CtrlAccessDenied1" runat="server" />
</asp:content>
