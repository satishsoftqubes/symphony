<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlProspectsList.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.Reports.CtrlProspectsList" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function openViewer() {
        var Preview = '<%=IsPreview%>';
        window.open("../../ReportFiles/frmViewer.aspx?preview=" + Preview);
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
                    PROSPECTS
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
                                <asp:Literal ID="litSProspectName" runat="server" Text="Name"></asp:Literal>
                            </td>
                            <td align="left" valign="top" >
                                <asp:TextBox ID="txtSProspectName" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="Literal1" runat="server" Text="Status"></asp:Literal>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlProspectStatus" runat="server" Style="width: 165px;">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td >
                                <asp:Literal ID="litMobileNo" runat="server" Text="City"></asp:Literal>
                            </td>
                            <td >
                                <asp:TextBox ID="txtLocation" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="litSEmail" runat="server" Text="Reference"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtReference" runat="server"></asp:TextBox>                               
                            </td>
                        </tr>
                         <tr>
                            <td align="left" valign="top" style="width: 50px;">
                                <asp:Literal ID="Literal2" runat="server" Text="Company Name"></asp:Literal>
                            </td>
                            <td align="left" valign="top" >
                                <asp:TextBox ID="txtCompanyName" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <div style="float: Left;">
                                    <asp:Button ID="btnPrint" Text="Print" Style="float: left; margin-left: 5px;" runat="server"
                                        ImageUrl="~/images/cancle.png" OnClick="btnPrint_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                    <asp:Button ID="btnPreview" Visible="false" Text="Preview" Style="float: left; margin-left: 5px;"
                                        runat="server" ImageUrl="~/images/save.png" OnClick="btnPreview_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                    <asp:ImageButton ID="imgbtnPDF" Text="" Style="float: left; margin-left: 5px;" ToolTip="ExportToPDF"
                                        runat="server" ImageUrl="~/images/report_pdf.png" 
                                        onclick="imgbtnPDF_Click" OnClientClick="fnDisplayCatchErrorMessage()"/> 
                                    <asp:ImageButton ID="imgbtnXLSX" Text="" Style="float: left; margin-left: 5px;" ToolTip="ExportToXLSX"
                                        runat="server" ImageUrl="~/images/report_xlsx.png" 
                                        onclick="imgbtnXLSX_Click" OnClientClick="fnDisplayCatchErrorMessage()"/>  
                                    <asp:ImageButton ID="imgbtnDOC" Text="" Style="float: left; margin-left: 5px;" ToolTip="ExportToDOC"
                                        runat="server" ImageUrl="~/images/report_word.png" 
                                        onclick="imgbtnDOC_Click" OnClientClick="fnDisplayCatchErrorMessage()"/>  
                                </div>
                            </td>
                        </tr>
            </table> </td>
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
        <asp:PostBackTrigger ControlID="btnPrint" />
        <asp:PostBackTrigger ControlID="imgbtnPDF" />
        <asp:PostBackTrigger ControlID="imgbtnXLSX" />
        <asp:PostBackTrigger ControlID="imgbtnDOC" />
    </Triggers>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>