<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmViewer.aspx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.ReportFiles.frmViewer" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../Style/style.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        var gAutoPrint = true; // Flag for whether or not to automatically call the print function
        function printSpecial() {
            if (document.getElementById != null) {
                var html = '\n\n';
                //                if (document.getElementsByTagName != null)
                //                { 
                //                    var headTags = document.getElementsByTagName("head"); 
                //                    if (headTags.length > 0) 
                //                    html += headTags[0].innerHTML;
                //                } 
                //                html += '\n< / H E A D >\n< B O D Y>\n';
                var printReadyElem = document.getElementById("CRViewer_ctl01");
                alert(document.getElementById("CRViewer_ctl01"));
                if (printReadyElem != null) {
                    html += printReadyElem.innerHTML;
                }
                else {
                    alert("Could not find the printReady section in the HTML"); return;
                }
                html += '\n</ B O D Y >\n</ H T M L >';
                var printWin = window.open("", "printSpecial");
                printWin.document.open();
                printWin.document.write(html);
                printWin.document.close();
                if (gAutoPrint) printWin.print();
            }
            else {
                alert("Sorry, the print ready feature is only available in modern browsers.");
            }
        }
    </script>
    <script type="text/javascript" language="javascript">
        function fnPrintPage() {
            document.getElementById('dvToHide').style.display = 'none';
            window.print();
        }
    </script>
    <script language="javascript">

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
    </script>
</head>
<body>
    <form id="form1" runat="server">
      <asp:ScriptManager ID="scptInnerHTML" runat="server">
    </asp:ScriptManager>
    <div>
        <div id="dvToHide" style="padding-bottom:10px; padding-top:10px;padding-left:10px; padding-right:10px;">           
            <asp:Button ID="btnEmail" runat="server" Text="E-Mail" 
                style="float:left; margin-left:5px;" CssClass="button1" 
                onclick="btnEmail_Click" />
            <asp:Button ID="btnPrint" runat="server" Text="Print" style="float:left; margin-left:5px;" CssClass="button1" OnClientClick="javascript:fnPrintPage();" />
            <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="button1" OnClientClick="javascript:window.close();" />
        </div>
        <CR:CrystalReportViewer ID="CRViewer" runat="server" AutoDataBind="true" HasDrilldownTabs="False"
            HasToggleGroupTreeButton="false" HasToggleParameterPanelButton="false" BestFitPage="True"
            ToolPanelView="None" EnableTheming="false" DisplayToolbar="False" />
    </div>
    <div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
    </div>
    </form>
</body>
</html>

