<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlAdddEditStayType.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.PriceManager.CtrlAdddEditStayType" %>
<script type="text/javascript" language="javascript">
    function fnValidateMinMax() {
        if (Page_ClientValidate("IsRequire")) {
            var minDays = document.getElementById('<%= txtMinDays.ClientID %>').value;
            var maxDays = document.getElementById('<%= txtMaxDays.ClientID %>').value;
            if (minDays != '' && maxDays != '') {
                if (parseInt(maxDays) < parseInt(minDays)) {
                    $find('mpeCustomePopup').show();
                    return false;
                }
                else {
                    return true;
                }
            }
            else {
                return true;
            }
        }
        else {
            return false;
        }
    }
</script>
<ajx:ModalPopupExtender ID="mpeAddEditRecord" runat="server" TargetControlID="hfAddEditRecord"
    PopupControlID="pnlAddEditRecord" BackgroundCssClass="mod_background" CancelControlID="btnCancel">
</ajx:ModalPopupExtender>
<asp:HiddenField ID="hfAddEditRecord" runat="server" />
<asp:Panel ID="pnlAddEditRecord" runat="server">
    <div class="box_col1">
        <div class="box_head">
            <span>
                <asp:Literal ID="litHeaderPopupStayType" runat="server"></asp:Literal></span></div>
        <div class="clear">
        </div>
        <div class="box_form">
            <table cellpadding="2" cellspacing="2" width="100%">
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
                    <td class="isrequire">
                        <asp:Literal ID="litName" runat="server"></asp:Literal>
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" MaxLength="65"></asp:TextBox>
                        <span>
                            <asp:RequiredFieldValidator ID="rvfName" runat="server" ControlToValidate="txtName"
                                SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire"></asp:RequiredFieldValidator>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td class="isrequire">
                        <asp:Literal ID="litCode" runat="server"></asp:Literal>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCode" runat="server" MaxLength="7"></asp:TextBox>
                        <span>
                            <asp:RequiredFieldValidator ID="rvfCode" runat="server" ControlToValidate="txtCode"
                                SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire"></asp:RequiredFieldValidator>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td class="isrequire">
                        <asp:Literal ID="litMinMaxDays" runat="server"></asp:Literal>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMinDays" runat="server" MaxLength="9" Width="116px" SkinID="nowidth"
                            Style="text-align: right;"></asp:TextBox>
                        <ajx:FilteredTextBoxExtender ID="fteMinDays" runat="server" FilterMode="ValidChars"
                            ValidChars="0123456789" TargetControlID="txtMinDays">
                        </ajx:FilteredTextBoxExtender>
                        <span>
                            <asp:RequiredFieldValidator ID="rfvMinDays" runat="server" ControlToValidate="txtMinDays"
                                Display="Dynamic" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                ValidationGroup="IsRequire"></asp:RequiredFieldValidator>
                        </span>&nbsp;-&nbsp;
                        <asp:TextBox ID="txtMaxDays" runat="server" MaxLength="9" Width="116px" SkinID="nowidth"
                            Style="text-align: right;"></asp:TextBox>
                        <ajx:FilteredTextBoxExtender ID="fteMaxDays" runat="server" FilterMode="ValidChars"
                            ValidChars="0123456789" TargetControlID="txtMaxDays">
                        </ajx:FilteredTextBoxExtender>
                        <%--<div>
                            <asp:CompareValidator ID="cmpvMinMaxDays" runat="server" ControlToValidate="txtMinDays"
                                ControlToCompare="txtMaxDays" Operator="LessThanEqual" Type="Double" SetFocusOnError="true"
                                Display="Dynamic" ForeColor="Red" ValidationGroup="IsRequire"></asp:CompareValidator>
                        </div>--%>
                    </td>
                </tr>
                <tr>
                    <th align="left" valign="top">
                        <asp:Literal ID="litDetails" runat="server"></asp:Literal>
                    </th>
                    <td>
                        <asp:TextBox ID="txtDetails" runat="server" SkinID="nowidth" Width="450px" TextMode="MultiLine"
                            Height="70px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <table cellpadding="3" cellspacing="3" style="margin-left: 5px; margin-top: 15px;">
                            <tr>
                                <td>
                                    <asp:Button ID="btnSaveAndClose" runat="server" CausesValidation="true" ValidationGroup="IsRequire"
                                        OnClick="btnSaveAndClose_Click" OnClientClick="return fnValidateMinMax();" />
                                </td>
                                <td>
                                    <asp:Button ID="btnSave" runat="server" CausesValidation="true" ValidationGroup="IsRequire"
                                        OnClick="btnSave_Click" OnClientClick="return fnValidateMinMax();" />
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
