<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlGroupReservationList.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation.CtrlGroupReservationList" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlAutoAssignUnit.ascx" TagName="AutoAssignUnit"
    TagPrefix="ucCtrlAutoAssignUnit" %>
<script type="text/javascript">
    function pageLoad(sender, args) {
        var v1 = '<%=ConfigurationManager.AppSettings["IsUpperCase"].ToString() %>'
        if (v1 == "1") {
            $('input[type="text"],textarea').each(function () { $(this).css("text-transform", "uppercase") });
        }
        $(function () {
            $("#tabs").tabs();
        });
    }
</script>
<script type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }
</script>
<asp:UpdatePanel ID="updGroupReservationList" runat="server">
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
                                <asp:Literal ID="litMainHeader" runat="server" Text="Group Reservation List"></asp:Literal>
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
                                            <td>
                                                <asp:Literal ID="litSearchName" runat="server" Text="Name"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtSearchName" runat="server" Style="width: 140px !important;" SkinID="searchtextbox"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Literal ID="litSearcReservationNo" runat="server" Text="Booking #"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtSearcReservationNo" runat="server" Style="width: 140px !important;"
                                                    SkinID="searchtextbox"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Literal ID="litSearchGroup" runat="server" Text="Group"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlSearchGroup" runat="server">
                                                    <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                    <asp:ListItem Value="Softqube" Text="Softqube"></asp:ListItem>
                                                    <asp:ListItem Value="Uniworld" Text="Uniworld"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal ID="litSearchDateOfReservation" runat="server" Text="Booking Date"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtSearchDateOfReservation" runat="server" Style="width: 140px !important;"
                                                    SkinID="searchtextbox" onkeypress="return false;"></asp:TextBox>
                                                <asp:Image ID="imgReseravationDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                    Height="20px" Width="20px" />
                                                <ajx:CalendarExtender ID="calReseravationDate" PopupButtonID="imgReseravationDate"
                                                    TargetControlID="txtSearchDateOfReservation" runat="server" Format="dd-MM-yyyy">
                                                </ajx:CalendarExtender>
                                                <img src="../../images/clear.png" id="imgSearchSD" style="vertical-align: middle;"
                                                    title="Clear Date" onclick="fnClearDate('<%= txtSearchDateOfReservation.ClientID %>');" />
                                            </td>
                                            <td>
                                                <asp:Literal ID="litSearchByMonth" runat="server" Text="Month"></asp:Literal>
                                            </td>
                                            <td colspan="3" style="padding-bottom: 8px;">
                                                <asp:DropDownList ID="ddlSearchByMonth" runat="server" Style="width: 142px;">
                                                    <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                    <asp:ListItem Text="January" Value="January"></asp:ListItem>
                                                    <asp:ListItem Text="February" Value="February"></asp:ListItem>
                                                    <asp:ListItem Text="March" Value="March"></asp:ListItem>
                                                    <asp:ListItem Text="April" Value="April"></asp:ListItem>
                                                    <asp:ListItem Text="May" Value="May"></asp:ListItem>
                                                    <asp:ListItem Text="June" Value="June"></asp:ListItem>
                                                    <asp:ListItem Text="July" Value="July"></asp:ListItem>
                                                    <asp:ListItem Text="August" Value="August"></asp:ListItem>
                                                    <asp:ListItem Text="September" Value="September"></asp:ListItem>
                                                    <asp:ListItem Text="Octomber" Value="Octomber"></asp:ListItem>
                                                    <asp:ListItem Text="November" Value="November"></asp:ListItem>
                                                    <asp:ListItem Text="December" Value="December"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                    Style="border: 0px; margin-left: 5px; vertical-align: middle;" ToolTip="Search" />
                                                <asp:ImageButton ID="imgbtnClearSearch" runat="server" ImageUrl="~/images/clearsearch.png"
                                                    Style="border: 0px; vertical-align: middle; margin: 0 0 0 10px;" ToolTip="Clear" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="border-top: 1px solid #CCCCCC; padding-top: 5px;" colspan="6" align="right"
                                                valign="middle">
                                                <asp:Button ID="btnAddTopGroupReservation" runat="server" Style="float: right;" OnClick="btnAddTopGroupReservation_Click"
                                                    Text="Add" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <%-- <div id="tabs">--%>
                                                <%-- <ul>
                                                        <li><a href="#tabs-1">
                                                            <asp:Literal ID="littabGroupReservationList" runat="server" Text="Group Reservation List"></asp:Literal></a></li>
                                                        <li><a href="#tabs-2">
                                                            <asp:Literal ID="littabReservationList" runat="server" Text="Reservation List"></asp:Literal></a></li>
                                                    </ul>--%>
                                                <%--<div id="tabs-1">--%>
                                                <table cellpadding="2" cellspacing="2" width="100%">
                                                    <tr>
                                                        <td>
                                                            <div class="box_head">
                                                                <span>
                                                                    <asp:Literal ID="litGroupReservationList" runat="server" Text="Group Reservation List"></asp:Literal>
                                                                </span>
                                                            </div>
                                                            <div class="clear">
                                                            </div>
                                                            <div class="box_content">
                                                                <asp:GridView ID="gvGroupReservationList" runat="server" AutoGenerateColumns="false"
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
                                                                                <asp:Label ID="lblGvHdrUnitNo" runat="server" Text="Rooms"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <%#DataBinder.Eval(Container.DataItem, "Rooms")%>
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
                                                                        <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrAction" runat="server" Text="Action"></asp:Label>
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
                                                                                                            <asp:LinkButton ID="lnkEdit" Style="background: none !important; border: none;" runat="server"
                                                                                                                ToolTip="Edit" CommandName="EDITDATA"><img src="../../images/file.png" /></asp:LinkButton>
                                                                                                        </li>
                                                                                                        <li>
                                                                                                            <asp:LinkButton ID="lnkDelete" Style="background: none !important; border: none;"
                                                                                                                runat="server" ToolTip="Delete" CommandName="CANCELDATA"><img src="../../images/delete.png" /></asp:LinkButton>
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
                                                        </td>
                                                    </tr>
                                                </table>
                                                <%-- </div>--%>
                                                <%-- <div id="tabs-2">
                                                        <table cellpadding="2" cellspacing="2" width="100%">
                                                            <tr>
                                                                <td>
                                                                    <div class="box_head">
                                                                        <span>
                                                                            <asp:Literal ID="litReservationList" runat="server" Text="Reservation List"></asp:Literal>
                                                                        </span>
                                                                    </div>
                                                                    <div class="clear">
                                                                    </div>
                                                                    <div class="box_content">
                                                                        <asp:GridView ID="gvReservationList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
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
                                                                                <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrReservationListStatus" runat="server" Text="Status"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%#DataBinder.Eval(Container.DataItem, "Status")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrReservationListReservationNo" runat="server" Text="RES No."></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%#DataBinder.Eval(Container.DataItem, "ReservationNo")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrReservationListGuestName" runat="server" Text="Guest Name"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%#DataBinder.Eval(Container.DataItem, "GuestName")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrReservationListGuestName" runat="server" Text="Unit/CNF"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%#DataBinder.Eval(Container.DataItem, "RoomConference")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrReservationListUnitType" runat="server" Text="Unit Type"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%#DataBinder.Eval(Container.DataItem, "UnitType")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrReservationListArrivalDepature" runat="server" Text="Arrival - Depature"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%#DataBinder.Eval(Container.DataItem, "Date")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrReservationListGroupName" runat="server" Text="Group"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%#DataBinder.Eval(Container.DataItem, "Group")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrReservationListGroupPayment" runat="server" Text="Payment"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%#DataBinder.Eval(Container.DataItem, "Payment")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrReservationListVIP" runat="server" Text="VIP"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%#DataBinder.Eval(Container.DataItem, "VIP")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrReservationListMessage" runat="server" Text="Message"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%#DataBinder.Eval(Container.DataItem, "Message")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrReservationListAction" runat="server" Text="Actions"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkEdit" runat="server" ToolTip="Edit" CommandName="EDITDATA"><img src="../../images/file.png" /></asp:LinkButton>
                                                                                        <asp:LinkButton ID="lnkDelete" runat="server" ToolTip="Cancel" CommandName="CANCELDATA"><img src="../../images/delete.png" /></asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                            <EmptyDataTemplate>
                                                                                <div style="padding: 10px;">
                                                                                    <b>
                                                                                        <asp:Label ID="lblNoRecordFoundForReservationList" runat="server" Text="No Record Found."></asp:Label>
                                                                                    </b>
                                                                                </div>
                                                                            </EmptyDataTemplate>
                                                                        </asp:GridView>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>--%>
                                                <%--</div>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="6" style="padding-bottom: 15px;">
                                                <%--<a href="">Print</a>--%>
                                                <asp:Button ID="btnPrint" runat="server" Style="float: right;" Text="Print" />
                                            </td>
                                            <%--<td align="right" style="padding-bottom: 15px;">
                                                <asp:LinkButton ID="lnkAutoAssignUnit" runat="server" Text="Auto Assign Unit" OnClick="lnkAutoAssignUnit_Click"></asp:LinkButton>
                                            </td>--%>
                                        </tr>
                                        <tr>
                                            <td colspan="6" style="border: 1px solid Grey">
                                                <div style="float: left; width: 140px;">
                                                    <img src="../../images/CheckIn22x22.png" title="Checked In" style="vertical-align: middle;" />&nbsp;&nbsp;
                                                    1 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                                                <div style="float: left; width: 140px;">
                                                    <img src="../../images/No-Show22x22.png" title="Checked out" style="vertical-align: middle;" />&nbsp;&nbsp;
                                                    2 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                                                <div style="float: left; width: 140px;">
                                                    <img src="../../images/Confirmed22x22.png" title="Confirmed" style="vertical-align: middle;" />&nbsp;&nbsp;
                                                    3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                                                <%--<img src="../../images/Guarented22x22.png" title="Guarented" style="vertical-align: middle;" />&nbsp;&nbsp;
                                                4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
                                                <div style="float: left; width: 140px;">
                                                    <img src="../../images/UnConfirmed22x22.png" title="Provisional" style="vertical-align: middle;" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                                                <div style="float: left; width: 140px;">
                                                    <img src="../../images/WaitingList22x22.png" title="Waiting List" style="vertical-align: middle;" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                                                <%--<img src="../../images/Cancelled22x22.png" title="Cancelled" style="vertical-align: middle;" />&nbsp;&nbsp;
                                                1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6" align="right" valign="middle">
                                                <asp:Button ID="btnAddBottomGroupReservation" runat="server" Style="float: right;"
                                                    OnClick="btnAddTopGroupReservation_Click" Text="Add" />
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
                        <%--<uc1:MsgBox ID="MessageBox" runat="server" />--%>
                    </div>
                </td>
            </tr>
        </table>
        <ucCtrlAutoAssignUnit:AutoAssignUnit ID="CtrlAutoAssignUnit" runat="server" />
    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updGroupReservationList" ID="UpdateProgressGroupReservationList"
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
