<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlExtendReservation.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation.CtrlExtendReservation" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<%@ Register Src="~/UIControls/Reservation/PaymentReceipt.ascx" TagName="PaymentReceipt"
    TagPrefix="ucCtrlPaymentReceipt" %>
<script type="text/javascript" language="javascript">
    function pageLoad(sender, args) {
        var v1 = '<%=ConfigurationManager.AppSettings["IsUpperCase"].ToString() %>'
        if (v1 == "1") {
            $('input[type="text"],textarea').each(function () { $(this).css("text-transform", "uppercase") });
        }
    }

    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function fnSetCheckOutDate() {
        var pageUrl = '<%=ResolveUrl("~/GUI/Reservation/FindBlackList.asmx")%>';

        document.getElementById('<%=hdnIsCalculateRate.ClientID%>').value = 'NO';
        document.getElementById('<%= hfIsToCheckAvailability.ClientID %>').value = 'YES';

        var checkInDate = document.getElementById('<%= lblDisplayDepartureDate.ClientID %>').innerHTML;
        var frequency = 'DAILY';
        var add = document.getElementById('<%=txtNight.ClientID%>').value;

        if (add == null || add == '') {
            add = 0;
        }

        $.ajax({
            type: "POST",
            url: pageUrl + "/GetCheckOutDate",
            data: JSON.stringify({ strCheckInDate: checkInDate, strFrequency: frequency, strAdd: add }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccessDateCall,
            error: OnErrorDateCall
        });

        return false;
    }

    function OnSuccessDateCall(response) {
        if (response.d != '') {
            document.getElementById('<%= txtNewDepartureDate.ClientID %>').value = response.d;
            return false;
        }
        else if (response.d == '') {
            document.getElementById('<%= txtNewDepartureDate.ClientID %>').value = '';
            return false;
        }
    }

    function fnopenPrintWindow() {
        $find('mpePrintReceipt').hide();
        var hdnReservationID = document.getElementById('<%= hdnResID.ClientID %>').value;
        var hdnBookingID = document.getElementById('<%= hdnBookingID.ClientID %>').value;
        window.open("CheckInPaymentRecipt.aspx?IdofRes=" + hdnReservationID + "&IdofBook=" + hdnBookingID, "CheckInVouche", "height=600,width=600,status=1,toolbar=no,menubar=no,scrollbars=1,location=0");
        return false;
    }

    function OnErrorDateCall(response) {
        alert(response.d);
        return false;
    }
    function fnOpenCheckInVoucherPrintWindow() {
        var hdnReservationID = document.getElementById('<%= hdnResID.ClientID %>').value;
        window.open("ExtandReservationVoucherPrint.aspx?ReservationID=" + hdnReservationID, "ExtandReservationVoucher", "height=600,width=800,status=1,toolbar=no,menubar=no,scrollbars=1,location=0");
        return false;
    }
</script>
<asp:UpdatePanel ID="updExtendReservation" runat="server">
    <ContentTemplate>
        <asp:HiddenField ID="hdnIsCalculateRate" runat="server" Value="NO" />
        <asp:HiddenField ID="hdnResID" runat="server" />
        <asp:HiddenField ID="hfIsToCheckAvailability" runat="server" Value="NO" />
        <asp:HiddenField ID="hdnBillingInstMode" runat="server" Value="" />
        <asp:HiddenField ID="hdnBookingID" runat="server" />
        <asp:HiddenField ID="hdnAmtPayByCmp" runat="server" Value="0.000000" />
        <%--<asp:HiddenField ID="hdnOldAddValue" runat="server" />
        <asp:HiddenField ID="hdnNewAddValue" runat="server" />--%>
        <asp:MultiView ID="mvExtendStay" runat="server">
            <asp:View ID="vResList" runat="server">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="content" style="padding-left: 0px; width: 66.66%">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="boxtopleft">
                                        &nbsp;
                                    </td>
                                    <td class="boxtopcenter">
                                        <asp:Literal ID="Literal1" runat="server" Text="Extend Stay"></asp:Literal>
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
                                                                    Width="100%" DataKeyNames="RoomTypeID,RoomID,RateID,CheckOutDate,FolioID,DiscountID,Adults,Children,RestStatus_TermID"
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
                                                                        <asp:TemplateField ItemStyle-Width="180px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrListUnitType" runat="server" Text="Room Type"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblGvListRoomTypeName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "RoomTypeName")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrListRoomNo" runat="server" Text="Room No."></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblGvListRoomNo" runat="server"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="125px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrListRateCardName" runat="server" Text="Rate Card"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblGvListRateCardName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "RateCardName")%>'></asp:Label>
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
                                                                                                                ToolTip="Extend Stay" CommandName="EXTENDSTAY" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ReservationID")%>'><img src="../../images/file.png" /></asp:LinkButton>
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
            </asp:View>
            <asp:View ID="vExtendStay" runat="server">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="content" style="padding-left: 0px; width: 66.66%">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="boxtopleft">
                                        &nbsp;
                                    </td>
                                    <td class="boxtopcenter">
                                        <asp:Literal ID="litMainHeader" runat="server" Text="Extend Stay"></asp:Literal>
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
                                            <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                <tr>
                                                    <td colspan="2" style="vertical-align: top; border: 1px solid #ccccce;">
                                                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                            <tr>
                                                                <td style="width: 100px;">
                                                                    <asp:Literal ID="litReservationNo" runat="server" Text="Reservation No."></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="litDspReservationNo" runat="server"></asp:Literal>
                                                                </td>
                                                                <td align="right">
                                                                    <asp:Literal ID="litName" runat="server" Text="Guest Name"></asp:Literal>
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                                                </td>
                                                                <td style="width: 190px;">
                                                                    <asp:Literal ID="litDspName" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 50%; vertical-align: top; border: 1px solid #ccccce;">
                                                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                            <tr>
                                                                <td colspan="2">
                                                                    <b>
                                                                        <asp:Literal ID="litCurrentStayInfo" Text="Current Stay Info." runat="server"></asp:Literal></b>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <hr />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 90px;">
                                                                    <asp:Literal ID="litArrivalDate" runat="server" Text="Arrival"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <%-- <asp:TextBox ID="txtArrivalDate" runat="server" Style="width: 90px !important;" onkeypress="return false;"></asp:TextBox>
                                                                    <asp:Image ID="imgArrivalDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                                        Height="20px" Width="20px" />
                                                                    <ajx:CalendarExtender ID="calArrivalDate" PopupButtonID="imgArrivalDate" TargetControlID="txtArrivalDate"
                                                                        runat="server" Format="dd-MM-yyyy">
                                                                    </ajx:CalendarExtender>
                                                                    <img src="../../images/clear.png" id="imgAD" style="vertical-align: middle;" title="Clear Date"
                                                                        onclick="fnClearDate('<%= txtArrivalDate.ClientID %>');" />--%>
                                                                    <asp:Label ID="lblDisplayArrivalDate" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litDepartureDate" runat="server" Text="Departure"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblDisplayDepartureDate" runat="server"></asp:Label>
                                                                    <%-- <asp:TextBox ID="txtDepartureDate" runat="server" Style="width: 90px !important;"
                                                                        onkeypress="return false;"></asp:TextBox>
                                                                    <asp:Image ID="imgDepartureDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                                        Height="20px" Width="20px" />
                                                                    <ajx:CalendarExtender ID="calDepartureDate" PopupButtonID="imgDepartureDate" TargetControlID="txtDepartureDate"
                                                                        runat="server" Format="dd-MM-yyyy">
                                                                    </ajx:CalendarExtender>
                                                                    <img src="../../images/clear.png" id="imgDD" style="vertical-align: middle;" title="Clear Date"
                                                                        onclick="fnClearDate('<%= txtDepartureDate.ClientID %>');" />--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litRoomType" runat="server" Text="Room Type"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:Literal runat="server" ID="litDspRoomType"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litRoomNo" runat="server" Text="Room No."></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="litDspRoomNo" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litAdultChild" runat="server" Text="Adult / Child"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="litDspAdultChild" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litRateCard" runat="server" Text="Rate Card"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="litDspRateCard" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr id="trDiscount" runat="server" visible="false">
                                                                <td>
                                                                    <asp:Literal ID="litDiscount" runat="server" Text="Discount"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="litDspDiscount" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td style="width: 50%; vertical-align: top; border: 1px solid #ccccce;">
                                                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                            <tr>
                                                                <td colspan="3">
                                                                    <b>
                                                                        <asp:Literal ID="litExtendStayInfo" Text="Extend Stay Info." runat="server"></asp:Literal></b>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3">
                                                                    <hr />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 90px;">
                                                                    <asp:Literal ID="litAddNights" runat="server" Text="Nights"></asp:Literal>
                                                                </td>
                                                                <td style="width: 120px;">
                                                                    <asp:TextBox ID="txtNight" runat="server" MaxLength="3" Style="width: 90px !important;"></asp:TextBox>
                                                                    <ajx:FilteredTextBoxExtender ID="ftNight" runat="server" TargetControlID="txtNight"
                                                                        FilterType="Numbers" />
                                                                </td>
                                                                <td valign="middle" rowspan="2">
                                                                    <asp:Button ID="btnCheckAvailibility" runat="server" Text="Check Availability" Style="display: inline;"
                                                                        OnClick="btnCheckAvailibility_Click" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 90px;">
                                                                    <asp:Literal ID="Literal7" runat="server" Text="Amount"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtAmount" runat="server" MaxLength="5" Style="width: 90px !important;"></asp:TextBox>
                                                                    <ajx:FilteredTextBoxExtender ID="ftbAmount" runat="server" TargetControlID="txtAmount"
                                                                        FilterType="Numbers" />
                                                                </td>
                                                                
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litNewDepartureDate" runat="server" Text="New Departure"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtNewDepartureDate" Enabled="false" runat="server" Style="width: 90px !important;"
                                                                        onkeypress="return false;"></asp:TextBox>
                                                                    <span>
                                                                        <asp:RequiredFieldValidator ID="rfvNewDepartureDate" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                            runat="server" ValidationGroup="IsRequire" ControlToValidate="txtNewDepartureDate"
                                                                            Display="Dynamic">
                                                                        </asp:RequiredFieldValidator>
                                                                    </span>
                                                                </td>
                                                                <td align="right" style="padding-right: 10px;">
                                                                    No. of Over stay Night(s) = <b>
                                                                        <asp:Literal ID="ltrOverStayNights" runat="server"></asp:Literal></b>
                                                                    <asp:Button ID="btnViewChart" runat="server" Text="View Chart" Visible="false" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" colspan="3">
                                                                    
                                                                    <asp:Button ID="btnCalculateRate" runat="server" Text="Calculate Rate" Style="display: inline;"
                                                                        OnClick="btnCalculateRate_Click" Visible="false" ValidationGroup="IsRequire" />
                                                                    <asp:LinkButton ID="lnkBilltoCompanySettlement" runat="server" Text="Bill to Company Settlement"
                                                                        OnClick="lnkBilltoCompanySettlement_Click" Visible="false" Style="display: inline;"></asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3" style="padding-top: 10px;">
                                                                    <b>
                                                                        <asp:Label ID="lblMakePaymentNotification" runat="server" ForeColor="Blue"></asp:Label></b>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="padding: 0;">
                                                        <table width="100%" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td valign="top" width="50%">
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td>
                                                                                <div class="box_head">
                                                                                    <span>
                                                                                        <asp:Literal ID="litExtendReservationList" runat="server" Text="Rate List"></asp:Literal>
                                                                                    </span>
                                                                                </div>
                                                                                <div class="clear">
                                                                                </div>
                                                                                <div class="box_content">
                                                                                    <div style="height: 350px; overflow: auto;">
                                                                                        <asp:GridView ID="gvRoomRate" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                                            Width="100%" OnRowDataBound="gvRoomRate_RowDataBound" SkinID="gvNoPaging">
                                                                                            <Columns>
                                                                                                <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                    <HeaderTemplate>
                                                                                                        <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                                                                                    </HeaderTemplate>
                                                                                                    <ItemTemplate>
                                                                                                        <%# Container.DataItemIndex + 1 %>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                    <HeaderTemplate>
                                                                                                        <asp:Label ID="lblGvHdrDate" runat="server" Text="Date"></asp:Label>
                                                                                                    </HeaderTemplate>
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblGvBlockDate" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "BlockDate")).ToString(clsSession.DateFormat)%>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField ItemStyle-Width="120px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                                                    <HeaderTemplate>
                                                                                                        <asp:Label ID="lblGvHdrRMRate" runat="server" Text="Room Rate"></asp:Label>
                                                                                                    </HeaderTemplate>
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblGvRMTypeRMRate" runat="server"></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Right" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Right">
                                                                                                    <HeaderTemplate>
                                                                                                        <asp:Label ID="lblGvHdrTaxes" runat="server" Text="Taxes"></asp:Label>
                                                                                                    </HeaderTemplate>
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblGvRMTypeTax" runat="server"></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField Visible="false" HeaderStyle-HorizontalAlign="Right" ItemStyle-Width="120px"
                                                                                                    ItemStyle-HorizontalAlign="Right">
                                                                                                    <HeaderTemplate>
                                                                                                        <asp:Label ID="lblGvHdrDiscount" runat="server" Text="Discount"></asp:Label>
                                                                                                    </HeaderTemplate>
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblGvRMTypeDiscount" runat="server"></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Right" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Right">
                                                                                                    <HeaderTemplate>
                                                                                                        <asp:Label ID="lblGvHdrTotal" runat="server" Text="Total"></asp:Label>
                                                                                                    </HeaderTemplate>
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblGvRMTypeTotal" runat="server"></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Right" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Right">
                                                                                                    <HeaderTemplate>
                                                                                                        <asp:Label ID="lblGvHdrPaidByCompany" runat="server" Text="Paid By Company"></asp:Label>
                                                                                                    </HeaderTemplate>
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblGvRMTypePaidByCompany" runat="server"></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Right" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Right">
                                                                                                    <HeaderTemplate>
                                                                                                        <asp:Label ID="lblGvHdrPaidByGuest" runat="server" Text="Paid By Guest"></asp:Label>
                                                                                                    </HeaderTemplate>
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblGvRMTypePaidByGuest" runat="server"></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                            </Columns>
                                                                                            <EmptyDataTemplate>
                                                                                                <div style="padding: 10px;">
                                                                                                    <b>
                                                                                                        <asp:Label ID="lblNoRecordFound" Text="No Record Found." runat="server"></asp:Label>
                                                                                                    </b>
                                                                                                </div>
                                                                                            </EmptyDataTemplate>
                                                                                        </asp:GridView>
                                                                                    </div>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trCalculation" runat="server" visible="false">
                                                                            <td colspan="3" style="border: 1px solid #ccccce;">
                                                                                <div>
                                                                                   <asp:Literal ID="ltrRoomRentPlusInfraCharges" runat="server"></asp:Literal>
                                                                                </div>
                                                                                <div style="float: right; text-align: right; width: 500px; background-color: #DCDDDF;
                                                                                    color: #0083CE; font-size: 15px; font-weight: bold; padding: 9px;">
                                                                                    <asp:Literal ID="litINRRs" runat="server" Text="INR Rs."></asp:Literal>
                                                                                    <asp:Literal ID="litOldRate" runat="server" Visible="false" Text="0.00"></asp:Literal>
                                                                                    <%--+--%>
                                                                                    <asp:Literal ID="litNewRate" runat="server" Text="0.00"></asp:Literal>
                                                                                    <%--=--%>
                                                                                    <asp:Literal ID="litTotalRate" runat="server" Visible="false" Text="0.00"></asp:Literal>
                                                                                </div>
                                                                                <div>
                                                                                    Overstay Infra. Service Charges = <asp:Literal ID="ltrOverStayInfraCharges" runat="server"></asp:Literal>
                                                                                    <br />Overstay Food Charges = <asp:Literal ID="ltrOverStayFoodCharges" runat="server"></asp:Literal>
                                                                                    <br />Overstay Electricity and Water Charges = <asp:Literal ID="ltrOverStayElectricityCharges" runat="server"></asp:Literal>
                                                                                    <br />Late Payment Charges = <asp:Literal ID="ltrLatePaymentCharges" runat="server"></asp:Literal>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right" colspan="3">
                                                                                <asp:Button ID="btnSave" ValidationGroup="IsRequire" runat="server" Text="Save" Style="display: inline;"
                                                                                    Visible="false" OnClick="btnSave_Click" />
                                                                                <asp:Button ID="btnCancel" runat="server" Text="Back" Style="display: inline;" OnClick="btnCancel_Click" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td valign="top" style="vertical-align: top; border-left: 1px solid gray;" width="50%">
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td style="padding-top: 13px;">
                                                                                <b>Receipt</b>
                                                                            </td>
                                                                            <td style="padding-top: 13px;" align="right">
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                <hr />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="130px">
                                                                                <b>Amount</b>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtPaymentAmount" runat="server" SkinID="nowidth" Width="150px"
                                                                                    MaxLength="9"></asp:TextBox>
                                                                                <ajx:FilteredTextBoxExtender ID="ftePaymentAmount" runat="server" TargetControlID="txtPaymentAmount"
                                                                                    FilterMode="ValidChars" ValidChars=".0123456789">
                                                                                </ajx:FilteredTextBoxExtender>
                                                                                <span>
                                                                                    <asp:RequiredFieldValidator ID="rfvPaymentAmount" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                                        runat="server" ValidationGroup="RequireForPayment" ControlToValidate="txtPaymentAmount"
                                                                                        Display="Dynamic">
                                                                                    </asp:RequiredFieldValidator>
                                                                                </span>
                                                                                <asp:RegularExpressionValidator ID="regPaymentAmount" SetFocusOnError="True" runat="server"
                                                                                    ValidationGroup="RequireForPayment" ControlToValidate="txtPaymentAmount" ValidationExpression="^\d{0,18}(\.\d{0,2})?$"
                                                                                    Display="Dynamic" ForeColor="Red" ErrorMessage="Two digit allowd after decimal point."></asp:RegularExpressionValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <b>Mode of Payment</b>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlModeOfPayment" runat="server" SkinID="nowidth" Width="150px"
                                                                                    OnSelectedIndexChanged="ddlModeOfPayment_OnSelectedIndexChanged" AutoPostBack="true">
                                                                                </asp:DropDownList>
                                                                                <span>
                                                                                    <asp:RequiredFieldValidator ID="rfvModeOfPayment" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                                        SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                                        ValidationGroup="RequireForPayment" ControlToValidate="ddlModeOfPayment" Display="Dynamic">
                                                                                    </asp:RequiredFieldValidator>
                                                                                </span>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trLedgerAccount" runat="server" visible="false">
                                                                            <td>
                                                                                Ledger
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlLedgerAccount" SkinID="nowidth" Width="150px" runat="server">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trChequeDD1" runat="server" visible="false">
                                                                            <td>
                                                                                Bank Name
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtBankName" SkinID="nowidth" Width="150px" runat="server"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trChequeDD2" runat="server" visible="false">
                                                                            <td>
                                                                                Cheque/DD No.
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtChequeDDNo" SkinID="nowidth" Width="150px" runat="server"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trCreditCard1" runat="server" visible="false">
                                                                            <td>
                                                                                Card Type
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlCreditCardType" SkinID="nowidth" Width="150px" runat="server">
                                                                                </asp:DropDownList>
                                                                                <span>
                                                                                    <asp:RequiredFieldValidator ID="rfvCreditCardType" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                                        SetFocusOnError="true" CssClass="input-notification error png_bg" Enabled="false"
                                                                                        runat="server" ValidationGroup="RequireForPayment" ControlToValidate="ddlCreditCardType"
                                                                                        Display="Dynamic">
                                                                                    </asp:RequiredFieldValidator>
                                                                                </span>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trCreditCard2" runat="server" visible="false">
                                                                            <td>
                                                                                Name on Card
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtNameOnCard" SkinID="nowidth" Width="150px" runat="server"></asp:TextBox>
                                                                                <span>
                                                                                    <asp:RequiredFieldValidator ID="rfvNameOnCreditCard" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                                        Enabled="false" runat="server" ValidationGroup="RequireForPayment" ControlToValidate="txtNameOnCard"
                                                                                        Display="Dynamic">
                                                                                    </asp:RequiredFieldValidator>
                                                                                </span>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trCreditCard3" runat="server" visible="false">
                                                                            <td>
                                                                                Card Number
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtCardNumber" runat="server" SkinID="nowidth" Width="150px" MaxLength="16"></asp:TextBox>
                                                                                <span>
                                                                                    <asp:RequiredFieldValidator ID="rfvCreditCardNumber" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                                        Enabled="false" runat="server" ValidationGroup="RequireForPayment" ControlToValidate="txtCardNumber"
                                                                                        Display="Dynamic">
                                                                                    </asp:RequiredFieldValidator>
                                                                                </span>
                                                                                <ajx:FilteredTextBoxExtender ID="fteCreditCardNumber" runat="server" TargetControlID="txtCardNumber"
                                                                                    FilterMode="ValidChars" ValidChars="0123456789">
                                                                                </ajx:FilteredTextBoxExtender>
                                                                                <asp:RegularExpressionValidator ID="regCreditCardNumber" runat="server" ControlToValidate="txtCardNumber"
                                                                                    ErrorMessage="Card No. must be 16 digits." Display="Dynamic" ValidationGroup="RequireForPayment"
                                                                                    ForeColor="Red" ValidationExpression="^[0-9]{16}"></asp:RegularExpressionValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trCVVNo" runat="server" visible="false">
                                                                            <td>
                                                                                CVV No.
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtCVVNo" runat="server" SkinID="nowidth" Width="150px" MaxLength="4"></asp:TextBox>
                                                                                <span>
                                                                                    <asp:RequiredFieldValidator ID="rfvCVVNumber" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                                        Enabled="false" runat="server" ValidationGroup="RequireForPayment" ControlToValidate="txtCVVNo"
                                                                                        Display="Dynamic">
                                                                                    </asp:RequiredFieldValidator>
                                                                                </span>
                                                                                <ajx:FilteredTextBoxExtender ID="fteCVVNo" runat="server" TargetControlID="txtCVVNo"
                                                                                    FilterMode="ValidChars" ValidChars="0123456789">
                                                                                </ajx:FilteredTextBoxExtender>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trCreditCard4" runat="server" visible="false">
                                                                            <td>
                                                                                Expiration Date
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlCardExpirationMonth" runat="server" SkinID="nowidth" Width="100px">
                                                                                    <asp:ListItem Text="-SELECT-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                                                    <asp:ListItem Text="January" Value="1"></asp:ListItem>
                                                                                    <asp:ListItem Text="February" Value="2"></asp:ListItem>
                                                                                    <asp:ListItem Text="March" Value="3"></asp:ListItem>
                                                                                    <asp:ListItem Text="April" Value="4"></asp:ListItem>
                                                                                    <asp:ListItem Text="May" Value="5"></asp:ListItem>
                                                                                    <asp:ListItem Text="June" Value="6"></asp:ListItem>
                                                                                    <asp:ListItem Text="July" Value="7"></asp:ListItem>
                                                                                    <asp:ListItem Text="August" Value="8"></asp:ListItem>
                                                                                    <asp:ListItem Text="September" Value="9"></asp:ListItem>
                                                                                    <asp:ListItem Text="October" Value="10"></asp:ListItem>
                                                                                    <asp:ListItem Text="November" Value="11"></asp:ListItem>
                                                                                    <asp:ListItem Text="December" Value="12"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                <span>
                                                                                    <asp:RequiredFieldValidator ID="rfvCardExpirationMonth" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                                        SetFocusOnError="true" CssClass="input-notification error png_bg" Enabled="false"
                                                                                        runat="server" ValidationGroup="RequireForPayment" ControlToValidate="ddlCardExpirationMonth"
                                                                                        Display="Static">
                                                                                    </asp:RequiredFieldValidator>
                                                                                </span>
                                                                                <asp:DropDownList ID="ddlCardExpirationYear" runat="server" SkinID="nowidth" Width="90px">
                                                                                </asp:DropDownList>
                                                                                <span>
                                                                                    <asp:RequiredFieldValidator ID="rfvCardExpirationYear" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                                        SetFocusOnError="true" CssClass="input-notification error png_bg" Enabled="false"
                                                                                        runat="server" ValidationGroup="RequireForPayment" ControlToValidate="ddlCardExpirationYear"
                                                                                        Display="Dynamic">
                                                                                    </asp:RequiredFieldValidator>
                                                                                </span>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trSavePaymentButton" runat="server" visible="false">
                                                                            <td>
                                                                            </td>
                                                                            <td style="padding-top: 5px;">
                                                                                <asp:Button ID="btnSavePayment" runat="server" Text="Save" Style="display: inline;"
                                                                                    ValidationGroup="RequireForPayment" OnClick="btnSavePayment_OnClick" OnClientClick="hidebutton();" />
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
                                <%--<uc1:MsgBox ID="MessageBox" runat="server" />--%>
                            </div>
                        </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="vExtendGuestStay" runat="server">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="content" style="padding-left: 0px; width: 66.66%">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="boxtopleft">
                                        &nbsp;
                                    </td>
                                    <td class="boxtopcenter">
                                        <asp:Literal ID="Literal2" runat="server" Text="Extend Stay"></asp:Literal>
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
                                            <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                <tr>
                                                    <td colspan="2">
                                                        <%if (IsReservationMsg)
                                                          { %>
                                                        <div class="message finalsuccess">
                                                            <p>
                                                                <strong>
                                                                    <asp:Label ID="lblMessage" runat="server"></asp:Label></strong>
                                                            </p>
                                                        </div>
                                                        <%}%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: top; border: 1px solid #ccccce;" colspan="2">
                                                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                            <tr>
                                                                <td style="width: 80px;">
                                                                    <asp:Literal ID="litBookingNo" runat="server" Text="Booking #"></asp:Literal>
                                                                </td>
                                                                <td style="width: 175px;">
                                                                    <asp:Literal ID="litDisplayBookingNo" runat="server"></asp:Literal>
                                                                </td>
                                                                <td style="width: 100px;">
                                                                    <asp:Literal ID="litGuestName" runat="server" Text="Guest Name"></asp:Literal>
                                                                </td>
                                                                <td style="width: 175px;">
                                                                    <asp:Literal ID="litDisplayGuestName" runat="server"></asp:Literal>
                                                                </td>
                                                                <td style="width: 100px;">
                                                                    <asp:Literal ID="litCheckInDate" runat="server" Text="Check In"></asp:Literal>
                                                                </td>
                                                                <td style="width: 100px;">
                                                                    <asp:Literal ID="litDisplayCheckInDate" runat="server"></asp:Literal>
                                                                </td>
                                                                <td style="width: 100px;">
                                                                    <asp:Literal ID="litCheckOutDate" runat="server" Text="Check Out"></asp:Literal>
                                                                </td>
                                                                <td style="width: 190px;">
                                                                    <asp:Literal ID="litDisplayCheckOutDate" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litGuestRateCard" runat="server" Text="Rate Card"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="litDisplayGuestRateCard" runat="server"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="litGuestRoomType" runat="server" Text="Room Type"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="litDisplayGuestRoomType" runat="server"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="litGuestRoomNo" runat="server" Text="Room No."></asp:Literal>
                                                                </td>
                                                                <td colspan="3">
                                                                    <asp:Literal ID="litDisplayGuestRoomNo" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 75px;" class="isrequire">
                                                        <asp:Literal ID="litAssignRoomNo" runat="server" Text="Room No."></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlAssignRoomNo" runat="server">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="rfvAssignRoomNo" InitialValue="00000000-0000-0000-0000-000000000000"
                                                            SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                            ValidationGroup="IsRequireExtendStay" ControlToValidate="ddlAssignRoomNo" Display="Dynamic">
                                                        </asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" colspan="2">
                                                        <asp:Button ID="btnUpdateGuestRoom" runat="server" Text="Save" OnClick="btnUpdateGuestRoom_Click"
                                                            ValidationGroup="IsRequireExtendStay" Style="display: inline;" />
                                                        <asp:Button ID="btnBackChangeRoom" runat="server" Text="Back" OnClick="btnBackChangeRoom_Click"
                                                            Style="display: inline;" />
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
                                <%--<uc1:MsgBox ID="MessageBox" runat="server" />--%>
                            </div>
                        </td>
                    </tr>
                </table>
            </asp:View>
        </asp:MultiView>
        <asp:HiddenField ID="hdnOpenExtandResVoucher" runat="server" />
        <ajx:ModalPopupExtender ID="mpeExtandResVoucher" runat="server" TargetControlID="hdnOpenExtandResVoucher"
            PopupControlID="pnlExtandResVoucher" CancelControlID="iBtnCacelExtandResVoucher"
            BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:Panel ID="pnlExtandResVoucher" runat="server" Width="750px">
            <div class="box_col1">
                <div class="box_head">
                    <div style="display: inline;">
                        <span>
                            <asp:Literal ID="Literal3" runat="server" Text="Extand Reservation Voucher"></asp:Literal></span></div>
                    <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                        <asp:ImageButton ID="iBtnCacelExtandResVoucher" runat="server" ImageUrl="~/images/closepopup.png"
                            Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;" />
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table width="100%">
                        <tr>
                            <td align="center">
                                <div style="height: 450px; overflow: auto;">
                                    <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                        <tr>
                                            <td align="center">
                                                <b>
                                                    <asp:Literal ID="litCheckInVoucher" runat="server" Text="Extand Reservation Voucher"></asp:Literal></b>
                                                <hr />
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
                                                                        <asp:Literal ID="Literal4" runat="server" Text="Mobile No."></asp:Literal>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Literal ID="litChVchrMobileNo" runat="server"></asp:Literal>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Literal ID="Literal5" runat="server" Text="Email"></asp:Literal>
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
                                                                        <%--3 Month (Long Stay)--%>
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
                                                                                <td style="padding: 0px;" colspan="3">
                                                                                    <hr />
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
                                                                                <td style="padding: 0px;" colspan="3">
                                                                                    <hr />
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
                                                                                <td style="padding: 0px;" colspan="3">
                                                                                    <hr />
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
                                                                                <td style="padding: 0px;" colspan="3">
                                                                                    <hr />
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
                                            <td colspan="4" align="left" style="text-align: justify; width: 780px;">
                                                <asp:Label ID="lblChVchrHousingRules" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnPrintExtandResVoucher" runat="server" style="display:inline;" Text="Print" OnClientClick="fnOpenCheckInVoucherPrintWindow();" />
                                <asp:Button ID="btnEmailExtendVoucher" runat="server" Text="Email" style="display:inline;" OnClick="btnEmailExtendVoucher_OnClick" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <asp:HiddenField ID="hfPopupCustomeMessage" runat="server" />
        <ajx:ModalPopupExtender ID="mpeCustomePopup" runat="server" TargetControlID="hfPopupCustomeMessage"
            PopupControlID="pnlCustomeMessage" BackgroundCssClass="mod_background" DropShadow="true"
            BehaviorID="mpeCustomePopup" CancelControlID="iBtnCancelPopup">
        </ajx:ModalPopupExtender>
        <asp:Panel ID="pnlCustomeMessage" runat="server" Width="350px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <div style="display: inline;">
                        <span>
                            <asp:Literal ID="litHeaderCustomePopupMessage" runat="server" Text="Message"></asp:Literal></span></div>
                    <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                        <asp:ImageButton ID="iBtnCancelPopup" runat="server" ImageUrl="~/images/closepopup.png"
                            Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;" />
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td align="left" style="padding-bottom: 15px; color: Red;">
                                <asp:Label ID="lblCustomePopupMsg" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnOKCustomeMsgPopup" runat="server" Text="Reallocate" Style="display: inline;
                                    padding-right: 10px;" OnClick="btnOKCustomeMsgPopup_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <asp:HiddenField ID="hfDateFormat" runat="server" />
        <ajx:ModalPopupExtender ID="mpeBillToCompany" runat="server" TargetControlID="hdnBillToCompany"
            PopupControlID="pnlBillToCompany" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnBillToCompany" runat="server" />
        <asp:Panel ID="pnlBillToCompany" runat="server" Width="750px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <div style="display: inline;">
                        <span>
                            <asp:Literal ID="litBillToCompany" runat="server" Text="Bill To Company"></asp:Literal></span></div>
                    <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                        <asp:ImageButton ID="iBtnCloseForm" runat="server" ImageUrl="~/images/closepopup.png"
                            Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;" /></div>
                    <div class="clear">
                    </div>
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td colspan="2">
                                <%if (IsListMessage)
                                  { %>
                                <div class="message finalsuccess">
                                    <p>
                                        <strong>
                                            <asp:Label ID="lblListMessage" runat="server"></asp:Label></strong>
                                    </p>
                                </div>
                                <%}%>
                            </td>
                        </tr>
                        <tr>
                            <td width="80px">
                                <b>Billing Mode</b>
                            </td>
                            <td>
                                <asp:Literal ID="litDisplayBillingMode" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <fieldset style="border: 1px solid #ccc !important;">
                                    <legend>Bill To Company </legend>
                                    <table cellpadding="2" cellspacing="2" width="100%">
                                        <tr>
                                            <td style="width: 110px;">
                                                Bill To Company
                                            </td>
                                            <td>
                                                <%--OnSelectedIndexChanged="ddlDiscountType_OnSelectedIndexChanged" AutoPostBack="true"--%>
                                                <asp:DropDownList ID="ddlDiscountType" runat="server" Style="width: 90px !important;">
                                                    <asp:ListItem Value="0" Text="%"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Flat"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td colspan="2">
                                                Amount &nbsp;&nbsp;
                                                <asp:TextBox ID="txtCompnayWillBare" runat="server" MaxLength="18" Style="width: 100px;"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvCompnayWillBare" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                    runat="server" ValidationGroup="BillToCompany" ControlToValidate="txtCompnayWillBare"
                                                    Display="Dynamic">
                                                </asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="revDiscountType" SetFocusOnError="True" runat="server"
                                                    ValidationGroup="BillToCompany" ControlToValidate="txtCompnayWillBare" Display="Dynamic"
                                                    ForeColor="Red" ValidationExpression="^\d{0,18}(\.\d{0,2})?$" ErrorMessage="2 digits allowed after decimal point."></asp:RegularExpressionValidator>
                                                <ajx:FilteredTextBoxExtender ID="ftCompnayWillBare" runat="server" TargetControlID="txtCompnayWillBare"
                                                    ValidChars="0123456789." FilterMode="ValidChars">
                                                </ajx:FilteredTextBoxExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="lblDiscountErrorMsg" runat="server" ForeColor="Red"></asp:Label>
                                            </td>
                                            <td colspan="2" align="right">
                                                <asp:Button ID="btnApply" runat="server" Text="Apply" OnClick="btnApply_Click" CausesValidation="true"
                                                    ValidationGroup="BillToCompany" />
                                            </td>
                                        </tr>
                                    </table>
                                </fieldset>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpeAmoutIsLargerThanSuggestedAlert" runat="server" TargetControlID="hfAmoutIsLargerThanSuggestedAlert"
            PopupControlID="pnlAmoutIsLargerThanSuggestedAlert" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hfAmoutIsLargerThanSuggestedAlert" runat="server" />
        <asp:Panel ID="pnlAmoutIsLargerThanSuggestedAlert" runat="server" Style="display: none;
            min-height: 150px; min-width: 350px;">
            <div class="box_col1" style="height: 150px; width: 500px;">
                <div class="box_head">
                    <div style="display: inline;">
                        <span>
                            <asp:Literal ID="Literal25" runat="server" Text="Alert Message"></asp:Literal></span></div>
                    <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                        <asp:ImageButton ID="iBtnSuggestedAmountClosePopup" runat="server" ImageUrl="~/images/closepopup.png"
                            Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;" />
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%" style="margin-top: 0px;">
                        <tr>
                            <td align="center" style="padding-bottom: 15px;">
                                <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="Paying amount is greater than suggested amount. Are you sure you want to proceed?"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnYesAmoutIsLargerThanSuggestedAlert" Text="Yes" runat="server"
                                    OnClick="btnOKAmoutIsLargerThanSuggestedAlert_OnClick" Style="display: inline;
                                    padding-right: 10px;" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpePrintReceipt" runat="server" TargetControlID="hdnPrintReceipt"
            PopupControlID="pnlPrintReceipt" BehaviorID="mpePrintReceipt" CancelControlID="iBtnClosePaymentReceipt"
            BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnPrintReceipt" runat="server" />
        <asp:Panel ID="pnlPrintReceipt" runat="server" Width="400px">
            <div class="box_col1">
                <div class="box_head">
                    <div style="display: inline;">
                        <span>
                            <asp:Literal ID="Literal6" runat="server" Text="Payment Receipt"></asp:Literal></span></div>
                    <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                        <asp:ImageButton ID="iBtnClosePaymentReceipt" runat="server" ImageUrl="~/images/closepopup.png"
                            Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;" />
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table width="100%">
                        <tr>
                            <td align="left">
                                <ucCtrlPaymentReceipt:PaymentReceipt ID="ucPaymentReceipt" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:HiddenField ID="hfOldGuestEmail" runat="server" />
                                Guest Email:&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtGuestEmail" SkinID="nowidth" Width="250px" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvRequire2SendGuestEmail" SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                     ValidationGroup="IsRequire4GuestEmail" ControlToValidate="txtGuestEmail" Display="Dynamic">
                                </asp:RequiredFieldValidator>
                                <span>
                                <asp:RegularExpressionValidator ID="revGuestEmail" Display="Dynamic" ValidationGroup="IsRequire4GuestEmail"
                                     runat="server" ErrorMessage="Please Enter Valid Email" ForeColor="Red" ControlToValidate="txtGuestEmail"
                                     ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnPaymentPrintReceipt" runat="server" Text="Print" style="display:inline;" OnClientClick="return fnopenPrintWindow();" />
                                <asp:Button ID="btnEmailPaymentReceipt" runat="server" Text="Email" style="display:inline;" ValidationGroup="IsRequire4GuestEmail" OnClick="btnEmailPaymentReceipt_OnClick" />
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
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updExtendReservation" ID="UpdateProgressExtendReservation"
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
