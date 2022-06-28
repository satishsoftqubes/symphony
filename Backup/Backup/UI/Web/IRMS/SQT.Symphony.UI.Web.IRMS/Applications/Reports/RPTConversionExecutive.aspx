<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RPTConversionExecutive.aspx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.Applications.Reports.RPTConversionExecutive" %>


<%@ Register src="~/UIControls/Reports/CtrlConversionExecutives.ascx" tagname="CtrlConversionExecutives" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlConversionExecutives ID="ucConversionExecutives" runat="server" />
</asp:Content>

