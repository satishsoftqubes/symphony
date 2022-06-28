<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlInvestorList.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.Reports.CtrlInvestorList" %>
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
                    INVESTORS
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
                                <asp:Literal ID="litName" runat="server" Text="Investor Name"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="litMobile" runat="server" Text="Mobile"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="litEmail" runat="server" Text="Email"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="litOccupation" runat="server" Text="Occupation"></asp:Literal>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlOccupation" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>                       
                        <tr>
                            <td>
                                <asp:Literal ID="litCity" runat="server" Text="Location"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                         <tr>
                            <td>
                                <asp:Literal ID="litCompanyName" runat="server" Text="Company Name"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCompanyName" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                      <%--  <tr style="visibility:hidden;">
                            <td>
                                <asp:Literal ID="litState" runat="server" Text="State"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtState" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="visibility:hidden;">
                            <td>
                                <asp:Literal ID="litCountry" runat="server" Text="Country"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCountry" runat="server"></asp:TextBox>
                            </td>
                        </tr>                --%>        
                        <tr>
                            <td>
                            </td>
                            <td>
                                <div style="float: Left;">
                                    <asp:Button ID="btnPrint" Text="Print" Style="float: left; margin-left: 5px;" runat="server"
                                        ImageUrl="~/images/cancle.png" OnClick="btnPrint_Click"  OnClientClick="fnDisplayCatchErrorMessage()"/>
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
        <asp:PostBackTrigger ControlID="btnPrint" />
        <asp:PostBackTrigger ControlID="imgbtnPDF" />
        <asp:PostBackTrigger ControlID="imgbtnXLSX" />
        <asp:PostBackTrigger ControlID="imgbtnDOC" />
    </Triggers>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>