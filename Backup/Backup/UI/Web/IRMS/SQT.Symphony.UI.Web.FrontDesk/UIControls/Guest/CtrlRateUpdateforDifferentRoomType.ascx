<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlRateUpdateforDifferentRoomType.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Guest.CtrlRateUpdateforDifferentRoomType" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">
    function openMyWindow() {
        var hdnReservationID = document.getElementById('<%= hdnReservationID.ClientID %>').value;
        window.open("UpgradeDownGradePrint.aspx?id=" + hdnReservationID + "&Operation=yes", "RegistrationVouche", "height=600,width=750,status=1,toolbar=no,menubar=no,scrollbars=1,location=0");
    }
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<ajx:ModalPopupExtender ID="mpeRate" runat="server" TargetControlID="hdnRate" PopupControlID="pnlRate"
    BackgroundCssClass="mod_background">
</ajx:ModalPopupExtender>
<asp:HiddenField ID="hdnRate" runat="server" />
<asp:HiddenField ID="hdnReservationID" runat="server" />
<asp:Panel ID="pnlRate" runat="server" Width="600px" Style="display: none;">
    <div class="box_col1">
        <div class="box_head">
            <div style="display: inline;">
                <span>
                    <asp:Literal ID="litQuickPostHeader" runat="server" Text="Upgrade/Downgrade Room"></asp:Literal></span>
            </div>
            <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                <asp:ImageButton ID="imgUpgradeCancel" runat="server" OnClick="imgUpgradeCancel_Click"
                    ImageUrl="~/images/closepopup.png" Style="border: 0px; width: 16px; height: 16px;
                    margin: -4px 0 0 5px; vertical-align: middle;" />
            </div>
        </div>
        <div class="clear">
        </div>
        <div class="box_form">
            <table border="0" cellpadding="2" cellspacing="2" width="100%">
                <tr>
                    <td style="width: 100px;">
                        <asp:Literal ID="litReservationNo" Text="Reservation No." runat="server"></asp:Literal>
                    </td>
                    <td style="width: 80px;">
                        <asp:Literal ID="litDspReservationNo" runat="server"></asp:Literal>
                    </td>
                    <td style="width: 75px;">
                        <asp:Literal ID="litRoomType" Text="Room Type" runat="server"></asp:Literal>&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:Literal ID="litDspRoomType" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="border-bottom: 1px solid #ccccce;">
                        <div class="box_head">
                            <span>
                                <asp:Literal ID="litExtendReservationList" runat="server" Text="Affected Days List"></asp:Literal>
                            </span>
                        </div>
                        <div class="clear">
                        </div>
                        <div class="box_content">
                            <div style="height: 270px; overflow: auto;">
                                <asp:GridView ID="gvRateUpdateForRoomType" runat="server" AutoGenerateColumns="false"
                                    ShowHeader="true" Width="100%" OnRowDataBound="gvResevationList_RowDataBound"
                                    SkinID="gvNoPaging">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-Width="30px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                            <HeaderTemplate>
                                                <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                            <HeaderTemplate>
                                                <asp:Label ID="lblGvHdrDate" runat="server" Text="Date"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblGvBlockDate" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "BlockDate")).ToString(clsSession.DateFormat)%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="120px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                            <HeaderTemplate>
                                                <asp:Label ID="lblGvHdrRMRate" runat="server" Text="RM Rate"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblGvRMTypeRMRate" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Right" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Right">
                                            <HeaderTemplate>
                                                <asp:Label ID="lblGvHdrTaxes" runat="server" Text="Taxes"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblGvRMTypeTax" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:TemplateField HeaderStyle-HorizontalAlign="Right" ItemStyle-Width="120px" Visible="false" ItemStyle-HorizontalAlign="Right">
                                            <HeaderTemplate>
                                                <asp:Label ID="lblGvHdrDiscount" runat="server" Text="Discount"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblGvRMTypeDiscount" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Right" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Right">
                                            <HeaderTemplate>
                                                <asp:Label ID="lblGvHdrTotal" runat="server" Text="Total"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblGvRMTypeTotal" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <div style="padding: 10px;">
                                            <b>
                                                <asp:Label ID="lblNoRecordFound" Text="No Record Found." runat="server"></asp:Label>
                                            </b>
                                        </div>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="center">
                        <table style="border: 1px solid #ccccce; background-color: #DCDDDF;" cellpadding="2"
                            cellspacing="2" width="70%">
                            <tr>
                                <td width="170px">
                                    <asp:Literal ID="litAvailabelBalance" runat="server" Text="Available Balance"></asp:Literal>
                                </td>
                                <td width="110px" align="right" style="padding-right: 40px;">
                                    <asp:Literal ID="litDispPreviousTotalRent" runat="server" Text="0.00"></asp:Literal>
                                </td>
                                <td width="120px">
                                    <asp:Literal ID="litPreviousDeposit" runat="server" Text="Previous Deposit"></asp:Literal>
                                </td>
                                <td width="90px" align="right">
                                    <asp:Literal ID="litDispPreviousTotalDeposit" runat="server" Text="0.00"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td style="border-bottom: 1px solid gray;">
                                    <asp:Literal ID="litNewRoomRent" runat="server" Text="New Room Rent"></asp:Literal>
                                </td>
                                <td style="border-bottom: 1px solid gray; padding-right: 40px;" align="right">
                                    <asp:Literal ID="litDispNewTotalRent" runat="server" Text="0.00"></asp:Literal>
                                </td>
                                <td style="border-bottom: 1px solid gray;">
                                    <asp:Literal ID="litNewDeposit" runat="server" Text="New Deposit"></asp:Literal>
                                </td>
                                <td style="border-bottom: 1px solid gray;" align="right">
                                    <asp:Literal ID="litDispNewTotalDeposit" runat="server" Text="0.00"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Literal ID="litRoomBalanceDue" runat="server" Text="Balance"></asp:Literal>
                                </td>
                                <td align="right" style="padding-right: 40px;">
                                    <asp:Literal ID="litDispRoomBalanceDueCredit" runat="server" Text="0.00"></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="litDepositBalanceDue" runat="server" Text="Balance (Due/Credit)"></asp:Literal>
                                </td>
                                <td align="right">
                                    <asp:Literal ID="litDispDepositBalanceDueCredit" runat="server" Text="0.00"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="padding-left: 100px;">
                                    <asp:Literal ID="litRoomRentDue" runat="server" Text="Room Rent"></asp:Literal>
                                </td>
                                <td colspan="2" align="right" style="padding-right: 110px;">
                                    <asp:Literal ID="litDispRoomRentDue" runat="server" Text="0.00"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="border-bottom: 1px solid gray; padding-left: 100px;">
                                    <asp:Literal ID="litDepositDue" runat="server" Text="Deposit"></asp:Literal>
                                </td>
                                <td colspan="2" align="right" style="border-bottom: 1px solid gray; padding-right: 110px;">
                                    <asp:Literal ID="litDispDepositDue" runat="server" Text="0.00"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="font-weight: bold; padding-left: 100px;">
                                    <asp:Literal ID="litNetBalance" runat="server" Text="Net Balance"></asp:Literal>
                                </td>
                                <td colspan="2" align="right" style="padding-right: 110px;">
                                    <asp:Literal ID="litDispNetBalance" runat="server" Text="0.00"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <div style="text-align: right; font-size: 11px;">
                                        NOTE: Any credit amount will be refund at the time of check out.
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr style="display: none;">
                    <td colspan="4" style="border: 1px solid #ccccce;">
                        <div style="float: right; text-align: right; width: 200px; background-color: #DCDDDF;
                            color: #0083CE; font-size: 15px; font-weight: bold; padding: 9px;">
                            <asp:Literal ID="litINRRs" runat="server" Text="Rs."></asp:Literal>
                            <asp:Literal ID="litTotal" runat="server" Text="0.00"></asp:Literal>
                            <br />
                            <asp:Literal ID="litINROld" runat="server" Text="Rs."></asp:Literal>
                            <asp:Literal ID="litOldTotal" runat="server" Text="0.00"></asp:Literal>
                            <br />
                            <asp:Literal ID="litINRBalanceDiff" runat="server" Text="Rs."></asp:Literal>
                            <asp:Literal ID="litBalanceDiff" runat="server" Text="0.00"></asp:Literal>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="right" colspan="4">
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" Style="display: inline;"
                            OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnQuickPost" runat="server" Text="Quick Post" Style="display: inline;"
                            Visible="false" />
                        <asp:Button ID="btnCancel" runat="server" Text="Update Without Rate Change" Style="display: inline;"
                            OnClick="btnCancel_Click" />
                        <asp:Button ID="btnUpgradeVoucherPrint" runat="server" Text="Print" Style="display: inline;"
                            OnClientClick="openMyWindow();" OnClick="btnUpgradeVoucherPrint_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="clear">
        </div>
    </div>
</asp:Panel>
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
