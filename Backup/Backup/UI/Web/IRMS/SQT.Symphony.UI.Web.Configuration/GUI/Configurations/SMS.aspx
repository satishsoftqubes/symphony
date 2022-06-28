<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true" CodeBehind="SMS.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.Configurations.SMS" %>
<%@ Register src="~/UIControls/Configurations/CtrlSMS.ascx" tagname="CtrlSMS" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlSMS ID="CtrlSMS1" runat="server" />
</asp:Content>
