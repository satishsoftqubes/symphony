<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SQT.Symphony.UI.Web.BackOffice.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><asp:Literal ID="litPageTitle" runat="server"></asp:Literal></title>
    <link id="lnkLoginCss" href="~/Style/login.css" runat="server" rel="stylesheet" type="text/css" />
    <link href="Style/style.css" rel="Stylesheet" type="text/css" />
    <link href="Style/modelpopup.css" type="text/css" rel="Stylesheet" />
</head>
<body>
    <form id="frmLogin" runat="server">
    <asp:ScriptManager ID="srcptmana" runat="server" EnablePageMethods="true">
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
                            <td class="loginboxtopcenter">
                                <asp:Literal ID="litMainHeader" runat="server"></asp:Literal>
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
                                <asp:Panel ID="pnlLogin" runat="server" DefaultButton="btnLogin">
                                    <div class="loginbox_content" style="width: 280px;">
                                        <span>
                                            <asp:Literal ID="lblUserName" runat="server"></asp:Literal></span><br />
                                        <asp:TextBox ID="txtUsername" runat="server" Style="width: 245px; height: 25px;" />
                                        <span>
                                            <asp:RequiredFieldValidator ID="rvfUserName" ValidationGroup="IsRequire" runat="server"
                                                ControlToValidate="txtUserName" CssClass="input-notification error png_bg" SetFocusOnError="true"></asp:RequiredFieldValidator></span>
                                        <br />
                                        <br />
                                        <span>
                                            <asp:Literal ID="lblPassword" runat="server"></asp:Literal></span><br />
                                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Style="width: 245px;
                                            height: 25px;" />
                                        <span>
                                            <asp:RequiredFieldValidator ID="rvfPassword" ValidationGroup="IsRequire" runat="server"
                                                ControlToValidate="txtPassword" SetFocusOnError="true" CssClass="input-notification error png_bg"></asp:RequiredFieldValidator></span>
                                        <%-- <br />
                                        <br />--%>
                                        <span>
                                            <asp:Literal ID="litHotel" runat="server" Visible="false"></asp:Literal></span><br />
                                        <asp:TextBox ID="txtHotelCode" runat="server" MaxLength="4" Visible="false" Style="width: 245px; height: 25px;" />
                                        <ajx:FilteredTextBoxExtender ID="ftbHotelCode" runat="server" TargetControlID="txtHotelCode" FilterMode="ValidChars" 
                                            ValidChars="0123456789"></ajx:FilteredTextBoxExtender>
                                        <span>
                                            <asp:RequiredFieldValidator ID="rfvHotelCode" ValidationGroup="IsRequire" runat="server"
                                            ControlToValidate="txtHotelCode" SetFocusOnError="true" CssClass="input-notification error png_bg"></asp:RequiredFieldValidator></span>
                                        <br />
                                        <%--<br />--%>
                                        <asp:CheckBox ID="chkRememberMe" runat="server" />
                                        <%--<br />
                                        <br />--%>
                                    </div>
                                    <div style="padding-left: 25px;">
                                        <asp:Button ID="btnLogin" Style="outline: none; float: left;"
                                            runat="server" CssClass="button1" OnClick="btnLogin_OnClick" ValidationGroup="IsRequire"
                                            CausesValidation="true" />
                                        <asp:Button ID="btnCancel" Style="outline: none; float: left; margin-left: 10px"
                                             CssClass="button1" OnClick="btnCancel_OnClick"
                                            CausesValidation="true" runat="server" />
                                    </div>
                                    <div style="text-align: right; float: right; padding-bottom: 5px; padding-right: 5px;">
                                        <asp:LinkButton ID="lnkForgotPassword" runat="server" ForeColor="#0067a4" Font-Underline="false"
                                            PostBackUrl="~/ForgotPassword.aspx"></asp:LinkButton></div>
                                    <br />
                                    <br />
                                </asp:Panel>
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
                <div class="clear">
                    <%--<uc1:msgbox id="MessageBox" runat="server" />--%>
                </div>
            </div>
            <div>
                <ajx:ModalPopupExtender ID="mpeMessage" runat="server" TargetControlID="hfMessage" PopupControlID="pnlMessage"
                    BackgroundCssClass="mod_background" CancelControlID="btnOk">
                </ajx:ModalPopupExtender>
                <asp:HiddenField ID="hfMessage" runat="server" />
                <asp:Panel ID="pnlMessage" runat="server" style="display:none;">
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
                                        <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
                                    </div>
                                    <table cellpadding="3" cellspacing="3" width="100%" style="margin-left: 5px; margin-top: 15px;">
                                        <tr>
                                            <td align="center" valign="middle">
                                                <asp:Button ID="btnOk" runat="server" Style="display: inline-block;" />
                                                <%--<asp:Button ID="btnAddressCancel" Text="<%$ Resources:Login, lblCancel %>" Style="display: inline-block;
                                                    margin-left: 5px;" runat="server" ImageUrl="~/images/cancle.png" />--%>
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
    </form>
</body>
</html>
