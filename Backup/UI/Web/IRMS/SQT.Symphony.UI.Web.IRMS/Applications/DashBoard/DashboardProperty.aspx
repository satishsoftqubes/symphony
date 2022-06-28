<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DashboardProperty.aspx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.Applications.DashBoard.DashboardProperty" %>

<%@ Register src="~/UIControls/DashBoard/CltrDashboardProperty.ascx" tagname="CltrDashboardProperty" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CltrDashboardProperty ID="CltrDashboardProperty1" runat="server" />
</asp:Content>