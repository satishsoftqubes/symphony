<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlHouseKeeping.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.Configurations.CtrlHouseKeeping" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
</script>
<asp:UpdatePanel ID="pnlUpdtHouseKeepingConfiguration" runat="server">
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
                                <asp:Literal ID="litHouseKeepingHeading" runat="server"></asp:Literal>
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
                                    <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                        <tr>
                                            <td colspan="2">
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
                                            <td style="text-align: left; width: 125px;">
                                                <asp:Literal ID="litHKPType" runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlHKPType" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal ID="litDefaultTimeForFullHKP" runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDefaultTimeForFullHKP" runat="server" />&nbsp;(HH:MM)
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression="^(20|21|22|23|[01]\d|\d)(([:][0-5]\d){1,2})$"
                                                    SetFocusOnError="true" ValidationGroup="IsRequire" ControlToValidate="txtDefaultTimeForFullHKP"
                                                    Display="Dynamic" CssClass="input-notification error png_bg"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal ID="litDefaultTimeForMinHKP" runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDefaultTimeForMinHKP" runat="server" />&nbsp;(HH:MM)
                                                <asp:RegularExpressionValidator ID="rgvCheckOutTime" runat="server" ValidationExpression="^(20|21|22|23|[01]\d|\d)(([:][0-5]\d){1,2})$"
                                                    SetFocusOnError="true" ValidationGroup="IsRequire" ControlToValidate="txtDefaultTimeForMinHKP"
                                                    Display="Dynamic" CssClass="input-notification error png_bg"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal ID="litHKPInterval" runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtHKPInterval" runat="server" MaxLength="5" />
                                                <ajx:FilteredTextBoxExtender ID="fltInterval" runat="server" FilterMode="ValidChars"
                                                    FilterType="Numbers" ValidChars="0123456789" TargetControlID="txtHKPInterval">
                                                </ajx:FilteredTextBoxExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal ID="litSetDefaultHKP" runat="server"></asp:Literal>
                                            </td>
                                            <td class="checkbox_new">
                                                <asp:CheckBox ID="chkSetDefaultHKP" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal ID="litSetAlterNetDayHKP" runat="server"></asp:Literal>
                                            </td>
                                            <td class="checkbox_new">
                                                <asp:CheckBox ID="chkSetAlternetDayHKP" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <div style="float: right; width: auto; display: inline-block;">
                                                    <asp:Button ID="btnCancel" Text="Cancel" Style="float: right; margin-left: 5px;"
                                                        runat="server" ImageUrl="~/images/cancle.png" CausesValidation="false" OnClientClick="fnDisplayCatchErrorMessage();"
                                                        OnClick="btnCancel_Click" />
                                                    <asp:Button ID="btnSave" Text="Save" Style="float: right; margin-left: 5px;" runat="server"
                                                        ImageUrl="~/images/save.png" CausesValidation="true" ValidationGroup="IsRequire"
                                                        OnClientClick="fnDisplayCatchErrorMessage();" OnClick="btnSave_Click" />
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
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="pnlUpdtHouseKeepingConfiguration" ID="UpdateProgressHouseKeepingConfiguration"
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
