<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrCommonGuestInfo.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls.CtrCommonGuestInfo" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonCardInfo.ascx" TagName="CommonCardInfo"
    TagPrefix="ucCommonCardInfo" %>
<%@ Register Src="../Folio/CtrlCommonAddDeposit.ascx" TagName="CtrlCommonAddDeposit"
    TagPrefix="ucAddDeposit" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript">
    function Clear() {
        document.getElementById('<%= txtCountryName.ClientID %>').value = document.getElementById('<%= txtStateName.ClientID %>').value = document.getElementById('<%= txtCityName.ClientID %>').value = document.getElementById('<%= txtZipCode.ClientID %>').value = document.getElementById('<%= txtAddress.ClientID %>').value = document.getElementById('<%= txtMobile.ClientID %>').value = document.getElementById('<%= txtFirstName.ClientID %>').value = document.getElementById('<%= txtLastName.ClientID %>').value = document.getElementById('<%= txtGuestEmail.ClientID %>').value = document.getElementById('<%= txtNationality.ClientID %>').value = "";
        document.getElementById('<%= ddlTitle.ClientID %>').selectedIndex = document.getElementById('<%= ddlStatus.ClientID %>').selectedIndex = document.getElementById('<%= ddlStayType.ClientID %>').selectedIndex = 0;
    }
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
    function validate(Type) {

        if (document.getElementById("<%=ddlTitle.ClientID%>").selectedIndex == 0) {
            document.getElementById("<%=lblCustomePopupMsg.ClientID%>").innerHTML = "Please Select Title";
            $find('mpeCustomePopup').show();
            return false;
        }
        else if (document.getElementById("<%=txtFirstName.ClientID%>").value == '') {
            document.getElementById("<%=lblCustomePopupMsg.ClientID%>").innerHTML = "Please Enter Guest Name";
            document.getElementById("<%=txtFirstName.ClientID%>").focus();
            $find('mpeCustomePopup').show();
            return false;
        }


    }

    function fntest() {
        if ($('#foo').is(':hidden')) {
            document.getElementById("foo").style.display = "block";
            document.getElementById('imgExtraInfo').src = "../../images/plus_minus.png";
            return false;
        }
        else {
            // it's not hidden so do something else
            document.getElementById("foo").style.display = "none";
            document.getElementById('imgExtraInfo').src = "../../images/plus_button.png";
            return false;
        }
    }

</script>
<style type="text/css">
    #div1
    {
        width: 100%;
        display: none;
        border: 2px solid #EFEFEF;
        background-color: #FEFEFE;
    }
</style>
<table cellpadding="2" cellspacing="2" border="0" width="100%">
    <tr>
        <td colspan="2">
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="left">
                        <b>
                            <asp:Literal ID="litGuestInformation" runat="server" Text="Guest Information"></asp:Literal></b>
                    </td>
                    <td align="right">
                        <asp:LinkButton ID="lnkComplementaryReservation" runat="server" OnClick="lnkComplementaryReservation_OnClick"
                            Text="Complementary Reservation"></asp:LinkButton>
                    </td>
                </tr>
            </table>
            <hr />
        </td>
    </tr>
    <tr id="trComplementoryReservationType" runat="server" visible="false">
        <td class="isrequire">
            <asp:Literal ID="Literal2" runat="server" Text="Reference By"></asp:Literal>
        </td>
        <td>
            <asp:DropDownList ID="ddlComplementoryRefBy" runat="server" Style="width: 224px;
                height: 25px;" AutoPostBack="true" OnSelectedIndexChanged="ddlComplementoryRefBy_OnSelectedIndexChanged">
                <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                <asp:ListItem Text="CEO" Value="CEO"></asp:ListItem>
                <asp:ListItem Text="GM" Value="GM"></asp:ListItem>
                <asp:ListItem Text="INVESTOR" Value="INVESTOR"></asp:ListItem>
            </asp:DropDownList>
            <%--<span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" InitialValue="00000000-0000-0000-0000-000000000000"
                    SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                    ValidationGroup="IsRequire" ControlToValidate="ddlStayType" Display="Dynamic">
                </asp:RequiredFieldValidator>
            </span>--%>
        </td>
    </tr>
    <tr id="trInvestors" runat="server" visible="false">
        <td class="isrequire">
            <asp:Literal ID="Literal3" runat="server" Text="Investor"></asp:Literal>
        </td>
        <td>
            <asp:DropDownList ID="ddlInvestor" runat="server" AutoPostBack="true" Style="width: 224px;
                height: 25px;" OnSelectedIndexChanged="ddlInvestor_OnSelectedIndexChanged">
                <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                <asp:ListItem Text="Pradeep Patel" Value="0"></asp:ListItem>
                <asp:ListItem Text="Shyam Benegal" Value="1"></asp:ListItem>
            </asp:DropDownList>
            <%--<span>
                <asp:RequiredFieldValidator ID="rfvInvestor" InitialValue="00000000-0000-0000-0000-000000000000"
                    SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                    ValidationGroup="IsRequire" ControlToValidate="ddlInvestor" Display="Dynamic">
                </asp:RequiredFieldValidator>
            </span>--%>
        </td>
    </tr>
    <tr id="trToHide" runat="server" visible="false">
        <td class="isrequire">
            <asp:Literal ID="litStayType" runat="server" Text="*Stay Type"></asp:Literal>
        </td>
        <td>
            <asp:DropDownList ID="ddlStayType" runat="server" Style="width: 224px; height: 25px;">
                <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                <asp:ListItem Text="Short" Value="Short"></asp:ListItem>
                <asp:ListItem Text="Long" Value="Long"></asp:ListItem>
            </asp:DropDownList>
            <span>
                <asp:RequiredFieldValidator ID="rfvStayType" InitialValue="00000000-0000-0000-0000-000000000000"
                    SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                    ValidationGroup="IsRequire" ControlToValidate="ddlStayType" Display="Dynamic">
                </asp:RequiredFieldValidator>
            </span>
        </td>
    </tr>
    <tr>
        <td class="isrequire">
            <asp:Literal ID="litNationality" runat="server" Text="Nationality"></asp:Literal>
        </td>
        <td>
            <asp:TextBox ID="txtNationality" runat="server" Text="Indian"></asp:TextBox>
            <span>
                <asp:RequiredFieldValidator ID="rfvNationality" InitialValue="00000000-0000-0000-0000-000000000000"
                    SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                    ValidationGroup="IsRequire" ControlToValidate="txtNationality" Display="Dynamic">
                </asp:RequiredFieldValidator>
            </span>
        </td>
    </tr>
    <tr>
        <td class="isrequire" style="width: 80px !important;">
            <asp:Literal ID="litName" runat="server" Text="Name"></asp:Literal>
        </td>
        <td>
            <div style="float: left;">
                <asp:DropDownList ID="ddlTitle" runat="server" Style="width: 60px; height: 25px;">
                    <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                    <asp:ListItem Text="Mr." Value="Mr."></asp:ListItem>
                    <asp:ListItem Text="Mrs." Value="Mrs."></asp:ListItem>
                    <asp:ListItem Text="Ms" Value="Ms"></asp:ListItem>
                </asp:DropDownList>
                <span>
                    <asp:RequiredFieldValidator ID="rvfTitle" InitialValue="00000000-0000-0000-0000-000000000000"
                        SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                        ValidationGroup="IsRequire" ControlToValidate="ddlTitle" Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </span>
                <asp:TextBox ID="txtFirstName" runat="server" MaxLength="150" Style="width: 120px !important;"></asp:TextBox>
                <ajx:TextBoxWatermarkExtender ID="txtwmeFirstName" runat="server" TargetControlID="txtFirstName"
                    WatermarkText="First Name">
                </ajx:TextBoxWatermarkExtender>
                <span>
                    <asp:RequiredFieldValidator ID="rvfFirstName" SetFocusOnError="true" CssClass="input-notification error png_bg"
                        runat="server" ValidationGroup="IsRequire" ControlToValidate="txtFirstName" Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </span>
                <asp:TextBox ID="txtLastName" runat="server" MaxLength="150" Style="width: 120px !important;"></asp:TextBox>
                <ajx:TextBoxWatermarkExtender ID="txtwmeLastName" runat="server" TargetControlID="txtLastName"
                    WatermarkText="Last Name">
                </ajx:TextBoxWatermarkExtender>
                &nbsp;&nbsp;&nbsp;
            </div>
            <%--<div style="float: left;">
                <asp:Button ID="btnAddGuest" runat="server" Text="+" OnClick="btnAddGuest_Click" />
            </div>--%>
            <div style="float: left;">
                <%-- <asp:Button ID="btnSearchGuestInfo" runat="server" Text="S" OnClick="btnSearchGuestInfo_Click"
                    Style="margin-left: 3px;" />--%>
                <asp:ImageButton ID="imgSearchGuestInfo" runat="server" ImageUrl="~/images/001_38.gif"
                    OnClick="btnSearchGuestInfo_Click" Style="margin-top: 3px; border: none;" />
            </div>
            <div style="float: left;">
                <asp:Button ID="btnAddGuest" runat="server" Visible="false" Text="+" OnClick="btnAddGuest_Click"
                    Style="margin-left: 5px;" />
            </div>
            <%--<div style="float: left;">
                <asp:Button ID="btnProfile" runat="server" Text="P" OnClick="btnProfile_Click" OnClientClick="return validate('PROFILE');"
                    Style="margin-left: 3px;" />
            </div>--%>
            <div style="float: left;">
                <img src="../../images/clearsearch.png" id="imgClear" style="vertical-align: middle;
                    margin-top: 6px; margin-left: 4px;" title="Clear" onclick="Clear();" />
            </div>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Literal ID="litBookedBy" runat="server" Text="Booked By"></asp:Literal>
        </td>
        <td>
            <asp:TextBox ID="txtBookedBy" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="lnkBookedBy" runat="server" Text="Copy Name" Style="display: inline;"></asp:LinkButton>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Literal ID="litMobile" runat="server" Text="Mobile No."></asp:Literal>
        </td>
        <td>
            <asp:TextBox ID="txtCode" runat="server" Text="+91" Style="width: 30px !important;"></asp:TextBox>
            <asp:TextBox ID="txtMobile" Style="width: 190px;" runat="server"></asp:TextBox>
            <ajx:FilteredTextBoxExtender ID="ftMobile" runat="server" TargetControlID="txtMobile"
                ValidChars="0123456789" FilterMode="ValidChars">
            </ajx:FilteredTextBoxExtender>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Literal ID="litGuestEmail" runat="server" Text="Email"></asp:Literal>
        </td>
        <td>
            <asp:TextBox ID="txtGuestEmail" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="lnkVerifyBlackList" runat="server" Text="Verify Black List" Style="display: inline;"></asp:LinkButton>
            <span>
                <asp:RegularExpressionValidator ID="revGuestEmail" Display="Dynamic" ValidationGroup="IsRequire"
                    runat="server" ErrorMessage="Please Enter Valid Email" ForeColor="Red" ControlToValidate="txtGuestEmail"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </span>
        </td>
    </tr>
    <tr>
        <td style="vertical-align: top;">
            <asp:Literal ID="litAddress" runat="server" Text="Address"></asp:Literal>
        </td>
        <td>
            <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="vertical-align: top;">
        </td>
        <td>
            <asp:TextBox ID="txtAddressLine2" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Literal ID="litCityName" runat="server" Text="City"></asp:Literal>
        </td>
        <td>
            <asp:TextBox ID="txtCityName" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Literal ID="litZipCode" runat="server" Text="Zip Code"></asp:Literal>
        </td>
        <td>
            <asp:TextBox ID="txtZipCode" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Literal ID="litStateName" runat="server" Text="State"></asp:Literal>
        </td>
        <td>
            <asp:TextBox ID="txtStateName" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Literal ID="litCountryName" runat="server" Text="Country"></asp:Literal>
        </td>
        <td>
            <div style="float: left;">
                <asp:TextBox ID="txtCountryName" runat="server"></asp:TextBox>
            </div>
            <div style="float: left;">
                <%--<img src="../../images/plus_button.png"
                    title="Extra Info" id="imgExtraInfo" onclick="fntest();" />--%>
            </div>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Literal ID="Literal4" runat="server" Text="Company Name"></asp:Literal>
        </td>
        <td>
            <asp:TextBox ID="txtCompanyName" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <div style="display: none;" id="foo">
                <table cellpadding="2" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td style="padding-left: 0px !important; width: 102px !important;">
                            <asp:Literal ID="litGuestIDType" runat="server" Text="ID Type"></asp:Literal>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlGuestIDType" runat="server">
                                <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                <asp:ListItem Text="Licence No." Value="Licence No"></asp:ListItem>
                                <asp:ListItem Text="Passport" Value="Passport"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left: 0px !important;">
                            <asp:Literal ID="litGuestIDDetail" runat="server" Text="ID Detail"></asp:Literal>
                        </td>
                        <td>
                            <asp:TextBox ID="txtGuestIDDetail" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left: 0px !important;">
                            <asp:Literal ID="litDOB" runat="server" Text="DOB"></asp:Literal>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDOB" runat="server" onkeypress="return false;"></asp:TextBox>
                            <asp:Image ID="imgDOB" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                Height="20px" Width="20px" />
                            <ajx:CalendarExtender ID="calGuestDOB" PopupButtonID="imgDOB" TargetControlID="txtDOB"
                                runat="server" Format="dd/MMM/yyyy">
                            </ajx:CalendarExtender>
                            <img src="../../images/clear.png" id="imgClearDOB" style="vertical-align: middle;"
                                title="Clear Date" onclick="fnClearDate('<%= txtDOB.ClientID %>');" />
                        </td>
                    </tr>
                </table>
            </div>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <b>Payment</b>
            <hr />
        </td>
    </tr>
    <tr>
        <td>
            Billing Instruction
        </td>
        <td>
            <asp:DropDownList ID="ddlBillingInstruction" runat="server">
                <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                <asp:ListItem Text="Full Billing To Company" Value="Full Billing To Company"></asp:ListItem>
                <asp:ListItem Text="Part Billing To Company" Value="Part Billing To Company"></asp:ListItem>
                <asp:ListItem Text="Full Payment By Company" Value="Full Payment By Company"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            Min. Amount for Confirm Reservation&nbsp;&nbsp;&nbsp;&nbsp;2500.00
        </td>
    </tr>
    <tr>
        <td>
            Amount Paid
        </td>
        <td>
            <asp:TextBox ID="txtPaymentAmount" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Mode of Payment
        </td>
        <td>
            <asp:DropDownList ID="ddlModeOfPayment" runat="server" OnSelectedIndexChanged="ddlModeOfPayment_OnSelectedIndexChanged"
                AutoPostBack="true">
                <asp:ListItem Text="-Select-" Value="0"></asp:ListItem>
                <asp:ListItem Text="Cash" Value="1"></asp:ListItem>
                <asp:ListItem Text="Cheque" Value="2"></asp:ListItem>
                <asp:ListItem Text="DD" Value="3"></asp:ListItem>
                <asp:ListItem Text="Credit Card" Value="4"></asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;
            <asp:Button ID="btnAddDeposit" runat="server" Text="Deposit" OnClick="btnAddDeposit_Click"
                Style="display: none;" />
            <%--<asp:Button ID="btnAddMoreModeOfPayment" runat="server" Text="+" Style="display: inline;"
                            OnClick="btnAddMoreModeOfPayment_OnClick" />--%>
        </td>
    </tr>
    <tr id="trChequeDD1" runat="server" visible="false">
        <td>
            Bank Name
        </td>
        <td>
            <asp:TextBox ID="txtBankName" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr id="trChequeDD2" runat="server" visible="false">
        <td>
            Cheque/DD No.
        </td>
        <td>
            <asp:TextBox ID="txtChequeDDNo" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr id="trCreditCard1" runat="server" visible="false">
        <td>
            Card Type
        </td>
        <td>
            <asp:DropDownList ID="ddlCardType" runat="server">
                <asp:ListItem Text="-Select-" Value="0"></asp:ListItem>
                <asp:ListItem Text="Visa" Value="1"></asp:ListItem>
                <asp:ListItem Text="MasterCard" Value="2"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr id="trCreditCard2" runat="server" visible="false">
        <td>
            Name on Card
        </td>
        <td>
            <asp:TextBox ID="txtNameOnCard" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr id="trCreditCard3" runat="server" visible="false">
        <td>
            Card Number
        </td>
        <td>
            <asp:TextBox ID="txtCardNumber" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr id="trCVVNo" runat="server" visible="false">
        <td>
            CVV No.
        </td>
        <td>
            <asp:TextBox ID="txtCVVNo" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr id="trCreditCard4" runat="server" visible="false">
        <td>
            Expiration Date
        </td>
        <td>
            <asp:DropDownList ID="ddlCardExpirationMonth" runat="server" SkinID="nowidth" Width="115px">
                <asp:ListItem Text="-Select-" Value="0"></asp:ListItem>
                <asp:ListItem Text="January" Value="1"></asp:ListItem>
                <asp:ListItem Text="February" Value="2"></asp:ListItem>
                <asp:ListItem Text="March" Value="3"></asp:ListItem>
                <asp:ListItem Text="April" Value="4"></asp:ListItem>
                <asp:ListItem Text="May" Value="5"></asp:ListItem>
                <asp:ListItem Text="June" Value="6"></asp:ListItem>
                <asp:ListItem Text="July" Value="7"></asp:ListItem>
                <asp:ListItem Text="August" Value="8"></asp:ListItem>
                <asp:ListItem Text="September" Value="9"></asp:ListItem>
                <asp:ListItem Text="October" Value="10"></asp:ListItem>
                <asp:ListItem Text="November" Value="11"></asp:ListItem>
                <asp:ListItem Text="December" Value="12"></asp:ListItem>
            </asp:DropDownList>
            &nbsp;
            <asp:DropDownList ID="ddlCardExpirationYear" runat="server" SkinID="nowidth" Width="103px">
                <asp:ListItem Text="-Select-" Value="0"></asp:ListItem>
                <asp:ListItem Text="2012" Value="2012"></asp:ListItem>
                <asp:ListItem Text="2013" Value="2013"></asp:ListItem>
                <asp:ListItem Text="2014" Value="2014"></asp:ListItem>
                <asp:ListItem Text="2015" Value="2015"></asp:ListItem>
                <asp:ListItem Text="2016" Value="2016"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr id="trCreditCard5" runat="server" visible="false">
        <td>
        </td>
        <td style="padding: 0px;">
            <asp:RadioButtonList ID="rdbPaymentOrBlock" runat="server" CellPadding="0" CellSpacing="0"
                RepeatColumns="2" RepeatDirection="Horizontal">
                <asp:ListItem Text="Payment" Value="1" Selected="True"></asp:ListItem>
                <asp:ListItem Text="Block" Value="0"></asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Literal ID="litStatus" runat="server" Text="Booking Status"></asp:Literal>
        </td>
        <td>
            <asp:DropDownList ID="ddlStatus" runat="server" OnSelectedIndexChanged="ddlStatus_OnSelectedIndexChanged"
                AutoPostBack="true">
                <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                <asp:ListItem Text="Confirmed" Value="Confirmed"></asp:ListItem>
                <asp:ListItem Text="Provisional" Value="Unconfirmed"></asp:ListItem>
                <asp:ListItem Text="Waiting List" Value="Waiting List"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr id="trAssignRoom" runat="server" visible="false">
        <td>
        </td>
        <td>
            <asp:Button ID="btnAssignRoom" runat="server" Text="Select Room" Style="display: inline;" />
        </td>
    </tr>
    <tr id="trAssignedRoomNo" runat="server" visible="false">
        <td>
            Room No.
        </td>
        <td>
        </td>
    </tr>
</table>
<ajx:ModalPopupExtender ID="mpeAddGuest" runat="server" TargetControlID="hdnGuestName"
    PopupControlID="pnlAddGuest" BackgroundCssClass="mod_background" CancelControlID="imgAddGuest">
</ajx:ModalPopupExtender>
<asp:HiddenField ID="hdnGuestName" runat="server" />
<asp:Panel ID="pnlAddGuest" runat="server" Width="800px" Style="display: none;">
    <div class="box_col1">
        <div class="box_head">
            <div style="display: inline;">
                <span>
                    <asp:Literal ID="ltrHeaderAddGuest" runat="server" Text="Add Guest"></asp:Literal></span>
            </div>
            <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                <asp:ImageButton ID="imgAddGuest" runat="server" ImageUrl="~/images/closepopup.png"
                    Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;" />
            </div>
        </div>
        <div class="clear">
        </div>
        <div class="box_form">
            <table cellpadding="2" cellspacing="2" border="0" width="100%">
                <tr>
                    <td width="75px">
                        <b>
                            <asp:Literal ID="litGuestName" runat="server" Text="Name"></asp:Literal></b>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlGuestTitle" runat="server" Style="width: 80px; height: 25px;">
                            <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                            <asp:ListItem Text="Mr." Value="Mr."></asp:ListItem>
                            <asp:ListItem Text="Mrs." Value="Mrs."></asp:ListItem>
                            <asp:ListItem Text="Ms" Value="Ms"></asp:ListItem>
                        </asp:DropDownList>
                        <span>
                            <asp:RequiredFieldValidator ID="rfvGuestTitle" InitialValue="00000000-0000-0000-0000-000000000000"
                                SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                ValidationGroup="AddGuest" ControlToValidate="ddlGuestTitle" Display="Static">
                            </asp:RequiredFieldValidator>
                        </span>
                        <asp:TextBox ID="txtGuestFirstName" runat="server" MaxLength="150" Style="width: 80px !important;"></asp:TextBox>
                        <ajx:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="txtGuestFirstName"
                            WatermarkText="First Name">
                        </ajx:TextBoxWatermarkExtender>
                        <span>
                            <asp:RequiredFieldValidator ID="rfvGuestFirstName" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                runat="server" ValidationGroup="AddGuest" ControlToValidate="txtGuestFirstName"
                                Display="Static">
                            </asp:RequiredFieldValidator>
                        </span>
                        <asp:TextBox ID="txtGuestLastName" runat="server" MaxLength="150" Style="width: 80px !important;"></asp:TextBox>
                        <asp:TextBox ID="TextBox1" runat="server" MaxLength="150" Style="width: 90px !important;"></asp:TextBox><ajx:TextBoxWatermarkExtender
                            ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtGuestLastName"
                            WatermarkText="Last Name">
                        </ajx:TextBoxWatermarkExtender>
                    </td>
                    <td width="100px">
                        <b>
                            <asp:Literal ID="litMobileNo" runat="server" Text="Mobile No."></asp:Literal></b>
                    </td>
                    <td width="230px">
                        <asp:TextBox ID="tctCode" runat="server" Style="width: 30px !important;"></asp:TextBox>
                        <asp:TextBox ID="txtMobileNo" runat="server" SkinID="nowidth" Width="175px"></asp:TextBox>
                        <ajx:FilteredTextBoxExtender ID="ftMobileNo" runat="server" TargetControlID="txtMobileNo"
                            FilterType="Numbers" />
                        <span>
                            <asp:RequiredFieldValidator ID="rfvMaritalStatus" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                runat="server" ValidationGroup="AddGuest" ControlToValidate="txtMobileNo" Display="Static">
                            </asp:RequiredFieldValidator>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>
                            <asp:Literal ID="litIDType" runat="server" Text="ID Type"></asp:Literal></b>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlIDType" runat="server" Style="width: 175px;">
                            <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                            <asp:ListItem Text="Licence No." Value="Licence No"></asp:ListItem>
                            <asp:ListItem Text="Passport" Value="Passport"></asp:ListItem>
                        </asp:DropDownList>
                        <span>
                            <asp:RequiredFieldValidator ID="rfvIDType" InitialValue="00000000-0000-0000-0000-000000000000"
                                SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                ValidationGroup="AddGuest" ControlToValidate="ddlIDType" Display="Static">
                            </asp:RequiredFieldValidator>
                        </span>
                    </td>
                    <td>
                        <b>
                            <asp:Literal ID="litIDDetail" runat="server" Text="ID Detail"></asp:Literal></b>
                    </td>
                    <td>
                        <asp:TextBox ID="txtIDDetail" runat="server" SkinID="nowidth" Width="175px"></asp:TextBox>
                        <span>
                            <asp:RequiredFieldValidator ID="rfvIDDetail" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                runat="server" ValidationGroup="AddGuest" ControlToValidate="txtIDDetail" Display="Static">
                            </asp:RequiredFieldValidator>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>
                            <asp:Literal ID="litGuestDOB" runat="server" Text="DOB"></asp:Literal></b>
                    </td>
                    <td>
                        <asp:TextBox ID="txtGuestDOB" runat="server" Style="width: 173px;" onkeypress="return false;"></asp:TextBox>
                        <asp:Image ID="imgGuestDOB" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                            Height="20px" Width="20px" />
                        <ajx:CalendarExtender ID="calDOB" PopupButtonID="imgGuestDOB" TargetControlID="txtGuestDOB"
                            runat="server" Format="dd/MMM/yyyy">
                        </ajx:CalendarExtender>
                        <img src="../../images/clear.png" id="imgClearGuestDOB" style="vertical-align: middle;"
                            title="Clear Date" onclick="fnClearDate('<%= txtGuestDOB.ClientID %>');" />
                        <span>
                            <asp:RequiredFieldValidator ID="rfvGuestDOB" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                runat="server" ValidationGroup="AddGuest" ControlToValidate="txtGuestDOB" Display="Static">
                            </asp:RequiredFieldValidator>
                        </span>
                    </td>
                    <td>
                        <b>
                            <asp:Literal ID="litEmail" runat="server" Text="Email"></asp:Literal></b>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" SkinID="nowidth" Width="175px"></asp:TextBox>
                        <span>
                            <asp:RequiredFieldValidator ID="rfvEmail" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                runat="server" ValidationGroup="AddGuest" ControlToValidate="txtEmail" Display="Static">
                            </asp:RequiredFieldValidator>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="regEmailAd" Display="Dynamic" ValidationGroup="AddGuest"
                            runat="server" CssClass="input-notification error png_bg" ErrorMessage="Please Enter Valid Email"
                            ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 200px; overflow: auto; vertical-align: top;">
                        <div class="box_head">
                            <span>
                                <asp:Literal ID="litGuestList" runat="server" Text="Guest List"></asp:Literal>
                            </span>
                        </div>
                        <div class="clear">
                        </div>
                        <div class="box_content">
                            <asp:GridView ID="gvGuestList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
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
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblGvHdrName" runat="server" Text="Name"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "Name")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblGvHdrEmail" runat="server" Text="Email"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "Email")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblGvHdrIDType" runat="server" Text="ID Type"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "IDType")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblGvHdrMobileNo" runat="server" Text="Mobile No."></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "MobileNo")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblGvHdrDOB" runat="server" Text="DOB"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "DOB")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <div style="padding: 10px;">
                                        <b>
                                            <asp:Label ID="lblNoRecordFoundForService" runat="server" Text="No Record Found."></asp:Label>
                                        </b>
                                    </div>
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="4">
                        <asp:Button ID="btnSaveGuest" runat="server" Style="display: inline; padding-right: 10px;"
                            OnClientClick="fnDisplayCatchErrorMessage();" ValidationGroup="AddGuest" Text="Save" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="clear">
        </div>
    </div>
</asp:Panel>
<ucCommonCardInfo:CommonCardInfo ID="CtrlCommonCardInfo" runat="server" />
<asp:HiddenField ID="hfPopupCustomeMessage" runat="server" />
<ajx:ModalPopupExtender ID="mpeCustomePopup" runat="server" TargetControlID="hfPopupCustomeMessage"
    PopupControlID="pnlCustomeMessage" BackgroundCssClass="mod_background" CancelControlID="btnOKCustomeMsgPopup"
    DropShadow="true" BehaviorID="mpeCustomePopup">
</ajx:ModalPopupExtender>
<asp:Panel ID="pnlCustomeMessage" runat="server" Width="350px" Style="display: none;">
    <div class="box_col1">
        <div class="box_head">
            <span>
                <asp:Literal ID="litHeaderCustomePopupMessage" runat="server" Text="Message"></asp:Literal></span></div>
        <div class="clear">
        </div>
        <div class="box_form">
            <table cellpadding="2" cellspacing="2" width="100%">
                <tr>
                    <td align="center" style="padding-bottom: 15px; color: Red;">
                        <asp:Label ID="lblCustomePopupMsg" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btnOKCustomeMsgPopup" runat="server" Text="OK" Style="display: inline;
                            padding-right: 10px;" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="clear">
        </div>
    </div>
</asp:Panel>
<ajx:ModalPopupExtender ID="mpeDeposit" runat="server" TargetControlID="hdnDeposit"
    PopupControlID="pnlDeposit" BackgroundCssClass="mod_background">
</ajx:ModalPopupExtender>
<asp:HiddenField ID="hdnDeposit" runat="server" />
<asp:Panel ID="pnlDeposit" runat="server" Width="900px" Style="display: none;">
    <ucAddDeposit:CtrlCommonAddDeposit ID="CtrlCommonAddDeposit1" runat="server" OnbtnAddDepositCallParent_Click="btnAddDepositCallParent_Click" />
</asp:Panel>
<ajx:ModalPopupExtender ID="mpeSearchGuestInfo" runat="server" TargetControlID="hdnSearchGuestInfo"
    PopupControlID="pnlSearchGuestInfo" BackgroundCssClass="mod_background">
</ajx:ModalPopupExtender>
<asp:HiddenField ID="hdnSearchGuestInfo" runat="server" />
<asp:Panel ID="pnlSearchGuestInfo" runat="server" Width="800px" Style="display: none;">
    <div class="box_col1">
        <div class="box_head">
            <span>
                <asp:Literal ID="Literal1" runat="server" Text="Guest List"></asp:Literal></span></div>
        <div class="clear">
        </div>
        <div class="box_form">
            <table cellpadding="2" cellspacing="2" border="0" width="100%">
                <tr>
                    <td width="75px">
                        <asp:Literal ID="litSearchGuestName" runat="server" Text="Name"></asp:Literal>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSearchGuestName" runat="server"></asp:TextBox>
                        <%--<span>
                            <asp:RequiredFieldValidator ID="rfvSearchGuestName" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                runat="server" ValidationGroup="SearchGuest" ControlToValidate="txtSearchGuestName"
                                Display="Static">
                            </asp:RequiredFieldValidator>
                        </span>--%>
                    </td>
                    <td>
                        <asp:Literal ID="litSearchMobileNo" runat="server" Text="Mobile No."></asp:Literal>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSearchMobileNo" runat="server"></asp:TextBox>
                        <ajx:FilteredTextBoxExtender ID="ftSearchMobileNo" runat="server" TargetControlID="txtSearchMobileNo"
                            ValidChars="0123456789" FilterMode="ValidChars">
                        </ajx:FilteredTextBoxExtender>
                        <asp:ImageButton ID="btnSearchGuest" runat="server" ImageUrl="~/images/search-icon.png"
                            Style="border: 0px; margin: -4px 0 0 5px; vertical-align: middle;" OnClick="btnSearchGuest_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 300px; overflow: auto; vertical-align: top;">
                        <div class="box_head">
                            <span>
                                <asp:Literal ID="Literal8" runat="server" Text="Guest List"></asp:Literal>
                            </span>
                        </div>
                        <div class="clear">
                        </div>
                        <div class="box_content">
                            <asp:GridView ID="gvSearchGuestList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                Width="100%" SkinID="gvNoPaging" OnRowCommand="gvSearchGuestList_RowCommand">
                                <Columns>
                                    <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblGvHdrSearchGuestSrNo" runat="server" Text="No."></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="110px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblGvHdrSearchGuestName" runat="server" Text="Name"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkSearchGuestName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Name")%>'
                                                CommandName="SEARCHGUEST" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "Name")%>'></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblGvHdrSearchGuestMobileNo" runat="server" Text="Mobile No."></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "MobileNo")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblGvHdrSearchGuestEmail" runat="server" Text="Email"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "Email")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblGvHdrSearchGuestCountry" runat="server" Text="Country"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "Country")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblGvHdrSearchGuestState" runat="server" Text="State"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "State")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblGvHdrSearchGuestCity" runat="server" Text="City"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "City")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblGvHdrSearchGuestDOB" runat="server" Text="DOB"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "DOB")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <div style="padding: 10px;">
                                        <b>
                                            <asp:Label ID="lblNoRecordFoundForSearchGuest" runat="server" Text="No Record Found."></asp:Label>
                                        </b>
                                    </div>
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="4">
                        <asp:Button ID="btnSearchGuestSave" runat="server" Style="display: inline; padding-right: 10px;"
                            ValidationGroup="SearchGuest" Text="Save" />
                        <asp:Button ID="btnSearchGuestCancel" runat="server" Style="display: inline;" Text="Cancel" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="clear">
        </div>
    </div>
</asp:Panel>
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
