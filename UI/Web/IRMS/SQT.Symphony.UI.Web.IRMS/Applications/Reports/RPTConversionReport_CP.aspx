<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RPTConversionReport_CP.aspx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.Applications.Reports.RPTConversionReport_CP" %>

<%@ Register src="~/UIControls/Reports/CtrlConversionExecutive_CP.ascx" tagname="CtrlConversionExecutive_CP" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlConversionExecutive_CP ID="ucConversionExecutive_CP" runat="server" />
</asp:Content>
