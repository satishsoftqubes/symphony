<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="UserSetUp.aspx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.Applications.UsersSetUp.UserSetUp" %>
<%@ Register src="~/UIControls/UserSetUp/CtrlUsers.ascx" tagname="CtrlUsers" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManagerProxy ID="srcProxy" runat="server"></asp:ScriptManagerProxy>
    <script src="../../Javascript/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../../Javascript/jquery.autocomplete.js" type="text/javascript"></script>
    <link href="../../Javascript/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
    <uc1:CtrlUsers ID="CtrlUsersctrssss" runat="server" />
</asp:Content>
