<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test Popup Page</title>
    <script type="text/javascript">        var GB_ROOT_DIR = "http://localhost:4148/greybox/"; </script>
    <script type="text/javascript" src="greybox/AJS.js"></script>
    <script type="text/javascript" src="greybox/AJS_fx.js"></script>
    <script type="text/javascript" src="greybox/gb_scripts.js"></script>
    <link href="greybox/gb_styles.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">

        function EventReg() {
            var url = '../TestPopupPage.aspx';
            return GB_showCenter('Test Greybox', url, 550, 620);
        }

        function fnUpdateParent() {
            __doPostBack('lnkTest', '');
         }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <a href="#" onclick="return EventReg();" >Test Greybox</a>
        <div style="display:none;">
            <asp:LinkButton ID="lnkTest" runat="server" OnClick="lnkTest_OnClick"></asp:LinkButton>
        </div>
        <br />
        <br />
        <asp:Label ID="lblTest" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
