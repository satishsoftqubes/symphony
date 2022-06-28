<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlRoomBooking.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.Activity.CtrlRoomBooking" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
        document.getElementById('<%= lblNoOfNightTodisp.ClientID %>').value = '';
    }

    function stopKey(evt) {
        var evt = (evt) ? evt : ((event) ? event : null);
        var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
        if ((evt.keyCode == 8) && (node.type == "text")) { return false; }
        else if ((evt.keyCode == 9) && (node.type == "text")) { return true; }
        else if ((evt.keyCode == 46) && (node.type == "text")) { return false; }
        else { return false; }
    }
</script>
<style type="text/css">
    #progressBackgroundFilter
    {
        position: fixed;
        top: 0px;
        width: 100%;
        height: 100%;
        bottom: 0px;
        left: 0px;
        right: 0px;
        overflow: hidden;
        padding: 0;
        margin: 0;
        background-color: #000;
        filter: alpha(opacity=50);
        opacity: 0.5;
        z-index: 1111111;
    }
    #processMessage
    {
        position: fixed;
        top: 50%;
        left: 50%;
        padding: 10px;
        width: 30px;
        border-radius: 10px;
        z-index: 1111112;
        background-color: #fff;
        border: solid 1px #efefef;
    }
</style>
<asp:UpdatePanel ID="updRoomBookingList" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td style="padding-left: 0px; width: 100%">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                ROOM BOOKING 
                            </td>
                            <td class="boxtopright">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="boxleft">
                                &nbsp;
                            </td>
                            <td>
                                <div style="height: 500px;">
                                    <table width="100%" cellpadding="2" cellspacing="2">
                                        <tr>
                                            <td colspan="2">
                                                <div style="height: 26px;">
                                                    <%if (IsInsert)
                                                      { %>
                                                    <div class="ResetSuccessfully">
                                                        <div style="float: left; padding-top: 7px; width: 25px; height: 24px; margin-right: 10px;">
                                                            <img src="../../images/success.png" />
                                                        </div>
                                                        <div>
                                                            <asp:Label ID="lblProsMsg" runat="server"></asp:Label></div>
                                                        <div style="height: 10px;">
                                                        </div>
                                                    </div>
                                                    <% }%>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <div style="float: right;">
                                                    <b>All Bold Fields are Mandatory</b>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 110px;">
                                                <asp:Label ID="litNoOfRooms" runat="server" Text="No.Of Rooms" CssClass="RequireFile"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="litViewNoOfRoom" runat="server" Text="1" CssClass="RequireFile"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">
                                                <asp:Label ID="litPropertyID" CssClass="RequireFile" runat="server" Text="Property Name"></asp:Label>
                                                <span class="erroraleart">
                                                    <asp:RequiredFieldValidator ID="rvfddlPropertyName" runat="server" ControlToValidate="ddlPropertyName"
                                                        SetFocusOnError="true" CssClass="rfv_ErrorStar" InitialValue="00000000-0000-0000-0000-000000000000"
                                                        ErrorMessage="*" ValidationGroup="RoomBookingList"></asp:RequiredFieldValidator>
                                                </span>
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:DropDownList ID="ddlPropertyName" runat="server" Style="width: 202px;">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">
                                                <asp:Label ID="litInvestor" runat="server" Text="Investor Name" CssClass="RequireFile"></asp:Label>
                                                <span class="erroraleart">
                                                    <asp:RequiredFieldValidator ID="rvfInvestor" SetFocusOnError="True" ControlToValidate="ddlInvestor"
                                                        ValidationGroup="RoomBookingList" InitialValue="00000000-0000-0000-0000-000000000000"
                                                        runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                                </span>
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:DropDownList ID="ddlInvestor" runat="server" Style="width: 203px;" OnSelectedIndexChanged="ddlInvestor_selectedIndexchange"
                                                    AutoPostBack="true">
                                                </asp:DropDownList>
                                                <%--<asp:TextBox ID="txtComplementorydays" runat="server" Style="width: 40px !important;"
                                                    onkeydown="return stopKey(event);"></asp:TextBox>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblComplementorydays" runat="server">                                                
                                                </asp:Label>
                                                <asp:Label ID="lblStoreComplementorydays" runat="server">                                                
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblCheckInDate" runat="server" Text="CheckIn Date" CssClass="RequireFile"></asp:Label>
                                                <span class="erroraleart">
                                                    <asp:RequiredFieldValidator ID="rfvCheckInDate" SetFocusOnError="True" ControlToValidate="txtCheckInDate"
                                                        ValidationGroup="RoomBookingList" runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                                </span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCheckInDate" SkinID="CmpTextbox" runat="server" onkeydown="return stopKey(event);"></asp:TextBox>
                                                <asp:Image ID="imbCheckInDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png" />
                                                <ajx:CalendarExtender ID="calCheckInDate" runat="server" PopupButtonID="imbCheckInDate"
                                                    TargetControlID="txtCheckInDate" CssClass="MyCalendar">
                                                </ajx:CalendarExtender>
                                                <img src="../../images/clear.png" id="imgClearDate" style="vertical-align: middle;"
                                                    onclick="fnClearDate('<%= txtCheckInDate.ClientID %>');" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblCheckOutDate" runat="server" Text="CheckOut Date" CssClass="RequireFile"></asp:Label>
                                                <span class="erroraleart">
                                                    <asp:RequiredFieldValidator ID="rfvCheckOutDate" SetFocusOnError="True" ControlToValidate="txtCheckOutDate"
                                                        ValidationGroup="RoomBookingList" runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                                </span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCheckOutDate" SkinID="CmpTextbox" AutoPostBack="true" OnTextChanged="txtCheckOutDate_TextChange"
                                                    runat="server" onkeydown="return stopKey(event);"></asp:TextBox>
                                                <asp:Image ID="imbCheckOutDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png" />
                                                <ajx:CalendarExtender ID="calCheckOutDate" runat="server" PopupButtonID="imbCheckOutDate"
                                                    TargetControlID="txtCheckOutDate" CssClass="MyCalendar">
                                                </ajx:CalendarExtender>
                                                <img src="../../images/clear.png" id="img1" style="vertical-align: middle;" onclick="fnClearDate('<%= txtCheckOutDate.ClientID %>');" />
                                                <%--<asp:TextBox ID="txtNoOfNightTodisp" runat="server" Style="width: 40px !important;"
                                                    onkeydown="return stopKey(event);"></asp:TextBox>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblNoOfNightTodisp" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="litInvestorGuestName" runat="server" Text="Guest Name" CssClass="RequireFile"></asp:Label>
                                                <span class="erroraleart">
                                                    <asp:RequiredFieldValidator ID="rvfInvestorGuestName" SetFocusOnError="True" ControlToValidate="txtInvestorGuestName"
                                                        ValidationGroup="RoomBookingList" runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                                </span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtInvestorGuestName" runat="server" MaxLength="150" SkinID="CmpTextbox"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="litEmail" runat="server" Text="Email" CssClass="RequireFile"></asp:Label>
                                                <span class="erroraleart">
                                                    <asp:RequiredFieldValidator ID="rvfEmail" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                        runat="server" ValidationGroup="RoomBookingList" ControlToValidate="txtEmail"
                                                        ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="*" ControlToValidate="txtEmail"
                                                        CssClass="rfv_ErrorStar" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                        ValidationGroup="RoomBookingList" Display="Dynamic"></asp:RegularExpressionValidator>
                                                </span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtEmail" runat="server" MaxLength="150" SkinID="CmpTextbox"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="litPhone" runat="server" Text="Contact No." CssClass="RequireFile"></asp:Label>
                                                <span class="erroraleart">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" SetFocusOnError="True" ControlToValidate="txtPhone"
                                                        ValidationGroup="RoomBookingList" runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                                </span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPhone" runat="server" MaxLength="15" SkinID="CmpTextbox"></asp:TextBox>
                                                <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtPhone"
                                                    FilterType="Custom, numbers" ValidChars="" Enabled="True" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblTotalGuest" runat="server" Text="Total Guest" CssClass="RequireFile"></asp:Label>
                                                <span class="erroraleart">
                                                    <asp:RequiredFieldValidator ID="rfvTotalGuest" SetFocusOnError="True" ControlToValidate="txtNoOfAdult"
                                                        ValidationGroup="RoomBookingList" runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                                </span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTotalGuest" runat="server" MaxLength="10" SkinID="CmpTextbox"></asp:TextBox>
                                                <ajx:FilteredTextBoxExtender ID="fteTotalGuest" runat="server" TargetControlID="txtTotalGuest"
                                                    FilterType="Custom, numbers" ValidChars="" Enabled="True" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="litNoOfAdult" runat="server" Text="No.Of Adult" CssClass="RequireFile"></asp:Label>
                                                <span class="erroraleart">
                                                    <asp:RequiredFieldValidator ID="rvfNoOfAdult" SetFocusOnError="True" ControlToValidate="txtNoOfAdult"
                                                        ValidationGroup="RoomBookingList" runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                                </span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtNoOfAdult" runat="server" MaxLength="10" SkinID="CmpTextbox"></asp:TextBox>
                                                <ajx:FilteredTextBoxExtender ID="ftbetxtNoOfAdult" runat="server" TargetControlID="txtNoOfAdult"
                                                    FilterType="Custom, numbers" ValidChars="" Enabled="True" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="litNoOfChild" runat="server" Text="No.Of Child" CssClass="RequireFile"></asp:Label>
                                                <span class="erroraleart">
                                                    <asp:RequiredFieldValidator ID="rvfNoOfChild" SetFocusOnError="True" ControlToValidate="txtNoOfChild"
                                                        ValidationGroup="RoomBookingList" runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                                </span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtNoOfChild" runat="server" MaxLength="10" SkinID="CmpTextbox"></asp:TextBox>
                                                <ajx:FilteredTextBoxExtender ID="ftbetxtNoOfChild" runat="server" TargetControlID="txtNoOfChild"
                                                    FilterType="Custom, numbers" ValidChars="" Enabled="True" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblNotes" runat="server" Text="Note"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtNotes" runat="server" SkinID="Medium" TextMode="MultiLine" Height="60px"
                                                    MaxLength="500"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <asp:CheckBox ID="chkIsUtilizedVoucher" runat="server" OnCheckedChanged="chkIsUtilizedVoucher_OnCheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                Is Utilized Voucher
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top" colspan="2" style="text-align: right;">
                                                <div style="float: right; width: auto; height: 33px; display: inline-block;">
                                                    <asp:Button ID="btnSave" runat="server" Style="display: inline-block; margin-left: 5px;
                                                        display: inline;" Text="Save" OnClientClick="fnDisplayCatchErrorMessage()" ValidationGroup="RoomBookingList"
                                                        OnClick="btnSave_Click" />
                                                    <asp:Button ID="btnCancel" Text="Back To List" Style="display: inline-block; margin-left: 5px;"
                                                        runat="server" ImageUrl="~/images/save.png" CausesValidation="true" OnClientClick="return postbackButtonClick();"
                                                        OnClick="btnCancel_Click" />
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
                </td>
                <td style="width: 2px;">
                    &#160;
                </td>
            </tr>
        </table>
        <div>
            <ajx:ModalPopupExtender ID="mpeMessageBox" runat="server" TargetControlID="hdnMessageBox"
                PopupControlID="pnlMessageBox" BackgroundCssClass="mod_background" CancelControlID="btnMessageBoxOk">
            </ajx:ModalPopupExtender>
            <asp:HiddenField ID="hdnMessageBox" runat="server" />
            <asp:Panel ID="pnlMessageBox" runat="server" Style="display: none;">
                <div style="width: 500px; height: 200px; margin-top: 25px;">
                    <table border="0" cellspacing="0" cellpadding="0" class="modelpopup_box">
                        <tr>
                            <td class="modelpopup_boxtopleft">
                                &nbsp;
                            </td>
                            <td class="modelpopup_boxtopcenter">
                                &nbsp;
                            </td>
                            <td class="modelpopup_boxtopright">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="modelpopup_boxleft">
                                &nbsp;
                            </td>
                            <td class="modelpopup_box_bg">
                                <div style="width: 100px; float: left; margin-top: 10px;">
                                    <asp:HyperLink ID="HyperLink1" runat="server">
                                        <asp:Image ImageUrl="~/images/error.png" AlternateText="" Height="75px" Width="75px"
                                            ID="Image1" runat="server" />
                                    </asp:HyperLink>
                                </div>
                                <div style="float: left; width: 290px; margin-top: 40px; margin-left: 10px;">
                                    <asp:Label ID="litMessageBox" runat="server"></asp:Label>
                                </div>
                                <table cellpadding="3" cellspacing="3" width="100%" style="margin-left: 5px; margin-top: 15px;">
                                    <tr>
                                        <td align="center" valign="middle">
                                            <asp:Button ID="btnMessageBoxOk" runat="server" Text="OK" Style="display: inline;
                                                padding-right: 10px;" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td class="modelpopup_boxright">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="modelpopup_boxbottomleft">
                                &nbsp;
                            </td>
                            <td class="modelpopup_boxbottomcenter">
                            </td>
                            <td class="modelpopup_boxbottomright">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessage" class="clear" >
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updRoomBookingList" ID="UpdateProgressIPR"
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
