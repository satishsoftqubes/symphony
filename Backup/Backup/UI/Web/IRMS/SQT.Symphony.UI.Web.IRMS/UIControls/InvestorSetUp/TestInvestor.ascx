<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TestInvestor.ascx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.InvestorSetUp.TestInvestor" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
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


            $("#<%=txtRefCountry.ClientID%>").autocomplete('../SetUp/AutoComplete.ashx');
            $("#<%=txtRefState.ClientID%>").autocomplete('../SetUp/StateAutoComplete.ashx');
            $("#<%=txtRefCity.ClientID%>").autocomplete('../SetUp/CityAutoComplete.ashx');


            $("#<%=txtRefCCountry.ClientID%>").autocomplete('../SetUp/AutoComplete.ashx');
            $("#<%=txtRefCState.ClientID%>").autocomplete('../SetUp/StateAutoComplete.ashx');
            $("#<%=txtRefCCity.ClientID%>").autocomplete('../SetUp/CityAutoComplete.ashx');

            $("#<%=txtSTermName.ClientID%>").autocomplete('InvestorAutoComplete.ashx');
        });

        $(function () {
            $("#tabs").tabs();
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
            //            document.getElementById('<%=txtRefCAddress1.ClientID %>').value = document.getElementById('<%=txtCAddress1.ClientID %>').value;
            //            document.getElementById('<%=txtRefCCity.ClientID %>').value = document.getElementById('<%=txtCCity.ClientID%>').value;
            //            document.getElementById('<%=txtRefCState.ClientID%>').value = document.getElementById('<%=txtCState.ClientID%>').value;
            //            document.getElementById('<%=txtRefCCountry.ClientID%>').value = document.getElementById('<%=txtCCountry.ClientID%>').value;
            //            document.getElementById('<%=txtRefCPostCode.ClientID%>').value = document.getElementById('<%=txtCPostCode.ClientID%>').value;
        }
        else {
            document.getElementById('<%=txtCAddress1.ClientID %>').value = "";
            document.getElementById('<%=txtCCity.ClientID %>').value = "";
            document.getElementById('<%=txtCState.ClientID%>').value = "";
            document.getElementById('<%=txtCCountry.ClientID%>').value = "";
            document.getElementById('<%=txtCPostCode.ClientID%>').value = "";
            //            document.getElementById('<%=txtRefCAddress1.ClientID %>').value = "";
            //            document.getElementById('<%=txtRefCCity.ClientID %>').value = "";
            //            document.getElementById('<%=txtRefCState.ClientID%>').value = "";
            //            document.getElementById('<%=txtRefCCountry.ClientID%>').value = "";
            //            document.getElementById('<%=txtRefCPostCode.ClientID%>').value = "";
        }
    }
    function CopayRefAddress(chk) {
        var obj = chk;
        if (obj.checked == true) {
            document.getElementById('<%=txtRefCAddress1.ClientID %>').value = document.getElementById('<%=txtRefAddress1.ClientID %>').value;
            document.getElementById('<%=txtRefCCity.ClientID %>').value = document.getElementById('<%=txtRefCity.ClientID%>').value;
            document.getElementById('<%=txtRefCState.ClientID%>').value = document.getElementById('<%=txtRefState.ClientID%>').value;
            document.getElementById('<%=txtRefCCountry.ClientID%>').value = document.getElementById('<%=txtRefCountry.ClientID%>').value;
            document.getElementById('<%=txtRefCPostCode.ClientID%>').value = document.getElementById('<%=txtRefPostCode.ClientID%>').value;
        }
        else {
            document.getElementById('<%=txtRefCAddress1.ClientID %>').value = "";
            document.getElementById('<%=txtRefCCity.ClientID %>').value = "";
            document.getElementById('<%=txtRefCState.ClientID%>').value = "";
            document.getElementById('<%=txtRefCCountry.ClientID%>').value = "";
            document.getElementById('<%=txtRefCPostCode.ClientID%>').value = "";
        }
    }

    function NomineeAddress(chk) {
        var obj = chk;
        if (obj.checked == true) {
            document.getElementById('<%= txtRefAddress1.ClientID %>').value = document.getElementById('<%= txtAddressLine1.ClientID %>').value;
            document.getElementById('<%= txtRefCity.ClientID %>').value = document.getElementById('<%= txtCity.ClientID %>').value;
            document.getElementById('<%= txtRefPostCode.ClientID %>').value = document.getElementById('<%= txtPostCode.ClientID %>').value;
            document.getElementById('<%= txtRefState.ClientID %>').value = document.getElementById('<%= txtState.ClientID %>').value;
            document.getElementById('<%= txtRefCountry.ClientID %>').value = document.getElementById('<%= txtCountry.ClientID %>').value;
        }
        else {
            document.getElementById('<%= txtRefAddress1.ClientID %>').value = "";
            document.getElementById('<%= txtRefCity.ClientID %>').value = "";
            document.getElementById('<%= txtRefPostCode.ClientID %>').value = "";
            document.getElementById('<%= txtRefState.ClientID %>').value = "";
            document.getElementById('<%= txtRefCountry.ClientID %>').value = "";
        }
    }


    function CopayRefAddress2JO(chk) {
        var obj = chk;
        if (obj.checked == true) {
            document.getElementById('<%=txt2JOPostalAddress.ClientID %>').value = document.getElementById('<%=txt2JOAddress.ClientID %>').value;
            document.getElementById('<%=txt2JOPostalCity.ClientID %>').value = document.getElementById('<%=txt2JOCity.ClientID%>').value;
            document.getElementById('<%=txt2JOPostalState.ClientID%>').value = document.getElementById('<%=txt2JOState.ClientID%>').value;
            document.getElementById('<%=txt2JOPostalCountry.ClientID%>').value = document.getElementById('<%=txt2JOCountry.ClientID%>').value;
            document.getElementById('<%=txt2JOPostalZipCode.ClientID%>').value = document.getElementById('<%=txt2JOZipCode.ClientID%>').value;
        }
        else {
            document.getElementById('<%=txt2JOPostalAddress.ClientID %>').value = "";
            document.getElementById('<%=txt2JOPostalCity.ClientID %>').value = "";
            document.getElementById('<%=txt2JOPostalState.ClientID%>').value = "";
            document.getElementById('<%=txt2JOPostalCountry.ClientID%>').value = "";
            document.getElementById('<%=txt2JOPostalZipCode.ClientID%>').value = "";
        }
    }

    function NomineeAddress2JO(chk) {
        var obj = chk;
        if (obj.checked == true) {
            document.getElementById('<%= txt2JOAddress.ClientID %>').value = document.getElementById('<%= txtAddressLine1.ClientID %>').value;
            document.getElementById('<%= txt2JOCity.ClientID %>').value = document.getElementById('<%= txtCity.ClientID %>').value;
            document.getElementById('<%= txt2JOZipCode.ClientID %>').value = document.getElementById('<%= txtPostCode.ClientID %>').value;
            document.getElementById('<%= txt2JOState.ClientID %>').value = document.getElementById('<%= txtState.ClientID %>').value;
            document.getElementById('<%= txt2JOCountry.ClientID %>').value = document.getElementById('<%= txtCountry.ClientID %>').value;
        }
        else {
            document.getElementById('<%= txt2JOAddress.ClientID %>').value = "";
            document.getElementById('<%= txt2JOCity.ClientID %>').value = "";
            document.getElementById('<%= txt2JOZipCode.ClientID %>').value = "";
            document.getElementById('<%= txt2JOState.ClientID %>').value = "";
            document.getElementById('<%= txt2JOCountry.ClientID %>').value = "";
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
        if (Page_ClientValidate("Configuration")) {
            document.getElementById('errormessage').style.display = "block";
            updateProgress = $find("<%= UpdateProgressInvestor.ClientID %>");
            window.setTimeout("updateProgress.set_visible(true)", updateProgress.get_displayAfter());
            return true;
        }
        else {
            return false;
        }
    }
</script>
<asp:UpdatePanel ID="pnlUpdt" runat="server">
    <ContentTemplate>
        <asp:HiddenField ID="hidden1" runat="server" />
        <script type="text/javascript">
            function investors(str) {
                document.getElementById('lblInvestorName').innerHTML = str;
            }
        </script>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td style="padding-left: 0px; width: 66.66%">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                INVESTOR
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
                                <div style="height: 26px; margin: 10px 0px;">
                                    <%if (IsInsert)
                                      { %>
                                    <div class="ResetSuccessfully">
                                        <div style="float: left; padding-top: 7px; width: 25px; height: 24px; margin-right: 10px;">
                                            <img src="../../images/success.png" />
                                        </div>
                                        <div>
                                            <asp:Label ID="lblInvestorMsg" runat="server"></asp:Label></div>
                                        <div style="height: 10px;">
                                        </div>
                                    </div>
                                    <% }%>
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
                            <td class="boxright">
                            </td>
                        </tr>
                        <tr>
                            <td class="boxleft">
                                &nbsp;
                            </td>
                            <td>
                                <div style="float: right;">
                                    <b>All Bold Fields are Mandatory</b>
                                </div>
                            </td>
                            <td class="boxright">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="boxleft">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="boxright">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="boxleft">
                                &nbsp;
                            </td>
                            <td style="text-align: right;">
                                <div style="float: right; width: auto; display: inline-block;">
                                    <asp:Button ID="btnSaveUp" Text="Save" Style="margin-left: 5px; display: inline-block;"
                                        runat="server" ImageUrl="~/images/save.png" ValidationGroup="Configuration" OnClick="btnSaveUp_Click"
                                        OnClientClick="return postbackButtonClick();" />
                                    <asp:Button ID="btnCancelUp" Text="Cancel" Style="margin-left: 5px; display: inline-block;"
                                        runat="server" ImageUrl="~/images/cancle.png" CausesValidation="False" OnClick="btnCancel_Click"
                                        OnClientClick="fnDisplayCatchErrorMessage()" />
                                </div>
                            </td>
                            <td class="boxright">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="boxleft">
                                &nbsp;
                            </td>
                            <td>
                                <br />
                                <div class="demo">
                                    <div id="tabs">
                                        <ul>
                                            <li><a href="#tabs-1">First Owner</a></li>
                                            <li><a href="#tabs-2">Joint Owner</a></li>
                                            <li><a href="#tabs-3">2nd Joint Owner</a></li>
                                        </ul>
                                        <div id="tabs-1">
                                            <div style="height: 1750px;">
                                                <table width="100%" cellpadding="3" cellspacing="3">
                                                    <tr>
                                                        <td style="width: 150px;">
                                                            <asp:Label ID="litSurName" runat="server" Text="Name" CssClass="RequireFile"></asp:Label>
                                                            <span class="erroraleart">
                                                                <asp:RequiredFieldValidator ID="rvfTitle" SetFocusOnError="True" ControlToValidate="ddlTitle"
                                                                    ValidationGroup="Configuration" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                    runat="server" ErrorMessage="*" Display="Dynamic" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                                            </span>
                                                        </td>
                                                        <td style="vertical-align: top;">
                                                            <asp:DropDownList ID="ddlTitle" runat="server" Style="width: 100px;">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <span class="erroralert" style="float: right;">
                                                                <asp:RequiredFieldValidator ID="rvftxtFirstName" SetFocusOnError="True" ControlToValidate="txtFirstName"
                                                                    ValidationGroup="Configuration" Display="Dynamic" runat="server" ErrorMessage="*"
                                                                    CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                                            </span>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtFirstName" Style="vertical-align: middle;" runat="server" SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtLastName" Style="vertical-align: middle;" runat="server" SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:HiddenField ID="hfOldEmial" runat="server" />
                                                            <asp:Label ID="litEMail" runat="server" Text="Email"></asp:Label>
                                                            <span class="erroraleart">
                                                                <asp:RegularExpressionValidator ID="refEmail" Display="Dynamic" SetFocusOnError="True"
                                                                    ControlToValidate="txtEmail" ValidationGroup="Configuration" runat="server" ErrorMessage="*"
                                                                    CssClass="rfv_ErrorStar" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                            </span>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtEmail" runat="server" SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="litMobileNo" runat="server" Text="Mobile No."></asp:Label>
                                                            <%--<span class="erroraleart">
                                                                <asp:RequiredFieldValidator ID="rvftxtMobileNo" Display="Dynamic" SetFocusOnError="True"
                                                                    ControlToValidate="txtMobileNo" ValidationGroup="Configuration" runat="server"
                                                                    ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                                            </span>--%>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtMobileCntCode" runat="server" MaxLength="4" Style="width: 45px;"></asp:TextBox>
                                                            <ajx:FilteredTextBoxExtender ID="fltCountryCode" runat="server" TargetControlID="txtMobileCntCode"
                                                                FilterMode="ValidChars" ValidChars="1234567890+" Enabled="True" />
                                                            <asp:TextBox ID="txtMobileNo" runat="server" MaxLength="12" Style="width: 150px;"></asp:TextBox>
                                                            <ajx:FilteredTextBoxExtender ID="flttxtMobileNo" runat="server" TargetControlID="txtMobileNo"
                                                                FilterMode="ValidChars" ValidChars="1234567890" Enabled="True" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litLandlineNo" runat="server" Text="Landline No."></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtLandLineNo" runat="server" MaxLength="15" SkinID="CmpTextbox"></asp:TextBox>
                                                            <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" TargetControlID="txtLandLineNo"
                                                                FilterMode="ValidChars" ValidChars="1234567890+-" Enabled="True" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblRefernceThrow" runat="server" Text="Reference Through"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlReferenceThrow" runat="server" Style="width: 202px;">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="litRefrence" runat="server" Text="Reference Name"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtRefrence" runat="server" SkinID="CmpTextbox" MaxLength="180"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" class="pagesubheader">
                                                            <asp:Literal ID="litRepresentativeDetails" runat="server" Text="Representative Details"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Literal13" runat="server" Text="Representative Name"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtContactPersonName" runat="server" SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Literal11" runat="server" Text="Representative Relation"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtRelationalName" runat="server" SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Literal14" runat="server" Text="Representative Email"></asp:Label>
                                                            <span class="erroraleart">
                                                                <asp:RegularExpressionValidator ID="rfvgtxtContactPersonEmail" Display="Dynamic"
                                                                    SetFocusOnError="True" ControlToValidate="txtContactPersonEmail" ValidationGroup="Configuration"
                                                                    runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                            </span>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtContactPersonEmail" runat="server" SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Literal7" runat="server" Text="Representative Contact"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtContactPersonMobile" runat="server" MaxLength="15" SkinID="CmpTextbox"></asp:TextBox>
                                                            <ajx:FilteredTextBoxExtender ID="flttxtContactPersonMobile" runat="server" TargetControlID="txtContactPersonMobile"
                                                                FilterType="Custom" ValidChars="+-0123456789" FilterMode="ValidChars" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" class="pagesubheader">
                                                            <asp:Literal ID="Literal5" runat="server" Text="Agreement Address"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td id="tdAddress1" runat="server">
                                                            <asp:Literal ID="litAddressLine1" runat="server" Text="Address"></asp:Literal>
                                                            <span class="erroraleart">
                                                                <asp:RequiredFieldValidator ID="rvfAddressLine1" Display="Dynamic" SetFocusOnError="True"
                                                                    ControlToValidate="txtAddressLine1" ValidationGroup="Configuration" runat="server"
                                                                    ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                                            </span>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtAddressLine1" runat="server" SkinID="Medium" TextMode="MultiLine"
                                                                Height="60px" MaxLength="300"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td id="tdCity" runat="server">
                                                            <asp:Literal ID="litCity" runat="server" Text="City "></asp:Literal>
                                                            <span class="erroraleart">
                                                                <asp:RequiredFieldValidator ID="rvfCity" Display="Dynamic" SetFocusOnError="True"
                                                                    CssClass="rfv_ErrorStar" runat="server" ValidationGroup="Configuration" ControlToValidate="txtCity"
                                                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                                                            </span>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCity" runat="server" SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td id="tdPostCode" runat="server">
                                                            <asp:Literal ID="litPostCode" runat="server" Text="ZipCode"></asp:Literal>
                                                            <span class="erroraleart">
                                                                <asp:RequiredFieldValidator ID="rvftxtPostCode" Display="Dynamic" SetFocusOnError="True"
                                                                    CssClass="rfv_ErrorStar" runat="server" ValidationGroup="Configuration" ControlToValidate="txtPostCode"
                                                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                                                            </span>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPostCode" runat="server" MaxLength="10" SkinID="CmpTextbox"></asp:TextBox>
                                                            <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtPostCode"
                                                                FilterMode="ValidChars" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890">
                                                            </ajx:FilteredTextBoxExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td id="tdState" runat="server">
                                                            <asp:Literal ID="litState" runat="server" Text="State"></asp:Literal>
                                                            <span class="erroraleart">
                                                                <asp:RequiredFieldValidator ID="rvfState" Display="Dynamic" SetFocusOnError="True"
                                                                    CssClass="rfv_ErrorStar" runat="server" ValidationGroup="Configuration" ControlToValidate="txtState"
                                                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                                                            </span>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtState" runat="server" SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td id="tdCountry" runat="server">
                                                            <asp:Literal ID="litCountry" runat="server" Text="Country"></asp:Literal>
                                                            <span class="erroraleart">
                                                                <asp:RequiredFieldValidator ID="rvfCountry" Display="Dynamic" SetFocusOnError="True"
                                                                    ControlToValidate="txtCountry" ValidationGroup="Configuration" runat="server"
                                                                    ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                                            </span>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCountry" runat="server" SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="litRegion" runat="server" Text="Region"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlEnteryRegion" runat="server" Style="width: 202px;">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" class="pagesubheader">
                                                            <div style="float: left; vertical-align:middle;" class="checkbox_new1">
                                                                <asp:Literal ID="litCAddressInfo" runat="server" Text="Postal Address"></asp:Literal>
                                                            <%--</div>
                                                            <div style="float: right;" class="checkbox_new1">--%>
                                                                <asp:CheckBox ID="chk" runat="server" onclick="javascript:Copyaddress(this);" Text="As Above" />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litCAddress1" runat="server" Text="Address"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCAddress1" runat="server" SkinID="Medium" TextMode="MultiLine"
                                                                Height="60px" MaxLength="300"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litCCity" runat="server" Text="City"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCCity" runat="server" SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="littxtCPostCode" runat="server" Text="ZipCode"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCPostCode" runat="server" MaxLength="10" SkinID="CmpTextbox"></asp:TextBox>
                                                            <ajx:FilteredTextBoxExtender ID="fltPostCode" runat="server" TargetControlID="txtCPostCode"
                                                                FilterMode="ValidChars" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890">
                                                            </ajx:FilteredTextBoxExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litCState" runat="server" Text="State"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCState" runat="server" SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litCCountry" runat="server" Text="Country"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCCountry" runat="server" SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" class="pagesubheader">
                                                            <asp:Literal ID="Literal8" runat="server" Text="Other Info"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litAge" runat="server" Text="Age"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtAge" runat="server" MaxLength="5" SkinID="CmpTextbox"></asp:TextBox>
                                                            <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtAge"
                                                                FilterType="Numbers" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litPANNo" runat="server" Text="PAN No"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPANNo" runat="server" MaxLength="10" SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litPOAHolder" runat="server" Text="POA Holder"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPOAHolder" runat="server" MaxLength="10" SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litBankName" runat="server" Text="Bank Name"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtBankName" runat="server" MaxLength="25" SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litAccNo" runat="server" Text="Bank Account No."></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtBankAccNo" runat="server" MaxLength="20" SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litIFSCCode" runat="server" Text="IFSC Code"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtIFSCCode" runat="server" MaxLength="16" SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" class="pagesubheader">
                                                            <asp:Literal ID="Literal4" runat="server" Text="Professional Information"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litOccupationTerm" runat="server" Text="Occupation"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlOccupationTermID" runat="server" Style="width: 202px;">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litCompanyName" runat="server" Text="Company Name"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCompanyName" runat="server" SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litDesignation" runat="server" Text="Designation"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtDesignation" runat="server" MaxLength="25" SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" class="pagesubheader">
                                                            <asp:Literal ID="Literal6" runat="server" Text="Relationship Information"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="litManagerType" runat="server" Text="Relationship Through" CssClass="RequireFile"></asp:Label>
                                                            <span class="erroraleart">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" SetFocusOnError="True"
                                                                    ControlToValidate="ddlManagerType" ValidationGroup="Configuration" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                    runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                                            </span>
                                                        </td>
                                                        <td>
                                                            <div>
                                                                <asp:DropDownList ID="ddlManagerType" AutoPostBack="true" OnSelectedIndexChanged="ddlManagerType_SelectedIndexChanged"
                                                                    runat="server" Style="width: 202px;">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="litRelationManagerID" runat="server" Text="Name" CssClass="RequireFile"></asp:Label>
                                                            <span class="erroraleart">
                                                                <asp:RequiredFieldValidator ID="rvfddlRelationManagementID" Display="Dynamic" SetFocusOnError="True"
                                                                    ControlToValidate="ddlRelationManagementID" ValidationGroup="Configuration" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                    runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                                            </span>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlRelationManagementID" AutoPostBack="true" OnSelectedIndexChanged="ddlRelationManagementID_SelectedIndexChanged"
                                                                runat="server" Style="width: 202px;">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr id="trFirmName" runat="server">
                                                        <td>
                                                            <asp:Literal ID="litNameOfFirm" runat="server" Text="Name Of Firm"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtNameOfFirm" runat="server" SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litManagerContactNo" runat="server" Text="Contact No."></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtManagerContactNo" runat="server" MaxLength="15" SkinID="CmpTextbox"></asp:TextBox>
                                                            <ajx:FilteredTextBoxExtender ID="fttxtManagerContactNo" runat="server" TargetControlID="txtManagerContactNo"
                                                                FilterMode="ValidChars" ValidChars="1234567890+-" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litManagerEmail" runat="server" Text="Email"></asp:Literal>
                                                            <span class="erroraleart">
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic"
                                                                    SetFocusOnError="True" ControlToValidate="txtManagerEmail" ValidationGroup="Configuration"
                                                                    runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                            </span>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtManagerEmail" runat="server" SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" class="pagesubheader">
                                                            <asp:Literal ID="Literal15" runat="server" Text="Uniworld Relationship"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="Literal16" runat="server" Text="Relationship Manager"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlEmployee" AutoPostBack="true" OnSelectedIndexChanged="ddlEmployee_SelectedIndexChanged"
                                                                runat="server" Style="width: 202px;">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litPrimeMobileNo" runat="server" Text="Contact No"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPrimeMobileNo" runat="server" MaxLength="15" SkinID="CmpTextbox"></asp:TextBox>
                                                            <ajx:FilteredTextBoxExtender ID="fttxtPrimeMobileNo" runat="server" TargetControlID="txtPrimeMobileNo"
                                                                FilterMode="ValidChars" ValidChars="1234567890+-" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litPrimeEmail" runat="server" Text="Email"></asp:Literal>
                                                            <span class="erroraleart">
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Display="Dynamic"
                                                                    SetFocusOnError="True" ControlToValidate="txtPrimeEmail" ValidationGroup="Configuration"
                                                                    runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                            </span>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPrimeEmail" runat="server" SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <%--<tr>
                                                        <td colspan="2" class="pagesubheader">
                                                            <asp:Literal ID="Literal12" runat="server" Text="Communication SetUp"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td class="checkbox_new">
                                                            <asp:CheckBox ID="chkIsSMS" runat="server" Text="SMS" Checked="true" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td class="checkbox_new">
                                                            <asp:CheckBox ID="chkIsEmail" runat="server" Text="Email" Checked="true" />
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td colspan="2" class="pagesubheader">
                                                            <asp:Literal ID="LitPhotoInfo" runat="server" Text="Visiting Card"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="140px" align="left" valign="top">
                                                            <asp:Literal ID="Literal1" runat="server" Text="Upload Visiting Card"></asp:Literal>
                                                            <span class="erroraleart">
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" Display="Dynamic"
                                                                    runat="server" ControlToValidate="UplodFile" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                                    ValidationGroup="Configuration" ErrorMessage="*" ValidationExpression="^.+(.jpg|JPG|.gif|.GIF|.png|.PNG)$"></asp:RegularExpressionValidator>
                                                            </span>
                                                        </td>
                                                        <td align="left" valign="top" colspan="3">
                                                            <div id='browse_file_grid'>
                                                                <asp:FileUpload ID="UplodFile" runat="server" Height="25px" size="18" ToolTip=".jpg|JPG|.gif|.GIF|.png|.PNG" /></div>
                                                            <asp:HiddenField ID="hdnUploadPhoto" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="140px" align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            <asp:Image ID="imgInvPhoto" runat="server" ImageUrl="~/UploadPhoto/BusinessCard.png"
                                                                Height="125px" Width="200px" /><br />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="140px" align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="right" valign="top" style="padding-right: 132px;">
                                                            <b>
                                                                <asp:LinkButton ID="HypRemove" runat="server" Text="Remove" OnClick="HypRemove_Click"></asp:LinkButton></b>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                        <div id="tabs-2">
                                            <div style="height: 1650px;">
                                                <table width="100%" cellpadding="3" cellspacing="3">
                                                    <tr>
                                                        <td style="width: 130px;">
                                                            <asp:Label ID="Literal10" runat="server" Text="Name"></asp:Label>
                                                        </td>
                                                        <td style="vertical-align: top;">
                                                            <asp:DropDownList ID="dllRefTitle" runat="server" Style="width: 100px;">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtRefFirstName" Style="vertical-align: middle;" runat="server"
                                                                SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtRefLastName" Style="vertical-align: middle;" runat="server" SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="littxtRefEmail" runat="server" Text="Email"></asp:Label>
                                                            <span class="erroraleart">
                                                                <asp:RegularExpressionValidator ID="reptxtRefEmail" Display="Dynamic" SetFocusOnError="true"
                                                                    ControlToValidate="txtRefEmail" ValidationGroup="Configuration" runat="server"
                                                                    ErrorMessage="*" CssClass="rfv_ErrorStar" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                            </span>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtRefEmail" runat="server" SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="littxtRefMobileNO" runat="server" Text="Mobile No."></asp:Label>
                                                            <%--<span class="erroraleart">
                                                                <asp:RequiredFieldValidator ID="rvftxtRefMobileNO" Display="Dynamic" SetFocusOnError="true"
                                                                    ControlToValidate="txtRefMobileNO" ValidationGroup="Configuration" runat="server"
                                                                    ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                                            </span>--%>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtRefMobileCntNo" runat="server" MaxLength="4" Style="width: 45px;"></asp:TextBox>
                                                            <ajx:FilteredTextBoxExtender ID="flttxtRefMobileCntNo" runat="server" TargetControlID="txtRefMobileCntNo"
                                                                FilterMode="ValidChars" ValidChars="1234567890+" />
                                                            <asp:TextBox ID="txtRefMobileNO" runat="server" MaxLength="12" Style="width: 150px;"></asp:TextBox>
                                                            <ajx:FilteredTextBoxExtender ID="flttxtRefMobileNO" runat="server" TargetControlID="txtRefMobileNO"
                                                                FilterMode="ValidChars" ValidChars="1234567890" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="littxtRefLandLineNo" runat="server" Text="Landline No."></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtRefLandLineNo" runat="server" MaxLength="15" SkinID="CmpTextbox"></asp:TextBox>
                                                            <ajx:FilteredTextBoxExtender ID="flttxtRefLandLineNo" runat="server" TargetControlID="txtRefLandLineNo"
                                                                FilterMode="ValidChars" ValidChars="1234567890+-" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" class="pagesubheader">
                                                            <div style="float: left; vertical-align:middle;" class="checkbox_new1">
                                                                <asp:Literal ID="Literal9" runat="server" Text="Agreement Address"></asp:Literal>
                                                            <%--</div>
                                                            <div style="float: right;" class="checkbox_new1">--%>
                                                                <asp:CheckBox ID="chkSameasFirstOwner" runat="server" onclick="javascript:NomineeAddress(this);"
                                                                    Text="Same As First Owner" />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="Literal2" runat="server" Text="Address"></asp:Literal>
                                                            <%--<span class="erroraleart">
                                                                <asp:RequiredFieldValidator ID="rvftxtRefStreet" Display="Dynamic" SetFocusOnError="true"
                                                                    ControlToValidate="txtRefAddress1" ValidationGroup="Configuration" runat="server"
                                                                    ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                                            </span>--%>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtRefAddress1" runat="server" SkinID="Medium" TextMode="MultiLine"
                                                                Height="60px" MaxLength="300"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="Literal24" runat="server" Text="City "></asp:Literal>
                                                            <%--<span class="erroraleart">
                                                                <asp:RequiredFieldValidator ID="rvftxtRefPCity" Display="Dynamic" SetFocusOnError="true"
                                                                    CssClass="rfv_ErrorStar" runat="server" ValidationGroup="Configuration" ControlToValidate="txtRefCity"
                                                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                                                            </span>--%>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtRefCity" runat="server" SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="Literal28" runat="server" Text="Zip Code"></asp:Literal>
                                                            <%--<span class="erroraleart">
                                                                <asp:RequiredFieldValidator ID="frvRefPostCode" Display="Dynamic" SetFocusOnError="true"
                                                                    CssClass="rfv_ErrorStar" runat="server" ValidationGroup="Configuration" ControlToValidate="txtRefPostCode"
                                                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                                                            </span>--%>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtRefPostCode" runat="server" MaxLength="10" SkinID="CmpTextbox"></asp:TextBox>
                                                            <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txtRefPostCode"
                                                                FilterMode="ValidChars" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890">
                                                            </ajx:FilteredTextBoxExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="littxtRefPState" runat="server" Text="State"></asp:Literal>
                                                            <%--<span class="erroraleart">
                                                                <asp:RequiredFieldValidator ID="rvftxtRefPState" Display="Dynamic" SetFocusOnError="true"
                                                                    CssClass="rfv_ErrorStar" runat="server" ValidationGroup="Configuration" ControlToValidate="txtRefState"
                                                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                                                            </span>--%>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtRefState" runat="server" SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="littxtRefPCountry" runat="server" Text="Country"></asp:Literal>
                                                            <%--<span class="erroraleart">
                                                                <asp:RequiredFieldValidator ID="rvftxtRefPCountry" Display="Dynamic" SetFocusOnError="true"
                                                                    ControlToValidate="txtRefCountry" ValidationGroup="Configuration" runat="server"
                                                                    ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                                            </span>--%>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtRefCountry" runat="server" SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" class="pagesubheader">
                                                            <div style="float: left; vertical-align:middle;" class="checkbox_new1">
                                                                <asp:Literal ID="Literal17" runat="server" Text="Postal Address"></asp:Literal>
                                                             <%--</div>
                                                            <div style="float: right; text-align: center;" class="checkbox_new1">--%>
                                                                <asp:CheckBox ID="chkRefAsAbove" runat="server" style="margin-left:27px;" onclick="javascript:CopayRefAddress(this);"
                                                                    Text="As Above" />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="littxtRefCStreetAddress" runat="server" Text="Address"></asp:Literal>
                                                            <%--<span class="erroraleart">
                                                                <asp:RequiredFieldValidator ID="rvftxtRefCStreetAddress" SetFocusOnError="true" ControlToValidate="txtRefCAddress1"
                                                                    ValidationGroup="Configuration" runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                                            </span>--%>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtRefCAddress1" runat="server" SkinID="Medium" TextMode="MultiLine"
                                                                Height="60px" MaxLength="300"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <%--<tr>
                                                        <td>
                                                            <asp:Literal ID="littxtRefCAddress1" runat="server" Text="Area"></asp:Literal>
                                                        </td>
                                                        <td colspan="3">
                                                            <asp:TextBox ID="txtRefCAddress2" runat="server" SkinID="Small_Long" TextMode="MultiLine"
                                                                Height="40px"></asp:TextBox>
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="littxtCRefCCity" runat="server" Text="City "></asp:Literal>
                                                            <%--<span class="erroraleart">
                                                                <asp:RequiredFieldValidator ID="rvftxtCRefCCity" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                                    runat="server" ValidationGroup="Configuration" ControlToValidate="txtRefCCity"
                                                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                                                            </span>--%>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtRefCCity" runat="server" SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="littxtRefCPostCode" runat="server" Text="Zip Code"></asp:Literal>
                                                            <%--<span class="erroraleart">
                                                                <asp:RequiredFieldValidator ID="rvftxtRefCPostCode" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                                    runat="server" ValidationGroup="Configuration" ControlToValidate="txtRefCPostCode"
                                                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                                                            </span>--%>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtRefCPostCode" runat="server" MaxLength="10" SkinID="CmpTextbox"></asp:TextBox>
                                                            <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="txtRefCPostCode"
                                                                FilterMode="ValidChars" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890">
                                                            </ajx:FilteredTextBoxExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="littxtRefCState" runat="server" Text="State"></asp:Literal>
                                                            <%--<span class="erroraleart">
                                                                <asp:RequiredFieldValidator ID="rvftxtRefCState" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                                    runat="server" ValidationGroup="Configuration" ControlToValidate="txtRefCState"
                                                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                                                            </span>--%>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtRefCState" runat="server" SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="littxtCRefCCountry" runat="server" Text="Country"></asp:Literal>
                                                            <%-- <span class="erroraleart">
                                                                <asp:RequiredFieldValidator ID="rvftxtCRefCCountry" SetFocusOnError="true" ControlToValidate="txtRefCCountry"
                                                                    ValidationGroup="Configuration" runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                                            </span>--%>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtRefCCountry" runat="server" SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" class="pagesubheader">
                                                            <asp:Literal ID="Literal25" runat="server" Text="Other Info"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litRefAge" runat="server" Text="Age"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtRefAge" runat="server" MaxLength="5" SkinID="CmpTextbox"></asp:TextBox>
                                                            <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtRefAge"
                                                                FilterType="Numbers" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litRefPANNo" runat="server" Text="PAN No"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtRefPANNo" runat="server" SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litRefPOAHolder" runat="server" Text="POA Holder"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtRefPOAHolder" runat="server" SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litRefBankName" runat="server" Text="Bank Name"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtRefBankNo" runat="server" SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litRefBankAccNO" runat="server" Text="Bank Account No."></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtRefBankAccNo" runat="server" MaxLength="20" SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litRefIFSCCode" runat="server" Text="IFSC Code"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtRefIFSCCode" runat="server" MaxLength="16" SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" class="pagesubheader">
                                                            <asp:Literal ID="litRefProfessionalInformation" runat="server" Text="Professional Information"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litRefOccupation" runat="server" Text="Occupation"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlRefOccupation" runat="server" Style="width: 202px;">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litRefCompanyName" runat="server" Text="Company Name"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtRefCompanyName" runat="server" SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litRefDesignation" runat="server" Text="Designation"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtRefDesignation" runat="server" MaxLength="15" SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                        <div id="tabs-3">
                                            <div style="height: 1650px;">
                                                <table width="100%" cellpadding="3" cellspacing="3">
                                                    <tr>
                                                        <td style="width: 130px;">
                                                            <asp:Label ID="lbl2JOName" runat="server" Text="Name"></asp:Label>
                                                        </td>
                                                        <td style="vertical-align: top;">
                                                            <asp:DropDownList ID="ddl2JOTitle" runat="server" Style="width: 100px;">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txt2JOFirstName" Style="vertical-align: middle;" runat="server"
                                                                SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txt2JOLastName" Style="vertical-align: middle;" runat="server" SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lbl2JOEmail" runat="server" Text="Email"></asp:Label>
                                                            <span class="erroraleart">
                                                                <asp:RegularExpressionValidator ID="rev2JOEmail" Display="Dynamic" SetFocusOnError="true"
                                                                    ControlToValidate="txt2JOEmail" ValidationGroup="Configuration" runat="server"
                                                                    ErrorMessage="*" CssClass="rfv_ErrorStar" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                            </span>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txt2JOEmail" runat="server" SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lbl2JOMobile" runat="server" Text="Mobile No."></asp:Label>
                                                           
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txt2JOMobilecode" runat="server" MaxLength="4" Style="width: 45px;"></asp:TextBox>
                                                            <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txt2JOMobilecode"
                                                                FilterMode="ValidChars" ValidChars="1234567890+" />
                                                            <asp:TextBox ID="txt2JOMobileNo" runat="server" MaxLength="12" Style="width: 150px;"></asp:TextBox>
                                                            <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" TargetControlID="txt2JOMobileNo"
                                                                FilterMode="ValidChars" ValidChars="1234567890" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="lbl2JOLandlineNo" runat="server" Text="Landline No."></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txt2JOLandlineNo" runat="server" MaxLength="15" SkinID="CmpTextbox"></asp:TextBox>
                                                            <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" TargetControlID="txt2JOLandlineNo"
                                                                FilterMode="ValidChars" ValidChars="1234567890+-" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" class="pagesubheader">
                                                            <div style="float: left; vertical-align:middle;" class="checkbox_new1">
                                                                <asp:Literal ID="lbl2JOAgreementAddress" runat="server" Text="Agreement Address"></asp:Literal>
                                                            
                                                                <asp:CheckBox ID="chk2JOSameasFirstOwner" runat="server" onclick="javascript:NomineeAddress2JO(this);"
                                                                    Text="Same As First Owner" />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="lit2JOAddress" runat="server" Text="Address"></asp:Literal>
                                                           
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txt2JOAddress" runat="server" SkinID="Medium" TextMode="MultiLine"
                                                                Height="60px" MaxLength="300"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="lit2JOCity" runat="server" Text="City "></asp:Literal>
                                                            
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txt2JOCity" runat="server" SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="lit2JOZipCode" runat="server" Text="Zip Code"></asp:Literal>
                                                           
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txt2JOZipCode" runat="server" MaxLength="10" SkinID="CmpTextbox"></asp:TextBox>
                                                            <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server" TargetControlID="txt2JOZipCode"
                                                                FilterMode="ValidChars" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890">
                                                            </ajx:FilteredTextBoxExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="lit2JOState" runat="server" Text="State"></asp:Literal>
                                                            
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txt2JOState" runat="server" SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="lit2JOCountry" runat="server" Text="Country"></asp:Literal>
                                                           
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txt2JOCountry" runat="server" SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" class="pagesubheader">
                                                            <div style="float: left; vertical-align:middle;" class="checkbox_new1">
                                                                <asp:Literal ID="lithd2JOPostalAddress" runat="server" Text="Postal Address"></asp:Literal>
                                                            
                                                                <asp:CheckBox ID="chk2JOAsAbove" runat="server" style="margin-left:27px;" onclick="javascript:CopayRefAddress2JO(this);"
                                                                    Text="As Above" />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="lit2JOPostalAddress" runat="server" Text="Address"></asp:Literal>
                                                            
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txt2JOPostalAddress" runat="server" SkinID="Medium" TextMode="MultiLine"
                                                                Height="60px" MaxLength="300"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                   
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="lit2JOPostalCity" runat="server" Text="City "></asp:Literal>
                                                            
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txt2JOPostalCity" runat="server" SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="lit2JOPostalZipCode" runat="server" Text="Zip Code"></asp:Literal>
                                                           
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txt2JOPostalZipCode" runat="server" MaxLength="10" SkinID="CmpTextbox"></asp:TextBox>
                                                            <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server" TargetControlID="txt2JOPostalZipCode"
                                                                FilterMode="ValidChars" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890">
                                                            </ajx:FilteredTextBoxExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="lit2JOPostalState" runat="server" Text="State"></asp:Literal>
                                                           
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txt2JOPostalState" runat="server" SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="lit2JOPostalCountry" runat="server" Text="Country"></asp:Literal>
                                                            
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txt2JOPostalCountry" runat="server" SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" class="pagesubheader">
                                                            <asp:Literal ID="lit2JOOtherInfo" runat="server" Text="Other Info"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="lit2JOAge" runat="server" Text="Age"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txt2JOAge" runat="server" MaxLength="5" SkinID="CmpTextbox"></asp:TextBox>
                                                            <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" runat="server" TargetControlID="txt2JOAge"
                                                                FilterType="Numbers" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="lit2JOPanNo" runat="server" Text="PAN No"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txt2JOPanNo" runat="server" SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="lit2JOPOAHolder" runat="server" Text="POA Holder"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txt2JOPOAHolder" runat="server" SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="lit2JOBankName" runat="server" Text="Bank Name"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txt2JOBankName" runat="server" SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="lit2JOBankAccountNo" runat="server" Text="Bank Account No."></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txt2JOBankAccountNo" runat="server" MaxLength="20" SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="lit2JOIFSCCode" runat="server" Text="IFSC Code"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txt2JOIFSCCode" runat="server" MaxLength="16" SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" class="pagesubheader">
                                                            <asp:Literal ID="lit2JOPorssionalInfo" runat="server" Text="Professional Information"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="lit2JOOccupation" runat="server" Text="Occupation"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddl2JOOccupation" runat="server" Style="width: 202px;">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="lit2JOCompanyName" runat="server" Text="Company Name"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txt2JOCompanyName" runat="server" SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="lit2JODesignation" runat="server" Text="Designation"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txt2JODesignation" runat="server" MaxLength="15" SkinID="CmpTextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </td>
                            <td class="boxright">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="boxleft">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="boxright">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="boxleft">
                                &nbsp;
                            </td>
                            <td style="text-align: right;">
                                <div style="float: right; width: auto; display: inline-block;">
                                    <asp:Button ID="btnSave" Text="Save" Style="margin-left: 5px; display: inline-block;"
                                        runat="server" ImageUrl="~/images/save.png" ValidationGroup="Configuration" OnClick="btnSave_Click"
                                        OnClientClick="return postbackButtonClick();" />
                                    <asp:Button ID="btnCancel" Text="Cancel" Style="margin-left: 5px; display: inline-block;"
                                        runat="server" ImageUrl="~/images/cancle.png" CausesValidation="False" OnClick="btnCancel_Click"
                                        OnClientClick="fnDisplayCatchErrorMessage()" />
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
                                                    Name
                                                </td>
                                                <td style="vertical-align: middle;">
                                                    <asp:TextBox ID="txtSTermName" runat="server" Width="100" SkinID="Search"></asp:TextBox>
                                                    <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                        Style="border: 0px; vertical-align: middle; margin-top: -3px; margin-left: 5px;"
                                                        OnClick="btnSearch_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                </td>
                                            </tr>
                                            <% if (Session["UserType"].ToString().ToUpper().Equals("ADMIN"))
                                               {%>
                                            <tr>
                                                <td align="left" valign="middle" style="vertical-align: middle; margin-top: 7px;">
                                                    Relation Type
                                                </td>
                                                <td style="vertical-align: middle;">
                                                    <asp:DropDownList ID="ddlSManagerType" runat="server" Style="width: 102px;" AutoPostBack="true"
                                                        OnSelectedIndexChanged="ddlSManagerType_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="middle" style="vertical-align: middle; margin-top: 7px;">
                                                    Manager Name
                                                </td>
                                                <td style="vertical-align: middle;">
                                                    <asp:DropDownList ID="ddlSManager" runat="server" Style="width: 102px;">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <% }%>
                                            <%-- <tr>
                                                <td align="left" valign="middle" style="vertical-align: middle; margin-top: 7px;">
                                                </td>
                                                <td style="vertical-align: middle;text-align:right;">
                                                   
                                                </td>
                                            </tr>--%>
                                        </table>
                                    </div>
                                    <div class="leftmarginbox_content">
                                        <div style="height: 1879px; overflow: auto;">
                                            <asp:GridView ID="grdInvestorList" runat="server" ShowHeader="false" ShowFooter="false"
                                                SkinID="gvNoPaging" AutoGenerateColumns="false" Width="92%" OnRowCommand="grdInvestorList_RowCommand"
                                                OnRowDataBound="grdInvestorList_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <div class="rightmargin_grid">
                                                                <div class="leftmargin_contentarea" style="width: 137px !important;">
                                                                    <%--<div class="leftmargin_thumb_invester">
                                                                        <asp:Image ID="imgEmp" runat="server" Height="54px" Width="54px" ImageUrl='<%#GetPath(DataBinder.Eval(Container.DataItem, "Thumb"))%>' />
                                                                    </div>--%>
                                                                    <strong>
                                                                        <%#DataBinder.Eval(Container.DataItem, "FullName")%></strong><br />
                                                                    <asp:Literal ID="litMobileNo" runat="server"></asp:Literal><br />
                                                                    <%#DataBinder.Eval(Container.DataItem, "Email")%><br />
                                                                </div>
                                                                <div class="leftmargin_icons">
                                                                    <asp:ImageButton ID="btnEdit" ToolTip="Edit" CommandName="EDITCMD" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "InvestorID")%>'
                                                                        runat="server" ImageUrl="~/images/edit.png" Style="border: 0px; vertical-align: middle;
                                                                        margin-top: 7px; margin-right: 7px;" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                                    <asp:ImageButton ID="btnDelete" ToolTip="Delete" CommandName="DELETECMD" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "InvestorID")%>'
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
        <ajx:ModalPopupExtender ID="msgbx" runat="server" TargetControlID="hfMessage" PopupControlID="pnl"
            BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hfMessage" runat="server" />
        <asp:Panel ID="pnl" runat="server" Style="display: none;">
            <<div style="width: 500px; height: 200px; margin-top: 25px;">
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
                                <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
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
                                        ID="Image1" runat="server" />
                                </asp:HyperLink>
                            </div>
                            <div style="float: left; width: 330px; margin-top: 15px; margin-left: 10px;">
                                <asp:Label ID="lblEmailNotification" runat="server" Text="You have changed your Mail Id .A new Id and Password will be generated for your  login  and will be sent on new  Mail Id"></asp:Label>
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
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnSave" />
        <asp:PostBackTrigger ControlID="btnSaveUp" />
    </Triggers>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="pnlUpdt" ID="UpdateProgressInvestor"
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
