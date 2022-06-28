<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true" CodeBehind="HouseKeeping.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.Configurations.HouseKeeping" %>
<%@ Register src="~/UIControls/Configurations/CtrlHouseKeeping.ascx" tagname="CtrlHouseKeeping" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlHouseKeeping ID="CtrlHouseKeepingStup" runat="server" />
</asp:Content>
