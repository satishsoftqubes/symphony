<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCommonVoidTransaction.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls.CtrlCommonVoidTransaction" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<ajx:ModalPopupExtender ID="mpeVoidTransaction" runat="server" TargetControlID="hdnVoidTransaction"
    PopupControlID="pnlVoidTransaction" BackgroundCssClass="mod_background" CancelControlID="btnVoidTransactionCancel">
</ajx:ModalPopupExtender>
<asp:HiddenField ID="hdnVoidTransaction" runat="server" />
<asp:Panel ID="pnlVoidTransaction" runat="server" Width="500px" Style="display: none;">
    <div class="box_col1">
        <div class="box_head">
            <span>
                <asp:Literal ID="litHdrVoidReason" runat="server" Text="Void Reason"></asp:Literal></span></div>
        <div class="clear">
        </div>
        <div class="box_form">
            <table cellpadding="2" cellspacing="2" border="0" width="100%">
                <tr>
                    <td>
                        Enter the Void Reason for this Transaction...
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtVoidReason" runat="server" TextMode="MultiLine" Style="width: 400px;
                            height: 150px;"></asp:TextBox>
                        <span>
                            <asp:RequiredFieldValidator ID="rfvVoidReason" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                runat="server" ValidationGroup="VoidTransaction" ControlToValidate="txtVoidReason">
                            </asp:RequiredFieldValidator>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btnVoidTransactionSave" runat="server" Text="Save" Style="display: inline;"
                            ValidationGroup="VoidTransaction" OnClick="btnVoidTransactionSave_Click" />
                        <asp:Button ID="btnVoidTransactionCancel" runat="server" Text="Cancel" Style="display: inline;" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="clear">
        </div>
    </div>
</asp:Panel>
<ajx:ModalPopupExtender ID="mpeVoidTransactionErrMsg" runat="server" TargetControlID="hdnVoidTransactionErrMsg"
    PopupControlID="pnlVoidTransactionErrMsg" BackgroundCssClass="mod_background" CancelControlID="btnVoidTransactionErrMsgOK">
</ajx:ModalPopupExtender>
<asp:HiddenField ID="hdnVoidTransactionErrMsg" runat="server" />
<asp:Panel ID="pnlVoidTransactionErrMsg" runat="server" Height="350px" Width="325px"
    Style="display: none;">
    <div class="box_col1">
        <div class="box_head">
            <span>
                <asp:Literal ID="Literal1" runat="server" Text="Message"></asp:Literal></span></div>
        <div class="clear">
        </div>
        <div class="box_form">
            <table cellpadding="2" cellspacing="2" width="100%">
                <tr>
                    <td align="center" style="padding-bottom: 15px;">                        
                        <asp:Label ID="Label1" runat="server" Text="You cant' void this transaction."></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btnVoidTransactionErrMsgOK" runat="server" Style="display: inline; padding-right: 10px;"
                            Text="Ok" />
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
