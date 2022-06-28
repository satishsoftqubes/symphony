<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyBillPrint.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Reservation.CompanyBillPrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function fnPrint() {
            document.getElementById('dvToHide').style.display = 'none';
            window.print();
            window.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="border: 1px solid black; width:800px; font-family:Calibri; font-size:small;">
        <table width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td align="center">
                    <div id="dvToHide" style="padding-bottom: 10px; padding-top: 10px; padding-left: 10px;
                        padding-right: 10px;" align="center">
                        <asp:Button ID="btnPrintInvoice" runat="server" Style="display: inline;"
                            Text="Print" OnClientClick="fnPrint();" />
                    </div>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table width="100%" cellpadding="1" cellspacing="1">
                        <tr>
                            <td align="center">
                                <img src="../../images/logo.jpg" alt="" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <b>A UNIT OF SIERRA PROJECTS (P) LTD.</b>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Literal ID="ltrUniworldAddress" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <b>E:</b> <asp:Literal ID="ltrUniworldEmail" runat="server"></asp:Literal> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>W:</b> <asp:Literal ID="ltrUniworldURL" runat="server"></asp:Literal> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>M:</b> <asp:Literal ID="ltrUniworldMobileNo" runat="server"></asp:Literal>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center" style="border-bottom: 1px solid black; padding-top:5px; padding-bottom:5px;">
                    <b>INVOICE CUM CHECK-OUT VOUCHER</b>
                </td>
            </tr>
            <tr>
                <td style="border-bottom: 1px solid black;">
                    <table width="100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="50%" valign="top" style="border-right: 1px solid black;">
                                <table width="100%" cellpadding="1" cellspacing="1">
                                    <tr>
                                        <td> &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="padding-left:5px;">
                                            <b><asp:Literal ID="ltrCompanyName" runat="server"></asp:Literal></b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height:70px; padding-left:5px;" valign="top">
                                            <asp:Literal ID="ltrCompanyAddress" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-left:5px;">
                                            <b>Guest:</b> <asp:Literal ID="ltrGuestName" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="50%">
                                <table width="100%" cellpadding="2" cellspacing="2">
                                    <tr>
                                        <td style="padding-left:5px;" width="65px">
                                            <b>Bill No.:</b>
                                        </td>
                                        <td width="140px">
                                            <asp:Literal ID="ltrBillNo" runat="server"></asp:Literal>
                                        </td>
                                        <td width="70px">
                                            <b>Date:</b>
                                        </td>
                                        <td>
                                            <asp:Literal ID="ltrTodaysDate" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-left:5px;">
                                            <b>Res # :</b>
                                        </td>
                                        <td>
                                            <asp:Literal ID="ltrReservationNo" runat="server"></asp:Literal>
                                        </td>
                                        <td>
                                            <b>PAX:</b>
                                        </td>
                                        <td>
                                            <asp:Literal ID="ltrPax" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-left:5px;">
                                            <b>Arr. Date:</b>
                                        </td>
                                        <td>
                                            <asp:Literal ID="ltrArrivalDate" runat="server"></asp:Literal>
                                        </td>
                                        <td>
                                            <b>Dep. Date:</b>
                                        </td>
                                        <td>
                                            <asp:Literal ID="ltrDepartureDate" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-left:5px;">
                                            <b>Nights:</b>
                                        </td>
                                        <td>
                                            <asp:Literal ID="ltrNoOfNights" runat="server"></asp:Literal>
                                        </td>
                                        <td>
                                            <b>Room No:</b>
                                        </td>
                                        <td>
                                            <asp:Literal ID="ltrRoomNo" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-left:5px;">
                                            <b>Time IN:</b>
                                        </td>
                                        <td>
                                            <asp:Literal ID="ltrCheckInTime" runat="server"></asp:Literal>
                                        </td>
                                        <td>
                                            <b>Time OUT:</b>
                                        </td>
                                        <td>
                                            <asp:Literal ID="ltrCheckOutTime" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-top:15px; padding-bottom:10px; padding-left:5px;">
                                            <b>Billing:</b>
                                        </td>
                                        <td style="padding-top:10px; padding-bottom:5px;" colspan="3" align="left">
                                            <asp:Literal ID="ltrBillingInstruction" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="border-bottom: 1px solid black;">
                    <table width="100%" cellpadding="0" cellspacing="0">
                        <tr >
                            <td width="180px" style="padding:5px; border-bottom: 1px solid black; border-right: 1px solid black;">
                                Room Type
                            </td>
                            <td width="216px" style="padding:5px; border-bottom: 1px solid black; border-right: 1px solid black;">
                                Description
                            </td>
                            <td width="100px" style="padding:5px; border-bottom: 1px solid black; border-right: 1px solid black;">
                                Nights
                            </td>
                            <td width="140px" style="padding:5px; border-bottom: 1px solid black; border-right: 1px solid black;">
                                Rate
                            </td>
                            <td width="145px" style="padding:5px; border-bottom: 1px solid black;">
                                Amount
                            </td>
                        </tr>
                        <tr>
                            <td style="padding:5px; padding-top:15px; border-right: 1px solid black;">
                                <asp:Literal ID="ltrRoomType" runat="server"></asp:Literal>
                            </td>
                            <td style="padding:5px; padding-top:15px; border-right: 1px solid black;">
                                Room Rent and Service Charges
                            </td>
                            <td style="padding:5px; padding-top:15px; border-right: 1px solid black;">
                                <asp:Literal ID="ltrNoOfNightsInGrid" runat="server"></asp:Literal>
                            </td>
                            <td style="padding:5px; padding-top:15px; border-right: 1px solid black;">
                                <asp:Literal ID="ltrRatePerNight" runat="server"></asp:Literal>
                            </td>
                            <td style="padding:5px; padding-top:15px; ">
                                <asp:Literal ID="ltrTotalRoomRate" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding:5px; border-right: 1px solid black;">
                            </td>
                            <td style="padding:5px; border-right: 1px solid black;">
                            </td>
                            <td style="padding:5px; padding-top:200px; padding-bottom:80px; border-right: 1px solid black;">
                                Luxury Tax
                            </td>
                            <td style="padding:5px; border-right: 1px solid black;">
                            </td>
                            <td style="padding:5px; padding-top:200px; padding-bottom:80px; border-bottom: 1px solid black;">
                                <asp:Literal ID="ltrLuxuryTax" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding:5px; border-right: 1px solid black;">
                            </td>
                            <td style="padding:5px; border-right: 1px solid black;">
                            </td>
                            <td style="padding:5px; border-right: 1px solid black;">
                                <b>Total</b>
                            </td>
                            <td style="padding:5px; border-right: 1px solid black;">
                            </td>
                            <td style="padding:5px; ">
                                <b><asp:Literal ID="ltrTotalBillAmount" runat="server"></asp:Literal></b>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="padding-left:5px; padding-top:2px;">
                    The above amount is inclusive of Service tax.
                </td>
            </tr>
            <tr>
                <td style="border-bottom: 1px solid black;">
                    <table width="100%" cellpadding="1" cellspacing="1">
                        <tr>
                            <td style="padding-left:5px;" align="left">
                                TIN: 29530875582
                            </td>
                            <td>
                            
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left:5px;" align="left">
                                PAN: AAMCS6803J
                            </td>
                            <td>
                            
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left:5px; padding-bottom:5px;" align="left">
                                ST: AAMCS6803JSD001
                            </td>
                            <td style="padding-right:5px; padding-bottom:5px;" align="right">
                            Cheques to be made in Favour of "SIERRA PROJECTS PVT. LTD".
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="border-bottom: 1px solid black; padding-top:10px; padding-bottom:150px; padding-left:5px;">
                    <b>I agree with the changes mentioned herein</b>
                </td>
            </tr>
            <tr>
                <td>
                    <table width="100%" cellpadding="3" cellspacing="3">
                        <tr>
                            <td style="padding-left:50px;">
                                <b>Guest Signature</b>
                            </td>
                            <td align="right" style="padding-right:100px;">
                                <b>Front Office Executive</b>
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
