<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlPropertyTax.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.InvestorSetUp.CtrlPropertyTax" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function pageLoad(sender, args) {

        $(document).ready(function () {
            $("#<%=txtSInvestorName.ClientID%>").autocomplete('InvestorAutoComplete.ashx');
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

    function fnCheckPaidAmount() {

        var PaidAmount = document.getElementById('<%=txtPaidAmount.ClientID %>').value;

        if (parseFloat(PaidAmount) > 0) {
            document.getElementById('<%=lblPaidAmountErrorMessage.ClientID %>').innerHTML = '';
        }
        else {
            document.getElementById('<%=lblPaidAmountErrorMessage.ClientID %>').innerHTML = 'Invalid Amount.';
        }
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
            updateProgress = $find("<%= UpdateProgressPropertyTax.ClientID %>");
            window.setTimeout("updateProgress.set_visible(true)", updateProgress.get_displayAfter());
            return true;
        }
        else {
            return false;
        }
    }
</script>
<asp:UpdatePanel ID="updtTaxReceipt" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td style="padding-left: 0px; width: 66.66%">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                PROPERTY TAX
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
                                <table width="100%" cellpadding="3" cellspacing="3">
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
                                                        <asp:Label ID="lblPropertyTaxReceipt" runat="server"></asp:Label></div>
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
                                        <td align="left" valign="top" style="width: 30%;">
                                            <asp:Label ID="litInvestor" runat="server" Text="Investor Name" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfInvestor" SetFocusOnError="True" ControlToValidate="ddlInvestor"
                                                    ValidationGroup="PaymentReceipt" InitialValue="00000000-0000-0000-0000-000000000000"
                                                    runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td align="left" valign="top" style="width: 70%;">
                                            <asp:DropDownList ID="ddlInvestor" runat="server" AutoPostBack="true" Style="width: 202px;"
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
                                            <asp:DropDownList ID="ddlPropertyName" runat="server" AutoPostBack="true" Style="width: 203px;"
                                                OnSelectedIndexChanged="ddlPropertyName_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top">
                                            <asp:Label ID="litRoomName" runat="server" Text="Unit No" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rfvRoomName" SetFocusOnError="True" ControlToValidate="ddlRoomName"
                                                    ValidationGroup="PaymentReceipt" InitialValue="00000000-0000-0000-0000-000000000000"
                                                    runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td align="left" valign="top">
                                            <asp:DropDownList ID="ddlRoomName" runat="server" AutoPostBack="true" Style="width: 202px;"
                                                OnSelectedIndexChanged="ddlRoomName_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litPaidAmount" runat="server" Text="Amount" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rfvPaidAmount" SetFocusOnError="True" ControlToValidate="txtPaidAmount"
                                                    ValidationGroup="PaymentReceipt" runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPaidAmount" SkinID="CmpTextbox" runat="server" MaxLength="10"
                                                onkeyup="fnCheckPaidAmount();"></asp:TextBox>
                                            <ajx:FilteredTextBoxExtender ID="ftbetxtPaidAmount" runat="server" TargetControlID="txtPaidAmount"
                                                FilterType="Custom, numbers" ValidChars="." Enabled="True" />
                                        </td>
                                    </tr>
                                    <tr style="padding:0px;">
                                        <td>
                                        </td>
                                        <td style="color: Red; padding:0px;">
                                            <asp:Label ID="lblPaidAmountErrorMessage" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" style="width: 25%;">
                                            <asp:Label ID="litPaymentScheduleID" runat="server" Text="Period From" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rfvPaymentSchedule" SetFocusOnError="True" ControlToValidate="ddlDate"
                                                    ValidationGroup="PaymentReceipt" runat="server" InitialValue="00000000-0000-0000-0000-000000000000"
                                                    ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td align="left" valign="top" style="width: 75%;">
                                            <asp:DropDownList ID="ddlDate" runat="server" Style="width: 65px;">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rvfMonth" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                Display="Dynamic" ControlToValidate="ddlMonth" ValidationGroup="PaymentReceipt"
                                                runat="server" ErrorMessage="*" InitialValue="00000000-0000-0000-0000-000000000000"></asp:RequiredFieldValidator>
                                            <asp:DropDownList ID="ddlMonth" runat="server" Style="width: 70px;">
                                                <asp:ListItem Text="-Month-" Value="00000000-0000-0000-0000-000000000000" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="Jan" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Feb" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="Mar" Value="3"></asp:ListItem>
                                                <asp:ListItem Text="Apr" Value="4"></asp:ListItem>
                                                <asp:ListItem Text="May" Value="5"></asp:ListItem>
                                                <asp:ListItem Text="Jun" Value="6"></asp:ListItem>
                                                <asp:ListItem Text="Jul" Value="7"></asp:ListItem>
                                                <asp:ListItem Text="Aug" Value="8"></asp:ListItem>
                                                <asp:ListItem Text="Sep" Value="9"></asp:ListItem>
                                                <asp:ListItem Text="Oct" Value="10"></asp:ListItem>
                                                <asp:ListItem Text="Nov" Value="11"></asp:ListItem>
                                                <asp:ListItem Text="Dec" Value="12"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rvfYear" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                Display="Dynamic" ControlToValidate="ddlYear" ValidationGroup="PaymentReceipt"
                                                runat="server" ErrorMessage="*" InitialValue="00000000-0000-0000-0000-000000000000"></asp:RequiredFieldValidator>
                                            <asp:DropDownList ID="ddlYear" runat="server" Style="width: 60px;">
                                            </asp:DropDownList>
                                            <div id="FromValidDate" runat="server" class="rfv_ErrorStar" visible="false" style="float: right;">
                                                <asp:Label ID="litFromValidDate" runat="server"></asp:Label></div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" style="width: 25%;">
                                            <asp:Label ID="lblTo" runat="server" Text="Period To" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfToDate" SetFocusOnError="True" ControlToValidate="ddlToDate"
                                                    ValidationGroup="PaymentReceipt" runat="server" InitialValue="00000000-0000-0000-0000-000000000000"
                                                    ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td align="left" valign="top" style="width: 75%;">
                                            <asp:DropDownList ID="ddlToDate" runat="server" Style="width: 65px;">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rvfToMonth" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                Display="Dynamic" ControlToValidate="ddlToMonth" ValidationGroup="PaymentReceipt"
                                                runat="server" ErrorMessage="*" InitialValue="00000000-0000-0000-0000-000000000000"></asp:RequiredFieldValidator>
                                            <asp:DropDownList ID="ddlToMonth" runat="server" Style="width: 70px;">
                                                <asp:ListItem Text="-Month-" Value="00000000-0000-0000-0000-000000000000" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="Jan" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Feb" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="Mar" Value="3"></asp:ListItem>
                                                <asp:ListItem Text="Apr" Value="4"></asp:ListItem>
                                                <asp:ListItem Text="May" Value="5"></asp:ListItem>
                                                <asp:ListItem Text="Jun" Value="6"></asp:ListItem>
                                                <asp:ListItem Text="Jul" Value="7"></asp:ListItem>
                                                <asp:ListItem Text="Aug" Value="8"></asp:ListItem>
                                                <asp:ListItem Text="Sep" Value="9"></asp:ListItem>
                                                <asp:ListItem Text="Oct" Value="10"></asp:ListItem>
                                                <asp:ListItem Text="Nov" Value="11"></asp:ListItem>
                                                <asp:ListItem Text="Dec" Value="12"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rvfToYear" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                Display="Dynamic" ControlToValidate="ddlYear" ValidationGroup="PaymentReceipt"
                                                runat="server" ErrorMessage="*" InitialValue="00000000-0000-0000-0000-000000000000"></asp:RequiredFieldValidator>
                                            <asp:DropDownList ID="ddlToYear" runat="server" Style="width: 60px;">
                                            </asp:DropDownList>
                                            <div id="ToValidDate" runat="server" class="rfv_ErrorStar" visible="false" style="float: right;">
                                                <asp:Label ID="litToValidDate" runat="server"></asp:Label></div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="litPaymentRefNo" runat="server" Text="Receipt No"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPaymentRefNo" SkinID="CmpTextbox" runat="server" MaxLength="50"></asp:TextBox>
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
                                            <asp:DropDownList ID="ddlModeOfPayment" runat="server" Style="width: 202px;">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <%--<tr>
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
                                    </tr>--%>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="litReceiptNo" runat="server" Text="Cheque/DD No."></asp:Literal>
                                            <span class="erroraleart">
                                                <%--<asp:RequiredFieldValidator ID="rvftxtChqTranNo" runat="server" ControlToValidate="txtChqTranNo"
                                                    CssClass="rfv_ErrorStar" ErrorMessage="*" ValidationGroup="PaymentReceipt"></asp:RequiredFieldValidator>--%>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtChqTranNo" SkinID="CmpTextbox" runat="server" MaxLength="250"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <%-- <tr>
                                        <td>
                                            <asp:Literal ID="litDepostiToBank" runat="server" Text="Deposit To Bank"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDepostiToBank" SkinID="CmpTextbox" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="Literal1" runat="server" Text="Notes"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNotes" runat="server" TextMode="MultiLine" Height="60px" SkinID="Medium"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="Literal6" runat="server" Text="Upload Receipt"></asp:Literal>
                                            <span class="erroraleart">
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="fuLicenseNo"
                                                    SetFocusOnError="true" CssClass="rfv_ErrorStar" ValidationGroup="PaymentReceipt"
                                                    Display="Dynamic" ErrorMessage="*" ValidationExpression="^.+(.pdf|.jpg|.jpeg|.gif|.png|.bmp|.JPG|.JPEG|.GIF|.PNG|.BMP|.TIF|.tif|.PDF|.doc|.DOC|.docx|.DOCX|xlsx|XLSX)$"></asp:RegularExpressionValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <div id='browse_file_grid' style="float: left;">
                                                <asp:FileUpload ID="fuLicenseNo" runat="server" Height="25px" ToolTip=".pdf|.jpg|.jpeg|.gif|.png|.bmp|.JPG|.JPEG|.GIF|.PNG|.BMP|.TIF|.tif|.PDF|.doc|.DOC|.docx|.DOCX|xlsx|XLSX" /></div>
                                            &nbsp;&nbsp;
                                            <a id="aLicenseNo" runat="server" visible="false" target="_blank">
                                                <asp:Image ID="Image6" runat="server" ImageUrl="~/images/View.png" /></a>
                                            <asp:ImageButton ID="imgDelete" BorderStyle="None" runat="server" ImageUrl="~/images/DeleteFile.png" OnClick="imgDelete_OnClick" />
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
                                                    <asp:TextBox ID="txtSInvestorName" runat="server" Width="100" SkinID="Search"></asp:TextBox>
                                                    <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                        Style="border: 0px; vertical-align: middle; margin-top: -3px; margin-left: 5px;"
                                                        OnClick="btnSearch_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Period From
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtDateFrom" runat="server" Style="width: 80px !important;" onkeydown="return stopKey(event);"></asp:TextBox>
                                                    <asp:Image ID="imbDateFrom" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png" />
                                                    <ajx:CalendarExtender ID="calDateFrom" runat="server" PopupButtonID="imbDateFrom" CssClass="MyCalendar"
                                                        TargetControlID="txtDateFrom">
                                                    </ajx:CalendarExtender>
                                                    <img src="../../images/clear.png" id="imgClearDateFrom" style="vertical-align: middle;"
                                                        onclick="fnClearDate('<%= txtDateFrom.ClientID %>');" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Period To
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtDateTo" runat="server" Style="width: 80px !important;" onkeydown="return stopKey(event);"></asp:TextBox>
                                                    <asp:Image ID="imbDateTo" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png" />
                                                    <ajx:CalendarExtender ID="calExtDateTo" runat="server" PopupButtonID="imbDateTo"
                                                        TargetControlID="txtDateTo" CssClass="MyCalendar">
                                                    </ajx:CalendarExtender>
                                                    <img src="../../images/clear.png" id="imgClearDateTo" style="vertical-align: middle;"
                                                        onclick="fnClearDate('<%= txtDateTo.ClientID %>');" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div>
                                        <div style="height: 415px; overflow: auto;">
                                            <asp:GridView ID="grdInvRecptList" runat="server" ShowHeader="false" ShowFooter="false"
                                                SkinID="gvNoPaging" AutoGenerateColumns="false" Width="92%" OnRowCommand="grdInvRecptList_RowCommand"
                                                OnRowDataBound="grdInvRecptList_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <div class="rightmargin_grid">
                                                                <div class="leftmargin_contentarea" style="width: 137px !important;">
                                                                    <strong>
                                                                        <%#DataBinder.Eval(Container.DataItem, "InvestorName")%></strong><br />
                                                                    <%#DataBinder.Eval(Container.DataItem, "PropertyName")%><br />
                                                                    <%#DataBinder.Eval(Container.DataItem, "RoomNo")%><br />
                                                                    <%#DataBinder.Eval(Container.DataItem, "PaidAmount")%><br />
                                                                    From :
                                                                    <asp:Label ID="lblPDDueDate" runat="server" Width="75px" Text='<%# DataBinder.Eval(Container.DataItem, "FromDate") != DBNull.Value ? Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "FromDate")).ToString(DateFormat) : ""%>'></asp:Label>
                                                                    <br />
                                                                    To :
                                                                    <asp:Label ID="Label1" runat="server" Width="75px" Text='<%# DataBinder.Eval(Container.DataItem, "ToDate") != DBNull.Value ? Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "ToDate")).ToString(DateFormat) : ""%>'></asp:Label><br />
                                                                    <%#DataBinder.Eval(Container.DataItem, "PayRefNo")%><br />
                                                                    <%#DataBinder.Eval(Container.DataItem, "YearToPay")%>
                                                                </div>
                                                                <div class="leftmargin_icons">
                                                                    <asp:ImageButton ID="btnEdit" runat="server" ToolTip="Edit" CommandName="EDITCMD"
                                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem, "InvestorPaymentReceiptID")%>'
                                                                        ImageUrl="~/images/edit.png" Style="border: 0px; vertical-align: middle; margin-top: 7px;
                                                                        margin-right: 7px;" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                                    <asp:ImageButton ID="btnDelete" ToolTip="Delete" CommandName="DELETECMD" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "InvestorPaymentReceiptID")%>'
                                                                        runat="server" ImageUrl="~/images/delete_icon.png" Style="border: 0px; vertical-align: middle;
                                                                        margin-top: 7px; margin-right: 7px;" OnClientClick="fnDisplayCatchErrorMessage()" />
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
                                        <asp:Button ID="btnPopOk" Text="Yes" runat="server" ImageUrl="~/images/save.png"
                                            OnClick="btnPopOk_Click" Style="display: inline-block;" OnClientClick="fnDisplayCatchErrorMessage()" />
                                        <asp:Button ID="btnPopCancel" Text="Cancel" runat="server" ImageUrl="~/images/cancle.png"
                                            OnClick="btnPopCancel_Click" Style="display: inline-block;" OnClientClick="fnDisplayCatchErrorMessage()" />
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
<asp:UpdateProgress AssociatedUpdatePanelID="updtTaxReceipt" ID="UpdateProgressPropertyTax"
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
