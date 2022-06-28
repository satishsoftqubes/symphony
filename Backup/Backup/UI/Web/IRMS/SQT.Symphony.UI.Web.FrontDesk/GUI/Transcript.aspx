<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Transcript.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Transcript" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">
        function fnCloseWindow() {
            window.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="pnlTranscrition" runat="server" Width="650px">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="litMainHeader" runat="server" Text="Reservation"></asp:Literal>
                    </span>
                    <div style="display: inline; float: right; padding: 7px 10px 0px 0px;">
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table border="0" cellpadding="2" cellspacing="5" width="100%">
                        <tr id="trDataToshow" runat="server" visible="false">
                            <td id="tdDataToshow" runat="server">
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnTranscriptionOK" runat="server" Text="Close" OnClientClick="fnCloseWindow();" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
