<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true" CodeBehind="EmailTempaltes.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.Configurations.EmailTempaltes" %>
<%@ Register src="~/UIControls/Configurations/CtrlEmailTemplate.ascx" tagname="CtrlEmailTemplate" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlEmailTemplate ID="CtrlEmailTemplatestuyp" runat="server" />
</asp:Content>
