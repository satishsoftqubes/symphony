<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true" CodeBehind="Deposits.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.Configurations.Deposits" %>
<%@ Register src="~/UIControls/Configurations/CtrlDeposits.ascx" tagname="CtrlDeposits" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlDeposits ID="CtrlDeposits1" runat="server" />
</asp:Content>
