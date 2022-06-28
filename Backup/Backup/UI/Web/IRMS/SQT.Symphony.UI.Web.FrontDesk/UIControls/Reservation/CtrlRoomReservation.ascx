<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlRoomReservation.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation.CtrlRoomReservation" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<%@ Register Src="~/UIControls/CommonControls/CtrCommonGuestInfo.ascx" TagName="CommonGuestInfo"
    TagPrefix="uc2" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonAddServices.ascx" TagName="AddServices"
    TagPrefix="ucCtrlAddServices" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonHouseKeeping.ascx" TagName="HouseKeeping"
    TagPrefix="ucCtrlHouseKeeping" %>
<%@ Register Src="../CommonControls/CtrlCommonStayInformation.ascx" TagName="CtrlCommonStayInformation"
    TagPrefix="uc3" %>
<%@ Register Src="../Folio/CtrlCommonAddDeposit.ascx" TagName="CtrlCommonAddDeposit"
    TagPrefix="uc4" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonCheckIn.ascx" TagName="CheckIn"
    TagPrefix="ucCtrlCheckIn" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonOterhInformation.ascx" TagName="CommonOterhInformation"
    TagPrefix="ucCtrlCommonOterhInformation" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonVoucherDetails.ascx" TagName="VoucherDetails"
    TagPrefix="ucCtrlVoucherDetails" %>
<%@ Register Src="~/UIControls/Folio/CtrlDepositList.ascx" TagName="DepositList"
    TagPrefix="ucCtrlDepositList" %>
<script type="text/javascript" language="javascript">
    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

</script>
<asp:UpdatePanel ID="updRoomReservation" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="content" style="padding-left: 0px; width: 66.66%">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                <asp:Literal ID="litMainHeader" runat="server" Text="OOM RESERVATION"></asp:Literal>
                                <a style="text-align:left;float:left;" href="../../GUI/Reservation/Reservation.aspx">R</a>
                            </td>
                            <td class="boxtopright">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="boxleft">
                            </td>
                            <td>
                                <div class="box_form">
                                    <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                        <tr>
                                            <td width="48%" style="vertical-align: top; border-right: 1px solid #ccccce;">
                                                <uc3:CtrlCommonStayInformation ID="CtrlCommonStayInformation1" runat="server" />
                                            </td>
                                            <td style="vertical-align: top;">
                                                <uc2:CommonGuestInfo ID="ucCommonGuestInfo" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <table cellpadding="2" cellspacing="2" width="100%">
                                                    <tr>
                                                        <td colspan="2">
                                                            <div style="float: left; display: inline-block;">
                                                                <asp:Button ID="btnCheckiIn" Style="float: left; margin-left: 5px;" runat="server"
                                                                    Text="Check In" OnClick="lnkCheckiIn_OnClick" />
                                                                <asp:Button ID="btnDeposit" Style="float: left; margin-left: 5px;" runat="server"
                                                                    Text="Deposit" OnClick="lnkDeposit_OnClick" />
                                                                <asp:Button ID="btnReRoute" Visible="false" Style="float: left; margin-left: 5px;" runat="server"
                                                                    Text="ReRoute" OnClick="lnkReRoute_OnClick" />
                                                                <asp:Button ID="btnVoucherDetail" Visible="false" Style="float: left; margin-left: 5px;" runat="server"
                                                                    Text="VoucherDetail" OnClick="lnkVoucherDetail_OnClick" />
                                                                <asp:Button ID="btnFolio" Style="float: left; margin-left: 5px;" runat="server" Text="Folio"
                                                                    OnClick="lnkFolio_OnClick" />
                                                            </div>
                                                            <%--<div style="float: left; margin-left: 5px;">
                                                                <ul class="buttonnav">
                                                                    <li><a href="#">Print</a>
                                                                        <ul>
                                                                            <li>
                                                                                <asp:LinkButton ID="lnkConfirmation" runat="server" Text="Confirmation"></asp:LinkButton></li>
                                                                            <li>
                                                                                <asp:LinkButton ID="lnkSigninSheet" runat="server" Text="Signin Sheet"></asp:LinkButton></li>
                                                                        </ul>
                                                                    </li>
                                                                </ul>
                                                            </div>--%>
                                                            <div style="float: right; display: inline-block;">
                                                                <asp:Button ID="btnCancel" runat="server" CausesValidation="false" ImageUrl="~/images/cancle.png"
                                                                    Style="float: right; margin-left: 5px;" Text="Cancel" OnClick="btnCancel_Click" />
                                                                <asp:Button ID="btnSave" runat="server" CausesValidation="true" Text="Save" ImageUrl="~/images/save.png"
                                                                    Style="float: right; margin-left: 5px;" OnClick="btnSave_Click" />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                            <td class="boxright">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="boxbottomleft">
                                &nbsp;
                            </td>
                            <td class="boxbottomcenter">
                                &nbsp;
                            </td>
                            <td class="boxbottomright">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <div class="clear_divider">
                    </div>
                    <div class="clear">
                    </div>
                </td>
            </tr>
        </table>
        <ucCtrlAddServices:AddServices ID="ctrlCommonAddServices" runat="server" OnbtnAddServicesCallParent_Click="btnAddServicesCallParent_Click" />
        <ucCtrlHouseKeeping:HouseKeeping ID="ctrlCommonHouseKeeping" runat="server" />
        <ajx:ModalPopupExtender ID="mpeOtherInfo" runat="server" TargetControlID="hdnOtherInfo"
            PopupControlID="pnlOtherInfo" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnOtherInfo" runat="server" />
        <asp:Panel ID="pnlOtherInfo" runat="server" Width="650px" Style="display: none;">
            <ucCtrlCommonOterhInformation:CommonOterhInformation ID="ctrlCommonOterhInformation"
                runat="server" />
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpeVoucherDetails" runat="server" TargetControlID="hdnVoucherDetails"
            PopupControlID="pnlVoucherDetails" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnVoucherDetails" runat="server" />
        <asp:Panel ID="pnlVoucherDetails" runat="server" Width="500px" Style="display: none;">
            <ucCtrlVoucherDetails:VoucherDetails ID="CommonCtrlVoucherDetails" runat="server" />
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpeCheckIn" runat="server" TargetControlID="hdnCheckIn"
            PopupControlID="pnlCheckIn" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnCheckIn" runat="server" />
        <asp:Panel ID="pnlCheckIn" runat="server" Width="800px" Style="display: none;">
            <ucCtrlCheckIn:CheckIn ID="ctrlCommonCheckIn" runat="server" OnbtnCheckInCallParent_Click="btnCheckInCallParent_Click" />
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpeDepositList" runat="server" TargetControlID="hdnDepositList"
            PopupControlID="pnlDepositList" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnDepositList" runat="server" />
        <asp:Panel ID="pnlDepositList" runat="server" Width="900px" Style="display: none;">
            <ucCtrlDepositList:DepositList ID="CtrlDepositList" runat="server" OnbtnDepositListCallParent_Click="btnDepositListCallParent_Click" />
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpeReservatinoVoucher" runat="server" TargetControlID="hdnReservationVoucher"
            PopupControlID="pnlReservatinoVoucher" CancelControlID="btnCnacelPrint" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnReservationVoucher" runat="server" />
        <asp:Panel ID="pnlReservatinoVoucher" runat="server" Width="700px">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="litCardInfo" runat="server" Text="Reservation Voucher"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table border="0" cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td align="left">
                                <table width="100%" border="0" cellpadding="2" cellspacing="2">
                                    <tr>
                                        <td align="center" colspan="4">
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td width="33%">
                                                        &nbsp;
                                                    </td>
                                                    <td width="33%" align="center">
                                                        <b>Reservation Voucher</b>
                                                    </td>
                                                    <td align="right" width="33%">
                                                        08-09-2012 11:35 AM
                                                    </td>
                                                </tr>
                                            </table>
                                            <hr />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="litName" runat="server" Text="Name"></asp:Literal>
                                        </td>
                                        <td>
                                            :&nbsp;Mr. Mahesh Ojha
                                        </td>
                                        <td>
                                            <asp:Literal ID="litBookingNo" runat="server" Text="Booking #"></asp:Literal>
                                        </td>
                                        <td>
                                            :&nbsp;3014046
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="litMobileNo" Text="Mobile No." runat="server"></asp:Literal>
                                        </td>
                                        <td>
                                            :&nbsp;+91 9825568956
                                        </td>
                                        <td>
                                            <asp:Literal ID="litEmail" runat="server" Text="Email ID"></asp:Literal>
                                        </td>
                                        <td>
                                            :&nbsp;mahesh@gmail.com
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="litCheckingDate" runat="server" Text="Check In Date"></asp:Literal>
                                        </td>
                                        <td>
                                            :&nbsp;01-09-2012
                                        </td>
                                        <td>
                                            <asp:Literal ID="litCheckoutDate" runat="server" Text="Check Out Date"></asp:Literal>
                                        </td>
                                        <td>
                                            :&nbsp;31-10-2012
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="litNoOfNights" runat="server" Text="No of Nights"></asp:Literal>
                                        </td>
                                        <td>
                                            :&nbsp;60
                                        </td>
                                        <td>
                                            <asp:Literal ID="Literal1" runat="server" Text="No of Guests"></asp:Literal>
                                        </td>
                                        <td>
                                            :&nbsp;1
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="litRateCardType" runat="server" Text="Rate Card Type"></asp:Literal>
                                        </td>
                                        <td>
                                            :&nbsp;Standard Monthly Rate Card
                                        </td>
                                        <td>
                                            <asp:Literal ID="litRoomType" runat="server" Text="Room Type"></asp:Literal>
                                        </td>
                                        <td>
                                            :&nbsp;Standard Non A/c - Double Share
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="litStatus" runat="server" Text="Booking Status"></asp:Literal>
                                        </td>
                                        <td>
                                            :&nbsp;Provisional
                                        </td>
                                        <td>
                                            <%--Is Complimentory only if reservation is complementory--%>
                                            <%--<asp:Literal ID="Literal2" runat="server" Text="Is Complementary"></asp:Literal>--%>
                                            Valid Upto
                                        </td>
                                        <td>
                                            :&nbsp;15-09-2012
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
                                                                <td>
                                                                    <b></b>
                                                                </td>
                                                                <td>
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
                                                                <td>
                                                                    90 (days)
                                                                </td>
                                                                <td>
                                                                    15000.00
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    S. Tax
                                                                </td>
                                                                <td>
                                                                    -
                                                                </td>
                                                                <td>
                                                                    1500.00
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    Other Tax
                                                                </td>
                                                                <td>
                                                                    -
                                                                </td>
                                                                <td>
                                                                    00.00
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
                                                                <td>
                                                                    -
                                                                </td>
                                                                <td>
                                                                    <b>16500.00</b>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    Deposit
                                                                </td>
                                                                <td>
                                                                    -
                                                                </td>
                                                                <td>
                                                                    10000.00
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
                                                                <td>
                                                                    -
                                                                </td>
                                                                <td>
                                                                    <b>26500.00</b>
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
                                                                    Amount
                                                                </td>
                                                                <td>
                                                                    26000.00 (Cash)
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" style="padding: 0px;">
                                                                    <hr />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    Total Amount Received
                                                                </td>
                                                                <td>
                                                                    <b>26000.00</b>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" style="padding: 0px;">
                                                                    <hr />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <b>Balance Amount (Due)</b>
                                                                </td>
                                                                <td>
                                                                    <b>500.00</b>
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
                                                        <div style="text-align:center;">
                                                            <b>
                                                                <asp:Literal ID="Literal22" runat="server" Text="CANCELLATION POLICY"></asp:Literal></b>
                                                        </div>
                                                        <div>
                                                            <hr />
                                                        </div>
                                                        <div style="font-size:10px;">
                                                            <table width="100%" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td style="vertical-align:top;">
                                                                        1)
                                                                    </td>
                                                                    <td>
                                                                        Cancellation before 30 days of check in date – no retention.
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="vertical-align:top;">
                                                                        2)
                                                                    </td>
                                                                    <td>
                                                                        Cancellation between 30 days to 15 week of check in date : 25% retention.
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="vertical-align:top;">
                                                                        3)
                                                                    </td>
                                                                    <td>
                                                                        Cancellation between 15 days to 1 week of check in date :50 % retention.
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="vertical-align:top;">
                                                                        4)
                                                                    </td>
                                                                    <td>
                                                                        Cancellation below 1 week :- 70 % retention.
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="vertical-align:top;">
                                                                        5)
                                                                    </td>
                                                                    <td>
                                                                        Cancellation Received less than 48 hours Prior to Arrival : 100% retention will
                                                                        be charged
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </td>
                                                    <td style="border-left: 1px solid #CCCCCC;">
                                                    </td>
                                                    <td width="50%" style="vertical-align: top;">
                                                        <div style="text-align:center;">
                                                            <b>
                                                                <asp:Literal ID="Literal2" runat="server" Text="RESERVATION POLICY"></asp:Literal></b>
                                                        </div>
                                                        <div>
                                                            <hr />
                                                        </div>
                                                        <div style="font-size:10px;">
                                                            <table width="100%" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td style="vertical-align:top;">
                                                                        1)
                                                                    </td>
                                                                    <td>
                                                                        Check In time: 10:30 AM
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="vertical-align:top;">
                                                                        2)
                                                                    </td>
                                                                    <td>
                                                                        Check Out time: 10:00 AM
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="vertical-align:top;">
                                                                        3)
                                                                    </td>
                                                                    <td>
                                                                        Reservation will be held until 12:00 AM
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="vertical-align:top;">
                                                                        4)
                                                                    </td>
                                                                    <td>
                                                                        Please carry your photo ID along with this voucher at the time of check in.
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="vertical-align:top;">
                                                                        5)
                                                                    </td>
                                                                    <td>
                                                                        Charges wii apply for any changes on confirmed booking as per policy.
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" align="center">
                                            <div style="text-align: center; display: inline-block;">
                                                <asp:Button ID="Button2" runat="server" Text="Email & SMS" ImageUrl="~/images/save.png"
                                                    Style="float: right; margin-left: 5px;" />
                                                <asp:Button ID="Button3" runat="server" Text="SMS" ImageUrl="~/images/save.png" Style="float: right;
                                                    margin-left: 5px;" />
                                                <asp:Button ID="Button4" runat="server" Text="Email" ImageUrl="~/images/save.png"
                                                    Style="float: right; margin-left: 5px;" />
                                                <asp:Button ID="btnCnacelPrint" runat="server" Text="Print" Style="float: right;
                                                    margin-left: 5px;" />
                                            </div>
                                        </td>
                                    </tr>
                                </table>
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
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updRoomReservation" ID="UpdateProgressRoomReservation"
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
