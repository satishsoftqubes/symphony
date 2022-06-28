<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="AddServices.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Guest.AddServices" %>
<%@ Register Src="~/UIControls/Guest/CtrlAddServices.ascx" TagName="CtrlAddServices" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<uc1:CtrlAddServices ID="CtrlAddServices" runat="server" />
</asp:Content>
