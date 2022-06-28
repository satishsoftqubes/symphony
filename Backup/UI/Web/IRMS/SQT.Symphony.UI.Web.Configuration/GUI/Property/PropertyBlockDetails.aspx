<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PropertyBlockDetails.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.Property.PropertyBlockDetails" %>
<%@ Register Src="~/UIControls/Property/CtrlPropertyBlockInformation.ascx" TagName="CtrlPropertyBlockInformation"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<uc1:CtrlPropertyBlockInformation ID="ucCtrlPropertyBlockInformation" runat="server" />
</asp:Content>
