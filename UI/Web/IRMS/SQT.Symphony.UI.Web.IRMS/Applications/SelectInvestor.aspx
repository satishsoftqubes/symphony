<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectInvestor.aspx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.Applications.SelectInvestor" %>

<%@ Register Src="~/UIControls/DashBoard/SelectInvestor.ascx" TagName="SelectInvestor"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Investor Selection</title>
    <link href="../Style/style.css" type="text/css" rel="Stylesheet" />
    <link href="../Style/login.css" runat="server" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%">
            <tr>
                <td>
                    <div class="login_header">
                    <div class="login_logo">
                        <img src="../images/logo.jpg" alt="" />
                    </div>
                </div>
                </td>
            </tr>
            <tr>
                <td align="center" valign="top" style="padding-top:50px;">
                    <div style="width:600px; vertical-align:top;">
                        <uc1:SelectInvestor ID="ucSelectInvestor" runat="server" />
                    </div>
                </td>
            </tr>
        </table>
        
    </div>
    </form>
</body>
</html>
