<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true" CodeBehind="UnitOfMeasure.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.Configurations.UnitOfMeasure" %>
<%@ Register src="~/UIControls/Configurations/CtrlUnitOfMeasure.ascx" tagname="CtrlUnitOfMeasure" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlUnitOfMeasure ID="CtrlUnitOfMeasure1" runat="server" />
</asp:Content>
