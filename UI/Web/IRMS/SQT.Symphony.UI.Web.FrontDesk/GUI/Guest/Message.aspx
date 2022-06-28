<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/Site.Master"
    CodeBehind="Message.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Guest.Message" %>

<%@ Register Src="~/UIControls/CommonControls/CtrlCommonMessage.ascx" TagName="Message"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="updMessage" runat="server">
        <ContentTemplate>
            <uc1:Message ID="ucCtrlMessage" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress AssociatedUpdatePanelID="updMessage" ID="UpdateProgressMessage"
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
