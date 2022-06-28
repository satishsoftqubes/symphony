<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlReservationConfig.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.Configurations.CtrlReservationConfig" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<script type="text/javascript" language="javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function pageLoad(sender, args) {  
        $(function () {
            $("#tabs").tabs();
        });

        $('#tabs').tabs({
            select: function (event, ui) {
                window.location.hash = ui.tab.hash;
            }
        });
    }

    function SelectTab(tabno) {
        if (tabno == '1') {
            window.location.hash = 'tabs-1';
        }
        else if (tabno == '2') {
            window.location.hash = 'tabs-2';
        }
        else if (tabno == '3') {
            window.location.hash = 'tabs-3';
        }
    }

</script>
<%--<asp:UpdatePanel ID="upnlReservationConfig" runat="server">
    <ContentTemplate>--%>
<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td align="left" valign="top">
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="boxtopleft">
                        &nbsp;
                    </td>
                    <td class="boxtopcenter">
                        <asp:Literal ID="litMainHeader" runat="server"></asp:Literal>
                    </td>
                    <td class="boxtopright">
                        &nbsp;
                    </td>
                    <tr>
                        <td class="boxleft">
                            &nbsp;
                        </td>
                        <td align="left" valign="top">
                            <div class="box_form">
                                <div class="demo">
                                    <div id="tabs">
                                        <ul>
                                            <li><a href="#tabs-1">
                                                <asp:Literal ID="litTabReservationConfiguration" runat="server"></asp:Literal></a></li>
                                            <li><a href="#tabs-2">
                                                <asp:Literal ID="litTabResPolicy" runat="server"></asp:Literal></a></li>
                                            <li><a href="#tabs-3">
                                                <asp:Literal ID="litTabHousingRules" runat="server"></asp:Literal></a></li>
                                            <li><a href="#tabs-4">
                                                <asp:Literal ID="litTabReservationPolicy" runat="server"></asp:Literal></a></li>
                                            <%--<li><a href="#tabs-4">
                                                        <asp:Literal ID="litTabResCancellationPolicy" runat="server"></asp:Literal></a></li>--%>
                                        </ul>
                                        <div id="tabs-1">
                                            <table cellpadding="2" cellspacing="2" width="100%">
                                                <tr>
                                                    <td>
                                                        <%if (IsMessage)
                                                          { %>
                                                        <div class="message finalsuccess">
                                                            <p>
                                                                <strong>
                                                                    <asp:Literal ID="litResConfMessage" runat="server"></asp:Literal></strong>
                                                            </p>
                                                        </div>
                                                        <%}%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: top;" valign="top">
                                                        <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                            <tr>
                                                                <td width="165px">
                                                                    <asp:Literal ID="litCheckInTime" runat="server"></asp:Literal>
                                                                </td>
                                                                <td width="280px">
                                                                    <asp:TextBox ID="txtCheckInTime" Style="width: 100px;" runat="server"></asp:TextBox>&nbsp;(HH:MM)
                                                                    <asp:RegularExpressionValidator ID="rgvtxtCheckInTime" runat="server" ValidationGroup="IsRequire"
                                                                        ValidationExpression="^(20|21|22|23|[01]\d|\d)(([:][0-5]\d){1,2})$" SetFocusOnError="true"
                                                                        ControlToValidate="txtCheckInTime" Display="Static" CssClass="input-notification error png_bg"></asp:RegularExpressionValidator>
                                                                </td>
                                                                <td width="165px">
                                                                    <asp:Literal ID="litCheckOutTime" runat="server"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtCheckOutTime" Style="width: 100px;" runat="server"></asp:TextBox>&nbsp;(HH:MM)
                                                                    <asp:RegularExpressionValidator ID="rgvCheckOutTime" runat="server" ValidationGroup="IsRequire"
                                                                        ValidationExpression="^(20|21|22|23|[01]\d|\d)(([:][0-5]\d){1,2})$" SetFocusOnError="true"
                                                                        ControlToValidate="txtCheckOutTime" Display="Static" CssClass="input-notification error png_bg"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr id="trToHide" runat="server" visible="false">
                                                                <td>
                                                                    <asp:Literal ID="litCheckInStlMins" runat="server"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtCheckInStlMins" Style="width: 100px;" runat="server" MaxLength="5"></asp:TextBox>
                                                                    <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" FilterMode="ValidChars"
                                                                        ValidChars="0123456789" TargetControlID="txtCheckInStlMins">
                                                                    </ajx:FilteredTextBoxExtender>
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="litCheckOutStlMins" runat="server"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtCheckOutStlMins" Style="width: 100px;" runat="server" MaxLength="5"></asp:TextBox>
                                                                    <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" FilterMode="ValidChars"
                                                                        ValidChars="0123456789" TargetControlID="txtCheckOutStlMins">
                                                                    </ajx:FilteredTextBoxExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litBeforeCheckInHR" runat="server"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtBeforeCheckInHR" Style="width: 100px;" runat="server" MaxLength="2"></asp:TextBox>
                                                                    <ajx:FilteredTextBoxExtender ID="fltBeforeCheckInHR" runat="server" FilterMode="ValidChars"
                                                                        ValidChars="0123456789" TargetControlID="txtBeforeCheckInHR">
                                                                    </ajx:FilteredTextBoxExtender>
                                                                    <asp:RangeValidator ID="rngBeforeCheckInHr" Display="Dynamic" runat="server" SetFocusOnError="true"
                                                                        ValidationGroup="IsRequireRP" ControlToValidate="txtBeforeCheckInHR" ForeColor="Red"
                                                                        ErrorMessage="Before hour set between 0-24" MinimumValue="0" MaximumValue="24"
                                                                        Type="Double"></asp:RangeValidator>
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="litAfterCheckInHR" runat="server"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtAfterCheckInHR" Style="width: 100px;" runat="server" MaxLength="2"></asp:TextBox>
                                                                    <ajx:FilteredTextBoxExtender ID="flttxtAfterCheckInHR" runat="server" FilterMode="ValidChars"
                                                                        ValidChars="0123456789" TargetControlID="txtAfterCheckInHR">
                                                                    </ajx:FilteredTextBoxExtender>
                                                                    <asp:RangeValidator ID="RGVtxtAfterCheckInHR" Display="Dynamic" runat="server" SetFocusOnError="true"
                                                                        ValidationGroup="IsRequireRP" ControlToValidate="txtAfterCheckInHR" ForeColor="Red"
                                                                        ErrorMessage="Before hour set between 0-24" MinimumValue="0" MaximumValue="24"
                                                                        Type="Double"></asp:RangeValidator>
                                                                </td>
                                                            </tr>
                                                            <tr id="trToHide1" runat="server" visible="false">
                                                                <td>
                                                                    <asp:Literal ID="litBeforeCharge" runat="server"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtBeforeCharge" runat="server" MaxLength="24" Style="width: 100px;"></asp:TextBox>
                                                                    <asp:DropDownList ID="ddlBeforeCharge" runat="server" Style="width: 91px; height: 24px;
                                                                        margin-top: -1; margin-left: 6px;" AutoPostBack="true" OnSelectedIndexChanged="ddlBeforeCharge_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                    <br />
                                                                    <ajx:FilteredTextBoxExtender ID="fltBeforeCharge" runat="server" FilterMode="ValidChars"
                                                                        ValidChars="0123456789." TargetControlID="txtBeforeCharge">
                                                                    </ajx:FilteredTextBoxExtender>
                                                                    <asp:RegularExpressionValidator Display="Dynamic" ID="refBeforeCharge" runat="server"
                                                                        ForeColor="Red" ControlToValidate="txtBeforeCharge" SetFocusOnError="true" ValidationGroup="IsRequireRP">
                                                                    </asp:RegularExpressionValidator>
                                                                    <asp:RangeValidator ID="rbgBeforeCharge" Display="Dynamic" runat="server" MinimumValue="0"
                                                                        MaximumValue="100" ControlToValidate="txtBeforeCharge" SetFocusOnError="true"
                                                                        ValidationGroup="IsRequireRP" ForeColor="Red" Type="Double"></asp:RangeValidator>
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="litAfterCharge" runat="server"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtAfterCharge" runat="server" MaxLength="24" Style="width: 100px;"></asp:TextBox>
                                                                    <asp:DropDownList ID="ddlAfterCharge" runat="server" Style="width: 91px; height: 24px;
                                                                        margin-top: -1; margin-left: 6px;" AutoPostBack="true" OnSelectedIndexChanged="ddlAfterCharge_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                    <br />
                                                                    <ajx:FilteredTextBoxExtender ID="fltAfterCharge" runat="server" FilterMode="ValidChars"
                                                                        ValidChars="0123456789." TargetControlID="txtAfterCharge">
                                                                    </ajx:FilteredTextBoxExtender>
                                                                    <asp:RegularExpressionValidator Display="Dynamic" ID="regAfterCharge" runat="server"
                                                                        ForeColor="Red" ControlToValidate="txtAfterCharge" SetFocusOnError="true" ValidationGroup="IsRequireRP">
                                                                    </asp:RegularExpressionValidator>
                                                                    <asp:RangeValidator ID="rgvAfterCharge" Display="Dynamic" runat="server" MinimumValue="0"
                                                                        MaximumValue="100" ControlToValidate="txtAfterCharge" SetFocusOnError="true"
                                                                        ValidationGroup="IsRequireRP" ForeColor="Red" Type="Double"></asp:RangeValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litInFantAgeLimit" runat="server"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtInFantAgeLimit" Style="width: 100px;" runat="server" MaxLength="5"></asp:TextBox>
                                                                    <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server" FilterMode="ValidChars"
                                                                        ValidChars="0123456789" TargetControlID="txtInFantAgeLimit">
                                                                    </ajx:FilteredTextBoxExtender>
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="litChildAgeLimit" runat="server"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtChildAgeLimit" Style="width: 100px;" runat="server" MaxLength="5"></asp:TextBox>
                                                                    <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" FilterMode="ValidChars"
                                                                        ValidChars="0123456789" TargetControlID="txtChildAgeLimit">
                                                                    </ajx:FilteredTextBoxExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <%--<asp:Literal ID="litNoOfVerificationCriteriaForAmendmentOrCancellationReservaion"
                                                                        runat="server"></asp:Literal>--%>
                                                                    <asp:Literal ID="litMinDaysForLongstay" runat="server"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <%--<asp:TextBox ID="txtNoOfVerificationCriteriaForAmendmentOrCancellationReservaion"
                                                                        runat="server" MaxLength="10" Style="width: 100px;"></asp:TextBox>
                                                                    <ajx:FilteredTextBoxExtender ID="ftNoOfVerificationCriteriaForAmendmentOrCancellationReservaion"
                                                                        runat="server" FilterMode="ValidChars" ValidChars="0123456789" TargetControlID="txtNoOfVerificationCriteriaForAmendmentOrCancellationReservaion">
                                                                    </ajx:FilteredTextBoxExtender>--%>
                                                                    <asp:TextBox ID="txtMinDaysForLongstay" runat="server" MaxLength="18" Style="width: 100px;"></asp:TextBox>
                                                                    <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" FilterMode="ValidChars"
                                                                        ValidChars="0123456789" TargetControlID="txtMinDaysForLongstay">
                                                                    </ajx:FilteredTextBoxExtender>
                                                                    <asp:RequiredFieldValidator ID="rfvMinDaysForLongstay" SetFocusOnError="True" CssClass="input-notification error png_bg"
                                                                        runat="server" ValidationGroup="IsRequire" ControlToValidate="txtMinDaysForLongstay"
                                                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                                                    <asp:RegularExpressionValidator Display="Dynamic" ID="revMinDaysForLongstay" runat="server"
                                                                        ForeColor="Red" ControlToValidate="txtMinDaysForLongstay" SetFocusOnError="true"
                                                                        ValidationExpression="^\d{0,18}(\.\d{0,2})?$" ValidationGroup="IsRequire">
                                                                    </asp:RegularExpressionValidator>
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="litProvisionRsrvnDayLmt" runat="server"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtProvisionRsrvnDayLmt" Style="width: 100px;" runat="server" MaxLength="5"></asp:TextBox>
                                                                    <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server" FilterMode="ValidChars"
                                                                        ValidChars="0123456789" TargetControlID="txtProvisionRsrvnDayLmt">
                                                                    </ajx:FilteredTextBoxExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    Max. Refund Cash Limit
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtMaxRefundCashLimit" Style="width: 100px;" runat="server" MaxLength="5"></asp:TextBox>
                                                                    <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender14" runat="server" FilterMode="ValidChars"
                                                                        ValidChars="0123456789" TargetControlID="txtMaxRefundCashLimit">
                                                                    </ajx:FilteredTextBoxExtender>
                                                                </td>
                                                            </tr>
                                                            <tr id="tr5" runat="server" visible="false">
                                                                <td>
                                                                    <asp:Literal ID="litDefualtHoldType" runat="server"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlDefualtHoldType" runat="server">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr id="tr3" runat="server" visible="false">
                                                                <td>
                                                                    <asp:Literal ID="litGeneralTravelAgntCmsn" runat="server"></asp:Literal>
                                                                </td>
                                                                <td colspan="3">
                                                                    <asp:TextBox ID="txtGeneralTravelAgntCmsn" runat="server" MaxLength="10" Style="width: 100px;"></asp:TextBox>
                                                                    <asp:DropDownList ID="ddlGeneralTravlAgntCmnd" runat="server" Style="width: 91px;
                                                                        height: 24px; margin-top: -1; margin-left: 6px;" OnSelectedIndexChanged="ddlGeneralTravlAgntCmnd_SelectedIndexChanged"
                                                                        AutoPostBack="true">
                                                                    </asp:DropDownList>
                                                                    <br />
                                                                    <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterMode="ValidChars"
                                                                        ValidChars="0123456789." TargetControlID="txtGeneralTravelAgntCmsn">
                                                                    </ajx:FilteredTextBoxExtender>
                                                                    <asp:RegularExpressionValidator Display="Dynamic" ID="regGeneralTravelAgentCmsn"
                                                                        runat="server" ForeColor="Red" ControlToValidate="txtGeneralTravelAgntCmsn" SetFocusOnError="true"
                                                                        ValidationGroup="IsRequire">
                                                                    </asp:RegularExpressionValidator>
                                                                    <asp:RangeValidator ID="rgvGeneralTravelAgentCMS" Display="Dynamic" runat="server"
                                                                        MinimumValue="0" MaximumValue="100" ControlToValidate="txtGeneralTravelAgntCmsn"
                                                                        SetFocusOnError="true" ValidationGroup="IsRequire" ForeColor="Red" Type="Double"></asp:RangeValidator>
                                                                </td>
                                                            </tr>
                                                            <tr id="tr4" runat="server" visible="false">
                                                                <td>
                                                                    <asp:Literal ID="litGeneralCorporateDisc" runat="server"></asp:Literal>
                                                                </td>
                                                                <td colspan="3">
                                                                    <asp:TextBox ID="txtGeneralCorporateDisc" runat="server" MaxLength="10" Style="width: 100px;"></asp:TextBox>
                                                                    <asp:DropDownList ID="ddlGeneralCorporateDisc" runat="server" Style="width: 91px;
                                                                        height: 24px; margin-top: -1; margin-left: 6px;" OnSelectedIndexChanged="ddlGeneralCorporateDisc_SelectedIndexChanged"
                                                                        AutoPostBack="true">
                                                                    </asp:DropDownList>
                                                                    <br />
                                                                    <ajx:FilteredTextBoxExtender ID="fltFilterBox" runat="server" FilterMode="ValidChars"
                                                                        ValidChars="0123456789." TargetControlID="txtGeneralCorporateDisc">
                                                                    </ajx:FilteredTextBoxExtender>
                                                                    <asp:RegularExpressionValidator Display="Dynamic" ID="regGeneralCorporateDisc" runat="server"
                                                                        ForeColor="Red" ControlToValidate="txtGeneralCorporateDisc" SetFocusOnError="true"
                                                                        ValidationGroup="IsRequire">
                                                                    </asp:RegularExpressionValidator>
                                                                    <asp:RangeValidator ID="rgvCorporateDiscount" Display="Dynamic" runat="server" MinimumValue="0"
                                                                        MaximumValue="100" ControlToValidate="txtGeneralCorporateDisc" SetFocusOnError="true"
                                                                        ValidationGroup="IsRequire" ForeColor="Red" Type="Double"></asp:RangeValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div style="float: right; width: auto; display: inline-block;">
                                                            <asp:Button ID="btnSave" Text="Save" Style="float: right; margin-left: 5px;" runat="server"
                                                                ImageUrl="~/images/save.png" ValidationGroup="IsRequire" CausesValidation="true"
                                                                OnClick="btnSave_Click" OnClientClick="fnDisplayCatchErrorMessage();" />
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="tabs-2">
                                            <table cellpadding="2" cellspacing="2" width="100%">
                                                <tr>
                                                    <td colspan="2">
                                                        <%if (IsInsert)
                                                          { %>
                                                        <div class="message finalsuccess">
                                                            <p>
                                                                <strong>
                                                                    <asp:Literal ID="litResPolicyMessage" runat="server"></asp:Literal></strong>
                                                            </p>
                                                        </div>
                                                        <%}%>
                                                    </td>
                                                </tr>
                                                <tr id="tr6" runat="server" visible="false">
                                                    <td style="vertical-align: middle; padding-left: 7px;">
                                                        <asp:Literal ID="litHighWeekDays" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="left" style="vertical-align: top;">
                                                        <table cellpadding="2" cellspacing="2" width="100%">
                                                            <tr>
                                                                <td class="checkbox_new">
                                                                    <asp:CheckBox ID="chkMon" runat="server" />
                                                                </td>
                                                                <td class="checkbox_new">
                                                                    <asp:CheckBox ID="chkTue" runat="server" />
                                                                </td>
                                                                <td class="checkbox_new">
                                                                    <asp:CheckBox ID="chkWed" runat="server" />
                                                                </td>
                                                                <td class="checkbox_new">
                                                                    <asp:CheckBox ID="chkThr" runat="server" />
                                                                </td>
                                                                <td class="checkbox_new">
                                                                    <asp:CheckBox ID="chkFri" runat="server" />
                                                                </td>
                                                                <td class="checkbox_new">
                                                                    <asp:CheckBox ID="chkSat" runat="server" />
                                                                </td>
                                                                <td class="checkbox_new">
                                                                    <asp:CheckBox ID="chkSun" runat="server" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: top;" valign="top" colspan="2">
                                                        <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                            <tr>
                                                                <td width="265px">
                                                                    <asp:Literal ID="litAutoRemindProvisionalBooking" Text="Auto Remind Provisional Booking (Days)"
                                                                        runat="server"></asp:Literal>
                                                                </td>
                                                                <td width="250px">
                                                                    <asp:TextBox ID="txtAutoRemindProvisionalBooking" Style="width: 100px;" runat="server"
                                                                        MaxLength="5"></asp:TextBox>
                                                                    <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" runat="server" FilterMode="ValidChars"
                                                                        ValidChars="0123456789" TargetControlID="txtAutoRemindProvisionalBooking">
                                                                    </ajx:FilteredTextBoxExtender>
                                                                </td>
                                                                <td width="265px">
                                                                    <asp:Literal ID="litWaitingLisrBookingRoomAvailable" Text="Auto remind Waiting List Booking if Room Available (Days)"
                                                                        runat="server"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtWaitingLisrBookingRoomAvailable" Style="width: 100px;" runat="server"
                                                                        MaxLength="5"></asp:TextBox>
                                                                    <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" runat="server" FilterMode="ValidChars"
                                                                        ValidChars="0123456789" TargetControlID="txtWaitingLisrBookingRoomAvailable">
                                                                    </ajx:FilteredTextBoxExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="265px">
                                                                    <asp:Literal ID="litUnconfirmedResRmdDays" runat="server"></asp:Literal>
                                                                </td>
                                                                <td width="250px">
                                                                    <asp:TextBox ID="txtUnconfirmedResRmdDays" Style="width: 100px;" runat="server" MaxLength="5"></asp:TextBox>
                                                                    <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterMode="ValidChars"
                                                                        ValidChars="0123456789" TargetControlID="txtUnconfirmedResRmdDays">
                                                                    </ajx:FilteredTextBoxExtender>
                                                                </td>
                                                                <td width="265px">
                                                                    <asp:Literal ID="litRoomReservationCnfmDays" runat="server"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtRoomReservationCnfmDays" Style="width: 100px;" runat="server"
                                                                        MaxLength="5"></asp:TextBox>
                                                                    <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterMode="ValidChars"
                                                                        ValidChars="0123456789" TargetControlID="txtRoomReservationCnfmDays">
                                                                    </ajx:FilteredTextBoxExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal Visible="false" ID="litConferenceReservationCnfmDays" runat="server"></asp:Literal>
                                                                    <asp:Literal ID="litGroupReservationCnfmDays" runat="server"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox Visible="false" ID="txtConferenceReservationCnfmDays" Style="width: 100px;"
                                                                        runat="server" MaxLength="5"></asp:TextBox>
                                                                    <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" FilterMode="ValidChars"
                                                                        ValidChars="0123456789" TargetControlID="txtConferenceReservationCnfmDays">
                                                                    </ajx:FilteredTextBoxExtender>
                                                                    <asp:TextBox ID="txtGroupReservationCnfmDays" Style="width: 100px;" runat="server"
                                                                        MaxLength="5"></asp:TextBox>
                                                                    <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" FilterMode="ValidChars"
                                                                        ValidChars="0123456789" TargetControlID="txtGroupReservationCnfmDays">
                                                                    </ajx:FilteredTextBoxExtender>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <hr />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                            <tr>
                                                                <td class="checkbox_new">
                                                                    <asp:CheckBox ID="ChkIsReasonRequired" runat="server" />
                                                                </td>
                                                                <td class="checkbox_new">
                                                                    <asp:CheckBox ID="ChkIsFirstNightChargeCompForCashPayers" runat="server" />
                                                                </td>
                                                                <td class="checkbox_new">
                                                                    <asp:CheckBox ID="ChkIsAssignRoomToUnConfirmRes" runat="server" />
                                                                </td>
                                                                <td class="checkbox_new">
                                                                    <asp:CheckBox ID="ChkIsAssignRoomOnReservation" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="checkbox_new">
                                                                    <asp:CheckBox ID="ChkIsUserCanOverrideRackRate" runat="server" />
                                                                </td>
                                                                <td class="checkbox_new">
                                                                    <asp:CheckBox ID="ChkIsUserCanApplyDiscount" runat="server" />
                                                                </td>
                                                                <td class="checkbox_new">
                                                                    <asp:CheckBox ID="ChkIsUserCanSetTaxExempt" runat="server" />
                                                                </td>
                                                                <td class="checkbox_new">
                                                                    <asp:CheckBox ID="chkIsShowDepositAlertCheckIn" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="checkbox_new">
                                                                    <asp:CheckBox ID="chkIsShowDirtyRoomAlertCheckIn" runat="server" />
                                                                </td>
                                                                <td class="checkbox_new">
                                                                    <asp:CheckBox ID="chkIsAutoPostFirstNightChargeCheckIn" runat="server" />
                                                                </td>
                                                                <td class="checkbox_new">
                                                                    <asp:CheckBox ID="chkGuestEmailCompulsory" runat="server" />
                                                                </td>
                                                                <td class="checkbox_new">
                                                                    <asp:CheckBox ID="chkGuestIdentifyCompulsory" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="checkbox_new">
                                                                    <asp:CheckBox ID="chkRateInclusiveService" runat="server" />
                                                                </td>
                                                                <td class="checkbox_new">
                                                                    <asp:CheckBox ID="chkEnblAutoAsgnRoom" runat="server" />
                                                                </td>
                                                                <td class="checkbox_new">
                                                                    <asp:CheckBox ID="chkCardInfmRequired" runat="server" />
                                                                </td>
                                                                <td class="checkbox_new">
                                                                    <asp:CheckBox ID="chkWarnOnOverBooking" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="checkbox_new">
                                                                    <asp:CheckBox ID="chkShowDenomination" runat="server" />
                                                                </td>
                                                                <td class="checkbox_new">
                                                                    <asp:CheckBox ID="chkApplyYield" runat="server" />
                                                                </td>
                                                                <td class="checkbox_new">
                                                                    <asp:CheckBox ID="chkYieldFlat" runat="server" />
                                                                </td>
                                                                <td class="checkbox_new">
                                                                    <asp:CheckBox ID="chkIs24HrsChckIn" runat="server" Style="padding: 0px;" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <div style="float: right; width: auto; display: inline-block;">
                                                            <asp:Button ID="btnReservationPolicySave" Text="Save" Style="float: right; margin-left: 5px;"
                                                                runat="server" ImageUrl="~/images/save.png" ValidationGroup="IsRequireRP" CausesValidation="true"
                                                                OnClientClick="fnDisplayCatchErrorMessage();" OnClick="btnReservationPolicySave_Click" />
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="tabs-3">
                                            <table cellpadding="2" cellspacing="2" width="100%">
                                                <tr>
                                                    <td colspan="2">
                                                        <div>
                                                            <%if (IsMessageForHR)
                                                              { %>
                                                            <div class="message finalsuccess">
                                                                <p>
                                                                    <strong>
                                                                        <asp:Literal ID="ltrSuccessfullyTerm" runat="server"></asp:Literal></strong>
                                                                </p>
                                                            </div>
                                                            <%}%>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <CKEditor:CKEditorControl ID="txtTermsCondition" runat="server">
                                                        </CKEditor:CKEditorControl>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" colspan="2">
                                                        <div>
                                                            <asp:Button ID="btnTermsConditionSave" runat="server" CausesValidation="true" ValidationGroup="IsRequire"
                                                                OnClick="btnTermsConditionSave_Click" Style="display: inline;" OnClientClick="fnDisplayCatchErrorMessage();" />
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="tabs-4">
                                            <table cellpadding="2" cellspacing="2" width="100%">
                                                <tr>
                                                    <td colspan="2">
                                                        <div>
                                                            <%if (IsMessageForHR)
                                                              { %>
                                                            <div class="message finalsuccess">
                                                                <p>
                                                                    <strong>
                                                                        <asp:Literal ID="Literal1" runat="server"></asp:Literal></strong>
                                                                </p>
                                                            </div>
                                                            <%}%>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <CKEditor:CKEditorControl ID="CKEditorControl1" runat="server">
                                                        </CKEditor:CKEditorControl>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" colspan="2">
                                                        <div>
                                                            <asp:Button ID="Button1" runat="server" CausesValidation="true" ValidationGroup="IsRequire"
                                                                Style="display: inline;" Text="Save" OnClientClick="fnDisplayCatchErrorMessage();" />
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
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
                </tr>
            </table>
            <div class="clear_divider">
            </div>
        </td>
    </tr>
</table>
<%-- <ajx:ModalPopupExtender ID="mpeConfirmDelete" runat="server" TargetControlID="hdnConfirmDelete"
            PopupControlID="pnlDeleteData" BackgroundCssClass="mod_background"
            BehaviorID="mpeConfirmDelete">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnConfirmDelete" runat="server" />
        <asp:Panel ID="pnlDeleteData" runat="server" Height="350px" Width="325px" Style="display: none;">
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
                                    OnClick="btnYes_Click" OnClientClick="fnDisplayCatchErrorMessage();" />
                                <asp:Button ID="btnNo" runat="server" Style="display: inline;" OnClick="btnNo_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>--%>
<%--  </ContentTemplate>
</asp:UpdatePanel>--%>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<%--<asp:UpdateProgress AssociatedUpdatePanelID="upnlReservationConfig" ID="UpdateProgressReservationConfig"
    runat="server">
    <ProgressTemplate>
        <div id="progressBackgroundFilter">
        </div>
        <div id="processMessage">
            <center>
                <img src="../../images/ajax-loader.gif" /></center>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>--%>
