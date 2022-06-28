<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.ResetPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link id="lnkLoginCss" href="~/Style/login.css" runat="server" rel="stylesheet" type="text/css" />
    <link href="Style/style.css" rel="Stylesheet" type="text/css" />
    <link href="Style/modelpopup.css" type="text/css" rel="Stylesheet" />
    <title><asp:Literal ID="ltrPageTitle" runat="server"></asp:Literal></title>
</head>
<body>
    <style type="text/css">
        #progressBackgroundFilter
        {
            position: fixed;
            top: 0px;
            bottom: 0px;
            left: 0px;
            right: 0px;
            overflow: hidden;
            padding: 0;
            margin: 0;
            background-color: #000;
            filter: alpha(opacity=50);
            opacity: 0.5;
            z-index: 1000;
        }
        #processMessage
        {
            position: fixed;
            top: 30%;
            left: 43%;
            padding: 10px;
            width: 14%;
            z-index: 1001;
            background-color: #fff;
            border: solid 1px #000;
        }
    </style>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="srcptmana" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="pnlLogni" runat="server">
        <ContentTemplate>
            <div class="contentmain">
                <div class="login_header">
                    <div class="login_logo">
                        <img src="images/logoold.jpg" alt="" />
                    </div>
                </div>
                <div class="login_main">
                    <table border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="loginboxtopleft">
                                &nbsp;
                            </td>
                            <td class="loginboxtopcenter_new">
                                <asp:Literal ID="ltrMainHeader" runat="server"></asp:Literal>
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
                                    <asp:MultiView ID="mvResetPassword" runat="server">
                                        <asp:View ID="vGetPassword" runat="server">
                                            <span><asp:Literal ID="ltrEmail" runat="server"></asp:Literal></span><br />
                                            <asp:TextBox ID="txtEmail" runat="server" Style="margin-top: 5px; outline: none;
                                                width: 225px; height: 25px;" />
                                            <span>
                                                <asp:RequiredFieldValidator ID="rvfUserName" ValidationGroup="Login" Display="Dynamic"
                                                    runat="server" ControlToValidate="txtEmail" CssClass="input-notification error png_bg"
                                                    SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="refEmail" SetFocusOnError="True" ControlToValidate="txtEmail"
                                                    ValidationGroup="Login" runat="server" CssClass="input-notification error png_bg"
                                                    Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                            </span>
                                            <br />
                                            <br />
                                            <asp:Button ID="btnGo" Style="outline: none; float: left;" runat="server"
                                                CssClass="button1" ValidationGroup="Login" CausesValidation="true" OnClick="btnGo_OnClick" />
                                            <asp:Button ID="btnCancel" Style="outline: none; float: left; margin-left: 10px"
                                                CssClass="button1" CausesValidation="true" runat="server" OnClick="btnCancel_OnClick" />
                                            <br />
                                            <br />
                                            <br />
                                            <br />
                                        </asp:View>
                                        <asp:View ID="vSetPassword" runat="server">
                                            <span><asp:Literal ID="ltrNewPassword" runat="server"></asp:Literal></span><br />
                                            <asp:TextBox ID="txtPassword" runat="server" Style="margin-top: 5px; outline: none;
                                                width: 225px; height: 25px;" TextMode="Password" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="vgSetPassword"
                                                Display="Dynamic" runat="server" ControlToValidate="txtPassword" CssClass="input-notification error png_bg"
                                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                                            <br />
                                            <br />
                                            <span><asp:Literal ID="ltrConfirmPassword" runat="server"></asp:Literal></span><br />
                                            <asp:TextBox ID="txtConfirmPassword" runat="server" Style="margin-top: 5px; outline: none;
                                                width: 225px; height: 25px;" TextMode="Password" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="vgSetPassword"
                                                Display="Dynamic" runat="server" ControlToValidate="txtConfirmPassword" CssClass="input-notification error png_bg"
                                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                                            <asp:CompareValidator ID="cmpPwd" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword"
                                                ValidationGroup="vgSetPassword" CssClass="input-notification error png_bg" Display="Dynamic"
                                                SetFocusOnError="true"></asp:CompareValidator>
                                            <br />
                                            <br />
                                            <asp:Button ID="btnSave" Style="outline: none; float: left;" runat="server"
                                                CssClass="button1" ValidationGroup="vgSetPassword" CausesValidation="true" OnClick="btnSave_OnClick" />
                                            <asp:Button ID="btnCancelSave" Style="outline: none; float: left; margin-left: 10px"
                                                CssClass="button1" CausesValidation="true" runat="server" OnClick="btnCancelSave_OnClick" />
                                            <br />
                                            <br />
                                            <br />
                                        </asp:View>
                                        <asp:View ID="vFeedbackMessage" runat="server">
                                            <table>
                                                <tr>
                                                    <td align="center" style="text-align:center;">
                                                        <span><asp:Literal ID="ltrMsgPasswordResetSuccessfully" runat="server"></asp:Literal></span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-top:15px; padding-left:100px;">
                                                        <asp:Button ID="btnGoToLogin" Style="outline: none; float: left;" runat="server"
                                                            CssClass="button1" CausesValidation="true" OnClick="btnOK_OnClick" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                    </asp:MultiView>
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
                </div>
                <div class="clear">
                    <uc1:MsgBox ID="MessageBox" runat="server" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress AssociatedUpdatePanelID="pnlLogni" ID="UpdateProgressLogni" runat="server">
        <ProgressTemplate>
            <div id="progressBackgroundFilter">
            </div>
            <div id="processMessage">
                <center>
                    <img src="images/ajax-loader.gif" /></center>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    </form>
</body>
</html>
