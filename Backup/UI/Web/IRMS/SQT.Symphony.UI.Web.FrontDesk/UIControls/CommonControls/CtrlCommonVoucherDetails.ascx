<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCommonVoucherDetails.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls.CtrlCommonVoucherDetails" %>
<div class="box_col1">
    <div class="box_head">
        <span>
            <asp:Literal ID="litOtherInformation" runat="server" Text="Voucher Detail [20632]"></asp:Literal></span></div>
    <div class="clear">
    </div>
    <div class="box_form">
        <table cellpadding="2" cellspacing="2" border="0" width="100%">
            <tr>
                <td>
                    <fieldset style="border: 1px solid #ccc !important;">
                        <legend>
                            <asp:Literal ID="litAgentInformation" Text="Agent Information" runat="server"></asp:Literal>
                        </legend>
                        <table cellpadding="2" cellspacing="2" width="100%">
                            <tr>
                                <td width="100px">
                                    <asp:Literal ID="litAgentName" runat="server" Text="Agent Name"></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="litDisplayAgentName" runat="server" Text="PMW Travel"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Literal ID="litAgentCode" runat="server" Text="Agent Code"></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="litDisplayAgentCode" runat="server" Text="PMW"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Literal ID="litCreditLimit" runat="server" Text="Credit Limit"></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="litDisplayCreditLimit" runat="server" Text="0.00"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td class="isrequire" style="width: 100px !important;">
                                    <asp:Literal ID="litVoucherNo" runat="server" Text="Voucher No."></asp:Literal>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtVoucherNo" runat="server" MaxLength="24" Style="text-align: right;
                                        width: 100px !important;"></asp:TextBox>
                                    &nbsp;&nbsp;&nbsp; <span>
                                        <asp:RequiredFieldValidator ID="rfvVoucherNo" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                            runat="server" ValidationGroup="IsRequireVoucher" ControlToValidate="txtVoucherNo" Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                    </span>
                                    <%--<asp:RegularExpressionValidator ID="revVoucherNo" SetFocusOnError="True" runat="server"
                                        ValidationGroup="IsRequire" ControlToValidate="txtVoucherNo" Display="Dynamic"
                                        ForeColor="Red" ErrorMessage="2 digits allow after decimal point."  ValidationExpression="\\d{0,24}.\\d{0,2}"></asp:RegularExpressionValidator>--%>
                                    <ajx:FilteredTextBoxExtender ID="ftVoucherNo" runat="server" TargetControlID="txtVoucherNo"
                                        FilterType="Custom, Numbers" ValidChars="." />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkCommission" runat="server" Text="Commission" />
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
            <tr>
                <td>
                    <fieldset style="border: 1px solid #ccc !important;">
                        <legend>
                            <asp:CheckBox ID="chkDirectBillToAgentFolio" Text="Direct Bill To Agent Folio" runat="server" />
                        </legend>
                        <table cellpadding="2" cellspacing="2" width="100%">
                            <tr>
                                <td width="100px">
                                    <asp:Literal ID="litBillingAddress" runat="server" Text="Billing Address"></asp:Literal>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlAddress" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:CheckBoxList ID="chkBillingInfo" runat="server" RepeatDirection="Horizontal"
                                        RepeatColumns="2">
                                        <asp:ListItem Text="Accommodation Charges" Value="Accommodation Charges"></asp:ListItem>
                                        <asp:ListItem Text="Miscellaneous Charges" Value="Miscellaneous Charges"></asp:ListItem>
                                        <asp:ListItem Text="Restauraunt Charges" Value="Restauraunt Charges"></asp:ListItem>
                                        <asp:ListItem Text="POS" Value="POS"></asp:ListItem>
                                        <asp:ListItem Text="Phone Charges" Value="Phone Charges"></asp:ListItem>
                                    </asp:CheckBoxList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Literal ID="litNote" runat="server" Text="Notes"></asp:Literal>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNote" runat="server" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btnOtherInfoSave" runat="server" Text="Save" Style="display: inline;"
                        ValidationGroup="IsRequireVoucher" />
                    <asp:Button ID="btnOtherInfoCancel" runat="server" Text="Cancel" Style="display: inline;" />
                    <a href="#">
                        <img src="../../images/Print32x32.png" style="vertical-align:middle;" /></a>
                </td>
            </tr>
        </table>
    </div>
    <div class="clear">
    </div>
</div>
