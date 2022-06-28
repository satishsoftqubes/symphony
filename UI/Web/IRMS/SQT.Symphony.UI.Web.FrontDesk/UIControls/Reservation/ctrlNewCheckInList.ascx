<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlNewCheckInList.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation.ctrlNewCheckInList" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<link type="text/css" href="../../Styles/jquery-ui-1.8.5.custom.css" rel="stylesheet" />
<script type="text/javascript" src="../../Scripts/jquery-1.4.2.min.js"></script>
<script type="text/javascript" src="../../Scripts/jquery-ui-1.8.5.custom.min.js"></script>
<link rel="stylesheet" href="../../Styles/jquery.ui.timepicker.css" type="text/css" />
<script type="text/javascript" src="../../Scripts/jquery-ui-timepicker-addon.js"></script>
<script type="text/javascript" language="javascript" src="../../Scripts/script.js"></script>
<script type="text/javascript">
    function pageLoad(sender, args) {
        $('#<%=txtServiceTime.ClientID %>').timepicker({ ampm: false });

        $("#tabs").tabs();

        $('#tabs').tabs({
            select: function (event, ui) {
                window.location.hash = ui.tab.hash;
            }
        });

    }

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<script>
    function fnCalculateDayForDailyBooking(id) {
        var originalTable = $("#table_" + id).clone();
        var tds = $(originalTable).children('tbody').children('tr').children('td').length;

        var tdOldClass = '';
        var totaltd = 0;
        for (var i = 1, j = 1; i <= tds; i++, j++) {
            var tdClass = $("#" + id + "-" + j).attr('class');
            if (tdClass != tdOldClass) {
                break;
            }
            totaltd++;
        }

        if (totaltd < 10) {
            $find('mpeCustomePopup').show();
            return false;
        }
        else {
            document.getElementById('<%=lblDisplayRoomNo.ClientID %>').innerHTML = id;
            $find('mpeAssignRoom').hide();
            return true;
        }
    }
</script>
<style type="text/css">
    .hotspot
    {
        color: #900;
        padding-bottom: 1px;
        cursor: pointer;
    }
    #tt
    {
        position: absolute;
        display: block;
        background: url(../../images/tt_left.gif) top left no-repeat;
    }
    #tttop
    {
        display: block;
        height: 5px;
        margin-left: 5px;
        background: url(../../images/tt_top.gif) top right no-repeat;
        overflow: hidden;
    }
    #ttcont
    {
        display: block;
        padding: 2px 12px 3px 7px;
        margin-left: 5px;
        background: #666;
        color: Red;
        font-size: 15px;
    }
    #ttbot
    {
        display: block;
        height: 5px;
        margin-left: 5px;
        background: url(../../images/tt_bottom.gif) top right no-repeat;
        overflow: hidden;
    }
</style>
<asp:UpdatePanel ID="updCheckInList" runat="server">
    <ContentTemplate>
        <asp:MultiView ID="mvCheckInForm" runat="server">
            <asp:View ID="vCheckInList" runat="server">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="content">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="boxtopleft">
                                        &nbsp;
                                    </td>
                                    <td class="boxtopcenter">
                                        <asp:Literal ID="litCheckInMainHeader" runat="server" Text="Check-in"></asp:Literal>
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
                                            <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                <tr>
                                                    <td>
                                                        <div class="box_head">
                                                            <span>
                                                                <asp:Literal ID="litRoomReservationList" runat="server" Text="Reservations"></asp:Literal>
                                                            </span>
                                                        </div>
                                                        <div class="clear">
                                                        </div>
                                                        <div class="box_content">
                                                            <asp:GridView ID="gvRoomReservationList" runat="server" AutoGenerateColumns="false"
                                                                ShowHeader="true" Width="100%" OnRowCommand="gvRoomReservationList_RowCommand">
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
                                                                            <asp:Label ID="lblGvHdrReservationNo" runat="server" Text="Booking #"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "ReservationNo")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrStatus" runat="server" Text="Status"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "Status")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrGuestName" runat="server" Text="Name"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "GuestName")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrMobileNo" runat="server" Text="Mobile No."></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "MobileNo")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrCompany" runat="server" Text="Company"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "Company")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="125px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrRateCardType" runat="server" Text="Rate Card Type"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "RateCardType")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrUnitType" runat="server" Text="Room Type"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "RoomType")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrCheckIn" runat="server" Text="Check In"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "CheckIn")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrCheckOut" runat="server" Text="Check Out"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "CheckOut")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblActions" runat="server" Text="Action"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblPopUp" runat="server" Text="Action"></asp:Label>
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
                                                                                                        <asp:LinkButton Style="background: none !important; border: none;" ID="lnkCheckIn"
                                                                                                            runat="server" ToolTip="Check In" CommandName="CHECKIN"><img src="../../images/edit.png" /></asp:LinkButton>
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
                                                                            <asp:Label ID="lblNoRecordFound" runat="server"></asp:Label>
                                                                        </b>
                                                                    </div>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </div>
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
                            <div class="clear_divider">
                            </div>
                            <div class="clear">
                            </div>
                        </td>
                    </tr>
                </table>
            </asp:View>
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
                                        <asp:Literal ID="litCheckinReservation" runat="server" Text="Check-in Reservation"></asp:Literal>
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
                                            <div class="demo">
                                                <div id="tabs">
                                                    <ul>
                                                        <li><a href="#tabs-1" onclick="fnChangeValue('1015.00');">
                                                            <asp:Literal ID="littabAllCharges" runat="server" Text="Reservation"></asp:Literal></a></li>
                                                        <li><a href="#tabs-2" onclick="fnChangeValue('200.00');">
                                                            <asp:Literal ID="littabPaidAmount" runat="server" Text="Stay History"></asp:Literal></a></li>
                                                        <li><a href="#tabs-3" onclick="fnChangeValue('1000.00');">
                                                            <asp:Literal ID="littabRentCharge" runat="server" Text="Registration"></asp:Literal></a></li>
                                                        <li><a href="#tabs-4" onclick="fnChangeValue('1015.00');">
                                                            <asp:Literal ID="littabPayment" runat="server" Text="Payment"></asp:Literal></a></li>
                                                    </ul>
                                                    <div id="tabs-1">
                                                        <table width="100%">
                                                            <tr>
                                                                <td width="40%" style="vertical-align: top;">
                                                                    <table cellpadding="2" cellspacing="2" width="100%" border="0">
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                <b>Booking Detail</b>
                                                                                <hr />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="70px">
                                                                                Booking #
                                                                            </td>
                                                                            <td width="250px">
                                                                                <b>122324</b>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Booking Date
                                                                            </td>
                                                                            <td>
                                                                                01-08-2012
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Booked By
                                                                            </td>
                                                                            <td>
                                                                                Mr. Jayesh Rama
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Check In
                                                                            </td>
                                                                            <td>
                                                                                07-08-2012
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Check Out
                                                                            </td>
                                                                            <td>
                                                                                10-10-2012
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Adult
                                                                            </td>
                                                                            <td>
                                                                                1
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Child
                                                                            </td>
                                                                            <td>
                                                                                0
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Infant
                                                                            </td>
                                                                            <td>
                                                                                0
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Rate card
                                                                            </td>
                                                                            <td>
                                                                                3 Month
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Room Type
                                                                            </td>
                                                                            <td>
                                                                                Standard
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Room No.
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblDisplayRoomNo" runat="server"></asp:Label>
                                                                                &nbsp;&nbsp;&nbsp;<asp:LinkButton ID="lnkSelectRoom" runat="server" ForeColor="#0067b0"
                                                                                    Text="Assign Room" OnClick="lnkSelectRoom_Click"></asp:LinkButton>&nbsp;&nbsp;
                                                                                <asp:LinkButton ID="lnkNew" runat="server" ForeColor="#0067b0" Text="New" OnClick="lnkNew_Click"></asp:LinkButton>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td style="border-left: 1px solid #CCCCCC;">
                                                                </td>
                                                                <td width="60%" valign="top">
                                                                    <table cellpadding="5" cellspacing="2" width="100%" border="0">
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                <b>Guest Detail</b>
                                                                                <hr />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="isrequire">
                                                                                <asp:Literal ID="litNationality" runat="server" Text="Nationality"></asp:Literal>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlNationality" runat="server" Style="width: 224px; height: 25px;"
                                                                                    Enabled="false">
                                                                                    <asp:ListItem Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                                                    <asp:ListItem Text="Indian" Value="Indian" Selected="True"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                &nbsp;&nbsp;
                                                                                <asp:Button ID="btnEditGuestInfo" runat="server" Text="Edit" Style="display: inline;"
                                                                                    OnClick="btnEditGuestInfo_Click" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="isrequire" style="width: 80px !important;">
                                                                                <asp:Literal ID="litName" runat="server" Text="Name"></asp:Literal>
                                                                            </td>
                                                                            <td>
                                                                                <div style="float: left;">
                                                                                    <asp:DropDownList ID="ddlTitle" runat="server" Style="width: 60px; height: 25px;"
                                                                                        Enabled="false">
                                                                                        <asp:ListItem Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                                                        <asp:ListItem Text="Mr." Value="Mr." Selected="True"></asp:ListItem>
                                                                                        <asp:ListItem Text="Mrs." Value="Mrs."></asp:ListItem>
                                                                                        <asp:ListItem Text="Ms" Value="Ms"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                    <asp:TextBox ID="txtFirstName" runat="server" MaxLength="150" Enabled="false" Style="width: 135px !important;"
                                                                                        Text="Hariprasad"></asp:TextBox>
                                                                                    <ajx:TextBoxWatermarkExtender ID="txtwmeFirstName" runat="server" TargetControlID="txtFirstName"
                                                                                        WatermarkText="First Name">
                                                                                    </ajx:TextBoxWatermarkExtender>
                                                                                    <asp:TextBox ID="txtLastName" runat="server" MaxLength="150" Enabled="false" Style="width: 130px !important;"
                                                                                        Text="Rama"></asp:TextBox>
                                                                                    <ajx:TextBoxWatermarkExtender ID="txtwmeLastName" runat="server" TargetControlID="txtLastName"
                                                                                        WatermarkText="Last Name">
                                                                                    </ajx:TextBoxWatermarkExtender>
                                                                                    &nbsp;&nbsp;&nbsp;
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Literal ID="litMobile" runat="server" Text="Mobile No."></asp:Literal>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtMobile" runat="server" Enabled="false" Text="9898565623"></asp:TextBox>
                                                                                <ajx:FilteredTextBoxExtender ID="ftMobile" runat="server" TargetControlID="txtMobile"
                                                                                    ValidChars="0123456789" FilterMode="ValidChars">
                                                                                </ajx:FilteredTextBoxExtender>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Literal ID="litGuestEmail" runat="server" Text="Email"></asp:Literal>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtGuestEmail" runat="server" Enabled="false" Text="hariprasad@gmai1.com"></asp:TextBox>
                                                                                <span>
                                                                                    <asp:RegularExpressionValidator ID="revGuestEmail" Display="Dynamic" ValidationGroup="IsRequire"
                                                                                        runat="server" ErrorMessage="Please Enter Valid Email" ForeColor="Red" ControlToValidate="txtGuestEmail"
                                                                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                                                </span>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="vertical-align: top;">
                                                                                <asp:Literal ID="litAddress" runat="server" Text="Address"></asp:Literal>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtAddress" runat="server" Enabled="false" Text="30, Shri Shaishav Colony, Nr. Shiva temple,"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="vertical-align: top;">
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtAddressLine2" runat="server" Enabled="false" Text="Jalnagar road, Ahmedabad-658556"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Literal ID="litCityName" runat="server" Text="City"></asp:Literal>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtCityName" runat="server" Enabled="false" Text="Ahmedabad"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Literal ID="litZipCode" runat="server" Text="ZipCode"></asp:Literal>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtZipCode" runat="server" Enabled="false" Text="658556"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Literal ID="litStateName" runat="server" Text="State"></asp:Literal>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtStateName" runat="server" Enabled="false" Text="Gujarat"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Literal ID="litCountryName" runat="server" Text="Country"></asp:Literal>
                                                                            </td>
                                                                            <td>
                                                                                <div style="float: left;">
                                                                                    <asp:TextBox ID="txtCountryName" runat="server" Enabled="false" Text="India"></asp:TextBox>
                                                                                </div>
                                                                                <div style="float: left;">
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Pickup
                                                                            </td>
                                                                            <td style="padding: 0px;">
                                                                                <table cellpadding="0" cellspacing="0">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:RadioButtonList ID="rdbIsPicup" runat="server" Enabled="false" RepeatDirection="Horizontal"
                                                                                                RepeatColumns="2">
                                                                                                <asp:ListItem Text="Yes" Value="1" Selected="True"></asp:ListItem>
                                                                                                <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                                                            </asp:RadioButtonList>
                                                                                        </td>
                                                                                        <td style="padding-left: 5px;">
                                                                                            <asp:TextBox ID="txtSpecificInstruction" runat="server" Enabled="false" Text="Pickup from Airport at 02:30 PM"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="vertical-align: top;">
                                                                                Note
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtNote" runat="server" SkinID="nowidth" Width="334px" Enabled="false"
                                                                                    Height="35px" TextMode="MultiLine"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3">
                                                                    <div style="float: left;">
                                                                        <asp:Button ID="btnCheckInAddService" runat="server" Text="Add Service" Style="display: inline;"
                                                                            OnClick="btnCheckInAddService_Click" />
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div id="tabs-2">
                                                        <div class="box_head">
                                                            <span>
                                                                <asp:Literal ID="litStayHistoryList" runat="server" Text="Stay History List"></asp:Literal>
                                                            </span>
                                                        </div>
                                                        <div class="clear">
                                                        </div>
                                                        <div class="box_content">
                                                            <asp:GridView ID="gvGuestHistory" runat="server" AutoGenerateColumns="false" ShowHeader="true"
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
                                                                    <asp:TemplateField ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrBookingNo" runat="server" Text="Booking #"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "BookingNo")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrRoomCnf" runat="server" Text="Check In"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "CheckInDate")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrCheckInDate" runat="server" Text="Check Out"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "CheckOutDate")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrCheckOutDate" runat="server" Text="Nights"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "Nights")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="120px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrNights" runat="server" Text="Rate Card"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "RateCard")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrRateCard" runat="server" Text="Room Type"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "RoomType")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrInvoiceAmt" runat="server" Text="Room No."></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "RoomNo")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrStatus" runat="server" Text="Invoice Amt."></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "InvAmt")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <div style="padding: 10px;">
                                                                        <b>
                                                                            <asp:Label ID="lblNoRecordFound" runat="server"></asp:Label>
                                                                        </b>
                                                                    </div>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </div>
                                                        <br />
                                                        <table width="100%" border="0">
                                                            <tr>
                                                                <td width="50%" style="vertical-align: top;">
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td>
                                                                                <b>Guest Preferences</b>
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
                                                                                                    <%#DataBinder.Eval(Container.DataItem, "Preference")%>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                        <EmptyDataTemplate>
                                                                                            <div style="padding: 10px;">
                                                                                                <b>
                                                                                                    <asp:Label ID="lblNoRecordFound" runat="server"></asp:Label>
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
                                                                            <td>
                                                                                <b>Front desk Note</b>
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
                                                                                                    <%#DataBinder.Eval(Container.DataItem, "Note")%>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                        <EmptyDataTemplate>
                                                                                            <div style="padding: 10px;">
                                                                                                <b>
                                                                                                    <asp:Label ID="lblNoRecordFound" runat="server"></asp:Label>
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
                                                        <table cellpadding="5" cellspacing="2" border="0">
                                                            <tr>
                                                                <td width="140px">
                                                                    Name
                                                                </td>
                                                                <td width="250px">
                                                                    <b>Mr. Hariprasad Rama</b>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    Photo
                                                                </td>
                                                                <td>
                                                                    <asp:FileUpload ID="fuPhoto" runat="server" Height="28px" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding-top: 10px;">
                                                                    ID Document
                                                                </td>
                                                                <td style="padding-top: 10px;">
                                                                    <asp:DropDownList ID="ddlIDDoc" runat="server">
                                                                        <asp:ListItem Text="-Select-" Value="0"></asp:ListItem>
                                                                        <asp:ListItem Text="Licence" Value="1"></asp:ListItem>
                                                                        <asp:ListItem Text="Passport" Value="2"></asp:ListItem>
                                                                        <asp:ListItem Text="PAN Card" Value="3"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    ID Reference No.
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtIDRefNo" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    ID Scan copy
                                                                </td>
                                                                <td>
                                                                    <asp:FileUpload ID="fuIDScanCopy" runat="server" Height="28px" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding-top: 10px;">
                                                                    ID Document2
                                                                </td>
                                                                <td style="padding-top: 10px;">
                                                                    <asp:DropDownList ID="DropDownList1" runat="server">
                                                                        <asp:ListItem Text="-Select-" Value="0"></asp:ListItem>
                                                                        <asp:ListItem Text="Licence" Value="1"></asp:ListItem>
                                                                        <asp:ListItem Text="Passport" Value="2"></asp:ListItem>
                                                                        <asp:ListItem Text="PAN Card" Value="3"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    ID Reference No.
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    ID Scan copy
                                                                </td>
                                                                <td>
                                                                    <asp:FileUpload ID="FileUpload1" runat="server" Height="28px" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div id="tabs-4">
                                                        <table width="100%">
                                                            <tr>
                                                                <td width="40%" style="vertical-align: top;">
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
                                                                                Acco. Charges
                                                                            </td>
                                                                            <td>
                                                                                90
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
                                                                                <b>Total Amount</b>
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
                                                                <td width="60%" style="vertical-align: top;">
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                <b>Payment</b>
                                                                                <hr />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="120px">
                                                                                <b>Amount</b>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtPaymentAmount" runat="server" Text="26000.00"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <b>Mode of Payment</b>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlModeOfPayment" runat="server" OnSelectedIndexChanged="ddlModeOfPayment_OnSelectedIndexChanged"
                                                                                    AutoPostBack="true">
                                                                                    <asp:ListItem Text="-Select-" Value="0"></asp:ListItem>
                                                                                    <asp:ListItem Text="Cash" Value="1"></asp:ListItem>
                                                                                    <asp:ListItem Text="Cheque" Value="2"></asp:ListItem>
                                                                                    <asp:ListItem Text="DD" Value="3"></asp:ListItem>
                                                                                    <asp:ListItem Text="Credit Card" Value="4"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trChequeDD1" runat="server" visible="false">
                                                                            <td>
                                                                                Bank Name
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtBankName" runat="server"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trChequeDD2" runat="server" visible="false">
                                                                            <td>
                                                                                Cheque/DD No.
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtChequeDDNo" runat="server"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trCreditCard1" runat="server" visible="false">
                                                                            <td>
                                                                                Card Type
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlCardType" runat="server">
                                                                                    <asp:ListItem Text="-Select-" Value="0"></asp:ListItem>
                                                                                    <asp:ListItem Text="Visa" Value="1"></asp:ListItem>
                                                                                    <asp:ListItem Text="MasterCard" Value="2"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trCreditCard2" runat="server" visible="false">
                                                                            <td>
                                                                                Name on Card
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtNameOnCard" runat="server"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trCreditCard3" runat="server" visible="false">
                                                                            <td>
                                                                                Card Number
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtCardNumber" runat="server"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trCreditCard4" runat="server" visible="false">
                                                                            <td>
                                                                                Expiration Date
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlCardExpirationMonth" runat="server" SkinID="nowidth" Width="115px">
                                                                                    <asp:ListItem Text="-Select-" Value="0"></asp:ListItem>
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
                                                                                &nbsp;
                                                                                <asp:DropDownList ID="ddlCardExpirationYear" runat="server" SkinID="nowidth" Width="103px">
                                                                                    <asp:ListItem Text="-Select-" Value="0"></asp:ListItem>
                                                                                    <asp:ListItem Text="2012" Value="2012"></asp:ListItem>
                                                                                    <asp:ListItem Text="2013" Value="2013"></asp:ListItem>
                                                                                    <asp:ListItem Text="2014" Value="2014"></asp:ListItem>
                                                                                    <asp:ListItem Text="2015" Value="2015"></asp:ListItem>
                                                                                    <asp:ListItem Text="2016" Value="2016"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" style="padding: 0px;">
                                                                                <hr />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <b>Total Payment Received</b>
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
                                                                                <b>Amount Due</b>
                                                                            </td>
                                                                            <td>
                                                                                <b>500.00</b>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3">
                                                                    <div style="float: left;">
                                                                        <asp:Button ID="btnCheckInSave" runat="server" Text="Save" Style="display: inline;" />
                                                                        <asp:Button ID="btnCheckInCancel" runat="server" Text="Cancel" Style="display: inline;"
                                                                            OnClick="btnCheckInCancel_Click" />
                                                                        <asp:Button ID="btnCheckInReRoute" runat="server" Text="Set ReRoute" Style="display: inline;"
                                                                            OnClick="btnCheckInReRoute_Click" />
                                                                        <asp:Button ID="btnRegistratonForm" runat="server" Text="Registration Form" Style="display: inline;" />
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </div>
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
                            <div class="clear_divider">
                            </div>
                            <div class="clear">
                            </div>
                        </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="vAddService" runat="server">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="content">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="boxtopleft">
                                        &nbsp;
                                    </td>
                                    <td class="boxtopcenter">
                                        <asp:Literal ID="litAddServices" runat="server" Text="Add Services"></asp:Literal>
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
                                            <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                <tr>
                                                    <td colspan="2" width="320">
                                                        <div style="width: 180px; float: left;">
                                                            <asp:RadioButtonList ID="rdblServicePackage" AutoPostBack="true" OnSelectedIndexChanged="rdblServicePackage_SelectedIndexChanged"
                                                                runat="server" RepeatColumns="2" RepeatDirection="Horizontal">
                                                                <asp:ListItem Text="Services" Value="1" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Text="Packages" Value="2"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </div>
                                                        <div style="float: left; margin-top: 7px;">
                                                            <asp:DropDownList ID="ddlServicesAndPackages" runat="server" SkinID="nowidth" Style="width: 110px;">
                                                                <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                                <asp:ListItem Text="Tea" Value="Tea"></asp:ListItem>
                                                                <asp:ListItem Text="Coffe" Value="Coffe"></asp:ListItem>
                                                                <asp:ListItem Text="Cold Drink" Value="Cold Drink"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvServicesAndPackages" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                    ValidationGroup="AddCheckInService" ControlToValidate="ddlServicesAndPackages"
                                                                    Display="Static">
                                                                </asp:RequiredFieldValidator>
                                                            </span>
                                                        </div>
                                                    </td>
                                                    <td style="width: 50px !important;" class="isrequire">
                                                        <asp:Literal ID="litDate" runat="server" Text="Date"></asp:Literal>
                                                    </td>
                                                    <td colspan="3">
                                                        <asp:TextBox ID="txtServiceDate" runat="server" SkinID="nowidth" Style="width: 100px;"></asp:TextBox>
                                                        <asp:Image ID="imgCalServiceDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                            Height="20px" Width="20px" />
                                                        <ajx:CalendarExtender ID="calExtServiceDate" PopupButtonID="imgCalServiceDate" TargetControlID="txtServiceDate"
                                                            runat="server" Format="dd/MMM/yyyy">
                                                        </ajx:CalendarExtender>
                                                        <img src="../../images/clear.png" id="imgClrExt" style="vertical-align: middle;"
                                                            title="Clear Date" onclick="fnClearServiceDate('<%= txtServiceDate.ClientID %>');" />
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                runat="server" ValidationGroup="AddCheckInService" ControlToValidate="txtServiceDate"
                                                                Display="Static">
                                                            </asp:RequiredFieldValidator>
                                                        </span>
                                                        <asp:TextBox ID="txtServiceTime" runat="server" Style="width: 50px !important;" onkeypress="return false;"
                                                            MaxLength="5"></asp:TextBox>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rfvServiceTime" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                runat="server" ValidationGroup="AddCheckInService" ControlToValidate="txtServiceTime"
                                                                Display="Static">
                                                            </asp:RequiredFieldValidator>
                                                        </span>
                                                        <ajx:FilteredTextBoxExtender ID="ftServiceTime" runat="server" TargetControlID="txtServiceTime"
                                                            FilterType="Custom, Numbers" ValidChars=":" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="isrequire" style="width: 80px !important;">
                                                        <asp:Literal ID="litServiceFrequency" runat="server" Text="Frequency"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlServiceFrequency" runat="server" SkinID="nowidth" Style="width: 125px;">
                                                            <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                            <asp:ListItem Text="Daily" Value="Daily"></asp:ListItem>
                                                            <asp:ListItem Text="Once" Value="Daily"></asp:ListItem>
                                                            <asp:ListItem Text="Weekly" Value="Weekly"></asp:ListItem>
                                                            <asp:ListItem Text="Monthly" Value="Monthly"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rfvServiceFrequency" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                ValidationGroup="AddCheckInService" ControlToValidate="ddlServiceFrequency" Display="Dynamic">
                                                            </asp:RequiredFieldValidator>
                                                        </span>
                                                    </td>
                                                    <td style="width: 40px !important;" class="isrequire">
                                                        <asp:Literal ID="ltrQuentity" runat="server" Text="Qty"></asp:Literal>
                                                    </td>
                                                    <td class="isrequire" style="width: 90px !important;">
                                                        <asp:TextBox ID="txtQty" runat="server" Style="width: 60px;"></asp:TextBox>
                                                        <ajx:FilteredTextBoxExtender ID="fteQty" runat="server" TargetControlID="txtQty"
                                                            FilterMode="ValidChars" ValidChars="1234567890">
                                                        </ajx:FilteredTextBoxExtender>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rfvQty" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                runat="server" ValidationGroup="AddCheckInService" ControlToValidate="txtQty"
                                                                Display="Dynamic">
                                                            </asp:RequiredFieldValidator>
                                                        </span>
                                                    </td>
                                                    <td class="isrequire" style="width: 60px !important;">
                                                        <asp:Literal ID="litAmount" runat="server" Text="Amount"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <div style="float: left; padding-right: 10px;">
                                                            <asp:TextBox ID="txtAmount" runat="server" Style="width: 100px;"></asp:TextBox>
                                                            <ajx:FilteredTextBoxExtender ID="ftbAmount" runat="server" TargetControlID="txtAmount"
                                                                FilterMode="ValidChars" ValidChars="1234567890.">
                                                            </ajx:FilteredTextBoxExtender>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvAmount" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                    runat="server" ValidationGroup="AddCheckInService" ControlToValidate="txtAmount"
                                                                    Display="Static">
                                                                </asp:RequiredFieldValidator>
                                                            </span>
                                                        </div>
                                                        <div style="float: left;">
                                                            <asp:Button ID="btnCheckInAddServices" runat="server" Text="+" OnClick="btnCheckInAddServices_Click"
                                                                ValidationGroup="AddCheckInService" />
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="6" width="100%" style="height: 150px; overflow: auto;">
                                                        <div class="box_head">
                                                            <span>
                                                                <asp:Literal ID="litServiceList" runat="server" Text="Service List"></asp:Literal>
                                                            </span>
                                                        </div>
                                                        <div class="clear">
                                                        </div>
                                                        <div class="box_content">
                                                            <asp:GridView ID="gvServiceList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                Width="100%">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%# Container.DataItemIndex + 1 %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrService" runat="server" Text="Service"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "Service")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrServiceDate" runat="server" Text="Date"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "Date")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrServiceTime" runat="server" Text="Time"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "Time")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrServicesNotes" runat="server" Text="Notes"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "Notes")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrQty" runat="server" Text="Qty"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "Qty")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrAmount" runat="server" Text="Amount"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "Amount")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrServiceRate" runat="server" Text="Srv Rate"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "ServiceRate")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrTax" runat="server" Text="Tax"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "Tax")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrSrvTax" runat="server" Text="Srv Tax"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "SrvTax")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrTotal" runat="server" Text="Total"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "Total")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <div style="padding: 10px;">
                                                                        <b>
                                                                            <asp:Label ID="lblNoRecordFoundForService" runat="server" Text="No Record Found."></asp:Label>
                                                                        </b>
                                                                    </div>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="6" align="right" style="background-color: #DCDDDF; color: #0083CE; font-size: 15px;
                                                        font-weight: bold; padding: 9px;">
                                                        <asp:Literal ID="litCheckInTotalServiceRate" runat="server" Text="0.00"></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-top: 8px;" align="center" colspan="6">
                                                        <asp:Button ID="btnServiceSave" runat="server" Style="display: inline; padding-right: 10px;"
                                                            ValidationGroup="AddCheckInService" Text="Save" />
                                                        <asp:Button ID="btnServiceCancel" runat="server" Style="display: inline;" Text="Cancel"
                                                            OnClick="btnServiceCancel_Click" />
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
                            <div class="clear_divider">
                            </div>
                            <div class="clear">
                            </div>
                        </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="vBlockAndFloor" runat="server">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="content">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="boxtopleft">
                                        &nbsp;
                                    </td>
                                    <td class="boxtopcenter">
                                        <asp:Literal ID="Literal1" runat="server" Text="Assign Room"></asp:Literal>
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
                                            <asp:TreeView ID="treeviwExample" runat="server" ImageSet="Arrows" OnSelectedNodeChanged="treeviwExample_SelectedNodeChanged"
                                                OnTreeNodeCheckChanged="treeviwExample_TreeNodeCheckChanged">
                                                <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                                                <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                                                    NodeSpacing="0px" VerticalPadding="0px" />
                                                <ParentNodeStyle Font-Bold="False" />
                                                <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px"
                                                    VerticalPadding="0px" />
                                            </asp:TreeView>
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
        </asp:MultiView>
        <asp:HiddenField ID="hdnAssignRoom" runat="server" />
        <ajx:ModalPopupExtender ID="mpeAssignRoom" runat="server" TargetControlID="hdnAssignRoom"
            PopupControlID="pnlAssignRoom" BackgroundCssClass="mod_background" DropShadow="true"
            BehaviorID="mpeAssignRoom" CancelControlID="btnAssignRoomCancel">
        </ajx:ModalPopupExtender>
        <asp:Panel ID="pnlAssignRoom" runat="server" Width="1100px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="lithdrAssignRoom" runat="server" Text="Assign Room"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <div style="padding-bottom: 10px;">
                        <table width="100%" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="100px">
                                    <asp:Literal ID="litRoomType" runat="server" Text="Room Type"></asp:Literal>
                                </td>
                                <td width="450px">
                                    <asp:Literal ID="litDisplayRoomType" runat="server" Text="Standard"></asp:Literal>
                                </td>
                                <td width="100px">
                                    <asp:Literal ID="litFrequency" runat="server" Text="Frequency"></asp:Literal>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlFrequency" runat="server">
                                        <%-- <asp:DropDownList ID="ddlFrequency" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlFrequency_OnSelectedIndexChanged">--%>
                                        <asp:ListItem Selected="True" Value="Daily" Text="Daily"></asp:ListItem>
                                        <asp:ListItem Value="Weekly" Text="Weekly"></asp:ListItem>
                                        <asp:ListItem Value="Monthly" Text="Monthly"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <hr />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="border: 1px solid #fa982f; padding: 5px;">
                        <div id="divCalendar" runat="server">
                        </div>
                        <div id="divBooking" runat="server">
                        </div>
                    </div>
                    <div style="padding-top: 10px;">
                        <table width="100%" cellspacing="0" cellpadding="0">
                            <tr>
                                <td align="center">
                                    <asp:Button ID="btnAssignRoomCancel" runat="server" Text="Cancel" Style="display: inline;" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
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
                                <asp:Literal ID="litCustomePopupMsg" runat="server" Text="You Can't select this room"></asp:Literal>
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
