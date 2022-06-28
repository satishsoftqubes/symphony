<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="BlockDetail.aspx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.Applications.SetUp.BlockDetail" %>
<%@ Register src="~/UIControls/Configurations/BlockDetail.ascx" tagname="BlockDetail" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:BlockDetail ID="ucBlockDetail" runat="server" />
</asp:Content>
