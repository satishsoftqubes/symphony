<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCheckOut.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Billing.CtrlCheckOut" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<%@ Register Src="~/UIControls/Reservation/PaymentReceipt.ascx" TagName="PaymentReceipt"
    TagPrefix="ucCtrlPaymentReceipt" %>
<%@ Register Src="~/UIControls/Billing/CtrlCheckOutVoucher.ascx" TagName="CheckOutVoucher"
    TagPrefix="ucCheckOutVoucher" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonCounterLogin.ascx" TagName="CommonCounterLogin"
    TagPrefix="ucCtrlCommonCounterLogin" %>
<link type="text/css" href="../../Styles/jquery-ui-1.8.5.custom.css" rel="stylesheet" />
<script type="text/javascript" src="../../Scripts/jquery-1.4.2.min.js"></script>
<script type="text/javascript" src="../../Scripts/jquery-ui-1.8.5.custom.min.js"></script>
<script type="text/javascript">
    function pageLoad(sender, args) {
        var v1 = '<%=ConfigurationManager.AppSettings["IsUpperCase"].ToString() %>'
        if (v1 == "1") {
            $('input[type="text"],textarea').each(function () { $(this).css("text-transform", "uppercase") });
        }
        $("#tabs").tabs();

        $('#tabs').tabs({
            select: function (event, ui) {
                window.location.hash = ui.tab.hash;
            }
        });

    }

    function fnGetTabIndex(operation) {
        var current_tab = $('#tabs').tabs('option', 'selected');
        current_tab++;
        if (operation == 'NEXT') {
            if (current_tab != '4') {
                var selected_tab = current_tab + 1;
                window.location.hash = 'tabs-' + selected_tab;
            }
            else {
                window.location.hash = 'tabs-1';
            }
        }
        else {
            if (current_tab != '1') {
                var selected_tab = current_tab - 1;
                window.location.hash = 'tabs-' + selected_tab;
            }
            else {
                window.location.hash = 'tabs-4'
            }
        }
    }

    function fnopenPrintWindow() {
        $find('mpePrintReceipt').hide();
        var hdnReservationID = document.getElementById('<%= hdnReservationID.ClientID %>').value;
        var hdnBookingID = document.getElementById('<%= hdnBookingID.ClientID %>').value;
        window.open("../Reservation/CheckInPaymentRecipt.aspx?IdofRes=" + hdnReservationID + "&IdofBook=" + hdnBookingID, "CheckInVouche", "height=600,width=600,status=1,toolbar=no,menubar=no,scrollbars=1,location=0");
        return false;
    }
</script>
<script type="text/javascript">
    function fnCompanyInvoicePrint() {
        var hdnReservationID = document.getElementById('<%= hdnReservationID.ClientID %>').value;
        window.open("CompanyInvoicePrint.aspx?ReservationID=" + hdnReservationID, "Company Invoice", "height=600,width=800,status=1,toolbar=no,menubar=no,scrollbars=1,location=0");
    }
</script>
<script type="text/javascript">
    function openViewer() {
        var Preview = '<%=IsPreview%>';
        window.open("../../ReportFiles/frmViewer.aspx?preview=" + Preview);
    }  
</script>
<script type="text/javascript">
    function fnCompanyInvoicePrint() {
        var hdnReservationID = document.getElementById('<%= hdnReservationID.ClientID %>').value;
        window.open("../../GUI/Reservation/CompanyBillPrint.aspx?ReservationID=" + hdnReservationID, "Company Invoice", "height=900,width=850,status=1,toolbar=no,menubar=no,scrollbars=1,location=0");
    }
</script>
<script type="text/javascript">
    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function RoleValidate() {
        var isChecked = false;
        var c = document.getElementsByTagName('input');
        for (var i = 1; i < c.length; i++) {
            if (c[i].type == 'checkbox') {
                if (c[i].checked) {
                    isChecked = true;
                    break;
                }
            }
        }

        if (isChecked == false) {
            $find('mpeCustomePopup').show();
            return false;
        }

    }

    function SelectAll(id) {
        //get reference of GridView control
        var grid = document.getElementById("<%= gvPostChargesGrid.ClientID %>");
        //variable to contain the cell of the grid
        var cell;

        if (grid.rows.length > 0) {
            //loop starts from 1. rows[0] points to the header.
            for (i = 1; i < grid.rows.length; i++) {
                //get the reference of first column
                cell = grid.rows[i].cells[1]; //// define cell column where Checkbox is located.
                //loop according to the number of childNodes in the cell
                for (j = 0; j < cell.childNodes.length; j++) {
                    //if childNode type is CheckBox
                    if (cell.childNodes[j].type == "checkbox") {
                        //assign the status of the Select All checkbox to the cell checkbox within the grid
                        cell.childNodes[j].checked = document.getElementById(id).checked;
                    }
                }
            }
        }
    }
</script>
<style>
    .aabbcc
    {
        border-right-color: Red;
        border-right-style: solid;
        border-bottom-width: 3px;
    }
</style>
<asp:UpdatePanel ID="updCheckOut" runat="server">
    <ContentTemplate>
        <asp:HiddenField ID="hdnReservationID" runat="server" />
        <asp:HiddenField ID="hdnResIDForcmpInvPrint" runat="server" />
        <asp:HiddenField ID="hdnBookingID" runat="server" />
        <asp:MultiView ID="mvCheckOut" runat="server">
            <asp:View ID="vPostCharges" runat="server">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="content">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="boxtopleft">
                                        &nbsp;
                                    </td>
                                    <td class="boxtopcenter">
                                        <asp:Literal ID="litCheckOutProcessOfReservation" runat="server" Text="Check Out"></asp:Literal>
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
                                        <div class="box_form">
                                            <table cellpadding="2" cellspacing="2" width="100%">
                                                <tr style="background-color: #F3F3F5;">
                                                    <td width="33%" style="vertical-align: top; border: 1px solid #ccccce !important;">
                                                        <table cellpadding="2" cellspacing="2" width="100%">
                                                            <tr>
                                                                <th style="width: 75px;" align="left">
                                                                    <asp:Label ID="lblFolioDetailsGuestName" runat="server" Text="Name"></asp:Label>
                                                                </th>
                                                                <td>
                                                                    <asp:Label ID="lblFolioDetailsDisplayGuestName" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th align="left">
                                                                    <asp:Label ID="lblFolioDetailsMobileNo" runat="server" Text="Mobile No."></asp:Label>
                                                                </th>
                                                                <td>
                                                                    <asp:Label ID="lblFolioDetailsDisplayMobileNo" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th align="left">
                                                                    <asp:Label ID="lblFolioDetailsEmail" runat="server" Text="Email"></asp:Label>
                                                                </th>
                                                                <td>
                                                                    <asp:Label ID="lblFolioDetailsDisplayEmail" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td width="33%" style="vertical-align: top; border: 1px solid #ccccce !important;">
                                                        <table cellpadding="2" cellspacing="2" width="100%">
                                                            <tr>
                                                                <th style="width: 75px;" align="left">
                                                                    <asp:Literal ID="litArrivalDate" runat="server" Text="Check In"></asp:Literal>
                                                                </th>
                                                                <td>
                                                                    <asp:Literal ID="litDisplayArrivalDate" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th align="left">
                                                                    <asp:Literal ID="litDepatureDate" runat="server" Text="Check Out"></asp:Literal>
                                                                </th>
                                                                <td>
                                                                    <asp:Literal ID="litDisplayDepatureDate" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th align="left">
                                                                    <asp:Literal ID="litFolioNo" runat="server" Text="Booking #"></asp:Literal>
                                                                </th>
                                                                <td>
                                                                    <asp:Literal ID="litDisplayFolioNo" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td style="vertical-align: top; border: 1px solid #ccccce !important;">
                                                        <table cellpadding="2" cellspacing="2" width="100%">
                                                            <tr>
                                                                <th style="width: 75px;" align="left">
                                                                    <asp:Literal ID="litUnitNo" runat="server" Text="Room No."></asp:Literal>
                                                                </th>
                                                                <td>
                                                                    <asp:Literal ID="litDisplayUnitNo" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th align="left">
                                                                    <asp:Literal ID="litRoomType" runat="server" Text="Room Type"></asp:Literal>
                                                                </th>
                                                                <td>
                                                                    <asp:Literal ID="litDisplayRoomType" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th align="left">
                                                                    <asp:Literal ID="litRateCard" runat="server" Text="Rate Card"></asp:Literal>
                                                                </th>
                                                                <td>
                                                                    <asp:Literal ID="litDisplayRateCard" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <div style="height: 10px;">
                                                    &nbsp;
                                                </div>
                                            </table>
                                            <div class="demo">
                                                <div id="tabs">
                                                    <ul>
                                                        <li><a href="#tabs-1" onclick="fnChangeValue('1015.00');">
                                                            <asp:Literal ID="littabProfile" runat="server" Text="Room Rent"></asp:Literal></a></li>
                                                        <%--<li><a href="#tabs-2" onclick="fnChangeValue('200.00');">
                                                                <asp:Literal ID="littabStayHistory" runat="server" Text="Cash Card"></asp:Literal></a></li>
                                                            <li><a href="#tabs-3" onclick="fnChangeValue('1015.00');">
                                                                <asp:Literal ID="littabCashcardInfo" runat="server" Text="Feedback"></asp:Literal></a></li>--%>
                                                        <li><a href="#tabs-2" onclick="fnChangeValue('1000.00');">
                                                            <asp:Literal ID="littabPreference" runat="server" Text="Account Settlement"></asp:Literal></a></li>
                                                    </ul>
                                                    <div id="tabs-1">
                                                        <table width="100%">
                                                            <tr id="trCheckOutNote" runat="server" visible="false">
                                                                <td colspan="3" style="padding-left:5px; background-color: #218ccb; border: 2px solid Red;">
                                                                    <asp:Label ID="lblCheckOutNote" runat="server" Font-Bold="true" ForeColor="White"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="40%" style="vertical-align: top;">
                                                                    <asp:Literal ID="ltrChkPmtGuestName" runat="server" Visible="false"></asp:Literal>
                                                                    <table width="100%" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                <b>Particulars</b>
                                                                            </td>
                                                                            <td align="center">
                                                                                <b>No. of Nights</b>
                                                                            </td>
                                                                            <td align="right">
                                                                                <b>Amount (Rs.)</b>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="padding: 0px;" colspan="3">
                                                                                <hr />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Room Rent
                                                                            </td>
                                                                            <td align="center">
                                                                                <asp:Label ID="lblDisplayNoOfDays" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td align="right">
                                                                                <asp:Label ID="lblDisplayRoomRent" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Tax
                                                                            </td>
                                                                            <td align="center">
                                                                                -
                                                                            </td>
                                                                            <td align="right">
                                                                                <asp:Label ID="lblDisplayTax" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="padding: 0px;" colspan="3">
                                                                                <hr />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <b>Total Charges</b>
                                                                            </td>
                                                                            <td align="center">
                                                                                -
                                                                            </td>
                                                                            <td align="right">
                                                                                <b>
                                                                                    <asp:Label ID="lblDisplayTotalAmount" runat="server"></asp:Label></b>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Deposit
                                                                            </td>
                                                                            <td align="center">
                                                                                -
                                                                            </td>
                                                                            <td align="right">
                                                                                <asp:Label ID="lblDisplayDepositAmount" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="padding: 0px;" colspan="3">
                                                                                <hr />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <b>Total Amount Payable</b>
                                                                            </td>
                                                                            <td align="center">
                                                                                -
                                                                            </td>
                                                                            <td align="right">
                                                                                <b>
                                                                                    <asp:Label ID="lblTotalAmountPayable" runat="server"></asp:Label></b>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td style="border-left: 1px solid #CCCCCC; display: none;">
                                                                </td>
                                                                <td width="60%" style="vertical-align: top;">
                                                                    <table width="100%" cellpadding="0" cellspacing="0" style="display: none;">
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                <b>Payment Received</b>
                                                                                <hr />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="140px">
                                                                                <asp:Literal ID="Literal6" runat="server" Text="Total Amount Payable"></asp:Literal>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblDisplayAmount" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" style="padding: 0px;">
                                                                                <hr />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Literal ID="Literal8" runat="server" Text="Total Amount Received"></asp:Literal>
                                                                            </td>
                                                                            <td>
                                                                                <b>
                                                                                    <asp:Label ID="lblDisplayTotalAmountReceived" runat="server"></asp:Label></b>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" style="padding: 0px;">
                                                                                <hr />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <b>Balance Amount (<asp:Label ID="lblDisplayBalanceAmountDueOrCredit" runat="server"></asp:Label>)</b>
                                                                            </td>
                                                                            <td>
                                                                                <b>
                                                                                    <asp:Label ID="lblDisplayBalanceAmount" runat="server"></asp:Label></b>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div style="display: none;" id="tabs-2a">
                                                        <table width="100%" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td colspan="4">
                                                                    <b>Cash Card Statement</b>
                                                                    <hr />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="60px">
                                                                    <asp:Literal ID="litSearchFromDate" runat="server" Text="From"></asp:Literal>
                                                                </td>
                                                                <td width="250px">
                                                                    <asp:TextBox ID="txtSearchFromDate" runat="server" Style="width: 140px !important;"
                                                                        SkinID="searchtextbox" onkeypress="return false;"></asp:TextBox>
                                                                    <asp:Image ID="imgFromDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                                        Height="20px" Width="20px" />
                                                                    <ajx:CalendarExtender ID="calArrivalDate" PopupButtonID="imgFromDate" TargetControlID="txtSearchFromDate"
                                                                        runat="server" Format="dd/MMM/yyyy">
                                                                    </ajx:CalendarExtender>
                                                                    <img src="../../images/clear.png" id="img1" style="vertical-align: middle;" title="Clear Date"
                                                                        onclick="fnClearDate('<%= txtSearchFromDate.ClientID %>');" />
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="litSearchToDate" runat="server" Text="To"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtSearchToDate" runat="server" Style="width: 140px !important;"
                                                                        SkinID="searchtextbox" onkeypress="return false;"></asp:TextBox>
                                                                    <asp:Image ID="imgToDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                                        Height="20px" Width="20px" />
                                                                    <ajx:CalendarExtender ID="calToDate" PopupButtonID="imgToDate" TargetControlID="txtSearchToDate"
                                                                        runat="server" Format="dd/MMM/yyyy">
                                                                    </ajx:CalendarExtender>
                                                                    <img src="../../images/clear.png" id="img2" style="vertical-align: middle;" title="Clear Date"
                                                                        onclick="fnClearDate('<%= txtSearchToDate.ClientID %>');" />
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/search-icon.png"
                                                                        Style="border: 0px; margin: -4px 0 0 5px; vertical-align: middle;" />
                                                                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/clearsearch.png"
                                                                        Style="border: 0px; vertical-align: middle; margin: 0 0 0 10px;" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding-top: 8px;" colspan="4">
                                                                    <div class="box_content">
                                                                        <asp:GridView ID="gvCashcardStatement" runat="server" AutoGenerateColumns="false"
                                                                            ShowHeader="true" Width="100%">
                                                                            <Columns>
                                                                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrDate" runat="server" Text="Date"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%#DataBinder.Eval(Container.DataItem, "Date")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrCreditTransactionNo" runat="server" Text="Transaction No."></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%#DataBinder.Eval(Container.DataItem, "CreditTransactionID")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrCreditAmount" runat="server" Text="Credit"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%#DataBinder.Eval(Container.DataItem, "CreditAmount")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="100px" ItemStyle-CssClass="aabbcc" HeaderStyle-HorizontalAlign="Left"
                                                                                    ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrPaymentMode" runat="server" Text="Mode"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%#DataBinder.Eval(Container.DataItem, "PaymentMode")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrExpence" runat="server" Text="Expence"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%#DataBinder.Eval(Container.DataItem, "Expence")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrDebitTransactionNo" runat="server" Text="Transaction No."></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%#DataBinder.Eval(Container.DataItem, "DebitTransactionID")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrDebitAmount" runat="server" Text="Debit"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%#DataBinder.Eval(Container.DataItem, "DebitAmount")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrBalanceAmount" runat="server" Text="Balance"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%#DataBinder.Eval(Container.DataItem, "Balance")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                            <EmptyDataTemplate>
                                                                                <div style="padding: 10px;">
                                                                                    <b>
                                                                                        <asp:Label ID="lblNoRecordFoundForCardList" runat="server" Text="No Record Found."></asp:Label>
                                                                                    </b>
                                                                                </div>
                                                                            </EmptyDataTemplate>
                                                                        </asp:GridView>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div style="display: none;" id="tabs-3a">
                                                        <table width="100%" border="0">
                                                            <tr>
                                                                <td colspan="3">
                                                                    <%if (IsGstFeedBackMessage)
                                                                      { %>
                                                                    <div class="ResetSuccessfully">
                                                                        <div style="float: left; padding-top: 7px; width: 25px; height: 24px; margin-right: 10px;">
                                                                            <img src="../../images/success.png" />
                                                                        </div>
                                                                        <div>
                                                                            <asp:Label ID="lblFeedbackMsg" runat="server"></asp:Label></div>
                                                                        <div style="height: 10px;">
                                                                        </div>
                                                                    </div>
                                                                    <% }%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="50%" style="vertical-align: top;">
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td style="padding: 0px;">
                                                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            <b>Guest Preferences</b>
                                                                                        </td>
                                                                                        <td align="right">
                                                                                            <asp:Button ID="btnAddPreferences" runat="server" Text="Add" Height="20px" OnClick="btnAddPreferences_Click" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <hr />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <div class="box_content">
                                                                                    <asp:GridView ID="gvGuestPreferences" runat="server" AutoGenerateColumns="false"
                                                                                        ShowHeader="true" Width="100%">
                                                                                        <Columns>
                                                                                            <asp:TemplateField ItemStyle-Width="30px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                <HeaderTemplate>
                                                                                                    <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                                                                                </HeaderTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <%# Container.DataItemIndex + 1 %>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                <HeaderTemplate>
                                                                                                    <asp:Label ID="lblGvHdrPreference" runat="server" Text="Preferences"></asp:Label>
                                                                                                </HeaderTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblGvPreference" runat="server" Text='<%#TruncateString(DataBinder.Eval(Container.DataItem, "Preference").ToString(), 35)%>'></asp:Label>
                                                                                                    <ajx:HoverMenuExtender ID="hmePreference" runat="server" TargetControlID="lblGvPreference"
                                                                                                        PopupControlID="pnlPreference" PopupPosition="Right">
                                                                                                    </ajx:HoverMenuExtender>
                                                                                                    <asp:Panel ID="pnlPreference" runat="server" Style="visibility: hidden; opacity: 100%"
                                                                                                        BorderColor="#000000" BorderStyle="Solid" BorderWidth="1px">
                                                                                                        <table border="0" cellpadding="0" cellspacing="0" class="tooltip_hover_lettmenu_table">
                                                                                                            <tr>
                                                                                                                <td style="background-color: #FFFFF0">
                                                                                                                    <%#DataBinder.Eval(Container.DataItem, "Preference")%>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </asp:Panel>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                        <EmptyDataTemplate>
                                                                                            <div style="padding: 10px;">
                                                                                                <b>
                                                                                                    <asp:Label ID="lblNoRecordFound" Text="No Record Found." runat="server"></asp:Label>
                                                                                                </b>
                                                                                            </div>
                                                                                        </EmptyDataTemplate>
                                                                                    </asp:GridView>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td style="border-left: 1px solid #CCCCCC;">
                                                                </td>
                                                                <td width="50%" style="vertical-align: top;">
                                                                    <table width="100%" style="vertical-align: top;">
                                                                        <tr>
                                                                            <td style="padding: 0px;">
                                                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            <b>Management Note</b>
                                                                                        </td>
                                                                                        <td align="right">
                                                                                            <asp:Button ID="btnAddMgmtNote" runat="server" Text="Add" Height="20px" OnClick="btnAddMgmtNote_Click" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <hr />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <div class="box_content">
                                                                                    <asp:GridView ID="gvFrontDesksNote" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                                        Width="100%">
                                                                                        <Columns>
                                                                                            <asp:TemplateField ItemStyle-Width="30px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                <HeaderTemplate>
                                                                                                    <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                                                                                </HeaderTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <%# Container.DataItemIndex + 1 %>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                <HeaderTemplate>
                                                                                                    <asp:Label ID="lblGvHdrPreference" runat="server" Text="Notes"></asp:Label>
                                                                                                </HeaderTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblGvFrontDesksNote" runat="server" Text='<%#TruncateString(DataBinder.Eval(Container.DataItem, "Notes").ToString(), 25)%>'></asp:Label>
                                                                                                    <ajx:HoverMenuExtender ID="hmeFrontDesksNote" runat="server" TargetControlID="lblGvFrontDesksNote"
                                                                                                        PopupControlID="pnlFrontDesksNote" PopupPosition="Right">
                                                                                                    </ajx:HoverMenuExtender>
                                                                                                    <asp:Panel ID="pnlFrontDesksNote" runat="server" Style="visibility: hidden; opacity: 100%"
                                                                                                        BorderColor="#000000" BorderStyle="Solid" BorderWidth="1px">
                                                                                                        <table border="0" cellpadding="0" cellspacing="0" class="tooltip_hover_lettmenu_table">
                                                                                                            <tr>
                                                                                                                <td style="background-color: #FFFFF0">
                                                                                                                    <%#DataBinder.Eval(Container.DataItem, "Notes")%>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </asp:Panel>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                <HeaderTemplate>
                                                                                                    <asp:Label ID="lblGvHdrPreference" runat="server" Text="Note By"></asp:Label>
                                                                                                </HeaderTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <%#DataBinder.Eval(Container.DataItem, "UserDisplayName")%>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                <HeaderTemplate>
                                                                                                    <asp:Label ID="lblGvHdrDate" runat="server" Text="Date"></asp:Label>
                                                                                                </HeaderTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <%#DataBinder.Eval(Container.DataItem, "NoteOn", "{0:dd-MM-yyyy}")%>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                        <EmptyDataTemplate>
                                                                                            <div style="padding: 10px;">
                                                                                                <b>
                                                                                                    <asp:Label ID="lblNoRecordFound" Text="No Record Found." runat="server"></asp:Label>
                                                                                                </b>
                                                                                            </div>
                                                                                        </EmptyDataTemplate>
                                                                                    </asp:GridView>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3">
                                                                    <hr />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="50%" style="vertical-align: top;">
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td style="padding: 0px;">
                                                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            <b>Feedback</b>
                                                                                        </td>
                                                                                        <td align="right">
                                                                                            <asp:Button ID="btnAddFeedBack" runat="server" Text="Add" Height="20px" OnClick="btnAddFeedBack_Click" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <hr />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <div class="box_content">
                                                                                    <asp:GridView ID="gvFeedbacks" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                                        Width="100%">
                                                                                        <Columns>
                                                                                            <asp:TemplateField ItemStyle-Width="30px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                <HeaderTemplate>
                                                                                                    <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                                                                                </HeaderTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <%# Container.DataItemIndex + 1 %>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                <HeaderTemplate>
                                                                                                    <asp:Label ID="lblGvHdrFeedback" runat="server" Text="Feedback"></asp:Label>
                                                                                                </HeaderTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblgvFeedbacks" runat="server" Text='<%#TruncateString(DataBinder.Eval(Container.DataItem, "Comment").ToString(), 25)%>'></asp:Label>
                                                                                                    <ajx:HoverMenuExtender ID="hmeFeedbacks" runat="server" TargetControlID="lblgvFeedbacks"
                                                                                                        PopupControlID="pnlFeedbacks" PopupPosition="Right">
                                                                                                    </ajx:HoverMenuExtender>
                                                                                                    <asp:Panel ID="pnlFeedbacks" runat="server" Style="visibility: hidden; opacity: 100%"
                                                                                                        BorderColor="#000000" BorderStyle="Solid" BorderWidth="1px">
                                                                                                        <table border="0" cellpadding="0" cellspacing="0" class="tooltip_hover_lettmenu_table">
                                                                                                            <tr>
                                                                                                                <td style="background-color: #FFFFF0">
                                                                                                                    <%#DataBinder.Eval(Container.DataItem, "Comment")%>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </asp:Panel>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                <HeaderTemplate>
                                                                                                    <asp:Label ID="lblGvHdrDepartment" runat="server" Text="Department"></asp:Label>
                                                                                                </HeaderTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <%#DataBinder.Eval(Container.DataItem, "DepartmentName")%>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                <HeaderTemplate>
                                                                                                    <asp:Label ID="lblGvHdrDate" runat="server" Text="Date"></asp:Label>
                                                                                                </HeaderTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <%#DataBinder.Eval(Container.DataItem, "CreatedOn", "{0:dd-MM-yyyy}")%>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                        <EmptyDataTemplate>
                                                                                            <div style="padding: 10px;">
                                                                                                <b>
                                                                                                    <asp:Label ID="lblNoRecordFound" Text="No Record Found." runat="server"></asp:Label>
                                                                                                </b>
                                                                                            </div>
                                                                                        </EmptyDataTemplate>
                                                                                    </asp:GridView>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td style="border-left: 1px solid #CCCCCC;">
                                                                </td>
                                                                <td width="50%" style="vertical-align: top;">
                                                                    <table width="100%" style="vertical-align: top;">
                                                                        <tr>
                                                                            <td style="padding: 0px;">
                                                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            <b>Complaint</b>
                                                                                        </td>
                                                                                        <td align="right">
                                                                                            <asp:Button ID="btnAddCompalin" runat="server" Text="Add" Height="20px" OnClick="btnAddCompalin_Click" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <hr />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <div class="box_content">
                                                                                    <asp:GridView ID="gvComplains" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                                        Width="100%">
                                                                                        <Columns>
                                                                                            <asp:TemplateField ItemStyle-Width="30px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                <HeaderTemplate>
                                                                                                    <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                                                                                </HeaderTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <%# Container.DataItemIndex + 1 %>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                <HeaderTemplate>
                                                                                                    <asp:Label ID="lblGvHdrFeedback" runat="server" Text="Complain"></asp:Label>
                                                                                                </HeaderTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblgvComplains" runat="server" Text='<%#TruncateString(DataBinder.Eval(Container.DataItem, "ComplaintDescription").ToString(), 25)%>'></asp:Label>
                                                                                                    <ajx:HoverMenuExtender ID="hmeComplains" runat="server" TargetControlID="lblgvComplains"
                                                                                                        PopupControlID="pnlComplains" PopupPosition="Right">
                                                                                                    </ajx:HoverMenuExtender>
                                                                                                    <asp:Panel ID="pnlComplains" runat="server" Style="visibility: hidden; opacity: 100%"
                                                                                                        BorderColor="#000000" BorderStyle="Solid" BorderWidth="1px">
                                                                                                        <table border="0" cellpadding="0" cellspacing="0" class="tooltip_hover_lettmenu_table">
                                                                                                            <tr>
                                                                                                                <td style="background-color: #FFFFF0">
                                                                                                                    <%#DataBinder.Eval(Container.DataItem, "ComplaintDescription")%>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </asp:Panel>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                <HeaderTemplate>
                                                                                                    <asp:Label ID="lblGvHdrDepartment" runat="server" Text="Department"></asp:Label>
                                                                                                </HeaderTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <%#DataBinder.Eval(Container.DataItem, "DepartmentName")%>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                <HeaderTemplate>
                                                                                                    <asp:Label ID="lblGvHdrDate" runat="server" Text="Date"></asp:Label>
                                                                                                </HeaderTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <%#DataBinder.Eval(Container.DataItem, "DateOfComplain", "{0:dd-MM-yyyy}")%>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                        <EmptyDataTemplate>
                                                                                            <div style="padding: 10px;">
                                                                                                <b>
                                                                                                    <asp:Label ID="lblNoRecordFound" Text="No Record Found." runat="server"></asp:Label>
                                                                                                </b>
                                                                                            </div>
                                                                                        </EmptyDataTemplate>
                                                                                    </asp:GridView>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div id="tabs-2">
                                                        <table width="100%" cellpadding="0" cellspacing="0">
                                                            <tr id="trCheckOutNote1" runat="server" visible="false">
                                                                <td colspan="3" style="padding-left:5px; background-color: #218ccb; border: 2px solid Red;">
                                                                    <asp:Label ID="lblCheckOutNote1" runat="server" Font-Bold="true" ForeColor="White"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="50%" style="vertical-align: top; padding-right: 8px;">
                                                                    <table width="80%">
                                                                        <tr>
                                                                            <td width="100px">
                                                                                <b>Summary</b>
                                                                            </td>
                                                                            <td align="right">
                                                                                <b>Charge</b>
                                                                            </td>
                                                                            <td align="right">
                                                                                <b>Credit</b>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="padding: 0px;" colspan="3">
                                                                                <hr />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Room Rent
                                                                            </td>
                                                                            <td align="right">
                                                                                <asp:Label ID="lblSmryRoomRentDebit" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td align="right">
                                                                                -
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Misc. Charges
                                                                            </td>
                                                                            <td align="right">
                                                                                <asp:Label ID="lblSmryServicesChargeDebit" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td align="right">
                                                                                -
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Receipt
                                                                            </td>
                                                                            <td align="right">
                                                                                -
                                                                            </td>
                                                                            <td align="right">
                                                                                <asp:Label ID="lblSmryPaymentCredit" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr style="display: none;">
                                                                            <td>
                                                                                Cash Card
                                                                            </td>
                                                                            <td align="right">
                                                                                -
                                                                            </td>
                                                                            <td align="right">
                                                                                <asp:Label ID="lblSmryCashCardCredit" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Deposit
                                                                            </td>
                                                                            <td align="right">
                                                                                -
                                                                            </td>
                                                                            <td align="right">
                                                                                <asp:Label ID="lblSmryDepositCredit" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="padding: 0px;" colspan="3">
                                                                                <hr />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Total
                                                                            </td>
                                                                            <td align="right">
                                                                                <asp:Label ID="lblSmryTotalDebit" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td align="right">
                                                                                <asp:Label ID="lblSmryTotalCredit" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <b>Balance (<asp:Label ID="lblSmryTotalDebitOrCredit" runat="server"></asp:Label>)</b>
                                                                            </td>
                                                                            <td align="right">
                                                                                -
                                                                            </td>
                                                                            <td align="right">
                                                                                <b>
                                                                                    <asp:Label ID="lblSmryNetBalanceAmount" runat="server"></asp:Label></b>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td style="border-left: 1px solid #CCCCCC;">
                                                                </td>
                                                                <td style="vertical-align: top;">
                                                                    <div style="height: 200px; overflow: auto;">
                                                                        <div class="box_head" style="display: none;">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td align="left">
                                                                                        <span>
                                                                                            <asp:Literal ID="Literal3" runat="server" Text="Recovery"></asp:Literal>
                                                                                        </span>
                                                                                    </td>
                                                                                    <td align="right" style="padding-right: 15px;">
                                                                                        <asp:ImageButton ID="imgRecovery" runat="server" ImageUrl="~/images/plus_button_orange.png"
                                                                                            OnClick="imgRecovery_OnClick" Style="padding-left: 385px; padding-top: 0px; border: none;
                                                                                            height: 16px;" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                        <div class="box_head">
                                                                            <span>
                                                                                <asp:Literal ID="litFolioDetails" runat="server" Text="Folio Details"></asp:Literal>
                                                                            </span>
                                                                        </div>
                                                                        <div class="clear">
                                                                        </div>
                                                                        <div class="box_content">
                                                                            <asp:GridView ID="gvRecovery" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                                Width="100%" Visible="false">
                                                                                <Columns>
                                                                                    <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <%# Container.DataItemIndex + 1 %>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                        <ItemTemplate>
                                                                                            <asp:CheckBox ID="chkGvSelectAll" runat="server" />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblGvHdrDescription" runat="server" Text="Recovery Type"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <%#DataBinder.Eval(Container.DataItem, "Description")%>
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
                                                                                    <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblGvHdrAmount" runat="server" Text="Amount"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <%#DataBinder.Eval(Container.DataItem, "Amount")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                                <EmptyDataTemplate>
                                                                                    <div style="padding: 10px;">
                                                                                        <b>
                                                                                            <asp:Label ID="lblNoRecordFoundForCardList" runat="server" Text="No Record Found."></asp:Label>
                                                                                        </b>
                                                                                    </div>
                                                                                </EmptyDataTemplate>
                                                                            </asp:GridView>
                                                                            <asp:GridView ID="gvFolioDetails" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                                Width="100%" OnRowDataBound="gvFolioDetails_RowDataBound" SkinID="gvNoPaging"
                                                                                OnPageIndexChanging="gvFolioDetails_PageIndexChanging" DataKeyNames="GuestName,ReservationNo,FolioNo,EntryDate,DisplayAmount,IsVoid,RoomNo,BookID"
                                                                                ShowFooter="true">
                                                                                <Columns>
                                                                                    <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblGvHdrFolioDetailsDate" runat="server" Text="Date"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblGvFolioDetailsDate" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "EntryDate")).ToString(clsSession.DateFormat)%>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblGvHdrFolioDetailsTransaction" runat="server" Text="Trans. #"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblGvFolioDetailsBookNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "BookNo")%>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblGvHdrFolioDetailsAccount" runat="server" Text="Ledger Account"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <%#DataBinder.Eval(Container.DataItem, "Account")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" Visible="false" ItemStyle-HorizontalAlign="Left">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblGvHdrFolioDetailsDescription" runat="server" Text="Description"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblGvFolioDetailsDescription" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Narration")%>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <FooterTemplate>
                                                                                            <b>Total</b>
                                                                                        </FooterTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                                                                        FooterStyle-HorizontalAlign="Right">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblGvHdrFolioDetailsCharges" runat="server" Text="Charge"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblGvCharges" runat="server"></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <FooterTemplate>
                                                                                            <b>
                                                                                                <asp:Label ID="lblGvFtTotalCharge" runat="server"></asp:Label></b>
                                                                                        </FooterTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                                                                        FooterStyle-HorizontalAlign="Right">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblGvHdrFolioDetailsPayment" runat="server" Text="Credit"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblGvPayment" runat="server"></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <FooterTemplate>
                                                                                            <b>
                                                                                                <asp:Label ID="lblGvFtTotalPayment" runat="server"></asp:Label></b>
                                                                                        </FooterTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                                                                        FooterStyle-HorizontalAlign="Right">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblGvHdrFolioDetailsBalance" runat="server" Text="Balance"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblBalance" runat="server"></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <FooterTemplate>
                                                                                            <b>
                                                                                                <asp:Label ID="lblGvFtFinalBalance" runat="server"></asp:Label></b>
                                                                                        </FooterTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                                <EmptyDataTemplate>
                                                                                    <div style="padding: 10px;">
                                                                                        <b>
                                                                                            <asp:Label ID="lblFolioDetailsNoRecordFound" runat="server" Text="No Record Found."></asp:Label>
                                                                                        </b>
                                                                                    </div>
                                                                                </EmptyDataTemplate>
                                                                            </asp:GridView>
                                                                        </div>
                                                                    </div>
                                                                    <div style="height: 10px;">
                                                                    </div>
                                                                    <div style="float: left;">
                                                                        <%--<asp:Button ID="Button1" runat="server" Text="Post" Style="display: inline;" />
                                                                            <asp:Button ID="Button2" runat="server" Text="Delete" Style="display: inline;" />--%>
                                                                    </div>
                                                                    <div style="float: right; text-align: right; width: 100px; background-color: #F3F3F5;
                                                                        color: #0083CE; font-size: 15px; font-weight: bold; padding: 5px; display: none">
                                                                        <b>0.00 </b>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3" style="padding: 0px;">
                                                                    <hr />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="50%" style="vertical-align: top; padding-right: 8px;">
                                                                    <div class="box_head">
                                                                        <div>
                                                                            <div style="float: left;">
                                                                                <span>
                                                                                    <asp:Literal ID="litUnpostedTransactions" runat="server" Text="Unposted Transactions"></asp:Literal>
                                                                                </span>
                                                                            </div>
                                                                            <div style="float: right; padding-right: 15px;">
                                                                                <asp:LinkButton ID="lnkViewUnpostedTransDetail" runat="server" Text="View Detail"
                                                                                    ForeColor="#0067A4" OnClick="lnkViewUnpostedTransDetail_OnClick"></asp:LinkButton>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div style="height: 125px; overflow: auto;">
                                                                        <div class="clear">
                                                                        </div>
                                                                        <div>
                                                                            <asp:MultiView ID="mvUnpostedTransactions" runat="server">
                                                                                <asp:View ID="vUnpostedTransSummary" runat="server">
                                                                                    <div>
                                                                                        <table width="100%" cellpadding="5px" cellspacing="5px" border="0px">
                                                                                            <tr>
                                                                                                <td>
                                                                                                    Unposted transaction charges
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:Literal ID="ltrUnPostedChargesSummary" runat="server"></asp:Literal>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    Retention charges on unposted transaction charges
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:Literal ID="ltrUnPostedChargesToApplyInPercentage" runat="server"></asp:Literal>
                                                                                                    &nbsp;%
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    Retention charges
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:Literal ID="ltrUnpostedChargesEarlyCheckOutCharge" runat="server"></asp:Literal>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    &nbsp;
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </div>
                                                                                </asp:View>
                                                                                <asp:View ID="vUnpostedTransDetail" runat="server">
                                                                                    <div class="box_content">
                                                                                        <asp:GridView ID="gvPostChargesGrid" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                                            AllowPaging="false" Width="100%" OnRowDataBound="gvPostChargesGrid_RowDataBound"
                                                                                            DataKeyNames="ResBlockDateRateID,ResServiceID,RateCardRate" SkinID="gvNoPaging">
                                                                                            <Columns>
                                                                                                <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                    <HeaderTemplate>
                                                                                                        <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                                                                                    </HeaderTemplate>
                                                                                                    <ItemTemplate>
                                                                                                        <%# Container.DataItemIndex + 1 %>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <%--<asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                        <HeaderTemplate>
                                                                                                            <asp:CheckBox ID="chkSelectAll" runat="server" />
                                                                                                        </HeaderTemplate>
                                                                                                        <ItemTemplate>
                                                                                                            <asp:CheckBox ID="chkGvSelect" runat="server" />
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>--%>
                                                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                    <HeaderTemplate>
                                                                                                        <asp:Label ID="lblGvHdrDescription" runat="server" Text="Description"></asp:Label>
                                                                                                    </HeaderTemplate>
                                                                                                    <ItemTemplate>
                                                                                                        <%#DataBinder.Eval(Container.DataItem, "Description")%>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                    <HeaderTemplate>
                                                                                                        <asp:Label ID="lblGvHdrDate" runat="server" Text="Date"></asp:Label>
                                                                                                    </HeaderTemplate>
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblServiceDate" runat="server"></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                                                    <HeaderTemplate>
                                                                                                        <asp:Label ID="lblGvHdrAmount" runat="server" Text="Amount"></asp:Label>
                                                                                                    </HeaderTemplate>
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblAmount" runat="server"></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                            </Columns>
                                                                                            <EmptyDataTemplate>
                                                                                                <div style="padding: 10px;">
                                                                                                    <b>
                                                                                                        <asp:Label ID="lblNoRecordFoundForCardList" runat="server" Text="No Record Found."></asp:Label>
                                                                                                    </b>
                                                                                                </div>
                                                                                            </EmptyDataTemplate>
                                                                                        </asp:GridView>
                                                                                    </div>
                                                                                    <div style="float: right; text-align: right; width: 100px; background-color: #F3F3F5;
                                                                                        color: #0083CE; font-size: 15px; font-weight: bold; padding: 5px;">
                                                                                        <b>
                                                                                            <asp:Label ID="lblTotalUnpostedCharge" runat="server"></asp:Label></b>
                                                                                    </div>
                                                                                </asp:View>
                                                                                <asp:View ID="vPostTodaysCharges" runat="server">
                                                                                    <div style="padding-top: 15px;">
                                                                                        Do you want to post today's charge? &nbsp;&nbsp;&nbsp;
                                                                                        <asp:Button ID="btnPostTodaysCharge" runat="server" Text="Yes" OnClick="btnPostTodaysCharge_OnClick"
                                                                                            Style="display: inline;" />
                                                                                        <asp:Button ID="btnCancelPostTodaysCharge" runat="server" Text="No" OnClick="btnCancelPostTodaysCharge_OnClick"
                                                                                            Style="display: inline;" />
                                                                                    </div>
                                                                                </asp:View>
                                                                            </asp:MultiView>
                                                                        </div>
                                                                    </div>
                                                                    <div style="height: 10px;">
                                                                    </div>
                                                                    <div style="float: right; padding-right: 15px;">
                                                                        <asp:Button ID="btnApplyEarlyCheckOutCharge" runat="server" Text="Apply" OnClick="btnApplyEarlyCheckOutCharge_OnClick"
                                                                            Style="display: inline;" />
                                                                        <%--<asp:Button ID="btnPostCheckedUnpostedCharges" runat="server" Text="Post" Style="display: inline;"
                                                                                OnClick="btnPostCheckedUnpostedCharges_Click" />
                                                                            <asp:Button ID="btnDeleteCheckedUnpostedCharges" runat="server" Text="Delete" Style="display: inline;"
                                                                                OnClick="btnDeleteCheckedUnpostedCharges_Click" OnClientClick="return RoleValidate()" />--%>
                                                                    </div>
                                                                </td>
                                                                <td style="border-left: 1px solid #CCCCCC;">
                                                                </td>
                                                                <td width="50%" style="vertical-align: top;">
                                                                    <div style="height: 160px; overflow: auto;">
                                                                        <div class="box_head">
                                                                            <span>
                                                                                <asp:Literal ID="Literal5" runat="server" Text="Deposits"></asp:Literal>
                                                                            </span>
                                                                        </div>
                                                                        <div class="clear">
                                                                        </div>
                                                                        <div class="box_content">
                                                                            <asp:GridView ID="gvDeposits" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                                Width="100%" OnRowDataBound="gvDeposits_RowDataBound" DataKeyNames="BookID" AllowPaging="false">
                                                                                <Columns>
                                                                                    <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <%# Container.DataItemIndex + 1 %>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                        <HeaderTemplate>
                                                                                            <%--<asp:CheckBox ID="chkGvHdrSelectAll" runat="server" />--%>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:CheckBox ID="chkGvSelect" runat="server" />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblGvHdrDescription" runat="server" Text="Description"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <%--<%#DataBinder.Eval(Container.DataItem, "Description")%>--%>
                                                                                            <asp:Label ID="lblDepositDescription" runat="server" Text="ROOM DEPOSIT"></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblGvHdrDate" runat="server" Text="Date"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblEntryDate" runat="server"></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblGvHdrAmount" runat="server" Text="Amount"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblAmount" runat="server"></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                                <EmptyDataTemplate>
                                                                                    <div style="padding: 10px;">
                                                                                        <b>
                                                                                            <asp:Label ID="lblNoRecordFoundForCardList" runat="server" Text="No Record Found."></asp:Label>
                                                                                        </b>
                                                                                    </div>
                                                                                </EmptyDataTemplate>
                                                                            </asp:GridView>
                                                                        </div>
                                                                    </div>
                                                                    <div style="height: 10px;">
                                                                    </div>
                                                                    <div style="float: left;">
                                                                        <%--<asp:Button ID="btnRefundCheckedDeposits" runat="server" OnClick="btnRefundCheckedDeposits_OnClick"
                                                                                Text="Refund" Style="display: inline;" />--%>
                                                                        <asp:Button ID="btnTransferCheckedDeposits" runat="server" Text="Transfer" OnClick="btnTransferCheckedDeposits_OnClick"
                                                                            Style="display: inline;" />
                                                                    </div>
                                                                    <div style="float: right; text-align: right; width: 100px; background-color: #F3F3F5;
                                                                        color: #0083CE; font-size: 15px; font-weight: bold; padding: 5px;">
                                                                        <b>
                                                                            <asp:Label ID="lblTotalDepositToProcess" runat="server"></asp:Label></b>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3" style="padding: 0px;">
                                                                    <hr />
                                                                </td>
                                                            </tr>
                                                            <tr style="background-color: #DCDDDF;">
                                                                <td align="center" colspan="3" style="padding: 0px; font-size: 15px; border: 1px solid #ccccce !important;">
                                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                        <td width="50%" align="right">
                                                                            Net Balance:&nbsp;&nbsp;&nbsp; <b>
                                                                                <asp:Label ID="lblAmountRefundOrPayment" runat="server"></asp:Label>
                                                                            </b>&nbsp;(<asp:Label ID="lblCreditOrDebitFinal" runat="server"></asp:Label>)&nbsp;<span
                                                                                style="font-size: 20px;">|</span>
                                                                        </td>
                                                                        <td width="50%">
                                                                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                                <tr>
                                                                                    <td align="left">
                                                                                        <asp:Button ID="btnRefundAmount" Visible="false" runat="server" OnClick="btnRefundAmount_OnClick"
                                                                                            Text="Refund" Style="display: inline;" />
                                                                                        <asp:Button ID="btnTakePayment" runat="server" OnClick="btnTakePayment_OnClick" Text="Receipt"
                                                                                            Style="display: inline;" Visible="false" />
                                                                                    </td>
                                                                                    <td align="right">
                                                                                        Refunded Amouunt:
                                                                                        <asp:Literal ID="ltrRefundedAmount" runat="server" Text="0.00"></asp:Literal>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr id="trPayment" runat="server" visible="false">
                                                                <td colspan="3">
                                                                    <table width="65%">
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                <b>Receipt</b>
                                                                                <hr />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="150px">
                                                                                <b>Amount</b>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtPaymentAmount" runat="server" SkinID="nowidth" Width="150px"
                                                                                    MaxLength="9"></asp:TextBox>
                                                                                <ajx:FilteredTextBoxExtender ID="ftePaymentAmount" runat="server" TargetControlID="txtPaymentAmount"
                                                                                    FilterMode="ValidChars" ValidChars=".0123456789">
                                                                                </ajx:FilteredTextBoxExtender>
                                                                                <span>
                                                                                    <asp:RequiredFieldValidator ID="rfvPaymentAmount" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                                        runat="server" ValidationGroup="RequireForPayment" ControlToValidate="txtPaymentAmount"
                                                                                        Display="Dynamic">
                                                                                    </asp:RequiredFieldValidator>
                                                                                </span>
                                                                                <asp:RegularExpressionValidator ID="regPaymentAmount" SetFocusOnError="True" runat="server"
                                                                                    ValidationGroup="RequireForPayment" ControlToValidate="txtPaymentAmount" ValidationExpression="^\d{0,18}(\.\d{0,2})?$"
                                                                                    Display="Dynamic" ForeColor="Red" ErrorMessage="Two digit allowd after decimal point."></asp:RegularExpressionValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <b>Mode of Payment</b>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlModeOfPayment" runat="server" SkinID="nowidth" Width="150px"
                                                                                    OnSelectedIndexChanged="ddlModeOfPayment_OnSelectedIndexChanged" AutoPostBack="true">
                                                                                </asp:DropDownList>
                                                                                <span>
                                                                                    <asp:RequiredFieldValidator ID="rfvModeOfPayment" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                                        SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                                        ValidationGroup="RequireForPayment" ControlToValidate="ddlModeOfPayment" Display="Dynamic">
                                                                                    </asp:RequiredFieldValidator>
                                                                                </span>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trLedgerAccount" runat="server" visible="false">
                                                                            <td>
                                                                                Ledger
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlLedgerAccount" SkinID="nowidth" Width="150px" runat="server">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trChequeDD1" runat="server" visible="false">
                                                                            <td>
                                                                                Bank Name
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtBankName" SkinID="nowidth" Width="150px" runat="server"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trChequeDD2" runat="server" visible="false">
                                                                            <td>
                                                                                Cheque/DD No.
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtChequeDDNo" SkinID="nowidth" Width="150px" runat="server"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trCreditCard1" runat="server" visible="false">
                                                                            <td>
                                                                                Card Type
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlCreditCardType" SkinID="nowidth" Width="150px" runat="server">
                                                                                </asp:DropDownList>
                                                                                <span>
                                                                                    <asp:RequiredFieldValidator ID="rfvCreditCardType" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                                        SetFocusOnError="true" CssClass="input-notification error png_bg" Enabled="false"
                                                                                        runat="server" ValidationGroup="RequireForPayment" ControlToValidate="ddlCreditCardType"
                                                                                        Display="Dynamic">
                                                                                    </asp:RequiredFieldValidator>
                                                                                </span>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trCreditCard2" runat="server" visible="false">
                                                                            <td>
                                                                                Name on Card
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtNameOnCard" SkinID="nowidth" Width="150px" runat="server"></asp:TextBox>
                                                                                <span>
                                                                                    <asp:RequiredFieldValidator ID="rfvNameOnCreditCard" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                                        Enabled="false" runat="server" ValidationGroup="RequireForPayment" ControlToValidate="txtNameOnCard"
                                                                                        Display="Dynamic">
                                                                                    </asp:RequiredFieldValidator>
                                                                                </span>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trCreditCard3" runat="server" visible="false">
                                                                            <td>
                                                                                Card Number
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtCardNumber" runat="server" SkinID="nowidth" Width="150px" MaxLength="16"></asp:TextBox>
                                                                                <span>
                                                                                    <asp:RequiredFieldValidator ID="rfvCreditCardNumber" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                                        Enabled="false" runat="server" ValidationGroup="RequireForPayment" ControlToValidate="txtCardNumber"
                                                                                        Display="Dynamic">
                                                                                    </asp:RequiredFieldValidator>
                                                                                </span>
                                                                                <ajx:FilteredTextBoxExtender ID="fteCreditCardNumber" runat="server" TargetControlID="txtCardNumber"
                                                                                    FilterMode="ValidChars" ValidChars="0123456789">
                                                                                </ajx:FilteredTextBoxExtender>
                                                                                <asp:RegularExpressionValidator ID="regCreditCardNumber" runat="server" ControlToValidate="txtCardNumber"
                                                                                    ErrorMessage="Card No. must be 16 digits." Display="Dynamic" ValidationGroup="RequireForPayment"
                                                                                    ForeColor="Red" ValidationExpression="^[0-9]{16}"></asp:RegularExpressionValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trCVVNo" runat="server" visible="false">
                                                                            <td>
                                                                                CVV No.
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtCVVNo" runat="server" SkinID="nowidth" Width="150px" MaxLength="4"></asp:TextBox>
                                                                                <span>
                                                                                    <asp:RequiredFieldValidator ID="rfvCVVNumber" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                                        Enabled="false" runat="server" ValidationGroup="RequireForPayment" ControlToValidate="txtCVVNo"
                                                                                        Display="Dynamic">
                                                                                    </asp:RequiredFieldValidator>
                                                                                </span>
                                                                                <ajx:FilteredTextBoxExtender ID="fteCVVNo" runat="server" TargetControlID="txtCVVNo"
                                                                                    FilterMode="ValidChars" ValidChars="0123456789">
                                                                                </ajx:FilteredTextBoxExtender>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trCreditCard4" runat="server" visible="false">
                                                                            <td>
                                                                                Expiration Date
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlCardExpirationMonth" runat="server" SkinID="nowidth" Width="100px">
                                                                                    <asp:ListItem Text="-SELECT-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                                                    <asp:ListItem Text="January" Value="1"></asp:ListItem>
                                                                                    <asp:ListItem Text="February" Value="2"></asp:ListItem>
                                                                                    <asp:ListItem Text="March" Value="3"></asp:ListItem>
                                                                                    <asp:ListItem Text="April" Value="4"></asp:ListItem>
                                                                                    <asp:ListItem Text="May" Value="5"></asp:ListItem>
                                                                                    <asp:ListItem Text="June" Value="6"></asp:ListItem>
                                                                                    <asp:ListItem Text="July" Value="7"></asp:ListItem>
                                                                                    <asp:ListItem Text="August" Value="8"></asp:ListItem>
                                                                                    <asp:ListItem Text="September" Value="9"></asp:ListItem>
                                                                                    <asp:ListItem Text="October" Value="10"></asp:ListItem>
                                                                                    <asp:ListItem Text="November" Value="11"></asp:ListItem>
                                                                                    <asp:ListItem Text="December" Value="12"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                <span>
                                                                                    <asp:RequiredFieldValidator ID="rfvCardExpirationMonth" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                                        SetFocusOnError="true" CssClass="input-notification error png_bg" Enabled="false"
                                                                                        runat="server" ValidationGroup="RequireForPayment" ControlToValidate="ddlCardExpirationMonth"
                                                                                        Display="Static">
                                                                                    </asp:RequiredFieldValidator>
                                                                                </span>
                                                                                <asp:DropDownList ID="ddlCardExpirationYear" runat="server" SkinID="nowidth" Width="90px">
                                                                                </asp:DropDownList>
                                                                                <span>
                                                                                    <asp:RequiredFieldValidator ID="rfvCardExpirationYear" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                                        SetFocusOnError="true" CssClass="input-notification error png_bg" Enabled="false"
                                                                                        runat="server" ValidationGroup="RequireForPayment" ControlToValidate="ddlCardExpirationYear"
                                                                                        Display="Dynamic">
                                                                                    </asp:RequiredFieldValidator>
                                                                                </span>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td style="padding-top: 15px;">
                                                                                <asp:Button ID="btnSavePayment" runat="server" Text="Save" Style="display: inline;"
                                                                                    ValidationGroup="RequireForPayment" OnClick="btnSavePayment_OnClick" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr id="trRefund" runat="server" visible="false">
                                                                <td colspan="3">
                                                                    <table width="65%">
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                <b>Refund</b>
                                                                                <hr />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="100px">
                                                                                <b>Amount</b>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtAmountToRefund" runat="server" SkinID="nowidth" Enabled="false"
                                                                                    Width="100px"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <b>Mode of Refund</b>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlRefundPaymentMOP" runat="server" SkinID="nowidth" Width="150px"
                                                                                    OnSelectedIndexChanged="ddlRefundPaymentMOP_OnSelectedIndexChanged" AutoPostBack="true">
                                                                                </asp:DropDownList>
                                                                                <span>
                                                                                    <asp:RequiredFieldValidator ID="rfvRefundAmountMOP" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                                        SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                                        ValidationGroup="RequireForRefundAmount" ControlToValidate="ddlRefundPaymentMOP"
                                                                                        Display="Dynamic">
                                                                                    </asp:RequiredFieldValidator>
                                                                                </span>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trRefundPaymentLedger" runat="server" visible="false">
                                                                            <td>
                                                                                <b>Ledger</b>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlRefundPaymentLedger" SkinID="nowidth" Width="150px" runat="server">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trRefundPaymentBankName" runat="server" visible="false">
                                                                            <td>
                                                                                <b>Bank Name</b>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtRefundPaymentBankName" SkinID="nowidth" Width="150px" runat="server"></asp:TextBox>
                                                                                <span>
                                                                                    <asp:RequiredFieldValidator ID="rfvRefundPaymentBankName" Enabled="false" SetFocusOnError="true"
                                                                                        CssClass="input-notification error png_bg" runat="server" ValidationGroup="RequireForRefundAmount"
                                                                                        ControlToValidate="txtRefundPaymentBankName" Display="Dynamic">
                                                                                    </asp:RequiredFieldValidator>
                                                                                </span>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trRefundPaymentChequeDDNo" runat="server" visible="false">
                                                                            <td>
                                                                                <b>Cheque No.</b>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtRefundPaymentChequeDDNo" SkinID="nowidth" Width="150px" runat="server"></asp:TextBox>
                                                                                <span>
                                                                                    <asp:RequiredFieldValidator ID="rfvRefundPaymentChequeDDNo" Enabled="false" SetFocusOnError="true"
                                                                                        CssClass="input-notification error png_bg" runat="server" ValidationGroup="RequireForRefundAmount"
                                                                                        ControlToValidate="txtRefundPaymentChequeDDNo" Display="Dynamic">
                                                                                    </asp:RequiredFieldValidator>
                                                                                </span>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Button ID="btnProceedRefund" runat="server" Text="Proceed Refund" OnClick="btnProceedRefund_OnClick"
                                                                                    Style="display: inline;" ValidationGroup="RequireForRefundAmount" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr id="trCheckoutVoucher" runat="server" visible="false">
                                                                <td colspan="3" align="center">
                                                                    <asp:Button ID="btnCheckOutComplete" runat="server" Text="Check Out Completed" Visible="false"
                                                                        OnClick="btnCheckOutComplete_OnClick" Style="display: inline;" />
                                                                    <asp:RadioButton ID="rdoDetail" runat="server" Text="Detail Report" AutoPostBack="true"
                                                                        GroupName="Collection" OnCheckedChanged="rdoDetail_CheckedChanged" Visible="false" />
                                                                    <asp:RadioButton ID="rdoSummary" runat="server" Text="Summary Report" GroupName="Collection"
                                                                        AutoPostBack="true" OnCheckedChanged="rdoDetail_CheckedChanged" Visible="false" />
                                                                    <asp:Button ID="btnPrintBill" runat="server" Visible="false" Text="Print Bill" OnClick="btnPrintBill_OnClick"
                                                                        Style="display: inline;" />
                                                                </td>
                                                            </tr>
                                                            <tr id="trCompBillPrint" runat="server" visible="false">
                                                                <td colspan="3" align="center">
                                                                    <asp:Button ID="btnCmpBillPrint" runat="server" Text="Print Company Invoice" Visible="false"
                                                                        Style="display: inline;" OnClick="btnCmpBillPrint_Click" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>
                                            <div style="padding-top: 10px; text-align: center;">
                                                <asp:Button ID="btnBack" runat="server" Text="Back" Visible="false" Style="display: inline;"
                                                    OnClientClick="return fnGetTabIndex('BACK');" />
                                                <asp:Button ID="btnCheckOutBack" runat="server" Text="Back to List" OnClick="btnCheckOutBack_OnClick"
                                                    Style="display: inline;" />
                                                <asp:Button ID="btnNext" runat="server" Text="Next" Visible="false" Style="display: inline;"
                                                    OnClientClick="return fnGetTabIndex('NEXT');" />
                                            </div>
                                        </div>
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
                <ajx:ModalPopupExtender ID="mpePrintReceipt" runat="server" TargetControlID="hdnPrintReceipt"
                    PopupControlID="pnlPrintReceipt" BehaviorID="mpePrintReceipt" CancelControlID="iBtnClosePaymentReceipt"
                    BackgroundCssClass="mod_background">
                </ajx:ModalPopupExtender>
                <asp:HiddenField ID="hdnPrintReceipt" runat="server" />
                <asp:Panel ID="pnlPrintReceipt" runat="server" Width="400px">
                    <div class="box_col1">
                        <div class="box_head">
                            <div style="display: inline;">
                                <span>
                                    <asp:Literal ID="Literal20" runat="server" Text="Payment Receipt"></asp:Literal></span></div>
                            <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                                <asp:ImageButton ID="iBtnClosePaymentReceipt" runat="server" ImageUrl="~/images/closepopup.png"
                                    Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;" />
                            </div>
                        </div>
                        <div class="clear">
                        </div>
                        <div class="box_form">
                            <table width="100%">
                                <tr>
                                    <td align="left">
                                        <ucCtrlPaymentReceipt:PaymentReceipt ID="ucPaymentReceipt" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:Button ID="btnPaymentPrintReceipt" runat="server" Text="Print" OnClientClick="return fnopenPrintWindow();" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                </asp:Panel>
                <%--<ajx:ModalPopupExtender ID="mpeMOPforRefundDeposit" runat="server" TargetControlID="hdnMOPforRefundDeposit"
                    PopupControlID="pnlMOPforRefundDeposit" BackgroundCssClass="mod_background" CancelControlID="btnCancelRefundDeposit">
                </ajx:ModalPopupExtender>
                <asp:HiddenField ID="hdnMOPforRefundDeposit" runat="server" />
                <asp:Panel ID="pnlMOPforRefundDeposit" runat="server" Width="400px" Style="display: none;">
                    <div class="box_col1">
                        <div class="box_head">
                            <span>
                                <asp:Literal ID="Literal7" runat="server" Text="Mode Of Refund"></asp:Literal></span></div>
                        <div class="clear">
                        </div>
                        <div class="box_form">
                            <table cellpadding="2" cellspacing="2" width="100%">
                                <tr>
                                    <td width="120px">
                                        <b>Mode of Refund</b>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlRefundDepositMOP" runat="server" SkinID="nowidth" Width="150px"
                                            OnSelectedIndexChanged="ddlRefundDepositMOP_OnSelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>
                                        <span>
                                            <asp:RequiredFieldValidator ID="rfvRefundDepositMOP" InitialValue="00000000-0000-0000-0000-000000000000"
                                                SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                ValidationGroup="RequireForRefundDeposit" ControlToValidate="ddlRefundDepositMOP"
                                                Display="Static">
                                            </asp:RequiredFieldValidator>
                                        </span>
                                    </td>
                                </tr>
                                <tr id="trRefundDepoistLedgerAccount" runat="server" visible="false">
                                    <td>
                                        <b>Ledger</b>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlRefundDepositLedgerAcct" SkinID="nowidth" Width="150px"
                                            runat="server">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr id="trRefundDepositBankName" runat="server" visible="false">
                                    <td>
                                        <b>Bank Name</b>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRefundDepositBankName" SkinID="nowidth" Width="150px" runat="server"></asp:TextBox>
                                        <span>
                                            <asp:RequiredFieldValidator ID="rfvRefundDepositBankName" Enabled="false" SetFocusOnError="true"
                                                CssClass="input-notification error png_bg" runat="server" ValidationGroup="RequireForRefundDeposit"
                                                ControlToValidate="txtRefundDepositBankName" Display="Static">
                                            </asp:RequiredFieldValidator>
                                        </span>
                                    </td>
                                </tr>
                                <tr id="trRefundDepositChequeDDNo" runat="server" visible="false">
                                    <td>
                                        <b>Cheque No.</b>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRefundDepositChequeDDno" SkinID="nowidth" Width="150px" runat="server"></asp:TextBox>
                                        <span>
                                            <asp:RequiredFieldValidator ID="rfvRefundDepositChequeDDno" Enabled="false" SetFocusOnError="true"
                                                CssClass="input-notification error png_bg" runat="server" ValidationGroup="RequireForRefundDeposit"
                                                ControlToValidate="txtRefundDepositChequeDDno" Display="Static">
                                            </asp:RequiredFieldValidator>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:Button ID="btnOKRefundDepositMOP" OnClick="btnOKRefundDepositMOP_OnClick" runat="server"
                                            Text="OK" Style="display: inline;" ValidationGroup="RequireForRefundDeposit" />
                                        <asp:Button ID="btnCancelRefundDeposit" runat="server" Text="Cancel" Style="display: inline;" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                </asp:Panel>--%>
            </asp:View>
        </asp:MultiView>
        <asp:HiddenField ID="hfPopupCustomeMessage" runat="server" />
        <ajx:ModalPopupExtender ID="mpeCustomePopup" runat="server" TargetControlID="hfPopupCustomeMessage"
            PopupControlID="pnlCustomeMessage" BackgroundCssClass="mod_background" CancelControlID="btnOKCustomeMsgPopup"
            DropShadow="true" BehaviorID="mpeCustomePopup">
        </ajx:ModalPopupExtender>
        <asp:Panel ID="pnlCustomeMessage" runat="server" Width="350px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="litHeaderCustomePopupMessage" runat="server" Text="Message"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td align="center" style="padding-bottom: 15px; color: Red;">
                                <asp:Literal ID="litCustomePopupMsg" runat="server" Text="Please select atleast one Transaction"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnOKCustomeMsgPopup" runat="server" Text="OK" Style="display: inline;
                                    padding-right: 10px;" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpePreference" runat="server" TargetControlID="hdnPreference"
            PopupControlID="pnlPreference" BackgroundCssClass="mod_background" CancelControlID="btnPreferenceCancel">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnPreference" runat="server" />
        <asp:Panel ID="pnlPreference" runat="server" Width="600px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="litHdrPreference" runat="server" Text="Preference"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td class="isrequire">
                                <asp:Literal ID="litPreference" runat="server" Text="Preference"></asp:Literal>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlPreference" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvPreference" InitialValue="00000000-0000-0000-0000-000000000000"
                                    SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                    ValidationGroup="IsRequirePreference" ControlToValidate="ddlPreference" Display="Dynamic">
                                </asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="litPreferenceDetails" runat="server" Text="Details"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPreferenceDetails" runat="server" Style="width: 450px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="vertical-align: top;">
                                <asp:Literal ID="litPreferenceDescription" runat="server" Text="Description"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPreferenceDescription" runat="server" Style="width: 450px" TextMode="MultiLine"
                                    Rows="4"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Button ID="btnPreferenceSave" OnClick="btnPreferenceSave_OnClick" runat="server"
                                    Text="Save" Style="display: inline;" ValidationGroup="IsRequirePreference" />
                                <asp:Button ID="btnPreferenceCancel" runat="server" Text="Cancel" Style="display: inline;" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpeManagementNote" runat="server" TargetControlID="hdnManagementNote"
            PopupControlID="pnlManagementNote" BackgroundCssClass="mod_background" CancelControlID="btnManagementNoteCancel">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnManagementNote" runat="server" />
        <asp:Panel ID="pnlManagementNote" runat="server" Width="600px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="litHdrManagementNote" runat="server" Text="Management Note"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td class="isrequire" style="vertical-align: top; width: 60px;">
                                <asp:Literal ID="litManagementNote" runat="server" Text="Note"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtManagementNote" runat="server" Style="width: 450px" TextMode="MultiLine"
                                    Rows="5"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvManagementNote" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                    runat="server" ValidationGroup="IsRequireManagementNote" ControlToValidate="txtManagementNote"
                                    Display="Dynamic">
                                </asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Button ID="btnManagementNoteSave" OnClick="btnManagementNoteSave_OnClick" runat="server"
                                    Text="Save" Style="display: inline;" ValidationGroup="IsRequireManagementNote" />
                                <asp:Button ID="btnManagementNoteCancel" runat="server" Text="Cancel" Style="display: inline;" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpeFeedBackAndComplain" runat="server" TargetControlID="hdnFeedBackAndComplain"
            PopupControlID="pnlFeedBackAndComplain" BackgroundCssClass="mod_background" CancelControlID="btnCancelFeedBackAndComplain">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnFeedBackAndComplain" runat="server" />
        <asp:Panel ID="pnlFeedBackAndComplain" runat="server" Width="600px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="litHdrFeedBackAndComplain" runat="server" Text=""></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td>
                                <asp:Literal ID="litCategory" runat="server" Text="Category"></asp:Literal>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rbtCategoryList" runat="server" Enabled="false" RepeatColumns="2"
                                    RepeatDirection="Horizontal">
                                    <asp:ListItem Text="Feedback" Value="Feedback"></asp:ListItem>
                                    <asp:ListItem Text="Complaint" Value="Complaint"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire" style="width: 130px !important;">
                                <asp:Literal ID="litComplainBy" runat="server" Text="Complain By"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtComplainBy" runat="server"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rfvComplainBy" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                        runat="server" ValidationGroup="IsRequireFeedBackAndComplain" ControlToValidate="txtComplainBy"
                                        Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire" style="width: 130px !important;">
                                <asp:Literal ID="litDepartment" runat="server" Text="Department"></asp:Literal>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlDepartment" runat="server">
                                </asp:DropDownList>
                                <span>
                                    <asp:RequiredFieldValidator ID="rvfDepartment" InitialValue="00000000-0000-0000-0000-000000000000"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                        ValidationGroup="IsRequireFeedBackAndComplain" ControlToValidate="ddlDepartment"
                                        Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire" style="width: 130px !important;">
                                <asp:Literal ID="litNatureOfComplaint" runat="server" Text="Nature Of Complaint"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtNatureOfComplaint" runat="server"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rvfNatureOfComplaint" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                        runat="server" ValidationGroup="IsRequireFeedBackAndComplain" ControlToValidate="txtNatureOfComplaint"
                                        Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="litDescription" runat="server" Text="Description"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDescription" runat="server" Rows="5" Style="width: 375px;" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="btnSaveFeedBackAndComplain" OnClick="btnSaveFeedBackAndComplain_OnClick"
                                    runat="server" Text="Save" Style="display: inline;" ValidationGroup="IsRequireFeedBackAndComplain" />
                                <asp:Button ID="btnCancelFeedBackAndComplain" runat="server" Text="Cancel" Style="display: inline;" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <%--<ajx:ModalPopupExtender ID="mpeRecovery" runat="server" TargetControlID="hdnRecovery"
            PopupControlID="pnlRecovery" BackgroundCssClass="mod_background" CancelControlID="btnRecoveryCancel">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnRecovery" runat="server" />
        <asp:Panel ID="pnlRecovery" runat="server" Width="600px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="Literal1" runat="server" Text="Recovery"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td class="isrequire" style="width: 110px !important;">
                                <asp:Literal ID="litRecoveryType" runat="server" Text="Recovery Item"></asp:Literal>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlRecoveryType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlRecoveryType_SelectedIndexChanged">
                                    <asp:ListItem Selected="True" Value="00000000-0000-0000-0000-000000000000" Text="-Select-"></asp:ListItem>
                                    <asp:ListItem Value="Chair Broken" Text="Chair Broken"></asp:ListItem>
                                    <asp:ListItem Value="Window Broken" Text="Window Broken"></asp:ListItem>
                                    <asp:ListItem Value="Others" Text="Others"></asp:ListItem>
                                </asp:DropDownList>
                                <span>
                                    <asp:RequiredFieldValidator ID="rfvRecoveryType" InitialValue="00000000-0000-0000-0000-000000000000"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                        ValidationGroup="IsRequireRecovery" ControlToValidate="ddlRecoveryType" Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire" style="width: 110px !important;">
                                <asp:Literal ID="litRecoveryAmount" runat="server" Text="Amount"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtRecoveryAmount" runat="server" Enabled="false" Style="text-align: right;"></asp:TextBox>
                                <ajx:FilteredTextBoxExtender ID="ftRecoveryAmount" runat="server" TargetControlID="txtRecoveryAmount"
                                    FilterType="Custom, Numbers" ValidChars="." />
                                <span>
                                    <asp:RequiredFieldValidator ID="rfvRecoveryAmount" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                        runat="server" ValidationGroup="IsRequireRecovery" ControlToValidate="txtRecoveryAmount"
                                        Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                </span>
                            </td>
                        </tr>
                        <tr id="trDescription" runat="server" visible="false">
                            <td style="width: 110px !important; vertical-align: top;">
                                <asp:Literal ID="Literal4" runat="server" Text="Description"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtRecoveryDescription" runat="server" TextMode="MultiLine" Rows="2"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire" style="width: 110px !important;">
                                <asp:Literal ID="litRecoveryMode" runat="server" Text="Recovery Mode"></asp:Literal>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlRecoveryMode" runat="server">
                                    <asp:ListItem Selected="True" Value="00000000-0000-0000-0000-000000000000" Text="-Select-"></asp:ListItem>
                                    <asp:ListItem Value="Cashcard" Text="Cashcard"></asp:ListItem>
                                    <asp:ListItem Value="Folio Posting" Text="Folio Posting"></asp:ListItem>
                                </asp:DropDownList>
                                <span>
                                    <asp:RequiredFieldValidator ID="rfvRecoveryMode" InitialValue="00000000-0000-0000-0000-000000000000"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                        ValidationGroup="IsRequireRecovery" ControlToValidate="ddlRecoveryMode" Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="right">
                                <asp:Button ID="btnSave" runat="server" Text="Save" Style="display: inline; padding-left: 5px;"
                                    ValidationGroup="IsRequireRecovery" />
                                <asp:Button ID="btnRecoveryCancel" runat="server" Text="Cancel" Style="display: inline;
                                    padding-left: 5px;" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>--%>
        <%--<asp:HiddenField ID="hdnCheckOutVoucher" runat="server" />
        <ajx:ModalPopupExtender ID="mpeCheckOutVoucher" runat="server" TargetControlID="hdnCheckOutVoucher"
            PopupControlID="pnlCheckOutVoucher" CancelControlID="ibtnCloseCheckOutVoucher"
            BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:Panel ID="pnlCheckOutVoucher" runat="server" Width="700px">
            <div class="box_col1">
                <div class="box_head">
                    <div style="display: inline;">
                        <span>
                            <asp:Literal ID="Literal2" runat="server" Text="Check Out Voucher"></asp:Literal></span></div>
                    <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                        <asp:ImageButton ID="ibtnCloseCheckOutVoucher" runat="server" ImageUrl="~/images/closepopup.png"
                            Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;" />
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <ucCheckOutVoucher:CheckOutVoucher ID="ucCheckOutVoucher" runat="server" />
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>--%>
        <ajx:ModalPopupExtender ID="mpeOpenCounter" runat="server" TargetControlID="hdnOpenCounter"
            PopupControlID="pnlOpenCounter" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnOpenCounter" runat="server" />
        <asp:Panel ID="pnlOpenCounter" runat="server" Width="400px">
            <div class="box_col1">
                <div class="box_head">
                    <div style="display: inline;">
                        <span>
                            <asp:Literal ID="Literal23" runat="server" Text="Counter"></asp:Literal></span></div>
                    <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                        <asp:ImageButton ID="iBtnCloseCounter" runat="server" ImageUrl="~/images/closepopup.png"
                            OnClick="iBtnCloseCounter_OnClick" Style="border: 0px; width: 16px; height: 16px;
                            margin: -4px 0 0 5px; vertical-align: middle;" />
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table width="100%">
                        <tr>
                            <td align="left">
                                <ucCtrlCommonCounterLogin:CommonCounterLogin ID="ucCommonCounterLogin" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnSaveCounterData" runat="server" Text="Log In" OnClick="btnSaveCounterData_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpeCounterErrorMessage" runat="server" TargetControlID="hfCounterMessage"
            PopupControlID="pnlCounterErrorMessage" BackgroundCssClass="mod_background" BehaviorID="mpeCounterErrorMessage">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hfCounterMessage" runat="server" />
        <asp:Panel ID="pnlCounterErrorMessage" runat="server" Style="display: none; min-height: 350px;
            min-width: 350px;">
            <div class="box_col1" style="height: 300px; width: 500px;">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="ltrHeaderCounterMsg" runat="server" Text="Message"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%" style="margin-top: 75px;">
                        <tr>
                            <td align="center" style="padding-bottom: 15px;">
                                <asp:Label ID="lblCounterErrorMessage" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnCounterErrorMessageOK" Text="OK" runat="server" OnClick="btnCounterErrorMessageOK_OnClick"
                                    Style="display: inline; padding-right: 10px;" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpePrintInvoice" runat="server" TargetControlID="hdnPrintInvoice"
            CancelControlID="btnCancelPrintInvoice" PopupControlID="pnlPrintInvoice" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnPrintInvoice" runat="server" />
        <asp:Panel ID="pnlPrintInvoice" runat="server">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="ltrHeaderPrintInvoice" runat="server" Text="Company Invoice"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%" border="0">
                        <tr>
                            <td colspan="6" align="center">
                                <img src="<%=Page.ResolveUrl("~/images/Logo.jpg") %>" border="0" alt="" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" align="center" style="padding-bottom: 10px;">
                                <asp:Literal ID="ltrUniworldAddress" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Bill No.
                            </td>
                            <td>
                                <asp:Literal ID="ltrBillNo" runat="server"></asp:Literal>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                Date
                            </td>
                            <td>
                                <asp:Literal ID="ltrTopRightDate" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td width="80px">
                                Res. #
                            </td>
                            <td width="200px">
                                <asp:Literal ID="ltrReservationNo" runat="server"></asp:Literal>
                            </td>
                            <td width="80px">
                                Guest Name
                            </td>
                            <td width="200px">
                                <asp:Literal ID="ltrGuestName" runat="server"></asp:Literal>
                            </td>
                            <td width="100px">
                                Company Name
                            </td>
                            <td width="200px">
                                <asp:Literal ID="ltrCompanyName" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Room No.
                            </td>
                            <td>
                                <asp:Literal ID="ltrRoomNo" runat="server"></asp:Literal>
                            </td>
                            <td>
                                Check In
                            </td>
                            <td>
                                <asp:Literal ID="ltrCheckInDate" runat="server"></asp:Literal>
                            </td>
                            <td>
                                Address
                            </td>
                            <td rowspan="3" style="vertical-align: top;">
                                <asp:Label ID="ltrCompanyAddressL" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Room Type
                            </td>
                            <td>
                                <asp:Literal ID="ltrRoomType" runat="server"></asp:Literal>
                            </td>
                            <td>
                                Check Out
                            </td>
                            <td>
                                <asp:Literal ID="ltrCheckOutDate" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Rate Card
                            </td>
                            <td>
                                <asp:Literal ID="ltrRateCard" runat="server"></asp:Literal>
                            </td>
                            <td>
                                Billing Instr.
                            </td>
                            <td>
                                <asp:Literal ID="ltrBillingInstruction" runat="server" Text="Part bill to Company"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                Billing Period
                            </td>
                            <td>
                                <asp:Literal ID="ltrBillingPeriod" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td style="padding-top: 25px; border-bottom: 1px solid Gray;">
                                Particulars
                            </td>
                            <td align="right" style="padding-top: 25px; border-bottom: 1px solid Gray;">
                                Amount
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                Room Rent
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrRoomRent" runat="server"></asp:Literal>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center" style="padding-top: 50px;">
                                _______________
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td align="right">
                                &nbsp;
                            </td>
                            <td colspan="2" align="center" style="padding-top: 50px;">
                                _______________
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                Authorized Person
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td align="right">
                                &nbsp;
                            </td>
                            <td colspan="2" align="center">
                                Guest
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" align="center">
                                <asp:Button ID="btnPrintInvoice" runat="server" Style="display: inline; padding-right: 10px;"
                                    Text="Print" OnClick="btnPrintInvoice_OnClick" />
                                <asp:Button ID="btnCancelPrintInvoice" runat="server" Style="display: inline;" Text="Cancel" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnPrintBill" />
        <asp:PostBackTrigger ControlID="btnPrintInvoice" />
        <asp:PostBackTrigger ControlID="btnCmpBillPrint" />
        <%--<asp:PostBackTrigger ControlID="btnEMail" />--%>
    </Triggers>
</asp:UpdatePanel>
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updCheckOut" ID="UpdateProgressCheckOut"
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
