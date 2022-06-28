<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlRateCardCheckInDays.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.PriceManager.CtrlRateCardCheckInDays" %>
<asp:UpdatePanel ID="upnlRateCardCheckInDays" runat="server">
    <ContentTemplate>
        <div style="padding-bottom: 5px;">
    <h1>
        <asp:Literal ID="litHeaderAllowRateCardOnCheckinDays" runat="server"></asp:Literal>
    </h1>
    <hr />
</div>
<div style="border: 1px solid Gray; padding: 5px;" class="checkbox_new">
    <asp:CheckBoxList ID="chkLstDays" runat="server" Width="100%" RepeatColumns="8" RepeatDirection="Horizontal">
    </asp:CheckBoxList>
</div>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdateProgress AssociatedUpdatePanelID="upnlRateCardCheckInDays" ID="upgrsRateCardCheckInDays"
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
