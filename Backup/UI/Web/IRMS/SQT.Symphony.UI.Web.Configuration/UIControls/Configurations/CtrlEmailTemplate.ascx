<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlEmailTemplate.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.Configurations.CtrlEmailTemplate" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:UpdatePanel ID="updSystemSetUp" runat="server">
    <ContentTemplate>
        <script language="javascript" type="text/javascript">

            function fnDisplayCatchErrorMessage() {
                document.getElementById('errormessage').style.display = "block";
            }

            function fnConfirmDelete(id) {
                document.getElementById('<%= hdnConfirmDelete.ClientID %>').value = id;
                $find('mpeConfirmDelete').show();
                return false;
            }

            function validation() {
                document.getElementById('errormessage').style.display = "block";
                var title = document.getElementById('<%= txtTitle.ClientID%>').value;
                var ActionFor = document.getElementById('<%= ddlActionType.ClientID%>').value;
                var issuccess = true;

                if (title == '') {
                    document.getElementById("litTitle").style.display = "inline-block";
                    document.getElementById("litTitle").style.float = "left";
                    document.getElementById("litTitle").style.height = "25px";
                    issuccess = false;
                }
                else {
                    document.getElementById("litTitle").style.display = "none";
                }
                
                if (ActionFor == '00000000-0000-0000-0000-000000000000') {
                    document.getElementById("lblActionType").style.display = "inline-block";
                    document.getElementById("lblActionType").style.float = "left";
                    document.getElementById("lblActionType").style.height = "25px";
                    issuccess = false;
                }
                else {
                    document.getElementById("lblActionType").style.display = "none";
                }

                return issuccess;
            }
        </script>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="content">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                <asp:Literal ID="ltrEmailLatterHeading" runat="server"></asp:Literal>
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
                                    <asp:MultiView ID="mvEmailTemplate" runat="server">
                                        <asp:View ID="vEmailTemplateList" runat="server">
                                            <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                <tr>
                                                    <td colspan="4">
                                                        <%if (IsListMessage)
                                                          { %>
                                                        <div class="message finalsuccess">
                                                            <p>
                                                                <strong>
                                                                    <asp:Literal ID="ltrListMessage" runat="server"></asp:Literal></strong>
                                                            </p>
                                                        </div>
                                                        <%}%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="75px">
                                                        <asp:Literal ID="litSTitle" runat="server"></asp:Literal>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="txtSTitle" runat="server"></asp:TextBox>
                                                        <asp:ImageButton ID="btnSearchBlock" CssClass="small_img" Style="border: 0px; margin: -4px 0 0 5px;
                                                            vertical-align: middle;" runat="server" ImageUrl="~/images/search-icon.png" OnClientClick="fnDisplayCatchErrorMessage();"
                                                            OnClick="btnSearch_Click" />
                                                        <asp:ImageButton ID="imgbtnClearSearch" runat="server" ImageUrl="~/images/clearsearch.png"
                                                            Style="border: 0px; vertical-align: middle; margin: -2px 0 0 10px;" OnClick="imgbtnClearSearch_Click" />
                                                    </td>
                                                </tr>
                                                <%--<tr>
                                                    <td colspan="4" align="right" valign="middle">
                                                        <asp:Button ID="btnAddTopEmailTemplate" runat="server" Style="float: right;" OnClick="btnAddTopEmailTemplate_Click" />
                                                    </td>
                                                </tr>--%>
                                                <tr>
                                                    <td colspan="4">
                                                        <div class="box_head">
                                                            <span>
                                                                <asp:Literal ID="ltrNewsLatterList" runat="server"></asp:Literal></span></div>
                                                        <div class="clear">
                                                        </div>
                                                        <div class="box_content">
                                                            <asp:GridView ID="gvEmailTemplateList" runat="server" AutoGenerateColumns="False"
                                                                Width="100%" CssClass="grid_content" OnRowDataBound="gvEmailTemplateList_RowDataBound"
                                                                OnRowCommand="gvEmailTemplateList_RowCommand">
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
                                                                            <asp:Literal ID="ltrGvHdrTitleInti" runat="server"></asp:Literal>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblTitle" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Title")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="300px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Literal ID="ltrGvHdrAction" runat="server"></asp:Literal>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblAction" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "DisplayTerm")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Literal ID="lblGvHdrEditView" runat="server"></asp:Literal>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkEdit" runat="server" Text="test" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "EmailTemplateID")%>'
                                                                                CommandName="EDITDATA"><img src="../../images/file.png" /></asp:LinkButton>
                                                                            <%--<asp:LinkButton ID="lnkDelete" runat="server" Text="test" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "EmailTemplateID")%>'
                                                                                CommandName="DELETEDATA" OnClientClick="ShowPopup();"><img src="../../images/delete.png" /></asp:LinkButton>--%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <div class="pagecontent_info">
                                                                        <div class="NoItemsFound">
                                                                            <h2>
                                                                                <asp:Label ID="lblNoRecordFound" runat="server"></asp:Label></h2>
                                                                        </div>
                                                                    </div>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <%--<tr>
                                                    <td colspan="4" align="right" valign="middle">
                                                        <asp:Button ID="btnAddEmailTemplate" runat="server" Style="float: right;" OnClick="btnAddTopEmailTemplate_Click" />
                                                    </td>
                                                </tr>--%>
                                            </table>
                                        </asp:View>
                                        <asp:View ID="vNewLatterEntry" runat="server">
                                            <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                <tr>
                                                    <td colspan="2">
                                                        <div>
                                                            <%if (IsPopupMessage)
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
                                                    <td class="isrequire">
                                                        <asp:Literal ID="ltrTitle" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtTitle" runat="server" Style="float: left;"></asp:TextBox>
                                                        <span class="input-notification error png_bg" id="litTitle" style="display: none;">
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <asp:Literal ID="litEmailConfiguration" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlEmailConfiguration" runat="server" Style="float: left;">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="isrequire">
                                                        <asp:Literal ID="ltrActionType" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlActionType" runat="server" Style="float: left;">
                                                        </asp:DropDownList>
                                                        <span class="input-notification error png_bg" id="lblActionType" style="display: none;">
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th align="left" style="vertical-align: top;" valign="top">
                                                        <asp:Literal ID="ltrBody" runat="server"></asp:Literal>
                                                    </th>
                                                    <td colspan="2">
                                                        <CKEditor:CKEditorControl ID="ckBody" runat="server">
                                                        </CKEditor:CKEditorControl>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" colspan="2">
                                                        <div>
                                                            <asp:Button ID="btnBackToList" runat="server" OnClientClick="fnDisplayCatchErrorMessage();"
                                                                OnClick="btnBackToList_Click" Style="display: inline;" />
                                                            <asp:Button ID="btnSave" runat="server" OnClientClick="return validation();" OnClick="btnSave_Click"
                                                                Style="display: inline;" />
                                                            <asp:Button ID="btnCancel" runat="server" OnClientClick="fnDisplayCatchErrorMessage();"
                                                                OnClick="btnCancel_Click" Visible="false" Style="display: inline;" />
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
                                <asp:Button ID="btnYes" runat="server" OnClientClick="fnDisplayCatchErrorMessage();"
                                    Style="display: inline; padding-right: 10px;" OnClick="btnYes_Click" />
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
