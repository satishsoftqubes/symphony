<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckInPaymentRecipt.aspx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Reservation.CheckInPaymentRecipt" %>

<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link id="Link1" href="~/Styles/style.css" runat="server" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function fnPrint() {
            document.getElementById('dvToHide').style.display = 'none';
            window.print();
            window.close();
        }
        function fnDisplayCatchErrorMessage() {
            document.getElementById('errormessage').style.display = "block";
        }
    </script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="scrptmngCheckInPayment" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <center>
        <div style="margin: 0; height: 60px; text-align: center;">
            <img src="<%=Page.ResolveUrl("~/images/Logo - registerd_small.jpg") %>" style="width: 175px;
                height: 54px" border="0" alt="" />
        </div>
        <div style="text-align: center;">
            <asp:Label runat="server" ID="lblPropertyaddress"></asp:Label></div>
    </center>
    <div class="box_form" id="divName">
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
        <table border="0" cellpadding="2" cellspacing="2" width="100%">
            <tr>
                <td align="center">
                    <b>
                        <asp:Literal ID="litPaymentRecipt" runat="server" Text="Payment Receipt-(For Front Desk)"></asp:Literal></b>
                    <hr />
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table width="100%">
                        <tr>
                            <td width="80px">
                                Name
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
                                <div class="box_content">
                                    <asp:GridView ID="gvPaymentList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                        Width="80%" SkinID="gvNoPaging" OnRowDataBound="gvPaymentList_RowDataBound" ShowFooter="true">
                                        <Columns>
                                            <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Literal ID="litGvHdrNumber" runat="server" Text="No."></asp:Literal>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="90px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrTransactionNo" runat="server" Text="Transaction #"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "BookNo")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrEntryDate" runat="server" Text="Entry Date"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "EntryDate")).ToString("dd-MM-yyyy hh:mm tt")%>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Literal ID="litTotalAmount" runat="server" Text="Total Amount"></asp:Literal>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                                FooterStyle-HorizontalAlign="Right" ItemStyle-Width="80px">
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
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrMOP" runat="server" Text="Payment Mode"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblGVMOP" runat="server"></asp:Label>
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
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <br />
                                <br />
                                ______________________________
                                <br />
                                Cashier
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <div style="height:70px;">
    </div>
    <center>
        <div style="margin: 0; height: 60px; text-align: center;">
            <img src="<%=Page.ResolveUrl("~/images/Logo - registerd_small.jpg") %>" style="width: 175px;
                height: 54px" border="0" alt="" />
        </div>
        <div style="text-align: center;">
            <asp:Label runat="server" ID="lblPropertyaddress1"></asp:Label></div>
    </center>
    <div class="box_form" id="div1">
        <table border="0" cellpadding="2" cellspacing="2" width="100%">
            <tr>
                <td align="center">
                    <b>
                        <asp:Literal ID="Literal1" runat="server" Text="Payment Receipt-(For Guest)"></asp:Literal></b>
                    <hr />
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table width="100%">
                        <tr>
                            <td width="80px">
                                Name
                            </td>
                            <td>
                                <asp:Label ID="ltrGuestName1" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Folio #
                            </td>
                            <td>
                                <asp:Label ID="lblFolioNo1" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Date
                            </td>
                            <td>
                                <asp:Label ID="lblPaymentDate1" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                Time :
                                <asp:Label ID="lblPaymentTime1" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Received By
                            </td>
                            <td>
                                <asp:Label ID="lblPaymentReceivedBy1" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div class="box_content">
                                    <asp:GridView ID="gvPaymentList1" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                        Width="80%" SkinID="gvNoPaging" OnRowDataBound="gvPaymentList1_RowDataBound" ShowFooter="true">
                                        <Columns>
                                            <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Literal ID="litGvHdrNumber" runat="server" Text="No."></asp:Literal>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="90px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrTransactionNo" runat="server" Text="Transaction #"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "BookNo")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrEntryDate" runat="server" Text="Entry Date"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "EntryDate")).ToString("dd-MM-yyyy hh:mm tt")%>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Literal ID="litTotalAmount" runat="server" Text="Total Amount"></asp:Literal>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                                FooterStyle-HorizontalAlign="Right" ItemStyle-Width="80px">
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
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrMOP" runat="server" Text="Payment Mode"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblGVMOP" runat="server"></asp:Label>
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
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <br />
                                <br />
                                ______________________________
                                <br />
                                Cashier
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <div id="errormessage" class="clear">
        <uc1:MsgBox ID="MessageBox" runat="server" />
    </div>
    </form>
</body>
</html>
