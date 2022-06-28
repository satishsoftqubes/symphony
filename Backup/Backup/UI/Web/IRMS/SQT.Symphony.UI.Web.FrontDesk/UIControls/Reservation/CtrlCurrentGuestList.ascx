<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCurrentGuestList.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation.CtrlCurrentGuestList" %>
<%--<%@ Register Src="~/UIControls/CommonControls/CtrlCommonQuickPost.ascx" TagName="QuickPost"
    TagPrefix="ucCtrlQuickPost" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonPayment.ascx" TagName="Payment"
    TagPrefix="ucCtrlPayment" %>--%>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonCounterLogin.ascx" TagName="CommonCounterLogin"
    TagPrefix="ucCtrlCommonCounterLogin" %>
<script type="text/javascript" src="../../Scripts/jquery-1.4.2.min.js"></script>
<script type="text/javascript" src="../../Scripts/jquery-ui-1.8.5.custom.min.js"></script>
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
</script>
<script type="text/javascript">
    function fnGuestListPrint() {
        window.open("GuestListPrint.aspx", "Check in Guest List", "height=600,width=1000,status=1,toolbar=no,menubar=no,scrollbars=1,location=0");
    }
</script>
<asp:UpdatePanel ID="updGuestList" runat="server">
    <ContentTemplate>
        <asp:MultiView ID="mvGuestList" runat="server">
            <asp:View ID="vGuestList" runat="server">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="content">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="boxtopleft">
                                        &nbsp;
                                    </td>
                                    <td class="boxtopcenter">
                                        <asp:Literal ID="litMainHeader" runat="server" Text="Guest List"></asp:Literal>
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
                                                                <td width="170px">
                                                                    <asp:TextBox ID="txtSearchMobileNo" runat="server" Style="width: 140px !important;"
                                                                        SkinID="searchtextbox"></asp:TextBox>
                                                                </td>
                                                                <td width="65px">
                                                                    <asp:Literal ID="litSearcReservationNo" runat="server" Text="Booking #"></asp:Literal>
                                                                </td>
                                                                <td width="170px">
                                                                    <asp:TextBox ID="txtSearcReservationNo" runat="server" Style="width: 140px !important;"
                                                                        SkinID="searchtextbox"></asp:TextBox>
                                                                    <ajx:FilteredTextBoxExtender ID="fteSearcReservationNo" runat="server" TargetControlID="txtSearcReservationNo"
                                                                        FilterMode="ValidChars" ValidChars="0123456789">
                                                                    </ajx:FilteredTextBoxExtender>
                                                                </td>
                                                                <td width="65px">
                                                                    <asp:Literal ID="litSearchUnitNo" runat="server" Text="Room No."></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtSearchUnitNo" runat="server" Style="width: 120px !important;"
                                                                        SkinID="searchtextbox"></asp:TextBox>
                                                                    <asp:ImageButton ID="btnSearch" OnClick="btnSearch_OnClick" runat="server" ImageUrl="~/images/search-icon.png"
                                                                        ToolTip="Search" Style="border: 0px; margin: -4px 0 0 5px; vertical-align: middle;" />
                                                                    <asp:ImageButton ID="imgbtnClearSearch" OnClick="imgbtnClearSearch_OnClick" runat="server"
                                                                        ToolTip="Reset" ImageUrl="~/images/clearsearch.png" Style="border: 0px; vertical-align: middle;
                                                                        margin: -4px 0 0 5px;" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litbillinginstruction" runat="server" Text="Billing instruction"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlbillinginstruction" runat="server" Style="width: 165px;">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="litOrderByList" runat="server" Text="Sort By"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlOrderByList" runat="server" Style="width: 165px;">
                                                                        <asp:ListItem Selected="True" Text="Booking No" Value="Booking No"></asp:ListItem>
                                                                        <asp:ListItem Text="Room No" Value="Room No"></asp:ListItem>
                                                                        <asp:ListItem Text="Block name" Value="Block name"></asp:ListItem>
                                                                        <asp:ListItem Text="Arrival Date" Value="Arrival Date"></asp:ListItem>
                                                                        <asp:ListItem Text="Company Name" Value="Company Name"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td colspan="4" align="right">
                                                                    <asp:Button ID="btnExportToExcel" runat="server" Text="Excel" OnClick="btnExportToExcel_OnClick"
                                                                        Style="float: right; margin-left: 5px;" />
                                                                    <asp:Button ID="btnPrintGuestList" runat="server" Text="Print" OnClick="btnPrintGuestList_OnClick"
                                                                        Style="float: right; margin-left: 5px;" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <hr />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div class="box_head">
                                                            <span>
                                                                <asp:Literal ID="litGuestList" runat="server" Text="Guest List"></asp:Literal>
                                                            </span>
                                                        </div>
                                                        <div class="clear">
                                                        </div>
                                                        <div class="box_content">
                                                            <asp:GridView ID="gvGuestList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                Width="100%" OnRowCommand="gvGuestList_RowCommand" OnRowDataBound="gvGuestList_RowDataBound"
                                                                OnPageIndexChanging="gvGuestList_PageIndexChanging" DataKeyNames="FolioID,GuestID,ReservationID,FolioNo,Balance">
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
                                                                            <asp:LinkButton ID="lnkReservationNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ReservationNo")%>'
                                                                                CommandName="GUESTPROFILE" CommandArgument='<%#Eval("ReservationID")%>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrGuestName" runat="server" Text="Name"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkGuestName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "GuestFullName")%>'
                                                                                CommandName="GUESTPROFILE" CommandArgument='<%#Eval("ReservationID")%>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrMobileNo" runat="server" Text="Mobile No."></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%-- <%#DataBinder.Eval(Container.DataItem, "Phone1")%>--%>
                                                                            <asp:Label ID="lblGvPhone" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrCompany" runat="server" Text="Company"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "CompanyName")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="125px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrRateCardType" runat="server" Text="Rate Card"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "RateCardName")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrRateCardNo" runat="server" Text="RC No."></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "Code")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="130px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrUnitType" runat="server" Text="Room Type"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvRoomTypeName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "RoomTypeName")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrUnitNo" runat="server" Text="Room No."></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvRoomNo" runat="server" Text='<%# GetFormatedRoomNumber(Eval("RoomNo")) %>'></asp:Label>
                                                                            <%--<%#DataBinder.Eval(Container.DataItem, "RoomNo")%>--%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrCheckIn" runat="server" Text="Check In"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "CheckInDate", "{0:dd-MM-yyyy}")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrCheckOut" runat="server" Text="Check Out"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "CheckOutDate", "{0:dd-MM-yyyy}")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblActions" runat="server" Text="Action"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblPopUp" runat="server" Text="Actions"></asp:Label>
                                                                            <ajx:HoverMenuExtender ID="hmeAction" runat="server" TargetControlID="lblPopUp" PopupControlID="pnlAction"
                                                                                PopupPosition="Left">
                                                                            </ajx:HoverMenuExtender>
                                                                            <asp:Panel ID="pnlAction" runat="server" Style="visibility: hidden; opacity: 100%">
                                                                                <div class="actionsbuttons_hovermenu">
                                                                                    <table border="0" cellpadding="0" cellspacing="0" class="actionsbuttons_hover_lettmenu_table">
                                                                                        <tr>
                                                                                            <td class="actionsbuttons_hover_lettmenu">
                                                                                            </td>
                                                                                            <td class="actionsbuttons_hover_centermenu">
                                                                                                <ul>
                                                                                                    <li>
                                                                                                        <asp:LinkButton Style="background: none !important; border: none;" Visible="false"
                                                                                                            ID="lnkPayment" runat="server" ToolTip="Payment" CommandName="PAYMENT"><img src="../../images/file.png" /></asp:LinkButton>
                                                                                                    </li>
                                                                                                    <li>
                                                                                                        <asp:LinkButton ID="lnkCheckOut" Style="background: none !important; border: none;"
                                                                                                            runat="server" ToolTip="Quick Post" Visible="false" CommandName="QUICKPOST"><img src="../../images/QuickPost32x32.png" /></asp:LinkButton></li>
                                                                                                    <li>
                                                                                                        <asp:LinkButton ID="lnkViewFolio" Style="background: none !important; border: none;"
                                                                                                            runat="server" ToolTip="View Folio" CommandName="VIEWFOLIO" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ReservationID")%>'><img src="../../images/file.png" /></asp:LinkButton></li>
                                                                                                    <li>
                                                                                                        <asp:LinkButton ID="lnkUpdateCheckOutNote" Style="background: none !important; border: none;"
                                                                                                            runat="server" ToolTip="Update Check Out Note" CommandName="CHECKOUTNOTE" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ReservationID")%>'><img src="../../images/file.png" /></asp:LinkButton></li>
                                                                                                    <li>
                                                                                                        <asp:LinkButton ID="lnkChangeRoomOnly" Style="background: none !important; border: none;"
                                                                                                            runat="server" ToolTip="Change Wrongly Assigned Room" CommandName="CHANGEWRONGROOMNUMBER" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ReservationID")%>'><img src="../../images/file.png" /></asp:LinkButton></li>
                                                                                                    <li>
                                                                                                        <asp:LinkButton Style="display: none; background: none !important; border: none;"
                                                                                                            ID="lnkRecovery" runat="server" ToolTip="Recovery" CommandName="RECOVERY" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ReservationID")%>'><img src="../../images/file.png" /></asp:LinkButton>
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
            <asp:View ID="vRecovery" runat="server">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="content" style="padding-left: 0px; width: 66.66%">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="boxtopleft">
                                        &nbsp;
                                    </td>
                                    <td class="boxtopcenter">
                                        <asp:Literal ID="litHdrRecovery" runat="server" Text="RECOVERY"></asp:Literal>
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
                                                    <td>
                                                        Guest Name
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblRecoveryGuestName" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-bottom: 5px;">
                                                        Booking No.
                                                    </td>
                                                    <td style="padding-bottom: 5px;">
                                                        <asp:Label ID="lblRecoveryBookingNo" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="isrequire" style="width: 110px !important;">
                                                        <asp:Literal ID="litRecoveryType" runat="server" Text="Recovery Item"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlRecoveryType" runat="server" OnSelectedIndexChanged="ddlRecoveryType_SelectedIndexChanged"
                                                            AutoPostBack="true">
                                                        </asp:DropDownList>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rfvRecoveryType" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                ValidationGroup="IsRequireRecovery" ControlToValidate="ddlRecoveryType" Display="Dynamic">
                                                            </asp:RequiredFieldValidator>
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="isrequire" style="width: 110px !important;">
                                                        <asp:Literal ID="litRecoveryAmount" runat="server" Text="Amount"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtRecoveryAmount" runat="server" Enabled="true" Style="text-align: right;"></asp:TextBox>
                                                        <ajx:FilteredTextBoxExtender ID="ftRecoveryAmount" runat="server" TargetControlID="txtRecoveryAmount"
                                                            FilterType="Custom, Numbers" ValidChars="." />
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rfvRecoveryAmount" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                runat="server" ValidationGroup="IsRequireRecovery" ControlToValidate="txtRecoveryAmount"
                                                                Display="Dynamic">
                                                            </asp:RequiredFieldValidator>
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 110px !important; vertical-align: top;">
                                                        <asp:Literal ID="litDescription" runat="server" Text="Description"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="isrequire" style="width: 110px !important;">
                                                        <asp:Literal ID="litRecoveryMode" runat="server" Text="Recovery Mode"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlRecoveryMode" runat="server">
                                                            <asp:ListItem Selected="True" Value="00000000-0000-0000-0000-000000000000" Text="-SELECT-"></asp:ListItem>
                                                            <%--<asp:ListItem Value="Cashcard" Text="Cashcard"></asp:ListItem>--%>
                                                            <asp:ListItem Value="Folio Posting" Text="Folio Posting"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rfvRecoveryMode" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                ValidationGroup="IsRequireRecovery" ControlToValidate="ddlRecoveryMode" Display="Dynamic">
                                                            </asp:RequiredFieldValidator>
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="right">
                                                        <asp:Button ID="btnSave" runat="server" Text="Save" Style="display: inline; padding-left: 5px;"
                                                            ValidationGroup="IsRequireRecovery" OnClick="btnSave_Click" />
                                                        <asp:Button ID="btnRecoveryCancel" runat="server" Text="Cancel" Style="display: inline;
                                                            padding-left: 5px;" OnClick="btnRecoveryCancel_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="padding-top: 10px;">
                                                        <b>Recovery History</b>
                                                        <hr />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <div class="box_content">
                                                            <asp:GridView ID="gvRecoveryList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                OnPageIndexChanging="gvRecoveryList_PageIndexChanging" OnRowDataBound="gvRecoveryList_RowDataBound">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrRecoverySrNo" runat="server" Text="No."></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%# Container.DataItemIndex + 1 %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrRecoveryDate" runat="server" Text="Recovery Date"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvPaymentEntryDate" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "EntryDate")).ToString(clsSession.DateFormat)%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrFolioDetailsTransaction" runat="server" Text="Trans. #"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvFolioDetailsBookNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "BookNo")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrRecoveryTitle" runat="server" Text="Item"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvRecoveryTitle" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Title")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrRecoveryAmount" runat="server" Text="Amount"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblRecoveryAmount" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrRecoverBy" runat="server" Text="Recover By"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvRecoverBy" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "UserName")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <div style="padding: 10px;">
                                                                        <b>
                                                                            <asp:Label ID="lblNoRecordFound" runat="server" Text="No record found"></asp:Label>
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
        </asp:MultiView>
        <%--<ucCtrlQuickPost:QuickPost ID="ctrlQuickPost" runat="server" OnbtnQuickPostCallParent_Click="btnQuickPostCallParent_Click" />
        <ucCtrlPayment:Payment ID="ctrlPayment" runat="server" OnbtnPaymentCallParent_Click="btnPaymentCallParent_Click" />--%>
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
        <ajx:ModalPopupExtender ID="mpeCheckOutNote" runat="server" TargetControlID="hfCheckOutNote"
            PopupControlID="pnlCheckOutNote" BackgroundCssClass="mod_background" CancelControlID="btnCheckOutNoteCancel"
            BehaviorID="mpeCheckOutNote">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hfCheckOutNote" runat="server" />
        <asp:Panel ID="pnlCheckOutNote" runat="server" Style="display: none; min-height: 350px;
            min-width: 350px;">
            <div class="box_col1" style="height: 200px; width: 500px;">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="Literal1" runat="server" Text="Check Out Note"></asp:Literal></span>
                </div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%" style="margin-top: 10px;">
                        <tr>
                            <td align="left" valign="top" style="padding-bottom: 15px;">
                                Check Out Note
                            </td>
                            <td>
                                <asp:TextBox ID="txtCheckOutNote" runat="server" SkinID="nowidth" Width="325px" Height="70px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td align="left">
                                <asp:Button ID="btnUpdateCheckOutNote" Text="Update" runat="server" OnClick="btnUpdateCheckOutNote_OnClick" Style="display: inline;
                                    padding-right: 10px;" />
                                <asp:Button ID="btnCheckOutNoteCancel" Text="Cancel" runat="server" Style="display: inline;
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
    <Triggers>
        <asp:PostBackTrigger ControlID="btnPrintGuestList" />
        <asp:PostBackTrigger ControlID="btnExportToExcel" />        
    </Triggers>
</asp:UpdatePanel>
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updGuestList" ID="UpdateProgressGuestList"
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
