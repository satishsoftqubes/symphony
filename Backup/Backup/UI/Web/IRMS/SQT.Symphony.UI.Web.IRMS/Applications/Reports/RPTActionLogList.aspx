<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RPTActionLogList.aspx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.Applications.Reports.RPTActionLogList" %>


<%@ Register src="~/UIControls/Reports/CtrlActionLogList.ascx" tagname="CtrlRPTActionLogList" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlRPTActionLogList ID="ucActionLogList" runat="server" />
</asp:Content>
