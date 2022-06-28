<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlSettings.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.DashBoard.CtrlSettings" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<asp:UpdatePanel ID="updtSettings" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box" style="height: 200px !important;">
            <tr>
                <td class="boxtopleft">
                    &nbsp;
                </td>
                <td class="boxtopcenter">
                    SETTINGS
                </td>
                <td class="boxtopright">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="boxleft">
                    &nbsp;
                </td>
                <td style="vertical-align: top;">
                    <table cellpadding="3" cellspacing="3" width="100%">
                        <tr style="display:none;">
                            <td class="pagesubheader">
                                <asp:Literal ID="Literal5" runat="server" Text="DashBoard Gadget Information"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="height: 26px;">
                                    <%if (IsInsert)
                                      { %>
                                    <div class="ResetSuccessfully">
                                        <div style="float: left; padding-top: 7px; width: 25px; height: 24px; margin-right: 10px;">
                                            <img src="../../images/success.png" />
                                        </div>
                                        <div>
                                            <asp:Label ID="lblSaveMsg" runat="server"></asp:Label></div>
                                        <div style="height: 10px;">
                                        </div>
                                    </div>
                                    <% }%>
                                </div>
                            </td>
                        </tr>
                        <tr style="display:none;">
                            <td class="dTableBox" style="padding: 10px 0px;">
                                <asp:GridView ID="grdGadgetlist" runat="server" AutoGenerateColumns="false" DataKeyNames="GadgetID"
                                    SkinID="gvNoPaging" ShowHeader="true" Width="100%" OnRowDataBound="grdGadgetlist_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="DisplayName" HeaderText="Gadget Name" HeaderStyle-HorizontalAlign="Left"
                                            ItemStyle-HorizontalAlign="Left" />
                                        <asp:TemplateField HeaderText="Show" ItemStyle-Width="20px" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="20px" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkIsAdmin" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <div class="pageinfo">
                                            <div class="NoItemsFound">
                                                <h2>
                                                    <asp:Literal ID="Literal3" runat="server" Text="No Record Found"></asp:Literal></h2>
                                            </div>
                                        </div>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr style="display:none;">
                            <td>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="chkIsSMS" runat="server"
                                    Text="SMS" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="chkIsEmail"
                                        runat="server" Text="Email" />
                            </td>
                        </tr>
                        <tr style="display:none;">
                            <td>
                                <div style="float: right; width: auto; display: inline-block;">
                                    <asp:Button ID="btnCancel" Text="Cancel" Style="float: right; margin-left: 5px;"
                                        runat="server" ImageUrl="~/images/cancle.png" CausesValidation="False" OnClick="btnCancel_Click" />
                                    <asp:Button ID="btnSave" Text="Save" Style="float: right; margin-left: 5px;" runat="server"
                                        ImageUrl="~/images/save.png" OnClick="btnSave_Click" />
                                </div>
                            </td>
                        </tr>
                        <tr style="display:none;">
                            <td class="pagesubheader">
                                <asp:Literal ID="Literal1" runat="server" Text="Change Display Name"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Display Name : &nbsp;&nbsp;&nbsp;<asp:Literal ID="litDisplayName" runat="server"
                                    Text="ADMIN"></asp:Literal>
                                &nbsp;&nbsp;<asp:LinkButton ID="lnkbtnChangeDisplayName" runat="server" Text="Change"
                                    OnClick="lnkbtnChangeDisplayName_Click" Style="color: #0067A4;"></asp:LinkButton>
                            </td>
                        </tr>
                        <tr style="display:none;">
                            <td class="pagesubheader">
                                <asp:Literal ID="Literal2" runat="server" Text="Change Password"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-top:25px;">
                                Password : &nbsp;&nbsp;&nbsp;<asp:Literal ID="litCurrentPassword" runat="server"
                                    Text="*********" />&nbsp;&nbsp;<asp:LinkButton ID="lnkbtnChangePassword" Style="color: #0067A4;"
                                        Text="Change" runat="server" OnClick="lnkbtnChangePassword_Click"></asp:LinkButton>
                            </td>
                        </tr>
                    </table>
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
    </ContentTemplate>
</asp:UpdatePanel>
<ajx:ModalPopupExtender ID="msgbx" runat="server" TargetControlID="hfMessage" PopupControlID="pnl"
    BackgroundCssClass="mod_background">
</ajx:ModalPopupExtender>
<asp:HiddenField ID="hfMessage" runat="server" />
<asp:Panel ID="pnl" runat="server" style="display:none;">
    <div style="width: 500px; height: 200px; margin-top: 25px;">
        <table border="0" cellspacing="0" cellpadding="0" class="modelpopup_box">
            <tr>
                <td class="modelpopup_boxtopleft">
                    &nbsp;
                </td>
                <td class="modelpopup_boxtopcenter">
                    &nbsp;
                </td>
                <td class="modelpopup_boxtopright">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="modelpopup_boxleft">
                    &nbsp;
                </td>
                <td class="modelpopup_box_bg">
                    <table cellpadding="3" cellspacing="3" width="100%" style="margin-left: 15px;">
                        <tr>
                            <td>
                                Display Name :
                                <asp:TextBox ID="txtDisplayName" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="middle" style="float: left;">
                                <div style="margin-left: 115px; float: left;">
                                    <asp:Button ID="btnSaveDisplayName" Text="Save" Style="float: right; margin-left: 5px;"
                                        runat="server" ImageUrl="~/images/save.png" OnClick="btnSaveDisplayName_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                </div>
                                <div style="margin-left: 10px; float: left;">
                                    <asp:Button ID="btnCancelDisplayName" Text="Cancel" Style="float: right; margin-left: 5px;"
                                        runat="server" ImageUrl="~/images/cancle.png" OnClick="btnCancelDisplayName_Click" OnClientClick="fnDisplayCatchErrorMessage()"/>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
                <td class="modelpopup_boxright">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="modelpopup_boxbottomleft">
                    &nbsp;
                </td>
                <td class="modelpopup_boxbottomcenter">
                </td>
                <td class="modelpopup_boxbottomright">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
</asp:Panel>
<ajx:ModalPopupExtender ID="ChangePwd" runat="server" TargetControlID="hdnChangePwd"
    PopupControlID="pnlChangePwd" BackgroundCssClass="mod_background">
</ajx:ModalPopupExtender>
<asp:HiddenField ID="hdnChangePwd" runat="server" />
<asp:Panel ID="pnlChangePwd" runat="server" style="display:none;">
    <div style="width: 500px; height: 200px; margin-top: 25px;">
        <table border="0" cellspacing="0" cellpadding="0" class="modelpopup_box">
            <tr>
                <td class="modelpopup_boxtopleft">
                    &nbsp;
                </td>
                <td class="modelpopup_boxtopcenter">
                    &nbsp;
                </td>
                <td class="modelpopup_boxtopright">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="modelpopup_boxleft">
                    &nbsp;
                </td>
                <td class="modelpopup_box_bg">
                    <table cellpadding="3" cellspacing="3" width="100%" style="margin-left: 15px;">
                        <tr>
                            <td style="width: 45%;">
                                Current Password <span class="erroraleart">
                                    <asp:RequiredFieldValidator ID="rvfTitle" SetFocusOnError="True" ControlToValidate="txtCurrentPassword"
                                        ValidationGroup="Configuration" runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                </span>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCurrentPassword" runat="server" TextMode="Password" Enabled="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Email
                            </td>
                            <td>
                                <asp:Label ID="lblEmail" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 45%;">
                                New Password : <span class="erroraleart">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" SetFocusOnError="True" ControlToValidate="txtNewPassword"
                                        ValidationGroup="Configuration" runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                </span>
                            </td>
                            <td>
                                <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 45%;">
                                New Confirm Password <span class="erroraleart">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" SetFocusOnError="True" ControlToValidate="txtNewConfirmPassword"
                                        ValidationGroup="Configuration" runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                </span>
                            </td>
                            <td>
                                <asp:TextBox ID="txtNewConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:CompareValidator ID="cmprValidator" SetFocusOnError="True" ControlToValidate="txtNewConfirmPassword"
                                    ControlToCompare="txtNewPassword" ValidationGroup="Configuration" runat="server"
                                    CultureInvariantValues="false" ErrorMessage="New And confirm Password are not same."
                                    CssClass="rfv_ErrorStar"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div style="margin-left: 115px; float: left;">
                                    <asp:Button ID="btnSavePassword" Text="Save" Style="float: right; margin-left: 5px;"
                                        runat="server" ImageUrl="~/images/save.png" CausesValidation="true" ValidationGroup="Configuration"
                                        OnClick="btnSavePassword_Click" OnClientClick="fnDisplayCatchErrorMessage()"/>
                                </div>
                                <div style="margin-left: 10px; float: left;">
                                    <asp:Button ID="btnCancelPassword" Text="Cancel" Style="float: right; margin-left: 5px;"
                                        runat="server" ImageUrl="~/images/cancle.png" OnClick="btnCancelPassword_Click" OnClientClick="fnDisplayCatchErrorMessage()"/>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
                <td class="modelpopup_boxright">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="modelpopup_boxbottomleft">
                    &nbsp;
                </td>
                <td class="modelpopup_boxbottomcenter">
                </td>
                <td class="modelpopup_boxbottomright">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
</asp:Panel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
