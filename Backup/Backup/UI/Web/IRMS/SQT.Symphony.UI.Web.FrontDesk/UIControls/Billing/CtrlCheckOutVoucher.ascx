<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCheckOutVoucher.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Billing.CtrlCheckOutVoucher" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<style type="text/css">
    h1, p
    {
        font-weight: normal;
        font-size: 10px;
        margin: 0px;
        padding: 0px;
        color: Black;
    }
</style>
<script language="javascript" type="text/javascript">
    function openMyWindow() {
        var varReservationID = document.getElementById('<%= hdnReservationID.ClientID %>').value;
        var varReservationFolioID = document.getElementById('<%= hdnReservationFolioID.ClientID %>').value;
        var varDcmlTotalAmountRefundOrPayment = document.getElementById('<%= hdnDcmlTotalAmountRefundOrPayment.ClientID %>').value;
        var varStrRefundOrPayment = document.getElementById('<%= hdnStrRefundOrPayment.ClientID %>').value;
        var varStrModeOfRefundOrPayment = document.getElementById('<%= hdnStrModeOfRefundOrPayment.ClientID %>').value;
        window.open("CheckOutVoucher.aspx?ResID=" + varReservationID + "&ResFolioID=" + varReservationFolioID + "&TotalAmountRefundOrPayment=" + varDcmlTotalAmountRefundOrPayment + "&StrRefundOrPayment=" + varStrRefundOrPayment + "&StrModeOfRefundOrPayment=" + varStrModeOfRefundOrPayment + "&Operation=1", "CheckOutVouche", "height=600,width=750,status=1,toolbar=no,menubar=no,scrollbars=1,location=0");
    }
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<asp:HiddenField ID="hdnReservationID" runat="server" />
<asp:HiddenField ID="hdnReservationFolioID" runat="server" />
<asp:HiddenField ID="hdnDcmlTotalAmountRefundOrPayment" runat="server" />
<asp:HiddenField ID="hdnStrRefundOrPayment" runat="server" />
<asp:HiddenField ID="hdnStrModeOfRefundOrPayment" runat="server" />
<table width="100%">
    <tr>
        <td align="center">
            <table width="100%" border="0" cellpadding="2" cellspacing="2">
                <tr>
                    <td align="center">
                        <b>
                            <asp:Literal ID="litCheckOutVoucher" runat="server" Text="Check Out Voucher"></asp:Literal></b>
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td>
                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                            <tr>
                                <td>
                                    Booking #
                                </td>
                                <td>
                                    <b>
                                        <asp:Literal ID="ltrChkVchrBookingNo" runat="server"></asp:Literal>
                                    </b>
                                </td>
                                <td>
                                    Rate Card
                                </td>
                                <td>
                                    <asp:Literal ID="ltrChkVchrRateCard" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Check In
                                </td>
                                <td>
                                    <asp:Literal ID="ltrChkVchrCheckInDate" runat="server"></asp:Literal>
                                </td>
                                <td>
                                    Check Out
                                </td>
                                <td>
                                    <asp:Literal ID="ltrChkVchrCheckOutDate" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Room Type
                                </td>
                                <td>
                                    <asp:Literal ID="ltrChkVchrRoomType" runat="server"></asp:Literal>
                                </td>
                                <td>
                                    Room No.
                                </td>
                                <td>
                                    <asp:Literal ID="ltrChkVchrRoomNo" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Name
                                </td>
                                <td>
                                    <asp:Literal ID="ltrChkVchrGuestName" runat="server"></asp:Literal>
                                </td>
                                <td>
                                    Mobile No.
                                </td>
                                <td> 
                                    <asp:Literal ID="ltrChkVchrMobileNo" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td style="vertical-align: top;">
                                    Email
                                </td>
                                <td style="vertical-align: top;">
                                    <asp:Literal ID="ltrChkVchrGuestEmail" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" align="left">
                                    <b>Account Settlement</b>
                                    <hr />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                        <tr>
                                            <td style="vertical-align: top;" width="50%">
                                                <table width="100%">
                                                    <tr>
                                                        <td width="100px">
                                                            <b>Summary</b>
                                                        </td>
                                                        <td align="right">
                                                            <b>Debit</b>
                                                        </td>
                                                        <td align="right">
                                                            <b>Credit</b>
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
                                                        <td align="right">
                                                            <asp:Label ID="lblChkOutVchrSmryRoomRentDebit" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="right">
                                                            -
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Services Charge
                                                        </td>
                                                        <td align="right">
                                                            <asp:Label ID="lblChkOutVchrSmryServicesChargeDebit" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="right">
                                                            -
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Payment
                                                        </td>
                                                        <td align="right">
                                                            -
                                                        </td>
                                                        <td align="right">
                                                            <asp:Label ID="lblChkOutVchrSmryPaymentCredit" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Cash Card
                                                        </td>
                                                        <td align="right">
                                                            -
                                                        </td>
                                                        <td align="right">
                                                            <asp:Label ID="lblChkOutVchrSmryCashCardCredit" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Deposit
                                                        </td>
                                                        <td align="right">
                                                            -
                                                        </td>
                                                        <td align="right">
                                                            <asp:Label ID="lblChkOutVchrSmryDepositCredit" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 0px;" colspan="3">
                                                            <hr />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Total
                                                        </td>
                                                        <td align="right">
                                                            <asp:Label ID="lblChkOutVchrSmryTotalDebit" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="right">
                                                            <asp:Label ID="lblChkOutVchrSmryTotalCredit" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <b>Balance (<asp:Label ID="lblChkOutVchrSmryTotalDebitOrCredit" runat="server"></asp:Label>)</b>
                                                        </td>
                                                        <td align="right">
                                                            -
                                                        </td>
                                                        <td align="right">
                                                            <b>
                                                                <asp:Label ID="lblChkOutVchrSmryNetBalanceAmount" runat="server"></asp:Label></b>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="border-left: 1px solid #CCCCCC;">
                                            </td>
                                            <td style="vertical-align: top;" width="50%">
                                                <table width="100%">
                                                    <tr>
                                                        <td colspan="3">
                                                            <b>
                                                                <asp:Literal ID="ltrChkOutVchrRefundOrPaymentHeader" runat="server" Text="Refund"></asp:Literal>
                                                            </b>
                                                            <hr />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="160px">
                                                            Payment
                                                        </td>
                                                        <td align="right" style="text-align:right;">
                                                            <asp:Literal ID="ltrChkOutVchrTotalAmountRefundOrPayment" runat="server"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="ltrChkOutVchrModeOfRefundOrPayment" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 135px;">
                                                            Deposit
                                                        </td>
                                                        <td align="right" style="text-align:right;">
                                                            <asp:Literal ID="ltrChkOutVchrRefundedDeposits" runat="server"></asp:Literal> 
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="ltrChkOutVchrModeOfRefundDeposits" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" style="padding: 0px;">
                                                            <hr />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 135px;">
                                                            Total Refund
                                                        </td>
                                                        <td align="right" style="text-align:right;">
                                                            <asp:Literal ID="ltrChkOutVchrTotalRefund" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <b>Balance Amount (<asp:Literal ID="ltrChkOutVchrDueOrCredit" runat="server"></asp:Literal>)</b>
                                                        </td>
                                                        <td align="right" style="text-align:right;">
                                                            <b>
                                                                <asp:Literal ID="ltrChkOutVchrBalanceAmountDueOrCredit" runat="server"></asp:Literal>
                                                            </b>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <div style="text-align: center; display: inline-block;">
                            <%--<asp:Button ID="Button2" runat="server" Text="Email & SMS" ImageUrl="~/images/save.png"
                                Style="float: right; margin-left: 5px;" />
                            <asp:Button ID="Button3" runat="server" Text="SMS" ImageUrl="~/images/save.png" Style="float: right;
                                margin-left: 5px;" />
                            <asp:Button ID="Button4" runat="server" Text="Email" ImageUrl="~/images/save.png"
                                Style="float: right; margin-left: 5px;" />--%>
                            <asp:Button ID="btnCheckOutVoucherPrint" runat="server" Text="Print" Style="float: right;
                                margin-left: 5px;" OnClientClick="openMyWindow();" />
                        </div>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
