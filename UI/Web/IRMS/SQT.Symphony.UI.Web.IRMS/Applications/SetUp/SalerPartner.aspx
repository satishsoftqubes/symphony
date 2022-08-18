<%@ Page Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true" CodeBehind="SalerPartner.aspx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.Applications.SetUp.SalerPartner" %>

<%@ Register Src="~/UIControls/Configurations/CtrlSalerPartner.ascx" TagName="CtrlSalerPartner" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../Javascript/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../../Javascript/jquery.autocomplete.js" type="text/javascript"></script>
    <link href="../../Javascript/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
    <uc1:CtrlSalerPartner ID="CtrlSalerPartner1" runat="server" />
</asp:Content>

