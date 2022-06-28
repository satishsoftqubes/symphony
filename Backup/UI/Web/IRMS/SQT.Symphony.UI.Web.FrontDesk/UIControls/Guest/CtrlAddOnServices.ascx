<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlAddOnServices.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Guest.CtrlAddOnServices" %>
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
<asp:UpdatePanel ID="updAddOnServices" runat="server">
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
                                <asp:Literal ID="litMainHeader" runat="server" Text="AddOn Services"></asp:Literal>
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
                                                            <asp:ImageButton ID="btnSearch" OnClick="btnSearch_OnClick" runat="server" ImageUrl="~/images/search-icon.png" ToolTip="Search"
                                                                Style="border: 0px; margin: -4px 0 0 5px; vertical-align: middle;" />
                                                            <asp:ImageButton ID="imgbtnClearSearch" OnClick="imgbtnClearSearch_OnClick" runat="server" ToolTip="Reset"
                                                                ImageUrl="~/images/clearsearch.png" Style="border: 0px; vertical-align: middle;
                                                                margin: -4px 0 0 5px;" />
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
                                            <td align="right">
                                                <div style="margin-left: 15px;">
                                                    <asp:Button ID="btnAdvanceSearch" runat="server" Text="Advance Search" CssClass="add_content_inner"
                                                        OnClick="btnAdvanceSearch_Click" Style="display: inline;" />
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div class="box_head">
                                                    <span>
                                                        <asp:Literal ID="litAddOnServicesGuestList" runat="server" Text="AddOn Services"></asp:Literal>
                                                    </span>
                                                </div>
                                                <div class="clear">
                                                </div>
                                                <div class="box_content">
                                                    <asp:GridView ID="gvGuestListAddOnServices" runat="server" AutoGenerateColumns="false"
                                                        ShowHeader="true" Width="100%" DataKeyNames="ReservationNo,GuestFullName" OnPageIndexChanging="gvGuestListAddOnServices_PageIndexChanging"
                                                        OnRowDataBound="gvGuestListAddOnServices_RowDataBound" OnRowCommand="gvGuestListAddOnServices_RowCommand">
                                                        <Columns>
                                                            <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrReservationNo" runat="server" Text="Booking #"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkReservationNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ReservationNo")%>'
                                                                        CommandName="GUESTPROFILE" CommandArgument='<%#Eval("ReservationNo") + "," +Eval("ReservationID")+","+Eval("FolioID")+","+Eval("GuestID")%>'></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrGuestName" runat="server" Text="Name"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkGuestName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "GuestFullName")%>'
                                                                        CommandName="GUESTPROFILE" CommandArgument='<%#Eval("ReservationNo") + "," +Eval("ReservationID")+","+Eval("FolioID")+","+Eval("GuestID")%>'></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="110px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrMobileNo" runat="server" Text="Mobile No."></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGvPhone" runat="server"></asp:Label>
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
                                                            <asp:TemplateField ItemStyle-Width="180px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrUnitType" runat="server" Text="Room Type"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGvRoomTypeName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "RoomTypeName")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrUnitNo" runat="server" Text="Room No."></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGvRoomNo" runat="server" Text='<%# GetFormatedRoomNumber(Eval("RoomNo")) %>'></asp:Label>
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
                                                            <asp:TemplateField ItemStyle-Width="50px" Visible="false" HeaderStyle-HorizontalAlign="Center"
                                                                ItemStyle-HorizontalAlign="Center">
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
                                                                                                <asp:LinkButton Style="background: none !important; border: none;" CommandArgument='<%#Eval("ReservationID") + "," + Eval("GuestID")%>'
                                                                                                    ID="lnkPayment" runat="server" ToolTip="Assign Cashcard" CommandName="CASHCARD"><img src="../../images/file.png" /></asp:LinkButton>
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
        <ajx:ModalPopupExtender ID="mpeCashcardAssignment" runat="server" TargetControlID="hfCashcardAssignment"
            PopupControlID="pnlCashcardAssignment" BackgroundCssClass="mod_background" CancelControlID="imbCloseCashcardAssignmentPopup">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hfCashcardAssignment" runat="server" />
        <asp:Panel ID="pnlCashcardAssignment" runat="server" Style="display: none; min-height: 350px;
            min-width: 350px;">
            <div class="box_col1" style="height: 200px; width: 500px;">
                <div class="box_head">
                    <div style="display: inline;">
                        <span>
                            <asp:Literal ID="Literal14" runat="server" Text="Cashcard Assignment"></asp:Literal></span></div>
                    <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                        <asp:ImageButton ID="imbCloseCashcardAssignmentPopup" runat="server" ImageUrl="~/images/closepopup.png"
                            OnClick="imbCloseCashcardAssignmentPopup_OnClick" Style="border: 0px; width: 16px;
                            height: 16px; margin: -4px 0 0 5px; vertical-align: middle;" />
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="5" cellspacing="5" width="100%">
                        <tr>
                            <td width="80px">
                                <b>Guest Name</b>
                            </td>
                            <td width="200px">
                                <asp:Label ID="lblGuestName" runat="server"></asp:Label>
                            </td>
                            <td width="70px">
                                <b>Booking #</b>
                            </td>
                            <td>
                                <asp:Label ID="lblBookingNo" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-top: 10px;">
                                <b>Cashcard No.</b>
                            </td>
                            <td style="padding-top: 10px;">
                                <asp:TextBox ID="txtCashcardNumber" runat="server" SkinID="nowidth" Width="150px"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rfvCashcardNumber" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                        runat="server" ValidationGroup="IsRequire4CashcardNumber" ControlToValidate="txtCashcardNumber"
                                        Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4" style="padding-top: 15px; padding-bottom: 25px;">
                                <asp:Button ID="btnSaveCashcardNo" runat="server" Text="Save" ValidationGroup="IsRequire4CashcardNumber"
                                    OnClick="btnSaveCashcardNo_OnClick" />
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
<asp:UpdateProgress AssociatedUpdatePanelID="updAddOnServices" ID="UpdateProgressAddOnServices"
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
