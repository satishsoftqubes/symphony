<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="RPTYeildCalculation.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Report.RPTYeildCalculation" %>
<%@ Register src="~/UIControls/Report/YeildCalculation.ascx" tagname="YeildCalculation" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
    <uc1:YeildCalculation ID="ucYeildCalculation" runat="server" />
</asp:Content>

