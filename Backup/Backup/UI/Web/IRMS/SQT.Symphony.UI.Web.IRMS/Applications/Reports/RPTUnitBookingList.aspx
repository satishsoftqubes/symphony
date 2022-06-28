<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RPTUnitBookingList.aspx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.Applications.Reports.RPTUnitBookingList" %>
<%@ Register src="~/UIControls/Reports/CtrlUnitBookingList.ascx" tagname="CtrlRPTUnitBookingList" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlRPTUnitBookingList ID="ucUnitBookingList" runat="server" />
</asp:Content>