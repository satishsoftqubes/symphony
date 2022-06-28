<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlAccountGroup.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.BackOffice.UIControls.AccountSetup.CtrlAccountGroup" %>
<%@ Register Src="~/MsgBox/MsgBx.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<asp:UpdatePanel ID="updAcctGroup" runat="server">
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
                                <asp:Literal ID="litMainHeading" runat="server"></asp:Literal>
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
                                            <th>
                                                <asp:Literal ID="litGroupCode" runat="server"></asp:Literal>
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtGroupCode" runat="server" MaxLength="10"></asp:TextBox>
                                            </td>
                                            <th>
                                                <asp:Literal ID="litGroupName" runat="server"></asp:Literal>
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtGroupName" runat="server" MaxLength="70"></asp:TextBox>
                                                <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                    Style="border: 0px; vertical-align: middle; margin: -4px 0 0 5px;" OnClick="btnSearch_Click" />
                                                <asp:ImageButton ID="imgbtnClearSearch" runat="server" ImageUrl="~/images/clearsearch.png"
                                                    Style="border: 0px; vertical-align: middle; margin: -2px 0 0 10px;" OnClick="imgbtnClearSearch_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <hr>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="right" valign="middle">
                                                <asp:Button ID="btnAddTopGroup" runat="server" Style="float: right;" OnClick="btnAddTopGroup_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <div class="box_head">
                                                    <span>
                                                        <asp:Literal ID="litAcctGroupList" runat="server"></asp:Literal></span></div>
                                                <div class="clear">
                                                </div>
                                                <div class="box_content">
                                                    <asp:GridView ID="gvAcctGroupList" runat="server" AutoGenerateColumns="false" Width="100%"
                                                        ShowHeader="true" OnRowDataBound="gvAcctGroupList_RowDataBound" OnRowCommand="gvAcctGroupList_RowCommand">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="No." ItemStyle-Width="25px">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="400px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Literal ID="litAcctGroupCode" runat="server"></asp:Literal>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblAcctGroupCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "GroupCode")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="400px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Literal ID="litAcctGroupName" runat="server"></asp:Literal>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblAcctGroupName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "GroupName")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="6%">
                                                                <HeaderTemplate>
                                                                    <asp:Literal ID="lblGvHdrEditView" runat="server"></asp:Literal>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "AcctGrpID")%>'
                                                                        CommandName="EDITDATA"><img src="../../images/file.png" /></asp:LinkButton>
                                                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "AcctGrpID")%>'
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
                                                <asp:Button ID="btnAddBottomGroup" runat="server" Style="float: right;" OnClick="btnAddTopGroup_Click" />
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
        <ajx:ModalPopupExtender ID="mpeAddEditAcctGroup" runat="server" TargetControlID="hfAcctGroup"
            PopupControlID="pnlAcctGroup" BackgroundCssClass="mod_background" CancelControlID="btnCancel">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hfAcctGroup" runat="server" />
        <asp:Panel ID="pnlAcctGroup" runat="server">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="ltrAcctGroupHeading" runat="server"></asp:Literal></span></div>
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
                            <td class="isrequire">
                                <asp:Literal ID="ltrGroupCode" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtGrpCode" runat="server" MaxLength="10"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rvfGroupCode" runat="server" ControlToValidate="txtGrpCode"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire"></asp:RequiredFieldValidator></span>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire">
                                <asp:Literal ID="ltrGroupName" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtGrpName" runat="server" MaxLength="70"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rvfGrpName" runat="server" ControlToValidate="txtGrpName"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire"></asp:RequiredFieldValidator></span>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire">
                                Sub Group
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlAccountGroup" runat="server" Style="width: 150px; height: 25px;" >
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
                            <td align="center" colspan="2">
                                <div style="text-align: center; vertical-align: middle;">
                                    <asp:Button ID="btnSaveAndExit" runat="server" CausesValidation="true" ValidationGroup="IsRequire"
                                        Style="display: inline;" OnClick="btnSaveAndExit_Click" />
                                    <asp:Button ID="btnSave" runat="server" CausesValidation="true" ValidationGroup="IsRequire"
                                        Style="display: inline;" OnClick="btnSave_Click" />
                                    <asp:Button ID="btnCancel" runat="server" CausesValidation="false" Style="display: inline;"
                                        OnClick="btnCancelDelete_Click" />
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
                                    OnClientClick="this.disabled = true; this.value = 'Processing...';" UseSubmitBehavior="false"
                                    OnClick="btnYes_Click" />
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
<asp:UpdateProgress AssociatedUpdatePanelID="updAcctGroup" ID="UpdateProgressAcctGroup"
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
