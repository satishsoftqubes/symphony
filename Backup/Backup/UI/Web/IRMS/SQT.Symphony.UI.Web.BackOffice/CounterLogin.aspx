<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CounterLogin.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.CounterLogin" %>

<%@ Register Src="~/UIControls/CommonControls/CtrlCounterLogin.ascx" TagName="CtrlCounterLogin"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>
        <asp:Literal ID="litPageTitle" runat="server"></asp:Literal></title>
    <link id="lnkLoginCss" href="~/Style/login.css" runat="server" rel="stylesheet"
        type="text/css" />
    <link href="~/Style/style.css" rel="Stylesheet" type="text/css" />
    <link href="~/Style/modelpopup.css" type="text/css" rel="Stylesheet" />
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
                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
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
                                <asp:Panel ID="pnlLogin" runat="server">
                                    <div class="loginbox_content" style="width: 280px;">
                                        <uc1:CtrlCounterLogin ID="CtrlCounterLogin1" runat="server" />
                                    </div>
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
                </div>
                <div class="clear">
                    <%--<uc1:msgbox id="MessageBox" runat="server" />--%>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
