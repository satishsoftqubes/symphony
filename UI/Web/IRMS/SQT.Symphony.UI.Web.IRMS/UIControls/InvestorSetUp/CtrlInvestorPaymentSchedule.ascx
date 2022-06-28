<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlInvestorPaymentSchedule.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.InvestorSetUp.CtrlInvestorPaymentSchedule" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">
    function pageLoad(sender, args) {
        $(document).ready(function () {
            $("#<%=txtSUnitNumber.ClientID%>").autocomplete('../SetUp/UnitAutoComplete.ashx');
        });
    }

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

    function fnCountTotal(blurFrom) {
        if (Page_ClientValidate("InvestorPayment")) {
            document.getElementById('errormessage').style.display = "block";
            var isValid = false;
            var gridView = document.getElementById("<%= gvPaymentSchedules.ClientID %>");
            var totalPurchaseValue = parseFloat(document.getElementById('ContentPlaceHolder1_CtrlInvestorPaymentSchedule1_txtTotalScheduledValue').value);
            var totalGridCount = 0;
            var totalPercentage = 0;
            var isAmountZero = 0;
            var isMilestoneTitleEmpty = 0;

            for (var i = 1; i < gridView.rows.length - 1; i++) {
                var inputs = gridView.rows[i].getElementsByTagName('input');
                if (inputs != null) {

                    //inputs[0] will be Milestone Title
                    if (inputs[0].value == "") {
                        isMilestoneTitleEmpty = 1;
                    }

                    //inputs[1] will be Due(%)
                    if (inputs[1].value != "") {

                        if (blurFrom == 'AMOUNT') {
                            var newAmount = parseFloat(inputs[2].value);

                            if (newAmount > 0) {
                                var newPrcnt = 0;

                                newpr = (newAmount * 100) / totalPurchaseValue;
                                inputs[1].value = parseFloat(newpr).toFixed(2);
                            }
                            else {
                                inputs[1].value = 0;
                                inputs[2].value = 0;
                                isAmountZero = 1;
                            }
                        }

                        if (parseFloat(inputs[1].value) > 0) {
                            totalPercentage = totalPercentage + parseFloat(inputs[1].value);
                        }
                    }

                    //inputs[2] will be PayableAmount
                    if (inputs[2].value != "") {

                        if (blurFrom == 'PERCENTAGE') {
                            var prcntValue = parseFloat(inputs[1].value);

                            if (prcntValue > 0) {
                                var newAmount = 0;
                                newAmount = (totalPurchaseValue * prcntValue) / 100;
                                inputs[2].value = parseFloat(newAmount).toFixed(2);
                            }
                            else {
                                inputs[1].value = 0;
                                inputs[2].value = 0;
                                isAmountZero = 1;
                            }
                        }

                        if (parseFloat(inputs[2].value) > 0) {
                            totalGridCount = totalGridCount + parseFloat(inputs[2].value);
                        }

                        if (blurFrom == 'SAVE') {
                            var newAmount = parseFloat(inputs[2].value);

                            if (!(newAmount > 0)) {
                                isAmountZero = 1;
                            }
                        }
                    }

                }
            }

            document.getElementById('ContentPlaceHolder1_CtrlInvestorPaymentSchedule1_gvPaymentSchedules_lblTotalAmount').innerHTML = parseFloat(totalGridCount).toFixed(2);
            document.getElementById('ContentPlaceHolder1_CtrlInvestorPaymentSchedule1_gvPaymentSchedules_lblTotalPercentage').innerHTML = parseFloat(totalPercentage).toFixed(2);

            if (blurFrom == 'SAVE') {
                if (isMilestoneTitleEmpty == 1) {
                    //alert('Milestone title should not be empty.');
                    document.getElementById('<%= lblAlertMessage.ClientID  %>').innerHTML = 'Milestone title should not be empty.';
                    $find('mpeAlertMessage').show();
                    return false;
                }

                if (isAmountZero == 1) {
                    //alert('Amount Payable should be greater than 0.');
                    document.getElementById('<%= lblAlertMessage.ClientID  %>').innerHTML = 'Amount Payable should be greater than 0.';
                    $find('mpeAlertMessage').show();
                    return false;
                }

                if (totalGridCount > totalPurchaseValue) {
                    //alert('Overdue payable amount.');
                    document.getElementById('<%= lblAlertMessage.ClientID  %>').innerHTML = 'Schedule amount can not exceed total purchase value.';
                    $find('mpeAlertMessage').show();
                    return false;
                }
                else if (totalGridCount < totalPurchaseValue) {
                    //alert('Overdue payable amount.');
                    document.getElementById('<%= lblAlertMessage.ClientID  %>').innerHTML = 'Please insure Payment schedule is 100%.';
                    $find('mpeAlertMessage').show();
                    return false;
                }
                else {
                    return true;
                }
            }
        }
        else {
            return false;
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
<%--function fnClearDate(indexNo) {
        var txtName = 'ContentPlaceHolder1_CtrlInvestorPaymentSchedule1_gvPaymentSchedules_txtDueDate_' + indexNo;
        document.getElementById(txtName).value = '';
    }--%>
<asp:UpdatePanel ID="updIPS" runat="server">
    <ContentTemplate>
        <asp:HiddenField ID="hdnTotalAmt" runat="server" Value="" />
        <asp:HiddenField ID="hdnPaymentSlab" runat="server" Value="" />
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="content" style="padding-left: 0px; width: 66.66%">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                PAYMENT SCHEDULE SETUP
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
                                <table width="100%" cellpadding="3" cellspacing="3" border="0">
                                    <tr>
                                        <td colspan="2">
                                            <div style="height: 26px;">
                                                <%if (IsMessage)
                                                  { %>
                                                <div class="ResetSuccessfully">
                                                    <div style="float: left; padding-top: 7px; width: 25px; height: 24px; margin-right: 10px;">
                                                        <img src="../../images/success.png" /></div>
                                                    <div>
                                                        <asp:Label ID="lblErrorMessage" runat="server"></asp:Label></div>
                                                    <div style="height: 10px;">
                                                    </div>
                                                </div>
                                                <%}%>
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
                                        <td align="left" valign="top" width="165px">
                                            <asp:Label ID="litInvestor" runat="server" Text="Investor Name" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfddlInvestor" runat="server" ControlToValidate="ddlInvestor"
                                                    SetFocusOnError="true" CssClass="rfv_ErrorStar" InitialValue="00000000-0000-0000-0000-000000000000"
                                                    ErrorMessage="*" ValidationGroup="InvestorPayment"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td align="left" style="padding-left: 5px;" valign="top">
                                            <asp:DropDownList ID="ddlInvestor" runat="server" Enabled="false">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top">
                                            <asp:Label ID="lblProperty" runat="server" Text="Property Name" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfProperty" runat="server" ControlToValidate="ddlProperty"
                                                    SetFocusOnError="true" CssClass="rfv_ErrorStar" InitialValue="00000000-0000-0000-0000-000000000000"
                                                    ErrorMessage="*" ValidationGroup="InvestorPayment"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td align="left" style="padding-left: 5px;" valign="top">
                                            <asp:DropDownList ID="ddlProperty" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProperty_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top">
                                            <asp:Label ID="litPaymentScheduleID" runat="server" Text="Unit No" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfddlInvestorRoom" runat="server" ControlToValidate="ddlInvestorRoom"
                                                    SetFocusOnError="true" CssClass="rfv_ErrorStar" InitialValue="00000000-0000-0000-0000-000000000000"
                                                    ErrorMessage="*" ValidationGroup="InvestorPayment"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td align="left" style="padding-left: 5px;" valign="top">
                                            <asp:DropDownList ID="ddlInvestorRoom" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlInvestorRoom_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <%--<asp:Label ID="lblRemainingAmount" runat="server" Text="0.00"></asp:Label>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top">
                                            Unit Price
                                        </td>
                                        <td align="left" style="padding-left: 5px;" valign="top">
                                            <asp:TextBox ID="txtUnitPrice" runat="server" Text="0.00" Enabled="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top">
                                            Total Purchase Value
                                            <br />
                                            <span style="font-size: 11px;">(Unit price + Taxes + Other Cost)</span>
                                        </td>
                                        <td align="left" style="padding-left: 5px;" valign="top">
                                            <asp:TextBox ID="lblTotalPurchaseValue" runat="server" Text="0.00" Enabled="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <%--**************  IMPORTANT *************--%>
                                    <%--txtTotalScheduledValue is used in Counting, so not to remove but not to display it.--%>
                                    <%--**************  IMPORTANT *************--%>
                                    <tr style="display: none;">
                                        <td align="left" valign="top">
                                            Total Scheduled Value
                                        </td>
                                        <td align="left" style="padding-left: 5px;" valign="top">
                                            <asp:TextBox ID="txtTotalScheduledValue" runat="server" Text="0.00" Enabled="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Payment Schedule
                                        </td>
                                        <td style="padding: 3px 0px 0px 0px;">
                                            <asp:RadioButtonList ID="rdblstScheduleType" runat="server" CellPadding="0" CellSpacing="0"
                                                Enabled="false" AutoPostBack="true" RepeatColumns="1" RepeatDirection="Vertical"
                                                OnSelectedIndexChanged="rdblstScheduleType_OnSelectedIndexChanged">
                                                <asp:ListItem Text="Full Payment" Value="FULL"></asp:ListItem>
                                                <asp:ListItem Text="Standard Installment" Value="STANDARD"></asp:ListItem>
                                                <asp:ListItem Text="Custom Installment" Value="CUSTOM"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
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
                    <div class="clear">
                        <%--<uc1:MsgBox ID="MessageBox" runat="server" />--%>
                    </div>
                </td>
                <td style="width: 2px;">
                    &#160;
                </td>
                <td class="content">
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
                                                    Property Name
                                                </td>
                                                <td style="vertical-align: middle;">
                                                    <asp:DropDownList ID="ddlSPropertyName" runat="server" SkinID="Search">
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="right" valign="middle">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="middle" style="vertical-align: middle; margin-top: 7px;">
                                                    Unit Number
                                                </td>
                                                <td style="vertical-align: middle;">
                                                    <asp:TextBox ID="txtSUnitNumber" runat="server" Width="100" MaxLength="9" SkinID="Search"></asp:TextBox>
                                                </td>
                                                <td align="right" valign="middle">
                                                    <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                        Style="border: 0px; vertical-align: middle; margin-top: 3px; margin-right: 7px;"
                                                        OnClick="btnSearch_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="leftmarginbox_content">
                                        <div style="height: 231px; overflow: auto;">
                                            <asp:GridView ID="gvInvestorUnits" runat="server" ShowHeader="false" ShowFooter="false"
                                                SkinID="gvNoPaging" AutoGenerateColumns="false" Width="92%" OnRowCommand="gvInvestorUnits_RowCommand"
                                                OnRowDataBound="gvInvestorUnits_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <div class="rightmargin_grid">
                                                                <div class="leftmargin_contentarea" style="width: 137px;">
                                                                    <%--<strong>
                                                                        <%#DataBinder.Eval(Container.DataItem, "InvestorName")%></strong><br />--%>
                                                                    <strong>Unit No. :-
                                                                        <%#DataBinder.Eval(Container.DataItem, "RoomNo")%></strong><br />
                                                                    <%#DataBinder.Eval(Container.DataItem, "PropertyName")%><br />
                                                                    Total Price:
                                                                    <%#DataBinder.Eval(Container.DataItem, "TotalPrice")%><br />
                                                                </div>
                                                                <div class="leftmargin_icons">
                                                                    <asp:ImageButton ID="btnEdit" runat="server" ToolTip="Edit" ImageUrl="~/images/edit.png"
                                                                        Style="border: 0px; vertical-align: middle; margin-top: 7px; margin-right: 7px;"
                                                                        CommandName="EditData" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "InvestorRoomID")%>'
                                                                        OnClientClick="fnDisplayCatchErrorMessage();" />
                                                                    <asp:ImageButton ID="btnDelete" runat="server" ToolTip="Delete" ImageUrl="~/images/delete_icon.png"
                                                                        Style="border: 0px; vertical-align: middle; margin-top: 7px; margin-right: 7px;"
                                                                        CommandName="DeleteData" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "InvestorRoomID")%>'
                                                                        OnClientClick="fnDisplayCatchErrorMessage();" />
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
                                                        <div class="NoItemsFound">
                                                            <h2>
                                                                <asp:Literal ID="Literal3" runat="server" Text="No Record Found"></asp:Literal></h2>
                                                        </div>
                                                    </div>
                                                </EmptyDataTemplate>
                                            </asp:GridView>
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
            <tr>
                <td class="content" colspan="3">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                PAYMENT SCHEDULE&nbsp;&nbsp;&nbsp;<asp:Literal ID="litScheduleType" runat="server"></asp:Literal>
                            </td>
                            <td class="boxtopright">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="boxleft">
                                &nbsp;
                            </td>
                            <td class="boxcenter">
                                <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td style="padding: 10px 0px;" class="dTableBox">
                                            <asp:GridView ID="gvPaymentSchedules" runat="server" SkinID="gvNoPaging" AutoGenerateColumns="False"
                                                DataKeyNames="PaymentScheduleID" ShowFooter="true" Width="100%" OnRowCommand="gvPaymentSchedules_RowCommand"
                                                OnRowDataBound="gvPaymentSchedules_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="MileStone Title" ItemStyle-Width="140px" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <%--<asp:RequiredFieldValidator ID="rfvMileStoneTitle" runat="server" ControlToValidate="txtMileStoneTitle"
                                                                SetFocusOnError="true" CssClass="rfv_ErrorStar" ErrorMessage="*" ValidationGroup="InvestorPayment"></asp:RequiredFieldValidator>--%>
                                                            <asp:TextBox ID="txtMileStoneTitle" runat="server" SkinID="nowidth" Width="140px"
                                                                onblur="fnCountTotal('TITLE');" Text='<%# DataBinder.Eval(Container.DataItem, "ProjectMileStone") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <b>Total :</b>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="% Due" FooterStyle-HorizontalAlign="Right" ItemStyle-Width="30px"
                                                        HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtDue" runat="server" Style="text-align: right;" SkinID="nowidth"
                                                                Width="50px" MaxLength="5" onblur="fnCountTotal('PERCENTAGE');" Text='<%# DataBinder.Eval(Container.DataItem, "Due") %>'></asp:TextBox>
                                                            <ajx:FilteredTextBoxExtender ID="ftbDue" runat="server" TargetControlID="txtDue"
                                                                FilterMode="ValidChars" ValidChars="0123456789.">
                                                            </ajx:FilteredTextBoxExtender>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <b>
                                                                <asp:Label ID="lblTotalPercentage" runat="server"></asp:Label></b>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Amount Payable" FooterStyle-HorizontalAlign="Right"
                                                        ItemStyle-Width="90px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtAmountPayable" Style="text-align: right;" runat="server" SkinID="Search"
                                                                Width="70px" MaxLength="18" onblur="fnCountTotal('AMOUNT');" Text='<%# DataBinder.Eval(Container.DataItem, "AmountPayable") %>'></asp:TextBox>
                                                            <ajx:FilteredTextBoxExtender ID="ftbAmountPayable" runat="server" TargetControlID="txtAmountPayable"
                                                                FilterMode="ValidChars" ValidChars="0123456789.">
                                                            </ajx:FilteredTextBoxExtender>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <b>
                                                                <asp:Label ID="lblTotalAmount" runat="server"></asp:Label></b>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Due Date" ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left">
                                                        <HeaderTemplate>
                                                            <asp:Literal ID="litGvDueDate" runat="server" Text="Due Date"></asp:Literal>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="hdScheduleType" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ScheduleType") %>' />
                                                            <asp:TextBox ID="txtDueDate" Width="70px" runat="server" SkinID="Search" onkeydown="return stopKey(event);"></asp:TextBox>
                                                            <asp:Image ID="imgtxtDueDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                                Height="20px" Width="20px" />
                                                            <ajx:CalendarExtender ID="calDueDate" runat="server" TargetControlID="txtDueDate"
                                                                CssClass="MyCalendar" PopupButtonID="imgtxtDueDate">
                                                            </ajx:CalendarExtender>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete" ItemStyle-Width="20px" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnDelete" ToolTip="Delete" CommandName="DELETECMD" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "PaymentScheduleID")%>'
                                                                runat="server" ImageUrl="~/images/delete_icon.png" Style="border: 0px; vertical-align: middle;
                                                                margin-top: 2px; margin-right: 7px;" OnClientClick="fnDisplayCatchErrorMessage()" />
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
                                            <span id="spnMessage" runat="server" visible="false" style="font-size: 11px;">** Amount
                                                payable against installment includes VAT and Service Tax</span>
                                        </td>
                                    </tr>
                                    <tr id="trTitleOtherTaxes" runat="server" visible="false">
                                        <td style="padding-top: 3px; padding-bottom: 2px;">
                                            <b>Other Costs</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dTableBox">
                                            <asp:GridView ID="gvOtherCost" runat="server" SkinID="gvNoPaging" AutoGenerateColumns="False"
                                                DataKeyNames="PaymentScheduleID" ShowFooter="true" Width="100%" ShowHeader="false"
                                                OnRowDataBound="gvOtherCost_RowDataBound" Visible="false">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="MileStone Title" ItemStyle-Width="140px" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtMileStoneTitle" runat="server" SkinID="nowidth" Width="140px"
                                                                Text='<%# DataBinder.Eval(Container.DataItem, "ProjectMileStone") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <b>Total :</b>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="% Due" FooterStyle-HorizontalAlign="Right" ItemStyle-Width="30px"
                                                        HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtDue" runat="server" Style="text-align: right;" SkinID="nowidth"
                                                                Width="50px" MaxLength="5" Text='<%# DataBinder.Eval(Container.DataItem, "Due") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                        <%--<FooterTemplate>
                                                            <b>
                                                                <asp:Label ID="lblTotalPercentage" runat="server"></asp:Label></b>
                                                        </FooterTemplate>--%>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Amount Payable" FooterStyle-HorizontalAlign="Right"
                                                        ItemStyle-Width="90px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtAmountPayable" Style="text-align: right;" runat="server" SkinID="Search"
                                                                Width="70px" MaxLength="18" Text='<%# DataBinder.Eval(Container.DataItem, "AmountPayable") %>'></asp:TextBox>
                                                            <ajx:FilteredTextBoxExtender ID="ftbAmountPayable" runat="server" TargetControlID="txtAmountPayable"
                                                                FilterMode="ValidChars" ValidChars="0123456789.">
                                                            </ajx:FilteredTextBoxExtender>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <b>
                                                                <asp:Label ID="lblTotalAmount" runat="server"></asp:Label></b>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Due Date" ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="hdScheduleType" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ScheduleType") %>' />
                                                            <asp:TextBox ID="txtDueDate" Width="70px" runat="server" SkinID="Search" onkeydown="return stopKey(event);"></asp:TextBox>
                                                            <ajx:CalendarExtender ID="calDueDate" runat="server" TargetControlID="txtDueDate">
                                                            </ajx:CalendarExtender>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete" ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <%--<asp:ImageButton ID="btnDelete" ToolTip="Delete" CommandName="DELETECMD" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "PaymentScheduleID")%>'
                                                                runat="server" ImageUrl="~/images/delete_icon.png" Style="border: 0px; vertical-align: middle;
                                                                margin-top: 2px; margin-right: 7px;" OnClientClick="fnDisplayCatchErrorMessage()" />--%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EmptyDataTemplate>
                                                    <div class="pagecontent_info">
                                                        <div class="NoItemsFound">
                                                            <h2>
                                                                <asp:Literal ID="litNoRecordFound" runat="server" Text="No Record Found"></asp:Literal></h2>
                                                        </div>
                                                    </div>
                                                </EmptyDataTemplate>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" style="text-align: right;">
                                            <div style="float: left; display: inline; height: 30px;">
                                                <asp:Button ID="btnLoadStdSchedule" runat="server" Text="Load STD. Schedule" OnClick="btnLoadStdSchedule_Click" />
                                            </div>
                                            <div style="float: right; width: auto; display: inline-block; height: 30px;">
                                                <asp:Button ID="btnNew" runat="server" Style="display: inline-block; margin-left: 5px;
                                                    display: inline;" Text="New" OnClick="btnNew_Click" OnClientClick="fnDisplayCatchErrorMessage();" />
                                                <asp:Button ID="btnSave" Text="Save" Style="display: inline-block; margin-left: 5px;"
                                                    runat="server" ImageUrl="~/images/save.png" ValidationGroup="InvestorPayment"
                                                    CausesValidation="true" OnClick="btnSave_Click" OnClientClick="return fnCountTotal('SAVE');" />
                                                <asp:Button ID="btnCancel" Text="Cancel" Style="display: inline-block; margin-left: 5px;"
                                                    runat="server" ImageUrl="~/images/cancle.png" CausesValidation="false" OnClick="btnCancel_Click"
                                                    OnClientClick="fnDisplayCatchErrorMessage();" />
                                                <asp:Button ID="btnAddNewRow" Text="Add New Row" Style="display: inline-block; margin-left: 5px;"
                                                    runat="server" Visible="false" ImageUrl="~/images/cancle.png" OnClick="btnAddNewRow_Click"
                                                    ValidationGroup="InvestorPayment" CausesValidation="true" />
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
                </td>
            </tr>
        </table>
        <ajx:ModalPopupExtender ID="msgbx" runat="server" TargetControlID="hfMessage" PopupControlID="Panel1"
            BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hfMessage" runat="server" />
        <asp:Panel ID="Panel1" runat="server" Style="display: none;">
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
                                <asp:HyperLink ID="HyperLink1" runat="server">
                                    <asp:Image ImageUrl="~/images/error.png" AlternateText="" Height="75px" Width="75px"
                                        ID="Image1" runat="server" />
                                </asp:HyperLink>
                            </div>
                            <div style="float: left; width: 225px; margin-top: 40px; margin-left: 10px;">
                                <asp:Label ID="Label1" runat="server" Text="Sure you want to delete?"></asp:Label>
                            </div>
                            <table cellpadding="3" cellspacing="3" width="100%" style="margin-left: 5px; margin-top: 15px;">
                                <tr>
                                    <td align="center" valign="middle">
                                        <asp:Button ID="btnPaymentScheduleYes" Text="Yes" runat="server" ImageUrl="~/images/save.png"
                                            OnClick="btnPaymentScheduleYes_Click" Style="display: inline-block;" OnClientClick="fnDisplayCatchErrorMessage()" />
                                        <asp:Button ID="btnPaymentScheduleNo" Text="Cancel" runat="server" ImageUrl="~/images/cancle.png"
                                            OnClick="btnPaymentScheduleNo_Click" Style="display: inline-block;" OnClientClick="fnDisplayCatchErrorMessage()" />
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
        <ajx:ModalPopupExtender ID="mpeAlertMessage" runat="server" TargetControlID="hdnAlertMessage"
            PopupControlID="pnlAlertMessage" BackgroundCssClass="mod_background" CancelControlID="btnCancelAlertMessage"
            BehaviorID="mpeAlertMessage">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnAlertMessage" runat="server" />
        <asp:Panel ID="pnlAlertMessage" runat="server" Height="140px" Width="325px">
            <table border="0" cellspacing="0" cellpadding="0" class="modelpopup_box">
                <tr>
                    <td class="modelpopup_boxtopleft">
                        &nbsp;
                    </td>
                    <td class="modelpopup_boxtopcenter">
                        &nbsp;Message
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
                        <table cellpadding="2" cellspacing="2" width="100%">
                            <tr>
                                <td align="center" style="padding-bottom: 25px;">
                                    <asp:Label ID="lblAlertMessage" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Button ID="btnCancelAlertMessage" runat="server" Text="OK" Style="display: inline;" />
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
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updIPS" ID="UpdateProgressIPS" runat="server">
    <ProgressTemplate>
        <div id="progressBackgroundFilter">
        </div>
        <div id="processMessage">
            <center>
                <img src="../../images/ajax-loader.gif" /></center>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
