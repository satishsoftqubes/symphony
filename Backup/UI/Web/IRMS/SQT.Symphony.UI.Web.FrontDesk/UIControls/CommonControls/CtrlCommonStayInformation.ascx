<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCommonStayInformation.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls.CtrlCommonStayInformation" %>
<script type="text/javascript" language="javascript">
    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

</script>
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
            <asp:TextBox ID="txtCheckInDate" runat="server" Style="width: 90px !important;" onkeypress="return false;"></asp:TextBox>
            <asp:Image ID="imgCheckInDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                Height="20px" Width="20px" />
            <ajx:CalendarExtender ID="calCheckInDate" PopupButtonID="imgCheckInDate" TargetControlID="txtCheckInDate"
                runat="server" Format="dd/MMM/yyyy">
            </ajx:CalendarExtender>
            <img src="../../images/clear.png" id="imgAD" style="vertical-align: middle;" title="Clear Date"
                onclick="fnClearDate('<%= txtCheckInDate.ClientID %>');" />
            <span>
                <asp:RequiredFieldValidator ID="rfvCheckInDate" SetFocusOnError="true" CssClass="input-notification error png_bg"
                    runat="server" ValidationGroup="IsRequire" ControlToValidate="txtCheckInDate"
                    Display="Dynamic">
                </asp:RequiredFieldValidator>
            </span>&nbsp;&nbsp;&nbsp;
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
            <asp:TextBox ID="txtNight" runat="server" MaxLength="3" Style="width: 40px !important;"
                AutoPostBack="true"></asp:TextBox>
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
            <asp:Literal ID="litCheckOutDate" runat="server" Text="Check Out"></asp:Literal>
        </td>
        <td>
            <asp:TextBox ID="txtCheckOutDate" runat="server" onkeypress="return false;"></asp:TextBox>
            <asp:Image ID="imgCheckOutDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                Height="20px" Width="20px" />
            <ajx:CalendarExtender ID="calCheckOutDate" PopupButtonID="imgCheckOutDate" TargetControlID="txtCheckOutDate"
                runat="server" Format="dd/MMM/yyyy">
            </ajx:CalendarExtender>
            <img src="../../images/clear.png" id="imgDD" style="vertical-align: middle;" title="Clear Date"
                onclick="fnClearDate('<%= txtCheckOutDate.ClientID %>');" />
            <span>
                <asp:RequiredFieldValidator ID="rfvCheckOutDate" SetFocusOnError="true" CssClass="input-notification error png_bg"
                    runat="server" ValidationGroup="IsRequire" ControlToValidate="txtCheckOutDate"
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
            <asp:Literal ID="litCorporate" runat="server" Text="Company"></asp:Literal>
        </td>
        <td>
            <asp:DropDownList ID="ddlCorporate" runat="server">
                <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                <asp:ListItem Text="Infosys" Value="Vatsal Shah"></asp:ListItem>
                <asp:ListItem Text="Wipro" Value="Jayesh Patel"></asp:ListItem>
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
                <asp:ListItem Text="Unit RateCard" Value="Unit RateCard"></asp:ListItem>
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
        <td>
            <asp:Literal ID="litDiscount" runat="server" Text="Discount"></asp:Literal>
        </td>
        <td>
            <asp:DropDownList ID="ddlDiscount" runat="server">
                <asp:ListItem Selected="True" Text="-Select-" Value="-Select-"></asp:ListItem>
                <asp:ListItem Text="Diwali Discount" Value="Diwali Discount"></asp:ListItem>
                <asp:ListItem Text="Christmas Discount" Value="Christmas Discount"></asp:ListItem>
            </asp:DropDownList>
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
            <asp:Literal ID="litInfo" runat="server" Text="Inf"></asp:Literal>&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtInfo" runat="server" MaxLength="3"></asp:TextBox>
            <ajx:NumericUpDownExtender ID="InfoNUDE" runat="server" TargetControlID="txtInfo"
                Width="60" Minimum="0" Maximum="999" />
            <ajx:FilteredTextBoxExtender ID="ftInfo" runat="server" TargetControlID="txtInfo"
                FilterType="Numbers" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Literal ID="Literal1" runat="server" Text="Guest Type"></asp:Literal>
        </td>
        <td>
            <asp:DropDownList runat="server" ID="DropDownList1">
                <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                <asp:ListItem Text="VIP" Value="VIP"></asp:ListItem>
                <asp:ListItem Text="VVIP" Value="VVIP"></asp:ListItem>
                <asp:ListItem Text="Investor" Value="Investor"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Literal ID="Literal2" runat="server" Text="Source of Business"></asp:Literal>
        </td>
        <td>
            <asp:DropDownList runat="server" ID="DropDownList2">
                <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                <asp:ListItem Text="Internet" Value="Internet"></asp:ListItem>
                <asp:ListItem Text="Agent" Value="Agent"></asp:ListItem>
                <asp:ListItem Text="Referal" Value="Referal"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Literal ID="litAgent" runat="server" Text="Booking Agent"></asp:Literal>
        </td>
        <td>
            <asp:DropDownList runat="server" ID="ddlAgent">
                <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                <asp:ListItem Text="Mr. Vinod Rao" Value="Mr. Vinod Rao"></asp:ListItem>
                <asp:ListItem Text="Ms. Krupali Patel" Value="Ms. Krupali Patel"></asp:ListItem>
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
        <td>
            Standard Instruction
        </td>
        <td>
            <asp:TextBox ID="txtSpecificInstruction" runat="server" Enabled="false" TextMode="MultiLine"
                SkinID="nowidth" Width="334px" Height="35px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="vertical-align: top;">
            Specific Instruction
        </td>
        <td>
            <asp:TextBox ID="txtNote" runat="server" SkinID="nowidth" Width="334px" Height="35px"
                TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <hr />
            <div style="float: left; width: auto; display: inline-block;">
                <asp:Button ID="btnCalRate" runat="server" Style="float: left; padding-left: 10px;"
                    Text="Calculate Rate" OnClick="btnCalRate_OnClick" />
            </div>
        </td>
    </tr>
    <tr>
        <td colspan="2" style="padding: 0px;">
            <table id="tblRateCalculation" runat="server" visible="false" width="80%">
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
                        Room Rent
                    </td>
                    <td>
                        90
                    </td>
                    <td>
                        15000.00
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
                        1500.00
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
                        00.00
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
                        <b>16500.00</b>
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
                        10000.00
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
                        <b>26500.00</b>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>