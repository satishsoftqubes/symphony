<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlEditReservation.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation.CtrlEditReservation" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
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

    function Clear() {
        document.getElementById('<%= txtCountryName.ClientID %>').value = document.getElementById('<%= txtStateName.ClientID %>').value = document.getElementById('<%= txtCityName.ClientID %>').value = document.getElementById('<%= txtZipCode.ClientID %>').value = document.getElementById('<%= txtAddressLine1.ClientID %>').value = document.getElementById('<%= txtMobile.ClientID %>').value = document.getElementById('<%= txtFirstName.ClientID %>').value = document.getElementById('<%= txtLastName.ClientID %>').value = document.getElementById('<%= txtGuestEmail.ClientID %>').value = "";
        document.getElementById('<%= ddlTitle.ClientID %>').selectedIndex = document.getElementById('<%= ddlNationality.ClientID %>').selectedIndex = 0;
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
        <asp:HiddenField ID="hdnIsBlackList" runat="server" />
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="content" style="padding-left: 0px; width: 66.66%">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                <asp:Literal ID="Literal1" runat="server" Text="EDIT RESERVATION"></asp:Literal>
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
                                                            <asp:TextBox ID="txtCheckInDate" runat="server" Enabled="false" onkeydown="return stopKey(event);"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="isrequire">
                                                            <asp:Literal ID="litCheckOutDate" runat="server" Text="Check Out"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCheckOutDate" runat="server" Enabled="false" onkeydown="return stopKey(event);"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="isrequire">
                                                            <asp:Literal ID="litRoomType" runat="server" Text="Room Type"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlRoomType" runat="server" Enabled="false">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="Literal12" runat="server" Text="Reservation Ref."></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlBookingReference" runat="server" Enabled="false" AutoPostBack="true"
                                                                OnSelectedIndexChanged="ddlBookingReference_OnSelectedIndexChanged">
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
                                                            <asp:DropDownList ID="ddlCompany" runat="server" Enabled="false">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="isrequire">
                                                            <asp:Literal ID="litRateCard" runat="server" Text="Rate Card"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlRateCard" runat="server" Enabled="false" AutoPostBack="true"
                                                                OnSelectedIndexChanged="ddlRateCard_OnSelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="isrequire">
                                                            <asp:Literal ID="litAdult" runat="server" Text="Adult"></asp:Literal>
                                                        </td>
                                                        <td style="vertical-align: middle;" class="NumericDropdown">
                                                            <asp:TextBox ID="txtAdult" runat="server" SkinID="nowidth" Width="40px" Enabled="false"
                                                                MaxLength="3"></asp:TextBox>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                            <asp:Literal ID="litChild" runat="server" Text="Child"></asp:Literal>&nbsp;&nbsp;&nbsp;
                                                            <asp:TextBox ID="txtChild" runat="server" SkinID="nowidth" Width="40px" MaxLength="3"
                                                                Enabled="false"></asp:TextBox>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                            <asp:Literal ID="litInf" runat="server" Text="Inf"></asp:Literal>&nbsp;&nbsp;&nbsp;
                                                            <asp:TextBox ID="txtInfant" runat="server" MaxLength="3" SkinID="nowidth" Width="40px"
                                                                Enabled="false"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="Literal2" runat="server" Text="Guest Type"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList runat="server" ID="ddlGuestType" Enabled="false" AutoPostBack="true"
                                                                OnSelectedIndexChanged="ddlGuestType_OnSelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="Literal3" runat="server" Text="Source of Business"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList runat="server" Enabled="false" ID="ddlSourceOfBusiness">
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
                                                                            <asp:ListItem Text="Yes" Value="YES"></asp:ListItem>
                                                                            <asp:ListItem Text="No" Value="NO"></asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                    </td>
                                                                    <td width="60px">
                                                                        Pickup
                                                                    </td>
                                                                    <td style="padding: 0px;">
                                                                        <asp:RadioButtonList ID="rdbIsPicup" Enabled="false" runat="server" RepeatDirection="Horizontal"
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
                                                            <asp:TextBox ID="txtSpecificInstruction" runat="server" Enabled="false" SkinID="nowidth"
                                                                Width="334px" Height="35px" TextMode="MultiLine"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="padding: 0px;">
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
                                                        <td colspan="2">
                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td align="left">
                                                                        <b>
                                                                            <asp:Literal ID="litGuestInformation" runat="server" Text="Guest Information"></asp:Literal></b>
                                                                    </td>
                                                                    <td align="right">
                                                                        <asp:LinkButton ID="lnkComplementaryReservation" runat="server" Visible="false" OnClick="lnkComplementaryReservation_OnClick"
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
                                                            <b>Payment</b>
                                                            <hr />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Billing Instruction
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlBillingInstruction" runat="server" Enabled="false">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            Min. Amount for Confirm Reservation&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblMinAmountForConfirmReservation"
                                                                runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Paid Amount
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDispalyPaidAmount" runat="server" Text="0.00"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="isrequire">
                                                            <asp:Literal ID="Literal11" runat="server" Text="Booking Status"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDisplayBookingStatus" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="Literal13" runat="server" Text="Room No."></asp:Literal>
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
        <ajx:ModalPopupExtender ID="mpeSuccessMessage" runat="server" TargetControlID="hdnSuccessMessage"
            PopupControlID="pnlSuccessMessage" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnSuccessMessage" runat="server" />
        <asp:Panel ID="pnlSuccessMessage" runat="server" Width="400px" Height="250px">
            <div class="box_col1">
                <div class="box_head">
                    <div style="display: inline;">
                        <span>
                            <asp:Literal ID="Literal9" runat="server" Text="Message"></asp:Literal></span></div>
                    <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                        <asp:ImageButton ID="iBtnCloseSuccessMessage" runat="server" ImageUrl="~/images/closepopup.png"
                            Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;"
                            OnClick="iBtnCloseSuccessMessage_OnClick" />
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table border="0" cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td style="padding-bottom: 15px;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                Reservation edited successfully.
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-bottom: 15px;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnSuccessMsgOK" runat="server" Text="OK" ImageUrl="~/images/save.png"
                                    OnClick="btnSuccessMsgOK_OnClick" />
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
