<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCompanyConfiguration.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.Property.CtrlCompanyConfiguration" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<asp:UpdatePanel ID="updSystemSetUp" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td align="left" valign="top">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                <asp:Literal ID="ltrSystemSetup" runat="server"></asp:Literal>
                            </td>
                            <td class="boxtopright">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="boxleft">
                                &nbsp;
                            </td>
                            <td align="left" valign="top">
                                <div class="box_form">
                                    <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                        <tr>
                                            <td>
                                                <div>
                                                    <%if (IsMessage)
                                                      { %>
                                                    <div class="message finalsuccess">
                                                        <p>
                                                            <strong>
                                                                <asp:Literal ID="ltrSuccessfully" runat="server"></asp:Literal></strong>
                                                        </p>
                                                    </div>
                                                    <%}%>
                                                </div>
                                            </td>
                                        </tr>
                                       <%-- <tr>
                                            <td>
                                                <h1>
                                                    <asp:Literal ID="ltrSMTPEmailSetup" runat="server"></asp:Literal>
                                                </h1>
                                                <hr>
                                            </td>
                                        </tr>--%>
                                       <%-- <tr>
                                            <td>
                                                <asp:Literal ID="ltrSMTPEmailDescription" runat="server"></asp:Literal>
                                                <asp:LinkButton ID="lnkbtnSMTPEmail" runat="server" OnClick="lnkbtnSMTPEmail_Click"></asp:LinkButton>
                                            </td>
                                        </tr>--%>
                                        <tr>
                                            <td>
                                                <h1>
                                                    <asp:Literal ID="ltrDefaultSetup" runat="server"></asp:Literal>
                                                </h1>
                                                <hr>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal ID="ltrDefaultSetupDescription" runat="server"></asp:Literal>
                                                <asp:LinkButton ID="lnkbtnDefaultSetup" runat="server" OnClick="lnkbtnDefaultSetup_Click"></asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h1>
                                                    <asp:Literal ID="ltrTransportationView" runat="server"></asp:Literal>
                                                </h1>
                                                <hr>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal ID="ltrTransportationViewDescription" runat="server"></asp:Literal>
                                                <asp:LinkButton ID="lnkbtnTransportationView" runat="server" OnClick="lnkbtnTransportationView_Click"></asp:LinkButton>
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
        <%--<ajx:ModalPopupExtender ID="SMTPSetup" runat="server" TargetControlID="hfSMTPSetp"
            PopupControlID="pnlSMTPSetup" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hfSMTPSetp" runat="server" />
        <asp:Panel ID="pnlSMTPSetup" runat="server" Width="800px" style="display:none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="ltrSMTPSetpHeading" runat="server"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td colspan="4">
                                <div style="float: right; padding-bottom:5px;">
                                    <b>
                                    <asp:Literal ID="litGeneralMandartoryFiledMessageForSMTP" runat="server"></asp:Literal>
                                    </b>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire">
                                <asp:Literal ID="ltrSMTPAddress" runat="server"></asp:Literal>
                            </td>
                            <td style="width: 260px;">
                                <asp:TextBox ID="txtSMTPAddress" runat="server" MaxLength="360" style="width:195px !important;"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rvfCategory" runat="server" ControlToValidate="txtSMTPAddress"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire" Display="Dynamic"></asp:RequiredFieldValidator>
                                </span>
                            </td>
                            <td class="isrequire">
                                <asp:Literal ID="ltrDNSName" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDNSName" runat="server" MaxLength="360" style="width:195px !important;"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rvfTermName" runat="server" ControlToValidate="txtDNSName"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire" Display="Dynamic"></asp:RequiredFieldValidator></span>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire">
                                <asp:Literal ID="ltrPOP3Server" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPOP3Server" runat="server" MaxLength="360" style="width:195px !important;"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rvfTermCode" runat="server" ControlToValidate="txtPOP3Server"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire" Display="Dynamic"></asp:RequiredFieldValidator></span>
                            </td>
                            <td class="isrequire">
                                <asp:Literal ID="ltrPOP3OutGoingServer" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPOP3OutGoingServer" runat="server" MaxLength="360" style="width:195px !important;"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rvfPOP3OutGoingServer" runat="server" ControlToValidate="txtPOP3OutGoingServer"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire" Display="Dynamic"></asp:RequiredFieldValidator></span>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire">
                                <asp:Literal ID="ltrUserName" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtUserName" runat="server" MaxLength="360" style="width:195px !important;"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rvfUserName" runat="server" ControlToValidate="txtUserName"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire" Display="Dynamic"></asp:RequiredFieldValidator></span>
                            </td>
                            <td class="isrequire">
                                <asp:Literal ID="ltrPassword" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPassword" runat="server" MaxLength="360" TextMode="Password" style="width:195px !important;"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rvfPassword" runat="server" ControlToValidate="txtPassword"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire" Display="Dynamic"></asp:RequiredFieldValidator></span>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire">
                                <asp:Literal ID="ltrPrimaryEmail" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPrimaryEmail" runat="server" MaxLength="360" style="width:195px !important;"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rvfPrimaryEmail" runat="server" ControlToValidate="txtPrimaryEmail"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire"
                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="refEmail" SetFocusOnError="True" ControlToValidate="txtPrimaryEmail"
                                        ValidationGroup="IsRequire" runat="server" CssClass="input-notification error png_bg"
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator></span>
                            </td>
                            <td class="isrequire">
                                <asp:Literal ID="ltrPrimaryDomain" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPrimaryDomain" runat="server" MaxLength="360" style="width:195px !important;"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rvfPrimaryDomain" runat="server" ControlToValidate="txtPrimaryDomain"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire" Display="Dynamic"></asp:RequiredFieldValidator></span>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                <table cellpadding="3" cellspacing="3" width="100%" style="margin-left: 5px; margin-top: 15px;">
                                    <tr>
                                        <td align="center" valign="middle">
                                            <asp:Button ID="btnSMTPOK" runat="server" CausesValidation="true" ValidationGroup="IsRequire"
                                                OnClick="btnSMTPOK_Click" Style="display:inline-block;" OnClientClick="fnDisplayCatchErrorMessage()" />                                       
                                            <asp:Button ID="btnSMTPCancel" runat="server" OnClick="btnSMTPCancel_Click" Style="display:inline-block;" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>--%>
        <%--Model Popup For Default Settings--%>
        <ajx:ModalPopupExtender ID="DefaultSetup" runat="server" TargetControlID="hfDefaultSetup"
            PopupControlID="pnlDefaultSetup" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hfDefaultSetup" runat="server" />
        <asp:Panel ID="pnlDefaultSetup" runat="server" Width="425px" style="display:none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="litDefaultSetupHeading" runat="server"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td colspan="2">
                                <div style="float: right; padding-bottom:5px;">
                                    <b>
                                    <asp:Literal ID="litGeneralMandartoryFiledMessageForDefaultSetup" runat="server"></asp:Literal>
                                    </b>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <h1>
                                    <table>
                                        <tr>
                                            <td style="padding-right: 12px; padding-left: 95px;">
                                                <asp:Literal ID="ltrMandatory" runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal ID="ltrOptional" runat="server"></asp:Literal>
                                            </td>
                                        </tr>
                                    </table>
                                </h1>
                                <hr>
                            </td>
                        </tr>
                        <tr>
                            <th align="left">
                                <asp:Literal ID="ltrAddress" runat="server"></asp:Literal>
                            </th>
                            <td class="readiobuttonarea">
                                <div style="float: left; padding: 0 46px 0 0px;">
                                    <asp:RadioButton ID="rbtAddressYes" runat="server" GroupName="Address" /></div>
                                <div style="float: left;">
                                    <asp:RadioButton ID="rbtAddressNo" runat="server" GroupName="Address" /></div>
                            </td>
                        </tr>
                        <tr>
                            <th align="left">
                                <asp:Literal ID="ltrPostCode" runat="server"></asp:Literal>
                            </th>
                            <td class="readiobuttonarea">
                                <div style="float: left; padding: 0 46px 0 0px;">
                                    <asp:RadioButton ID="rdoPostCodeYes" runat="server" GroupName="PostCode" /></div>
                                <div style="float: left;">
                                    <asp:RadioButton ID="rdoPostCodeNo" runat="server" GroupName="PostCode" /></div>
                            </td>
                        </tr>
                        <tr>
                            <th align="left">
                                <asp:Literal ID="ltrContactNo" runat="server"></asp:Literal>
                            </th>
                            <td class="readiobuttonarea">
                                <div style="float: left; padding: 0 46px 0 0px;">
                                    <asp:RadioButton ID="rdoContactNoYes" runat="server" GroupName="ContactNo" /></div>
                                <div style="float: left;">
                                    <asp:RadioButton ID="rdoContactNoNo" runat="server" GroupName="ContactNo" /></div>
                            </td>
                        </tr>
                        <tr>
                            <th align="left">
                                <asp:Literal ID="ltrEmail" runat="server"></asp:Literal>
                            </th>
                            <td class="readiobuttonarea">
                                <div style="float: left; padding: 0 46px 0 0px;">
                                    <asp:RadioButton ID="rdoEmailYes" runat="server" GroupName="Email" /></div>
                                <div style="float: left;">
                                    <asp:RadioButton ID="rdoEmailNo" runat="server" GroupName="Email" /></div>
                            </td>
                        </tr>
                        <tr>
                            <th align="left">
                                <asp:Literal ID="ltrGuestIdentification" runat="server"></asp:Literal>
                            </th>
                            <td class="readiobuttonarea">
                                <div style="float: left; padding: 0 46px 0 0px;">
                                    <asp:RadioButton ID="rdoGuestIdentificationYes" runat="server" GroupName="GuestIdentification" /></div>
                                <div style="float: left;">
                                    <asp:RadioButton ID="rdoGuestIdentificationNo" runat="server" GroupName="GuestIdentification" /></div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <h1>
                                    <asp:Literal ID="ltrDefaultSystemSetup" runat="server"></asp:Literal>
                                </h1>
                                <hr>
                            </td>
                        </tr>
                       <%-- <tr>
                            <td class="isrequire">
                                <asp:Literal ID="ltrDefaultCurrency" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCurrency" runat="server">
                                </asp:DropDownList>
                                <span>
                                    <asp:RequiredFieldValidator ID="rfvCurrency" InitialValue="00000000-0000-0000-0000-000000000000"
                                        SetFocusOnError="True" CssClass="input-notification error png_bg" runat="server"
                                        ValidationGroup="IsRequireFormat" ControlToValidate="ddlCurrency" Display="Dynamic"></asp:RequiredFieldValidator>
                                </span>
                            </td>
                        </tr>--%>
                        <tr>
                            <td class="isrequire">
                                <asp:Literal ID="ltrDateFormat" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlDateFormat" runat="server">
                                </asp:DropDownList>
                                <span>
                                    <asp:RequiredFieldValidator ID="rfvDateFormat" InitialValue="00000000-0000-0000-0000-000000000000"
                                        SetFocusOnError="True" CssClass="input-notification error png_bg" runat="server"
                                        ValidationGroup="IsRequireFormat" ControlToValidate="ddlDateFormat" Display="Dynamic"></asp:RequiredFieldValidator>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire">
                                <asp:Literal ID="ltrTimeForamt" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlTimeFormat" runat="server">
                                </asp:DropDownList>
                                <span>
                                    <asp:RequiredFieldValidator ID="rfvTimeFormat" InitialValue="00000000-0000-0000-0000-000000000000"
                                        SetFocusOnError="True" CssClass="input-notification error png_bg" runat="server"
                                        ValidationGroup="IsRequireFormat" ControlToValidate="ddlTimeFormat" Display="Dynamic"></asp:RequiredFieldValidator>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <table cellpadding="3" cellspacing="3" width="100%" style="margin-left: 5px; margin-top: 15px;">
                                    <tr>
                                        <td align="center" valign="middle">
                                            <asp:Button ID="btnDefaultSetupOK" runat="server" OnClick="btnDefaultSetupOK_Click" ValidationGroup="IsRequireFormat" Style="display:inline-block;" OnClientClick="fnDisplayCatchErrorMessage()" />                                        
                                            <asp:Button ID="btnDefaultSetupCancel" runat="server" OnClick="btnDefaultSetupCancel_Click" Style="display:inline-block;" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <%--Model Popup For Transportation View--%>
        <ajx:ModalPopupExtender ID="TransportationView" runat="server" TargetControlID="hfTransportationView"
            PopupControlID="pnlTransportationView" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hfTransportationView" runat="server" />
        <asp:Panel ID="pnlTransportationView" runat="server" style="display:none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="litTransportationViewHeading" runat="server"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <th align="left" style="vertical-align:top;">
                                <asp:Literal ID="ltrRoodDescription" runat="server"></asp:Literal>
                            </th>
                            <td>
                                <asp:TextBox ID="txtRoadDescription" runat="server" SkinID="nowidth" Width="400px" Height="75px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th align="left" style="vertical-align:top;">
                                <asp:Literal ID="ltrTubeDescription" runat="server"></asp:Literal>
                            </th>
                            <td>
                                <asp:TextBox ID="txtTubeDescription" runat="server" SkinID="nowidth" Width="400px" Height="75px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th align="left" style="vertical-align:top;">
                                <asp:Literal ID="ltrByAirDescription" runat="server"></asp:Literal>
                            </th>
                            <td>
                                <asp:TextBox ID="txtByAirDescription" runat="server" SkinID="nowidth" Width="400px" Height="75px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th align="left" style="vertical-align:top;">
                                <asp:Literal ID="ltrByPublicTranspertation" runat="server"></asp:Literal>
                            </th>
                            <td>
                                <asp:TextBox ID="txtByPublicTranspertation" runat="server" SkinID="nowidth" Width="400px" Height="75px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th align="left" style="vertical-align:top;">
                                <asp:Literal ID="ltrMapView" runat="server"></asp:Literal>
                            </th>
                            <td>
                                <asp:TextBox ID="txtMapView" runat="server" SkinID="nowidth" Width="400px" Height="75px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" style=" text-align:center;">
                                <table cellpadding="3" cellspacing="3" width="100%" style="margin-left: 5px; margin-top: 15px;">
                                    <tr>
                                        <td align="center" valign="middle">
                                            <asp:Button ID="btnTransOK" runat="server" OnClick="btnTransOK_Click" Style="display:inline-block;" OnClientClick="fnDisplayCatchErrorMessage()" />                                        
                                            <asp:Button ID="btnTransCancel" runat="server" OnClick="btnTransCancel_Click" Style="display:inline-block;" />
                                        </td>
                                    </tr>
                                </table>
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
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updSystemSetUp" ID="UpdateProgressSystemSetUp"
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
