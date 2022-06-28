<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SQT.Symphony.UI.Web.IRMS._Default" %>

<%@ Register Src="MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link id="Link1" href="~/Style/login.css" runat="server" rel="stylesheet" type="text/css" />
    <title>Uniworld | Investor Login</title>
    <link href="Style/style.css" type="text/css" rel="Stylesheet" />
    <link href="Style/modelpopup.css" type="text/css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="srcptmana" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <script type="text/javascript">
        function fnDisplayCatchErrorMessage() {
            document.getElementById('errormessage').style.display = "block";
        }

        function checkname(username) {
            var em = document.getElementById("<%=txtUsername.ClientID%>").value;
            alert(em);
            //HelloWorld(username, onRequestComplete, onError);
            PageMethods.GetUser('abcabcd');
        }
        
    </script>
    <asp:UpdatePanel ID="pnlLogni" runat="server">
        <ContentTemplate>
            <div class="contentmain">
                <div class="login_header">
                    <div class="login_logo">
                        <img src="images/logo.jpg" alt="" />
                    </div>
                </div>
                <div class="login_main">
                    <table border="0" cellspacing="0" cellpadding="0" class="box">
                        <tr>
                            <td class="loginboxtopleft">
                                &nbsp;
                            </td>
                            <td class="loginboxtopcenter">
                                LOG IN
                            </td>
                            <td class="loginboxtopright">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="loginbox_bg_left">
                                &nbsp;
                            </td>
                            <td class="loginbox_bg">
                                <div class="loginbox_content">
                                    <span>Username</span><br />
                                    <asp:TextBox ID="txtUsername" runat="server" Style="margin-top: 5px; outline: none;
                                        width: 250px; height: 25px;" />
                                    <asp:RequiredFieldValidator ID="rvfUserName" Style="color: Red;" ValidationGroup="Login"
                                        runat="server" ControlToValidate="txtUserName" ErrorMessage="*" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    <br />
                                    <br />
                                    <span>Password</span><br />
                                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Style="outline: none;
                                        margin-top: 5px; width: 250px; height: 25px;" />
                                    <asp:RequiredFieldValidator ID="rvfPassword" Style="color: Red;" ValidationGroup="Login"
                                        runat="server" ControlToValidate="txtPassword" ErrorMessage="*" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:CheckBox ID="chkRememberMe" runat="server" Text="Remember me" />
                                    <br />
                                    <br />
                                    <asp:Button ID="Login" Style="outline: none; float: left;" Text="Login" runat="server"
                                        CssClass="button1" ValidationGroup="Login" CausesValidation="true" OnClick="Login_Click" />
                                    <asp:Button ID="Cancel" Style="outline: none; float: left; margin-left: 10px" Text="Cancel"
                                        CssClass="button1" CausesValidation="true" runat="server" OnClick="Cancel_Click" />
                                </div>
                                <div style="text-align: right; float: right; padding-bottom: 5px; padding-right: 5px;">
                                    <asp:LinkButton ID="lnkForgotPassword" runat="server" ForeColor="#0067a4" Font-Underline="false"
                                        PostBackUrl="~/ForgotPassword.aspx" Text="Forgot Password"></asp:LinkButton>
                                </div>
                            </td>
                            <td class="loginbox_bg_right">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="loginboxbottomleft">
                                &nbsp;
                            </td>
                            <td class="loginboxbottomcenter">
                                &nbsp;
                            </td>
                            <td class="loginboxbottomright">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <div class="clear">
                    </div>
                    <br />
                    <p>
                        <strong>Note : </strong>Only authorised members are permitted to log into this portal.
                        Any unauthorised access or attempt to access will be a breach of our data security
                        and liable for prosecution under IT Act 2000 of India.</p>
                </div>
            </div>
            <div>
                <ajx:ModalPopupExtender ID="msgbx" runat="server" TargetControlID="hfMessage" PopupControlID="pnl"
                    BackgroundCssClass="mod_background">
                </ajx:ModalPopupExtender>
                <asp:HiddenField ID="hfMessage" runat="server" />
                <asp:Panel ID="pnl" runat="server" Style="display: none;">
                    <div style="width: 500px; height: 200px; margin-top: 25px;">
                        <table border="0" cellspacing="0" cellpadding="0" class="modelpopup_box">
                            <tr>
                                <td class="modelpopup_boxtopleft">
                                    &nbsp;
                                </td>
                                <td class="modelpopup_boxtopcenter">
                                    &nbsp;
                                </td>
                                <td class="modelpopup_boxtopright">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="modelpopup_boxleft">
                                    &nbsp;
                                </td>
                                <td class="modelpopup_box_bg">
                                    <div style="width: 100px; float: left; margin-top: 10px;">
                                        <asp:HyperLink ID="CloseModelPopup" runat="server">
                                            <asp:Image ImageUrl="~/images/error.png" AlternateText="" Height="75px" Width="75px"
                                                ID="btnImage" runat="server" />
                                        </asp:HyperLink>
                                    </div>
                                    <div style="float: left; width: 225px; margin-top: 40px; margin-left: 10px;">
                                        <asp:Label ID="lblErrorMessage" runat="server" Text="Enter Valid Username and Password"></asp:Label>
                                    </div>
                                    <table cellpadding="3" cellspacing="3" width="100%" style="margin-left: 5px; margin-top: 15px;">
                                        <tr>
                                            <td align="center" valign="middle">
                                                <asp:Button ID="btnAddressOk" runat="server" Text="Ok" Style="display: inline-block;" />
                                                <%--<asp:Button ID="btnAddressCancel" Text="Cancel" Style="display: inline-block; margin-left: 5px;"
                                                    runat="server" ImageUrl="~/images/cancle.png" />--%>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td class="modelpopup_boxright">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="modelpopup_boxbottomleft">
                                    &nbsp;
                                </td>
                                <td class="modelpopup_boxbottomcenter">
                                </td>
                                <td class="modelpopup_boxbottomright">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>
                <%--<script language="javascript">
                    document.getElementById('pnl').style.display = "block";
                </script>--%>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div id="errormessage" class="clear" style="display: none;">
        <uc1:MsgBox ID="MessageBox" runat="server" />
    </div>
    </form>
</body>
</html>
