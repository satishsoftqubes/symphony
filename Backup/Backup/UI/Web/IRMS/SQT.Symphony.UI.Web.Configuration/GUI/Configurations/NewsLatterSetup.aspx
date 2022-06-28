<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true" CodeBehind="NewsLatterSetup.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.Configurations.NewsLatterSetup" %>
<%@ Register src="~/UIControls/Configurations/CtrlNewsLatterSetup.ascx" tagname="CtrlNewsLatterSetup" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlNewsLatterSetup ID="CtrlNewsLatterSetupstup" runat="server" />
</asp:Content>
