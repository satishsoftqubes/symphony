<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCommonCounterLogin.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls.CtrlCommonCounterLogin" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<%--<ajx:ModalPopupExtender ID="mpeCounterLogin" runat="server" TargetControlID="hdnCounterLogin"
    PopupControlID="pnlCounterLogin" BackgroundCssClass="mod_background">
</ajx:ModalPopupExtender>
<asp:HiddenField ID="hdnCounterLogin" runat="server" />
<asp:Panel ID="pnlCounterLogin" runat="server" Width="750px" Style="display: none;">--%>
    <asp:MultiView ID="mvCounter" runat="server">
        <asp:View ID="vCounterLogin" runat="server">
            <table border="0" cellpadding="2" cellspacing="2">
                <tr>
                    <td>
                        <div id="divLogin" runat="server" style="margin-left: 30px; width: 250px">
                            <span><b>
                                <asp:Literal ID="litCounter" Text="Counter" runat="server"></asp:Literal>&nbsp;&nbsp;&nbsp;&nbsp;</b></span>
                            <span>
                                <asp:DropDownList ID="ddlCounter" Style="width: 100px;" runat="server">
                                </asp:DropDownList>
                            </span><span>
                                <asp:RequiredFieldValidator Enabled="false" ID="rfvCounter" InitialValue="00000000-0000-0000-0000-000000000000"
                                    SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                    ValidationGroup="IsRequireForCounterLogin" ControlToValidate="ddlCounter" Display="Dynamic"></asp:RequiredFieldValidator>
                            </span>
                            <br />
                            <br />
                            <span><b>
                                <asp:Literal ID="litLoginTime" Text="Login Time" runat="server"></asp:Literal>&nbsp;&nbsp;</b>
                            </span><span><b>
                                <asp:Literal ID="litDspLoginTime" runat="server"></asp:Literal></b></span>
                        </div>
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="vCounterDetail" runat="server">
            <table border="0" cellpadding="2" cellspacing="2">
                <tr>
                    <td>
                        <div id="divDetails" runat="server" style="margin-left: 30px; width: 250px">
                            <span><b>
                                <asp:Literal ID="litDetailCounter" Text="Counter" runat="server"></asp:Literal>&nbsp;&nbsp;&nbsp;&nbsp;</b></span>
                            <span><b>
                                <asp:Literal ID="litDspDetailCounter" runat="server"></asp:Literal></b></span>
                            <br />
                            <br />
                            <span><b>
                                <asp:Literal ID="litDetailLoginTime" Text="Login Time" runat="server"></asp:Literal>&nbsp;&nbsp;</b>
                            </span><span><b>
                                <asp:Literal ID="litDspDetailLoginTime" runat="server"></asp:Literal></b> </span>
                            <br />
                            <br />
                            <span><b>
                                <asp:Literal ID="litDetailAmount" Text="Amount collection" runat="server"></asp:Literal>&nbsp;&nbsp;</b>
                            </span><span><b>
                                <asp:Literal ID="litDspAmount" Text="0.00" runat="server"></asp:Literal></b>
                            </span>
                        </div>
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
<%--</asp:Panel>--%>
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
