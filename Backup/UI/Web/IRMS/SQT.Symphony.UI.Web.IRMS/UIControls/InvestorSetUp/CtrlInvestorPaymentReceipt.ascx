<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlInvestorPaymentReceipt.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.InvestorSetUp.CtrlInvestorPaymentReceipt" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function pageLoad(sender, args) {
        $(document).ready(function () {
            $("#<%=txtSInvestorName.ClientID%>").autocomplete('../Investors/InvestorAutoComplete.ashx');
        });
    }

    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }

    function stopKey(evt) {
        var evt = (evt) ? evt : ((event) ? event : null);
        var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
        if ((evt.keyCode == 8) && (node.type == "text")) { return false; }
        else if ((evt.keyCode == 9) && (node.type == "text")) { return true; }
        else if ((evt.keyCode == 46) && (node.type == "text")) { return false; }
        else { return false; }
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
<script type="text/javascript">
    var updateProgress = null;

    function postbackButtonClick() {
        if (Page_ClientValidate("PaymentReceipt")) {
            document.getElementById('errormessage').style.display = "block";
            updateProgress = $find("<%= UpdateProgressIPR.ClientID %>");
            window.setTimeout("updateProgress.set_visible(true)", updateProgress.get_displayAfter());
            return true;
        }
        else {
            return false;
        }
    }
</script>
<asp:UpdatePanel ID="updIPR" runat="server">
    <ContentTemplate>
        <asp:HiddenField ID="hdnPaymentSlab" runat="server" Value="" />
        <asp:HiddenField ID="hdnTotal" runat="server" Value="" />
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td style="padding-left: 0px; width: 66.66%">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                PAYMENT RECEIPTS
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
                                <div style="height: 455px;">
                                    <table width="100%" cellpadding="2" cellspacing="2">
                                        <tr>
                                            <td colspan="2">
                                                <div style="height: 26px;">
                                                    <%if (IsInsert)
                                                      { %>
                                                    <div class="ResetSuccessfully">
                                                        <div style="float: left; padding-top: 7px; width: 25px; height: 24px; margin-right: 10px;">
                                                            <img src="../../images/success.png" />
                                                        </div>
                                                        <div>
                                                            <asp:Label ID="lblPaymentReceiptMsg" runat="server"></asp:Label></div>
                                                        <div style="height: 10px;">
                                                        </div>
                                                    </div>
                                                    <% }%>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <div style="float: right;">
                                                    <b>All Bold Fields are Mandatory</b>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top" style="width: 25%;">
                                                <asp:Label ID="litInvestor" runat="server" Text="Investor Name" CssClass="RequireFile"></asp:Label>
                                                <span class="erroraleart">
                                                    <asp:RequiredFieldValidator ID="rvfInvestor" SetFocusOnError="True" ControlToValidate="ddlInvestor"
                                                        ValidationGroup="PaymentReceipt" InitialValue="00000000-0000-0000-0000-000000000000"
                                                        runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                                </span>
                                            </td>
                                            <td align="left" valign="top" style="width: 75%;">
                                                <asp:DropDownList ID="ddlInvestor" runat="server" AutoPostBack="true" Style="width: 203px;"
                                                    OnSelectedIndexChanged="ddlInvestor_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">
                                                <asp:Label ID="lblPropertyName" runat="server" Text="Property Name" CssClass="RequireFile"></asp:Label>
                                                <span class="erroraleart">
                                                    <asp:RequiredFieldValidator ID="rfvPropertyName" SetFocusOnError="True" ControlToValidate="ddlPropertyName"
                                                        ValidationGroup="PaymentReceipt" InitialValue="00000000-0000-0000-0000-000000000000"
                                                        runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                                </span>
                                            </td>
                                            <td align="left" valign="top">
                                                <%--<asp:DropDownList ID="ddlPropertyName" runat="server" AutoPostBack="true" Style="width: 203px;"
                                                    OnSelectedIndexChanged="ddlPropertyName_SelectedIndexChanged">
                                                </asp:DropDownList>--%>
                                                <asp:DropDownList ID="ddlPropertyName" runat="server" Style="width: 203px;">                                                    
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                       <%-- <tr>
                                            <td align="left" valign="top">
                                                <asp:Label ID="litRoomName" runat="server" Text="Unit No." CssClass="RequireFile"></asp:Label>
                                                <span class="erroraleart">
                                                    <asp:RequiredFieldValidator ID="rfvRoomName" SetFocusOnError="True" ControlToValidate="ddlRoomName"
                                                        ValidationGroup="PaymentReceipt" InitialValue="00000000-0000-0000-0000-000000000000"
                                                        runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                                </span>
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:DropDownList ID="ddlRoomName" runat="server" Style="width: 203px;" AutoPostBack="true"
                                                    OnSelectedIndexChanged="ddlRoomName_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top" style="width: 25%;">
                                                <asp:Label ID="litPaymentScheduleID" runat="server" Text="Payment Milestone" CssClass="RequireFile"></asp:Label>
                                                <span class="erroraleart">
                                                    <asp:RequiredFieldValidator ID="rfvPaymentSchedule" SetFocusOnError="True" ControlToValidate="ddlPaymentSchedule"
                                                        ValidationGroup="PaymentReceipt" InitialValue="00000000-0000-0000-0000-000000000000"
                                                        runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                                </span>
                                            </td>
                                            <td align="left" valign="top" style="width: 75%;">
                                                <asp:DropDownList ID="ddlPaymentSchedule" Style="width: 203px;" runat="server" AutoPostBack="true"
                                                    OnSelectedIndexChanged="ddlPaymentSchedule_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblSlabAmount" runat="server" Text="Milestone Amount"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblTotalSlabAmount" runat="server" Text="0.0"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblInvestorPaidAmount" runat="server" Text="Amount Paid"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPaidAmount" runat="server" Text="0.0"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblBalanceAmount" runat="server" Text="Balance Amount"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDisplayBalanceAmount" runat="server" Text="0.0"></asp:Label>
                                            </td>
                                        </tr>--%>
                                        <tr>
                                            <td>
                                                <asp:Label ID="litPaidAmount" runat="server" Text="Received Amount" CssClass="RequireFile"></asp:Label>
                                                <span class="erroraleart">
                                                    <asp:RequiredFieldValidator ID="rfvPaidAmount" SetFocusOnError="True" ControlToValidate="txtPaidAmount"
                                                        ValidationGroup="PaymentReceipt" runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                                </span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPaidAmount" runat="server" MaxLength="10" SkinID="CmpTextbox"></asp:TextBox>
                                                <ajx:FilteredTextBoxExtender ID="ftbetxtPaidAmount" runat="server" TargetControlID="txtPaidAmount"
                                                    FilterType="Custom, numbers" ValidChars="-." Enabled="True" />
                                            </td>
                                        </tr>
                                       <%-- <tr>
                                            <td>                                                
                                            </td>
                                            <td style="color:Red; font-size:12px;">
                                                <asp:Label ID="lblPaidAmountErrorMessage" runat="server"></asp:Label>--%>
                                                <%--<asp:RangeValidator ID="rvAmt" runat="server" ErrorMessage="Overdue input value!"
                                                    ForeColor="Red" ControlToValidate="txtPaidAmount" Type="Double" ValidationGroup="PaymentReceipt"
                                                    Display="Dynamic"></asp:RangeValidator>--%>
                                          <%--  </td>
                                        </tr>--%>
                                        <tr>
                                            <td>
                                                <asp:Label ID="litPaymentRefNo" runat="server" Text="Receipt No." CssClass="RequireFile"></asp:Label>
                                                <span class="erroraleart">
                                                    <asp:RequiredFieldValidator ID="rvftxtReceiptNo" SetFocusOnError="True" ControlToValidate="txtReceiptNo"
                                                        ValidationGroup="PaymentReceipt" runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                                </span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtReceiptNo" SkinID="CmpTextbox" runat="server" MaxLength="13"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblDate" runat="server" Text="Date" CssClass="RequireFile"></asp:Label>
                                                <span class="erroraleart">
                                                    <asp:RequiredFieldValidator ID="rfvDate" SetFocusOnError="True" ControlToValidate="txtDate"
                                                        ValidationGroup="PaymentReceipt" runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                                </span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDate" SkinID="CmpTextbox" runat="server" onkeydown="return stopKey(event);"></asp:TextBox>
                                                <asp:Image ID="imbDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png" />
                                                <ajx:CalendarExtender ID="calDate" runat="server" PopupButtonID="imbDate" TargetControlID="txtDate" CssClass="MyCalendar">
                                                </ajx:CalendarExtender>
                                                <img src="../../images/clear.png" id="imgClearDate" style="vertical-align: middle;"
                                                    onclick="fnClearDate('<%= txtDate.ClientID %>');" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top" style="width: 25%;">
                                                <asp:Label ID="litModeOfPayment" runat="server" Text="Mode Of Payment" CssClass="RequireFile"></asp:Label>
                                                <span class="erroraleart">
                                                    <asp:RequiredFieldValidator ID="rfvModeOfPayment" SetFocusOnError="True" ControlToValidate="ddlModeOfPayment"
                                                        ValidationGroup="PaymentReceipt" InitialValue="00000000-0000-0000-0000-000000000000"
                                                        runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                                </span>
                                            </td>
                                            <td align="left" valign="top" style="width: 75%;">
                                                <asp:DropDownList ID="ddlModeOfPayment" runat="server" Style="width: 203px;">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>                                       
                                        <tr>
                                            <td>
                                                <asp:Literal ID="litBankName" runat="server" Text="Bank Name"></asp:Literal>                                               
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtBankName" SkinID="CmpTextbox" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td>
                                                <asp:Literal ID="litChecqueNo" runat="server" Text="Cheque/DD No."></asp:Literal>                                               
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtChecqueNo" SkinID="CmpTextbox" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <%--<tr>
                                            <td align="left" valign="top" style="width: 25%;">
                                                <asp:Label ID="litModeOfPayment" runat="server" Text="Mode Of Payment" CssClass="RequireFile"></asp:Label>
                                                <span class="erroraleart">
                                                    <asp:RequiredFieldValidator ID="rfvModeOfPayment" SetFocusOnError="True" ControlToValidate="ddlModeOfPayment"
                                                        ValidationGroup="PaymentReceipt" InitialValue="00000000-0000-0000-0000-000000000000"
                                                        runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                                </span>
                                            </td>
                                            <td align="left" valign="top" style="width: 75%;">
                                                <asp:DropDownList ID="ddlModeOfPayment" runat="server" Style="width: 203px;" OnSelectedIndexChanged="ddlModeOfPayment_SelectedIndexChanged"
                                                    AutoPostBack="true">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal ID="litBankName" runat="server" Text="Bank Name"></asp:Literal>
                                                <span class="erroraleart">
                                                    <asp:RequiredFieldValidator ID="rvftxtBankName" runat="server" ControlToValidate="txtBankName"
                                                        CssClass="rfv_ErrorStar" ErrorMessage="*" ValidationGroup="PaymentReceipt"></asp:RequiredFieldValidator>
                                                </span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtBankName" SkinID="CmpTextbox" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal ID="litReceiptNo" runat="server" Text="Payment Ref. No"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtBankReceiptNo" SkinID="CmpTextbox" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>--%>
                                        <%--<tr>
                                            <td class="content_checkbox">
                                                <asp:CheckBox ID="chkIsReconciled" runat="server" Text="Reconciled On" AutoPostBack="true"
                                                    OnCheckedChanged="chkIsReconciled_CheckedChanged" />
                                            </td>
                                            <td>
                                                <div style="float:left;">
                                                <asp:TextBox ID="txtReconciledOn" SkinID="CmpTextbox" runat="server" onkeypress="return false;"></asp:TextBox>
                                                <ajx:CalendarExtender ID="caltxtReconciledOn" runat="server" Enabled="True" TargetControlID="txtReconciledOn"
                                                    PopupButtonID="imgRegiDate" CssClass="MyCalendar">
                                                </ajx:CalendarExtender>
                                                </div>
                                                <div style="padding-top:2px;float:left;">
                                                <asp:ImageButton ID="imgRegiDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                    Height="20px" Width="20px" style="border:0px;"/>
                                                    </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal ID="litDepostiToBank" runat="server" Text="Deposit To Bank"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDepostiToBank" SkinID="CmpTextbox" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>--%>
                                        <tr>
                                            <td>
                                                <asp:Literal ID="Literal6" runat="server" Text="Upload Receipt"></asp:Literal>
                                                <span class="erroraleart">
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="fuLicenseNo"
                                                        SetFocusOnError="true" CssClass="rfv_ErrorStar" ValidationGroup="PaymentReceipt"
                                                        Display="Dynamic" ErrorMessage="*" ValidationExpression="^.+(.pdf|.PDF|.doc|.jpg|.jpeg|.gif|.png|.bmp|.JPG|.JPEG|.GIF|.PNG|.BMP|.TIF|.tif|.DOC|.docx|.DOCX|xlsx|XLSX)$"></asp:RegularExpressionValidator>
                                                </span>
                                            </td>
                                            <td>
                                                <div style="display: inline;">
                                                    <div id='browse_file_grid' style="float: left;">
                                                        <asp:FileUpload ID="fuLicenseNo" runat="server" Height="25px" ToolTip=".pdf|.PDF|.doc|.jpg|.jpeg|.gif|.png|.bmp|.JPG|.JPEG|.GIF|.PNG|.BMP|.TIF|.tif|.DOC|.docx|.DOCX|xlsx|XLSX" /></div>
                                                        &nbsp;&nbsp;
                                                    <a id="aLicenseNo" runat="server" visible="false" target="_blank">
                                                        <asp:Image ID="Image6" runat="server" ImageUrl="~/images/View.png" /></a>
                                                        <asp:ImageButton ID="imgDelete" BorderStyle="None" runat="server" ImageUrl="~/images/DeleteFile.png"
                                                OnClick="imgDelete_OnClick" />
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top" colspan="2" style="text-align: right;">
                                                <div style="float: right; width: auto; height: 33px; display: inline-block;">
                                                    <asp:Button ID="btnNew" runat="server" Style="display: inline-block; margin-left: 5px;
                                                        display: inline;" Text="New" OnClick="btnNew_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                    <asp:Button ID="btnSave" Text="Save" Style="display: inline-block; margin-left: 5px;"
                                                        runat="server" ImageUrl="~/images/save.png" ValidationGroup="PaymentReceipt"
                                                        CausesValidation="true" OnClick="btnSave_Click" OnClientClick="return postbackButtonClick();" />
                                                    <%--<asp:Button ID="btnCancel" Text="Cancel" Style="display: inline-block; margin-left: 5px;"
                                                        runat="server" ImageUrl="~/images/cancle.png" CausesValidation="false" OnClick="btnCancel_Click"
                                                        OnClientClick="fnDisplayCatchErrorMessage()" />--%>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
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
                <td style="width: 2px;">
                    &#160;
                </td>
                <td>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                QUICK SEARCH
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
                                <div class="box_leftmargin_content">
                                    <div>
                                        <table id="tbl" cellpadding="2" cellspacing="0" width="100%" border="0" class="pageinfo">
                                            <tr>
                                                <td align="left" valign="middle" style="vertical-align: middle; margin-top: 7px;">
                                                    Investor Name
                                                </td>
                                                <td style="vertical-align: middle;">
                                                    <asp:TextBox ID="txtSInvestorName" runat="server" Style="width: 100px !important"></asp:TextBox>                                                        
                                                        <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                        OnClick="btnSearch_Click" Style="border: 0px; vertical-align: middle; margin-top: -4px;
                                                        margin-left: 5px;" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                </td>
                                            </tr>
                                            <%--<tr>
                                                <td align="left" valign="middle" style="vertical-align: middle; margin-top: 7px;">
                                                    Unit No
                                                </td>
                                                <td style="vertical-align: middle;">
                                                    <asp:TextBox ID="txtSUnitNumber" runat="server" Width="100" MaxLength="9" SkinID="Search"></asp:TextBox>
                                                    <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                        OnClick="btnSearch_Click" Style="border: 0px; vertical-align: middle; margin-top: -4px;
                                                        margin-left: 5px;" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                </td>
                                            </tr>--%>
                                        </table>
                                    </div>
                                    <div>
                                        <div style="height: 423px; overflow: auto;">
                                            <asp:GridView ID="grdInvRecptList" runat="server" ShowHeader="false" ShowFooter="false"
                                                SkinID="gvNoPaging" AutoGenerateColumns="false" Width="92%" OnRowCommand="grdInvRecptList_RowCommand"
                                                OnRowDataBound="grdInvRecptList_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <div class="rightmargin_grid">
                                                                <div class="leftmargin_contentarea" style="width: 137px;">
                                                                    <strong>
                                                                        <%#DataBinder.Eval(Container.DataItem, "InvestorName")%></strong><br />
                                                                    <%#DataBinder.Eval(Container.DataItem, "PropertyName")%><br />
                                                                    Receipt :
                                                                    <%#DataBinder.Eval(Container.DataItem, "ReceiptNo")%><br />
                                                                    <%--Unit No. :
                                                                    <%#DataBinder.Eval(Container.DataItem, "RoomNo")%><br />--%>
                                                                    <%#DataBinder.Eval(Container.DataItem, "PaidAmount")%><br />
                                                                    <%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "DateToPay")).ToString(this.DateFormat)%><br />
                                                                </div>
                                                                <div class="leftmargin_icons">
                                                                    <asp:ImageButton ID="btnEdit" runat="server" ToolTip="Edit" CommandName="EDITCMD"
                                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem, "InvestorPaymentReceiptID")%>'
                                                                        ImageUrl="~/images/edit.png" Style="border: 0px; vertical-align: middle; margin-top: 7px;
                                                                        margin-right: 7px;" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                                    <asp:ImageButton ID="btnDelete" ToolTip="Delete" CommandName="DELETECMD" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "InvestorPaymentReceiptID")%>'
                                                                        runat="server" ImageUrl="~/images/delete_icon.png" Style="border: 0px; vertical-align: middle;
                                                                        margin-top: 5px; margin-right: 7px;" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                                </div>
                                                                <div class="clear">
                                                                </div>
                                                            </div>
                                                            <div class="clear">
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EmptyDataTemplate>
                                                    <div class="pagecontent_info">
                                                        <div class="NoItemsFound" id="msgNoRecordFound" runat="server">
                                                            <h2>
                                                                <asp:Literal ID="Literal3" runat="server" Text="No Record Found"></asp:Literal></h2>
                                                        </div>
                                                    </div>
                                                </EmptyDataTemplate>
                                            </asp:GridView>
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
                </td>
            </tr>
        </table>
        <ajx:ModalPopupExtender ID="msgbx" runat="server" TargetControlID="hfMessage" PopupControlID="pnl"
            BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hfMessage" runat="server" />
        <asp:Panel ID="pnl" runat="server" Style="display: none;">
            <div style="width: 500px; height: 200px; margin-top: 25px;">
                <table border="0" cellspacing="0" cellpadding="0" class="modelpopup_box">
                    <tr>
                        <td class="modelpopup_boxtopleft">
                            &nbsp;
                        </td>
                        <td class="modelpopup_boxtopcenter">
                            &nbsp;
                        </td>
                        <td class="modelpopup_boxtopright">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="modelpopup_boxleft">
                            &nbsp;
                        </td>
                        <td class="modelpopup_box_bg">
                            <div style="width: 100px; float: left; margin-top: 10px;">
                                <asp:HyperLink ID="CloseModelPopup" runat="server">
                                    <asp:Image ImageUrl="~/images/error.png" AlternateText="" Height="75px" Width="75px"
                                        ID="btnImage" runat="server" />
                                </asp:HyperLink>
                            </div>
                            <div style="float: left; width: 225px; margin-top: 40px; margin-left: 10px;">
                                <asp:Label ID="lblErrorMessage" runat="server" Text="Sure you want to delete?"></asp:Label>
                            </div>
                            <table cellpadding="3" cellspacing="3" width="100%" style="margin-left: 5px; margin-top: 15px;">
                                <tr>
                                    <td align="center" valign="middle">
                                        <asp:Button ID="btnAddressSave" Text="Yes" runat="server" ImageUrl="~/images/save.png"
                                            OnClick="btnAddressSave_Click" Style="display: inline-block;" OnClientClick="fnDisplayCatchErrorMessage()" />
                                        <asp:Button ID="btnAddressCancel" Text="Cancel" runat="server" ImageUrl="~/images/cancle.png"
                                            OnClick="btnAddressCancel_Click" Style="display: inline-block;" OnClientClick="fnDisplayCatchErrorMessage()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="modelpopup_boxright">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="modelpopup_boxbottomleft">
                            &nbsp;
                        </td>
                        <td class="modelpopup_boxbottomcenter">
                        </td>
                        <td class="modelpopup_boxbottomright">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnSave" />
    </Triggers>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updIPR" ID="UpdateProgressIPR" runat="server">
    <ProgressTemplate>
        <div id="progressBackgroundFilter">
        </div>
        <div id="processMessage">
            <center>
                <img src="../../images/ajax-loader.gif" /></center>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
