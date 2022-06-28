<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogInLog.aspx.cs" MasterPageFile="~/Master/admin.Master" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.Configurations.LogInLog" %>
<%@ Register src="~/UIControls/Configurations/CtrlLoginLog.ascx" tagname="CtrlLoginLog" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlLoginLog ID="CtrlLoginLog1" runat="server" />
</asp:Content>
