<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlPrintStatement.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Card.CtrlPrintStatement" %>
<%@ Register Src="~/UIControls/Card/CtrlCommonSearchGuest.ascx" TagName="SearchGuest"
    TagPrefix="ucSearchGuest" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<asp:UpdatePanel ID="updPrintStatement" runat="server">
    <ContentTemplate>
        <asp:MultiView ID="mvPrintStatement" runat="server">
            <asp:View ID="vGuestList" runat="server">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="content">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="boxtopleft">
                                        &nbsp;
                                    </td>
                                    <td class="boxtopcenter">
                                        <asp:Literal ID="lithdrGuestList" runat="server" Text="Print Statement"></asp:Literal>
                                    </td>
                                    <td class="boxtopright">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="boxleft">
                                        &nbsp;
                                    </td>
                                    <td align="left">
                                        <ucSearchGuest:SearchGuest ID="ctrlCommonSearchGuest" runat="server" OnbtnSearchGuestCallParent_Click="btnSearchGuestCallParent_Click" />
                                    </td>
                                    <td class="boxright">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="boxbottomleft">
                                    </td>
                                    <td class="boxbottomcenter">
                                    </td>
                                    <td class="boxbottomright">
                                    </td>
                                </tr>
                            </table>
                            <div class="clear_divider">
                            </div>
                            <div class="clear">
                            </div>
                        </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="vPrintStatement" runat="server">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="content">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="boxtopleft">
                                        &nbsp;
                                    </td>
                                    <td class="boxtopcenter">
                                        <asp:Literal ID="litVPrintStatement" runat="server" Text="Print Statement"></asp:Literal>
                                    </td>
                                    <td class="boxtopright">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="boxleft">
                                        &nbsp;
                                    </td>
                                    <td align="left">
                                        <table width="100%" cellpadding="2" cellspacing="2">
                                            <tr>
                                                <td width="80%" style="border-right: 1px solid #DDDDDF; padding-right: 5px; vertical-align: top;">
                                                    <%--<div class="box_head">
                                <span>
                                    <asp:Literal ID="litGuestList" runat="server" Text="Guest List"></asp:Literal>
                                </span>
                            </div>
                            <div class="clear">
                            </div>--%>
                                                    <div class="box_content">
                                                        <asp:GridView ID="gvCreditList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                            Width="100%" OnRowDataBound="gvCreditList_RowDataBound" ShowFooter="true">
                                                            <Columns>
                                                                <asp:TemplateField ItemStyle-Width="25px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex + 1 %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="110px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblGvHdrTransactionNo" runat="server" Text="Transaction No."></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <%#DataBinder.Eval(Container.DataItem, "TransactionNo")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblGvHdrDate" runat="server" Text="Date"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <%#DataBinder.Eval(Container.DataItem, "Date")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblGvHdrPerticulars" runat="server" Text="Perticulars"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <%#DataBinder.Eval(Container.DataItem, "Perticulars")%>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <b>Total:</b>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblGvHdrCredit" runat="server" Text="Credit"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <%#DataBinder.Eval(Container.DataItem, "Credit")%>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <b style="float: right;">
                                                                            <asp:Literal ID="litTotalCredit" runat="server"></asp:Literal></b>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EmptyDataTemplate>
                                                                <div style="padding: 10px;">
                                                                    <b>
                                                                        <asp:Label ID="lblNoRecordFoundForCredit" runat="server" Text="No Record Found."></asp:Label>
                                                                    </b>
                                                                </div>
                                                            </EmptyDataTemplate>
                                                        </asp:GridView>
                                                    </div>
                                                </td>
                                                <td width="20%" style="padding-left: 5px; vertical-align: top">
                                                    <%--<div class="box_head">
                                <span>
                                    <asp:Literal ID="Literal1" runat="server" Text="Guest List"></asp:Literal>
                                </span>
                            </div>
                            <div class="clear">
                            </div>--%>
                                                    <div class="box_content">
                                                        <asp:GridView ID="gvDebitList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                            Width="100%" OnRowDataBound="gvDebitList_RowDataBound" ShowFooter="true">
                                                            <Columns>
                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblGvHdrDebit" runat="server" Text="Debit"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <%#DataBinder.Eval(Container.DataItem, "Debit")%>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <b style="float: right;">
                                                                            <asp:Literal ID="litTotalDebit" runat="server"></asp:Literal></b>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EmptyDataTemplate>
                                                                <div style="padding: 10px;">
                                                                    <b>
                                                                        <asp:Label ID="lblNoRecordFoundDebit" runat="server" Text="No Record Found."></asp:Label>
                                                                    </b>
                                                                </div>
                                                            </EmptyDataTemplate>
                                                        </asp:GridView>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="padding-top: 15px;">
                                                    <div style="float: left;">
                                                        <asp:ImageButton ID="imgbtnDOC_Ledger" Text="" Style="float: left; margin-left: 5px;
                                                            border: 0px;" ToolTip="ExportToDOC" runat="server" ImageUrl="~/images/report_word.png" />
                                                        <asp:ImageButton ID="imgbtnXLSX_Ledger" Text="" Style="float: left; margin-left: 5px;
                                                            border: 0px;" ToolTip="ExportToXLSX" runat="server" ImageUrl="~/images/report_xlsx.png" />
                                                        <asp:ImageButton ID="imgbtnPDF_Ledger" Text="" Style="float: left; margin-left: 5px;
                                                            border: 0px;" ToolTip="ExportToPDF" runat="server" ImageUrl="~/images/report_pdf.png" />
                                                        <asp:Button ID="btnPreview_Ledger" Text="Preview" Style="float: left; margin-left: 5px;"
                                                            runat="server" ImageUrl="~/images/save.png" />
                                                        <a href="#">
                                                            <img src="../../images/Print32x32.png" title="Print" /></a>
                                                    </div>
                                                    <div style="float: right;">
                                                        <asp:Button ID="btnPrintStatementCancel" runat="server" Text="Cancel" OnClick="btnPrintStatementCancel_Click" />
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td class="boxright">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="boxbottomleft">
                                    </td>
                                    <td class="boxbottomcenter">
                                    </td>
                                    <td class="boxbottomright">
                                    </td>
                                </tr>
                            </table>
                            <div class="clear_divider">
                            </div>
                            <div class="clear">
                            </div>
                        </td>
                    </tr>
                </table>
            </asp:View>
        </asp:MultiView>
    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updPrintStatement" ID="UpdateProgressPrintStatement"
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
