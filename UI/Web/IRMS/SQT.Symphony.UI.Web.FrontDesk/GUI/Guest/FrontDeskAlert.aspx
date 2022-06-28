<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="FrontDeskAlert.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Guest.FrontDeskAlert" %>
<%@ Register src="../../UIControls/CommonControls/CtrlCommonFrontDeskAlert.ascx" tagname="CtrlCommonFrontDeskAlert" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlCommonFrontDeskAlert ID="CtrlCommonFrontDeskAlert1" runat="server" />
</asp:Content>
