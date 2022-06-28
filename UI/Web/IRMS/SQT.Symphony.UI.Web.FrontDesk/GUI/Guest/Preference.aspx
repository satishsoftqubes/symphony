<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="Preference.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Guest.Preference" %>
<%@ Register src="../../UIControls/Guest/CtrlPreference.ascx" tagname="CtrlPreference" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlPreference ID="CtrlPreference1" runat="server" />
</asp:Content>
