<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlEmployee.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.IRMSCofiguration.CtrlEmployee" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<%@ Register Src="CtrlAddress.ascx" TagName="CtrlAddress" TagPrefix="uc2" %>
<link href="../../Style/tab_control.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function pageLoad(sender, args) {

        $(document).ready(function () {
            $("#<%=txtCountry.ClientID%>").autocomplete('../SetUp/AutoComplete.ashx');
            $("#<%=txtState.ClientID%>").autocomplete('../SetUp/StateAutoComplete.ashx');
            $("#<%=txtCity.ClientID%>").autocomplete('../SetUp/CityAutoComplete.ashx');



            $("#<%=txtCCountry.ClientID%>").autocomplete('../SetUp/AutoComplete.ashx');
            $("#<%=txtCState.ClientID%>").autocomplete('../SetUp/StateAutoComplete.ashx');
            $("#<%=txtCCity.ClientID%>").autocomplete('../SetUp/CityAutoComplete.ashx');

            $("#<%=txtSEmployeeName.ClientID%>").autocomplete('../SetUp/EmployeeAutoComplete.ashx');
        });
    }

    function Copyaddress(chk) {
        var obj = chk;
        if (obj.checked == true) {
            document.getElementById('<%=txtCAddress1.ClientID %>').value = document.getElementById('<%=txtAddressLine1.ClientID %>').value;
            document.getElementById('<%=txtCCity.ClientID %>').value = document.getElementById('<%=txtCity.ClientID%>').value;
            document.getElementById('<%=txtCState.ClientID%>').value = document.getElementById('<%=txtState.ClientID%>').value;
            document.getElementById('<%=txtCCountry.ClientID%>').value = document.getElementById('<%=txtCountry.ClientID%>').value;
            document.getElementById('<%=txtCPostCode.ClientID%>').value = document.getElementById('<%=txtPostCode.ClientID%>').value;
        }
        else {
            document.getElementById('<%=txtCAddress1.ClientID %>').value = "";
            document.getElementById('<%=txtCCity.ClientID %>').value = "";
            document.getElementById('<%=txtCState.ClientID%>').value = "";
            document.getElementById('<%=txtCCountry.ClientID%>').value = "";
            document.getElementById('<%=txtCPostCode.ClientID%>').value = "";
        }
    }

</script>
<script type="text/javascript">
    var updateProgress = null;

    function postbackButtonClick() {
        if (Page_ClientValidate("Employee")) {
            document.getElementById('errormessage').style.display = "block";
            updateProgress = $find("<%= UpdateProgressupdEmployee.ClientID %>");
            window.setTimeout("updateProgress.set_visible(true)", updateProgress.get_displayAfter());
            return true;
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
<asp:UpdatePanel ID="updEmployee" runat="server">
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
                                EMPLOYEE
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
                                                        <asp:Label ID="lblEmployeeMsg" runat="server"></asp:Label></div>
                                                    <div style="height: 10px;">
                                                    </div>
                                                </div>
                                                <% }%>
                                            </div>
                                            <div>
                                                <%if (IsEmail)
                                                  { %>
                                                <div class="ResetSuccessfullyEmail">
                                                    <div style="float: left;">
                                                        <asp:Label ID="lblActivationMsg" runat="server" ForeColor="Red"></asp:Label></div>
                                                    <div style="float: right; padding-right: 5px;">
                                                        <asp:LinkButton ID="lnkReSendEmail" CssClass="LinkButton" runat="server" Text="Resend Activation Email"
                                                            OnClick="lnkReSendEmail_Click" Visible="false" OnClientClick="fnDisplayCatchErrorMessage()"></asp:LinkButton>
                                                    </div>
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
                                        <td align="left" valign="top" colspan="2" style="text-align: right;">
                                            <div style="float: right; width: auto; display: inline-block;">
                                                <asp:Button ID="btnNewUp" runat="server" Style="display: inline-block; margin-left: 5px;
                                                    display: inline;" Text="New" OnClientClick="fnDisplayCatchErrorMessage()" OnClick="btnNewUp_Click" />
                                                <asp:Button ID="btnSaveUp" Text="Save" Style="display: inline-block; margin-left: 5px;
                                                    position: static;" runat="server" ImageUrl="~/images/save.png" ValidationGroup="Employee"
                                                    CausesValidation="true" OnClick="btnSaveUp_Click" OnClientClick="return postbackButtonClick();" />
                                                <%--<asp:Button ID="btnCancelUp" Text="Cancel" Style="display: inline-block; margin-left: 5px;"
                                                    runat="server" ImageUrl="~/images/cancle.png" CausesValidation="false" OnClick="btnCancelUp_Click"
                                                    OnClientClick="fnDisplayCatchErrorMessage()" />--%>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litDepartmentID" runat="server" Text="Department Name" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfDepartment" SetFocusOnError="True" Display="Dynamic"
                                                    ControlToValidate="ddlDepartment" ValidationGroup="Employee" InitialValue="00000000-0000-0000-0000-000000000000"
                                                    runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlDepartment" runat="server" Style="width: 202px;" AutoPostBack="true"
                                                OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litEmployeeNO" runat="server" Text="Employee No"></asp:Label>
                                            <%--<span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfEmployeeNo" Display="Dynamic" runat="server" ControlToValidate="txtEmployeeNo"
                                                    CssClass="rfv_ErrorStar" ErrorMessage="*" ValidationGroup="Employee"></asp:RequiredFieldValidator>
                                            </span>--%>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtEmployeeNo" runat="server" MaxLength="60" SkinID="CmpTextbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litSurName" runat="server" Text="Name" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfTitle" Display="Dynamic" SetFocusOnError="True"
                                                    ControlToValidate="ddlTitle" ValidationGroup="Employee" InitialValue="00000000-0000-0000-0000-000000000000"
                                                    runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td style="vertical-align: top;">
                                            <asp:DropDownList ID="ddlTitle" runat="server" Style="width: 202px;">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span class="erroralert" style="float: right;">
                                                <asp:RequiredFieldValidator ID="rvftxtFirstName" Display="Dynamic" SetFocusOnError="True"
                                                    ControlToValidate="txtFirstName" ValidationGroup="Employee" runat="server" ErrorMessage="*"
                                                    CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFirstName" Style="vertical-align: middle;" runat="server" SkinID="CmpTextbox"
                                                MaxLength="90"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtLastName" Style="vertical-align: middle;" runat="server" SkinID="CmpTextbox"
                                                MaxLength="90"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr style="display:none;">
                                        <td>
                                            <asp:Label ID="litBirthDate" runat="server" Text="Date Of Birth" CssClass="RequireFile"></asp:Label>
                                            <%--<span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rfvDate" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                    Display="Dynamic" ControlToValidate="ddlDate" ValidationGroup="Employee" runat="server"
                                                    ErrorMessage="*" InitialValue="00000000-0000-0000-0000-000000000000"></asp:RequiredFieldValidator>
                                            </span>--%>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlDate" runat="server" Style="width: 65px;">
                                            </asp:DropDownList>
                                            <%--<asp:RequiredFieldValidator ID="rvfMonth" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                Display="Dynamic" ControlToValidate="ddlMonth" ValidationGroup="Employee" runat="server"
                                                ErrorMessage="*" InitialValue="00000000-0000-0000-0000-000000000000"></asp:RequiredFieldValidator>--%>
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
                                            <%--<asp:RequiredFieldValidator ID="rvfYear" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                Display="Dynamic" ControlToValidate="ddlYear" ValidationGroup="Employee" runat="server"
                                                ErrorMessage="*" InitialValue="00000000-0000-0000-0000-000000000000"></asp:RequiredFieldValidator>--%>
                                            <asp:DropDownList ID="ddlYear" runat="server" Style="width: 60px;">
                                            </asp:DropDownList>
                                            <div id="ValidDate" runat="server" class="rfv_ErrorStar" visible="false" style="float: right;">
                                                Enter Valid Date</div>
                                        </td>
                                    </tr>
                                    <tr style="display:none;">
                                        <td>
                                            <asp:Literal ID="litNationalityAtBirth" runat="server" Text="Nationality"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBirthNationality" runat="server" MaxLength="65" SkinID="CmpTextbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr style="display:none;">
                                        <td>
                                            <asp:Literal ID="litGender" runat="server" Text="Gender"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlGender" runat="server" Style="width: 202px;">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr style="display:none;">
                                        <td>
                                            <asp:Literal ID="litMaritalStatus" runat="server" Text="Marital Status"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlMartialStatus" runat="server" Style="width: 202px;">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td id="tdMobileNo" runat="server">
                                            <asp:Literal ID="Literal1" runat="server" Text="Mobile No."></asp:Literal>
                                            <%--<span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rfvMobileNo" Display="Dynamic" SetFocusOnError="True" ControlToValidate="txtMobileNo"
                                                    ValidationGroup="Employee" runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                            </span>--%>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMobileCntNo" runat="server" MaxLength="4" Style="width: 45px;"></asp:TextBox>
                                            <ajx:FilteredTextBoxExtender ID="flttxtMobileCntNo" runat="server" TargetControlID="txtMobileCntNo"
                                                FilterMode="ValidChars" ValidChars="1234567890+" />
                                            <asp:TextBox ID="txtMobileNo" runat="server" MaxLength="10" Style="width: 150px;"></asp:TextBox>
                                            <ajx:FilteredTextBoxExtender ID="ftMobileNo" runat="server" TargetControlID="txtMobileNo"
                                                FilterMode="ValidChars" ValidChars="1234567890" />
                                        </td>
                                    </tr>
                                    <tr style="display:none;">
                                        <td>
                                            <asp:Literal ID="Literal2" runat="server" Text="Landline No."></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtLandlineNo" runat="server" MaxLength="15" SkinID="CmpTextbox"></asp:TextBox>
                                            <ajx:FilteredTextBoxExtender ID="ftLandlineNo" runat="server" TargetControlID="txtLandlineNo"
                                                FilterMode="ValidChars" ValidChars="1234567890+-" Enabled="True" />
                                        </td>
                                    </tr>
                                    <tr style="display:none;">
                                        <td colspan="2" class="pagesubheader">
                                            <asp:Literal ID="Literal5" runat="server" Text="Permanent Address"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr style="display:none;">
                                        <td id="tdAddress" runat="server">
                                            <asp:Literal ID="litAddressLine1" runat="server" Text="Address"></asp:Literal>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfAddressLine1" Display="Dynamic" SetFocusOnError="True"
                                                    ControlToValidate="txtAddressLine1" ValidationGroup="Employee" runat="server"
                                                    ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAddressLine1" runat="server" SkinID="Medium" Height="60px" TextMode="MultiLine"
                                                MaxLength="380"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr style="display:none;">
                                        <td id="tdCity" runat="server">
                                            <asp:Literal ID="litCity" runat="server" Text="City "></asp:Literal>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfCity" Display="Dynamic" SetFocusOnError="True"
                                                    CssClass="rfv_ErrorStar" runat="server" ValidationGroup="Employee" ControlToValidate="txtCity"
                                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCity" runat="server" MaxLength="78" SkinID="CmpTextbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr style="display:none;">
                                        <td id="tdPostCode" runat="server">
                                            <asp:Literal ID="litPostCode" runat="server" Text="ZipCode"></asp:Literal>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvftxtPostCode" Display="Dynamic" SetFocusOnError="True"
                                                    CssClass="rfv_ErrorStar" runat="server" ValidationGroup="Employee" ControlToValidate="txtPostCode"
                                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPostCode" runat="server" MaxLength="13" SkinID="CmpTextbox"></asp:TextBox>
                                            <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="txtPostCode"
                                                FilterMode="ValidChars" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890">
                                            </ajx:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    <tr style="display:none;">
                                        <td id="tdState" runat="server">
                                            <asp:Literal ID="litState" runat="server" Text="State"></asp:Literal>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfState" Display="Dynamic" SetFocusOnError="True"
                                                    CssClass="rfv_ErrorStar" runat="server" ValidationGroup="Employee" ControlToValidate="txtState"
                                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtState" runat="server" MaxLength="120" SkinID="CmpTextbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr style="display:none;">
                                        <td id="tdCountry" runat="server">
                                            <asp:Literal ID="litCountry" runat="server" Text="Country"></asp:Literal>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfCountry" Display="Dynamic" SetFocusOnError="True"
                                                    ControlToValidate="txtCountry" ValidationGroup="Employee" runat="server" ErrorMessage="*"
                                                    CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCountry" runat="server" MaxLength="120" SkinID="CmpTextbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr style="display:none;">
                                        <td colspan="2" class="pagesubheader">
                                            <div style="float: left; vertical-align:middle;" class="checkbox_new1">
                                                <asp:Literal ID="LiteralCurrentAddress" runat="server" Text="Current Address"></asp:Literal><%--</div>--%>
                                            <%--<div style="float: left; vertical-align:middle;" class="checkbox_new1">--%>
                                                <asp:CheckBox ID="chkAsAbove" runat="server" onclick="javascript:Copyaddress(this);" Text="As Above" />                                                
                                            </div>
                                        </td>
                                    </tr>
                                    <tr style="display:none;">
                                        <td>
                                            <asp:Literal ID="Literal7" runat="server" Text="Address"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCAddress1" runat="server" SkinID="Medium" Height="60px" TextMode="MultiLine"
                                                MaxLength="380"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr style="display:none;">
                                        <td>
                                            <asp:Literal ID="Literal9" runat="server" Text="City "></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCCity" runat="server" MaxLength="78" SkinID="CmpTextbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr style="display:none;">
                                        <td>
                                            <asp:Literal ID="littxtCPostCode" runat="server" Text="ZipCode"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCPostCode" runat="server" MaxLength="13" SkinID="CmpTextbox"></asp:TextBox>
                                            <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtCPostCode"
                                                FilterMode="ValidChars" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890">
                                            </ajx:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    <tr style="display:none;">
                                        <td>
                                            <asp:Literal ID="Literal10" runat="server" Text="State"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCState" runat="server" MaxLength="120" SkinID="CmpTextbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr style="display:none;">
                                        <td>
                                            <asp:Literal ID="litCCountry" runat="server" Text="Country"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCCountry" runat="server" MaxLength="120" SkinID="CmpTextbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr style="display:none;">
                                        <td colspan="2" class="pagesubheader">
                                            <asp:Literal ID="litOther" runat="server" Text="Other Information"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litEmail" runat="server" Text="Email"></asp:Label>
                                            <asp:HiddenField ID="hfOldEmial" runat="server" />
                                            <span class="erroraleart">
                                                <asp:RegularExpressionValidator ID="refEmail" Display="Dynamic" SetFocusOnError="True"
                                                    ControlToValidate="txtEmail" ValidationGroup="Employee" runat="server" ErrorMessage="*"
                                                    CssClass="rfv_ErrorStar" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                <%--<asp:RequiredFieldValidator ID="rvftxtEmail" SetFocusOnError="True" Display="Dynamic" ControlToValidate="txtEmail"
                                                    ValidationGroup="Employee" runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>--%>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtEmail" runat="server" MaxLength="180" SkinID="CmpTextbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr style="display:none;">
                                        <td>
                                            <asp:Label ID="lblJoinDate" runat="server" Text="Date Of Join" CssClass="RequireFile"></asp:Label>
                                            <%--<span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfDate" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                    Display="Dynamic" ControlToValidate="ddlJDate" ValidationGroup="Employee" runat="server"
                                                    ErrorMessage="*" InitialValue="00000000-0000-0000-0000-000000000000"></asp:RequiredFieldValidator>
                                            </span>--%>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlJDate" runat="server" Style="width: 65px;">
                                            </asp:DropDownList>
                                            <%--<asp:RequiredFieldValidator ID="rvfddlJMonth" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                Display="Dynamic" ControlToValidate="ddlJMonth" ValidationGroup="Employee" runat="server"
                                                ErrorMessage="*" InitialValue="00000000-0000-0000-0000-000000000000"></asp:RequiredFieldValidator>--%>
                                            <asp:DropDownList ID="ddlJMonth" runat="server" Style="width: 70px;">
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
                                            <%--<asp:RequiredFieldValidator ID="rvfJYear" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                Display="Dynamic" ControlToValidate="ddlJYear" ValidationGroup="Employee" runat="server"
                                                ErrorMessage="*" InitialValue="00000000-0000-0000-0000-000000000000"></asp:RequiredFieldValidator>--%>
                                            <asp:DropDownList ID="ddlJYear" runat="server" Style="width: 60px;">
                                            </asp:DropDownList>
                                            <div id="JDate" runat="server" class="rfv_ErrorStar" visible="false" style="float: right;">
                                                Enter Valid Date</div>
                                        </td>
                                    </tr>
                                    <tr style="display:none;">
                                        <td>
                                            <asp:Literal ID="Status" runat="server" Text="Status"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlStatus" runat="server" Style="width: 202px;">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr style="display:none;">
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="chkIsSales" runat="server" Text="Club in Sales Team" AutoPostBack="true"
                                                OnCheckedChanged="chkIsSales_CheckedChanged" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Role" runat="server" Text="Role" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfRole" SetFocusOnError="True" Display="Dynamic"
                                                    ControlToValidate="ddlRole" ValidationGroup="Employee" runat="server" ErrorMessage="*"
                                                    InitialValue="00000000-0000-0000-0000-000000000000" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlRole" runat="server" Style="width: 202px;">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr style="display:none;">
                                        <td colspan="2" class="pagesubheader">
                                            <asp:Literal ID="Literal6" runat="server" Text="Employee ID Proof"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr style="display:none;">
                                        <td width="150px" align="left" valign="top">
                                            <asp:Literal ID="Literal4" runat="server" Text="Upload Employee ID Proof"></asp:Literal>
                                            <span class="erroraleart">
                                                <asp:RegularExpressionValidator ID="revPhoto" runat="server" ControlToValidate="UplodFile"
                                                    SetFocusOnError="true" CssClass="rfv_ErrorStar" ValidationGroup="Employee" Display="Dynamic"
                                                    ErrorMessage="*" ValidationExpression="^.+(.jpg|JPG|.gif|.GIF|.png|.PNG)$"></asp:RegularExpressionValidator>
                                            </span>
                                        </td>
                                        <td align="left" valign="top" colspan="3">
                                            <div id='browse_file_grid'>
                                                <asp:FileUpload ID="UplodFile" runat="server" Height="25px" size="18" ToolTip=".jpg|JPG|.gif|.GIF|.png|.PNG" /></div>
                                            <asp:HiddenField ID="hdnUploadPhoto" runat="server" />
                                        </td>
                                    </tr>
                                    <tr style="display:none;">
                                        <td align="center" valign="top" colspan="2" style="padding-left: 200px;">
                                            <asp:Image ID="imgThumb" runat="server" ImageUrl="~/UploadPhoto/BlankPhoto.jpg" Height="125px"
                                                Width="200px" /><br />
                                            <b>
                                                <asp:LinkButton ID="hypThumb" runat="server" Text="Remove" Style="padding-right: 5px;"
                                                    OnClick="hypThumb_Click"></asp:LinkButton></b>
                                        </td>
                                    </tr>
                                    <tr style="display:none;">
                                        <td align="left" valign="top" colspan="2" style="text-align: right;">
                                            <div style="float: right; width: auto; display: inline-block;">
                                                <asp:Button ID="btnNew" runat="server" Style="display: inline-block; margin-left: 5px;
                                                    display: inline;" Text="New" OnClick="btnNew_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                <asp:Button ID="btnSave" Text="Save" Style="display: inline-block; margin-left: 5px;
                                                    position: static;" runat="server" ImageUrl="~/images/save.png" ValidationGroup="Employee"
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
                                                    Department
                                                </td>
                                                <td style="vertical-align: middle;">
                                                    <asp:DropDownList ID="ddlSearchDepartment" runat="server" SkinID="Search">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="middle" style="vertical-align: middle; margin-top: 7px;">
                                                    Name
                                                </td>
                                                <td style="vertical-align: middle;" colspan="2">
                                                    <asp:TextBox ID="txtSEmployeeName" runat="server" SkinID="Search" MaxLength="90"></asp:TextBox>
                                                    <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                        Style="border: 0px; vertical-align: middle; margin-top: -4px; margin-left: 5px;"
                                                        OnClick="btnSearch_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div>
                                        <div style="height: 1243px; overflow: auto;">
                                            <asp:GridView ID="grdEmployeeList" runat="server" ShowHeader="false" ShowFooter="false"
                                                SkinID="gvNoPaging" AutoGenerateColumns="false" Width="92%" OnRowCommand="grdEmployeeList_RowCommand"
                                                OnRowDataBound="grdEmployeeList_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <div class="rightmargin_grid">
                                                                <div class="leftmargin_contentarea">
                                                                    <strong>
                                                                        <%#DataBinder.Eval(Container.DataItem, "FullName")%></strong><br />
                                                                    <%#DataBinder.Eval(Container.DataItem, "DepartmentName")%><br />
                                                                    <%#DataBinder.Eval(Container.DataItem, "Email")%><br />
                                                                </div>
                                                                <div class="leftmargin_icons">
                                                                    <asp:ImageButton ID="btnEdit" ToolTip="Edit" runat="server" CommandName="EDITCMD"
                                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem, "EmployeeID")%>' ImageUrl="~/images/edit.png"
                                                                        Style="border: 0px; vertical-align: middle; margin-top: 7px; margin-right: 7px;"
                                                                        OnClientClick="fnDisplayCatchErrorMessage()" />
                                                                    <asp:ImageButton ID="btnDelete" runat="server" ToolTip="Delete" CommandName="DELETECMD"
                                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem, "EmployeeID")%>' ImageUrl="~/images/delete_icon.png"
                                                                        Style="border: 0px; vertical-align: middle; margin-top: 7px; margin-right: 7px;"
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
        <!-- Change Email Notification Model Popup !-->
        <ajx:ModalPopupExtender ID="EmailNotification" runat="server" TargetControlID="hfEmailNotification"
            PopupControlID="pnlEmailNotification" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hfEmailNotification" runat="server" />
        <asp:Panel ID="pnlEmailNotification" runat="server" Style="display: none;">
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
                                <asp:HyperLink ID="hypEmailNotification" runat="server">
                                    <asp:Image ImageUrl="~/images/error.png" AlternateText="" Height="75px" Width="75px"
                                        ID="Image2" runat="server" />
                                </asp:HyperLink>
                            </div>
                            <div style="float: left; width: 326px; margin-top: 15px; margin-left: 10px;">
                                <asp:Label ID="lblEmailNotification" runat="server" Text="You have changed your Mail Id .A new Id and Password will be generated for your login and will be sent on new  Mail Id"></asp:Label>
                            </div>
                            <table cellpadding="3" cellspacing="3" width="100%" style="margin-left: 5px; margin-top: 15px;">
                                <tr>
                                    <td align="center" valign="middle">
                                        <asp:Button ID="btnSaveEmailNotification" Text="OK" runat="server" ImageUrl="~/images/save.png"
                                            Style="display: inline-block;" OnClick="btnSaveEmailNotification_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                        <asp:Button ID="btnCancelEmailNotification" Text="Cancel" runat="server" ImageUrl="~/images/cancle.png"
                                            Style="display: inline-block;" OnClick="btnCancelEmailNotification_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
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
        <!-- End Change Email Notification Model Popup !-->
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
                                        ID="Image1" runat="server" />
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
        <asp:PostBackTrigger ControlID="btnSaveUp" />
    </Triggers>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updEmployee" ID="UpdateProgressupdEmployee"
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
