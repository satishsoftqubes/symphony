<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true" CodeBehind="DenominationSetup.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.Configurations.DenominationSetup" %>
<%@ Register src="~/UIControls/Configurations/CtrlDenominationSetup.ascx" tagname="CtrlDenominationSetup" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlDenominationSetup ID="CtrlDenominationSetup1" runat="server" />
</asp:Content>
