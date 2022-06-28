<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlInvestorPaymentList.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.InvestorSetUp.CtrlInvestorPaymentList" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function stopKey(evt) {
        var evt = (evt) ? evt : ((event) ? event : null);
        var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
        if ((evt.keyCode == 8) && (node.type == "text")) { return false; }
        else if ((evt.keyCode == 9) && (node.type == "text")) { return true; }
        else if ((evt.keyCode == 46) && (node.type == "text")) { return false; }
        else { return false; }
    }

    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }

    function SelectTab() {
        if (window.location.hash != '#tabs-1') {
            window.location.hash = 'tabs-2';
        }
    }

    function pageLoad(sender, args) {
        $(document).ready(function () {
            $("#<%=txtUnitNo.ClientID%>").autocomplete('../SetUp/UnitAutoComplete.ashx');
            $("#<%=txtPropertyName.ClientID%>").autocomplete('../SetUp/PropertyAutoComplete.ashx');
        });

        $(function () {
            $("#tabs").tabs();
        });

        $('#tabs').tabs({
            select: function (event, ui) {
                window.location.hash = ui.tab.hash;
            }
        });
    }

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }   
</script>
<style type="text/css">
    #progressBackgroundFilter
    {
        position: fixed;
        top: 0px;
        width: 100%;
        height: 100%;
        bottom: 0px;
        left: 0px;
        right: 0px;
        overflow: hidden;
        padding: 0;
        margin: 0;
        background-color: #000;
        filter: alpha(opacity=50);
        opacity: 0.5;
        z-index: 1111111;
    }
    #processMessage
    {
        position: fixed;
        top: 50%;
        left: 50%;
        padding: 10px;
        width: 30px;
        border-radius: 10px;
        z-index: 1111112;
        background-color: #fff;
        border: solid 1px #efefef;
    }
</style>
<script language="javascript">

    function openViewer() {
        var Preview = '<%=IsPreview%>';
        window.open("../../ReportFiles/frmViewer.aspx?preview=" + Preview);
    }
</script>
<asp:UpdatePanel ID="updIPL" runat="server">
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
                                PAYMENT INFORMATION
                            </td>
                            <td class="boxtopright">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="boxleft">
                                &nbsp;
                            </td>
                            <td style="padding-top: 15px;">
                                <div class="demo">
                                    <div id="tabs">
                                        <ul>
                                            <li><a href="#tabs-1">Payment Information</a></li>
                                            <li><a href="#tabs-2">Ledger Statement</a></li>
                                            <li><a href="#tabs-3">Payment Receipt</a></li>
                                        </ul>
                                        <div id="tabs-1">
                                            <table cellpadding="2" cellspacing="0" border="0" width="100%">
                                                <tr>
                                                    <td>
                                                        <table cellpadding="2" cellspacing="2">
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litPropertyName" runat="server" Text="Property Name"></asp:Literal>&nbsp;&nbsp;<asp:TextBox
                                                                        ID="txtPropertyName" runat="server"></asp:TextBox>
                                                                </td>
                                                                <td style="padding-left: 100px;">
                                                                    <asp:Literal ID="litUserName" runat="server" Text="Unit No"></asp:Literal>&nbsp;&nbsp;<asp:TextBox
                                                                        ID="txtUnitNo" runat="server"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                                        OnClick="btnSearch_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dTableBox" style="padding: 10px 0px;">
                                                        <asp:GridView ID="grdInvestorPaymentList" runat="server" AutoGenerateColumns="False"
                                                            Width="100%" SkinID="gvNoPaging" OnRowDataBound="grdInvestorPaymentList_RowDataBound"
                                                            OnRowCommand="grdInvestorPaymentList_RowCommand" ShowFooter="true">
                                                            <Columns>
                                                                <asp:BoundField DataField="PropertyName" HeaderText="Property Name" HeaderStyle-HorizontalAlign="Left"
                                                                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="120px" />
                                                                <asp:TemplateField ItemStyle-ForeColor="Blue" HeaderText="Unit No." HeaderStyle-HorizontalAlign="Left"
                                                                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="70px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkbtnUnitInfo" Text='<%#DataBinder.Eval(Container.DataItem, "RoomNo")%>'
                                                                            runat="server" CommandName="EDITDATA" CommandArgument='<%#Eval("InvestorRoomID") + "," +Eval("PropertyID")%>'
                                                                            OnClientClick="fnDisplayCatchErrorMessage()" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Unit Type" ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Left"
                                                                    ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <%#DataBinder.Eval(Container.DataItem, "RoomTypeName")%>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <b>Total :</b>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Purchase Amount (Rs.)" ItemStyle-Width="140px" FooterStyle-HorizontalAlign="Right"
                                                                    HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                    <ItemTemplate>
                                                                        <%#DataBinder.Eval(Container.DataItem, "TotalPurchaseAmount")%>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <b>
                                                                            <asp:Literal ID="litPurchaseAmount" runat="server"></asp:Literal></b>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <%--<asp:TemplateField HeaderText="Amount Paid" ItemStyle-Width="140px" FooterStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                        <ItemTemplate>
                                                            <%#DataBinder.Eval(Container.DataItem, "TotalReceivedAmount")%>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <b>
                                                                <asp:Literal ID="litAmountPaid" runat="server"></asp:Literal></b>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>--%>
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
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="tabs-2">
                                            <table cellpadding="2" cellspacing="0" border="0" width="100%">
                                                <tr>
                                                    <td colspan="3">
                                                        <div style="height: 26px;">
                                                            <%if (IsEmail)
                                                              { %>
                                                            <div class="ResetSuccessfully">
                                                                <div style="float: left; padding-top: 7px; width: 25px; height: 24px; margin-right: 10px;">
                                                                    <img src="../../images/success.png" />
                                                                </div>
                                                                <div>
                                                                    <asp:Label ID="lblEmailMsg" runat="server"></asp:Label></div>
                                                                <div style="height: 10px;">
                                                                </div>
                                                            </div>
                                                            <%
                                                              }%>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                            <tr>
                                                                <td style="width: 222px;">
                                                                    <asp:Literal ID="Literal1" runat="server" Text="Property"></asp:Literal>&nbsp;&nbsp;
                                                                    <asp:DropDownList ID="ddlLadgerProperty" runat="server">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td style="vertical-align: bottom;">
                                                                    <asp:ImageButton ID="ibtnFirstSearchLadger" runat="server" ImageUrl="~/images/search-icon.png"
                                                                        OnClick="ibtnSearchLadger_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                                </td>
                                                                <td align="left" valign="middle" style="vertical-align: middle; width: 40px;">
                                                                    From
                                                                </td>
                                                                <td width="165px" align="left" valign="middle" style="vertical-align: middle;">
                                                                    <asp:TextBox ID="txtLedgerDateFrom" runat="server" SkinID="Search" onkeydown="return stopKey(event);"></asp:TextBox>
                                                                    <asp:Image ID="imgtxtLedgerDateFrom" CssClass="small_img" runat="server" Height="20px"
                                                                        Width="20px" ImageUrl="~/images/CalanderIcon.png" />
                                                                    <%--<div style="float:left; display: inline block;">
                                                                        <asp:ImageButton ID="imgtxtLedgerDateFrom" runat="server" Style="" ImageUrl="~/images/CalanderIcon.png"
                                                                            BorderStyle="None" Height="20px" Width="20px" />
                                                                    </div>--%>
                                                                    <ajx:CalendarExtender ID="caltxtLedgerDateFrom" PopupButtonID="imgtxtLedgerDateFrom"
                                                                        CssClass="MyCalendar" TargetControlID="txtLedgerDateFrom" runat="server">
                                                                    </ajx:CalendarExtender>
                                                                    <img src="../../images/clear.png" id="img1" style="vertical-align: middle;" onclick="fnClearDate('<%= txtLedgerDateFrom.ClientID %>');" />
                                                                </td>
                                                                <td align="left" valign="middle" style="vertical-align: middle; width: 25px;">
                                                                    To
                                                                </td>
                                                                <td width="150px" align="left" valign="middle" style="vertical-align: middle;">
                                                                    <asp:TextBox ID="txtLedgerToDate" runat="server" SkinID="Search" onkeydown="return stopKey(event);"></asp:TextBox>
                                                                    <asp:Image ID="imgtxtLedgerToDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                                        Height="20px" Width="20px" />
                                                                    <ajx:CalendarExtender ID="caltxtLedgerToDate" PopupButtonID="imgtxtLedgerToDate"
                                                                        CssClass="MyCalendar" TargetControlID="txtLedgerToDate" runat="server">
                                                                    </ajx:CalendarExtender>
                                                                    <img src="../../images/clear.png" id="img2" style="vertical-align: middle;" onclick="fnClearDate('<%= txtLedgerToDate.ClientID %>');" />
                                                                </td>
                                                                <td style="vertical-align: bottom;">
                                                                    <asp:ImageButton ID="ibtnSearchLadger" runat="server" ImageUrl="~/images/search-icon.png"
                                                                        OnClick="ibtnSearchLadger_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-top: 8px;" colspan="3">
                                                        <b>Ledger Statement</b>
                                                        <hr />
                                                    </td>
                                                </tr>
                                                <tr id="trNoPropertyMessage" runat="server" visible="false">
                                                    <td colspan="3" align="center">
                                                        Please Select Property
                                                    </td>
                                                </tr>
                                                <tr id="trOpeningBalance" runat="server" visible="false">
                                                    <td>
                                                        <div style="float: left;">
                                                            <b>Opening balance</b></div>
                                                        <div style="float: right; padding-right: 8px;">
                                                            <b>
                                                                <asp:Label ID="lblOpeningMilestoneAmount" runat="server"></asp:Label></b></div>
                                                    </td>
                                                    <td style="border-left: 1px solid Gray;">
                                                    </td>
                                                    <td>
                                                        <div style="float: left;">
                                                            <b>Opening balance</b></div>
                                                        <div style="float: right;">
                                                            <b>
                                                                <asp:Label ID="lblOpeningReceivedAmount" runat="server"></asp:Label></b></div>
                                                    </td>
                                                </tr>
                                                <tr id="trGrids" runat="server" visible="false">
                                                    <td width="55%" style="padding-right: 10px;">
                                                        <asp:GridView ID="gvMilestones" runat="server" AutoGenerateColumns="False" Width="100%"
                                                            SkinID="gvNoPaging" OnRowDataBound="gvMilestones_RowDataBound">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Due Date" ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Left"
                                                                    ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDueDate" runat="server"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Unit No." ItemStyle-Width="45px" HeaderStyle-HorizontalAlign="Left"
                                                                    ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblUnitNo" runat="server" Style="width: 45px !important;" Text='<%# DataBinder.Eval(Container.DataItem, "RoomNo") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Milestone title" ItemStyle-Width="105px" HeaderStyle-HorizontalAlign="Left"
                                                                    ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblMilestoneTitle" Style="width: 105px !important;" runat="server"
                                                                            Text='<%# DataBinder.Eval(Container.DataItem, "ProjectMilestone") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <%--<asp:BoundField DataField="RoomNo" HeaderText="Unit No." HeaderStyle-HorizontalAlign="Left"
                                                                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="45px" />
                                                                <asp:BoundField DataField="ProjectMilestone" HeaderText="Milestone title" HeaderStyle-HorizontalAlign="Left"
                                                                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="105px" />--%>
                                                                <asp:TemplateField HeaderText="Amount" ItemStyle-Width="60px" FooterStyle-HorizontalAlign="Right"
                                                                    HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblAmountPayable" runat="server" Style="width: 60px !important;" Text='<%# DataBinder.Eval(Container.DataItem, "AmountPayable") %>'></asp:Label>
                                                                        <%--<%#DataBinder.Eval(Container.DataItem, "AmountPayable")%>--%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
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
                                                    </td>
                                                    <td width="1%" style="border-left: 1px solid Gray;">
                                                    </td>
                                                    <td width="44%">
                                                        <asp:GridView ID="gvReceipts" runat="server" AutoGenerateColumns="False" Width="100%"
                                                            SkinID="gvNoPaging" OnRowDataBound="gvReceipts_RowDataBound">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Date" ItemStyle-Width="110px" HeaderStyle-HorizontalAlign="Left"
                                                                    ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDate" runat="server"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Receipt No." ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left"
                                                                    ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblReceiptNo" runat="server" Style="width: 45px !important;" Text='<%# DataBinder.Eval(Container.DataItem, "ReceiptNo") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <%-- <asp:BoundField DataField="ReceiptNo" HeaderText="Receipt No." HeaderStyle-HorizontalAlign="Left"
                                                                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="150px" />--%>
                                                                <asp:TemplateField HeaderText="Amount" FooterStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right"
                                                                    ItemStyle-HorizontalAlign="Right">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPaidAmount" runat="server" Style="width: 120px !important;" Text='<%# DataBinder.Eval(Container.DataItem, "PaidAmount") %>'></asp:Label>
                                                                        <%--<%#DataBinder.Eval(Container.DataItem, "PaidAmount")%>--%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
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
                                                    </td>
                                                </tr>
                                                <tr id="trHrLine" runat="server" visible="false">
                                                    <td>
                                                        <hr />
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <hr />
                                                    </td>
                                                </tr>
                                                <tr id="trTotal" runat="server" visible="false">
                                                    <td>
                                                        <div style="float: left;">
                                                            <b>Total</b></div>
                                                        <div style="float: right; padding-right: 8px;">
                                                            <b>
                                                                <asp:Label ID="lblTotalPayableAmuont" runat="server"></asp:Label></b></div>
                                                    </td>
                                                    <td style="border-left: 1px solid Gray;">
                                                    </td>
                                                    <td>
                                                        <div style="float: left;">
                                                            <b>Total</b></div>
                                                        <div style="float: right;">
                                                            <b>
                                                                <asp:Label ID="lblTotalReceivedAmount" runat="server"></asp:Label></b></div>
                                                    </td>
                                                </tr>
                                                <tr id="trBalance" runat="server" visible="false">
                                                    <td>
                                                        <div style="float: left;">
                                                            <b>Balance (Credit)</b></div>
                                                        <div style="float: right; padding-right: 8px;">
                                                            <b>
                                                                <asp:Label ID="lblBalaceCreditAmount" runat="server"></asp:Label></b></div>
                                                    </td>
                                                    <td style="border-left: 1px solid Gray;">
                                                    </td>
                                                    <td>
                                                        <div style="float: left;">
                                                            <b>Balance (Due)</b></div>
                                                        <div style="float: right;">
                                                            <b>
                                                                <asp:Label ID="lblBalanceDueAmount" runat="server"></asp:Label></b></div>
                                                    </td>
                                                </tr>
                                                <tr id="trLedgerStatement" runat="server" visible="false">
                                                    <td align="right" valign="middle" colspan="3" style="padding-top: 10px;">
                                                        <asp:ImageButton ID="imgbtnDOC_Ledger" Text="" Style="float: left; margin-left: 5px;
                                                            border: 0px;" ToolTip="ExportToDOC" runat="server" ImageUrl="~/images/report_word.png"
                                                            OnClick="imgbtnDOC_Ledger_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                        <asp:ImageButton ID="imgbtnXLSX_Ledger" Text="" Style="float: left; margin-left: 5px;
                                                            border: 0px;" ToolTip="ExportToXLSX" runat="server" ImageUrl="~/images/report_xlsx.png"
                                                            OnClick="imgbtnXLSX_Ledger_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                        <asp:ImageButton ID="imgbtnPDF_Ledger" Text="" Style="float: left; margin-left: 5px;
                                                            border: 0px;" ToolTip="ExportToPDF" runat="server" ImageUrl="~/images/report_pdf.png"
                                                            OnClick="imgbtnPDF_Ledger_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                        <asp:Button ID="btnPreview_Ledger" Text="Preview" Visible="false" Style="float: left;
                                                            margin-left: 5px;" runat="server" ImageUrl="~/images/save.png" OnClick="btnPreview_Ledger_Click"
                                                            OnClientClick="fnDisplayCatchErrorMessage()" />
                                                        <asp:Button ID="btnPrint_Ledger" Text="Print" Style="float: left; margin-left: 5px;"
                                                            runat="server" ImageUrl="~/images/cancle.png" OnClick="btnPrint_Ledger_Click"
                                                            OnClientClick="fnDisplayCatchErrorMessage()" />
                                                        <asp:Button ID="btnSendEmail" runat="server" Style="float: left; margin-left: 5px;"
                                                            Text="Send Email" OnClick="btnSendEmail_Click" OnClientClick="fnDisplayCatchErrorMessage();" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="tabs-3">
                                            <table cellpadding="2" cellspacing="0" border="0" width="100%">
                                                <tr>
                                                    <td colspan="3">
                                                        <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litSearchProperty" runat="server" Text="Property"></asp:Literal>&nbsp;&nbsp;
                                                                    <asp:DropDownList ID="ddlSearchProperty" runat="server">
                                                                    </asp:DropDownList>
                                                                    <asp:ImageButton ID="btnPropertySearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                                        OnClick="btnPropertySearch_Click" Style="border: 0px; vertical-align: middle;
                                                                        margin: -2px 0 0 10px;" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="dTableBox" style="padding: 10px 0px;">
                                                                    <asp:GridView ID="gvPaymentReceipt" runat="server" AutoGenerateColumns="False" Width="100%"
                                                                        SkinID="gvNoPaging" OnRowDataBound="gvPaymentReceipt_RowDataBound" OnRowCommand="gvPaymentReceipt_RowCommand">
                                                                        <Columns>
                                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblGvHdrProperty" runat="server" Text="Property Name"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "PropertyName")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblGvHdrReceiptNo" runat="server" Text="Receipt No"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "ReceiptNo")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblGvHdrDateToPay" runat="server" Text="Payment Date"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "DateToPay")).ToString(this.DateFormat)%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblGvHdrPaidAmount" runat="server" Text="Amount Paid (Rs.)"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "PaidAmount")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="30px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblGvHdrView" Text="View/Download" runat="server"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%--<a id="aDocumentLink" runat="server" visible="false" target="_blank">
                                                                                        <asp:Image ID="imgView" runat="server" ImageUrl="~/images/view.png" /></a>--%>
                                                                                    <asp:ImageButton ID="imgViewDoc" runat="server" Visible="false" BorderWidth="0px"
                                                                                        ImageUrl="~/images/View.png" CommandName="VIEWDOC" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "DocumentName")%>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <EmptyDataTemplate>
                                                                            <div class="pagecontent_info">
                                                                                <div class="NoItemsFound">
                                                                                    <h2>
                                                                                        <asp:Literal ID="litReceiptRecordNotFound" runat="server" Text="No Record Found"></asp:Literal></h2>
                                                                                </div>
                                                                            </div>
                                                                        </EmptyDataTemplate>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>
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
                    <%--<div class="clear">
                        <uc1:MsgBox ID="MessageBox" runat="server" />
                    </div>--%>
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
        <asp:PostBackTrigger ControlID="gvPaymentReceipt" />
    </Triggers>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updIPL" ID="UpdateProgressIPL" runat="server">
    <ProgressTemplate>
        <div id="progressBackgroundFilter">
        </div>
        <div id="processMessage">
            <center>
                <img src="../../images/ajax-loader.gif" /></center>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
