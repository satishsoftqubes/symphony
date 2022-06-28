<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCommonFolioPostCharge.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Folio.CtrlCommonFolioPostCharge" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<ajx:ModalPopupExtender ID="mpeOpenPostCharge" runat="server" TargetControlID="hdnOpenPostCharge"
    PopupControlID="pnlOpenPostCharge" BackgroundCssClass="mod_background" CancelControlID="iBtnCacelPostChargePopup">
</ajx:ModalPopupExtender>
<asp:HiddenField ID="hdnOpenPostCharge" runat="server" />
<asp:Panel ID="pnlOpenPostCharge" runat="server" Width="450px" Style="display: none;">
    <div class="box_col1">
        <div class="box_head">
            <div style="display: inline;">
                <span>
                    <asp:Literal ID="litOpnPostChargeHeader" runat="server" Text="Post Charge"></asp:Literal></span></div>
            <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                <asp:ImageButton ID="iBtnCacelPostChargePopup" runat="server" ImageUrl="~/images/closepopup.png"
                    Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;" />
            </div>
        </div>
        <div class="clear">
        </div>
        <div class="box_form">
            <table cellpadding="2" cellspacing="2" width="100%">
                <tr>
                    <td width="80" class="isrequire">
                        Amount
                    </td>
                    <td>
                        <asp:TextBox ID="txtPostChargeAmount" runat="server" MaxLength="18"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPostChargeAmount" SetFocusOnError="true" CssClass="input-notification error png_bg"
                            runat="server" ValidationGroup="FolioPostCharge" ControlToValidate="txtPostChargeAmount"
                            Display="Dynamic">
                        </asp:RequiredFieldValidator>
                        <ajx:FilteredTextBoxExtender ID="fttxtPostChargeAmount" runat="server" TargetControlID="txtPostChargeAmount"
                            FilterType="Custom" ValidChars="0123456789." />
                        <asp:RegularExpressionValidator Display="Dynamic" ID="revtxtPostChargeAmount" runat="server"
                            ForeColor="Red" ControlToValidate="txtPostChargeAmount" SetFocusOnError="true"
                            ValidationGroup="FolioPostCharge">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="isrequire">
                        Ledger Account
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlPostChargeLedger" runat="server">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvPostChargeLedger" InitialValue="00000000-0000-0000-0000-000000000000"
                            SetFocusOnError="True" CssClass="input-notification error png_bg" runat="server"
                            ValidationGroup="FolioPostCharge" ControlToValidate="ddlPostChargeLedger" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="isrequire" valign="top">
                        Reason
                    </td>
                    <td>
                        <asp:TextBox ID="txtPostChargeNote" runat="server" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPostChargeNote" SetFocusOnError="true" CssClass="input-notification error png_bg"
                            runat="server" ValidationGroup="FolioPostCharge" ControlToValidate="txtPostChargeNote"
                            Display="Dynamic">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:Button ID="btnOpenPostCharge" runat="server" Style="display: inline; padding-right: 10px;"
                            Text="Post" OnClick="btnOpenPostCharge_Click" ValidationGroup="FolioPostCharge" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
        <div class="clear">
        </div>
    </div>
</asp:Panel>
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
