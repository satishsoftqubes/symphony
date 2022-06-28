<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlBookingAgent.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.PriceManager.CtrlBookingAgent" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlAddress.ascx" TagName="ucCtrlAddress"
    TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<asp:UpdatePanel ID="upnlCorporate" runat="server">
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
                                &nbsp;
                            </td>
                            <td>
                                <div class="box_form">
                                    <table cellpadding="2" cellspacing="2" width="100%">
                                        <tr>
                                            <td colspan="2">
                                                <%if (IsFeedbackMessage)
                                                  { %>
                                                <div class="message finalsuccess">
                                                    <p>
                                                        <strong>
                                                            <asp:Literal ID="litFeedbackMessage" runat="server"></asp:Literal></strong>
                                                    </p>
                                                </div>
                                                <%}%>
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
                                        <tr>
                                            <td width="60%" style="vertical-align: top;" valign="top">
                                                <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                    <tr>
                                                        <td class="isrequire">
                                                            <asp:Literal ID="litCompanyName" runat="server"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCompanyName" runat="server" MaxLength="167"></asp:TextBox>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvCompanyName" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                    runat="server" ValidationGroup="IsRequire" ControlToValidate="txtCompanyName"></asp:RequiredFieldValidator></span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="isrequire">
                                                            <asp:Literal ID="litTitleFnameLname" runat="server"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlTitle" runat="server" Style="width: 65px;">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rvfTitle" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                ValidationGroup="IsRequire" ControlToValidate="ddlTitle" Display="Dynamic">
                                                            </asp:RequiredFieldValidator>
                                                            <asp:TextBox ID="txtFName" runat="server" SkinID="nowidth" MaxLength="75" Width="120px"></asp:TextBox>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rvfFname" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                    runat="server" ValidationGroup="IsRequire" ControlToValidate="txtFName"></asp:RequiredFieldValidator></span>
                                                            <asp:TextBox ID="txtLName" runat="server" SkinID="nowidth" MaxLength="75" Width="120px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td id="tdEmail" runat="server">
                                                            <asp:Literal ID="litEmail" runat="server"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvEmail" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                    runat="server" ValidationGroup="IsRequire" ControlToValidate="txtEmail" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ID="refEmail" SetFocusOnError="True" ControlToValidate="txtEmail"
                                                                    ValidationGroup="IsRequire" runat="server" CssClass="input-notification error png_bg"
                                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator></span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Mobile No.
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtMobileCntNo" runat="server" MaxLength="4" Style="width: 45px;"></asp:TextBox>
                                                            <ajx:FilteredTextBoxExtender ID="flttxtMobileCntNo" runat="server" TargetControlID="txtMobileCntNo"
                                                                FilterMode="ValidChars" ValidChars="1234567890+" Enabled="True" />
                                                            <asp:TextBox ID="txtMobileNo" runat="server" MaxLength="10"></asp:TextBox>
                                                            <ajx:FilteredTextBoxExtender ID="ftMobileNo" runat="server" TargetControlID="txtMobileNo"
                                                                FilterType="Numbers" Enabled="True" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="isrequire">
                                                            <asp:Literal ID="litLedgerAccount" runat="server"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlLedgerAccount" runat="server">
                                                            </asp:DropDownList>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvLedgerAccount" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                    runat="server" InitialValue="00000000-0000-0000-0000-000000000000" ValidationGroup="IsRequire"
                                                                    ControlToValidate="ddlLedgerAccount"></asp:RequiredFieldValidator></span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="checkbox_new">
                                                            <asp:CheckBox ID="chkIsCommission" runat="server" AutoPostBack="true" OnCheckedChanged="chkIsCommission_OnCheckedChanged" />
                                                        </td>
                                                        <td>
                                                            <div style="float: left; padding-left: 0px">
                                                                <table cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="txtCommission" runat="server" MaxLength="25" Enabled="false" SkinID="nowidth"
                                                                                Style="width: 100px; text-align: right;">                                                                    
                                                                            </asp:TextBox>
                                                                            <ajx:FilteredTextBoxExtender ID="fteCommission" runat="server" TargetControlID="txtCommission"
                                                                                FilterMode="ValidChars" ValidChars="0123456789.">
                                                                            </ajx:FilteredTextBoxExtender>
                                                                        </td>
                                                                        <td>
                                                                            <span>
                                                                                <asp:RequiredFieldValidator ID="rvfCommission" runat="server" ControlToValidate="txtCommission"
                                                                                    Enabled="false" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                                    ValidationGroup="IsRequire"></asp:RequiredFieldValidator>
                                                                            </span>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                            <div style="float: left; padding-left: 10px">
                                                                <asp:DropDownList ID="ddlCommissionType" runat="server" Enabled="false" OnSelectedIndexChanged="ddlCommissionType_OnSelectedIndexChanged"
                                                                    AutoPostBack="true" Style="width: 80px;">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            <div>
                                                                <asp:RangeValidator ID="rngvCommission" runat="server" ControlToValidate="txtCommission"
                                                                    SetFocusOnError="true" Type="Double" Display="Dynamic" ValidationGroup="IsRequire"
                                                                    MinimumValue="0" ForeColor="Red"></asp:RangeValidator>
                                                            </div>
                                                            <div>
                                                                <asp:RegularExpressionValidator Display="Dynamic" ID="regExpCommission" runat="server"
                                                                    ForeColor="Red" ControlToValidate="txtCommission" SetFocusOnError="true" ValidationGroup="IsRequire">
                                                                </asp:RegularExpressionValidator>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="40%" style="vertical-align: top;" valign="top">
                                                <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                    <tr id="tr8" runat="server" visible="false">
                                                        <td>
                                                        </td>
                                                        <td class="readiobuttonarea">
                                                            <asp:RadioButtonList ID="rdbLstComissionFlag" runat="server" RepeatColumns="3" CellPadding="0"
                                                                CellSpacing="0" Width="100%" Enabled="false" RepeatDirection="Horizontal">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr9" runat="server" visible="false">
                                                        <td style="vertical-align: top;" valign="top" class="checkbox_new">
                                                            <asp:CheckBox ID="chkDisableAgent" runat="server" AutoPostBack="true" OnCheckedChanged="chkDisableAgent_OnCheckedChanged" />
                                                        </td>
                                                        <td style="vertical-align: top;" valign="top">
                                                            <asp:TextBox ID="txtDisableReason" Width="307px" Height="65px" Enabled="false" runat="server"
                                                                SkinID="nowidth" TextMode="MultiLine"></asp:TextBox>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvDisableReason" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                    runat="server" ValidationGroup="IsRequire" Enabled="false" ControlToValidate="txtDisableReason"></asp:RequiredFieldValidator></span>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td style="vertical-align: top; border-right: 1px solid grey;" width="50%">
                                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                                <tr>
                                                                    <td style="padding-top: 10px;">
                                                                        <h1>
                                                                            <asp:Literal ID="litHeaderAddress" runat="server"></asp:Literal></h1>
                                                                        <hr>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <uc1:ucCtrlAddress ID="ucCtrlAddress" runat="server" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td style="vertical-align: top;" width="50%">
                                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                                <tr>
                                                                    <td style="padding-top: 10px;">
                                                                        <h1>
                                                                            <asp:Literal ID="litRateCard" runat="server" Text="Rate Cards"></asp:Literal></h1>
                                                                        <hr>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <div style="float: right; width: auto; display: inline-block;">
                                                    <asp:Button ID="btnCancel" Style="float: right; margin-left: 5px;" runat="server"
                                                        CausesValidation="false" OnClick="btnCancel_OnClick" />
                                                    <asp:Button ID="btnSave" Style="float: right; margin-left: 5px;" runat="server" ValidationGroup="IsRequire"
                                                        CausesValidation="true" OnClick="btnSave_OnClick" OnClientClick="fnDisplayCatchErrorMessage();" />
                                                    <asp:Button ID="btnBackToList" Style="float: right; margin-left: 5px;" runat="server"
                                                        CausesValidation="false" OnClick="btnBackToList_OnClick" />
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
                        <%--<uc1:MsgBox ID="MessageBox" runat="server" />--%>
                    </div>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="upnlCorporate" ID="upgrCorporate" runat="server">
    <ProgressTemplate>
        <div id="progressBackgroundFilter">
        </div>
        <div id="processMessage">
            <center>
                <img src="../../images/ajax-loader.gif" /></center>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
