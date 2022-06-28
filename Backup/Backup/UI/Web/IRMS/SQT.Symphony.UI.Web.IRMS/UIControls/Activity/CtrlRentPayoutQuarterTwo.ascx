<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlRentPayoutQuarterTwo.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.Activity.CtrlRentPayoutQuarterTwo" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
    function openViewerForPrint() {
        window.open("../Activity/InvestorRentPayoutPrint.aspx");
    }
    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }
</script>
<style type="text/css">
    #progressBackgroundFilter
    {
        position: fixed;
        top: 0px;
        width: 100%;
        height: 100%;
        bottom: 0px;
        left: 0px;
        right: 0px;
        overflow: hidden;
        padding: 0;
        margin: 0;
        background-color: #000;
        filter: alpha(opacity=50);
        opacity: 0.5;
        z-index: 1111111;
    }
    #processMessage
    {
        position: fixed;
        top: 50%;
        left: 50%;
        padding: 10px;
        width: 30px;
        border-radius: 10px;
        z-index: 1111112;
        background-color: #fff;
        border: solid 1px #efefef;
    }
</style>
<asp:UpdatePanel ID="updRentPayuot" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height: 473px;">
            <tr>
                <td class="content" style="padding-left: 0px; width: 66.66%">
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
                                <asp:MultiView ID="mvRentPayout" runat="server">
                                    <asp:View ID="vRentPayout" runat="server">
                                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                            <tr>
                                                <td class="dTableBox" style="padding: 10px 0px 10px 0px;">
                                                    <div style="overflow: auto; width: 735px; height: 350px;">
                                                        <style type="text/css">
                                                            .mGrid td.topalign
                                                            {
                                                                vertical-align: top;
                                                            }
                                                        </style>
                                                        <asp:GridView ID="gvRentPayout" runat="server" AutoGenerateColumns="false" ShowHeader="false"
                                                            Width="100%" OnRowCommand="gvRentPayout_RowCommand">
                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <div style="float: left; margin-top: 5px;">
                                                                            &nbsp;<%# DataBinder.Eval(Container.DataItem, "Year")%></div>
                                                                        <div class="dTableBox" style="border: none; margin-top: 25px;">
                                                                            <asp:GridView ID="gvInnerGridRentPayout" runat="server" Width="100%" ShowHeader="true"
                                                                                AutoGenerateColumns="false">
                                                                                <Columns>
                                                                                    <asp:TemplateField ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblGvHdrQ1" runat="server" Text="Q1"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkQ1" runat="server" CommandName="details" Text='<%#DataBinder.Eval(Container.DataItem, "Q1")%>'
                                                                                                CommandArgument='<%#DataBinder.Eval(Container.DataItem, "Q1")%>'></asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblGvHdrQ2" runat="server" Text="Q2"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkQ2" CommandName="details" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Q2")%>'
                                                                                                CommandArgument='<%#DataBinder.Eval(Container.DataItem, "Q2")%>'></asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblGvHdrQ3" runat="server" Text="Q3" ToolTip="Available"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkQ3" CommandName="details" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Q3")%>'
                                                                                                CommandArgument='<%#DataBinder.Eval(Container.DataItem, "Q3")%>'></asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblGvHdrQ4" runat="server" Text="Q4" ToolTip="Out of Service"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkQ4" CommandName="details" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Q4")%>'
                                                                                                CommandArgument='<%#DataBinder.Eval(Container.DataItem, "Q4")%>'></asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                                <EmptyDataTemplate>
                                                                                    <div style="padding: 10px;">
                                                                                        <b>
                                                                                            <asp:Label ID="lblGRNoRecordFound" runat="server" Text="No Record Found."></asp:Label>
                                                                                        </b>
                                                                                    </div>
                                                                                </EmptyDataTemplate>
                                                                            </asp:GridView>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EmptyDataTemplate>
                                                                <div style="padding: 10px;">
                                                                    <b>
                                                                        <asp:Label ID="lblGRNoRecordFound" runat="server" Text="No Record Found."></asp:Label>
                                                                    </b>
                                                                </div>
                                                            </EmptyDataTemplate>
                                                        </asp:GridView>
                                                    </div>
                                                </td>
                                                <%--</div>
                                        </td>--%>
                                            </tr>
                                        </table>
                                    </asp:View>
                                    <asp:View ID="vRentPayoutQuarterList" runat="server">
                                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                            <tr>
                                                <td class="dTableBox" style="padding: 10px 0px 10px 0px;">
                                                    <div style="overflow: auto; width: 735px; height: 350px;">
                                                        <style type="text/css">
                                                            .mGrid td.topalign
                                                            {
                                                                vertical-align: top;
                                                            }
                                                        </style>
                                                        <asp:DataList ID="dlRentPayOutQuarter" runat="server" CellPadding="0" CellSpacing="5"
                                                            RepeatDirection="Horizontal" RepeatColumns="4" OnItemDataBound="dlRentPayOutQuarter_ItemDataBound"
                                                            OnItemCommand="dlRentPayOutQuarter_ItemCommand">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblQuarterTitle" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Title")%>'></asp:Label></br>
                                                                <asp:LinkButton ID="lnkToViewQuarterDetail" CommandName="QUARTERDETAILS" runat="server"
                                                                    CommandArgument='<%#DataBinder.Eval(Container.DataItem, "QuarterID")%>'></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:DataList>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:View>
                                    <asp:View ID="vListRentPayout" runat="server">
                                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                            <tr>
                                                <td style="width: 39%; border-right: 1px solid #ccccce;">
                                                    <table border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td style="width: 85px;">
                                                                <asp:Literal ID="litPeriodFrom" Text="Period From :" runat="server"></asp:Literal>
                                                            </td>
                                                            <td style="width: 90px;">
                                                                <asp:Literal ID="litDisplayPeriodFrom" runat="server"></asp:Literal>
                                                            </td>
                                                            <td style="width: 30px;">
                                                                <asp:Literal ID="litTo" runat="server" Text="To :"></asp:Literal>
                                                            </td>
                                                            <td style="padding-right: 5px;">
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
                                                <td style="width: 35%; border-right: 1px solid #ccccce;">
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
                                                            <td style="padding-left: 10px;">
                                                                <b>E) Less :</b>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding-left: 24px;">
                                                                <b>(1)</b>&nbsp;
                                                                <asp:Literal ID="litLessPropertyManegefees" Text=" Property Mgmt. fees:" runat="server"></asp:Literal>
                                                                &nbsp;<b>(<asp:Literal ID="litDisppropertymangeper" Text="" runat="server"></asp:Literal>
                                                                    % of (D))</b>
                                                            </td>
                                                            <td style="text-align: right; ">
                                                                <asp:Literal ID="litDisplayLessPropertyManegefees" runat="server" Text="250"></asp:Literal>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding-left: 24px;">
                                                                <b>(2)</b>&nbsp;&nbsp;Service tax on Property Mgmt. fees @ 12.36%
                                                            </td>
                                                            <td style="text-align: right;">
                                                                <asp:Literal ID="ltrServiceTax" runat="server" Text="250"></asp:Literal>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding-left: 24px; border-bottom: 1px solid #ccccce;">
                                                                <b>(3)</b>&nbsp;&nbsp;Credit Card / Bank Charges
                                                            </td>
                                                            <td style="text-align: right; border-bottom: 1px solid #ccccce;">
                                                                <asp:Literal ID="ltrBankCharges" runat="server" Text="250"></asp:Literal>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding-left: 10px; border-bottom: 1px solid #ccccce;">
                                                                <b>F)</b>&nbsp;Total amount to deduct <b>(1+2+3)</b>
                                                            </td>
                                                            <td style="text-align: right; border-bottom: 1px solid #ccccce;">
                                                                <asp:Label ID="ltrTotalAmountToDeduct" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding-left: 10px; border-bottom: 1px solid #ccccce;">
                                                                <b>G)</b>
                                                                <asp:Literal ID="litTotalAmountTodistribute" Text=" Room rent to distribute" runat="server"></asp:Literal>
                                                                <b>(D - F)</b>
                                                            </td>
                                                            <td style="text-align: right; border-bottom: 1px solid #ccccce;">
                                                                <asp:Literal ID="litDispTotalAmountTodistribute" runat="server"></asp:Literal>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding-left: 10px; border-bottom: 1px solid #ccccce;">
                                                                <b>H)</b>
                                                                <asp:Literal ID="litInterestOnRoomRent" Text=" Interest earned for the period" runat="server"></asp:Literal>
                                                            </td>
                                                            <td style="text-align: right; border-bottom: 1px solid #ccccce;">
                                                                <asp:Literal ID="litDispInterestOnRoomRent" runat="server"></asp:Literal>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding-left: 10px; border-bottom: 1px solid #ccccce;">
                                                                <b>I)</b>
                                                                <asp:Literal ID="litRentToDistributed" Text=" Net amount to be distributed&nbsp;<b>(G + H)</b>"
                                                                    runat="server"></asp:Literal>
                                                            </td>
                                                            <td style="text-align: right; border-bottom: 1px solid #ccccce;">
                                                                <asp:Literal ID="litDisplayRentToDistributed" runat="server"></asp:Literal>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding-left: 10px; border-bottom: 1px solid #ccccce;">
                                                                <b>J)</b>
                                                                <asp:Literal ID="litRentYieldPerSFT" Text=" Rent yield per Sft for period&nbsp;<b>(I/C)</b> :"
                                                                    runat="server"></asp:Literal>
                                                            </td>
                                                            <td style="text-align: right; border-bottom: 1px solid #ccccce;">
                                                                <asp:Literal ID="litDisplayRentYieldPerSFT" runat="server"></asp:Literal>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding-left: 10px; border-bottom: 1px solid #ccccce;">
                                                                <b>K)</b>
                                                                <asp:Literal ID="litRentYieldPerDay" Text=" Rent yield per Sft / day :" runat="server"></asp:Literal>
                                                                &nbsp;<asp:Literal ID="litPercRentYieldPerDay" Text="<b>(J / No. of days)</b>" runat="server"></asp:Literal>
                                                            </td>
                                                            <td style="text-align: right; border-bottom: 1px solid #ccccce;">
                                                                <asp:Literal ID="litDisplayRentYieldPerDay" runat="server"></asp:Literal>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" class="dTableBox" style="padding: 10px 0px;">
                                                    <asp:GridView ID="gvAdminRendPayoutDetails" runat="server" ShowHeader="true" ShowFooter="true"
                                                        AutoGenerateColumns="false" OnRowDataBound="gvAdminRendPayoutDetails_RowDatabound">
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
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" align="right" valign="middle" style="padding-top: 15px;">
                                                    <table>
                                                        <tr>
                                                            <td style="padding-right: 10px; padding-top: 5px;">
                                                                <a id="ancViewCertificate" runat="server" target="_blank" style="color: #0067a4;
                                                                    font-weight: bold; cursor: pointer;">CA Certificate</a>
                                                                <%--<asp:LinkButton ID="lnkViewCertificate" runat="server" ForeColor="#0067a4" Text="View Certificate"></asp:LinkButton>--%>
                                                            </td>
                                                            <td style="padding-right: 10px;">
                                                                <asp:Button ID="btnBackToQuarterList" Text="Back To List" runat="server" ImageUrl="~/images/save.png"
                                                                    OnClick="btnBackToQuarterList_Click" />
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnPrint" Text="Print" runat="server" ImageUrl="~/images/cancle.png" Visible="false"
                                                                    OnClientClick="fnDisplayCatchErrorMessage()" Style="display: inline-block;" OnClick="btnPrint_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:View>
                                </asp:MultiView>
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
        </table>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnPrint" />
    </Triggers>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updRentPayuot" ID="updateprogressRentPayout"
    runat="server">
    <ProgressTemplate>
        <div id="progressBackgroundFilter">
        </div>
        <div id="processMessage">
            <center>
                <img src="../../images/ajax-loader.gif" /></center>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>