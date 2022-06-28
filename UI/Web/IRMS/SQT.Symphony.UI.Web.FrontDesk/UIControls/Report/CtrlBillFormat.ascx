<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlBillFormat.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Report.CtrlBillFormat" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript">

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
    function openViewer() {
        var Preview = '<%=IsPreview%>';
        window.open("../../ReportFiles/frmViewer.aspx?mail=" + Preview);
    }
</script>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
            <tr>
                <td class="boxtopleft">
                    &nbsp;
                </td>
                <td class="boxtopcenter">
                    Invoice
                </td>
                <td class="boxtopright">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="boxleft">
                    &nbsp;
                </td>
                <td>
                    <table width="100%" cellpadding="3" cellspacing="2" style="background-color: #fff;">
                        <tr>
                            <td align="left" valign="top" style="width: 100px;">
                                <asp:Literal ID="ltInvoice" runat="server" Text="Invoice No."></asp:Literal>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlInvoice" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top" style="width: 100px;">
                            </td>
                            <td>
                                <div style="float: left; padding-right: 30px;">
                                    <asp:RadioButton ID="rdoDetail" runat="server" Text="Detail Report" AutoPostBack="true"
                                        GroupName="Collection" OnCheckedChanged="rdoDetail_CheckedChanged" /></div>
                                <asp:RadioButton ID="rdoSummary" runat="server" Text="Summary Report" GroupName="Collection"
                                    AutoPostBack="true" OnCheckedChanged="rdoDetail_CheckedChanged" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <div style="float: Left;">
                                    <%-- <asp:Button ID="btnPrint" Text="Print" Style="float: left; margin-left: 5px;" runat="server"
                                        ImageUrl="~/images/cancle.png" OnClick="btnPrint_Click" OnClientClick="fnDisplayCatchErrorMessage()" />--%>
                                    <asp:Button ID="btnPreview" Text="View" Style="float: left; margin-left: 5px;" runat="server"
                                        EnableViewState="false" ImageUrl="~/images/save.png" OnClick="btnPreview_Click"
                                        OnClientClick="fnDisplayCatchErrorMessage()" />
                                    <asp:ImageButton ID="imgbtnPDF" Text="" Style="float: left; margin-left: 5px;" ToolTip="ExportToPDF"
                                        runat="server" ImageUrl="~/images/report_pdf.png" OnClick="imgbtnPDF_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                    <asp:ImageButton ID="imgbtnXLSX" Text="" Style="float: left; margin-left: 5px;" ToolTip="ExportToXLSX"
                                        runat="server" ImageUrl="~/images/report_xlsx.png" OnClick="imgbtnXLSX_Click"
                                        OnClientClick="fnDisplayCatchErrorMessage()" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
                <td class="boxright">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="boxbottomleft">
                    &nbsp;
                </td>
                <td class="boxbottomcenter">
                    &nbsp;
                </td>
                <td class="boxbottomright">
                    &nbsp;
                </td>
            </tr>
        </table>
        <div class="clear_divider">
        </div>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnPreview" />
        <asp:PostBackTrigger ControlID="imgbtnPDF" />
        <asp:PostBackTrigger ControlID="imgbtnXLSX" />
    </Triggers>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
