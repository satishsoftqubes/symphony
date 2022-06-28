<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true" CodeBehind="POSConfiguration.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.Configurations.POSConfiguration" %>
<%@ Register src="~/UIControls/Configurations/CtrlPOSConfiguration.ascx" tagname="CtrlPOSConfiguration" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <uc1:CtrlPOSConfiguration ID="CtrlPOSConfiguration" runat="server" />
</asp:Content>
