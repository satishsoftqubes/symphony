<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true"
    CodeBehind="AssignRoom.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Reservation.AssignRoom" %>

<%@ Register Src="~/UIControls/Reservation/ctrlAssignRoom.ascx" TagName="ctrlAssignRoom"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ctrlAssignRoom ID="ucAssignRoom" runat="server" />
</asp:Content>
