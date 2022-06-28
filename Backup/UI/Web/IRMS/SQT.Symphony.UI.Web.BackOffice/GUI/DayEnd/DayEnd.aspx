<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true" CodeBehind="DayEnd.aspx.cs" Inherits="SQT.Symphony.UI.Web.BackOffice.GUI.DayEnd.DayEnd" %>
<%@ Register src="../../UIControls/DayEnd/CtrlDayEnd.ascx" tagname="CtrlDayEnd" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlDayEnd ID="CtrlDayEnd1" runat="server" />
</asp:Content>
