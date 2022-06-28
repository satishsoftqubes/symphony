<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCommonFolioTransactionDetails.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls.CtrlCommonFolioTransactionDetails" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript" language="javascript">
    function fnRequireValidationForCheckBox() {        
        var chkChangeDescription = document.getElementById("<%=chkChangeDescription.ClientID %>");
        var rfvChangeDescription = document.getElementById("<%=rfvChangeDescription.ClientID %>");
        var txtChangeDescription = document.getElementById("<%=txtChangeDescription.ClientID %>");

        if (chkChangeDescription.checked) {            
            txtChangeDescription.disabled = false;
            ValidatorEnable(rfvChangeDescription, true);
        }
        else {            
            txtChangeDescription.disabled = true;
            txtChangeDescription.value = "";
            ValidatorEnable(rfvChangeDescription, false);
        }
    }
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<ajx:ModalPopupExtender ID="mpeTransactionDetail" runat="server" TargetControlID="hdnTransactionDetail"
    PopupControlID="pnlTransactionDetail" BackgroundCssClass="mod_background" CancelControlID="btnTransactionDetailCancel">
</ajx:ModalPopupExtender>
<asp:HiddenField ID="hdnTransactionDetail" runat="server" />
<asp:Panel ID="pnlTransactionDetail" runat="server" Width="595px"
    Style="display: none;">
    <div class="box_col1">
        <div class="box_head">
            <span>
                <asp:Literal ID="litTransactionDetailHeader" runat="server" Text="Transaction Detail"></asp:Literal></span></div>
        <div class="clear">
        </div>
        <div class="box_form">
            <table cellpadding="2" cellspacing="2" border="0" width="100%">
                <tr>
                    <td style="border: 1px solid #ccccce;">
                        <table cellpadding="2" cellspacing="2" width="100%">
                            <tr>
                                <td width="100px">
                                    <asp:Literal ID="litTransactionDetailReservationNo" runat="server" Text="Reservation No."></asp:Literal>
                                </td>
                                <td width="150px">
                                    <asp:Literal ID="litDisplayTransactionDetailReservationNo" runat="server"></asp:Literal>
                                </td>
                                <td width="100px">
                                    <asp:Literal ID="litTransactionDetailName" runat="server" Text="Name"></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="litDisplayTransactionDetailName" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Literal ID="litTransactionDetailFolioNo" runat="server" Text="Folio No."></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="litDisplayTransactionDetailFolioNo" runat="server"></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="litTransactionDetailGroupName" runat="server" Text="Group Name"></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="litDisplayTransactionDetailGroupName" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Literal ID="litTransactionDetailUnitNo" runat="server" Text="Room No."></asp:Literal>
                                </td>
                                <td colspan="3">
                                    <asp:Literal ID="litDisplayTransactionDetailUnitNo" runat="server"></asp:Literal>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td>
                        <fieldset style="border: 1px solid #ccc !important;">
                            <legend>
                                <asp:Literal ID="litTransactionDetail" Text="Post Unit Charges Info." runat="server"></asp:Literal>
                            </legend>
                            <table cellpadding="2" cellspacing="2" width="100%">
                                <tr>
                                    <td width="100px">
                                        <asp:Literal ID="litTransactionNo" runat="server" Text="Transaction No."></asp:Literal>
                                    </td>
                                    <td width="200px">
                                        <asp:Literal ID="litDisplayTransactionNo" runat="server"></asp:Literal>
                                    </td>
                                    <td width="75px">
                                        <asp:Literal ID="litTransactionAmount" runat="server" Text="Amount"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:Literal ID="litDisplayTransactionAmount" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Literal ID="litTransactionAuditDate" runat="server" Text="Audit Date"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:Literal ID="litDisplayTransactionAuditDate" runat="server"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:Literal ID="litTransactionVoid" runat="server" Text="Void"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:Literal ID="litDisplayTransactionVoid" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Literal ID="litTransactionDescription" runat="server" Text="Description"></asp:Literal>
                                    </td>
                                    <td colspan="3">
                                        <asp:Literal ID="litDisplayTransactionDescription" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr id="trChangeDescription" runat="server" visible="false">
                                    <td colspan="4">
                                        <asp:CheckBox ID="chkChangeDescription" runat="server" Text="Change Description"
                                            onclick="fnRequireValidationForCheckBox();" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="vertical-align:top;">
                                        <asp:Literal ID="litTransactionDetailDescription" runat="server" Text="Description"></asp:Literal>
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtChangeDescription" runat="server" style="width:400px !important;" Enabled="true" TextMode="MultiLine"></asp:TextBox>
                                        <span>
                                            <asp:RequiredFieldValidator ID="rfvChangeDescription" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                runat="server" ValidationGroup="AddTranscationDetail" Enabled="true" ControlToValidate="txtChangeDescription"
                                                Display="Dynamic">
                                            </asp:RequiredFieldValidator>
                                        </span>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btnTransactionDetailSave" runat="server" Text="Save" Style="display: inline;"
                            ValidationGroup="AddTranscationDetail" OnClick="btnTransactionDetailSave_Click" />
                        <asp:Button ID="btnTransactionDetailCancel" runat="server" Text="Cancel" Style="display: inline;" />
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