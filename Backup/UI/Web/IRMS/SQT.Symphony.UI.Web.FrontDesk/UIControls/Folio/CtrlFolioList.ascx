<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlFolioList.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Folio.CtrlFolioList" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonMoveUnitSetup.ascx" TagName="MoveUnitSetup"
    TagPrefix="ucCtrlMoveUnitSetup" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonQuickPost.ascx" TagName="QuickPost"
    TagPrefix="ucCtrlQuickPost" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonExtendReservation.ascx" TagName="ExtendReservation"
    TagPrefix="ucCtrlExtendReservation" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonPayment.ascx" TagName="Payment"
    TagPrefix="ucCtrlPayment" %>
<%@ Register Src="~/UIControls/Folio/CtrlPostUnitCharges.ascx" TagName="PostUnitCharges"
    TagPrefix="ucCtrlPostUnitCharges" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonCardInfo.ascx" TagName="CardInfo"
    TagPrefix="ucCtrlCardInfo" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonCheckIn.ascx" TagName="CheckIn"
    TagPrefix="ucCtrlCheckIn" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonCounterLogin.ascx" TagName="CommonCounterLogin"
    TagPrefix="ucCtrlCommonCounterLogin" %>
<%@ Register Src="~/UIControls/Folio/CtrlCommonFolioPostCharge.ascx" TagName="CommonFolioPostCharge"
    TagPrefix="ucCommonFolioPostCharge" %>
<%@ Register Src="~/UIControls/Folio/CtrlCommonPostCredit.ascx" TagName="CommonFolioPostCredit"
    TagPrefix="ucCommonFolioPostCredit" %>
<script type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }
</script>
<asp:UpdatePanel ID="updFolioList" runat="server">
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
                                <asp:Literal ID="litMainHeader" runat="server" Text="Folio List"></asp:Literal>
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
                                            <td width="80px">
                                                <asp:Label ID="lblSearchFolioNo" runat="server" Text="Folio No."></asp:Label>
                                            </td>
                                            <td width="225px">
                                                <asp:TextBox ID="txtSearchFolioNo" runat="server" SkinID="searchtextbox"></asp:TextBox>
                                            </td>
                                            <td width="80px">
                                                <asp:Label ID="lblSearchRoomNo" runat="server" Text="Room No."></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtSearchRoomNo" runat="server" SkinID="searchtextbox"></asp:TextBox>
                                            </td>
                                            <td>
                                                &nbsp;
                                                <asp:Label ID="lblSearchGuestName" runat="server" Text="Guest Name"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtSearchGuestName" runat="server" SkinID="searchtextbox"></asp:TextBox>
                                                <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png" ToolTip="Search"
                                                    Style="border: 0px; margin: 2px 0 0 5px; vertical-align: middle;" OnClick="btnSearch_Click" />
                                                <asp:ImageButton ID="imgbtnClearSearch" runat="server" ImageUrl="~/images/clearsearch.png" ToolTip="Clear"
                                                    Style="border: 0px; vertical-align: middle; margin: 2px 0 0 10px;" OnClick="imgbtnClearSearch_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="8">
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="8" style="padding-bottom: 15px;">
                                                <div class="box_head">
                                                    <span>
                                                        <asp:Literal ID="litFolioList" runat="server" Text="Folio List"></asp:Literal>
                                                    </span>
                                                </div>
                                                <div class="clear">
                                                </div>
                                                <div class="box_content">
                                                    <asp:GridView ID="gvFolioList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                        Width="100%" OnRowCommand="gvFolioList_RowCommand" DataKeyNames="FolioID,ReservationID,GuestID"
                                                        OnRowDataBound="gvFolioList_RowDataBound" OnPageIndexChanging="gvFolioList_PageIndexChanging">
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
                                                                    <asp:Label ID="lblGvHdrFolioNo" runat="server" Text="Folio No."></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkFolioNo" runat="server" ToolTip="View Folio" Text='<%#DataBinder.Eval(Container.DataItem, "FolioNo")%>'
                                                                        CommandName="FOLIODETAILS_NEW" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ReservationID")%>'></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrGuestName" runat="server" Text="Name"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGvGuestName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "GuestFullName")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrUnitCNF" runat="server" Text="Room No."></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGvRoomNo" runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="185px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
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
                                                            <asp:TemplateField ItemStyle-Width="85px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrGroupName" runat="server" Text="Group Name"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "GroupName")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrBalance" runat="server" Text="Balance"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGvBalance" runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
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
                                                                                                <%--temp--%>
                                                                                                <asp:LinkButton ID="lnkMoveUnit" Style="background: none !important; border: none;"
                                                                                                    runat="server" ToolTip="Move Unit" CommandName="MOVEUNIT" Visible="false"><img src="../../images/file.png" /></asp:LinkButton>
                                                                                            </li>
                                                                                            <li>
                                                                                                <asp:LinkButton ID="lnkQuickPost" Style="background: none !important; border: none;"
                                                                                                    runat="server" ToolTip="Quick Post" CommandName="QUICKPOST" Visible="false" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "GuestID")%>'><img src="../../images/QuickPost32x32.png" /></asp:LinkButton>
                                                                                            </li>
                                                                                            <li>
                                                                                                <%--temp--%>
                                                                                                <asp:LinkButton ID="lnkUnitCharges" Style="background: none !important; border: none;"
                                                                                                    Visible="false" runat="server" ToolTip="Room Charges" CommandName="UNITCHARGES"><img src="../../images/file.png" /></asp:LinkButton>
                                                                                            </li>
                                                                                            <li>
                                                                                                <asp:LinkButton ID="lnkPayment" Style="background: none !important; border: none;"
                                                                                                    Visible="false" runat="server" ToolTip="Payment" CommandName="PAYMENT" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "GuestID")%>'><img src="../../images/file.png" /></asp:LinkButton></li>
                                                                                            <li>
                                                                                                <%--temp--%>
                                                                                                <asp:LinkButton ID="lnkPaymentInformation" Style="background: none !important; border: none;"
                                                                                                    runat="server" ToolTip="Payment Information" CommandName="PAYMENTINFORMATION"
                                                                                                    Visible="false"><img src="../../images/file.png" /></asp:LinkButton></li>
                                                                                            <li>
                                                                                                <%--temp--%>
                                                                                                <asp:LinkButton ID="lnkExtendReservation" Style="background: none !important; border: none;"
                                                                                                    runat="server" ToolTip="Extend Reservation" CommandName="EXTENDRESERVATION" Visible="false"><img src="../../images/file.png" /></asp:LinkButton></li>
                                                                                            <li>
                                                                                                <%--temp--%>
                                                                                                <asp:LinkButton ID="lnkCheckOut" Style="background: none !important; border: none;"
                                                                                                    runat="server" ToolTip="Check Out" CommandName="CHECKOUT" Visible="false"><img src="../../images/file.png" /></asp:LinkButton></li>
                                                                                            <li>
                                                                                                <asp:LinkButton ID="lnkTransferTransaction" Style="background: none !important; border: none;"
                                                                                                    Visible="false" runat="server" ToolTip="Transfer Transaction" CommandName="TRANSFERTRANSACTION"
                                                                                                    CommandArgument='<%#DataBinder.Eval(Container.DataItem, "FolioID")%>'><img src="../../images/file.png" /></asp:LinkButton></li>
                                                                                            <li>
                                                                                                <asp:LinkButton ID="lnkFolioDetails" Style="background: none !important; border: none;"
                                                                                                    Visible="false" runat="server" ToolTip="Folio Details" CommandName="FOLIODETAILS_NEW"
                                                                                                    CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ReservationID")%>'><img src="../../images/file.png" /></asp:LinkButton></li>
                                                                                            <li>
                                                                                                <asp:LinkButton ID="lnkPostCharge" Style="background: none !important; border: none;"
                                                                                                    runat="server" ToolTip="Post Charge" CommandName="POSTCHARGE" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ReservationID")%>'><img src="../../images/file.png" /></asp:LinkButton></li>
                                                                                            <li>
                                                                                                <asp:LinkButton ID="lnkPostCredit" Style="background: none !important; border: none;"
                                                                                                    runat="server" ToolTip="Post Credit" CommandName="POSTCREDIT" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ReservationID")%>'><img src="../../images/file.png" /></asp:LinkButton></li>
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
                                        <tr>
                                            <td colspan="8" style="border: 1px solid #ccccce;">
                                                <div style="float: left;">
                                                    <asp:LinkButton ID="lnkFolioListPrint" runat="server"><img src="../../images/Print32x32.png" title="Print" style="vertical-align: middle;" /></asp:LinkButton>
                                                </div>
                                                <div style="float: right; text-align: right; width: 200px; background-color: #DCDDDF;
                                                    color: #0083CE; font-size: 15px; font-weight: bold; padding: 9px;">
                                                    <b>
                                                        <asp:Label ID="lblDispalyTotalFolioBalance" runat="server" Text="0.00"></asp:Label></b>
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
        <ajx:ModalPopupExtender ID="mpeMoveUnit" runat="server" TargetControlID="hdnMoveUnit"
            PopupControlID="pnlMoveUnit" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnMoveUnit" runat="server" />
        <asp:Panel ID="pnlMoveUnit" runat="server" Width="670px" Style="display: none;">
            <ucCtrlMoveUnitSetup:MoveUnitSetup ID="CtrlCommonMoveUnitSetup" runat="server" OnbtnMoveUnitCallParent_Click="btnMoveUnitCallParent_Click" />
        </asp:Panel>
        <ucCtrlQuickPost:QuickPost ID="ctrlCommonQuickPost" runat="server" OnbtnQuickPostCallParent_Click="btnQuickPostCallParent_Click" />
        <ucCommonFolioPostCharge:CommonFolioPostCharge ID="ctrlFolioPostCharge" runat="server" OnbtnCommonFolioPostChargeCallParent_Click="btnCommonFolioPostChargeCallParent_Click"  />
        <ucCommonFolioPostCredit:CommonFolioPostCredit ID="ctrlFolioPostCredit" runat="server" OnbtnCommonFolioPostCreditCallParent_Click="btnCommonFolioPostCreditCallParent_Click"  />
        <ucCtrlPostUnitCharges:PostUnitCharges ID="CtrlCommonPostUnitCharges" runat="server"
            OnbtnPostUnitChargesCallParent_Click="btnPostUnitChargesCallParent_Click" />
        <ucCtrlCardInfo:CardInfo ID="ctrlCommonCardInfo" runat="server" />
        <ucCtrlPayment:Payment ID="ctrlCommonPayment" runat="server" OnbtnPaymentCallParent_Click="btnPaymentCallParent_Click" />
        <ajx:ModalPopupExtender ID="mpeMessage" runat="server" TargetControlID="hdnMessage"
            PopupControlID="pnlMessage" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnMessage" runat="server" />
        <asp:Panel ID="pnlMessage" runat="server" Width="800px" Style="display: none;">
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpeCheckIn" runat="server" TargetControlID="hdnCheckIn"
            PopupControlID="pnlCheckIn" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnCheckIn" runat="server" />
        <asp:Panel ID="pnlCheckIn" runat="server" Width="800px" Style="display: none;">
            <ucCtrlCheckIn:CheckIn ID="ctrlCommonCheckIn" runat="server" OnbtnCheckInCallParent_Click="btnCheckInCallParent_Click" />
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpeExtendReservation" runat="server" TargetControlID="hdnExtendReservation"
            PopupControlID="pnlExtendReservation" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnExtendReservation" runat="server" />
        <asp:Panel ID="pnlExtendReservation" runat="server" Width="780px" Style="display: none;">
            <ucCtrlExtendReservation:ExtendReservation ID="CtrlCommonExtendReservation" runat="server"
                OnbtnExtendReservationCallParent_Click="btnExtendReservationCallParent_Click" />
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
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updFolioList" ID="UpdateProgressFolioList"
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
