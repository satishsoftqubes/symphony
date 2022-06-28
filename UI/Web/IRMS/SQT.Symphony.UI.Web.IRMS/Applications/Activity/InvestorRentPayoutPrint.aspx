<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InvestorRentPayoutPrint.aspx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.Applications.Activity.InvestorRentPayoutPrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../Style/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function fnPrint() {
            document.getElementById('dvToHide').style.display = 'none';
            window.print();
            window.close();
        }</script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin: 25px 25px 25px 25px;">
        <table width="65%" border="0" cellspacing="0" cellpadding="0" style="height: 550px;">
            <tr>
                <td class="content" style="padding-left: 0px; width: 100%">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                Rent Payout
                            </td>
                            <td class="boxtopright">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="boxleft">
                                &nbsp;
                            </td>
                            <td style="padding-top: 10px;">
                                <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                    <tr>
                                        <td style="width: 42%; border-right: 1px solid #ccccce;">
                                            <table border="0" cellpadding="0" cellspacing="0" style="vertical-align: top;">
                                                <tr>
                                                    <td style="width: 80px;">
                                                        <asp:Literal ID="litPeriodFrom" Text="Period From :" runat="server"></asp:Literal>
                                                    </td>
                                                    <td style="width: 80px;">
                                                        <asp:Literal ID="litDisplayPeriodFrom" runat="server"></asp:Literal>
                                                    </td>
                                                    <td style="width: 30px;">
                                                        <asp:Literal ID="litTo" runat="server" Text="To :"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="litDisplayTo" runat="server"></asp:Literal>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td style="padding-left: 10px;">
                                            <asp:Literal ID="litNoOfays" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <hr />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" style="width: 35%; border-right: 1px solid #ccccce;">
                                            <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                <tr>
                                                    <td style="border-bottom: 1px solid #ccccce;">
                                                        <b>A)</b>
                                                        <asp:Literal ID="litTotalAreaOfComplex" Text=" Total Area of Complex <b>(Sft)</b> :"
                                                            runat="server"></asp:Literal>
                                                    </td>
                                                    <td style="text-align: right; padding-right: 17px; border-bottom: 1px solid #ccccce;">
                                                        <asp:Literal ID="litDisplayTotalAreaOfComplex" runat="server"></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr style="border-bottom: 1px solid #ccccce;">
                                                    <td style="border-bottom: 1px solid #ccccce;">
                                                        <b>B)</b>
                                                        <asp:Literal ID="litSelfOccupiedArea" Text=" Less Self Occupied Area <b>(Sft)</b> :"
                                                            runat="server"></asp:Literal>
                                                    </td>
                                                    <td style="text-align: right; padding-right: 17px; border-bottom: 1px solid #ccccce;">
                                                        <asp:Literal ID="litDisplaySelfOccupiedArea" runat="server"></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr style="border-bottom: 1px solid #ccccce;">
                                                    <td style="border-bottom: 1px solid #ccccce;">
                                                        <b>C)</b>
                                                        <asp:Literal ID="litNetAreaUnderPMS" Text=" Net Area under PMS <b>(Sft)</b> :" runat="server"></asp:Literal>
                                                    </td>
                                                    <td style="text-align: right; padding-right: 17px; border-bottom: 1px solid #ccccce;">
                                                        <asp:Literal ID="litDisplayNetAreaUnderPMS" runat="server"></asp:Literal>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                <tr>
                                                    <td style="width: 300px; padding-left: 10px; border-bottom: 1px solid #ccccce;">
                                                        <b>D)</b>
                                                        <asp:Literal ID="litRoomRentForPeriod" Text=" Room rent collected for the period :"
                                                            runat="server"></asp:Literal>
                                                    </td>
                                                    <td style="text-align: right; border-bottom: 1px solid #ccccce;">
                                                        <asp:Literal ID="litDisplayRoomRentForPeriod" runat="server"></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-left: 10px; border-bottom: 1px solid #ccccce;">
                                                        <b>E)</b>&nbsp;&nbsp;Less Credit Card / Bank Charges
                                                    </td>
                                                    <td style="text-align: right; border-bottom: 1px solid #ccccce;">
                                                        <asp:Literal ID="ltrBankCharges" runat="server" Text="250"></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-left: 10px; border-bottom: 1px solid #ccccce;">
                                                        <b>F)</b>&nbsp;Remaining Room rent <b>(D - E)</b>
                                                    </td>
                                                    <td style="text-align: right; border-bottom: 1px solid #ccccce;">
                                                        <asp:Label ID="lblRemainingRoomRent" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-left: 10px;">
                                                        <b>G) Less :</b>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-left: 24px;">
                                                        <b>(1)</b>&nbsp;
                                                        <asp:Literal ID="litLessPropertyManegefees" Text=" Property Mgmt. fees:" runat="server"></asp:Literal>
                                                        &nbsp;<b>(<asp:Literal ID="litDisppropertymangeper" Text="" runat="server"></asp:Literal>
                                                            % of (F))</b>
                                                    </td>
                                                    <td style="text-align: right;">
                                                        <asp:Literal ID="litDisplayLessPropertyManegefees" runat="server" Text="250"></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-left: 24px; border-bottom: 1px solid #ccccce;">
                                                        <b>(2)</b>&nbsp;&nbsp;Service tax on Property Mgmt. fees @ 12.36%
                                                    </td>
                                                    <td style="text-align: right; border-bottom: 1px solid #ccccce;">
                                                        <asp:Literal ID="ltrServiceTax" runat="server" Text="250"></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-left: 10px; border-bottom: 1px solid #ccccce;">
                                                        <b>H)</b>&nbsp;Total amount to deduct <b>(1+2)</b>
                                                    </td>
                                                    <td style="text-align: right; border-bottom: 1px solid #ccccce;">
                                                        <asp:Label ID="ltrTotalAmountToDeduct" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-left: 10px; border-bottom: 1px solid #ccccce;">
                                                        <b>I)</b>
                                                        <asp:Literal ID="litTotalAmountTodistribute" Text=" Room rent to distribute" runat="server"></asp:Literal>
                                                        <b>(F - H)</b>
                                                    </td>
                                                    <td style="text-align: right; border-bottom: 1px solid #ccccce;">
                                                        <asp:Literal ID="litDispTotalAmountTodistribute" runat="server"></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-left: 10px; border-bottom: 1px solid #ccccce;">
                                                        <b>J)</b>
                                                        <asp:Literal ID="litInterestOnRoomRent" Text=" Interest earned for the period" runat="server"></asp:Literal>
                                                    </td>
                                                    <td style="text-align: right; border-bottom: 1px solid #ccccce;">
                                                        <asp:Literal ID="litDispInterestOnRoomRent" runat="server"></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-left: 10px; border-bottom: 1px solid #ccccce;">
                                                        <b>K)</b>
                                                        <asp:Literal ID="litRentToDistributed" Text=" Net amount to be distributed&nbsp;<b>(I + J)</b>"
                                                            runat="server"></asp:Literal>
                                                    </td>
                                                    <td style="text-align: right; border-bottom: 1px solid #ccccce;">
                                                        <asp:Literal ID="litDisplayRentToDistributed" runat="server"></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-left: 10px; border-bottom: 1px solid #ccccce;">
                                                        <b>L)</b>
                                                        <asp:Literal ID="litRentYieldPerSFT" Text=" Rent yield per Sft for period&nbsp;<b>(K/C)</b> :"
                                                            runat="server"></asp:Literal>
                                                    </td>
                                                    <td style="text-align: right; border-bottom: 1px solid #ccccce;">
                                                        <asp:Literal ID="litDisplayRentYieldPerSFT" runat="server"></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-left: 10px; border-bottom: 1px solid #ccccce;">
                                                        <b>M)</b>
                                                        <asp:Literal ID="litRentYieldPerDay" Text=" Rent yield per Sft / day :" runat="server"></asp:Literal>
                                                        &nbsp;<asp:Literal ID="litPercRentYieldPerDay" Text="<b>(L / No. of days)</b>" runat="server"></asp:Literal>
                                                    </td>
                                                    <td style="text-align: right; border-bottom: 1px solid #ccccce;">
                                                        <asp:Literal ID="litDisplayRentYieldPerDay" runat="server"></asp:Literal>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" class="dTableBox" style="padding: 10px 0px;">
                                            <div style="width: 100%; overflow: auto;">
                                                <asp:GridView ID="gvAdminRendPayoutDetails" runat="server" Width="700px" Height="175px"
                                                    ShowHeader="true" ShowFooter="true" AutoGenerateColumns="false" OnRowDataBound="gvAdminRendPayoutDetails_RowDatabound">
                                                    <Columns>
                                                        <asp:TemplateField ItemStyle-Width="70px" FooterStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                            ItemStyle-HorizontalAlign="Center">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrUnitNo" runat="server" Text="Unit No"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%#DataBinder.Eval(Container.DataItem, "RoomNo")%>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <b>
                                                                    <asp:Literal ID="litTotal" runat="server" Text="Total"></asp:Literal></b>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField FooterStyle-HorizontalAlign="Right" ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Right"
                                                            ItemStyle-HorizontalAlign="Right">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrSFT" runat="server" Text="Sft"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%#DataBinder.Eval(Container.DataItem, "TotalSqft")%>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <b>
                                                                    <asp:Literal ID="litTotalSFT" runat="server"></asp:Literal></b>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField FooterStyle-HorizontalAlign="Left" ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Left"
                                                            ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrStartDate" runat="server" Text="Start Date"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%#DataBinder.Eval(Container.DataItem, "StartDate")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField FooterStyle-HorizontalAlign="Left" ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Left"
                                                            ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrEndDate" runat="server" Text="End Date"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%#DataBinder.Eval(Container.DataItem, "EndDate")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField FooterStyle-HorizontalAlign="Center" ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Right"
                                                            ItemStyle-HorizontalAlign="Right">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrNoofDays" runat="server" Text="No. of Days"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%#DataBinder.Eval(Container.DataItem, "NoofDays")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField FooterStyle-HorizontalAlign="Center" ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Right"
                                                            ItemStyle-HorizontalAlign="Right">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrYieldPerDay" runat="server" Text="Yield/Day"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%#DataBinder.Eval(Container.DataItem, "YieldPerDay")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField FooterStyle-HorizontalAlign="Center" ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Right"
                                                            ItemStyle-HorizontalAlign="Right">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrYieldPersft" runat="server" Text="Yield/sft"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%#DataBinder.Eval(Container.DataItem, "RentYieldPerSqft")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField FooterStyle-HorizontalAlign="Right" ItemStyle-Width="90px" HeaderStyle-HorizontalAlign="Right"
                                                            ItemStyle-HorizontalAlign="Right">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrYieldAmount" runat="server" Text="Yield Amount"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%#DataBinder.Eval(Container.DataItem, "YieldAmount")%>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <b>
                                                                    <asp:Literal ID="litTotalYieldAmount" runat="server"></asp:Literal></b>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
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
                </td>
            </tr>
            <tr>
                <td>
                    <div id="dvToHide" style="padding-bottom: 10px; padding-top: 10px; padding-left: 10px;
                        padding-right: 10px;" align="center">
                        <asp:Button ID="btnPrintRentPayoutInList" runat="server" Style="display: inline;"
                            Text="Print" OnClientClick="fnPrint();" />
                    </div>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
