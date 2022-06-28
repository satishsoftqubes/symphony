<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrCommonInvBookingGuestInfo.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls.CtrCommonInvBookingGuestInfo" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonCardInfo.ascx" TagName="CommonCardInfo"
    TagPrefix="ucCommonCardInfo" %>
<%@ Register Src="../Folio/CtrlCommonAddDeposit.ascx" TagName="CtrlCommonAddDeposit"
    TagPrefix="ucAddDeposit" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript">
    function Clear() {
        document.getElementById('<%= txtCountryName.ClientID %>').value = document.getElementById('<%= txtStateName.ClientID %>').value = document.getElementById('<%= txtCityName.ClientID %>').value = document.getElementById('<%= txtZipCode.ClientID %>').value = document.getElementById('<%= txtAddress.ClientID %>').value = document.getElementById('<%= txtMobile.ClientID %>').value = document.getElementById('<%= txtFirstName.ClientID %>').value = document.getElementById('<%= txtLastName.ClientID %>').value = document.getElementById('<%= txtEmail1.ClientID %>').value = "";
        document.getElementById('<%= ddlTitle.ClientID %>').selectedIndex = document.getElementById('<%= ddlStatus.ClientID %>').selectedIndex = document.getElementById('<%= ddlPMT.ClientID %>').selectedIndex = document.getElementById('<%= ddlStayType.ClientID %>').selectedIndex = document.getElementById('<%= ddlNationality1.ClientID %>').selectedIndex = 0;
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

        if (Type == 'CARD') {
            if (document.getElementById("<%=ddlPMT.ClientID%>").selectedIndex == 0) {
                document.getElementById("<%=lblCustomePopupMsg.ClientID%>").innerHTML = "Please Select Payment Type";
                $find('mpeCustomePopup').show();
                return false;
            }
        }
    }

    //    function fntest() {
    //        if ($('#foo').is(':hidden')) {
    //            document.getElementById("foo").style.display = "block";
    //            document.getElementById('imgExtraInfo').src = "../../images/plus_minus.png";
    //            return false;
    //        }
    //        else {
    //            // it's not hidden so do something else
    //            document.getElementById("foo").style.display = "none";
    //            document.getElementById('imgExtraInfo').src = "../../images/plus_button.png";
    //            return false;
    //        }
    //    }
</script>
<table cellpadding="2" cellspacing="2" border="0" width="100%">
    <tr>
        <td colspan="4">
            <b>
                <asp:Literal ID="litGuestInformation" runat="server" Text="Guest Information"></asp:Literal></b>
            <hr />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Literal ID="ltrInvestor" runat="server" Text="Investor"></asp:Literal>
        </td>
        <td>
            <asp:DropDownList ID="ddlInvestor" runat="server" AutoPostBack="true" Style="width: 224px;
                height: 25px;" OnSelectedIndexChanged="ddlInvestor_OnSelectedIndexChanged">
                <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                <asp:ListItem Text="Mr. Pradeep Patel" Value="0"></asp:ListItem>
                <asp:ListItem Text="Mr. Shyam Benegal" Value="1"></asp:ListItem>
            </asp:DropDownList>
            <span>
                <asp:RequiredFieldValidator ID="rfvInvestor" InitialValue="00000000-0000-0000-0000-000000000000"
                    SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                    ValidationGroup="IsRequire" ControlToValidate="ddlInvestor" Display="Dynamic">
                </asp:RequiredFieldValidator>
            </span>
        </td>
    </tr>
    <tr>
        <td class="isrequire">
            <asp:Literal ID="litStayType" runat="server" Text="Stay Type"></asp:Literal>
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
            <asp:Literal ID="litNationality1" runat="server" Text="Nationality"></asp:Literal>
        </td>
        <td>
            <asp:DropDownList ID="ddlNationality1" runat="server" Style="width: 224px; height: 25px;">
                <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                <asp:ListItem Text="Indian" Value="Indian"></asp:ListItem>
            </asp:DropDownList>
            <span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" InitialValue="00000000-0000-0000-0000-000000000000"
                    SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                    ValidationGroup="IsRequire" ControlToValidate="ddlNationality1" Display="Dynamic">
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
                <asp:DropDownList ID="ddlTitle" runat="server" Style="width: 50px; height: 25px;">
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
                <asp:TextBox ID="txtFirstName" runat="server" MaxLength="150" Style="width: 90px !important;"></asp:TextBox>
                <ajx:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtFirstName"
                    WatermarkText="First Name">
                </ajx:TextBoxWatermarkExtender>
                <span>
                    <asp:RequiredFieldValidator ID="rvfFirstName" SetFocusOnError="true" CssClass="input-notification error png_bg"
                        runat="server" ValidationGroup="IsRequire" ControlToValidate="txtFirstName" Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </span>
                <asp:TextBox ID="txtLastName" runat="server" MaxLength="150" Style="width: 90px !important;"></asp:TextBox>
                <ajx:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="txtLastName"
                    WatermarkText="Last Name">
                </ajx:TextBoxWatermarkExtender>
                &nbsp;&nbsp;&nbsp;
            </div>
            <%-- <div style="float: left;">
                <asp:Button ID="btnAddGuest" runat="server" Text="+" OnClick="btnAddGuest_Click" />
            </div>--%>
            <div style="float: left;">
                <%-- <asp:Button ID="btnSearchGuestInfo" runat="server" Text="S" OnClick="btnSearchGuestInfo_Click"
                    Style="margin-left: 3px;" />--%>
                <%--<asp:ImageButton ID="btnSearchGuestInfo" runat="server" ImageUrl="~/images/001_38.gif" OnClick="btnSearchGuestInfo_Click" />--%>
                <asp:ImageButton ID="imgSearchGuestInfo" runat="server" ImageUrl="~/images/001_38.gif"
                    OnClick="btnSearchGuestInfo_Click" Style="margin-top: 3px; border: none;" />
            </div>
            <div style="float: left;">
                <asp:Button ID="btnAddGuest" runat="server" Text="+" OnClick="btnAddGuest_Click"
                    Style="margin-left: 5px;" />
            </div>
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
        </td>
    </tr>
    <tr>
        <td>
            <asp:Literal ID="litMobile" runat="server" Text="Mobile No."></asp:Literal>
        </td>
        <td>
            <asp:TextBox ID="txtCode" Style="width: 30px !important;" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Literal ID="litEmail1" runat="server" Text="Email"></asp:Literal>
        </td>
        <td>
            <asp:TextBox ID="txtEmail1" runat="server"></asp:TextBox>
            <span>
                <asp:RegularExpressionValidator ID="revEmail1" Display="Dynamic" ValidationGroup="IsRequire"
                    runat="server" ErrorMessage="Please Enter Valid Email" ForeColor="Red" ControlToValidate="txtEmail1"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </span>
        </td>
    </tr>
    <tr>
        <td style="vertical-align: top;">
            <asp:Literal ID="litAddress" runat="server" Text="Address"></asp:Literal>
        </td>
        <td>
            <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Rows="2"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Literal ID="litZipCode" runat="server" Text="ZipCode"></asp:Literal>
        </td>
        <td>
            <asp:TextBox ID="txtZipCode" runat="server"></asp:TextBox>
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
            <%-- <div style="float: left;">--%>
            <%--<a href="#" onclick="return fntest();" style="margin-left: 15px;">--%><%--<img src="../../images/plus_button.png"
                    title="Extra Info" id="imgExtraInfo" onclick="fntest();" />--%><%--</a>--%>
            <%--<asp:Button ID="btnExtraInfo" runat="server" Text="Extra Info" OnClientClick="return fntest();" Style="margin-left: 15px;" />--%>
            <%--</div>--%>
        </td>
    </tr>
    <%-- <tr>
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
                            <asp:Literal ID="Literal1" runat="server" Text="DOB"></asp:Literal>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDOB" runat="server" onkeypress="return false;"></asp:TextBox>
                            <asp:Image ID="imgDOB" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                Height="20px" Width="20px" />
                            <ajx:CalendarExtender ID="CalendarExtender1" PopupButtonID="imgDOB" TargetControlID="txtDOB"
                                runat="server" Format="dd/MMM/yyyy">
                            </ajx:CalendarExtender>
                            <img src="../../images/clear.png" id="img1" style="vertical-align: middle;" title="Clear Date"
                                onclick="fnClearDate('<%= txtDOB.ClientID %>');" />
                        </td>
                    </tr>
                </table>
            </div>
        </td>
    </tr>--%>
    <tr>
        <td colspan="2">
            <b>
                <asp:Literal ID="litPayment" runat="server" Text="Payment"></asp:Literal></b>
            <hr />
        </td>
    </tr>
    <tr>
        <td class="isrequire" style="width: 80px !important;">
            <asp:Literal ID="litPMT" runat="server" Text="PMT"></asp:Literal>
        </td>
        <td>
            <div style="float: left; padding-right: 13px;">
                <asp:DropDownList ID="ddlPMT" runat="server">
                    <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                    <asp:ListItem Text="Cash" Value="Cash"></asp:ListItem>
                    <asp:ListItem Text="Card" Value="Card"></asp:ListItem>
                    <asp:ListItem Text="Cheque" Value="Cheque"></asp:ListItem>
                    <asp:ListItem Text="BACS" Value="BACS"></asp:ListItem>
                    <asp:ListItem Text="CAPS" Value="CAPS"></asp:ListItem>
                    <asp:ListItem Text="Direct Bill" Value="Direct Bill"></asp:ListItem>
                </asp:DropDownList>
                <span>
                    <asp:RequiredFieldValidator ID="rfvPMT" InitialValue="00000000-0000-0000-0000-000000000000"
                        SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                        ValidationGroup="IsRequire" ControlToValidate="ddlPMT" Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </span>
            </div>
            <div style="float: left;">
                <asp:Button ID="btnAddCardDetails" runat="server" Text="+" OnClick="btnAddCardDetails_Click"
                    OnClientClick="return validate('CARD');" />
            </div>
            <div style="float: left; padding-left: 15px;">
                <asp:Button ID="btnAddDeposit" runat="server" Text="Deposit" OnClick="btnAddDeposit_Click" />
            </div>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Literal ID="litStatus" runat="server" Text="Status"></asp:Literal>
        </td>
        <td>
            <asp:DropDownList ID="ddlStatus" runat="server">
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
        </td>
    </tr>
</table>
<ajx:ModalPopupExtender ID="mpeAddGuest" runat="server" TargetControlID="hdnGuestName"
    PopupControlID="pnlAddGuest" BackgroundCssClass="mod_background" CancelControlID="imgCancelAddGuest">
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
                <asp:ImageButton ID="imgCancelAddGuest" runat="server" ImageUrl="~/images/closepopup.png"
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
                        <ajx:TextBoxWatermarkExtender ID="txtwmeFirstName" runat="server" TargetControlID="txtGuestFirstName"
                            WatermarkText="First Name">
                        </ajx:TextBoxWatermarkExtender>
                        <span>
                            <asp:RequiredFieldValidator ID="rfvGuestFirstName" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                runat="server" ValidationGroup="AddGuest" ControlToValidate="txtGuestFirstName"
                                Display="Static">
                            </asp:RequiredFieldValidator>
                        </span>
                        <asp:TextBox ID="txtGuestLastName" runat="server" MaxLength="150" Style="width: 80px !important;"></asp:TextBox>
                        <ajx:TextBoxWatermarkExtender ID="txtwmeLastName" runat="server" TargetControlID="txtGuestLastName"
                            WatermarkText="Last Name">
                        </ajx:TextBoxWatermarkExtender>
                    </td>
                    <td width="100px">
                        <b>
                            <asp:Literal ID="litMaritalStatus" runat="server" Text="Marital Status"></asp:Literal></b>
                    </td>
                    <td width="230px">
                        <asp:DropDownList ID="ddlMaritalStatus" runat="server" Style="width: 175px;">
                            <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                            <asp:ListItem Text="Married" Value="Married"></asp:ListItem>
                            <asp:ListItem Text="Single" Value="Single"></asp:ListItem>
                        </asp:DropDownList>
                        <span>
                            <asp:RequiredFieldValidator ID="rfvMaritalStatus" InitialValue="00000000-0000-0000-0000-000000000000"
                                SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                ValidationGroup="AddGuest" ControlToValidate="ddlMaritalStatus" Display="Static">
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
                        <asp:TextBox ID="txtIDDetail" runat="server" Style="width: 173px;"></asp:TextBox>
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
                            <asp:Literal ID="litDOB" runat="server" Text="DOB"></asp:Literal></b>
                    </td>
                    <td>
                        <asp:TextBox ID="txtGuestDOB" runat="server" Style="width: 173px;" onkeypress="return false;"></asp:TextBox>
                        <asp:Image ID="imgGuestDOB" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                            Height="20px" Width="20px" />
                        <ajx:CalendarExtender ID="calGuestDOB" PopupButtonID="imgGuestDOB" TargetControlID="txtGuestDOB"
                            runat="server" Format="dd/MMM/yyyy">
                        </ajx:CalendarExtender>
                        <img src="../../images/clear.png" id="imgClearDOB" style="vertical-align: middle;"
                            title="Clear Date" onclick="fnClearDate('<%= txtGuestDOB.ClientID %>');" />
                        <span>
                            <asp:RequiredFieldValidator ID="rfvGuestDOB" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                runat="server" ValidationGroup="AddGuest" ControlToValidate="txtGuestDOB" Display="Static">
                            </asp:RequiredFieldValidator>
                        </span>
                    </td>
                    <td>
                        <b>
                            <asp:Literal ID="litNationality" runat="server" Text="Nationality"></asp:Literal></b>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlNationality" runat="server" Style="width: 175px;">
                            <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                            <asp:ListItem Text="American" Value="American"></asp:ListItem>
                            <asp:ListItem Text="Indian" Value="Indian"></asp:ListItem>
                        </asp:DropDownList>
                        <span>
                            <asp:RequiredFieldValidator ID="rfvNationality" InitialValue="00000000-0000-0000-0000-000000000000"
                                SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                ValidationGroup="AddGuest" ControlToValidate="ddlNationality" Display="Static">
                            </asp:RequiredFieldValidator>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
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
                <asp:Literal ID="Literal2" runat="server" Text="Guest List"></asp:Literal></span></div>
        <div class="clear">
        </div>
        <div class="box_form">
            <table cellpadding="2" cellspacing="2" border="0" width="100%">
                <tr>
                    <td width="75px">
                        <asp:Literal ID="litSearchGuestName" runat="server" Text="Guest Name"></asp:Literal>
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
