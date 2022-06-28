<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlCheckInListOld.ascx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation.ctrlCheckInListOld" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<link type="text/css" href="../../Styles/jquery-ui-1.8.5.custom.css" rel="stylesheet" />
<script type="text/javascript" src="../../Scripts/jquery-1.4.2.min.js"></script>
<script type="text/javascript" src="../../Scripts/jquery-ui-1.8.5.custom.min.js"></script>
<link rel="stylesheet" href="../../Styles/jquery.ui.timepicker.css" type="text/css" />
<script type="text/javascript" src="../../Scripts/jquery-ui-timepicker-addon.js"></script>
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
                                        <asp:Literal ID="litCheckInMainHeader" runat="server" Text="Check-in Reservation"></asp:Literal>
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
                                                                            <asp:Label ID="lblGvHdrUnitNo" runat="server" Text="Room No."></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "RoomNo")%>
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
                <%--<div class="box_col1">
                    <div class="box_head">
                        <span>
                            <asp:Literal ID="Literal1" runat="server" Text="Check-in Reservation"></asp:Literal></span></div>
                    <div class="clear">
                    </div>
                    <div class="box_form">--%>
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
                                            <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                <tr>
                                                    <td>
                                                        <fieldset style="border: 1px solid #ccc !important;">
                                                            <legend>
                                                                <asp:Literal ID="litReservationInformation" Text="Reservation Information" runat="server"></asp:Literal>
                                                            </legend>
                                                            <table cellpadding="2" cellspacing="2" width="100%" border="0">
                                                                <tr>
                                                                    <td width="100px">
                                                                        <asp:Literal ID="litCheckInBookingNo" runat="server" Text="Booking #"></asp:Literal>
                                                                    </td>
                                                                    <td width="230px">
                                                                        <asp:Literal ID="litDisplayCheckInBookingNo" runat="server" Text="123456"></asp:Literal>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Literal ID="ltrGuestName" runat="server" Text="Name"></asp:Literal>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Literal ID="litDispalyName" runat="server" Text="Mr.Prakash Mehta"></asp:Literal>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Literal ID="litRoomType" runat="server" Text="Room Type"></asp:Literal>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Literal ID="litDisplayRoomType" runat="server" Text="Standard"></asp:Literal>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Literal ID="litCheckInDate" runat="server" Text="Check In"></asp:Literal>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Literal ID="litDisplayCheckInDate" runat="server" Text="07-08-2012 14:00 PM"></asp:Literal>
                                                                    </td>
                                                                    <td width="100px">
                                                                        <asp:Literal ID="litCheckOutDate" runat="server" Text="Check Out"></asp:Literal>
                                                                    </td>
                                                                    <td width="230px">
                                                                        <asp:Literal ID="litDisplayCheckOutDate" runat="server" Text="09-08-2012 11:00 AM"></asp:Literal>
                                                                    </td>
                                                                    <td width="100px">
                                                                        <asp:Literal ID="litRoomNo" runat="server" Text="Room No."></asp:Literal>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Literal ID="litDisplayRoomNo" runat="server" Text="3"></asp:Literal>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <table width="100%">
                                                                            <tr>
                                                                                <td style="padding-right: 10px !important;">
                                                                                    <asp:Literal ID="litAdult" runat="server" Text="ADT"></asp:Literal>
                                                                                    &nbsp;&nbsp;&nbsp;<asp:Literal ID="litDisplayAdult" runat="server" Text="2"></asp:Literal>
                                                                                </td>
                                                                                <td style="padding-right: 10px !important;">
                                                                                    <asp:Literal ID="litChild" runat="server" Text="CHD"></asp:Literal>
                                                                                    &nbsp;&nbsp;&nbsp;<asp:Literal ID="litDisplayChild" runat="server" Text="0"></asp:Literal>
                                                                                </td>
                                                                                <td style="padding-right: 10px !important;">
                                                                                    <asp:Literal ID="litINF" runat="server" Text="INF"></asp:Literal>
                                                                                    &nbsp;&nbsp;&nbsp;<asp:Literal ID="litDisplayINF" runat="server" Text="0"></asp:Literal>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Literal ID="litCRLimit" runat="server" Text="CR Limit"></asp:Literal>
                                                                    </td>
                                                                    <td colspan="3">
                                                                        <asp:TextBox ID="txtCRLimit" runat="server" Text="1000.00" Style="text-align: right;
                                                                            width: 100px !important;"></asp:TextBox>
                                                                        <ajx:FilteredTextBoxExtender ID="ftCRLimit" runat="server" TargetControlID="txtCRLimit"
                                                                            FilterType="Custom, Numbers" ValidChars="." />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </fieldset>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="100%" style="height: 150px; overflow: auto; vertical-align: top;">
                                                        <div class="clear">
                                                        </div>
                                                        <div class="box_content">
                                                            <asp:GridView ID="gvGuestList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                Width="100%" SkinID="gvNoPaging">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrGuestSrNo" runat="server" Text="No."></asp:Label>
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
                                                                            <asp:CheckBox ID="chkSelectGuest" runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="125px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrGuestName" runat="server" Text="Name"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "GuestName")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrGuestListCheckIn" runat="server" Text="Check In"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "ArrivalDate")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="90px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrGuestListCheckOut" runat="server" Text="Check Out"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "DepatureDate")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrGuestNotes" runat="server" Text="Guest Notes"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "GuestNotes")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <div style="padding: 10px;">
                                                                        <b>
                                                                            <asp:Label ID="lblNoRecordFoundForGuest" runat="server" Text="No Record Found."></asp:Label>
                                                                        </b>
                                                                    </div>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div style="float: left;">
                                                            <asp:Button ID="btnCheckInSave" runat="server" Text="Save" Style="display: inline;" />
                                                            <asp:Button ID="btnCheckInCancel" runat="server" Text="Cancel" Style="display: inline;"
                                                                OnClick="btnCheckInCancel_Click" />
                                                            <asp:Button ID="btnCheckInAddService" runat="server" Text="Add Service" Style="display: inline;"
                                                                OnClick="btnCheckInAddService_Click" />
                                                            <asp:Button ID="btnCheckInReRoute" runat="server" Text="Set ReRoute" Style="display: inline;"
                                                                OnClick="btnCheckInReRoute_Click" />
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
        </asp:MultiView>
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
