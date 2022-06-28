<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlRoomReservationList.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation.CtrlRoomReservationList" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlAutoAssignUnit.ascx" TagName="AutoAssignUnit"
    TagPrefix="ucCtrlAutoAssignUnit" %>
<%--<%@ Register Src="~/UIControls/CommonControls/CtrlCommonExtendReservation.ascx" TagName="ExtendReservation"
    TagPrefix="ucCtrlExtendReservation" %>--%>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonQuickPost.ascx" TagName="QuickPost"
    TagPrefix="ucCtrlQuickPost" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonPayment.ascx" TagName="Payment"
    TagPrefix="ucCtrlPayment" %>
<%@ Register Src="~/UIControls/Reservation/CtrlReservationGuestMgt.ascx" TagName="ReservationGuestMgt"
    TagPrefix="ucCtrlReservationGuestMgt" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonCounterLogin.ascx" TagName="CommonCounterLogin"
    TagPrefix="ucCtrlCommonCounterLogin" %>
<script type="text/javascript" src="../../Scripts/jquery.js"></script>
<script type="text/javascript">
    function pageLoad(sender, args) {
        var v1 = '<%=ConfigurationManager.AppSettings["IsUpperCase"].ToString() %>'
        if (v1 == "1") {
            $('input[type="text"],textarea').each(function () { $(this).css("text-transform", "uppercase") });
        }
    }
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }

    function fnCheckAmendmentCriteria() {
        if (Page_ClientValidate("IsRequire")) {

            var AmendmentCriteria = document.getElementById('<%=hdnNoOfAmendmentCriteria.ClientID%>').value;

            if (AmendmentCriteria != '') {

                var isChecked = 0;

                var chkMobileNo = document.getElementById('<%=chkMobileNo.ClientID%>');
                var chkEmail = document.getElementById('<%=chkEmail.ClientID%>');
                var chkCreditCard = document.getElementById('<%=chkCreditCard.ClientID%>');
                var chkCompanyName = document.getElementById('<%=chkCompanyName.ClientID%>');

                if (chkMobileNo.checked) {
                    isChecked++;
                }

                if (chkEmail.checked) {
                    isChecked++;
                }

                if (chkCreditCard.checked) {
                    isChecked++;
                }

                if (chkCompanyName.checked) {
                    isChecked++;
                }

                if (parseInt(isChecked) >= parseInt(AmendmentCriteria)) {
                    return true;
                }
                else {
                    $find('mpeMessage').show();
                    document.getElementById('<%=lblAmendmentCriteriaMsg.ClientID %>').innerHTML = "Varification is not Complete.";
                    return false;
                }
            }
            else {
                $find('mpeMessage').show();
                document.getElementById('<%=lblAmendmentCriteriaMsg.ClientID %>').innerHTML = "Minimum Criteria for Cancel Reservation is not configured. Please Configure it";
                return false;
            }
        }
    }

</script>
<style type="text/css">
    #div1
    {
        width: 97%;
        display: none;
        border: 2px solid #EFEFEF;
        background-color: #FEFEFE;
    }
</style>
<asp:UpdatePanel ID="updRoomReservationList" runat="server">
    <ContentTemplate>
        <asp:HiddenField ID="hdnNoOfAmendmentCriteria" runat="server" />
        <%--function pageLoad(sender, args) {
        $(function () {
            $("#<%=imgbtnAdvanceSearch.ClientID%>").click(function (event) {
                event.preventDefault();
                $("#div1").slideToggle();
            });

            $("#div1 a").click(function (event) {
                event.preventDefault();
                $("#div1").slideUp();
            });
        });
    }--%>
        <asp:MultiView ID="mvRoomReservation" runat="server">
            <asp:View ID="vRoomReservationList" runat="server">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="content">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="boxtopleft">
                                        &nbsp;
                                    </td>
                                    <td class="boxtopcenter">
                                        <asp:Literal ID="litMainHeader" runat="server" Text="Reservation List"></asp:Literal>
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
                                                    <td width="50px">
                                                        <asp:Literal ID="litSearchName" runat="server" Text="Name"></asp:Literal>
                                                    </td>
                                                    <td width="170px">
                                                        <asp:TextBox ID="txtSearchName" runat="server" Style="width: 140px !important;" SkinID="searchtextbox"></asp:TextBox>
                                                    </td>
                                                    <td width="65px">
                                                        <asp:Literal ID="Literal2" runat="server" Text="Mobile No."></asp:Literal>
                                                    </td>
                                                    <td width="130px">
                                                        <asp:TextBox ID="txtMobileNo" runat="server" Style="width: 100px !important;" SkinID="searchtextbox"></asp:TextBox>
                                                    </td>
                                                    <td width="65px">
                                                        <asp:Literal ID="litSearcReservationNo" runat="server" Text="Booking #"></asp:Literal>
                                                    </td>
                                                    <td width="130px">
                                                        <asp:TextBox ID="txtSearcReservationNo" runat="server" Style="width: 100px !important;"
                                                            SkinID="searchtextbox"></asp:TextBox>
                                                        <ajx:FilteredTextBoxExtender ID="fteSearcReservationNo" runat="server" TargetControlID="txtSearcReservationNo"
                                                            FilterMode="ValidChars" ValidChars="0123456789">
                                                        </ajx:FilteredTextBoxExtender>
                                                    </td>
                                                    <td width="65px">
                                                        <asp:Literal ID="litSearchUnitNo" runat="server" Text="Room Type"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlSrchRoomType" runat="server" SkinID="nowidth" Width="170px">
                                                        </asp:DropDownList>
                                                        <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png" ToolTip="Search"
                                                            Style="border: 0px; margin: 0 0 0 5px; vertical-align: middle;" OnClick="btnSearch_Click" />
                                                        <asp:ImageButton ID="imgbtnClearSearch" runat="server" ImageUrl="~/images/clearsearch.png" ToolTip="Clear"
                                                            Style="border: 0px; vertical-align: middle; margin: 0 0 0 10px;" OnClick="imgbtnClearSearch_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <%--<td>
                                                        <asp:Literal ID="litSearchCompany" runat="server" Text="Company"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSearchCompanyName" runat="server" Style="width: 140px !important;"
                                                            SkinID="searchtextbox"></asp:TextBox>
                                                    </td>--%>
                                                    <td>
                                                        <asp:Literal ID="litSearchStatus" runat="server" Text="Status"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlSearchStatus" runat="server" Style="width: 142px;">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td colspan="4" style="padding-left: 15px">
                                                        <asp:Literal ID="litbillinginstruction" runat="server" Text="Billing instruction"></asp:Literal>
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddlbillinginstruction" runat="server"
                                                            Style="width: 165px;">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                <tr>
                                                    <td colspan="6">
                                                        <hr />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="6">
                                                        <div class="box_head">
                                                            <span>
                                                                <asp:Literal ID="litRoomReservationList" runat="server" Text="Reservation List"></asp:Literal>
                                                            </span>
                                                        </div>
                                                        <div class="clear">
                                                        </div>
                                                        <div class="box_content">
                                                            <asp:GridView ID="gvRoomReservationList" runat="server" AutoGenerateColumns="false"
                                                                ShowHeader="true" Width="100%" OnRowCommand="gvRoomReservationList_RowCommand"
                                                                OnRowDataBound="gvRoomReservationList_RowDataBound" OnPageIndexChanging="gvRoomReservationList_PageIndexChanging"
                                                                DataKeyNames="Email,CardNo,SymphonyValue,ReservationID,FolioID,GuestID">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%# Container.DataItemIndex + 1 %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="25px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                        <HeaderTemplate>
                                                                            <img runat="server" id="imgHdrGroupReservation" alt="Group Reservation" title="Group Reservation"
                                                                                style="height: 20px; width: 20px;" src="~/images/groupreservation.png" />
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Image ID="imgGroupReservation" runat="server" Style="height: 20px; width: 20px;" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrReservationNo" runat="server" Text="Booking #"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvReservationNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ReservationNo")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="40px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrStatus" runat="server" Text="Status"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Image ID="imgReservationStatus" runat="server" Style="height: 20px; width: 20px;" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrGuestName" runat="server" Text="Name"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvGuestFullName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "GuestFullName")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrMobileNo" runat="server" Text="Mobile No."></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvPhone" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrCompany" runat="server" Text="Company"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvCompanyName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CompanyName")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrRoomNo" runat="server" Text="Room No."></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvRoomNo" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="110px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrRateCardType" runat="server" Text="Rate Card Name"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvRateCardName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "RateCardName")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="110px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrUnitType" runat="server" Text="Room Type"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvRoomTypeName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "RoomTypeName")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrCheckIn" runat="server" Text="Check In"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvCheckInDate" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "CheckInDate")).ToString(clsSession.DateFormat)%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrCheckOut" runat="server" Text="Check Out"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvCheckOutDate" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "CheckOutDate")).ToString(clsSession.DateFormat)%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblActions" runat="server" Text="Action"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblPopUp" runat="server" Text="Actions"></asp:Label>
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
                                                                                                        <asp:LinkButton Style="background: none !important; border: none;" ID="lnkView" runat="server"
                                                                                                            ToolTip="View" CommandName="VIEWDATA" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ReservationID")%>'><img src="../../images/file.png" /></asp:LinkButton>
                                                                                                    </li>
                                                                                                    <li>
                                                                                                        <asp:LinkButton Style="background: none !important; border: none;" ID="lnkEdit" runat="server"
                                                                                                            ToolTip="Edit" CommandName="EDITDATA" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ReservationID")%>'><img src="../../images/file.png" /></asp:LinkButton>
                                                                                                    </li>
                                                                                                    <li>
                                                                                                        <asp:LinkButton Style="background: none !important; border: none;" ID="lnkReservationPayment"
                                                                                                            Visible="false" runat="server" ToolTip="Payment" CommandName="RESERVATIONPAYMENT"
                                                                                                            CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ReservationID")%>'><img src="../../images/file.png" /></asp:LinkButton>
                                                                                                    </li>
                                                                                                    <%--<li>
                                                                                                        <asp:LinkButton ID="LinkGuestMgt" Style="background: none !important; border: none;"
                                                                                                            runat="server" ToolTip="Guest Mgt." CommandName="GUESTMGT" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ReservationID")%>'><img src="../../images/file.png" /></asp:LinkButton></li>
                                                                                                    <li>
                                                                                                        <asp:LinkButton ID="lnkCancelReservation" Style="background: none !important; border: none;"
                                                                                                            runat="server" ToolTip="Cancel Reservation" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ReservationID")%>'><img src="../../images/file.png" /></asp:LinkButton></li>
                                                                                                    <li>
                                                                                                        <asp:LinkButton ID="lnkExtendReservation" runat="server" Style="background: none !important;
                                                                                                            border: none;" ToolTip="Amend Reservation" CommandName="AMENDRESERVATION" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ReservationID")%>'><img src="../../images/file.png" /></asp:LinkButton>
                                                                                                    </li>--%>
                                                                                                    <li>
                                                                                                        <asp:LinkButton ID="lnkAmendmentHistory" CommandName="AMENDMENT" Style="background: none !important;
                                                                                                            border: none;" runat="server" ToolTip="Amendment History" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ReservationID")%>'><img src="../../images/file.png" /></asp:LinkButton></li>
                                                                                                    <li>
                                                                                                        <asp:LinkButton ID="lnkReinstantReservation" CommandName="REINSTATE" Style="background: none !important;
                                                                                                            border: none;" runat="server" ToolTip="Reinstate Reservation" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ReservationID")%>'><img src="../../images/file.png" /></asp:LinkButton></li>
                                                                                                    <%--<li>
                                                                                                        <asp:LinkButton ID="lnkCheckOut" Style="background: none !important; border: none;"
                                                                                                            runat="server" ToolTip="Quick Post" CommandName="CHECKOUT"><img src="../../images/QuickPost32x32.png" /></asp:LinkButton></li>
                                                                                                    <li>
                                                                                                        <asp:LinkButton ID="lnkViewFolio" Style="background: none !important; border: none;"
                                                                                                            runat="server" ToolTip="View Folio" CommandName="VIEWFOLIO"><img src="../../images/file.png" /></asp:LinkButton></li>--%>
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
                                                                            <asp:Label ID="lblNoRecordFound" runat="server" Text="No record found."></asp:Label>
                                                                        </b>
                                                                    </div>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <%--<tr>
                                                    <td align="right" colspan="5" style="padding-bottom: 15px;">
                                                        <asp:Button ID="btnPrint" runat="server" Style="float: right;" Text="Print" />
                                                    </td>
                                                </tr>--%>
                                                <tr style="display: none;">
                                                    <td colspan="6" style="border: 1px solid #CCCCCC;">
                                                        <div style="float: left; width: 140px;">
                                                            <img src="../../images/Confirmed22x22.png" title="Confirmed" style="vertical-align: middle;" />&nbsp;&nbsp;
                                                            3</div>
                                                        <%--<div style="float: left; width: 140px;">
                                                    <img src="../../images/Guarented22x22.png" title="Guarented" style="vertical-align: middle;" />&nbsp;&nbsp;
                                                    4</div>--%>
                                                        <div style="float: left; width: 140px;">
                                                            <img src="../../images/UnConfirmed22x22.png" title="Provisional" style="vertical-align: middle;" />&nbsp;&nbsp;5</div>
                                                        <div style="float: left; width: 140px;">
                                                            <img src="../../images/WaitingList22x22.png" title="Waiting List" style="vertical-align: middle;" />&nbsp;&nbsp;
                                                            1</div>
                                                        <%--<div style="float: left; width: 140px;">
                                                    <img src="../../images/Cancelled22x22.png" title="Cancelled" style="vertical-align: middle;" />&nbsp;&nbsp;3</div>--%>
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
            <asp:View ID="vRoomReservationView" runat="server">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="content" style="padding-left: 0px; width: 66.66%">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="boxtopleft">
                                        &nbsp;
                                    </td>
                                    <td class="boxtopcenter">
                                        <asp:Literal ID="Literal1" runat="server" Text="ROOM RESERVATION"></asp:Literal>
                                    </td>
                                    <td class="boxtopright">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="boxleft">
                                    </td>
                                    <td>
                                        <div class="box_form">
                                            <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                <tr>
                                                    <td width="48%" style="vertical-align: top; border-right: 1px solid #ccccce;">
                                                        <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                            <tr>
                                                                <td colspan="4">
                                                                    <b>
                                                                        <asp:Literal ID="litStayInformation" runat="server" Text="Stay Information"></asp:Literal></b>
                                                                    <hr />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="95px">
                                                                    <asp:Literal ID="litCheckInDate" runat="server" Text="Check In"></asp:Literal>
                                                                </td>
                                                                <td style="width: 7px;">
                                                                    :
                                                                </td>
                                                                <td style="vertical-align: middle;" class="NumericDropdown">
                                                                    <asp:Literal ID="litDisplayCheckInDate" runat="server"></asp:Literal>
                                                                    <%--&nbsp;&nbsp;&nbsp;
                                                                    <asp:Literal ID="litFrequency" runat="server" Text="Frequency"></asp:Literal>&nbsp;&nbsp;&nbsp;:&nbsp;&nbsp;&nbsp;
                                                                    <asp:Literal ID="litDisplayFrequency" runat="server" Text="Daily"></asp:Literal>
                                                                    &nbsp;&nbsp;&nbsp;
                                                                    <asp:Literal ID="litDuretion" runat="server" Text="Duretion"></asp:Literal>&nbsp;&nbsp;&nbsp;:&nbsp;&nbsp;&nbsp;
                                                                    <asp:Literal ID="litDisplayDuretion" runat="server" Text="1"></asp:Literal>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litCheckOutDate" runat="server" Text="Check Out"></asp:Literal>
                                                                </td>
                                                                <td style="width: 7px;">
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="litDisplayCheckOutDate" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litRoomType" runat="server" Text="Room Type"></asp:Literal>
                                                                </td>
                                                                <td style="width: 7px;">
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="litDisplayRoomType" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litCompanyName" runat="server" Text="Company Name"></asp:Literal>
                                                                </td>
                                                                <td style="width: 7px;">
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="litDisplayCompanyName" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litRateCard" runat="server" Text="Rate Card"></asp:Literal>
                                                                </td>
                                                                <td style="width: 7px;">
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="litDisplayRateCard" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <%--<tr>
                                                                <td>
                                                                    <asp:Literal ID="litDiscount" runat="server" Text="Discount"></asp:Literal>
                                                                </td>
                                                                <td style="width: 7px;">
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="litDisplayDiscount" runat="server" Text="Diwali Discount"></asp:Literal>
                                                                </td>
                                                            </tr>--%>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litAdult" runat="server" Text="Adult"></asp:Literal>
                                                                </td>
                                                                <td style="width: 7px;">
                                                                    :
                                                                </td>
                                                                <td style="vertical-align: middle;" class="NumericDropdown">
                                                                    <asp:Literal ID="litDisplayAdult" runat="server"></asp:Literal>
                                                                    &nbsp;&nbsp;&nbsp;
                                                                    <asp:Literal ID="litChild" runat="server" Text="Child"></asp:Literal>&nbsp;&nbsp;&nbsp;:&nbsp;&nbsp;&nbsp;
                                                                    <asp:Literal ID="litDisplayChild" runat="server"></asp:Literal>
                                                                    &nbsp;&nbsp;&nbsp;
                                                                    <asp:Literal ID="litInf" runat="server" Text="Inf"></asp:Literal>&nbsp;&nbsp;&nbsp;:&nbsp;&nbsp;&nbsp;
                                                                    <asp:Literal ID="litDisplayInf" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litVGuestType" runat="server" Text="Guest Type"></asp:Literal>
                                                                </td>
                                                                <td style="width: 7px;">
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="litViewGuestType" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litVSourceofBusiness" runat="server" Text="Source Of Business"></asp:Literal>
                                                                </td>
                                                                <td style="width: 7px;">
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="litViewSourceofBusiness" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding-left: 0px; padding-top: 10px;" colspan="3">
                                                                    <b>Specific Instruction</b>
                                                                    <hr />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    Smoking
                                                                </td>
                                                                <td style="width: 7px;">
                                                                    :
                                                                </td>
                                                                <td style="padding: 0px;">
                                                                    <asp:Literal ID="litvIsSmoking" runat="server" Text="No"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    Pickup
                                                                </td>
                                                                <td style="width: 7px;">
                                                                    :
                                                                </td>
                                                                <td style="padding: 0px;">
                                                                    <asp:Literal ID="litDisplayPickup" runat="server" Text="No"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    Note
                                                                </td>
                                                                <td style="width: 7px;">
                                                                    :
                                                                </td>
                                                                <td style="padding: 0px;">
                                                                    <asp:Literal ID="litDisplayNote" runat="server" Text="-"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    Standard Instruction
                                                                </td>
                                                                <td style="width: 7px;">
                                                                    :
                                                                </td>
                                                                <td style="padding: 0px;">
                                                                    <asp:Literal ID="litDisplayStandardInstruction" runat="server" Text="-"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3" style="padding-top: 10px;">
                                                                    <table id="tblRateCalculation" runat="server" width="80%">
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
                                                                                <asp:Label ID="lblDisplayNoOfDays" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td align="right">
                                                                                <asp:Label ID="lblDisplayRoomRent" runat="server"></asp:Label>
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
                                                                                <asp:Label ID="lblDisplayTax" runat="server"></asp:Label>
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
                                                                                <b>
                                                                                    <asp:Label ID="lblDisplayTotalAmount" runat="server"></asp:Label></b>
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
                                                                                <asp:Label ID="lblDisplayDepositAmount" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="padding: 0px;" colspan="3">
                                                                                <hr />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <b>Total Amount Payable</b>
                                                                            </td>
                                                                            <td align="center">
                                                                                -
                                                                            </td>
                                                                            <td align="right">
                                                                                <b>
                                                                                    <asp:Label ID="lblTotalAmountPayable" runat="server"></asp:Label></b>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td style="vertical-align: top;">
                                                        <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                            <tr>
                                                                <td colspan="3">
                                                                    <b>
                                                                        <asp:Literal ID="litGuestInformation" runat="server" Text="Guest Information"></asp:Literal></b>
                                                                    <hr />
                                                                </td>
                                                            </tr>
                                                            <%--<tr>
                                                                <td>
                                                                    <asp:Literal ID="litStayType" runat="server" Text="Stay Type"></asp:Literal>
                                                                </td>
                                                                <td style="width: 7px;">
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="litDisplayStayType" runat="server" Text="Long"></asp:Literal>
                                                                </td>
                                                            </tr>--%>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litNationality" runat="server" Text="Nationality"></asp:Literal>
                                                                </td>
                                                                <td style="width: 7px;">
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="litDisplayNationality" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px !important;">
                                                                    <asp:Literal ID="litName" runat="server" Text="Name"></asp:Literal>
                                                                </td>
                                                                <td style="width: 7px;">
                                                                    :
                                                                </td>
                                                                <td style="vertical-align: middle;" class="NumericDropdown">
                                                                    <asp:Literal ID="litDisplayGuestName" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litvBookedBy" runat="server" Text="Booked By"></asp:Literal>
                                                                </td>
                                                                <td style="width: 7px;">
                                                                    :
                                                                </td>
                                                                <td style="vertical-align: middle;" class="NumericDropdown">
                                                                    <asp:Literal ID="litviewBookedBy" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litMobile" runat="server" Text="Mobile No."></asp:Literal>
                                                                </td>
                                                                <td style="width: 7px;">
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="litDisplayMobile" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litGuestEmail" runat="server" Text="Email"></asp:Literal>
                                                                </td>
                                                                <td style="width: 7px;">
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="litDisplayEmail" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="vertical-align: top;">
                                                                    <asp:Literal ID="litAddress" runat="server" Text="Address"></asp:Literal>
                                                                </td>
                                                                <td style="width: 7px;">
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="litDisplayAddress" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litCityName" runat="server" Text="City"></asp:Literal>
                                                                </td>
                                                                <td style="width: 7px;">
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="litDisplayCityName" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litZipCode" runat="server" Text="ZipCode"></asp:Literal>
                                                                </td>
                                                                <td style="width: 7px;">
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="litDisplayZipCode" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litStateName" runat="server" Text="State"></asp:Literal>
                                                                </td>
                                                                <td style="width: 7px;">
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="litDisplayStateName" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litCountryName" runat="server" Text="Country"></asp:Literal>
                                                                </td>
                                                                <td style="width: 7px;">
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="litDisplayCountryName" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <%--<tr>
                                                                <td colspan="3" style="padding-top: 10px;">
                                                                    <b>
                                                                        <asp:Literal ID="litPayment" runat="server" Text="Payment"></asp:Literal></b>
                                                                    <hr />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 90px !important;">
                                                                    <asp:Literal ID="litPMT" runat="server" Text="Payment Mode"></asp:Literal>
                                                                </td>
                                                                <td style="width: 7px;">
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="litDisplayPmt" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litStatus" runat="server" Text="Status"></asp:Literal>
                                                                </td>
                                                                <td style="width: 7px;">
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="litDisplayStatus" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>--%>
                                                            <tr>
                                                                <td colspan="3" style="padding-top: 15px;">
                                                                    <b>
                                                                        <asp:Literal ID="litvReceipt" runat="server" Text="Payment"></asp:Literal></b>
                                                                    <hr />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litvBillingInstruction" runat="server" Text="Billing Instruction"></asp:Literal>
                                                                </td>
                                                                <td style="width: 7px;">
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblViewBillingInstruction" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litvresStatus" runat="server" Text="Booking Status"></asp:Literal>
                                                                </td>
                                                                <td style="width: 7px;">
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblViewBookingStatus" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="Literal6" runat="server" Text="Total Amount"></asp:Literal>
                                                                </td>
                                                                <td style="width: 7px;">
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblDisplayAmount" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="Literal8" runat="server" Text="Total Amount Received"></asp:Literal>
                                                                </td>
                                                                <td style="width: 7px;">
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblDisplayTotalAmountReceived" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <b>
                                                                        <asp:Literal ID="ltrViewReservationBalanceAmt" runat="server"></asp:Literal></b>
                                                                </td>
                                                                <td style="width: 7px;">
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblDisplayBalanceAmountDue" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:Button ID="btnBack" runat="server" Style="float: right;" Text="Back" OnClick="btnBack_OnClick" />
                                                    </td>
                                                </tr>
                                            </table>
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
                            <div class="clear">
                            </div>
                        </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="vAmendment" runat="server">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="content" style="padding-left: 0px; width: 66.66%">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="boxtopleft">
                                        &nbsp;
                                    </td>
                                    <td class="boxtopcenter">
                                        <asp:Literal ID="litMainHeaderAmendment" runat="server" Text="Amendment History"></asp:Literal>
                                    </td>
                                    <td class="boxtopright">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="boxleft">
                                    </td>
                                    <td>
                                        <table width="100%" border="0" cellspacing="2" cellpadding="2">
                                            <tr>
                                                <td>
                                                    <asp:Literal ID="litSearchBooking" Text="Booking #" runat="server"></asp:Literal>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtSearchBooking" runat="server" Style="width: 170px;"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Literal ID="litSearchAmendmentBy" Text="Amendment By" runat="server"></asp:Literal>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtSearchAmendmentBy" runat="server" Style="width: 170px;"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Literal ID="litSearchAmendmentDate" Text="Amendment Date" runat="server"></asp:Literal>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtSearchAmendmentDate" runat="server" Style="width: 170px;"></asp:TextBox>
                                                    <asp:Image ID="imgSearchAmendmentDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                        Height="20px" Width="20px" />
                                                    <ajx:CalendarExtender ID="calCheckInDate" PopupButtonID="imgSearchAmendmentDate"
                                                        TargetControlID="txtSearchAmendmentDate" runat="server" Format="dd-MM-yyyy">
                                                    </ajx:CalendarExtender>
                                                    <img src="../../images/clear.png" id="imgAD" style="vertical-align: middle;" title="Clear Date"
                                                        onclick="fnClearDate('<%= txtSearchAmendmentDate.ClientID %>');" />
                                                    <asp:ImageButton ID="btnSearchAmendData" runat="server" ImageUrl="~/images/search-icon.png"
                                                        Style="border: 0px; margin: -4px 0 0 5px; vertical-align: middle;" OnClick="btnSearchAmendData_OnClick" />
                                                    <asp:ImageButton ID="btnrefreshAmendData" runat="server" ImageUrl="~/images/clearsearch.png"
                                                        Style="border: 0px; vertical-align: middle; margin: 0 0 0 10px;" OnClick="btnrefreshAmendData_OnClick" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <hr />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <div class="box_form">
                                                        <div class="box_head">
                                                            <span>
                                                                <asp:Literal ID="litAmendment" runat="server" Text="Amendment List"></asp:Literal>
                                                            </span>
                                                        </div>
                                                        <div class="clear">
                                                        </div>
                                                        <div class="box_content">
                                                            <asp:GridView ID="gvAmendment" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                Width="100%" OnRowCommand="gvAmendmentList_RowCommand">
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
                                                                            <asp:LinkButton ID="lnkReservationNoAmendment" runat="server" CommandName="AMENDMENT"
                                                                                Text='<%#DataBinder.Eval(Container.DataItem, "ReservationNo")%>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrGuestName" runat="server" Text="Name"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkGuestNameAmendment" runat="server" CommandName="AMENDMENT"
                                                                                Text='<%#DataBinder.Eval(Container.DataItem, "GuestFullName")%>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrRateCardType" runat="server" Text="Rate Card Name"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "RateCardName")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrUnitType" runat="server" Text="Room Type"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "RoomTypeName")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrUnitNo" runat="server" Text="Room No."></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#Convert.ToString(clsCommon.GetFormatedRoomNumber(Convert.ToString(DataBinder.Eval(Container.DataItem, "RoomNo"))))%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrCheckIn" runat="server" Text="Check In"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "CheckInDate")).ToString(clsSession.DateFormat)%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrCheckOut" runat="server" Text="Check Out"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "Checkoutdate")).ToString(clsSession.DateFormat)%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrAmendmentBy" runat="server" Text="Amend By"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "AmendmentBy")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrAmendmentDate" runat="server" Text="Amend Date"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "AmendmentDate")).ToString(clsSession.DateFormat)%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <div style="padding: 10px;">
                                                                        <b>
                                                                            <asp:Label ID="lblNoRecordFound" Text="No record found" runat="server"></asp:Label>
                                                                        </b>
                                                                    </div>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" colspan="6">
                                                    <asp:Button ID="btnCancelViewAmendment" runat="server" Text="Back" OnClick="btnCancelViewAmendment_OnClick" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td class="boxright">
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
                            <div class="clear">
                            </div>
                        </td>
                    </tr>
                </table>
            </asp:View>
        </asp:MultiView>
        <ajx:ModalPopupExtender ID="mpeConfirmDeleteNew" runat="server" TargetControlID="hdnConfirmDeleteNew"
            PopupControlID="pnlDeleteDataNew" BackgroundCssClass="mod_background" CancelControlID="btnCancelDeleteNew"
            BehaviorID="mpeConfirmDeleteNew">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnConfirmDeleteNew" runat="server" />
        <asp:Panel ID="pnlDeleteDataNew" runat="server" Width="325px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="ltrHeaderConfirmDeletePopupNew" runat="server"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td align="center" style="padding-bottom: 15px;">
                                <asp:Literal ID="ltrConfirmDeleteMsgNew" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnYesNew" runat="server" Style="display: inline; padding-right: 10px;"
                                    OnClientClick="fnDisplayCatchErrorMessage();" />
                                <asp:Button ID="btnCancelDeleteNew" runat="server" Style="display: inline;" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <ucCtrlAutoAssignUnit:AutoAssignUnit ID="CtrlAutoAssignUnit" runat="server" />
        <ucCtrlQuickPost:QuickPost ID="ctrlQuickPost" runat="server" OnbtnQuickPostCallParent_Click="btnQuickPostCallParent_Click" />
        <ucCtrlPayment:Payment ID="ctrlPayment" runat="server" />
        <ucCtrlReservationGuestMgt:ReservationGuestMgt ID="ctrlidReservationGuestMgt" runat="server"
            OnbtnReservationGuestMgtCallParent_Click="btnReservationGuestMgtCallParent_Click" />
        <%--        <ajx:ModalPopupExtender ID="mpeExtendReservation" runat="server" TargetControlID="hdnExtendReservation"
            PopupControlID="pnlExtendReservation" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnExtendReservation" runat="server" />
        <asp:Panel ID="pnlExtendReservation" runat="server" Width="780px" Style="display: none;">
            <ucCtrlExtendReservation:ExtendReservation ID="CtrlExtendReservation" runat="server"
                OnbtnExtendReservationCallParent_Click="btnExtendReservationCallParent_Click" />
        </asp:Panel>--%>
        <ajx:ModalPopupExtender ID="mpeOpenAmendment" runat="server" TargetControlID="hdnAmendment"
            PopupControlID="pnlAmendment" BackgroundCssClass="mod_background" CancelControlID="btnCancel">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnAmendment" runat="server" />
        <asp:Panel ID="pnlAmendment" runat="server" Width="750px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="Literal4" runat="server" Text="Amend Reservation"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td style="width: 140px;">
                                <asp:Literal ID="Literal5" runat="server" Text="Name"></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="litDisplayAmendmentGuestName" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="litBookingNo" runat="server" Text="Booking #"></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="litDisplayAmendmentBookingNo" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="litChangeRequestBy" runat="server" Text="Change Request By"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtChangeRequestBy" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvChangeRequestBy" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                    runat="server" ValidationGroup="IsRequire" ControlToValidate="txtChangeRequestBy"
                                    Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="litChangeRequestMode" runat="server" Text="Change Request Mode"></asp:Literal>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlChangeRequestMode" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvRoomType" InitialValue="00000000-0000-0000-0000-000000000000"
                                    SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                    ValidationGroup="IsRequire" ControlToValidate="ddlChangeRequestMode" Display="Dynamic">
                                </asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <fieldset style="border: 1px solid #ccc !important;">
                                    <legend>
                                        <asp:Literal ID="litIsVerification" runat="server" Text="Verification"></asp:Literal>
                                    </legend>
                                    <table cellpadding="2" cellspacing="2" width="100%">
                                        <tr>
                                            <td style="width: 100px;">
                                                <asp:Literal ID="litMobileNo" runat="server" Text="Mobile No."></asp:Literal>
                                            </td>
                                            <td style="width: 50px;">
                                                <asp:CheckBox ID="chkMobileNo" runat="server" />
                                            </td>
                                            <td>
                                                <asp:Literal ID="litDisplayMobileNo" runat="server"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal ID="litEmail" runat="server" Text="Email"></asp:Literal>
                                            </td>
                                            <td style="width: 50px;">
                                                <asp:CheckBox ID="chkEmail" runat="server" />
                                            </td>
                                            <td>
                                                <asp:Literal ID="litDispAmendmentEmail" runat="server"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal ID="litCreditCard" runat="server" Text="Credit Card"></asp:Literal>
                                            </td>
                                            <td style="width: 50px;">
                                                <asp:CheckBox ID="chkCreditCard" runat="server" />
                                            </td>
                                            <td>
                                                <asp:Literal ID="litDispayCreditCard" runat="server"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal ID="litCompany" runat="server" Text="Company"></asp:Literal>
                                            </td>
                                            <td style="width: 50px;">
                                                <asp:CheckBox ID="chkCompanyName" runat="server" />
                                            </td>
                                            <td>
                                                <asp:Literal ID="litDispayCompany" runat="server"></asp:Literal>
                                            </td>
                                        </tr>
                                    </table>
                                </fieldset>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Button ID="btnVerificationComplete" runat="server" Style="display: inline; padding-right: 10px;"
                                    Text="Verification Complete" ValidationGroup="IsRequire" OnClientClick="return fnCheckAmendmentCriteria();"
                                    OnClick="btnVerificationComplete_OnClick" />
                                <asp:Button ID="btnCancel" runat="server" Style="display: inline;" Text="Cancel" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpeAmendment" runat="server" TargetControlID="hdnAmendmentList"
            PopupControlID="pnlAmendmentList" BackgroundCssClass="mod_background" CancelControlID="btnCancelAmendment">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnAmendmentList" runat="server" />
        <asp:Panel ID="pnlAmendmentList" runat="server" Width="440px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="Literal3" runat="server" Text="Reservation Amendment"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td>
                                <asp:TextBox ID="txtAmendmetText" runat="server" TextMode="MultiLine" SkinID="nowidth"
                                    Width="400px" Height="120px" Text="Content of Amedment"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnCancelAmendment" runat="server" Text="OK" Style="display: inline;
                                    padding-right: 10px;" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpeMessage" runat="server" TargetControlID="hfMessage"
            PopupControlID="pnlMessage" BackgroundCssClass="mod_background" CancelControlID="btnDateMessageOK"
            BehaviorID="mpeMessage">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hfMessage" runat="server" />
        <asp:Panel ID="pnlMessage" runat="server" Width="350px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="ltrHeaderValidatemsg" runat="server" Text="Message"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td align="center" style="padding-bottom: 15px;">
                                <asp:Label ID="lblAmendmentCriteriaMsg" runat="server"></asp:Label>
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
        <ajx:ModalPopupExtender ID="mpeOpenCounter" runat="server" TargetControlID="hdnOpenCounter"
            PopupControlID="pnlOpenCounter" BackgroundCssClass="mod_background" CancelControlID="iBtnCloseCounter">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnOpenCounter" runat="server" />
        <asp:Panel ID="pnlOpenCounter" runat="server" Width="400px">
            <div class="box_col1">
                <div class="box_head">
                    <div style="display: inline;">
                        <span>
                            <asp:Literal ID="Literal20" runat="server" Text="Counter"></asp:Literal></span></div>
                    <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                        <asp:ImageButton ID="iBtnCloseCounter" runat="server" ImageUrl="~/images/closepopup.png"
                            Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;" />
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
            PopupControlID="pnlCounterErrorMessage" BackgroundCssClass="mod_background" CancelControlID="btnCounterErrorMessageOK"
            BehaviorID="mpeCounterErrorMessage">
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
                                <asp:Label ID="lblCounterErrorMessage" runat="server" Text="Please Select Counter"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnCounterErrorMessageOK" Text="OK" runat="server" Style="display: inline;
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
