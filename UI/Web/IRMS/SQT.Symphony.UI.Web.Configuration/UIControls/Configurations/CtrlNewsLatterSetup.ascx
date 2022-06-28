<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlNewsLatterSetup.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.Configurations.CtrlNewsLatterSetup" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>
<asp:UpdatePanel ID="updSystemSetUp" runat="server">
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
                                <asp:Literal ID="ltrNewsLatterHeading" runat="server"></asp:Literal>
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
                                    <asp:MultiView ID="mvNewLatter" runat="server">
                                        <asp:View ID="vNewLatterList" runat="server">
                                            <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                <tr>
                                                    <td colspan="4">
                                                        <%if (IsMessageLst)
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
                                                    <th>
                                                        <asp:Literal ID="litSTitle" runat="server"></asp:Literal>
                                                    </th>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="txtSTitle" runat="server"></asp:TextBox>
                                                        <asp:ImageButton ID="btnSearchBlock" CssClass="small_img" Style="border: 0px; vertical-align: middle;
                                                            margin-left: 5px;" runat="server" ImageUrl="~/images/search-icon.png" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" align="right" valign="middle">
                                                        <asp:Button ID="btnAddTopBlock" runat="server" Style="float: right;" 
                                                            onclick="btnAddTopBlock_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                    <div class="box_head">
                                                    <span>
                                                        <asp:Literal ID="ltrNewsLatterList" runat="server"></asp:Literal></span></div>
                                                <div class="clear">
                                                </div>
                                                <div class="box_content">
                                                        <asp:GridView ID="gvNewsLatterList" runat="server" AutoGenerateColumns="False" Width="100%"
                                                            CssClass="grid_content" onrowdatabound="gvNewsLatterList_RowDataBound"  onrowcommand="gvNewsLatterList_RowCommand">
                                                            <Columns>
                                                                <asp:TemplateField ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                    <HeaderTemplate>
                                                                     <asp:Literal ID="ltrGvHdrTitleInti" runat="server"></asp:Literal>
                                                                       
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTitle" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Title")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                    <HeaderTemplate>
                                                                    <asp:Literal ID="ltrGvHdrNewsForInit" runat="server"></asp:Literal>
                                                                        
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblNewsFor" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "NewsFor")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="6%">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkEdit" runat="server" Text="test" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "NewsLetterID")%>'  CommandName="EDITDATA"><img src="../../images/file.png" /></asp:LinkButton>
                                                                        <asp:LinkButton ID="lnkDelete" runat="server" Text="test" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "NewsLetterID")%>'  CommandName="DELETEDATA"><img src="../../images/delete.png" /></asp:LinkButton>
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
                                                        </asp:GridView></div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" align="right" valign="middle">
                                                        <asp:Button ID="btnAddBlocks" runat="server" Style="float: right;" onclick="btnAddTopBlock_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                        <asp:View ID="vNewLatterEntry" runat="server">
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
                                                <tr>
                                                    <th>
                                                        <asp:Literal ID="ltrTitle" runat="server"></asp:Literal>
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>
                                                        <asp:Literal ID="ltrNewsFor" runat="server"></asp:Literal>
                                                    </th>
                                                    <td>
                                                        <asp:DropDownList ID="ddlNewsFor" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>
                                                        <asp:Literal ID="ltrDetails" runat="server"></asp:Literal>
                                                    </th>
                                                    <td>
                                                        
                                                        <CKEditor:CKEditorControl ID="CKEditorControl1" runat="server">
                                                        </CKEditor:CKEditorControl>
                                                        
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="2">
                                                        <table cellpadding="3" cellspacing="3" width="100%" style="margin-left: 5px; margin-top: 15px;">
                                                            <tr>
                                                                <td>
                                                                    <asp:Button ID="btnSaveAndPublish" runat="server" 
                                                                        onclick="btnSaveAndPublish_Click"/>
                                                                </td>
                                                                <td align="right" valign="middle">
                                                                    <asp:Button ID="btnOk" runat="server" onclick="btnOk_Click"/>
                                                                </td>
                                                                <td align="left" valign="middle">
                                                                    <asp:Button ID="btnCancel" runat="server" onclick="btnCancel_Click"/>
                                                                </td>
                                                            </tr>
                                                        </table>
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
                        <uc1:MsgBox ID="MessageBox" runat="server" />
                    </div>
                </td>
            </tr>

        </table>
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
                                <asp:Button ID="btnYes" runat="server" OnClientClick="this.disabled = true; this.value = 'Processing...';" UseSubmitBehavior="false" Style="display: inline; padding-right: 10px;" />
                                 <asp:Button ID="btnCancelDelete" runat="server" Style="display: inline;"  />
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
<asp:UpdateProgress AssociatedUpdatePanelID="updSystemSetUp" ID="UpdateProgressSystemSetUp"
    runat="server">
    <ProgressTemplate>
        <div id="progressBackgroundFilter">
        </div>
        <div id="processMessage">
            <center>
                <img src="../../images/ajax-loader.gif" />
            </center>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>