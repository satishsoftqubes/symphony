<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/Site.Master"
    CodeBehind="ExtendStay.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Guest.ExtendStay" %>

<%@ Register Src="~/UIControls/CommonControls/CtrlCommonExtendReservation.ascx" TagName="ExtendReservation"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="updExtendStay" runat="server">
        <ContentTemplate>
            <uc1:ExtendReservation ID="ucCtrlExtendReservation" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress AssociatedUpdatePanelID="updExtendStay" ID="UpdateProgressExtendStay"
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
