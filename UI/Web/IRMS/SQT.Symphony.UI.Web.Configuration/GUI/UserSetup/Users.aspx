<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.Configurations.Users" %>
<%@ Register src="../../UIControls/UserSetup/CtrlUsers.ascx" tagname="CtrlUsers" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlUsers ID="CtrlUsers1" runat="server" />
</asp:Content>
