<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AmendmentList.aspx.cs"
    MasterPageFile="~/Master/Site.Master" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Reservation.AmendmentList" %>

<%@ Register Src="~/UIControls/Reservation/ctrlAmendmentList.ascx" TagName="CtrlAmendmentList"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="../../Scripts/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlAmendmentList ID="ucCtrlCtrlAmendmentList" runat="server" />
</asp:Content>
