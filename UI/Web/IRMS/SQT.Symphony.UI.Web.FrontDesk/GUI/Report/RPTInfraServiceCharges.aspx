<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="RPTInfraServiceCharges.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Report.RPTInfraServiceCharges" %>
<%@ Register src="~/UIControls/Report/InfraServiceCharges.ascx" tagname="CtrlInfraServiceCharges" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlInfraServiceCharges ID="ucInfraServiceCharges" runat="server" />
</asp:Content>
