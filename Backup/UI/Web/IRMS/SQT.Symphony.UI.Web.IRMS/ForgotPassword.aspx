<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.ForgotPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link id="Link1" href="~/Style/login.css" runat="server" rel="stylesheet" type="text/css" />
    <link href="Style/style.css" type="text/css" rel="Stylesheet" />
    <link href="Style/modelpopup.css" type="text/css" rel="Stylesheet" />
    <title>Uniworld | Forgot Password</title>
</head>
<body>
    <script type="text/javascript">
        function fnDisplayCatchErrorMessage() {
            document.getElementById('errormessage').style.display = "block";
        }
    </script>
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
    <asp:UpdatePanel ID="upnlForgetPassword" runat="server">
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
                            <td class="loginboxtopcenter_new">
                                FORGOT PASSWORD
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
                                    <asp:MultiView ID="mvForgetPwd" runat="server">
                                        <asp:View ID="vGetPwd" runat="server">
                                            <span>Email</span><br />
                                            <asp:TextBox ID="txtEmail" runat="server" Style="margin-top: 5px; outline: none;
                                                width: 250px; height: 25px;" />
                                            <asp:RequiredFieldValidator ID="rvfUserName" Style="color: Red;" ValidationGroup="Login"
                                                Display="Dynamic" runat="server" ControlToValidate="txtEmail" ErrorMessage="*"
                                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="refEmail" SetFocusOnError="True" ControlToValidate="txtEmail"
                                                ValidationGroup="Login" runat="server" ErrorMessage="*" Style="color: Red;" Display="Dynamic"
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                            <br />
                                            <br />
                                            <asp:Button ID="btnGetPassword" Style="outline: none; float: left;" Text="Submit"
                                                runat="server" CssClass="button1" ValidationGroup="Login" CausesValidation="true"
                                                OnClick="btnGetPassword_OnClick" OnClientClick="fnDisplayCatchErrorMessage()" />
                                            <asp:Button ID="btnCancel" Style="outline: none; float: left; margin-left: 10px"
                                                Text="Cancel" CssClass="button1" CausesValidation="true" runat="server" OnClick="btnCancel_OnClick"
                                                OnClientClick="fnDisplayCatchErrorMessage()" />
                                            <br />
                                            <br />
                                            <br />
                                            <br />
                                        </asp:View>
                                        <asp:View ID="vOK" runat="server">
                                            <span>Email send to your EmailID. Please check your inbox.</span><br />
                                            <br />
                                            <br />
                                            <table align="center">
                                                <tr>
                                                    <td align="center">
                                                        <asp:Button ID="btnOK" Style="outline: none; margin-left: 10px" Text="OK" CssClass="button1"
                                                            CausesValidation="true" runat="server" OnClick="btnOK_OnClick" />
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
                                                <asp:Button ID="btnAddressCancel" Text="Cancel" Style="display: inline-block; margin-left: 5px;"
                                                    runat="server" ImageUrl="~/images/cancle.png" />
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
            </div>
            <div>
                <ajx:ModalPopupExtender ID="mpeMessageBox" runat="server" TargetControlID="hdnMessageBox" PopupControlID="pnlMessageBox"
                    BackgroundCssClass="mod_background" CancelControlID="btnMessageBoxOk">
                </ajx:ModalPopupExtender>
                <asp:HiddenField ID="hdnMessageBox" runat="server" />
                <asp:Panel ID="pnlMessageBox" runat="server" Style="display: none;">
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
                                        <asp:HyperLink ID="HyperLink1" runat="server">
                                            <asp:Image ImageUrl="~/images/error.png" AlternateText="" Height="75px" Width="75px"
                                                ID="Image1" runat="server" />
                                        </asp:HyperLink>
                                    </div>
                                    <div style="float: left; width: 225px; margin-top: 40px; margin-left: 10px;">
                                        <asp:Label ID="litMessageBox" runat="server"></asp:Label>
                                    </div>
                                    <table cellpadding="3" cellspacing="3" width="100%" style="margin-left: 5px; margin-top: 15px;">
                                        <tr>
                                            <td align="center" valign="middle">
                                                <asp:Button ID="btnMessageBoxOk" runat="server" Text="OK" Style="display: inline; padding-right:10px;" />
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
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
   
    <div id="errormessage" class="clear" style="display: none;">
        <uc1:MsgBox ID="MessageBox" runat="server" />
    </div>
     
    <asp:UpdateProgress AssociatedUpdatePanelID="upnlForgetPassword" ID="UpdateProgressForgetPassword"
        runat="server">
        <ProgressTemplate>
            <div id="progressBackgroundFilter">
            </div>
            <div id="processMessage">
                <center>
                    <img src="../../images/Wait.gif" /></center>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    </form>
</body>
</html>
