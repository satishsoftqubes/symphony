<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/admin.Master" CodeBehind="Account.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.Configurations.Account" %>

<%@ Register src="~/UIControls/Configurations/CtrlAccount.ascx" tagname="CtrlAccount" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlAccount ID="ucCtrlAccount" runat="server" />
</asp:Content>
