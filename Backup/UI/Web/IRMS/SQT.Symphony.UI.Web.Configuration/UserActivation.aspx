<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserActivation.aspx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UserActivation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link id="Link1" href="~/Style/login.css" runat="server" rel="stylesheet" type="text/css" />
    <link href="Style/style.css" type="text/css" rel="Stylesheet" />
    <link href="Style/modelpopup.css" type="text/css" rel="Stylesheet" />
    <title>Uniworld | Activate User</title>
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
    <div class="contentmain">
        <div class="login_header">
            <div class="login_logo">
                <img src="images/logoold.jpg" alt="" />
            </div>
        </div>
        <div class="login_main">
            <table border="0" cellspacing="0" cellpadding="0" class="box" style="border:0px !important;">
                <tr>
                    <td class="loginboxtopleft">
                    </td>
                    <td class="loginboxtopcenter" align="left" style="width:325px !important; border:0px !important;">
                        ACTIVATE USER
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
                            <div id="dvSuccess" runat="server" visible="false" style="width: 250px; height: 130px;">
                                <br />
                                <br />
                                Your account is activated successfully.
                                <br />
                                <br />
                                Please, &nbsp;<a href="Index.aspx"><b>Click here</b></a>&nbsp; to login.
                            </div>
                            <div id="dvError" runat="server" visible="false" style="width: 250px; height: 130px;">
                                <br />
                                <br />
                                No user found to activate.
                                <br />
                                <br />
                                Please, &nbsp;<a href="Index.aspx"><b>Click here</b></a>&nbsp; to login.
                            </div>
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
    </form>
</body>
</html>
