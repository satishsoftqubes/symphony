<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/admin.Master" CodeBehind="CompanyList.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.Configurations.CompanyList" %>
<%@ Register src="~/UIControls/Property/CtrlCompanyList.ascx" tagname="CtrlCompanyList" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlCompanyList ID="ucCtrlCompanyList" runat="server" />
</asp:Content>

