<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/Site.Master"
    CodeBehind="Dashboard.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Dashboard" %>

<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonArrivalList.ascx" TagName="CtrlArrivalList"
    TagPrefix="ucArrivalList" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonDepatureList.ascx" TagName="CtrlDepatureList"
    TagPrefix="ucDepatureList" %>
<%@ Register Src="~/UIControls/Dashboard/CtrlCommonRatecardDashboard.ascx" TagName="CtrlRatecardDashboard"
    TagPrefix="ucRatecardDashboard" %>
<%@ Register Src="~/UIControls/Dashboard/CtrlRoomToSellDashboard.ascx" TagName="CtrlRoomToSellDashboard"
    TagPrefix="ucRoomToSellDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/Common.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function fnClearDate(para1) {
            document.getElementById(para1).value = '';
        }
        function fnDisplayCatchErrorMessage() {
            document.getElementById('errormessage').style.display = "block";
        }
        function fnOpenTodayArrival() {
            var hdnArrival = document.getElementById('<%= hdnArrival.ClientID %>').value;
            window.open("./Reservation/TodayArrivalPrint.aspx?ArrivalID=" + hdnArrival, "Today's Arrival", "height=600,width=800,status=1,toolbar=no,menubar=no,scrollbars=1,location=0");
        }
        function fnOpenTodayDeparture() {
            var hdnDeparture = document.getElementById('<%= hdnDeparture.ClientID %>').value;
            window.open("./Reservation/TodaysDeparturePrintt.aspx?DepartureID=" + hdnDeparture, "Today's Departure", "height=600,width=800,status=1,toolbar=no,menubar=no,scrollbars=1,location=0");
        }


        function fnClick(para1) {
            $find('mpeReservationProceed').show();
        }

        function fnCheckDate() {
            var varDateFrom = document.getElementById('<%= txtDateFrom.ClientID %>').value;
            var varDateTo = document.getElementById('<%= txtDateTo.ClientID %>').value;

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

    </script>
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
    <asp:UpdatePanel ID="updDashboard" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hdnArrival" runat="server" />
            <asp:HiddenField ID="hdnDeparture" runat="server" />
            <asp:HiddenField ID="hfDateFormat" runat="server" />
            <asp:MultiView ID="mvDashboard" runat="server">
                <asp:View ID="vDashboard" runat="server">
                    <table width="100%" border="0" cellpadding="10" cellspacing="0">
                        <tr>
                            <td width="50%" style="height: 300px !important;">
                                <table width="100%" style="border: 0px !important;" cellspacing="0" cellpadding="0"
                                    class="box">
                                    <tr>
                                        <td class="boxtopleft">
                                            &nbsp;
                                        </td>
                                        <td class="boxtopcenter">
                                            Availability Chart
                                            <%--<asp:Label ID="Label1" runat="server"></asp:Label><a href="#"><img
                                        src="../../images/box_arrow.jpg" /></a>--%>
                                        </td>
                                        <td class="boxtopright">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="boxleft">
                                            &nbsp;
                                        </td>
                                        <td style="vertical-align: top; padding-top: 10px;">
                                            <div style="height: 300px !important; overflow: auto;">
                                                <div style="min-height: 175px;">
                                                    <div class="box_head">
                                                        <span>
                                                            <asp:Literal ID="litgvhdRoomAvailability" runat="server" Text="Today’s Availability"></asp:Literal>
                                                        </span>
                                                    </div>
                                                    <div class="clear">
                                                    </div>
                                                    <div class="box_content">
                                                        <asp:GridView ID="gvRoomToSell" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                            ShowFooter="true" Width="100%" DataKeyNames="RoomTypeID" OnRowDataBound="gvRoomToSell_RowDataBound">
                                                            <Columns>
                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblGvHdrRoomType" runat="server" Text="Room Type"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <%#DataBinder.Eval(Container.DataItem, "RoomTypeName")%>
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
                                                                        <asp:Label ID="lblDispTOTAL" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Rooms")%>'></asp:Label>
                                                                        <%--<asp:LinkButton ID="lnkTotal" runat="server" ToolTip="Roome" CommandName="TOTAL"
                                                                            Text='<%#DataBinder.Eval(Container.DataItem, "Rooms")%>'></asp:LinkButton>--%>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <b>
                                                                            <asp:Label ID="lblGvFtrTotalRooms" runat="server"></asp:Label></b>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center"
                                                                    FooterStyle-HorizontalAlign="Center">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblGvHdrAVL" runat="server" Text="AVL" ToolTip="Available"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDispGvAVL" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "AvailableRooms")%>'></asp:Label>
                                                                        <%--<asp:LinkButton ID="lnkGvAVL" runat="server" CommandName="TOTAL" Text='<%#DataBinder.Eval(Container.DataItem, "AvailableRooms")%>'></asp:LinkButton>--%>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <b>
                                                                            <asp:Label ID="lblGvFtrTotalAVL" runat="server"></asp:Label></b>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center"
                                                                    FooterStyle-HorizontalAlign="Center">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblGvHdrOOS" runat="server" Text="OOS" ToolTip="Out of Service"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDispGvOOS" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "OOS")%>'></asp:Label>
                                                                        <%--<asp:LinkButton ID="lnkGvOOS" runat="server" CommandName="TOTAL" Text='<%#DataBinder.Eval(Container.DataItem, "OOS")%>'></asp:LinkButton>--%>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <b>
                                                                            <asp:Label ID="lblGvFtrOOS" runat="server"></asp:Label></b>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="20px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                                    FooterStyle-HorizontalAlign="Center">
                                                                    <HeaderTemplate>
                                                                        <img src="<%=Page.ResolveUrl("~/images/Arrival22x22.png") %>" title="Today’s Arrival"
                                                                            style="vertical-align: middle;" />
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblGvArrivalCount" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Arrival")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <b>
                                                                            <asp:Label ID="lblGvFtrTodaysArrival" runat="server"></asp:Label></b>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="20px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                                    FooterStyle-HorizontalAlign="Center">
                                                                    <HeaderTemplate>
                                                                        <img src="<%=Page.ResolveUrl("~/images/CheckIn22x22.png") %>" title="Checked In" style="vertical-align: middle;" />
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblGvCheckInCount" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CheckedIn")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <b>
                                                                            <asp:Label ID="lblGvFtrTotalCheckIn" runat="server"></asp:Label></b>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <%--<asp:TemplateField ItemStyle-Width="20px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                                    FooterStyle-HorizontalAlign="Center">
                                                                    <HeaderTemplate>
                                                                        <img src="../../images/InHouse22x22.png" title="Pending Allocation" id="imgGvHdrInHouse"
                                                                            style="vertical-align: middle;" />
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkPendingAllocation" runat="server" CommandName="TOTAL">
                                                                            <asp:Label ID="lblPendingAllocation" runat="server" Text="0"></asp:Label></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <b>
                                                                            <asp:Label ID="lblTotalPendingAllocation" runat="server" Text="0"></asp:Label></b>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>--%>
                                                                <asp:TemplateField ItemStyle-Width="20px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                                    FooterStyle-HorizontalAlign="Center">
                                                                    <HeaderTemplate>
                                                                        <%-- <img src="../../images/Departure22X22.png" title="Departure" id="imgGvHdrDepartur"
                                                                            style="vertical-align: middle;" />--%>
                                                                        <img src="<%=Page.ResolveUrl("~/images/Non-Arrival22x22.png") %>" title="Past Check in Time" style="vertical-align: middle;" />
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPastCheckinTime" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "NoShow")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <b>
                                                                            <asp:Label ID="lblGvFtrPastCheckinTime" runat="server"></asp:Label></b>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="20px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                                    FooterStyle-HorizontalAlign="Center">
                                                                    <HeaderTemplate>
                                                                        <img src="<%=Page.ResolveUrl("~/images/Departure22X22.png") %>" title="Today’s Departure" style="vertical-align: middle;" />
                                                                        <%--<img src="../../images/InHouse22x22.png" title="Pending Allocation" id="imgGvHdrInHouse"
                                                                            style="vertical-align: middle;" />--%>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDeparture" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Departure")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <b>
                                                                            <asp:Label ID="lblGvFtrDeparture" runat="server"></asp:Label></b>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="20px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                                    FooterStyle-HorizontalAlign="Center">
                                                                    <HeaderTemplate>
                                                                        <img src="<%=Page.ResolveUrl("~/images/No-Show22x22.png") %>" title="Checked out" style="vertical-align: middle;" />
                                                                        <%--<img src="../../images/Non-Arrival22x22.png" title="Non-Arrival" id="imgGvHdrNonArrival"
                                                                            style="vertical-align: middle;" />--%>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCheckedout" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CheckedOut")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <b>
                                                                            <asp:Label ID="lblGvFtrCheckedout" runat="server"></asp:Label></b>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="20px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                                    FooterStyle-HorizontalAlign="Center">
                                                                    <HeaderTemplate>
                                                                        <img src="<%=Page.ResolveUrl("~/images/No-Show22x22.png") %>" title="Past Checked out" style="vertical-align: middle;" />
                                                                        <%--<img src="../../images/Non-Arrival22x22.png" title="Non-Arrival" id="imgGvHdrNonArrival"
                                                                            style="vertical-align: middle;" />--%>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPastCheckedout" runat="server" Text="0"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <b>
                                                                            <asp:Label ID="lblGvFtrPastCheckedout" runat="server"></asp:Label></b>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EmptyDataTemplate>
                                                                <div style="padding: 10px;">
                                                                    <b>
                                                                        <asp:Label ID="lblNoRecordFoundForRoomToSell" runat="server" Text="No record found."></asp:Label>
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
                                                </div>
                                                <div>
                                                    <table width="100%">
                                                        <tr>
                                                            <td style="padding-top: 35px;">
                                                                <b>Search Availability</b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <hr />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                                    <tr>
                                                                        <td style="padding-bottom: 3px;" width="130px">
                                                                            From
                                                                        </td>
                                                                        <td style="padding-bottom: 3px;" width="130px">
                                                                            To
                                                                        </td>
                                                                        <td style="padding-bottom: 3px; width: 160px;">
                                                                            Room Type
                                                                        </td>
                                                                        <td width="80px">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="txtDateFrom" runat="server" Style="width: 80px !important;" SkinID="searchtextbox"
                                                                                onkeydown="return stopKey(event);"></asp:TextBox>
                                                                            <asp:Image ID="imgtxtDateFrom" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                                                Height="20px" Width="20px" />
                                                                            <ajx:CalendarExtender ID="caltxtDateFrom" PopupButtonID="imgtxtDateFrom" TargetControlID="txtDateFrom"
                                                                                runat="server">
                                                                            </ajx:CalendarExtender>
                                                                            <%--<img src="../../images/clear.png" id="imgclearDateFrom" style="vertical-align: middle;"
                                                                                title="Clear Date" onclick="fnClearDate('<%= txtDateFrom.ClientID %>');" />--%>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtDateTo" runat="server" Style="width: 80px !important;" SkinID="searchtextbox"
                                                                                onkeydown="return stopKey(event);"></asp:TextBox>
                                                                            <asp:Image ID="imgDateTo" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                                                Height="20px" Width="20px" />
                                                                            <ajx:CalendarExtender ID="calExtDateTo" PopupButtonID="imgDateTo" TargetControlID="txtDateTo"
                                                                                runat="server">
                                                                            </ajx:CalendarExtender>
                                                                            <%--<img src="../../images/clear.png" id="imgclearDateTo" style="vertical-align: middle;"
                                                                                title="Clear Date" onclick="fnClearDate('<%= txtDateTo.ClientID %>');" />--%>
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlRoomTypes" runat="server" SkinID="nowidth" Width="150px">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Button ID="btnSearchRoomLayout" runat="server" Text="Search" OnClick="btnSearchRoomLayout_OnClick"
                                                                                Style="display: inline;" OnClientClick="return fnCheckDate();" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
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
                            <td width="50%" style="vertical-align: top; height: 300px !important;">
                                <table width="100%" style="border: 0px !important; height: 100%; min-width: 225px;"
                                    cellspacing="0" cellpadding="0" class="box">
                                    <tr>
                                        <td class="boxtopleft">
                                            &nbsp;
                                        </td>
                                        <td class="boxtopcenter">
                                            Rate Card<a href="Reservation/RateCardList.aspx"><img src="../../images/plus_button_orange.png" /></a>
                                        </td>
                                        <td class="boxtopright">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="boxleft">
                                            &nbsp;
                                        </td>
                                        <td style="vertical-align: top; padding-top: 7px;">
                                            <div style="height: 300px !important; overflow: auto;">
                                                <ucRatecardDashboard:CtrlRatecardDashboard ID="CtrlArrivalList1" runat="server" />
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
                        <tr>
                            <td width="50%" style="height: 300px !important;">
                                <table width="100%" style="border: 0px !important; height: 100%; min-width: 225px;"
                                    cellspacing="0" cellpadding="0" class="box">
                                    <tr>
                                        <td class="boxtopleft">
                                            &nbsp;
                                        </td>
                                        <td class="boxtopcenter">
                                            Today’s Arrival
                                            <asp:Label ID="lblProspectsCount" runat="server"></asp:Label>
                                            <a href="Reservation/CheckIn.aspx" style="cursor: pointer; margin-left: 10px;">
                                                <img src="../../images/plus_button_orange.png" /></a> <a style="margin-left: 10px;">
                                                    <img src="../../images/Buttonseprator.png" style="height: 20px;" /></a>
                                            <a onclick="fnOpenTodayArrival('');" style="cursor: pointer; margin-left: 10px;">
                                                <img src="../../images/PrinterImg.png" /></a>
                                        </td>
                                        <td class="boxtopright">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="boxleft">
                                            &nbsp;
                                        </td>
                                        <td style="vertical-align: top; padding-top: 10px;">
                                            <div style="height: 200px !important; overflow: auto;">
                                                <ucArrivalList:CtrlArrivalList ID="ucCtrlArrivalList" runat="server" />
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
                            <td width="50%" style="height: 300px !important;">
                                <table width="100%" style="border: 0px !important; height: 100%; min-width: 225px;"
                                    cellspacing="0" cellpadding="0" class="box">
                                    <tr>
                                        <td class="boxtopleft">
                                            &nbsp;
                                        </td>
                                        <td class="boxtopcenter">
                                            Today’s Departure
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                            <a href="Billing/CheckOut.aspx" style="cursor: pointer; margin-left: 10px;">
                                                <img src="../../images/plus_button_orange.png" /></a> <a style="margin-left: 10px;">
                                                    <img src="../../images/Buttonseprator.png" style="height: 20px;" /></a>
                                            <a onclick="fnOpenTodayDeparture('');" style="cursor: pointer; margin-left: 10px;">
                                                <img src="../../images/PrinterImg.png" /></a>
                                        </td>
                                        <td class="boxtopright">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="boxleft">
                                            &nbsp;
                                        </td>
                                        <td style="vertical-align: top; border: 0px !important; padding-top: 10px;">
                                            <div style="height: 200px !important; overflow: auto;">
                                                <ucDepatureList:CtrlDepatureList ID="ucCtrlDepatureList" runat="server" />
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
                </asp:View>
            </asp:MultiView>
            <ajx:ModalPopupExtender ID="mpeDateMessage" runat="server" TargetControlID="hfDateMessage"
                PopupControlID="pnlDateMessage" BackgroundCssClass="mod_background" CancelControlID="btnDateMessageOK"
                BehaviorID="mpeDateMessage">
            </ajx:ModalPopupExtender>
            <asp:HiddenField ID="hfDateMessage" runat="server" />
            <asp:Panel ID="pnlDateMessage" runat="server" Width="350px" Style="display: none;">
                <div class="box_col1">
                    <div class="box_head">
                        <span>
                            <asp:Literal ID="ltrHeaderDateValidate" runat="server" Text="Message"></asp:Literal></span></div>
                    <div class="clear">
                    </div>
                    <div class="box_form">
                        <table cellpadding="2" cellspacing="2" width="100%">
                            <tr>
                                <td align="center" style="padding-bottom: 15px;">
                                    <asp:Literal ID="ltrMsgDateValidate" runat="server" Text="From Date is greater than or equal to To Date."></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Button ID="btnDateMessageOK" Text="OK" runat="server" Style="display: inline;
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
</asp:Content>
