<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationVoucher.aspx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Reservation.RegistrationVoucher" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link id="Link1" href="~/Styles/style.css" runat="server" rel="stylesheet" type="text/css" />
    <%-- <script type="text/javascript">
        function fnPrint() {
            document.getElementById('dvToHide').style.display = 'none';

            var DocumentContainer = document.getElementById('divName');
            var WindowObject = window.open('', 'PrintWindow', 'width=750,height=650,top=50,left=50,toolbars=no,scrollbars=yes,status=no,resizable=yes');
            WindowObject.document.writeln(DocumentContainer.innerHTML);
            WindowObject.document.close();
            WindowObject.focus();
            WindowObject.print();
            WindowObject.close();
        }
    </script>--%>
    <script type="text/javascript">
        function fnPrint() {
            document.getElementById('dvToHide').style.display = 'none';
            window.print();
            window.close();
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
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 800px; margin: 0; height: 60px; text-align: center;">
        <img src="<%=Page.ResolveUrl("~/images/Logo - registerd_small.jpg") %>" style="width: 175px;
            height: 54px" border="0" alt="" />
    </div>
    <div style="text-align: center; width: 800px;">
        <asp:Label runat="server" ID="lblPropertyaddress"></asp:Label></div>
    <div class="box_form" id="divName">
        <table width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <div id="dvToHide" style="padding-bottom: 10px; padding-top: 10px; padding-left: 10px;
                        padding-right: 10px;">
                        <asp:Button ID="btnPrint" runat="server" Text="Print" OnClientClick="fnPrint();" />
                    </div>
                </td>
            </tr>
        </table>
        <table width="100%" border="0" cellpadding="2" cellspacing="2">
            <tr>
                <td align="center" colspan="4">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border-bottom: 1px solid #CCCCCC;">
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
                </td>
            </tr>
            <tr>
                <td>
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
                            <td colspan="4" style="border-bottom: 1px solid #CCCCCC;">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="border-bottom: 1px solid #CCCCCC;">
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
                                                        Electricity and Food Charges
                                                    </td>
                                                    <td align="center">
                                                        -
                                                    </td>
                                                    <td align="right">
                                                        <asp:Label ID="lblElectricityCharges" runat="server"></asp:Label>
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
                                                            <asp:Label ID="lblDisplayReservationPolicy" Style="font-size: 10px; font-weight: normal;
                                                                color: black;" runat="server"></asp:Label>
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
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
