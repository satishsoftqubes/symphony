<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlBilling.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.Configurations.CtrlBilling" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript" language="javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<asp:UpdatePanel ID="upnlBilling" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td align="left" valign="top">
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
                            <td align="left" valign="top">
                                <div class="box_form">
                                    <table cellpadding="2" cellspacing="2" width="100%">
                                        <tr>
                                            <td colspan="2">
                                                <div>
                                                    <%if (IsMessage)
                                                      { %>
                                                    <div class="message finalsuccess">
                                                        <p>
                                                            <strong>
                                                                <asp:Literal ID="ltrSuccessfullyTerm" runat="server"></asp:Literal></strong>
                                                        </p>
                                                    </div>
                                                    <%}%>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th align="left" valign="top">
                                                <asp:Literal ID="litFolioNotes" runat="server"></asp:Literal>
                                            </th>
                                            <td>
                                                <CKEditor:CKEditorControl ID="txtFolioNotes" runat="server">
                                                </CKEditor:CKEditorControl>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" colspan="2">
                                                <div>
                                                    <asp:Button ID="btnTermsConditionSave" runat="server" CausesValidation="true" ValidationGroup="IsRequire"
                                                        OnClick="btnTermsConditionSave_Click" Style="display: inline;" OnClientClick="fnDisplayCatchErrorMessage();" />
                                                </div>
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
    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox id="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="upnlBilling" ID="UpdateProgressBilling"
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
