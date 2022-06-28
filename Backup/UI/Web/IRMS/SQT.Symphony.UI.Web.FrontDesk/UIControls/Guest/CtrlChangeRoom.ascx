<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlChangeRoom.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Guest.CtrlChangeRoom" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script src="../../Scripts/jquery-1.8.2.js"></script>
<script src="../../Scripts/jquery-ui.js"></script>
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

    function fnClick(para1, para2) {
        document.getElementById('<%=hdnRMID.ClientID %>').value = para1;
        document.getElementById('<%=hdnRMNo.ClientID %>').value = para2
        $find('mpeReservationProceed').show();
    }
</script>
<style type="text/css">
    .container
    {
        margin: 0;
        width: 800px;
    }
    .item
    {
        float: left;
        width: 113px;
        height: 40px;
    }
    .clear
    {
        clear: both;
        width: 100%;
        height: 1px;
    }
    .availableroom
    {
        background-color: #2e8b57;
    }
    
    .bookedroom
    {
        background-color: #0080FF;
    }
    
    .oosroom
    {
        background-color: Maroon;
    }
    
    .checkinroom
    {
        background-color: #0101DF;
    }
    
    h1, p
    {
        font-weight: normal;
        font-size: 10px;
        margin: 0px;
        padding: 0px;
        color: Black;
    }
</style>
<asp:UpdatePanel ID="updChangeRoom" runat="server">
    <ContentTemplate>
        <asp:HiddenField ID="hdnRMID" runat="server" />
        <asp:HiddenField ID="hdnRMNo" runat="server" />
        <asp:MultiView ID="mvChangeRoom" runat="server">
            <asp:View ID="vReservationList" runat="server">
                <div class="box_col1">
                    <div class="box_head">
                        <span>
                            <asp:Literal ID="Literal1" runat="server" Text="Change Room"></asp:Literal></span></div>
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
                                                Width="100%" DataKeyNames="Balance,RoomTypeID,RoomID,RateID,CheckOutDate,FolioID"
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
                                                                                            ToolTip="Change Room" CommandName="MOVEROOM" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ReservationID")%>'><img src="../../images/file.png" /></asp:LinkButton>
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
            <asp:View ID="vChangeRoom" runat="server">
                <div class="box_col1">
                    <div class="box_head">
                        <span>
                            <asp:Literal ID="litMoveUnitHeader" runat="server" Text="Change Room"></asp:Literal></span></div>
                    <div class="clear">
                    </div>
                    <div class="box_form">
                        <table cellpadding="2" cellspacing="2" width="100%">
                            <tr>
                                <td colspan="2">
                                    <div style="float: left; width: 75px;">
                                        <asp:Literal ID="litMoveUnitRoomNoAndRoomType" runat="server" Text="Room No."></asp:Literal>
                                    </div>
                                    <div style="float: left; width: 250px;">
                                        <asp:Literal ID="litDisplayMoveUnitRoomNoAndRoomType" runat="server"></asp:Literal>
                                    </div>
                                    <div style="float: left; width: 80px;">
                                        <asp:Literal ID="litMoveUnitReservationNo" runat="server" Text="Booking #"></asp:Literal>
                                    </div>
                                    <div style="float: left; width: 100px;">
                                        <asp:Literal ID="litDisplayMoveUnitReservationNo" runat="server"></asp:Literal>
                                    </div>
                                    <div style="float: left; width: 75px;">
                                        <asp:Literal ID="litMoveUnitGuestName" runat="server" Text="Name"></asp:Literal>
                                    </div>
                                    <div style="float: left;">
                                        <asp:Literal ID="litDisplayMoveUnitGuestName" runat="server"></asp:Literal>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <hr />
                                </td>
                            </tr>
                            <tr>
                                <td style="vertical-align: top; width: 11%;">
                                    <%--<div style="background-color: #CCCCCC; min-height: 50px; width: 100px;">--%>
                                    <div class="moveroom_currentstatus_bg">
                                        <div class="moveroom_currentstatus_content">
                                            <%--<asp:Literal ID="litMoveUnitCurrentStatus" runat="server" Text="Current Status"></asp:Literal>
                                <br />--%>
                                            <asp:Literal ID="litMoveUnitCheckInDate" runat="server" Text="Check In"></asp:Literal><br />
                                            <asp:Literal ID="litDisplayMoveUnitCheckInDate" runat="server"></asp:Literal><br />
                                            <br />
                                            <asp:Literal ID="litMoveUnitCheckOutDate" runat="server" Text="Check Out"></asp:Literal><br />
                                            <asp:Literal ID="litDisplayMoveUnitCheckOutDate" runat="server"></asp:Literal><br />
                                            <br />
                                            <asp:Literal ID="litMoveUnitRoomStatus" runat="server" Text="Room No."></asp:Literal><br />
                                            <asp:Literal ID="litDisplayMoveUnitRoomNo" runat="server"></asp:Literal><br />
                                            <br />
                                            <asp:Literal ID="litMoveUnitFolioBalance" runat="server" Text="Folio Balance"></asp:Literal><br />
                                            <asp:Literal ID="litDisplayMoveUnitFolioBalance" runat="server"></asp:Literal>
                                        </div>
                                    </div>
                                </td>
                                <td style="vertical-align: top;">
                                    <table cellpadding="2" cellspacing="2" width="100%">
                                        <tr>
                                            <td>
                                                <asp:Literal ID="litMoveUnitRoomType" runat="server" Text="Room Type"></asp:Literal>&nbsp;&nbsp;&nbsp;
                                                <asp:DropDownList ID="ddlMoveUnitUnitType" runat="server" AutoPostBack="true">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 150px; overflow: auto;">
                                                <div class="box_head">
                                                    <span>
                                                        <asp:Literal ID="litMoveUnitList" runat="server" Text="Room List"></asp:Literal>
                                                    </span>
                                                </div>
                                                <div class="clear">
                                                </div>
                                                <div class="box_content">
                                                    <asp:GridView ID="gvMoveUnitList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                        Width="100%" OnRowDataBound="gvMoveUnitList_RowDataBound" OnPageIndexChanging="gvMoveUnitList_PageIndexChanging"
                                                        DataKeyNames="RoomID">
                                                        <Columns>
                                                            <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrMoveUnitSrNo" runat="server" Text="No."></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrSelect" runat="server" Text="Select"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chkSelectRoom" runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrMoveUnitUnitNo" runat="server" Text="Room No."></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGvMoveUnitRoomNo" runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrMoveUnitUnitNo" runat="server" Text="Block Name"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "WingFloor")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--<asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblGvHdrMoveUnitBeds" runat="server" Text="Beds"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <%#DataBinder.Eval(Container.DataItem, "Beds")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblGvHdrMoveUnitAdultChild" runat="server" Text="Adult/Child"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <%#DataBinder.Eval(Container.DataItem, "ADTCHILD")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                        </Columns>
                                                        <EmptyDataTemplate>
                                                            <div style="padding: 10px;">
                                                                <b>
                                                                    <asp:Label ID="lblMoveUnitRecordFound" runat="server" Text="No Record Found."></asp:Label>
                                                                </b>
                                                            </div>
                                                        </EmptyDataTemplate>
                                                    </asp:GridView>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <fieldset style="border: 1px solid #ccc !important;">
                                                    <legend>
                                                        <asp:Literal ID="litReasontoMoveRoom" runat="server" Text="Reason to Move Room"></asp:Literal>
                                                    </legend>
                                                    <asp:TextBox ID="txtReasontoMoveRoom" Style="margin: 5px; width: 500px !important;"
                                                        TextMode="MultiLine" runat="server"></asp:TextBox>
                                                </fieldset>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <asp:Button ID="btnMoveUnitSave" runat="server" Style="display: inline; padding-right: 10px;"
                                                    Text="Save" Visible="false" OnClientClick="return ValidateRoom();" />
                                                <asp:Button ID="btnMoveUnitHistory" runat="server" Style="display: inline;" Text="History" />
                                                <asp:Button ID="btnMoveUnitCancel" runat="server" Style="display: inline;" Text="Cancel" />
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
            <asp:View ID="vAvailabilityChart" runat="server">
                <div class="box_col1">
                    <div class="box_head">
                        <span>
                            <asp:Literal ID="Literal2" runat="server" Text="Change Room"></asp:Literal></span></div>
                    <div class="clear">
                    </div>
                    <div class="box_form">
                        <table cellpadding="2" cellspacing="2" width="100%">
                            <tr>
                                <td style="border: 1px solid gary;">
                                    <table width="100%" cellpadding="2" cellspacing="2">
                                        <tr>
                                            <td width="60px">
                                                Booking #
                                            </td>
                                            <td width="150px">
                                                <asp:Literal ID="ltrChkPmtReservationNo" runat="server"></asp:Literal>
                                            </td>
                                            <td width="70px">
                                                Guest Name
                                            </td>
                                            <td width="150px">
                                                <asp:Literal ID="ltrChkPmtGuestName" runat="server"></asp:Literal>
                                            </td>
                                            <td width="50px">
                                                Check In
                                            </td>
                                            <td width="100px">
                                                <asp:Literal ID="ltrChkPmtCheckInDate" runat="server"></asp:Literal>
                                            </td>
                                            <td width="50px">
                                                Check Out
                                            </td>
                                            <td width="100px">
                                                <asp:Literal ID="ltrChkPmtCheckOutDate" runat="server"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Room Type
                                            </td>
                                            <td>
                                                <asp:Literal ID="ltrChkPmtRoomType" runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                Room No.
                                            </td>
                                            <td colspan="5">
                                                <asp:Literal ID="ltrChkPmtRoomNo" runat="server"></asp:Literal>
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
                                <td>
                                    <div id="dvChart" visible="false" runat="server" style="height: 500px; width: 1000px;
                                        overflow: auto;">
                                    </div>
                                    <div style="text-align: center; margin-top: 10px;">
                                        <asp:Button ID="btnBackFromRoomChart" runat="server" Text="Back" Style="display: inline;"
                                            OnClick="btnBackFromRoomChart_OnClick" />
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="clear">
                    </div>
                </div>
            </asp:View>
        </asp:MultiView>
        <ajx:ModalPopupExtender ID="mpeReservationProceed" runat="server" TargetControlID="hdnReservationProceed"
            PopupControlID="pnlReservationProceed" BackgroundCssClass="mod_background" CancelControlID="iBtnCloseChangeRoomPopup"
            BehaviorID="mpeReservationProceed">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnReservationProceed" runat="server" />
        <asp:Panel ID="pnlReservationProceed" runat="server" Width="400px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <div style="display: inline;">
                        <span>
                            <asp:Literal ID="litHeaderReservationProceed" runat="server" Text="Message"></asp:Literal></span>
                    </div>
                    <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                        <asp:ImageButton ID="iBtnCloseChangeRoomPopup" runat="server" ImageUrl="~/images/closepopup.png"
                            Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;" />
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td align="center">
                                <asp:Label ID="lblChangeRoomMsg" runat="server" Text="Are you sure want to change room ?"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnOKChangeRoom" runat="server" Text="OK" OnClick="btnOKChangeRoom_Click" />
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
            PopupControlID="pnlCustomeMessage" BackgroundCssClass="mod_background" CancelControlID="ibtnCancelCustomMsgPopup"
            DropShadow="true" BehaviorID="mpeCustomePopup">
        </ajx:ModalPopupExtender>
        <asp:Panel ID="pnlCustomeMessage" runat="server" Width="350px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <div style="display: inline;">
                        <span>
                            <asp:Literal ID="litHeaderCustomePopupMessage" runat="server" Text="Message"></asp:Literal></span></div>
                    <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                        <asp:ImageButton ID="ibtnCancelCustomMsgPopup" runat="server" ImageUrl="~/images/closepopup.png"
                            Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;" />
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td align="center" style="padding-bottom: 15px; color: Red;">
                                <asp:Label ID="lblCustomePopupMsg" runat="server" Text=""></asp:Label>
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
<asp:UpdateProgress AssociatedUpdatePanelID="updChangeRoom" ID="UpdateProgressMoveRoom"
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
