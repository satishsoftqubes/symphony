<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DashBoardInvestors.aspx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.Applications.DashBoard.DashBoardInvestors" %>

<%@ Register src="~/UIControls/DashBoard/CltrDashBoardInvestors .ascx" tagname="CltrDashBoardInvestors" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CltrDashBoardInvestors ID="CltrDashBoardInvestors1" runat="server" />
</asp:Content>