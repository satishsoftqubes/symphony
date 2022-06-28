<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExtandReservationVoucherPrint.aspx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Reservation.ExtandReservationVoucherPrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link id="Link1" href="~/Styles/style.css" runat="server" rel="stylesheet" type="text/css" />
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
    <div class="box_form" id="divName">
        <center>
            <div style="margin: 0; height: 60px; text-align: center;">
                <img src="<%=Page.ResolveUrl("~/images/Logo - registerd_small.jpg") %>" style="width: 175px;
                    height: 54px" border="0" alt="" />
            </div>
            <div style="text-align: center;">
                <asp:Label runat="server" ID="lblPropertyaddress"></asp:Label></div>
        </center>
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
        <table border="0" cellpadding="2" cellspacing="2" width="100%">
            <tr>
                <td align="center">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border-bottom: 1px solid #CCCCCC;">
                        <tr>
                            <td width="33%">
                                &nbsp;
                            </td>
                            <td width="33%" align="center">
                                <b>Extand Reservation Voucher
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
                    <table border="0" cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td style="vertical-align: top;" width="50%">
                                <table cellpadding="2" cellspacing="2" width="100%" border="0">
                                    <tr>
                                        <td>
                                            <asp:Literal ID="Literal14" runat="server" Text="Booking #"></asp:Literal>
                                        </td>
                                        <td>
                                            <b>
                                                <asp:Literal ID="ltrChVchrReservationNo" runat="server"></asp:Literal></b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="Literal16" runat="server" Text="Name"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal ID="litChVchrGuestName" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="Literal17" runat="server" Text="Mobile No."></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal ID="litChVchrMobileNo" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="Literal18" runat="server" Text="Email"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal ID="litChVchrEmail" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="100px">
                                            Folio #
                                        </td>
                                        <td width="250px">
                                            <asp:Literal ID="ltrChVchrFolioNo" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Check In
                                        </td>
                                        <td>
                                            <asp:Literal ID="ltrChVchrCheckInDate" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Check Out
                                        </td>
                                        <td>
                                            <asp:Literal ID="ltrChVchrCheckOutDate" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 153px;">
                                            <b>No. of Days Extended</b>
                                        </td>
                                        <td>
                                            <asp:Literal ID="litChvNoOfExtendedDays" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>New CheckOut Date</b>
                                        </td>
                                        <td>
                                            <asp:Literal ID="litchvNewCheckOutDate" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Adult/Child
                                        </td>
                                        <td>
                                            <asp:Literal ID="ltrChVchrAdultChild" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Rate card
                                        </td>
                                        <td>
                                            <asp:Literal ID="ltrChVchrRateCard" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Room Type
                                        </td>
                                        <td>
                                            <asp:Literal ID="ltrChVchrRoomType" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Room No.
                                        </td>
                                        <td>
                                            <asp:Literal ID="ltrChVchrRoomNo" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td style="border-left: 1px solid #CCCCCC;">
                            </td>
                            <td style="vertical-align: top;">
                                <table cellpadding="2" cellspacing="2" width="100%" border="0">
                                    <tr>
                                        <td colspan="2">
                                            <table width="100%">
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
                                                    <td style="padding: 0px; border-bottom: 1px solid #CCCCCC;" colspan="3">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Room Rent
                                                    </td>
                                                    <td align="center">
                                                        <asp:Literal ID="ltrChVchrNoOfDays" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right">
                                                        <asp:Literal ID="ltrChVchrRoomRent" runat="server"></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Taxes
                                                    </td>
                                                    <td align="center">
                                                        -
                                                    </td>
                                                    <td align="right">
                                                        <asp:Literal ID="ltrChVchrTaxes" runat="server"></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 0px; border-bottom: 1px solid #CCCCCC;" colspan="3">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Total Charges
                                                    </td>
                                                    <td align="center">
                                                        -
                                                    </td>
                                                    <td align="right">
                                                        <asp:Literal ID="ltrChVchrTotalCharges" runat="server"></asp:Literal>
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
                                                        <asp:Literal ID="ltrChVchrDeposit" runat="server"></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 0px; border-bottom: 1px solid #CCCCCC;" colspan="3">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Total Amount
                                                    </td>
                                                    <td align="center">
                                                        -
                                                    </td>
                                                    <td align="right">
                                                        <asp:Literal ID="ltrChVchrTotalAmount" runat="server"></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Paid Amount
                                                    </td>
                                                    <td align="center">
                                                        -
                                                    </td>
                                                    <td align="right">
                                                        <asp:Literal ID="ltrChVchrPaidAmount" runat="server"></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 0px; border-bottom: 1px solid #CCCCCC;" colspan="3">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Amount to Pay
                                                    </td>
                                                    <td align="center">
                                                        -
                                                    </td>
                                                    <td align="right">
                                                        <asp:Literal ID="ltrChVchrAmountToPay" runat="server"></asp:Literal>
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
                <td style="width: 780px;">
                    <hr />
                </td>
            </tr>
            <tr>
                <td colspan="4" align="left">
                    <asp:Label ID="lblChVchrHousingRules" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <br />
                    <br />
                    ______________________________
                    <br />
                    Front Desk Executive
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
