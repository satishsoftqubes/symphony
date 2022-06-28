<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RPTConversionReport_RefThrough.aspx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.Applications.Reports.RPTConversionReport_RefThrough" %>


<%@ Register src="~/UIControls/Reports/CtrlConversionReport_RefThrough.ascx" tagname="CtrlConversionReport_RefThrough" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlConversionReport_RefThrough ID="ucConversionReport_RefThrough" runat="server" />
</asp:Content>
