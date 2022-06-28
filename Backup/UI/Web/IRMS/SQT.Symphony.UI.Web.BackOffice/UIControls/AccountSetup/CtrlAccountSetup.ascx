<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlAccountSetup.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.BackOffice.UIControls.AccountSetup.CtrlAccountSetup" %>
<%@ Register Src="~/MsgBox/MsgBx.ascx" TagName="MsgBx" TagPrefix="uc1" %>
<script type="text/javascript" language="javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    var updateProgress = null;

    function postbackButtonClick() {
        if (Page_ClientValidate("AccountSetup")) {

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
                                            <td align="left" valign="top" width="30%">
                                                <div class="box_form">
                                                    <asp:TreeView ID="tvAccount" runat="server" ImageSet="Arrows" Width="100%" OnSelectedNodeChanged="tvAccount_SelectedNodeChanged">
                                                        <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                                                        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                                                            NodeSpacing="0px" VerticalPadding="0px" />
                                                        <ParentNodeStyle Font-Bold="False" />
                                                        <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px"
                                                            VerticalPadding="0px" />
                                                    </asp:TreeView>
                                                </div>
                                            </td>
                                            <td class="boxleft">
                                                &nbsp;
                                            </td>
                                            <td class="boxright" style="vertical-align: top;">
                                                <table cellpadding="2" cellspacing="2" border="0" width="100%" style="vertical-align: top;">
                                                    <tr>
                                                        <td colspan="2">
                                                            <% if (IsListMessage)
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
                                                        <td colspan="2">
                                                            <div style="float: right; padding-bottom: 5px;">
                                                                <b>
                                                                    <asp:Literal ID="litGeneralMandartoryFiledMessage" runat="server"></asp:Literal>
                                                                </b>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <%--<tr>
                                                        <td>
                                                            <asp:Literal ID="litAccountNo" runat="server"></asp:Literal>
                                                        </td>
                                                        <td style="width: 315px;">
                                                            <asp:TextBox ID="txtAccountNo" runat="server" MaxLength="7"></asp:TextBox>
                                                            <span>
                                                                <ajx:FilteredTextBoxExtender ID="ftbeAccountNo" TargetControlID="txtAccountNo" runat="server"
                                                                    FilterMode="ValidChars" ValidChars="0123456789">
                                                                </ajx:FilteredTextBoxExtender>
                                                                <asp:RequiredFieldValidator ID="rfvAccountNo" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                    runat="server" ValidationGroup="IsRequire" ControlToValidate="txtAccountNo" Display="Dynamic"></asp:RequiredFieldValidator></span>
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td class="isrequire">
                                                            <asp:Literal ID="litAccountName" runat="server"></asp:Literal>
                                                        </td>
                                                        <td style="width: 315px;">
                                                            <asp:TextBox ID="txtAccountName" runat="server" MaxLength="150"></asp:TextBox>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvAccountName" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                    runat="server" ValidationGroup="IsRequire" ControlToValidate="txtAccountName"
                                                                    Display="Dynamic"></asp:RequiredFieldValidator></span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="isrequire">
                                                            <asp:Literal ID="litAccountGroup" runat="server"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlAccountGroup" runat="server" AutoPostBack="true" Style="width: 150px;
                                                                height: 25px;" OnSelectedIndexChanged="ddlAccountGroup_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rvfAccountGroup" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                    ValidationGroup="IsRequire" ControlToValidate="ddlAccountGroup" Display="Dynamic">
                                                                </asp:RequiredFieldValidator>
                                                            </span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litSubAccount" runat="server"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlSubAccount" runat="server" AutoPostBack="true" Style="width: 150px;
                                                                height: 25px;" OnSelectedIndexChanged="ddlSubAccount_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litReRouteGroup" runat="server"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlReRouteGroup" runat="server" Style="width: 150px; height: 25px;">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litOpeningBalance" runat="server"></asp:Literal>
                                                        </td>
                                                        <td style="width: 315px;">
                                                            <asp:TextBox ID="txtOpeningBalance" runat="server" MaxLength="10"></asp:TextBox>
                                                            <ajx:FilteredTextBoxExtender ID="ftOpeningBalance" TargetControlID="txtOpeningBalance"
                                                                runat="server" FilterMode="ValidChars" ValidChars="0123456789.">
                                                            </ajx:FilteredTextBoxExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litCurrentBalance" runat="server"></asp:Literal>
                                                        </td>
                                                        <td style="width: 315px;">
                                                            <asp:TextBox ID="txtCurrentBalance" runat="server" MaxLength="10" ReadOnly="true"></asp:TextBox>
                                                            <ajx:FilteredTextBoxExtender ID="ftCurrentBalance" TargetControlID="txtCurrentBalance"
                                                                runat="server" FilterMode="ValidChars" ValidChars="0123456789.">
                                                            </ajx:FilteredTextBoxExtender>
                                                        </td>
                                                    </tr>                                                  
                                                    <tr>
                                                        <td colspan="2">
                                                            <div style="padding-bottom: 5px;">
                                                                <h1>
                                                                    <asp:Literal ID="litHeaderAccountType" runat="server"></asp:Literal>
                                                                </h1>
                                                            </div>
                                                            <hr />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="checkbox_new">
                                                            
                                                            <asp:CheckBox ID="chkIsEnable" runat="server" />
                                                        </td>
                                                        <td class="checkbox_new" align="left">
                                                            <asp:CheckBox ID="chkMOPAccount" runat="server" AutoPostBack="true" OnCheckedChanged="chkMOPAccount_CheckedChanged" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="checkbox_new">
                                                            <asp:CheckBox ID="chkShowInStatement" runat="server" Visible="false" />
                                                        </td>
                                                        <td class="checkbox_new">
                                                            <asp:CheckBox ID="chkPaidOut" runat="server" AutoPostBack="true" OnCheckedChanged="chkMOPAccount_CheckedChanged" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="checkbox_new">
                                                            <asp:CheckBox ID="chkOverride" runat="server" Visible="false" />
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="lblMOPAcct" runat="server" Text="MOP Type"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="checkbox_new">
                                                            <asp:CheckBox ID="chkServiceAccount" runat="server" />
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlMOPAccount" runat="server" AutoPostBack="true" Style="width: 150px;
                                                                height: 25px;">
                                                            </asp:DropDownList>
                                                             <span>
                                                                <asp:RequiredFieldValidator ID="rfvMOPAccount" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                    ValidationGroup="IsRequire" ControlToValidate="ddlMOPAccount" Display="Dynamic">
                                                                </asp:RequiredFieldValidator>
                                                            </span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="checkbox_new" align="left">
                                                            <asp:CheckBox ID="chkRoomRevenueAccount" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="checkbox_new" align="left">
                                                            <asp:CheckBox ID="chkItemAccount" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <div style="padding-bottom: 5px;">
                                                                <h1>
                                                                    <asp:Literal ID="litTaxes" runat="server"></asp:Literal>
                                                                </h1>
                                                            </div>
                                                            <hr />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:CheckBoxList ID="chklstTax" runat="server" />
                                                        </td>
                                                    </tr>
                                                      <tr style="visibility:hidden;">
                                                        <td>
                                                            <asp:Literal ID="litBalanceType" runat="server"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:RadioButton ID="rdoCredit" GroupName="BalanceType" runat="server" />
                                                            <asp:RadioButton ID="rdoDebit" GroupName="BalanceType" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr  style="visibility:hidden;">
                                                        <td colspan="2">
                                                            <%--<div style="padding-bottom: 5px;">
                                                                <h1>--%>
                                                                    <asp:Literal ID="litDefaultAccount" runat="server"></asp:Literal>
                                                              <%--  </h1>
                                                            </div>--%>
                                                            <%--<hr />--%>
                                                        </td>
                                                    </tr>
                                                    <tr  style="visibility:hidden;">
                                                        <td>
                                                            <asp:Literal ID="litDefaultAmt" runat="server"></asp:Literal>
                                                        </td>
                                                        <td style="width: 315px;">
                                                            <asp:TextBox ID="txtDefaultAmt" runat="server" MaxLength="10"></asp:TextBox>
                                                            <ajx:FilteredTextBoxExtender ID="ftDefaultAmt" TargetControlID="txtDefaultAmt" runat="server"
                                                                FilterMode="ValidChars" ValidChars="0123456789.">
                                                            </ajx:FilteredTextBoxExtender>
                                                        </td>
                                                    </tr>
                                                    <tr style="visibility:hidden;">
                                                        <td class="checkbox_new" align="left">
                                                            <asp:CheckBox ID="chkIsDefault" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <div style="float: right; width: auto; display: inline-block;">
                                                                <asp:Button ID="btnCancel" runat="server" CausesValidation="false" ImageUrl="~/images/cancle.png"
                                                                    Style="float: right; margin-left: 5px;" OnClick="btnCancel_Click" />
                                                                <asp:Button ID="btnDelete" runat="server" Visible="false" CausesValidation="true" ImageUrl="~/images/delete.png"
                                                                    Text="Delete" Style="float: right; margin-left: 5px;" ValidationGroup="IsRequire"
                                                                    OnClientClick="return postbackButtonClick();" OnClick="btnDelete_Click" />
                                                                <asp:Button ID="btnSave" runat="server" CausesValidation="true" ImageUrl="~/images/save.png"
                                                                    Style="float: right; margin-left: 5px;" ValidationGroup="IsRequire" OnClientClick="return postbackButtonClick();"
                                                                    OnClick="btnSave_Click" />
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
                        <%--<uc1:MsgBox ID="MessageBox" runat="server" />--%>
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
<ajx:ModalPopupExtender ID="mpeBankDetail" runat="server" TargetControlID="hdnBank"
    PopupControlID="pnlBank" BackgroundCssClass="mod_background" BehaviorID="mpeBank">
</ajx:ModalPopupExtender>
<asp:HiddenField ID="hdnBank" runat="server" />
<asp:Panel ID="pnlBank" runat="server" Width="800px" Style="display: none;">
    <div class="box_col1">
        <div class="box_head">
            <span>
                <asp:Literal ID="Literal1" Text="Bank Account" runat="server"></asp:Literal></span></div>
        <div class="clear">
        </div>
        <div class="box_form">
            <table cellpadding="2" cellspacing="2" width="100%">
                <tr>
                    <td style="padding-bottom: 15px;">
                        <div style="padding-bottom: 5px;">
                            <h1>
                                <asp:Literal ID="Literal2" Text="Account Information" runat="server"></asp:Literal>
                            </h1>
                        </div>
                        <table cellpadding="2" cellspacing="2" width="100%">
                            <tr>
                                <td style="width: 150px;">
                                    <asp:Literal ID="litBankName" runat="server" Text="Bank Name"></asp:Literal>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtBankName" Text="" runat="server"></asp:TextBox>
                                    <span>
                                        <asp:RequiredFieldValidator ID="rfvtxtBankName" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                            runat="server" ValidationGroup="IsRequireBankDetail" ControlToValidate="txtBankName"
                                            Display="Dynamic"></asp:RequiredFieldValidator></span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Literal ID="litContactName" runat="server" Text="Contact Name"></asp:Literal>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtContactName" Text="" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Literal ID="litContactNo" runat="server" Text="Contact No."></asp:Literal>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtContactNo" Text="" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Literal ID="litAcctNo" runat="server" Text="Account No"></asp:Literal>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAcctNo" runat="server" Text="Gujarat"></asp:TextBox>
                                    <span>
                                        <ajx:FilteredTextBoxExtender ID="ftbeAcctNo" TargetControlID="txtAcctNo" runat="server"
                                            FilterMode="ValidChars" ValidChars="0123456789">
                                        </ajx:FilteredTextBoxExtender>
                                        <asp:RequiredFieldValidator ID="rfvAcctNo" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                            runat="server" ValidationGroup="IsRequireBankDetail" ControlToValidate="txtAcctNo"
                                            Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Literal ID="litSortCode" runat="server" Text="Sort Code"></asp:Literal>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSortCode" Text="" runat="server"></asp:TextBox>
                                    <span>
                                        <ajx:FilteredTextBoxExtender ID="ftbeSortCode" TargetControlID="txtSortCode" runat="server"
                                            FilterMode="ValidChars" ValidChars="0123456789">
                                        </ajx:FilteredTextBoxExtender>
                                        <asp:RequiredFieldValidator ID="rfvtxtSortCode" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                            runat="server" ValidationGroup="IsRequireBankDetail" ControlToValidate="txtSortCode"
                                            Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Literal ID="litBalance" runat="server" Text="Balance"></asp:Literal>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtBalance" Text="" runat="server"></asp:TextBox>
                                    <span>
                                        <ajx:FilteredTextBoxExtender ID="ftbeBalance" TargetControlID="txtBalance" runat="server"
                                            FilterMode="ValidChars" ValidChars="0123456789.">
                                        </ajx:FilteredTextBoxExtender>
                                        <asp:RequiredFieldValidator ID="rfvBalance" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                            runat="server" ValidationGroup="IsRequireBankDetail" ControlToValidate="txtBalance"
                                            Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                    </span>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="padding-bottom: 15px;">
                        <div style="padding-bottom: 5px;">
                            <h1>
                                <asp:Literal ID="Literal3" Text="Address Information" runat="server"></asp:Literal>
                            </h1>
                        </div>
                        <table cellpadding="2" cellspacing="2" width="100%">
                            <tr>
                                <td style="width: 150px;">
                                    <asp:Literal ID="litAddress" runat="server" Text="Address"></asp:Literal>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAddress1" Text="" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAddress2" Text="" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Literal ID="litCity" runat="server" Text="City"></asp:Literal>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCity" Text="" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Literal ID="litZipCode" runat="server" Text="Zip Code"></asp:Literal>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtZipCode" Text="" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Literal ID="litState" runat="server" Text="State"></asp:Literal>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtState" runat="server" Text=""></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Literal ID="littCountry" runat="server" Text="Country"></asp:Literal>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCountry" Text="" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="btnSaveBankDetail" OnClick="btnSaveBankDetail_OnClick" runat="server"
                            Text="Save" Style="display: inline;" ValidationGroup="IsRequireBankDetail" />
                        <asp:Button ID="btnCancelBankDetail" runat="server" Text="Cancel" Style="display: inline;" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="clear">
        </div>
    </div>
</asp:Panel>
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
