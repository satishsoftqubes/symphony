<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlSwapRoom.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Guest.CtrlSwapRoom" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function SelectReservation() {
        var isChecked = 0;
        var c = document.getElementsByTagName('input');
        for (var i = 1; i < c.length; i++) {
            if (c[i].type == 'checkbox') {
                if (c[i].checked) {
                    isChecked++;
                }
            }
        }

        if (isChecked == 0) {
            document.getElementById('<%= lblCustomErrorMessage.ClientID %>').innerHTML = "Please Select Reservation.";
            $find('mpeCustomePopup').show();
            return false;
        }
        else if (isChecked > 1) {
            document.getElementById('<%= lblCustomErrorMessage.ClientID %>').innerHTML = "Please Select only one Reservation.";
            $find('mpeCustomePopup').show();
            return false;
        }

    }

</script>
<asp:UpdatePanel ID="updSwapRoom" runat="server">
    <ContentTemplate>
        <asp:MultiView ID="mvSwapUnit" runat="server">
            <asp:View ID="View1" runat="server">
                <div class="box_col1">
                    <div class="box_head">
                        <span>
                            <asp:Literal ID="Literal1" runat="server" Text="Swap Room Setup"></asp:Literal></span></div>
                    <div class="clear">
                    </div>
                    <div class="box_form">
                        <table cellpadding="2" cellspacing="2" width="100%">
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
                                                Width="100%" DataKeyNames="Balance" OnRowDataBound="gvResevationList_RowDataBound" OnRowCommand="gvResevationList_RowCommand" OnPageIndexChanging="gvResevationList_PageIndexChanging">
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
                                                    <asp:TemplateField ItemStyle-Width="140px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
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
                                                                                            ToolTip="View" CommandName="SWAPROOM" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ReservationID")%>'><img src="../../images/file.png" /></asp:LinkButton>
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
            <asp:View ID="vSwapUnit" runat="server">
                <div class="box_col1">
                    <div class="box_head">
                        <span>
                            <asp:Literal ID="litSwapUnitHeader" runat="server" Text="Swap Room Setup"></asp:Literal></span></div>
                    <div class="clear">
                    </div>
                    <div class="box_form">
                        <table cellpadding="2" cellspacing="2" width="100%">
                            <tr>
                                <td colspan="4">
                                    <div style="float: left; width: 75px;">
                                        <asp:Literal ID="litSwapUnitUnitNo" runat="server" Text="Room Type"></asp:Literal>
                                    </div>
                                    <div style="float: left; width: 200px;">
                                        <asp:Literal ID="litDisplaySwapUnitRoomType" runat="server"></asp:Literal>
                                    </div>
                                    <div style="float: left; width: 100px;">
                                        <asp:Literal ID="litSwapUnitBookingNo" runat="server" Text="Booking #"></asp:Literal>
                                    </div>
                                    <div style="float: left; width: 100px;">
                                        <asp:Literal ID="litDisplaySwapUnitBookingNo" runat="server"></asp:Literal>
                                    </div>
                                    <div style="float: left; width: 100px;">
                                        <asp:Literal ID="litSwapUnitName" runat="server" Text="Name"></asp:Literal>
                                    </div>
                                    <div style="float: left;">
                                        <asp:Literal ID="litDisplaySwapUnitName" runat="server"></asp:Literal>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <hr />
                                </td>
                            </tr>
                            <tr>
                                <td style="vertical-align: top; width: 11%;">
                                    <div class="moveroom_currentstatus_bg">
                                        <div class="moveroom_currentstatus_content">
                                            <asp:Literal ID="litSwapUnitCheckInDate" runat="server" Text="Check In"></asp:Literal><br />
                                            <asp:Literal ID="litDisplaySwapUnitCheckInDate" runat="server"></asp:Literal><br />
                                            <br />
                                            <asp:Literal ID="litSwapUnitCheckOutDate" runat="server" Text="Check Out"></asp:Literal><br />
                                            <asp:Literal ID="litDisplaySwapUnitCheckOutDate" runat="server"></asp:Literal><br />
                                            <br />
                                            <asp:Literal ID="litSwapUnitRoomStatus" runat="server" Text="Room No."></asp:Literal><br />
                                            <asp:Literal ID="litDisplaySwapUnitRoomNumber" runat="server"></asp:Literal><br />
                                            <br />
                                            <asp:Literal ID="litSwapUnitFolioBalance" runat="server" Text="Folio Balance"></asp:Literal><br />
                                            <asp:Literal ID="litDisplaySwapUnitFolioBalance" runat="server"></asp:Literal>
                                        </div>
                                    </div>
                                </td>
                                <td style="vertical-align: top;" colspan="3">
                                    <table cellpadding="2" cellspacing="2" width="100%">
                                        <tr>
                                            <td>
                                                <fieldset style="border: 1px solid #ccc !important;">
                                                    <legend>
                                                        <asp:Literal ID="litSearch" runat="server" Text="Search"></asp:Literal>
                                                    </legend>
                                                    <table>
                                                        <tr>
                                                            <td width="90px">
                                                                <asp:Literal ID="litSearchSwapUnitRoomNo" runat="server" Text="Room No."></asp:Literal>
                                                            </td>
                                                            <td width="350px">
                                                                <asp:TextBox ID="txtSearchSwapUnitRoomNo" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td width="90px">
                                                                <asp:Literal ID="litSearchSwapUnitBookingNo" runat="server" Text="Booking #"></asp:Literal>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtSearchSwapUnitBookingNo" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Literal ID="litSearchSwapUnitGuestName" runat="server" Text="Name"></asp:Literal>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtSearchSwapUnitGuestName" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:Literal ID="litSearchSwapUnitUnitType" runat="server" Text="Room Type"></asp:Literal>
                                                            </td>
                                                            <td>
                                                                <%--<asp:DropDownList ID="ddlSearchSwapUnitUnitType" runat="server" AutoPostBack="true"
                                                                    OnSelectedIndexChanged="ddlSwapUnitUnitType_SelectedIndexChanged">--%>
                                                                <asp:DropDownList ID="ddlSearchSwapUnitUnitType" runat="server">
                                                                </asp:DropDownList>
                                                                <asp:ImageButton ID="btnSearch" runat="server" ToolTip="Search" ImageUrl="~/images/search-icon.png"
                                                                    Style="border: 0px; margin: -4px 0 0 5px; vertical-align: middle;" OnClick="btnSearch_Click" />
                                                                <asp:ImageButton ID="imgbtnClearSearch" runat="server" ToolTip="Clear" ImageUrl="~/images/clearsearch.png"
                                                                    Style="border: 0px; vertical-align: middle; margin: 0 0 0 10px;" OnClick="imgbtnClearSearch_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </fieldset>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: top;">
                                                <div class="box_head">
                                                    <span>
                                                        <asp:Literal ID="litSwapUnitList" runat="server" Text="Reservation List"></asp:Literal>
                                                    </span>
                                                </div>
                                                <div class="clear">
                                                </div>
                                                <div class="box_content">
                                                    <div style="height: 500px; overflow: auto;">
                                                        <asp:GridView ID="gvSwapUnitList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                            Width="100%" SkinID="gvNoPaging" OnRowDataBound="gvSwapUnitList_RowDataBound">
                                                            <Columns>
                                                                <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblGvHdrSwapUnitSrNo" runat="server" Text="No."></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex + 1 %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblGvHdrSelect" runat="server" Text="Select"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chkSelect" runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblGvHdrReservationNo" runat="server" Text="Booking #"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblGvReservationNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ReservationNo")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="140px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblGvHdrUnitType" runat="server" Text="Room Type"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblGvRoomTypeName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "RoomTypeName")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblGvHdrRoomNo" runat="server" Text="Room No."></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblGvRoomNo" runat="server"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblGvHdrSwapGuestName" runat="server" Text="Name"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <%#DataBinder.Eval(Container.DataItem, "GuestFullName")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblGvHdrMobileNo" runat="server" Text="Mobile No."></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblGvPhone" runat="server"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblGvHdrCheckIn" runat="server" Text="Check In"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblGvCheckInDate" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "CheckInDate")).ToString(clsSession.DateFormat)%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblGvHdrCheckOut" runat="server" Text="Check Out"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblGvCheckOutDate" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "CheckOutDate")).ToString(clsSession.DateFormat)%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EmptyDataTemplate>
                                                                <div style="padding: 10px;">
                                                                    <b>
                                                                        <asp:Label ID="lblSwapUnitRecordFound" runat="server" Text="No Record Found."></asp:Label>
                                                                    </b>
                                                                </div>
                                                            </EmptyDataTemplate>
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="vertical-align: top;">
                                                <fieldset style="border: 1px solid #ccc !important;">
                                                    <legend>
                                                        <asp:Literal ID="litReasontoSwapRoom" runat="server" Text="Reason to Swap Room"></asp:Literal>
                                                    </legend>
                                                    <asp:TextBox ID="txtReasontoSwapRoom" Style="margin: 5px; width: 500px !important;"
                                                        TextMode="MultiLine" runat="server"></asp:TextBox>
                                                </fieldset>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="4">
                                                <asp:Button ID="btnSwapUnitSave" runat="server" Style="display: inline; padding-right: 10px;"
                                                    Text="Save" OnClientClick="return SelectReservation();" />
                                                <asp:Button ID="btnSwapUnitHistory" runat="server" Style="display: inline;" Text="History"
                                                    OnClick="btnSwapUnitHistory_Click" />
                                                <asp:Button ID="btnSwapUnitCancel" runat="server" Style="display: inline;" Text="Cancel" OnClick="btnSwapUnitCancel_Click" />
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
            </asp:View>
            <asp:View ID="vSwapUnitHistory" runat="server">
                <div class="box_col1">
                    <div class="box_head">
                        <span>
                            <asp:Literal ID="litSwapUnitHistory" runat="server" Text="Swap Room History"></asp:Literal></span></div>
                    <div class="clear">
                    </div>
                    <div class="box_form">
                        <table cellpadding="2" cellspacing="2" width="100%">
                            <tr>
                                <td width="100%" style="height: 150px; overflow: auto; vertical-align: top;">
                                    <div class="box_head">
                                        <span>
                                            <asp:Literal ID="litSwapUnitHistoryList" runat="server" Text="Swap Room History List"></asp:Literal>
                                        </span>
                                    </div>
                                    <div class="clear">
                                    </div>
                                    <div class="box_content">
                                        <asp:GridView ID="gvSwapUnitHistoryList" runat="server" AutoGenerateColumns="false"
                                            ShowHeader="true" Width="100%">
                                            <Columns>
                                                <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrSwapUnitHistorySrNo" runat="server" Text="No."></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrSwapUnitHistoryOldUnitNo" runat="server" Text="Old Room No."></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#DataBinder.Eval(Container.DataItem, "OldUnitNo")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrSwapUnitHistoryNewUnitNo" runat="server" Text="New Room No."></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#DataBinder.Eval(Container.DataItem, "NewUnitNo")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrSwapUnitHistoryDateOfSwap" runat="server" Text="Date Of Swap"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#DataBinder.Eval(Container.DataItem, "DateOfSwap")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrSwapUnitHistoryReason" runat="server" Text="Reason"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#DataBinder.Eval(Container.DataItem, "Reason")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <div style="padding: 10px;">
                                                    <b>
                                                        <asp:Label ID="lblNoRecordFoundForSwapUnitHistory" runat="server" Text="No Record Found."></asp:Label>
                                                    </b>
                                                </div>
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Button ID="btnSwapUnitHistoryCancel" runat="server" Text="Cancel" OnClick="btnSwapUnitHistoryCancel_Click" />
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
                                <asp:Label ID="lblCustomErrorMessage" runat="server"></asp:Label>
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
    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updSwapRoom" ID="UpdateProgressSwapRoom"
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
