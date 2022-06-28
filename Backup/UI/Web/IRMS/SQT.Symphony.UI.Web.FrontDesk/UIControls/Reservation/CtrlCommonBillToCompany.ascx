<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCommonBillToCompany.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation.CtrlCommonBillToCompany" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox1" TagPrefix="ucMsg" %>
<script src="../../Scripts/Common.js" type="text/javascript"></script>
<script>
    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }

    function fnCheckDate() {
        if (Page_ClientValidate("BillToCompany")) {
            var varDateFrom = document.getElementById('<%= txtBillToCmpStartDate.ClientID %>').value;
            var varDateTo = document.getElementById('<%= txtBillToCmpEndDate.ClientID %>').value;

            if (varDateFrom != '' && varDateTo != '') {
                var dateFormat = document.getElementById('<%= hfDateFormat.ClientID %>').value;

                var dateFrom = fnGetValidDateFormat(varDateFrom, dateFormat);
                var dateTo = fnGetValidDateFormat(varDateTo, dateFormat);

                dateFrom = Date.parse(dateFrom, 'MM/dd/yyyy');
                dateTo = Date.parse(dateTo, 'MM/dd/yyyy');

                if (dateFrom > dateTo) {
                    $find('mpeDateMessage').show();
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
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

</script>
<asp:HiddenField ID="hfDateFormat" runat="server" />
<ajx:ModalPopupExtender ID="mpeBillToCompany" runat="server" TargetControlID="hdnBillToCompany"
    PopupControlID="pnlBillToCompany" BackgroundCssClass="mod_background">
</ajx:ModalPopupExtender>
<asp:HiddenField ID="hdnBillToCompany" runat="server" />
<asp:Panel ID="pnlBillToCompany" runat="server" Width="750px" Style="display: none;">
    <div class="box_col1">
        <div class="box_head">
            <div style="display: inline;">
                <span>
                    <asp:Literal ID="litBillToCompany" runat="server" Text="Bill To Company"></asp:Literal></span></div>
            <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                <asp:ImageButton ID="iBtnCloseForm" runat="server" ImageUrl="~/images/closepopup.png"
                    Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;"
                    OnClick="iBtnCloseForm_Click" /></div>
            <div class="clear">
            </div>
        </div>
        <div class="box_form">
            <table cellpadding="2" cellspacing="2" width="100%">
                <tr>
                    <td colspan="2">
                        <%if (IsListMessage)
                          { %>
                        <div class="message finalsuccess">
                            <p>
                                <strong>
                                    <asp:Label ID="lblListMessage" runat="server"></asp:Label></strong>
                            </p>
                        </div>
                        <%}%>
                    </td>
                </tr>
                <tr>
                    <td width="80px">
                        <b>Billing Mode</b>
                    </td>
                    <td>
                        <asp:Literal ID="litDisplayBillingMode" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <fieldset style="border: 1px solid #ccc !important;">
                            <legend>Bill To Company </legend>
                            <table cellpadding="2" cellspacing="2" width="100%">
                                <tr>
                                    <td class="isrequire" style="width: 110px;">
                                        Start Date
                                    </td>
                                    <td width="215px">
                                        <asp:TextBox ID="txtBillToCmpStartDate" runat="server" Style="width: 125px;" onkeypress="return false;"></asp:TextBox>
                                        <asp:Image ID="imgBillToCmpStartDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                            Height="20px" Width="20px" />
                                        <ajx:CalendarExtender ID="calBillToCmpStartDate" PopupButtonID="imgBillToCmpStartDate"
                                            TargetControlID="txtBillToCmpStartDate" runat="server">
                                        </ajx:CalendarExtender>
                                        <img src="../../images/clear.png" id="imgSD" style="vertical-align: middle; display: none;"
                                            title="Clear Date" onclick="fnClearDate('<%= txtBillToCmpStartDate.ClientID %>');" />
                                        <asp:RequiredFieldValidator ID="rfvBillToCmpStartDate" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                            runat="server" ValidationGroup="BillToCompany" ControlToValidate="txtBillToCmpStartDate"
                                            Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                    <td class="isrequire">
                                        End Date
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtBillToCmpEndDate" runat="server" Style="width: 125px;" onkeypress="return false;"></asp:TextBox>
                                        <asp:Image ID="imgBillToCmpEndDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                            Height="20px" Width="20px" />
                                        <ajx:CalendarExtender ID="calBillToCmpEndDate" PopupButtonID="imgBillToCmpEndDate"
                                            TargetControlID="txtBillToCmpEndDate" runat="server">
                                        </ajx:CalendarExtender>
                                        <img src="../../images/clear.png" id="imgED" style="vertical-align: middle; display: none;"
                                            title="Clear Date" onclick="fnClearDate('<%= txtBillToCmpEndDate.ClientID %>');" />
                                        <asp:RequiredFieldValidator ID="rfvBillToCmpEndDate" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                            runat="server" ValidationGroup="BillToCompany" ControlToValidate="txtBillToCmpEndDate"
                                            Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 110px;">
                                        Bill To Company
                                    </td>
                                    <td>
                                        <%--OnSelectedIndexChanged="ddlDiscountType_OnSelectedIndexChanged" AutoPostBack="true"--%>
                                        <asp:DropDownList ID="ddlDiscountType" runat="server" Style="width: 90px !important;">
                                            <asp:ListItem Value="0" Text="%"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Flat"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td colspan="2">
                                        Amount &nbsp;&nbsp;
                                        <asp:TextBox ID="txtCompnayWillBare" runat="server" MaxLength="18" Style="width: 100px;"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvCompnayWillBare" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                            runat="server" ValidationGroup="BillToCompany" ControlToValidate="txtCompnayWillBare"
                                            Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revDiscountType" SetFocusOnError="True" runat="server"
                                            ValidationGroup="BillToCompany" ControlToValidate="txtCompnayWillBare" Display="Dynamic"
                                            ForeColor="Red" ValidationExpression="^\d{0,18}(\.\d{0,2})?$" ErrorMessage="2 digits allowed after decimal point."></asp:RegularExpressionValidator>
                                        <ajx:FilteredTextBoxExtender ID="ftCompnayWillBare" runat="server" TargetControlID="txtCompnayWillBare"
                                            ValidChars="0123456789." FilterMode="ValidChars">
                                        </ajx:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="lblDiscountErrorMsg" runat="server" ForeColor="Red"></asp:Label>
                                        <%--<asp:RangeValidator ID="rvDiscountType" Enabled="false" Display="Dynamic" runat="server"
                                            MinimumValue="0" ControlToValidate="txtCompnayWillBare" SetFocusOnError="true"
                                            ValidationGroup="BillToCompany" ForeColor="Red" Type="Double" ErrorMessage="Discount in % should be less than or equal to 100."></asp:RangeValidator>--%>
                                    </td>
                                    <td colspan="2" align="right">
                                        <asp:Button ID="btnApply" runat="server" Text="Apply" OnClick="btnApply_Click" CausesValidation="true"
                                            OnClientClick="return fnCheckDate();" ValidationGroup="BillToCompany" />
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div class="box_head">
                            <span>
                                <asp:Literal ID="litBlockDateRateList" runat="server" Text="Room Rent"></asp:Literal>
                            </span>
                        </div>
                        <div class="clear">
                        </div>
                        <div class="box_content">
                            <div style="height: 250px; overflow: auto;">
                                <asp:GridView ID="gvBlockDateRateList" runat="server" AutoGenerateColumns="false"
                                    ShowHeader="true" Width="100%" OnRowDataBound="gvBlockDateRateList_RowDataBound"
                                    SkinID="gvNoPaging">
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
                                                <asp:Label ID="lblGvHdrBlockDate" runat="server" Text="Date"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblGvBlockDate" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "BlockDate")).ToString(clsSession.DateFormat)%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                            <HeaderTemplate>
                                                <asp:Label ID="lblGvHdrBlockDateRate" runat="server" Text="Room Rent"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblGvBlockDateRate" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                            <HeaderTemplate>
                                                <asp:Label ID="lblGvHdrBlockDateTax" runat="server" Text="Taxes"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblGvBlockDateTax" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                            <HeaderTemplate>
                                                <asp:Label ID="lblGvHdrTotal" runat="server" Text="Total"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblGvTotal" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="130px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                            <HeaderTemplate>
                                                <asp:Label ID="lblGvHdrB2C" runat="server" Text="Bill To Company"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblGvB2C" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="130px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                            <HeaderTemplate>
                                                <asp:Label ID="lblGvHdrB2G" runat="server" Text="Bill To Guest"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblGvB2G" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <div style="padding: 10px;">
                                            <b>
                                                <asp:Label ID="lblBlockDateNoRecordFound" runat="server" Text="No Record Found."></asp:Label>
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
</asp:Panel>
<ajx:ModalPopupExtender ID="mpeDateMessage" runat="server" TargetControlID="hfDateMessage"
    PopupControlID="pnlDateMessage" BackgroundCssClass="mod_background" CancelControlID="btnDateMessageOK"
    BehaviorID="mpeDateMessage">
</ajx:ModalPopupExtender>
<asp:HiddenField ID="hfDateMessage" runat="server" />
<asp:Panel ID="pnlDateMessage" runat="server" Width="350px" Style="display: none;">
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
                        <asp:Literal ID="ltrMsgDateValidate" runat="server" Text="Start Date is greater than or equal to End Date."></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btnDateMessageOK" Text="OK" runat="server" Style="display: inline;
                            padding-right: 10px;" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="clear">
        </div>
    </div>
</asp:Panel>
<div id="errormessage" class="clear">
    <ucMsg:MsgBox1 ID="MessageBox1" runat="server" />
</div>
