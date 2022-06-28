<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RPTLocationAnalysis.aspx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.Applications.Reports.RPTLocationAnalysis" %>

<%@ Register src="~/UIControls/Reports/CtrlLocationAnalysis.ascx" tagname="CtrlLocationAnalysis" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlLocationAnalysis ID="ucLocationAnalysist" runat="server" />
</asp:Content>
