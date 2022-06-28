<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlProspects.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.InvestorSetUp.CtrlProspects" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<%@ Register Src="~/UIControls/IRMSCofiguration/CtrlAddress.ascx" TagName="CtrlAddress"
    TagPrefix="uc2" %>
<script language="javascript" type="text/javascript">
    function pageLoad(sender, args) {
        $(document).ready(function () {
            $("#<%=txtCountry.ClientID%>").autocomplete('../SetUp/AutoComplete.ashx');
            $("#<%=txtState.ClientID%>").autocomplete('../SetUp/StateAutoComplete.ashx');
            $("#<%=txtCity.ClientID%>").autocomplete('../SetUp/CityAutoComplete.ashx');
            $("#<%=txtSTermName.ClientID%>").autocomplete('ProspectsAutoComplete.ashx');
        });
    }

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

</script>
<style type="text/css">
    #progressBackgroundFilter
    {
        position: fixed;
        top: 0px;
        width:100%;
        height:100%;
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
        border-radius:10px;
        z-index: 1111112;
        background-color:#fff;
        border: solid 1px #efefef;
    }
</style>

<script type="text/javascript">
    var updateProgress = null;

    function postbackButtonClick() {
        if (Page_ClientValidate("Configuration")) {
            document.getElementById('errormessage').style.display = "block";
            updateProgress = $find("<%= UpdateProgressProspects.ClientID %>");
            window.setTimeout("updateProgress.set_visible(true)", updateProgress.get_displayAfter());
            return true;
        }
        else {
            return false;
        }
    }
</script>

<asp:UpdatePanel ID="updProspects" runat="server">
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
                                PROSPECT
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
                                                        <asp:Label ID="lblProsMsg" runat="server"></asp:Label></div>
                                                    <div style="height: 10px;">
                                                    </div>
                                                </div>
                                                <% }%>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <div style="float:right;">
                                                <b>All Bold Fields are Mandatory</b>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" colspan="2">
                                            <div style="float: left;">
                                                <asp:Button ID="btnConvertToInvestorUp" Text="Convert To Investor" Style="float: left;
                                                    margin-left: 5px;" runat="server" ImageUrl="~/images/cancle.png" CausesValidation="false"
                                                    Visible="false" OnClick="btnConvertToInvestor_Click" OnClientClick="fnDisplayCatchErrorMessage()"/>
                                            </div>
                                            <div style="float: right; width: auto; display: inline-block;">
                                                <asp:Button ID="btnNewUp" runat="server" style="display: inline-block;margin-left:5px;display:inline;" Text="New" OnClick="btnNewUp_Click" OnClientClick="fnDisplayCatchErrorMessage()"/>
                                                <asp:Button ID="btnSaveUp" Text="Save" Style="display: inline-block;margin-left: 5px;" runat="server"
                                                    ImageUrl="~/images/save.png" ValidationGroup="Configuration" CausesValidation="true"
                                                    OnClick="btnSaveUp_Click" OnClientClick="return postbackButtonClick();"/>
                                                <asp:Button ID="btnCancelUp" Text="Cancel" Style="display: inline-block;margin-left: 5px;"
                                                    runat="server" ImageUrl="~/images/cancle.png" CausesValidation="false" OnClick="btnCancelUp_Click" OnClientClick="fnDisplayCatchErrorMessage()"/>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 130px;">
                                            <asp:Label ID="litSurName" runat="server" Text="Name" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfTitle" Display="Dynamic" SetFocusOnError="True" ControlToValidate="ddlTitle"
                                                    ValidationGroup="Configuration" InitialValue="00000000-0000-0000-0000-000000000000"
                                                    runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td style="vertical-align: top;">
                                            <asp:DropDownList ID="ddlTitle" runat="server" Style="width: 100px;">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvftxtFirstName" Display="Dynamic" SetFocusOnError="True" ControlToValidate="txtFirstName"
                                                    ValidationGroup="Configuration" runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFirstName" Style="vertical-align: middle;" runat="server" SkinID="CmpTextbox"
                                                MaxLength="120"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtLastName" Style="vertical-align: middle;" runat="server" MaxLength="120"
                                                SkinID="CmpTextbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblRefernceThrow" runat="server" Text="Reference Through" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfReferenceThrow" Display="Dynamic" SetFocusOnError="True" ControlToValidate="ddlReferenceThrow"
                                                    ValidationGroup="Configuration" InitialValue="00000000-0000-0000-0000-000000000000"
                                                    runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlReferenceThrow" runat="server" Style="width: 202px;">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litRefrence" runat="server" Text="Reference Name" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvftxtRefrence" Display="Dynamic" runat="server" ControlToValidate="txtRefrence"
                                                    SetFocusOnError="true" CssClass="rfv_ErrorStar" ErrorMessage="*" ValidationGroup="Configuration"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRefrence" runat="server" SkinID="CmpTextbox" MaxLength="180"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litStatus" runat="server" Text="Status" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" SetFocusOnError="True" ControlToValidate="ddlStatus"
                                                    ValidationGroup="Configuration" InitialValue="00000000-0000-0000-0000-000000000000"
                                                    runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlStatus" runat="server" Style="width: 202px;">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td colspan="2" class="pagesubheader">
                                            <div class="rfv_ErrorStar" visible="false" style="float:left;">At least one of these details should be Entered:-Email,  Mobile No.  , Landline No.</div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litEMail" runat="server" Text="Email"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RegularExpressionValidator ID="refEmail" Display="Dynamic" SetFocusOnError="True" ControlToValidate="txtEmail"
                                                    ValidationGroup="Configuration" runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"
                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtEmail" runat="server" SkinID="CmpTextbox" MaxLength="250"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litMobileNo" runat="server" Text="Mobile No."></asp:Label>
                                            <%--<span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvftxtMobileNo" Display="Dynamic" SetFocusOnError="True" ControlToValidate="txtMobileNo"
                                                    ValidationGroup="Configuration" runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                            </span>--%>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMobileCntNo" runat="server" MaxLength="4" style="width:45px;"></asp:TextBox>
                                            <ajx:FilteredTextBoxExtender ID="flttxtMobileCntNo" runat="server" TargetControlID="txtMobileCntNo"
                                                 Enabled="True" FilterMode="ValidChars" ValidChars="1234567890+" />
                                            <asp:TextBox ID="txtMobileNo" runat="server" MaxLength="11" style="width:150px;"></asp:TextBox>
                                            <ajx:FilteredTextBoxExtender ID="flttxtMobileNo" runat="server" TargetControlID="txtMobileNo"
                                                 Enabled="True" FilterMode="ValidChars" ValidChars="1234567890" />
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
                                        <td colspan="2" class="pagesubheader">
                                            <asp:Literal ID="Literal5" runat="server" Text="Address"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td id="tdAddress1" runat="server">
                                            <asp:Literal ID="litAddressLine1" runat="server" Text="Address"></asp:Literal>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfAddressLine1" Display="Dynamic" SetFocusOnError="True" ControlToValidate="txtAddressLine1"
                                                    ValidationGroup="Configuration" runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAddressLine1" runat="server" MaxLength="380" SkinID="Medium"
                                                TextMode="MultiLine" Height="60px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td id="tdCity" runat="server">
                                            <asp:Literal ID="litCity" runat="server" Text="City "></asp:Literal>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfCity" Display="Dynamic" SetFocusOnError="True" CssClass="rfv_ErrorStar"
                                                    runat="server" ValidationGroup="Configuration" ControlToValidate="txtCity" ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCity" runat="server" MaxLength="120" SkinID="CmpTextbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td id="tdPostCode" runat="server">
                                            <asp:Literal ID="litPostCode" runat="server" Text="ZipCode"></asp:Literal>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvftxtPostCode" Display="Dynamic" SetFocusOnError="True" CssClass="rfv_ErrorStar"
                                                    runat="server" ValidationGroup="Configuration" ControlToValidate="txtPostCode"
                                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPostCode" runat="server" MaxLength="12" SkinID="CmpTextbox"></asp:TextBox>
                                            <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="txtPostCode" FilterMode="ValidChars" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"></ajx:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td id="tdState" runat="server">
                                            <asp:Literal ID="litState" runat="server" Text="State"></asp:Literal>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfState" Display="Dynamic" SetFocusOnError="True" CssClass="rfv_ErrorStar"
                                                    runat="server" ValidationGroup="Configuration" ControlToValidate="txtState" ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtState" runat="server" SkinID="CmpTextbox" MaxLength="120"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td id="tdCountry" runat="server">
                                            <asp:Literal ID="litCountry" runat="server" Text="Country"></asp:Literal>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfCountry" Display="Dynamic" SetFocusOnError="True" ControlToValidate="txtCountry"
                                                    ValidationGroup="Configuration" runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCountry" runat="server" SkinID="CmpTextbox" MaxLength="120"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litRegion" runat="server" Text="Region"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlEnteryRegion" runat="server" style="width:202px;"></asp:DropDownList>
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
                                            <asp:DropDownList ID="ddlOccupationTerm" runat="server" Style="width: 202px;">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="LitCompanyName" runat="server" Text="Company Name"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCompanyName" runat="server" SkinID="CmpTextbox" MaxLength="320"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td colspan="2" class="pagesubheader">
                                            <asp:Literal ID="Literal2" runat="server" Text="Communication SetUp"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="chkIsSMS" runat="server" Text="SMS" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="chkIsEmail" runat="server" Text="Email" />
                                        </td>
                                    </tr>--%>
                                     <tr>
                                        <td colspan="2" class="pagesubheader">
                                            Relationship Information
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litManagerType" runat="server" Text="Relationship Through" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" SetFocusOnError="True" ControlToValidate="ddlManagerType"
                                                    ValidationGroup="Configuration" InitialValue="00000000-0000-0000-0000-000000000000"
                                                    runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <div>
                                                <asp:DropDownList ID="ddlManagerType" runat="server" Style="width: 202px;" 
                                                    AutoPostBack="true" 
                                                    onselectedindexchanged="ddlManagerType_SelectedIndexChanged">
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
                                            <asp:DropDownList ID="ddlRelationManagementID" runat="server" 
                                                Style="width: 202px;" AutoPostBack="True" 
                                                onselectedindexchanged="ddlRelationManagementID_SelectedIndexChanged">
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
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" SetFocusOnError="True"
                                                    ControlToValidate="txtManagerEmail" ValidationGroup="Configuration" runat="server"
                                                    ErrorMessage="*" CssClass="rfv_ErrorStar" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtManagerEmail" runat="server" SkinID="CmpTextbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" class="pagesubheader">
                                            <asp:Literal ID="LitPhotoInfo" runat="server" Text="Visiting Card"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Literal1" runat="server" Text="Upload Visiting Card" ></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="UplodFile"
                                                    SetFocusOnError="true" CssClass="rfv_ErrorStar" ValidationGroup="Configuration"
                                                    Display="Dynamic" ErrorMessage="*" ValidationExpression="^.+(.jpg|JPG|.gif|.GIF|.png|.PNG)$"></asp:RegularExpressionValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <div id='browse_file_grid'>
                                                <asp:FileUpload ID="UplodFile" runat="server" Height="25px" size="18" ToolTip=".jpg|JPG|.gif|.GIF|.png|.PNG" />
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="140px" align="left" valign="top">
                                            &nbsp;
                                        </td>
                                        <td align="center" valign="top">
                                            <asp:Image ID="imgInvPhoto" runat="server" ImageUrl="~/UploadPhoto/BusinessCard.png"
                                                Width="200px" Height="125px" /><br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="140px" align="left" valign="top">
                                            &nbsp;
                                        </td>
                                        <td align="right" valign="top" style="padding-right: 145px;">
                                            <b>
                                                <asp:LinkButton ID="HypRemove" runat="server" Text="Remove" UseSubmitBehavior="false" OnClientClick="this.disabled = true; this.value = 'Processing...';" OnClick="HypRemove_Click"></asp:LinkButton></b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" colspan="2">
                                            <div style="float: left;">
                                                <asp:Button ID="btnConvertToInvestor" Text="Convert To Investor" Style="float: left;
                                                    margin-left: 5px;" runat="server" ImageUrl="~/images/cancle.png" CausesValidation="false"
                                                    Visible="false" OnClick="btnConvertToInvestor_Click" OnClientClick="fnDisplayCatchErrorMessage()"/>
                                            </div>
                                            <div style="float: right; width: auto; display: inline-block;">
                                                <asp:Button ID="btnNew" runat="server" style="display: inline-block;margin-left:5px;display:inline;" Text="New" OnClick="btnNew_Click" OnClientClick="fnDisplayCatchErrorMessage()"/>
                                                <asp:Button ID="btnSave" Text="Save" Style="display: inline-block; margin-left: 5px;" runat="server"
                                                    ImageUrl="~/images/save.png" ValidationGroup="Configuration" CausesValidation="true"
                                                    OnClick="btnSave_Click" OnClientClick="return postbackButtonClick();"/>
                                                <asp:Button ID="btnCancel" Text="Cancel" Style="display: inline-block;margin-left: 5px;"
                                                    runat="server" ImageUrl="~/images/cancle.png" CausesValidation="false" OnClick="btnCancel_Click" OnClientClick="fnDisplayCatchErrorMessage()"/>
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
                                                    Name
                                                </td>
                                                <td style="vertical-align: middle;">
                                                    <asp:TextBox ID="txtSTermName" runat="server" style="width:150px !important"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="middle" style="vertical-align: middle; margin-top: 7px;">
                                                    Status
                                                </td>
                                                <td style="vertical-align: middle;">
                                                    <asp:DropDownList ID="ddlSStatus" runat="server" style="width:152px !important"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="middle" style="vertical-align: middle; margin-top: 7px;">
                                                    Reference
                                                </td>
                                                <td style="vertical-align: middle;">
                                                    <asp:DropDownList ID="txtSReference" runat="server" style="width:152px !important"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="middle" style="vertical-align: middle; margin-top: 7px;">
                                                    Region
                                                </td>
                                                <td style="vertical-align: middle;">
                                                    <asp:DropDownList ID="ddlRegion" runat="server" style="width:152px !important"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="middle" style="vertical-align: middle; margin-top: 7px;">
                                                    City
                                                </td>
                                                <td style="vertical-align: middle;">
                                                    <asp:DropDownList ID="txtSLocation" runat="server" style="width:126px !important"></asp:DropDownList>
                                                    <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                        Style="border: 0px; vertical-align: middle; margin: -1px 0 0 5px;" OnClick="btnSearch_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="leftmarginbox_content">
                                        <div style="height: 1032px; overflow:auto;">
                                            <asp:GridView ID="grdProspectesList" runat="server" ShowHeader="false" ShowFooter="false"
                                                SkinID="gvNoPaging" AutoGenerateColumns="false" Width="92%" OnRowCommand="grdProspectesList_RowCommand"
                                                OnRowDataBound="grdProspectesList_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <div class="rightmargin_grid">
                                                                <div class="leftmargin_contentarea" style="width:137px !important;">
                                                                    <strong>
                                                                    <%#DataBinder.Eval(Container.DataItem, "FullName")%></strong><br />
                                                                    <%#DataBinder.Eval(Container.DataItem, "Status")%></div>
                                                                <div class="leftmargin_icons">
                                                                    <asp:ImageButton ID="btnEdit" ToolTip="Edit" CommandName="EDITCMD" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ProspectID")%>'
                                                                        runat="server" ImageUrl="~/images/edit.png" Style="border: 0px; vertical-align: middle;
                                                                        margin-top: 7px; margin-right: 7px;" OnClientClick="fnDisplayCatchErrorMessage()"/>
                                                                    <asp:ImageButton ID="btnDelete" ToolTip="Delete" CommandName="DELETECMD" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ProspectID")%>'
                                                                        runat="server" ImageUrl="~/images/delete_icon.png" Style="border: 0px; vertical-align: middle;
                                                                        margin-top: 7px; margin-right: 7px;" OnClientClick="fnDisplayCatchErrorMessage()"/>
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
        <asp:Panel ID="pnl" runat="server" style="display:none;">
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
                            <div class="leftmargin_contentarea" style="float: left; width: 100px;">
                                <asp:Label ID="lblErrorMessage" runat="server" Text="Sure you want to delete?"></asp:Label>
                            </div>
                            <table cellpadding="3" cellspacing="3" width="100%" style="margin-left: 5px; margin-top: 15px;">
                                <tr>
                                    <td align="center" valign="middle">
                                        <asp:Button ID="btnAddressSave" Text="Yes" runat="server" ImageUrl="~/images/save.png"
                                            OnClick="btnAddressSave_Click" Style="display:inline-block;" OnClientClick="fnDisplayCatchErrorMessage()"/>
                                        <asp:Button ID="btnAddressCancel" Text="Cancel" runat="server" ImageUrl="~/images/cancle.png"
                                            OnClick="btnAddressCancel_Click" Style="display:inline-block;" OnClientClick="fnDisplayCatchErrorMessage()"/>
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
<asp:UpdateProgress AssociatedUpdatePanelID="updProspects" ID="UpdateProgressProspects"
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