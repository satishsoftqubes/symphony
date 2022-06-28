<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCheckIn.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation.CtrlCheckIn" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<%@ Register Src="~/UIControls/Reservation/PaymentReceipt.ascx" TagName="PaymentReceipt"
    TagPrefix="ucCtrlPaymentReceipt" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonCounterLogin.ascx" TagName="CommonCounterLogin"
    TagPrefix="ucCtrlCommonCounterLogin" %>
<%@ Register Src="~/UIControls/Reservation/CtrlCommonBillToCompany.ascx" TagName="CommonBillToCompany"
    TagPrefix="ucCtrlCommonBillToCompany" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonVoidTransaction.ascx" TagName="VoidTransaction"
    TagPrefix="ucCtrlVoidTransaction" %>
<link type="text/css" href="../../Styles/jquery-ui-1.8.5.custom.css" rel="stylesheet" />
<script type="text/javascript" src="../../Scripts/jquery-1.4.2.min.js"></script>
<script type="text/javascript" src="../../Scripts/jquery-ui-1.8.5.custom.min.js"></script>
<link rel="stylesheet" href="../../Styles/jquery.ui.timepicker.css" type="text/css" />
<script type="text/javascript" src="../../Scripts/jquery-ui-timepicker-addon.js"></script>
<script type="text/javascript">
    function pageLoad(sender, args) {
        var v1 = '<%=ConfigurationManager.AppSettings["IsUpperCase"].ToString() %>'
        if (v1 == "1") {
            $('input[type="text"],textarea').each(function () { $(this).css("text-transform", "uppercase") });
        }
        $("#tabs").tabs();

        $('#tabs').tabs({
            select: function (event, ui) {
                window.location.hash = ui.tab.hash;
            }
        });
    }

    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }

    function fnGetTabIndex(operation) {
        var current_tab = $('#tabs').tabs('option', 'selected');
        current_tab++;
        if (operation == 'NEXT') {
            if (current_tab != '4') {
                var selected_tab = current_tab + 1;
                window.location.hash = 'tabs-' + selected_tab;
            }
            else {
                window.location.hash = 'tabs-1';
            }
        }
        else {
            if (current_tab != '1') {
                var selected_tab = current_tab - 1;
                window.location.hash = 'tabs-' + selected_tab;
            }
            else {
                window.location.hash = 'tabs-4';
            }
        }
    }

    function SelectTab(tabno) {
        if (tabno == '1') {
            window.location.hash = 'tabs-1';
        }
        else if (tabno == '2') {
            window.location.hash = 'tabs-2';
        }
        else if (tabno == '3') {
            window.location.hash = 'tabs-3';
        }
        else if (tabno == '4') {
            window.location.hash = 'tabs-4';
        }
    }

    function fnClick(para1, para2) {

        document.getElementById('<%=hdnRoomID.ClientID %>').value = para1;
        document.getElementById('<%=txtReservationProceedFromDate.ClientID %>').value = document.getElementById('<%=txtSearchFromDate.ClientID %>').value;
        document.getElementById('<%=txtReservationProceedToDate.ClientID %>').value = document.getElementById('<%=txtSearchToDate.ClientID %>').value;
        document.getElementById('<%=hdnRoomNo.ClientID %>').value = para2

        var e = document.getElementById('<%=ddlSearchRoomType.ClientID %>');
        var strRoomType = e.options[e.selectedIndex].text;

        document.getElementById('<%=lblReservationProceedRoomType.ClientID %>').innerHTML = strRoomType;

        var roomno = para2.split("|");

        if (roomno.length > 0) {
            document.getElementById('<%=lblReservationProceedRoomNo.ClientID %>').innerHTML = roomno[0] + "(" + roomno[1] + ")";
        }

        $find('mpeReservationProceed').show();
    }

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function hidebutton() {
        document.getElementById('<%= btnSavePayment.ClientID %>').style.display = "none";
    }

    function fnOpneWindow() {
        var hdnReservationID = document.getElementById('<%= hdnResID.ClientID %>').value;
        window.open("CheckInPaymentRecipt.aspx?IdofRes=" + hdnReservationID, "CheckInVouche", "height=600,width=600,status=1,toolbar=no,menubar=no,scrollbars=1,location=0");
    }

    function fnopenPrintWindow() {
        $find('mpePrintReceipt').hide();
        var hdnReservationID = document.getElementById('<%= hdnResID.ClientID %>').value;
        var hdnBookingID = document.getElementById('<%= hdnBookingID.ClientID %>').value;
        window.open("CheckInPaymentRecipt.aspx?IdofRes=" + hdnReservationID + "&IdofBook=" + hdnBookingID, "CheckInVouche", "height=600,width=600,status=1,toolbar=no,menubar=no,scrollbars=1,location=0");
        return false;
    }

    function fnOpenCheckInVoucherPrintWindow() {
        var hdnReservationID = document.getElementById('<%= hdnResID.ClientID %>').value;
        window.open("CheckInVoucher.aspx?ReservationID=" + hdnReservationID, "CheckInVouche", "height=600,width=800,status=1,toolbar=no,menubar=no,scrollbars=1,location=0");
        return false;
    }
     
</script>
<script type="text/javascript">
    var updateProgress = null;

    function postbackButtonClick() {
        if (Page_ClientValidate("IsRequire")) {
            document.getElementById('errormessage').style.display = "block";
            updateProgress = $find("<%= UpdateProgressCheckInList.ClientID %>");
            window.setTimeout("updateProgress.set_visible(true)", updateProgress.get_displayAfter());
            return true;
        }
    }

    function postbackButtonClickOnComparision() {
        if (Page_ClientValidate("IsRequireVoucher")) {
            document.getElementById('errormessage').style.display = "block";
            updateProgress = $find("<%= UpdateProgressCheckInList.ClientID %>");
            window.setTimeout("updateProgress.set_visible(true)", updateProgress.get_displayAfter());
            return true;
        }
    }

    function postbackButtonClickPopup() {
        document.getElementById('errormessage').style.display = "block";
        updateProgress = $find("<%= UpdateProgressCheckInList.ClientID %>");
        window.setTimeout("updateProgress.set_visible(true)", updateProgress.get_displayAfter());
        return true;

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
<asp:UpdatePanel ID="updCheckInList" runat="server">
    <ContentTemplate>
        <%--<asp:HiddenField ID="hdnReservationID" runat="server" />--%>
        <%--<asp:HiddenField ID="hfDateFormat" runat="server" />--%>
        <asp:HiddenField ID="hdnRoomID" runat="server" />
        <asp:HiddenField ID="hdnRoomNo" runat="server" />
        <asp:HiddenField ID="hdnResID" runat="server" />
        <asp:HiddenField ID="hdnBookingID" runat="server" />
        <asp:HiddenField ID="hdnAmtPayByCmp" runat="server" Value="0.000000" />
        <asp:MultiView ID="mvCheckInForm" runat="server">
            <asp:View ID="vCheckIn" runat="server">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="content">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="boxtopleft">
                                        &nbsp;
                                    </td>
                                    <td class="boxtopcenter">
                                        <asp:Literal ID="litCheckinReservation" runat="server" Text="Check In"></asp:Literal>
                                        <div style="float: right; display: inline; font-size: smaller; color: Black;">
                                            Start Time:
                                            <asp:Label ID="lblCheckinStartTime" runat="server"></asp:Label>
                                            &nbsp;&nbsp;&nbsp;End Time:
                                            <asp:Label ID="lblCheckinEndTime" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;
                                        </div>
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
                                            <%if (IsMessage)
                                              { %>
                                            <div class="ResetSuccessfully">
                                                <div style="float: left; padding-top: 7px; width: 25px; height: 24px; margin-right: 10px;">
                                                    <img src="../../images/success.png" />
                                                </div>
                                                <div>
                                                    <asp:Label ID="lblFeedbackMsg" runat="server"></asp:Label></div>
                                                <div style="height: 10px;">
                                                </div>
                                            </div>
                                            <% }%>
                                            <div class="demo">
                                                <div id="tabs">
                                                    <ul>
                                                        <li><a href="#tabs-1" onclick="fnChangeValue('1015.00');">
                                                            <asp:Literal ID="littabAllCharges" runat="server" Text="Reservation"></asp:Literal></a></li>
                                                        <li><a href="#tabs-2" onclick="fnChangeValue('200.00');">
                                                            <asp:Literal ID="littabPaidAmount" runat="server" Text="Guest History"></asp:Literal></a></li>
                                                        <li><a href="#tabs-3" onclick="fnChangeValue('1000.00');">
                                                            <asp:Literal ID="littabRentCharge" runat="server" Text="Registration"></asp:Literal></a></li>
                                                        <li><a href="#tabs-4" onclick="fnChangeValue('1015.00');">
                                                            <asp:Literal ID="littabPayment" runat="server" Text="Payment"></asp:Literal></a></li>
                                                    </ul>
                                                    <div id="tabs-1">
                                                        <table width="100%">
                                                            <tr>
                                                                <td width="45%" style="vertical-align: top;">
                                                                    <table cellpadding="2" cellspacing="2" width="100%" border="0">
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                <b>Booking Detail</b>
                                                                                <hr />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="65px">
                                                                                Booking #
                                                                            </td>
                                                                            <td width="260px">
                                                                                <b>
                                                                                    <asp:Literal ID="litDisplayReservationNo" runat="server"></asp:Literal></b>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Booking Date
                                                                            </td>
                                                                            <td>
                                                                                <asp:Literal ID="litDisplayBookingDate" runat="server"></asp:Literal>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Booked By
                                                                            </td>
                                                                            <td>
                                                                                <asp:Literal ID="litDisplayBookedBy" runat="server"></asp:Literal>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Check In
                                                                            </td>
                                                                            <td>
                                                                                <asp:Literal ID="litDisplayCheckInDate" runat="server"></asp:Literal>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Check Out
                                                                            </td>
                                                                            <td>
                                                                                <asp:Literal ID="litDisplayCheckOutDate" runat="server"></asp:Literal>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Adult
                                                                            </td>
                                                                            <td>
                                                                                <asp:Literal ID="litDisplayAdult" runat="server"></asp:Literal>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Child
                                                                            </td>
                                                                            <td>
                                                                                <asp:Literal ID="litDisplayChild" runat="server"></asp:Literal>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Infant
                                                                            </td>
                                                                            <td>
                                                                                <asp:Literal ID="litDisplayInf" runat="server"></asp:Literal>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Rate card
                                                                            </td>
                                                                            <td>
                                                                                <asp:Literal ID="litDisplayRateCard" runat="server"></asp:Literal>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Room Type
                                                                            </td>
                                                                            <td>
                                                                                <asp:Literal ID="litDisplayRoomType" runat="server"></asp:Literal>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Smoking
                                                                            </td>
                                                                            <td>
                                                                                <asp:Literal ID="litDisplaySmoking" runat="server"></asp:Literal>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Room No.
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblDisplayRoomNo" runat="server"></asp:Label>
                                                                                &nbsp;&nbsp;&nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="padding: 0px;" colspan="2">
                                                                                <hr />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <b>
                                                                                    <asp:Literal ID="Literal2" runat="server" Text="Date of Birth"></asp:Literal></b>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlDOBDate" runat="server" Style="width: 80px; height: 25px;">
                                                                                </asp:DropDownList>
                                                                                <asp:RequiredFieldValidator ID="rfvDOBDate" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                                    ValidationGroup="IsRequire" ControlToValidate="ddlDOBDate" Display="Dynamic">
                                                                                </asp:RequiredFieldValidator>
                                                                                <asp:DropDownList ID="ddlDOBMonth" runat="server" Style="width: 80px; height: 25px;">
                                                                                    <asp:ListItem Text="-MONTH-" Value="00000000-0000-0000-0000-000000000000" Selected="True"></asp:ListItem>
                                                                                    <asp:ListItem Text="Jan" Value="1"></asp:ListItem>
                                                                                    <asp:ListItem Text="Feb" Value="2"></asp:ListItem>
                                                                                    <asp:ListItem Text="Mar" Value="3"></asp:ListItem>
                                                                                    <asp:ListItem Text="Apr" Value="4"></asp:ListItem>
                                                                                    <asp:ListItem Text="May" Value="5"></asp:ListItem>
                                                                                    <asp:ListItem Text="Jun" Value="6"></asp:ListItem>
                                                                                    <asp:ListItem Text="Jul" Value="7"></asp:ListItem>
                                                                                    <asp:ListItem Text="Aug" Value="8"></asp:ListItem>
                                                                                    <asp:ListItem Text="Sep" Value="9"></asp:ListItem>
                                                                                    <asp:ListItem Text="Oct" Value="10"></asp:ListItem>
                                                                                    <asp:ListItem Text="Nov" Value="11"></asp:ListItem>
                                                                                    <asp:ListItem Text="Dec" Value="12"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                <asp:RequiredFieldValidator ID="rfvDOBMonth" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                                    ValidationGroup="IsRequire" ControlToValidate="ddlDOBMonth" Display="Dynamic">
                                                                                </asp:RequiredFieldValidator>
                                                                                <asp:DropDownList ID="ddlDOBYear" runat="server" Style="width: 80px; height: 25px;">
                                                                                </asp:DropDownList>
                                                                                <asp:RequiredFieldValidator ID="rfvDOBYear" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                                    ValidationGroup="IsRequire" ControlToValidate="ddlDOBYear" Display="Dynamic">
                                                                                </asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Company
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtCompanyName" runat="server" SkinID="nowidth" Width="120px"></asp:TextBox>
                                                                                &nbsp;&nbsp;&nbsp;&nbsp;Dept. &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtCompanyDepartment"
                                                                                    runat="server" SkinID="nowidth" Width="125px"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Job Title
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtJobTitle" runat="server" SkinID="nowidth" Width="120px"></asp:TextBox>
                                                                                &nbsp;&nbsp;&nbsp;&nbsp;Emp. ID
                                                                                <asp:TextBox ID="txtEmployeeID" runat="server" SkinID="nowidth" Width="125px"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <b>Sector</b>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlCompanySector" runat="server" Style="width: 224px; height: 25px;">
                                                                                </asp:DropDownList>
                                                                                <asp:RequiredFieldValidator ID="rfvCompanySector" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                                    ValidationGroup="IsRequire" ControlToValidate="ddlCompanySector" Display="Dynamic">
                                                                                </asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Location
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtWorkLocation" runat="server"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <b>Work Timing</b>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlWorkTiming" runat="server" Style="width: 224px; height: 25px;">
                                                                                </asp:DropDownList>
                                                                                <asp:RequiredFieldValidator ID="rfvWorkTiming" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                                    ValidationGroup="IsRequire" ControlToValidate="ddlWorkTiming" Display="Dynamic">
                                                                                </asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <b>Expected Stay</b>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlExpectedStay" runat="server" Style="width: 105px; height: 25px;
                                                                                    margin-right: 5px;" AutoPostBack="true" OnSelectedIndexChanged="ddlExpectedStay_SlectedIndexChanged"
                                                                                    CausesValidation="true">
                                                                                    <asp:ListItem Text="-SELECT-" Value="00000000-0000-0000-0000-000000000000" Selected="True"></asp:ListItem>
                                                                                    <asp:ListItem Text="1 Month" Value="1"></asp:ListItem>
                                                                                    <asp:ListItem Text="2 Month" Value="2"></asp:ListItem>
                                                                                    <asp:ListItem Text="3 Month" Value="3"></asp:ListItem>
                                                                                    <asp:ListItem Text="6 Month" Value="6"></asp:ListItem>
                                                                                    <asp:ListItem Text="9 Month" Value="9"></asp:ListItem>
                                                                                    <asp:ListItem Text="12 Month" Value="12"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                <span>
                                                                                    <asp:RequiredFieldValidator ID="rfvExpectedStay" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                                        SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                                        EnableClientScript="true" ValidationGroup="IsRequire" ControlToValidate="ddlExpectedStay"
                                                                                        Display="Dynamic">
                                                                                    </asp:RequiredFieldValidator></span>
                                                                                <asp:Label ID="lblExpectedCheckOutDate" runat="server" Visible="false" ForeColor="Green"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td style="border-left: 1px solid #CCCCCC;">
                                                                </td>
                                                                <td width="55%" valign="top">
                                                                    <table cellpadding="5" cellspacing="2" width="100%" border="0">
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                                                    <tr>
                                                                                        <td style="padding: 0px;" align="left">
                                                                                            <b>Guest Detail</b>
                                                                                        </td>
                                                                                        <td style="padding: 0px;" align="right">
                                                                                            <asp:LinkButton ID="LinkButton1" it="imgSearchGuestInfo" runat="server" ForeColor="#0067a4"
                                                                                                Text="Repeat Guest" OnClick="btnSearchGuestInfo_Click"></asp:LinkButton>
                                                                                            <%--<asp:ImageButton ID="imgSearchGuestInfo" runat="server" ImageUrl="~/images/001_38.gif"
                                                                                    OnClick="btnSearchGuestInfo_Click" Style="border: none;" />--%>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <hr />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="isrequire">
                                                                                <asp:Literal ID="litNationality" runat="server" Text="Nationality"></asp:Literal>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlNationality" AutoPostBack="true" OnSelectedIndexChanged="ddlNationality_selectedindexchanged"
                                                                                    runat="server" Style="width: 165px;">
                                                                                </asp:DropDownList>
                                                                                <span>
                                                                                    <asp:RequiredFieldValidator ID="rfvNationality" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                                        SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                                        ValidationGroup="IsRequire" ControlToValidate="ddlNationality" Display="Dynamic">
                                                                                    </asp:RequiredFieldValidator>
                                                                                </span>
                                                                                <asp:LinkButton ID="linkForeignNationalpopup" Visible="false" runat="server" ForeColor="#0067a4"
                                                                                    Text="Foreign National Info" OnClick="linkForeignNationalpopup_Click"></asp:LinkButton>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="isrequire" style="width: 80px !important;">
                                                                                <asp:Literal ID="litName" runat="server" Text="Name"></asp:Literal>
                                                                            </td>
                                                                            <td>
                                                                                <div style="float: left;">
                                                                                    <asp:DropDownList ID="ddlTitle" runat="server" Style="width: 60px; height: 25px;">
                                                                                    </asp:DropDownList>
                                                                                    <span>
                                                                                        <asp:RequiredFieldValidator ID="rvfTitle" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                                            SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                                            ValidationGroup="IsRequire" ControlToValidate="ddlTitle" Display="Dynamic">
                                                                                        </asp:RequiredFieldValidator>
                                                                                    </span>
                                                                                    <asp:TextBox ID="txtFirstName" runat="server" MaxLength="150" Style="width: 135px !important;"></asp:TextBox>
                                                                                    <ajx:TextBoxWatermarkExtender ID="txtwmeFirstName" runat="server" TargetControlID="txtFirstName"
                                                                                        WatermarkText="First Name">
                                                                                    </ajx:TextBoxWatermarkExtender>
                                                                                    <span>
                                                                                        <asp:RequiredFieldValidator ID="rvfFirstName" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                                            runat="server" ValidationGroup="IsRequire" ControlToValidate="txtFirstName" Display="Dynamic">
                                                                                        </asp:RequiredFieldValidator>
                                                                                    </span>
                                                                                    <asp:TextBox ID="txtLastName" runat="server" MaxLength="150" Style="width: 130px !important;"></asp:TextBox><ajx:TextBoxWatermarkExtender
                                                                                        ID="txtwmeLastName" runat="server" TargetControlID="txtLastName" WatermarkText="Last Name">
                                                                                    </ajx:TextBoxWatermarkExtender>
                                                                                    <span>
                                                                                        <asp:RequiredFieldValidator ID="rfvLastName" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                                            runat="server" ValidationGroup="IsRequire" ControlToValidate="txtLastName" Display="Dynamic">
                                                                                        </asp:RequiredFieldValidator>
                                                                                    </span>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <b>
                                                                                    <asp:Literal ID="litMobile" runat="server" Text="Mobile No."></asp:Literal></b>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtCountryMobileCode" Style="width: 30px !important;" Text="+91"
                                                                                    MaxLength="4" runat="server"></asp:TextBox>
                                                                                <ajx:FilteredTextBoxExtender ID="ftCountryMobileCode" runat="server" TargetControlID="txtCountryMobileCode"
                                                                                    ValidChars="+0123456789" FilterMode="ValidChars">
                                                                                </ajx:FilteredTextBoxExtender>
                                                                                <asp:TextBox ID="txtMobile" runat="server" SkinID="nowidth" Width="190px" MaxLength="10"></asp:TextBox>
                                                                                <ajx:FilteredTextBoxExtender ID="ftMobile" runat="server" TargetControlID="txtMobile"
                                                                                    ValidChars="0123456789" FilterMode="ValidChars">
                                                                                </ajx:FilteredTextBoxExtender>
                                                                                <span>
                                                                                    <asp:RequiredFieldValidator ID="rfvMobileNo" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                                        runat="server" ValidationGroup="IsRequire" ControlToValidate="txtMobile" Display="Dynamic">
                                                                                    </asp:RequiredFieldValidator>
                                                                                </span>
                                                                                <asp:RegularExpressionValidator ID="regMobileNo" runat="server" ControlToValidate="txtMobile"
                                                                                    ErrorMessage="Mobile No. must be 10 digits." ValidationGroup="IsRequire" ForeColor="Red"
                                                                                    ValidationExpression="^[0-9]{10}"></asp:RegularExpressionValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <b>
                                                                                    <asp:Literal ID="litGuestEmail" runat="server" Text="Email"></asp:Literal></b>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtGuestEmail" runat="server" MaxLength="150"></asp:TextBox>
                                                                                <span>
                                                                                    <asp:RequiredFieldValidator ID="rfvGuestEmail" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                                        runat="server" ValidationGroup="IsRequire" ControlToValidate="txtGuestEmail"
                                                                                        Display="Dynamic">
                                                                                    </asp:RequiredFieldValidator>
                                                                                </span><span>
                                                                                    <asp:RegularExpressionValidator ID="revGuestEmail" Display="Dynamic" ValidationGroup="IsRequire"
                                                                                        runat="server" ErrorMessage="Please Enter Valid Email" ForeColor="Red" ControlToValidate="txtGuestEmail"
                                                                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                                                </span>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="vertical-align: top;">
                                                                                <b>
                                                                                    <asp:Literal ID="litAddress" runat="server" Text="Address"></asp:Literal></b>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtAddressLine1" runat="server" MaxLength="300"></asp:TextBox>
                                                                                <span>
                                                                                    <asp:RequiredFieldValidator ID="rfvAddressLine1" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                                        runat="server" ValidationGroup="IsRequire" ControlToValidate="txtAddressLine1"
                                                                                        Display="Dynamic">
                                                                                    </asp:RequiredFieldValidator>
                                                                                </span>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="vertical-align: top;">
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtAddressLine2" runat="server" MaxLength="300"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <b>
                                                                                    <asp:Literal ID="litCityName" runat="server" Text="City"></asp:Literal></b>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtCityName" runat="server" MaxLength="150"></asp:TextBox>
                                                                                <span>
                                                                                    <asp:RequiredFieldValidator ID="rfvCity" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                                        runat="server" ValidationGroup="IsRequire" ControlToValidate="txtCityName" Display="Dynamic">
                                                                                    </asp:RequiredFieldValidator>
                                                                                </span>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Literal ID="litZipCode" runat="server" Text="Zip Code"></asp:Literal>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtZipCode" runat="server" MaxLength="15"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <b>
                                                                                    <asp:Literal ID="litStateName" runat="server" Text="State"></asp:Literal></b>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtStateName" runat="server" MaxLength="150"></asp:TextBox>
                                                                                <span>
                                                                                    <asp:RequiredFieldValidator ID="rfvStateName" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                                        runat="server" ValidationGroup="IsRequire" ControlToValidate="txtStateName" Display="Dynamic">
                                                                                    </asp:RequiredFieldValidator>
                                                                                </span>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <b>
                                                                                    <asp:Literal ID="litCountryName" runat="server" Text="Country"></asp:Literal></b>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtCountryName" runat="server" MaxLength="150"></asp:TextBox>
                                                                                <span>
                                                                                    <asp:RequiredFieldValidator ID="rfvCountryName" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                                        runat="server" ValidationGroup="IsRequire" ControlToValidate="txtCountryName"
                                                                                        Display="Dynamic">
                                                                                    </asp:RequiredFieldValidator>
                                                                                </span>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <b>
                                                                                    <asp:Literal ID="Literal15" runat="server" Text="Guest Type"></asp:Literal></b>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList runat="server" ID="ddlGuestType" AutoPostBack="true" OnSelectedIndexChanged="ddlGuestType_OnSelectedIndexChanged">
                                                                                </asp:DropDownList>
                                                                                <asp:RequiredFieldValidator ID="rfvGuestType" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                                    ValidationGroup="IsRequire" ControlToValidate="ddlGuestType" Display="Dynamic">
                                                                                </asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="vertical-align: top;">
                                                                                Standard Instruction
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtStandardInstruction" runat="server" Enabled="false" SkinID="nowidth"
                                                                                    Width="334px" Height="35px" TextMode="MultiLine"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Smoking
                                                                            </td>
                                                                            <td style="padding: 0px;">
                                                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                                                    <tr>
                                                                                        <td style="padding: 0px">
                                                                                            <asp:RadioButtonList ID="rdbLIsSmoking" runat="server" RepeatDirection="Horizontal"
                                                                                                RepeatColumns="2">
                                                                                                <asp:ListItem Text="Yes" Value="YES"></asp:ListItem>
                                                                                                <asp:ListItem Text="No" Value="NO" Selected="True"></asp:ListItem>
                                                                                            </asp:RadioButtonList>
                                                                                        </td>
                                                                                        <td width="60px">
                                                                                            Pickup
                                                                                        </td>
                                                                                        <td style="padding: 0px;">
                                                                                            <asp:RadioButtonList ID="rdbIsPicup" runat="server" RepeatDirection="Horizontal"
                                                                                                RepeatColumns="2">
                                                                                                <asp:ListItem Text="Yes" Value="YES"></asp:ListItem>
                                                                                                <asp:ListItem Text="No" Value="NO" Selected="True"></asp:ListItem>
                                                                                            </asp:RadioButtonList>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="vertical-align: top;">
                                                                                Specific Instruction
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtSpecificInstruction" runat="server" SkinID="nowidth" Width="334px"
                                                                                    Height="35px" TextMode="MultiLine"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div id="tabs-2">
                                                        <div class="box_head">
                                                            <span>
                                                                <asp:Literal ID="litStayHistoryList" runat="server" Text="Stay History"></asp:Literal>
                                                            </span>
                                                        </div>
                                                        <div class="clear">
                                                        </div>
                                                        <div class="box_content">
                                                            <asp:GridView ID="gvGuestHistory" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                Width="100%" OnRowDataBound="gvGuestHistory_RowDataBound">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-Width="30px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%# Container.DataItemIndex + 1 %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrBookingNo" runat="server" Text="Booking #"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "ReservationNo")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrRoomCnf" runat="server" Text="Check In"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvCheckInDate" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "CheckInDate")).ToString(clsSession.DateFormat)%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrCheckInDate" runat="server" Text="Check Out"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvCheckOutDate" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "CheckOutDate")).ToString(clsSession.DateFormat)%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrCheckOutDate" runat="server" Text="Nights"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvNights" runat="server" Text='<%# Reservation_GetTotalDays(Eval("CheckInDate"),Eval("CheckOutDate")) %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="120px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrNights" runat="server" Text="Rate Card"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "RateCardName")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrRateCard" runat="server" Text="Room Type"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "RoomTypeName")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrInvoiceAmt" runat="server" Text="Room No."></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvRoomNo" runat="server" Text='<%# GetFormatedRoomNumber(Eval("RoomNo")) %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrStatus" runat="server" Text="Invoice Amt."></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvInvoiceAmount" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrFolioBalance" runat="server" Text="Folio Balance"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            0.00
                                                                            <%-- <%#DataBinder.Eval(Container.DataItem, "Amt")%>--%>
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
                                                        <br />
                                                        <br />
                                                        <table width="100%" border="0">
                                                            <tr>
                                                                <td width="50%" style="vertical-align: top;">
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td style="padding: 0px;">
                                                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            <b>Guest Preferences</b>
                                                                                        </td>
                                                                                        <td align="right">
                                                                                            <asp:Button ID="btnAddPreferences" runat="server" Text="Add" Height="20px" OnClick="btnAddPreferences_Click" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <hr />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <div class="box_content">
                                                                                    <asp:GridView ID="gvGuestPreferences" runat="server" AutoGenerateColumns="false"
                                                                                        ShowHeader="true" Width="100%">
                                                                                        <Columns>
                                                                                            <asp:TemplateField ItemStyle-Width="30px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                <HeaderTemplate>
                                                                                                    <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                                                                                </HeaderTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <%# Container.DataItemIndex + 1 %>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                <HeaderTemplate>
                                                                                                    <asp:Label ID="lblGvHdrPreference" runat="server" Text="Preferences"></asp:Label>
                                                                                                </HeaderTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblGvPreference" runat="server" Text='<%#TruncateString(DataBinder.Eval(Container.DataItem, "Preference").ToString(), 35)%>'></asp:Label>
                                                                                                    <ajx:HoverMenuExtender ID="hmePreference" runat="server" TargetControlID="lblGvPreference"
                                                                                                        PopupControlID="pnlPreference" PopupPosition="Right">
                                                                                                    </ajx:HoverMenuExtender>
                                                                                                    <asp:Panel ID="pnlPreference" runat="server" Style="visibility: hidden; opacity: 100%"
                                                                                                        BorderColor="#000000" BorderStyle="Solid" BorderWidth="1px">
                                                                                                        <table border="0" cellpadding="0" cellspacing="0" class="tooltip_hover_lettmenu_table">
                                                                                                            <tr>
                                                                                                                <td style="background-color: #FFFFF0">
                                                                                                                    <%#DataBinder.Eval(Container.DataItem, "Preference")%>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </asp:Panel>
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
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td style="border-left: 1px solid #CCCCCC;">
                                                                </td>
                                                                <td width="50%" style="vertical-align: top;">
                                                                    <table width="100%" style="vertical-align: top;">
                                                                        <tr>
                                                                            <td style="padding: 0px;">
                                                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            <b>Management Note</b>
                                                                                        </td>
                                                                                        <td align="right">
                                                                                            <asp:Button ID="btnAddMgmtNote" runat="server" Text="Add" Height="20px" OnClick="btnAddMgmtNote_Click" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <hr />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <div class="box_content">
                                                                                    <asp:GridView ID="gvFrontDesksNote" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                                        Width="100%">
                                                                                        <Columns>
                                                                                            <asp:TemplateField ItemStyle-Width="30px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                <HeaderTemplate>
                                                                                                    <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                                                                                </HeaderTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <%# Container.DataItemIndex + 1 %>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                <HeaderTemplate>
                                                                                                    <asp:Label ID="lblGvHdrPreference" runat="server" Text="Notes"></asp:Label>
                                                                                                </HeaderTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblGvFrontDesksNote" runat="server" Text='<%#TruncateString(DataBinder.Eval(Container.DataItem, "Notes").ToString(), 25)%>'></asp:Label>
                                                                                                    <ajx:HoverMenuExtender ID="hmeFrontDesksNote" runat="server" TargetControlID="lblGvFrontDesksNote"
                                                                                                        PopupControlID="pnlFrontDesksNote" PopupPosition="Right">
                                                                                                    </ajx:HoverMenuExtender>
                                                                                                    <asp:Panel ID="pnlFrontDesksNote" runat="server" Style="visibility: hidden; opacity: 100%"
                                                                                                        BorderColor="#000000" BorderStyle="Solid" BorderWidth="1px">
                                                                                                        <table border="0" cellpadding="0" cellspacing="0" class="tooltip_hover_lettmenu_table">
                                                                                                            <tr>
                                                                                                                <td style="background-color: #FFFFF0">
                                                                                                                    <%#DataBinder.Eval(Container.DataItem, "Notes")%>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </asp:Panel>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                <HeaderTemplate>
                                                                                                    <asp:Label ID="lblGvHdrPreference" runat="server" Text="Note By"></asp:Label>
                                                                                                </HeaderTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <%#DataBinder.Eval(Container.DataItem, "UserDisplayName")%>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                <HeaderTemplate>
                                                                                                    <asp:Label ID="lblGvHdrDate" runat="server" Text="Date"></asp:Label>
                                                                                                </HeaderTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <%#DataBinder.Eval(Container.DataItem, "NoteOn", "{0:dd-MM-yyyy}")%>
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
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div id="tabs-3">
                                                        <table width="100%">
                                                            <tr>
                                                                <td width="50%" style="vertical-align: top;">
                                                                    <table width="100%" cellpadding="5" cellspacing="2" border="0">
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                <%if (IsGuestDocMessage)
                                                                                  { %>
                                                                                <div class="ResetSuccessfully">
                                                                                    <div style="float: left; padding-top: 7px; width: 25px; height: 24px; margin-right: 10px;">
                                                                                        <img src="../../images/success.png" />
                                                                                    </div>
                                                                                    <div>
                                                                                        <asp:Label ID="lblDocMessage" runat="server"></asp:Label></div>
                                                                                    <div style="height: 10px;">
                                                                                    </div>
                                                                                </div>
                                                                                <% }%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="80px">
                                                                                Name
                                                                            </td>
                                                                            <td width="250px">
                                                                                <b>
                                                                                    <asp:Label ID="lblGuestNameInRegistrationTab" runat="server"></asp:Label></b>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <%--<b>Photo</b>--%>
                                                                                Photo
                                                                            </td>
                                                                            <td>
                                                                                <div id='browse_file_grid'>
                                                                                    <asp:FileUpload ID="fuGuestPhoto" runat="server" />
                                                                                </div>
                                                                                <%--Not to delete this commented req. field--%>
                                                                                <%--<asp:RequiredFieldValidator ID="rfvGuestPhoto" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                                    runat="server" ValidationGroup="GuestDocument" ControlToValidate="fuGuestPhoto"
                                                                                    Display="Dynamic">
                                                                                </asp:RequiredFieldValidator>--%>
                                                                                <asp:RegularExpressionValidator ID="regGuestPhotoExtention" runat="server" ControlToValidate="fuGuestPhoto"
                                                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="GuestDocument"
                                                                                    Display="Dynamic" ValidationExpression="^.+(.jpg|.JPG|.jpeg|.JPEG|.png|.PNG|.gif|.GIF|.bmp|.BMP)$"></asp:RegularExpressionValidator>
                                                                                <a id="ancViewGuestPhoto" runat="server" target="_blank" visible="false">
                                                                                    <img src="../../images/View.png" width="17px" alt="view photo" height="17px" /></a>
                                                                                <asp:ImageButton ID="imgBtnDeleteGuestPhoto" runat="server" OnClick="imgBtnDeleteGuestPhoto_OnClick"
                                                                                    ImageUrl="~/images/Delete.png" Visible="false" Width="16px" Height="16px" BorderStyle="None" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="padding-top: 10px;">
                                                                                <b>ID Document-1</b>
                                                                            </td>
                                                                            <td style="padding-top: 10px;">
                                                                                <asp:DropDownList ID="ddlDocument1" runat="server">
                                                                                </asp:DropDownList>
                                                                                <asp:RequiredFieldValidator ID="rfvDocument1" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                                    runat="server" ValidationGroup="GuestDocument" ControlToValidate="ddlDocument1"
                                                                                    InitialValue="00000000-0000-0000-0000-000000000000" Display="Dynamic">
                                                                                </asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <b>Reference No.</b>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtDocRefNo1" runat="server" MaxLength="150"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="rfvDocRefNo1" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                                    runat="server" ValidationGroup="GuestDocument" ControlToValidate="txtDocRefNo1"
                                                                                    Display="Dynamic">
                                                                                </asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <b>Upload Document-1</b>
                                                                            </td>
                                                                            <td>
                                                                                <div class="browse_file_grid_test">
                                                                                    <asp:FileUpload ID="fuIDDocument1" runat="server" Height="28px" CssClass="browse_file_grid" />
                                                                                </div>
                                                                                <asp:RequiredFieldValidator ID="rfvIDDocument1" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                                    runat="server" ValidationGroup="GuestDocument" ControlToValidate="fuIDDocument1"
                                                                                    Display="Dynamic">
                                                                                </asp:RequiredFieldValidator>
                                                                                <asp:RegularExpressionValidator ID="regIDDocumentExtention" runat="server" ControlToValidate="fuIDDocument1"
                                                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="GuestDocument"
                                                                                    Display="Dynamic" ValidationExpression="^.+(.jpg|.JPG|.jpeg|.JPEG|.png|.PNG|.gif|.GIF|.bmp|.BMP)$"></asp:RegularExpressionValidator>
                                                                                <a id="ancViewIDDocument1" runat="server" target="_blank" visible="false">
                                                                                    <img src="../../images/View.png" width="17px" alt="view photo" height="17px" /></a>
                                                                                <asp:ImageButton ID="imgBtnDeleteIDDocument1" runat="server" OnClick="imgBtnDeleteIDDocument1_OnClick"
                                                                                    ImageUrl="~/images/Delete.png" Visible="false" Width="16px" Height="16px" BorderStyle="None" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="padding-top: 10px;">
                                                                                ID Document-2
                                                                            </td>
                                                                            <td style="padding-top: 10px;">
                                                                                <asp:DropDownList ID="ddlDocument2" runat="server">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Reference No.
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtDocRefNo2" runat="server" MaxLength="150"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Upload Document-2
                                                                            </td>
                                                                            <td>
                                                                                <div class="browse_file_grid_test">
                                                                                    <asp:FileUpload ID="fuIDDocument2" runat="server" />
                                                                                </div>
                                                                                <asp:RegularExpressionValidator ID="regIDDocument2" runat="server" ControlToValidate="fuIDDocument2"
                                                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="GuestDocument"
                                                                                    Display="Dynamic" ValidationExpression="^.+(.jpg|.JPG|.jpeg|.JPEG|.png|.PNG|.gif|.GIF|.bmp|.BMP)$"></asp:RegularExpressionValidator>
                                                                                <a id="ancViewIDDocument2" runat="server" target="_blank" visible="false">
                                                                                    <img src="../../images/View.png" width="17px" alt="view photo" height="17px" /></a>
                                                                                <asp:ImageButton ID="imgBtnDeleteIDDocument2" runat="server" OnClick="imgBtnDeleteIDDocument2_OnClick"
                                                                                    ImageUrl="~/images/Delete.png" Visible="false" Width="16px" Height="16px" BorderStyle="None" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" align="left" style="text-align: left; color: Blue;">
                                                                                ** jpg, jpeg, png, gif, bmp files allowed.
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" align="center" style="text-align: center;">
                                                                                <asp:Button ID="btnUploadDocument" runat="server" Text="Upload" Style="display: inline;"
                                                                                    OnClick="btnUploadDocument_OnClick" ValidationGroup="GuestDocument" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td style="border-left: 1px solid #CCCCCC;">
                                                                </td>
                                                                <td width="50%" style="vertical-align: top;">
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                <b>Other Information</b>
                                                                                <hr />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Literal ID="Literal4" runat="server" Text="Blood Group"></asp:Literal>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlBloodGroup" runat="server" Style="width: 80px; height: 25px;">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <b>
                                                                                    <asp:Literal ID="Literal3" runat="server" Text="Meal Preference"></asp:Literal></b>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlMealPreference" runat="server" Style="height: 25px;">
                                                                                </asp:DropDownList>
                                                                                <asp:RequiredFieldValidator ID="rfvMealPreference" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                                    ValidationGroup="IsRequire" ControlToValidate="ddlMealPreference" Display="Dynamic">
                                                                                </asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Parent Name
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtParentName" runat="server" MaxLength="250"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Parent Contact No.
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtParentCntcNumber" runat="server" MaxLength="15"></asp:TextBox>
                                                                                <ajx:FilteredTextBoxExtender ID="fteParentContactNo" runat="server" TargetControlID="txtParentCntcNumber"
                                                                                    ValidChars="0123456789+-" FilterMode="ValidChars">
                                                                                </ajx:FilteredTextBoxExtender>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Local Contact
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtLocalContactPerson" runat="server" MaxLength="150"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Local Contact No.
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtLocalContactNumber" runat="server" MaxLength="15"></asp:TextBox>
                                                                                <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtLocalContactNumber"
                                                                                    ValidChars="0123456789+-" FilterMode="ValidChars">
                                                                                </ajx:FilteredTextBoxExtender>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3" align="center" style="padding-top: 10px;">
                                                                    <asp:Button ID="btnAssignRoom" runat="server" Text="Assign Room" Style="display: inline;"
                                                                        OnClick="btnAssignRoom_OnClick" Visible="false" />
                                                                    <asp:Button ID="btnCheckinVoucher" runat="server" Text="Check In Voucher" OnClick="btnCheckinVoucher_OnClick"
                                                                        Visible="false" Style="display: inline;" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div id="tabs-4">
                                                        <table width="100%" border="0">
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
                                                                <td width="60%">
                                                                    &nbsp;
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
                                                                    <asp:Label ID="lblDisplayNoOfDaysPmtTab" runat="server"></asp:Label>
                                                                </td>
                                                                <td align="right">
                                                                    <asp:Label ID="lblResTimeRoomRentPmtTab" runat="server"></asp:Label>
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
                                                                    <asp:Label ID="lblResTimeTaxPmtTab" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    Infra. Service Charges
                                                                </td>
                                                                <td>
                                                                    -
                                                                </td>
                                                                <td align="right">
                                                                    <asp:Label ID="lblResTimeInfraServiceChargesPmtTab" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    Food Charges
                                                                </td>
                                                                <td>
                                                                    -
                                                                </td>
                                                                <td align="right">
                                                                    <asp:Label ID="lblResTimeFoodChargesPmtTab" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    Electricity and Food Charges
                                                                </td>
                                                                <td>
                                                                    -
                                                                </td>
                                                                <td align="right">
                                                                    <asp:Label ID="lblResTimeElectricityChargesPmtTab" runat="server"></asp:Label>
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
                                                                    <asp:Label ID="lblResTimeTotalChargesPmtTab" runat="server"></asp:Label>
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
                                                                    <asp:Label ID="lblResTimeDepositAmountPmtTab" runat="server"></asp:Label>
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
                                                                    <asp:Label ID="lblResTimeTotalPayableAmountPmtTab" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <b>Paid Amount</b>
                                                                </td>
                                                                <td align="center">
                                                                    -
                                                                </td>
                                                                <td align="right">
                                                                    <asp:Label ID="lblResTimePaidAmountPmtTab" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 0px;" colspan="3">
                                                                    <hr />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <b>Amount to Pay</b>
                                                                </td>
                                                                <td align="center">
                                                                    -
                                                                </td>
                                                                <td align="right">
                                                                    <asp:Label ID="lblResTimeAmountToPayPmtTab" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td colspan="2" align="right" style="padding-top: 10px;">
                                                                    <asp:Button ID="btnProceedForPayment" runat="server" Text="Proceed for Payment" Visible="false"
                                                                        OnClick="btnProceedForPayment_OnClick" Style="display: inline;" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div style="text-align: center;">
                                            <asp:Button ID="btnBack" runat="server" Text="Back" Style="display: inline;" OnClientClick="return fnGetTabIndex('BACK');" />
                                            <asp:Button ID="btnCheckInSave" runat="server" Text="Save" Style="display: inline;"
                                                OnClick="btnCheckInSave_Click" OnClientClick="return postbackButtonClick();"
                                                ValidationGroup="IsRequire" />
                                            <asp:Button ID="btnCheckInCancel" runat="server" Text="Back to List" Style="display: inline;"
                                                OnClick="btnCheckInCancel_Click" />
                                            <asp:Button ID="btnNext" runat="server" Text="Next" Style="display: inline;" OnClientClick="return fnGetTabIndex('NEXT');" />
                                        </div>
                                    </td>
                                    <td class="boxright">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="boxbottomleft">
                                    </td>
                                    <td class="boxbottomcenter">
                                    </td>
                                    <td class="boxbottomright">
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
                <ajx:ModalPopupExtender ID="mpeSearchGuestInfo" runat="server" TargetControlID="hdnSearchGuestInfo"
                    PopupControlID="pnlSearchGuestInfo" BackgroundCssClass="mod_background" CancelControlID="imgSearchGuestInfoCancel">
                </ajx:ModalPopupExtender>
                <asp:HiddenField ID="hdnSearchGuestInfo" runat="server" />
                <asp:Panel ID="pnlSearchGuestInfo" runat="server" Width="800px" Style="display: none;">
                    <div class="box_col1">
                        <div class="box_head">
                            <div style="display: inline;">
                                <span>
                                    <asp:Literal ID="Literal1" runat="server" Text="Guest List"></asp:Literal></span></div>
                            <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                                <asp:ImageButton ID="imgSearchGuestInfoCancel" runat="server" ImageUrl="~/images/closepopup.png"
                                    Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;" />
                            </div>
                        </div>
                        <div class="clear">
                        </div>
                        <div class="box_form">
                            <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                <tr>
                                    <td width="75px">
                                        <asp:Literal ID="litSearchGuestName" runat="server" Text="Name"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSearchGuestName" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Literal ID="litSearchMobileNo" runat="server" Text="Mobile No."></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSearchMobileNo" runat="server"></asp:TextBox>
                                        <ajx:FilteredTextBoxExtender ID="ftSearchMobileNo" runat="server" TargetControlID="txtSearchMobileNo"
                                            ValidChars="0123456789" FilterMode="ValidChars">
                                        </ajx:FilteredTextBoxExtender>
                                        <asp:ImageButton ID="btnSearchGuest" runat="server" ImageUrl="~/images/search-icon.png"
                                            Style="border: 0px; margin: -4px 0 0 5px; vertical-align: middle;" OnClick="btnSearchGuest_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="height: 300px; overflow: auto; vertical-align: top;">
                                        <div class="box_head">
                                            <span>
                                                <asp:Literal ID="Literal8" runat="server" Text="Guest List"></asp:Literal>
                                            </span>
                                        </div>
                                        <div class="clear">
                                        </div>
                                        <div class="box_content">
                                            <asp:GridView ID="gvSearchGuestList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                Width="100%" SkinID="gvNoPaging" OnRowCommand="gvSearchGuestList_RowCommand">
                                                <Columns>
                                                    <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblGvHdrSearchGuestSrNo" runat="server" Text="No."></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="110px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblGvHdrSearchGuestName" runat="server" Text="Name"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkSearchGuestName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Name")%>'
                                                                CommandName="SEARCHGUEST" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "Name")%>'></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblGvHdrSearchGuestMobileNo" runat="server" Text="Mobile No."></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <%#DataBinder.Eval(Container.DataItem, "MobileNo")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblGvHdrSearchGuestEmail" runat="server" Text="Email"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <%#DataBinder.Eval(Container.DataItem, "Email")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblGvHdrSearchGuestCountry" runat="server" Text="Country"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <%#DataBinder.Eval(Container.DataItem, "Country")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblGvHdrSearchGuestState" runat="server" Text="State"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <%#DataBinder.Eval(Container.DataItem, "State")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblGvHdrSearchGuestCity" runat="server" Text="City"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <%#DataBinder.Eval(Container.DataItem, "City")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblGvHdrSearchGuestDOB" runat="server" Text="DOB"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <%#DataBinder.Eval(Container.DataItem, "DOB")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EmptyDataTemplate>
                                                    <div style="padding: 10px;">
                                                        <b>
                                                            <asp:Label ID="lblNoRecordFoundForSearchGuest" runat="server" Text="No Record Found."></asp:Label>
                                                        </b>
                                                    </div>
                                                </EmptyDataTemplate>
                                            </asp:GridView>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="4">
                                        <asp:Button ID="btnSearchGuestSave" runat="server" Style="display: inline; padding-right: 10px;"
                                            ValidationGroup="SearchGuest" Text="Save" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                </asp:Panel>
                <ajx:ModalPopupExtender ID="mpeForeignNationalInfo" runat="server" TargetControlID="hdnForeignNationalInfo"
                    PopupControlID="pnlForeignNationalInfo" BackgroundCssClass="mod_background" CancelControlID="imbCloseForeignNationalInfoHeader">
                </ajx:ModalPopupExtender>
                <asp:HiddenField ID="hdnForeignNationalInfo" runat="server" />
                <asp:Panel ID="pnlForeignNationalInfo" runat="server" Width="800px" Style="display: none;">
                    <div class="box_col1">
                        <div class="box_head">
                            <div style="display: inline;">
                                <span>
                                    <asp:Literal ID="litpnlForeignNationalInfoHeader" runat="server" Text="Foreign National Info"></asp:Literal></span></div>
                            <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                                <asp:ImageButton ID="imbCloseForeignNationalInfoHeader" runat="server" ImageUrl="~/images/closepopup.png"
                                    Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;" />
                            </div>
                        </div>
                        <div class="clear">
                        </div>
                        <div class="box_form">
                            <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                <tr>
                                    <td width="75px" class="isrequire">
                                        <asp:Literal ID="litIdtypeForeignNatinal" runat="server" Text="ID Type"></asp:Literal>
                                    </td>
                                    <td style="padding-top: 10px;">
                                        <asp:DropDownList ID="ddlIdtypeForeignNatinal" Style="width: 120px !important;" runat="server">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfvIdtypeForeignNatinal" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                            runat="server" ValidationGroup="ForeignNatinal" ControlToValidate="ddlIdtypeForeignNatinal"
                                            InitialValue="00000000-0000-0000-0000-000000000000" Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                    <td style="width: 95px;" class="isrequire">
                                        <asp:Literal ID="litPassportNumber" runat="server" Text="Passport No."></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPassportNumber" runat="server" Style="width: 135px !important;"></asp:TextBox>
                                        <span>
                                            <asp:RequiredFieldValidator ID="rfvPassportNumber" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                runat="server" ValidationGroup="ForeignNatinal" ControlToValidate="txtPassportNumber"
                                                Display="Dynamic">
                                            </asp:RequiredFieldValidator>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="isrequire">
                                        <asp:Literal ID="litPassportDateOfIssue" runat="server" Text="Passport Date Of Issue"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPassportDateOfIssue" runat="server" Style="width: 90px !important;"
                                            onkeypress="return false;"></asp:TextBox>
                                        <asp:Image ID="imgPassportDateOfIssue" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                            Height="20px" Width="20px" />
                                        <ajx:CalendarExtender ID="calPassportDateOfIssue" PopupButtonID="imgPassportDateOfIssue"
                                            TargetControlID="txtPassportDateOfIssue" runat="server">
                                        </ajx:CalendarExtender>
                                        <img src="../../images/clear.png" id="img1" style="vertical-align: middle;" title="Clear Date"
                                            onclick="fnClearDate('<%= txtPassportDateOfIssue.ClientID %>');" />
                                        <span>
                                            <asp:RequiredFieldValidator ID="rfvPassportDateOfIssue" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                runat="server" ValidationGroup="ForeignNatinal" ControlToValidate="txtPassportDateOfIssue"
                                                Display="Dynamic">
                                            </asp:RequiredFieldValidator>
                                        </span>
                                    </td>
                                    <td class="isrequire" style="width: 175px !important;">
                                        <asp:Literal ID="litPassportDateOfExpiry" runat="server" Text="Passport Date Of Expiry"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPassportDateOfExpiry" runat="server" Style="width: 90px !important;"
                                            onkeypress="return false;"></asp:TextBox>
                                        <asp:Image ID="imgPassportDateOfExpiry" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                            Height="20px" Width="20px" />
                                        <ajx:CalendarExtender ID="calPassportDateOfExpiry" PopupButtonID="imgPassportDateOfExpiry"
                                            TargetControlID="txtPassportDateOfExpiry" runat="server">
                                        </ajx:CalendarExtender>
                                        <img src="../../images/clear.png" id="img2" style="vertical-align: middle;" title="Clear Date"
                                            onclick="fnClearDate('<%= txtPassportDateOfExpiry.ClientID %>');" />
                                        <span>
                                            <asp:RequiredFieldValidator ID="rfvPassportDateOfExpiry" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                runat="server" ValidationGroup="ForeignNatinal" ControlToValidate="txtPassportDateOfExpiry"
                                                Display="Dynamic">
                                            </asp:RequiredFieldValidator>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="isrequire">
                                        <asp:Literal ID="litPassportscan1" runat="server" Text="Passport scan1"></asp:Literal>
                                    </td>
                                    <td>
                                        <div class="browse_file_grid_test">
                                            <asp:FileUpload ID="fuPassportscan1" runat="server" />
                                        </div>
                                        <asp:RegularExpressionValidator ID="revPassportscan1" runat="server" ControlToValidate="fuPassportscan1"
                                            SetFocusOnError="true" CssClass="input-notification error png_bg" Display="Dynamic"
                                            ValidationExpression="^.+(.jpg|.JPG|.jpeg|.JPEG|.png|.PNG|.gif|.GIF|.bmp|.BMP)$"></asp:RegularExpressionValidator>
                                        <a id="a1" runat="server" target="_blank" visible="false">
                                            <img src="../../images/View.png" width="17px" alt="view photo" height="17px" /></a>
                                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/Delete.png"
                                            Visible="false" Width="16px" Height="16px" BorderStyle="None" />
                                        <asp:RequiredFieldValidator ID="rfvPassportscan1" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                            runat="server" ValidationGroup="ForeignNatinal" ControlToValidate="fuPassportscan1"
                                            Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:Literal ID="litPassportscan2" runat="server" Text="Passport scan2"></asp:Literal>
                                    </td>
                                    <td>
                                        <div class="browse_file_grid_test">
                                            <asp:FileUpload ID="fupPassportscan2" runat="server" />
                                        </div>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="fupPassportscan2"
                                            SetFocusOnError="true" ValidationGroup="ForeignNatinal" CssClass="input-notification error png_bg"
                                            Display="Dynamic" ValidationExpression="^.+(.jpg|.JPG|.jpeg|.JPEG|.png|.PNG|.gif|.GIF|.bmp|.BMP)$"></asp:RegularExpressionValidator>
                                        <a id="a2" runat="server" target="_blank" visible="false">
                                            <img src="../../images/View.png" width="17px" alt="view photo" height="17px" /></a>
                                        <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/images/Delete.png"
                                            Visible="false" Width="16px" Height="16px" BorderStyle="None" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="isrequire">
                                        <asp:Literal ID="litPassportPlaceOfIssue" runat="server" Text="Passport Place Of Issue"></asp:Literal>
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtPassportPlaceOfIssue" Style="width: 135px !important;" runat="server"></asp:TextBox>
                                        <span>
                                            <asp:RequiredFieldValidator ID="rfvPassportPlaceOfIssue" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                runat="server" ValidationGroup="ForeignNatinal" ControlToValidate="txtPassportPlaceOfIssue"
                                                Display="Dynamic">
                                            </asp:RequiredFieldValidator>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="isrequire">
                                        <asp:Literal ID="litVisatype" runat="server" Text="Visa Type"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtVisatype" Style="width: 135px !important;" runat="server"></asp:TextBox>
                                        <span>
                                            <asp:RequiredFieldValidator ID="rfvVisatype" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                runat="server" ValidationGroup="ForeignNatinal" ControlToValidate="txtVisatype"
                                                Display="Dynamic">
                                            </asp:RequiredFieldValidator>
                                        </span>
                                    </td>
                                    <td class="isrequire">
                                        <asp:Literal ID="litVisanumber" runat="server" Text="Visa No."></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtVisaNo" Style="width: 135px !important;" runat="server"></asp:TextBox>
                                        <span>
                                            <asp:RequiredFieldValidator ID="rfvVisaNo" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                runat="server" ValidationGroup="ForeignNatinal" ControlToValidate="txtVisaNo"
                                                Display="Dynamic">
                                            </asp:RequiredFieldValidator>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="isrequire" style="width: 175px !important;">
                                        <asp:Literal ID="litVisaDateofIssue" runat="server" Text="Visa Date Of Issue"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtVisaDateofIssue" runat="server" Style="width: 90px !important;"
                                            onkeypress="return false;"></asp:TextBox>
                                        <asp:Image ID="imgVisaDateofIssue" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                            Height="20px" Width="20px" />
                                        <ajx:CalendarExtender ID="calVisaDateofIssue" PopupButtonID="imgVisaDateofIssue"
                                            TargetControlID="txtVisaDateofIssue" runat="server">
                                        </ajx:CalendarExtender>
                                        <img src="../../images/clear.png" id="img3" style="vertical-align: middle;" title="Clear Date"
                                            onclick="fnClearDate('<%= txtVisaDateofIssue.ClientID %>');" />
                                        <span>
                                            <asp:RequiredFieldValidator ID="rfvVisaDateofIssue" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                runat="server" ValidationGroup="ForeignNatinal" ControlToValidate="txtVisaDateofIssue"
                                                Display="Dynamic">
                                            </asp:RequiredFieldValidator>
                                        </span>
                                    </td>
                                    <td class="isrequire">
                                        <asp:Literal ID="litVisaDateofExpiry" runat="server" Text="Visa Date Of Expiry"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtVisaDateofExpiry" runat="server" Style="width: 90px !important;"
                                            onkeypress="return false;"></asp:TextBox>
                                        <asp:Image ID="imgVisaDateofExpiry" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                            Height="20px" Width="20px" />
                                        <ajx:CalendarExtender ID="calVisaDateofExpiry" PopupButtonID="imgVisaDateofExpiry"
                                            TargetControlID="txtVisaDateofExpiry" runat="server">
                                        </ajx:CalendarExtender>
                                        <img src="../../images/clear.png" id="img4" style="vertical-align: middle;" title="Clear Date"
                                            onclick="fnClearDate('<%= txtVisaDateofExpiry.ClientID %>');" />
                                        <span>
                                            <asp:RequiredFieldValidator ID="rfvVisaDateofExpiry" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                runat="server" ValidationGroup="ForeignNatinal" ControlToValidate="txtVisaDateofExpiry"
                                                Display="Dynamic">
                                            </asp:RequiredFieldValidator>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="isrequire">
                                        <asp:Literal ID="litVisaplaceofissue" runat="server" Text="Visa Place Of Issue"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtVisaplaceofissue" Style="width: 135px !important;" runat="server"></asp:TextBox>
                                        <span>
                                            <asp:RequiredFieldValidator ID="rfvVisaplaceofissue" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                runat="server" ValidationGroup="ForeignNatinal" ControlToValidate="txtVisaplaceofissue"
                                                Display="Dynamic">
                                            </asp:RequiredFieldValidator>
                                        </span>
                                    </td>
                                    <td>
                                        <asp:Literal ID="litVisaPurpose" runat="server" Text="Purpose Of Visa"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtVisaPurpose" Style="width: 135px !important;" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="isrequire">
                                        <asp:Literal ID="litVisaScan" runat="server" Text="Visa scan"></asp:Literal>
                                    </td>
                                    <td colspan="3">
                                        <div class="browse_file_grid_test">
                                            <asp:FileUpload ID="fupVisaScan" runat="server" />
                                        </div>
                                        <asp:RegularExpressionValidator ID="revVisaScan" runat="server" ControlToValidate="fupVisaScan"
                                            SetFocusOnError="true" ValidationGroup="ForeignNatinal" CssClass="input-notification error png_bg"
                                            Display="Dynamic" ValidationExpression="^.+(.jpg|.JPG|.jpeg|.JPEG|.png|.PNG|.gif|.GIF|.bmp|.BMP)$"></asp:RegularExpressionValidator>
                                        <a id="a3" runat="server" target="_blank" visible="false">
                                            <img src="../../images/View.png" width="17px" alt="view photo" height="17px" /></a>
                                        <asp:ImageButton ID="imgVisaScan" runat="server" ImageUrl="~/images/Delete.png" Visible="false"
                                            Width="16px" Height="16px" BorderStyle="None" />
                                        <asp:RequiredFieldValidator ID="rfvVisaScan" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                            runat="server" ValidationGroup="ForeignNatinal" ControlToValidate="fupVisaScan"
                                            Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="4">
                                        <asp:Button ID="btnSaveForeignNationalInfo" runat="server" ValidationGroup="ForeignNatinal"
                                            Style="display: inline; padding-right: 10px;" Text="Save" OnClick="btnSaveForeignNationalInfo_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="Panel1" runat="server" Width="800px" Style="display: none;">
                    <div class="box_col1">
                        <div class="box_head">
                            <span>
                                <asp:Literal ID="Literal10" runat="server" Text="Guest List"></asp:Literal></span></div>
                        <div class="clear">
                        </div>
                        <div class="box_form">
                            <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                <tr>
                                    <td width="75px">
                                        <asp:Literal ID="Literal11" runat="server" Text="Name"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Literal ID="Literal12" runat="server" Text="Mobile No."></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                                        <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtSearchMobileNo"
                                            ValidChars="0123456789" FilterMode="ValidChars">
                                        </ajx:FilteredTextBoxExtender>
                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/search-icon.png"
                                            Style="border: 0px; margin: -4px 0 0 5px; vertical-align: middle;" OnClick="btnSearchGuest_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="height: 300px; overflow: auto; vertical-align: top;">
                                        <div class="box_head">
                                            <span>
                                                <asp:Literal ID="Literal13" runat="server" Text="Guest List"></asp:Literal>
                                            </span>
                                        </div>
                                        <div class="clear">
                                        </div>
                                        <div class="box_content">
                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                Width="100%" SkinID="gvNoPaging" OnRowCommand="gvSearchGuestList_RowCommand">
                                                <Columns>
                                                    <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblGvHdrSearchGuestSrNo" runat="server" Text="No."></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="110px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblGvHdrSearchGuestName" runat="server" Text="Name"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkSearchGuestName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Name")%>'
                                                                CommandName="SEARCHGUEST" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "Name")%>'></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblGvHdrSearchGuestMobileNo" runat="server" Text="Mobile No."></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <%#DataBinder.Eval(Container.DataItem, "MobileNo")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblGvHdrSearchGuestEmail" runat="server" Text="Email"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <%#DataBinder.Eval(Container.DataItem, "Email")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblGvHdrSearchGuestCountry" runat="server" Text="Country"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <%#DataBinder.Eval(Container.DataItem, "Country")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblGvHdrSearchGuestState" runat="server" Text="State"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <%#DataBinder.Eval(Container.DataItem, "State")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblGvHdrSearchGuestCity" runat="server" Text="City"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <%#DataBinder.Eval(Container.DataItem, "City")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblGvHdrSearchGuestDOB" runat="server" Text="DOB"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <%#DataBinder.Eval(Container.DataItem, "DOB")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EmptyDataTemplate>
                                                    <div style="padding: 10px;">
                                                        <b>
                                                            <asp:Label ID="lblNoRecordFoundForSearchGuest" runat="server" Text="No Record Found."></asp:Label>
                                                        </b>
                                                    </div>
                                                </EmptyDataTemplate>
                                            </asp:GridView>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="4">
                                        <asp:Button ID="Button2" runat="server" Style="display: inline; padding-right: 10px;"
                                            ValidationGroup="SearchGuest" Text="Save" />
                                        <asp:Button ID="Button3" runat="server" Style="display: inline;" Text="Cancel" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                </asp:Panel>
                <asp:HiddenField ID="hdnOpenCheckinVoucher" runat="server" />
                <ajx:ModalPopupExtender ID="mpeCheckInVoucher" runat="server" TargetControlID="hdnOpenCheckinVoucher"
                    PopupControlID="pnlCheckinVoucher" CancelControlID="iBtnCacelCheckinVoucher"
                    BackgroundCssClass="mod_background">
                </ajx:ModalPopupExtender>
                <asp:Panel ID="pnlCheckinVoucher" runat="server" Width="750px">
                    <div class="box_col1">
                        <div class="box_head">
                            <div style="display: inline;">
                                <span>
                                    <asp:Literal ID="Literal21" runat="server" Text="Check In Voucher"></asp:Literal></span></div>
                            <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                                <asp:ImageButton ID="iBtnCacelCheckinVoucher" runat="server" ImageUrl="~/images/closepopup.png"
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
                                                            <asp:Literal ID="litCheckInVoucher" runat="server" Text="Check In Voucher"></asp:Literal></b>
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
                                                                                <asp:Literal ID="Literal17" runat="server" Text="Mobile No."></asp:Literal>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Literal ID="litChVchrMobileNo" runat="server"></asp:Literal>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Literal ID="Literal18" runat="server" Text="Email"></asp:Literal>
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
                                        <asp:Button ID="btnPrintCheckinVoucher" runat="server" Text="Print" OnClientClick="fnOpenCheckInVoucherPrintWindow();" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                </asp:Panel>
            </asp:View>
            <asp:View ID="vPayment" runat="server">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="content">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="boxtopleft">
                                        &nbsp;
                                    </td>
                                    <td class="boxtopcenter">
                                        <asp:Literal ID="Literal19" runat="server" Text="Receipt"></asp:Literal>
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
                                            <table width="100%" border="0">
                                                <tr>
                                                    <td colspan="3">
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
                                                                    Rate Card
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="ltrChkPmtRateCard" runat="server"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    Room Type
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="ltrChkPmtRoomType" runat="server"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    Room No.
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="ltrChkPmtRoomNo" runat="server"></asp:Literal>
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
                                                <tr id="trPaymentHistory" runat="server" visible="true">
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
                                                                <td>
                                                                    Infra. Service Charges
                                                                </td>
                                                                <td>
                                                                    -
                                                                </td>
                                                                <td align="right">
                                                                    <asp:Label ID="lblResTimeInfraServiceCharges" runat="server"></asp:Label>
                                                                </td>
                                                             </tr>
                                                             <tr>
                                                                <td>
                                                                    Food Charges
                                                                </td>
                                                                <td>
                                                                    -
                                                                </td>
                                                                <td align="right">
                                                                    <asp:Label ID="lblResTimeFoodCharges" runat="server"></asp:Label>
                                                                </td>
                                                             </tr>
                                                             <tr>
                                                                <td>
                                                                    Electricity and Water Charges
                                                                </td>
                                                                <td>
                                                                    -
                                                                </td>
                                                                <td align="right">
                                                                    <asp:Label ID="lblResTimeElectricityCharges" runat="server"></asp:Label>
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
                                                        <table width="100%" border="0">
                                                            <tr>
                                                                <td>
                                                                    <b>Receipt</b>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 0px;">
                                                                    <hr />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <div class="box_content">
                                                                        <asp:GridView ID="gvPaymentList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                            OnRowDataBound="gvPaymentList_RowDataBound" Width="100%" OnRowCommand="gvFolioDetails_RowCommand">
                                                                            <Columns>
                                                                                <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrDateOfPayment" runat="server" Text="Date"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblDateOfPayment" runat="server"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrTransactionNo" runat="server" Text="Transaction #"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%#DataBinder.Eval(Container.DataItem, "BookNo")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrPaymentMode" runat="server" Text="Payment Mode"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%--<%#DataBinder.Eval(Container.DataItem, "PaymentMode")%>--%>
                                                                                        <asp:Label ID="lblPaymentMode" runat="server"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrAmount" runat="server" Text="Amount"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblAmount" runat="server"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="50px" Visible="true" HeaderStyle-HorizontalAlign="Left"
                                                                                    ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrPaymentDetailsAction" runat="server" Text="Action"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblPaymentDetailsPopUp" runat="server" Text="Action"></asp:Label>
                                                                                        <ajx:HoverMenuExtender ID="hmePaymentDetails" runat="server" TargetControlID="lblPaymentDetailsPopUp"
                                                                                            PopupControlID="panPaymentDetails" PopupPosition="Left">
                                                                                        </ajx:HoverMenuExtender>
                                                                                        <asp:Panel ID="panPaymentDetails" runat="server" Style="visibility: hidden; opacity: 100%">
                                                                                            <div class="actionsbuttons_hovermenu">
                                                                                                <table border="0" cellpadding="0" cellspacing="0" class="actionsbuttons_hover_lettmenu_table">
                                                                                                    <tr>
                                                                                                        <td class="actionsbuttons_hover_lettmenu">
                                                                                                        </td>
                                                                                                        <td class="actionsbuttons_hover_centermenu">
                                                                                                            <ul>
                                                                                                                <li>
                                                                                                                    <asp:LinkButton ID="lnkPaymentDetailsVoid" Style="background: none !important; border: none;"
                                                                                                                        runat="server" ToolTip="Void" CommandName="VOID" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "BookID")%>'><img src="../../images/file.png" /></asp:LinkButton>
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
                                                                                        <asp:Label ID="lblNoRecordFound" runat="server" Text="No payment found."></asp:Label>
                                                                                    </b>
                                                                                </div>
                                                                            </EmptyDataTemplate>
                                                                        </asp:GridView>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <b>Total Received</b>&nbsp;&nbsp;&nbsp;<b><asp:Label ID="lblTotalPaymentReceived"
                                                                        runat="server"></asp:Label></b>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 0px;">
                                                                    <hr />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <b>
                                                                        <asp:Label ID="lblAmountBalanceOrDueText" runat="server"></asp:Label></b>&nbsp;&nbsp;&nbsp;<b><asp:Label
                                                                            ID="lblAmountBalanceOrDue" runat="server"></asp:Label></b>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding-top: 15px;" align="right">
                                                                    <asp:Button ID="btnPrintReceipt" runat="server" Text="Print Receipt" OnClientClick="fnOpneWindow();"
                                                                        Style="display: inline;" />
                                                                    <asp:Button ID="btnCheckInReRoute" runat="server" Text="Bill to Company" Style="display: inline;"
                                                                        OnClick="btnCheckInReRoute_Click" />
                                                                    <%--<asp:Button ID="btnBackToListFromPmtView" runat="server" Text="Back" Style="display: inline;"
                                                                        OnClick="btnCheckInCancel_Click" />--%>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-top:5px; color:Blue; font-weight:bold;" colspan="3">
                                                        <asp:Literal ID="ltrSpecNote" runat="server" ></asp:Literal>
                                                        <hr />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table width="100%">
                                                            <tr>
                                                                <td>
                                                                    <b>Receipt</b>
                                                                </td>
                                                                <td style="padding: 0px;" align="right">
                                                                    <asp:Literal ID="ltrMinAmtForConfirmReservation" runat="server"></asp:Literal>
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
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td style="padding-top: 5px;">
                                                                    <table width="100%" border="0">
                                                                        <tr>
                                                                            <td width="100px">
                                                                                &nbsp;<asp:Button ID="btnSavePayment" runat="server" Text="Save" Style="display: inline;"
                                                                        ValidationGroup="RequireForPayment" OnClick="btnSavePayment_OnClick" OnClientClick="hidebutton();" />
                                                                            </td>
                                                                            <td >
                                                                                <asp:Button ID="btnCheckInReservatin" runat="server" Text="Check In Reservation"
                                                                        Visible="false" Style="display: inline;" ValidationGroup="RequireForCheckIn" OnClick="btnCheckInReservatin_OnClick" />
                                                                            </td>
                                                                            <td >
                                                                                <asp:Button ID="btnBackToListFromPmtView" runat="server" Text="Back to Dashboard"
                                                                        Style="display: inline;" OnClick="btnCheckInCancel_Click" />
                                                                            </td>
                                                                            <td>&nbsp;</td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td style="border-left: 1px solid #CCCCCC; display:none;">
                                                    </td>
                                                    <td align="left" style="vertical-align:top; padding-top:10px;" >
                                                        <table width="100%" style="display:none;">
                                                            <tr>
                                                                <td colspan="2">
                                                                    <b>Assign Room</b>
                                                                    <hr />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="50px">
                                                                    Booking Status
                                                                </td>
                                                                <td>
                                                                    Confirmed
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <b>Room No.</b>
                                                                </td>
                                                                <td style="width: 264px;">
                                                                    <asp:DropDownList ID="ddlRoomNumber" runat="server">
                                                                    </asp:DropDownList>
                                                                    <span>
                                                                        <asp:RequiredFieldValidator ID="rfvRoomNumber" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                            SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                            ValidationGroup="IsRequire" ControlToValidate="ddlRoomNumber" Display="Dynamic">
                                                                        </asp:RequiredFieldValidator>
                                                                    </span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td style="padding-top: 15px;">
                                                                    <asp:Button ID="btnAssignRoomNo" runat="server" Text="Save" Style="display: inline;" ValidationGroup="IsRequire"
                                                                        OnClick="btnAssignRoomNo_OnClick" />
                                                                    <asp:Button ID="btnCancelAssignRoom" runat="server" Text="Back to Dashboard" Style="display: inline;"
                                                                        OnClick="btnCancelAssignRoom_Click" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                    <td class="boxright">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="boxbottomleft">
                                    </td>
                                    <td class="boxbottomcenter">
                                    </td>
                                    <td class="boxbottomright">
                                    </td>
                                </tr>
                            </table>
                            <div style="height: 10px;">
                            </div>
                            <div class="clear_divider">
                            </div>
                            <div class="clear">
                            </div>
                        </td>
                    </tr>
                </table>
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
                                    <asp:Literal ID="Literal20" runat="server" Text="Payment Receipt"></asp:Literal></span></div>
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
                                        Guest Email:&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtPaymentTimeEmail" SkinID="nowidth" Width="250px" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvRequire2SendGuestEmail" SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                             ValidationGroup="IsRequire4GuestEmail" ControlToValidate="txtPaymentTimeEmail" Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                        <span>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Display="Dynamic" ValidationGroup="IsRequire4GuestEmail"
                                             runat="server" ErrorMessage="Please Enter Valid Email" ForeColor="Red" ControlToValidate="txtPaymentTimeEmail"
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
            </asp:View>
            <asp:View ID="vAssignRoomNumber" runat="server">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="content">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="boxtopleft">
                                        &nbsp;
                                    </td>
                                    <td class="boxtopcenter">
                                        <asp:Literal ID="Literal5" runat="server" Text="Assign Room"></asp:Literal>
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
                                                    <td width="215px">
                                                        From&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtSearchFromDate" runat="server"
                                                            Style="width: 100px !important;" SkinID="searchtextbox" Enabled="false" onkeydown="return stopKey(event);"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rvfFromDate" runat="server" ControlToValidate="txtSearchFromDate"
                                                            SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequireSearch"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td width="200px">
                                                        To&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtSearchToDate" runat="server"
                                                            Enabled="false" Style="width: 100px !important;" SkinID="searchtextbox" onkeydown="return stopKey(event);"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rvfToDate" runat="server" ControlToValidate="txtSearchToDate"
                                                            SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequireSearch"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td colspan="2">
                                                        Room Type&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddlSearchRoomType" runat="server"
                                                            Enabled="false" SkinID="nowidth" Width="180px">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="rvfSearchRoomType" InitialValue="00000000-0000-0000-0000-000000000000"
                                                            SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                            ValidationGroup="IsRequireSearch" ControlToValidate="ddlSearchRoomType" Display="Dynamic">
                                                        </asp:RequiredFieldValidator>
                                                        <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                            Visible="false" Style="border: 0px; margin: -1px 0 0 10px; vertical-align: middle;"
                                                            OnClick="btnSearch_Click" ValidationGroup="IsRequireSearch" OnClientClick="return fnCheckDate();" />
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
                                                                    <asp:DropDownList ID="DropDownList1" runat="server" SkinID="nowidth" Width="100px">
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
                                                                    <asp:Button ID="Button5" runat="server" Text="Advanced Search" Style="display: inline;" />
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
                                            <div style="text-align: center;">
                                                <asp:Button ID="btnBackFromRoomChart" runat="server" OnClick="btnBackFromRoomChart_OnClick"
                                                    Text="Back" Style="display: inline;" />
                                            </div>
                                        </div>
                                    </td>
                                    <td class="boxright">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="boxbottomleft">
                                    </td>
                                    <td class="boxbottomcenter">
                                    </td>
                                    <td class="boxbottomright">
                                    </td>
                                </tr>
                            </table>
                            <div style="height: 10px;">
                            </div>
                            <div class="clear_divider">
                            </div>
                            <div class="clear">
                            </div>
                        </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="vSplitBilling" runat="server">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="content">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="boxtopleft">
                                        &nbsp;
                                    </td>
                                    <td class="boxtopcenter">
                                        <asp:Literal ID="litMainHeader" runat="server" Text="Bill to Company"></asp:Literal>
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
                                            <table cellpadding="2" cellspacing="2" width="100%">
                                                <tr>
                                                    <td style="font-size: 13px; border: 1px solid #ccccce;">
                                                        <table cellpadding="2" cellspacing="2" width="100%">
                                                            <tr>
                                                                <td width="100px">
                                                                    <b>
                                                                        <asp:Literal ID="litReRouteSetupBookingNo" runat="server" Text="Booking #"></asp:Literal></b>
                                                                </td>
                                                                <td width="240px">
                                                                    <asp:Literal ID="litDisplayReRouteSetupBookingNo" runat="server"></asp:Literal>
                                                                </td>
                                                                <td width="110px">
                                                                    <b>
                                                                        <asp:Literal ID="litReRouteSetupSourceFolio" runat="server" Text="Folio No."></asp:Literal></b>
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="litDisplayReRouteSetupSourceFolio" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <b>
                                                                        <asp:Literal ID="litReRouteSetupUnitNo" runat="server" Text="Room No."></asp:Literal></b>
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="litDisplayReRouteSetupUnitNo" runat="server"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <b>
                                                                        <asp:Literal ID="litReRouteSetupGuestName" runat="server" Text="Name"></asp:Literal></b>
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="litDisplayReRouteSetupGuestName" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-top: 10px;">
                                                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                            <tr>
                                                                <td style="vertical-align: top;" width="50%">
                                                                    <table cellpadding="2" cellspacing="2" width="100%" border="0">
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                <table width="100%">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <b>Particulars</b>
                                                                                        </td>
                                                                                        <td>
                                                                                            <b>No. of Nights</b>
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
                                                                                            <asp:Label ID="lblSplBillDisplayNoOfDays" runat="server"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="lblSplBillDisplayRoomRent" runat="server"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            Tax
                                                                                        </td>
                                                                                        <td>
                                                                                            -
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="lblSplBillDisplayTax" runat="server"></asp:Label>
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
                                                                                            <asp:Label ID="lblSplBillDisplayTotalAmount" runat="server"></asp:Label>
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
                                                                                            <asp:Label ID="lblSplBillDisplayDepositAmount" runat="server"></asp:Label>
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
                                                                                        <td>
                                                                                            -
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="lblSplBillTotalPayableAmount" runat="server"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="padding: 0px;" colspan="3">
                                                                                            <hr />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <b>Payable By Guest</b>
                                                                                        </td>
                                                                                        <td>
                                                                                            -
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="lblPayableByGuest" runat="server"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <b>Payable By Company</b>
                                                                                        </td>
                                                                                        <td>
                                                                                            -
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="lblPayableByCompany" runat="server" Text="0.00"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="padding: 0px;" colspan="3">
                                                                                            <hr />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <b>Paid Amount</b>
                                                                                        </td>
                                                                                        <td>
                                                                                            -
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="lblSplBillTotalAmountReceived" runat="server"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="padding: 0px;" colspan="3">
                                                                                            <hr />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <b>Amount to Pay</b>
                                                                                        </td>
                                                                                        <td>
                                                                                            -
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="lblSplBillAmountToPay" runat="server"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
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
                                                                                        <td colspan="2">
                                                                                            <b>Billing Instruction</b>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="padding: 0px;" colspan="2">
                                                                                            <hr />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2">
                                                                                            <%if (IsVoucherMessage)
                                                                                              { %>
                                                                                            <div class="message finalsuccess">
                                                                                                <p>
                                                                                                    <strong>
                                                                                                        <asp:Label ID="lblVoucherMessage" runat="server"></asp:Label></strong>
                                                                                                </p>
                                                                                            </div>
                                                                                            <%}%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 175px !important;" class="isrequire">
                                                                                            Company
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:DropDownList Style="height: 25px; width: 135px;" ID="ddlCompany" runat="server">
                                                                                            </asp:DropDownList>
                                                                                            <span>
                                                                                                <asp:RequiredFieldValidator ID="rfvCompany" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                                                    SetFocusOnError="True" CssClass="input-notification error png_bg" runat="server"
                                                                                                    ValidationGroup="IsRequireVoucher" ControlToValidate="ddlCompany" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                                            </span>
                                                                                            <%--<asp:Literal ID="litDisplayFolioNo" runat="server" Text="(Folio No.)"></asp:Literal>--%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <%--<tr>
                                                                                        <td>
                                                                                            Amount Charge To Company
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtCompanyCharges" runat="server" SkinID="nowidth" Width="100px"></asp:TextBox>
                                                                                            &nbsp;&nbsp;&nbsp;
                                                                                            <asp:DropDownList ID="DropDownList3" runat="server" SkinID="nowidth" Width="80px">
                                                                                                <asp:ListItem Text="-Select-" Value="0"></asp:ListItem>
                                                                                                <asp:ListItem Text="%" Value="1"></asp:ListItem>
                                                                                                <asp:ListItem Text="Flat" Value="1"></asp:ListItem>
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                    </tr>--%>
                                                                                    <tr>
                                                                                        <td colspan="2" style="padding-top: 10px;">
                                                                                            <b>Authorisation</b>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="padding: 0px;" colspan="2">
                                                                                            <hr />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            Employee ID
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="lblDisplayVoucherEmployeeID" runat="server"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            Department
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="lblDisplayVoucherDepartment" runat="server"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            Job Title
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="lblDisplayJobTitle" runat="server"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="isrequire">
                                                                                            Voucher No.
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtVoucherNo" runat="server"></asp:TextBox>
                                                                                            <span>
                                                                                                <asp:RequiredFieldValidator ID="rfvVoucherNo" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                                                    runat="server" ValidationGroup="IsRequireVoucher" ControlToValidate="txtVoucherNo"
                                                                                                    Display="Dynamic">
                                                                                                </asp:RequiredFieldValidator>
                                                                                            </span>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            Voucher Authorised By
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtVoucherAuthorisedBy" runat="server" MaxLength="150"></asp:TextBox>
                                                                                            <%-- <span>
                                                                                                <asp:RequiredFieldValidator ID="rfvVoucherAuthorisedBy" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                                                    runat="server" ValidationGroup="IsRequireVoucher" ControlToValidate="txtVoucherAuthorisedBy"
                                                                                                    Display="Dynamic">
                                                                                                </asp:RequiredFieldValidator>
                                                                                            </span>--%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            Validity
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtValidity" runat="server" Style="width: 90px !important;" onkeypress="return false;"></asp:TextBox>
                                                                                            <asp:Image ID="imgValidity" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                                                                Height="20px" Width="20px" />
                                                                                            <ajx:CalendarExtender ID="calValidity" PopupButtonID="imgValidity" TargetControlID="txtValidity"
                                                                                                runat="server">
                                                                                            </ajx:CalendarExtender>
                                                                                            <img src="../../images/clear.png" id="imgAD" style="vertical-align: middle;" title="Clear Date"
                                                                                                onclick="fnClearDate('<%= txtValidity.ClientID %>');" />
                                                                                            <%-- <span>
                                                                                                <asp:RequiredFieldValidator ID="rfvValidity" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                                                    runat="server" ValidationGroup="IsRequireVoucher" ControlToValidate="txtValidity"
                                                                                                    Display="Dynamic">
                                                                                                </asp:RequiredFieldValidator>
                                                                                            </span>--%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="isrequire">
                                                                                            Voucher
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:FileUpload ID="fuVoucher" runat="server" Height="25px" />
                                                                                            <span>
                                                                                                <asp:RequiredFieldValidator ID="rfvVoucher" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                                                    runat="server" ValidationGroup="IsRequireVoucher" ControlToValidate="fuVoucher"
                                                                                                    Display="Dynamic">
                                                                                                </asp:RequiredFieldValidator>
                                                                                            </span><span>
                                                                                                <asp:RegularExpressionValidator ID="revVoucher" runat="server" ControlToValidate="fuVoucher"
                                                                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequireVoucher"
                                                                                                    Display="Dynamic" ValidationExpression="^.+(.jpg|.JPG|.jpeg|.JPEG|.png|.PNG|gif|GIF|.bmp|.BMP)$"></asp:RegularExpressionValidator>
                                                                                            </span>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Button runat="server" ID="btnUploadAndCompareVoucher" Text="Upload & Compare"
                                                                                                ValidationGroup="IsRequireVoucher" OnClick="btnUploadAndCompareVoucher_Click"
                                                                                                Style="display: inline;" OnClientClick="return postbackButtonClickOnComparision();" />
                                                                                            <asp:Button ID="btnVoucherProceed" runat="server" OnClick="btnVoucherProceed_Click"
                                                                                                Text="Proceed" Style="display: inline;" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2">
                                                                                            <asp:LinkButton ID="lnkBilltoCompanySettlement" runat="server" Text="Bill to Company Settlement"
                                                                                                OnClick="lnkBilltoCompanySettlement_Click" Visible="false" OnClientClick="return postbackButtonClickPopup();"></asp:LinkButton>
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
                                                    <td colspan="3" align="center">
                                                        <asp:Button runat="server" ID="btnCancelSplitBilling" Style="display: inline;" Text="Next"
                                                            OnClick="btnCancelSplitBilling_OnClick" Visible="false" />
                                                        <asp:Button runat="server" ID="Button4" Text="Back" Style="display: inline;" OnClick="btnCancelSplitBilling_OnClick" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                    <td class="boxright">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="boxbottomleft">
                                    </td>
                                    <td class="boxbottomcenter">
                                    </td>
                                    <td class="boxbottomright">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                </td> </tr> </table>
            </asp:View>
        </asp:MultiView>
        <ajx:ModalPopupExtender ID="mpePreference" runat="server" TargetControlID="hdnPreference"
            PopupControlID="pnlPreference" BackgroundCssClass="mod_background" CancelControlID="imgPreferenceCancel">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnPreference" runat="server" />
        <asp:Panel ID="pnlPreference" runat="server" Width="600px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <div style="display: inline;">
                        <span>
                            <asp:Literal ID="litHdrPreference" runat="server" Text="Preference"></asp:Literal></span>
                    </div>
                    <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                        <asp:ImageButton ID="imgPreferenceCancel" runat="server" ImageUrl="~/images/closepopup.png"
                            Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;" />
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td class="isrequire">
                                <asp:Literal ID="litPreference" runat="server" Text="Preference"></asp:Literal>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlPreference" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvPreference" InitialValue="00000000-0000-0000-0000-000000000000"
                                    SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                    ValidationGroup="IsRequirePreference" ControlToValidate="ddlPreference" Display="Dynamic">
                                </asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="litPreferenceDetails" runat="server" Text="Details"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPreferenceDetails" runat="server" Style="width: 450px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="vertical-align: top;">
                                <asp:Literal ID="litPreferenceDescription" runat="server" Text="Description"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPreferenceDescription" runat="server" Style="width: 450px" TextMode="MultiLine"
                                    Rows="4"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Button ID="btnPreferenceSave" OnClick="btnPreferenceSave_OnClick" runat="server"
                                    Text="Save" Style="display: inline;" ValidationGroup="IsRequirePreference" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpeManagementNote" runat="server" TargetControlID="hdnManagementNote"
            PopupControlID="pnlManagementNote" BackgroundCssClass="mod_background" CancelControlID="imgManagementNoteCancel">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnManagementNote" runat="server" />
        <asp:Panel ID="pnlManagementNote" runat="server" Width="600px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <div style="display: inline;">
                        <span>
                            <asp:Literal ID="litHdrManagementNote" runat="server" Text="Management Note"></asp:Literal></span>
                    </div>
                    <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                        <asp:ImageButton ID="imgManagementNoteCancel" runat="server" ImageUrl="~/images/closepopup.png"
                            Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;" />
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td class="isrequire" style="vertical-align: top; width: 60px;">
                                <asp:Literal ID="litManagementNote" runat="server" Text="Note"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtManagementNote" runat="server" Style="width: 450px" TextMode="MultiLine"
                                    Rows="5"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvManagementNote" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                    runat="server" ValidationGroup="IsRequireManagementNote" ControlToValidate="txtManagementNote"
                                    Display="Dynamic">
                                </asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Button ID="btnManagementNoteSave" OnClick="btnManagementNoteSave_OnClick" runat="server"
                                    Text="Save" Style="display: inline;" ValidationGroup="IsRequireManagementNote" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpeCheckInPayment" runat="server" TargetControlID="hdnCheckInPayment"
            PopupControlID="pnlCheckInPayment" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnCheckInPayment" runat="server" />
        <asp:Panel ID="pnlCheckInPayment" runat="server" Width="400px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <div style="display: inline;">
                        <span>
                            <asp:Literal ID="Literal6" runat="server" Text="Receipt"></asp:Literal></span></div>
                    <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                        <asp:ImageButton ID="iBtnCacelCheckInPayment" runat="server" ImageUrl="~/images/closepopup.png"
                            Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;"
                            OnClick="iBtnCacelCheckInPayment_OnClick" />
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td class="isrequire">
                                <b>
                                    <asp:Literal ID="Literal7" runat="server" Text="Booking #"></asp:Literal></b>
                            </td>
                            <td>
                                <asp:TextBox ID="txtForPaymentBookingNo" runat="server" Style="width: 200px"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rfvForPaymentBookingNo" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                        runat="server" ValidationGroup="IsRequireForPayment" ControlToValidate="txtForPaymentBookingNo"
                                        Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                </span>
                                <ajx:FilteredTextBoxExtender ID="ftePaymentBookingNo" runat="server" TargetControlID="txtForPaymentBookingNo"
                                    FilterMode="ValidChars" ValidChars="0123456789">
                                </ajx:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="Literal9" runat="server" Text="Guest Name"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtForPaymentGuestName" runat="server" Style="width: 200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Button ID="btnProceedCheckInPayment" runat="server" Text="Proceed" Style="display: inline;"
                                    OnClick="btnProceedCheckInPayment_OnClick" ValidationGroup="IsRequireForPayment" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpeReservationProceed" runat="server" TargetControlID="hdnReservationProceed"
            PopupControlID="pnlReservationProceed" BackgroundCssClass="mod_background" CancelControlID="imgCancelReservationProceed"
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
                        <asp:ImageButton ID="imgCancelReservationProceed" runat="server" ImageUrl="~/images/closepopup.png"
                            Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;" />
                    </div>
                </div>
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
                                <b>Check In Date</b>
                            </td>
                            <td>
                                <asp:TextBox ID="txtReservationProceedFromDate" runat="server" Style="width: 120px !important;"
                                    SkinID="searchtextbox" onkeypress="return false;" Enabled="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>Check Out Date</b>
                            </td>
                            <td>
                                <asp:TextBox ID="txtReservationProceedToDate" runat="server" Style="width: 120px !important;"
                                    SkinID="searchtextbox" onkeypress="return false;" Enabled="false"></asp:TextBox>
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
                            <td style="padding-top: 10px; padding-bottom: 10px;" colspan="2" align="center">
                                <asp:Button ID="btnProceed" runat="server" OnClick="btnProceed_OnClick" Style="display: inline;
                                    padding-right: 10px;" Text="Proceed" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpeOpenCounter" runat="server" TargetControlID="hdnOpenCounter"
            PopupControlID="pnlOpenCounter" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnOpenCounter" runat="server" />
        <asp:Panel ID="pnlOpenCounter" runat="server" Width="400px">
            <div class="box_col1">
                <div class="box_head">
                    <div style="display: inline;">
                        <span>
                            <asp:Literal ID="Literal23" runat="server" Text="Counter"></asp:Literal></span></div>
                    <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                        <asp:ImageButton ID="iBtnCloseCounter" runat="server" ImageUrl="~/images/closepopup.png"
                            OnClick="iBtnCloseCounter_OnClick" Style="border: 0px; width: 16px; height: 16px;
                            margin: -4px 0 0 5px; vertical-align: middle;" />
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table width="100%">
                        <tr>
                            <td align="left">
                                <ucCtrlCommonCounterLogin:CommonCounterLogin ID="ucCommonCounterLogin" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnSaveCounterData" runat="server" Text="Log In" OnClick="btnSaveCounterData_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpeCounterErrorMessage" runat="server" TargetControlID="hfCounterMessage"
            PopupControlID="pnlCounterErrorMessage" BackgroundCssClass="mod_background" BehaviorID="mpeCounterErrorMessage">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hfCounterMessage" runat="server" />
        <asp:Panel ID="pnlCounterErrorMessage" runat="server" Style="display: none; min-height: 350px;
            min-width: 350px;">
            <div class="box_col1" style="height: 300px; width: 500px;">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="ltrHeaderCounterMsg" runat="server" Text="Message"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%" style="margin-top: 75px;">
                        <tr>
                            <td align="center" style="padding-bottom: 15px;">
                                <asp:Label ID="lblCounterErrorMessage" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnCounterErrorMessageOK" Text="OK" runat="server" OnClick="btnCounterErrorMessageOK_OnClick"
                                    Style="display: inline; padding-right: 10px;" />
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
        <ajx:ModalPopupExtender ID="mpeCompareVoucher" runat="server" TargetControlID="hdnCompareVoucher"
            PopupControlID="pnlCompareVoucher" BackgroundCssClass="mod_background" CancelControlID="iBtnCacelVoucherPopup">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnCompareVoucher" runat="server" />
        <asp:Panel ID="pnlCompareVoucher" runat="server" Style="display: none; min-height: 350px;
            min-width: 350px;">
            <div class="box_col1" style="width: 1000px;">
                <div class="box_head">
                    <div style="display: inline;">
                        <span>
                            <asp:Literal ID="Literal24" runat="server" Text="Voucher"></asp:Literal></span></div>
                    <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                        <asp:ImageButton ID="iBtnCacelVoucherPopup" runat="server" ImageUrl="~/images/closepopup.png"
                            Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;" />
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td style="padding-bottom: 15px; width: 49%; padding-right: 15px; border-right: 1px solid gray;
                                vertical-align: top;">
                                <%--<asp:Image ID="imgCompanyVoucher" runat="server" Style="width: 450px; height: 400px;" />--%>
                                <iframe id="iFrmTest" runat="server" style="width: 450px; height: 400px;"></iframe>
                                <b>
                                    <asp:Literal ID="litCompanyVoucherMsg" runat="server" Visible="false" Text="Company Voucher not Found."></asp:Literal></b>
                            </td>
                            <td style="padding-bottom: 15px; vertical-align: top;">
                                <asp:Image ID="imgGuestVoucher" runat="server" Style="width: 450px; height: 400px;" />
                                <b style="vertical-align: top;">
                                    <asp:Literal ID="litGuestVoucherMsg" runat="server" Visible="false" Text="Guest Voucher not Found."></asp:Literal></b>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Button ID="btnPopupVoucherProceed" Text="Proceed" runat="server" OnClick="btnPopupVoucherProceed_OnClick"
                                    Style="display: inline; padding-right: 10px;" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <ucCtrlCommonBillToCompany:CommonBillToCompany ID="ctrlBillToCompany" runat="server"
            OnbtnCommonBillToCompanyCallParent_Click="btnCommonBillToCompanyCallParent_Click" />
        <ucCtrlVoidTransaction:VoidTransaction ID="ctrlCommonVoidTransaction" runat="server"
            OnbtnVoidTransactionCallParent_Click="btnVoidTransactionCallParent_Click" />
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnUploadDocument" />
        <asp:PostBackTrigger ControlID="linkForeignNationalpopup" />
        <asp:PostBackTrigger ControlID="btnSaveForeignNationalInfo" />
        <asp:PostBackTrigger ControlID="btnCheckInSave" />
        <asp:PostBackTrigger ControlID="btnUploadAndCompareVoucher" />
        <asp:PostBackTrigger ControlID="btnCheckInReRoute" />
        <asp:PostBackTrigger ControlID="Button4" />
        <asp:PostBackTrigger ControlID="btnVoucherProceed" />
        <asp:PostBackTrigger ControlID="btnPopupVoucherProceed" />
        <asp:PostBackTrigger ControlID="lnkBilltoCompanySettlement" />
    </Triggers>
</asp:UpdatePanel>
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updCheckInList" ID="UpdateProgressCheckInList"
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
