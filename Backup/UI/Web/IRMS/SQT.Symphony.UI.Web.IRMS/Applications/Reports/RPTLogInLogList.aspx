<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RPTLogInLogList.aspx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.Applications.Reports.RPTLogInLogList" %>

<%@ Register src="~/UIControls/Reports/CtrlLogInLogList.ascx" tagname="CtrlRPTLogInLogList" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlRPTLogInLogList ID="ucLogInLogList" runat="server" />
</asp:Content>