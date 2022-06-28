<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlAmendmentList.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation.ctrlAmendmentList" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonCounterLogin.ascx" TagName="CommonCounterLogin"
    TagPrefix="ucCtrlCommonCounterLogin" %>
<script type="text/javascript">
    function pageLoad(sender, args) {
        var v1 = '<%=ConfigurationManager.AppSettings["IsUpperCase"].ToString() %>'
        if (v1 == "1") {
            $('input[type="text"],textarea').each(function () { $(this).css("text-transform", "uppercase") });
        }
    }
    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function fncall() {
        SQT.Symphony.UI.Web.FrontDesk.WebService1.HelloWorld();
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
                    $find('mpeDateMessage').show();
                    document.getElementById('<%=lblAmendmentCriteriaMsg.ClientID %>').innerHTML = "Varification is not Complete.";
                    return false;
                }
            }
            else {
                $find('mpeDateMessage').show();
                document.getElementById('<%=lblAmendmentCriteriaMsg.ClientID %>').innerHTML = "Minimum Criteria for Cancel Reservation is not configured. Please Configure it";
                return false;
            }
        }
    }
</script>
<asp:UpdatePanel ID="updAmendmentList" runat="server">
    <ContentTemplate>
        <asp:HiddenField ID="hdnNoOfAmendmentCriteria" runat="server" />
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="content">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                <asp:Literal ID="litMainHeader" runat="server" Text="Amend Reservation"></asp:Literal>
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
                                    <table cellpadding="2" cellspacing="2" border="0">
                                        <tr>
                                            <td width="60px">
                                                <asp:Literal ID="litSearchName" runat="server" Text="Name"></asp:Literal>
                                            </td>
                                            <td width="250px">
                                                <asp:TextBox ID="txtSearchName" runat="server"></asp:TextBox>
                                            </td>
                                            <td width="60px">
                                                <asp:Literal ID="litSearchMobileNo" runat="server" Text="Mobile No."></asp:Literal>
                                            </td>
                                            <td width="180px">
                                                <asp:TextBox ID="txtSearchMobileNo" runat="server" SkinID="nowidth" Width="150px"></asp:TextBox>
                                            </td>
                                            <td style="width: 60px;">
                                                <asp:Literal ID="litSearcReservationNo" runat="server" Text="Booking #"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtSearcReservationNo" runat="server" SkinID="nowidth" Width="150px"></asp:TextBox>
                                                <ajx:FilteredTextBoxExtender ID="fteSearcReservationNo" runat="server" TargetControlID="txtSearcReservationNo"
                                                    FilterMode="ValidChars" ValidChars="0123456789">
                                                </ajx:FilteredTextBoxExtender>
                                                <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png" ToolTip="Search"
                                                    Style="border: 0px; margin: -4px 0 0 5px; vertical-align: middle;" OnClick="btnSearch_Click" />
                                                <asp:ImageButton ID="imgbtnClearSearch" runat="server" ImageUrl="~/images/clearsearch.png" ToolTip="Clear"
                                                    Style="border: 0px; vertical-align: middle; margin: 0 0 0 10px;" OnClick="imgbtnClearSearch_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                    <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                        <tr>
                                            <td>
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div class="box_head">
                                                    <span>
                                                        <asp:Literal ID="litAmendmentList" runat="server" Text="Reservation List"></asp:Literal>
                                                    </span>
                                                </div>
                                                <div class="clear">
                                                </div>
                                                <div class="box_content">
                                                    <asp:GridView ID="gvAmendmentList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                        Width="100%" OnRowCommand="gvAmendmentList_RowCommand" OnPageIndexChanging="gvAmendmentList_PageIndexChanging"
                                                        OnRowDataBound="gvAmendmentList_RowDataBound" DataKeyNames="Email,CardNo,SymphonyValue,ReservationID">
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
                                                                    <%--<asp:LinkButton ID="lnkReservationNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ReservationNo")%>'
                                                                        CommandName="AMENDMENT" CommandArgument='<%#Eval("ReservationID")%>'></asp:LinkButton>--%>
                                                                    <asp:LinkButton ID="lnkReservationNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ReservationNo")%>'
                                                                        CommandName="AMENDMENT" CommandArgument='<%# Container.DataItemIndex %>'></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrStatus" runat="server" Text="Status"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Image ID="imgReservationStatus" runat="server" Style="height: 20px; width: 20px;" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrGuestName" runat="server" Text="Name"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%--<asp:LinkButton ID="lnkGuestName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "GuestFullName")%>'
                                                                        CommandName="AMENDMENT" CommandArgument='<%#Eval("ReservationID")%>'></asp:LinkButton>--%>
                                                                    <asp:LinkButton ID="lnkGuestName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "GuestFullName")%>'
                                                                        CommandName="AMENDMENT" CommandArgument='<%# Container.DataItemIndex %>'></asp:LinkButton>
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
                                                            <asp:TemplateField ItemStyle-Width="125px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrRateCardType" runat="server" Text="Rate Card Name"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGvRateCardName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "RateCardName")%>'></asp:Label>
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
        <ajx:ModalPopupExtender ID="mpeOpenAmendment" runat="server" TargetControlID="hdnAmendment"
            PopupControlID="pnlAmendment" BackgroundCssClass="mod_background" CancelControlID="imgCancelAmendent">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnAmendment" runat="server" />
        <asp:Panel ID="pnlAmendment" runat="server" Width="750px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <div style="display: inline;">
                        <span>
                            <asp:Literal ID="litAmendment" runat="server" Text="Amendment"></asp:Literal></span></div>
                    <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                        <asp:ImageButton ID="imgCancelAmendent" runat="server" ImageUrl="~/images/closepopup.png"
                            Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;" />
                    </div>
                </div>
                <%-- <div class="box_head">
                    <span>
                        <asp:Literal ID="litAmendment" runat="server" Text="Amendment"></asp:Literal></span></div>--%>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td style="width: 140px !important;">
                                <asp:Literal ID="litName" runat="server" Text="Name"></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="litDisplayGuestName" runat="server" Text="Name"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="litBookingNo" runat="server" Text="Booking #"></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="litDisplayResNo" runat="server" Text="Booking #"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire">
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
                            <td class="isrequire">
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
                                                <asp:Literal ID="litDisplayEmail" runat="server"></asp:Literal>
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
                                <asp:Button ID="btnVerificationComplete" runat="server" OnClick="btnVerificationComplete_OnClick"
                                    Style="display: inline; padding-right: 10px;" Text="Verification Complete" ValidationGroup="IsRequire"
                                    OnClientClick="return fnCheckAmendmentCriteria();" />
                                <%--<asp:Button ID="btnCancel" runat="server" Style="display: inline;" Text="Cancel" />--%>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpeDateMessage" runat="server" TargetControlID="hfDateMessage"
            PopupControlID="pnlDateMessage" BackgroundCssClass="mod_background" CancelControlID="btnDateMessageOK"
            BehaviorID="mpeDateMessage" DropShadow="true">
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
            PopupControlID="pnlOpenCounter" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnOpenCounter" runat="server" />
        <asp:Panel ID="pnlOpenCounter" runat="server" Width="400px">
            <div class="box_col1">
                <div class="box_head">
                    <div style="display: inline;">
                        <span>
                            <asp:Literal ID="Literal23" runat="server" Text="Counter"></asp:Literal></span></div>
                    <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                        <asp:ImageButton ID="iBtnCloseCounter" runat="server" ImageUrl="~/images/closepopup.png"
                            OnClick="iBtnCloseCounter_OnClick" Style="border: 0px; width: 16px; height: 16px;
                            margin: -4px 0 0 5px; vertical-align: middle;" />
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
            PopupControlID="pnlCounterErrorMessage" BackgroundCssClass="mod_background" BehaviorID="mpeCounterErrorMessage">
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
                                <asp:Label ID="lblCounterErrorMessage" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnCounterErrorMessageOK" Text="OK" runat="server" OnClick="btnCounterErrorMessageOK_OnClick"
                                    Style="display: inline; padding-right: 10px;" />
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
<asp:UpdateProgress AssociatedUpdatePanelID="updAmendmentList" ID="UpdateProgressAmendmentList"
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
