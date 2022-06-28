<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="RPTCancellationCharges.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Report.RPTCancellationCharges" %>
<%@ Register src="~/UIControls/Report/CtrlCancellationCharges.ascx" tagname="CtrlCancellationCharges" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlCancellationCharges ID="ucCtrlCancellationCharges" runat="server" />
</asp:Content>

