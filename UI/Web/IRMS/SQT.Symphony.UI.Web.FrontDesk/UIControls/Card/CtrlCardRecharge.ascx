<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCardRecharge.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Card.CtrlCardRecharge" %>
<%@ Register Src="~/UIControls/Card/CtrlCommonSearchGuest.ascx" TagName="SearchGuest"
    TagPrefix="ucSearchGuest" %>
<asp:UpdatePanel ID="updRecharge" runat="server">
    <ContentTemplate>
        <asp:MultiView ID="mvCardRecharge" runat="server">
            <asp:View ID="vGuestList" runat="server">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="content">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="boxtopleft">
                                        &nbsp;
                                    </td>
                                    <td class="boxtopcenter">
                                        <asp:Literal ID="lithdrGuestList" runat="server" Text="Recharge"></asp:Literal>
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
                                            <ucSearchGuest:SearchGuest ID="ctrlCommonSearchGuest" runat="server" OnbtnSearchGuestCallParent_Click="btnSearchGuestCallParent_Click" />
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
            </asp:View>
            <asp:View ID="vCardRecharge" runat="server">                
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="content">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="boxtopleft">
                                        &nbsp;
                                    </td>
                                    <td class="boxtopcenter">
                                        <asp:Literal ID="litRecharge" runat="server" Text="Recharge"></asp:Literal>
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
                                                    <td class="isrequire" style="width: 80px !important;">
                                                        <asp:Literal ID="litPMT" runat="server" Text="Payment Mode"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlPMT" runat="server">
                                                            <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                            <asp:ListItem Text="Cash" Value="Cash"></asp:ListItem>
                                                            <asp:ListItem Text="Card" Value="Card"></asp:ListItem>
                                                            <asp:ListItem Text="Cheque" Value="Cheque"></asp:ListItem>
                                                            <asp:ListItem Text="BACS" Value="BACS"></asp:ListItem>
                                                            <asp:ListItem Text="Direct Bill" Value="Direct Bill"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rfvPMT" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                ValidationGroup="IsRequire" ControlToValidate="ddlPMT" Display="Dynamic">
                                                            </asp:RequiredFieldValidator>
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="isrequire" style="width: 80px !important;">
                                                        <asp:Literal ID="litBalance" runat="server" Text="Balance"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtBalance" runat="server"></asp:TextBox>
                                                        <ajx:FilteredTextBoxExtender ID="ftBalance" runat="server" TargetControlID="txtBalance"
                                                            FilterType="Custom, Numbers" ValidChars="." />
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rfvBalance" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                runat="server" ValidationGroup="IsRequire" ControlToValidate="txtBalance" Display="Dynamic">
                                                            </asp:RequiredFieldValidator>
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" colspan="2">
                                                        <asp:Button ID="btnSavePrint" runat="server" Text="Save & Print" Style="display: inline;"
                                                            ValidationGroup="IsRequire" />
                                                        <asp:Button ID="btnSave" runat="server" Text="Save" Style="display: inline;" ValidationGroup="IsRequire" />
                                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" Style="display: inline;"
                                                            OnClick="btnCancel_Click" />
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
            </asp:View>
        </asp:MultiView>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdateProgress AssociatedUpdatePanelID="updRecharge" ID="UpdateProgressRecharge"
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
