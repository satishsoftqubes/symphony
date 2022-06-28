<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCheckOutNew.ascx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Billing.CtrlCheckOutNew" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>

<%@ Register Src="~/UIControls/Billing/CtrlCheckOutVoucher.ascx" TagName="CheckOutVoucher"
    TagPrefix="ucCheckOutVoucher" %>

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
                                                    <div id="tabs-2">
                                                        <table width="100%" cellpadding="0" cellspacing="0">
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
                                                                        
                                                                        <div class="box_head">
                                                                            <span>
                                                                                <asp:Literal ID="litFolioDetails" runat="server" Text="Folio Details"></asp:Literal>
                                                                            </span>
                                                                        </div>
                                                                        <div class="clear">
                                                                        </div>
                                                                        <div class="box_content">
                                                                            Folio Detials                                                                            
                                                                        </div>
                                                                    </div>
                                                                    <div style="height: 10px;">
                                                                    </div>
                                                                    <div style="float: left;">
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
