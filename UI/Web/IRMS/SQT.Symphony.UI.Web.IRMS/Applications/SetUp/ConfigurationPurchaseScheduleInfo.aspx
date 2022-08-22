<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true"
    CodeBehind="ConfigurationPurchaseScheduleInfo.aspx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.Applications.SetUp.ConfigurationPurchaseScheduleInfo" %>

<%@ Register Src="~/UIControls/Configurations/CtrlPurchaseScheduleConfigurationInformation.ascx" tagName="CtrlPurchaseScheduleConfigurationInformation" tagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../Javascript/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../../Javascript/jquery.autocomplete.js" type="text/javascript"></script>
    <link href="../../Javascript/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
    <uc1:CtrlPurchaseScheduleConfigurationInformation ID="CtrlPropertyConfigurationInformation1"
        runat="server" />
</asp:Content>
