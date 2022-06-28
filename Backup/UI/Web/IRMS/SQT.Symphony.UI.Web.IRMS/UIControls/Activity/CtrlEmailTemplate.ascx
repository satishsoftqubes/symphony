<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlEmailTemplate.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.Activity.CtrlEmailTemplate" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<style type="text/css">
    #progressBackgroundFilter
    {
        position: fixed;
        top: 0px;
        width: 100%;
        height: 100%;
        bottom: 0px;
        left: 0px;
        right: 0px;
        overflow: hidden;
        padding: 0;
        margin: 0;
        background-color: #000;
        filter: alpha(opacity=50);
        opacity: 0.5;
        z-index: 1111111;
    }
    #processMessage
    {
        position: fixed;
        top: 50%;
        left: 50%;
        padding: 10px;
        width: 30px;
        border-radius: 10px;
        z-index: 1111112;
        background-color: #fff;
        border: solid 1px #efefef;
    }
    
    .autocomplete_completionListElement
    {
        visibility: hidden;
        margin: 0px !important;
        background-color: inherit;
        color: windowtext;
        border: buttonshadow;
        border-width: 1px;
        border-style: solid;
        cursor: 'default';
        overflow: auto;
        height: auto;
        text-align: left;
        list-style-type: none;
    }
    .autocomplete_completionListElement li a:hover
    {
        color: White !important;
    }
    /* AutoComplete highlighted item */
    
    .autocomplete_highlightedListItem
    {
        background-color: #0A246A;
        color: white;
        padding: 1px;
    }
    
    /* AutoComplete item */
    
    .autocomplete_listItem
    {
        background-color: window;
        color: windowtext;
        padding: 1px;
    }
</style>
<asp:UpdatePanel ID="updSystemSetUp" runat="server">
    <ContentTemplate>
        <script language="javascript" type="text/javascript">

            function fnDisplayCatchErrorMessage() {
                document.getElementById('errormessage').style.display = "block";
            }

            function validation() {
                document.getElementById('errormessage').style.display = "block";
                var title = document.getElementById('<%= txtSubject.ClientID %>').value;
                var issuccess = true;
                if (title == '') {
                    document.getElementById("litSubject").style.display = "inline-block";
                    document.getElementById("litSubject").style.float = "left";
                    document.getElementById("litSubject").style.height = "25px";
                    issuccess = false;
                }
                else {
                    document.getElementById("litSubject").style.display = "none";
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
                                <asp:Literal ID="ltrEmailLatterHeading" Text="Email Templates" runat="server"></asp:Literal>
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
                                                    <td>
                                                        <%if (IsListMessage)
                                                          { %>
                                                        <div class="ResetSuccessfully">
                                                            <div style="float: left; padding-top: 7px; width: 25px; height: 24px; margin-right: 10px;">
                                                                <img src="../../images/success.png" />
                                                            </div>
                                                            <div>
                                                                <asp:Literal ID="ltrListMessage" runat="server"></asp:Literal></div>
                                                            <div style="height: 10px;">
                                                            </div>
                                                        </div>
                                                        <%}%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dTableBox">
                                                        <asp:GridView ID="gvEmailTemplateList" runat="server" AutoGenerateColumns="False"
                                                            Width="100%" CssClass="grid_content" OnRowCommand="gvEmailTemplateList_RowCommand">
                                                            <Columns>
                                                                <asp:TemplateField ItemStyle-Width="25px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblGvHrdNo" runat="server" Text="No."></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex + 1 %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                    <HeaderTemplate>
                                                                        <asp:Literal ID="ltrGvHdrTitleInti" runat="server" Text="Title"></asp:Literal>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTitle" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Title")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="30px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                    <HeaderTemplate>
                                                                        <asp:Literal ID="lblGvHdrEditView" runat="server" Text="Edit"></asp:Literal>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkEdit" runat="server" Text="test" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "EmailTemplateID")%>'
                                                                            CommandName="EDITDATA"><img src="/images/edit.png" /></asp:LinkButton>
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
                                                    </td>
                                                </tr>
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
                                                    <td class="isrequire" width="70px">
                                                        <asp:Literal ID="ltrTitle" runat="server" Text="Title"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtTitle" runat="server" SkinID="nowidth" Width="250px" Style="float: left;"
                                                            Enabled="false"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="isrequire">
                                                        <asp:Literal ID="ltrSubject" runat="server" Text="Subject"></asp:Literal>
                                                    </td>
                                                    <td>
                                                    <span class="rfv_ErrorStar" id="litSubject" style="display: none;">*
                                                        </span>
                                                        <asp:TextBox ID="txtSubject" runat="server" SkinID="nowidth" Width="250px" Style="float: left;"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th align="left" style="vertical-align: top;" valign="top">
                                                        <asp:Literal ID="ltrBody" runat="server" Text="Body"></asp:Literal>
                                                    </th>
                                                    <td colspan="2">
                                                        <CKEditor:CKEditorControl ID="ckBody" runat="server">
                                                        </CKEditor:CKEditorControl>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" colspan="2">
                                                        <div>
                                                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClientClick="return validation();"
                                                                OnClick="btnSave_Click" Style="display: inline;" />
                                                            <asp:Button ID="btnBackToList" runat="server" OnClientClick="fnDisplayCatchErrorMessage();"
                                                                OnClick="btnBackToList_Click" Text="Cancel" Style="display: inline;" />
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
