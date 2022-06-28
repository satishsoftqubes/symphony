<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlPreference.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Guest.CtrlPreference" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript">
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
                                <asp:Literal ID="litMainHeader" runat="server" Text="Preference"></asp:Literal>
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
                                            <td>
                                                <asp:MultiView ID="mvPreference" runat="server">
                                                    <asp:View ID="vPreferenceList" runat="server">
                                                        <table border="0" width="100%" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td colspan="2" align="right" style="padding: 5px;">
                                                                    <asp:Button ID="btnTopAdd" runat="server" Text="Add" Style="display: inline;" OnClick="btnTopAdd_OnClick" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <div class="box_head">
                                                                        <span>
                                                                            <asp:Literal ID="litPreferenceList" runat="server" Text="Preference List"></asp:Literal>
                                                                        </span>
                                                                    </div>
                                                                    <div class="clear">
                                                                    </div>
                                                                    <div class="box_content">
                                                                        <asp:GridView ID="gvPreference" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                            Width="100%">
                                                                            <Columns>
                                                                                <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%# Container.DataItemIndex + 1 %>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrPreference" runat="server" Text="Preference"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%#DataBinder.Eval(Container.DataItem, "Preference")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblActions" runat="server" Text="Action"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblPopUp" runat="server" Text="Action"></asp:Label>
                                                                                        <ajx:HoverMenuExtender ID="HoverMenuExtender2" runat="server" TargetControlID="lblPopUp"
                                                                                            PopupControlID="Panel2" PopupPosition="Left">
                                                                                        </ajx:HoverMenuExtender>
                                                                                        <asp:Panel ID="Panel2" runat="server" Style="visibility: hidden; opacity: 100%">
                                                                                            <div class="actionsbuttons_hovermenu">
                                                                                                <table border="0" cellpadding="0" cellspacing="0" class="actionsbuttons_hover_lettmenu_table">
                                                                                                    <tr>
                                                                                                        <td class="actionsbuttons_hover_lettmenu">
                                                                                                        </td>
                                                                                                        <td class="actionsbuttons_hover_centermenu">
                                                                                                            <ul>
                                                                                                                <li>
                                                                                                                    <asp:LinkButton ID="lnkEdit" runat="server" Style="background: none !important; border: none;"
                                                                                                                        ToolTip="Edit" CommandName="EDIT" Text="Profile"><img src="../../images/file.png" /></asp:LinkButton>
                                                                                                                </li>
                                                                                                                <li>
                                                                                                                    <asp:LinkButton ID="lnkDelete" runat="server" Style="background: none !important;
                                                                                                                        border: none;" ToolTip="Delete" CommandName="DELETE" Text="Profile"><img src="../../images/delete_icon.png" /></asp:LinkButton>
                                                                                                                </li>
                                                                                                            </ul>
                                                                                                        </td>
                                                                                                        <td class="actionsbuttons_hover_rightmenu">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </div>
                                                                                        </asp:Panel>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" align="right" style="padding: 5px;">
                                                                    <asp:Button ID="btnBottumAdd" runat="server" Text="Add" Style="display: inline;" OnClick="btnTopAdd_OnClick" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:View>
                                                    <asp:View ID="vPreferenceAdd" runat="server">
                                                        <table border="0" width="100%" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td class="isrequire">
                                                                    <asp:Literal ID="litPreference" runat="server" Text="Preference"></asp:Literal>
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
                                                                <td colspan="2" align="right" style="padding: 5px;">
                                                                    <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="IsRequire" Style="display: inline;"
                                                                        OnClick="btnSave_OnClick" />
                                                                    <asp:Button ID="btnClear" runat="server" Text="Cancel" Style="display: inline;" OnClick="btnClear_OnClick" />
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
    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessage" class="clear">
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
