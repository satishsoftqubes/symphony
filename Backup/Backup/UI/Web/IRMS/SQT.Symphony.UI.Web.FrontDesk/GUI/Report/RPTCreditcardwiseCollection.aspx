<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="RPTCreditcardwiseCollection.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Report.RPTCreditcardwiseCollection" %>
<%@ Register src="~/UIControls/Report/CtrlCreditcardwisecollectionReport.ascx" tagname="CtrlCreditcardwisecollectionReport" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlCreditcardwisecollectionReport ID="ucCtrlCreditcardwisecollectionReport" runat="server" />
</asp:Content>

