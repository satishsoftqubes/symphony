<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true"
    CodeBehind="SendEmailToInvestors.aspx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.Applications.Investors.SendEmailToInvestors" %>

<%@ Register Src="~/UIControls/InvestorSetUp/CtrlSendEmailToInvestors.ascx" TagName="CtrlSendEmailToInvestors"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Javascript/jquery-1.4.1.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlSendEmailToInvestors ID="CtrlSendEmailToInvestors1" runat="server" />
</asp:Content>
