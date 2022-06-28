<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlOccupancyReportByType.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Report.CtrlOccupancyReportByType" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript">

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
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
    .corners
    {
        width: 22%;
        float: left;
        height: 33%;
        text-align: center;
        border: 1px solid #a9a9a9;
        margin: 12px auto;
        margin-right: 12px;
        background-color: White;
        color: Black ;
        padding: 10px;
        border-radius: 15px;
        -moz-border-radius: 15px;
    }
    .ratecarddiv
    {
        width: 47%;
        float: left;
        height: 66%;
        text-align: center;
        border: 1px solid #a9a9a9;
        margin: 12px auto;
        margin-right: 12px;
        background-color: White;
        color: Black ;
        padding: 10px;
        border-radius: 15px; 
        -moz-border-radius: 15px;
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
                    <div id="divReportParameter" runat="server" style="padding-bottom: 10px; padding-top: 10px;
                        padding-left: 10px; padding-right: 10px;">
                        <table width="100%" cellpadding="3" cellspacing="2" style="background-color: #fff;">
                            <tr>
                                <td style="width: 100px;">
                                    <asp:Literal ID="litAsOnDate" runat="server" Text="As On Date"></asp:Literal>
                                </td>
                                <td style="width: 230px;">
                                    <asp:TextBox ID="txtAsOnDate" runat="server" onkeypress="return false;" Style="width: 125px;
                                        height: 25px;"></asp:TextBox>
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
                                    <asp:TextBox ID="txtStartDate" runat="server" onkeypress="return false;" Style="width: 125px;
                                        height: 25px;"></asp:TextBox>
                                    <asp:Image ID="imgSColor" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                        Height="20px" Width="20px" />
                                    <ajx:CalendarExtender ID="calStartDate" runat="server" TargetControlID="txtStartDate"
                                        PopupButtonID="imgSColor">
                                    </ajx:CalendarExtender>
                                </td>
                                <td>
                                    <asp:Literal ID="litEndDate" runat="server" Text="To"></asp:Literal>
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkEndDate" runat="server" AutoPostBack="true" Text="" OnCheckedChanged="chkEndDate_CheckedChanged" />
                                    <asp:TextBox ID="txtEndDate" runat="server" onkeypress="return false;" Style="width: 125px;
                                        height: 25px;"></asp:TextBox>
                                    <asp:Image ID="imgEColor" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                        Height="20px" Width="20px" />
                                    <ajx:CalendarExtender ID="calEndDate" runat="server" TargetControlID="txtEndDate"
                                        PopupButtonID="imgEColor">
                                    </ajx:CalendarExtender>
                                </td>
                                <td>
                                    <div>
                                        <asp:Button ID="btnPreview" Text="View" Style="float: left; margin-left: 5px;" runat="server"
                                            EnableViewState="false" ImageUrl="~/images/save.png" OnClick="btnPreview_Click"
                                            OnClientClick="fnDisplayCatchErrorMessage()" />
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="dvDashBoard" runat="server" style="margin-top: 15px;">
                        <div align="right" style="margin-right: 38px;">
                            <asp:Button runat="server" ID="btnBackToParameter" Text="Back" OnClick="btnBackToParameter_Click"
                                Style="display: inline;" /></div>
                        <div class="corners">
                            <div>
                                <b>Occupancy By Gender</b></div>
                            <asp:Chart ID="chartByGender" runat="server" Width="278px">
                                <Series>
                                    <asp:Series ChartType="Pie" Legend="legendByGender" Name="seriesByGender" IsValueShownAsLabel="true">
                                    </asp:Series>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="chartAreaByGender" Area3DStyle-Enable3D="true">
                                        <Area3DStyle Enable3D="True" />
                                    </asp:ChartArea>
                                </ChartAreas>
                                <Legends>
                                    <asp:Legend Name="legendByGender">
                                    </asp:Legend>
                                </Legends>
                            </asp:Chart>
                        </div>
                        <div class="corners">
                            <div>
                                <b>Occupancy By Food preference</b></div>
                            <asp:Chart ID="chartBymealpreference" runat="server" Width="278px">
                                <Series>
                                    <asp:Series ChartType="Pie" Legend="legendByMealPreference" Name="seriesByPreference"
                                        ToolTip="#VAL" IsValueShownAsLabel="true">
                                    </asp:Series>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="chartAreaByMealPreference" Area3DStyle-Enable3D="true">
                                        <Area3DStyle Enable3D="True" />
                                    </asp:ChartArea>
                                </ChartAreas>
                                <Legends>
                                    <asp:Legend Name="legendByMealPreference">
                                    </asp:Legend>
                                </Legends>
                            </asp:Chart>
                        </div>
                        <div class="corners">
                            <div>
                                <b>Occupancy By Sector</b></div>
                            <asp:Chart ID="chartCompanySector" runat="server" Width="278px">
                                <Series>
                                    <asp:Series ChartType="Pie" Legend="legendByCompanySector" Name="seriesByCompanySector"
                                        ToolTip="#VAL" IsValueShownAsLabel="true">
                                    </asp:Series>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="chartAreaByCompanySector" Area3DStyle-Enable3D="true">
                                        <Area3DStyle Enable3D="True" />
                                    </asp:ChartArea>
                                </ChartAreas>
                                <Legends>
                                    <asp:Legend Name="legendByCompanySector">
                                    </asp:Legend>
                                </Legends>
                            </asp:Chart>
                        </div>
                        <div class="corners">
                            <div>
                                <b>Occupancy By Working time</b></div>
                            <asp:Chart ID="chartByWorkingTime" runat="server" Width="278px">
                                <Series>
                                    <asp:Series ChartType="Pie" Legend="legendByWorkingTime" Name="seriesByWorkingTime"
                                        ToolTip="#VAL" IsValueShownAsLabel="true">
                                    </asp:Series>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="chartAreaByWorkingTime" Area3DStyle-Enable3D="true">
                                        <Area3DStyle Enable3D="True" />
                                    </asp:ChartArea>
                                </ChartAreas>
                                <Legends>
                                    <asp:Legend Name="legendByWorkingTime">
                                    </asp:Legend>
                                </Legends>
                            </asp:Chart>
                        </div>
                        <div class="corners">
                            <div>
                                <b>Occupancy By Billing Instruction</b></div>
                            <asp:Chart ID="chartByBillingInstruction" runat="server" Width="278px">
                                <Series>
                                    <asp:Series ChartType="Pie" Legend="legendByBillingInstruction" Name="seriesByBillingInstruction"
                                        ToolTip="#VAL" IsValueShownAsLabel="true">
                                    </asp:Series>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="chartAreaByBillingInstruction" Area3DStyle-Enable3D="true">
                                        <Area3DStyle Enable3D="True" />
                                    </asp:ChartArea>
                                </ChartAreas>
                                <Legends>
                                    <asp:Legend Name="legendByBillingInstruction">
                                    </asp:Legend>
                                </Legends>
                            </asp:Chart>
                        </div>
                        <div class="corners">
                            <div>
                                <b>Occupancy By Reservation Type</b></div>
                            <asp:Chart ID="chartByReservationType" runat="server" Width="278px">
                                <Series>
                                    <asp:Series ChartType="Pie" Legend="legendByReservationType" Name="seriesByReservationType"
                                        ToolTip="#VAL" IsValueShownAsLabel="true">
                                    </asp:Series>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="chartAreaByReservationType" Area3DStyle-Enable3D="true">
                                        <Area3DStyle Enable3D="True" />
                                    </asp:ChartArea>
                                </ChartAreas>
                                <Legends>
                                    <asp:Legend Name="legendByReservationType">
                                    </asp:Legend>
                                </Legends>
                            </asp:Chart>
                        </div>
                        <div class="ratecarddiv">
                            <div>
                                <b>Occupancy By Rate card</b></div>
                            <asp:Chart ID="chartByRateCard" runat="server" Width="550px">
                                <Series>
                                    <asp:Series ChartType="Column" Legend="legendByRateCard" Name="By Rate Card"
                                        ToolTip="#VAL" IsValueShownAsLabel="true">
                                    </asp:Series>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="chartAreaByRateCard" Area3DStyle-Enable3D="true">
                                        <Area3DStyle Enable3D="True" />
                                    </asp:ChartArea>
                                </ChartAreas>
                                <Legends>
                                    <asp:Legend Name="legendByRateCard">
                                    </asp:Legend>
                                </Legends>
                            </asp:Chart>
                        </div>
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
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
