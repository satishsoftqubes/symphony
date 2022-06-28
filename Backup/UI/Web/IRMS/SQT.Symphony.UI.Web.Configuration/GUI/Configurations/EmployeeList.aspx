<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true"
    CodeBehind="EmployeeList.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.Configurations.EmployeeList" %>

<%@ Register Src="../../UIControls/Configurations/CtrlEmployeeList.ascx" TagName="CtrlEmployeeList"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Javascript/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../../Javascript/jquery.autocomplete.js" type="text/javascript"></script>
    <link href="../../Javascript/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ctrlemployeelist id="CtrlEmployeeList1" runat="server" />
</asp:Content>
