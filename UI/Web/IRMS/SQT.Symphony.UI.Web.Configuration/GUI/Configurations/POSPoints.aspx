<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true" CodeBehind="POSPoints.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.Configurations.POSPoints" %>
<%@ Register src="~/UIControls/Configurations/CtrlPOSPoints.ascx" tagname="CtrlPOSPoints" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlPOSPoints ID="CtrlPOSPoints1" runat="server" />
</asp:Content>
