<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true"  CodeBehind="ActionLog.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.Configurations.ActionLog" %>
<%@ Register src="../../UIControls/Configurations/CtrlActionLog.ascx" tagname="CtrlActionLog" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlActionLog ID="ucCtrlActionLog" runat="server" />
</asp:Content>
