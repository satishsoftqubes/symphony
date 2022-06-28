<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpgradeDownGradePrint.aspx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Guest.UpgradeDownGradePrint" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>

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
        function fnDisplayCatchErrorMessage() {
            document.getElementById('errormessage').style.display = "block";
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 800px; margin: 0; height: 60px; text-align: center;">
        <img src="<%=Page.ResolveUrl("~/images/Logo - registerd_small.jpg") %>" style="width: 175px;
            height: 54px" border="0" alt="" />
    </div>
    <div style="text-align: center; width: 800px;">
        <asp:Label runat="server" ID="lblPropertyaddress" Style="font-size: 13px; font-weight: bold;"></asp:Label></div>
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
                            <td width="33%" align="center" style="font-size: 13px;">
                                <b>Upgrade/Downgrade Room Voucher
                                    <asp:HiddenField ID="hdnReservationID" runat="server" />
                                </b>
                            </td>
                            <td align="right" width="33%">
                                <asp:Literal ID="litCurrentDate1" runat="server"></asp:Literal>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="90px" style="font-size: 13px; font-weight: bold;">
                                <asp:Literal ID="litGuestName" runat="server" Text="Name"></asp:Literal>
                            </td>
                            <td width="217px" style="font-size: 13px;">
                                :&nbsp;<asp:Literal ID="litDispGuestName" runat="server"></asp:Literal>
                            </td>
                            <td style="font-size: 13px; font-weight: bold;">
                                <asp:Literal ID="litBookingNo" runat="server" Text="Booking #"></asp:Literal>
                            </td>
                            <td style="font-size: 13px; font-weight: normal !important;">
                                :&nbsp;<b><asp:Literal ID="litDispBookingNo" runat="server"></asp:Literal></b>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-size: 13px; font-weight: bold;">
                                <asp:Literal ID="litNoOfDaysaffectd" runat="server" Text="No of Days Affected"></asp:Literal>
                            </td>
                            <td style="font-size: 13px;">
                                :&nbsp;<asp:Literal ID="litDispNoOfDaysAffected" runat="server"></asp:Literal>
                            </td>
                            <td width="180px" style="font-size: 13px; font-weight: bold;">
                                <asp:Literal ID="litCurrentDate" runat="server" Text="Upgrade/Downgrade Date"></asp:Literal>
                            </td>
                            <td style="font-size: 13px; font-weight: normal !important;">
                                :&nbsp;<b><asp:Literal ID="litDispCurrentDate" runat="server"></asp:Literal></b>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-size: 13px; font-weight: bold;">
                                <asp:Literal ID="litCheckInDate" runat="server" Text="Check In Date"></asp:Literal>
                            </td>
                            <td style="font-size: 13px;">
                                :&nbsp;<asp:Literal ID="litDispCheckInDate" runat="server"></asp:Literal>
                            </td>
                            <td style="font-size: 13px; font-weight: bold;">
                                <asp:Literal ID="litCheckoutDate" runat="server" Text="Check Out Date"></asp:Literal>
                            </td>
                            <td style="font-size: 13px;">
                                :&nbsp;<asp:Literal ID="litDispCheckoutDate" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="border-bottom: 1px solid #CCCCCC;">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 150px; font-size: 13px; font-weight: bold;">
                                <asp:Literal ID="litOldRoomType" runat="server" Text="Previous Room Type"></asp:Literal>
                            </td>
                            <td style="font-size: 13px;">
                                :&nbsp;<asp:Literal ID="litDispOldRoomType" runat="server"></asp:Literal>
                            </td>
                            <td style="font-size: 13px; font-weight: bold;">
                                <asp:Literal ID="litNewRoomType" runat="server" Text="New Room Type"></asp:Literal>
                            </td>
                            <td style="font-size: 13px;">
                                :&nbsp;<asp:Literal ID="litDispNewRoomType" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-size: 13px; font-weight: bold;">
                                <asp:Literal ID="litOldRoomNo" runat="server" Text="Previous Room No"></asp:Literal>
                            </td>
                            <td style="font-size: 13px;">
                                :&nbsp;<asp:Literal ID="litDispOldRoomNo" runat="server"></asp:Literal>
                            </td>
                            <td style="font-size: 13px; font-weight: bold;">
                                <asp:Literal ID="litNewRoomNo" runat="server" Text="New Room No"></asp:Literal>
                            </td>
                            <td style="font-size: 13px;">
                                :&nbsp;<asp:Literal ID="litDispNewRoomNo" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="border-bottom: 1px solid #CCCCCC;">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                            </td>
                        </tr>
                        <tr>
                            <td style="font-size: 13px; font-weight: bold; width: 194px;">
                                <asp:Literal ID="litAvailabelBalance" runat="server" Text="Available Balance"></asp:Literal>
                            </td>
                            <td style="font-size: 13px; width: 173px;">
                                <div style="text-align: right; width: 60px;">
                                    <asp:Literal ID="litDispPreviousTotalRent" runat="server" Text="0.00"></asp:Literal>
                                </div>
                            </td>
                            <td style="font-size: 13px; font-weight: bold;">
                                <asp:Literal ID="litPreviousDeposit" runat="server" Text="Previous Deposit"></asp:Literal>
                            </td>
                            <td style="font-size: 13px;">
                                <div style="text-align: right; width: 60px;">
                                    <asp:Literal ID="litDispPreviousTotalDeposit" runat="server" Text="0.00"></asp:Literal>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-size: 13px; font-weight: bold;">
                                <asp:Literal ID="litNewRoomRent" runat="server" Text="New Room Rent"></asp:Literal>
                            </td>
                            <td style="font-size: 13px;">
                                <div style="text-align: right; width: 60px;">
                                    <asp:Literal ID="litDispNewTotalRent" runat="server" Text="0.00"></asp:Literal>
                                </div>
                            </td>
                            <td style="font-size: 13px; font-weight: bold;">
                                <asp:Literal ID="litNewDeposit" runat="server" Text="New Deposit"></asp:Literal>
                            </td>
                            <td style="font-size: 13px;">
                                <div style="text-align: right; width: 60px;">
                                    <asp:Literal ID="litDispNewTotalDeposit" runat="server" Text="0.00"></asp:Literal>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-size: 13px; font-weight: bold;">
                                <asp:Literal ID="litRoomBalanceDue" runat="server" Text="Balance (Due/Credit)"></asp:Literal>
                            </td>
                            <td style="font-size: 13px;">
                                <div style="text-align: right; width: 60px;">
                                    <asp:Literal ID="litDispRoomBalanceDueCredit" runat="server" Text="0.00"></asp:Literal>
                                </div>
                            </td>
                            <td style="font-size: 13px; font-weight: bold;">
                                <asp:Literal ID="litDepositBalanceDue" runat="server" Text="Balance (Due/Credit)"></asp:Literal>
                            </td>
                            <td style="font-size: 13px;">
                                <div style="text-align: right; width: 60px;">
                                    <asp:Literal ID="litDispDepositBalanceDueCredit" runat="server" Text="0.00"></asp:Literal>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                            </td>
                        </tr>
                        <tr>
                            <td style="font-size: 13px; font-weight: bold; text-align: right;" colspan="2">
                                <asp:Literal ID="litRoomRentDue" runat="server" Text="Room Rent(Credit/Due)"></asp:Literal>
                            </td>
                            <td style="font-size: 13px;">
                                <div style="text-align: right; width: 100px;">
                                    <asp:Literal ID="litDispRoomRentDue" runat="server" Text="0.00"></asp:Literal>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-size: 13px; font-weight: bold; text-align: right;" colspan="2">
                                <asp:Literal ID="litDepositDue" runat="server" Text="Deposit(Credit/Due)"></asp:Literal>
                            </td>
                            <td style="font-size: 13px;">
                                <div style="text-align: right; width: 100px;">
                                    <asp:Literal ID="litDispDepositDue" runat="server" Text="0.00"></asp:Literal>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-size: 18px; font-weight: bold; text-align: right;" colspan="2">
                                <asp:Literal ID="litNetBalance" runat="server" Text="Net Balance(Credit/Due)"></asp:Literal>
                            </td>
                            <td style="font-size: 13px;">
                                <div style="text-align: right; width: 100px;">
                                    <asp:Literal ID="litDispNetBalance" runat="server" Text="0.00"></asp:Literal>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <br />
                                ______________________________
                                <br />
                                <span style="font-size: 17px;">(Frontdesk Executive)</span>
                            </td>
                            <td>
                                <br />
                                ______________________________
                                <br />
                                <span style="font-size: 17px;">(Cashier)</span>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <div id="errormessage" class="clear">
        <uc1:MsgBox ID="MessageBox" runat="server" />
    </div>
    </form>
</body>
</html>
