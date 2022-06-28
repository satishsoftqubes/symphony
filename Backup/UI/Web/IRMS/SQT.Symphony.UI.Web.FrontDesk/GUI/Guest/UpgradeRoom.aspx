<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="UpgradeRoom.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Guest.UpgradeRoom" %>

<%@ Register Src="~/UIControls/CommonControls/CtrlCommonMoveUnitSetup.ascx" TagName="MoveUnitSetup"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="updChangeRoom" runat="server">
        <ContentTemplate>
            <uc1:MoveUnitSetup ID="ucCtrlMoveUnitSetup" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress AssociatedUpdatePanelID="updChangeRoom" ID="UpdateProgressChangeRoom"
        runat="server">
        <ProgressTemplate>
            <div id="progressBackgroundFilter">
            </div>
            <div id="processMessage">
                <center>
                    <img src="../../images/ajax-loader.gif" /></center>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
