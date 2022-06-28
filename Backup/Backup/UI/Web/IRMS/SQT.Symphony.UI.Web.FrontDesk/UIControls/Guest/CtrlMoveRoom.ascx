<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlMoveRoom.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Guest.CtrlMoveRoom" %>
<asp:UpdatePanel ID="updMoveRoom" runat="server">
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
                                <asp:Literal ID="litMainHeader" runat="server" Text="Move Room"></asp:Literal>
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
                                    <table border="0" cellpadding="2" cellspacing="2" width="30%">
                                        <tr>
                                            <td>
                                                <b>
                                                    <asp:Literal ID="litReservationInfo" runat="server" Text="Reservation Info."></asp:Literal></b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: top; border: 1px solid #ccccce !important;">
                                                <table border="0" cellpadding="2" cellspacing="2">
                                                    <tr>
                                                        <td style="width: 125px;">
                                                            <asp:Literal ID="ReservationNo" runat="server" Text="Reservation No."></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="litDspReservationNo" Text="Res-10052" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litGuestName" runat="server" Text="Guest Name"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="litDspGuestName" runat="server" Text="Miss. Amee Golvadia"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litRoomType" runat="server" Text="Room Type"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="litDspRoomType" runat="server" Text="Non-Ac"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litStatus" Text="Status" runat="server"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="litDspStatus" Text="UnConfirmed" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                    <tr>
                                                        <td style="width: 125px;">
                                                            <asp:Literal ID="litCurRoomNo" runat="server" Text="Cur. Room No."></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="litDspCurRoomNo" Text="1001" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litArrivalDate" runat="server" Text="Arrival"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="litDspArrivalDate" runat="server" Text="11-11-2012"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litDepartureDate" runat="server" Text="Departure"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="litDspDepartureDate" runat="server" Text="12-12-2012"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <br />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litNewRoomNo" runat="server" Text="Room No."></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="litDspNewRoomNo" runat="server" Text="12310"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litNewArrivalDate" runat="server" Text="Arrival"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="litDspNewArrivalDate" runat="server" Text="12-11-2012"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litNewDepartureDate" runat="server" Text="Departure"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="litDspNewDepartureDate" runat="server" Text="15-12-2012"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <b>
                                                    <asp:Literal ID="litMsg" runat="server" Text="Do you want to Countinue with Move Room?"></asp:Literal>
                                                </b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <asp:Button ID="btnYes" Text="Yes" Style="display: inline; margin: 5px;" runat="server" />
                                                <asp:Button ID="btnCancel" Text="Cancel" Style="display: inline; margin: 5px;" runat="server" />
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
    </ContentTemplate>
</asp:UpdatePanel>
