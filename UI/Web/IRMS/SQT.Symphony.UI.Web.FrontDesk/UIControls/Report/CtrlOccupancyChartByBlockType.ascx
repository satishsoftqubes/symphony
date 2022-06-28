<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlOccupancyChartByBlockType.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Report.CtrlOccupancyChartByBlockType" %>
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
<script type="text/javascript" language="javascript">
    function fnPrintPage() {
        document.getElementById('dvToHide').style.display = 'none';
        window.print();
    }
</script>
<style>
    .box_form table tr th
    {
        height: auto;
        width: auto;
        color: #393939;
        font-weight: bold;
        border: 1px solid #000000;
    }
    .box_form table td
    {
        padding: 3px;
        border: 1px solid #000000;
    }
</style>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
            <tr>
                <td class="boxtopleft">
                    &nbsp;
                </td>
                <td class="boxtopcenter">
                    Occupancy Report - RoomType
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
                            <td>
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkbtnRateCard" runat="server" Text="Occupancy Report - RoomType & RateCard"
                                    OnClick="lnkbtnRateCard_Click"></asp:LinkButton>
                                <br />
                                <br />
                                <asp:LinkButton ID="lnkbtnRoomType" runat="server" Text="Occupancy Report - Block & Room Type"
                                    OnClick="lnkbtnRoomType_Click"></asp:LinkButton>
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
                                    <%--<asp:ImageButton ID="imgbtnPDF" Text="" Style="float: left; margin-left: 5px;" ToolTip="ExportToPDF"
                                        runat="server" ImageUrl="~/images/report_pdf.png" OnClick="imgbtnPDF_Click" OnClientClick="fnDisplayCatchErrorMessage()" />--%>
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
        <%--     <asp:PostBackTrigger ControlID="imgbtnPDF" />--%>
        <asp:PostBackTrigger ControlID="imgbtnXLSX" />
    </Triggers>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<ajx:ModalPopupExtender ID="mpeOccupancy" runat="server" TargetControlID="hdnOCcupancy"
    PopupControlID="pnlOccupancy" BackgroundCssClass="mod_background" BehaviorID="mpeOccupancy">
</ajx:ModalPopupExtender>
<asp:HiddenField ID="hdnOccupancy" runat="server" />
<asp:Panel ID="pnlOccupancy" runat="server" Width="800px" Style="display: none;">
    <div class="box_col1">
        <div class="box_head">
            <span>
                <asp:Literal ID="Literal1" Text="Occupancy Report" runat="server"></asp:Literal></span></div>
        <div class="clear">
        </div>
        <div class="box_form">
            <table cellpadding="2" cellspacing="2" width="100%" border="0">
                <tr>
                    <td style="padding-bottom: 15px; border: 0px;">
                        <div style="padding-bottom: 5px; text-align: center;">
                            <div style="font-family: Arial; font-weight: bold; font-size: 18pt;">
                                <asp:Literal ID="litCompanyName" Text="" runat="server"></asp:Literal>
                            </div>
                            <div style="height: 10px;">
                            </div>
                            <div style="font-family: Arial; font-weight: bold; font-size: 14pt;">
                                <asp:Literal ID="Literal2" Text="Occupancy Report - RoomType" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <table cellpadding="2" cellspacing="2" width="100%">
                            <tr>
                                <td style="border: 0px;">
                                    <div id="dvToHide" style="padding-bottom: 10px; padding-top: 10px; padding-left: 10px;
                                        padding-right: 10px;">
                                        <asp:Button ID="btnPrint" runat="server" Text="Print" Style="float: left; margin-left: 5px; margin-right:5px;"
                                            CssClass="button1" OnClientClick="return fnPrintPage();" />
                                        <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="button1" OnClientClick="javascript:window.close();" />
                                    </div>
                                    <asp:Label ID="lblFromDate" runat="server" Font-Bold="true"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="lblToDate" runat="server" Font-Bold="true"></asp:Label>
                                    <div style="height: 10px;">
                                    </div>
                                    <asp:GridView ID="grdOccupancy" runat="server" SkinID="gvAutoColumns" Width="100%"
                                        HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black" HeaderStyle-BorderWidth="1pt"
                                        CssClass="grid_content" Font-Bold="true" BorderStyle="Solid" BorderColor="Black"
                                        BorderWidth="1pt" GridLines="Vertical">
                                        <EmptyDataTemplate>
                                            <div class="pagecontent_info">
                                                <div class="NoItemsFound">
                                                    <h2>
                                                        <asp:Label ID="lblNoRecordFound" Text="No record found." runat="server"></asp:Label></h2>
                                                </div>
                                            </div>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <div class="clear">
        </div>
    </div>
</asp:Panel>
