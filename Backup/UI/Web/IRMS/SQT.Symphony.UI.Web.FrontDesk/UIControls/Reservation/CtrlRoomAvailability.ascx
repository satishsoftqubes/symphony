<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlRoomAvailability.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation.CtrlRoomAvailability" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script src="../../Scripts/jquery-1.4.3.min.js" type="text/javascript"></script>
<style type="text/css">
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
</style>
<style>
    fieldset, img
    {
        border: 0 none;
        vertical-align: middle;
    }
    .img
    {
        vertical-align: middle;
    }
</style>
<script src="../../Scripts/jquery-1.8.2.js"></script>
<script src="../../Scripts/jquery-ui.js"></script>
<script src="../../Scripts/Common.js" type="text/javascript"></script>
<script>
    function pageLoad(sender, args) {

        $(function () {
            var dateToday = new Date();

            $("#<%= txtSearchFromDate.ClientID %>").datepicker({
                changeMonth: true,
                numberOfMonths: 1,
                minDate: dateToday,
                showOn: "button",
                dateFormat: "dd-mm-yy",
                buttonImage: "../../images/CalanderIcon.png",
                buttonImageOnly: true,
                onSelect: function (selectedDate) {
                    $("#<%= txtSearchToDate.ClientID %>").datepicker("option", "minDate", selectedDate);
                }
            });
            $("#<%= txtSearchToDate.ClientID %>").datepicker({
                changeMonth: true,
                numberOfMonths: 1,
                minDate: dateToday,
                dateFormat: "dd-mm-yy",
                showOn: "button",
                buttonImage: "../../images/CalanderIcon.png",
                buttonImageOnly: true,
                onSelect: function (selectedDate) {
                    $("#<%= txtSearchFromDate.ClientID %>").datepicker("option", "maxDate", selectedDate);
                }
            });
        });
    }
</script>
<script>
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }

    function fnCheckDate() {
        if (Page_ClientValidate("IsRequireSearch")) {

            document.getElementById('errormessage').style.display = "block";
            var varDateFrom = document.getElementById('<%= txtSearchFromDate.ClientID %>').value;
            var varDateTo = document.getElementById('<%= txtSearchToDate.ClientID %>').value;

            if (varDateFrom != '' && varDateTo != '') {
                var dateFormat = document.getElementById('<%= hfDateFormat.ClientID %>').value;

                var dateFrom = fnGetValidDateFormat(varDateFrom, dateFormat);
                var dateTo = fnGetValidDateFormat(varDateTo, dateFormat);

                dateFrom = Date.parse(dateFrom, 'MM/dd/yyyy');
                dateTo = Date.parse(dateTo, 'MM/dd/yyyy');


                if (dateFrom > dateTo) {
                    $find('mpeDateMessage').show();
                    return false;
                }
                else {
                    return true;
                }
            }
            else {
                return true;
            }
        }
        else {
            return false;
        }
    }

    function ReservationProceedValidate() {
        if (Page_ClientValidate("IsRequire")) {
            document.getElementById('errormessage').style.display = "block";
            var varDateFrom = document.getElementById('<%= txtReservationProceedFromDate.ClientID %>').value;
            var varDateTo = document.getElementById('<%= txtReservationProceedToDate.ClientID %>').value;
            if (varDateFrom != '' && varDateTo != '') {

                var dateFormat = document.getElementById('<%= hfDateFormat.ClientID %>').value;
                var dateFrom = fnGetValidDateFormat(varDateFrom, dateFormat);
                var dateTo = fnGetValidDateFormat(varDateTo, dateFormat);

                dateFrom = Date.parse(dateFrom, 'MM/dd/yyyy');
                dateTo = Date.parse(dateTo, 'MM/dd/yyyy');

                if (varDateFrom > varDateTo) {
                    $find('mpeDateMessage').show();
                    return false;
                }
                else {
                    return true;
                }
            }
            else {
                return true;
            }
        }
    }

    function fnClick(para1, para2) {
        document.getElementById('<%=hdnRoomID.ClientID %>').value = para1;
        document.getElementById('<%=txtReservationProceedFromDate.ClientID %>').value = document.getElementById('<%=txtSearchFromDate.ClientID %>').value;
        document.getElementById('<%=txtReservationProceedToDate.ClientID %>').value = document.getElementById('<%=txtSearchToDate.ClientID %>').value;

        var e = document.getElementById('<%=ddlSearchRoomType.ClientID %>');
        var strRoomType = e.options[e.selectedIndex].text;

        document.getElementById('<%=lblReservationProceedRoomType.ClientID %>').innerHTML = strRoomType;

        var roomno = para2.split("|");

        if (roomno.length > 0) {
            document.getElementById('<%=lblReservationProceedRoomNo.ClientID %>').innerHTML = roomno[0] + "(" + roomno[1] + ")";
        }

        $find('mpeReservationProceed').show();
    }

</script>
<style type="text/css">
    #div1
    {
        width: 100%;
        display: none;
        border: 2px solid #EFEFEF;
        background-color: #FEFEFE;
    }
</style>
<asp:UpdatePanel ID="updRoomAvailabilityChart" runat="server">
    <ContentTemplate>
        <asp:HiddenField ID="hfDateFormat" runat="server" />
        <asp:HiddenField ID="hdnRoomID" runat="server" />
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="content">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                <asp:Literal ID="Literal1" runat="server" Text="Room Availability"></asp:Literal>
                            </td>
                            <td class="boxtopright">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="boxleft">
                                &nbsp;
                            </td>
                            <td align="left">
                                <div class="box_form">
                                    <table cellpadding="2" cellspacing="2" width="100%" border="0">
                                        <tr>
                                            <td width="225px">
                                                From&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtSearchFromDate" runat="server"
                                                    Style="width: 100px !important;" SkinID="searchtextbox" onkeydown="return stopKey(event);"></asp:TextBox>
                                                <%--<asp:Image ID="imgSearchFromDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                    Height="20px" Width="20px" />
                                                <ajx:CalendarExtender ID="calSearchFromDate" PopupButtonID="imgSearchFromDate" TargetControlID="txtSearchFromDate"
                                                    runat="server" Format="dd-MM-yyyy">
                                                </ajx:CalendarExtender>
                                                <img src="../../images/clear.png" id="imgclearDateFrom" style="vertical-align: middle;"
                                                    title="Clear Date" onclick="fnClearDate('<%= txtSearchFromDate.ClientID %>');" />--%>
                                                <asp:RequiredFieldValidator ID="rvfFromDate" runat="server" ControlToValidate="txtSearchFromDate"
                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequireSearch"></asp:RequiredFieldValidator>
                                            </td>
                                            <td width="210px">
                                                To&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtSearchToDate" runat="server"
                                                    Style="width: 100px !important;" SkinID="searchtextbox" onkeydown="return stopKey(event);"></asp:TextBox>
                                                <%--<asp:Image ID="imgSearchToDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                    Height="20px" Width="20px" />
                                                <ajx:CalendarExtender ID="calSearchToDate" PopupButtonID="imgSearchToDate" TargetControlID="txtSearchToDate"
                                                    runat="server" Format="dd-MM-yyyy">
                                                </ajx:CalendarExtender>
                                                <img src="../../images/clear.png" id="imgclearDateTo" style="vertical-align: middle;"
                                                    title="Clear Date" onclick="fnClearDate('<%= txtSearchToDate.ClientID %>');" />--%>
                                                <asp:RequiredFieldValidator ID="rvfToDate" runat="server" ControlToValidate="txtSearchToDate"
                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequireSearch"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                Room Type&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddlSearchRoomType" runat="server"
                                                    SkinID="nowidth" Width="180px">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rvfSearchRoomType" InitialValue="00000000-0000-0000-0000-000000000000"
                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                    ValidationGroup="IsRequireSearch" ControlToValidate="ddlSearchRoomType" Display="Dynamic">
                                                </asp:RequiredFieldValidator>
                                                <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                    ToolTip="Search" Style="border: 0px; margin: -1px 0 0 10px; vertical-align: middle;"
                                                    OnClick="btnSearch_Click" ValidationGroup="IsRequireSearch" OnClientClick="return fnCheckDate();" />
                                            </td>
                                            <td align="left">
                                                <asp:LinkButton ID="lnkViewRateCardDetail" runat="server" Text="View Rate Cards"
                                                    OnClick="lnkViewRateCardDetail_OnClick"></asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <hr />
                                                <table cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td width="135px">
                                                            &nbsp;&nbsp;&nbsp;&nbsp;Block
                                                        </td>
                                                        <td width="135px">
                                                            &nbsp;&nbsp;&nbsp;&nbsp;Floor
                                                        </td>
                                                        <td width="135px">
                                                            &nbsp;&nbsp;&nbsp;&nbsp;Work Timing
                                                        </td>
                                                        <td width="135px">
                                                            &nbsp;&nbsp;&nbsp;&nbsp;Smoking
                                                        </td>
                                                        <td width="210px">
                                                            &nbsp;&nbsp;&nbsp;&nbsp;Company
                                                        </td>
                                                        <td width="110px">
                                                            &nbsp;&nbsp;&nbsp;&nbsp;Occupancy
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="DropDownList2" runat="server" SkinID="nowidth" Width="100px">
                                                                <asp:ListItem Text="-SELECT-" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="Block A" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="Block B" Value="2"></asp:ListItem>
                                                                <asp:ListItem Text="Block C" Value="3"></asp:ListItem>
                                                                <asp:ListItem Text="Block D" Value="4"></asp:ListItem>
                                                                <asp:ListItem Text="Block E" Value="4"></asp:ListItem>
                                                                <asp:ListItem Text="Block F" Value="4"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="DropDownList3" runat="server" SkinID="nowidth" Width="100px">
                                                                <asp:ListItem Text="-SELECT-" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="Ground Floor" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="1st" Value="2"></asp:ListItem>
                                                                <asp:ListItem Text="2nd" Value="3"></asp:ListItem>
                                                                <asp:ListItem Text="3rd" Value="4"></asp:ListItem>
                                                                <asp:ListItem Text="4th" Value="4"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="DropDownList4" runat="server" SkinID="nowidth" Width="100px">
                                                                <asp:ListItem Text="-SELECT-" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="Day Shift" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="Night Shift" Value="2"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="DropDownList6" runat="server" SkinID="nowidth" Width="100px">
                                                                <asp:ListItem Text="-SELECT-" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="DropDownList5" runat="server" SkinID="nowidth" Width="180px">
                                                                <asp:ListItem Text="-SELECT-" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="Infosys" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="Wipro" Value="2"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="DropDownList7" runat="server" SkinID="nowidth" Width="100px">
                                                                <asp:ListItem Text="-SELECT-" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="Single" Value="1"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="Button1" runat="server" Text="Advanced Search" Style="display: inline;" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <div>
                                        <hr />
                                    </div>
                                    <div>
                                        <div style="padding-bottom: 10px;">
                                            Room Type: <b>
                                                <asp:Literal ID="litDisplayRoomType" runat="server" Text="-"></asp:Literal></b><br />
                                            <div style="height: 5px;">
                                            </div>
                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td>
                                                        <div style="float: right;">
                                                            <table width="380px">
                                                                <tr style="height: 25px;">
                                                                    <td align="center" style="font-weight: bold; color: White; background-color: #2e8b57;">
                                                                        Available
                                                                    </td>
                                                                    <td align="center" style="font-weight: bold; color: White; background-color: #0101DF;">
                                                                        Occupied
                                                                    </td>
                                                                    <td align="center" style="font-weight: bold; color: White; background-color: #0080FF;">
                                                                        Booked
                                                                    </td>
                                                                    <td align="center" style="font-weight: bold; color: White; background-color: Maroon;">
                                                                        Out of Service
                                                                    </td>
                                                                    <td align="center" style="font-weight: bold; color: White; background-color: Gray;">
                                                                        Under Cleaning
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                    <div id="dvChart" visible="false" runat="server" style="height: 500px; width: 1000px;
                                        overflow: auto;">
                                    </div>
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
                </td>
            </tr>
        </table>
        <div style="float: right; padding-right: 10px;">
            <asp:Button ID="btnBackToDashboard" runat="server" Text="Back" Style="display: inline;"
                OnClick="btnBackToDashboard_Click" />
        </div>
        <ajx:ModalPopupExtender ID="mpeReservationProceed" runat="server" TargetControlID="hdnReservationProceed"
            PopupControlID="pnlReservationProceed" BackgroundCssClass="mod_background" CancelControlID="imgReservationclose"
            BehaviorID="mpeReservationProceed">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnReservationProceed" runat="server" />
        <asp:Panel ID="pnlReservationProceed" runat="server" Width="400px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <div style="display: inline;">
                        <span>
                            <asp:Literal ID="litHeaderReservationProceed" runat="server" Text="Reservation"></asp:Literal></span></div>
                    <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                        <asp:ImageButton ID="imgReservationclose" runat="server" ImageUrl="~/images/closepopup.png"
                            Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;" />
                    </div>
                </div>
                <%-- <div class="box_head">
                    <span>
                        <asp:Literal ID="litHeaderReservationProceed" runat="server" Text="Reservation"></asp:Literal></span></div>--%>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td width="80px">
                                Room Type
                            </td>
                            <td>
                                <asp:Label ID="lblReservationProceedRoomType" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Room No.
                            </td>
                            <td>
                                <asp:Label ID="lblReservationProceedRoomNo" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>From</b>
                            </td>
                            <td>
                                <asp:TextBox ID="txtReservationProceedFromDate" runat="server" Style="width: 120px !important;"
                                    Text="03-09-2012" SkinID="searchtextbox" onkeypress="return false;"></asp:TextBox>
                                <asp:Image ID="imgReservationProceedFromDate" CssClass="small_img" runat="server"
                                    ImageUrl="~/images/CalanderIcon.png" Height="20px" Width="20px" />
                                <ajx:CalendarExtender ID="calReservationProceedFromDate" PopupButtonID="imgReservationProceedFromDate"
                                    TargetControlID="txtReservationProceedFromDate" runat="server">
                                </ajx:CalendarExtender>
                                <img src="../../images/clear.png" id="img1" style="vertical-align: middle;" title="Clear Date"
                                    onclick="fnClearDate('<%= txtReservationProceedFromDate.ClientID %>');" />
                                <span>
                                    <asp:RequiredFieldValidator ID="rfvReservationProceedFromDate" runat="server" ControlToValidate="txtReservationProceedFromDate"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire">
                                    </asp:RequiredFieldValidator>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>To</b>
                            </td>
                            <td>
                                <asp:TextBox ID="txtReservationProceedToDate" runat="server" Style="width: 120px !important;"
                                    SkinID="searchtextbox" onkeypress="return false;"></asp:TextBox>
                                <asp:Image ID="imgReservationProceedToDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                    Height="20px" Width="20px" />
                                <ajx:CalendarExtender ID="calReservationProceedToDate" PopupButtonID="imgReservationProceedToDate"
                                    TargetControlID="txtReservationProceedToDate" runat="server" Format="dd-MM-yyyy">
                                </ajx:CalendarExtender>
                                <img src="../../images/clear.png" id="img2" style="vertical-align: middle;" title="Clear Date"
                                    onclick="fnClearDate('<%= txtReservationProceedToDate.ClientID %>');" />
                                <span>
                                    <asp:RequiredFieldValidator ID="rfvReservationProceedToDate" runat="server" ControlToValidate="txtReservationProceedToDate"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire">
                                    </asp:RequiredFieldValidator>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-top: 10px; padding-bottom: 10px;" colspan="2" align="center">
                                <asp:Button ID="btnProceed" runat="server" Style="display: inline; padding-right: 10px;"
                                    Text="Proceed" OnClick="btnProceed_OnClick" ValidationGroup="IsRequire" OnClientClick="return ReservationProceedValidate();" />
                                <%--<asp:Button ID="btnCancelReservationProceed" Text="Cancel" runat="server" Style="display: inline;" />--%>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpeDateMessage" runat="server" TargetControlID="hfDateMessage"
            PopupControlID="pnlDateMessage" BackgroundCssClass="mod_background" CancelControlID="imgDateMessageOK"
            BehaviorID="mpeDateMessage">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hfDateMessage" runat="server" />
        <asp:Panel ID="pnlDateMessage" runat="server" Width="350px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <div style="display: inline;">
                        <span>
                            <asp:Literal ID="ltrHeaderDateValidate" runat="server" Text="Message"></asp:Literal></span></div>
                    <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                        <asp:ImageButton ID="imgDateMessageOK" runat="server" ImageUrl="~/images/closepopup.png"
                            Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;" />
                    </div>
                </div>
                <%--<div class="box_head">
                    <span>
                        <asp:Literal ID="ltrHeaderDateValidate" runat="server" Text="Message"></asp:Literal></span></div>--%>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td align="center" style="padding-bottom: 15px;">
                                <asp:Literal ID="ltrMsgDateValidate" runat="server" Text="From Date is greater than or equal to To Date."></asp:Literal>
                            </td>
                        </tr>
                        <%--<tr>
                            <td align="center">
                                <asp:Button ID="btnDateMessageOK" Text="OK" runat="server" Style="display: inline;
                                    padding-right: 10px;" />
                            </td>
                        </tr>--%>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpeRateCardDetail" runat="server" TargetControlID="hdnRateCardDetail"
            PopupControlID="pnlRateCardDetail" CancelControlID="imbCloseRateCardDetailPopup"
            OkControlID="btnCancelRateCardDetail" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnRateCardDetail" runat="server" />
        <asp:Panel ID="pnlRateCardDetail" runat="server" Width="600px">
            <div class="box_col1">
                <div class="box_head">
                    <div style="display: inline;">
                        <span>
                            <asp:Literal ID="Literal14" runat="server" Text="Rate Cards"></asp:Literal></span></div>
                    <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                        <asp:ImageButton ID="imbCloseRateCardDetailPopup" runat="server" ImageUrl="~/images/closepopup.png"
                            Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;" />
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table border="0" cellpadding="2" cellspacing="2" width="100%">
                        <tr style="height: 2px;">
                            <td align="right">
                                <asp:CheckBox ID="chkIsFullRoomForRoomAvail" runat="server" OnCheckedChanged="chkIsFullRoomForRoomAvail_CheckChanged"
                                    Text="Is Per Room" AutoPostBack="true" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButtonList ID="rblRatecardTyep" runat="server" RepeatColumns="7" Width="100%"
                                    OnSelectedIndexChanged="rblRatecardTyep_SelectedIndexChanged" AutoPostBack="true">
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="clear">
                                </div>
                                <div class="box_content">
                                    <div style="height: 160px !important; overflow: auto;">
                                        <asp:GridView ID="gvRoomTypeList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                            Width="100%" OnRowDataBound="gvRoomTypeList_RowDataBound" DataKeyNames="DepositAmount,TotalRackRate,RackRate"
                                            SkinID="gvNoPaging">
                                            <Columns>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrRoomType" runat="server" Text="Room Type"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#DataBinder.Eval(Container.DataItem, "RoomTypeName")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrRoomTypeDeposit" runat="server" Text="Deposit"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGvDepositAmount" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrRoomTypeRackRate" runat="server" Text="Rack Rate"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGvTotalRackRate" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrRoomTypeTax" runat="server" Text="Taxes"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGvTax" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrRoomTypeTotal" runat="server" Text="Total"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGvTotal" runat="server"></asp:Label>
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
                        <tr>
                            <td align="center" style="padding-top: 10px;">
                                <asp:Button ID="btnCancelRateCardDetail" runat="server" Text="OK" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updRoomAvailabilityChart" ID="uprgRoomAvailabilityChart"
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
