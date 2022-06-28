<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FolioDetailsReceipt.aspx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Folio.FolioDetailsReceipt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link id="Link1" href="~/Styles/style.css" runat="server" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function fnPrint() {
            document.getElementById('dvToHide').style.display = 'none';
            window.print();
            window.close();
        }
    </script>
    <style type="text/css">
        h1, p
        {
            font-weight: normal;
            font-size: 10px;
            margin: 0px;
            padding: 0px;
            color: Black;
        }
    </style>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <div id="dvToHide" style="padding-bottom: 10px; padding-top: 10px; padding-left: 10px;
                    padding-right: 10px;">
                    <asp:Button ID="btnPrint" runat="server" Text="Print" OnClientClick="fnPrint();" />
                </div>
            </td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>            
            <td width="49%" style="vertical-align: top; padding-left:5px;">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="litRoomReservationList" runat="server" Text="Payment List"></asp:Literal>
                    </span>
                </div>
                <div class="clear">
                </div>
                <div class="box_content">
                    <asp:GridView ID="gvPayment" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                        Width="100%" SkinID="gvNoPaging" OnRowDataBound="gvPayment_RowDataBound" ShowFooter="true">
                        <Columns>
                            <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                <HeaderTemplate>
                                    <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                <HeaderTemplate>
                                    <asp:Label ID="lblGvHdrPaymentTransactionNo" runat="server" Text="Transaction No."></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblGvPaymentTransactionNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "BookNo")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                <HeaderTemplate>
                                    <asp:Label ID="lblGvHdrPaymentEntryDate" runat="server" Text="Date"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblGvPaymentEntryDate" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "EntryDate")).ToString(clsSession.DateFormat)%>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <b>
                                        <asp:Label ID="lblPaymentTotal" runat="server" Text="Total"></asp:Label></b>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                FooterStyle-HorizontalAlign="Right">
                                <HeaderTemplate>
                                    <asp:Label ID="lblGvHdrPaymentAmount" runat="server" Text="Amount"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblGvPaymentAmount" runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <b>
                                        <asp:Label ID="lblGvFtrDisplayPaymentTotal" runat="server"></asp:Label></b>
                                </FooterTemplate>
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
            </td>
            <td width="2%" style="border-right: 1px solid #DDDDDD;
                vertical-align: top;">
            </td>
            <td width="49%" style="vertical-align: top; padding:0px 5px 0px 10px;">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="Literal1" runat="server" Text="Charge List"></asp:Literal>
                    </span>
                </div>
                <div class="clear">
                </div>
                <div class="box_content">
                    <asp:GridView ID="gvCharge" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                        Width="100%" SkinID="gvNoPaging" OnRowDataBound="gvCharge_RowDataBound" ShowFooter="true">
                        <Columns>
                            <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                <HeaderTemplate>
                                    <asp:Label ID="lblGvChargeHdrSrNo" runat="server" Text="No."></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                <HeaderTemplate>
                                    <asp:Label ID="lblGvHdrChargeTransactionNo" runat="server" Text="Transaction No."></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblGvChargeTransactionNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "BookNo")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                <HeaderTemplate>
                                    <asp:Label ID="lblGvHdrChargeEntryDate" runat="server" Text="Date"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblGvChargeEntryDate" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "EntryDate")).ToString(clsSession.DateFormat)%>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <b>
                                        <asp:Label ID="lblChargeTotal" runat="server" Text="Total"></asp:Label></b>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                FooterStyle-HorizontalAlign="Right">
                                <HeaderTemplate>
                                    <asp:Label ID="lblGvHdrChargeAmount" runat="server" Text="Amount"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblGvChargeAmount" runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <b>
                                        <asp:Label ID="lblGvFtrDisplayChargeTotal" runat="server"></asp:Label></b>
                                </FooterTemplate>
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
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <hr />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td align="right" colspan="2">
                <table width="100%">
                    <tr>
                        <td align="right" width="420px">
                            <b>
                                <asp:Label ID="lblAmountText" runat="server" Text="Due:-"></asp:Label></b>
                        </td>
                        <td align="right">
                            <b>
                                <asp:Label ID="lblDisplayAmount" runat="server" Text="0.00"></asp:Label></b>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
