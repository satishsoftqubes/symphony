<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlEmailConfiguration.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.Configurations.CtrlEmailConfiguration" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">
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
<asp:UpdatePanel ID="updtEmailConfiguration" runat="server">
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
                                <asp:Literal ID="ltrMainHeading" runat="server"></asp:Literal>
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
                                    <table cellpadding="2" cellspacing="2" width="100%">
                                        <tr>
                                            <td colspan="4">
                                                <%if (IsListMessage)
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
                                            <td colspan="2">
                                                <h1 style="color:Black;">
                                                    <asp:Literal ID="ltrSMTPEmailSetup" runat="server"></asp:Literal> - <asp:LinkButton ID="lnkbtnSMTPEmail"  runat="server" OnClick="lnkbtnSMTPEmail_Click"></asp:LinkButton>
                                                </h1>
                                                <asp:Literal ID="ltrSMTPEmailDescription"  runat="server"></asp:Literal>
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <h1>
                                                </h1>
                                                <hr>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="130px">
                                                <asp:Literal ID="ltrPrimaryDomainName" runat="server"></asp:Literal>
                                            </td>
                                            <td style="width: 270px">
                                                <asp:TextBox ID="txtPrimaryDomainName" runat="server" MaxLength="35"></asp:TextBox>
                                            </td>
                                            <th>
                                                <asp:Literal ID="ltrSPrimaryEmail" runat="server"></asp:Literal>
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtSPrimaryEmail" runat="server"></asp:TextBox>
                                                <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png" OnClientClick="fnDisplayCatchErrorMessage();"
                                                    Style="border: 0px; margin: -4px 0 0 5px; vertical-align: middle;" OnClick="btnSearch_Click" />
                                                <asp:ImageButton ID="imgbtnClearSearch" runat="server" ImageUrl="~/images/clearsearch.png"
                                                    Style="border: 0px; vertical-align: middle; margin: -2px 0 0 10px;" OnClick="imgbtnClearSearch_Click" />
                                            </td>
                                        </tr>
                                        <%--<tr>
                                            <td colspan="4">
                                                <h1>
                                                </h1>
                                                <hr>
                                            </td>
                                        </tr>--%>
                                        <tr>
                                            <td colspan="2">
                                            </td>
                                            <td colspan="2" align="right" valign="middle">
                                                <asp:Button ID="btnAddTopEmailConfig" runat="server" Style="float: right;" OnClick="btnAddTopEmailConfig_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <div class="box_head">
                                                    <span>
                                                        <asp:Literal ID="ltrEmailConfigList" runat="server"></asp:Literal></span></div>
                                                <div class="clear">
                                                </div>
                                                <div class="box_content">
                                                    <asp:GridView ID="gvEmailConfigList" runat="server" AutoGenerateColumns="false" Width="100%"
                                                        ShowHeader="true" OnRowCommand="gvEmailConfigList_RowCommand" OnRowDataBound="gvEmailConfigList_RowDataBound">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="No." ItemStyle-Width="25px">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="250px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Literal ID="ltrGvHdrPrimaryDomain" runat="server"></asp:Literal>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblgvPrimaryDomain" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "PrimoryDomainName")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Literal ID="ltrGvHdrPrimaryEmail" runat="server"></asp:Literal>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblgvPrimaryEmail" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "PrimoryEmail")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="250px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Literal ID="ltrGvHdrSMTPHost" runat="server"></asp:Literal>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblSMTPHost" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "SMTPHost")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="50px">
                                                                <HeaderTemplate>
                                                                    <asp:Literal ID="lblGvHdrEditView" runat="server"></asp:Literal>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "EmailConfigID")%>'
                                                                        CommandName="EDITDATA" OnClientClick="fnDisplayCatchErrorMessage();"><img src="../../images/file.png" /></asp:LinkButton>
                                                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "EmailConfigID")%>'
                                                                        CommandName="DELETEDATA"><img src="../../images/delete.png" /></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <EmptyDataTemplate>
                                                            <div style="padding: 10px;">
                                                                <b>
                                                                    <asp:Label ID="lblNoRecordFound" runat="server"></asp:Label>
                                                                </b>
                                                            </div>
                                                        </EmptyDataTemplate>
                                                    </asp:GridView>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="right" valign="middle">
                                                <asp:Button ID="btnAddBottomEmailConfig" runat="server" Style="float: right;" OnClick="btnAddTopEmailConfig_Click" />
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
                </td>
            </tr>
        </table>
        <ajx:ModalPopupExtender ID="mpeEmailConfiguration" runat="server" TargetControlID="hfCurrencyDate"
            PopupControlID="pnlCurrencyDate" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hfCurrencyDate" runat="server" />
        <asp:Panel ID="pnlCurrencyDate" runat="server" Width="800px" style="display: none;">
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
                                <%if (IsPopupMessage)
                                  { %>
                                <div class="message finalsuccess">
                                    <p>
                                        <strong>
                                            <asp:Literal ID="ltrMsgPopup" runat="server"></asp:Literal></strong>
                                    </p>
                                </div>
                                <%}%>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <div style="float: right; padding-bottom:5px;">
                                    <b>
                                    <asp:Literal ID="litGeneralMandartoryFiledMessage" runat="server"></asp:Literal>
                                    </b>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire">
                                <asp:Literal ID="ltrPrimaryEmail" runat="server"></asp:Literal>
                            </td>
                            <td style="width: 260px;">
                                <asp:TextBox ID="txtPrimaryEmail" runat="server" Style="width: 195px !important;"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rvfPrimaryEmail" runat="server" ControlToValidate="txtPrimaryEmail"
                                        Display="Dynamic" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                        ValidationGroup="IsRequire"></asp:RequiredFieldValidator></span> <span>
                                            <asp:RegularExpressionValidator ID="regEmail" ValidationGroup="IsRequire" runat="server"
                                                Display="Dynamic" CssClass="input-notification error png_bg" ControlToValidate="txtPrimaryEmail"
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></span>
                            </td>
                            <td class="isrequire">
                                <asp:Literal ID="ltrPrimaryDomain" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPrimaryDomain" runat="server" MaxLength="150" Style="width: 195px !important;"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rvfPrimaryDomain" runat="server" ControlToValidate="txtPrimaryDomain"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire"
                                        Display="Dynamic"></asp:RequiredFieldValidator></span>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire">
                                <asp:Literal ID="ltrSMTPAddress" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSMTPAddress" runat="server" Style="width: 195px !important;"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rvfCategory" runat="server" ControlToValidate="txtSMTPAddress"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire"
                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                </span>
                            </td>
                            <td class="isrequire">
                                <asp:Literal ID="ltrSMTPPOT" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSMTPPOT" runat="server" MaxLength="137" Style="width: 195px !important;"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rvfTermName" runat="server" ControlToValidate="txtSMTPPOT"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire"
                                        Display="Dynamic"></asp:RequiredFieldValidator></span>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire">
                                <asp:Literal ID="ltrPOP3Server" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPOP3Server" runat="server" Style="width: 195px !important;"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rvfTermCode" runat="server" ControlToValidate="txtPOP3Server"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire"
                                        Display="Dynamic"></asp:RequiredFieldValidator></span>
                            </td>
                            <td class="isrequire">
                                <asp:Literal ID="ltrPOP3OutGoingServer" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPOP3OutGoingServer" runat="server" MaxLength="15" Style="width: 195px !important;"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rvfPOP3OutGoingServer" runat="server" ControlToValidate="txtPOP3OutGoingServer"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire"
                                        Display="Dynamic"></asp:RequiredFieldValidator></span>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire">
                                <asp:Literal ID="ltrUserName" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtUserName" runat="server" Style="width: 195px !important;"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rvfUserName" runat="server" ControlToValidate="txtUserName"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire"
                                        Display="Dynamic"></asp:RequiredFieldValidator></span>
                            </td>
                            <td class="isrequire">
                                <asp:Literal ID="ltrPassword" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPassword" runat="server" MaxLength="15" TextMode="Password" Style="width: 195px !important;"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rvfPassword" runat="server" ControlToValidate="txtPassword"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire"
                                        Display="Dynamic"></asp:RequiredFieldValidator></span>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                <div>
                                    <asp:Button ID="btnSaveAndExit" runat="server" CausesValidation="true" ValidationGroup="IsRequire"
                                        OnClick="btnSaveAndExit_Click" Style="display: inline;" OnClientClick="fnDisplayCatchErrorMessage();" />
                                    <asp:Button ID="btnSave" runat="server" CausesValidation="true" ValidationGroup="IsRequire"
                                        OnClick="btnSave_Click" Style="display: inline;" OnClientClick="fnDisplayCatchErrorMessage();" />
                                    <asp:Button ID="btnCancel" runat="server" OnClientClick="fnDisplayCatchErrorMessage();" CausesValidation="false" Style="display: inline;" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpeConfirmDelete" runat="server" TargetControlID="hdnConfirmDelete"
            PopupControlID="pnlDeleteData" BackgroundCssClass="mod_background" 
            CancelControlID="btnCancelDelete" BehaviorID="mpeConfirmDelete">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnConfirmDelete" runat="server" />
        <asp:Panel ID="pnlDeleteData" runat="server" Height="350px" Width="325px" style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="ltrHeaderConfirmDeletePopup" runat="server"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td align="center" style="padding-bottom: 15px;">
                                <asp:Literal ID="ltrConfirmDeleteMsg" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnYes" runat="server" Style="display: inline; padding-right: 10px;"
                                    OnClientClick="fnDisplayCatchErrorMessage();" OnClick="btnYes_Click" />
                                <asp:Button ID="btnCancelDelete" runat="server" Style="display: inline;" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>




        <ajx:ModalPopupExtender ID="SMTPSetup" runat="server" TargetControlID="hfSMTPSetp"
            PopupControlID="pnlSMTPSetup" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hfSMTPSetp" runat="server" />
        <asp:Panel ID="pnlSMTPSetup" runat="server" Width="800px" style="display:none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="ltrSysSMTPSetpHeading" runat="server"></asp:Literal></span></div>
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
                                <asp:Literal ID="ltrSysSMTPAddress" runat="server"></asp:Literal>
                            </td>
                            <td style="width: 260px;">
                                <asp:TextBox ID="txtSysSMTPAddress" runat="server" MaxLength="360" style="width:195px !important;"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSysSMTPAddress"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequirepopup" Display="Dynamic"></asp:RequiredFieldValidator>
                                </span>
                            </td>
                            <td class="isrequire">
                                <asp:Literal ID="ltrSysDNSName" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSysDNSName" runat="server" MaxLength="360" style="width:195px !important;"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSysDNSName"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequirepopup" Display="Dynamic"></asp:RequiredFieldValidator></span>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire">
                                <asp:Literal ID="ltrSysPOP3Server" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSysPOP3Server" runat="server" MaxLength="360" style="width:195px !important;"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSysPOP3Server"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequirepopup" Display="Dynamic"></asp:RequiredFieldValidator></span>
                            </td>
                            <td class="isrequire">
                                <asp:Literal ID="ltrSysPOP3OutGoingServer" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSysPOP3OutGoingServer" runat="server" MaxLength="360" style="width:195px !important;"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtSysPOP3OutGoingServer"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequirepopup" Display="Dynamic"></asp:RequiredFieldValidator></span>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire">
                                <asp:Literal ID="ltrSysUserName" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSysUserName" runat="server" MaxLength="360" style="width:195px !important;"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtSysUserName"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequirepopup" Display="Dynamic"></asp:RequiredFieldValidator></span>
                            </td>
                            <td class="isrequire">
                                <asp:Literal ID="ltrSysPassword" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSysPassword" runat="server" MaxLength="360" TextMode="Password" style="width:195px !important;"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtSysPassword"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequirepopup" Display="Dynamic"></asp:RequiredFieldValidator></span>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire">
                                <asp:Literal ID="ltrSysPrimaryEmail" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSysPrimaryEmail" runat="server" MaxLength="360" style="width:195px !important;"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtSysPrimaryEmail"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequirepopup"
                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="refEmail" SetFocusOnError="True" ControlToValidate="txtSysPrimaryEmail"
                                        ValidationGroup="IsRequirepopup" runat="server" CssClass="input-notification error png_bg"
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator></span>
                            </td>
                            <td class="isrequire">
                                <asp:Literal ID="ltrSysPrimaryDomain" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSysPrimaryDomain" runat="server" MaxLength="360" style="width:195px !important;"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtSysPrimaryDomain"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequirepopup" Display="Dynamic"></asp:RequiredFieldValidator></span>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                <table cellpadding="3" cellspacing="3" width="100%" style="margin-left: 5px; margin-top: 15px;">
                                    <tr>
                                        <td align="center" valign="middle">
                                           <%-- <asp:Button ID="btnSMTPOK" runat="server" CausesValidation="true" ValidationGroup="IsRequire"
                                                OnClick="btnSMTPOK_Click" Style="display:inline-block;" OnClientClick="fnDisplayCatchErrorMessage()" />--%>
                                                <asp:Button ID="btnSMTPOK" runat="server" CausesValidation="true" ValidationGroup="Isrequirepopup" OnClick="btnSMTPOK_Click" Style="display:inline-block;" OnClientClick="fnDisplayCatchErrorMessage()" />
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
        </asp:Panel>






    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updtEmailConfiguration" ID="UpdateProgressEmailConfiguration"
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
