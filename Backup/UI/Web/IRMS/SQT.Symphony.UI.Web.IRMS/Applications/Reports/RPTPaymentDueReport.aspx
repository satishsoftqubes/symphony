<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RPTPaymentDueReport.aspx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.Applications.Reports.RPTPaymentDueReport" %>


<%@ Register src="~/UIControls/Reports/CtrlPaymentDueReport.ascx" tagname="CtrlRPTPaymentDue" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlRPTPaymentDue ID="ucPaymentDue" runat="server" />
</asp:Content>

