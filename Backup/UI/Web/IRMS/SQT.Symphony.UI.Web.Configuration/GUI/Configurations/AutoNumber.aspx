<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true" CodeBehind="AutoNumber.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.Configurations.AutoNumber" %>
<%@ Register src="~/UIControls/Configurations/CtrlAutoNo.ascx" tagname="CtrlAutoNumber" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlAutoNumber ID="CtrlAutoNumberaa" runat="server" />
</asp:Content>
