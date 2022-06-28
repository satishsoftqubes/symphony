<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlAmendReservation.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation.CtrlAmendReservation" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<%@ Register Src="~/UIControls/Reservation/CtrlReservationVoucher.ascx" TagName="ReservationVoucher"
    TagPrefix="ucCtrlReservationVoucher" %>
<script src="../../Scripts/Common.js"></script>
<script src="../../Scripts/jquery-1.8.2.js"></script>
<script src="../../Scripts/jquery-ui.js"></script>
<style>
    fieldset, img
    {
        border: 0 none;
        vertical-align: middle;
    }
    .img
    {
        vertical-align: middle;
    }
</style>
<script type="text/javascript" language="javascript">
    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function pageLoad(sender, args) {
        var v1 = '<%=ConfigurationManager.AppSettings["IsUpperCase"].ToString() %>'
        if (v1 == "1") {
            $('input[type="text"],textarea').each(function () { $(this).css("text-transform", "uppercase") });
        }
        $(function () {
            var dateToday = new Date();

            $("#<%= txtCheckInDate.ClientID %>").datepicker({
                changeMonth: true,
                numberOfMonths: 1,
                minDate: dateToday,
                showOn: "button",
                dateFormat: "dd-mm-yy",
                buttonImage: "../../images/CalanderIcon.png",
                buttonImageOnly: true,
                onSelect: function (selectedDate) {
                    $("#<%= txtCheckOutDate.ClientID %>").datepicker("option", "minDate", selectedDate);
                }
            });
            $("#<%= txtCheckOutDate.ClientID %>").datepicker({
                changeMonth: true,
                numberOfMonths: 1,
                minDate: dateToday,
                dateFormat: "dd-mm-yy",
                showOn: "button",
                buttonImage: "../../images/CalanderIcon.png",
                buttonImageOnly: true,
                onSelect: function (selectedDate) {
                    $("#<%= txtCheckInDate.ClientID %>").datepicker("option", "maxDate", selectedDate);
                }
            });
        });
    }

    function Clear() {
        document.getElementById('<%= txtCountryName.ClientID %>').value = document.getElementById('<%= txtStateName.ClientID %>').value = document.getElementById('<%= txtCityName.ClientID %>').value = document.getElementById('<%= txtZipCode.ClientID %>').value = document.getElementById('<%= txtAddressLine1.ClientID %>').value = document.getElementById('<%= txtMobile.ClientID %>').value = document.getElementById('<%= txtFirstName.ClientID %>').value = document.getElementById('<%= txtLastName.ClientID %>').value = document.getElementById('<%= txtGuestEmail.ClientID %>').value = "";
        document.getElementById('<%= ddlTitle.ClientID %>').selectedIndex = document.getElementById('<%= ddlBookingStatus.ClientID %>').selectedIndex = document.getElementById('<%= ddlNationality.ClientID %>').selectedIndex = 0;
    }

    function CopyName() {
        var title = document.getElementById('<%=ddlTitle.ClientID%>').value;
        var fname = document.getElementById('<%=txtFirstName.ClientID%>').value;
        var lname = document.getElementById('<%=txtLastName.ClientID%>').value;

        if (title == '00000000-0000-0000-0000-000000000000') {
            title = '';
        }

        if (title != '' && fname != '' && fname.toUpperCase() != 'FIRST NAME') {
            if (lname != '' && lname.toUpperCase() != 'LAST NAME') {
                document.getElementById('<%=txtBookedBy.ClientID%>').value = title + ' ' + fname + ' ' + lname;
            }
            else {
                document.getElementById('<%=txtBookedBy.ClientID%>').value = title + ' ' + fname;
            }
        }
        else {
            document.getElementById('<%=txtBookedBy.ClientID%>').value = '';
        }
        return false
    }


    function fnFindBlackListGuest() {

        var pageUrl = '<%=ResolveUrl("~/GUI/Reservation/FindBlackList.asmx")%>';
        var title = document.getElementById('<%=ddlTitle.ClientID%>').value;
        var fname = document.getElementById('<%=txtFirstName.ClientID%>').value;
        var lname = document.getElementById('<%=txtLastName.ClientID%>').value;
        var guestname = null;
        var email = document.getElementById('<%=txtGuestEmail.ClientID%>').value;
        var code = document.getElementById('<%=txtCountryMobileCode.ClientID%>').value;
        var mobileno = document.getElementById('<%=txtMobile.ClientID%>').value;

        var strMessage = '';

        if (title == '00000000-0000-0000-0000-000000000000') {
            strMessage = 'Please Select Title';
        }

        if (fname != '' && fname.toUpperCase() == 'FIRST NAME') {
            strMessage = strMessage + '\nFirst Name is Required';
        }

        if (lname != '' && lname.toUpperCase() == 'LAST NAME') {
            strMessage = strMessage + '\nLast Name is Required';
        }

        if (email == '') {
            email = null;
        }

        if (mobileno == '') {
            strMessage = strMessage + '\nMobile No. is Required';
        }

        if (mobileno.length < 10) {
            strMessage = strMessage + '\nMobile No. must be 10 digits number';
        }

        if (strMessage != '') {
            alert(strMessage);
            return;
        }

        if (code != '' && mobileno != '') {
            mobileno = code + "-" + mobileno;
        }

        guestname = title + " " + fname + " " + lname;

        $.ajax({
            type: "POST",
            url: pageUrl + "/SelectBlackListData",
            data: JSON.stringify({ strTitle: title, strFirstName: fname, strLastName: lname, strMobilNo: mobileno, strEmail: email }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccessCall,
            error: OnErrorCall
        });

        return false;
    }


    function OnSuccessCall(response) {
        if (response.d == false) {
            document.getElementById('<%=lblBlackListMessage.ClientID %>').innerHTML = '';
            document.getElementById('<%=hdnIsBlackList.ClientID%>').value = 'NO';
            return false;
        }
        else if (response.d == true) {
            document.getElementById('trBlackListMessage').style.display = 'block';
            document.getElementById('<%=lblBlackListMessage.ClientID %>').innerHTML = 'This Guest is in Black List.';
            document.getElementById('<%=hdnIsBlackList.ClientID%>').value = 'YES';
            return false;
        }
    }


    function OnErrorCall(response) {
        alert(response.d);
        return false;
    }

</script>
<asp:UpdatePanel ID="updReservation" runat="server">
    <ContentTemplate>
        <asp:HiddenField ID="hdnCalRateCheckInDate" runat="server" />
        <asp:HiddenField ID="hdnCalRateCheckOutDate" runat="server" />
        <asp:HiddenField ID="hdnCalRateRoomType" runat="server" />
        <asp:HiddenField ID="hdnCalRateRateCard" runat="server" />
        <asp:HiddenField ID="hdnCalRateAdult" runat="server" />
        <asp:HiddenField ID="hdnCalRateChild" runat="server" />
        <asp:HiddenField ID="hdnCalRateInfant" runat="server" />
        <asp:HiddenField ID="hdnRateCardAVBLTCheckInDate" runat="server" />
        <asp:HiddenField ID="hdnRateCardAVBLTCheckOutDate" runat="server" />
        <asp:HiddenField ID="hdnIsBlackList" runat="server" />
        <asp:HiddenField ID="hdnRoomID" runat="server" />
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="content" style="padding-left: 0px; width: 66.66%">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                <asp:Literal ID="Literal1" runat="server" Text="AMEND RESERVATION"></asp:Literal>
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
                                            <td width="50%" style="vertical-align: top; border-right: 1px solid #ccccce;">
                                                <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                    <tr>
                                                        <td colspan="4">
                                                            <b>
                                                                <asp:Literal ID="litStayInformation" runat="server" Text="Stay Information"></asp:Literal></b>
                                                            <hr />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="isrequire">
                                                            <asp:Literal ID="litCheckInDate" runat="server" Text="Check In"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCheckInDate" runat="server" onkeydown="return stopKey(event);"></asp:TextBox>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvCheckInDate" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                    runat="server" ValidationGroup="IsRequire" ControlToValidate="txtCheckInDate"
                                                                    Display="Dynamic">
                                                                </asp:RequiredFieldValidator>
                                                            </span><span>
                                                                <asp:RequiredFieldValidator ID="rfvCheckIn4CalRate" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                    runat="server" ValidationGroup="IsRequire4CalculateRate" ControlToValidate="txtCheckInDate"
                                                                    Display="Dynamic">
                                                                </asp:RequiredFieldValidator>
                                                            </span><span>
                                                                <asp:RequiredFieldValidator ID="rfvCheckIn4RateAvailability" SetFocusOnError="true"
                                                                    CssClass="input-notification error png_bg" runat="server" ValidationGroup="IsRequire4CheckIn4RateAvailability"
                                                                    ControlToValidate="txtCheckInDate" Display="Dynamic">
                                                                </asp:RequiredFieldValidator>
                                                            </span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="isrequire">
                                                            <asp:Literal ID="litCheckOutDate" runat="server" Text="Check Out"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCheckOutDate" runat="server" onkeydown="return stopKey(event);"></asp:TextBox>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvCheckOutDate" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                    runat="server" ValidationGroup="IsRequire" ControlToValidate="txtCheckOutDate"
                                                                    Display="Dynamic">
                                                                </asp:RequiredFieldValidator>
                                                            </span><span>
                                                                <asp:RequiredFieldValidator ID="rfvCheckOut4CalRate" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                    runat="server" ValidationGroup="IsRequire4CalculateRate" ControlToValidate="txtCheckOutDate"
                                                                    Display="Dynamic">
                                                                </asp:RequiredFieldValidator>
                                                            </span><span>
                                                                <asp:RequiredFieldValidator ID="rfvCheckOut4RateAvailability" SetFocusOnError="true"
                                                                    CssClass="input-notification error png_bg" runat="server" ValidationGroup="IsRequire4CheckIn4RateAvailability"
                                                                    ControlToValidate="txtCheckOutDate" Display="Dynamic">
                                                                </asp:RequiredFieldValidator>
                                                            </span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="isrequire">
                                                            <asp:Literal ID="litRoomType" runat="server" Text="Room Type"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlRoomType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlRoomType_OnSelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvRoomType" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                    ValidationGroup="IsRequire" ControlToValidate="ddlRoomType" Display="Dynamic">
                                                                </asp:RequiredFieldValidator>
                                                            </span><span>
                                                                <asp:RequiredFieldValidator ID="rfvRoomType4CalRate" SetFocusOnError="true" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                    CssClass="input-notification error png_bg" runat="server" ValidationGroup="IsRequire4CalculateRate"
                                                                    ControlToValidate="ddlRoomType" Display="Dynamic">
                                                                </asp:RequiredFieldValidator>
                                                            </span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="Literal12" runat="server" Text="Reservation Ref."></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlBookingReference" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBookingReference_OnSelectedIndexChanged">
                                                                <asp:ListItem Text="-SELECT-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                                <asp:ListItem Text="Company" Value="COMPANY"></asp:ListItem>
                                                                <asp:ListItem Text="Agent" Value="AGENT"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litCorporate" runat="server" Text="Company"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlCompany" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCompany_OnSelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="isrequire">
                                                            <asp:Literal ID="litRateCard" runat="server" Text="Rate Card"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlRateCard" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlRateCard_OnSelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvRateCard" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                    ValidationGroup="IsRequire" ControlToValidate="ddlRateCard" Display="Dynamic">
                                                                </asp:RequiredFieldValidator>
                                                            </span><span>
                                                                <asp:RequiredFieldValidator ID="rfvRateCard4CalRate" SetFocusOnError="true" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                    CssClass="input-notification error png_bg" runat="server" ValidationGroup="IsRequire4CalculateRate"
                                                                    ControlToValidate="ddlRateCard" Display="Dynamic">
                                                                </asp:RequiredFieldValidator>
                                                            </span>&nbsp;&nbsp;&nbsp;
                                                            <asp:LinkButton ID="lnkCheckRateCardAvailability" runat="server" Text="Check Availability"
                                                                ValidationGroup="IsRequire4CheckIn4RateAvailability" OnClick="lnkCheckRateCardAvailability_OnClick"
                                                                Style="display: inline;"></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="isrequire">
                                                            <asp:Literal ID="litAdult" runat="server" Text="Adult"></asp:Literal>
                                                        </td>
                                                        <td style="vertical-align: middle;" class="NumericDropdown">
                                                            <asp:TextBox ID="txtAdult" runat="server" MaxLength="3"></asp:TextBox>
                                                            <ajx:NumericUpDownExtender ID="AdultNUDE" runat="server" TargetControlID="txtAdult"
                                                                Width="60" Minimum="1" Maximum="999" />
                                                            <ajx:FilteredTextBoxExtender ID="ftAdult" runat="server" TargetControlID="txtAdult"
                                                                FilterType="Numbers" />
                                                            &nbsp;&nbsp;&nbsp;
                                                            <asp:Literal ID="litChild" runat="server" Text="Child"></asp:Literal>&nbsp;&nbsp;&nbsp;
                                                            <asp:TextBox ID="txtChild" runat="server" MaxLength="3"></asp:TextBox>
                                                            <ajx:NumericUpDownExtender ID="ChildNUDE" runat="server" TargetControlID="txtChild"
                                                                Width="60" Minimum="0" Maximum="999" />
                                                            <ajx:FilteredTextBoxExtender ID="ftChild" runat="server" TargetControlID="txtChild"
                                                                FilterType="Numbers" />
                                                            &nbsp;&nbsp;&nbsp;
                                                            <asp:Literal ID="litInf" runat="server" Text="Inf"></asp:Literal>&nbsp;&nbsp;&nbsp;
                                                            <asp:TextBox ID="txtInfant" runat="server" MaxLength="3"></asp:TextBox>
                                                            <ajx:NumericUpDownExtender ID="InfNUDE" runat="server" TargetControlID="txtInfant"
                                                                Width="60" Minimum="0" Maximum="999" />
                                                            <ajx:FilteredTextBoxExtender ID="ftInfo" runat="server" TargetControlID="txtInfant"
                                                                FilterType="Numbers" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="Literal2" runat="server" Text="Guest Type"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList runat="server" ID="ddlGuestType" AutoPostBack="true" OnSelectedIndexChanged="ddlGuestType_OnSelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="Literal3" runat="server" Text="Source of Business"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList runat="server" ID="ddlSourceOfBusiness">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding-left: 0px; padding-top: 10px;" colspan="2">
                                                            <b>Specific Instructions</b>
                                                            <hr />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Smoking
                                                        </td>
                                                        <td style="padding: 0px;">
                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td style="padding: 0px">
                                                                        <asp:RadioButtonList ID="rdbLIsSmoking" runat="server" RepeatDirection="Horizontal"
                                                                            RepeatColumns="2">
                                                                            <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                                                            <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                    </td>
                                                                    <td width="60px">
                                                                        Pickup
                                                                    </td>
                                                                    <td style="padding: 0px;">
                                                                        <asp:RadioButtonList ID="rdbIsPicup" runat="server" RepeatDirection="Horizontal"
                                                                            RepeatColumns="2">
                                                                            <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                                                            <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 115px;">
                                                            Standard Instruction
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtStandardInstruction" runat="server" Enabled="false" TextMode="MultiLine"
                                                                SkinID="nowidth" Width="334px" Height="35px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="vertical-align: top;">
                                                            Specific Instruction
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtSpecificInstruction" runat="server" SkinID="nowidth" Width="334px"
                                                                Height="35px" TextMode="MultiLine"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <hr />
                                                            <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                                <tr>
                                                                    <td width="75px">
                                                                        <b>
                                                                            <asp:Label ID="lblPaidAmount" runat="server" Text="Paid Amount"></asp:Label></b>
                                                                    </td>
                                                                    <td width="75px">
                                                                        <asp:Label ID="lblDispalyPaidAmount" runat="server" Text="0.00"></asp:Label>
                                                                    </td>
                                                                    <td width="95px">
                                                                        <asp:Label ID="Label1" runat="server" Text="Booking Status"></asp:Label>
                                                                    </td>
                                                                    <td width="95px">
                                                                        <asp:Label ID="lblDisplayBookingStatus" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td width="65px">
                                                                        <asp:Literal ID="Literal10" runat="server" Text="Room No."></asp:Literal>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblDisplayRoomNo" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <hr />
                                                            <div style="float: left; width: auto; display: inline-block;">
                                                                <asp:Button ID="btnCalRate" runat="server" Style="float: left; padding-left: 10px;"
                                                                    Text="Calculate Rate" ValidationGroup="IsRequire4CalculateRate" OnClick="btnCalculateRate_OnClick" />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="padding: 0px;">
                                                            <table id="tblRateCalculation" runat="server" border="0" visible="true" width="70%">
                                                                <tr>
                                                                    <td width="180px">
                                                                        <b>Particulars</b>
                                                                    </td>
                                                                    <td width="100px">
                                                                        <b>No. of Nights</b>
                                                                    </td>
                                                                    <td align="right" width="150px">
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
                                                                    <td>
                                                                        <asp:Label ID="lblReservationDays" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="right">
                                                                        <asp:Label ID="lblRackRate" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        Tax
                                                                    </td>
                                                                    <td>
                                                                        -
                                                                    </td>
                                                                    <td align="right">
                                                                        <asp:Label ID="lblTotalTax" runat="server"></asp:Label>
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
                                                                    <td>
                                                                        -
                                                                    </td>
                                                                    <td align="right">
                                                                        <b>
                                                                            <asp:Label ID="lblTotalCharges" runat="server"></asp:Label></b>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        Deposit
                                                                    </td>
                                                                    <td>
                                                                        -
                                                                    </td>
                                                                    <td align="right">
                                                                        <asp:Label ID="lblDeposit" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding: 0px;" colspan="3">
                                                                        <hr />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <b>Amount Due</b>
                                                                    </td>
                                                                    <td>
                                                                        -
                                                                    </td>
                                                                    <td align="right">
                                                                        <b>
                                                                            <asp:Label ID="lblTotalAmount" runat="server"></asp:Label></b>
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
                                                            <asp:Literal ID="Literal4" runat="server" Text="Reference By"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlComplementoryRefBy" runat="server" Style="width: 224px;
                                                                height: 25px;" AutoPostBack="true" OnSelectedIndexChanged="ddlComplementoryRefBy_OnSelectedIndexChanged">
                                                                <asp:ListItem Selected="True" Text="-SELECT-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                                <asp:ListItem Text="CEO" Value="CEO"></asp:ListItem>
                                                                <asp:ListItem Text="GM" Value="GM"></asp:ListItem>
                                                                <asp:ListItem Text="INVESTOR" Value="INVESTOR"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr id="trInvestors" runat="server" visible="false">
                                                        <td class="isrequire">
                                                            <asp:Literal ID="Literal5" runat="server" Text="Investor"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlInvestor" runat="server" AutoPostBack="true" Style="width: 224px;
                                                                height: 25px;" OnSelectedIndexChanged="ddlInvestor_OnSelectedIndexChanged">
                                                                <asp:ListItem Selected="True" Text="-SELECT-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                                <asp:ListItem Text="Mr. Pradeep Patel" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="Mr. Shyam Benegal" Value="1"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr id="trToHide" runat="server" visible="false">
                                                        <td class="isrequire">
                                                            <asp:Literal ID="litStayType" runat="server" Text="*Stay Type"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlStayType" runat="server" Style="width: 224px; height: 25px;">
                                                                <asp:ListItem Selected="True" Text="-SELECT-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
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
                                                            <asp:DropDownList ID="ddlNationality" runat="server" Style="height: 25px;">
                                                            </asp:DropDownList>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvNationality" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                    ValidationGroup="IsRequire" ControlToValidate="ddlNationality" Display="Dynamic">
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
                                                            <div style="float: left;">
                                                                <asp:ImageButton ID="imgSearchGuestInfo" runat="server" ImageUrl="~/images/001_38.gif"
                                                                    ToolTip="Search" OnClick="btnSearchGuestInfo_Click" Style="margin-top: 3px; border: none;" />
                                                            </div>
                                                            <div style="float: left;">
                                                                <img src="../../images/clearsearch.png" id="imgClear" style="vertical-align: middle;
                                                                    margin-top: 4px; margin-left: 4px;" title="Clear" onclick="Clear();" />
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
                                                            <asp:LinkButton ID="lnkBookedBy" runat="server" OnClientClick="return CopyName();"
                                                                Text="Copy Name" Style="display: inline;"></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litMobile" runat="server" Text="Mobile No."></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCountryMobileCode" runat="server" MaxLength="4" Style="width: 30px !important;"></asp:TextBox>
                                                            <ajx:FilteredTextBoxExtender ID="ftCountryMobileCode" runat="server" TargetControlID="txtCountryMobileCode"
                                                                ValidChars="+0123456789" FilterMode="ValidChars">
                                                            </ajx:FilteredTextBoxExtender>
                                                            <asp:TextBox ID="txtMobile" Style="width: 190px;" MaxLength="10" runat="server"></asp:TextBox>
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
                                                            <span>
                                                                <asp:RegularExpressionValidator ID="revGuestEmail" Display="Dynamic" ValidationGroup="IsRequire"
                                                                    runat="server" ErrorMessage="Please Enter Valid Email" ForeColor="Red" ControlToValidate="txtGuestEmail"
                                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                            </span>&nbsp;&nbsp;&nbsp;
                                                            <asp:LinkButton ID="lnkVerifyBlackList" runat="server" Text="Verify Black List" Style="display: inline;"
                                                                OnClientClick="return fnFindBlackListGuest();"></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr style="padding: 0px;">
                                                        <td style="padding: 0px;">
                                                        </td>
                                                        <td style="padding: 0px;">
                                                            <div id='trBlackListMessage' style="display: none;">
                                                                <asp:Label ID="lblBlackListMessage" runat="server" ForeColor="Red"></asp:Label></div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="vertical-align: top;">
                                                            <asp:Literal ID="litAddress" runat="server" Text="Address"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtAddressLine1" runat="server"></asp:TextBox>
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
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="Literal6" runat="server" Text="Company Name"></asp:Literal>
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
                                                                                <asp:ListItem Selected="True" Text="-SELECT-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
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
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            Min. Amount for Confirm Reservation&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblMinAmountForConfirmReservation"
                                                                runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="display: none;">
                                                        <td>
                                                            Amount
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPaymentAmount" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="display: none;">
                                                        <td>
                                                            Mode of Payment
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlModeOfPayment" runat="server" OnSelectedIndexChanged="ddlModeOfPayment_OnSelectedIndexChanged"
                                                                AutoPostBack="true">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr id="trLedgerAccount" runat="server" visible="false">
                                                        <td>
                                                            Ledger
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlLedgerAccount" runat="server">
                                                            </asp:DropDownList>
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
                                                            <asp:DropDownList ID="ddlCreditCardType" runat="server">
                                                            </asp:DropDownList>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvCreditCardType" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" Enabled="false"
                                                                    runat="server" ValidationGroup="IsRequire" ControlToValidate="ddlCreditCardType"
                                                                    Display="Dynamic">
                                                                </asp:RequiredFieldValidator>
                                                            </span>
                                                        </td>
                                                    </tr>
                                                    <tr id="trCreditCard2" runat="server" visible="false">
                                                        <td>
                                                            Name on Card
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtNameOnCard" runat="server"></asp:TextBox>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvNameOnCreditCard" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                    Enabled="false" runat="server" ValidationGroup="IsRequire" ControlToValidate="txtNameOnCard"
                                                                    Display="Dynamic">
                                                                </asp:RequiredFieldValidator>
                                                            </span>
                                                        </td>
                                                    </tr>
                                                    <tr id="trCreditCard3" runat="server" visible="false">
                                                        <td>
                                                            Card Number
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCardNumber" runat="server" MaxLength="16"></asp:TextBox>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvCreditCardNumber" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                    Enabled="false" runat="server" ValidationGroup="IsRequire" ControlToValidate="txtCardNumber"
                                                                    Display="Dynamic">
                                                                </asp:RequiredFieldValidator>
                                                            </span>
                                                            <ajx:FilteredTextBoxExtender ID="fteCreditCardNumber" runat="server" TargetControlID="txtCardNumber"
                                                                FilterMode="ValidChars" ValidChars="0123456789">
                                                            </ajx:FilteredTextBoxExtender>
                                                        </td>
                                                    </tr>
                                                    <tr id="trCVVNo" runat="server" visible="false">
                                                        <td>
                                                            CVV No.
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCVVNo" runat="server" MaxLength="4"></asp:TextBox>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvCVVNumber" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                    Enabled="false" runat="server" ValidationGroup="IsRequire" ControlToValidate="txtCVVNo"
                                                                    Display="Dynamic">
                                                                </asp:RequiredFieldValidator>
                                                            </span>
                                                            <ajx:FilteredTextBoxExtender ID="fteCVVNo" runat="server" TargetControlID="txtCVVNo"
                                                                FilterMode="ValidChars" ValidChars="0123456789">
                                                            </ajx:FilteredTextBoxExtender>
                                                        </td>
                                                    </tr>
                                                    <tr id="trCreditCard4" runat="server" visible="false">
                                                        <td>
                                                            Expiration Date
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlCardExpirationMonth" runat="server" SkinID="nowidth" Width="115px">
                                                                <asp:ListItem Text="-SELECT-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
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
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvCardExpirationMonth" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" Enabled="false"
                                                                    runat="server" ValidationGroup="IsRequire" ControlToValidate="ddlCardExpirationMonth"
                                                                    Display="Static">
                                                                </asp:RequiredFieldValidator>
                                                            </span>
                                                            <asp:DropDownList ID="ddlCardExpirationYear" runat="server" SkinID="nowidth" Width="103px">
                                                            </asp:DropDownList>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvCardExpirationYear" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" Enabled="false"
                                                                    runat="server" ValidationGroup="IsRequire" ControlToValidate="ddlCardExpirationYear"
                                                                    Display="Dynamic">
                                                                </asp:RequiredFieldValidator>
                                                            </span>
                                                        </td>
                                                    </tr>
                                                    <tr id="trCreditCard5" runat="server" visible="false">
                                                        <td>
                                                        </td>
                                                        <td style="padding: 0px;">
                                                            <asp:RadioButtonList ID="rdbPaymentOrBlock" runat="server" CellPadding="0" CellSpacing="0"
                                                                RepeatColumns="2" RepeatDirection="Horizontal">
                                                                <asp:ListItem Text="Charge" Value="CHARGE" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Text="Block" Value="BLOCK"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="isrequire">
                                                            <asp:Literal ID="Literal11" runat="server" Text="Booking Status"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlBookingStatus" runat="server" Enabled="false" OnSelectedIndexChanged="ddlBookingStatus_OnSelectedIndexChanged"
                                                                AutoPostBack="true">
                                                            </asp:DropDownList>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvBookingStatus" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                    ValidationGroup="IsRequire" ControlToValidate="ddlBookingStatus" Display="Dynamic">
                                                                </asp:RequiredFieldValidator>
                                                            </span>
                                                        </td>
                                                    </tr>
                                                    <tr id="trAssignRoom" runat="server" visible="false">
                                                        <td id="tdAssignRoomNo" runat="server">
                                                            <asp:Literal ID="litRoomNoForAmend" runat="server" Text="Room No."></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlRoomNumber" runat="server">
                                                            </asp:DropDownList>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvRoomNumberForAmend" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                    ValidationGroup="IsRequire" ControlToValidate="ddlRoomNumber" Display="Dynamic">
                                                                </asp:RequiredFieldValidator>
                                                            </span>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <div style="float: right; display: inline-block;">
                                                    <asp:Button ID="btnCancel" runat="server" ImageUrl="~/images/cancle.png" Style="float: right;
                                                        margin-left: 5px;" Text="Cancel" OnClick="btnCancel_Click" />
                                                    <asp:Button ID="btnSave" runat="server" Text="Save" ImageUrl="~/images/save.png"
                                                        Style="float: right; margin-left: 5px;" ValidationGroup="IsRequire" OnClick="btnSave_Click" />
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
        <ajx:ModalPopupExtender ID="mpeSearchGuestInfo" runat="server" TargetControlID="hdnSearchGuestInfo"
            PopupControlID="pnlSearchGuestInfo" CancelControlID="imbCloseSrchGuestPopup"
            BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnSearchGuestInfo" runat="server" />
        <asp:Panel ID="pnlSearchGuestInfo" runat="server" Width="800px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <div style="display: inline;">
                        <span>
                            <asp:Literal ID="Literal7" runat="server" Text="Guest List"></asp:Literal></span></div>
                    <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                        <asp:ImageButton ID="imbCloseSrchGuestPopup" runat="server" ImageUrl="~/images/closepopup.png"
                            Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;" />
                    </div>
                </div>
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
                            </td>
                            <td>
                                <asp:Literal ID="litSearchMobileNo" runat="server" Text="Mobile No."></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSearchMobileNo" runat="server" MaxLength="10"></asp:TextBox>
                                <ajx:FilteredTextBoxExtender ID="ftSearchMobileNo" runat="server" TargetControlID="txtSearchMobileNo"
                                    ValidChars="0123456789" FilterMode="ValidChars">
                                </ajx:FilteredTextBoxExtender>
                                <asp:ImageButton ID="btnSearchGuest" runat="server" ImageUrl="~/images/search-icon.png"
                                    ToolTip="Search" Style="border: 0px; margin: -4px 0 0 5px; vertical-align: middle;"
                                    OnClick="btnSearchGuest_Click" />
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
                                        Width="100%" SkinID="gvNoPaging" OnRowDataBound="gvSearchGuestList_RowDataBound"
                                        OnRowCommand="gvSearchGuestList_RowCommand">
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
                                                    <asp:LinkButton ID="lnkSearchGuestName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "GuestFullName")%>'
                                                        CommandName="GETGUESTINFO" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "GuestID")%>'></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrSearchGuestMobileNo" runat="server" Text="Mobile No."></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMobileNo" runat="server"></asp:Label>
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
                                                    <asp:Label ID="lblGvHdrSearchGuestCity" runat="server" Text="City"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "CityName")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrSearchGuestState" runat="server" Text="State"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "StateName")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrSearchGuestCountry" runat="server" Text="Country"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "CountryName")%>
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
        <ajx:ModalPopupExtender ID="mpeReservatinoVoucher" runat="server" TargetControlID="hdnReservationVoucher"
            PopupControlID="pnlReservatinoVoucher" BackgroundCssClass="mod_background" CancelControlID="iBtnCloseResVoucher">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnReservationVoucher" runat="server" />
        <asp:Panel ID="pnlReservatinoVoucher" runat="server" Width="700px">
            <div class="box_col1">
                <div class="box_head">
                    <div style="display: inline;">
                        <span>
                            <asp:Literal ID="Literal9" runat="server" Text="Reservation Voucher"></asp:Literal></span></div>
                    <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                        <asp:ImageButton ID="iBtnCloseResVoucher" runat="server" ImageUrl="~/images/closepopup.png"
                            Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;" />
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table border="0" cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td align="left">
                                <ucCtrlReservationVoucher:ReservationVoucher ID="ctrlReservationVoucher" runat="server" />
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
<asp:UpdateProgress AssociatedUpdatePanelID="updReservation" ID="UpdateProgressReservation"
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
