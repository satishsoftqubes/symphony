<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true" CodeBehind="ConferenceList.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.Configurations.ConferenceList" %>
<%@ Register Src="~/UIControls/Configurations/CtrlConferenceList.ascx" TagName="CtrlConferenceList" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<uc1:CtrlConferenceList ID="ucCtrlConferenceList" runat="server"/>
</asp:Content>
