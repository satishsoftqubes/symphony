<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true"
    CodeBehind="InfraCharges.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Billing.InfraCharges" %>

<%@ Register Src="~/UIControls/Billing/CtrlInfraCharges.ascx" TagName="CtrlInfraCharges"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlInfraCharges ID="ucCtrlInfraCharges" runat="server" />
</asp:Content>
