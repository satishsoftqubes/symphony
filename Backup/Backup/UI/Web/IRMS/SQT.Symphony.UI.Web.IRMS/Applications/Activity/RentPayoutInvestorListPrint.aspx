<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RentPayoutInvestorListPrint.aspx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.Applications.Activity.RentPayoutInvestorListPrint" %>

<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="../../Javascript/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../../Javascript/jquery.autocomplete.js" type="text/javascript"></script>
    <link href="../../Javascript/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
    <link href="../../Style/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function fnPrint() {
            document.getElementById('dvToHide').style.display = 'none';
            window.print();
            window.close();
        }
        function fnDisplayCatchErrorMessage() {
            document.getElementById('errormessage').style.display = "block";
        }
        function openViewer() {
            var Preview = '<%=IsPreview%>';
            window.open("../../ReportFiles/frmViewer.aspx?preview=" + Preview);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="scptInnerHTML" runat="server">
    </asp:ScriptManager>
    <div>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height: 473px;">
            <tr>
                <td class="content" style="padding-left: 0px; width: 66.66%">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                RENT PAYOUT INVESTOR LIST
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
                                <div style="font-size: 12px; font-weight: bold; padding-top: 10px; margin-bottom: 20px;">
                                    <asp:Literal ID="litQuarterTitle" runat="server" Text="Quarter Title :"> </asp:Literal>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Literal
                                        ID="litDispQuarterTitle" Text="First Quarter" runat="server"></asp:Literal>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Literal ID="litDuspQuarterPeriod" runat="server" Text="Quarter period :"> </asp:Literal>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Literal
                                        ID="litQuarterPeriod" runat="server"></asp:Literal>
                                </div>
                                <%--<div style="float: left; margin-left: 250px; text-align: right; margin-bottom: 10px;
                                    margin-top: 10px; margin-right: 15px; font-size: 12px; font-weight: bold; margin-right: 10px;">
                                    </div>
                                <div style="float: left; text-align: right; margin-bottom: 10px; margin-top: 10px;
                                    font-size: 12px; font-weight: bold; margin-right: 10px;">
                                    </div>--%>
                                <table cellpadding="2" cellspacing="0" border="0" width="100%">
                                    <tr>
                                        <td>
                                            <div style="float: Left;">
                                                <asp:Button ID="btnPrint" Text="Print Report" Style="float: left; margin-left: 5px;" runat="server"
                                                    ImageUrl="~/images/cancle.png" OnClick="btnPrint_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                <asp:Button ID="btnPreview" Visible="false" Text="Preview" Style="float: left; margin-left: 5px;"
                                                    runat="server" ImageUrl="~/images/save.png" OnClick="btnPreview_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                <asp:ImageButton ID="imgbtnPDF" Text="" Style="float: left; margin-left: 5px;" ToolTip="ExportToPDF"
                                                    runat="server" ImageUrl="~/images/report_pdf.png" OnClick="imgbtnPDF_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                <asp:ImageButton ID="imgbtnXLSX" Text="" Style="float: left; margin-left: 5px;" ToolTip="ExportToXLSX"
                                                    runat="server" ImageUrl="~/images/report_xlsx.png" OnClick="imgbtnXLSX_Click"
                                                    OnClientClick="fnDisplayCatchErrorMessage()" />
                                                <asp:ImageButton ID="imgbtnDOC" Text="" Style="float: left; margin-left: 5px;" ToolTip="ExportToDOC"
                                                    runat="server" ImageUrl="~/images/report_word.png" OnClick="imgbtnDOC_Click"
                                                    OnClientClick="fnDisplayCatchErrorMessage()" />
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dTableBox" style="padding: 10px 0px;">
                                            <asp:GridView ID="gvAdminRendPayoutDetails" runat="server" Width="100%" ShowHeader="true"
                                                ShowFooter="true" AutoGenerateColumns="false" OnRowDataBound="gvAdminRendPayoutDetails_RowDatabound"
                                                OnPageIndexChanging="gvAdminRendPayoutDetails_PageIndexChange">
                                                <Columns>
                                                    <asp:TemplateField ItemStyle-Width="25px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="InvName" HeaderText="Name" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left" ItemStyle-Width="160px" />
                                                    <asp:TemplateField FooterStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60px">
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
                                                    <asp:TemplateField FooterStyle-HorizontalAlign="Left" ItemStyle-Width="90px" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblGvHdrFinalPaymentDate" runat="server" Text="Payment Date"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <%#DataBinder.Eval(Container.DataItem, "FinalPaymentDate")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField FooterStyle-HorizontalAlign="Right" ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Right"
                                                        ItemStyle-HorizontalAlign="Right">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblGvHdrSFT" runat="server" Text="Total Sft"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <%#DataBinder.Eval(Container.DataItem, "TotalSqft")%>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <b>
                                                                <asp:Literal ID="litTotalSFT" runat="server"></asp:Literal></b>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField FooterStyle-HorizontalAlign="Center" ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Right"
                                                        ItemStyle-HorizontalAlign="Right">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblGvHdrNoofDays" runat="server" Text="Total Days"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <%#DataBinder.Eval(Container.DataItem, "NoofDays")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField FooterStyle-HorizontalAlign="Center" ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Right"
                                                        ItemStyle-HorizontalAlign="Right">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblGvHdrYieldPerDay" runat="server" Text="Yield/day"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <%#DataBinder.Eval(Container.DataItem, "YieldPerDay")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField FooterStyle-HorizontalAlign="Center" ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Right"
                                                        ItemStyle-HorizontalAlign="Right">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblGvHdrYieldPerSqft" runat="server" Text="Yield/sft"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <%#DataBinder.Eval(Container.DataItem, "RentYieldPerSqft")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField FooterStyle-HorizontalAlign="Right" ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Right"
                                                        ItemStyle-HorizontalAlign="Right">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblGvHdrYieldAmount" runat="server" Text="Total Amount"></asp:Label>
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
        <div id="dvToHide" style="padding-bottom: 10px; padding-top: 10px; padding-left: 10px;
            padding-right: 10px;" align="center">
            <asp:Button ID="btnPrintRentPayoutInList" runat="server" Style="display: inline;"
                Text="Print" OnClientClick="fnPrint();" />
        </div>
    </div>
    <div id="errormessage" class="clear" style="display: none;">
        <uc1:MsgBox ID="MessageBox" runat="server" />
    </div>
    </form>
</body>
</html>
