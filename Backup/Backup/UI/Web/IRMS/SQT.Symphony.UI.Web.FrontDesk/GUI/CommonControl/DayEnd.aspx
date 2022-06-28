<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/Site.Master" CodeBehind="DayEnd.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.CommonControl.DayEnd" %>

<%@ Register Src="~/UIControls/CommonControls/ctrlCommonDayEnd.ascx" TagName="DayEnd"
    TagPrefix="ucCtrlDayEnd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ucCtrlDayEnd:DayEnd ID="ctrlDayEnd" runat="server" />
</asp:Content>