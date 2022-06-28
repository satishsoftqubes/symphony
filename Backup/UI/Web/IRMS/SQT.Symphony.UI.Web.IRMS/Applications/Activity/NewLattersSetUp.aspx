<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewLattersSetUp.aspx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.Applications.Activity.NewLattersSetUp" %>
<%@ Register src="~/UIControls/Activity/NewsLatter.ascx" tagname="NewsLatter" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:NewsLatter ID="CtrlNewsLatter1" runat="server" />
</asp:Content>
