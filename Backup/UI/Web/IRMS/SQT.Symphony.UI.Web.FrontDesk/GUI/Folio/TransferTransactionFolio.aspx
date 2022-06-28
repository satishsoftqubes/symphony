<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/Site.Master" CodeBehind="TransferTransactionFolio.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Folio.TransferTransactionFolio" %>
<%@ Register Src="~/UIControls/Folio/ctrlTransferTransactionFolio.ascx" TagName="ctrlTransferTransactionFolio"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="../../Scripts/jquery-1.4.2.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<uc1:ctrlTransferTransactionFolio ID="ucctrlTransferTransactionFolio" runat="server" />
</asp:Content>