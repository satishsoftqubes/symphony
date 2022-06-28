<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlOccupancyChart.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Report.CtrlOccupancyChart" %>
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
<script type="text/javascript">
    function fnOpenDashBoardForOccupancy() {
        window.open("RPTOccupancyReoprtByType.aspx", "Occupancy reoport", "height=700,width=1500,status=1,toolbar=no,menubar=no,scrollbars=1,location=0");
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
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="boxtopleft">
                    &nbsp;
                </td>
                <td class="boxtopcenter">
                    <asp:Literal ID="litHeading" runat="server" Text="Occupancy Report"></asp:Literal>
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
                    <table cellpadding="5" cellspacing="5" id="divTilte" runat="server">
                        <tr>
                            <td>
                                For Property
                            </td>
                            <td>
                                <asp:Button ID="btnReportView" Text="View" runat="server" EnableViewState="false"
                                ImageUrl="~/images/save.png" OnClick="btnReportView_Click" Style="display: inline-block;"
                                OnClientClick="fnDisplayCatchErrorMessage()" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Occupancy Dashboard
                            </td>
                            <td>
                                <asp:Button ID="btnOccupancyDashboard" Text="View" runat="server" EnableViewState="false"
                                ImageUrl="~/images/save.png" OnClientClick="fnOpenDashBoardForOccupancy();" Style="display: inline-block;" />
                            </td>
                        </tr>
                    </table>
                    <%--<div style="padding-bottom: 10px; padding-top: 10px;
                        padding-left: 10px; padding-right: 10px;">
                        <%--<asp:RadioButtonList ID="rdoReportName" runat="server" RepeatDirection="Horizontal"
                            RepeatColumns="2" Width="520px">
                            <asp:ListItem Text="By RoomType" Value="1"></asp:ListItem>
                            <asp:ListItem Text="By RoomCard" Value="2"></asp:ListItem>
                            <asp:ListItem Text="By Gender" Value="3"></asp:ListItem>
                            <asp:ListItem Text="By Work Timing" Value="4"></asp:ListItem>
                            <asp:ListItem Text="By Meal Preference" Value="5"></asp:ListItem>
                            <asp:ListItem Text="By Sector" Value="6"></asp:ListItem>
                            <asp:ListItem Text="By Reservation Type" Value="7"></asp:ListItem>
                            <asp:ListItem Text="By Billing Instruction" Value="8"></asp:ListItem>
                        </asp:RadioButtonList>
                        <div style="padding-top: 30px; width: 520px; text-align: center; display: inline-block;">
                            
                            
                        </div>
                    </div>--%>
                    <div id="divParameter" runat="server" style="padding-bottom: 10px; padding-top: 10px;
                        padding-left: 10px; padding-right: 10px;">
                        <table width="100%" cellpadding="3" cellspacing="2" style="background-color: #fff;" border="0">
                            <tr>
                                <td style="width: 100px;">
                                    <asp:Literal ID="litAsOnDate" runat="server" Text="As On Date"></asp:Literal>
                                </td>
                                <td style="width: 230px;">
                                    <asp:TextBox ID="txtAsOnDate" runat="server" onkeypress="return false;" SkinID="Search"></asp:TextBox>
                                    <asp:Image ID="imgAsColor" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                        Height="20px" Width="20px" />
                                    <ajx:CalendarExtender ID="calAsOnDate" runat="server" TargetControlID="txtAsOnDate"
                                        PopupButtonID="imgAsColor">
                                    </ajx:CalendarExtender>
                                </td>
                                <td style="width: 60px;">
                                    <asp:Button ID="btnAsPrint" Text="View" Style="float: left; margin-left: 5px;" runat="server"
                                        EnableViewState="false" ImageUrl="~/images/save.png" OnClick="btnAsPrint_Click"
                                        OnClientClick="fnDisplayCatchErrorMessage()" />
                                </td>
                                <td style="width: 230px;">
                                    &nbsp;
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5">
                                    <div style="border: 1px solid #ccccce;">
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Literal ID="litStartDate" runat="server" Text="From"></asp:Literal>
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkStartDate" runat="server" AutoPostBack="true" Text="" OnCheckedChanged="chkStartDate_CheckedChanged" />
                                    <asp:TextBox ID="txtStartDate" runat="server" onkeypress="return false;" SkinID="Search"></asp:TextBox>
                                    <asp:Image ID="imgSColor" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                        Height="20px" Width="20px" />
                                    <ajx:CalendarExtender ID="calStartDate" runat="server" TargetControlID="txtStartDate"
                                        PopupButtonID="imgSColor">
                                    </ajx:CalendarExtender>
                                </td>
                                <td >
                                    <asp:Literal ID="litEndDate" runat="server" Text="To"></asp:Literal>
                                </td>
                                <td >
                                    <asp:CheckBox ID="chkEndDate" runat="server" AutoPostBack="true" Text="" OnCheckedChanged="chkEndDate_CheckedChanged" />
                                    <asp:TextBox ID="txtEndDate" runat="server" onkeypress="return false;" SkinID="Search"></asp:TextBox>
                                    <asp:Image ID="imgEColor" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                        Height="20px" Width="20px" />
                                    <ajx:CalendarExtender ID="calEndDate" runat="server" TargetControlID="txtEndDate"
                                        PopupButtonID="imgEColor">
                                    </ajx:CalendarExtender>
                                </td>
                                <td>
                                    <div>
                                        <%-- <asp:Button ID="btnPrint" Text="Print" Style="float: left; margin-left: 5px;" runat="server"
                                        ImageUrl="~/images/cancle.png" OnClick="btnPrint_Click" OnClientClick="fnDisplayCatchErrorMessage()" />--%>
                                        <asp:Button ID="btnPreview" Text="View" Style="float: left; margin-left: 5px;" runat="server"
                                            EnableViewState="false" ImageUrl="~/images/save.png" OnClick="btnPreview_Click"
                                            OnClientClick="fnDisplayCatchErrorMessage()" />
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5" align="right">
                                    <asp:Button ID="btnBack" Text="Back" runat="server" OnClick="btnBack_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
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
        <asp:PostBackTrigger ControlID="btnAsPrint" />
        <asp:PostBackTrigger ControlID="btnReportView" />
    </Triggers>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<ajx:ModalPopupExtender ID="mpeOccupancy" runat="server" TargetControlID="hdnOCcupancy"
    PopupControlID="pnlOccupancy" BackgroundCssClass="mod_background" BehaviorID="mpeOccupancy">
</ajx:ModalPopupExtender>
<asp:HiddenField ID="hdnOccupancy" runat="server" />
<asp:Panel ID="pnlOccupancy" runat="server" Width="800px" Height="650px" Style="display: none;
    background-color: White;">
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
                                        <asp:Button ID="btnPrint" runat="server" Text="Print" Style="float: left; margin-left: 5px;
                                            margin-right: 5px;" CssClass="button1" OnClientClick="return fnPrintPage();" />
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
                                    <div style="padding-bottom: 10px; padding-top: 10px; padding-left: 10px; padding-right: 10px;
                                        height: 10px;" />
                                    <div style="width: 100%; background-color: White; text-align: center;">
                                        <asp:Chart ID="chartOccupancy" runat="server" Height="280px" Width="391px">
                                            <Series>
                                                <asp:Series ChartType="Pie" XValueMember="Section" YValueMembers="Absentees" Legend="Legend1"
                                                    Name="Default" ToolTip="#VAL{P}" IsValueShownAsLabel="true">
                                                </asp:Series>
                                            </Series>
                                            <ChartAreas>
                                                <asp:ChartArea Name="ChartArea1" Area3DStyle-Enable3D="true">
                                                    <Area3DStyle Enable3D="True" />
                                                </asp:ChartArea>
                                            </ChartAreas>
                                            <Legends>
                                                <asp:Legend Name="Legend1">
                                                </asp:Legend>
                                            </Legends>
                                        </asp:Chart>
                                    </div>
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
