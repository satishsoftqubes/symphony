<%@ Page Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true" CodeBehind="CompanyConfiguration.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.Property.CompanyConfiguration" %>
<%@ Register src="~/UIControls/Property/CtrlCompanyConfiguration.ascx" tagname="CtrlCompanyConfiguration" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlCompanyConfiguration ID="CtrlCompanyConfiguration1" runat="server" />
</asp:Content>
