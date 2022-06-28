<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckOutVoucher.aspx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Billing.CheckOutVoucher" %>
    <%@ Register Src="~/UIControls/Billing/CtrlCheckOutVoucher.ascx" TagName="CheckOutVoucher"
    TagPrefix="ucCheckOutVoucher" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link id="Link1" href="~/Styles/style.css" runat="server" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function fnPrint() {
            document.getElementById('dvToHide').style.display = 'none';
            window.print();
            window.close();
        }
    </script>
    <style type="text/css">
        h1, p
        {
            font-weight: normal;
            font-size: 10px;
            margin: 0px;
            padding: 0px;
            color: Black;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="box_form" id="divName">
        <table width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <div id="dvToHide" style="padding-bottom: 10px; padding-top: 10px; padding-left: 10px;
                        padding-right: 10px;">
                        <asp:Button ID="btnPrint" runat="server" Text="Print" OnClientClick="fnPrint();" />
                    </div>
                </td>
            </tr>
        </table>
        <ucCheckOutVoucher:CheckOutVoucher ID="ucCheckOutVoucher" runat="server" />
        <br />
        <br />
        ________________________________
        <br />
        Cashier / Front Desk Executive
    </div>
    </form>
</body>
</html>
