<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanySetup.aspx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.Applications.SetUp.CompanySetup" %>

<%@ Register Src="~/UIControls/Configurations/CtrlCompanyInfo.ascx" TagName="CtrlCompanyInfo"
    TagPrefix="uc1" %>
<asp:content id="Content1" contentplaceholderid="head" runat="server">
</asp:content>
<asp:content id="Content2" contentplaceholderid="ContentPlaceHolder1" runat="server">
<script src="../../Javascript/jquery-1.4.1.min.js" type="text/javascript"></script>
<script src="../../Javascript/jquery.autocomplete.js" type="text/javascript"></script>
<link href="../../Javascript/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
    <uc1:CtrlCompanyInfo ID="CtrlCompanyInfo1" runat="server" />
</asp:content>
