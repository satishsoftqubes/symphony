<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlInvestorPaymentDetails.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.InvestorSetUp.CtrlInvestorPaymentDetails" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function openViewer() {
        var Preview = '<%=IsPreview%>';
        window.open("../../ReportFiles/frmViewer.aspx?preview=" + Preview);
    }
</script>
<asp:UpdatePanel ID="updInvestorPaymentDetails" runat="server">
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
                                PAYMENT SCHEDULE
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
                                                            <td align="left" valign="top" style="width: 15%;">
                                                                <asp:Literal ID="litPropertyName" runat="server" Text="Unit No"></asp:Literal>
                                                            </td>
                                                            <td align="left" valign="top" style="width: 30%;">
                                                                <asp:Literal ID="litUnitNO" runat="server"></asp:Literal>
                                                            </td>
                                                            <td align="left" valign="top" style="width: 20%;">
                                                                <%--<asp:Literal ID="Literal3" runat="server" Text="Amount Paid"></asp:Literal>--%>
                                                                <asp:Literal ID="Literal1" runat="server" Text="Type Of Unit"></asp:Literal>
                                                            </td>
                                                            <td align="left" valign="top" style="width: 25%;">
                                                                <%--<asp:Literal ID="litAmountPaid" runat="server"></asp:Literal>--%>
                                                                <asp:Literal ID="litTypeOfUnit" runat="server"></asp:Literal>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">
                                                                Unit Price
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Literal ID="ltrUnitPrice" runat="server"></asp:Literal>
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Literal ID="Literal2" runat="server" Text="Total Purchase Value"></asp:Literal>
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Literal ID="litTotalPurValue" runat="server"></asp:Literal>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="pagesubheader">
                                                    SCHEDULE TYPE :&nbsp;&nbsp;<asp:Literal ID="litScheduleType" runat="server"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="dTableBox" style="padding: 10px 0px; height: 150px; overflow: auto;">
                                                    <asp:GridView ID="grdInvestorPaymentDetails" runat="server" AutoGenerateColumns="False"
                                                        Width="100%" SkinID="gvNoPaging" ShowFooter="true" OnRowCommand="grdInvestorPaymentDetails_RowCommand"
                                                        OnRowDataBound="grdInvestorPaymentDetails_RowDataBound">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="No." ItemStyle-Width="20px" HeaderStyle-HorizontalAlign="Left"
                                                                ItemStyle-HorizontalAlign="Left">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Milestone Title" HeaderStyle-HorizontalAlign="Left"
                                                                ItemStyle-HorizontalAlign="Left">
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "ProjectMilestone")%>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <b>Total Purchase:</b>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="%Due" ItemStyle-Width="45px" HeaderStyle-HorizontalAlign="Right"
                                                                ItemStyle-HorizontalAlign="Right">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGvDue" runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Amount Payable (Rs.)" ItemStyle-Width="130px" FooterStyle-HorizontalAlign="Right"
                                                                HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGvAmountPayable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AmountPayable") != DBNull.Value ? Convert.ToString(DataBinder.Eval(Container.DataItem, "AmountPayable")) : ""%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <b>
                                                                        <asp:Label ID="lblGvTotalAmountPayable" runat="server"></asp:Label></b>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Date" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left"
                                                                ItemStyle-HorizontalAlign="Left">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGvDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DueDate") != DBNull.Value ? Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "DueDate")).ToString(DateFormat) : ""%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--<asp:TemplateField HeaderText="Amount Paid" ItemStyle-Width="90px" HeaderStyle-HorizontalAlign="Right"
                                                                ItemStyle-HorizontalAlign="Right">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblAmountPaid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AmountPaid") != DBNull.Value ? Convert.ToString(DataBinder.Eval(Container.DataItem, "AmountPaid")) : ""%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Balance Amount" ItemStyle-Width="120px" HeaderStyle-HorizontalAlign="Right"
                                                                ItemStyle-HorizontalAlign="Right">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblBalanceAmount" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BalanceAmount") != DBNull.Value ? Convert.ToString(DataBinder.Eval(Container.DataItem, "BalanceAmount")) : ""%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                                                            <%--<asp:TemplateField HeaderText="Action" ItemStyle-Width="40px" HeaderStyle-HorizontalAlign="Left"
                                                                ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkInvestorPaymentDetailsView" Text="Receipt" runat="server"
                                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem, "PaymentScheduleID")%>'
                                                                        CommandName="VIEWRECEIPT" ToolTip="View Receipts"></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" valign="middle">
                                                    <asp:ImageButton ID="imgbtnDOC" Text="" Style="float: left; margin-left: 5px; border: 0px;"
                                                        ToolTip="ExportToDOC" runat="server" ImageUrl="~/images/report_word.png" OnClick="imgbtnDOC_Click"
                                                        OnClientClick="fnDisplayCatchErrorMessage()" />
                                                    <asp:ImageButton ID="imgbtnXLSX" Text="" Style="float: left; margin-left: 5px; border: 0px;"
                                                        ToolTip="ExportToXLSX" runat="server" ImageUrl="~/images/report_xlsx.png" OnClick="imgbtnXLSX_Click"
                                                        OnClientClick="fnDisplayCatchErrorMessage()" />
                                                    <asp:ImageButton ID="imgbtnPDF" Text="" Style="float: left; margin-left: 5px; border: 0px;"
                                                        ToolTip="ExportToPDF" runat="server" ImageUrl="~/images/report_pdf.png" OnClick="imgbtnPDF_Click"
                                                        OnClientClick="fnDisplayCatchErrorMessage()" />
                                                    <asp:Button ID="btnPreview" Visible="false" Text="Preview" Style="float: left; margin-left: 5px;"
                                                        runat="server" ImageUrl="~/images/save.png" OnClick="btnPreview_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                   
                                                    <asp:Button ID="btnPrint" Text="Print" Style="float: left; margin-left: 5px;" runat="server"
                                                        ImageUrl="~/images/cancle.png" OnClick="btnPrint_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                         <asp:Button ID="btnBackInvesterPaymentList" Text="Back" Style="float: left; margin-left: 5px;"
                                                        runat="server" ImageUrl="~/images/save.png" OnClick="btnBackInvesterPaymentList_Click"
                                                        OnClientClick="fnDisplayCatchErrorMessage()" />
                                                    <asp:Button ID="btnAdd" runat="server" Text="Add New" OnClick="btnAdd_Click" Style="float: right;"
                                                        OnClientClick="fnDisplayCatchErrorMessage()" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:View>
                                    <asp:View ID="vReceiptDetails" runat="server">
                                        <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                            <tr>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="pagesubheader">
                                                    <asp:Literal ID="litReceiptDetail" runat="server" Text="RECEIPT DETAIL"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="border: 1px solid #ccccce;">
                                                    <table cellpadding="2" cellspacing="2" width="100%">
                                                        <tr>
                                                            <td style="border-right: 1px solid #ccccce; width: 125px;">
                                                                <b>
                                                                    <asp:Literal ID="litReceiptDetailsMilestoneTitle" runat="server"></asp:Literal></b>
                                                            </td>
                                                            <td style="border-right: 1px solid #ccccce; width: 45px; text-align: right;">
                                                                <b>
                                                                    <asp:Literal ID="litReceiptDetailsDue" runat="server"></asp:Literal></b>
                                                            </td>
                                                            <td style="border-right: 1px solid #ccccce; width: 120px; text-align: right;">
                                                                <b>
                                                                    <asp:Literal ID="litReceiptDetailsTotalMilestoneAmountPayable" runat="server"></asp:Literal></b>
                                                            </td>
                                                            <td style="border-right: 1px solid #ccccce; width: 90px;">
                                                                <b>
                                                                    <asp:Literal ID="litReceiptDetailsDate" runat="server"></asp:Literal></b>
                                                            </td>
                                                            <td style="border-right: 1px solid #ccccce; width: 90px; text-align: right;">
                                                                <b>
                                                                    <asp:Literal ID="litReceiptDetailsAmountPaid" runat="server"></asp:Literal></b>
                                                            </td>
                                                            <td style="width: 120px; text-align: right;">
                                                                <b>
                                                                    <asp:Literal ID="litReceiptDetailsBalanceAmount" runat="server"></asp:Literal></b>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="dTableBox" style="padding: 10px 0px;">
                                                    <asp:GridView ID="grdInvestorPaymentReceipt" runat="server" AutoGenerateColumns="False"
                                                        Width="100%" SkinID="gvNoPaging" OnRowDataBound="grdInvestorPaymentReceipt_RowDataBound">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="No." ItemStyle-Width="20px" HeaderStyle-HorizontalAlign="Left"
                                                                ItemStyle-HorizontalAlign="Left">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Receipt No." ItemStyle-Width="125px" HeaderStyle-HorizontalAlign="Left"
                                                                ItemStyle-HorizontalAlign="Left">
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "ReceiptNo")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Date" ItemStyle-Width="125px" HeaderStyle-HorizontalAlign="Left"
                                                                ItemStyle-HorizontalAlign="Left">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGvDateToPay" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DateToPay") != DBNull.Value ? Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "DateToPay")).ToString(DateFormat) : ""%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Amount" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right"
                                                                ItemStyle-HorizontalAlign="Right">
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "PaidAmount")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Action" ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left"
                                                                ItemStyle-HorizontalAlign="Left">
                                                                <ItemTemplate>
                                                                    <a href='../../Document/<%# DataBinder.Eval(Container.DataItem, "DocumentName")%>'
                                                                        target="_blank" style="border: 0px;">
                                                                        <asp:Image ID="imgAttachment" ImageUrl="~/images/Attachment.png" runat="server" ToolTip="" /></a>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;" valign="middle">
                                                    <asp:Button ID="btnBack" runat="server" Style="display: inline; text-align: right;
                                                        margin-right: 5px;" OnClick="btnBack_OnClick" Text="Back" />
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
    <Triggers>
        <asp:PostBackTrigger ControlID="btnPreview" />
        <asp:PostBackTrigger ControlID="btnPrint" />
        <asp:PostBackTrigger ControlID="imgbtnPDF" />
        <asp:PostBackTrigger ControlID="imgbtnXLSX" />
        <asp:PostBackTrigger ControlID="imgbtnDOC" />
    </Triggers>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
