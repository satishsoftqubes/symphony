<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true" CodeBehind="GuestPreferenceSetup.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.Configurations.GuestPreferenceSetup" %>

<%@ Register src="../../UIControls/Configurations/CtrlGuestPreferenceSetup.ascx" tagname="CtrlGuestPreferenceSetup" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <uc1:CtrlGuestPreferenceSetup ID="CtrlGuestPreferenceSetup1" runat="server" />
    
</asp:Content>
