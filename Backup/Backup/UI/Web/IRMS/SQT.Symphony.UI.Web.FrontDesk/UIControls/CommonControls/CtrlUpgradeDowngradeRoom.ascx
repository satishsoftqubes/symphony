<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlUpgradeDowngradeRoom.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls.CtrlUpgradeDowngradeRoom" %>
<%@ Register Src="~/UIControls/Guest/CtrlRateUpdateforDifferentRoomType.ascx" TagName="UpdatesRate"
    TagPrefix="ucCtrlUpdatesRate" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script src="../../Scripts/jquery-1.8.2.js" type="text/javascript"></script>
<script src="../../Scripts/jquery-ui.js"></script>
<script src="../../Scripts/Common.js" type="text/javascript"></script>
<script type="text/javascript">
    function pageLoad(sender, args) {
        var v1 = '<%=ConfigurationManager.AppSettings["IsUpperCase"].ToString() %>'
        if (v1 == "1") {
            $('input[type="text"],textarea').each(function () { $(this).css("text-transform", "uppercase") });
        }

    }
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

</script>
<asp:UpdatePanel ID="updMoveRoom" runat="server">
    <ContentTemplate>
        <asp:MultiView ID="mvMoveUnit" runat="server">
            <asp:View ID="vReservationList" runat="server">
                <div class="box_col1">
                    <div class="box_head">
                        <span>
                            <asp:Literal ID="Literal1" runat="server" Text="Up/Down-grade Room"></asp:Literal></span></div>
                    <div class="clear">
                    </div>
                    <div class="box_form">
                        <table cellpadding="2" cellspacing="2" width="100%">
                            <tr>
                                <td colspan="4">
                                    <%if (IsListMessage)
                                      { %>
                                    <div class="message finalsuccess">
                                        <p>
                                            <strong>
                                                <asp:Literal ID="ltrListMessage" runat="server"></asp:Literal></strong>
                                        </p>
                                    </div>
                                    <%}%>
                                </td>
                            </tr>
                            <tr>
                                <td width="90px">
                                    <asp:Literal ID="Literal17" runat="server" Text="Room No."></asp:Literal>
                                </td>
                                <td width="350px">
                                    <asp:TextBox ID="txtSearchRoomNo" runat="server"></asp:TextBox>
                                </td>
                                <td width="90px">
                                    <asp:Literal ID="Literal18" runat="server" Text="Booking #"></asp:Literal>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSearchBookingNo" runat="server"></asp:TextBox>
                                    <ajx:FilteredTextBoxExtender ID="fteSearcReservationNo" runat="server" TargetControlID="txtSearchBookingNo"
                                        FilterMode="ValidChars" ValidChars="0123456789">
                                    </ajx:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Literal ID="Literal19" runat="server" Text="Name"></asp:Literal>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSearchGuestName" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Literal ID="Literal20" runat="server" Text="Room Type"></asp:Literal>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSearchRoomType" runat="server">
                                    </asp:DropDownList>
                                    <asp:ImageButton ID="imgbtnSearchListData" runat="server" ToolTip="Search" ImageUrl="~/images/search-icon.png"
                                        Style="border: 0px; margin: 0 0 0 5px; vertical-align: middle;" OnClick="imgbtnSearchListData_Click" />
                                    <asp:ImageButton ID="imgbtnClearListData" runat="server" ToolTip="Clear" ImageUrl="~/images/clearsearch.png"
                                        Style="border: 0px; vertical-align: middle; margin: 0 0 0 10px;" OnClick="imgbtnClearListData_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <hr />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" style="vertical-align: top;">
                                    <div class="box_head">
                                        <span>
                                            <asp:Literal ID="Literal21" runat="server" Text="Reservation List"></asp:Literal>
                                        </span>
                                    </div>
                                    <div class="clear">
                                    </div>
                                    <div class="box_content">
                                        <div style="height: 500px; overflow: auto;">
                                            <asp:GridView ID="gvResevationList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                Width="100%" DataKeyNames="Balance,RoomTypeID,RoomID,RateID,CheckOutDate,CheckInDate,FolioID,RateCardName"
                                                OnRowDataBound="gvResevationList_RowDataBound" OnRowCommand="gvResevationList_RowCommand"
                                                OnPageIndexChanging="gvResevationList_PageIndexChanging">
                                                <Columns>
                                                    <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblGvHdrListReservationNo" runat="server" Text="Booking #"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblGvListReservationNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ReservationNo")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblGvHdrListUnitType" runat="server" Text="Room Type"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblGvListRoomTypeName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "RoomTypeName")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblGvHdrListRoomNo" runat="server" Text="Room No."></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblGvListRoomNo" runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblGvHdrSwapGuestName" runat="server" Text="Name"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblGvListName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "GuestFullName")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblGvHdrListMobileNo" runat="server" Text="Mobile No."></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblGvListPhone" runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblGvHdrListCheckIn" runat="server" Text="Check In"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblGvListCheckInDate" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "CheckInDate")).ToString(clsSession.DateFormat)%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblGvHdrListCheckOut" runat="server" Text="Check Out"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblGvListCheckOutDate" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "CheckOutDate")).ToString(clsSession.DateFormat)%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblActions" runat="server" Text="Action"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPopUp" runat="server" Text="Actions"></asp:Label>
                                                            <ajx:HoverMenuExtender ID="HoverMenuExtender2" runat="server" TargetControlID="lblPopUp"
                                                                PopupControlID="Panel2" PopupPosition="Left">
                                                            </ajx:HoverMenuExtender>
                                                            <asp:Panel ID="Panel2" runat="server" Style="visibility: hidden; opacity: 100%">
                                                                <div class="actionsbuttons_hovermenu">
                                                                    <table border="0" cellpadding="0" cellspacing="0" class="actionsbuttons_hover_lettmenu_table">
                                                                        <tr>
                                                                            <td class="actionsbuttons_hover_lettmenu">
                                                                            </td>
                                                                            <td class="actionsbuttons_hover_centermenu">
                                                                                <ul>
                                                                                    <li>
                                                                                        <asp:LinkButton Style="background: none !important; border: none;" ID="lnkView" runat="server"
                                                                                            ToolTip="Up/Down-grade Room" CommandName="MOVEROOM" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ReservationID")%>'><img src="../../images/file.png" /></asp:LinkButton>
                                                                                    </li>
                                                                                </ul>
                                                                            </td>
                                                                            <td class="actionsbuttons_hover_rightmenu">
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                            </asp:Panel>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EmptyDataTemplate>
                                                    <div style="padding: 10px;">
                                                        <b>
                                                            <asp:Label ID="lblNoRecordFound" runat="server" Text="No Record Found."></asp:Label>
                                                        </b>
                                                    </div>
                                                </EmptyDataTemplate>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="clear">
                    </div>
                </div>
            </asp:View>
            <asp:View ID="vMoveUnit" runat="server">
                <div class="box_col1">
                    <div class="box_head">
                        <span>
                            <asp:Literal ID="litMoveUnitHeader" runat="server" Text="Upgrade/Downgrade Room Setup"></asp:Literal></span></div>
                    <div class="clear">
                    </div>
                    <div class="box_form">
                        <table cellpadding="2" cellspacing="2" width="100%">
                            <%--<tr>
                                <td colspan="3">
                                    <div style="float: left; width: 80px;">
                                        <asp:Literal ID="litMoveUnitReservationNo" runat="server" Text="Booking #"></asp:Literal>
                                    </div>
                                    <div style="float: left; width: 100px;">
                                        <asp:Literal ID="litDisplayMoveUnitReservationNo" runat="server"></asp:Literal>
                                    </div>
                                    <div style="float: left; width: 102px;">
                                        <asp:Literal ID="litMoveUnitGuestName" runat="server" Text="Guest Name"></asp:Literal>
                                    </div>
                                    <div style="float: left;">
                                        <asp:Literal ID="litDisplayMoveUnitGuestName" runat="server"></asp:Literal>
                                    </div>
                                    <div style="float: left; width: 75px;">
                                        <asp:Literal ID="litMoveUnitRoomNoAndRoomType" runat="server" Text="Room No."></asp:Literal>
                                    </div>
                                    <div style="float: left; width: 250px;">
                                        <asp:Literal ID="litDisplayMoveUnitRoomNoAndRoomType" runat="server"></asp:Literal>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <div style="float: left; width: 75px;">
                                        <asp:Literal ID="litCheckIn" runat="server" Text="Check In"></asp:Literal>
                                    </div>
                                    <div style="float: left; width: 250px;">
                                        <asp:Literal ID="litDisplayCheckIn" runat="server"></asp:Literal>
                                    </div>
                                    <div style="float: left; width: 79px;">
                                        <asp:Literal ID="litCheckOut" runat="server" Text="Check Out"></asp:Literal>
                                    </div>
                                    <div style="float: left; width: 102px;">
                                        <asp:Literal ID="litDisplayCheckout" runat="server"></asp:Literal>
                                    </div>
                                    <div style="float: left; width: 102px;">
                                        <asp:Literal ID="litFolioBalance" runat="server" Text="Folio Balance"></asp:Literal>
                                    </div>
                                    <div style="float: left; width: 250px;">
                                        <asp:Literal ID="litDisplayFolioBalance" runat="server"></asp:Literal>
                                    </div>
                                </td>
                            </tr>--%>
                            <tr>
                                <td colspan="3">
                                    <table width="100%" cellpadding="2" cellspacing="2">
                                        <tr>
                                            <td width="60px">
                                                Booking #
                                            </td>
                                            <td width="150px">
                                                <asp:Literal ID="litDisplayMoveUnitReservationNo" runat="server"></asp:Literal>
                                            </td>
                                            <td width="70px">
                                                Guest Name
                                            </td>
                                            <td width="150px">
                                                <asp:Literal ID="litDisplayMoveUnitGuestName" runat="server"></asp:Literal>
                                            </td>
                                            <td width="50px">
                                                Check In
                                            </td>
                                            <td width="100px">
                                                <asp:Literal ID="litDisplayCheckIn" runat="server"></asp:Literal>
                                            </td>
                                            <td width="50px">
                                                Check Out
                                            </td>
                                            <td width="100px">
                                                <asp:Literal ID="litDisplayCheckout" runat="server"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Rate Card
                                            </td>
                                            <td>
                                                <asp:Literal ID="ltrChkPmtRateCard" runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                Room No.
                                            </td>
                                            <td style="width: 203px;">
                                                <asp:Literal ID="litDisplayMoveUnitRoomNoAndRoomType" runat="server"></asp:Literal>
                                            </td>
                                            <td style="width: 68px;">
                                                Folio Balance
                                            </td>
                                            <td>
                                                <asp:Literal ID="litDisplayFolioBalance" runat="server"></asp:Literal>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <hr />
                                </td>
                            </tr>
                            <tr>
                                <td width="40%" style="vertical-align: top;">
                                    <table width="100%" border="0">
                                        <tr>
                                            <td width="40%">
                                                <b>Particulars</b>
                                            </td>
                                            <td width="30%" align="center">
                                                <b>No. of Nights</b>
                                            </td>
                                            <td width="30%" align="right">
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
                                                <asp:Label ID="lblResTimeRoomRent" runat="server"></asp:Label>
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
                                                <asp:Label ID="lblResTimeTax" runat="server"></asp:Label>
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
                                                <asp:Label ID="lblResTimeTotalCharges" runat="server"></asp:Label>
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
                                                <asp:Label ID="lblResTimeDepositAmount" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 0px;" colspan="3">
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <b>Total Amount</b>
                                            </td>
                                            <td align="center">
                                                -
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblResTimeTotalPayableAmount" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="border-left: 1px solid #CCCCCC;">
                                </td>
                                <td width="60%" style="vertical-align: top;">
                                    <table cellpadding="2" cellspacing="2" width="100%">
                                        <tr>
                                            <td>
                                                <asp:Literal ID="litMoveUnitRoomType" runat="server" Text="Room Type"></asp:Literal>&nbsp;&nbsp;&nbsp;
                                                <asp:DropDownList ID="ddlMoveUnitUnitType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlMoveUnitUnitType_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal ID="litRoomNo" runat="server" Text="Room No."></asp:Literal>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:DropDownList ID="ddlRoomNumber" runat="server">
                                                </asp:DropDownList>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rfvRoomNumber" InitialValue="00000000-0000-0000-0000-000000000000"
                                                        SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                        Enabled="true" ValidationGroup="IsRequire" ControlToValidate="ddlRoomNumber"
                                                        Display="Dynamic">
                                                    </asp:RequiredFieldValidator>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <fieldset style="border: 1px solid #ccc !important;">
                                                    <legend>
                                                        <asp:Literal ID="litReasontoMoveRoom" runat="server" Text="Reason"></asp:Literal>
                                                    </legend>
                                                    <asp:TextBox ID="txtReasontoMoveRoom" Style="margin: 5px; width: 500px !important;"
                                                        TextMode="MultiLine" runat="server"></asp:TextBox>
                                                    <span>
                                                        <asp:RequiredFieldValidator ID="rfvMoveRoomReason" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                            runat="server" Enabled="true" ValidationGroup="IsRequire" ControlToValidate="txtReasontoMoveRoom"
                                                            Display="Dynamic">
                                                        </asp:RequiredFieldValidator>
                                                    </span>
                                                </fieldset>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:Button ID="btnMoveUnitSave" runat="server" Style="display: inline; padding-right: 10px;"
                                        Text="Save" Visible="false" ValidationGroup="IsRequire" OnClick="btnMoveUnitSave_Click" />
                                    <asp:Button ID="btnMoveUnitHistory" runat="server" Style="display: inline;" Text="History"
                                        OnClick="btnMoveUnitHistory_Click" />
                                    <asp:Button ID="btnMoveUnitCancel" runat="server" Style="display: inline;" Text="Cancel"
                                        OnClick="btnMoveUnitCancel_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="clear">
                    </div>
                </div>
            </asp:View>
            <asp:View ID="vMoveUnitHistory" runat="server">
                <div class="box_col1">
                    <div class="box_head">
                        <span>
                            <asp:Literal ID="litMoveUnitHistory" runat="server" Text="Move Room History"></asp:Literal></span></div>
                    <div class="clear">
                    </div>
                    <div class="box_form">
                        <table cellpadding="2" cellspacing="2" width="100%">
                            <tr>
                                <td width="100%" style="height: 150px; overflow: auto; vertical-align: top;">
                                    <div class="box_head">
                                        <span>
                                            <asp:Literal ID="litMoveUnitHistoryList" runat="server" Text="Move Room History List"></asp:Literal>
                                        </span>
                                    </div>
                                    <div class="clear">
                                    </div>
                                    <div class="box_content">
                                        <asp:GridView ID="gvMoveUnitHistoryList" runat="server" AutoGenerateColumns="false"
                                            ShowHeader="true" Width="100%" OnPageIndexChanging="gvMoveUnitHistoryList_PageIndexChanging"
                                            OnRowDataBound="gvMoveUnitHistoryList_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrMoveUnitHistorySrNo" runat="server" Text="No."></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrMoveUnitHistoryOldUnitNo" runat="server" Text="Old Room No."></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGvOldRoomNo" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrMoveUnitHistoryNewUnitNo" runat="server" Text="New Room No."></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGvNewRoomNo" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrMoveUnitHistoryDateOfMove" runat="server" Text="Date Of Move"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGvDateOfMove" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "DateOfMove")).ToString(clsSession.DateFormat)%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrMoveUnitHistoryReason" runat="server" Text="Reason"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGvMoveRoomReason" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Reasom")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <div style="padding: 10px;">
                                                    <b>
                                                        <asp:Label ID="lblNoRecordFoundForMoveUnitHistory" runat="server" Text="No Record Found."></asp:Label>
                                                    </b>
                                                </div>
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Button ID="btnMoveUnitHistoryCancel" runat="server" Text="Cancel" OnClick="btnMoveUnitHistoryCancel_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="clear">
                    </div>
                </div>
            </asp:View>
        </asp:MultiView>
        <asp:HiddenField ID="hfPopupCustomeMessage" runat="server" />
        <ajx:ModalPopupExtender ID="mpeCustomePopup" runat="server" TargetControlID="hfPopupCustomeMessage"
            PopupControlID="pnlCustomeMessage" BackgroundCssClass="mod_background" CancelControlID="btnOKCustomeMsgPopup"
            DropShadow="true" BehaviorID="mpeCustomePopup">
        </ajx:ModalPopupExtender>
        <asp:Panel ID="pnlCustomeMessage" runat="server" Width="350px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="litHeaderCustomePopupMessage" runat="server" Text="Message"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td align="center" style="padding-bottom: 15px; color: Red;">
                                <%--<asp:la ID="litCustomePopupMsg" runat="server" Text=""></asp:Literal>--%>
                                <asp:Label ID="lblCustomePopupMsg" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnOKCustomeMsgPopup" runat="server" Text="OK" Style="display: inline;
                                    padding-right: 10px;" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpeRateUpdateMsg" runat="server" TargetControlID="hdnRateUpdate"
            PopupControlID="pnlRateUpdate" BackgroundCssClass="mod_background" CancelControlID="btnCancelRateUpdate"
            DropShadow="true">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnRateUpdate" runat="server" />
        <asp:Panel ID="pnlRateUpdate" runat="server" Height="350px" Width="325px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="Literal2" runat="server" Text="Message"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td align="center" style="padding-bottom: 15px;">
                                <asp:Label ID="Label1" runat="server" Text="Please Select Credit Card Info."></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnYesRateUpdate" runat="server" Style="display: inline; padding-right: 10px;"
                                    Text="Yes" />
                                <asp:Button ID="btnCancelRateUpdate" runat="server" Style="display: inline; padding-right: 10px;"
                                    Text="No" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <ucCtrlUpdatesRate:UpdatesRate ID="ctrlUpdatesRate" runat="server" OnbtnUpdatesRateCallParent_Click="btnUpdatesRateCallParent_Click" />
    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updMoveRoom" ID="UpdateProgressMoveRoom"
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
