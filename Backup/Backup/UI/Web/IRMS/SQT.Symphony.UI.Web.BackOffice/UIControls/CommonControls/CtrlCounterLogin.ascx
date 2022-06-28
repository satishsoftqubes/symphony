<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCounterLogin.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.BackOffice.UIControls.CommonControls.CtrlCounterLogin" %>
<%@ Register Src="~/MsgBox/MsgBx.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<asp:MultiView ID="mvCounte" runat="server">
    <asp:View ID="vCounterLogin" runat="server">
        <table border="0" cellpadding="2" cellspacing="2">
            <tr>
                <td>
                    <span>
                        <asp:RadioButtonList runat="server" ID="rblLoginOption" AutoPostBack="true" OnSelectedIndexChanged="rblLoginOption_OnSelectedIndexChanged"
                            RepeatColumns="1" RepeatDirection="Vertical">
                            <asp:ListItem Selected="True" Text="Countinue Without Counter Login" Value="Countinue Without Counter Login"></asp:ListItem>
                            <asp:ListItem Text="Countinue With Counter Login" Value="Countinue With Counter Login"></asp:ListItem>
                        </asp:RadioButtonList>
                    </span>
                    <br />
                    <div id="divLogin" runat="server" visible="false" style="margin-left: 30px; width: 250px">
                        <span>
                            <asp:Literal ID="litCounter" Text="Counter" runat="server"></asp:Literal>&nbsp;&nbsp;&nbsp;&nbsp;</span>
                        <span>
                            <asp:DropDownList ID="ddlCounter" Style="width: 100px;" runat="server">
                            </asp:DropDownList>
                        </span><span>
                            <asp:RequiredFieldValidator Enabled="false" ID="rfvCounter" InitialValue="00000000-0000-0000-0000-000000000000"
                                SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                ValidationGroup="IsRequire" ControlToValidate="ddlCounter" Display="Dynamic"></asp:RequiredFieldValidator>
                        </span>
                        <br />
                        <br />
                        <span>
                            <asp:Literal ID="litLoginTime" Text="Login Time" runat="server"></asp:Literal>&nbsp;&nbsp;
                        </span><span>
                            <asp:Literal ID="litDspLoginTime" runat="server"></asp:Literal>
                        </span>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <div style="display: inline-block;">
                        <asp:Button ID="btnCancel" runat="server" OnClick="btnDetailCancel_OnClick" CausesValidation="false"
                            ImageUrl="~/images/cancle.png" Style="float: right; margin-left: 5px;" Text="Cancel" />
                        <asp:Button ID="btnLogin" runat="server" CausesValidation="true" Text="Login" ImageUrl="~/images/save.png"
                            Style="float: right; margin-left: 5px;" ValidationGroup="IsRequire" OnClick="btnLogin_OnClick" />
                    </div>
                </td>
            </tr>
        </table>
    </asp:View>
    <asp:View ID="vCounterDetail" runat="server">
        <table border="0" cellpadding="2" cellspacing="2">
            <tr>
                <td>
                    <span>
                        <asp:RadioButtonList runat="server" ID="rblDetailLoginOption" AutoPostBack="true"
                            OnSelectedIndexChanged="rblDetailLoginOption_OnSelectedIndexChanged" RepeatColumns="1"
                            RepeatDirection="Vertical">
                            <asp:ListItem Selected="True" Text="Countinue Without Counter Login" Value="Countinue Without Counter Login"></asp:ListItem>
                            <asp:ListItem Text="Countinue With Counter Login" Value="Countinue With Counter Login"></asp:ListItem>
                        </asp:RadioButtonList>
                    </span>
                    <br />
                    <div id="divDetails" runat="server" visible="false" style="margin-left: 30px; width: 250px">
                        <span>
                            <asp:Literal ID="litDetailCounter" Text="Counter" runat="server"></asp:Literal>&nbsp;&nbsp;&nbsp;&nbsp;</span>
                        <span>
                            <asp:Literal ID="litDspDetailCounter" runat="server"></asp:Literal></span>
                        <br />
                        <br />
                        <span>
                            <asp:Literal ID="litDetailLoginTime" Text="Login Time" runat="server"></asp:Literal>&nbsp;&nbsp;
                        </span><span>
                            <asp:Literal ID="litDspDetailLoginTime" runat="server"></asp:Literal>
                        </span>
                        <br />
                        <br />
                        <span>
                            <asp:Literal ID="litDetailAmount" Text="Amount collection" runat="server"></asp:Literal>&nbsp;&nbsp;
                        </span><span>
                            <asp:Literal ID="litDspAmount" Text="0.00" runat="server"></asp:Literal>
                        </span>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <div style="display: inline-block;">
                        <asp:Button ID="btnDetailCancel" runat="server" OnClick="btnDetailCancel_OnClick"
                            CausesValidation="false" ImageUrl="~/images/cancle.png" Style="float: right;
                            margin-left: 5px;" Text="Cancel" />
                        <asp:Button ID="btnDetailLogin" runat="server" OnClick="btnDetailLogin_OnClick" CausesValidation="true"
                            Text="Login" ImageUrl="~/images/save.png" Style="float: right; margin-left: 5px;" />
                    </div>
                </td>
            </tr>
        </table>
    </asp:View>
</asp:MultiView>
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
