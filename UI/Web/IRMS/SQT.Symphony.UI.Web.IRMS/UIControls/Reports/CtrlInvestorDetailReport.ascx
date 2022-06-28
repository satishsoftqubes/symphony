<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlInvestorDetailReport.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.Reports.CtrlInvestorDetailReport" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
    function openViewerForPrint() {
        window.open("../Reports/RptInvestorDetailPrint.aspx");
    }

    function openViewer() {
        var Preview = '<%=IsPreview%>';
        window.open("../../ReportFiles/frmViewer.aspx?preview=" + Preview);
    }

</script>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td class="content" style="padding-left: 0px; width: 66.66%">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                <tr>
                    <td class="boxtopleft">
                        &nbsp;
                    </td>
                    <td class="boxtopcenter">
                        INVESTOR List
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
                        <asp:UpdatePanel ID="updinvestorDetailInformation" runat="server">
                            <ContentTemplate>
                                <table cellpadding="2" cellspacing="0" border="0" width="100%">
                                    <tr>
                                        <td>
                                            <div style="margin-left: 20px;">
                                                <table cellpadding="2" cellspacing="2" width="100%">
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litInvestorName" runat="server" Text="Investor Name"></asp:Literal>
                                                            &nbsp;&nbsp;<asp:DropDownList ID="ddlinvestorList" runat="server">
                                                            </asp:DropDownList>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton ID="btnSearch" runat="server" Style="border: 0px; vertical-align: middle;
                                                                margin-top: 0px; margin-left: 5px;" ImageUrl="~/images/search-icon.png" OnClick="btnSearch_Click"
                                                                OnClientClick="fnDisplayCatchErrorMessage()" />
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="litBankName" runat="server" Visible="false" Text="Bank Name"></asp:Literal>
                                                            &nbsp;&nbsp;<asp:TextBox ID="txtSearchBankName" runat="server" Visible="false"></asp:TextBox>
                                                            
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dTableBox">
                                            <div style="text-align: right; margin-top: 5px; margin-bottom: 5px; margin-left: 688px;">
                                                <asp:Button ID="btnPrint" Text="Print" runat="server" ImageUrl="~/images/cancle.png"
                                                    OnClientClick="fnDisplayCatchErrorMessage()" OnClick="btnPrint_Click" /></div>
                                            <div style="overflow: auto; width: 730px; height: 400px; margin: 20px 20px 20px 20px;">
                                                <asp:GridView ID="gvInvestorDetailInformation" runat="server" AutoGenerateColumns="False"
                                                    Width="1500px" SkinID="gvNoPaging">
                                                    <Columns>
                                                        <asp:TemplateField ItemStyle-Width="25px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="InvName" HeaderText="Investor Name" HeaderStyle-HorizontalAlign="Left"
                                                            ItemStyle-HorizontalAlign="Left" ItemStyle-Width="230px" />
                                                        <asp:BoundField DataField="Email" HeaderText="Email" HeaderStyle-HorizontalAlign="Left"
                                                            ItemStyle-HorizontalAlign="Left" ItemStyle-Width="120px" />
                                                        <%--<asp:BoundField DataField="PanNo" HeaderText="Pan No." HeaderStyle-HorizontalAlign="Left"
                                                            ItemStyle-HorizontalAlign="Left" ItemStyle-Width="80px" />
                                                        <asp:BoundField DataField="BankName" HeaderText="Bank Name" HeaderStyle-HorizontalAlign="Left"
                                                            ItemStyle-HorizontalAlign="Left" ItemStyle-Width="160px" />
                                                        <asp:BoundField DataField="AccountNo" HeaderText="Bank A/c No." HeaderStyle-HorizontalAlign="Left"
                                                            ItemStyle-HorizontalAlign="Left" ItemStyle-Width="80px" />
                                                        <asp:BoundField DataField="IFSCCode" HeaderText="IFSC Code" HeaderStyle-HorizontalAlign="Left"
                                                            ItemStyle-HorizontalAlign="Left" ItemStyle-Width="70px" />--%>
                                                        <asp:BoundField DataField="MobileNo" HeaderText="Contact No." HeaderStyle-HorizontalAlign="Left"
                                                            ItemStyle-HorizontalAlign="Left" ItemStyle-Width="70px" />
                                                        <asp:BoundField DataField="CityName" HeaderText="City" HeaderStyle-HorizontalAlign="Left"
                                                            ItemStyle-HorizontalAlign="Left" ItemStyle-Width="70px" />
                                                        <asp:BoundField DataField="CPName" HeaderText="CP Name" HeaderStyle-HorizontalAlign="Left"
                                                            ItemStyle-HorizontalAlign="Left" ItemStyle-Width="230px" />
                                                        <asp:BoundField DataField="CPContactNo" HeaderText="CP Contact No." HeaderStyle-HorizontalAlign="Left"
                                                            ItemStyle-HorizontalAlign="Left" ItemStyle-Width="70px" />
                                                        <asp:BoundField DataField="ReferenceThrough" HeaderText="Reference Through" HeaderStyle-HorizontalAlign="Left"
                                                            ItemStyle-HorizontalAlign="Left" ItemStyle-Width="150px" />
                                                        <asp:BoundField DataField="TypeA" HeaderText="Type A" HeaderStyle-HorizontalAlign="Center"
                                                            ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50px" />
                                                        <asp:BoundField DataField="TypeB" HeaderText="Type B" HeaderStyle-HorizontalAlign="Center"
                                                            ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50px" />
                                                        <asp:BoundField DataField="TypeC" HeaderText="Type C" HeaderStyle-HorizontalAlign="Center"
                                                            ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50px" />
                                                        <asp:BoundField DataField="Noofunit" HeaderText="Total units" HeaderStyle-HorizontalAlign="Center"
                                                            ItemStyle-HorizontalAlign="Center" ItemStyle-Width="70px" />
                                                        <asp:BoundField DataField="Total" HeaderText="Total sft" HeaderStyle-HorizontalAlign="Right"
                                                            ItemStyle-HorizontalAlign="Right" ItemStyle-Width="60px" />
                                                    </Columns>
                                                    <EmptyDataTemplate>
                                                        <div class="pagecontent_info">
                                                            <div class="NoItemsFound">
                                                                <h2>
                                                                    <asp:Literal ID="Literal3" runat="server" Text="No Record Found"></asp:Literal></h2>
                                                            </div>
                                                        </div>
                                                    </EmptyDataTemplate>
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div style="float: Left; margin-left: 15px;">
                                                <asp:Button ID="btnPrintReport" Text="Print Report" Style="float: left; margin-left: 5px;"
                                                    runat="server" ImageUrl="~/images/cancle.png" OnClick="btnPrintReport_Click"
                                                    OnClientClick="fnDisplayCatchErrorMessage()" />
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
                                </table>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="btnPrint" />
                                <asp:PostBackTrigger ControlID="btnPrintReport" />
                                <asp:PostBackTrigger ControlID="imgbtnPDF" />
                                <asp:PostBackTrigger ControlID="imgbtnXLSX" />
                                <asp:PostBackTrigger ControlID="imgbtnDOC" />
                            </Triggers>
                        </asp:UpdatePanel>
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
            <div id="errormessage" class="clear" style="display: none;">
                <uc1:MsgBox ID="MessageBox" runat="server" />
            </div>
        </td>
    </tr>
</table>
