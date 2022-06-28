<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCashierCheckOut.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Billing.CtrlCashierCheckOut" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">

    function pageLoad(sender, args) {
        var v1 = '<%=ConfigurationManager.AppSettings["IsUpperCase"].ToString() %>'
        if (v1 == "1") {
            $('input[type="text"],textarea').each(function () { $(this).css("text-transform", "uppercase") });
        }
        $(document).ready(function () {
            $("#<%=txtCheckOutGuestName.ClientID%>").autocomplete('CheckedInGuestAutoSuggest.ashx');
        });
    }
    function fnConfirmDelete() {

        document.getElementById('errormessage').style.display = "block";
        $find('mpeConfirmDelete').show();
        return false;
    }
</script>
<asp:UpdatePanel ID="updCheckInList" runat="server">
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
                                <asp:Literal ID="litMainHeader" runat="server" Text="Check Out"></asp:Literal>
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
                                    <table width="100%">
                                        <tr>
                                            <td align="left" style="padding-bottom: 300px;">
                                                <table cellpadding="2" cellspacing="2" border="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="Literal9" runat="server" Text="Guest Name"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCheckOutGuestName" runat="server" Style="width: 400px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="isrequire">
                                                            <asp:Literal ID="Literal7" runat="server" Text="Booking #"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtBookingNoForCheckOut" runat="server" Style="width: 100px"></asp:TextBox>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvForCheckOut" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                    runat="server" ValidationGroup="IsRequireForCheckOut" ControlToValidate="txtBookingNoForCheckOut"
                                                                    Display="Dynamic">
                                                                </asp:RequiredFieldValidator>
                                                            </span>
                                                            <ajx:FilteredTextBoxExtender ID="fteBookingNoForCheckOut" runat="server" TargetControlID="txtBookingNoForCheckOut"
                                                                FilterMode="ValidChars" ValidChars="0123456789">
                                                            </ajx:FilteredTextBoxExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnProceedCheckOut" runat="server" Text="Proceed" Style="display: inline;"
                                                                OnClick="btnProceedCheckOut_OnClick" ValidationGroup="IsRequireForCheckOut" OnClientClick="return fnConfirmDelete()" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:LinkButton ID="btnHiddenCheckOut" runat="server" Text="#" OnClick="btnHiddenCheckOut_OnClick" Style="display: inline; color:White;"></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                            <td class="boxright">
                            </td>
                        </tr>
                        <tr>
                            <td class="boxbottomleft">
                            </td>
                            <td class="boxbottomcenter">
                            </td>
                            <td class="boxbottomright">
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
        <ajx:ModalPopupExtender ID="mpeSuccessMessage" runat="server" TargetControlID="hfSuccessMessage"
            PopupControlID="pnlSuccessMessage" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hfSuccessMessage" runat="server" />
        <asp:Panel ID="pnlSuccessMessage" runat="server" Style="display: none; min-height: 350px;
            min-width: 350px;">
            <div class="box_col1">
                <div class="box_head">
                    <div style="display: inline;">
                        <span>
                            <asp:Literal ID="Literal1" runat="server" Text="Message"></asp:Literal></span></div>
                    <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                        <asp:ImageButton ID="iBtnCancelSuccessMessage" runat="server" ImageUrl="~/images/closepopup.png"
                            Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;"
                            OnClick="iBtnCacelCheckOut_OnClick" />
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%" style="margin-top: 10px;">
                        <tr>
                            <td align="center" style="padding-bottom: 15px;">
                                <asp:Label ID="lblSuccessMessage" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnSuccessMessageOK" Text="OK" runat="server" OnClick="btnSuccessMessageOK_OnClick"
                                    Style="display: inline; padding-right: 10px;" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpeConfirmDelete" runat="server" TargetControlID="hdnConfirmDelete"
            PopupControlID="pnlDeleteData" BackgroundCssClass="mod_background" CancelControlID="btnCancelDelete"
            BehaviorID="mpeConfirmDelete">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnConfirmDelete" runat="server" />
        <asp:Panel ID="pnlDeleteData" runat="server" Height="350px" Width="325px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="ltrHeaderConfirmDeletePopup" runat="server" Text="Information"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td align="center" style="padding-bottom: 15px;">
                                <asp:Label ID="lblConfirmDeleteMessage" runat="server" Text="Please Check out the Cash Card before doing the Reservation Check out."></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnYes" runat="server" Style="display: inline; padding-right: 10px;"
                                    OnClick="btnYes_Click" Text="Ok" />
                                <asp:Button ID="btnCancelDelete" runat="server" Style="display: inline;" Text="Cancel" />
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
<asp:UpdateProgress AssociatedUpdatePanelID="updCheckInList" ID="UpdateProgressCheckInList"
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
