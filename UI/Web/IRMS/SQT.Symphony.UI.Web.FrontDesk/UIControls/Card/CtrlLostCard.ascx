<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlLostCard.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Card.CtrlLostCard" %>
<%@ Register Src="~/UIControls/Card/CtrlCommonSearchGuest.ascx" TagName="SearchGuest"
    TagPrefix="ucSearchGuest" %>
<script type="text/javascript">
    function fnCheckBalance() {

        var chkPMT = document.getElementById('<%=chkPMT.ClientID %>');
        var Balance = document.getElementById('<%=txtBalance.ClientID %>').value;
        var ddlPMT = document.getElementById('<%=ddlPMT.ClientID %>');

        if (parseFloat(Balance) > 0) {
            chkPMT.checked = true;
            ddlPMT.disabled = false;
        }
        else {
            chkPMT.checked = false;
            ddlPMT.disabled = true;
            ddlPMT.selectedIndex = 0;
        }
    }

    function fnCheckPaymentMethod() {
        var chkPMT = document.getElementById('<%=chkPMT.ClientID %>');
        var ddlPMT = document.getElementById('<%=ddlPMT.ClientID %>');
        var Balance = document.getElementById('<%=txtBalance.ClientID %>').value;

        if (chkPMT.checked) {
            if (parseFloat(Balance) > 0) {
                ddlPMT.disabled = false;
            }
            else {
                chkPMT.checked = false;
                ddlPMT.disabled = true;
                ddlPMT.selectedIndex = 0;
            }
        }
        else {
            ddlPMT.disabled = true;
            ddlPMT.selectedIndex = 0;
        }
    }
</script>
<asp:UpdatePanel ID="updRecharge" runat="server">
    <ContentTemplate>
        <asp:MultiView ID="mvLostCard" runat="server">
            <asp:View ID="vGuestList" runat="server">
                <%--<div class="box_col1">
                    <div class="box_head">
                        <span>
                            <asp:Literal ID="lithdrGuestList" runat="server" Text="Lost/Cancel Card"></asp:Literal></span></div>
                    <div class="clear">
                    </div>
                    <div class="box_form">--%>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="content">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="boxtopleft">
                                        &nbsp;
                                    </td>
                                    <td class="boxtopcenter">
                                        <asp:Literal ID="lithdrGuestList" runat="server" Text="Lost/Cancel Card"></asp:Literal>
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
                                        <ucSearchGuest:SearchGuest ID="ctrlCommonSearchGuest" runat="server" OnbtnSearchGuestCallParent_Click="btnSearchGuestCallParent_Click" />
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
            <asp:View ID="vLostCard" runat="server">
                <%--<div class="box_col1">
                    <div class="box_head">
                        <span>
                            <asp:Literal ID="lithdrLostCard" runat="server" Text="Lost/Cancel Card"></asp:Literal></span></div>
                    <div class="clear">
                    </div>
                    <div class="box_form">--%>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="content">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="boxtopleft">
                                        &nbsp;
                                    </td>
                                    <td class="boxtopcenter">
                                        <asp:Literal ID="lithdrLostCard" runat="server" Text="Lost/Cancel Card"></asp:Literal>
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
                                        <table cellpadding="2" cellspacing="2" width="100%">
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:RadioButtonList ID="rbtlstCard" runat="server" RepeatDirection="Horizontal"
                                                        RepeatColumns="2">
                                                        <asp:ListItem Text="Lost Card" Value="Lost Card"></asp:ListItem>
                                                        <asp:ListItem Text="Cancel Card" Value="Cancel Card"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="isrequire" style="width: 100px !important;">
                                                    <asp:Literal ID="litBalance" runat="server" Text="Balance"></asp:Literal>
                                                </td>
                                                <td>
                                                    <div style="float: left; width: 300px;">
                                                        <asp:TextBox ID="txtBalance" runat="server" onkeyup="fnCheckBalance();" Style="text-align: right;"
                                                            Text="500.00"></asp:TextBox>
                                                        <ajx:FilteredTextBoxExtender ID="ftBalance" runat="server" TargetControlID="txtBalance"
                                                            FilterType="Custom, Numbers" ValidChars="." />
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rfvBalance" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                runat="server" ValidationGroup="IsRequire" ControlToValidate="txtBalance" Display="Dynamic">
                                                            </asp:RequiredFieldValidator>
                                                        </span>
                                                    </div>
                                                    <div style="float: left; width: 300px;">
                                                        <asp:Button ID="btnStatemente" runat="server" OnClick="btnStatemente_Click" Text="Statement" />
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Literal ID="litReason" runat="server" Text="Reason"></asp:Literal>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtReason" runat="server" TextMode="MultiLine" Style="width: 400px !important;"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:CheckBox ID="chkPMT" runat="server" Checked="true" Text="Payment Mode" />
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
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Literal ID="litRefundAmount" runat="server" Text="Refund Amount"></asp:Literal>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtRefundAmount" runat="server"></asp:TextBox>
                                                    <ajx:FilteredTextBoxExtender ID="ftRefundAmount" runat="server" TargetControlID="txtRefundAmount"
                                                        FilterType="Custom, Numbers" ValidChars="." />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" colspan="2">
                                                    <asp:Button ID="btnSave" runat="server" Text="Save" Style="display: inline;" ValidationGroup="IsRequire" />
                                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" Style="display: inline;"
                                                        OnClick="btnCancel_Click" />
                                                </td>
                                            </tr>
                                        </table>
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
