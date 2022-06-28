<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="StayType.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.PriceManager.StayType" %>

<%@ Register Src="~/UIControls/PriceManager/CtrlStayType.ascx" TagName="CtrlStayType"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlStayType ID="ucStayType" runat="server" />
</asp:Content>
