<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlReprintPaymentInvoice.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Billing.CtrlReprintPaymentInvoice" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">

    function pageLoad(sender, args) {
        var v1 = '<%=ConfigurationManager.AppSettings["IsUpperCase"].ToString() %>'
        if (v1 == "1") {
            $('input[type="text"],textarea').each(function () { $(this).css("text-transform", "uppercase") });
        }
        $(document).ready(function () {
            $("#<%=txtCheckOutGuestName.ClientID%>").autocomplete('AutoGuestSuggest.ashx');
        });
    }

    function fnOpneWindow(TransactionID) {
        var hdnReservationID = document.getElementById('<%= hdnResID.ClientID %>').value;
        window.open("../Reservation/CheckInPaymentRecipt.aspx?IdofRes=" + hdnReservationID + "&IdOfTranNo=" + TransactionID, "CheckInVouche", "height=600,width=600,status=1,toolbar=no,menubar=no,scrollbars=1,location=0");
    }
    function openViewer() {
        var Preview = '<%=IsPreview%>';
        window.open("../../ReportFiles/frmViewer.aspx?preview=" + Preview);
    } 
</script>
<script type="text/javascript">
    function fnCompanyInvoicePrint() {
        var hdnReservationID = document.getElementById('<%= hdnResID.ClientID %>').value;
        window.open("../../GUI/Reservation/CompanyBillPrint.aspx?ReservationID=" + hdnReservationID, "Company Invoice", "height=900,width=850,status=1,toolbar=no,menubar=no,scrollbars=1,location=0");
    }
</script>
<asp:UpdatePanel ID="updCheckInList" runat="server">
    <ContentTemplate>
        <asp:HiddenField ID="hdnResID" runat="server" />
        <asp:HiddenField ID="hdnTransID" runat="server" />
        <asp:MultiView ID="mvReprint" runat="server">
            <asp:View ID="vResSearch" runat="server">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="content">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="boxtopleft">
                                        &nbsp;
                                    </td>
                                    <td class="boxtopcenter">
                                        <asp:Literal ID="litMainHeader" runat="server" Text="Reprint receipt"></asp:Literal>
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
                                            <table width="100%">
                                                <tr>
                                                    <td align="left" style="padding-bottom: 300px;">
                                                        <table cellpadding="2" cellspacing="2" border="0">
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="Literal9" runat="server" Text="Guest Name"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtCheckOutGuestName" runat="server" Style="width: 400px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="isrequire">
                                                                    <asp:Literal ID="Literal7" runat="server" Text="Booking #"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtBookingNoForCheckOut" runat="server" Style="width: 100px"></asp:TextBox>
                                                                    <span>
                                                                        <asp:RequiredFieldValidator ID="rfvForCheckOut" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                            runat="server" ValidationGroup="IsRequireForCheckOut" ControlToValidate="txtBookingNoForCheckOut"
                                                                            Display="Dynamic">
                                                                        </asp:RequiredFieldValidator>
                                                                    </span>
                                                                    <ajx:FilteredTextBoxExtender ID="fteBookingNoForCheckOut" runat="server" TargetControlID="txtBookingNoForCheckOut"
                                                                        FilterMode="ValidChars" ValidChars="0123456789">
                                                                    </ajx:FilteredTextBoxExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td>
                                                                    <asp:Button ID="btnProceedCheckOut" runat="server" Text="Proceed" Style="display: inline;"
                                                                        OnClick="btnProceedCheckOut_OnClick" ValidationGroup="IsRequireForCheckOut" />
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
                            </div>
                        </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="vReceiptData" runat="server">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="content">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="boxtopleft">
                                        &nbsp;
                                    </td>
                                    <td class="boxtopcenter">
                                        <asp:Literal ID="Literal2" runat="server" Text="Reprint receipt / Invoices"></asp:Literal>
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
                                            <div style="margin-bottom: 20px;">
                                                <table width="100%" cellpadding="2" cellspacing="2">
                                                    <tr>
                                                        <td width="60px">
                                                            Booking #
                                                        </td>
                                                        <td width="150px">
                                                            <asp:Literal ID="ltrChkPmtReservationNo" runat="server"></asp:Literal>
                                                        </td>
                                                        <td width="70px">
                                                            Guest Name
                                                        </td>
                                                        <td width="150px">
                                                            <asp:Literal ID="ltrChkPmtGuestName" runat="server"></asp:Literal>
                                                        </td>
                                                        <td width="50px">
                                                            Check In
                                                        </td>
                                                        <td width="100px">
                                                            <asp:Literal ID="ltrChkPmtCheckInDate" runat="server"></asp:Literal>
                                                        </td>
                                                        <td width="50px">
                                                            Check Out
                                                        </td>
                                                        <td width="100px">
                                                            <asp:Literal ID="ltrChkPmtCheckOutDate" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Rate Card
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="ltrChkPmtRateCard" runat="server"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            Room Type
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="ltrChkPmtRoomType" runat="server"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            Room No.
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="ltrChkPmtRoomNo" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div style="border-bottom: 1px solid #CCCCCC; margin-bottom: 20px;">
                                            </div>
                                            <div class="box_head">
                                                <span>
                                                    <asp:Literal ID="litPrintReceipt" runat="server" Text="Payment Receipt"></asp:Literal>
                                                </span>
                                            </div>
                                            <div class="box_content">
                                                <asp:GridView ID="gvPaymentList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                    OnRowDataBound="gvPaymentList_RowDataBound" Width="100%">
                                                    <Columns>
                                                        <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrDateOfPayment" runat="server" Text="Date"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDateOfPayment" runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrTransactionNo" runat="server" Text="Transaction #"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%#DataBinder.Eval(Container.DataItem, "BookNo")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrPaymentMode" runat="server" Text="Payment Mode"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%--<%#DataBinder.Eval(Container.DataItem, "PaymentMode")%>--%>
                                                                <asp:Label ID="lblPaymentMode" runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrAmount" runat="server" Text="Amount"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAmount" runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblActions" runat="server" Text="Action"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPopUp" runat="server" Text="Actions"></asp:Label>
                                                                <ajx:HoverMenuExtender ID="HoverMenuExtender2" runat="server" TargetControlID="lblPopUp"
                                                                    PopupControlID="Panel2" PopupPosition="Left">
                                                                </ajx:HoverMenuExtender>
                                                                <asp:Panel ID="Panel2" runat="server" Style="visibility: hidden; opacity: 100%">
                                                                    <div class="actionsbuttons_hovermenu">
                                                                        <table border="0" cellpadding="0" cellspacing="0" class="actionsbuttons_hover_lettmenu_table">
                                                                            <tr>
                                                                                <td class="actionsbuttons_hover_lettmenu">
                                                                                </td>
                                                                                <td class="actionsbuttons_hover_centermenu">
                                                                                    <ul>
                                                                                        <li>
                                                                                            <asp:LinkButton Style="background: none !important; border: none;" ID="lnkPrintReceipt"
                                                                                                runat="server" ToolTip="Print receipt" CommandName="PRINTRECEIPT" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ReservationID")%>'><img src="../../images/file.png" /></asp:LinkButton>
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
                                                                <asp:Label ID="lblNoRecordFound" runat="server" Text="No payment found."></asp:Label>
                                                            </b>
                                                        </div>
                                                    </EmptyDataTemplate>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                        <div style="margin-bottom: 18px; margin-top: 12px;">
                                            <center>
                                                <asp:Button ID="btnPrintReceipt" runat="server" Text="Print Receipt" Style="display: inline;"
                                                    OnClientClick="fnOpneWindow('');" />
                                                <asp:Button ID="btnBackToReprint" runat="server" OnClick="btnBackToReprint_Click"
                                                    Style="display: inline;" Text="Back" />
                                            </center>
                                        </div>
                                        <div style="border-bottom: 1px solid #CCCCCC; margin-bottom: 20px;">
                                        </div>
                                        <div class="box_head" style="margin-bottom: 20px;">
                                            <span>
                                                <asp:Literal ID="Literal3" runat="server" Text="Invoice"></asp:Literal>
                                            </span>
                                        </div>
                                        <div id="Div3" style="margin-left: 390px;">
                                            <div id="dvInvoicePrint" style="float: left; margin-left: 2px;">
                                                <asp:RadioButton ID="rdoDetail" runat="server" Text="Detail Report" AutoPostBack="true"
                                                    GroupName="Collection" OnCheckedChanged="rdoDetail_CheckedChanged" />
                                            </div>
                                            <div id="Div1" style="float: left; margin-left: 10px;">
                                                <asp:RadioButton ID="rdoSummary" runat="server" Text="Summary Report" GroupName="Collection"
                                                    AutoPostBack="true" OnCheckedChanged="rdoDetail_CheckedChanged" />
                                            </div>
                                            <div id="Div2" style="float: left; margin-left: 10px;">
                                                <asp:Button ID="btnPrintBill" runat="server" Text="Print Bill" OnClick="btnPrintBill_OnClick"
                                                    Style="display: inline;" />
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
                                <div class="clear_divider">
                                </div>
                                <div class="clear">
                                </div>
                            </table>
                        </td>
                    </tr>
                </table>
            </asp:View>
        </asp:MultiView>
        <ajx:ModalPopupExtender ID="mpeSuccessMessage" runat="server" TargetControlID="hfSuccessMessage"
            PopupControlID="pnlSuccessMessage" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hfSuccessMessage" runat="server" />
        <asp:Panel ID="pnlSuccessMessage" runat="server" Style="display: none; min-height: 350px;
            min-width: 350px;">
            <div class="box_col1">
                <div class="box_head">
                    <div style="display: inline;">
                        <span>
                            <asp:Literal ID="Literal1" runat="server" Text="Message"></asp:Literal></span></div>
                    <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                        <asp:ImageButton ID="iBtnCancelSuccessMessage" runat="server" ImageUrl="~/images/closepopup.png"
                            Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;"
                            OnClick="iBtnCacelCheckOut_OnClick" />
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%" style="margin-top: 10px;">
                        <tr>
                            <td align="center" style="padding-bottom: 15px;">
                                <asp:Label ID="lblSuccessMessage" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnSuccessMessageOK" Text="OK" runat="server" OnClick="btnSuccessMessageOK_OnClick"
                                    Style="display: inline; padding-right: 10px;" />
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
    </Triggers>
</asp:UpdatePanel>
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updCheckInList" ID="UpdateProgressCheckInList"
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
