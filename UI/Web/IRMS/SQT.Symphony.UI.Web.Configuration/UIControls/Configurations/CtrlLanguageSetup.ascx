<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlLanguageSetup.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.Configurations.CtrlLanguageSetup" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<asp:UpdatePanel ID="upnlLanguageSetup" runat="server">
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
                            <td align="left">
                                <div class="box_form">
                                    <table cellpadding="2" cellspacing="2" width="100%">
                                        <tr>
                                            <td colspan="3">
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
                                            <th>
                                                <asp:Literal ID="litSearchLanguageName" runat="server"></asp:Literal>
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtSLanguageName" runat="server"></asp:TextBox>
                                                <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                    Style="border: 0px; vertical-align: middle; margin: -1px 0 0 5px;" OnClick="btnSearch_Click" />
                                                <asp:ImageButton ID="imgbtnClearSearch" runat="server" ImageUrl="~/images/clearsearch.png"
                                                    Style="border: 0px; vertical-align: middle; margin: 0 0 0 10px;" OnClick="imgbtnClearSearch_Click" />
                                            </td>
                                            <td align="left">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <hr>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" align="right" valign="middle">
                                                <asp:Button ID="btnAddTopLanguageSetup" runat="server" Style="float: right;" OnClick="btnAddTopLanguageSetup_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <div class="box_head">
                                                    <span>
                                                        <asp:Literal ID="litLanguageSetupList" runat="server"></asp:Literal></span></div>
                                                <div class="clear">
                                                </div>
                                                <div class="box_content">
                                                    <asp:GridView ID="gvLanguageSetupList" runat="server" AutoGenerateColumns="false"
                                                        Width="100%" ShowHeader="true" OnRowDataBound="gvLanguageSetupList_RowDataBound"
                                                        OnPageIndexChanging="gvLanguageSetupList_PageIndexChanging" OnRowCommand="gvLanguageSetupList_RowCommand">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="No." ItemStyle-Width="35px">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrLanguageName" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblLanguageName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Name")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrLanguageCalture" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblLanguageCalture" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "LanguageCulture")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                                ItemStyle-Width="50px">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrEditView" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "LanguageID")%>'
                                                                        CommandName="EDITDATA"><img src="../../images/file.png" alt="" /></asp:LinkButton>
                                                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "LanguageID")%>'
                                                                        CommandName="DELETEDATA"><img src="../../images/delete.png"  alt=""/></asp:LinkButton>
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
                                            <td colspan="5" align="right" valign="middle">
                                                <asp:Button ID="btnAddBottomLanguageSetup" runat="server" Style="float: right;" OnClick="btnAddTopLanguageSetup_Click" />
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
                        <uc1:MsgBox ID="MessageBox" runat="server" />
                    </div>
                </td>
            </tr>
        </table>
        <ajx:ModalPopupExtender ID="mpeAddEditLanguageSetup" runat="server" TargetControlID="hfMessage"
            PopupControlID="pnlAddEditLanguageSetup" BackgroundCssClass="mod_background"
            CancelControlID="btnCancel">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hfMessage" runat="server" />
        <asp:Panel ID="pnlAddEditLanguageSetup" runat="server">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="litHeaderPopupLanguageSetup" runat="server"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td colspan="2">
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
                            <td class="isrequire" align="left" valign="top">
                                <asp:Literal ID="litLanguageName" runat="server"></asp:Literal>
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="txtLanguageName" runat="server"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rvfLanguageName" runat="server" ControlToValidate="txtLanguageName"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire"></asp:RequiredFieldValidator>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire">
                                <asp:Literal ID="litLanguageCalture" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtLanguageCalture" runat="server"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rvfLanguageCalture" runat="server" ControlToValidate="txtLanguageCalture"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire"></asp:RequiredFieldValidator>
                                </span>
                            </td>
                        </tr>
                        <%--<tr>
                            <th>
                                <asp:Literal ID="litCountry" runat="server"></asp:Literal>
                            </th>
                            <td>
                                <asp:DropDownList ID="ddlCountry" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>--%>
                        <tr>
                            <td align="center" colspan="2">
                                <table cellpadding="3" cellspacing="3" style="margin-left: 5px; margin-top: 15px;">
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnSaveAndClose" runat="server" CausesValidation="true" ValidationGroup="IsRequire"
                                                OnClick="btnSaveAndClose_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnSave" runat="server" CausesValidation="true" ValidationGroup="IsRequire"
                                                OnClick="btnSave_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnCancel" runat="server" CausesValidation="false" OnClick="btnCancel_Click" />
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
        <ajx:ModalPopupExtender ID="mpeConfirmDelete" runat="server" TargetControlID="hdnConfirmDelete"
            PopupControlID="pnlDeleteData" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnConfirmDelete" runat="server" />
        <asp:Panel ID="pnlDeleteData" runat="server" Height="350px" Width="325px">
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
                                    OnClientClick="this.disabled = true; this.value = 'Processing...';" UseSubmitBehavior="false" OnClick="btnYes_Click" />
                                <asp:Button ID="btnCancelDelete" runat="server" Style="display: inline;" OnClick="btnCancelDelete_Click" />
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
<asp:UpdateProgress AssociatedUpdatePanelID="upnlLanguageSetup" ID="UpdateProgressLanguageSetup"
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