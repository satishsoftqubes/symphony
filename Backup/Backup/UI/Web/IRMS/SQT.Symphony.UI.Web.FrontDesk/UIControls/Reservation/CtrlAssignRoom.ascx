<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlAssignRoom.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation.CtrlAssignRoom" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<%@ Register Src="~/UIControls/Reservation/CtrlReservationVoucher.ascx" TagName="ReservationVoucher"
    TagPrefix="ucCtrlReservationVoucher" %>
<script src="../../Scripts/jquery-1.8.2.js" type="text/javascript"></script>
<script src="../../Scripts/jquery-ui.js"></script>
<script src="../../Scripts/Common.js" type="text/javascript"></script>
<script>
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<asp:UpdatePanel ID="updCheckInList" runat="server">
    <ContentTemplate>
        <asp:MultiView ID="mvAssignRoom" runat="server">
            <asp:View ID="vAssignRoom" runat="server">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="content">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="boxtopleft">
                                        &nbsp;
                                    </td>
                                    <td class="boxtopcenter">
                                        <asp:Literal ID="Literal19" runat="server" Text="Assign Room"></asp:Literal>
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
                                            <table width="100%">
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
                                                                    <%--Room No.--%>
                                                                </td>
                                                                <td>
                                                                    <%--<asp:Literal ID="ltrChkPmtRoomNo" runat="server"></asp:Literal>--%>
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
                                                    <td width="40%" style="vertical-align: top;">
                                                        <table width="100%" border="0">
                                                            <tr>
                                                                <td width="40%">
                                                                    <b>Particulars</b>
                                                                </td>
                                                                <td width="30%" align="center">
                                                                    <b>No. of Nights</b>
                                                                </td>
                                                                <td width="30%" align="right">
                                                                    <b>Amount (Rs.)</b>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 0px;" colspan="3">
                                                                    <hr />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    Room Rent
                                                                </td>
                                                                <td align="center">
                                                                    <asp:Label ID="lblDisplayNoOfDays" runat="server"></asp:Label>
                                                                </td>
                                                                <td align="right">
                                                                    <asp:Label ID="lblResTimeRoomRent" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    Tax
                                                                </td>
                                                                <td align="center">
                                                                    -
                                                                </td>
                                                                <td align="right">
                                                                    <asp:Label ID="lblResTimeTax" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                    <td>
                                                                        Infra. Service Charges
                                                                    </td>
                                                                    <td align="center">
                                                                        -
                                                                    </td>
                                                                    <td align="right">
                                                                        <asp:Label ID="lblInfraServiceCharges" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            <tr>
                                                                <td style="padding: 0px;" colspan="3">
                                                                    <hr />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <b>Total Charges</b>
                                                                </td>
                                                                <td align="center">
                                                                    -
                                                                </td>
                                                                <td align="right">
                                                                    <asp:Label ID="lblResTimeTotalCharges" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    Deposit
                                                                </td>
                                                                <td align="center">
                                                                    -
                                                                </td>
                                                                <td align="right">
                                                                    <asp:Label ID="lblResTimeDepositAmount" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 0px;" colspan="3">
                                                                    <hr />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <b>Total Amount</b>
                                                                </td>
                                                                <td align="center">
                                                                    -
                                                                </td>
                                                                <td align="right">
                                                                    <asp:Label ID="lblResTimeTotalPayableAmount" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td style="border-left: 1px solid #CCCCCC;">
                                                    </td>
                                                    <td width="60%" style="vertical-align: top;">
                                                        <table width="100%" border="0">
                                                            <tr>
                                                                <td>
                                                                    <b>Receipt</b>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 0px;">
                                                                    <hr />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <div class="box_content">
                                                                        <asp:GridView ID="gvPaymentList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                            OnRowDataBound="gvPaymentList_RowDataBound" Width="100%">
                                                                            <Columns>
                                                                                <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrDateOfPayment" runat="server" Text="Date"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblDateOfPayment" runat="server"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrTransactionNo" runat="server" Text="Transaction #"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%#DataBinder.Eval(Container.DataItem, "BookNo")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrPaymentMode" runat="server" Text="Payment Mode"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%#DataBinder.Eval(Container.DataItem, "PaymentMode")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrAmount" runat="server" Text="Amount"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblAmount" runat="server"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                            <EmptyDataTemplate>
                                                                                <div style="padding: 10px;">
                                                                                    <b>
                                                                                        <asp:Label ID="lblNoRecordFound" runat="server" Text="No payment found."></asp:Label>
                                                                                    </b>
                                                                                </div>
                                                                            </EmptyDataTemplate>
                                                                        </asp:GridView>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <b>Total Received</b>&nbsp;&nbsp;&nbsp;<b><asp:Label ID="lblTotalPaymentReceived"
                                                                        runat="server"></asp:Label></b>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 0px;">
                                                                    <hr />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <b>
                                                                        <asp:Label ID="lblAmountBalanceOrDueText" runat="server"></asp:Label></b>&nbsp;&nbsp;&nbsp;<b><asp:Label
                                                                            ID="lblAmountBalanceOrDue" runat="server"></asp:Label></b>
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
                                                    <td colspan="3">
                                                        <table width="40%">
                                                            <tr>
                                                                <td style="padding: 0px;" colspan="2" align="right">
                                                                    <asp:Literal ID="ltrMinAmtForConfirmReservation" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <b>Assign Room</b>
                                                                    <hr />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="150px">
                                                                    Booking Status
                                                                </td>
                                                                <td>
                                                                    Confirmed
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <b>Room No.</b>
                                                                </td>
                                                                <td style="width: 264px;">
                                                                    <asp:DropDownList ID="ddlRoomNumber" runat="server">
                                                                    </asp:DropDownList>
                                                                    <span>
                                                                        <asp:RequiredFieldValidator ID="rfvRoomNumber" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                            SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                            ValidationGroup="IsRequire" ControlToValidate="ddlRoomNumber" Display="Dynamic">
                                                                        </asp:RequiredFieldValidator>
                                                                    </span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td style="padding-top: 15px;">
                                                                    <asp:Button ID="btnSave" runat="server" Text="Save" Style="display: inline;" ValidationGroup="IsRequire"
                                                                        OnClick="btnSave_OnClick" />
                                                                    <asp:Button ID="btnCancel" runat="server" Text="Back to Dashboard" Style="display: inline;"
                                                                        OnClick="btnCancel_Click" />
                                                                </td>
                                                            </tr>
                                                        </table>
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
                <%--Modal Popup for Sample Reservation Voucher Start--%>
                <ajx:ModalPopupExtender ID="mpeReservatinoVoucher" runat="server" TargetControlID="hdnReservationVoucher"
                    PopupControlID="pnlReservatinoVoucher" BackgroundCssClass="mod_background" CancelControlID="iBtnCloseResVoucher">
                </ajx:ModalPopupExtender>
                <asp:HiddenField ID="hdnReservationVoucher" runat="server" />
                <asp:Panel ID="pnlReservatinoVoucher" runat="server" Width="700px">
                    <div class="box_col1">
                        <div class="box_head">
                            <div style="display: inline;">
                                <span>
                                    <asp:Literal ID="Literal2" runat="server" Text="Reservation Voucher"></asp:Literal></span></div>
                            <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                                <asp:ImageButton ID="iBtnCloseResVoucher" runat="server" ImageUrl="~/images/closepopup.png"
                                    Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;" />
                            </div>
                        </div>
                        <div class="clear">
                        </div>
                        <div class="box_form">
                            <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                <tr>
                                    <td align="left">
                                        <ucCtrlReservationVoucher:ReservationVoucher ID="ctrlReservationVoucher" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                </asp:Panel>
                <%--Modal Popup for Sample Reservation Voucher End--%>
            </asp:View>
        </asp:MultiView>
        <ajx:ModalPopupExtender ID="mpeAssignRoom" runat="server" TargetControlID="hdnAssignRoom"
            PopupControlID="pnlAssignRoom" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnAssignRoom" runat="server" />
        <asp:Panel ID="pnlAssignRoom" runat="server" Width="400px">
            <div class="box_col1">
                <div class="box_head">
                    <div style="display: inline;">
                        <span>
                            <asp:Literal ID="Literal6" runat="server" Text="Assign Room"></asp:Literal></span></div>
                    <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                        <asp:ImageButton ID="iBtnCacelAssignRoom" runat="server" ImageUrl="~/images/closepopup.png"
                            Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;"
                            OnClick="iBtnCacelAssignRoom_OnClick" />
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td class="isrequire">
                                <b>
                                    <asp:Literal ID="Literal7" runat="server" Text="Booking #"></asp:Literal></b>
                            </td>
                            <td>
                                <asp:TextBox ID="txtForPaymentBookingNo" runat="server" Style="width: 200px"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rfvForPaymentBookingNo" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                        runat="server" ValidationGroup="IsRequireForPayment" ControlToValidate="txtForPaymentBookingNo"
                                        Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                </span>
                                <ajx:FilteredTextBoxExtender ID="ftePaymentBookingNo" runat="server" TargetControlID="txtForPaymentBookingNo"
                                    FilterMode="ValidChars" ValidChars="0123456789">
                                </ajx:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="Literal9" runat="server" Text="Guest Name"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtForPaymentGuestName" runat="server" Style="width: 200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Button ID="btnProceedAssignRoom" runat="server" Text="Proceed" Style="display: inline;"
                                    OnClick="btnProceedAssignRoom_OnClick" ValidationGroup="IsRequireForPayment" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpeSuccessMessage" runat="server" TargetControlID="hfSuccessMessage"
            PopupControlID="pnlSuccessMessage" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hfSuccessMessage" runat="server" />
        <asp:Panel ID="pnlSuccessMessage" runat="server" Style="display: none; min-height: 350px;
            min-width: 350px;">
            <div class="box_col1">
                <div class="box_head">
                    <div style="display: inline;">
                        <span>
                            <asp:Literal ID="Literal1" runat="server" Text="Message"></asp:Literal></span></div>
                    <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                        <asp:ImageButton ID="iBtnCancelSuccessMessage" runat="server" ImageUrl="~/images/closepopup.png"
                            Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;"
                            OnClick="iBtnCacelAssignRoom_OnClick" />
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%" style="margin-top: 10px;">
                        <tr>
                            <td align="center" style="padding-bottom: 15px;">
                                <asp:Label ID="lblSuccessMessage" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnSuccessMessageOK" Text="OK" runat="server" OnClick="btnSuccessMessageOK_OnClick"
                                    Style="display: inline; padding-right: 10px;" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnSave" />
    </Triggers>
</asp:UpdatePanel>
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updCheckInList" ID="UpdateProgressCheckInList"
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
