<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlGroupReservation.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation.CtrlGroupReservation" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<%@ Register Src="~/UIControls/CommonControls/CtrCommonGuestInfo.ascx" TagName="CommonGuestInfo"
    TagPrefix="uc2" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonAddServices.ascx" TagName="AddServices"
    TagPrefix="ucCtrlAddServices" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonCheckIn.ascx" TagName="CheckIn"
    TagPrefix="ucCtrlCheckIn" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonVoucherDetails.ascx" TagName="VoucherDetails"
    TagPrefix="ucCtrlVoucherDetails" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonOterhInformation.ascx" TagName="CommonOterhInformation"
    TagPrefix="ucCtrlCommonOterhInformation" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonPayment.ascx" TagName="Payment"
    TagPrefix="ucCtrlPayment" %>
<link type="text/css" href="../../Styles/jquery-ui-1.8.5.custom.css" rel="stylesheet" />
<script type="text/javascript" src="../../Scripts/jquery-1.4.2.min.js"></script>
<script type="text/javascript" src="../../Scripts/jquery-ui-1.8.5.custom.min.js"></script>
<link rel="stylesheet" href="../../Styles/jquery.ui.timepicker.css" type="text/css" />
<script type="text/javascript" src="../../Scripts/jquery-ui-timepicker-addon.js"></script>
<script type="text/javascript" language="javascript">
    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function validateRate() {



        if (document.getElementById("<%=txtArrivalDate.ClientID%>").value == '') {
            document.getElementById("<%=lblCustomePopupMsgRate.ClientID%>").innerHTML = "Please Enter Check In Date";
            document.getElementById("<%=txtArrivalDate.ClientID%>").focus();
            $find('mpeCustomePopupRate').show();
            return false;
        }
        else if (document.getElementById("<%=ddlFrequency.ClientID%>").selectedIndex == 0) {
            document.getElementById("<%=lblCustomePopupMsgRate.ClientID%>").innerHTML = "Please Select Frequency";
            $find('mpeCustomePopupRate').show();
            return false;
        }
        else if (document.getElementById("<%=txtNight.ClientID%>").value == '') {
            document.getElementById("<%=lblCustomePopupMsgRate.ClientID%>").innerHTML = "Please Enter Duration";
            document.getElementById("<%=txtNight.ClientID%>").focus();
            $find('mpeCustomePopupRate').show();
            return false;
        }
        else if (document.getElementById("<%=txtDepatureDate.ClientID%>").value == '') {
            document.getElementById("<%=lblCustomePopupMsgRate.ClientID%>").innerHTML = "Please Enter Check Out Date";
            document.getElementById("<%=txtDepatureDate.ClientID%>").focus();
            $find('mpeCustomePopupRate').show();
            return false;
        }
        else if (document.getElementById("<%=ddlRateCard.ClientID%>").selectedIndex == 0) {
            document.getElementById("<%=lblCustomePopupMsgRate.ClientID%>").innerHTML = "Please Select Rate Card";
            $find('mpeCustomePopupRate').show();
            return false;
        }
        else if (document.getElementById("<%=ddlRoomType.ClientID%>").selectedIndex == 0) {
            document.getElementById("<%=lblCustomePopupMsgRate.ClientID%>").innerHTML = "Please Select Room Type";
            $find('mpeCustomePopupRate').show();
            return false;
        }
        else if (document.getElementById("<%=txtNoOfRoom.ClientID%>").value == '0') {
            document.getElementById("<%=lblCustomePopupMsgRate.ClientID%>").innerHTML = "Please Enter at least One No.";
            document.getElementById("<%=txtNoOfRoom.ClientID%>").focus();
            $find('mpeCustomePopupRate').show();
            return false;
        }
        else if (document.getElementById("<%=txtAdult1.ClientID%>").value == '0') {
            document.getElementById("<%=lblCustomePopupMsgRate.ClientID%>").innerHTML = "Please Enter at least One Adutl";
            document.getElementById("<%=txtAdult1.ClientID%>").focus();
            $find('mpeCustomePopupRate').show();
            return false;
        }


    }
   
</script>
<asp:UpdatePanel ID="updRoomReservation" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="content" style="padding-left: 0px; width: 66.66%">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                <asp:Literal ID="litMainHeader" runat="server" Text="Group Reservation"></asp:Literal>
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
                                    <asp:MultiView ID="mvGroupReservation" runat="server">
                                        <asp:View ID="vGroupReservation" runat="server">
                                            <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                <tr>
                                                    <td width="48%" style="vertical-align: top; border-right: 1px solid #ccccce;">
                                                        <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                            <tr>
                                                                <td colspan="2">
                                                                    <b>
                                                                        <asp:Literal ID="litStayInformation" runat="server" Text="Stay Information"></asp:Literal></b>
                                                                    <hr />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="isrequire">
                                                                    <asp:Literal ID="litArrivalDate" runat="server" Text="Check In"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtArrivalDate" runat="server" Style="width: 90px !important;" onkeypress="return false;"></asp:TextBox>
                                                                    <asp:Image ID="imgArrivalDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                                        Height="20px" Width="20px" />
                                                                    <ajx:CalendarExtender ID="calArrivalDate" PopupButtonID="imgArrivalDate" TargetControlID="txtArrivalDate"
                                                                        runat="server" Format="dd-MM-yyyy">
                                                                    </ajx:CalendarExtender>
                                                                    <img src="../../images/clear.png" id="imgAD" style="vertical-align: middle;" title="Clear Date"
                                                                        onclick="fnClearDate('<%= txtArrivalDate.ClientID %>');" />
                                                                    <span>
                                                                        <asp:RequiredFieldValidator ID="rfvArrivalDate" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                            runat="server" ValidationGroup="IsRequire" ControlToValidate="txtArrivalDate"
                                                                            Display="Dynamic">
                                                                        </asp:RequiredFieldValidator>
                                                                    </span>
                                                                    <asp:DropDownList ID="ddlFrequency" runat="server" Style="width: 75px;">
                                                                        <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                                        <asp:ListItem Text="Daily" Value="Daily"></asp:ListItem>
                                                                        <asp:ListItem Text="Weekly" Value="Weekly"></asp:ListItem>
                                                                        <asp:ListItem Text="Monthly" Value="Monthly"></asp:ListItem>
                                                                        <asp:ListItem Text="Quartrly" Value="Quartrly"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <span>
                                                                        <asp:RequiredFieldValidator ID="rfvFrequency" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                            SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                            ValidationGroup="IsRequire" ControlToValidate="ddlFrequency" Display="Dynamic">
                                                                        </asp:RequiredFieldValidator>
                                                                    </span>&nbsp;&nbsp;&nbsp;
                                                                    <asp:TextBox ID="txtNight" runat="server" MaxLength="3" Style="width: 40px !important;"></asp:TextBox>
                                                                    <span>
                                                                        <asp:RequiredFieldValidator ID="rfvNight" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                            runat="server" ValidationGroup="IsRequire" ControlToValidate="txtNight" Display="Dynamic">
                                                                        </asp:RequiredFieldValidator>
                                                                    </span>
                                                                    <ajx:FilteredTextBoxExtender ID="ftNight" runat="server" TargetControlID="txtNight"
                                                                        FilterType="Numbers" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="isrequire">
                                                                    <asp:Literal ID="litDepatureDate" runat="server" Text="Check Out"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtDepatureDate" runat="server" onkeypress="return false;"></asp:TextBox>
                                                                    <asp:Image ID="imgDepatureDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                                        Height="20px" Width="20px" />
                                                                    <ajx:CalendarExtender ID="CalendarExtender1" PopupButtonID="imgDepatureDate" TargetControlID="txtDepatureDate"
                                                                        runat="server" Format="dd-MM-yyyy">
                                                                    </ajx:CalendarExtender>
                                                                    <img src="../../images/clear.png" id="imgDD" style="vertical-align: middle;" title="Clear Date"
                                                                        onclick="fnClearDate('<%= txtDepatureDate.ClientID %>');" />
                                                                    <span>
                                                                        <asp:RequiredFieldValidator ID="rfvDepatureDate" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                            runat="server" ValidationGroup="IsRequire" ControlToValidate="txtDepatureDate"
                                                                            Display="Dynamic">
                                                                        </asp:RequiredFieldValidator>
                                                                    </span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="isrequire">
                                                                    <asp:Literal ID="litRoomType" runat="server" Text="Room Type"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlRoomType" runat="server">
                                                                        <asp:ListItem Selected="True" Value="00000000-0000-0000-0000-000000000000" Text="-Select-"></asp:ListItem>
                                                                        <asp:ListItem Text="Standard Non A/c - Double Share" Value="Standard Non A/c - Double Share"></asp:ListItem>
                                                                        <asp:ListItem Text="Superior A/c - King Bed" Value="Superior A/c - King Bed"></asp:ListItem>
                                                                        <asp:ListItem Text="Superior Non A/c - Double Share" Value="Superior Non A/c - Double Share"></asp:ListItem>
                                                                        <asp:ListItem Text="Suite A/c - King Bed" Value="Suite A/c - King Bed"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <span>
                                                                        <asp:RequiredFieldValidator ID="rfvRoomType" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                            SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                            ValidationGroup="IsRequire" ControlToValidate="ddlRoomType" Display="Dynamic">
                                                                        </asp:RequiredFieldValidator>
                                                                    </span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litDispReservationRef" runat="server" Text="Reservation Ref."></asp:Literal>
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
                                                                    <asp:Literal ID="litCorporate" runat="server" Text="Corporate"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlCorporate" runat="server">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="isrequire">
                                                                    <asp:Literal ID="litRateCard" runat="server" Text="Rate Card"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlRateCard" runat="server">
                                                                        <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                                        <asp:ListItem Text="Corporate RateCard" Value="Corporate RateCard"></asp:ListItem>
                                                                        <asp:ListItem Text="Room RateCard" Value="Room RateCard"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <span>
                                                                        <asp:RequiredFieldValidator ID="rfvRateCard" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                            SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                            ValidationGroup="IsRequire" ControlToValidate="ddlRateCard" Display="Dynamic">
                                                                        </asp:RequiredFieldValidator>
                                                                    </span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="isrequire">
                                                                    <asp:Literal ID="litNoOfRoomDisp" runat="server" Text="No. of Room"></asp:Literal>
                                                                </td>
                                                                <td style="vertical-align: middle;" class="NumericDropdown">
                                                                    <asp:TextBox ID="txtNoOfRoom" runat="server" MaxLength="3"></asp:TextBox>
                                                                    <ajx:NumericUpDownExtender ID="NumericUpDownExtender4" runat="server" TargetControlID="txtNoOfRoom"
                                                                        Width="60" Minimum="1" Maximum="1" />
                                                                    <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtNoOfRoom"
                                                                        FilterType="Numbers" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="isrequire">
                                                                    <asp:Literal ID="Literal1" runat="server" Text="Adult"></asp:Literal>
                                                                </td>
                                                                <td style="vertical-align: middle;" class="NumericDropdown">
                                                                    <asp:TextBox ID="txtAdult1" runat="server" MaxLength="3"></asp:TextBox>
                                                                    <ajx:NumericUpDownExtender ID="NumericUpDownExtender1" runat="server" TargetControlID="txtAdult1"
                                                                        Width="60" Minimum="1" Maximum="1" />
                                                                    <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtAdult1"
                                                                        FilterType="Numbers" />
                                                                    <asp:Literal ID="Literal2" runat="server" Text="Child"></asp:Literal>&nbsp;&nbsp;&nbsp;
                                                                    <asp:TextBox ID="txtChild1" runat="server" MaxLength="3"></asp:TextBox>
                                                                    <ajx:NumericUpDownExtender ID="NumericUpDownExtender2" runat="server" TargetControlID="txtChild1"
                                                                        Width="60" Minimum="0" Maximum="0" />
                                                                    <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtChild1"
                                                                        FilterType="Numbers" />
                                                                    <asp:Literal ID="litInfo" runat="server" Text="Infant"></asp:Literal>&nbsp;&nbsp;&nbsp;
                                                                    <asp:TextBox ID="txtInfant" runat="server" MaxLength="3"></asp:TextBox>
                                                                    <ajx:NumericUpDownExtender ID="NumericUpDownExtender3" runat="server" TargetControlID="txtInfant"
                                                                        Width="60" Minimum="0" Maximum="0" />
                                                                    <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtInfant"
                                                                        FilterType="Numbers" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <div style="text-align: center; margin-left: 50%; margin-top: 12px;">
                                                                        <asp:Button ID="btnAddUnit" runat="server" Text="+" OnClientClick="return validateRate();"
                                                                            OnClick="btnAddUnit_Click" />
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding-left: 0px; padding-top: 10px;" colspan="2">
                                                                    <b>Specific Instruction</b>
                                                                    <hr />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    Pickup
                                                                </td>
                                                                <td style="padding: 0px;">
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:RadioButtonList ID="rdbIsPicup" runat="server" RepeatDirection="Horizontal"
                                                                                    RepeatColumns="2">
                                                                                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                                                                    <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                                                </asp:RadioButtonList>
                                                                            </td>
                                                                            <td style="padding-left: 5px;">
                                                                                <asp:TextBox ID="txtSpecificInstruction" runat="server"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="vertical-align: top;">
                                                                    Note
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtNote" runat="server" SkinID="nowidth" Width="334px" Height="35px"
                                                                        TextMode="MultiLine"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <%--<tr>
                                                                <td colspan="2" style="padding-top: 10px; padding-right: 10px;">
                                                                    <div style="float: right; width: auto; display: inline-block;">
                                                                        <asp:Button ID="btnCalRate" runat="server" Style="float: left; padding-left: 10px;"
                                                                            Text="Calculate Rate" OnClick="btnCalRate_OnClick" />
                                                                    </div>
                                                                </td>
                                                            </tr>--%>
                                                            <tr style="display: none;">
                                                                <td colspan="2" style="padding: 0px;">
                                                                    <table id="tblRateCalculation" runat="server" width="80%">
                                                                        <tr>
                                                                            <td>
                                                                                <b>Particulars</b>
                                                                            </td>
                                                                            <td>
                                                                                <b>No. of Nights</b>
                                                                            </td>
                                                                            <td>
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
                                                                                Acco. Charges
                                                                            </td>
                                                                            <td>
                                                                                <asp:Literal ID="litNoOfDays" runat="server" Text="0"></asp:Literal>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Literal ID="litTotalAccoCharges" runat="server" Text="0.00"></asp:Literal>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                S. Tax
                                                                            </td>
                                                                            <td>
                                                                                -
                                                                            </td>
                                                                            <td>
                                                                                <asp:Literal ID="litServiceTex" runat="server" Text="0.00"></asp:Literal>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Other Tax
                                                                            </td>
                                                                            <td>
                                                                                -
                                                                            </td>
                                                                            <td>
                                                                                <asp:Literal ID="litOtherTax" runat="server" Text="0.00"></asp:Literal>
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
                                                                            <td>
                                                                                <b>
                                                                                    <asp:Literal ID="litTotalCharges" runat="server" Text="0.00"></asp:Literal></b>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Deposit
                                                                            </td>
                                                                            <td>
                                                                                -
                                                                            </td>
                                                                            <td>
                                                                                <asp:Literal ID="litDeposit" runat="server" Text="0.00"></asp:Literal>
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
                                                                            <td>
                                                                                <b>
                                                                                    <asp:Literal ID="litAmountDue" runat="server" Text="0.00"></asp:Literal></b>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td style="vertical-align: top;">
                                                        <uc2:CommonGuestInfo ID="ucCommonGuestInfo" runat="server" />
                                                    </td>
                                                </tr>
                                                <%-- <tr>
                                                    <td colspan="2">
                                                        <div style="float: right; width: auto; display: inline-block;">
                                                            <asp:Button ID="btnCancel" runat="server" CausesValidation="false" ImageUrl="~/images/cancle.png"
                                                                Style="float: right; margin-left: 5px;" Text="Cancel" OnClick="btnCancel_Click" />
                                                            <asp:Button ID="btnNext" runat="server" CausesValidation="true" Text="Next" ImageUrl="~/images/save.png"
                                                                Style="float: right; margin-left: 5px;" OnClick="btnNext_Click" ValidationGroup="IsRequire" />
                                                        </div>
                                                    </td>
                                                </tr>--%>
                                                <tr>
                                                    <td colspan="2">
                                                        <table cellpadding="2" cellspacing="2" width="100%">
                                                            <tr>
                                                                <td colspan="2">
                                                                    <div class="box_head">
                                                                        <span>
                                                                            <asp:Literal ID="litGroupReservationList" runat="server" Text="Group Reservation"></asp:Literal>
                                                                        </span>
                                                                    </div>
                                                                    <div class="clear">
                                                                    </div>
                                                                    <div class="box_content">
                                                                        <asp:GridView ID="gvGroupReservation" runat="server" AutoGenerateColumns="false"
                                                                            CellPadding="0" CellSpacing="0" ShowHeader="true" Width="100%">
                                                                            <Columns>
                                                                                <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrArrivalSrNo" runat="server" Text="No."></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%# Container.DataItemIndex + 1 %>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrUnitType" runat="server" Text="Room Type"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%#DataBinder.Eval(Container.DataItem, "RoomType")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="40px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrUnit" runat="server" Text="Room(2)"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%#DataBinder.Eval(Container.DataItem, "Units")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="40px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrAdult" runat="server" Text="Adult(3)"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%#DataBinder.Eval(Container.DataItem, "Adult")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="40px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrChild" runat="server" Text="Child(2)"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%#DataBinder.Eval(Container.DataItem, "Child")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="40px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrInf" runat="server" Text="Inf(0)"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%#DataBinder.Eval(Container.DataItem, "Inf")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrRate" runat="server" Text="Rate"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%#DataBinder.Eval(Container.DataItem, "Rate")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrVAT" runat="server" Text="S. Tax"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%#DataBinder.Eval(Container.DataItem, "VAT")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrOtherTax" runat="server" Text="Other Tax"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%#DataBinder.Eval(Container.DataItem, "OtherTax")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrAdvancedPayment" runat="server" Text="Deposit"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%#DataBinder.Eval(Container.DataItem, "AdvancedPayment")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrTotal" runat="server" Text="Total"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%#DataBinder.Eval(Container.DataItem, "Total")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblActions" runat="server" Text="Action"></asp:Label>
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
                                                                                                                    <asp:LinkButton Style="background: none !important; border: none;" ID="lnkEdit" runat="server"
                                                                                                                        ToolTip="Edit" CommandName="EDITDATA"><img src="../../images/file.png" /></asp:LinkButton>
                                                                                                                </li>
                                                                                                                <li>
                                                                                                                    <asp:LinkButton Style="background: none !important; border: none;" ID="lnkDelete"
                                                                                                                        runat="server" ToolTip="Delete" CommandName="DELETEDATA"><img src="../../images/delete_icon.png" /></asp:LinkButton>
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
                                                                                        <asp:Label ID="lblNoRecordFoundForRoomReservation" runat="server" Text="No Record Found."></asp:Label>
                                                                                    </b>
                                                                                </div>
                                                                            </EmptyDataTemplate>
                                                                        </asp:GridView>
                                                                        <%--<asp:GridView ID="gvGroupReservation" runat="server" AutoGenerateColumns="false"
                                                                            CellPadding="0" CellSpacing="0" ShowHeader="true" Width="100%" OnRowDataBound="gvGroupReservation_OnRowDataBound">
                                                                            <Columns>
                                                                                <asp:TemplateField>
                                                                                    <HeaderTemplate>
                                                                                        <div style="float: left; width: 20px; border-right: 1px solid #ccc;">
                                                                                            &nbsp;
                                                                                        </div>
                                                                                        <div style="float: left; width: 250px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                                            <asp:Literal ID="litGvHdrRoomType" runat="server" Text="Unit Type"></asp:Literal>
                                                                                        </div>
                                                                                        <div style="float: left; width: 75px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                                            <asp:Literal ID="litGvHdrUnit" runat="server" Text="Unit(2)"></asp:Literal>
                                                                                        </div>
                                                                                        <div style="float: left; width: 75px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                                            <asp:Literal ID="litGvHdrAdult" runat="server" Text="Adult(3)"></asp:Literal></div>
                                                                                        <div style="float: left; width: 75px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                                            <asp:Literal ID="litGvHdrChild" runat="server" Text="Child(2)"></asp:Literal></div>
                                                                                        <div style="float: left; width: 75px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                                            <asp:Literal ID="litGvHdrInf" runat="server" Text="Inf(0)"></asp:Literal></div>
                                                                                        <div style="float: left; width: 75px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                                            <asp:Literal ID="litGvHdrRate" runat="server" Text="Rate"></asp:Literal></div>
                                                                                        <div style="float: left; width: 100px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                                            <asp:Literal ID="litGvHdrUnitRate" runat="server" Text="Unit Rate"></asp:Literal></div>
                                                                                        <div style="float: left; width: 100px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                                            <asp:Literal ID="litGvHdrServices" runat="server" Text="Services"></asp:Literal></div>
                                                                                        <div style="float: left; width: 100px;">
                                                                                            <asp:Literal ID="litGvHdrTotal" runat="server" Text="Total"></asp:Literal></div>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <div style="float: left; width: 20px; border-right: 1px solid #ccc;">
                                                                                            <img id="imgid<%# Container.DataItemIndex %>" alt="" src="../../images/icon111.png"
                                                                                                onclick="fnOnClick(this);" />
                                                                                        </div>
                                                                                        <div style="float: left; width: 250px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                                            &nbsp;
                                                                                            <%# DataBinder.Eval(Container.DataItem, "RoomType")%></div>
                                                                                        <div style="float: left; width: 75px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                                            &nbsp;
                                                                                            <%# DataBinder.Eval(Container.DataItem, "Units")%></div>
                                                                                        <div style="float: left; width: 75px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                                            &nbsp;
                                                                                            <%# DataBinder.Eval(Container.DataItem, "Adult")%></div>
                                                                                        <div style="float: left; width: 75px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                                            &nbsp;
                                                                                            <%# DataBinder.Eval(Container.DataItem, "Child")%></div>
                                                                                        <div style="float: left; width: 75px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                                            &nbsp;
                                                                                            <%# DataBinder.Eval(Container.DataItem, "Inf")%></div>
                                                                                        <div style="float: left; width: 75px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                                            &nbsp;
                                                                                            <%# DataBinder.Eval(Container.DataItem, "Rate")%></div>
                                                                                        <div style="float: left; width: 100px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                                            &nbsp;
                                                                                            <%# DataBinder.Eval(Container.DataItem, "UnitRate")%></div>
                                                                                        <div style="float: left; width: 100px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                                            &nbsp;
                                                                                            <%# DataBinder.Eval(Container.DataItem, "Services")%></div>
                                                                                        <div style="float: left; padding-left: 1px;">
                                                                                            &nbsp;
                                                                                            <%# DataBinder.Eval(Container.DataItem, "Total")%></div>
                                                                                        <div id="dvid<%# Container.DataItemIndex %>" style="display: none; width: 100%; float: left;">
                                                                                            <div class="box_content">
                                                                                                <asp:GridView ID="InnerGrid" runat="server" Width="100%" ShowHeader="false" AutoGenerateColumns="false">
                                                                                                    <Columns>
                                                                                                       
                                                                                                        <asp:TemplateField>
                                                                                                            <ItemTemplate>
                                                                                                                <div style="float: left; width: 20px; border-right: 1px solid #ccc;">
                                                                                                                    &nbsp;
                                                                                                                </div>
                                                                                                                <div style="float: left; width: 250px; padding-left: 1px; border-right: 1px solid #ccc;">
                                                                                                                    &nbsp;
                                                                                                                    <%# DataBinder.Eval(Container.DataItem, "RoomType")%></div>
                                                                                                                <div style="float: left; width: 75px; padding-left: 1px; border-right: 1px solid #ccc;">
                                                                                                                    &nbsp;
                                                                                                                    <%# DataBinder.Eval(Container.DataItem, "Units")%></div>
                                                                                                                <div style="float: left; width: 75px; padding-left: 1px; border-right: 1px solid #ccc;">
                                                                                                                    &nbsp;
                                                                                                                    <%# DataBinder.Eval(Container.DataItem, "Adult")%></div>
                                                                                                                <div style="float: left; width: 75px; padding-left: 1px; border-right: 1px solid #ccc;">
                                                                                                                    &nbsp;
                                                                                                                    <%# DataBinder.Eval(Container.DataItem, "Child")%></div>
                                                                                                                <div style="float: left; width: 75px; padding-left: 1px; border-right: 1px solid #ccc;">
                                                                                                                    &nbsp;
                                                                                                                    <%# DataBinder.Eval(Container.DataItem, "Inf")%></div>
                                                                                                                <div style="float: left; width: 75px; padding-left: 1px; border-right: 1px solid #ccc;">
                                                                                                                    &nbsp;
                                                                                                                    <%# DataBinder.Eval(Container.DataItem, "Rate")%></div>
                                                                                                                <div style="float: left; width: 100px; padding-left: 1px; border-right: 1px solid #ccc;">
                                                                                                                    &nbsp;
                                                                                                                    <%# DataBinder.Eval(Container.DataItem, "UnitRate")%></div>
                                                                                                                <div style="float: left; width: 100px; padding-left: 1px; border-right: 1px solid #ccc;">
                                                                                                                    &nbsp;
                                                                                                                    <%# DataBinder.Eval(Container.DataItem, "Services")%></div>
                                                                                                                <div style="float: left; width: 100px; padding-left: 1px;">
                                                                                                                    &nbsp;
                                                                                                                    <%# DataBinder.Eval(Container.DataItem, "Total")%></div>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                    </Columns>
                                                                                                </asp:GridView>
                                                                                            </div>
                                                                                        </div>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                            <EmptyDataTemplate>
                                                                                <div style="padding: 10px;">
                                                                                    <b>
                                                                                        <asp:Label ID="lblNoRecordFoundForRoomReservation" runat="server" Text="No Record Found."></asp:Label>
                                                                                    </b>
                                                                                </div>
                                                                            </EmptyDataTemplate>
                                                                        </asp:GridView>--%>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <div style="float: right; width: auto; display: inline-block;">
                                                            <asp:Button ID="btnCancel" runat="server" CausesValidation="false" ImageUrl="~/images/cancle.png"
                                                                Style="float: right; margin-left: 5px;" Text="Cancel" OnClick="btnCancel_Click" />
                                                            <asp:Button ID="btnNext" runat="server" CausesValidation="true" Text="Next" ImageUrl="~/images/save.png"
                                                                Style="float: right; margin-left: 5px;" OnClick="btnNext_Click" ValidationGroup="IsRequire" />
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                        <asp:View ID="vGroupReservationGrid" runat="server">
                                            <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                <tr>
                                                    <td style="border: 1px solid #ccccce !important; padding-bottom: 5px; line-height: 25px;">
                                                        <div style="display: none; float: left; width: 75px; padding-right: 15px; font-weight: bold;
                                                            padding-left: 10px;">
                                                            <asp:Literal ID="litGRGroupCode" runat="server" Text="Group Code"></asp:Literal>
                                                        </div>
                                                        <div style="display: none; float: left; padding-right: 15px; width: 130px;">
                                                            &nbsp;<asp:Literal ID="litGRDisplayGroupCode" runat="server"></asp:Literal>
                                                        </div>
                                                        <div style="float: left; padding-right: 15px; width: 60px; font-weight: bold;">
                                                            <asp:Literal ID="litGRArrivalDate" runat="server" Text="Check In"></asp:Literal>
                                                        </div>
                                                        <div style="float: left; padding-right: 15px; width: 140px;">
                                                            &nbsp;<asp:Literal ID="litGRDisplayArrivalDate" runat="server"></asp:Literal>
                                                        </div>
                                                        <div style="float: left; padding-right: 15px; width: 60px; font-weight: bold;">
                                                            <asp:Literal ID="litGRDepatureDate" runat="server" Text="Check Out"></asp:Literal>
                                                        </div>
                                                        <div style="float: left; padding-right: 15px; width: 140px;">
                                                            &nbsp;<asp:Literal ID="litGRDisplayDepatureDate" runat="server"></asp:Literal>
                                                        </div>
                                                        <div style="float: left; padding-right: 15px; width: 80px; font-weight: bold;">
                                                            <asp:Literal ID="litGRContactNo" runat="server" Text="Contact No."></asp:Literal>
                                                        </div>
                                                        <div style="float: left;">
                                                            &nbsp;<asp:Literal ID="litGRDisplayContactNo" runat="server" Text="NA"></asp:Literal>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <fieldset style="border: 1px solid #ccc !important;">
                                                            <legend>
                                                                <asp:Literal ID="litGroupOperation" runat="server" Text="Group Operation"></asp:Literal>
                                                            </legend>
                                                            <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                                <tr>
                                                                    <td>
                                                                        <div style="display: none; float: left; padding-right: 10px; padding-top: 5px;">
                                                                            <asp:Literal ID="litGroupReservationDiscount" runat="server" Text="Discount"></asp:Literal></div>
                                                                        <div style="float: left; padding-right: 10px;">
                                                                            <asp:DropDownList ID="ddlGroupReservationDiscount" runat="server" Style="width: 125px;">
                                                                                <asp:ListItem Selected="True" Text="-Select-" Value="-Select-"></asp:ListItem>
                                                                                <asp:ListItem Text="Christmas Discount" Value="Christmas Discount"></asp:ListItem>
                                                                                <asp:ListItem Text="Diwali Discount" Value="Diwali Discount"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                        <div style="display: none; float: left; padding-right: 10px;">
                                                                            <asp:Button ID="btnQthInfo" runat="server" Text="OTH INFO" OnClick="btnQthInfo_OnClick" /></div>
                                                                        <div style="float: left; padding-right: 10px;">
                                                                            <asp:Button ID="btnGuest" runat="server" Text="Guest" OnClick="btnGuest_Click" /></div>
                                                                        <%--<div style="float: left; padding-right: 10px;">
                                                                            <asp:Button ID="btnAddService" runat="server" Text="Add Service" OnClick="btnAddService_Click" /></div>--%>
                                                                        <%--<div style="float: left; padding-right: 10px;">
                                                                            <asp:Button ID="btnAutoUnitASG" runat="server" Text="Auto Unit ASG" /></div>--%>
                                                                        <div style="float: left; padding-right: 10px;">
                                                                            <asp:Button ID="btnGrpCheckIn" runat="server" Text="GRP CHK IN" /></div>
                                                                        <div style="display: none; float: left; padding-right: 10px;">
                                                                            <asp:Button ID="btnVoucher" runat="server" Text="Voucher" OnClick="btnVoucher_OnClick" /></div>
                                                                        <div style="display: none; float: left; padding-right: 10px;">
                                                                            <asp:Button ID="btnReRouteAll" runat="server" Text="ReRoute All" /></div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="checkbox_new">
                                                                        <div style="display: none; float: left;">
                                                                            <asp:CheckBox ID="chkGroupReservationLockRate" runat="server" Text="Lock Rate" />
                                                                        </div>
                                                                        <div style="display: none; float: right;">
                                                                            <asp:CheckBox ID="chkShowCancel" runat="server" Text="Show Cancel" />
                                                                            &nbsp;&nbsp;&nbsp;&nbsp; <span style="padding-top: 7px; vertical-align: middle;">
                                                                                <asp:Literal ID="litGroupDeposit" runat="server" Text="Group Deposit"></asp:Literal>
                                                                                &nbsp;&nbsp;&nbsp;&nbsp;0.00</span>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </fieldset>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-bottom: 20px;">
                                                        <div class="box_head">
                                                            <span>
                                                                <asp:Literal ID="litRoomReservationList" runat="server" Text="Group Reservations List"></asp:Literal>
                                                            </span>
                                                        </div>
                                                        <div class="clear">
                                                        </div>
                                                        <div class="box_content">
                                                            <asp:GridView ID="gvGroupReservationList" runat="server" AutoGenerateColumns="false"
                                                                ShowHeader="true" Width="100%" OnRowCommand="gvGroupReservationList_OnRowCommand">
                                                                <Columns>
                                                                    <%--<asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <div style="float: left; width: 20px; border-right: 1px solid #ccc;">
                                                                                &nbsp;
                                                                            </div>
                                                                            <div style="float: left; width: 75px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                                <asp:Label ID="lblGRGvHdrReservationNo" runat="server" Text="RES No."></asp:Label>
                                                                            </div>
                                                                            <div style="float: left; width: 100px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                                <asp:Label ID="lblGRGvHdrGuestCode" runat="server" Text="Guest/Grp. Code"></asp:Label>
                                                                            </div>
                                                                            <div style="float: left; width: 75px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                                <asp:Label ID="lblGRGvHdrUnitType" runat="server" Text="Unit Type"></asp:Label></div>
                                                                            <div style="float: left; width: 75px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                                <asp:Label ID="lblGRGvHdrUnit" runat="server" Text="Unit"></asp:Label></div>
                                                                            <div style="float: left; width: 75px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                                <asp:Label ID="lblGRGvHdrAdult" runat="server" Text="ADT"></asp:Label></div>
                                                                            <div style="float: left; width: 75px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                                <asp:Label ID="lblGRGvHdrChild" runat="server" Text="CHD"></asp:Label></div>
                                                                            <div style="float: left; width: 75px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                                <asp:Label ID="lblGRGvHdrINF" runat="server" Text="INF"></asp:Label></div>
                                                                            <div style="float: left; width: 100px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                                <asp:Label ID="lblGRGvHdrStatus" runat="server" Text="Status"></asp:Label></div>
                                                                            <div style="float: left; width: 100px; border-right: 1px solid #ccc;">
                                                                                <asp:Label ID="lblGRGvHdrRate" runat="server" Text="Rate"></asp:Label>
                                                                            </div>
                                                                            <div style="float: left; width: 100px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                                <asp:Label ID="lblGRGvHdrService" runat="server" Text="Service(s)"></asp:Label>
                                                                            </div>
                                                                            <div style="float: left; width: 100px; padding-left: 1px;">
                                                                                <asp:Label ID="lblGRGvHdrTotal" runat="server" Text="Total"></asp:Label>
                                                                            </div>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <div style="float: left; width: 20px; border-right: 1px solid #ccc;">
                                                                                <img id="imgGR<%# Container.DataItemIndex %>" alt="" src="../../images/icon111.png"
                                                                                    onclick="fnOnClickInnerGrid(this);" />
                                                                            </div>
                                                                            <div style="float: left; width: 75px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                                &nbsp;<%# DataBinder.Eval(Container.DataItem, "ReservationNo")%></div>
                                                                            <div style="float: left; width: 100px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                                &nbsp;
                                                                                <%# DataBinder.Eval(Container.DataItem, "GuestCode")%></div>
                                                                            <div style="float: left; width: 75px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                                &nbsp;
                                                                                <%# DataBinder.Eval(Container.DataItem, "UnitType")%></div>
                                                                            <div style="float: left; width: 75px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                                &nbsp;
                                                                                <%# DataBinder.Eval(Container.DataItem, "Unit")%></div>
                                                                            <div style="float: left; width: 75px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                                &nbsp;
                                                                                <%# DataBinder.Eval(Container.DataItem, "Adult")%></div>
                                                                            <div style="float: left; width: 75px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                                &nbsp;
                                                                                <%# DataBinder.Eval(Container.DataItem, "Child")%></div>
                                                                            <div style="float: left; width: 75px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                                &nbsp;
                                                                                <%# DataBinder.Eval(Container.DataItem, "INF")%></div>
                                                                            <div style="float: left; width: 100px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                                &nbsp;
                                                                                <%# DataBinder.Eval(Container.DataItem, "Status")%></div>
                                                                            <div style="float: left; width: 100px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                                &nbsp;
                                                                                <%# DataBinder.Eval(Container.DataItem, "Rate")%></div>
                                                                            <div style="float: left; width: 100px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                                &nbsp;
                                                                                <%# DataBinder.Eval(Container.DataItem, "Service")%></div>
                                                                            <div style="float: left; padding-left: 1px;">
                                                                                &nbsp;
                                                                                <%# DataBinder.Eval(Container.DataItem, "Total")%></div>
                                                                            <div id="dvGR<%# Container.DataItemIndex %>" style="display: none; width: 100%; float: left;">
                                                                                <div class="box_content">
                                                                                    <asp:GridView ID="InnerGridGRList" runat="server" Width="100%" ShowHeader="false"
                                                                                        AutoGenerateColumns="false">
                                                                                        <Columns>
                                                                                            <asp:TemplateField>
                                                                                                <ItemTemplate>
                                                                                                    <div style="float: left; width: 20px; border-right: 1px solid #ccc;">
                                                                                                        &nbsp;
                                                                                                    </div>
                                                                                                    <div style="float: left; width: 75px; border-right: 1px solid #ccc;">
                                                                                                        &nbsp;
                                                                                                    </div>
                                                                                                    <div style="float: left; width: 75px; padding-left: 1px; border-right: 1px solid #ccc;">
                                                                                                        <%#DataBinder.Eval(Container.DataItem, "ReservationNo")%>
                                                                                                    </div>
                                                                                                    <div style="float: left; width: 100px; padding-left: 1px; border-right: 1px solid #ccc;">
                                                                                                        &nbsp;
                                                                                                        <%#DataBinder.Eval(Container.DataItem, "GuestCode")%>
                                                                                                    </div>
                                                                                                    <div style="float: left; width: 75px; padding-left: 1px; border-right: 1px solid #ccc;">
                                                                                                        &nbsp;
                                                                                                        <%#DataBinder.Eval(Container.DataItem, "UnitType")%>
                                                                                                    </div>
                                                                                                    <div style="float: left; width: 75px; padding-left: 1px; border-right: 1px solid #ccc;">
                                                                                                        &nbsp;
                                                                                                        <%#DataBinder.Eval(Container.DataItem, "Unit")%>
                                                                                                    </div>
                                                                                                    <div style="float: left; width: 75px; padding-left: 1px; border-right: 1px solid #ccc;">
                                                                                                        &nbsp;
                                                                                                        <%#DataBinder.Eval(Container.DataItem, "Adult")%>
                                                                                                    </div>
                                                                                                    <div style="float: left; width: 75px; padding-left: 1px; border-right: 1px solid #ccc;">
                                                                                                        &nbsp;
                                                                                                        <%#DataBinder.Eval(Container.DataItem, "Child")%>
                                                                                                    </div>
                                                                                                    <div style="float: left; width: 75px; padding-left: 1px; border-right: 1px solid #ccc;">
                                                                                                        &nbsp;
                                                                                                        <%#DataBinder.Eval(Container.DataItem, "INF")%>
                                                                                                    </div>
                                                                                                    <div style="float: left; width: 100px; padding-left: 1px; border-right: 1px solid #ccc;">
                                                                                                        &nbsp;
                                                                                                        <%#DataBinder.Eval(Container.DataItem, "Status")%>
                                                                                                    </div>
                                                                                                    <div style="float: left; width: 100px; padding-left: 1px; border-right: 1px solid #ccc;">
                                                                                                        &nbsp;
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "Rate")%></div>
                                                                                                    <div style="float: left; width: 100px; padding-left: 1px; border-right: 1px solid #ccc;">
                                                                                                        &nbsp;
                                                                                                        <%#DataBinder.Eval(Container.DataItem, "Service")%>
                                                                                                    </div>
                                                                                                    <div style="float: left; width: 100px; padding-left: 1px;">
                                                                                                        &nbsp;
                                                                                                        <%#DataBinder.Eval(Container.DataItem, "Total")%></div>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </div>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>--%>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGRGvHdrReservationNo" runat="server" Text="Booking #"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "ReservationNo")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGRGvHdrGuestCode" runat="server" Text="Guest/Grp. Code"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "GuestCode")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGRGvHdrGuestName" runat="server" Text="Guest Name"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "GuestName")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGRGvHdrUnitType" runat="server" Text="Room Type"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "UnitType")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="20px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGRGvHdrUnit" runat="server" Text="Room"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "Unit")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="20px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGRGvHdrAdult" runat="server" Text="ADT"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "Adult")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="20px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGRGvHdrChild" runat="server" Text="CHD"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "Child")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="20px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGRGvHdrINF" runat="server" Text="INF"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "INF")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="20px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGRGvHdrStatus" runat="server" Text="Status"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <img src="../../images/CheckIn22x22.png" title="Checked In" id="imgGvHdrCheckIn"
                                                                                style="vertical-align: middle;" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGRGvHdrCheckIn" runat="server" Text="Check In"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "CheckIn")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGRGvHdrCheckOut" runat="server" Text="Check Out"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "CheckOut")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGRGvHdrRate" runat="server" Text="Rate"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "Rate")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGRGvHdrService" runat="server" Text="Service(s)"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "Service")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGRGvHdrTotal" runat="server" Text="Total"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "Total")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="40px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblActions" runat="server" Text="Action"></asp:Label>
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
                                                                                                        <asp:LinkButton ID="lnkSetReRoute" runat="server" ToolTip="Set ReRoute" CommandName="SETREROUTE"
                                                                                                            Style="background: none !important; border: none;" Text="Set ReRoute"><img src="../../images/file.png" /></asp:LinkButton>
                                                                                                    </li>
                                                                                                    <li>
                                                                                                        <asp:LinkButton ID="lnkPayInfo" runat="server" ToolTip="Pay Info" CommandName="PAYINFO"
                                                                                                            Style="background: none !important; border: none;" Text="Pay Info"><img src="../../images/file.png" /></asp:LinkButton>
                                                                                                    </li>
                                                                                                    <li>
                                                                                                        <asp:LinkButton ID="lnkAddService" runat="server" ToolTip="Add Service" CommandName="ADDSERVICE"
                                                                                                            Style="background: none !important; border: none;" Text="Add Service"><img src="../../images/file.png" /></asp:LinkButton>
                                                                                                    </li>
                                                                                                    <li>
                                                                                                        <asp:LinkButton ID="lnkUnitASG" runat="server" ToolTip="Unit ASG" CommandName="UNITASG"
                                                                                                            Style="background: none !important; border: none;" Text="Unit ASG"><img src="../../images/file.png" /></asp:LinkButton>
                                                                                                    </li>
                                                                                                    <li>
                                                                                                        <asp:LinkButton ID="lnkCHKIn" runat="server" ToolTip="CHK IN" CommandName="CHKIN"
                                                                                                            Style="background: none !important; border: none;" Text="CHK IN"><img src="../../images/file.png" /></asp:LinkButton>
                                                                                                    </li>
                                                                                                    <li>
                                                                                                        <asp:LinkButton ID="lnkViewFolio" runat="server" ToolTip="View Folio" CommandName="VIEWFOLIO"
                                                                                                            Style="background: none !important; border: none;" Text="View Folio"><img src="../../images/file.png" /></asp:LinkButton>
                                                                                                    </li>
                                                                                                    <li>
                                                                                                        <asp:LinkButton ID="lnkEdit" runat="server" ToolTip="Edit" CommandName="EDIT" Style="background: none !important;
                                                                                                            border: none;" Text="Edit"><img src="../../images/file.png" /></asp:LinkButton>
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
                                                                            <asp:Label ID="lblGRNoRecordFound" runat="server" Text="No Record Found."></asp:Label>
                                                                        </b>
                                                                    </div>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <%-- <tr>
                                                    <td style="padding-bottom: 20px;">
                                                        <div style="float: left; padding-right: 50px;">
                                                            <asp:Literal ID="litGRRoomOperation" runat="server" Text="Room Operation"></asp:Literal></div>
                                                        <div style="float: left; padding-right: 50px;">
                                                            <asp:Literal ID="litRODeposit" runat="server" Text="Deposit"></asp:Literal>&nbsp;&nbsp;&nbsp;&nbsp;0.00</div>
                                                        <div style="float: left; padding-right: 10px;">
                                                            <asp:Button ID="btnGRSetReRoute" runat="server" Text="Set ReRoute" /></div>
                                                        <div style="float: left; padding-right: 10px;">
                                                            <asp:Button ID="btnGRPayInfo" runat="server" Text="Pay Info" /></div>
                                                        <div style="float: left; padding-right: 10px;">
                                                            <asp:Button ID="btnGRAddService" runat="server" Text="Add Service" /></div>
                                                        <div style="float: left; padding-right: 10px;">
                                                            <asp:Button ID="btnGRUnitASG" runat="server" Text="Unit ASG" /></div>
                                                        <div style="float: left; padding-right: 10px;">
                                                            <asp:Button ID="btnGREdit" runat="server" Text="Edit" /></div>
                                                        <div style="float: left; padding-right: 10px;">
                                                            <asp:Button ID="btnGRChkIn" runat="server" Text="CHK IN" /></div>
                                                        <div style="float: left; padding-right: 10px;">
                                                            <asp:Button ID="btnGRViewFolio" runat="server" Text="View Folio" /></div>
                                                    </td>
                                                </tr>--%>
                                                <tr>
                                                    <td align="right" style="background-color: #DCDDDF; color: #0083CE; font-size: 15px;
                                                        font-weight: bold; padding: 9px;">
                                                        200.00
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-top: 20px;">
                                                        <div style="float: right; width: auto; display: inline-block;">
                                                            <asp:Button ID="btnGRPrint" runat="server" CausesValidation="true" Text="Print" Style="float: right;
                                                                margin-left: 5px;" />
                                                            <asp:Button ID="btnGRSave" runat="server" CausesValidation="false" Style="float: right;
                                                                margin-left: 5px;" Text="Save" OnClick="btnGRSave_Click" />
                                                            <asp:Button ID="btnGRBack" runat="server" CausesValidation="true" Text="Back" Style="float: right;
                                                                margin-left: 5px;" OnClick="btnGRBack_Click" />
                                                            <%--<asp:Button ID="btnGRCancel" runat="server" CausesValidation="false" Style="float: right;
                                                                margin-left: 5px;" Text="Cancel" OnClick="btnGRCancel_Click" />--%>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                    </asp:MultiView>
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
                        <%--<uc1:MsgBox ID="MessageBox" runat="server" />--%>
                    </div>
                </td>
            </tr>
        </table>
        <ajx:ModalPopupExtender ID="mpeCheckIn" runat="server" TargetControlID="hdnCheckIn"
            PopupControlID="pnlCheckIn" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnCheckIn" runat="server" />
        <asp:Panel ID="pnlCheckIn" runat="server" Width="800px" Style="display: none;">
            <ucCtrlCheckIn:CheckIn ID="ctrlCommonCheckIn" runat="server" OnbtnCheckInCallParent_Click="btnCheckInCallParent_Click" />
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpeOtherInfo" runat="server" TargetControlID="hdnOtherInfo"
            PopupControlID="pnlOtherInfo" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnOtherInfo" runat="server" />
        <asp:Panel ID="pnlOtherInfo" runat="server" Width="650px" Style="display: none;">
            <ucCtrlCommonOterhInformation:CommonOterhInformation ID="ctrlCommonOterhInformation"
                runat="server" />
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpeVoucherDetails" runat="server" TargetControlID="hdnVoucherDetails"
            PopupControlID="pnlVoucherDetails" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnVoucherDetails" runat="server" />
        <asp:Panel ID="pnlVoucherDetails" runat="server" Width="500px" Style="display: none;">
            <ucCtrlVoucherDetails:VoucherDetails ID="CommonCtrlVoucherDetails" runat="server" />
        </asp:Panel>
        <ucCtrlAddServices:AddServices ID="ctrlCommonAddServices" runat="server" OnbtnAddServicesCallParent_Click="btnAddServicesCallParent_Click" />
        <ucCtrlPayment:Payment ID="ctrlCommonPayment" runat="server" OnbtnPaymentCallParent_Click="btnPaymentCallParent_Click" />
        <ajx:ModalPopupExtender ID="mpeAddGroup" runat="server" TargetControlID="hdnAddGroup"
            PopupControlID="pnlAddGroup" BackgroundCssClass="mod_background" CancelControlID="imbAddGroupCancel">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnAddGroup" runat="server" />
        <asp:Panel ID="pnlAddGroup" runat="server" Width="400px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <div style="display: inline;">
                        <span>
                            <asp:Literal ID="litAddGroup" runat="server" Text="Add Group"></asp:Literal></span></div>
                    <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                        <asp:ImageButton ID="imbAddGroupCancel" runat="server" ImageUrl="~/images/closepopup.png"
                            Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;" />
                    </div>
                </div>
                <%--  <div class="box_head">
                    <span>
                        <asp:Literal ID="litAddGroup" runat="server" Text="Add Group"></asp:Literal></span></div>--%>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table border="0" cellpadding="2" cellspacing="2">
                        <tr>
                            <td class="isrequire">
                                <asp:Literal ID="litGroupName" runat="server" Text="Gropu Name"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtGroupName" runat="server"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rfvGroupName" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                        runat="server" ValidationGroup="IsRequireAddGroup" ControlToValidate="txtGroupName"
                                        Display="Static">
                                    </asp:RequiredFieldValidator>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Button ID="btnAddGroupSave" runat="server" Style="display: inline; padding-right: 10px;"
                                    ValidationGroup="IsRequireAddGroup" Text="Save" />
                                <%--  <asp:Button ID="btnAddGroupCancel" runat="server" Style="display: inline;" Text="Cancel" />--%>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </asp:Panel>
        <asp:HiddenField ID="hfPopupCustomeMessageRate" runat="server" />
        <ajx:ModalPopupExtender ID="mpeCustomePopupRate" runat="server" TargetControlID="hfPopupCustomeMessageRate"
            PopupControlID="pnlCustomeMessageRate" BackgroundCssClass="mod_background" CancelControlID="btnOKCustomeMsgPopupRate"
            DropShadow="true" BehaviorID="mpeCustomePopupRate">
        </ajx:ModalPopupExtender>
        <asp:Panel ID="pnlCustomeMessageRate" runat="server" Width="350px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="litHeaderCustomePopupMessageRate" runat="server" Text="Message"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td align="center" style="padding-bottom: 15px; color: Red;">
                                <asp:Label ID="lblCustomePopupMsgRate" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnOKCustomeMsgPopupRate" runat="server" Text="OK" Style="display: inline;
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
<script type="text/javascript">
    function fnOnClick(obj) {
        var imgID = obj.id;
        var divID = imgID.replace("imgid", "dvid");

        var toHidShowDiv = document.getElementById(divID);

        if (toHidShowDiv.style.display == 'none') {
            toHidShowDiv.style.display = 'block';
            document.getElementById(imgID).src = "../../images/icon222.png";
        }
        else if (toHidShowDiv.style.display == 'block') {
            toHidShowDiv.style.display = 'none';
            document.getElementById(imgID).src = "../../images/icon111.png";
        }
    }

    function fnOnClickInnerGrid(obj) {
        var imgID = obj.id;
        var divID = imgID.replace("imgGR", "dvGR");

        var toHidShowDiv = document.getElementById(divID);

        if (toHidShowDiv.style.display == 'none') {
            toHidShowDiv.style.display = 'block';
            document.getElementById(imgID).src = "../../images/icon222.png";
        }
        else if (toHidShowDiv.style.display == 'block') {
            toHidShowDiv.style.display = 'none';
            document.getElementById(imgID).src = "../../images/icon111.png";
        }
    }
</script>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updRoomReservation" ID="UpdateProgressRoomReservation"
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
