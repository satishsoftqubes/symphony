<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCancelReservation.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation.CtrlCancelReservation" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<%@ Register Src="~/UIControls/Reservation/CtrlCancellationVoucher.ascx" TagName="CancellationVoucher"
    TagPrefix="ucCancellationVoucher" %>
<script type="text/javascript">   
    
    function fnCalculateCharge() {
        if (Page_ClientValidate("IsRequire")) {

            var BalanceAmount = 0;
            var AmountPaid = document.getElementById('<%=lblDisplayAmountPaid.ClientID %>').innerHTML;
            var ReturnAmount = document.getElementById('<%=txtReturnAmount.ClientID %>').value;


            if (parseFloat(ReturnAmount) > parseFloat(AmountPaid)) {
                alert('Refund Amount cant greater than Amount Paid.');
                return false;
            }

            BalanceAmount = parseFloat(AmountPaid) - parseFloat(ReturnAmount);

            document.getElementById('<%=lblBalanceAmount.ClientID %>').innerHTML = BalanceAmount.toFixed(2);
        }
        return false;
    }

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

</script>
<asp:UpdatePanel ID="updCancelReservation" runat="server">
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
                                <asp:Literal ID="Literal1" runat="server" Text="CANCEL RESERVATION"></asp:Literal>
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
                                            <td colspan="2">
                                                <% if (IsMessage)
                                                   { %>
                                                <div class="message finalsuccess">
                                                    <p>
                                                        <strong>
                                                            <asp:Literal ID="litMessage" runat="server"></asp:Literal></strong>
                                                    </p>
                                                </div>
                                                <% }%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="48%" style="vertical-align: top; border-right: 1px solid #ccccce;">
                                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                    <tr>
                                                        <td colspan="4">
                                                            <b>
                                                                <asp:Literal ID="litStayInformation" runat="server" Text="Stay Information"></asp:Literal></b>
                                                            <hr />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="70px">
                                                            <asp:Literal ID="Literal2" runat="server" Text="Booking #"></asp:Literal>
                                                        </td>
                                                        <td style="width: 7px;">
                                                            :
                                                        </td>
                                                        <td style="vertical-align: middle;" class="NumericDropdown">
                                                            <asp:Literal ID="litDisplayReservationNo" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litCheckInDate" runat="server" Text="Check In"></asp:Literal>
                                                        </td>
                                                        <td style="width: 7px;">
                                                            :
                                                        </td>
                                                        <td style="vertical-align: middle;" class="NumericDropdown">
                                                            <asp:Literal ID="litDisplayCheckInDate" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litCheckOutDate" runat="server" Text="Check Out"></asp:Literal>
                                                        </td>
                                                        <td style="width: 7px;">
                                                            :
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="litDisplayCheckOutDate" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litRoomType" runat="server" Text="Room Type"></asp:Literal>
                                                        </td>
                                                        <td style="width: 7px;">
                                                            :
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="litDisplayRoomType" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litRateCard" runat="server" Text="Rate Card"></asp:Literal>
                                                        </td>
                                                        <td style="width: 7px;">
                                                            :
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="litDisplayRateCard" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litAdult" runat="server" Text="Adult"></asp:Literal>
                                                        </td>
                                                        <td style="width: 7px;">
                                                            :
                                                        </td>
                                                        <td style="vertical-align: middle;" class="NumericDropdown">
                                                            <asp:Literal ID="litDisplayAdult" runat="server"></asp:Literal>
                                                            &nbsp;&nbsp;&nbsp;
                                                            <asp:Literal ID="litChild" runat="server" Text="Child"></asp:Literal>&nbsp;&nbsp;&nbsp;:&nbsp;&nbsp;&nbsp;
                                                            <asp:Literal ID="litDisplayChild" runat="server"></asp:Literal>
                                                            &nbsp;&nbsp;&nbsp;
                                                            <asp:Literal ID="litInf" runat="server" Text="Inf"></asp:Literal>&nbsp;&nbsp;&nbsp;:&nbsp;&nbsp;&nbsp;
                                                            <asp:Literal ID="litDisplayInf" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litStatus" runat="server" Text="Status"></asp:Literal>
                                                        </td>
                                                        <td style="width: 7px;">
                                                            :
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="litDisplayStatus" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="Literal4" runat="server" Text="Room No."></asp:Literal>
                                                        </td>
                                                        <td style="width: 7px;">
                                                            :
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="litDisplayRoomNo" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" style="padding-top: 15px;">
                                                            <b>
                                                                <asp:Literal ID="litGuestInformation" runat="server" Text="Guest Information"></asp:Literal></b>
                                                            <hr />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 80px !important;">
                                                            <asp:Literal ID="litName" runat="server" Text="Name"></asp:Literal>
                                                        </td>
                                                        <td style="width: 7px;">
                                                            :
                                                        </td>
                                                        <td style="vertical-align: middle;" class="NumericDropdown">
                                                            <asp:Literal ID="litDisplayGuestName" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litMobile" runat="server" Text="Mobile No."></asp:Literal>
                                                        </td>
                                                        <td style="width: 7px;">
                                                            :
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="litDisplayMobile" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litGuestEmail" runat="server" Text="Email"></asp:Literal>
                                                        </td>
                                                        <td style="width: 7px;">
                                                            :
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="litDisplayEmail" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="vertical-align: top;">
                                                            <asp:Literal ID="litAddress" runat="server" Text="Address"></asp:Literal>
                                                        </td>
                                                        <td style="width: 7px;">
                                                            :
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="litDisplayAddress" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litCityName" runat="server" Text="City"></asp:Literal>
                                                        </td>
                                                        <td style="width: 7px;">
                                                            :
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="litDisplayCityName" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="vertical-align: top;">
                                                <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                    <tr>
                                                        <td style="padding: 0px;" colspan="3">
                                                            <table cellpadding="0" cellspacing="0" width="80%">
                                                                <tr>
                                                                    <td colspan="3">
                                                                        <b>Room Rent</b>
                                                                        <hr />
                                                                    </td>
                                                                </tr>
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
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" style="padding-top: 10px;">
                                                            <hr />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 90px !important;">
                                                            <b>
                                                                <asp:Literal ID="litPMT" runat="server" Text="Amount Paid"></asp:Literal></b>
                                                        </td>
                                                        <td style="width: 7px;">
                                                            :
                                                        </td>
                                                        <td>
                                                            <b>
                                                                <asp:Label ID="lblDisplayAmountPaid" runat="server"></asp:Label>
                                                            </b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            <asp:Button ID="btnCalculateCancellationCharge" runat="server" Text="Calculate Cancellation Charge"
                                                                OnClick="btnCalculateCancellationCharge_OnClick" />
                                                        </td>
                                                    </tr>
                                                    <tr id="trCalculateCancellationCharge" runat="server" visible="false">
                                                        <td colspan="3" style="padding: 0px;">
                                                            <table width="100%" cellpadding="0px" cellspacing="0px">
                                                                <tr>
                                                                    <td width="160px">
                                                                        <asp:Literal ID="Literal6" runat="server" Text="Check In Date"></asp:Literal>
                                                                    </td>
                                                                    <td style="width: 7px;">
                                                                        :
                                                                    </td>
                                                                    <td>
                                                                        <asp:Literal ID="litDisplayCanCalCharCheckInDate" runat="server"></asp:Literal>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Literal ID="Literal8" runat="server" Text="Cancellation Date"></asp:Literal>
                                                                    </td>
                                                                    <td style="width: 7px;">
                                                                        :
                                                                    </td>
                                                                    <td>
                                                                        <asp:Literal ID="litDisplayCanCalCharCancellationDate" runat="server"></asp:Literal>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Literal ID="Literal10" runat="server" Text="Days before Check In"></asp:Literal>
                                                                    </td>
                                                                    <td style="width: 7px;">
                                                                        :
                                                                    </td>
                                                                    <td>
                                                                        <asp:Literal ID="litDisplayCanCalCharDaysbeforeCheckIn" runat="server"></asp:Literal>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Literal ID="Literal3" runat="server" Text="Charge applied on Amount:"></asp:Literal>
                                                                    </td>
                                                                    <td style="width: 7px;">
                                                                        :
                                                                    </td>
                                                                    <td>
                                                                        <asp:Literal ID="ltrDisplayChargeAppliedOnAmt" runat="server"></asp:Literal>
                                                                        (Deposit amount only)
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding-bottom: 10px;">
                                                                        <b>
                                                                            <asp:Literal ID="Literal12" runat="server" Text="Cancellation Charge"></asp:Literal></b>
                                                                    </td>
                                                                    <td style="padding-bottom: 10px; width: 7px;">
                                                                        :
                                                                    </td>
                                                                    <td style="padding-bottom: 10px;">
                                                                        <b>
                                                                            <asp:Literal ID="litDisplayCancellationCharge" runat="server" Text="0.00"></asp:Literal></b>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding-bottom: 10px;">
                                                                        <b>
                                                                            <asp:Literal ID="Literal16" runat="server" Text="Net Balance (Credit)"></asp:Literal></b>
                                                                    </td>
                                                                    <td style="padding-bottom: 10px; width: 7px;">
                                                                        :
                                                                    </td>
                                                                    <td style="padding-bottom: 10px;">
                                                                        <b>
                                                                            <asp:Literal ID="litDisplayNetBalance" runat="server" Text="0.00"></asp:Literal></b>&nbsp;&nbsp;&nbsp;
                                                                        <asp:Button ID="btnRefund" runat="server" Text="Refund" Style="display: inline;"
                                                                            OnClick="btnRefund_OnClick" Visible="false" />
                                                                    </td>
                                                                </tr>
                                                                <tr id="trRefund" runat="server" visible="false">
                                                                    <td colspan="3">
                                                                        <table width="80%" cellpadding="0" cellspacing="0">
                                                                            <tr>
                                                                                <td colspan="2">
                                                                                    <b>Refund</b>
                                                                                    <hr />
                                                                                </td>
                                                                            </tr>
                                                                            <tr style="display: none;">
                                                                                <td width="100px">
                                                                                    <b>Amount</b>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtReturnAmount" runat="server" SkinID="nowidth" Width="100px" Enabled="false"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="rfvReturnAmount" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                                        runat="server" ValidationGroup="IsRequire" ControlToValidate="txtReturnAmount"
                                                                                        Display="Dynamic">
                                                                                    </asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr style="display: none;">
                                                                                <td>
                                                                                    Mode of Payment
                                                                                </td>
                                                                                <td>
                                                                                    Cash&nbsp&nbsp&nbsp<asp:Button ID="btnProceed" runat="server" Text="Proceed" Style="display: inline;"
                                                                                        OnClientClick="return fnCalculateCharge();" ValidationGroup="IsRequire" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2">
                                                                                    <div class="box_head">
                                                                                        <span>
                                                                                            <asp:Literal ID="litRoomReservationList" runat="server" Text="Room Reservation List"></asp:Literal>
                                                                                        </span>
                                                                                    </div>
                                                                                    <div class="clear">
                                                                                    </div>
                                                                                    <div class="box_content">
                                                                                        <asp:GridView ID="gvRefundDepositList" runat="server" AutoGenerateColumns="false"
                                                                                            ShowHeader="true" Width="100%" SkinID="gvNoPaging" DataKeyNames="BookID,ReservationID,MOP_TermID,FolioID,RoomID">
                                                                                            <Columns>
                                                                                                <asp:TemplateField ItemStyle-Width="30px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                    <HeaderTemplate>
                                                                                                        <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                                                                                    </HeaderTemplate>
                                                                                                    <ItemTemplate>
                                                                                                        <%# Container.DataItemIndex + 1 %>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                    <HeaderTemplate>
                                                                                                        <asp:Label ID="lblGvHdrDate" runat="server" Text="Date"></asp:Label>
                                                                                                    </HeaderTemplate>
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblGvDate" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "EntryDate")).ToString(clsSession.DateFormat)%>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                                                    <HeaderTemplate>
                                                                                                        <asp:Label ID="lblGvHdrAmount" runat="server" Text="Amount"></asp:Label>
                                                                                                    </HeaderTemplate>
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblGvAmount" runat="server"></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                    <HeaderTemplate>
                                                                                                        <asp:Label ID="lblGvHdrMOP" runat="server" Text="MOP"></asp:Label>
                                                                                                    </HeaderTemplate>
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblGvMOP" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "MOP")%>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                                                    <HeaderTemplate>
                                                                                                        <asp:Label ID="lblGvHdrRefund" runat="server" Text="Refund"></asp:Label>
                                                                                                    </HeaderTemplate>
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblGvRefund" runat="server"></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                            </Columns>
                                                                                            <EmptyDataTemplate>
                                                                                                <div style="padding: 10px;">
                                                                                                    <b>
                                                                                                        <asp:Label ID="lblNoRecordFound" runat="server" Text="No record found."></asp:Label>
                                                                                                    </b>
                                                                                                </div>
                                                                                            </EmptyDataTemplate>
                                                                                        </asp:GridView>
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                            <tr id="trModeOfRefund" runat="server" visible="false">
                                                                                <td width="120px">
                                                                                    <b>Mode of Refund</b>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlRefundDepositMOP" runat="server" SkinID="nowidth" Width="150px"
                                                                                        OnSelectedIndexChanged="ddlRefundDepositMOP_OnSelectedIndexChanged" AutoPostBack="true">
                                                                                    </asp:DropDownList>
                                                                                    <span>
                                                                                        <asp:RequiredFieldValidator ID="rfvRefundDepositMOP" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                                            SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                                            Enabled="false" ValidationGroup="RequireForRefundDeposit" ControlToValidate="ddlRefundDepositMOP"
                                                                                            Display="Static">
                                                                                        </asp:RequiredFieldValidator>
                                                                                    </span>
                                                                                </td>
                                                                            </tr>
                                                                            <tr id="trRefundDepoistLedgerAccount" runat="server" visible="false">
                                                                                <td>
                                                                                    <b>Ledger</b>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlRefundDepositLedgerAcct" SkinID="nowidth" Width="150px"
                                                                                        runat="server">
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr id="trRefundDepositBankName" runat="server" visible="false">
                                                                                <td>
                                                                                    <b>Bank Name</b>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtRefundDepositBankName" SkinID="nowidth" Width="150px" runat="server"></asp:TextBox>
                                                                                    <span>
                                                                                        <asp:RequiredFieldValidator ID="rfvRefundDepositBankName" Enabled="false" SetFocusOnError="true"
                                                                                            CssClass="input-notification error png_bg" runat="server" ValidationGroup="RequireForRefundDeposit"
                                                                                            ControlToValidate="txtRefundDepositBankName" Display="Static">
                                                                                        </asp:RequiredFieldValidator>
                                                                                    </span>
                                                                                </td>
                                                                            </tr>
                                                                            <tr id="trRefundDepositChequeDDNo" runat="server" visible="false">
                                                                                <td>
                                                                                    <b>Cheque No.</b>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtRefundDepositChequeDDno" SkinID="nowidth" Width="150px" runat="server"></asp:TextBox>
                                                                                    <span>
                                                                                        <asp:RequiredFieldValidator ID="rfvRefundDepositChequeDDno" Enabled="false" SetFocusOnError="true"
                                                                                            CssClass="input-notification error png_bg" runat="server" ValidationGroup="RequireForRefundDeposit"
                                                                                            ControlToValidate="txtRefundDepositChequeDDno" Display="Static">
                                                                                        </asp:RequiredFieldValidator>
                                                                                    </span>
                                                                                </td>
                                                                            </tr>
                                                                            <tr style="display: none;">
                                                                                <td colspan="2" style="padding: 0px;">
                                                                                    <hr />
                                                                                </td>
                                                                            </tr>
                                                                            <tr style="display: none;">
                                                                                <td>
                                                                                    <b>Balance Amount</b>
                                                                                </td>
                                                                                <td>
                                                                                    <b>
                                                                                        <asp:Label ID="lblBalanceAmount" runat="server" Text="0.00"></asp:Label></b>
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
                                            <td colspan="2" align="center">
                                                <asp:Button ID="btnCancelReservation" runat="server" Style="display: inline;" ValidationGroup="RequireForRefundDeposit"
                                                    Text="Cancel Reservation" OnClick="btnCancelReservation_Click" />
                                                <asp:Button ID="btnBackToList" runat="server" Style="display: inline;" Text="Back"
                                                    OnClick="btnBackToList_OnClick" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <ajx:ModalPopupExtender ID="mpeCancellationVoucher" runat="server" TargetControlID="hdnCancelRes"
                                    PopupControlID="pnlCancellationVoucher" CancelControlID="imgCloseTranscriptionPopup"
                                    BackgroundCssClass="mod_background">
                                </ajx:ModalPopupExtender>
                                <asp:HiddenField ID="hdnCancelRes" runat="server" />
                                <asp:Panel ID="pnlCancellationVoucher" runat="server" Width="400px">
                                    <div class="box_col1">
                                        <div class="box_head">
                                            <span>
                                                <asp:Literal ID="Literal23" runat="server" Text="Cancellation Voucher"></asp:Literal></span>
                                            <div style="display: inline; float: right; padding: 7px 10px 0px 0px;">
                                                <asp:ImageButton ID="imgCloseTranscriptionPopup" runat="server" ToolTip="Close" Width="15px"
                                                    Height="15px" ImageUrl="~/images/clear.png" />
                                            </div>
                                        </div>
                                        <div class="clear">
                                        </div>
                                        <div class="box_form">
                                            <ucCancellationVoucher:CancellationVoucher ID="ucCancellationVoucher" runat="server" />
                                        </div>
                                        <div class="clear">
                                        </div>
                                    </div>
                                </asp:Panel>
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
    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updCancelReservation" ID="UpdateProgressCancelReservation"
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
