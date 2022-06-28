<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true" ValidateRequest="false"
    CodeBehind="PropertyConfiguration.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.Property.PropertyConfiguration" %>

<%@ Register Src="~/UIControls/Property/CtrlCompanyConfiguration.ascx" TagName="CtrlCompanyConfiguration"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlCompanyConfiguration ID="CtrlCompanyConfiguration1" runat="server" />
</asp:Content>
