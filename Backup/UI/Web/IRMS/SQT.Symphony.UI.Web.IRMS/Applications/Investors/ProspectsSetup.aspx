<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="ProspectsSetup.aspx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.Applications.Investors.ProspectsSetup" %>
<%@ Register src="~/UIControls/InvestorSetUp/CtrlProspects.ascx" tagname="CtrlProspects" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script src="../../Javascript/jquery-1.4.1.min.js" type="text/javascript"></script>
<script src="../../Javascript/jquery.autocomplete.js" type="text/javascript"></script>
<link href="../../Javascript/jquery.autocomplete.css" rel="stylesheet" type="text/css" />

    <uc1:CtrlProspects ID="CtrlProspects1" runat="server" />
</asp:Content>
