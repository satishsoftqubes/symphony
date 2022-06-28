<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="InquiryList.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Guest.InquiryList" %>
<%@ Register src="../../UIControls/Guest/CtrlInquiryList.ascx" tagname="CtrlInquiryList" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlInquiryList ID="CtrlInquiryList1" runat="server" />
</asp:Content>