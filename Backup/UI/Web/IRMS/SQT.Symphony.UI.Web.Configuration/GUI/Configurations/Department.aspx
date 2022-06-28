<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Department.aspx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.GUI.Configurations.Department" %>

<%@ Register Src="~/UIControls/Configurations/CtrlDepartment.ascx" TagName="CtrlDepartment"
    TagPrefix="uc1" %>
<asp:content id="Content1" contentplaceholderid="head" runat="server">
</asp:content>
<asp:content id="Content2" contentplaceholderid="ContentPlaceHolder1" runat="server">
    <uc1:CtrlDepartment ID="ucCtrlDepartment" runat="server" />
</asp:content>
