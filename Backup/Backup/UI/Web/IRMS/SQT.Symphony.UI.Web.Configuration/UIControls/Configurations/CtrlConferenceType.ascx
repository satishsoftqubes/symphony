<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlConferenceType.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.Configurations.CtrlConferenceType" %>
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
<asp:UpdatePanel ID="updConferenceType" runat="server">
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
                                <asp:Literal ID="ltrMainHeader" runat="server"></asp:Literal>
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
                                            <td width="185px">
                                                <asp:Literal ID="ltrSearchConferenceTypeName" runat="server"></asp:Literal>
                                            </td>
                                            <td colspan="2">
                                                <asp:TextBox ID="txtSearchConferenceTypeName" runat="server"></asp:TextBox>
                                                <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                    Style="border: 0px; margin: -4px 0 0 5px; vertical-align: middle;" OnClick="btnSearch_Click" OnClientClick="fnDisplayCatchErrorMessage();" />
                                                <asp:ImageButton ID="imgbtnClearSearch" runat="server" ImageUrl="~/images/clearsearch.png"
                                                    Style="border: 0px; vertical-align: middle; margin: -2px 0 0 10px;" OnClick="imgbtnClearSearch_Click" OnClientClick="fnDisplayCatchErrorMessage();" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <hr>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" align="right" valign="middle">
                                                <asp:Button ID="btnAddTopConferenceType" runat="server" Style="float: right;" OnClick="btnAddTopConferenceType_Click" OnClientClick="fnDisplayCatchErrorMessage();" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <div class="box_head">
                                                    <span>
                                                        <asp:Literal ID="ltrConferenceTypeList" runat="server"></asp:Literal></span></div>
                                                <div class="clear">
                                                </div>
                                                <div class="box_content">
                                                    <asp:GridView ID="gvConferenceTypeList" runat="server" AutoGenerateColumns="false"
                                                        Width="100%" ShowHeader="true" OnPageIndexChanging="gvConferenceTypeList_PageIndexChanging"
                                                        OnRowCommand="gvConferenceTypeList_RowCommand" OnRowDataBound="gvConferenceTypeList_RowDataBound">
                                                        <Columns>
                                                            <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHrdNo" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrConferenceTypeName" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGvConferenceTypeName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ConferenceTypeName")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--<asp:TemplateField ItemStyle-Width="130px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrMaximumCapacity" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGvMaximumCapacity" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "MaximumCapacity")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                                                            <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrAction" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ConferenceTypeID")%>'
                                                                        CommandName="EDITDATA" OnClientClick="fnDisplayCatchErrorMessage();"><img src="../../images/file.png" /></asp:LinkButton>
                                                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ConferenceTypeID")%>'
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
                                            <td colspan="5" align="right" valign="middle">
                                                <asp:Button ID="btnAddBottomConferenceType" runat="server" Style="float: right;"
                                                    OnClick="btnAddTopConferenceType_Click" OnClientClick="fnDisplayCatchErrorMessage();" />
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
        <ajx:ModalPopupExtender ID="mpeAddEditConferenceType" runat="server" TargetControlID="hfMessage"
            PopupControlID="pnlAddEditConferenceType" BackgroundCssClass="mod_background"
            CancelControlID="btnCancel">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hfMessage" runat="server" />
        <asp:Panel ID="pnlAddEditConferenceType" runat="server" Width="430px" style="display:none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="ltrHeaderPopupConferenceType" runat="server"></asp:Literal></span></div>
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
                            <td colspan="2">
                                <div style="float: right; padding-bottom:5px;">
                                    <b>
                                    <asp:Literal ID="litGeneralMandartoryFiledMessage" runat="server"></asp:Literal>
                                    </b>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td width="185px" class="isrequire" valign="top">
                                <asp:Literal ID="ltrConferenceTypeName" runat="server"></asp:Literal>
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="txtConferenceTypeName" runat="server" MaxLength="120"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rvfConferenceTypeName" runat="server" ControlToValidate="txtConferenceTypeName"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire"></asp:RequiredFieldValidator>
                                </span>
                            </td>
                        </tr>
                        <%--<tr>
                            <td class="isrequire">
                                <asp:Literal ID="ltrMaximumCapacity" runat="server"></asp:Literal>
                            </th>
                            <td>
                                <asp:TextBox ID="txtMaximumCapacity" runat="server" SkinID="nowidth" Width="80px" MaxLength="8" style="text-align:right;"></asp:TextBox>
                                <ajx:FilteredTextBoxExtender ID="ftMaximumCapacity" runat="server" TargetControlID="txtMaximumCapacity"
                                    FilterType="Numbers" />
                                <span>
                                    <asp:RequiredFieldValidator ID="rvfMaximumCapacity" runat="server" ControlToValidate="txtMaximumCapacity"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire"></asp:RequiredFieldValidator>
                                </span>
                            </td>
                        </tr>--%>
                        <tr>
                            <td align="center" colspan="2">
                                <table cellpadding="3" cellspacing="3" style="margin-left: 5px; margin-top: 15px;">
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnSaveAndClose" runat="server" CausesValidation="true" ValidationGroup="IsRequire"
                                                OnClick="btnSaveAndClose_Click" OnClientClick="fnDisplayCatchErrorMessage();" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnSave" runat="server" CausesValidation="true" ValidationGroup="IsRequire"
                                                OnClick="btnSave_Click" OnClientClick="fnDisplayCatchErrorMessage();" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnCancel" runat="server" CausesValidation="false" />
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
            PopupControlID="pnlDeleteData" BackgroundCssClass="mod_background" CancelControlID="btnCancelDelete" BehaviorID="mpeConfirmDelete">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnConfirmDelete" runat="server" />
        <asp:Panel ID="pnlDeleteData" runat="server" Height="350px" Width="325px" style="display:none;">
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
    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updConferenceType" ID="UpdateProgressConferenceType"
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
