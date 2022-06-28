<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCommonPayment.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls.CtrlCommonPayment" %>
<%@ Register Src="~/UIControls/Folio/CtrlCommonSubFolioConfiguration.ascx" TagName="SubFolioConfiguration"
    TagPrefix="ucCtrlSubFolioConfiguration" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript">
    function fnConfirmDelete(id) {

        document.getElementById('errormessage').style.display = "block";
        document.getElementById('<%= hdnConfirmDelete.ClientID %>').value = id;
        $find('mpeConfirmDelete').show();
        return false;
    }
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<ajx:ModalPopupExtender ID="mpePayment" runat="server" TargetControlID="hdnPayment"
    PopupControlID="pnlPayment" BackgroundCssClass="mod_background">
</ajx:ModalPopupExtender>
<asp:HiddenField ID="hdnPayment" runat="server" />
<asp:Panel ID="pnlPayment" runat="server" Width="800px" Style="display: none;">
    <asp:HiddenField ID="hdnPaymentType" runat="server" />
    <asp:HiddenField ID="hdnResPayID" runat="server" />
    <asp:MultiView ID="mvPayment" runat="server">
        <asp:View ID="vPayment" runat="server">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="litPaymentHeader" runat="server" Text="Payment"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" border="0" width="100%">
                        <tr>
                            <td colspan="4">
                                <%if (IsMessageForPayment)
                                  { %>
                                <div class="message finalsuccess">
                                    <p>
                                        <strong>
                                            <asp:Literal ID="litPaymentMsg" runat="server"></asp:Literal></strong>
                                    </p>
                                </div>
                                <%}%>
                            </td>
                        </tr>
                        <tr style="background-color: #F3F3F5;">
                            <td style="vertical-align: top; border: 1px solid #ccccce !important;" colspan="4">
                                <table cellpadding="2" cellspacing="2" width="100%">
                                    <tr>
                                        <td>
                                            <asp:Literal ID="litPaymentFolioNo" runat="server" Text="Folio No."></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal ID="litDisplayPaymentFolioNo" runat="server"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal ID="litPaymentUnitNo" runat="server" Text="Room No."></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal ID="litDisplayRoomNoAndRoomType" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="litPaymentName" runat="server" Text="Name"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal ID="litDisplayPaymentGuestName" runat="server"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal ID="litPaymentBalance" runat="server" Text="Balance"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal ID="litDisplayPaymentBalance" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <%--<td>
                                <asp:Literal ID="litPaymentPMT" runat="server" Text="Payment Mode"></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="litDisplayPaymentPMT" runat="server" Text="BACS"></asp:Literal>
                            </td>--%>
                            <td class="isrequire">
                                <asp:Literal ID="litPModeofPayment" runat="server" Text="Mode of Payment"></asp:Literal>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlPModeOfPayment" runat="server" Style="width: 200px !important;"
                                    OnSelectedIndexChanged="ddlPModeOfPayment_OnSelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                                <span>
                                    <asp:RequiredFieldValidator ID="rfvPaymentCardType" InitialValue="00000000-0000-0000-0000-000000000000"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                        ValidationGroup="IsRequirePayment" ControlToValidate="ddlPModeOfPayment">
                                    </asp:RequiredFieldValidator>
                                </span>
                            </td>
                            <td class="isrequire">
                                <asp:Literal ID="litPaymentAmount" runat="server" Text="Amount"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPaymentAmount" runat="server" Style="width: 200px !important;
                                    text-align: right;" MaxLength="18"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rfvPaymentAmount" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                        runat="server" ValidationGroup="IsRequirePayment" ControlToValidate="txtPaymentAmount">
                                    </asp:RequiredFieldValidator>
                                </span>
                                <ajx:FilteredTextBoxExtender ID="ftPaymentAmount" runat="server" TargetControlID="txtPaymentAmount"
                                    FilterType="Custom, Numbers" ValidChars="." />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                            <td colspan="2">
                                <asp:RegularExpressionValidator Display="Static" ID="revPaymentAmount" runat="server"
                                    ForeColor="Red" ControlToValidate="txtPaymentAmount" SetFocusOnError="true" ValidationGroup="IsRequirePayment">
                                </asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr id="trLedgerAccount" runat="server" visible="false">
                            <td>
                                Ledger
                            </td>
                            <td colspan="3">
                                <asp:DropDownList ID="ddlLedgerAccount" runat="server" Style="width: 200px !important;">
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
                            <td>
                                Cheque/DD No.
                            </td>
                            <td>
                                <asp:TextBox ID="txtChequeDDNo" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <%--<td>
                                <asp:Literal ID="litPaymentReservation" runat="server" Text="Booking"></asp:Literal>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlPaymentReservation" runat="server">
                                    <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                    <asp:ListItem Text="Mr. Prakash Patel 0123" Value="Mr. Prakash Patel 0123"></asp:ListItem>
                                    <asp:ListItem Text="Mr. Pinakin Patel 4567" Value="Mr. Pinakin Patel 4567"></asp:ListItem>
                                </asp:DropDownList>
                            </td>--%>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="litPaymentNotes" runat="server" Text="Notes"></asp:Literal>
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="txtPaymentNotes" TextMode="MultiLine" Style="width: 614px !important;"
                                    SkinID="BigInput" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center" style="text-align: center;">
                                <div style="width: auto; display: inline-block; text-align: center;">
                                    <asp:Button ID="btnPaymentCancel" Style="float: right; margin-left: 5px;" runat="server"
                                        Text="Cancel" />
                                    <asp:Button ID="btnPaymentSubFolio" Style="float: right; margin-left: 5px;" runat="server"
                                        Text="Sub Folio" OnClick="btnPaymentSubFolio_Click" Visible="false" />
                                    <asp:Button ID="btnPaymentCardInfo" Style="float: right; margin-left: 5px;" runat="server"
                                        Text="Card Info." OnClick="btnPaymentCardInfo_Click" Visible="false" />
                                    <%--<asp:Button ID="btnPaymentForeignCurrency" Style="float: right; margin-left: 5px;"
                                        runat="server" Text="Foreign Currency" />--%>
                                    <asp:Button ID="btnPaymentSave" Style="float: right; margin-left: 5px;" runat="server"
                                        CausesValidation="true" Text="Save" ValidationGroup="IsRequirePayment" OnClick="btnPaymentSave_Click" />
                                    <asp:Button ID="btnPaymentPrint" Style="float: right; margin-left: 5px;" runat="server"
                                        Text="Print" Visible="false" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:View>
        <asp:View ID="VCardInofForPayment" runat="server">
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
                                    <asp:ListItem Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
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
        <asp:View ID="vSubFolioForPayment" runat="server">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="litSubFolioHeader" runat="server" Text="Sub Folio"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <ucCtrlSubFolioConfiguration:SubFolioConfiguration ID="ctrlCommonSubFolioConfiguration"
                        runat="server" OnbtnSubFolioConfigurationCallParent_Click="btnSubFolioConfigurationCallParent_Click" />
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:View>
    </asp:MultiView>
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
                <asp:Literal ID="ltrHeaderConfirmDeletePopup" runat="server" Text="Message"></asp:Literal></span></div>
        <div class="clear">
        </div>
        <div class="box_form">
            <table cellpadding="2" cellspacing="2" width="100%">
                <tr>
                    <td align="center" style="padding-bottom: 15px;">
                        <asp:Label ID="lblConfirmDeleteMessage" runat="server" Text="Are You sure want to Delete ?"></asp:Label>
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
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
