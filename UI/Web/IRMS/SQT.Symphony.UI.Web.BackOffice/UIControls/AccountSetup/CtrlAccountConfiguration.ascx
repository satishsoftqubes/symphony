<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlAccountConfiguration.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.BackOffice.UIControls.AccountSetup.CtrlAccountConfiguration" %>
<%@ Register Src="~/MsgBox/MsgBx.ascx" TagName="MsgBx" TagPrefix="uc1" %>
<script type="text/javascript" language="javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
  
    var updateProgress = null;

    function postbackButtonClick() {
        if (Page_ClientValidate("AccountConfiguration")) {

            document.getElementById('errormessage').style.display = "block";
            updateProgress = $find("<%= UpdateProgressAccount.ClientID %>");
            window.setTimeout("updateProgress.set_visible(true)", updateProgress.get_displayAfter());
            return true;
        }
        else {
            return false;
        }
    }
    </script>

</script>
<asp:UpdatePanel ID="updAccountConfig" runat="server">
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
                                <asp:Literal ID="litMainHeader" runat="server"></asp:Literal>
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
                                    <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                        <tr>
                                            <td colspan="2">
                                                 <% if (IsMessage)
                                                   { %>
                                                 <div class="message finalsuccess">
                                                    <p>
                                                        <strong>
                                                            <asp:Literal ID="litListMessage" runat="server"></asp:Literal></strong>
                                                    </p>
                                                </div>
                                                <% }%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" >
                                                <div style="float: right; padding-bottom: 5px;">
                                                    <b>
                                                        <asp:Literal ID="litGeneralMandartoryFiledMessage" runat="server"></asp:Literal>
                                                    </b>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="isrequire"  style="width:150px;" >
                                                <asp:Literal ID="litAccountMehod" runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlAccountMethod" runat="server" Style="width: 150px; height: 25px;">
                                                </asp:DropDownList>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rvfAccountMethod" InitialValue="00000000-0000-0000-0000-000000000000"
                                                        SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                        ValidationGroup="IsRequire" ControlToValidate="ddlAccountMethod" Display="Dynamic">
                                                    </asp:RequiredFieldValidator>
                                                </span>
                                            </td>
                                        </tr>
                                       <%-- <tr>
                                            <td>
                                                <asp:Literal ID="litFinancialYear" runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlFinancialYear" runat="server" Style="width: 100px; height: 25px;">
                                                </asp:DropDownList>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rvfFinancialYear" InitialValue="00000000-0000-0000-0000-000000000000"
                                                        SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                        ValidationGroup="IsRequire" ControlToValidate="ddlFinancialYear" Display="Dynamic">
                                                    </asp:RequiredFieldValidator>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal ID="litFolioDate" runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlFolioDate" runat="server" Style="width: 100px; height: 25px;">
                                                </asp:DropDownList>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rfvFolioDate" InitialValue="00000000-0000-0000-0000-000000000000"
                                                        SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                        ValidationGroup="IsRequire" ControlToValidate="ddlFolioDate" Display="Dynamic">
                                                    </asp:RequiredFieldValidator>
                                                </span>
                                            </td>
                                        </tr>--%>
                                        <tr>
                                            <td class="isrequire">
                                                <asp:Literal ID="litCurrency" runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlCurrency" runat="server" 
                                                    Style="width: 150px; height: 25px;" AutoPostBack="true"
                                                    onselectedindexchanged="ddlCurrency_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rfvCurrency" InitialValue="00000000-0000-0000-0000-000000000000"
                                                        SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                        ValidationGroup="IsRequire" ControlToValidate="ddlCurrency" Display="Dynamic">
                                                    </asp:RequiredFieldValidator>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="isrequire">
                                                <asp:Literal ID="litCurrencyRete" runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCurrencyRate" runat="server" MaxLength="10" Style="width: 120px;"></asp:TextBox>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rvfCurrencyRate" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                        runat="server" ValidationGroup="IsRequire" ControlToValidate="txtCurrencyRate"
                                                        Display="Dynamic"></asp:RequiredFieldValidator></span>
                                                <ajx:FilteredTextBoxExtender ID="fltCurrencyValue" TargetControlID="txtCurrencyRate"
                                                    runat="server" FilterMode="ValidChars" ValidChars="0123456789.">
                                                </ajx:FilteredTextBoxExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th align="left">
                                                <asp:Literal ID="litIsAutoConversion" runat="server"></asp:Literal>
                                            </th>
                                            <td class="checkbox_new">
                                                <asp:CheckBox ID="chkAutoConversion" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="isrequire">
                                                <asp:Literal ID="litDecimalPlaces" runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDecimalPlaces" Style="width: 120px;" runat="server" MaxLength="4"></asp:TextBox>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rfvDecimalPlaces" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                        runat="server" ValidationGroup="IsRequire" ControlToValidate="txtDecimalPlaces"
                                                        Display="Dynamic"></asp:RequiredFieldValidator></span>
                                                <ajx:FilteredTextBoxExtender ID="ftDecimalPlace" runat="server" TargetControlID="txtDecimalPlaces"
                                                    FilterType="Numbers" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th align="left">
                                                <asp:Literal ID="litIsStockInHandCompulsoryBeforeSold" runat="server"></asp:Literal>
                                            </th>
                                            <td class="checkbox_new">
                                                <asp:CheckBox ID="chkStockInHandCompulsory" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th align="left">
                                                <asp:Literal ID="litIsBillRequiredBeforePayment" runat="server"></asp:Literal>
                                            </th>
                                            <td class="checkbox_new">
                                                <asp:CheckBox ID="chkBillRequiredBeforePayment" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th align="left">
                                                <asp:Literal ID="litIsUpdateStockOnReceiveGoods" runat="server"></asp:Literal>
                                            </th>
                                            <td class="checkbox_new">
                                                <asp:CheckBox ID="chkUpdateStockOnReceiveGoods" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th align="left">
                                                <asp:Literal ID="litIsUpdateStockOnDeliveryChallan" runat="server"></asp:Literal>
                                            </th>
                                            <td class="checkbox_new">
                                                <asp:CheckBox ID="chkUpdateStockOnDeliveryChallan" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th align="left">
                                                <asp:Literal ID="litIsPartialPaymentAllowed" runat="server"></asp:Literal>
                                            </th>
                                            <td class="checkbox_new">
                                                <asp:CheckBox ID="chkPartialPaymentAllowed" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th align="left">
                                                <asp:Literal ID="litIsPostingDoneAutomatically" runat="server"></asp:Literal>
                                            </th>
                                            <td class="checkbox_new">
                                                <asp:CheckBox ID="chkPostingDoneAutomatic" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th align="left">
                                                <asp:Literal ID="litIsPostingRemainderAtNightAudit" runat="server"></asp:Literal>
                                            </th>
                                            <td class="checkbox_new">
                                                <asp:CheckBox ID="chkPostingRemainderAtNightAudit" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th align="left">
                                                <asp:Literal ID="litIsTaxBreakUpInInvoice" runat="server"></asp:Literal>
                                            </th>
                                            <td class="checkbox_new">
                                                <asp:CheckBox ID="chkTaxBreakUpInInvoice" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th align="left">
                                                <asp:Literal ID="litIsAdjustmentAllowed" runat="server"></asp:Literal>
                                            </th>
                                            <td class="checkbox_new">
                                                <asp:CheckBox ID="chkAdjustmentAllowed" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th align="left">
                                                <asp:Literal ID="litIsCounterCompulsoryOnPosting" runat="server"></asp:Literal>
                                            </th>
                                            <td class="checkbox_new">
                                                <asp:CheckBox ID="chkCounterCompulsoryOnPosting" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th align="left">
                                                <asp:Literal ID="litIsCounterLoginCoumpOnDayEnd" runat="server"></asp:Literal>
                                            </th>
                                            <td class="checkbox_new">
                                                <asp:CheckBox ID="chkCounterLoginCoumpOnDayEnd" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th align="left">
                                                <asp:Literal ID="litIsInclusiveTax" runat="server"></asp:Literal>
                                            </th>
                                            <td class="checkbox_new">
                                                <asp:CheckBox ID="chkIsInclusiveTax" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <div style="padding-bottom: 5px;">
                                                    <h1>
                                                        <asp:Literal ID="litHeaderAutoGenrate" runat="server"></asp:Literal>
                                                    </h1>
                                                </div>
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="checkbox_new" align="left">
                                                <asp:CheckBox ID="chkAutoGenAcctCode" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="checkbox_new" align="left">
                                                <asp:CheckBox ID="chkAutoGenItemCode" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="checkbox_new" align="left">
                                                <asp:CheckBox ID="chkAutoGenAgentCode" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="checkbox_new" align="left">
                                                <asp:CheckBox ID="chkAutoGenCustomerCode" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="checkbox_new" align="left">
                                                <asp:CheckBox ID="chkAutoGenGuestCode" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="checkbox_new" align="left">
                                                <asp:CheckBox ID="chkAutoGenVendorCode" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <div style="float: right; width: auto; display: inline-block;">                                                 
                                                    <asp:Button ID="btnSave" runat="server" CausesValidation="true" ImageUrl="~/images/save.png"
                                                        Style="float: right; margin-left: 5px;" ValidationGroup="IsRequire" 
                                                        OnClientClick="return postbackButtonClick();" onclick="btnSave_Click" />
                                                </div>
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
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnSave" />
    </Triggers>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBx ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updAccountConfig" ID="UpdateProgressAccount"
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