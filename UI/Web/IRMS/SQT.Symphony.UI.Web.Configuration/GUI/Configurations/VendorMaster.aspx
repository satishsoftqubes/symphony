<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true" CodeBehind="VendorMaster.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.Configurations.VendorMaster" %>
<%@ Register src="../../UIControls/Configurations/CtrlVendorMaster.ascx" tagname="CtrlVendorMaster" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlVendorMaster ID="CtrlVendorMaster1" runat="server" />
</asp:Content>
