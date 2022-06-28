<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlDashBoardOccupationStatus.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.DashBoard.CtrlDashBoardOccupationStatus" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBoxProspects" TagPrefix="ucP" %>
<%--<%@ Register Assembly="System.Web.DataVisualization" Namespace="System.Web.UI.DataVisualization.Charting"
    TagPrefix="asp" %>--%>
<script language="javascript" type="text/javascript">
    function fnDisplayCatchErrorMessageForOccupation() {
        document.getElementById('errormessageOccupation').style.display = "block";
    }
</script>
<script type="text/javascript" language="javascript">
    function fnPrintPage() {
        document.getElementById('dvToHide').style.display = 'none';
        window.print();
    }
</script>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box" style="height: 100%;
            min-width: 225px;">
            <tr>
                <td class="boxtopleft">
                    &nbsp;
                </td>
                <td class="boxtopcenter">
                    <asp:Label ID="lblHeaderQuarterTitle" runat="server" ></asp:Label><a href="#"><img
                        alt="View" src="../../images/box_arrow.jpg" /></a>
                </td>
                <td class="boxtopright">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="boxleft">
                    &nbsp;
                </td>
                <td style="vertical-align: top;">
                    <div style="min-height: 175px;">
                        <%--<asp:GridView ID="gvProspects" runat="server" ShowHeader="false" Width="100%" AutoGenerateColumns="false"
                SkinID="gvNoPaging">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <div class="box_content">
                                <ul class="box_contentlist">
                                    <li>Name: <span>
                                        <%#DataBinder.Eval(Container.DataItem, "PropertyName")%></span></li>
                                    <li>Status: <span>
                                        <%#DataBinder.Eval(Container.DataItem, "RoomNo")%></span></li>
                                </ul>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <div class="pagecontent_info">
                        <div class="NoItemsFound">
                            <h2>
                                <asp:Literal ID="litNoRecordFound" runat="server" Text="No Record Found"></asp:Literal></h2>
                        </div>
                    </div>
                </EmptyDataTemplate>
            </asp:GridView>--%>
                        <table width="100%" cellpadding="3" cellspacing="2" style="background-color: #fff;">
                            <tr>
                                <td style="width: 150px;">
                                    <asp:Literal ID="litAsOnDate" runat="server" Text="As on Date"></asp:Literal>
                                </td>
                                <td style="width: 300px;">
                                    <asp:TextBox ID="txtAsOnDate" runat="server" onkeypress="return false;" Enabled="false" SkinID="Search"></asp:TextBox>
                                    <asp:Image ID="imgAsColor" CssClass="small_img" Visible="false" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                        Height="20px" Width="20px" />
                                    <ajx:CalendarExtender ID="calAsOnDate" runat="server" TargetControlID="txtAsOnDate"
                                        PopupButtonID="imgAsColor" Enabled="false">
                                    </ajx:CalendarExtender>
                                </td>
                                <td>
                                    <asp:Button ID="btnAsPrint" Text="View" Style="float: left; margin-left: 5px;" Visible="false" runat="server"
                                        EnableViewState="false" ImageUrl="~/images/save.png" OnClick="btnAsPrint_Click"
                                        OnClientClick="fnDisplayCatchErrorMessage()" />
                                </td>
                                <td>
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
                            <tr style="display: none;">
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
                            </tr>
                            <tr style="display: none;">
                                <td style="width: 50px;">
                                    <asp:Literal ID="litEndDate" runat="server" Text="To"></asp:Literal>
                                </td>
                                <td style="width: 300px;">
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
                            <tr style="padding-top: 20px;">
                                <td style="width: 110px;">
                                    <asp:Literal ID="Literal3" runat="server" Text="No. of Beds"></asp:Literal>
                                </td>
                                <td style="width: 300px; color: #3f98c6;">
                                    :&nbsp;<asp:Label ID="lblNoOfBeds" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr style="padding-top: 20px;">
                                <td>
                                    <asp:Literal ID="litNoOfBedsoccupied" runat="server" Text="Beds occupied"></asp:Literal>
                                </td>
                                <td style="width: 300px; color: #3f98c6;">
                                    :&nbsp;<asp:Label ID="lblNumberOfBedsOccupied" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr style="padding-top: 20px;">
                                <td>
                                    <asp:Literal ID="Literal4" runat="server" Text="Occupancy %"></asp:Literal>
                                </td>
                                <td style="width: 300px; color: #3f98c6;">
                                    :&nbsp;<asp:Label ID="lblOccupancyPercentage" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr style="padding-top: 30px;">
                                <td>
                                    <asp:Literal ID="Literal5" runat="server" Text="Rent Income (Current Qtr.)"></asp:Literal>
                                </td>
                                <td style="width: 300px; color: #3f98c6;">
                                    :&nbsp;<asp:Label ID="lblRentIncomeForCurrentQtr" runat="server"></asp:Label>
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
    </Triggers>
</asp:UpdatePanel>
<div id="errormessageOccupation" class="clear" style="display: none;">
    <ucP:MsgBoxProspects ID="MessageBox" runat="server" />
</div>
<ajx:ModalPopupExtender ID="mpeOccupancy" runat="server" TargetControlID="hdnOCcupancy"
    PopupControlID="pnlOccupancy" BackgroundCssClass="mod_background" BehaviorID="mpeOccupancy">
</ajx:ModalPopupExtender>
<asp:HiddenField ID="hdnOccupancy" runat="server" />
<asp:Panel ID="pnlOccupancy" runat="server" Width="800px" Height="420px" Style="display: none;
    background-color: White;">
    <div class="box_col1">
        <div class="boxhead">
            <div style="float: left;">
                <asp:Literal ID="Literal1" Text="Occupancy Report" runat="server"></asp:Literal></div>
            <div style="float: right;">
                <asp:ImageButton ImageUrl="~/images/clear.png" Style="padding-top: 5px; padding-right: 10px;
                    border: none;" runat="server" OnClientClick="javascript:window.close();" />
            </div>
        </div>
        <div class="clear">
        </div>
        <div class="box_form">
            <table cellpadding="2" cellspacing="2" width="100%" border="0">
                <tr>
                    <td style="padding-bottom: 15px; border: 0px;">
                        <div style="padding-bottom: 5px; text-align: center;">
                            <%--  <div style="font-family: Arial; font-weight: bold; font-size: 18pt;">
                                <asp:Literal ID="litCompanyName" Text="" runat="server"></asp:Literal>
                            </div>--%>
                            <div style="height: 10px;">
                            </div>
                            <div style="font-family: Arial; font-weight: bold; font-size: 14pt;">
                                <asp:Literal ID="Literal2" Text="Occupancy Report" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <table cellpadding="2" cellspacing="2" width="100%">
                            <tr>
                                <td style="border: 0px;">
                                    <div id="dvToHide" style="padding-bottom: 10px; padding-top: 10px; padding-left: 10px;
                                        padding-right: 10px; display: none;">
                                        <asp:Button ID="btnPrint" runat="server" Text="Print" Style="float: left; margin-left: 5px;
                                            margin-right: 5px;" CssClass="button1" OnClientClick="return fnPrintPage();" />
                                        <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="button1" OnClientClick="javascript:window.close();" />
                                    </div>
                                    <asp:Label ID="lblFromDate" runat="server" Font-Bold="true"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="lblToDate" runat="server" Font-Bold="true"></asp:Label>
                                    <div style="padding-bottom: 10px; padding-top: 10px; padding-left: 10px; padding-right: 10px;
                                        height: 10px;" />
                                    <div style="width: 100%; background-color: White; text-align: center;">
                                        <%--<asp:Chart ID="chartOccupancy" runat="server" Height="260px" Width="391px" BorderlineWidth="1"
                                            BorderlineColor="Black">
                                            <Series>
                                                <asp:Series ChartType="Pie" XValueMember="Section" YValueMembers="Absentees" Legend="Legend1"
                                                    IsValueShownAsLabel="True" Name="Default">
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
                                        </asp:Chart>--%>
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
