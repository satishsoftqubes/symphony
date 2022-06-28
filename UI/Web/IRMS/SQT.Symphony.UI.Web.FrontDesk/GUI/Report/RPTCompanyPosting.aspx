<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="RPTCompanyPosting.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Report.RPTCompanyPosting" %>
<%@ Register src="~/UIControls/Report/CtrlCompanyPosting.ascx" tagname="CtrlCompanyPosting" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlCompanyPosting ID="ucCtrlCompanyPosting" runat="server" />
</asp:Content>
