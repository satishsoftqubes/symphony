<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlAddEditDiscount.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.PriceManager.CtrlAddEditDiscount" %>
<ajx:ModalPopupExtender ID="mpeAddEditRecord" runat="server" TargetControlID="hfAddEditRecord"
    PopupControlID="pnlAddEditRecord" BackgroundCssClass="mod_background" CancelControlID="btnCancel">
</ajx:ModalPopupExtender>
<asp:HiddenField ID="hfAddEditRecord" runat="server" />
<asp:Panel ID="pnlAddEditRecord" runat="server">
    <div class="box_col1">
        <div class="box_head">
            <span>
                <asp:Literal ID="litHeaderPopupDiscount" runat="server"></asp:Literal></span></div>
        <div class="clear">
        </div>
        <div class="box_form">
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td colspan="2">
                        <%if (IsPopupMessage)
                          { %>
                        <div class="message finalsuccess">
                            <p>
                                <strong>
                                    <asp:Literal ID="litMsgPopup" runat="server"></asp:Literal></strong>
                            </p>
                        </div>
                        <%}%>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div style="float: right; padding-bottom: 5px;">
                            <b>
                                <asp:Literal ID="litGeneralMandartoryFiledMessage" runat="server"></asp:Literal>
                            </b>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="isrequire" align="left" style="padding-top: 2px; padding-bottom: 6px;">
                        <asp:Literal ID="litDiscountName" runat="server"></asp:Literal>
                    </td>
                    <td align="left" style="padding-top: 2px; padding-bottom: 6px;">
                        <asp:TextBox ID="txtDiscountName" runat="server" MaxLength="70"></asp:TextBox>
                        <span>
                            <asp:RequiredFieldValidator ID="rvfDiscountName" runat="server" ControlToValidate="txtDiscountName"
                                SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire"></asp:RequiredFieldValidator>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td class="isrequire">
                        <asp:Literal ID="litDiscountRate" runat="server"></asp:Literal>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDiscountRate" runat="server" MaxLength="18" Style="text-align: right;"
                            SkinID="nowidth" Width="120px"></asp:TextBox>
                        <span>
                            <ajx:FilteredTextBoxExtender ID="fteRate" runat="server" TargetControlID="txtDiscountRate"
                                FilterMode="ValidChars" ValidChars="0123456789.">
                            </ajx:FilteredTextBoxExtender>
                            <asp:RequiredFieldValidator ID="rvfRate" runat="server" ControlToValidate="txtDiscountRate"
                                SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire"></asp:RequiredFieldValidator>
                        </span>
                        <asp:DropDownList ID="ddlRateType" runat="server" SkinID="nowidth" Width="100px"
                            OnSelectedIndexChanged="ddlRateType_OnSelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <div>
                            <asp:RangeValidator ID="rngvRate" runat="server" ControlToValidate="txtDiscountRate"
                                SetFocusOnError="true" Type="Double" Display="Dynamic" ValidationGroup="IsRequire"
                                MinimumValue="0" ForeColor="Red"></asp:RangeValidator>
                        </div>
                        <div>
                            <asp:RegularExpressionValidator Display="Dynamic" ID="regExpRate" runat="server"
                                ForeColor="Red" ControlToValidate="txtDiscountRate" SetFocusOnError="true" ValidationGroup="IsRequire">
                            </asp:RegularExpressionValidator>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="isrequire" style="padding-bottom: 6px;">
                        <asp:Literal ID="litDiscountType" runat="server"></asp:Literal>
                    </td>
                    <td style="padding-bottom: 6px;">
                        <asp:DropDownList ID="ddlDiscountType" runat="server">
                        </asp:DropDownList>
                        <span>
                            <asp:RequiredFieldValidator ID="rfvDiscountType" runat="server" ControlToValidate="ddlDiscountType"
                                InitialValue="00000000-0000-0000-0000-000000000000" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                ValidationGroup="IsRequire"></asp:RequiredFieldValidator>
                        </span>
                    </td>
                </tr>
                <tr>
                    <th align="left" valign="top" style="padding-left: 3px;">
                        <asp:Literal ID="litDetails" runat="server"></asp:Literal>
                    </th>
                    <td>
                        <asp:TextBox ID="txtDetails" runat="server" SkinID="BigInput" TextMode="MultiLine"
                            Height="70px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <table cellpadding="3" cellspacing="3" style="margin-left: 5px; margin-top: 15px;">
                            <tr>
                                <td>
                                    <asp:Button ID="btnSaveAndClose" runat="server" CausesValidation="true" ValidationGroup="IsRequire"
                                        OnClick="btnSaveAndClose_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnSave" runat="server" CausesValidation="true" ValidationGroup="IsRequire"
                                        OnClick="btnSave_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnCancel" runat="server" CausesValidation="false" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <div class="clear">
        </div>
    </div>
</asp:Panel>
