<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlGuestPreferenceSetup.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.Configurations.CtrlGuestPreferenceSetup" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript">

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
<asp:UpdatePanel ID="updPreference" runat="server">
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
                                    <table border="0" width="100%" cellpadding="0" cellspacing="0">
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
                                            <td>
                                                <asp:MultiView ID="mvPreference" runat="server">
                                                    <asp:View ID="vPreferenceList" runat="server">
                                                        <table border="0" width="100%" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td width="100px">
                                                                    <asp:Literal ID="litSearchPreference" runat="server"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtSearchPreference" runat="server"></asp:TextBox>
                                                                    <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                                        Style="border: 0px; margin-left: 5px; vertical-align: middle;" OnClick="btnSearch_Click"
                                                                        OnClientClick="fnDisplayCatchErrorMessage();" />
                                                                    <asp:ImageButton ID="imgbtnClearSearch" runat="server" ImageUrl="~/images/clearsearch.png"
                                                                        Style="border: 0px; vertical-align: middle; margin: 0 0 0 10px;" OnClick="imgbtnClearSearch_Click"
                                                                        OnClientClick="fnDisplayCatchErrorMessage();" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" align="right" style="padding: 5px;">
                                                                    <asp:Button ID="btnTopAdd" runat="server" Style="display: inline;" OnClick="btnTopAdd_OnClick" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <div class="box_head">
                                                                        <span>
                                                                            <asp:Literal ID="litPreferenceList" runat="server"></asp:Literal>
                                                                        </span>
                                                                    </div>
                                                                    <div class="clear">
                                                                    </div>
                                                                    <div class="box_content">
                                                                        <asp:GridView ID="gvPreference" OnRowDataBound="gvPreference_RowDataBound" OnRowCommand="gvPreference_RowCommand"
                                                                            OnPageIndexChanging="gvPreference_PageIndexChanging" runat="server" AutoGenerateColumns="false"
                                                                            ShowHeader="true" Width="100%">
                                                                            <Columns>
                                                                                <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrSrNo" runat="server"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%# Container.DataItemIndex + 1 %>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrPreference" runat="server"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%#DataBinder.Eval(Container.DataItem, "PreferenceName")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrAction" runat="server"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "PreferenceID")%>'
                                                                                            CommandName="EDITDATA"><img src="../../images/file.png" /></asp:LinkButton>
                                                                                        <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "PreferenceID")%>'
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
                                                                <td colspan="2" align="right" style="padding: 5px;">
                                                                    <asp:Button ID="btnBottumAdd" runat="server" Text="Add" Style="display: inline;"
                                                                        OnClick="btnTopAdd_OnClick" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:View>
                                                    <asp:View ID="vPreferenceAdd" runat="server">
                                                        <table border="0" width="100%" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td class="isrequire">
                                                                    <asp:Literal ID="litPreference" runat="server"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtPreference" runat="server"></asp:TextBox>
                                                                    <span>
                                                                        <asp:RequiredFieldValidator ID="rvfPreference" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                            runat="server" ValidationGroup="IsRequire" ControlToValidate="txtPreference"
                                                                            Display="Dynamic">
                                                                        </asp:RequiredFieldValidator>
                                                                    </span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litPreferenceDetail" runat="server"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox runat="server" ID="txtPreferenceDetail" TextMode="MultiLine"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" align="right" style="padding: 5px;">
                                                                    <asp:Button ID="btnSave" runat="server" ValidationGroup="IsRequire" Style="display: inline;"
                                                                        OnClick="btnSave_OnClick" />
                                                                    <asp:Button ID="btnCancel" runat="server" Style="display: inline;" OnClick="btnCancel_OnClick" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:View>
                                                </asp:MultiView>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                            <td class="boxright">
                            </td>
                        </tr>
                        <tr>
                            <td class="boxbottomleft">
                            </td>
                            <td class="boxbottomcenter">
                            </td>
                            <td class="boxbottomright">
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
        <ajx:ModalPopupExtender ID="mpeConfirmDelete" runat="server" TargetControlID="hdnConfirmDelete"
            PopupControlID="pnlDeleteData" BackgroundCssClass="mod_background" CancelControlID="btnCancelDelete"
            BehaviorID="mpeConfirmDelete">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnConfirmDelete" runat="server" />
        <asp:Panel ID="pnlDeleteData" runat="server" Height="350px" Width="325px" Style="display: none;">
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
                                    OnClick="btnYes_Click" OnClientClick="fnDisplayCatchErrorMessage();" />
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
<asp:UpdateProgress AssociatedUpdatePanelID="updPreference" ID="UpdateProgressPreference"
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
