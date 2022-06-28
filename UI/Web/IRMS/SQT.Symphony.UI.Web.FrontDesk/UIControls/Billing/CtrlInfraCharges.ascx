<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlInfraCharges.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Billing.CtrlInfraCharges" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<%@ Register Src="~/UIControls/Reservation/PaymentReceipt.ascx" TagName="PaymentReceipt"
    TagPrefix="ucCtrlPaymentReceipt" %>
    <script type="text/javascript">
        function fnopenPrintWindow() {
            $find('mpePrintReceipt').hide();
            var hdnReservationID = document.getElementById('<%= hdnResID.ClientID %>').value;
            var hdnBookingID = document.getElementById('<%= hdnBookingID.ClientID %>').value;
            window.open("../Reservation/CheckInPaymentRecipt.aspx?IdofRes=" + hdnReservationID + "&IdofBook=" + hdnBookingID, "CheckInVouche", "height=600,width=600,status=1,toolbar=no,menubar=no,scrollbars=1,location=0");
            return false;
        }
    </script>
<asp:UpdatePanel ID="updInfraCharges" runat="server">
    <ContentTemplate>
        <asp:HiddenField ID="hdnBookingID" runat="server" />
        <asp:HiddenField ID="hdnResID" runat="server" />
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="content">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                <asp:Literal ID="Literal19" runat="server" Text="Receipt"></asp:Literal>
                            </td>
                            <td class="boxtopright">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="boxleft">
                                &nbsp;
                            </td>
                            <td align="left">
                                <div class="box_form">
                                    <table width="100%" border="0">
                                        <tr>
                                            <td colspan="3">
                                                <table width="100%" cellpadding="2" cellspacing="2">
                                                    <tr>
                                                        <td width="60px">
                                                            Booking #
                                                        </td>
                                                        <td width="150px">
                                                            <asp:Literal ID="ltrChkPmtReservationNo" runat="server"></asp:Literal>
                                                        </td>
                                                        <td width="70px">
                                                            Guest Name
                                                        </td>
                                                        <td width="150px">
                                                            <asp:Literal ID="ltrChkPmtGuestName" runat="server"></asp:Literal>
                                                        </td>
                                                        <td width="50px">
                                                            Check In
                                                        </td>
                                                        <td width="100px">
                                                            <asp:Literal ID="ltrChkPmtCheckInDate" runat="server"></asp:Literal>
                                                        </td>
                                                        <td width="50px">
                                                            Check Out
                                                        </td>
                                                        <td width="100px">
                                                            <asp:Literal ID="ltrChkPmtCheckOutDate" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Rate Card
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="ltrChkPmtRateCard" runat="server"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            Room Type
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="ltrChkPmtRoomType" runat="server"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            Room No.
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="ltrChkPmtRoomNo" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table width="100%">
                                                    <tr>
                                                        <td>
                                                            <b>Receipt</b>
                                                        </td>
                                                        <td style="padding: 0px;" align="right">
                                                            <asp:Literal ID="ltrMinAmtForConfirmReservation" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <hr />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="130px">
                                                            <b>Amount</b>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPaymentAmount" runat="server" SkinID="nowidth" Width="150px"
                                                                MaxLength="9"></asp:TextBox>
                                                            <ajx:FilteredTextBoxExtender ID="ftePaymentAmount" runat="server" TargetControlID="txtPaymentAmount"
                                                                FilterMode="ValidChars" ValidChars=".0123456789">
                                                            </ajx:FilteredTextBoxExtender>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvPaymentAmount" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                    runat="server" ValidationGroup="RequireForPayment" ControlToValidate="txtPaymentAmount"
                                                                    Display="Dynamic">
                                                                </asp:RequiredFieldValidator>
                                                            </span>
                                                            <asp:RegularExpressionValidator ID="regPaymentAmount" SetFocusOnError="True" runat="server"
                                                                ValidationGroup="RequireForPayment" ControlToValidate="txtPaymentAmount" ValidationExpression="^\d{0,18}(\.\d{0,2})?$"
                                                                Display="Dynamic" ForeColor="Red" ErrorMessage="Two digit allowd after decimal point."></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <b>Mode of Payment</b>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlModeOfPayment" runat="server" SkinID="nowidth" Width="150px"
                                                                OnSelectedIndexChanged="ddlModeOfPayment_OnSelectedIndexChanged" AutoPostBack="true">
                                                            </asp:DropDownList>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvModeOfPayment" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                    ValidationGroup="RequireForPayment" ControlToValidate="ddlModeOfPayment" Display="Dynamic">
                                                                </asp:RequiredFieldValidator>
                                                            </span>
                                                        </td>
                                                    </tr>
                                                    <tr id="trLedgerAccount" runat="server" visible="false">
                                                        <td>
                                                            Ledger
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlLedgerAccount" SkinID="nowidth" Width="150px" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr id="trChequeDD1" runat="server" visible="false">
                                                        <td>
                                                            Bank Name
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtBankName" SkinID="nowidth" Width="150px" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr id="trChequeDD2" runat="server" visible="false">
                                                        <td>
                                                            Cheque/DD No.
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtChequeDDNo" SkinID="nowidth" Width="150px" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr id="trCreditCard1" runat="server" visible="false">
                                                        <td>
                                                            Card Type
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlCreditCardType" SkinID="nowidth" Width="150px" runat="server">
                                                            </asp:DropDownList>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvCreditCardType" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" Enabled="false"
                                                                    runat="server" ValidationGroup="RequireForPayment" ControlToValidate="ddlCreditCardType"
                                                                    Display="Dynamic">
                                                                </asp:RequiredFieldValidator>
                                                            </span>
                                                        </td>
                                                    </tr>
                                                    <tr id="trCreditCard2" runat="server" visible="false">
                                                        <td>
                                                            Name on Card
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtNameOnCard" SkinID="nowidth" Width="150px" runat="server"></asp:TextBox>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvNameOnCreditCard" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                    Enabled="false" runat="server" ValidationGroup="RequireForPayment" ControlToValidate="txtNameOnCard"
                                                                    Display="Dynamic">
                                                                </asp:RequiredFieldValidator>
                                                            </span>
                                                        </td>
                                                    </tr>
                                                    <tr id="trCreditCard3" runat="server" visible="false">
                                                        <td>
                                                            Card Number
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCardNumber" runat="server" SkinID="nowidth" Width="150px" MaxLength="16"></asp:TextBox>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvCreditCardNumber" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                    Enabled="false" runat="server" ValidationGroup="RequireForPayment" ControlToValidate="txtCardNumber"
                                                                    Display="Dynamic">
                                                                </asp:RequiredFieldValidator>
                                                            </span>
                                                            <ajx:FilteredTextBoxExtender ID="fteCreditCardNumber" runat="server" TargetControlID="txtCardNumber"
                                                                FilterMode="ValidChars" ValidChars="0123456789">
                                                            </ajx:FilteredTextBoxExtender>
                                                            <asp:RegularExpressionValidator ID="regCreditCardNumber" runat="server" ControlToValidate="txtCardNumber"
                                                                ErrorMessage="Card No. must be 16 digits." Display="Dynamic" ValidationGroup="RequireForPayment"
                                                                ForeColor="Red" ValidationExpression="^[0-9]{16}"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr id="trCVVNo" runat="server" visible="false">
                                                        <td>
                                                            CVV No.
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCVVNo" runat="server" SkinID="nowidth" Width="150px" MaxLength="4"></asp:TextBox>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvCVVNumber" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                    Enabled="false" runat="server" ValidationGroup="RequireForPayment" ControlToValidate="txtCVVNo"
                                                                    Display="Dynamic">
                                                                </asp:RequiredFieldValidator>
                                                            </span>
                                                            <ajx:FilteredTextBoxExtender ID="fteCVVNo" runat="server" TargetControlID="txtCVVNo"
                                                                FilterMode="ValidChars" ValidChars="0123456789">
                                                            </ajx:FilteredTextBoxExtender>
                                                        </td>
                                                    </tr>
                                                    <tr id="trCreditCard4" runat="server" visible="false">
                                                        <td>
                                                            Expiration Date
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlCardExpirationMonth" runat="server" SkinID="nowidth" Width="100px">
                                                                <asp:ListItem Text="-SELECT-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                                <asp:ListItem Text="January" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="February" Value="2"></asp:ListItem>
                                                                <asp:ListItem Text="March" Value="3"></asp:ListItem>
                                                                <asp:ListItem Text="April" Value="4"></asp:ListItem>
                                                                <asp:ListItem Text="May" Value="5"></asp:ListItem>
                                                                <asp:ListItem Text="June" Value="6"></asp:ListItem>
                                                                <asp:ListItem Text="July" Value="7"></asp:ListItem>
                                                                <asp:ListItem Text="August" Value="8"></asp:ListItem>
                                                                <asp:ListItem Text="September" Value="9"></asp:ListItem>
                                                                <asp:ListItem Text="October" Value="10"></asp:ListItem>
                                                                <asp:ListItem Text="November" Value="11"></asp:ListItem>
                                                                <asp:ListItem Text="December" Value="12"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvCardExpirationMonth" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" Enabled="false"
                                                                    runat="server" ValidationGroup="RequireForPayment" ControlToValidate="ddlCardExpirationMonth"
                                                                    Display="Static">
                                                                </asp:RequiredFieldValidator>
                                                            </span>
                                                            <asp:DropDownList ID="ddlCardExpirationYear" runat="server" SkinID="nowidth" Width="90px">
                                                            </asp:DropDownList>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvCardExpirationYear" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" Enabled="false"
                                                                    runat="server" ValidationGroup="RequireForPayment" ControlToValidate="ddlCardExpirationYear"
                                                                    Display="Dynamic">
                                                                </asp:RequiredFieldValidator>
                                                            </span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td style="padding-top: 5px;">
                                                            <table width="100%" border="0">
                                                                <tr>
                                                                    <td width="100px">
                                                                        &nbsp;<asp:Button ID="btnSavePayment" runat="server" Text="Save" Style="display: inline;"
                                                                            ValidationGroup="RequireForPayment" OnClick="btnSavePayment_OnClick" OnClientClick="hidebutton();" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:Button ID="btnBackToListFromPmtView" runat="server" Text="Back to Dashboard"
                                                                            Style="display: inline;" OnClick="btnCheckInCancel_Click" />
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="border-left: 1px solid #CCCCCC; display: none;">
                                            </td>
                                            <td align="left" style="vertical-align: top; padding-top: 10px;">
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                            <td class="boxright">
                            </td>
                        </tr>
                        <tr>
                            <td class="boxbottomleft">
                            </td>
                            <td class="boxbottomcenter">
                            </td>
                            <td class="boxbottomright">
                            </td>
                        </tr>
                    </table>
                    <div style="height: 10px;">
                    </div>
                    <div class="clear_divider">
                    </div>
                    <div class="clear">
                    </div>
                </td>
            </tr>
        </table>
        <ajx:ModalPopupExtender ID="mpePrintReceipt" runat="server" TargetControlID="hdnPrintReceipt"
            PopupControlID="pnlPrintReceipt" BehaviorID="mpePrintReceipt" CancelControlID="iBtnClosePaymentReceipt"
            BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnPrintReceipt" runat="server" />
        <asp:Panel ID="pnlPrintReceipt" runat="server" Width="400px">
            <div class="box_col1">
                <div class="box_head">
                    <div style="display: inline;">
                        <span>
                            <asp:Literal ID="Literal20" runat="server" Text="Payment Receipt"></asp:Literal></span></div>
                    <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                        <asp:ImageButton ID="iBtnClosePaymentReceipt" runat="server" ImageUrl="~/images/closepopup.png"
                            Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;" />
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table width="100%">
                        <tr>
                            <td align="left">
                                <ucCtrlPaymentReceipt:PaymentReceipt ID="ucPaymentReceipt" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnPaymentPrintReceipt" runat="server" Text="Print" Style="display: inline;"
                                    OnClientClick="return fnopenPrintWindow();" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updInfraCharges" ID="UpdateProgressInfraCharges"
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