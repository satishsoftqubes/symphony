<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCancellationVoucher.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation.CtrlCancellationVoucher" %>
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
    function openPrintWindow() {
        var varReservationID = document.getElementById('<%= hdnReservationID.ClientID %>').value;
        var varPaidAmount = document.getElementById('<%= hdnPaidAmount.ClientID %>').value;
        var varCancellationCharge = document.getElementById('<%= hdnCancellationCharge.ClientID %>').value;
        window.open("CancellationVoucher.aspx?ResID=" + varReservationID + "&PaidAmount=" + varPaidAmount + "&CancellationCharge=" + varCancellationCharge + "", "CancellationVouche", "height=500,width=400,status=1,toolbar=no,menubar=no,scrollbars=1,location=0");
    }
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<asp:HiddenField ID="hdnReservationID" runat="server" />
<asp:HiddenField ID="hdnPaidAmount" runat="server" />
<asp:HiddenField ID="hdnCancellationCharge" runat="server" />
<center>
    <div style="margin: 0; height: 60px; text-align: center;">
        <img src="<%=Page.ResolveUrl("~/images/Logo - registerd_small.jpg") %>" style="width: 175px; height:54px"
            border="0" alt="" />
    </div>
    <div style="text-align: center;">
        <asp:Label runat="server" ID="lblPropertyaddress"></asp:Label></div>
</center>
<table width="100%">
    <tr>
        <td align="left">
            <table border="0" cellpadding="2" cellspacing="2" width="100%">
                <tr>
                    <td align="center">
                        <b>
                            <asp:Literal ID="litPaymentRecipt" runat="server" Text="Cancellation Voucher"></asp:Literal></b>
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <table width="100%">
                            <tr>
                                <td>
                                    Name
                                </td>
                                <td>
                                    :&nbsp;<asp:Literal ID="ltrCancVchrGuestName" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Booking #
                                </td>
                                <td>
                                    :&nbsp;<asp:Literal ID="ltrCancVchrBookingNo" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Check In Date
                                </td>
                                <td>
                                    :&nbsp;<asp:Literal ID="ltrCancVchrCheckInDate" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Check Out Date
                                </td>
                                <td>
                                    :&nbsp;<asp:Literal ID="ltrCancVchrCheckOutDate" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Cancellation Date
                                </td>
                                <td>
                                    :&nbsp;<asp:Literal ID="ltrCancVchrCancellationDate" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td width="120px">
                                    Paid Amount
                                </td>
                                <td>
                                    :&nbsp;<asp:Literal ID="ltrCancVchrPaidAmount" runat="server" SkinID="nowidth"></asp:Literal>
                                    <asp:Literal ID="ltrCancVchrPaidAmountsMOP" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td width="130px">
                                    Cancellation Charge
                                </td>
                                <td>
                                    :&nbsp;<asp:Literal ID="ltrCancVchrCancellationCharge" runat="server" SkinID="nowidth"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td width="110px">
                                    Refund Amount
                                </td>
                                <td>
                                    :&nbsp;<asp:Literal ID="ltrCancVchrRefundedAmount" runat="server" SkinID="nowidth"></asp:Literal>
                                    <asp:Literal ID="ltrCancVchrRefundedAmountsMOP" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <%--<tr>
                                <td>
                                    Transaction No.
                                </td>
                                <td>
                                    :&nbsp;60782546
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Date
                                </td>
                                <td>
                                    :&nbsp;<asp:Literal ID="ltrCancVchrDateAndTime" runat="server"></asp:Literal>
                                </td>
                            </tr>--%>
                            <tr>
                                <td>
                                    Refund By
                                </td>
                                <td>
                                    :&nbsp;<asp:Literal ID="ltrCancVchrRefundedBy" runat="server"></asp:Literal>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btnPrint" runat="server" Style="display: inline;" Text="Print" OnClientClick="openPrintWindow();" />
                        <asp:Button ID="Button1" runat="server" Style="display: inline;" Text="Email" Visible="false" />
                        <asp:Button ID="Button2" runat="server" Style="display: inline;" Text="SMS" Visible="false" />
                        <asp:Button ID="Button4" runat="server" Style="display: inline;" Text="Email & SMS"
                            Visible="false" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
