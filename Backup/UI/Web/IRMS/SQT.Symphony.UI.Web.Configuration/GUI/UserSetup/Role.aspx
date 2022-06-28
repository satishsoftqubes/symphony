<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Role.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.UserSetup.Role" %>

<%@ Register Src="~/UIControls/UserSetup/CtrlRoles.ascx" TagName="CtrlRolesSetup"
    TagPrefix="uc1" %>
<asp:content id="Content1" contentplaceholderid="head" runat="server">
</asp:content>
<asp:content id="Content2" contentplaceholderid="ContentPlaceHolder1" runat="server">
<uc1:CtrlRolesSetup ID="ucRoleSetup" runat="server" />
</asp:content>
