<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PropertyList.aspx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.Applications.SetUp.PropertyList" %>
<%@ Register src="~/UIControls/Configurations/CtrlPropertyList.ascx" tagname="CtrlPropertyList" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script src="../../Javascript/jquery-1.4.1.min.js" type="text/javascript"></script>
<script src="../../Javascript/jquery.autocomplete.js" type="text/javascript"></script>
<link href="../../Javascript/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
    <uc1:CtrlPropertyList ID="CtrlPropertyList1" runat="server" />
</asp:Content>
