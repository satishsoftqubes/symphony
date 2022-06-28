﻿<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="PropertySetup.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.Property.PropertySetup" %>
<%@ Register Src="~/UIControls/Property/CtrlPropertySetup.ascx" TagName="CtrlPropertySetup"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="../../Javascript/jquery-1.4.1.min.js" type="text/javascript"></script>
<script src="../../Javascript/jquery.autocomplete.js" type="text/javascript"></script>
<link href="../../Javascript/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<uc1:CtrlPropertySetup ID="ucCtrlPropertySetup" runat="server" />
</asp:Content>