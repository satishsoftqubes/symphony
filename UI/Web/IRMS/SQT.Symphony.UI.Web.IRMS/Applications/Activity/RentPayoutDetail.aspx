<%@ Page Title="" Language="C#" MasterPageFile="~/Master/investor.Master" AutoEventWireup="true" CodeBehind="RentPayoutDetail.aspx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.Applications.Activity.RentPayoutDetail" %>
<%@ Register src="../../UIControls/Activity/CtrlRentPayoutDetail.ascx" tagname="CtrlRentPayoutDetail" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlRentPayoutDetail ID="CtrlRentPayoutDetail1" runat="server" />
</asp:Content>
