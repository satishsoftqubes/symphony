<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyInvoicePrint.aspx.cs"
    Inherits="SQT.Symphony.UI.Web.BackOffice.GUI.Invoice.CompanyInvoicePrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link id="Link1" href="~/Style/style.css" runat="server" rel="stylesheet" type="text/css" />
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
    <div class="box_form">
        <table cellpadding="0" cellspacing="0" width="100%" border="0">
            <tr>
                <td colspan="6" align="center">
                    <img src="<%=Page.ResolveUrl("~/images/Logo.jpg") %>" border="0" alt="" />
                </td>
            </tr>
            <tr>
                <td colspan="6" align="center" style="padding-bottom: 10px;">
                    <asp:Label runat="server" ID="lblPropertyaddress"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                </td>
            </tr>
            <tr>
                <td colspan="6">
                </td>
            </tr>
            <tr>
                <td colspan="6">
                </td>
            </tr>
            <tr>
                <td>
                    <b>Bill No.</b>
                </td>
                <td>
                    <b>
                        <asp:Literal ID="ltrBillNo" runat="server"></asp:Literal></b>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    <b>Date</b>
                </td>
                <td>
                    <b>
                        <asp:Literal ID="ltrTopRightDate" runat="server"></asp:Literal></b>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2" style="border-left: 1px solid Gray; border-top: 1px solid Gray; border-bottom: 1px solid Gray;">
                    <b>Reservation Info.</b>
                </td>
                <td colspan="2" style="border-left: 1px solid Gray; border-top: 1px solid Gray; border-bottom: 1px solid Gray;
                    border-right: 1px solid Gray;">
                    <b>Guest Info.</b>
                </td>
                <td colspan="2" style="border-top: 1px solid Gray; border-bottom: 1px solid Gray;
                    border-right: 1px solid Gray;">
                    <b>Company Info.</b>
                </td>
            </tr>
            <tr>
                <td width="80px" style="padding-top: 12px; padding-bottom: 12px; border-left: 1px solid Gray;
                    border-bottom: 1px solid Gray;">
                    Res. #
                </td>
                <td width="200px" style="border-right: 1px solid Gray; border-bottom: 1px solid Gray;">
                    :&nbsp;<asp:Literal ID="ltrReservationNo" runat="server"></asp:Literal>
                </td>
                <td width="80px" style="border-bottom: 1px solid Gray;">
                    Guest Name
                </td>
                <td width="200px" style="border-right: 1px solid Gray; border-bottom: 1px solid Gray;">
                    :&nbsp;<asp:Literal ID="ltrGuestName" runat="server"></asp:Literal>
                </td>
                <td width="100px" style="border-bottom: 1px solid Gray;">
                    Company
                </td>
                <td width="200px" style="border-right: 1px solid Gray; border-bottom: 1px solid Gray;">
                    :&nbsp;<asp:Literal ID="ltrCompanyName" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 12px; padding-bottom: 12px; border-left: 1px solid Gray;
                    border-bottom: 1px solid Gray;">
                    Room No.
                </td>
                <td style="border-right: 1px solid Gray; border-bottom: 1px solid Gray;">
                    :&nbsp;<asp:Literal ID="ltrRoomNo" runat="server"></asp:Literal>
                </td>
                <td style="border-bottom: 1px solid Gray;">
                    Check In
                </td>
                <td style="border-right: 1px solid Gray; border-bottom: 1px solid Gray; border-bottom: 1px solid Gray;">
                    :&nbsp;<asp:Literal ID="ltrCheckInDate" runat="server"></asp:Literal>
                </td>
                <td rowspan="3" style="vertical-align: top; border-bottom: 1px solid Gray;">
                    Address
                </td>
                <td rowspan="3" style="vertical-align: top; border-right: 1px solid Gray; border-bottom: 1px solid Gray;">
                    :&nbsp;<asp:Label ID="ltrCompanyAddressL" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 12px; padding-bottom: 12px; border-left: 1px solid Gray;
                    border-bottom: 1px solid Gray;">
                    Room Type
                </td>
                <td style="border-right: 1px solid Gray; border-bottom: 1px solid Gray;">
                    :&nbsp;<asp:Literal ID="ltrRoomType" runat="server"></asp:Literal>
                </td>
                <td style="border-bottom: 1px solid Gray;">
                    Check Out
                </td>
                <td style="border-right: 1px solid Gray; border-bottom: 1px solid Gray;">
                    :&nbsp;<asp:Literal ID="ltrCheckOutDate" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 12px; padding-bottom: 12px; border-left: 1px solid Gray;
                    vertical-align: top; border-bottom: 1px solid Gray;">
                    Rate Card
                </td>
                <td style="padding-top: 12px; padding-bottom: 12px; border-right: 1px solid Gray;
                    border-bottom: 1px solid Gray;">
                    :&nbsp;<asp:Literal ID="ltrRateCard" runat="server"></asp:Literal>
                </td>
                <td style="padding-top: 12px; padding-bottom: 12px; border-bottom: 1px solid Gray;">
                    Billing Instr.
                </td>
                <td style="border-right: 1px solid Gray; border-bottom: 1px solid Gray;">
                    :&nbsp;<asp:Literal ID="ltrBillingInstruction" runat="server" Text="Part bill to Company"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 12px; padding-bottom: 12px; border-left: 1px solid Gray;
                    border-bottom: 1px solid Gray;">
                    &nbsp;
                </td>
                <td style="border-right: 1px solid Gray; border-bottom: 1px solid Gray;">
                    &nbsp;
                </td>
                <td style="border-bottom: 1px solid Gray;">
                    &nbsp;
                </td>
                <td style="border-right: 1px solid Gray; border-bottom: 1px solid Gray;">
                    &nbsp;
                </td>
                <td style="border-bottom: 1px solid Gray;">
                    Billing Period
                </td>
                <td style="border-right: 1px solid Gray; border-bottom: 1px solid Gray;">
                    :&nbsp;<asp:Literal ID="ltrBillingPeriod" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td colspan="6" style="padding-top: 30px; padding-bottom: 30px; border-bottom: 1px solid Gray;
                    border-left: 1px solid Gray; border-right: 1px solid Gray;">
                    <div style="width: 60%; margin-left: 150px;">
                        <table cellpadding="0" cellspacing="0" width="100%" border="0" style="border: 1px solid Gray;">
                            <tr>
                                <td style="text-align: left; border-bottom: 1px solid Gray; border-right: 1px solid Gray;">
                                    Particulars
                                </td>
                                <td style="text-align: right; border-bottom: 1px solid Gray;">
                                    Amount
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-top: 12px; padding-bottom: 12px; text-align: left; border-bottom: 1px solid Gray;
                                    border-right: 1px solid Gray;">
                                    Room Rent
                                </td>
                                <td style="padding-top: 12px; padding-bottom: 12px; text-align: right; border-bottom: 1px solid Gray;">
                                    <asp:Literal ID="ltrRoomRent" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-top: 12px; padding-bottom: 12px; text-align: left; border-bottom: 1px solid Gray;
                                    border-right: 1px solid Gray;">
                                    &nbsp;
                                </td>
                                <td style="padding-top: 12px; padding-bottom: 12px; text-align: right; border-bottom: 1px solid Gray;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-top: 12px; padding-bottom: 12px; text-align: left; border-bottom: 1px solid Gray;
                                    border-right: 1px solid Gray;">
                                    Total
                                </td>
                                <td style="padding-top: 12px; padding-bottom: 12px; text-align: right; border-bottom: 1px solid Gray;">
                                    <asp:Literal ID="litTotal" runat="server"></asp:Literal>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center" style="padding-top: 150px;">
                    _______________
                </td>
                <td>
                    &nbsp;
                </td>
                <td align="right">
                    &nbsp;
                </td>
                <td colspan="2" align="center" style="padding-top: 150px;">
                    _______________
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    Authorized Person
                </td>
                <td>
                    &nbsp;
                </td>
                <td align="right">
                    &nbsp;
                </td>
                <td colspan="2" align="center">
                    Guest
                </td>
            </tr>
            <tr>
                <td colspan="6" align="center">
                    <div id="dvToHide" style="padding-bottom: 10px; padding-top: 10px; padding-left: 10px;
                        padding-right: 10px;" align="center">
                        <asp:Button ID="btnPrintInvoice" runat="server" Style="display: inline; padding-right: 10px;"
                            Text="Print" OnClientClick="fnPrint();" />
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div class="clear">
    </div>
    </form>
</body>
</html>
