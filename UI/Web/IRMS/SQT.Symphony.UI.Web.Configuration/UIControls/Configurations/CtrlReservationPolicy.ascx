<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlReservationPolicy.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.Configurations.CtrlReservationPolicy" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript" language="javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<asp:UpdatePanel ID="upnlReservationConfig" runat="server">
    <ContentTemplate>
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
                                        <table cellpadding="2" cellspacing="2" width="100%">
                                            <tr>
                                                <td colspan="2">
                                                    <%if (IsMessage)
                                                      { %>
                                                    <div class="message finalsuccess">
                                                        <p>
                                                            <strong>
                                                                <asp:Literal ID="litFeedbackMessage" runat="server"></asp:Literal></strong>
                                                        </p>
                                                    </div>
                                                    <%}%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="45%" style="vertical-align: top;" valign="top">
                                                    <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                        <tr>
                                                            <th style="width: 175px !important;">
                                                                <asp:Literal ID="litBeforeCheckInHR" runat="server"></asp:Literal>
                                                            </th>
                                                            <td>
                                                                <asp:TextBox ID="txtBeforeCheckInHR" Style="width: 100px;" runat="server" MaxLength="2"></asp:TextBox>
                                                                <%--<asp:RegularExpressionValidator ID="rgvBeforeCheckInHR" runat="server" ValidationGroup="IsRequire"  ValidationExpression="^(20|21|22|23|[01]\d|\d)(([:][0-5]\d){1,2})$" SetFocusOnError="true" ControlToValidate="txtBeforeCheckInHR" Display="Dynamic" CssClass="input-notification error png_bg"></asp:RegularExpressionValidator>--%>
                                                                <ajx:FilteredTextBoxExtender ID="fltBeforeCheckInHR" runat="server" FilterMode="ValidChars"
                                                                    ValidChars="0123456789" TargetControlID="txtBeforeCheckInHR">
                                                                </ajx:FilteredTextBoxExtender>
                                                                <asp:RangeValidator ID="rngBeforeCheckInHr" Display="Dynamic" runat="server" SetFocusOnError="true"
                                                                    ValidationGroup="IsRequire" ControlToValidate="txtBeforeCheckInHR" ForeColor="Red"
                                                                    ErrorMessage="Before hour set between 0-24" MinimumValue="0" MaximumValue="24"
                                                                    Type="Double"></asp:RangeValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th>
                                                                <asp:Literal ID="litBeforeCharge" runat="server"></asp:Literal>
                                                            </th>
                                                            <td>
                                                                <asp:TextBox ID="txtBeforeCharge" runat="server" MaxLength="24" Style="width: 125px;"></asp:TextBox>
                                                                <asp:DropDownList ID="ddlBeforeCharge" runat="server" Style="width: 91px; height: 24px;
                                                                    margin-top: -1; margin-left: 6px;" OnSelectedIndexChanged="ddlBeforeCharge_SelectedIndexChanged"
                                                                    AutoPostBack="true">
                                                                </asp:DropDownList>
                                                                <br />
                                                                <ajx:FilteredTextBoxExtender ID="fltBeforeCharge" runat="server" FilterMode="ValidChars"
                                                                    ValidChars="0123456789." TargetControlID="txtBeforeCharge">
                                                                </ajx:FilteredTextBoxExtender>
                                                                <asp:RegularExpressionValidator Display="Dynamic" ID="refBeforeCharge" runat="server"
                                                                    ForeColor="Red" ControlToValidate="txtBeforeCharge" SetFocusOnError="true" ValidationGroup="IsRequire">
                                                                </asp:RegularExpressionValidator>
                                                                <asp:RangeValidator ID="rbgBeforeCharge" Display="Dynamic" runat="server" MinimumValue="0"
                                                                    MaximumValue="100" ControlToValidate="txtBeforeCharge" SetFocusOnError="true"
                                                                    ValidationGroup="IsRequire" ForeColor="Red" Type="Double"></asp:RangeValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th>
                                                                <asp:Literal ID="litAfterCheckInHR" runat="server"></asp:Literal>
                                                            </th>
                                                            <td>
                                                                <asp:TextBox ID="txtAfterCheckInHR" Style="width: 100px;" runat="server" MaxLength="2"></asp:TextBox>
                                                                <ajx:FilteredTextBoxExtender ID="flttxtAfterCheckInHR" runat="server" FilterMode="ValidChars"
                                                                    ValidChars="0123456789" TargetControlID="txtAfterCheckInHR">
                                                                </ajx:FilteredTextBoxExtender>
                                                                <asp:RangeValidator ID="RGVtxtAfterCheckInHR" Display="Dynamic" runat="server" SetFocusOnError="true"
                                                                    ValidationGroup="IsRequire" ControlToValidate="txtAfterCheckInHR" ForeColor="Red"
                                                                    ErrorMessage="Before hour set between 0-24" MinimumValue="0" MaximumValue="24"
                                                                    Type="Double"></asp:RangeValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th>
                                                                <asp:Literal ID="litAfterCharge" runat="server"></asp:Literal>
                                                            </th>
                                                            <td>
                                                                <asp:TextBox ID="txtAfterCharge" runat="server" MaxLength="24" Style="width: 125px;"></asp:TextBox>
                                                                <asp:DropDownList ID="ddlAfterCharge" runat="server" Style="width: 91px; height: 24px;
                                                                    margin-top: -1; margin-left: 6px;" OnSelectedIndexChanged="ddlAfterCharge_SelectedIndexChanged"
                                                                    AutoPostBack="true">
                                                                </asp:DropDownList>
                                                                <br />
                                                                <ajx:FilteredTextBoxExtender ID="fltAfterCharge" runat="server" FilterMode="ValidChars"
                                                                    ValidChars="0123456789." TargetControlID="txtAfterCharge">
                                                                </ajx:FilteredTextBoxExtender>
                                                                <asp:RegularExpressionValidator Display="Dynamic" ID="regAfterCharge" runat="server"
                                                                    ForeColor="Red" ControlToValidate="txtAfterCharge" SetFocusOnError="true" ValidationGroup="IsRequire">
                                                                </asp:RegularExpressionValidator>
                                                                <asp:RangeValidator ID="rgvAfterCharge" Display="Dynamic" runat="server" MinimumValue="0"
                                                                    MaximumValue="100" ControlToValidate="txtAfterCharge" SetFocusOnError="true"
                                                                    ValidationGroup="IsRequire" ForeColor="Red" Type="Double"></asp:RangeValidator>
                                                            </td>
                                                        </tr>
                                                        <%--<tr>
                                                            <th>
                                                                <asp:Literal ID="litReservationType" runat="server"></asp:Literal>
                                                            </th>
                                                            <td>
                                                                <asp:DropDownList ID="ddlReservationType" runat="server">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>--%>
                                                    </table>
                                                </td>
                                                <td width="55%" style="vertical-align: top;" valign="top">
                                                    <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                        <tr>
                                                            <td class="checkbox_new">
                                                                <asp:CheckBox ID="ChkIsReasonRequired" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="checkbox_new">
                                                                <asp:CheckBox ID="ChkIsFirstNightChargeCompForCashPayers" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="checkbox_new">
                                                                <asp:CheckBox ID="ChkIsAssignRoomToUnConfirmRes" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="checkbox_new">
                                                                <asp:CheckBox ID="ChkIsAssignRoomOnReservation" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="checkbox_new">
                                                                <asp:CheckBox ID="ChkIsUserCanOverrideRackRate" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="checkbox_new">
                                                                <asp:CheckBox ID="ChkIsUserCanApplyDiscount" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="checkbox_new">
                                                                <asp:CheckBox ID="ChkIsUserCanSetTaxExempt" runat="server" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <div style="float: right; width: auto; display: inline-block;">
                                                        <asp:Button ID="btnCancel" Text="Cancel" Style="float: right; margin-left: 5px;"
                                                            runat="server" ImageUrl="~/images/cancle.png" OnClick="btnCancel_Click" />
                                                        <asp:Button ID="btnSave" Text="Save" Style="float: right; margin-left: 5px;" runat="server"
                                                            ImageUrl="~/images/save.png" ValidationGroup="IsRequire" CausesValidation="true" OnClientClick="fnDisplayCatchErrorMessage();"
                                                            OnClick="btnSave_Click" />
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
                        </tr>
                    </table>
                    <div class="clear_divider">
                    </div>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="upnlReservationConfig" ID="UpdateProgressReservationConfig"
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
