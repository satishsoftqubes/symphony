<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true"
    CodeBehind="RPTCompanyPosting.aspx.cs" Inherits="SQT.Symphony.UI.Web.BackOffice.GUI.Invoice.RPTCompanyPosting" %>

<%@ Register Src="../../UIControls/Invoice/CtrlRPTCompanyPosting.ascx" TagName="CtrlRPTCompanyPosting"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlRPTCompanyPosting ID="ucCtrlRPTCompanyPosting" runat="server" />
</asp:Content>
