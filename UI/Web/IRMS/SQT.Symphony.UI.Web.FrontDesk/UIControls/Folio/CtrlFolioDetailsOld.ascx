<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlFolioDetailsOld.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Folio.CtrlFolioDetailsOld" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonQuickPost.ascx" TagName="QuickPost"
    TagPrefix="ucCtrlQuickPost" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonFolioTransactionDetails.ascx"
    TagName="FolioTransactionDetails" TagPrefix="ucCtrlFolioTransactionDetails" %>
<%@ Register Src="~/UIControls/Folio/CtrlDiscountOnTransaction.ascx" TagName="TransactionDiscount"
    TagPrefix="ucCtrlTransactionDiscount" %>
<%@ Register Src="~/UIControls/Folio/CtrlRefundDeposit.ascx" TagName="RefundDeposit"
    TagPrefix="ucCtrlRefundDeposit" %>
<%@ Register Src="~/UIControls/Folio/CtrlTransferDeposit.ascx" TagName="TransferDeposit"
    TagPrefix="ucCtrlTransferDeposit" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonAddServices.ascx" TagName="AddServices"
    TagPrefix="ucCtrlAddServices" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonCardInfo.ascx" TagName="CommonCardInfo"
    TagPrefix="ucCtrlCommonCardInfo" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonMoveUnitSetup.ascx" TagName="MoveUnitSetup"
    TagPrefix="ucCtrlMoveUnitSetup" %>
<%@ Register Src="~/UIControls/Folio/CtrlCommonSubFolioConfiguration.ascx" TagName="SubFolioConfiguration"
    TagPrefix="ucCtrlSubFolioConfiguration" %>
<%@ Register Src="~/UIControls/Folio/CtrlCommonFolioOverrideTransaction.ascx" TagName="FolioOverrideTransaction"
    TagPrefix="ucCtrlFolioOverrideTransaction" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonHouseKeeping.ascx" TagName="HouseKeeping"
    TagPrefix="ucCtrlHouseKeeping" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonGuestHistory.ascx" TagName="GuestHistory"
    TagPrefix="ucCtrlGuestHistory" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonInvoiceBillingName.ascx"
    TagName="InvoiceBillingName" TagPrefix="ucCtrlInvoiceBillingName" %>
<%@ Register Src="~/UIControls/Folio/CtrlFolioAssignPackage.ascx" TagName="FolioAssingPackage"
    TagPrefix="ucCtrlFolioAssingPackage" %>
<%@ Register Src="~/UIControls/Folio/CtrlPostUnitCharges.ascx" TagName="PostUnitCharges"
    TagPrefix="ucCtrlPostUnitCharges" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonVoidTransaction.ascx" TagName="VoidTransaction"
    TagPrefix="ucCtrlVoidTransaction" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonPayment.ascx" TagName="SubFolioPayment"
    TagPrefix="ucCtrlSubFolioPayment" %>
<link type="text/css" href="../../Styles/jquery-ui-1.8.5.custom.css" rel="stylesheet" />
<script type="text/javascript" src="../../Scripts/jquery-1.4.2.min.js"></script>
<script type="text/javascript" src="../../Scripts/jquery-ui-1.8.5.custom.min.js"></script>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonCounterLogin.ascx" TagName="CommonCounterLogin"
    TagPrefix="ucCtrlCommonCounterLogin" %>
<%--<script src="../../Scripts/jquery-1.8.2.js"></script>
<script src="../../Scripts/jquery-ui.js"></script>
<script src="../../Scripts/Common.js" type="text/javascript"></script>--%>
<%--<script>
    function pageLoad(sender, args) {

        $(function () {
            var dateToday = new Date();

            $("#<%= txtPostChargeFrom.ClientID %>").datepicker({
                changeMonth: true,
                numberOfMonths: 1,
                minDate: dateToday,
                showOn: "button",
                dateFormat: "dd-mm-yy",
                buttonImage: "../../images/CalanderIcon.png",
                buttonImageOnly: true,
                onSelect: function (selectedDate) {
                    $("#<%= txtPostChargeTo.ClientID %>").datepicker("option", "minDate", selectedDate);
                }
            });
            $("#<%= txtPostChargeTo.ClientID %>").datepicker({
                changeMonth: true,
                numberOfMonths: 1,
                minDate: dateToday,
                dateFormat: "dd-mm-yy",
                showOn: "button",
                buttonImage: "../../images/CalanderIcon.png",
                buttonImageOnly: true,
                onSelect: function (selectedDate) {
                    $("#<%= txtPostChargeFrom.ClientID %>").datepicker("option", "maxDate", selectedDate);
                }
            });
        });
    }
</script>--%>
<script type="text/javascript">

    $(document).ready(function () {

        $("#tabs").tabs();


        $('#tabs').tabs({
            select: function (event, ui) {
                window.location.hash = ui.tab.hash;
            }
        });
    });

    function SelectTab() {
        alert('d');
        window.location.hash = 'tabs-1';
    }
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }

    function fnDisplayTabValue(text) {
        if (text == 'ALLCHARGES') {
            document.getElementById('<%= lblDisplayAmount.ClientID %>').innerHTML = document.getElementById('<%= hdnAllCharges.ClientID %>').value;
        }
        else if (text == 'RENTCHARGES') {
            document.getElementById('<%= lblDisplayAmount.ClientID %>').innerHTML = document.getElementById('<%= hdnRentCharges.ClientID %>').value;
        }
        else if (text == 'PAYEMNT') {
            document.getElementById('<%= lblDisplayAmount.ClientID %>').innerHTML = document.getElementById('<%= hdnPayment.ClientID %>').value;
        }
        else if (text == 'MISC') {
            document.getElementById('<%= lblDisplayAmount.ClientID %>').innerHTML = document.getElementById('<%= hdnMISC.ClientID %>').value;
        }
        else if (text == 'DEPOSIT') {
            document.getElementById('<%= lblDisplayAmount.ClientID %>').innerHTML = document.getElementById('<%= hdnDeposit.ClientID %>').value;
        }
    }

    function fnConfirmDelete(type) {
        document.getElementById('errormessage').style.display = "block";

        document.getElementById('<%= hdnConfirmDeleteFolioDetails.ClientID %>').value = type;

        if (type == 'REFUND') {
            document.getElementById('<%= lblConfirmDeleteMsg.ClientID %>').innerHTML = "Sure you want to Refund Balance?";
        }
        else {
            document.getElementById('<%= lblConfirmDeleteMsg.ClientID %>').innerHTML = "Sure you want to Transfer Balance?";
        }

        $find('mpeConfirmDelete').show();
        return false;
    }

</script>
<script language="javascript">

    function openViewer() {
        var Preview = '<%=IsPreview%>';
        window.open("../../ReportFiles/frmViewer.aspx?preview=" + Preview);
    }
</script>
<asp:UpdatePanel ID="updFolioDetails" runat="server">
    <ContentTemplate>
        <asp:HiddenField ID="hdnAllCharges" runat="server" />
        <asp:HiddenField ID="hdnRentCharges" runat="server" />
        <asp:HiddenField ID="hdnMISC" runat="server" />
        <asp:HiddenField ID="hdnPayment" runat="server" />
        <asp:HiddenField ID="hdnDeposit" runat="server" />
        <asp:HiddenField ID="hdn_MasterFolioID" runat="server" />
        <asp:MultiView ID="mvFolio" runat="server">
            <asp:View ID="vFolioDetails" runat="server">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="content">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="boxtopleft">
                                        &nbsp;
                                    </td>
                                    <td class="boxtopcenter">
                                        <asp:Literal ID="litMainHeader" runat="server" Text="Folio Details"></asp:Literal>
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
                                                <tr>
                                                    <td colspan="3">
                                                        <%if (IsMessageForSubFolioCheckOut)
                                                          { %>
                                                        <div class="message finalsuccess">
                                                            <p>
                                                                <strong>
                                                                    <asp:Literal ID="litSubFolioCheckOutMsg" runat="server"></asp:Literal></strong>
                                                            </p>
                                                        </div>
                                                        <%}%>
                                                    </td>
                                                </tr>
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
                                                                <th style="width: 75px;" align="left">
                                                                    <asp:Label ID="lblFolioDetailsMobileNo" runat="server" Text="Mobile No."></asp:Label>
                                                                </th>
                                                                <td>
                                                                    <asp:Label ID="lblFolioDetailsDisplayMobileNo" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th style="width: 75px;" align="left">
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
                                                                <th style="width: 75px;" align="left">
                                                                    <asp:Literal ID="litDepatureDate" runat="server" Text="Check Out"></asp:Literal>
                                                                </th>
                                                                <td>
                                                                    <asp:Literal ID="litDisplayDepatureDate" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th style="width: 75px;" align="left">
                                                                    <asp:Literal ID="litFolioNo" runat="server" Text="Folio No."></asp:Literal>
                                                                </th>
                                                                <td>
                                                                    <asp:Literal ID="litDisplayFolioNo" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr style="display: none;">
                                                                <th style="width: 75px;">
                                                                    <asp:Literal ID="litSubFolios" runat="server" Text="Sub Folios"></asp:Literal>
                                                                </th>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlDisplaySubFolios" runat="server" Style="width: 125px !important;"
                                                                        OnSelectedIndexChanged="ddlDisplaySubFolios_SelectedIndexChanged" AutoPostBack="true">
                                                                    </asp:DropDownList>
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
                                                                <th style="width: 75px;" align="left">
                                                                    <asp:Literal ID="litRoomType" runat="server" Text="Room Type"></asp:Literal>
                                                                </th>
                                                                <td>
                                                                    <asp:Literal ID="litDisplayRoomType" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th style="width: 85px;" align="left">
                                                                    <asp:Literal ID="litRateCard" runat="server" Text="Rate Card"></asp:Literal>
                                                                </th>
                                                                <td>
                                                                    <asp:Literal ID="litDisplayRateCard" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th style="width: 85px;" align="left">
                                                                    <asp:Literal ID="litCreditLimit" runat="server" Text="Folio Balance"></asp:Literal>
                                                                </th>
                                                                <td>
                                                                    <asp:Literal ID="litDisplayCreditLimit" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr id="trTax" runat="server" visible="false">
                                                                <th align="left">
                                                                    <asp:Literal ID="litTaxExempt" runat="server" Text="Tax Exempt"></asp:Literal>
                                                                </th>
                                                                <td>
                                                                    <asp:Literal ID="litDisplayTaxExempt" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3" align="right">
                                                        <asp:Button ID="btnRefreshFolio" runat="server" Text="Refresh Folio" OnClick="lnkRefreshFolio_Click" />
                                                    </td>
                                                </tr>
                                                <tr style="display: none;">
                                                    <td colspan="3" style="border: 1px solid #ccccce; padding: 10px 0 10px 0;">
                                                        <div style="float: left;">
                                                            <ul class="buttonnav">
                                                                <li>
                                                                    <%--<asp:LinkButton ID="lnkRefreshFolio" runat="server" Text="Refresh Folio" OnClick="lnkRefreshFolio_Click"></asp:LinkButton>--%>
                                                                </li>
                                                                <li>
                                                                    <asp:LinkButton ID="lnkFolioDetailsSubFolio" runat="server" Text="Sub Folio" OnClick="lnkFolioDetailsSubFolio_Click"
                                                                        Visible="false"></asp:LinkButton></li>
                                                                <li>
                                                                    <asp:LinkButton ID="lnkTransfer" runat="server" Text="Transfer" OnClick="lnkTransfer_Click"
                                                                        Visible="false"></asp:LinkButton>
                                                                </li>
                                                                <li>
                                                                    <asp:LinkButton ID="lnkInvoiceBillingName" runat="server" Text="Inv To" OnClick="lnkInvoiceBillingName_Click"
                                                                        Visible="false"></asp:LinkButton></li>
                                                                <li>
                                                                    <asp:LinkButton ID="lnkPostRoomCharge" runat="server" Text="Post Room Charge" Visible="false"
                                                                        OnClick="lnkPostRoomCharge_OnClick"></asp:LinkButton></li>
                                                                <li><a href="../../GUI/Billing/CheckOut.aspx?PostCharges=true" id="checkout" runat="server"
                                                                    visible="false">Check-Out</a></li>
                                                                <li>
                                                                    <asp:LinkButton ID="lnkQuickPost" runat="server" OnClick="lnkQuickPost_Click" Visible="false"
                                                                        Text="Quick Post"></asp:LinkButton>
                                                                </li>
                                                                <li>
                                                                    <asp:LinkButton ID="lnkSplitBilling" runat="server" Text="Split Billing" Visible="false"
                                                                        OnClick="lnkSplitBilling_Click"></asp:LinkButton>
                                                                </li>
                                                            </ul>
                                                        </div>
                                                        <div style="float: left; display: none;">
                                                            <img src="../../images/Print32x32.png" title="Print" />
                                                        </div>
                                                        <div style="float: left; padding-left: 100px;">
                                                            <asp:CheckBox ID="chkShowVoidTransaction" runat="server" Text="Show Void Transaction"
                                                                AutoPostBack="true" Visible="false" OnCheckedChanged="chkShowVoidTransaction_CheckedChanged" />
                                                        </div>
                                                        <div style="float: right;">
                                                            &nbsp;&nbsp;
                                                        </div>
                                                        <div style="float: right; background-color: #DCDDDF; color: #0083CE; font-size: 15px;
                                                            font-weight: bold; padding: 9px; width: 125px; text-align: right; display: none;">
                                                            <asp:Label ID="lblDisplayAmount" runat="server"></asp:Label>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <table cellpadding="2" cellspacing="2" width="100%">
                                                            <tr>
                                                                <td align="left" style="padding-top: 10px; background-color: #fff !important;">
                                                                    <div class="demo">
                                                                        <div id="tabs">
                                                                            <ul>
                                                                                <li><a href="#tabs-1">
                                                                                    <asp:Label ID="lbltabAllCharges" runat="server"></asp:Label>
                                                                                </a></li>
                                                                                <li><a href="#tabs-2">
                                                                                    <asp:Literal ID="littabRentCharge" runat="server"></asp:Literal></a></li>
                                                                                <li style="display: none;"><a href="#tabs-6">
                                                                                    <asp:Literal ID="littabMISC" runat="server"></asp:Literal></a></li>
                                                                                <li><a href="#tabs-7">
                                                                                    <asp:Literal ID="littabPayment" runat="server"></asp:Literal></a></li>
                                                                                <li><a href="#tabs-8">
                                                                                    <asp:Label ID="lblTabDeposit" runat="server"></asp:Label>
                                                                                </a></li>
                                                                            </ul>
                                                                            <div id="tabs-1">
                                                                                <table cellpadding="2" cellspacing="2" width="100%">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Literal ID="litStartDate" runat="server" Text="From"></asp:Literal>
                                                                                        </td>
                                                                                        <td style="width: 300px;">
                                                                                            <asp:CheckBox ID="chkStartDate" runat="server" AutoPostBack="true" Text="" OnCheckedChanged="chkStartDate_CheckedChanged" />
                                                                                            <asp:TextBox ID="txtStartDate" runat="server" onkeypress="return false;" SkinID="Search"></asp:TextBox>
                                                                                            <asp:Image ID="imgSColor" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                                                                Height="20px" Width="20px" />
                                                                                            <ajx:CalendarExtender ID="calStartDate" runat="server" TargetControlID="txtStartDate"
                                                                                                PopupButtonID="imgSColor">
                                                                                            </ajx:CalendarExtender>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Literal ID="litEndDate" runat="server" Text="To"></asp:Literal>
                                                                                        </td>
                                                                                        <td>
                                                                                            <div style="float: left;">
                                                                                                <asp:CheckBox ID="chkEndDate" runat="server" AutoPostBack="true" Text="" OnCheckedChanged="chkEndDate_CheckedChanged" />
                                                                                                <asp:TextBox ID="txtEndDate" runat="server" onkeypress="return false;" SkinID="Search"></asp:TextBox>
                                                                                                <asp:Image ID="imgEColor" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                                                                    Height="20px" Width="20px" />
                                                                                                <ajx:CalendarExtender ID="calEndDate" runat="server" TargetControlID="txtEndDate"
                                                                                                    PopupButtonID="imgEColor">
                                                                                                </ajx:CalendarExtender>
                                                                                                <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                                                                    ToolTip="Search" Style="border: 0px; margin: 0 0 0 5px; vertical-align: middle;"
                                                                                                    OnClick="btnSearch_Click" />
                                                                                                <span style="margin-left: auto; text-align: right;">
                                                                                                    <asp:RadioButton ID="rdoDetail" runat="server" Text="Detail" AutoPostBack="true"
                                                                                                        GroupName="ReportType" Style="margin: 0 0 0 50px;" OnCheckedChanged="rdoDetail_CheckedChanged" /></span>
                                                                                                <span style="margin-left: 10px; text-align: right;">
                                                                                                    <asp:RadioButton ID="rdoSummary" runat="server" Text="Summary" AutoPostBack="true"
                                                                                                        GroupName="ReportType" OnCheckedChanged="rdoDetail_CheckedChanged" />
                                                                                                </span>
                                                                                            </div>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="4">
                                                                                            <div class="box_head">
                                                                                                <span>
                                                                                                    <asp:Literal ID="litFolioDetails" runat="server" Text="Folio Details"></asp:Literal>
                                                                                                </span>
                                                                                            </div>
                                                                                            <div class="clear">
                                                                                            </div>
                                                                                            <div class="box_content">
                                                                                                <asp:GridView ID="gvFolioDetails" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                                                    Width="100%" OnRowCommand="gvFolioDetails_RowCommand" OnRowDataBound="gvFolioDetails_RowDataBound"
                                                                                                    OnPageIndexChanging="gvFolioDetails_PageIndexChanging" DataKeyNames="GuestName,ReservationNo,FolioNo,EntryDate,DisplayAmount,IsVoid,RoomNo,BookID"
                                                                                                    ShowFooter="true">
                                                                                                    <Columns>
                                                                                                        <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblGvHdrFolioDetailsDate" runat="server" Text="Date"></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="lblGvFolioDetailsDate" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "EntryDate")).ToString(clsSession.DateFormat)%>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblGvHdrFolioDetailsTransaction" runat="server" Text="Trans. #"></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="lblGvFolioDetailsBookNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "BookNo")%>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblGvHdrFolioDetailsAccount" runat="server" Text="Ledger Account"></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <%--<%#DataBinder.Eval(Container.DataItem, "Account")%>--%>
                                                                                                                <asp:Literal ID="ltrLedgerAccount" runat="server"></asp:Literal>
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
                                                                                                        <asp:TemplateField ItemStyle-Width="50px" Visible="true" HeaderStyle-HorizontalAlign="Left"
                                                                                                            ItemStyle-HorizontalAlign="Left">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblGvHdrFolioDetailsAction" runat="server" Text="Action"></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="lblFolioDetailsPopUp" runat="server" Text="Action"></asp:Label>
                                                                                                                <ajx:HoverMenuExtender ID="hmeFolioDetails" runat="server" TargetControlID="lblFolioDetailsPopUp"
                                                                                                                    PopupControlID="panFolioDetails" PopupPosition="Left">
                                                                                                                </ajx:HoverMenuExtender>
                                                                                                                <asp:Panel ID="panFolioDetails" runat="server" Style="visibility: hidden; opacity: 100%">
                                                                                                                    <div class="actionsbuttons_hovermenu">
                                                                                                                        <table border="0" cellpadding="0" cellspacing="0" class="actionsbuttons_hover_lettmenu_table">
                                                                                                                            <tr>
                                                                                                                                <td class="actionsbuttons_hover_lettmenu">
                                                                                                                                </td>
                                                                                                                                <td class="actionsbuttons_hover_centermenu">
                                                                                                                                    <ul>
                                                                                                                                        <li>
                                                                                                                                            <asp:LinkButton ID="lnkFolioDetailsChangeDescription" Visible="false" Style="background: none !important;
                                                                                                                                                border: none;" runat="server" ToolTip="Change Description" CommandName="CHANGEDESCRIPTION"
                                                                                                                                                CommandArgument='<%#DataBinder.Eval(Container.DataItem, "BookID")%>'><img src="../../images/file.png" /></asp:LinkButton>
                                                                                                                                        </li>
                                                                                                                                        <li>
                                                                                                                                            <asp:LinkButton ID="lnkFolioDetailsDiscount" Visible="false" Style="background: none !important;
                                                                                                                                                border: none;" runat="server" ToolTip="Discount" CommandName="DISCOUNT" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "BookID")%>'><img src="../../images/file.png" /></asp:LinkButton>
                                                                                                                                        </li>
                                                                                                                                        <li>
                                                                                                                                            <asp:LinkButton ID="lnkFolioDetailsOverride" Visible="false" Style="background: none !important;
                                                                                                                                                border: none;" runat="server" ToolTip="Override" CommandName="OVERRIDE" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "BookID")%>'><img src="../../images/file.png" /></asp:LinkButton>
                                                                                                                                        </li>
                                                                                                                                        <li>
                                                                                                                                            <asp:LinkButton ID="lnkFolioDetailsVoid" Visible="true" Style="background: none !important;
                                                                                                                                                border: none;" runat="server" ToolTip="Void" CommandName="VOID" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "BookID")%>'><img src="../../images/file.png" /></asp:LinkButton>
                                                                                                                                        </li>
                                                                                                                                    </ul>
                                                                                                                                </td>
                                                                                                                                <td class="actionsbuttons_hover_rightmenu">
                                                                                                                                </td>
                                                                                                                            </tr>
                                                                                                                        </table>
                                                                                                                    </div>
                                                                                                                </asp:Panel>
                                                                                                            </ItemTemplate>
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
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="4" align="center">
                                                                                            <asp:Button ID="btnPrintStatement" runat="server" Text="Print" OnClick="btnPrintStatement_Click"
                                                                                                Style="display: inline;" />
                                                                                            <asp:Button ID="btnSubFolioCheckOut" runat="server" Text="Check Out" OnClick="btnSubFolioCheckOut_Click"
                                                                                                Style="display: inline;" Visible="false" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </div>
                                                                            <div id="tabs-2">
                                                                                <table cellpadding="2" cellspacing="2" width="100%">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <div class="box_head">
                                                                                                <span>
                                                                                                    <asp:Literal ID="litAccomodationDetails" runat="server" Text="Room Rent"></asp:Literal>
                                                                                                </span>
                                                                                            </div>
                                                                                            <div class="clear">
                                                                                            </div>
                                                                                            <div class="box_content">
                                                                                                <asp:GridView ID="gvAccommodationList" runat="server" AutoGenerateColumns="false"
                                                                                                    ShowHeader="true" Width="100%" OnRowCommand="gvAccommodationList_RowCommand"
                                                                                                    OnRowDataBound="gvAccommodationList_RowDataBound" ShowFooter="true" OnPageIndexChanging="gvAccommodationList_PageIndexChanging"
                                                                                                    DataKeyNames="GuestName,ReservationNo,FolioNo,EntryDate,DisplayAmount,IsVoid,BookID,GeneralIDType_Term">
                                                                                                    <Columns>
                                                                                                        <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblGvHdrAccommodationDate" runat="server" Text="Date"></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="lblGvAccommodationDate" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "EntryDate")).ToString(clsSession.DateFormat)%>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblGvHdrAccommodationTransaction" runat="server" Text="Trans. #"></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="lblGvAccommodationBookNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "BookNo")%>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblGvHdrAccommodationAccount" runat="server" Text="Ledger Account"></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <%#DataBinder.Eval(Container.DataItem, "Account")%>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" Visible="false" ItemStyle-HorizontalAlign="Left">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblGvHdrAccommodationDescription" runat="server" Text="Description"></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="lblGvAccommodationDescription" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Narration")%>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                            <FooterTemplate>
                                                                                                                <b>Total</b>
                                                                                                            </FooterTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                                                                                            FooterStyle-HorizontalAlign="Right">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblGvHdrAccommodationCharges" runat="server" Text="Charge"></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="lblGvAccommodationCharges" runat="server"></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                            <FooterTemplate>
                                                                                                                <b>
                                                                                                                    <asp:Label ID="lblFtTotalAccommodationCharges" runat="server"></asp:Label>
                                                                                                                </b>
                                                                                                            </FooterTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField ItemStyle-Width="50px" Visible="false" HeaderStyle-HorizontalAlign="Left"
                                                                                                            ItemStyle-HorizontalAlign="Left">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblGvHdrAccommodationAction" runat="server" Text="Action"></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="lblAccommodationPopUp" runat="server" Text="Action"></asp:Label>
                                                                                                                <ajx:HoverMenuExtender ID="hmeAccommodation" runat="server" TargetControlID="lblAccommodationPopUp"
                                                                                                                    PopupControlID="panAccommodation" PopupPosition="Left">
                                                                                                                </ajx:HoverMenuExtender>
                                                                                                                <asp:Panel ID="panAccommodation" runat="server" Style="visibility: hidden; opacity: 100%">
                                                                                                                    <div class="actionsbuttons_hovermenu">
                                                                                                                        <table border="0" cellpadding="0" cellspacing="0" class="actionsbuttons_hover_lettmenu_table">
                                                                                                                            <tr>
                                                                                                                                <td class="actionsbuttons_hover_lettmenu">
                                                                                                                                </td>
                                                                                                                                <td class="actionsbuttons_hover_centermenu">
                                                                                                                                    <ul>
                                                                                                                                        <li>
                                                                                                                                            <asp:LinkButton ID="lnkAccommodationDescription" Style="background: none !important;
                                                                                                                                                border: none;" runat="server" ToolTip="Change Description" CommandName="CHANGEDESCRIPTION"
                                                                                                                                                CommandArgument='<%#DataBinder.Eval(Container.DataItem, "BookID")%>'><img src="../../images/file.png" /></asp:LinkButton>
                                                                                                                                        </li>
                                                                                                                                        <li>
                                                                                                                                            <asp:LinkButton ID="lnkAccommodationDiscount" Style="background: none !important;
                                                                                                                                                border: none;" runat="server" ToolTip="Discount" CommandName="DISCOUNT" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "BookID")%>'><img src="../../images/file.png" /></asp:LinkButton>
                                                                                                                                        </li>
                                                                                                                                        <li>
                                                                                                                                            <asp:LinkButton ID="lnkAccommodationOverride" Style="background: none !important;
                                                                                                                                                border: none;" runat="server" ToolTip="Override" CommandName="OVERRIDE" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "BookID")%>'><img src="../../images/file.png" /></asp:LinkButton>
                                                                                                                                        </li>
                                                                                                                                        <li>
                                                                                                                                            <asp:LinkButton ID="lnkAccommodationVoid" Style="background: none !important; border: none;"
                                                                                                                                                runat="server" ToolTip="Void" CommandName="VOID" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "BookID")%>'><img src="../../images/file.png" /></asp:LinkButton>
                                                                                                                                        </li>
                                                                                                                                    </ul>
                                                                                                                                </td>
                                                                                                                                <td class="actionsbuttons_hover_rightmenu">
                                                                                                                                </td>
                                                                                                                            </tr>
                                                                                                                        </table>
                                                                                                                    </div>
                                                                                                                </asp:Panel>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                    </Columns>
                                                                                                    <EmptyDataTemplate>
                                                                                                        <div style="padding: 10px;">
                                                                                                            <b>
                                                                                                                <asp:Label ID="lblNoRecordFoundForAccommodation" runat="server" Text="No Record Found."></asp:Label>
                                                                                                            </b>
                                                                                                        </div>
                                                                                                    </EmptyDataTemplate>
                                                                                                </asp:GridView>
                                                                                            </div>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </div>
                                                                            <div style="display: none;" id="tabs-6">
                                                                                <table cellpadding="2" cellspacing="2" width="100%">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <div class="box_head">
                                                                                                <span>
                                                                                                    <asp:Literal ID="litMISCDetails" runat="server" Text="Misc. Charges"></asp:Literal>
                                                                                                </span>
                                                                                            </div>
                                                                                            <div class="clear">
                                                                                            </div>
                                                                                            <div class="box_content">
                                                                                                <asp:GridView ID="gvMISCDetails" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                                                    Width="100%" OnRowCommand="gvMISCDetails_RowCommand" OnRowDataBound="gvMISCDetails_RowDataBound"
                                                                                                    OnPageIndexChanging="gvMISCDetails_PageIndexChanging" DataKeyNames="GuestName,ReservationNo,FolioNo,EntryDate,DisplayAmount,IsVoid,BookID,GeneralIDType_Term"
                                                                                                    ShowFooter="true">
                                                                                                    <Columns>
                                                                                                        <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblGvHdrMISCDate" runat="server" Text="Date"></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="lblGvMISCDate" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "EntryDate")).ToString(clsSession.DateFormat)%>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblGvHdrMISCTransaction" runat="server" Text="Trans. #"></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="lblGvMISCBookNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "BookNo")%>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblGvHdrMISCAccount" runat="server" Text="Ledger Account"></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="lblGvMISCAccount" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Account")%>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" Visible="false" ItemStyle-HorizontalAlign="Left">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblGvHdrMISCDescription" runat="server" Text="Description"></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="lblGvMISCDescription" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Narration")%>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                            <FooterTemplate>
                                                                                                                <b>Total</b>
                                                                                                            </FooterTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                                                                                            FooterStyle-HorizontalAlign="Right">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblGvHdrMISCCharges" runat="server" Text="Charge"></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="lblGvMISCCharges" runat="server"></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                            <FooterTemplate>
                                                                                                                <b>
                                                                                                                    <asp:Label ID="lblFtTotalMISCCharges" runat="server"></asp:Label>
                                                                                                                </b>
                                                                                                            </FooterTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField ItemStyle-Width="50px" Visible="false" HeaderStyle-HorizontalAlign="Left"
                                                                                                            ItemStyle-HorizontalAlign="Left">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblGvHdrMISCAction" runat="server" Text="Action"></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="lblMISCPopUp" runat="server" Text="Actions"></asp:Label>
                                                                                                                <ajx:HoverMenuExtender ID="hmeMISC" runat="server" TargetControlID="lblMISCPopUp"
                                                                                                                    PopupControlID="panMISC" PopupPosition="Left">
                                                                                                                </ajx:HoverMenuExtender>
                                                                                                                <asp:Panel ID="panMISC" runat="server" Style="visibility: hidden; opacity: 100%">
                                                                                                                    <div class="actionsbuttons_hovermenu">
                                                                                                                        <table border="0" cellpadding="0" cellspacing="0" class="actionsbuttons_hover_lettmenu_table">
                                                                                                                            <tr>
                                                                                                                                <td class="actionsbuttons_hover_lettmenu">
                                                                                                                                </td>
                                                                                                                                <td class="actionsbuttons_hover_centermenu">
                                                                                                                                    <ul>
                                                                                                                                        <li>
                                                                                                                                            <asp:LinkButton ID="lnkMISCDescription" Style="background: none !important; border: none;"
                                                                                                                                                runat="server" ToolTip="Change Description" CommandName="CHANGEDESCRIPTION" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "BookID")%>'><img src="../../images/file.png" /></asp:LinkButton>
                                                                                                                                        </li>
                                                                                                                                        <li>
                                                                                                                                            <asp:LinkButton ID="lnkMISCDiscount" Style="background: none !important; border: none;"
                                                                                                                                                runat="server" ToolTip="Discount" CommandName="DISCOUNT" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "BookID")%>'><img src="../../images/file.png" /></asp:LinkButton>
                                                                                                                                        </li>
                                                                                                                                        <li>
                                                                                                                                            <asp:LinkButton ID="lnkMISCOverride" Style="background: none !important; border: none;"
                                                                                                                                                runat="server" ToolTip="Override" CommandName="OVERRIDE" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "BookID")%>'><img src="../../images/file.png" /></asp:LinkButton>
                                                                                                                                        </li>
                                                                                                                                        <li>
                                                                                                                                            <asp:LinkButton ID="lnkMISCVoid" Style="background: none !important; border: none;"
                                                                                                                                                runat="server" ToolTip="Void" CommandName="VOID" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "BookID")%>'><img src="../../images/file.png" /></asp:LinkButton>
                                                                                                                                        </li>
                                                                                                                                </td>
                                                                                                                                <td class="actionsbuttons_hover_rightmenu">
                                                                                                                                </td>
                                                                                                                            </tr>
                                                                                                                        </table>
                                                                                                                    </div>
                                                                                                                </asp:Panel>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                    </Columns>
                                                                                                    <EmptyDataTemplate>
                                                                                                        <div style="padding: 10px;">
                                                                                                            <b>
                                                                                                                <asp:Label ID="lblNoRecordFoundForMISC" runat="server" Text="No Record Found."></asp:Label>
                                                                                                            </b>
                                                                                                        </div>
                                                                                                    </EmptyDataTemplate>
                                                                                                </asp:GridView>
                                                                                            </div>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </div>
                                                                            <div id="tabs-7">
                                                                                <table cellpadding="2" cellspacing="2" width="100%">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <div class="box_head">
                                                                                                <span>
                                                                                                    <asp:Literal ID="litPaymentDetails" runat="server" Text="Credit"></asp:Literal>
                                                                                                </span>
                                                                                            </div>
                                                                                            <div class="clear">
                                                                                            </div>
                                                                                            <div class="box_content">
                                                                                                <asp:GridView ID="gvPaymentDetails" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                                                    Width="100%" OnPageIndexChanging="gvPaymentDetails_PageIndexChanging" OnRowDataBound="gvPaymentDetails_RowDataBound"
                                                                                                    ShowFooter="true">
                                                                                                    <Columns>
                                                                                                        <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblGvHdrPaymentDate" runat="server" Text="Date"></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="lblGvPaymentDate" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "EntryDate")).ToString(clsSession.DateFormat)%>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblGvHdrPaymentBookNo" runat="server" Text="Trans. #"></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <%#DataBinder.Eval(Container.DataItem, "BookNo")%>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblGvHdrPaymentAccount" runat="server" Text="Ledger Account"></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="lblGvPaymentAccount" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Account")%>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" Visible="false" ItemStyle-HorizontalAlign="Left">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblGvHdrPaymentDescription" runat="server" Text="Description"></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="lblGvPaymentDescription" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Narration")%>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                            <FooterTemplate>
                                                                                                                <b>Total</b>
                                                                                                            </FooterTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                                                                                            FooterStyle-HorizontalAlign="Right">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblGvHdrPaymentPayment" runat="server" Text="Credit"></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="lblGvPayment" runat="server"></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                            <FooterTemplate>
                                                                                                                <b>
                                                                                                                    <asp:Label ID="lblGvFtTotalPayment" runat="server"></asp:Label>
                                                                                                                </b>
                                                                                                            </FooterTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                    </Columns>
                                                                                                    <EmptyDataTemplate>
                                                                                                        <div style="padding: 10px;">
                                                                                                            <b>
                                                                                                                <asp:Label ID="lblNoRecordFoundForPayment" runat="server" Text="No Record Found."></asp:Label>
                                                                                                            </b>
                                                                                                        </div>
                                                                                                    </EmptyDataTemplate>
                                                                                                </asp:GridView>
                                                                                            </div>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </div>
                                                                            <div id="tabs-8">
                                                                                <table cellpadding="2" cellspacing="2" width="100%">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <%if (IsDepositMessage)
                                                                                              { %>
                                                                                            <div class="message finalsuccess">
                                                                                                <p>
                                                                                                    <strong>
                                                                                                        <asp:Literal ID="ltrDepositMessage" runat="server"></asp:Literal></strong>
                                                                                                </p>
                                                                                            </div>
                                                                                            <%}%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <div class="box_head">
                                                                                                <span>
                                                                                                    <asp:Literal ID="litDepositDetails" runat="server" Text="Deposit"></asp:Literal>
                                                                                                </span>
                                                                                            </div>
                                                                                            <div class="clear">
                                                                                            </div>
                                                                                            <div class="box_content">
                                                                                                <asp:GridView ID="gvDepositDetails" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                                                    Width="100%" OnRowCommand="gvDepositDetails_RowCommand" ShowFooter="true" OnPageIndexChanging="gvDepositDetails_PageIndexChanging"
                                                                                                    OnRowDataBound="gvDepositDetails_RowDataBound" DataKeyNames="EntryDate,IsVoid,RoomID,BookID,ReservationNo">
                                                                                                    <Columns>
                                                                                                        <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblGvHdrDepositDate" runat="server" Text="Date"></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="lblGvDepositDate" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "EntryDate")).ToString(clsSession.DateFormat)%>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblGvHdrDepositBookNo" runat="server" Text="Trans. #"></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="lblGvDepositDetailsBookNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "BookNo")%>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblGvHdrDepositAccount" runat="server" Text="Ledger Account"></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="lblGvDepositAccount" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Account")%>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" Visible="false" ItemStyle-HorizontalAlign="Left">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblGvHdrDepositDescription" runat="server" Text="Description"></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="lblGvDepositDescription" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Narration")%>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                            <FooterTemplate>
                                                                                                                <b>Total</b>
                                                                                                            </FooterTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                                                                                            FooterStyle-HorizontalAlign="Right">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblGvHdrDepositDueAmount" runat="server" Text="Credit"></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="lblGvDepositDueAmount" runat="server"></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                            <FooterTemplate>
                                                                                                                <b>
                                                                                                                    <asp:Label ID="lblGvFtTotalDepositDueAmount" runat="server"></asp:Label></b>
                                                                                                            </FooterTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField ItemStyle-Width="50px" Visible="false" HeaderStyle-HorizontalAlign="Left"
                                                                                                            ItemStyle-HorizontalAlign="Left">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblGvHdrDepositAction" runat="server" Text="Action"></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="lblDepositPopUp" runat="server" Text="Action"></asp:Label>
                                                                                                                <ajx:HoverMenuExtender ID="hmeDeposit" runat="server" TargetControlID="lblDepositPopUp"
                                                                                                                    PopupControlID="panDeposit" PopupPosition="Left">
                                                                                                                </ajx:HoverMenuExtender>
                                                                                                                <asp:Panel ID="panDeposit" runat="server" Style="visibility: hidden; opacity: 100%">
                                                                                                                    <div class="actionsbuttons_hovermenu">
                                                                                                                        <table border="0" cellpadding="0" cellspacing="0" class="actionsbuttons_hover_lettmenu_table">
                                                                                                                            <tr>
                                                                                                                                <td class="actionsbuttons_hover_lettmenu">
                                                                                                                                </td>
                                                                                                                                <td class="actionsbuttons_hover_centermenu">
                                                                                                                                    <ul>
                                                                                                                                        <li>
                                                                                                                                            <asp:LinkButton ID="lnkDepositDetailsRefund" runat="server" Style="background: none !important;
                                                                                                                                                border: none;" ToolTip="Refund" CommandName="REFUND" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "BookID")%>'><img src="../../images/file.png" /></asp:LinkButton>
                                                                                                                                        </li>
                                                                                                                                        <li>
                                                                                                                                            <asp:LinkButton ID="lnkDepositDetailsTransfer" runat="server" Style="background: none !important;
                                                                                                                                                border: none;" ToolTip="Transfer" CommandName="TRANSFER" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "BookID")%>'><img src="../../images/file.png" /></asp:LinkButton>
                                                                                                                                        </li>
                                                                                                                                        <li>
                                                                                                                                            <asp:LinkButton ID="lnkDepositDetailsDetail" runat="server" Style="background: none !important;
                                                                                                                                                border: none;" ToolTip="Change Description" CommandName="CHANGEDESCRIPTION" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "BookID")%>'><img src="../../images/file.png" /></asp:LinkButton>
                                                                                                                                        </li>
                                                                                                                                    </ul>
                                                                                                                                </td>
                                                                                                                                <td class="actionsbuttons_hover_rightmenu">
                                                                                                                                </td>
                                                                                                                            </tr>
                                                                                                                        </table>
                                                                                                                    </div>
                                                                                                                </asp:Panel>
                                                                                                                <%--<asp:LinkButton ID="lnkDepositDetailsRefund" runat="server" ToolTip="Refund" CommandName="REFUND">Refund</asp:LinkButton>
                                                                                                        <asp:LinkButton ID="lnkDepositDetailsTransfer" runat="server" ToolTip="Transfer"
                                                                                                            CommandName="TRANSFER">Transfer</asp:LinkButton>
                                                                                                        <asp:LinkButton ID="lnkDepositDetailsDetail" runat="server" ToolTip="Detail" CommandName="DETAIL">Detail</asp:LinkButton>--%>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                    </Columns>
                                                                                                    <EmptyDataTemplate>
                                                                                                        <div style="padding: 10px;">
                                                                                                            <b>
                                                                                                                <asp:Label ID="lblNoRecordFoundForDueAmount" runat="server" Text="No Record Found."></asp:Label>
                                                                                                            </b>
                                                                                                        </div>
                                                                                                    </EmptyDataTemplate>
                                                                                                </asp:GridView>
                                                                                            </div>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
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
                                <%--<uc1:MsgBox ID="MessageBox" runat="server" />--%>
                            </div>
                        </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="vPostRoomCharge" runat="server">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="content">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="boxtopleft">
                                        &nbsp;
                                    </td>
                                    <td class="boxtopcenter">
                                        <asp:Literal ID="litMainHrdofPostRoomCharge" runat="server" Text="Post Room Charge"></asp:Literal>
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
                                            <%if (IsMessage)
                                              { %>
                                            <div class="message finalsuccess">
                                                <p>
                                                    <strong>
                                                        <asp:Label ID="lblCommonMsg" runat="server"></asp:Label>
                                                    </strong>
                                                </p>
                                            </div>
                                            <% }%>
                                            <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                <tr>
                                                    <td colspan="4" style="vertical-align: top; border: 1px solid #ccccce;">
                                                        <b>
                                                            <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                                <tr>
                                                                    <td>
                                                                        <asp:Literal ID="litReservationNo" runat="server" Text="Reservation No."></asp:Literal>
                                                                    </td>
                                                                    <td style="vertical-align: top; border-right: 1px solid #ccccce;">
                                                                        <asp:Literal ID="litDspReservationNo" runat="server" Text=""></asp:Literal>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Literal ID="litGuestName" runat="server" Text="Guest Name"></asp:Literal>
                                                                    </td>
                                                                    <td style="vertical-align: top; border-right: 1px solid #ccccce;">
                                                                        <asp:Literal ID="litDspGuestName" runat="server" Text=""></asp:Literal>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Literal ID="litRoomNo" runat="server" Text="Room No."></asp:Literal>
                                                                    </td>
                                                                    <td style="vertical-align: top; border-right: 1px solid #ccccce;">
                                                                        <asp:Literal ID="litDspRoomNo" runat="server" Text=""></asp:Literal>
                                                                    </td>
                                                                    <%--</tr>
                                                                <tr>--%>
                                                                    <td>
                                                                        <asp:Literal ID="litCheckin" runat="server" Text="Checkin Date"></asp:Literal>
                                                                    </td>
                                                                    <td style="vertical-align: top; border-right: 1px solid #ccccce;">
                                                                        <asp:Literal ID="litDspCheckin" runat="server" Text=""></asp:Literal>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Literal ID="litCheckoutDate" runat="server" Text="Checkout Date"></asp:Literal>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Literal ID="litDspCheckoutDate" runat="server" Text=""></asp:Literal>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <hr />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="isrequire" style="width: 102px;">
                                                        <asp:Literal ID="litPostChargeFrom" runat="server" Text="Post Charge From"></asp:Literal>
                                                    </td>
                                                    <td style="width: 252px;">
                                                        <asp:TextBox ID="txtPostChargeFrom" onkeypress="return false;" runat="server" Style="width: 180px !important;"></asp:TextBox>
                                                        <asp:Image ID="imgPostChargeFrom" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                            Height="20px" Width="20px" />
                                                        <ajx:CalendarExtender ID="calPostChargeFrom" PopupButtonID="imgPostChargeFrom" TargetControlID="txtPostChargeFrom"
                                                            runat="server">
                                                        </ajx:CalendarExtender>
                                                        <img src="../../images/clear.png" id="img1" style="vertical-align: middle;" title="Clear Date"
                                                            onclick="fnClearDate('<%= txtPostChargeFrom.ClientID %>');" />
                                                        <asp:RequiredFieldValidator ID="rfvPostChargeFrom" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                            runat="server" ValidationGroup="PostChargeIsRequire" ControlToValidate="txtPostChargeFrom"
                                                            Display="Dynamic">
                                                        </asp:RequiredFieldValidator>
                                                    </td>
                                                    <td class="isrequire" style="width: 30px;">
                                                        <asp:Literal ID="litPostChargeTo" runat="server" Text="To"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPostChargeTo" onkeypress="return false;" runat="server" Style="width: 180px !important;"></asp:TextBox>
                                                        <asp:Image ID="imgPostChargeTo" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                            Height="20px" Width="20px" />
                                                        <ajx:CalendarExtender ID="calPostChargeTo" PopupButtonID="imgPostChargeTo" TargetControlID="txtPostChargeTo"
                                                            runat="server">
                                                        </ajx:CalendarExtender>
                                                        <img src="../../images/clear.png" id="img2" style="vertical-align: middle;" title="Clear Date"
                                                            onclick="fnClearDate('<%= txtPostChargeTo.ClientID %>');" />
                                                        <asp:RequiredFieldValidator ID="rfvPostChargeTo" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                            runat="server" ValidationGroup="PostChargeIsRequire" ControlToValidate="txtPostChargeTo"
                                                            Display="Dynamic">
                                                        </asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" align="right">
                                                        <asp:Button ID="btnPostRoomChargePost" ValidationGroup="PostChargeIsRequire" runat="server"
                                                            Text="Post" Style="display: inline;" OnClick="btnPostRoomChargePost_OnClick" />
                                                        <asp:Button ID="btnPostRoomChargeCancel" runat="server" OnClick="btnPostRoomChargeCancel_OnClick"
                                                            Text="Cancel" Style="display: inline;" />
                                                    </td>
                                                </tr>
                                            </table>
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
                                <%--<uc1:MsgBox ID="MessageBox" runat="server" />--%>
                            </div>
                        </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="vSplitBilling" runat="server">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="content">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="boxtopleft">
                                        &nbsp;
                                    </td>
                                    <td class="boxtopcenter">
                                        <asp:Literal ID="Literal1" runat="server" Text="Split Billing"></asp:Literal>
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
                                            <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                <tr>
                                                    <td colspan="2">
                                                        <%if (IsSplitBilling)
                                                          { %>
                                                        <div class="message finalsuccess">
                                                            <p>
                                                                <strong>
                                                                    <asp:Label ID="lblSplitBillingMsg" runat="server"></asp:Label></strong>
                                                            </p>
                                                        </div>
                                                        <% }%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <div class="box_head">
                                                            <span>
                                                                <asp:Literal ID="Literal21" runat="server" Text="Folio List"></asp:Literal>
                                                            </span>
                                                        </div>
                                                        <div class="clear">
                                                        </div>
                                                        <div class="box_content">
                                                            <asp:GridView ID="gvSplitBillingFolioList" runat="server" AutoGenerateColumns="false"
                                                                ShowHeader="true" Width="100%" OnRowDataBound="gvSplitBillingFolioList_RowDataBound"
                                                                OnRowCommand="gvSplitBillingFolioList_RowCommand" OnPageIndexChanging="gvSplitBillingFolioList_PageIndexChanging">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrSBFolioNo" runat="server" Text="Folio No."></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvSBFolioNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "FolioNo")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrSBBilledTo" runat="server" Text="Bill To"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvSBBilledTo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "BilledTo")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrSBCreatedOn" runat="server" Text="Created On"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvSBCreatedOn" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="125px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrSBFolioStatus" runat="server" Text="Folio Status"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvSBFolioStatus" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "FolioStatus")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                                                        ItemStyle-Width="100px">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrSBBalance" runat="server" Text="Balance"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvSBBalance" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblSplitBillingActions" runat="server" Text="Action"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblSplitBillingPopUp" runat="server" Text="Actions"></asp:Label>
                                                                            <ajx:HoverMenuExtender ID="hmeSplitBilling" runat="server" TargetControlID="lblSplitBillingPopUp"
                                                                                PopupControlID="pnlSplitBilling" PopupPosition="Left">
                                                                            </ajx:HoverMenuExtender>
                                                                            <asp:Panel ID="pnlSplitBilling" runat="server" Style="visibility: hidden; opacity: 100%">
                                                                                <div class="actionsbuttons_hovermenu">
                                                                                    <table border="0" cellpadding="0" cellspacing="0" class="actionsbuttons_hover_lettmenu_table">
                                                                                        <tr>
                                                                                            <td class="actionsbuttons_hover_lettmenu">
                                                                                            </td>
                                                                                            <td class="actionsbuttons_hover_centermenu">
                                                                                                <ul>
                                                                                                    <li>
                                                                                                        <asp:LinkButton Style="background: none !important; border: none;" ID="lnkSplitBillingEdit"
                                                                                                            runat="server" ToolTip="Edit" CommandName="EDITDATA" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "FolioID")%>'><img src="../../images/file.png" /></asp:LinkButton>
                                                                                                    </li>
                                                                                                </ul>
                                                                                            </td>
                                                                                            <td class="actionsbuttons_hover_rightmenu">
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </div>
                                                                            </asp:Panel>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <div style="padding: 10px;">
                                                                        <b>
                                                                            <asp:Label ID="lblNoRecordFound" runat="server" Text="No Record Found."></asp:Label>
                                                                        </b>
                                                                    </div>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <hr />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="110px;">
                                                        <asp:Label ID="lblSBBillTo" runat="server" Text="Bill To"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSBBillTo" runat="server" MaxLength="65"></asp:TextBox>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rfvSBBillTo" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                runat="server" ValidationGroup="IsRequireSplitBilling" ControlToValidate="txtSBBillTo"
                                                                Display="Dynamic">
                                                            </asp:RequiredFieldValidator>
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: top;">
                                                        <asp:Label ID="lblSBBillingAddress" runat="server" Text="Billing Address"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSBBillingAddress" runat="server" MaxLength="500" TextMode="MultiLine"
                                                            Style="height: 150px;"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:Label ID="lblReRouteForm" runat="server" Text="Re Route Form" Style="font-weight: bold;"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:CheckBox ID="chkSBAccommodationCharges" runat="server" Text="Accommodation Charges" />
                                                    </td>
                                                    <%--<td>
                                                        <asp:DropDownList ID="ddlSBOperationAccommodationCharges" runat="server">
                                                            <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                            <asp:ListItem Text="E-voyages - 111" Value="E-voyages - 111"></asp:ListItem>
                                                            <asp:ListItem Text="E-voyages - 112" Value="E-voyages - 112"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>--%>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:CheckBox ID="chkSBRestaurantCharges" runat="server" Text="Restaurant Charges" />
                                                    </td>
                                                    <%--<td>
                                                        <asp:DropDownList ID="ddlSBRestaurantCharges" runat="server">
                                                            <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                            <asp:ListItem Text="E-voyages - 111" Value="E-voyages - 111"></asp:ListItem>
                                                            <asp:ListItem Text="E-voyages - 112" Value="E-voyages - 112"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>--%>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:CheckBox ID="chkSBPhoneCharges" runat="server" Text="Phone Charges" />
                                                    </td>
                                                    <%--<td>
                                                        <asp:DropDownList ID="ddlSBPhoneCharges" runat="server">
                                                            <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                            <asp:ListItem Text="E-voyages - 111" Value="E-voyages - 111"></asp:ListItem>
                                                            <asp:ListItem Text="E-voyages - 112" Value="E-voyages - 112"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>--%>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:CheckBox ID="chkSBMiscellaneousCharges" runat="server" Text="Miscellaneous Charges" />
                                                    </td>
                                                    <%--<td>
                                                        <asp:DropDownList ID="ddlSBOperationMiscellaneousCharges" runat="server">
                                                            <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                            <asp:ListItem Text="E-voyages - 111" Value="E-voyages - 111"></asp:ListItem>
                                                            <asp:ListItem Text="E-voyages - 112" Value="E-voyages - 112"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>--%>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:CheckBox ID="chkSBPOS" runat="server" Text="POS" />
                                                    </td>
                                                    <%--<td>
                                                        <asp:DropDownList ID="ddlSBOperationPOS" runat="server">
                                                            <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                            <asp:ListItem Text="E-voyages - 111" Value="E-voyages - 111"></asp:ListItem>
                                                            <asp:ListItem Text="E-voyages - 112" Value="E-voyages - 112"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>--%>
                                                </tr>
                                                <tr>
                                                    <td align="right" colspan="2">
                                                        <asp:Button ID="btnSplitBillingSave" runat="server" Style="display: inline; padding-right: 10px;"
                                                            Text="Save" OnClick="btnSplitBillingSave_Click" ValidationGroup="IsRequireSplitBilling" />
                                                        <asp:Button ID="btnSplitBillingCancel" runat="server" Style="display: inline;" Text="Cancel"
                                                            OnClick="btnSplitBillingCancel_Click" />
                                                        <asp:Button ID="btnSplitBillingBack" runat="server" Style="display: inline;" Text="Back To Details"
                                                            OnClick="btnSplitBillingBack_Click" />
                                                    </td>
                                                </tr>
                                            </table>
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
                                <%--<uc1:MsgBox ID="MessageBox" runat="server" />--%>
                            </div>
                        </td>
                    </tr>
                </table>
            </asp:View>
        </asp:MultiView>
        <ucCtrlQuickPost:QuickPost ID="ctrlCommonQuickPost" runat="server" OnbtnQuickPostCallParent_Click="btnQuickPostCallParent_Click" />
        <ucCtrlVoidTransaction:VoidTransaction ID="ctrlCommonVoidTransaction" runat="server"
            OnbtnVoidTransactionCallParent_Click="btnVoidTransactionCallParent_Click" />
        <ucCtrlFolioTransactionDetails:FolioTransactionDetails ID="ctrlCommonFolioTransactionDetails"
            runat="server" OnbtnFolioTransactionDetailsCallParent_Click="btnFolioTransactionDetailsCallParent_Click" />
        <ucCtrlTransactionDiscount:TransactionDiscount ID="ctrlCommonTransactionDiscount"
            runat="server" OnbtnDiscountOnTransactionCallParent_Click="btnDiscountOnTransactionCallParent_Click" />
        <ajx:ModalPopupExtender ID="mpeRefundDeposit" runat="server" TargetControlID="hdnRefundDeposit"
            PopupControlID="pnlRefundDeposit" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnRefundDeposit" runat="server" />
        <asp:Panel ID="pnlRefundDeposit" runat="server" Width="750px" Style="display: none;">
            <ucCtrlRefundDeposit:RefundDeposit ID="ctrlCommonRefundDeposit" runat="server" OnbtnRefundDepositCallParent_Click="btnRefundDepositCallParent_Click" />
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpeTransferDeposit" runat="server" TargetControlID="hdnTransferDeposit"
            PopupControlID="pnlTransferDeposit" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnTransferDeposit" runat="server" />
        <asp:Panel ID="pnlTransferDeposit" runat="server" Width="675px" Style="display: none;">
            <ucCtrlTransferDeposit:TransferDeposit ID="ctrlCommonTransferDeposit" runat="server" />
        </asp:Panel>
        <ucCtrlAddServices:AddServices ID="ctrlCommonAddServices" runat="server" OnbtnAddServicesCallParent_Click="btnAddServicesCallParent_Click" />
        <ucCtrlCommonCardInfo:CommonCardInfo ID="ctrlCommonCommonCardInfo" runat="server" />
        <ucCtrlFolioOverrideTransaction:FolioOverrideTransaction ID="ctrlCommoFolioOverrideTransaction"
            runat="server" OnbtnOverrideTransactionCallParent_Click="btnOverrideTransactionCallParent_Click" />
        <ucCtrlHouseKeeping:HouseKeeping ID="ctrlCommonHouseKeeping" runat="server" />
        <ucCtrlInvoiceBillingName:InvoiceBillingName ID="ctrlCommonInvoiceBillingName" runat="server" />
        <ucCtrlFolioAssingPackage:FolioAssingPackage ID="ctrlFolioAssingPackage" runat="server" />
        <ucCtrlPostUnitCharges:PostUnitCharges ID="CtrlCommonPostUnitCharges" runat="server" />
        <ucCtrlSubFolioPayment:SubFolioPayment ID="ctrlSubFolioPayment" runat="server" OnbtnSubFolioPaymentCallParent_Click="btnSubFolioPaymentCallParent_Click" />
        <ajx:ModalPopupExtender ID="mpeOpenSubFolio" runat="server" TargetControlID="hdnOpenSubFolio"
            PopupControlID="pnlOpenSubFolio" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnOpenSubFolio" runat="server" />
        <asp:Panel ID="pnlOpenSubFolio" runat="server" Width="790px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="litSubFolioHeader" runat="server" Text="Sub Folio"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <ucCtrlSubFolioConfiguration:SubFolioConfiguration ID="ctrlCommonSubFolioConfiguration"
                        runat="server" OnbtnSubFolioConfigurationCallParent_Click="btnSubFolioConfigurationCallParent_Click" />
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpeGuestHistory" runat="server" TargetControlID="hdnGuestHistory"
            PopupControlID="pnlGuestHistory" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnGuestHistory" runat="server" />
        <asp:Panel ID="pnlGuestHistory" runat="server" Width="850px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="litGuestHistory" runat="server" Text="Guest History"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <ucCtrlGuestHistory:GuestHistory ID="ctrlCommonGuestHistory" runat="server" />
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpeMoveUnit" runat="server" TargetControlID="hdnMoveUnit"
            PopupControlID="pnlMoveUnit" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnMoveUnit" runat="server" />
        <asp:Panel ID="pnlMoveUnit" runat="server" Width="670px" Style="display: none;">
            <ucCtrlMoveUnitSetup:MoveUnitSetup ID="ctrlCommonMoveUnitSetup" runat="server" OnbtnMoveUnitCallParent_Click="btnMoveUnitCallParent_Click" />
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpeDateErrorMsg" runat="server" TargetControlID="hdnDateErrorMsg"
            PopupControlID="pnlDateErrorMsg" BackgroundCssClass="mod_background" CancelControlID="btnOk">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnDateErrorMsg" runat="server" />
        <asp:Panel ID="pnlDateErrorMsg" runat="server" Width="300px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                </div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table width="100%" cellpadding="2" cellspacing="2">
                        <tr>
                            <td style="width: 70px;" align="center">
                                <asp:Literal ID="litCommonMsg" runat="server" Text="To Date Not Less Then From Date..."></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnOk" runat="server" Text="Ok" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpeOpenCounter" runat="server" TargetControlID="hdnOpenCounter"
            PopupControlID="pnlOpenCounter" BackgroundCssClass="mod_background" CancelControlID="iBtnCloseCounter">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnOpenCounter" runat="server" />
        <asp:Panel ID="pnlOpenCounter" runat="server" Width="400px">
            <div class="box_col1">
                <div class="box_head">
                    <div style="display: inline;">
                        <span>
                            <asp:Literal ID="Literal20" runat="server" Text="Counter"></asp:Literal></span></div>
                    <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                        <asp:ImageButton ID="iBtnCloseCounter" runat="server" ImageUrl="~/images/closepopup.png"
                            Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;" />
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
            PopupControlID="pnlCounterErrorMessage" BackgroundCssClass="mod_background" CancelControlID="btnCounterErrorMessageOK"
            BehaviorID="mpeCounterErrorMessage">
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
                                <asp:Button ID="btnCounterErrorMessageOK" Text="OK" runat="server" Style="display: inline;
                                    padding-right: 10px;" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpeConfirmDeleteFolioDetails" runat="server" TargetControlID="hdnConfirmDeleteFolioDetails"
            PopupControlID="pnlDeleteDataFolioDetails" BackgroundCssClass="mod_background"
            CancelControlID="btnCancelDeleteFolioDetails" BehaviorID="mpeConfirmDeleteFolioDetails">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnConfirmDeleteFolioDetails" runat="server" />
        <asp:Panel ID="pnlDeleteDataFolioDetails" runat="server" Height="350px" Width="325px"
            Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="ltrHeaderConfirmDeletePopup" runat="server" Text="Message"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td align="center" style="padding-bottom: 15px;">
                                <asp:Label ID="lblConfirmDeleteMsg" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnYesFolioDetails" runat="server" Style="display: inline; padding-right: 10px;"
                                    OnClick="btnYesFolioDetails_Click" Text="Yes" />
                                <asp:Button ID="btnCancelDeleteFolioDetails" runat="server" Style="display: inline;"
                                    Text="No" />
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
        <asp:PostBackTrigger ControlID="btnPrintStatement" />
    </Triggers>
</asp:UpdatePanel>
<asp:UpdateProgress AssociatedUpdatePanelID="updFolioDetails" ID="UpdateProgressFolioDetails"
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
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
