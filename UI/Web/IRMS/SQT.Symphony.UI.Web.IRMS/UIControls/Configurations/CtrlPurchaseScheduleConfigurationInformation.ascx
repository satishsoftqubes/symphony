<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlPurchaseScheduleConfigurationInformation.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.Configurations.CtrlPurchaseScheduleConfigurationInformation" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>

<script type="text/javascript">
    var updateProgress = null;

    function postbackButtonClick() {
        if (Page_ClientValidate("Configuration")) {
            document.getElementById('errormessage').style.display = "block";
            updateProgress = $find("<%= UpdateProgressPurchaseSchedule.ClientID %>");
            window.setTimeout("updateProgress.set_visible(true)", updateProgress.get_displayAfter());
            return true;
        }
        else {
            return false;
        }
    }

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function fnClearDate(para1) {
        var payDate = para1.previousElementSibling;
        payDate.value = '';
    }

    function fnCalcInstallmentAmount(percentage) {
        var rowIndex = percentage.parentNode.parentNode.parentNode.rowIndex + 1;
        var currentAmount = document.getElementById("ctl00_ContentPlaceHolder1_CtrlPropertyConfigurationInformation1_gvPropertyInstallments_ctl0" + rowIndex + "_txtInstallmentAmount");
        var percentage = parseFloat(percentage.value);
        var totalCost = parseFloat(document.getElementById('ctl00_ContentPlaceHolder1_CtrlPropertyConfigurationInformation1_txtTotalCost').value);
        var amount = (parseFloat(totalCost * percentage) / 100);
        currentAmount.value = amount;
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
<asp:UpdatePanel ID="updPurchaseSchedule" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="content" style="padding-left: 0px; width: 66.66%">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                        <tr>
                            <td class="boxtopleft">&nbsp;
                            </td>
                            <td class="boxtopcenter">PURCHASE SCHEDULE
                            </td>
                            <td class="boxtopright">&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="boxleft">&nbsp;
                            </td>
                            <td>
                                <table cellpadding="3" cellspacing="3" border="0" width="100%">
                                    <tr>
                                        <td colspan="2">
                                            <div style="height: 26px;">
                                                <%if (IsMessage)
                                                    { %>
                                                <div class="ResetSuccessfully">
                                                    <div style="float: left; padding-top: 7px; width: 25px; height: 24px; margin-right: 10px;">
                                                        <img src="../../images/success.png" />
                                                    </div>
                                                    <div>
                                                        <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
                                                    </div>
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
                                        <td>
                                            <asp:Label ID="litPropertyName" runat="server" Text="Property Name" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rfvPropertyName" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                    InitialValue="00000000-0000-0000-0000-000000000000" runat="server" ValidationGroup="Configuration"
                                                    ControlToValidate="ddlPropertyName" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlPropertyName" runat="server" Style="width: 205px;">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litPurchaseOption" runat="server" Text="Purchase Option" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rfvPurchaseOption" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                    InitialValue="00000000-0000-0000-0000-000000000000" runat="server" ValidationGroup="Configuration"
                                                    ControlToValidate="ddlPurchaseOption" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlPurchaseOption" Style="width: 205px;" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litPrice" runat="server" Text="Price" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rfvPrice" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                    runat="server" ValidationGroup="Configuration" ControlToValidate="txtPrice"
                                                    ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox AutoPostBack="true" ID="txtPrice" SkinID="CmpTextbox" runat="server" MaxLength="10"></asp:TextBox>
                                            <ajx:FilteredTextBoxExtender ID="filtxtPrice" runat="server" TargetControlID="txtPrice"
                                                FilterType="Numbers" />
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td>
                                            <asp:Label ID="litPurchaseArea" runat="server" SkinID="CmpTextbox" Text="Purchase Area" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rfvPurchaseArea" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                    runat="server" ValidationGroup="Configuration" ControlToValidate="txtPurchaseArea"
                                                    ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPurchaseArea" SkinID="CmpTextbox" runat="server" MaxLength="10"></asp:TextBox>
                                            <ajx:FilteredTextBoxExtender ID="filtxtPurchaseArea" runat="server" TargetControlID="txtPurchaseArea"
                                                FilterType="Numbers" />
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litPurchaseArea" runat="server" Text="Purchase Area" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rfvPurchaseArea" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                    runat="server" ValidationGroup="Configuration" ControlToValidate="txtPurchaseArea"
                                                    ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox AutoPostBack="true" ID="txtPurchaseArea" SkinID="CmpTextbox" runat="server" MaxLength="10"></asp:TextBox>
                                            <ajx:FilteredTextBoxExtender ID="filtxtPurchaseArea" runat="server" TargetControlID="txtPrice"
                                                FilterType="Numbers" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnCalcTotalCost" runat="server" Text="Calculate" OnClick="btnCalculateTotalCost_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litTotalCost" runat="server" Text="Total Cost" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rfvTotalCost" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                    runat="server" ValidationGroup="Configuration" ControlToValidate="txtTotalCost"
                                                    ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTotalCost" SkinID="CmpTextbox" runat="server" MaxLength="10" ReadOnly="true" Style="background: #dcdddf;"></asp:TextBox>
                                            <ajx:FilteredTextBoxExtender ID="filtxtTotalCost" runat="server" TargetControlID="txtTotalCost"
                                                FilterType="Numbers" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="pagesubheader">
                    <div class="pagesubheader">
                        <asp:Literal ID="Literal3" runat="server" Text="Property Installments"></asp:Literal>
                        <asp:ImageButton ID="ButtonAdd" ToolTip="Add" OnClick="fnAddNewInstallment"
                            CommandName="ADDDATA" runat="server" ImageUrl="~/images/add_icon.png" Style="border-radius: 50%; float: right; width: 19px; margin-bottom: 10px; border: 0px;"
                            OnClientClick="fnDisplayCatchErrorMessage()" />
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="dTableBox1">
                    <div class="leftmarginbox_content">
                        <asp:GridView ID="gvPropertyInstallments" AutoGenerateColumns="false" SkinID="gvNoPaging"
                            runat="server" ShowFooter="true" ShowHeader="true"
                            OnRowDataBound="gvPropertyInstallments_RowDataBound" OnRowCommand="gvPropertyInstallments_RowCommand"
                            OnRowCreated="gvPropertyInstallmentRowCreated">
                            <Columns>
                                <asp:BoundField DataField="RowNumber" HeaderText="Installment" />
                                <asp:TemplateField HeaderText="Payment Period">
                                    <ItemTemplate>
                                        <div style="justify-content: space-around; display: flex;">
                                            <asp:RequiredFieldValidator ID="rfvInstallmentType" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                            InitialValue="00000000-0000-0000-0000-000000000000" runat="server" ValidationGroup="Configuration"
                                            ControlToValidate="ddlPaymentPeriod" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                            <asp:DropDownList ID="ddlPaymentPeriod" Style="width: 140px; margin-left:5px;" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Percentage">
                                    <ItemTemplate>
                                        <div style="justify-content: space-around; display: flex;">
                                            <span class="erroralert">
                                                <asp:RequiredFieldValidator ID="txtInstallmentPercentName" SkinID="Search" SetFocusOnError="true" runat="server" ValidationGroup="Configuration" ControlToValidate="txtInstallmentPercent" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </span>
                                            <asp:TextBox onKeyUp="fnCalcInstallmentAmount(this)" style="margin-left:5px;" ID="txtInstallmentPercent" SkinID="Search" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "InstallmentInPercentage")%>'></asp:TextBox>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Payment Mode">
                                    <ItemTemplate>
                                        <div style="justify-content: space-around; display: flex;">
                                            <asp:RequiredFieldValidator ID="rfvPaymentMode" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                            InitialValue="00000000-0000-0000-0000-000000000000" runat="server" ValidationGroup="Configuration"
                                            ControlToValidate="ddlPaymentMode" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                            <asp:DropDownList ID="ddlPaymentMode" Style="width: 140px; margin-left:5px;" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                        
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Amount">
                                    <ItemTemplate>
                                        <div style="justify-content: space-around; display: flex;">
                                            <span class="erroralert">
                                                <asp:RequiredFieldValidator ID="txtInstallmentAmountName" SkinID="Search" SetFocusOnError="true" runat="server" ValidationGroup="Configuration" ControlToValidate="txtInstallmentAmount" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </span>
                                            <asp:TextBox ID="txtInstallmentAmount" SkinID="Search" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "InstallmentAmount")%>' Style="background: #dcdddf; margin-left:5px;"></asp:TextBox>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Payment Date">
                                    <ItemTemplate>
                                        <div style="display: flex;">
                                            <asp:TextBox ID="txtPaymentDate" runat="server" autocomplete="off"
                                                Style="width: 90px !important;" SkinID="searchtextbox" onkeydown="return stopKey(event);"></asp:TextBox>
                                            <%--<asp:Image ID="imgSearchFromDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                Height="20px" Width="20px" />--%>

                                            <ajx:CalendarExtender ID="calPaymentDate" PopupButtonID="imgPaymentDate" TargetControlID="txtPaymentDate"
                                                runat="server" Format="dd/MM/yyyy h:mm">
                                            </ajx:CalendarExtender>
                                            <img src="../../images/clear.png" onclick="fnClearDate(this);" 
                                                CssClass="small_img" style="height:17px; width:17px;"  id="imgclearDateFrom" title="Clear Date" />
                                            <asp:RequiredFieldValidator ID="rvfFromDate" runat="server" ControlToValidate="txtPaymentDate"
                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequireSearch"></asp:RequiredFieldValidator>
                                        </div>
                                        <%--onclick="fnClearDate('<%= txtPaymentDate.ClientID %>');"--%>
                                        <asp:RequiredFieldValidator ID="rvfPaymentDate" runat="server" ControlToValidate="txtPaymentDate"
                                            SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequireSearch"></asp:RequiredFieldValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
            <tr>
                <td style="float: right; width: auto; display: inline-block;">
                    <asp:Button ID="btnNew" runat="server" Style="display: inline-block; margin-left: 5px; display: inline;"
                        Text="New" OnClick="btnNew_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                     <asp:Button ID="btnSave" Text="Save" Style="display: inline-block; margin-left: 5px;"
                        runat="server" ImageUrl="~/images/save.png" ValidationGroup="Configuration" CausesValidation="true"
                        OnClick="btnSave_Click" OnClientClick="return postbackButtonClick();" />
                    <asp:Button ID="btnCancel" Text="Cancel" Style="display: inline-block; margin-left: 5px;"
                        runat="server" ImageUrl="~/images/cancle.png" CausesValidation="false" OnClick="btnCancel_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updPurchaseSchedule" ID="UpdateProgressPurchaseSchedule"
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



