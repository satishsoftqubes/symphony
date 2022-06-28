<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCommonPostCredit.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Folio.CtrlCommonPostCredit" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<ajx:ModalPopupExtender ID="mpeOpenPostCredit" runat="server" TargetControlID="hdnOpenPostCredit"
    PopupControlID="pnlOpenPostCredit" BackgroundCssClass="mod_background" CancelControlID="iBtnCacelPostCreditPopup">
</ajx:ModalPopupExtender>
<asp:HiddenField ID="hdnOpenPostCredit" runat="server" />
<asp:Panel ID="pnlOpenPostCredit" runat="server" Width="450px" Style="display: none;">
    <div class="box_col1">
        <div class="box_head">
            <div style="display: inline;">
                <span>
                    <asp:Literal ID="litOpnPostCreditHeader" runat="server" Text="Post Credit"></asp:Literal></span></div>
            <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                <asp:ImageButton ID="iBtnCacelPostCreditPopup" runat="server" ImageUrl="~/images/closepopup.png"
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
                        <asp:TextBox ID="txtPostCreditAmount" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPostCreditAmount" SetFocusOnError="true" CssClass="input-notification error png_bg"
                            runat="server" ValidationGroup="FolioPostCredit" ControlToValidate="txtPostCreditAmount"
                            Display="Dynamic">
                        </asp:RequiredFieldValidator>
                        <ajx:FilteredTextBoxExtender ID="ftPostCreditAmount" runat="server" TargetControlID="txtPostCreditAmount"
                            FilterType="Custom" ValidChars="0123456789." />
                        <asp:RegularExpressionValidator Display="Dynamic" ID="revPostCreditAmount" runat="server"
                            ForeColor="Red" ControlToValidate="txtPostCreditAmount" SetFocusOnError="true"
                            ValidationGroup="FolioPostCredit">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="isrequire" valign="top">
                        Ledger Account
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlPostCreditLedger" runat="server">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvPostCreditLedger" InitialValue="00000000-0000-0000-0000-000000000000"
                            SetFocusOnError="True" CssClass="input-notification error png_bg" runat="server"
                            ValidationGroup="FolioPostCredit" ControlToValidate="ddlPostCreditLedger" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="isrequire">
                        Reason
                    </td>
                    <td>
                        <asp:TextBox ID="txtPostCreditNote" runat="server" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPostCreditNote" SetFocusOnError="true" CssClass="input-notification error png_bg"
                            runat="server" ValidationGroup="FolioPostCredit" ControlToValidate="txtPostCreditNote"
                            Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:Button ID="btnOpenPostCredit" runat="server" Style="display: inline; padding-right: 10px;"
                            Text="Post" OnClick="btnOpenPostCredit_Click" ValidationGroup="FolioPostCredit" />
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
