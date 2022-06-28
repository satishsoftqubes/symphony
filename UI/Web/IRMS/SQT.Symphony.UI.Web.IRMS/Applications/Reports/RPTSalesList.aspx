<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RPTSalesList.aspx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.Applications.Reports.RPTSalesList" %>

<%@ Register src="~/UIControls/Reports/CtrlSalesList.ascx" tagname="CtrlRPTSalesList" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlRPTSalesList ID="ucSalesList" runat="server" />
</asp:Content>