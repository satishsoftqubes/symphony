<%@ Language="C#" AutoEventWireup="true" CodeBehind="AmenitiesSetup.aspx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.GUI.Configurations.AmenitiesSetup" %>

<%@ Register Src="~/UIControls/Configurations/CtrlAmenitiesSetup.ascx" TagName="CtrlAmenitiesSetup"
    TagPrefix="uc1" %>
<asp:content id="Content1" contentplaceholderid="head" runat="server">
    <script src="../../Javascript/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../../Javascript/jquery.autocomplete.js" type="text/javascript"></script>
    <link href="../../Javascript/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
</asp:content>
<asp:content id="Content2" contentplaceholderid="ContentPlaceHolder1" runat="server">
<uc1:CtrlAmenitiesSetup ID="ucAmenitiesSetup" runat="server" />
</asp:content>
