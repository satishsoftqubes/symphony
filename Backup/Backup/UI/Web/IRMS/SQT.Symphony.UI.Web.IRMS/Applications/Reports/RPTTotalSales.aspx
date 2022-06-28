<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RPTTotalSales.aspx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.Applications.Reports.RPTTotalSales" %>


<%@ Register src="~/UIControls/Reports/CtrlTotalSales.ascx" tagname="CtrlRPTTotalSales" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlRPTTotalSales ID="ucTotalSalses" runat="server" />
</asp:Content>
