<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true" CodeBehind="Recovery.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.Configurations.Recovery" %>
<%@ Register src="../../UIControls/Configurations/CtrlRecovery.ascx" tagname="CtrlRecovery" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlRecovery ID="CtrlRecovery1" runat="server" />
</asp:Content>
