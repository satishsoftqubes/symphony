<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlRoomsToSell.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation.CtrlRoomsToSell" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>

<script type="text/javascript" language="javascript">
    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>

<asp:UpdatePanel ID="updAvailabilityByType" runat="server">
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
                                <asp:Literal ID="litMainHeader" runat="server" Text="Availability By Type"></asp:Literal>
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
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td colspan="3">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td width="50px">
                                                            <asp:Literal ID="litSearchFromDate" runat="server" Text="From"></asp:Literal>
                                                        </td>
                                                        <td width="230px">
                                                            <asp:TextBox ID="txtSearchFromDate" runat="server" Style="width: 140px !important;"
                                                                SkinID="searchtextbox" onkeypress="return false;"></asp:TextBox>
                                                            <asp:Image ID="imgSearchFromDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                                Height="20px" Width="20px" />
                                                            <ajx:CalendarExtender ID="calSearchFromDate" PopupButtonID="imgSearchFromDate" TargetControlID="txtSearchFromDate"
                                                                runat="server" Format="dd/MMM/yyyy">
                                                            </ajx:CalendarExtender>
                                                            <%--<img src="../../images/clear.png" id="imgClearArrival" style="vertical-align: middle;"
                                                                title="Clear Date" onclick="fnClearDate('<%= txtArrivalDate.ClientID %>');" />--%>
                                                        </td>
                                                        <td width="40px">
                                                            <asp:Literal ID="litSearchToDate" runat="server" Text="To"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtSearchToDate" runat="server" Style="width: 140px !important;"
                                                                SkinID="searchtextbox" onkeypress="return false;"></asp:TextBox>
                                                            <asp:Image ID="imgSearchToDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                                Height="20px" Width="20px" />
                                                            <ajx:CalendarExtender ID="calSearchToDate" PopupButtonID="imgSearchToDate" TargetControlID="txtSearchToDate"
                                                                runat="server" Format="dd/MMM/yyyy">
                                                            </ajx:CalendarExtender>
                                                            <img src="../../images/clear.png" id="imgClearDeparture" style="vertical-align: middle;"
                                                                title="Clear Date" onclick="fnClearDate('<%= txtSearchToDate.ClientID %>');" />
                                                            <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                                Style="border: 0px; margin-left: 5px; vertical-align: middle;" />
                                                            <asp:ImageButton ID="imgbtnClearSearch" runat="server" ImageUrl="~/images/clearsearch.png"
                                                                Style="border: 0px; vertical-align: middle; margin: 0 0 0 10px;" />
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
                                        <tr>
                                            <td colspan="3">
                                                <div class="box_head">
                                                    <span>
                                                        <asp:Literal ID="litRoomTypeList" runat="server" Text="Room To Sell List"></asp:Literal>
                                                    </span>
                                                </div>
                                                <div class="clear">
                                                </div>
                                                <div class="box_content">
                                                    <asp:GridView ID="gvRoomToSell" runat="server" ShowFooter="true" AutoGenerateColumns="false"
                                                        ShowHeader="true" Width="100%">
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
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
                                                            <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrTotal" runat="server" Text="Total"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "Total")%>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <b>
                                                                        <asp:Label ID="lblTotalTotal" runat="server" Text="18"></asp:Label></b>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrAVL" runat="server" Text="AVL" ToolTip="Available"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "AVL")%>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <b>
                                                                        <asp:Label ID="lblTotalAVL" runat="server" Text="7"></asp:Label></b>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <%--<asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrENQ" runat="server" Text="ENQ"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "ENQ")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                                                            <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrBLK" runat="server" Text="OOS" ToolTip="Out of Service"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "OOS")%>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <b>
                                                                        <asp:Label ID="lblTotalBLK" runat="server" Text="2"></asp:Label></b>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderTemplate>
                                                                    <img src="../../images/Arrival22x22.png" title="Today's Arrival" id="imgGvHdrArrival"
                                                                        style="vertical-align: middle;" />
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblArrivalCount" runat="server" Text="0"></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <b>
                                                                        <asp:Label ID="lblTotalArrival" runat="server" Text="0"></asp:Label></b>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderTemplate>
                                                                    <img src="../../images/Departure22X22.png" title="Today's Departure" id="imgGvHdrDepartur"
                                                                        style="vertical-align: middle;" />
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDepartureCount" runat="server" Text="0"></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <b>
                                                                        <asp:Label ID="lblTotalDeparture" runat="server" Text="0"></asp:Label></b>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderTemplate>
                                                                    <img src="../../images/CheckIn22x22.png" title="Checked In" id="imgGvHdrCheckIn"
                                                                        style="vertical-align: middle;" />
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCheckInCount" runat="server" Text="0"></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <b>
                                                                        <asp:Label ID="lblTotalCheckIn" runat="server" Text="0"></asp:Label></b>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderTemplate>
                                                                    <img src="../../images/No-Show22x22.png" title="Checked out" id="imgGvHdrNoShow"
                                                                        style="vertical-align: middle;" />
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblNoShowCount" runat="server" Text="0"></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <b>
                                                                        <asp:Label ID="lblTotalCheckedOut" runat="server" Text="0"></asp:Label></b>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <%--<asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderTemplate>
                                                                    <img src="../../images/Guarented22x22.png" title="Guarented" id="imgGvHdrGuarented"
                                                                        style="vertical-align: middle;" />
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGuarentedCount" runat="server" Text="0"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                                                            <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderTemplate>
                                                                    <img src="../../images/UnConfirmed22x22.png" title="Provisional" id="imgGvHdrUnConfirmed"
                                                                        style="vertical-align: middle;" />
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblUnConfirmedCount" runat="server" Text="0"></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <b>
                                                                        <asp:Label ID="lblTotalUnConfirmedCount" runat="server" Text="0"></asp:Label></b>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderTemplate>
                                                                    <img src="../../images/InHouse22x22.png" title="Pending Allocation" id="imgGvHdrInHouse"
                                                                        style="vertical-align: middle;" />
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblInHouseCount" runat="server" Text="0"></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <b>
                                                                        <asp:Label ID="lblTotalInHouse" runat="server" Text="0"></asp:Label></b>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderTemplate>
                                                                    <img src="../../images/Non-Arrival22x22.png" title="Non-Arrival" id="imgGvHdrNonArrival"
                                                                        style="vertical-align: middle;" />
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblNonArrivalCount" runat="server" Text="0"></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <b>
                                                                        <asp:Label ID="lblTotalNoArrival" runat="server" Text="0"></asp:Label></b>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderTemplate>
                                                                    <img src="../../images/Confirmed22x22.png" title="Confirmed" id="imgGvHdrConfirmed"
                                                                        style="vertical-align: middle;" />
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblConfirmedCount" runat="server" Text="0"></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <b>
                                                                        <asp:Label ID="lblTotalConfirmedCount" runat="server" Text="0"></asp:Label></b>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderTemplate>
                                                                    <img src="../../images/WaitingList22x22.png" title="Waiting List" id="imgGvHdrWaitingList"
                                                                        style="vertical-align: middle;" />
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblWaitingListCount" runat="server" Text="0"></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <b>
                                                                        <asp:Label ID="lblTotalWaitingListCount" runat="server" Text="0"></asp:Label></b>
                                                                </FooterTemplate>
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
                                        <%--<tr>
                                            <td colspan="3" style="font-weight: bold; font-size: 13px; border: 1px solid #ccccce;">
                                                <div>
                                                    <img src="../../images/Vacant22x22.png" title="Vacant" id="imgVacant" style="vertical-align: middle;" />&nbsp;
                                                    <asp:Literal ID="litVacantCount" runat="server" Text="0"></asp:Literal>
                                                </div>
                                                
                                                <div style="margin-top: -21px; margin-left: 180px;">
                                                    <img src="../../images/Blocked22x22.png" title="Blocked" id="imgBlocked" style="vertical-align: middle;" />&nbsp;
                                                    <asp:Literal ID="litBlockedCount" runat="server" Text="0"></asp:Literal>
                                                </div>
                                            </td>
                                        </tr>--%>
                                        <%--<tr>
                                            <td colspan="3">
                                               
                                            </td>
                                        </tr>--%>
                                        <%--<tr>
                                            <td colspan="3" style="font-weight: bold; font-size: 13px; border: 1px solid #ccccce;">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td>
                                                            <img src="../../images/Arrival22x22.png" title="Today’s Arrival" id="img1" style="vertical-align: middle;" />&nbsp;
                                                            <asp:Literal ID="LitArrivalCount" runat="server" Text="0"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <img src="../../images/CheckIn22x22.png" title="Checked In" id="img1CheckIn" style="vertical-align: middle;" />&nbsp;
                                                            <asp:Literal ID="litChechInCount" runat="server" Text="0"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <img src="../../images/No-Show22x22.png" title="Checked out" id="imgNoShow" style="vertical-align: middle;" />&nbsp;
                                                            <asp:Literal ID="litNoShowCount" runat="server" Text="0"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            
                                                            <img src="../../images/WaitingList22x22.png" id="imgWaitingList" title="Waiting List"
                                                                style="vertical-align: middle;" />&nbsp;
                                                            <asp:Literal ID="litWaitingListCount" runat="server" Text="0"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <img src="../../images/UnConfirmed22x22.png" title="Provisional" id="imgUnConfirmed"
                                                                style="vertical-align: middle;" />&nbsp;
                                                            <asp:Literal ID="litUnConfirmedCount" runat="server" Text="0"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 196px;">
                                                            <img src="../../images/Departure22X22.png" title="Departure" id="img2" style="vertical-align: middle;" />&nbsp;
                                                            <asp:Literal ID="litDeparturcount" runat="server" Text="0"></asp:Literal>
                                                        </td>
                                                        <td style="width: 196px;">
                                                            <img src="../../images/InHouse22x22.png" id="imgInHouse" title="Pending Allocation"
                                                                style="vertical-align: middle;" />&nbsp;
                                                            <asp:Literal ID="litInHouseCount" runat="server" Text="0"></asp:Literal>
                                                        </td>
                                                        <td style="width: 196px;">
                                                            <img src="../../images/Non-Arrival22x22.png" id="imgNonArrival" title="Non-Arrival"
                                                                style="vertical-align: middle;" />&nbsp;
                                                            <asp:Literal ID="litNonArrivalCount" runat="server" Text="0"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <img src="../../images/Confirmed22x22.png" id="imgConfirmed" title="Confirmed" style="vertical-align: middle;" />&nbsp;
                                                            <asp:Literal ID="litConfirmedCount" runat="server" Text="0"></asp:Literal>
                                                        </td>
                                                        <td>
                                                          
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>--%>
                                        <%--<tr>
                                            <td colspan="3">
                                                <a id="aReservationStatus" href="">
                                                    <asp:Literal ID="LitReservationStatus" Text="Reservation Status" runat="server"></asp:Literal></a>
                                            </td>
                                        </tr>--%>
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
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
