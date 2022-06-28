<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlRentPayoutDetail.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.Activity.CtrlRentPayoutDetail" %>
<script type="text/javascript" language="javascript">
    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }
</script>
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
                            <td>
                                <table border="0" cellpadding="2" cellspacing="2">
                                    <tr>
                                        <td style="width: 95px;">
                                            <asp:Literal ID="litPeriodFrom" Text="Period From" runat="server"></asp:Literal>
                                        </td>
                                        <td style="width: 70px;">
                                            <asp:TextBox ID="txtPeriodFrom" runat="server" Style="width: 90px !important;" onkeypress="return false;"></asp:TextBox>
                                            <asp:Image ID="imgPeriodFrom" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                Height="20px" Width="20px" />
                                            <ajx:CalendarExtender ID="calPeriodFrom" PopupButtonID="imgPeriodFrom" TargetControlID="txtPeriodFrom"
                                                runat="server" Format="dd/MM/yyyy">
                                            </ajx:CalendarExtender>
                                            <img src="../../images/clear.png" id="imgAD" style="vertical-align: middle;" title="Clear Date"
                                                onclick="fnClearDate('<%= txtPeriodFrom.ClientID %>');" />
                                        </td>
                                        <td>
                                            <asp:Literal ID="litTo" runat="server" Text="To"></asp:Literal>
                                        </td>
                                        <td style="width: 230px;">
                                            <asp:TextBox ID="txtPeriodTo" runat="server" Style="width: 90px !important;" onkeypress="return false;"></asp:TextBox>
                                            <asp:Image ID="imgPeriodTo" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                Height="20px" Width="20px" />
                                            <ajx:CalendarExtender ID="calPeriodTo" PopupButtonID="imgPeriodTo" TargetControlID="txtPeriodTo"
                                                runat="server" Format="dd/MM/yyyy">
                                            </ajx:CalendarExtender>
                                            <img src="../../images/clear.png" id="img1" style="vertical-align: middle;" title="Clear Date"
                                                onclick="fnClearDate('<%= txtPeriodTo.ClientID %>');" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="litRoomRentForPeriod" Text="Room Rent For The Period" runat="server"></asp:Literal>
                                        </td>
                                        <td colspan="3">
                                            <asp:TextBox ID="txtRoomRentForPeriod" runat="server" style="text-align:right;"></asp:TextBox>
                                            <ajx:FilteredTextBoxExtender ID="ftRoomRentForPeriod" runat="server" TargetControlID="txtRoomRentForPeriod"
                                                FilterType="Numbers" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="litTotalAreaOfComplex" Text="Total Area Of Complex (Sft)" runat="server"></asp:Literal>
                                        </td>
                                        <td colspan="3">
                                            <asp:TextBox ID="txtTotalAreaOfComplex" runat="server" style="text-align:right;"></asp:TextBox>
                                            <ajx:FilteredTextBoxExtender ID="ftTotalAreaOfComplex" runat="server" TargetControlID="txtTotalAreaOfComplex"
                                                FilterType="Numbers" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="litSelfOccupiedArea" Text="Self Occupied Area (Sft)" runat="server"></asp:Literal>
                                        </td>
                                        <td colspan="3">
                                            <asp:TextBox ID="txtSelfOccupiedArea" runat="server" style="text-align:right;"></asp:TextBox>
                                            <ajx:FilteredTextBoxExtender ID="ftSelfOccupiedArea" runat="server" TargetControlID="txtSelfOccupiedArea"
                                                FilterType="Numbers" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="litNetAreaUnderPMS" Text="Net Area Under Pms (Sft)" runat="server"></asp:Literal>
                                        </td>
                                        <td colspan="3">
                                            <asp:TextBox ID="txtNetAreaUnderPMS" runat="server" style="text-align:right;"></asp:TextBox>
                                            <ajx:FilteredTextBoxExtender ID="ftNetAreaUnderPMS" runat="server" TargetControlID="txtNetAreaUnderPMS"
                                                FilterType="Numbers" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="litRentYieldPerSFT" Text="Rent Yield Per (Sft)" runat="server"></asp:Literal>
                                        </td>
                                        <td colspan="3">
                                            <asp:TextBox ID="txtRentYieldPerSFT" runat="server" style="text-align:right;"></asp:TextBox>
                                            <ajx:FilteredTextBoxExtender ID="ftRentYieldPerSFT" runat="server" TargetControlID="txtRentYieldPerSFT"
                                                FilterType="Numbers" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <hr />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" class="dTableBox" style="padding: 10px 0px;">
                                            <asp:GridView ID="gvRentPayout" runat="server" Width="100%" ShowHeader="true" ShowFooter="true"
                                                AutoGenerateColumns="false">
                                                <Columns>
                                                    <asp:TemplateField ItemStyle-Width="200px" FooterStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblGvHdrUnitNo" runat="server" Text="Unit No"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <%#DataBinder.Eval(Container.DataItem, "UnitNo")%>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <b>
                                                                <asp:Literal ID="litTotal" runat="server" Text="Total"></asp:Literal></b>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField FooterStyle-HorizontalAlign="Center" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblGvHdrSFT" runat="server" Text="Sft"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <%#DataBinder.Eval(Container.DataItem, "SFT")%>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <b>
                                                                <asp:Literal ID="litTotalSFT" runat="server" Text="300"></asp:Literal></b>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField FooterStyle-HorizontalAlign="Center" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblGvHdrYieldSFT" runat="server" Text="Yield/sft" ToolTip="Available"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <%#DataBinder.Eval(Container.DataItem, "YieldSFT")%>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <b>
                                                                <asp:Literal ID="litTotalYieldSFT" runat="server" Text="300"></asp:Literal></b>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField FooterStyle-HorizontalAlign="Center" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblGvHdrYieldAmount" runat="server" Text="Yield Amount" ToolTip="Out of Service"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <%#DataBinder.Eval(Container.DataItem, "YieldAmount")%>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <b>
                                                                <asp:Literal ID="litTotalYieldAmount" runat="server" Text="30000"></asp:Literal></b>
                                                        </FooterTemplate>
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
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
