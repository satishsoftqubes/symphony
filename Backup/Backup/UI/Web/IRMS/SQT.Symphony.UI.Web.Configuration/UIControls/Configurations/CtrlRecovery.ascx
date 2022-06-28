<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlRecovery.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.Configurations.CtrlRecovery" %>
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
<asp:UpdatePanel ID="updRecovery" runat="server">
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
                                <asp:Literal ID="litMainHeaderRecovery" runat="server"></asp:Literal>
                            </td>
                            <td class="boxtopright">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="boxleft">
                            </td>
                            <td align="left">
                                <div class="box_form">
                                    <asp:MultiView ID="mvRecovery" runat="server">
                                        <asp:View ID="vRecoveryList" runat="server">
                                            <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                <tr>
                                                    <td colspan="6">
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
                                                    <td width="70">
                                                        <asp:Literal ID="litSearchTitle" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox Style="width: 130px;" ID="txtSearchTitle" runat="server"></asp:TextBox>
                                                        <asp:ImageButton ID="btnSearch" OnClick="btnSearch_Click" runat="server" ImageUrl="~/images/search-icon.png"
                                                            Style="border: 0px; margin: 2px 0 0 5px; vertical-align: middle;" />
                                                        <asp:ImageButton ID="imgbtnClearSearch" OnClick="imgbtnClearSearch_Click" runat="server"
                                                            ImageUrl="~/images/clearsearch.png" Style="border: 0px; vertical-align: middle;
                                                            margin: 2px 0 0 10px;" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <hr />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:Button ID="btnTopAdd" runat="server" Style="float: right;" OnClick="btnTopAdd_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="padding-bottom: 15px;">
                                                        <div class="box_head">
                                                            <span>
                                                                <asp:Literal ID="litRecovery" runat="server" Text="Recovery List"></asp:Literal>
                                                            </span>
                                                        </div>
                                                        <div class="clear">
                                                        </div>
                                                        <div class="box_content">
                                                            <asp:GridView ID="gvRecoveryList" OnRowDataBound="gvRecovery_RowDataBound" OnRowCommand="gvRecovery_RowCommand"
                                                                OnPageIndexChanging="gvRecovery_PageIndexChanging" runat="server" AutoGenerateColumns="false"
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
                                                                            <asp:Label ID="lblGvHdrTitle" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "Title")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrAmount" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "Amount")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <%-- <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrDescription" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "Description")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>--%>
                                                                    <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrAction" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "RecoveryID")%>'
                                                                                CommandName="EDITDATA" OnClientClick="fnDisplayCatchErrorMessage();"><img src="../../images/file.png" /></asp:LinkButton>
                                                                            <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "RecoveryID")%>'
                                                                                CommandName="DELETEDATA"><img src="../../images/delete.png" /></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <div style="padding: 10px;">
                                                                        <b>
                                                                            <asp:Label ID="lblNoRecordFound" Text="Data Not Found" runat="server"></asp:Label>
                                                                        </b>
                                                                    </div>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:Button ID="btnButtomAdd" OnClick="btnTopAdd_Click" runat="server" Style="float: right;" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                        <asp:View ID="vDescriptionAdd" runat="server">
                                            <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                <tr>
                                                    <td style="width: 130px;" class="isrequire">
                                                        <asp:Literal ID="litTitle" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtTitle" Style="float: left;"></asp:TextBox>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rfvTitle" SetFocusOnError="True" CssClass="input-notification error png_bg"
                                                                runat="server" ValidationGroup="IsRequireRecovery" ControlToValidate="txtTitle"
                                                                Display="Static"></asp:RequiredFieldValidator></span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 130px;" class="isrequire">
                                                        <asp:Literal ID="litCategory" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList runat="server" ID="ddlCategory" Style="width: 130px;">
                                                            <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rvfLabelName" runat="server" ControlToValidate="ddlCategory"
                                                                SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequireRecovery"
                                                                InitialValue="00000000-0000-0000-0000-000000000000"></asp:RequiredFieldValidator></span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 130px;" class="isrequire">
                                                        <asp:Literal ID="litAccount" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList runat="server" ID="ddlAccSelection" Style="width: 185px;">
                                                            <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rfvAccsel" runat="server" ControlToValidate="ddlAccSelection"
                                                                SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequireRecovery"
                                                                InitialValue="00000000-0000-0000-0000-000000000000"></asp:RequiredFieldValidator></span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="isrequire">
                                                        <asp:Literal ID="litAmount" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtAmount" MaxLength="15" runat="server" Style="width: 75px !important;
                                                            text-align: right;"></asp:TextBox>
                                                        <ajx:FilteredTextBoxExtender ID="fteAmount" runat="server" FilterType="Custom, Numbers"
                                                            ValidChars="." TargetControlID="txtAmount">
                                                        </ajx:FilteredTextBoxExtender>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rfvAmount" SetFocusOnError="True" CssClass="input-notification error png_bg"
                                                                runat="server" ValidationGroup="IsRequireRecovery" ControlToValidate="txtAmount"
                                                                Display="Static"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator Display="Dynamic" ID="revAmount" runat="server" ForeColor="Red"
                                                                ControlToValidate="txtAmount" SetFocusOnError="true" ValidationGroup="IsRequireRecovery">
                                                            </asp:RegularExpressionValidator>
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: top;">
                                                        <asp:Literal ID="litDescription" Visible="false" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtDescription" Visible="false" Style="width: 227px; height: 100px;"
                                                            runat="server" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <div style="float: right; width: auto; display: inline-block;">
                                                            <asp:Button ID="btnCancel" runat="server" CausesValidation="false" ImageUrl="~/images/cancle.png"
                                                                Style="float: right; margin-left: 5px;" OnClick="btnCancel_OnClick" />
                                                            <asp:Button ID="btnSave" ValidationGroup="IsRequireRecovery" OnClick="btnSave_Click"
                                                                runat="server" ImageUrl="~/images/save.png" Style="float: right; margin-left: 5px;" />
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                    </asp:MultiView>
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
        <ajx:ModalPopupExtender ID="mpeConfirmDelete" runat="server" TargetControlID="hdnConfirmDelete"
            PopupControlID="pnlDeleteData" BackgroundCssClass="mod_background" CancelControlID="btnNo"
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
                                <asp:Button ID="btnYes" runat="server" OnClick="btnYes_Click" Style="display: inline;
                                    padding-right: 10px;" OnClientClick="fnDisplayCatchErrorMessage();" />
                                <asp:Button ID="btnNo" OnClick="btnNo_Click" runat="server" Style="display: inline;" />
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
