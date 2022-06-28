<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlAddEditVIPType.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.PriceManager.CtrlAddEditVIPType" %>
<ajx:ModalPopupExtender ID="mpeAddEditRecord" runat="server" TargetControlID="hfAddEditRecord"
    PopupControlID="pnlAddEditRecord" BackgroundCssClass="mod_background" CancelControlID="btnCancel">
</ajx:ModalPopupExtender>
<asp:HiddenField ID="hfAddEditRecord" runat="server" />
<asp:Panel ID="pnlAddEditRecord" runat="server" Width="430px" style="display:none;">
    <div class="box_col1">
        <div class="box_head">
            <span>
                <asp:Literal ID="litHeaderPopupVIPType" runat="server"></asp:Literal></span></div>
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
                    <td>
                       <b><asp:Literal ID="litVIPTypeName" runat="server"></asp:Literal></b>
                    </td>
                    <td>
                        <asp:TextBox ID="txtVIPTypeName" runat="server" MaxLength="65"></asp:TextBox>
                        <span>
                            <asp:RequiredFieldValidator ID="rvfName" runat="server" ControlToValidate="txtVIPTypeName"
                                SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire"></asp:RequiredFieldValidator>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b><asp:Literal ID="litCode" runat="server"></asp:Literal></b>
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
