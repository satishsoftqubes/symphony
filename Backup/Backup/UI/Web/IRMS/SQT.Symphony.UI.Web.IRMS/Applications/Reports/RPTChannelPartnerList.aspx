<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RPTChannelPartnerList.aspx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.Applications.Reports.RPTChannelPartnerList" %>

<%@ Register src="~/UIControls/Reports/CtrlChannelPartnerList.ascx" tagname="CtrlRPTChannelPartnerList" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlRPTChannelPartnerList ID="ucChannelPartnerList" runat="server" />
</asp:Content>
