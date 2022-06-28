<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlRoomToSellDashboard.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Dashboard.CtrlRoomToSellDashboard" %>
<div class="box_head">
    <span>
        <asp:Literal ID="litgvhdRoomAvailability" runat="server" Text="Today’s Availabilityss"></asp:Literal>
    </span>
</div>
<div class="clear">
</div>
<div class="box_content">
    <asp:GridView ID="gvRoomToSell" runat="server" AutoGenerateColumns="false" ShowHeader="true"
        ShowFooter="true" Width="100%" OnRowCommand="gvRoomToSell_RowCommand">
        <Columns>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                <HeaderTemplate>
                    <asp:Label ID="lblGvHdrRoomType" runat="server" Text="Room Type"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <%#DataBinder.Eval(Container.DataItem, "RoomType")%>
                </ItemTemplate>
                <FooterTemplate>
                    <b>Total :</b>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center"
                FooterStyle-HorizontalAlign="Center">
                <HeaderTemplate>
                    <asp:Label ID="lblGvHdrTOTAL" runat="server" Text="Total"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <%--<asp:LinkButton ID="lnkTotal" runat="server" ToolTip="Roome" CommandName="TOTAL"
                        Text='<%#DataBinder.Eval(Container.DataItem, "TOTAL")%>'></asp:LinkButton>--%>
                    <%#DataBinder.Eval(Container.DataItem, "TOTAL")%>
                </ItemTemplate>
                <FooterTemplate>
                    <b>
                        <asp:Label ID="lblTotalTotal" runat="server" Text="18"></asp:Label></b>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center"
                FooterStyle-HorizontalAlign="Center">
                <HeaderTemplate>
                    <asp:Label ID="lblGvHdrAVL" runat="server" Text="AVL" ToolTip="Available"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <%--<asp:LinkButton ID="lnkAVL" runat="server" CommandName="TOTAL" Text='<%#DataBinder.Eval(Container.DataItem, "AVL")%>'></asp:LinkButton>--%>
                    <%#DataBinder.Eval(Container.DataItem, "AVL")%>
                </ItemTemplate>
                <FooterTemplate>
                    <b>
                        <asp:Label ID="lblTotalAVL" runat="server" Text="7"></asp:Label></b>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center"
                FooterStyle-HorizontalAlign="Center">
                <HeaderTemplate>
                    <asp:Label ID="lblGvHdrBLK" runat="server" Text="OOS" ToolTip="Out of Service"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <%--<asp:LinkButton ID="lnkBLK" runat="server" CommandName="TOTAL" Text='<%#DataBinder.Eval(Container.DataItem, "BLK")%>'></asp:LinkButton>--%>
                    <%#DataBinder.Eval(Container.DataItem, "BLK")%>
                </ItemTemplate>
                <FooterTemplate>
                    <b>
                        <asp:Label ID="lblTotalBLK" runat="server" Text="2"></asp:Label></b>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="20px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                FooterStyle-HorizontalAlign="Center">
                <HeaderTemplate>
                    <img src="../../images/Arrival22x22.png" title="Today’s Arrival" id="imgGvHdrArrival" alt=""
                        style="vertical-align: middle;" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkArrivalCount" runat="server" CommandName="TOTAL">
                        <asp:Label ID="lblArrivalCount" runat="server" Text="0"></asp:Label></asp:LinkButton>
                </ItemTemplate>
                <FooterTemplate>
                    <b>
                        <asp:Label ID="lblTotalArrival" runat="server" Text="0"></asp:Label></b>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="20px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                FooterStyle-HorizontalAlign="Center">
                <HeaderTemplate>
                    <img src="../../images/CheckIn22x22.png" title="Checked In" id="imgGvHdrCheckIn"
                        style="vertical-align: middle;" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkCheckInCount" runat="server" CommandName="TOTAL">
                        <asp:Label ID="lblCheckInCount" runat="server" Text="0"></asp:Label></asp:LinkButton>
                </ItemTemplate>
                <FooterTemplate>
                    <b>
                        <asp:Label ID="lblTotalCheckIn" runat="server" Text="0"></asp:Label></b>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="20px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                FooterStyle-HorizontalAlign="Center">
                <HeaderTemplate>
                    <img src="../../images/No-Show22x22.png" title="Checked out" id="imgGvHdrCheckedOut"
                        style="vertical-align: middle;" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkCheckedOutCount" runat="server" CommandName="TOTAL">
                        <asp:Label ID="lblCheckedOutCount" runat="server" Text="0"></asp:Label></asp:LinkButton>
                </ItemTemplate>
                <FooterTemplate>
                    <b>
                        <asp:Label ID="lblTotalCheckedOut" runat="server" Text="0"></asp:Label></b>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="20px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                FooterStyle-HorizontalAlign="Center">
                <HeaderTemplate>
                    <img src="../../images/Departure22X22.png" title="Departure" id="imgGvHdrDepartur"
                        style="vertical-align: middle;" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkDepartureCount" runat="server" CommandName="TOTAL">
                        <asp:Label ID="lblDepartureCount" runat="server" Text="0"></asp:Label></asp:LinkButton>
                </ItemTemplate>
                <FooterTemplate>
                    <b>
                        <asp:Label ID="lblTotalDeparture" runat="server" Text="0"></asp:Label></b>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="20px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                FooterStyle-HorizontalAlign="Center">
                <HeaderTemplate>
                    <img src="../../images/InHouse22x22.png" title="Pending Allocation" id="imgGvHdrInHouse"
                        style="vertical-align: middle;" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkInHouseCount" runat="server" CommandName="TOTAL">
                        <asp:Label ID="lblInHouseCount" runat="server" Text="0"></asp:Label></asp:LinkButton>
                </ItemTemplate>
                <FooterTemplate>
                    <b>
                        <asp:Label ID="lblTotalInHouse" runat="server" Text="0"></asp:Label></b>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="20px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                FooterStyle-HorizontalAlign="Center">
                <HeaderTemplate>
                    <img src="../../images/Non-Arrival22x22.png" title="Non-Arrival" id="imgGvHdrNonArrival"
                        style="vertical-align: middle;" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkNonArrivalCount" runat="server" CommandName="TOTAL">
                        <asp:Label ID="lblNonArrivalCount" runat="server" Text="0"></asp:Label></asp:LinkButton>
                </ItemTemplate>
                <FooterTemplate>
                    <b>
                        <asp:Label ID="lblTotalNoArrival" runat="server" Text="0"></asp:Label></b>
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <div style="padding: 10px;">
                <b>
                    <asp:Label ID="lblNoRecordFoundForRoomToSell" runat="server"></asp:Label>
                </b>
            </div>
        </EmptyDataTemplate>
    </asp:GridView>
    <br />
    <%--<b>Booking Chart</b><br /><hr />--%>
    <div class="box_head">
        <span>
            <asp:Literal ID="litBookingChart" runat="server" Text="Booking Charttt"></asp:Literal>
        </span>
    </div>
    <asp:GridView ID="gvBookingChart" runat="server" AutoGenerateColumns="false" ShowHeader="true"
        ShowFooter="true" Width="100%" OnRowCommand="gvBookingChart_RowCommand">
        <Columns>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                <HeaderTemplate>
                    <asp:Label ID="lblGvHdrRoomType" runat="server" Text="Room Type"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <%#DataBinder.Eval(Container.DataItem, "RoomType")%>
                </ItemTemplate>
                <FooterTemplate>
                    <b>Total :</b>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center"
                FooterStyle-HorizontalAlign="Center">
                <HeaderTemplate>
                    <asp:Label ID="lblGvHdrTOTAL" runat="server" Text="Total"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkTotal" runat="server" ToolTip="Roome Booking" CommandName="TOTAL"
                        Text='<%#DataBinder.Eval(Container.DataItem, "TOTAL")%>'></asp:LinkButton>
                    <%-- <%#DataBinder.Eval(Container.DataItem, "TOTAL")%>--%>
                </ItemTemplate>
                <FooterTemplate>
                    <b>
                        <asp:Label ID="lblTotalTotal" runat="server" Text="18"></asp:Label></b>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center"
                FooterStyle-HorizontalAlign="Center">
                <HeaderTemplate>
                    <asp:Label ID="lblGvHdrAVL" runat="server" Text="AVL" ToolTip="Available"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkAVL" runat="server" CommandName="TOTAL" Text='<%#DataBinder.Eval(Container.DataItem, "AVL")%>'></asp:LinkButton>
                    <%-- <%#DataBinder.Eval(Container.DataItem, "AVL")%>--%>
                </ItemTemplate>
                <FooterTemplate>
                    <b>
                        <asp:Label ID="lblTotalAVL" runat="server" Text="7"></asp:Label></b>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center"
                FooterStyle-HorizontalAlign="Center">
                <HeaderTemplate>
                    <asp:Label ID="lblGvHdrBLK" runat="server" Text="OOS" ToolTip="Out of Service"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkBLK" runat="server" CommandName="TOTAL" ToolTip="Roome Booking"
                        Text='<%#DataBinder.Eval(Container.DataItem, "BLK")%>'></asp:LinkButton>
                    <%-- <%#DataBinder.Eval(Container.DataItem, "BLK")%>--%>
                </ItemTemplate>
                <FooterTemplate>
                    <b>
                        <asp:Label ID="lblTotalBLK" runat="server" Text="2"></asp:Label></b>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="30px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                FooterStyle-HorizontalAlign="Center">
                <HeaderTemplate>
                    <img src="../../images/Confirmed22x22.png" title="Confirmed" id="imgGvHdrConfirmed"
                        style="vertical-align: middle;" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkConfirmedCount" runat="server" CommandName="TOTAL">
                        <asp:Label ID="lblConfirmedCount" runat="server" Text="0"></asp:Label></asp:LinkButton>
                </ItemTemplate>
                <FooterTemplate>
                    <b>
                        <asp:Label ID="lblTotalConfirmed" runat="server" Text="0"></asp:Label></b>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="30px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                FooterStyle-HorizontalAlign="Center">
                <HeaderTemplate>
                    <img src="../../images/UnConfirmed22x22.png" title="Provisional" id="imgGvHdrProvisional"
                        style="vertical-align: middle;" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkProvisionalCount" runat="server" CommandName="TOTAL">
                        <asp:Label ID="lblProvisionalCount" runat="server" Text="0"></asp:Label></asp:LinkButton>
                </ItemTemplate>
                <FooterTemplate>
                    <b>
                        <asp:Label ID="lblTotalProvisional" runat="server" Text="0"></asp:Label></b>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="30px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                FooterStyle-HorizontalAlign="Center">
                <HeaderTemplate>
                    <img src="../../images/WaitingList22x22.png" title="Waiting List" id="imgGvHdrWaitingList"
                        style="vertical-align: middle;" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkWaitingListCount" runat="server" CommandName="TOTAL">
                        <asp:Label ID="lblWaitingListCount" runat="server" Text="0"></asp:Label></asp:LinkButton>
                </ItemTemplate>
                <FooterTemplate>
                    <b>
                        <asp:Label ID="lblTotalWaitingList" runat="server" Text="0"></asp:Label></b>
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <div style="padding: 10px;">
                <b>
                    <asp:Label ID="lblNoRecordFoundForRoomToSell" runat="server"></asp:Label>
                </b>
            </div>
        </EmptyDataTemplate>
    </asp:GridView>
</div>
<ajx:ModalPopupExtender ID="mpeRoomDetail" runat="server" TargetControlID="hdnRoomDetail"
    PopupControlID="pnlRoomDetail" CancelControlID="imgCancelRoomDetail" BackgroundCssClass="mod_background">
</ajx:ModalPopupExtender>
<asp:HiddenField ID="hdnRoomDetail" runat="server" />
<asp:Panel ID="pnlRoomDetail" runat="server" Width="800px" Style="display: none;">
    <div class="box_col1">
        <div class="box_head">
            <div style="display: inline;">
                <span>
                    <asp:Literal ID="litMainHeader" runat="server" Text="Room Details"></asp:Literal>
                </span>
            </div>
            <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                <asp:ImageButton ID="imgCancelRoomDetail" runat="server" ImageUrl="~/images/closepopup.png"
                    Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;" />
            </div>
        </div>
        <div class="clear">
        </div>
        <div class="box_form">
            <table border="0" cellpadding="2" cellspacing="2" width="100%">
                <tr>
                    <td>
                        <div class="clear">
                        </div>
                        <div class="box_content">
                            <asp:GridView ID="gvRoomDetail" runat="server" AutoGenerateColumns="false" ShowHeader="true"
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
                                            <asp:Label ID="lblGvHdrRoomNo" runat="server" Text="Room No."></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "RoomNo")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblGvHdrRoomType" runat="server" Text="Room Type"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "RoomType")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblGvHdrGuestName" runat="server" Text="Guest Name"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "GuestName")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblGvHdrBlockName" runat="server" Text="Block Name"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "BlockName")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblGvHdrFloor" runat="server" Text="Floor"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "Floor")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <div style="padding: 10px;">
                                        <b>
                                            <asp:Label ID="lblNoRecordFound" runat="server" Text="No Record Found"></asp:Label>
                                        </b>
                                    </div>
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Panel>
<ajx:ModalPopupExtender ID="mpeBookingDetail" runat="server" TargetControlID="hdnBookingDetail"
    PopupControlID="pnlBookingDetail" CancelControlID="imgCancelBooking" BackgroundCssClass="mod_background">
</ajx:ModalPopupExtender>
<asp:HiddenField ID="hdnBookingDetail" runat="server" />
<asp:Panel ID="pnlBookingDetail" runat="server" Width="800px" Style="display: none;">
    <div class="box_col1">
        <div class="box_head">
            <div style="display: inline;">
                <span>
                    <asp:Literal ID="litRoomDetails" runat="server" Text="Room Booking Details"></asp:Literal>
                </span>
            </div>
            <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                <asp:ImageButton ID="imgCancelBooking" runat="server" ImageUrl="~/images/closepopup.png"
                    Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;" />
            </div>
        </div>
        <div class="clear">
        </div>
        <div class="box_form">
            <table border="0" cellpadding="2" cellspacing="2" width="100%">
                <tr>
                    <td>
                        <div class="clear">
                        </div>
                        <div class="box_content">
                            <asp:GridView ID="gvRoomBookingDetail" runat="server" AutoGenerateColumns="false"
                                ShowHeader="true" Width="100%">
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
                                            <asp:Label ID="lblGvHdrRoomNo" runat="server" Text="Room No."></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "RoomNo")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblGvHdrRoomType" runat="server" Text="Room Type"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "RoomType")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblGvHdrGuestName" runat="server" Text="Guest Name"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "GuestName")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblGvHdrBlockName" runat="server" Text="Block Name"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "BlockName")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblGvHdrFloor" runat="server" Text="Floor"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "Floor")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <div style="padding: 10px;">
                                        <b>
                                            <asp:Label ID="lblNoRecordFound" runat="server" Text="No Record Found"></asp:Label>
                                        </b>
                                    </div>
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Panel>
