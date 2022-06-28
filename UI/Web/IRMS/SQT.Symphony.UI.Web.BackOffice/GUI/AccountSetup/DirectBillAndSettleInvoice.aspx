<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DirectBillAndSettleInvoice.aspx.cs"
    Inherits="SQT.Symphony.UI.Web.BackOffice.GUI.AccountSetup.DirectBillAndSettleInvoice"
    MasterPageFile="~/Master/admin.Master" %>

<%@ Register Src="~/UIControls/AccountSetup/CtrlDirectBillAndSettleInvoice.ascx"
    TagName="DirectBillAndSettleInvoice" TagPrefix="ucDirectBillAndSettleInvoice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ucDirectBillAndSettleInvoice:DirectBillAndSettleInvoice ID="CtrlDirectBillAndSettleInvoice1"
        runat="server" />
</asp:Content>
