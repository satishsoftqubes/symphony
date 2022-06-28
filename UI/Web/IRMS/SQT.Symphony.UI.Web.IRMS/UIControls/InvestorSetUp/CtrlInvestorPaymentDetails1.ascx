<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlInvestorPaymentDetails1.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.InvestorSetUp.CtrlInvestorPaymentDetails1" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="content" style="padding-left: 0px; width: 66.66%">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                INVESTOR PAYMENT DETAILS
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
                                <asp:MultiView ID="mvInvestorPaymentDetails" runat="server">
                                    <asp:View ID="vScheduleType" runat="server">
                                        <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                            <tr>
                                                <td>
                                                    <table cellpadding="2" cellspacing="2" width="100%">
                                                        <tr>
                                                            <td align="left" valign="top" style="width: 20%;">
                                                                <asp:Literal ID="litPropertyName" runat="server" Text="Unit No"></asp:Literal>
                                                            </td>
                                                            <td align="left" valign="top" style="width: 25%;">
                                                                <asp:Literal ID="litUnitNO" runat="server" Text="F-109"></asp:Literal>
                                                            </td>
                                                            <td align="left" valign="top" style="width: 20%;">
                                                                <asp:Literal ID="litUserName" runat="server" Text="Amount Payable "></asp:Literal>
                                                            </td>
                                                            <td align="left" valign="top" style="width: 25%;">
                                                                <asp:Literal ID="litAmountPayable" runat="server" Text="Rs. A"></asp:Literal>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top" style="width: 20%;">
                                                                <asp:Literal ID="Literal1" runat="server" Text="Type Of Unit"></asp:Literal>
                                                            </td>
                                                            <td align="left" valign="top" style="width: 25%;">
                                                                <asp:Literal ID="litTypeOfUnit" runat="server" Text="NA"></asp:Literal>
                                                            </td>
                                                            <td align="left" valign="top" style="width: 20%;">
                                                                <asp:Literal ID="Literal3" runat="server" Text="Amount Paid"></asp:Literal>
                                                            </td>
                                                            <td align="left" valign="top" style="width: 25%;">
                                                                <asp:Literal ID="litAmountPaid" runat="server" Text="Rs 65,333.00"></asp:Literal>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top" style="width: 20%;">
                                                                <asp:Literal ID="Literal2" runat="server" Text="Total Pur. Value(Rs.)"></asp:Literal>
                                                            </td>
                                                            <td align="left" valign="top" style="width: 25%;">
                                                                <asp:Literal ID="litTotalPurValue" runat="server" Text="A"></asp:Literal>
                                                            </td>
                                                            <td align="left" valign="top" style="width: 20%;">
                                                                <asp:Literal ID="Literal5" runat="server" Text="Net Payment Outstanding  "></asp:Literal>
                                                            </td>
                                                            <td align="left" valign="top" style="width: 25%;">
                                                                <asp:Literal ID="litNetPaymentOutStanding" runat="server" Text="Rs 65,333.00"></asp:Literal>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="pagesubheader">
                                                    <asp:Literal ID="litList" runat="server" Text="SCHEDULE TYPE: STANDARD"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="dTableBox" style="padding: 10px 0px;">
                                                    <asp:GridView ID="grdInvestorPaymentDetails" runat="server" AutoGenerateColumns="False"
                                                        Width="100%" SkinID="gvNoPaging" ShowFooter="true">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="No." HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign ="Right">
                                                                
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Milestone Title">
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "MilestoneTitle")%>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <b>Total Purchase:</b>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="%Due"  ItemStyle-HorizontalAlign ="Right">
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "Due")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Total Milestone Amount Payable"  ItemStyle-HorizontalAlign ="Right">
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "TotalMilestoneAmountPayable")%>
                                                                </ItemTemplate>
                                                               <FooterTemplate>
                                                                    <b style="padding-left: 145px;"><asp:Literal  runat="server" ID="litGrTotal" Text="50000"></asp:Literal></b>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Date"  ItemStyle-HorizontalAlign ="Right">
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "Date")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Amount Paid"  ItemStyle-HorizontalAlign ="Right">
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "AmountPaid")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Balance Amount"  ItemStyle-HorizontalAlign ="Right">
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "BalanceAmount")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Action">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkInvestorPaymentDetailsView" Text="View Receipt" runat="server" ToolTip="View Receipts"
                                                                        OnClick="lnkInvestorPaymentDetailsView_OnClick"></asp:LinkButton>
                                                                </ItemTemplate>
                                                                
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                          
                                        </table>
                                         
                                    </asp:View>
                                    <asp:View ID="vReceiptDetails" runat="server">
                                        <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                        <tr><td></td></tr>
                                            <tr>
                                                <td class="pagesubheader">
                                                    <asp:Literal ID="litReceiptDetail" runat="server" Text="RECEIPT DETAIL"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr><td></td></tr>
                                            <tr>
                                               <td style="border: 1px solid #ccccce;">
                                                    <table cellpadding="2" cellspacing="2">
                                                    <tr>
                                                        <td style="border:Right 1px solid #ccccce;">
                                                           <b><asp:Literal ID="litReceiptDetailsMilestoneTitle" runat="server" Text="On Booking"></asp:Literal></b> 
                                                        </td>
                                                        <td>
                                                           <b style="padding-left: 25px;"><asp:Literal ID="litReceiptDetailsDue" runat="server" Text="25"></asp:Literal></b> 
                                                        </td>
                                                        <td>
                                                            <b style="padding-left: 25px;"><asp:Literal ID="litReceiptDetailsTotalMilestoneAmountPayable" runat="server" Text="50000"></asp:Literal></b>
                                                        </td>
                                                        <td>
                                                            <b style="padding-left: 25px;"><asp:Literal ID="litReceiptDetailsDate" runat="server" Text="25/05/2012"></asp:Literal></b>
                                                        </td>
                                                        <td>
                                                            <b style="padding-left: 25px;"><asp:Literal ID="litReceiptDetailsAmountPaid" runat="server" Text="30000"></asp:Literal></b>
                                                        </td>
                                                        <td>
                                                            <b style="padding-left: 25px;"><asp:Literal ID="litReceiptDetailsBalanceAmount" runat="server" Text="20000"></asp:Literal></b>
                                                        </td>
                                                    </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td  class="dTableBox" style="padding: 10px 0px;">
                                                    <asp:GridView ID="grdInvestorPaymentReceipt" runat="server" AutoGenerateColumns="False"
                                                        Width="100%" SkinID="gvNoPaging">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="No." HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign ="Right">
                                                                <ItemTemplate >
                                                                    <%# Container.DataItemIndex + 1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Receipt No." HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign ="Right">
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "ReceiptNo")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Date" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign ="Right">
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "Date")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Amount" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign ="Center">
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "Amount")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Action">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkInvestorPaymentDetailsViewDownload" runat="server" ToolTip="View And Download"><img src="../../images/View.png" /></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                            <td style="text-align:right;" valign="middle">                                           
                                             <asp:Button ID="btnBack" runat="server" Style="display:inline; text-align:right;margin-right: 5px;" Text="Back" OnClick="btnBack_OnClick" />
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
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
