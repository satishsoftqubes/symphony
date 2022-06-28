<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlGuestType.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.Configurations.CtrlGuestType" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript" language="javascript">
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
<asp:UpdatePanel ID="upnlGuestType" runat="server">
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
                                <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="left">
                                            <div class="box_form">
                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td>
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
                                                            <asp:MultiView ID="mvGuestyType" runat="server">
                                                                <asp:View ID="vGuestTypeList" runat="server">
                                                                    <table width="100%" border="0" cellpadding="2" cellspacing="2">
                                                                        <tr>
                                                                            <td width="100px">
                                                                                <asp:Literal ID="litSearchType" runat="server" Text="Guest Type"></asp:Literal>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtSearchType" runat="server"></asp:TextBox>
                                                                                <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                                                    Style="border: 0px; margin-left: 5px; vertical-align: middle;" OnClick="btnSearch_Click"
                                                                                    OnClientClick="fnDisplayCatchErrorMessage();" />
                                                                                <asp:ImageButton ID="imgbtnClearSearch" runat="server" ImageUrl="~/images/clearsearch.png"
                                                                                    Style="border: 0px; vertical-align: middle; margin: 0 0 0 10px;" OnClick="imgbtnClearSearch_Click"
                                                                                    OnClientClick="fnDisplayCatchErrorMessage();" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                <hr>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" align="right">
                                                                                <asp:Button ID="btnAddTopGuestyType" OnClick="btnAddBottomGuestyType_OnClick" runat="server"
                                                                                    Style="float: right;" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" class="content_checkbox">
                                                                                <div class="box_head">
                                                                                    <span>
                                                                                        <asp:Literal ID="litGuestyTypeList" runat="server"></asp:Literal>
                                                                                    </span>
                                                                                </div>
                                                                                <div class="clear">
                                                                                </div>
                                                                                <div class="box_content">
                                                                                    <asp:GridView ID="gvGuestyTypeList" runat="server" OnRowCommand="gvRoomList_RowCommand"
                                                                                        OnRowDataBound="gvRoomList_RowDataBound" OnPageIndexChanging="gvRoomList_PageIndexChanging"
                                                                                        AutoGenerateColumns="False" Width="100%">
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
                                                                                                    <asp:Label ID="lblGvHdrGuestType" runat="server"></asp:Label>
                                                                                                </HeaderTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblGvGuestyType" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Term")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                <HeaderTemplate>
                                                                                                    <asp:Label ID="lblGvHdrAction" runat="server"></asp:Label>
                                                                                                </HeaderTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "TermID")%>'
                                                                                                        CommandName="EDITDATA" OnClientClick="fnDisplayCatchErrorMessage();"><img src="../../images/file.png"/></asp:LinkButton>
                                                                                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "TermID")%>'
                                                                                                        CommandName="DELETEDATA"><img src="../../images/delete.png" alt="" /></asp:LinkButton>
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
                                                                            <td colspan="2" align="right" valign="middle">
                                                                                <asp:Button ID="btnAddBottomGuestyType" OnClick="btnAddBottomGuestyType_OnClick"
                                                                                    runat="server" Style="float: right;" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </asp:View>
                                                                <asp:View ID="vGuestTypeAdd" runat="server">
                                                                    <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                                        <tr>
                                                                            <td style="width: 90px;" class="isrequire">
                                                                                <asp:Literal ID="litType" Text="Type" runat="server"></asp:Literal>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox runat="server" ID="txtType"></asp:TextBox>
                                                                                <span>
                                                                                    <asp:RequiredFieldValidator ID="rvfType" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                                        runat="server" ValidationGroup="IsRequire" ControlToValidate="txtType" Display="Dynamic"></asp:RequiredFieldValidator></span>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="vertical-align: top">
                                                                                <asp:Literal ID="litDescription" Text="Description" runat="server"></asp:Literal>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox runat="server" TextMode="MultiLine" SkinID="nowidth" Width="350px" Rows="5" ID="txtDescription"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                <div style="float: right; width: auto; display: inline-block;">
                                                                                    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_OnClick" ImageUrl="~/images/cancle.png"
                                                                                        Style="float: right; margin-left: 5px;" />
                                                                                    <asp:Button ID="btnSave" ValidationGroup="IsRequire" OnClick="btnSave_OnClick" runat="server"
                                                                                        ImageUrl="~/images/save.png" Style="float: right; margin-left: 5px;" OnClientClick="fnDisplayCatchErrorMessage();" />
                                                                                </div>
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
                                    </tr>
                                </table>
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
                                <asp:Button ID="btnYes" OnClick="btnYes_Click" runat="server" Style="display: inline;
                                    padding-right: 10px;" OnClientClick="fnDisplayCatchErrorMessage();" />
                                <asp:Button ID="btnNo" runat="server" Style="display: inline;" />
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
