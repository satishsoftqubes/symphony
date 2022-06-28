<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true" CodeBehind="AmendmentPolicy.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.Configurations.AmendmentPolicy" %>
<%@ Register src="../../UIControls/Configurations/ctrlAmendmentPolicy.ascx" tagname="ctrlAmendmentPolicy" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ctrlAmendmentPolicy ID="ctrlAmendmentPolicy1" runat="server" />
</asp:Content>
