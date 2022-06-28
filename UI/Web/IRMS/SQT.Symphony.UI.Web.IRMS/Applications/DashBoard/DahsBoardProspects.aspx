<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DahsBoardProspects.aspx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.Applications.DashBoard.DahsBoardProspects" %>

<%@ Register src="~/UIControls/DashBoard/CltrDahsBoardProspects .ascx" tagname="CltrDahsBoardProspects" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CltrDahsBoardProspects ID="CltrDahsBoardProspects1" runat="server" />
</asp:Content>