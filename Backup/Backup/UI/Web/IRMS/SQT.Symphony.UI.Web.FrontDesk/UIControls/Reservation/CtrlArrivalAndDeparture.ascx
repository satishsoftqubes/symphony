<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlArrivalAndDeparture.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation.CtrlArrivalAndDeparture" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonExtendReservation.ascx" TagName="ExtendReservation"
    TagPrefix="ucCtrlExtendReservation" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonCheckIn.ascx" TagName="CheckIn"
    TagPrefix="ucCtrlCheckIn" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlAutoAssignUnit.ascx" TagName="AutoAssignUnit"
    TagPrefix="ucCtrlAutoAssignUnit" %>
<%@ Register Src="~/UIControls/Reservation/CtrlReservationGuestMgt.ascx" TagName="ReservationGuestMgt"
    TagPrefix="ucCtrlReservationGuestMgt" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript">
    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<asp:UpdatePanel ID="updArrivalAndDeparture" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="content">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                <asp:Literal ID="litMainHeader" runat="server" Text="Arrival And Departure"></asp:Literal>
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
                                    <asp:MultiView ID="mvArrivalAndDeparture" runat="server">
                                        <asp:View ID="vArrivalAndDeparture" runat="server">
                                            <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                <tr>
                                                    <td colspan="2" align="center">
                                                        <asp:TextBox ID="txtSearchArrivalDate" runat="server" Style="width: 140px !important;"
                                                            SkinID="searchtextbox" onkeypress="return false;"></asp:TextBox>
                                                        <asp:Image ID="imgArrivalDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                            Height="20px" Width="20px" />
                                                        <ajx:CalendarExtender ID="calArrivalDate" PopupButtonID="imgArrivalDate" TargetControlID="txtSearchArrivalDate"
                                                            runat="server" Format="dd/MMM/yyyy">
                                                        </ajx:CalendarExtender>
                                                        <img src="../../images/clear.png" id="img1" style="vertical-align: middle;" title="Clear Date"
                                                            onclick="fnClearDate('<%= txtSearchArrivalDate.ClientID %>');" />
                                                        <asp:ImageButton ID="imgBtnSearchDate" runat="server" ImageUrl="~/images/search-icon.png"
                                                            Style="border: 0px; vertical-align: middle; margin: -4px 0 0 10px;" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <hr />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: top; border-right: 1px solid #ccccce;">
                                                        <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                            <tr>
                                                                <td>
                                                                    <b>
                                                                        <asp:Literal ID="litCheckIn" runat="server" Text="Check In [28 / 56]"></asp:Literal></b>
                                                                </td>
                                                                <td>
                                                                    <b>
                                                                        <asp:Literal ID="litArrivalSearchName" runat="server" Text="Last Name"></asp:Literal></b>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtArrivalSearchName" Style="width: 150px;" runat="server"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <b>
                                                                        <asp:Literal ID="litArrivalRM" runat="server" Text="RM #"></asp:Literal></b>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtArrivalRM" Style="width: 45px;" runat="server"></asp:TextBox>
                                                                    <asp:ImageButton ID="btnSearchArrival" runat="server" ImageUrl="~/images/search-icon.png"
                                                                        Style="border: 0px; margin-left: 5px; margin-top: -4px; vertical-align: middle;" />
                                                                    <asp:ImageButton ID="imgbtnClearSearchArrival" runat="server" ImageUrl="~/images/clearsearch.png"
                                                                        Style="border: 0px; vertical-align: middle; margin: 0 0 0 10px;" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="5" style="vertical-align:top;">
                                                                    <div class="box_head">
                                                                        <span>
                                                                            <asp:Literal ID="litgvhdArrivalList" runat="server" Text="Check In List"></asp:Literal>
                                                                        </span>
                                                                    </div>
                                                                    <div class="clear">
                                                                    </div>
                                                                    <div class="box_content">
                                                                        <asp:GridView ID="gvArrival" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                            Width="100%" OnRowCommand="gvArrival_RowCommand">
                                                                            <Columns>
                                                                                <asp:TemplateField ItemStyle-Width="20px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrArrivalSrNo" runat="server" Text="No."></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%# Container.DataItemIndex + 1 %>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrArrivalResNo" runat="server" Text="Booking #"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%#DataBinder.Eval(Container.DataItem, "ResNo")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="20px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrArrivalStatus" Text="Status" runat="server"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <img src="../../images/CheckIn22x22.png" title="Check In" style="vertical-align: middle;" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrArrivalGuest" runat="server" Text="Name"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%#DataBinder.Eval(Container.DataItem, "Guest")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrRoomType" runat="server" Text="Room Type"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%#DataBinder.Eval(Container.DataItem, "Type")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrRatecard" runat="server" Text="Ratecard"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%#DataBinder.Eval(Container.DataItem, "Ratecard")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="40px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrPickup" runat="server" Text="Pickup"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%#DataBinder.Eval(Container.DataItem, "Pickup")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <%--<asp:TemplateField ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrArrivalRoom" runat="server" Text="Room No."></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%#DataBinder.Eval(Container.DataItem, "Room")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>--%>
                                                                                <asp:TemplateField ItemStyle-Width="30px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrActions" Text="Action" runat="server"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblArrivalPopUp" runat="server" Text="Action"></asp:Label>
                                                                                        <ajx:HoverMenuExtender ID="hmeArrival" runat="server" TargetControlID="lblArrivalPopUp"
                                                                                            PopupControlID="pnlArrival" PopupPosition="Left">
                                                                                        </ajx:HoverMenuExtender>
                                                                                        <asp:Panel ID="pnlArrival" runat="server" Style="visibility: hidden; opacity: 100%">
                                                                                            <div class="actionsbuttons_hovermenu">
                                                                                                <table border="0" cellpadding="0" cellspacing="0" class="actionsbuttons_hover_lettmenu_table">
                                                                                                    <tr>
                                                                                                        <td class="actionsbuttons_hover_lettmenu">
                                                                                                        </td>
                                                                                                        <td class="actionsbuttons_hover_centermenu">
                                                                                                            <ul>
                                                                                                                <li>
                                                                                                                    <asp:LinkButton ID="lnkEdit" Style="background: none !important; border: none;" runat="server"
                                                                                                                        ToolTip="Edit" CommandName="EDITDATA"><img src="../../images/file.png" /></asp:LinkButton>
                                                                                                                </li>
                                                                                                                <li>
                                                                                                                    <asp:LinkButton ID="lnkCheckIn" Style="background: none !important; border: none;"
                                                                                                                        runat="server" ToolTip="Check In" CommandName="CHECKIN"><img src="../../images/file.png" /></asp:LinkButton>
                                                                                                                </li>
                                                                                                                <li>
                                                                                                                    <asp:LinkButton ID="lnkCANCEL" Style="background: none !important; border: none;"
                                                                                                                        runat="server" ToolTip="Cancel" CommandName="CANCEL"><img src="../../images/file.png" /></asp:LinkButton>
                                                                                                                </li>
                                                                                                                <li>
                                                                                                                    <asp:LinkButton ID="lnkSigninSheet" Style="background: none !important; border: none;"
                                                                                                                        runat="server" ToolTip="Signin Sheet"><img src="../../images/file.png" /></asp:LinkButton>
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
                                                                                        <asp:Label ID="lblNoRecordFoundForRoomReservation" runat="server" Text="No Record Found."></asp:Label>
                                                                                    </b>
                                                                                </div>
                                                                            </EmptyDataTemplate>
                                                                        </asp:GridView>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="5">
                                                                    <a href="#">
                                                                        <img src="../../images/Print32x32.png" title="Print" /></a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td>
                                                        <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                            <tr>
                                                                <td>
                                                                    <b>
                                                                        <asp:Literal ID="litCheckOut" runat="server" Text="Check Out [0 / 0]"></asp:Literal></b>
                                                                </td>
                                                                <td>
                                                                    <b>
                                                                        <asp:Literal ID="litDepartureSearchName" runat="server" Text="Last Name"></asp:Literal></b>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtDepartureSearchName" Style="width: 150px;" runat="server"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <b>
                                                                        <asp:Literal ID="litDepartureRM" runat="server" Text="RM #"></asp:Literal></b>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtDepartureRM" Style="width: 45px;" runat="server"></asp:TextBox>
                                                                    <asp:ImageButton ID="btnSearchDeparture" runat="server" ImageUrl="~/images/search-icon.png"
                                                                        Style="border: 0px; margin-left: 5px; margin-top: -4px; vertical-align: middle;" />
                                                                    <asp:ImageButton ID="imgbtnClearSearchDeparture" runat="server" ImageUrl="~/images/clearsearch.png"
                                                                        Style="border: 0px; vertical-align: middle; margin: 0 0 0 10px;" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="5" style="vertical-align:top;">
                                                                    <div class="box_head">
                                                                        <span>
                                                                            <asp:Literal ID="litgvhdCheckOutList" runat="server" Text="Check Out List"></asp:Literal>
                                                                        </span>
                                                                    </div>
                                                                    <div class="clear">
                                                                    </div>
                                                                    <div class="box_content">
                                                                        <asp:GridView ID="gvDeparture" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                            Width="100%" OnRowCommand="gvDeparture_RowCommand">
                                                                            <Columns>
                                                                                <asp:TemplateField ItemStyle-Width="20px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrDepartureSrNo" runat="server" Text="No."></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%# Container.DataItemIndex + 1 %>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrDepartureResNo" runat="server" Text="Booking #"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%#DataBinder.Eval(Container.DataItem, "ResNo")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrDepartureGuest" runat="server" Text="Name"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%#DataBinder.Eval(Container.DataItem, "Guest")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrRoomType" runat="server" Text="Room Type"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%#DataBinder.Eval(Container.DataItem, "Type")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrDepartureRoom" runat="server" Text="Room No."></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%#DataBinder.Eval(Container.DataItem, "Room")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="55px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrDeparturePayment" runat="server" Text="Balance"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%#DataBinder.Eval(Container.DataItem, "Payment")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrDepartureDrop" runat="server" Text="Drop"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%#DataBinder.Eval(Container.DataItem, "Drop")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="30px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrAction" runat="server" Text="Action"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblArrivalPopUp" runat="server" Text="Action"></asp:Label>
                                                                                        <ajx:HoverMenuExtender ID="hmeArrival" runat="server" TargetControlID="lblArrivalPopUp"
                                                                                            PopupControlID="pnlArrival" PopupPosition="Left">
                                                                                        </ajx:HoverMenuExtender>
                                                                                        <asp:Panel ID="pnlArrival" runat="server" Style="visibility: hidden; opacity: 100%">
                                                                                            <div class="actionsbuttons_hovermenu">
                                                                                                <table border="0" cellpadding="0" cellspacing="0" class="actionsbuttons_hover_lettmenu_table">
                                                                                                    <tr>
                                                                                                        <td class="actionsbuttons_hover_lettmenu">
                                                                                                        </td>
                                                                                                        <td class="actionsbuttons_hover_centermenu">
                                                                                                            <ul>
                                                                                                                <li>
                                                                                                                    <asp:LinkButton ID="lnkEdit" Style="background: none !important; border: none;" runat="server"
                                                                                                                        ToolTip="Edit" CommandName="EDITDATA"><img src="../../images/file.png" title="Edit" /></asp:LinkButton>
                                                                                                                </li>
                                                                                                                <li>
                                                                                                                    <asp:LinkButton ID="lnkViewFolio" Style="background: none !important; border: none;"
                                                                                                                        runat="server" ToolTip="Check In" CommandName="VIEWFOLIO"><img src="../../images/file.png" title="View Folio" /></asp:LinkButton>
                                                                                                                </li>
                                                                                                                <li>
                                                                                                                    <asp:LinkButton ID="lnkGuestMgt" Style="background: none !important; border: none;"
                                                                                                                        runat="server" ToolTip="Guest Mgt." CommandName="GUESTMGT"><img src="../../images/file.png" /></asp:LinkButton>
                                                                                                                </li>
                                                                                                                <li>
                                                                                                                    <asp:LinkButton ID="lnkCheckOut" Style="background: none !important; border: none;"
                                                                                                                        runat="server" ToolTip="Check Out" CommandName="CHECKOUT"><img src="../../images/file.png" /></asp:LinkButton>
                                                                                                                </li>
                                                                                                                <li>
                                                                                                                    <asp:LinkButton ID="lnkExtendReservation" Style="background: none !important; border: none;"
                                                                                                                        runat="server" ToolTip="Extend" CommandName="EXTENDRESERVATION"><img src="../../images/file.png" /></asp:LinkButton></li>
                                                                                                                <li>
                                                                                                                    <asp:LinkButton ID="lnkPrintInvoice" Style="background: none !important; border: none;"
                                                                                                                        runat="server" ToolTip="Print Invoice" CommandName="PIRNTINVOICE"><img src="../../images/Print32x32.png" /></asp:LinkButton>
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
                                                                                        <asp:Label ID="lblNoRecordFoundForRoomReservation" runat="server" Text="No Record Found."></asp:Label>
                                                                                    </b>
                                                                                </div>
                                                                            </EmptyDataTemplate>
                                                                        </asp:GridView>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="5">
                                                                    <a href="#">
                                                                        <img src="../../images/Print32x32.png" title="Print" /></a>
                                                                    <%-- <div style="float: left; padding-right: 10px;">
                                                                        <asp:Button ID="btnFolio" runat="server" Text="Folio" /></div>
                                                                    <div style="float: left; padding-right: 10px;">
                                                                        <asp:Button ID="btnCheckOut" runat="server" Text="Check Out" /></div>
                                                                    <div style="float: left; padding-right: 10px;">
                                                                        <asp:Button ID="btnExtendReservation" runat="server" Text="Extend Reservation" OnClick="btnExtendReservation_Click" /></div>
                                                                    <div style="color: Red">
                                                                        <asp:Literal ID="litGroCheckOut" Text="GroupCheckOut" runat="server"></asp:Literal>
                                                                        <asp:Literal ID="litInvoice" Text="Invoice" runat="server"></asp:Literal>
                                                                        <asp:Literal ID="litInvoiceAll" Text="InvoiceAll" runat="server"></asp:Literal></div>--%>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                    </asp:MultiView>
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
        <ajx:ModalPopupExtender ID="mpeCheckIn" runat="server" TargetControlID="hdnCheckIn"
            PopupControlID="pnlCheckIn" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnCheckIn" runat="server" />
        <asp:Panel ID="pnlCheckIn" runat="server" Width="800px" Style="display: none;">
            <ucCtrlCheckIn:CheckIn ID="ctrlCommonCheckIn" runat="server" OnbtnCheckInCallParent_Click="btnCheckInCallParent_Click" />
        </asp:Panel>
        <ucCtrlAutoAssignUnit:AutoAssignUnit ID="CtrlAutoAssignUnit" runat="server" />
        <ucCtrlReservationGuestMgt:ReservationGuestMgt ID="ctrlidReservationGuestMgt" runat="server"
            OnbtnReservationGuestMgtCallParent_Click="btnReservationGuestMgtCallParent_Click" />
        <ajx:ModalPopupExtender ID="mpeExtendReservation" runat="server" TargetControlID="hdnExtendReservation"
            PopupControlID="pnlExtendReservation" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnExtendReservation" runat="server" />
        <asp:Panel ID="pnlExtendReservation" runat="server" Width="780px" Style="display: none;">
            <ucCtrlExtendReservation:ExtendReservation ID="CtrlCommonExtendReservation" runat="server"
                OnbtnExtendReservationCallParent_Click="btnExtendReservationCallParent_Click" />
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updArrivalAndDeparture" ID="UpdateProgressArrivalAndDeparture"
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
