<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PropertyInformation.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.Property.PropertyInformation" %>
<%@ Register Src="~/UIControls/Property/CtrlPropertyInfomation.ascx" TagName="CtrlPropertyInfomation"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<uc1:CtrlPropertyInfomation ID="ucCtrlPropertyInfomation" runat="server" />
</asp:Content>