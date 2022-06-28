<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlPaymentAlertsList.ascx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.Reports.CtrlPaymentAlertsList" %>

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
                   <%if (IsAlert)
                     {%>
                     DUE PAYMENTS
                     <% }
                     else
                     {%>
                     PAYMENT RECEIPTS
                     <%} %>
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
                                <asp:Literal ID="litProperty" runat="server" Text="Property"></asp:Literal>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlProperty" runat="server"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="litInvestor" runat="server" Text="Investor"></asp:Literal>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlInvestor" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlInvestor_SelectedIndexChanged"></asp:DropDownList>
                            </td>
                        </tr>
                         <%if (IsAlert)
                     {%>                     
                        <tr>
                            <td>
                                <asp:Literal ID="litRoom" runat="server" Text="Unit"></asp:Literal>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlUnit" runat="server"></asp:DropDownList>
                            </td>
                        </tr>
                          <%} %>
                        <tr>
                            <td>
                                <asp:Literal ID="litStartDate" runat="server" Text="Start Date"></asp:Literal>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkStartDate" runat="server" AutoPostBack="true" Text="" 
                                    oncheckedchanged="chkStartDate_CheckedChanged" />
                                <asp:TextBox ID="txtStartDate" runat="server" onkeypress="return false;" 
                                    SkinID="Search"></asp:TextBox>
                                <asp:Image ID="imgSColor" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                    Height="20px" Width="20px" />
                                <ajx:CalendarExtender ID="calStartDate" runat="server" TargetControlID="txtStartDate" CssClass="MyCalendar"
                                    PopupButtonID="imgSColor">
                                </ajx:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="litEndDate" runat="server" Text="End Date" ></asp:Literal>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkEndDate" runat="server" AutoPostBack="true" Text="" 
                                    oncheckedchanged="chkEndDate_CheckedChanged"  />
                               <asp:TextBox ID="txtEndDate" runat="server" onkeypress="return false;" 
                                    SkinID="Search"></asp:TextBox>
                                <asp:Image ID="imgEColor" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                    Height="20px" Width="20px" />
                                <ajx:CalendarExtender ID="calEndDate" runat="server" TargetControlID="txtEndDate" CssClass="MyCalendar"
                                    PopupButtonID="imgEColor">
                                </ajx:CalendarExtender>
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