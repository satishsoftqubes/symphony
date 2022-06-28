<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlUnitBooking.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.InvestorSetUp.CtrlUnitBooking" %>
<script type="text/javascript" language="javascript">
    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function TotalNights() {
        var d1 = document.getElementById("<%=txtFromDate.ClientID%>");
        var d2 = document.getElementById("<%=txtToDate.ClientID%>");
        var result = document.getElementById("result");

        if (d1.value != "" && d2.value != "") {
            var dateFrom = new Date(d1.value);
            var dateTo = new Date(d2.value);
            var oneDay = 24 * 60 * 60 * 1000;
            var diffDays = Math.abs((dateFrom.getTime() - dateTo.getTime()) / (oneDay));
            document.getElementById("<%=txtNoOfNights.ClientID%>").value = diffDays;
        }

    }
</script>
<asp:UpdatePanel ID="updtTaxReceipt" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                UNIT BOOKING
                            </td>
                            <td class="boxtopright">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="boxleft">
                                &nbsp;
                            </td>
                            <td>
                                <table width="100%" cellpadding="3" cellspacing="3">
                                    <%--<tr>
                                        <td colspan="2">
                                            <div style="height: 26px;">
                                                <%if (IsInsert)
                                                  { %>
                                                <div class="ResetSuccessfully">
                                                    <div style="float: left; padding-top: 7px; width: 25px; height: 24px; margin-right: 10px;">
                                                        <img src="../../images/success.png" />
                                                    </div>
                                                    <div>
                                                        <asp:Label ID="lblPropertyTaxReceipt" runat="server"></asp:Label></div>
                                                    <div style="height: 10px;">
                                                    </div>
                                                </div>
                                                <% }%>
                                            </div>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td colspan="2">
                                            <div style="float: right;">
                                                <b>All Bold Fields are Mandatory</b>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <table border="0" cellpadding="2" cellspacing="2">
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="litInvestorName" runat="server" Text="Investor Name"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtInvestorName" Enabled="false" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="litGuestName" runat="server" Text="Guest Name"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtGuestName" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="litNoOfPepole" Text="No. Of Pepole" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtNoOfPepole" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <hr />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                <tr>
                                                    <td style="vertical-align: top; border-right: 1px solid #ccccce;">
                                                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litInquiryDate" runat="server" Text="Inquiry Date"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtInquiryDate" runat="server" Style="width: 118px !important;"
                                                                        onkeypress="return false;"></asp:TextBox>
                                                                    <asp:Image ID="imgInquiryDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                                        Height="20px" Width="20px" />
                                                                    <ajx:CalendarExtender ID="calInquiryDate" PopupButtonID="imgInquiryDate" TargetControlID="txtInquiryDate"
                                                                        runat="server" Format="dd/MMM/yyyy">
                                                                    </ajx:CalendarExtender>
                                                                    <img src="../../images/clear.png" id="imgAD" style="vertical-align: middle;" title="Clear Date"
                                                                        onclick="fnClearDate('<%= txtInquiryDate.ClientID %>');" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litDateOfBooking" runat="server" Text="Date Of Booking"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtDateOfBooking" runat="server" Style="width: 118px !important;"
                                                                        onkeypress="return false;"></asp:TextBox>
                                                                    <asp:Image ID="imgDateOfBooking" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                                        Height="20px" Width="20px" />
                                                                    <ajx:CalendarExtender ID="calDateOfBooking" PopupButtonID="imgDateOfBooking" TargetControlID="txtDateOfBooking"
                                                                        runat="server" Format="dd/MMM/yyyy">
                                                                    </ajx:CalendarExtender>
                                                                    <img src="../../images/clear.png" id="img1" style="vertical-align: middle;" title="Clear Date"
                                                                        onclick="fnClearDate('<%= txtDateOfBooking.ClientID %>');" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litBookedBy" runat="server" Text="Booked By"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlBookedBy" runat="server">
                                                                        <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                                        <asp:ListItem Text="Mr. Rajan Patel" Value="Mr. Rajan Patel"></asp:ListItem>
                                                                        <asp:ListItem Text="Miss. Roma Gupta" Value="Miss. Roma Gupta"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litStatus" runat="server" Text="Status"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBoxList ID="chkStatus" runat="server" RepeatColumns="2" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Conformed" Value="Conformed"></asp:ListItem>
                                                                        <asp:ListItem Text="Waitlist" Value="Waitlist"></asp:ListItem>
                                                                    </asp:CheckBoxList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litBookingVoucherNo" runat="server" Text="Booking Voucher No"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtBookingVoucherNo" Enabled="false" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td>
                                                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litTotalNoOfDay" runat="server" Text="Total No. Of Day"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtTotalNoOfDay" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litFromDate" Text="From" runat="server"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtFromDate" runat="server" Style="width: 118px !important;" onkeypress="return false;"></asp:TextBox>
                                                                    <asp:Image ID="imgFromDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                                        Height="20px" Width="20px" />
                                                                    <ajx:CalendarExtender ID="calFromDate" PopupButtonID="imgFromDate" TargetControlID="txtFromDate"
                                                                        runat="server" Format="dd/MMM/yyyy" OnClientDateSelectionChanged="TotalNights">
                                                                    </ajx:CalendarExtender>
                                                                    <img src="../../images/clear.png" id="img2" style="vertical-align: middle;" title="Clear Date"
                                                                        onclick="fnClearDate('<%= txtFromDate.ClientID %>');" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litToDate" runat="server" Text="To"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtToDate" runat="server" Style="width: 118px !important;" onkeypress="return false;"></asp:TextBox>
                                                                    <asp:Image ID="imgToDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                                        Height="20px" Width="20px" />
                                                                    <ajx:CalendarExtender ID="calToDate" PopupButtonID="imgToDate" TargetControlID="txtToDate"
                                                                        runat="server" Format="dd/MMM/yyyy" OnClientDateSelectionChanged="TotalNights">
                                                                    </ajx:CalendarExtender>
                                                                    <img src="../../images/clear.png" id="img3" style="vertical-align: middle;" title="Clear Date"
                                                                        onclick="fnClearDate('<%= txtToDate.ClientID %>');" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litNoOfNights" runat="server" Text="No. Of Nights"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtNoOfNights" Style="width: 40px !important;"   Enabled="false" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litTotalNoOfDayRemaining" Text="Total No Of Day Remaining" runat="server"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtTotalNoOfDayRemaining" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2" style="padding: 15px;">
                                            <asp:Button ID="btnPrint" runat="server" Text="Print" Style="display: inline;" />
                                            <asp:Button ID="btnDownload" runat="server" Text="Download" Style="display: inline;" />
                                        </td>
                                    </tr>
                                </table>
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
                </td>
            </tr>
        </table>
    </ContentTemplate>
    <Triggers>
        <%-- <asp:PostBackTrigger ControlID="btnSave" />--%>
    </Triggers>
</asp:UpdatePanel>
<asp:UpdateProgress AssociatedUpdatePanelID="updtTaxReceipt" ID="UpdateProgressPropertyTax"
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
