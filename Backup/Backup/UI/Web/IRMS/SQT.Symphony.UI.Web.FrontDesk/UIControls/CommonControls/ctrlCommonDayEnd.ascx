<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlCommonDayEnd.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls.ctrlCommonDayEnd" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }        
</script>
<asp:UpdatePanel ID="updDayEnd" runat="server">
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
                                <asp:Literal ID="litMainHeader" Text="Day End Process" runat="server"></asp:Literal>
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
                                    <table width="100%" border="0" cellspacing="2" cellpadding="2">
                                        <tr>
                                            <td colspan="2">
                                                <%if (IsMessage)
                                                  { %>
                                                <div class="ResetSuccessfully">
                                                    <div style="float: left; padding-top: 7px; width: 25px; height: 24px; margin-right: 10px;">
                                                        <img src="../../images/success.png" />
                                                    </div>
                                                    <div>
                                                        <asp:Label ID="lblCommonMsg" runat="server"></asp:Label></div>
                                                    <div style="height: 10px;">
                                                    </div>
                                                </div>
                                                <% }%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 30%; vertical-align: top; border-right: 1px solid #ccccce;">
                                                <table width="100%" border="0" cellspacing="2" cellpadding="2">
                                                    <tr>
                                                        <td style="vertical-align: top; border: 1px solid #ccccce;">
                                                            <asp:Image ID="imgCheckOut" runat="server" Style="height: 15px; width: 15px;" />
                                                            <asp:LinkButton ID="lnkCheckOut" Enabled="false" runat="server" Text="Check Out"
                                                                OnClick="lnkCheckOut_OnClick"></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="vertical-align: top; border: 1px solid #ccccce;">
                                                            <asp:Image ID="imgCheckIn" runat="server" Style="height: 15px; width: 15px;" />
                                                            <asp:LinkButton ID="lnkCheckIn" Enabled="false" runat="server" Text="Check In" OnClick="lnkCheckIn_OnClick"></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <%--<tr>
                                                        <td style="vertical-align: top; border: 1px solid #ccccce;">
                                                            <asp:Image ID="imgNoShowList" runat="server" Style="height: 15px; width: 15px;" />
                                                            <asp:LinkButton ID="lnkNoShowList" Enabled="false" runat="server" Text="No Show List" OnClick="NoShowList_OnClick"></asp:LinkButton>
                                                        </td>
                                                    </tr>--%>
                                                    <%--<tr>
                                                        <td style="vertical-align: top; border: 1px solid #ccccce;">
                                                            <asp:Image ID="imgDepositTranferred" runat="server" Style="height: 15px; width: 15px;" />
                                                            <asp:LinkButton ID="lnkDepositTranferred" Enabled="false" runat="server" Text="Deposit Tranferred (Optional)"
                                                                OnClick="lnkDepositTranferred_OnClick"></asp:LinkButton>
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td style="vertical-align: top; border: 1px solid #ccccce;">
                                                            <asp:Image ID="imgPOSTAccomodationCharges" runat="server" Style="height: 15px; width: 15px;" />
                                                            <asp:LinkButton ID="lnkPOSTAccomodationCharges" Enabled="false" OnClick="lnkPOSTAccomodationCharges_OnClick"
                                                                runat="server" Text="Room Rent"></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="vertical-align: top; border: 1px solid #ccccce;">
                                                            <asp:Image ID="imgPOSTServiceCharges" runat="server" Style="height: 15px; width: 15px;" />
                                                            <asp:LinkButton ID="lnkPOSTServiceCharges" Enabled="false" runat="server" OnClick="lnkPOSTServiceCharges_OnClick"
                                                                Text="Service Charges"></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="vertical-align: top; border: 1px solid #ccccce;">
                                                            <asp:Image ID="imgACBalanceSheet" runat="server" Style="height: 15px; width: 15px;" />
                                                            <asp:LinkButton ID="lnkACBalanceSheet" Enabled="false" runat="server" OnClick="lnkACBalanceSheet_OnClick"
                                                                Text="Account Balance Sheet"></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="vertical-align: top; border: 1px solid #ccccce;">
                                                            <asp:Image ID="imgCloseCounter" runat="server" Style="height: 15px; width: 15px;" />
                                                            <asp:LinkButton ID="lnkCloseCounter" runat="server" Enabled="false" OnClick="lnkCloseCounter_OnClick"
                                                                Text="Close Counter"></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="vertical-align: top;">
                                                <div class="box_head">
                                                    <span>
                                                        <asp:Literal ID="litDayEndDetails" runat="server"></asp:Literal>
                                                    </span>
                                                </div>
                                                <div class="clear">
                                                </div>
                                                <div class="box_content">
                                                    <div style="height: 400px; overflow: auto;">
                                                        <asp:GridView ID="gvDayEndDetails" OnRowDataBound="gvDayEndDetails_RowDataBound"
                                                            runat="server" OnRowCommand="gvDayEndDetails_RowCommand" AutoGenerateColumns="false"
                                                            ShowHeader="true" Width="100%" SkinID="gvNoPaging" DataKeyNames="CodeID">
                                                            <Columns>
                                                                <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex + 1 %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblGvHdrDescription" runat="server" Text="Description"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDescription" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ErrorCode")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblGvHdrAction" runat="server" Text="Transfer to"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkTransferToNoShow" runat="server" CommandName="TRANSFERTONOSHOW"
                                                                            CommandArgument='<%#DataBinder.Eval(Container.DataItem, "CodeID")%>' Visible="false"
                                                                            Text="No Show"></asp:LinkButton>
                                                                        <asp:LinkButton ID="lnkTransferToCancelled" runat="server" CommandName="TRANSFERTOCANCELLED"
                                                                            CommandArgument='<%#DataBinder.Eval(Container.DataItem, "CodeID")%>' Visible="false"
                                                                            Text="Cancelled"></asp:LinkButton>
                                                                        <asp:LinkButton ID="lnkOverStay" runat="server" CommandName="OVERSTAY" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "CodeID")%>'
                                                                            Text="Over stay" Visible="false"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EmptyDataTemplate>
                                                                <div style="padding: 10px;">
                                                                    <b>
                                                                        <asp:Label ID="lblNoRecordFound" runat="server" Text="No Record Found."></asp:Label>
                                                                    </b>
                                                                </div>
                                                            </EmptyDataTemplate>
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                                <div style="float: right; margin-top: 15px;">
                                                    <asp:Button ID="btnPost" runat="server" Text="Post" Style="display: inline;" Visible="false"
                                                        OnClick="btnPost_Click" />
                                                    <%--<asp:Button ID="btnDelete" runat="server" Text="Delete" Style="display: inline;"
                                                        Visible="false" OnClientClick="return ValidateRoom();" />--%></div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <table width="100%" border="0" cellspacing="2" cellpadding="2">
                                                    <tr>
                                                        <td style="vertical-align: top; width: 22px;">
                                                            <asp:Literal ID="litNote" runat="server" Text="Note"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtNote" Style="width: 255px;" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <div style="float: right; width: auto; display: inline-block;">
                                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" ImageUrl="~/images/cancle.png"
                                                                    Style="float: right; margin-left: 5px;" />
                                                                <asp:Button ID="btnPrint" runat="server" CausesValidation="true" ImageUrl="~/images/delete.png"
                                                                    Text="Print" Style="float: right; margin-left: 5px;" />
                                                                <asp:Button ID="btnDayEnd" runat="server" ImageUrl="~/images/save.png" Style="float: right;
                                                                    margin-left: 5px;" Text="Day End" Visible="false" OnClick="btnDayEnd_Click" />
                                                                <asp:Button ID="btnPreChecks" OnClick="btnPreChecks_OnClick" runat="server" ImageUrl="~/images/save.png"
                                                                    Style="float: right; margin-left: 5px;" Text="Pre Checks" />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
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
                    </div>
                </td>
            </tr>
        </table>
        <ajx:ModalPopupExtender ID="mpeConfirmMessage" runat="server" TargetControlID="hdnConfirmMessage"
            PopupControlID="pnlConfirmMessage" BackgroundCssClass="mod_background" CancelControlID="btnConfirmMessageCancel"
            BehaviorID="mpeConfirmMessage">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnConfirmMessage" runat="server" />
        <asp:Panel ID="pnlConfirmMessage" runat="server" Style="display: none; min-height: 350px;
            min-width: 350px;">
            <div class="box_col1" style="height: 150px; width: 500px;">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="ltrHeaderMessage" runat="server" Text="Message"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td style="padding-bottom: 15px; width: 150px;">
                                <asp:Label ID="lblMessage" runat="server" Text="Day End (Type - YES/NO)"></asp:Label>
                            </td>
                            <td style="padding-bottom: 15px;">
                                <asp:TextBox ID="txtConfirmMessage" runat="server"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rfvConfirmMessage" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                        runat="server" ValidationGroup="IsRequireDayEnd" ControlToValidate="txtConfirmMessage"
                                        Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Button ID="btnConfirmMessageOk" Text="Ok" runat="server" Style="display: inline;
                                    padding-right: 10px;" OnClick="btnConfirmMessageOk_Click" ValidationGroup="IsRequireDayEnd" />
                                <asp:Button ID="btnConfirmMessageCancel" Text="Cancel" runat="server" Style="display: inline;
                                    padding-right: 10px;" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <asp:HiddenField ID="hfPopupCustomeMessage" runat="server" />
        <ajx:ModalPopupExtender ID="mpeCustomePopup" runat="server" TargetControlID="hfPopupCustomeMessage"
            PopupControlID="pnlCustomeMessage" BackgroundCssClass="mod_background" CancelControlID="btnOKCustomeMsgPopup"
            DropShadow="true" BehaviorID="mpeCustomePopup">
        </ajx:ModalPopupExtender>
        <asp:Panel ID="pnlCustomeMessage" runat="server" Width="350px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="litHeaderCustomePopupMessage" runat="server" Text="Message"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td align="center" style="padding-bottom: 15px; color: Red;">
                                <asp:Label ID="lblCustomePopupMsg" runat="server" Text="Please Select Reservation."></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnOKCustomeMsgPopup" runat="server" Text="OK" Style="display: inline;
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
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updDayEnd" ID="UpdateProgressDayEnd"
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
