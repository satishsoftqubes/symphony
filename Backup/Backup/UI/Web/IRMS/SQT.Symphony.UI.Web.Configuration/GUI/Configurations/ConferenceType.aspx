<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true"
    CodeBehind="ConferenceType.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.Configurations.ConferenceType" %>

<%@ Register Src="~/UIControls/Configurations/CtrlConferenceType.ascx" TagName="CtrlConferenceType"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlConferenceType ID="CtrlConferenceType" runat="server" />
</asp:Content>
