<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCommonQuickPost.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls.CtrlCommonQuickPost" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox1" TagPrefix="uc11" %>
<script type="text/javascript">
    function fnCheckAmount() {
        if (Page_ClientValidate("AddQuickPost")) {
            var amount = document.getElementById('<%=txtQuickPostAmount.ClientID%>').value;
            if (amount != '' && amount != null) {
                if (parseFloat(amount) <= 0) {
                    $find('mpeErrorMessage').show();
                    document.getElementById('<%=lblErrorMessage.ClientID %>').innerHTML = "Amount must be greater than 0.";
                    return false;
                }

            }
            else if (amount == '' || amount == null) {
                $find('mpeErrorMessage').show();
                document.getElementById('<%=lblErrorMessage.ClientID %>').innerHTML = "Please Insert amount.";
                return false;
            }
        }
        else {
            return false;
        }
    }

    function fnConfirmDeleteQPCardInfoData(id) {

        document.getElementById('errormessage').style.display = "block";
        document.getElementById('<%= hdnConfirmDeleteQPCardInfo.ClientID %>').value = id;
        $find('mpeConfirmDeleteQPCardInfo').show();
        return false;
    }
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<ajx:ModalPopupExtender ID="mpeAddQuickPost" runat="server" TargetControlID="hdnQuickPost"
    PopupControlID="pnlAddQuickPost" BackgroundCssClass="mod_background">
</ajx:ModalPopupExtender>
<asp:HiddenField ID="hdnQuickPost" runat="server" />
<asp:Panel ID="pnlAddQuickPost" runat="server" Width="750px" Style="display: none;">
    <asp:HiddenField ID="hdnPaymentType" runat="server" />
    <asp:HiddenField ID="hdnResPayID" runat="server" />
    <asp:MultiView ID="mvQuickPost" runat="server">
        <asp:View ID="vQuickPost" runat="server">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="litQuickPostHeader" runat="server" Text="Quick Post"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td colspan="2">
                                <fieldset style="border: 1px solid #ccc !important; padding: 5px;">
                                    <div style="float: left; width: 75px;">
                                        <asp:Literal ID="litQuickPostFolioNo" runat="server" Text="Folio No."></asp:Literal>
                                    </div>
                                    <div style="float: left; width: 150px;">
                                        <asp:Literal ID="litDisplayQuickPostFolioNo" runat="server"></asp:Literal>
                                    </div>
                                    <div style="float: left; width: 75px;">
                                        <asp:Literal ID="litQuickPostUnitNo" runat="server" Text="Room No."></asp:Literal>
                                    </div>
                                    <div style="float: left;">
                                        <asp:Literal ID="litDisplayQuickPostUnitNo" runat="server"></asp:Literal>
                                    </div>
                                    <br />
                                    <div style="float: left; width: 75px;">
                                        <asp:Literal ID="litQuickPostName" runat="server" Text="Name"></asp:Literal>
                                    </div>
                                    <div style="float: left;">
                                        <asp:Literal ID="litDisplayQuickPostName" runat="server"></asp:Literal>
                                    </div>
                                    <div style="float: right;">
                                        <asp:Literal ID="litQuickPostCreditLimit" runat="server" Text="Balance"></asp:Literal>&nbsp;&nbsp;&nbsp;
                                        <asp:Literal ID="litDisplayQuickPostCreditLimit" runat="server"></asp:Literal>
                                    </div>
                                </fieldset>
                            </td>
                        </tr>
                        <tr>
                            <td width="45%" style="border-right: 1px solid #ccc;">
                                <fieldset style="border: 1px solid #ccc !important;">
                                    <legend>
                                        <asp:Literal ID="litQuickPostPostCharges" runat="server" Text="Post Charges A/C. Info"></asp:Literal>
                                    </legend>
                                    <table cellpadding="2" cellspacing="2" width="100%">
                                        <tr>
                                            <%--<td>
                                                <asp:Literal ID="litQuickPostPMT" runat="server" Text="PMT"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal ID="litDisplayQuickPostPMT" runat="server" Text="BACS"></asp:Literal>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>--%>
                                            <td colspan="2">
                                                <asp:RadioButtonList ID="rbtQuickPostAccount" runat="server" RepeatDirection="Horizontal"
                                                    RepeatColumns="2" AutoPostBack="true" OnSelectedIndexChanged="rbtQuickPostAccount_SelectedIndexChanged">
                                                    <asp:ListItem Selected="True" Value="Account" Text="Account"></asp:ListItem>
                                                    <asp:ListItem Value="Item" Text="Item"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="isrequire">
                                                <asp:Literal ID="litQuickPostAccount" runat="server" Text="Account/Item"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlQuickPostCharge" runat="server" Style="width: 148px !important;"
                                                    AutoPostBack="true" OnSelectedIndexChanged="ddlQuickPostCharge_OnSelectedIndexChanged">
                                                </asp:DropDownList>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rvfTitle" InitialValue="00000000-0000-0000-0000-000000000000"
                                                        SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                        ValidationGroup="AddQuickPost" ControlToValidate="ddlQuickPostCharge" Display="Dynamic">
                                                    </asp:RequiredFieldValidator>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="isrequire">
                                                <asp:Literal ID="litQuickPostAmount" runat="server" Text="Amount"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtQuickPostAmount" runat="server" Style="width: 146px !important;"></asp:TextBox>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rvfFirstName" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                        runat="server" ValidationGroup="AddQuickPost" ControlToValidate="txtQuickPostAmount"
                                                        Display="Dynamic">
                                                    </asp:RequiredFieldValidator>
                                                </span>
                                                <ajx:FilteredTextBoxExtender ID="ftQuickPostAmount" runat="server" TargetControlID="txtQuickPostQty"
                                                    FilterType="Custom, Numbers" ValidChars="." />
                                            </td>
                                        </tr>
                                        <tr id="trQty" runat="server" visible="false">
                                            <td style="vertical-align: top;">
                                                <asp:Literal ID="litQuickPostQty" runat="server" Text="Qty"></asp:Literal>
                                            </td>
                                            <td style="vertical-align: top; margin-left: -5px;">
                                                <asp:TextBox ID="txtQuickPostQty" runat="server"></asp:TextBox>
                                                <ajx:NumericUpDownExtender ID="QuickPostQtyNUDE" runat="server" TargetControlID="txtQuickPostQty"
                                                    Width="60" Minimum="1" Maximum="999" />
                                                <ajx:FilteredTextBoxExtender ID="ftQuickPostQty" runat="server" TargetControlID="txtQuickPostQty"
                                                    FilterType="Numbers" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="margin-top: 10px;">
                                                <asp:Label ID="lblQuickPostDocNo" runat="server" Style="margin-top: 10px;" Text="VOU/DOC No."></asp:Label>
                                            </td>
                                            <td style="vertical-align: top; margin-top: 10px;">
                                                <div style="float: left; padding-right: 15px;">
                                                    <asp:TextBox ID="txtQuickPostVoucherNo" runat="server" Style="width: 100px !important;
                                                        margin-top: 10px;"></asp:TextBox>
                                                </div>
                                                <div style="float: left; margin-top: 10px;">
                                                    <asp:Button ID="btnQuickPostAdd" runat="server" Text="Add" OnClick="btnQuickPostAdd_Click"
                                                        ValidationGroup="AddQuickPost" OnClientClick="return fnCheckAmount();" />
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal ID="litQuickPostPayment" runat="server" Text="Payment"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlQuickPostPayment" runat="server" Style="width: 148px;" AutoPostBack="true"
                                                    OnSelectedIndexChanged="ddlQuickPostPayment_OnSelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr id="trLedgerAccount" runat="server" visible="false">
                                            <td>
                                                Ledger
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlLedgerAccount" runat="server" Style="width: 148px;">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr id="trChequeDD1" runat="server" visible="false">
                                            <td>
                                                Bank Name
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtBankName" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr id="trChequeDD2" runat="server" visible="false">
                                            <td>
                                                Cheque/DD No.
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtChequeDDNo" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: top;">
                                                <asp:Literal ID="litQuickPostNotes" runat="server" Text="Notes"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtQuickPostNotes" Style="width: 146px !important;" TextMode="MultiLine"
                                                    runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </fieldset>
                            </td>
                            <td style="height: 150px; overflow: auto; vertical-align: top;" width="55%">
                                <div class="box_head">
                                    <span>
                                        <asp:Literal ID="litGroupReservationList" runat="server" Text="Quick Post List"></asp:Literal>
                                    </span>
                                </div>
                                <div class="clear">
                                </div>
                                <div class="box_content">
                                    <div style="height: 150px; overflow: auto;">
                                        <asp:GridView ID="gvQuickPostList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                            Width="100%" SkinID="gvNoPaging" DataKeyNames="ID,ForPostCharge,RefNo" OnRowCommand="gvQuickPostList_RowCommand">
                                            <Columns>
                                                <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrQuickPostSrNo" runat="server" Text="No."></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrQuickPostItem" runat="server" Text="Account/Item"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGvAccItem" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "AccItem")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="40px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrQuickPostQty" runat="server" Text="Qty"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGvQty" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Qty")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrQuickPostAmount" runat="server" Text="Amount"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGvAmount" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Amount")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblActions" runat="server" Text="Action"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPopUp" runat="server" Text="Action"></asp:Label>
                                                        <ajx:HoverMenuExtender ID="HoverMenuExtender2" runat="server" TargetControlID="lblPopUp"
                                                            PopupControlID="Panel2" PopupPosition="Left">
                                                        </ajx:HoverMenuExtender>
                                                        <asp:Panel ID="Panel2" runat="server" Style="visibility: hidden; opacity: 100%">
                                                            <div class="actionsbuttons_hovermenu">
                                                                <table border="0" cellpadding="0" cellspacing="0" class="actionsbuttons_hover_lettmenu_table">
                                                                    <tr>
                                                                        <td class="actionsbuttons_hover_lettmenu">
                                                                        </td>
                                                                        <td class="actionsbuttons_hover_centermenu">
                                                                            <ul>
                                                                                <%--<li>
                                                                                    <asp:LinkButton ID="lnkQuickPostEdit" Style="background: none !important; border: none;"
                                                                                        runat="server" ToolTip="Edit" CommandName="EDITDATA"><img src="../../images/file.png" /></asp:LinkButton>
                                                                                </li>--%>
                                                                                <li>
                                                                                    <asp:LinkButton ID="lnkQuickPostDelete" Style="background: none !important; border: none;"
                                                                                        runat="server" ToolTip="Delete" CommandName="DELETEDATA" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "No")%>'><img src="../../images/delete.png" /></asp:LinkButton>
                                                                                </li>
                                                                            </ul>
                                                                        </td>
                                                                        <td class="actionsbuttons_hover_rightmenu">
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </asp:Panel>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <div style="padding: 10px;">
                                                    <b>
                                                        <asp:Label ID="lblQuickPostNoRecordFound" runat="server" Text="No Record Found."></asp:Label>
                                                    </b>
                                                </div>
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td style="background-color: #DCDDDF; color: #0083CE; font-size: 15px; font-weight: bold;
                                padding: 9px; width: 100%">
                                <asp:Label Style="float: right;" ID="lblDisplayQuickPostAmount" runat="server" Text="0.00"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnQuickPostSave" runat="server" Style="display: inline; padding-right: 10px;"
                                    Text="Save" OnClick="btnQuickPostSave_Click" />
                                <%--<asp:Button ID="btnQuickPostCurrency" runat="server" Style="display: inline;" Text="Foreign Currency" />--%>
                                <asp:Button ID="btnQuickPostCardInfo" runat="server" Style="display: inline;" Text="Card Info."
                                    OnClick="btnQuickPostCardInfo_Click" Visible="false" />
                                <asp:Button ID="btnQuickPostCancel" runat="server" Style="display: inline;" Text="Cancel" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:View>
        <asp:View ID="vCardInof" runat="server">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="litCardInfo" runat="server" Text="Card Info"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td colspan="4">
                                <%if (IsMessage)
                                  { %>
                                <div class="message finalsuccess">
                                    <p>
                                        <strong>
                                            <asp:Literal ID="ltrMsgList" runat="server"></asp:Literal></strong>
                                    </p>
                                </div>
                                <%}%>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="font-weight: bold; font-size: 13px; border: 1px solid #ccccce;">
                                <asp:Literal ID="litDisplayCardHolderName" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire" style="width: 120px !important;">
                                <asp:Literal ID="litCardType" runat="server" Text="Type"></asp:Literal>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCreditCardType" runat="server" Style="width: 200px;">
                                </asp:DropDownList>
                                <span>
                                    <asp:RequiredFieldValidator ID="rfvddlCreditCardType" InitialValue="00000000-0000-0000-0000-000000000000"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                        ValidationGroup="AddCardDetailsForPayment" ControlToValidate="ddlCreditCardType"
                                        Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                </span>
                            </td>
                            <td class="isrequire">
                                <asp:Literal ID="litCardNo" runat="server" Text="Card No."></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCardNo" runat="server" Style="width: 198px;" MaxLength="16"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rfvCardNo" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                        runat="server" ValidationGroup="AddCardDetailsForPayment" ControlToValidate="txtCardNo"
                                        Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire">
                                <asp:Literal ID="litCardHolderName" runat="server" Text="Card Holder's Name"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCardHolderName" runat="server" Style="width: 198px;"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rfvCardHolderName" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                        runat="server" ValidationGroup="AddCardDetailsForPayment" ControlToValidate="txtCardHolderName"
                                        Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                </span>
                            </td>
                            <td class="isrequire">
                                <asp:Literal ID="litSecurityCode" runat="server" Text="Security Code(CVV)"></asp:Literal>
                                <%--<asp:Literal ID="litIssueDate" runat="server" Text="Issue Date"></asp:Literal>--%>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSecurityCode" runat="server" Style="width: 198px;"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rfvSecurityCode" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                        runat="server" ValidationGroup="AddCardDetailsForPayment" ControlToValidate="txtSecurityCode"
                                        Display="Static">
                                    </asp:RequiredFieldValidator>
                                </span>
                                <%--<asp:TextBox ID="txtIssueDate" runat="server" Style="width: 155px;"></asp:TextBox>
                                <asp:Image ID="imgIssueDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                    Height="20px" Width="20px" />
                                <ajx:CalendarExtender ID="calExtIssueDate" PopupButtonID="imgIssueDate" TargetControlID="txtIssueDate"
                                    runat="server">
                                </ajx:CalendarExtender>
                                <img src="../../images/clear.png" id="imgClrIssueDate" style="vertical-align: middle;"
                                    title="Clear Date" onclick="fnClearDate('<%= txtIssueDate.ClientID %>');" />--%>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire">
                                <asp:Literal ID="litExpiryDate" runat="server" Text="Expiry Date"></asp:Literal>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCardExpirationMonth" runat="server" SkinID="nowidth" Width="90px">
                                    <asp:ListItem Text="-SELECT-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                    <asp:ListItem Text="January" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="February" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="March" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="April" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="May" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="June" Value="6"></asp:ListItem>
                                    <asp:ListItem Text="July" Value="7"></asp:ListItem>
                                    <asp:ListItem Text="August" Value="8"></asp:ListItem>
                                    <asp:ListItem Text="September" Value="9"></asp:ListItem>
                                    <asp:ListItem Text="October" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="November" Value="11"></asp:ListItem>
                                    <asp:ListItem Text="December" Value="12"></asp:ListItem>
                                </asp:DropDownList>
                                <span>
                                    <asp:RequiredFieldValidator ID="rfvCardExpirationMonth" InitialValue="00000000-0000-0000-0000-000000000000"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                        ValidationGroup="AddCardDetailsForPayment" ControlToValidate="ddlCardExpirationMonth"
                                        Display="Static">
                                    </asp:RequiredFieldValidator>
                                </span>
                                <asp:DropDownList ID="ddlCardExpirationYear" runat="server" SkinID="nowidth" Width="90px">
                                </asp:DropDownList>
                                <span>
                                    <asp:RequiredFieldValidator ID="rfvCardExpirationYear" InitialValue="00000000-0000-0000-0000-000000000000"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                        ValidationGroup="AddCardDetailsForPayment" ControlToValidate="ddlCardExpirationYear"
                                        Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                </span>
                            </td>
                            <td colspan="2">
                                <asp:RadioButtonList ID="rdbPaymentOrBlock" runat="server" CellPadding="0" CellSpacing="0"
                                    RepeatColumns="2" RepeatDirection="Horizontal">
                                    <asp:ListItem Text="Charge" Value="CHARGE" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Block" Value="BLOCK"></asp:ListItem>
                                </asp:RadioButtonList>
                                <%--<asp:Literal ID="litIssueNo" runat="server" Text="Issue No."></asp:Literal>--%>
                            </td>
                            <%--<asp:TextBox ID="txtIssueNo" runat="server" Style="width: 198px;"></asp:TextBox>--%>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <%--<span>
                                    <asp:RequiredFieldValidator ID="rfvSecurityCode" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                        runat="server" ValidationGroup="AddCardDetailsForPayment" ControlToValidate="txtSecurityCode"
                                        Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                </span>--%>
                            </td>
                            <%-- <td>
                                <asp:Literal ID="litAuthorizationCode" runat="server" Text="Authorization Code"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAuthorizationCode" runat="server" Style="width: 198px;"></asp:TextBox>
                            </td>--%>
                            <td>
                                <%--<asp:Literal ID="litAuthorizedAmount" runat="server" Text="Authorized Amount"></asp:Literal>--%>
                            </td>
                            <td>
                                <%-- <asp:TextBox ID="txtAuthorizedAmount" runat="server" Style="width: 198px;" MaxLength="18"></asp:TextBox>
                                <ajx:FilteredTextBoxExtender ID="ftAuthorizedAmount" runat="server" TargetControlID="txtAuthorizedAmount"
                                    FilterType="Custom, Numbers" ValidChars="." />--%>
                            </td>
                        </tr>
                        <%--<tr>
                            <td>
                                <asp:Literal ID="litAuthorizedAmount" runat="server" Text="Authorized Amount"></asp:Literal>
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="txtAuthorizedAmount" runat="server" Style="width: 198px;"></asp:TextBox>
                            </td>
                        </tr>--%>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td style="padding: 0px;">
                            </td>
                            <td colspan="2">
                                <%-- <asp:RegularExpressionValidator Display="Static" ID="revAuthorizedAmount" runat="server"
                                    ForeColor="Red" ControlToValidate="txtAuthorizedAmount" SetFocusOnError="true"
                                    ValidationGroup="AddCardDetailsForPayment">
                                </asp:RegularExpressionValidator>--%>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                <asp:Button ID="btnSaveCardDetails" runat="server" Style="display: inline; padding-right: 10px;"
                                    ValidationGroup="AddCardDetailsForPayment" Text="Save" OnClick="btnSaveCardDetails_Click" />
                                <asp:Button ID="btnSaveAndExitCardDetails" runat="server" Style="display: inline;"
                                    Text="Save And Close" ValidationGroup="AddCardDetailsForPayment" Visible="false" />
                                <asp:Button ID="btnCancelCardDetailsForPayment" runat="server" Style="display: inline;"
                                    Text="Cancel" OnClick="btnCancelCardDetailsForPayment_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" width="100%" style="height: 150px; overflow: auto; vertical-align: top;">
                                <div class="box_head">
                                    <span>
                                        <asp:Literal ID="litCardList" runat="server" Text="Card List"></asp:Literal>
                                    </span>
                                </div>
                                <div class="clear">
                                </div>
                                <div class="box_content">
                                    <div style="height: 200px; overflow: auto;">
                                        <asp:GridView ID="gvCardList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                            Width="100%" DataKeyNames="CardNo,ResPayID" OnRowCommand="gvCardList_RowCommand"
                                            OnRowDataBound="gvCardList_RowDataBound" SkinID="gvNoPaging">
                                            <Columns>
                                                <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrSelect" runat="server" Text="Select"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkSelectCardDetails" runat="server" OnCheckedChanged="chkSelectCardDetails_CheckedChanged"
                                                            AutoPostBack="true" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrType" runat="server" Text="Type"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#DataBinder.Eval(Container.DataItem, "CardType")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrCardNo" runat="server" Text="Card No."></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGvCardNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CardNo")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrName" runat="server" Text="Name"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#DataBinder.Eval(Container.DataItem, "CardHolderName")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrServices" runat="server" Text="Expiry Date"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGvExpiryDate" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "DateOfExpiry")).ToString(clsSession.DateFormat)%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrUnitTaxes" runat="server" Text="Security Code"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#DataBinder.Eval(Container.DataItem, "CVVNo")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblActions" runat="server" Text="Action"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPopUp" runat="server" Text="Action"></asp:Label>
                                                        <ajx:HoverMenuExtender ID="HoverMenuExtender2" runat="server" TargetControlID="lblPopUp"
                                                            PopupControlID="Panel2" PopupPosition="Left">
                                                        </ajx:HoverMenuExtender>
                                                        <asp:Panel ID="Panel2" runat="server" Style="visibility: hidden; opacity: 100%">
                                                            <div class="actionsbuttons_hovermenu">
                                                                <table border="0" cellpadding="0" cellspacing="0" class="actionsbuttons_hover_lettmenu_table">
                                                                    <tr>
                                                                        <td class="actionsbuttons_hover_lettmenu">
                                                                        </td>
                                                                        <td class="actionsbuttons_hover_centermenu">
                                                                            <ul>
                                                                                <li>
                                                                                    <asp:LinkButton ID="lnkEdit" runat="server" Style="background: none !important; border: none;"
                                                                                        ToolTip="Edit" CommandName="EDITDATA" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ResPayID")%>'><img src="../../images/file.png" /></asp:LinkButton>
                                                                                </li>
                                                                                <li>
                                                                                    <asp:LinkButton ID="lnkDelete" runat="server" Style="background: none !important;
                                                                                        border: none;" ToolTip="Delete" CommandName="DELETEDATA" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ResPayID")%>'><img src="../../images/delete.png" /></asp:LinkButton>
                                                                                </li>
                                                                            </ul>
                                                                        </td>
                                                                        <td class="actionsbuttons_hover_rightmenu">
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </asp:Panel>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <div style="padding: 10px;">
                                                    <b>
                                                        <asp:Label ID="lblNoRecordFoundForCardList" runat="server" Text="No Record Found."></asp:Label>
                                                    </b>
                                                </div>
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:View>
    </asp:MultiView>
</asp:Panel>
<ajx:ModalPopupExtender ID="mpeErrorMessage" runat="server" TargetControlID="hfDateMessage"
    PopupControlID="pnlErrorMessage" BackgroundCssClass="mod_background" CancelControlID="btnErrorMessageOK"
    BehaviorID="mpeErrorMessage">
</ajx:ModalPopupExtender>
<asp:HiddenField ID="hfDateMessage" runat="server" />
<asp:Panel ID="pnlErrorMessage" runat="server" Width="350px" Style="display: none;">
    <div class="box_col1">
        <div class="box_head">
            <span>
                <asp:Literal ID="ltrHeaderDateValidate" runat="server" Text="Message"></asp:Literal></span></div>
        <div class="clear">
        </div>
        <div class="box_form">
            <table cellpadding="2" cellspacing="2" width="100%">
                <tr>
                    <td align="center" style="padding-bottom: 15px;">
                        <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btnErrorMessageOK" Text="OK" runat="server" Style="display: inline;
                            padding-right: 10px;" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="clear">
        </div>
    </div>
</asp:Panel>
<ajx:ModalPopupExtender ID="mpeConfirmDeleteQPCardInfo" runat="server" TargetControlID="hdnConfirmDeleteQPCardInfo"
    PopupControlID="pnlDeleteDataQPCardInfo" BackgroundCssClass="mod_background"
    CancelControlID="btnCancelDeleteQPCardInfo" BehaviorID="mpeConfirmDeleteQPCardInfo">
</ajx:ModalPopupExtender>
<asp:HiddenField ID="hdnConfirmDeleteQPCardInfo" runat="server" />
<asp:Panel ID="pnlDeleteDataQPCardInfo" runat="server" Height="350px" Width="325px"
    Style="display: none;">
    <div class="box_col1">
        <div class="box_head">
            <span>
                <asp:Literal ID="ltrHeaderConfirmDeletePopupQPCardInfo" runat="server" Text="Message"></asp:Literal></span></div>
        <div class="clear">
        </div>
        <div class="box_form">
            <table cellpadding="2" cellspacing="2" width="100%">
                <tr>
                    <td align="center" style="padding-bottom: 15px;">
                        <asp:Label ID="lblConfirmDeleteMessageQPCardInfo" runat="server" Text="Are You sure want to Delete ?"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btnYesQPCardInfo" runat="server" Style="display: inline; padding-right: 10px;"
                            OnClick="btnYesQPCardInfo_Click" Text="Ok" />
                        <asp:Button ID="btnCancelDeleteQPCardInfo" runat="server" Style="display: inline;"
                            Text="Cancel" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="clear">
        </div>
    </div>
</asp:Panel>
<ajx:ModalPopupExtender ID="mpeCreditCardInfoMsg" runat="server" TargetControlID="hdnCreditCardInfoMsg"
    PopupControlID="pnlCreditCardInfoMsg" BackgroundCssClass="mod_background" CancelControlID="btnCreditCardInfoMsgOk">
</ajx:ModalPopupExtender>
<asp:HiddenField ID="hdnCreditCardInfoMsg" runat="server" />
<asp:Panel ID="pnlCreditCardInfoMsg" runat="server" Height="350px" Width="325px"
    Style="display: none;">
    <div class="box_col1">
        <div class="box_head">
            <span>
                <asp:Literal ID="Literal1" runat="server" Text="Message"></asp:Literal></span></div>
        <div class="clear">
        </div>
        <div class="box_form">
            <table cellpadding="2" cellspacing="2" width="100%">
                <tr>
                    <td align="center" style="padding-bottom: 15px;">
                        <asp:Label ID="Label1" runat="server" Text="Please Select Credit Card Info."></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btnCreditCardInfoMsgOk" runat="server" Style="display: inline; padding-right: 10px;"
                            Text="Ok" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="clear">
        </div>
    </div>
</asp:Panel>
<div id="errormessage" class="clear">
    <uc11:MsgBox1 ID="MessageBox" runat="server" />
</div>
