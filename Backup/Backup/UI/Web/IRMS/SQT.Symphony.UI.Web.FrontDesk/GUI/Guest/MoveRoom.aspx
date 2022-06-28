<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true"
    CodeBehind="MoveRoom.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Guest.MoveRoom" %>

<%@ Register Src="../../UIControls/Guest/CtrlMoveRoom.ascx" TagName="CtrlMoveRoom" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlMoveRoom ID="CtrlMoveRoom1" runat="server" />
</asp:Content>
