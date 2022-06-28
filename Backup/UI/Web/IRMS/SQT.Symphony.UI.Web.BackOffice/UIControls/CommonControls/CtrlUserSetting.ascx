<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlUserSetting.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.BackOffice.UIControls.CommonControls.CtrlUserSetting" %>
<%@ Register Src="~/MsgBox/MsgBx.ascx" TagName="MsgBx" TagPrefix="uc1" %>
<asp:UpdatePanel ID="updUserSetting" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="content">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                <asp:Literal ID="ltrMainHeader" runat="server"></asp:Literal>
                            </td>
                            <td class="boxtopright">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="boxleft">
                                &nbsp;
                            </td>
                            <td align="left">
                                <div class="box_form">
                                    <table cellpadding="2" cellspacing="2" width="100%">
                                        <tr>
                                            <td>
                                                <%if (IsFeedbackMessage)
                                                  { %>
                                                <div class="message finalsuccess">
                                                    <p>
                                                        <strong>
                                                            <asp:Literal ID="ltrMsgFeedback" runat="server"></asp:Literal></strong>
                                                    </p>
                                                </div>
                                                <%}%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h1>
                                                    <asp:Label ID="lblHeaderChangeDisplayName" runat="server"></asp:Label>
                                                </h1>
                                                <hr>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal ID="ltrDisplayName" runat="server"></asp:Literal>:&nbsp;&nbsp;<asp:Label
                                                    ID="lblDisplayName" runat="server"></asp:Label>&nbsp;&nbsp;
                                                <asp:LinkButton ID="lnkChangeDisplayName" runat="server"></asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h1>
                                                    <asp:Label ID="lblHeaderChangePassword" runat="server"></asp:Label>
                                                </h1>
                                                <hr>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal ID="ltrPassword" runat="server"></asp:Literal>:&nbsp;&nbsp;
                                                <asp:Label ID="lblPassword" runat="server" ></asp:Label>&nbsp;&nbsp;
                                                <asp:LinkButton ID="lnkChangePassword" runat="server"></asp:LinkButton>                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
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
                        <%--<uc1:MsgBox ID="MessageBox" runat="server" />--%>
                    </div>
                </td>
            </tr>
        </table>
        <ajx:ModalPopupExtender ID="mpeChangeDisplayName" runat="server" TargetControlID="lnkChangeDisplayName"
            PopupControlID="pnlChangeDisplayName" BackgroundCssClass="mod_background" CancelControlID="btnCancelChangeDisplayName">
        </ajx:ModalPopupExtender>
        <asp:Panel ID="pnlChangeDisplayName" runat="server" style="display:none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="ltrHeaderChangeDisplayName" runat="server"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td colspan="2">
                                <div style="float: right; padding-bottom:5px;">
                                    <b>
                                    <asp:Literal ID="litGeneralMandartoryFiledMessageForDisplayName" runat="server"></asp:Literal>
                                    </b>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire" align="left" valign="top">
                                <asp:Literal ID="ltrUserDisplayName" runat="server"></asp:Literal>
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="txtDisplayName" runat="server" MaxLength="67"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rvfDisplayName" runat="server" ControlToValidate="txtDisplayName"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequireDisplayName"></asp:RequiredFieldValidator>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <table cellpadding="3" cellspacing="3" style="margin-left: 5px; margin-top: 15px;">
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnSaveDisplayName" runat="server" CausesValidation="true" ValidationGroup="IsRequireDisplayName"
                                                OnClick="btnSaveDisplayName_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnCancelChangeDisplayName" runat="server" CausesValidation="false" />
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
        <ajx:ModalPopupExtender ID="mpeChangePassword" runat="server" TargetControlID="lnkChangePassword"
            PopupControlID="pnlChangePassword" BackgroundCssClass="mod_background" CancelControlID="btnCancelChangePassword">
        </ajx:ModalPopupExtender>
        <asp:Panel ID="pnlChangePassword" runat="server" Width="500px" style="display:none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="ltrHeaderChangePassword" runat="server"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td colspan="2">
                                <%if (IsWrongPassword)
                                  { %>
                                <div class="message finalsuccess">
                                    <p>
                                        <strong>
                                            <asp:Literal ID="ltrMsgWrongPassword" runat="server"></asp:Literal></strong>
                                    </p>
                                </div>
                                <%}%>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div style="float: right; padding-bottom:5px;">
                                    <b>
                                    <asp:Literal ID="litGeneralMandartoryFiledMessageForPassword" runat="server"></asp:Literal>
                                    </b>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire" align="left" valign="top">
                                <asp:Literal ID="ltrCurrentPassword" runat="server"></asp:Literal>
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="txtCurrentPassword" runat="server" TextMode="Password" MaxLength="27"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rfvCurrentPassword" runat="server" ControlToValidate="txtCurrentPassword"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequirePassword"></asp:RequiredFieldValidator>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire" align="left" valign="top">
                                <asp:Literal ID="ltrNewPassword" runat="server"></asp:Literal>
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" MaxLength="27"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rfvNewPassword" runat="server" ControlToValidate="txtNewPassword"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequirePassword"></asp:RequiredFieldValidator>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire" align="left" valign="top">
                                <asp:Literal ID="ltrRepeatPassword" runat="server"></asp:Literal>
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="txtRepeatPassword" runat="server" TextMode="Password" MaxLength="27"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rfvRepeatPassword" runat="server" ControlToValidate="txtRepeatPassword"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequirePassword"></asp:RequiredFieldValidator>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td valign="top">
                                <asp:CompareValidator ID="cmpvRepeatPassword" runat="server" ControlToValidate="txtRepeatPassword"
                                    ControlToCompare="txtNewPassword" ForeColor="Red" ValidationGroup="IsRequirePassword"
                                    Display="Dynamic"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <table cellpadding="3" cellspacing="3" style="margin-left: 5px;">
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnSavePassword" runat="server" CausesValidation="true" ValidationGroup="IsRequirePassword"
                                                OnClick="btnSavePassword_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnCancelChangePassword" runat="server" CausesValidation="false" />
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
    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBx ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updUserSetting" ID="uPgrUserSetting"
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
