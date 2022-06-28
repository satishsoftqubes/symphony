<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlInvestorsUnit.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.InvestorSetUp.CtrlInvestorsUnit" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function pageLoad(sender, args) {
        $(document).ready(function () {
            $("#<%=txtSInvestorName.ClientID%>").autocomplete('../SetUp/UnitAutoComplete.ashx');
        });
    }

    function fnCalculateAgreementtoSell() {

        var AgreementtoSellToatl = 0;
        var AgrtoSellValue = document.getElementById('<%=txtAgToSellValue.ClientID %>').value;
        var StampDutyonAgrtoSell = document.getElementById('<%=txtStampDutyonAgrtoSell.ClientID %>').value;
        var StampDutyonSaleDeed = document.getElementById('<%=txtStampDutyonSaleDeed.ClientID %>').value;
        var RegistrationCharges = document.getElementById('<%=txtRegistrationCharges.ClientID %>').value;
        var OtherCosts = document.getElementById('<%=txtOtherCosts.ClientID %>').value;

        if (parseFloat(AgrtoSellValue) > 0) {
            AgreementtoSellToatl = AgreementtoSellToatl + parseFloat(AgrtoSellValue);
        }
        if (parseFloat(StampDutyonAgrtoSell) > 0) {
            AgreementtoSellToatl = AgreementtoSellToatl + parseFloat(StampDutyonAgrtoSell);
        }
        if (parseFloat(StampDutyonSaleDeed) > 0) {
            AgreementtoSellToatl = AgreementtoSellToatl + parseFloat(StampDutyonSaleDeed);
        }
        if (parseFloat(RegistrationCharges) > 0) {
            AgreementtoSellToatl = AgreementtoSellToatl + parseFloat(RegistrationCharges);
        }
        if (parseFloat(OtherCosts) > 0) {
            AgreementtoSellToatl = AgreementtoSellToatl + parseFloat(OtherCosts);
        }

        document.getElementById('<%=lblSubTotalAgreementToSell.ClientID %>').innerHTML = AgreementtoSellToatl.toFixed(2);
        document.getElementById('<%=hdnAgreementtoSell.ClientID %>').value = AgreementtoSellToatl.toFixed(2);
    }

    function fnCalculateConstructionAgreement() {

        var ConstructionAgreementToatl = 0;
        var ConstructionValue = document.getElementById('<%=txtConstructionCost.ClientID %>').value;
        var VAT = document.getElementById('<%=txtVAT.ClientID %>').value;
        var ServiceTax = document.getElementById('<%=txtSTax.ClientID %>').value;
        var OtherCosts = document.getElementById('<%=txtOtherConstructorCost.ClientID %>').value;

        if (parseFloat(ConstructionValue) > 0) {
            ConstructionAgreementToatl = ConstructionAgreementToatl + parseFloat(ConstructionValue);
        }
        if (parseFloat(VAT) > 0) {
            ConstructionAgreementToatl = ConstructionAgreementToatl + parseFloat(VAT);
        }
        if (parseFloat(ServiceTax) > 0) {
            ConstructionAgreementToatl = ConstructionAgreementToatl + parseFloat(ServiceTax);
        }
        if (parseFloat(OtherCosts) > 0) {
            ConstructionAgreementToatl = ConstructionAgreementToatl + parseFloat(OtherCosts);
        }

        document.getElementById('<%=lblSubTotalConstructionAgreement.ClientID %>').innerHTML = ConstructionAgreementToatl.toFixed(2);
        document.getElementById('<%=hdnConstructionAgreement.ClientID %>').value = ConstructionAgreementToatl.toFixed(2);
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
        if (Page_ClientValidate("InvestorUnit")) {
            document.getElementById('errormessage').style.display = "block";

            var TotalCost = 0;
            var UnitPrice = document.getElementById('<%=txtUnitPrice.ClientID %>').value;
            var AgrtoSellValue = document.getElementById('<%=txtAgToSellValue.ClientID %>').value;
            var ConstructionValue = document.getElementById('<%=txtConstructionCost.ClientID %>').value;

            if (parseFloat(AgrtoSellValue) > 0) {

                TotalCost = TotalCost + parseFloat(AgrtoSellValue);
            }

            if (parseFloat(ConstructionValue) > 0) {
                TotalCost = TotalCost + parseFloat(ConstructionValue);
            }

            if (parseFloat(TotalCost) == parseFloat(UnitPrice)) {
                document.getElementById('<%=lblErrorMessageOfUnitPrice.ClientID %>').innerHTML = "";
                updateProgress = $find("<%= UpdateProgressInvestorUnit.ClientID %>");
                window.setTimeout("updateProgress.set_visible(true)", updateProgress.get_displayAfter());
                return true;
            }
            else {
                if (parseFloat(UnitPrice) > parseFloat(TotalCost)) {
                    document.getElementById('<%=lblErrorMessageOfUnitPrice.ClientID %>').innerHTML = "Unit Price should be equal to (Land Value + Construction Value)";
                    return false;
                }
                else if (parseFloat(UnitPrice) < parseFloat(TotalCost)) {
                    document.getElementById('<%=lblErrorMessageOfUnitPrice.ClientID %>').innerHTML = "Unit Price should be equal to (Land Value + Construction Value)";
                    return false;
                }
            }

        }
        else {
            return false;
        }
    }
</script>
<asp:UpdatePanel ID="updInvestorUnit" runat="server">
    <ContentTemplate>
        <asp:HiddenField ID="hdnAgreementtoSell" runat="server" />
        <asp:HiddenField ID="hdnConstructionAgreement" runat="server" />
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="content" style="padding-left: 0px; width: 66.66%">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                INVESTOR UNIT DETAIL
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
                                        <td align="left" valign="top" colspan="2" style="text-align: right;">
                                            <div style="float: right; width: auto; display: inline-block;">
                                                <asp:Button ID="btnNewUp" runat="server" Style="display: inline-block; margin-left: 5px;
                                                    display: inline;" Text="New" OnClick="btnNewUp_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                <asp:Button ID="btnSaveUp" Text="Save" Style="display: inline-block; margin-left: 5px;"
                                                    runat="server" ImageUrl="~/images/save.png" ValidationGroup="InvestorUnit" CausesValidation="true"
                                                    OnClick="btnSaveUp_Click" OnClientClick="return postbackButtonClick();" />
                                                <asp:Button ID="btnCancelUp" Text="Cancel" Style="display: inline-block; margin-left: 5px;"
                                                    runat="server" ImageUrl="~/images/cancle.png" CausesValidation="false" OnClick="btnCancel_Click" />
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" style="width: 125px;">
                                            <asp:Label ID="litInvestor" CssClass="RequireFile" runat="server" Text="Investor Name"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfddlInvestor" runat="server" ControlToValidate="ddlInvestor"
                                                    SetFocusOnError="true" CssClass="rfv_ErrorStar" InitialValue="00000000-0000-0000-0000-000000000000"
                                                    ErrorMessage="*" ValidationGroup="InvestorUnit"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td align="left" valign="top">
                                            <asp:DropDownList ID="ddlInvestor" runat="server" Enabled="false" Style="width: 202px;">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top">
                                            <asp:Label ID="litPropertyID" CssClass="RequireFile" runat="server" Text="Property Name"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfddlPropertyName" runat="server" ControlToValidate="ddlPropertyName"
                                                    SetFocusOnError="true" CssClass="rfv_ErrorStar" InitialValue="00000000-0000-0000-0000-000000000000"
                                                    ErrorMessage="*" ValidationGroup="InvestorUnit"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td align="left" valign="top">
                                            <asp:DropDownList ID="ddlPropertyName" runat="server" Style="width: 202px;" OnSelectedIndexChanged="ddlPropertyName_SelectedIndexChanged"
                                                AutoPostBack="true">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top">
                                            <asp:Label ID="litUnitNo" runat="server" Text="Unit Type" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfddlRoomName" runat="server" ControlToValidate="ddlRoomName"
                                                    SetFocusOnError="true" CssClass="rfv_ErrorStar" InitialValue="00000000-0000-0000-0000-000000000000"
                                                    ErrorMessage="*" ValidationGroup="InvestorUnit"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td align="left" valign="top">
                                            <asp:DropDownList ID="ddlRoomName" runat="server" Style="width: 202px;" OnSelectedIndexChanged="ddlRoomName_SelectedIndexChanged"
                                                AutoPostBack="true">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top">
                                            <asp:Label ID="litRoomName" CssClass="RequireFile" runat="server" Text="Unit No"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfddlUnitNo" runat="server" ControlToValidate="ddlUnitNo"
                                                    SetFocusOnError="true" CssClass="rfv_ErrorStar" InitialValue="00000000-0000-0000-0000-000000000000"
                                                    ErrorMessage="*" ValidationGroup="InvestorUnit"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td align="left" valign="top">
                                            <asp:DropDownList ID="ddlUnitNo" runat="server" Style="width: 202px;" OnSelectedIndexChanged="ddlUnitNo_SelectedIndexChanged"
                                                AutoPostBack="true">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="litSBA" runat="server" Text="SBA(Sft)"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSBA" Enabled="false" runat="server" MaxLength="15" SkinID="CmpTextbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litUnitPrice" CssClass="RequireFile" runat="server" Text="Unit Price (Rs.)"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvftxtUnitPrice" runat="server" ControlToValidate="txtUnitPrice"
                                                    SetFocusOnError="true" CssClass="rfv_ErrorStar" ErrorMessage="*" ValidationGroup="InvestorUnit"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtUnitPrice" runat="server" SkinID="CmpTextbox" MaxLength="15"
                                                AutoPostBack="true" OnTextChanged="txtUnitPrice_TextChanged"></asp:TextBox>
                                            <ajx:FilteredTextBoxExtender ID="filtxtSBArea" runat="server" TargetControlID="txtUnitPrice"
                                                FilterType="Custom, Numbers" ValidChars="." />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litRatePerSqtFt" runat="server" Text="Rate Per Sft" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvftxtRatePerSqtFt" runat="server" ControlToValidate="txtRatePerSqtFt"
                                                    SetFocusOnError="true" CssClass="rfv_ErrorStar" ErrorMessage="*" ValidationGroup="InvestorUnit"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRatePerSqtFt" runat="server" MaxLength="15" SkinID="CmpTextbox"
                                                Enabled="false"></asp:TextBox>
                                            <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtRatePerSqtFt"
                                                FilterType="Custom, Numbers" ValidChars="." />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblDateOfBooking" runat="server" Text="Date Of Booking" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rfvDateOfBooking" runat="server" ControlToValidate="txtDateOfBooking"
                                                    SetFocusOnError="true" CssClass="rfv_ErrorStar" ErrorMessage="*" ValidationGroup="InvestorUnit"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDateOfBooking" runat="server" Style="width: 80px !important;"
                                                onkeydown="return stopKey(event);"></asp:TextBox>
                                            <asp:Image ID="imgCalendarDateOfBooking" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                Height="20px" Width="20px" />
                                            <ajx:CalendarExtender ID="ajxCalendarDateOfBooking" PopupButtonID="imgCalendarDateOfBooking"
                                                CssClass="MyCalendar" TargetControlID="txtDateOfBooking" runat="server">
                                            </ajx:CalendarExtender>
                                            <img src="../../images/clear.png" id="imgClearDate" style="vertical-align: middle;"
                                                onclick="fnClearDate('<%= txtDateOfBooking.ClientID %>');" />
                                            &nbsp;&nbsp;
                                            <asp:CustomValidator ID="vDataOfBooking" runat="server" ErrorMessage="Invalid date."
                                                Display="Dynamic" ControlToValidate="txtDateOfBooking" OnServerValidate="vDataOfBooking_ServerValidate"
                                                ValidationGroup="InvestorUnit" ForeColor="Red"></asp:CustomValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblFinalPaymentDate" runat="server" Text="Final Payment Date"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFinalPaymentDate" runat="server" Style="width: 80px !important;"
                                                onkeydown="return stopKey(event);"></asp:TextBox>
                                            <asp:Image ID="imgFinalPaymentDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                Height="20px" Width="20px" />
                                            <ajx:CalendarExtender ID="calFinalPaymentDate" PopupButtonID="imgFinalPaymentDate"
                                                CssClass="MyCalendar" TargetControlID="txtFinalPaymentDate" runat="server">
                                            </ajx:CalendarExtender>
                                            <img src="../../images/clear.png" id="img2" style="vertical-align: middle;" onclick="fnClearDate('<%= txtFinalPaymentDate.ClientID %>');" />
                                            &nbsp;&nbsp;
                                            <asp:CustomValidator ID="cvFinalPaymentDate" runat="server" ErrorMessage="Invalid date."
                                                Display="Dynamic" ControlToValidate="txtRegistrationDate" OnServerValidate="vFinalPaymentDate_ServerValidate"
                                                ValidationGroup="InvestorUnit" ForeColor="Red"></asp:CustomValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblRegistrationDate" runat="server" Text="Registration Date"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRegistrationDate" runat="server" Style="width: 80px !important;"
                                                onkeydown="return stopKey(event);"></asp:TextBox>
                                            <asp:Image ID="imgRegistrationDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                Height="20px" Width="20px" />
                                            <ajx:CalendarExtender ID="calRegistrationDate" PopupButtonID="imgRegistrationDate"
                                                CssClass="MyCalendar" TargetControlID="txtRegistrationDate" runat="server">
                                            </ajx:CalendarExtender>
                                            <img src="../../images/clear.png" id="img1" style="vertical-align: middle;" onclick="fnClearDate('<%= txtRegistrationDate.ClientID %>');" />
                                            &nbsp;&nbsp;
                                            <asp:CustomValidator ID="cvRegistrationDate" runat="server" ErrorMessage="Invalid date."
                                                Display="Dynamic" ControlToValidate="txtRegistrationDate" OnServerValidate="vRegistrationDate_ServerValidate"
                                                ValidationGroup="InvestorUnit" ForeColor="Red"></asp:CustomValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblSellerCompany" runat="server" Text="Seller Company"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSellerCompany" runat="server" SkinID="CmpTextbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="lblErrorMessageOfUnitPrice" ForeColor="Red" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" colspan="2" class="pagesubheader">
                                            Land Value
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="litAggToSellValue" runat="server" Text="Land Value"></asp:Literal>
                                            <span class="erroraleart">
                                                <asp:RegularExpressionValidator ID="revAggToSellValue" SetFocusOnError="True" runat="server"
                                                    ValidationGroup="InvestorUnit" ControlToValidate="txtAgToSellValue" ValidationExpression="^\d{0,15}(\.\d{0,2})?$"
                                                    Display="Dynamic" CssClass="rfv_ErrorStar" ErrorMessage="*"></asp:RegularExpressionValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAgToSellValue" runat="server" MaxLength="18" SkinID="CmpTextbox"
                                                onblur="fnCalculateAgreementtoSell();"></asp:TextBox>
                                            <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtAgToSellValue"
                                                FilterType="Custom, Numbers" ValidChars="." />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="litStmpDutyOnAgrToSell" runat="server" Text="Stamp Duty on Agr. to Sell"></asp:Literal>
                                            <span class="erroraleart">
                                                <asp:RegularExpressionValidator ID="revStmpDutyOnAgrToSell" SetFocusOnError="True"
                                                    runat="server" ValidationGroup="InvestorUnit" ControlToValidate="txtStampDutyonAgrtoSell"
                                                    ValidationExpression="^\d{0,15}(\.\d{0,2})?$" Display="Dynamic" CssClass="rfv_ErrorStar"
                                                    ErrorMessage="*"></asp:RegularExpressionValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtStampDutyonAgrtoSell" runat="server" MaxLength="18" SkinID="CmpTextbox"
                                                onblur="fnCalculateAgreementtoSell();"></asp:TextBox>
                                            <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server" TargetControlID="txtStampDutyonAgrtoSell"
                                                FilterType="Custom, Numbers" ValidChars="." />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="litStampDutyonSaleDeed" runat="server" Text="Stamp Duty on Sale Deed "></asp:Literal>
                                            <span class="erroraleart">
                                                <asp:RegularExpressionValidator ID="revStampDutyonSaleDeed" SetFocusOnError="True"
                                                    runat="server" ValidationGroup="InvestorUnit" ControlToValidate="txtStampDutyonSaleDeed"
                                                    ValidationExpression="^\d{0,15}(\.\d{0,2})?$" Display="Dynamic" CssClass="rfv_ErrorStar"
                                                    ErrorMessage="*"></asp:RegularExpressionValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtStampDutyonSaleDeed" runat="server" MaxLength="18" SkinID="CmpTextbox"
                                                onblur="fnCalculateAgreementtoSell();"></asp:TextBox>
                                            <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtStampDutyonSaleDeed"
                                                FilterType="Custom, Numbers" ValidChars="." />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="litRegistrationCharges" runat="server" Text="Registration Charges"></asp:Literal>
                                            <span class="erroraleart">
                                                <asp:RegularExpressionValidator ID="revRegistrationCharges" SetFocusOnError="True"
                                                    runat="server" ValidationGroup="InvestorUnit" ControlToValidate="txtRegistrationCharges"
                                                    ValidationExpression="^\d{0,15}(\.\d{0,2})?$" Display="Dynamic" CssClass="rfv_ErrorStar"
                                                    ErrorMessage="*"></asp:RegularExpressionValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRegistrationCharges" runat="server" MaxLength="18" SkinID="CmpTextbox"
                                                onblur="fnCalculateAgreementtoSell();"></asp:TextBox>
                                            <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server" TargetControlID="txtRegistrationCharges"
                                                FilterType="Custom, Numbers" ValidChars="." />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="litOtherCosts" runat="server" Text="Other Costs"></asp:Literal>
                                            <span class="erroraleart">
                                                <asp:RegularExpressionValidator ID="revAggOtherCosts" SetFocusOnError="True" runat="server"
                                                    ValidationGroup="InvestorUnit" ControlToValidate="txtOtherCosts" ValidationExpression="^\d{0,15}(\.\d{0,2})?$"
                                                    Display="Dynamic" CssClass="rfv_ErrorStar" ErrorMessage="*"></asp:RegularExpressionValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtOtherCosts" runat="server" MaxLength="18" SkinID="CmpTextbox"
                                                onblur="fnCalculateAgreementtoSell();"></asp:TextBox>
                                            <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtOtherCosts"
                                                FilterType="Custom, Numbers" ValidChars="." />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="litSubTotalAgreementToSell" runat="server" Text="Sub Total"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblSubTotalAgreementToSell" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" colspan="2" class="pagesubheader">
                                            Construction Agreement
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="litConstructionCost" runat="server" Text="Construction Value"></asp:Literal>
                                            <span class="erroraleart">
                                                <asp:RegularExpressionValidator ID="revConstructionCost" SetFocusOnError="True" runat="server"
                                                    ValidationGroup="InvestorUnit" ControlToValidate="txtConstructionCost" ValidationExpression="^\d{0,15}(\.\d{0,2})?$"
                                                    Display="Dynamic" CssClass="rfv_ErrorStar" ErrorMessage="*"></asp:RegularExpressionValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtConstructionCost" runat="server" MaxLength="18" SkinID="CmpTextbox"
                                                onblur="fnCalculateConstructionAgreement();"></asp:TextBox>
                                            <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txtConstructionCost"
                                                FilterType="Custom, Numbers" ValidChars="." />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="litVAT" runat="server" Text="VAT"></asp:Literal>
                                            <span class="erroraleart">
                                                <asp:RegularExpressionValidator ID="revVAT" SetFocusOnError="True" runat="server"
                                                    ValidationGroup="InvestorUnit" ControlToValidate="txtVAT" ValidationExpression="^\d{0,15}(\.\d{0,2})?$"
                                                    Display="Dynamic" CssClass="rfv_ErrorStar" ErrorMessage="*"></asp:RegularExpressionValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtVAT" runat="server" SkinID="CmpTextbox" MaxLength="18" onblur="fnCalculateConstructionAgreement();"></asp:TextBox>
                                            <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" TargetControlID="txtVAT"
                                                FilterType="Custom, Numbers" ValidChars="." />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="litSTax" runat="server" Text="S. Tax"></asp:Literal>
                                            <span class="erroraleart">
                                                <asp:RegularExpressionValidator ID="revSTax" SetFocusOnError="True" runat="server"
                                                    ValidationGroup="InvestorUnit" ControlToValidate="txtSTax" ValidationExpression="^\d{0,15}(\.\d{0,2})?$"
                                                    Display="Dynamic" CssClass="rfv_ErrorStar" ErrorMessage="*"></asp:RegularExpressionValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSTax" runat="server" MaxLength="18" SkinID="CmpTextbox" onblur="fnCalculateConstructionAgreement();"></asp:TextBox>
                                            <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="txtSTax"
                                                FilterType="Custom, Numbers" ValidChars="." />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="litOtherConstructorCost" runat="server" Text="Other Costs"></asp:Literal>
                                            <span class="erroraleart">
                                                <asp:RegularExpressionValidator ID="revOtherConstructorCost" SetFocusOnError="True"
                                                    runat="server" ValidationGroup="InvestorUnit" ControlToValidate="txtOtherConstructorCost"
                                                    ValidationExpression="^\d{0,15}(\.\d{0,2})?$" Display="Dynamic" CssClass="rfv_ErrorStar"
                                                    ErrorMessage="*"></asp:RegularExpressionValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtOtherConstructorCost" runat="server" MaxLength="18" SkinID="CmpTextbox"
                                                onblur="fnCalculateConstructionAgreement();"></asp:TextBox>
                                            <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" TargetControlID="txtOtherConstructorCost"
                                                FilterType="Custom, Numbers" ValidChars="." />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="litSubTotalConstructionAgreement" runat="server" Text="Sub Total"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblSubTotalConstructionAgreement" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" colspan="2" class="pagesubheader">
                                            Terms
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litBirthDate" runat="server" Text="Date Of Possession"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlDate" runat="server" Style="width: 65px;">
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddlMonth" runat="server" Style="width: 70px;">
                                                <asp:ListItem Text="-Month-" Value="00000000-0000-0000-0000-000000000000" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="Jan" Value="01"></asp:ListItem>
                                                <asp:ListItem Text="Feb" Value="02"></asp:ListItem>
                                                <asp:ListItem Text="Mar" Value="03"></asp:ListItem>
                                                <asp:ListItem Text="Apr" Value="04"></asp:ListItem>
                                                <asp:ListItem Text="May" Value="05"></asp:ListItem>
                                                <asp:ListItem Text="Jun" Value="06"></asp:ListItem>
                                                <asp:ListItem Text="Jul" Value="07"></asp:ListItem>
                                                <asp:ListItem Text="Aug" Value="08"></asp:ListItem>
                                                <asp:ListItem Text="Sep" Value="09"></asp:ListItem>
                                                <asp:ListItem Text="Oct" Value="10"></asp:ListItem>
                                                <asp:ListItem Text="Nov" Value="11"></asp:ListItem>
                                                <asp:ListItem Text="Dec" Value="12"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddlYear" runat="server" Style="width: 60px;">
                                            </asp:DropDownList>
                                            <div id="ValidDate" runat="server" class="rfv_ErrorStar" visible="false" style="float: right;">
                                                Enter Valid Date</div>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td>
                                            <asp:Literal ID="litInterest" Text="Interest Applicable" runat="server"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="chkIsInterestApplicable" runat="server" Text="Yes" AutoPostBack="true"
                                                OnCheckedChanged="chkIsInterestApplicable_CheckedChanged" />
                                            <asp:CheckBox ID="chkIntAppNo" runat="server" Text="No" AutoPostBack="true" OnCheckedChanged="chkIntAppNo_CheckedChanged" />
                                        </td>
                                    </tr>
                                    <tr id="trRateOfInterest" runat="server">
                                        <td>
                                            <asp:Literal ID="litRateOfInterest" runat="server" Text="Rate (%)"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRateOfInterest" runat="server" MaxLength="6" SkinID="CmpTextbox"></asp:TextBox>
                                            <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" TargetControlID="txtRateOfInterest"
                                                FilterType="Custom, Numbers" ValidChars="." />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:RangeValidator ID="rngvRateOfInterest" runat="server" ControlToValidate="txtRateOfInterest"
                                                Display="Dynamic" MinimumValue="0" MaximumValue="100" Type="Double" ValidationGroup="InvestorUnit"
                                                SetFocusOnError="true" ErrorMessage="Interest should be less or equal to 100."
                                                ForeColor="Red"></asp:RangeValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" colspan="2" class="pagesubheader">
                                            Unit Documents
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" class="dTableBox1">
                                            <div class="leftmarginbox_content">
                                                <asp:GridView ID="gvDocument" runat="server" AutoGenerateColumns="false" SkinID="gvNoPaging"
                                                    OnRowDataBound="gvDocument_RowDataBound" DataKeyNames="TermID" ShowHeader="true"
                                                    OnRowCommand="gvDocument_RowCommand">
                                                    <Columns>
                                                        <asp:BoundField DataField="Term" HeaderText="Document Name" ItemStyle-Width="155px"
                                                            HeaderStyle-HorizontalAlign="Center" />
                                                        <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Center" HeaderText="Document No.">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtDate" runat="server" Style="width: 100px;" Text='<%# DataBinder.Eval(Container.DataItem, "Notes")%>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="105px" HeaderText="File" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <div id='browse_file_grid'>
                                                                    <asp:FileUpload ID="fuDocument" ToolTip=".pdf|.PDF|.jpg|.jpeg|.gif|.png|.bmp|.JPG|.JPEG|.GIF|.PNG|.BMP|.TIF|.tif|.doc|.DOC|.docx|.DOCX|xlsx|XLSX"
                                                                        runat="server" Height="22px" size="5" Style="width: 100px;" />
                                                                </div>
                                                                <asp:HiddenField ID="hdnDocumentName" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "DocumentName")%>' />
                                                                <asp:RegularExpressionValidator ID="rfvDocument" runat="server" ControlToValidate="fuDocument"
                                                                    SetFocusOnError="true" CssClass="rfv_ErrorStar" ValidationGroup="Configuration"
                                                                    Display="Dynamic" ErrorMessage="*" ValidationExpression="^.+(.pdf|.PDF|.jpg|.jpeg|.gif|.png|.bmp|.JPG|.JPEG|.GIF|.PNG|.BMP|.TIF|.tif|.doc|.DOC|.docx|.DOCX|xlsx|XLSX)$"></asp:RegularExpressionValidator>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="40px" HeaderText="View" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <div style="display: inline;">
                                                                    <a id="aDocumentLink" runat="server" visible="false" target="_blank">
                                                                        <asp:Image ID="imgView" runat="server" Style="float: left; display: inline;" ImageUrl="~/images/View.png" /></a>
                                                                    <asp:ImageButton ID="btnDeleteDocument" ToolTip="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"DocumentID") %>'
                                                                        CommandName="DELETEDATA" runat="server" ImageUrl="~/images/DeleteFile.png" Style="float: right;
                                                                        margin-top: 5px; margin-left: 3px; height: 15px; width: 15px; border: 0px; display: inline;"
                                                                        OnClientClick="fnDisplayCatchErrorMessage()" />
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" colspan="2" style="text-align: right;">
                                            <div style="float: right; width: auto; display: inline-block;">
                                                <asp:Button ID="btnNew" runat="server" Style="display: inline-block; margin-left: 5px;
                                                    display: inline;" Text="New" OnClick="btnNew_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                <asp:Button ID="btnSave" Text="Save" Style="display: inline-block; margin-left: 5px;"
                                                    runat="server" ImageUrl="~/images/save.png" ValidationGroup="InvestorUnit" CausesValidation="true"
                                                    OnClick="btnSave_Click" OnClientClick="return postbackButtonClick();" />
                                                <asp:Button ID="btnCancel" Text="Cancel" Style="display: inline-block; margin-left: 5px;"
                                                    runat="server" ImageUrl="~/images/cancle.png" CausesValidation="false" OnClick="btnCancel_Click" />
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
                <td class="content">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                UNIT INFORMATION
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
                                                    <% if (Request.QueryString["Val"] != null)
                                                       {
                                                    %>
                                                    Unit No
                                                    <% }
                                                       else
                                                       { %>
                                                    Investor Name
                                                    <% } %>
                                                </td>
                                                <td style="vertical-align: middle;">
                                                    <asp:TextBox ID="txtSInvestorName" runat="server" SkinID="Search"></asp:TextBox>
                                                    <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                        Style="border: 0px; vertical-align: middle; margin-top: -3px; margin-left: 5px;"
                                                        OnClick="btnSearch_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="leftmarginbox_content">
                                        <div style="height: 1131px; overflow: auto;">
                                            <asp:GridView ID="grdInvestorUnitList" runat="server" ShowHeader="false" ShowFooter="false"
                                                SkinID="gvNoPaging" AutoGenerateColumns="false" Width="100%" OnRowCommand="grdInvestorUnitList_RowCommand"
                                                OnRowDataBound="grdInvestorUnitList_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <div class="rightmargin_grid">
                                                                <div class="leftmargin_contentarea">
                                                                    <% if (Request.QueryString["Val"] != null)
                                                                       {
                                                                    %>
                                                                    <strong>
                                                                        <%#DataBinder.Eval(Container.DataItem, "RoomNo")%></strong><br />
                                                                    <%#DataBinder.Eval(Container.DataItem, "UnitPrice")%><br />
                                                                    <%#DataBinder.Eval(Container.DataItem, "RatePerSqtft")%><br />
                                                                    <% }
                                                                       else
                                                                       { %>
                                                                    <strong>
                                                                        <%#DataBinder.Eval(Container.DataItem, "InvestorName")%></strong><br />
                                                                    <%#DataBinder.Eval(Container.DataItem, "RoomNo")%><br />
                                                                    <%#DataBinder.Eval(Container.DataItem, "UnitPrice")%><br />
                                                                    <%#DataBinder.Eval(Container.DataItem, "RatePerSqtft")%><br />
                                                                    <%#DataBinder.Eval(Container.DataItem, "VAT")%><br />
                                                                    <%#DataBinder.Eval(Container.DataItem, "STax")%><br />
                                                                    <%#DataBinder.Eval(Container.DataItem, "RateOfInterest")%><br />
                                                                    <% } %>
                                                                </div>
                                                                <div class="leftmargin_icons">
                                                                    <asp:ImageButton ID="btnEdit" runat="server" ToolTip="Edit" ImageUrl="~/images/edit.png"
                                                                        Style="border: 0px; vertical-align: middle; margin-top: 7px; margin-right: 7px;"
                                                                        CommandName="EditData" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "InvestorRoomID")%>'
                                                                        OnClientClick="fnDisplayCatchErrorMessage()" />
                                                                    <asp:ImageButton ID="btnDelete" runat="server" ToolTip="Delete" ImageUrl="~/images/delete_icon.png"
                                                                        Style="border: 0px; vertical-align: middle; margin-top: 7px; margin-right: 7px;"
                                                                        CommandName="DeleteData" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "InvestorRoomID")%>'
                                                                        OnClientClick="fnDisplayCatchErrorMessage()" />
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
                                        <asp:Button ID="btnInvestorsUnitYes" Text="Yes" runat="server" ImageUrl="~/images/save.png"
                                            OnClick="btnInvestorsUnitYes_Click" Style="display: inline-block;" OnClientClick="fnDisplayCatchErrorMessage()" />
                                        <asp:Button ID="btnInvestorsUnitNo" Text="Cancel" runat="server" ImageUrl="~/images/cancle.png"
                                            OnClick="btnInvestorsUnitNo_Click" Style="display: inline-block;" OnClientClick="fnDisplayCatchErrorMessage()" />
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
<asp:UpdatePanel ID="updMessage" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div id="errormessage" class="clear">
            <uc1:MsgBox ID="MessageBox" runat="server" />
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdateProgress AssociatedUpdatePanelID="updInvestorUnit" ID="UpdateProgressInvestorUnit"
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
