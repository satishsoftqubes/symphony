<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="ControlNumberSetup.aspx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.Applications.SetUp.ControlNumberSetup" %>
<%@ Register src="~/UIControls/Configurations/CtrlControlNumber.ascx" tagname="CtrlControlNumber" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlControlNumber ID="CtrlControlNumberctrl" runat="server" />
</asp:Content>
