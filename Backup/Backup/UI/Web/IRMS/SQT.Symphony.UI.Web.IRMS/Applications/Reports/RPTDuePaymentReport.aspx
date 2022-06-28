<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true" CodeBehind="RPTDuePaymentReport.aspx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.Applications.Reports.RPTDuePaymentReport" %>
<%@ Register src="~/UIControls/Reports/CtrlPaymentAlertsList.ascx" tagname="CtrlRPTPaymentAlertsList" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<uc1:CtrlRPTPaymentAlertsList ID="ucPaymentAlertsList" runat="server" />
</asp:Content>
