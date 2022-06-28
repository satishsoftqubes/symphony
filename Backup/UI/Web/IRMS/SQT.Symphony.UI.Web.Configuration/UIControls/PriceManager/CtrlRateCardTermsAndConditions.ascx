<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlRateCardTermsAndConditions.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.PriceManager.CtrlRateCardTermsAndConditions" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
    <asp:UpdatePanel ID="upnlRateCardTermsAndConditions" runat="server">
    <ContentTemplate>
<table width="100%">
    <tr>
        <td class="lblsameasth">
            <asp:Literal ID="litRateCardDetail" runat="server"></asp:Literal>
        </td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="txtDetails" runat="server" SkinID="nowidth" TextMode="MultiLine"
                Height="120px" Width="99.5%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="lblsameasth" style="padding-top: 10px;">
            <asp:Literal ID="litTermsAndConditions" runat="server"></asp:Literal>
        </td>
    </tr>
    <tr>
        <td>
            <CKEditor:CKEditorControl ID="edtrDetail" runat="server" ToolbarStartupExpanded="false"
                ResizeMaxWidth="450" Height="300">
            </CKEditor:CKEditorControl>
        </td>
    </tr>
</table>
</ContentTemplate>
</asp:UpdatePanel>
<asp:UpdateProgress AssociatedUpdatePanelID="upnlRateCardTermsAndConditions" ID="upgrsRateCardTermsAndConditions" runat="server">
    <ProgressTemplate>
        <div id="progressBackgroundFilter">
        </div>
        <div id="processMessage">
            <center>
                <img src="../../images/ajax-loader.gif" /></center>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
