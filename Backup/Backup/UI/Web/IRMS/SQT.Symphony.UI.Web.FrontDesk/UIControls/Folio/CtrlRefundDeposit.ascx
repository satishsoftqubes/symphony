<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlRefundDeposit.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Folio.CtrlRefundDeposit" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<%--<ajx:ModalPopupExtender ID="mpeRefundDeposit" runat="server" TargetControlID="hdnRefundDeposit"
    PopupControlID="pnlRefundDeposit" BackgroundCssClass="mod_background">
</ajx:ModalPopupExtender>
<asp:HiddenField ID="hdnRefundDeposit" runat="server" />
<asp:Panel ID="pnlRefundDeposit" runat="server" Width="750px" Style="display: none;">--%>
    <asp:MultiView ID="mvRefundDeposit" runat="server">
        <asp:View ID="vRefundDeposit" runat="server">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="litRefundDepositHeader" runat="server" Text="Refund Deposit"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td>
                                <div style="float: left; width: 75px;">
                                    <asp:Literal ID="litQuickPostFolioNo" runat="server" Text="Folio No."></asp:Literal>
                                </div>
                                <div style="float: left; width: 100px;">
                                    <asp:Literal ID="litDisplayQuickPostFolioNo" runat="server" Text="100141"></asp:Literal>
                                </div>
                                <div style="float: left; width: 75px;">
                                    <asp:Literal ID="litQuickPostUnitNo" runat="server" Text="Room No."></asp:Literal>
                                </div>
                                <div style="float: left; width: 100px;">
                                    <asp:Literal ID="litDisplayQuickPostUnitNo" runat="server" Text="100141"></asp:Literal>
                                </div>
                                <div style="float: left; width: 75px;">
                                    <asp:Literal ID="litQuickPostName" runat="server" Text="Name"></asp:Literal>
                                </div>
                                <div style="float: left;">
                                    <asp:Literal ID="litDisplayQuickPostName" runat="server" Text="Mr. Prakash Patel"></asp:Literal>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 150px; overflow: auto;">
                                <div class="box_head">
                                    <span>
                                        <asp:Literal ID="litRefundDepositList" runat="server" Text="Refund Deposit List"></asp:Literal>
                                    </span>
                                </div>
                                <div class="clear">
                                </div>
                                <div class="box_content">
                                    <asp:GridView ID="gvRefundDepositList" runat="server" AutoGenerateColumns="false"
                                        ShowHeader="true" Width="100%" SkinID="gvNoPaging">
                                        <Columns>
                                            <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="chkSelectAllRefundDeposit" runat="server" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkSelectRefundDeposit" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrQuickPostSrNo" runat="server" Text="No."></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrRefundDepositDeposit" runat="server" Text="Deposit"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "Deposit")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrRefundDepositDate" runat="server" Text="Date"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "Date")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrRefundDepositPayBy" runat="server" Text="Pay By"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "PayBy")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrRefundDepositBalance" runat="server" Text="Balance"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "Balance")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrRefundDepositRefundAC" runat="server" Text="Refund A/C."></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlRefundDepositRefundAC" runat="server" style="width:130px !important;">
                                                        <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                        <asp:ListItem Text="BACS - 1202" Value="BACS - 1202"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrRefundDepositRefund" runat="server" Text="Refund"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "Refund")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrRefundDepositForfeited" runat="server" Text="Forfeited"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "Forfeited")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <div style="padding: 10px;">
                                                <b>
                                                    <asp:Label ID="lblRefundDepositNoRecordFound" runat="server" Text="No Record Found."></asp:Label>
                                                </b>
                                            </div>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnRefundDepositSave" runat="server" Style="display: inline; padding-right: 10px;"
                                    Text="Save" />
                                <asp:Button ID="btnRefundDepositCardInfo" runat="server" Style="display: inline;"
                                    Text="Card Info." OnClick="btnRefundDepositCardInfo_Click" />
                                <asp:Button ID="btnRefundDepositCancel" runat="server" Style="display: inline;" Text="Cancel" />
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
                            <td colspan="4" style="font-weight: bold; font-size: 13px; border: 1px solid grey;">
                                <asp:Literal ID="litDisplayCardHolderName" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire" style="width: 120px !important;">
                                <asp:Literal ID="litCardType" runat="server" Text="Type"></asp:Literal>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCardType" runat="server" Style="width: 200px;">
                                    <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                    <asp:ListItem Text="American Express" Value="American Express"></asp:ListItem>
                                    <asp:ListItem Text="Mastero" Value="Mastero"></asp:ListItem>
                                    <asp:ListItem Text="Mastercard" Value="Mastercard"></asp:ListItem>
                                    <asp:ListItem Text="Solo" Value="Solo"></asp:ListItem>
                                    <asp:ListItem Text="Visa" Value="Visa"></asp:ListItem>
                                </asp:DropDownList>
                                <span>
                                    <asp:RequiredFieldValidator ID="rfvCardType" InitialValue="00000000-0000-0000-0000-000000000000"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                        ValidationGroup="AddCardDetails" ControlToValidate="ddlCardType" Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                </span>
                            </td>
                            <td class="isrequire">
                                <asp:Literal ID="litCardNo" runat="server" Text="Card No."></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCardNo" runat="server" Style="width: 198px;"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rfvCardNo" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                        runat="server" ValidationGroup="AddCardDetails" ControlToValidate="txtCardNo"
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
                                        runat="server" ValidationGroup="AddCardDetails" ControlToValidate="txtCardHolderName"
                                        Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                </span>
                            </td>
                            <td>
                                <asp:Literal ID="litIssueDate" runat="server" Text="Issue Date"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtIssueDate" runat="server" Style="width: 198px;"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire">
                                <asp:Literal ID="litExpiryDate" runat="server" Text="Expiry Date"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtExpiryDate" runat="server" Style="width: 198px;"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rfvExpiryDate" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                        runat="server" ValidationGroup="AddCardDetails" ControlToValidate="txtExpiryDate"
                                        Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                </span>
                            </td>
                            <td>
                                <asp:Literal ID="litIssueNo" runat="server" Text="Issue No."></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtIssueNo" runat="server" Style="width: 198px;"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire">
                                <asp:Literal ID="litSecurityCode" runat="server" Text="Security Code(CVC)"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSecurityCode" runat="server" Style="width: 198px;"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rfvSecurityCode" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                        runat="server" ValidationGroup="AddCardDetails" ControlToValidate="txtSecurityCode"
                                        Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                </span>
                            </td>
                            <td>
                                <asp:Literal ID="litAuthorizationCode" runat="server" Text="Authorization Code"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAuthorizationCode" runat="server" Style="width: 198px;"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="litAuthorizedAmount" runat="server" Text="Authorized Amount"></asp:Literal>
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="txtAuthorizedAmount" runat="server" Style="width: 198px;"></asp:TextBox>
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
                                    OnClientClick="fnDisplayCatchErrorMessage();" ValidationGroup="AddCardDetails"
                                    Text="Save" />
                                <asp:Button ID="btnSaveAndExitCardDetails" runat="server" Style="display: inline;"
                                    Text="Save And Close" ValidationGroup="AddCardDetails" />
                                <asp:Button ID="btnCancelCardDetails" runat="server" Style="display: inline;" Text="Cancel"
                                    OnClick="btnCancelCardDetails_Click" />
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
                                    <asp:GridView ID="gvCardList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                        Width="100%">
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
                                                    <asp:Label ID="lblGvHdrType" runat="server" Text="Type"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "Type")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrCardNo" runat="server" Text="Card No."></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "CardNo")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrName" runat="server" Text="Name"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "Name")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrServices" runat="server" Text="Expiry Date"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "ExpiryDate")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrUnitTaxes" runat="server" Text="Security Code"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "SecurityCode")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrAction" runat="server" Text="Actions"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkEdit" runat="server" ToolTip="Edit" CommandName="EDITDATA"><img src="../../images/file.png" /></asp:LinkButton>
                                                    <asp:LinkButton ID="lnkDelete" runat="server" ToolTip="Delete" CommandName="DELETEDATA"><img src="../../images/delete.png" /></asp:LinkButton>
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
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:View>
    </asp:MultiView>
<%--</asp:Panel>--%>
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
