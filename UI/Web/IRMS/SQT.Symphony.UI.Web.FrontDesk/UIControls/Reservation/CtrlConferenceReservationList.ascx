<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlConferenceReservationList.ascx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation.CtrlConferenceReservationList" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlAutoAssignUnit.ascx" TagName="AutoAssignUnit"
    TagPrefix="ucCtrlAutoAssignUnit" %>
<script type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }
</script>
<asp:UpdatePanel ID="updRoomReservationList" runat="server">
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
                                <asp:Literal ID="litMainHeader" runat="server" Text="Conference Reservation List"></asp:Literal>
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
                                            <th>
                                                <asp:Literal ID="litSearchName" runat="server" Text="Name"></asp:Literal>
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtSearchName" runat="server" Style="width: 140px !important;" SkinID="searchtextbox"></asp:TextBox>
                                            </td>
                                            <th>
                                                <asp:Literal ID="litSearcReservationNo" runat="server" Text="RES No."></asp:Literal>
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtSearcReservationNo" runat="server" Style="width: 140px !important;"
                                                    SkinID="searchtextbox"></asp:TextBox>
                                            </td>
                                            <th>
                                                <asp:Literal ID="litSearchUnitNo" runat="server" Text="Room No."></asp:Literal>
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtSearchUnitNo" runat="server" Style="width: 140px !important;"
                                                    SkinID="searchtextbox"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                <asp:Literal ID="litSearchDateOfReservation" runat="server" Text="RES Date"></asp:Literal>
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtSearchDateOfReservation" runat="server" Style="width: 140px !important;"
                                                    SkinID="searchtextbox"></asp:TextBox>
                                                <asp:Image ID="imgReseravationDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                    Height="20px" Width="20px" />
                                                <ajx:CalendarExtender ID="calReseravationDate" PopupButtonID="imgReseravationDate"
                                                    TargetControlID="txtSearchDateOfReservation" runat="server" Format="dd/MMM/yyyy">
                                                </ajx:CalendarExtender>
                                                <img src="../../images/clear.png" id="imgSearchSD" style="vertical-align: middle;"
                                                    title="Clear Date" onclick="fnClearDate('<%= txtSearchDateOfReservation.ClientID %>');" />
                                            </td>
                                            <th>
                                                <asp:Literal ID="litSearchByMonth" runat="server" Text="Month"></asp:Literal>
                                            </th>
                                            <td>
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
                                            </td>
                                            <th>
                                                <asp:Literal ID="litSearchCorporate" runat="server" Text="Corporate"></asp:Literal>
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtSearchCorporate" runat="server" Style="width: 140px !important;"
                                                    SkinID="searchtextbox"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                <asp:Literal ID="litSearchArrivalDate" runat="server" Text="Arrival"></asp:Literal>
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtSearchArrivalDate" runat="server" Style="width: 140px !important;"
                                                    SkinID="searchtextbox"></asp:TextBox>
                                                <asp:Image ID="imgArrivalDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                    Height="20px" Width="20px" />
                                                <ajx:CalendarExtender ID="calArrivalDate" PopupButtonID="imgArrivalDate" TargetControlID="txtSearchArrivalDate"
                                                    runat="server" Format="dd/MMM/yyyy">
                                                </ajx:CalendarExtender>
                                                <img src="../../images/clear.png" id="img1" style="vertical-align: middle;" title="Clear Date"
                                                    onclick="fnClearDate('<%= txtSearchArrivalDate.ClientID %>');" />
                                            </td>
                                            <th>
                                                <asp:Literal ID="litSearchDepatureDate" runat="server" Text="Depature"></asp:Literal>
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtSearchDepatureDate" runat="server" Style="width: 140px !important;"
                                                    SkinID="searchtextbox"></asp:TextBox>
                                                <asp:Image ID="imgDepatureDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                    Height="20px" Width="20px" />
                                                <ajx:CalendarExtender ID="calDepatureDate" PopupButtonID="imgDepatureDate" TargetControlID="txtSearchDepatureDate"
                                                    runat="server" Format="dd/MMM/yyyy">
                                                </ajx:CalendarExtender>
                                                <img src="../../images/clear.png" id="img2" style="vertical-align: middle;" title="Clear Date"
                                                    onclick="fnClearDate('<%= txtSearchDepatureDate.ClientID %>');" />
                                            </td>
                                            <th>
                                                <asp:Literal ID="txtSearchStatus" runat="server" Text="Status"></asp:Literal>
                                            </th>
                                            <td>
                                                <asp:DropDownList ID="ddlSearchStatus" runat="server" Style="width: 142px;">
                                                    <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                    <asp:ListItem Text="Check In" Value="Check In"></asp:ListItem>
                                                    <asp:ListItem Text="Check Out" Value="Check Out"></asp:ListItem>
                                                    <asp:ListItem Text="Confirmed" Value="Confirmed"></asp:ListItem>
                                                    <asp:ListItem Text="Guaranteed" Value="Guaranteed"></asp:ListItem>
                                                    <asp:ListItem Text="In House" Value="In House"></asp:ListItem>
                                                    <asp:ListItem Text="No Show" Value="No Show"></asp:ListItem>
                                                    <asp:ListItem Text="Non Arrival" Value="Non Arrival"></asp:ListItem>
                                                    <asp:ListItem Text="Unconfirmed" Value="Unconfirmed"></asp:ListItem>
                                                    <asp:ListItem Text="Waiting List" Value="Waiting List"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                    Style="border: 0px; margin-left: 5px; vertical-align: middle;" />
                                                <asp:ImageButton ID="imgbtnClearSearch" runat="server" ImageUrl="~/images/clearsearch.png"
                                                    Style="border: 0px; vertical-align: middle; margin: 0 0 0 10px;" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                <asp:Literal ID="litSearchRoomType" runat="server" Text="Room Type"></asp:Literal>
                                            </th>
                                            <td >
                                                <asp:DropDownList ID="ddlSearchRoomType" runat="server" Style="width: 142px;">
                                                    <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                    <asp:ListItem Text="Delux" Value="Delux"></asp:ListItem>
                                                    <asp:ListItem Text="Family" Value="Family"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <th>
                                                <asp:Literal ID="ltrConferences" runat="server" Text="Conferences"></asp:Literal>
                                            </th>
                                            <td colspan="3">
                                                <asp:DropDownList ID="ddlConferences" runat="server" Style="width: 142px;">
                                                    <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                    <asp:ListItem Text="Breed Conference" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Byfross Conf." Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="Natak Conference" Value="3"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6" align="right" valign="middle">
                                                <asp:Button ID="btnAddTopRoomReservation" runat="server" Style="float: right;" OnClick="btnAddTopRoomReservation_Click"
                                                    Text="Add" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <div class="box_head">
                                                    <span>
                                                        <asp:Literal ID="litRoomReservationList" runat="server" Text="Room Reservation List"></asp:Literal>
                                                    </span>
                                                </div>
                                                <div class="clear">
                                                </div>
                                                <div class="box_content">
                                                    <asp:GridView ID="gvRoomReservationList" runat="server" AutoGenerateColumns="false"
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
                                                            <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrStatus" runat="server" Text="Status"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "Status")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrReservationNo" runat="server" Text="RES No."></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "ReservationNo")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrGuestName" runat="server" Text="Guest Name"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "GuestName")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrChildAdult" runat="server" Text="Child/Adult"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "Child")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrUnitNo" runat="server" Text="Room No."></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "RoomNo")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrUnitType" runat="server" Text="Unit Type"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "RoomType")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrArrivalDepature" runat="server" Text="Arrival - Depature"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "Date")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrPayment" runat="server" Text="Payment"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "Payment")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrVIP" runat="server" Text="VIP"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "VIP")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrLaundry" runat="server" Text="Laundry"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "Laundry")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrAction" runat="server" Text="Actions"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkEdit" runat="server" ToolTip="Edit" CommandName="EDITDATA"><img src="../../images/file.png" /></asp:LinkButton>
                                                                    <asp:LinkButton ID="lnkDelete" runat="server" ToolTip="Delete" CommandName="DELETEDATA"><img src="../../images/delete.png" /></asp:LinkButton>
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
                                        <tr>
                                            <td align="center" colspan="5" style="padding-bottom:15px;">
                                                <a href="">Print</a>
                                            </td>
                                            <td align="right" style="padding-bottom:15px;">                                                
                                                <asp:LinkButton ID="lnkAutoAssignRoom" runat="server" OnClick="lnkAutoAssignRoom_Click">Auto Assign Room</asp:LinkButton>
                                            </td>
                                            
                                        </tr>
                                        
                                        <tr>
                                            <td colspan="6" style="border: 1px solid Grey">
                                                <img src="../../images/CheckIn22x22.png" title="Check In" style="vertical-align:middle;" />&nbsp;&nbsp; 1 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <img src="../../images/CheckOut22x22.png" title="CheckOut" style="vertical-align:middle;" />&nbsp;&nbsp; 2 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <img src="../../images/Confirmed22x22.png" title="Confirmed" style="vertical-align:middle;" />&nbsp;&nbsp; 3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <img src="../../images/Guarented22x22.png" title="Guarented" style="vertical-align:middle;" />&nbsp;&nbsp; 4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <img src="../../images/UnConfirmed22x22.png" title="UnConfirmed" style="vertical-align:middle;" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <img src="../../images/waitinglist_small.gif" title="Waiting" style="vertical-align:middle;" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <img src="../../images/Cancelled22x22.png" title="Cancelled" style="vertical-align:middle;" />&nbsp;&nbsp; 1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6" align="right" valign="middle">
                                                <asp:Button ID="btnAddBottomRoomReservation" runat="server" Style="float: right;"
                                                    OnClick="btnAddTopRoomReservation_Click" Text="Add" />
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
        <ajx:ModalPopupExtender ID="mpeConfirmDelete" runat="server" TargetControlID="hdnConfirmDelete"
            PopupControlID="pnlDeleteData" BackgroundCssClass="mod_background" CancelControlID="btnCancelDelete"
            BehaviorID="mpeConfirmDelete">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnConfirmDelete" runat="server" />
        <asp:Panel ID="pnlDeleteData" runat="server" Width="325px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="ltrHeaderConfirmDeletePopup" runat="server"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td align="center" style="padding-bottom: 15px;">
                                <asp:Literal ID="ltrConfirmDeleteMsg" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnYes" runat="server" Style="display: inline; padding-right: 10px;"
                                    OnClientClick="fnDisplayCatchErrorMessage();" />
                                <asp:Button ID="btnCancelDelete" runat="server" Style="display: inline;" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <ucCtrlAutoAssignUnit:AutoAssignUnit ID="CtrlAutoAssignUnit" runat="server" />
    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updRoomReservationList" ID="UpdateProgressRoomReservationList"
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
