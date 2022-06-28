<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="RPTRetentionCharges.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Report.RPTRetentionCharges" %>
<%@ Register src="~/UIControls/Report/CtrlRetentionCharges.ascx" tagname="CtrlRetentionCharges" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlRetentionCharges ID="ucCtrlCancellationCharges" runat="server" />
</asp:Content>
