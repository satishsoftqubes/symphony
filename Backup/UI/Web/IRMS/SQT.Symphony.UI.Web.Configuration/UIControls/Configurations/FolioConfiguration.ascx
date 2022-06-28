<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FolioConfiguration.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.Configurations.FolioConfiguration" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<script type="text/javascript" language="javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function pageLoad(sender, args) {
        $(function () {
            $("#tabs").tabs();
        });

        $('#tabs').tabs({
            select: function (event, ui) {
                window.location.hash = ui.tab.hash;
            }
        });
    }

    function SelectTab(tabno) {
        if (tabno == '1') {
            window.location.hash = 'tabs-1';
        }
        else if (tabno == '2') {
            window.location.hash = 'tabs-2';
        }
    }

</script>
<asp:UpdatePanel ID="upnlFolioConfiguration" runat="server">
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
                                    <div class="demo">
                                        <div id="tabs">
                                            <ul>
                                                <li><a href="#tabs-1">
                                                    <asp:Literal ID="litTabFolioConfiguration" runat="server"></asp:Literal></a></li>
                                                <li><a href="#tabs-2">
                                                    <asp:Literal ID="litTabBilling" runat="server"></asp:Literal></a></li>
                                            </ul>
                                            <div id="tabs-1">
                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td colspan="3">
                                                            <div>
                                                                <%if (IsInsert)
                                                                  { %>
                                                                <div class="message finalsuccess">
                                                                    <p>
                                                                        <strong>
                                                                            <asp:Literal ID="litMoreOptionMessage" runat="server"></asp:Literal></strong>
                                                                    </p>
                                                                </div>
                                                                <%}%>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="vertical-align: top; border-right: 1px solid #D0D0D0 !important;">
                                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                                <tr>
                                                                    <td class="box_head">
                                                                        <b>
                                                                            <asp:Literal ID="litReRountingEnable" runat="server"></asp:Literal></b>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="checkbox_new">
                                                                        <asp:CheckBox ID="chkSameReservation" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="checkbox_new">
                                                                        <asp:CheckBox ID="chkGroupReservation" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="checkbox_new">
                                                                        <asp:CheckBox ID="chkAllReservation" runat="server" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td style="vertical-align: top; border-right: 1px solid #D0D0D0 !important;">
                                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                                <tr>
                                                                    <td class="box_head">
                                                                        <b>
                                                                            <asp:Literal ID="lblCreateSubFolio" runat="server"></asp:Literal></b>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="checkbox_new">
                                                                        <asp:CheckBox ID="chkAccomodation" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="checkbox_new">
                                                                        <asp:CheckBox ID="chkRestaurant" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="checkbox_new">
                                                                        <asp:CheckBox ID="chkPOS" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="checkbox_new">
                                                                        <asp:CheckBox ID="chkMiscellaneous" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="checkbox_new">
                                                                        <asp:CheckBox ID="chkCallLogger" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="checkbox_new">
                                                                        <asp:CheckBox ID="chkLoundry" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="checkbox_new">
                                                                        <asp:CheckBox ID="chkMiscServices" runat="server" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td style="vertical-align: top;">
                                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                                <tr>
                                                                    <td class="box_head">
                                                                        <b>
                                                                            <asp:Literal ID="litApplicable" runat="server"></asp:Literal></b>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="checkbox_new">
                                                                        <asp:CheckBox ID="chkTransferBalance" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="checkbox_new">
                                                                        <asp:CheckBox ID="chkAdvanceChargePosting" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="checkbox_new">
                                                                        <asp:CheckBox ID="chkTransferTransaction" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="checkbox_new">
                                                                        <asp:CheckBox ID="chkBalanceTransfer" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="checkbox_new">
                                                                        <asp:CheckBox ID="chkDepositTransfer" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="checkbox_new">
                                                                        <asp:CheckBox ID="chkVoidTransaction" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="checkbox_new">
                                                                        <asp:CheckBox ID="chkSplitFolio" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="checkbox_new">
                                                                        <asp:CheckBox ID="chkAutoCheckinFolio" runat="server" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            <table cellpadding="3" cellspacing="3" width="100%" style="margin-left: 5px; margin-top: 15px;">
                                                                <tr>
                                                                    <td align="right" valign="middle" width="50%">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="right" valign="middle" width="50%">
                                                                        <asp:Button ID="btnMoreOptionSave" runat="server" CausesValidation="true" ValidationGroup="IsRequire"
                                                                            Style="float: right; margin: 0px 5px;" OnClick="btnMoreOptionSave_Click" OnClientClick="fnDisplayCatchErrorMessage();" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div id="tabs-2">
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
                                        </div>
                                    </div>
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
<asp:UpdateProgress AssociatedUpdatePanelID="upnlFolioConfiguration" ID="UpdateProgressFolioConfiguration"
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
