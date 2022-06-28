<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true" CodeBehind="Item.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.Inventory.Item" %>

<%@ Register src="~/UIControls/Inventory/CtrlItem.ascx" tagname="CtrlItem" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
    <uc1:CtrlItem ID="ucCtrlItem" runat="server" />
</asp:Content>
