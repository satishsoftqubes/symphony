<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PaymentReceipt.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation.PaymentReceipt" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
    <script type="text/javascript">
        function fnDisplayCatchErrorMessage() {
            document.getElementById('errormessage').style.display = "block";
        }
</script>
<table border="0" cellpadding="2" cellspacing="2" width="100%">
    <tr>
        <td align="center">
            <b>
                <asp:Literal ID="litPaymentRecipt" runat="server" Text="Payment Receipt"></asp:Literal></b>
            <hr />
        </td>
    </tr>
    <tr>
        <td align="center">
            <table width="100%">
                <tr>
                    <td>
                        Name
                        <asp:HiddenField ID="hdnReservationID" runat="server" />
                        <asp:HiddenField ID="hdnBookID" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="ltrGuestName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Folio #
                    </td>
                    <td>
                        <asp:Label ID="lblFolioNo" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Date
                    </td>
                    <td>
                        <asp:Label ID="lblPaymentDate" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        Time :
                        <asp:Label ID="lblPaymentTime" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Received By
                    </td>
                    <td>
                        <asp:Label ID="lblPaymentReceivedBy" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div style="height: 150px; overflow: auto;">
                            <div class="box_content">
                                <asp:GridView ID="gvPaymentList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                    Width="100%" SkinID="gvNoPaging" OnRowDataBound="gvPaymentList_RowDataBound" ShowFooter="true">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                            <HeaderTemplate>
                                                <asp:Literal ID="litGvHdrNumber" runat="server" Text="No."></asp:Literal>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                            <HeaderTemplate>
                                                <asp:Label ID="lblGvHdrTransactionNo" runat="server" Text="Transaction #"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%#DataBinder.Eval(Container.DataItem, "BookNo")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="110px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                            <HeaderTemplate>
                                                <asp:Label ID="lblGvHdrEntryDate" runat="server" Text="Entry Date"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "EntryDate")).ToString(clsSession.DateFormat)%>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Literal ID="litTotalAmount" runat="server" Text="Total Amount"></asp:Literal>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                            FooterStyle-HorizontalAlign="Right">
                                            <HeaderTemplate>
                                                <asp:Label ID="lblGvHdrAmount" runat="server" Text="Amount"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblGvAmount" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Amount")%>'></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <b>
                                                    <asp:Label ID="lblDisplayTotalAmount" runat="server"></asp:Label></b>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="110px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                            <HeaderTemplate>
                                                <asp:Label ID="lblGvHdrMOP" runat="server" Text="Payment Mode"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblGVMOP" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "MOP")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <div style="padding: 10px;">
                                            <b>
                                                <asp:Label ID="lblNoRecordFound" runat="server" Text="No record found."></asp:Label>
                                            </b>
                                        </div>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
