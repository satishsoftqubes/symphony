<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlOccupancyChartByBlockAndRateCard.ascx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Report.CtrlOccupancyChartByBlockAndRateCard" %>

<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
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
                    Occupancy Report - RoomType & RateCard
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
                            <td>
                                <asp:Literal ID="litStartDate" runat="server" Text="From"></asp:Literal>
                            </td>
                            <td style="width: 300px;">
                                <asp:CheckBox ID="chkStartDate" runat="server" AutoPostBack="true" Text="" OnCheckedChanged="chkStartDate_CheckedChanged" />
                                <asp:TextBox ID="txtStartDate" runat="server" onkeypress="return false;" SkinID="Search"></asp:TextBox>
                                <asp:Image ID="imgSColor" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                    Height="20px" Width="20px" />
                                <ajx:CalendarExtender ID="calStartDate" runat="server" TargetControlID="txtStartDate"
                                    PopupButtonID="imgSColor">
                                </ajx:CalendarExtender>
                            </td>
                            <td style="width: 50px;">
                                <asp:Literal ID="litEndDate" runat="server" Text="To"></asp:Literal>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkEndDate" runat="server" AutoPostBack="true" Text="" OnCheckedChanged="chkEndDate_CheckedChanged" />
                                <asp:TextBox ID="txtEndDate" runat="server" onkeypress="return false;" SkinID="Search"></asp:TextBox>
                                <asp:Image ID="imgEColor" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                    Height="20px" Width="20px" />
                                <ajx:CalendarExtender ID="calEndDate" runat="server" TargetControlID="txtEndDate"
                                    PopupButtonID="imgEColor">
                                </ajx:CalendarExtender>
                            </td>
                        </tr>       
                          <tr>
                          <td></td>
                        <td >
                            <asp:LinkButton ID="lbkbtnRoomType" runat="server" 
                                Text="Occupancy Report - RoomType" onclick="lbkbtnRoomType_Click"></asp:LinkButton>
                        </td>
                        </tr>                
                        <tr>
                            <td>
                            </td>
                            <td>
                                <div style="float: Left;">
                                    <%-- <asp:Button ID="btnPrint" Text="Print" Style="float: left; margin-left: 5px;" runat="server"
                                        ImageUrl="~/images/cancle.png" OnClick="btnPrint_Click" OnClientClick="fnDisplayCatchErrorMessage()" />--%>
                                    <asp:Button ID="btnPreview" Text="View" Style="float: left; margin-left: 5px;" runat="server" EnableViewState="false"
                                        ImageUrl="~/images/save.png" OnClick="btnPreview_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
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