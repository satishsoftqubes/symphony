<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true" CodeBehind="Transcript.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Guest.Transcript" %>
<%@ Register src="~/UIControls/Configurations/CtrlTranscript.ascx" tagname="CtrlTranscript" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <uc1:CtrlTranscript ID="CtrlTranscript1" runat="server" />
    
</asp:Content>
