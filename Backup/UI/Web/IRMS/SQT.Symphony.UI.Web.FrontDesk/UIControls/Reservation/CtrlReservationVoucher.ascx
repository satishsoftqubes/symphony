<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlReservationVoucher.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation.CtrlReservationVoucher" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script src="../../Scripts/jquery-1.8.2.js"></script>
<script src="../../Scripts/jquery-ui.js"></script>
<script type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
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
        var hdnReservationID = document.getElementById('<%= hdnReservationID.ClientID %>').value;
        window.open("RegistrationVoucher.aspx?id=" + hdnReservationID + "&Operation=yes", "RegistrationVouche", "height=600,width=750,status=1,toolbar=no,menubar=no,scrollbars=1,location=0");
    }
</script>
<table width="100%" border="0" cellpadding="2" cellspacing="2">
    <tr>
        <td align="center" colspan="4">
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="33%">
                        &nbsp;
                    </td>
                    <td width="33%" align="center">
                        <b>Reservation Voucher
                            <asp:HiddenField ID="hdnReservationID" runat="server" />
                        </b>
                    </td>
                    <td align="right" width="33%">
                        <asp:Literal ID="litCurrentDate" runat="server"></asp:Literal>
                    </td>
                </tr>
            </table>
            <hr />
        </td>
    </tr>
    <tr>
        <td>
            <div style="height: 400px; overflow: auto;">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="90px">
                            <asp:Literal ID="litName" runat="server" Text="Name"></asp:Literal>
                        </td>
                        <td width="217px">
                            :&nbsp;<asp:Literal ID="litReservationVoucherGuestName" runat="server"></asp:Literal>
                        </td>
                        <td width="90px">
                            <asp:Literal ID="litBookingNo" runat="server" Text="Booking #"></asp:Literal>
                        </td>
                        <td>
                            :&nbsp;<b><asp:Literal ID="litReservationVoucherBookingNo" runat="server"></asp:Literal></b>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Literal ID="litMobileNo" Text="Mobile No." runat="server"></asp:Literal>
                        </td>
                        <td>
                            :&nbsp;<asp:Literal ID="litReservationVoucherMobileNo" runat="server"></asp:Literal>
                        </td>
                        <td>
                            <asp:Literal ID="litEmail" runat="server" Text="Email ID"></asp:Literal>
                        </td>
                        <td>
                            :&nbsp;<asp:Literal ID="litReservationVoucherEmail" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Literal ID="litCheckingDate" runat="server" Text="Check In Date"></asp:Literal>
                        </td>
                        <td>
                            :&nbsp;<asp:Literal ID="litReservationVoucherCheckinDate" runat="server"></asp:Literal>
                        </td>
                        <td>
                            <asp:Literal ID="litCheckoutDate" runat="server" Text="Check Out Date"></asp:Literal>
                        </td>
                        <td>
                            :&nbsp;<asp:Literal ID="litReservationVoucherCheckoutDate" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Literal ID="litNoOfNights" runat="server" Text="No of Nights"></asp:Literal>
                        </td>
                        <td>
                            :&nbsp;<asp:Literal ID="litReservationVoucherNoofNights" runat="server"></asp:Literal>
                        </td>
                        <td>
                            <asp:Literal ID="Literal1" runat="server" Text="No of Guests"></asp:Literal>
                        </td>
                        <td>
                            :&nbsp;<asp:Literal ID="litReservationVoucherNoofGuests" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Literal ID="litRateCardType" runat="server" Text="Rate Card"></asp:Literal>
                        </td>
                        <td>
                            :&nbsp;<asp:Literal ID="litReservationVoucherRateCard" runat="server"></asp:Literal>
                        </td>
                        <td>
                            <asp:Literal ID="litRoomType" runat="server" Text="Room Type"></asp:Literal>
                        </td>
                        <td>
                            :&nbsp;<asp:Literal ID="litReservationVoucherRoomType" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Literal ID="litStatus" runat="server" Text="Booking Status"></asp:Literal>
                        </td>
                        <td>
                            :&nbsp;<asp:Literal ID="litReservationVoucherBookingStatus" runat="server"></asp:Literal>
                        </td>
                        <td>
                            <asp:Literal ID="litValidUpto" runat="server" Text="Valid Upto :"></asp:Literal>
                        </td>
                        <td>
                            <asp:Literal ID="litReservationVoucherValidUpto" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <table width="100%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="50%" style="vertical-align: top;">
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <b>Particulars</b>
                                                </td>
                                                <td align="center">
                                                    <b>No. of Nights</b>
                                                </td>
                                                <td align="right">
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
                                                    <asp:Label ID="lblDisplayRoomRent" runat="server"></asp:Label>
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
                                                    <asp:Label ID="lblDisplayTax" runat="server"></asp:Label>
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
                                                <td>
                                                    Food Charges
                                                </td>
                                                <td align="center">
                                                    -
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblFoodCharges" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Electricity and Water Charges
                                                </td>
                                                <td align="center">
                                                    -
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblElectricityCharge" runat="server"></asp:Label>
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
                                                    <b>
                                                        <asp:Label ID="lblDisplayTotalAmount" runat="server"></asp:Label></b>
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
                                                    <asp:Label ID="lblDisplayDepositAmount" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 0px;" colspan="3">
                                                    <hr />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <b>Total Amount Payable</b>
                                                </td>
                                                <td align="center">
                                                    -
                                                </td>
                                                <td align="right">
                                                    <b>
                                                        <asp:Label ID="lblTotalAmountPayable" runat="server"></asp:Label></b>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="border-left: 1px solid #CCCCCC;">
                                    </td>
                                    <td width="50%" style="vertical-align: top;">
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td colspan="2">
                                                    <b>Payment Received</b>
                                                    <hr />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="140px">
                                                    <asp:Literal ID="Literal6" runat="server" Text="Amount"></asp:Literal>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblDisplayAmount" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="padding: 0px;">
                                                    <hr />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Literal ID="Literal8" runat="server" Text="Total Amount Received"></asp:Literal>
                                                </td>
                                                <td>
                                                    <b>
                                                        <asp:Label ID="lblDisplayTotalAmountReceived" runat="server"></asp:Label></b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="padding: 0px;">
                                                    <hr />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <b>
                                                        <asp:Literal ID="litDispBalanceAmount" runat="server" Text="Balance Amount(Due)"></asp:Literal></b>
                                                </td>
                                                <td>
                                                    <b>
                                                        <asp:Label ID="lblDisplayBalanceAmountDue" runat="server"></asp:Label></b>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 0px;" colspan="4">
                            <hr />
                            <table width="100%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="50%" style="vertical-align: top;">
                                        <div style="text-align: center;">
                                            <b>
                                                <asp:Literal ID="Literal22" runat="server" Text="CANCELLATION POLICY"></asp:Literal></b>
                                        </div>
                                        <div>
                                            <hr />
                                        </div>
                                        <div style="font-size: 10px;">
                                            <table width="100%" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblDisplayCancellationPolicy" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                    <td style="border-left: 1px solid #CCCCCC;">
                                    </td>
                                    <td width="50%" style="vertical-align: top;">
                                        <div style="text-align: center;">
                                            <b>
                                                <asp:Literal ID="Literal2" runat="server" Text="RESERVATION POLICY"></asp:Literal></b>
                                        </div>
                                        <div>
                                            <hr />
                                        </div>
                                        <div style="font-size: 10px;">
                                            <table width="100%" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td>
                                                        -&nbsp;Check In time &nbsp;: &nbsp;<asp:Literal ID="litDisplayReservationVoucherCheckInTime"
                                                            runat="server"></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        -&nbsp;Check Out time&nbsp;: &nbsp;
                                                        <asp:Literal ID="litDisplayReservationVoucherCheckOutTime" runat="server"></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Reservation will be held until 12:00 AM
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblDisplayReservationPolicy" Style="font-weight: normal; color: black;"
                                                            runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </td>
    </tr>
    <tr>
        <td align="center" colspan="4">
            <div style="text-align: center; display: inline-block;">
                <asp:Button ID="Button2" runat="server" Text="Email & SMS" ImageUrl="~/images/save.png"
                    Style="float: right; margin-left: 5px;" />
                <asp:Button ID="Button3" runat="server" Text="SMS" ImageUrl="~/images/save.png" Style="float: right;
                    margin-left: 5px;" />
                <asp:Button ID="btnsendEmail" runat="server" Text="Email" ImageUrl="~/images/save.png"
                    Style="float: right; margin-left: 5px;" OnClick="btnsendEmail_Click" />
                <asp:Button ID="btnRegistrationVoucherPrint" runat="server" Text="Print" Style="float: right;
                    margin-left: 5px;" OnClientClick="openMyWindow();" />
            </div>
        </td>
    </tr>
</table>
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
