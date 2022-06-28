<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlEmployee.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.Configurations.CtrlEmployee" %>
<%@ Register Src="../CommonControls/CtrlAddress.ascx" TagName="CtrlAddress" TagPrefix="uc1" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script src="../../Javascript/Common.js" type="text/javascript"></script>
<script type="text/javascript" language="javascript">
    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<script type="text/javascript">
    var updateProgress = null;

    function postbackButtonClick() {
        if (Page_ClientValidate("IsRequire")) {
            document.getElementById('errormessage').style.display = "block";
            updateProgress = $find("<%= UpdateProgressEmployee.ClientID %>");
            window.setTimeout("updateProgress.set_visible(true)", updateProgress.get_displayAfter());
            return true;
        }
        else {
            return false;
        }
    }

    function Copyaddress(chk) {
        var obj = chk;
        if (obj.checked == true) {
            document.getElementById('ContentPlaceHolder1_CtrlEmployee1_ucCurrentAddress_txtAddress').value = document.getElementById('ContentPlaceHolder1_CtrlEmployee1_ucPermanentAddress_txtAddress').value;
            document.getElementById('ContentPlaceHolder1_CtrlEmployee1_ucCurrentAddress_txtCity').value = document.getElementById('ContentPlaceHolder1_CtrlEmployee1_ucPermanentAddress_txtCity').value;
            document.getElementById('ContentPlaceHolder1_CtrlEmployee1_ucCurrentAddress_txtState').value = document.getElementById('ContentPlaceHolder1_CtrlEmployee1_ucPermanentAddress_txtState').value;
            document.getElementById('ContentPlaceHolder1_CtrlEmployee1_ucCurrentAddress_txtCountry').value = document.getElementById('ContentPlaceHolder1_CtrlEmployee1_ucPermanentAddress_txtCountry').value;
            document.getElementById('ContentPlaceHolder1_CtrlEmployee1_ucCurrentAddress_txtZipCode').value = document.getElementById('ContentPlaceHolder1_CtrlEmployee1_ucPermanentAddress_txtZipCode').value;
        }
        else {
            document.getElementById('ContentPlaceHolder1_CtrlEmployee1_ucCurrentAddress_txtAddress').value = "";
            document.getElementById('ContentPlaceHolder1_CtrlEmployee1_ucCurrentAddress_txtCity').value = "";
            document.getElementById('ContentPlaceHolder1_CtrlEmployee1_ucCurrentAddress_txtState').value = "";
            document.getElementById('ContentPlaceHolder1_CtrlEmployee1_ucCurrentAddress_txtCountry').value = "";
            document.getElementById('ContentPlaceHolder1_CtrlEmployee1_ucCurrentAddress_txtZipCode').value = "";
        }
    }

</script>
<asp:UpdatePanel ID="updEmployee" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="content" style="padding-left: 0px; width: 66.66%">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                <asp:Literal ID="litMainHeader" runat="server"></asp:Literal>
                            </td>
                            <td class="boxtopright">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="boxleft">
                            </td>
                            <td>
                                <div class="box_form">
                                    <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                        <tr>
                                            <td colspan="4">
                                                <% if (IsListMessage)
                                                   { %>
                                                <div class="message finalsuccess">
                                                    <p>
                                                        <strong>
                                                            <asp:Literal ID="litListMessage" runat="server"></asp:Literal></strong>
                                                    </p>
                                                </div>
                                                <% }%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <div style="float: right; padding-bottom: 5px;">
                                                    <b>
                                                        <asp:Literal ID="litGeneralMandartoryFiledMessage" runat="server"></asp:Literal>
                                                    </b>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="isrequire">
                                                <asp:Literal ID="litDepartmentName" runat="server"></asp:Literal>
                                            </td>
                                            <td colspan="3">
                                                <asp:DropDownList ID="ddlDepartmentName" runat="server">
                                                </asp:DropDownList>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rvfDepartmentName" InitialValue="00000000-0000-0000-0000-000000000000"
                                                        SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                        ValidationGroup="IsRequire" ControlToValidate="ddlDepartmentName" Display="Dynamic">
                                                    </asp:RequiredFieldValidator>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="isrequire">
                                                <asp:Literal ID="litName" runat="server"></asp:Literal>
                                            </td>
                                            <td colspan="3">
                                                <asp:DropDownList ID="ddlTitle" runat="server" Style="width: 100px; height: 25px;">
                                                </asp:DropDownList>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rvfTitle" InitialValue="00000000-0000-0000-0000-000000000000"
                                                        SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                        ValidationGroup="IsRequire" ControlToValidate="ddlTitle" Display="Dynamic">
                                                    </asp:RequiredFieldValidator>
                                                </span>
                                                <asp:TextBox ID="txtFirstName" runat="server" MaxLength="150"></asp:TextBox>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rvfFirstName" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                        runat="server" ValidationGroup="IsRequire" ControlToValidate="txtFirstName" Display="Dynamic">
                                                    </asp:RequiredFieldValidator>
                                                </span>
                                                <asp:TextBox ID="txtLastName" runat="server" MaxLength="150"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="isrequire">
                                                <asp:Literal ID="litEmployeeNo" runat="server"></asp:Literal>
                                            </td>
                                            <td style="width: 315px;">
                                                <asp:TextBox ID="txtEmployeeNo" runat="server" MaxLength="120"></asp:TextBox>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rvfEmployeeNo" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                        runat="server" ValidationGroup="IsRequire" ControlToValidate="txtEmployeeNo"
                                                        Display="Dynamic"></asp:RequiredFieldValidator></span>
                                            </td>
                                            <td class="isrequire">
                                                <asp:Literal ID="litNationality" runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtNationality" runat="server" MaxLength="50"></asp:TextBox>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rvfNationality" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                        runat="server" ValidationGroup="IsRequire" ControlToValidate="txtNationality"
                                                        Display="Dynamic"></asp:RequiredFieldValidator></span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="isrequire">
                                                <asp:Literal ID="litDateOfBirth" runat="server"></asp:Literal>
                                            </td>
                                            <td style="width: 315px;">
                                                <asp:DropDownList ID="ddlDate" runat="server" Style="width: 70px;">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvDate" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                    Display="Dynamic" ControlToValidate="ddlDate" ValidationGroup="IsRequire" runat="server"
                                                    InitialValue="00000000-0000-0000-0000-000000000000"></asp:RequiredFieldValidator>
                                                <asp:DropDownList ID="ddlMonth" runat="server" Style="width: 75px;">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rvfMonth" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                    Display="Dynamic" ControlToValidate="ddlMonth" ValidationGroup="IsRequire" runat="server"
                                                    InitialValue="00000000-0000-0000-0000-000000000000"></asp:RequiredFieldValidator>
                                                <asp:DropDownList ID="ddlYear" runat="server" Style="width: 70px;">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rvfYear" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                    Display="Dynamic" ControlToValidate="ddlYear" ValidationGroup="IsRequire" runat="server"
                                                    InitialValue="00000000-0000-0000-0000-000000000000"></asp:RequiredFieldValidator>
                                                <br />
                                                <div id="ValidDate" runat="server" visible="false" style="float: left; color: Red;
                                                    padding-top: 3px;">
                                                </div>
                                            </td>
                                            <th align="left">
                                                <asp:Literal ID="litMaritalStatus" runat="server"></asp:Literal>
                                            </th>
                                            <td>
                                                <asp:DropDownList ID="ddlMaritalStatus" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th align="left">
                                                <asp:Literal ID="litGender" runat="server"></asp:Literal>
                                            </th>
                                            <td style="width: 315px;">
                                                <asp:DropDownList ID="ddlGender" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <th align="left">
                                                <asp:Literal ID="litLandlineNo" runat="server"></asp:Literal>
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtLandlineNo" runat="server" MaxLength="15"></asp:TextBox>
                                                <ajx:FilteredTextBoxExtender ID="ftLandlineNo" runat="server" TargetControlID="txtLandlineNo"
                                                    FilterType="Numbers" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td id="tdMobileNo" runat="server">
                                                <asp:Literal ID="litMobileNo" runat="server"></asp:Literal>
                                            </td>
                                            <td colspan="3">
                                                <asp:TextBox ID="txtMobileNo" runat="server" MaxLength="15"></asp:TextBox>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rfvMobileNo" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                        runat="server" ValidationGroup="IsRequire" ControlToValidate="txtMobileNo" Display="Dynamic"></asp:RequiredFieldValidator></span>
                                                <ajx:FilteredTextBoxExtender ID="ftMobileNo" runat="server" TargetControlID="txtMobileNo"
                                                    FilterType="Numbers" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <div style="padding-bottom: 5px;">
                                                    <h1>
                                                        <asp:Literal ID="litHeaderAddressInfo" runat="server"></asp:Literal>
                                                    </h1>
                                                </div>
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2"></td>
                                            <td></td>
                                            <td class="checkbox_new" style="padding:0px;">
                                                <asp:CheckBox ID="chkAsPermanenetAddress" runat="server" onclick="Copyaddress(this);" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <uc1:CtrlAddress ID="ucPermanentAddress" runat="server" />
                                            </td>
                                            <td colspan="2">
                                                <uc1:CtrlAddress ID="ucCurrentAddress" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <h1>
                                                    <asp:Literal ID="litOtherInformation" runat="server"></asp:Literal>
                                                </h1>
                                                <hr>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="isrequire">
                                                <asp:Literal ID="litEmail" runat="server"></asp:Literal>
                                            </td>
                                            <td style="width: 315px;">
                                                <asp:TextBox ID="txtEmail" runat="server" MaxLength="120"></asp:TextBox>
                                                <asp:HiddenField ID="hfOldEmial" runat="server" />
                                                <span>
                                                    <asp:RegularExpressionValidator ID="refEmail" SetFocusOnError="True" ControlToValidate="txtEmail"
                                                        ValidationGroup="IsRequire" runat="server" CssClass="input-notification error png_bg"
                                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>
                                                    <asp:RequiredFieldValidator ID="rvfEmail" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                        runat="server" ValidationGroup="IsRequire" ControlToValidate="txtEmail" Display="Dynamic"></asp:RequiredFieldValidator></span>
                                            </td>
                                            <td class="isrequire">
                                                <asp:Literal ID="litDateOfJoin" runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlJoiningDate" runat="server" Style="width: 70px;">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvJoiningDate" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                    Display="Dynamic" ControlToValidate="ddlJoiningDate" ValidationGroup="IsRequire"
                                                    runat="server" InitialValue="00000000-0000-0000-0000-000000000000"></asp:RequiredFieldValidator>
                                                <asp:DropDownList ID="ddlJoiningMonth" runat="server" Style="width: 75px;">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvJoiningMonth" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                    Display="Dynamic" ControlToValidate="ddlJoiningMonth" ValidationGroup="IsRequire"
                                                    runat="server" InitialValue="00000000-0000-0000-0000-000000000000"></asp:RequiredFieldValidator>
                                                <asp:DropDownList ID="ddlJoiningYear" runat="server" Style="width: 70px;">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvJoiningYear" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                    Display="Dynamic" ControlToValidate="ddlJoiningYear" ValidationGroup="IsRequire"
                                                    runat="server" InitialValue="00000000-0000-0000-0000-000000000000"></asp:RequiredFieldValidator>
                                                <br />
                                                <div id="divJoiningDate" runat="server" visible="false" style="float: left; color: Red;
                                                    padding-top: 3px;">
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="isrequire">
                                                <asp:Literal ID="litStatus" runat="server"></asp:Literal>
                                            </td>
                                            <td colspan="3">
                                                <asp:DropDownList ID="ddlStatus" runat="server">
                                                </asp:DropDownList>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rvfStatus" runat="server" ControlToValidate="ddlStatus"
                                                        CssClass="input-notification error png_bg" InitialValue="00000000-0000-0000-0000-000000000000"
                                                        SetFocusOnError="true" ValidationGroup="IsRequire" Display="Dynamic"></asp:RequiredFieldValidator>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <h1>
                                                    <asp:Literal ID="litHeaderVisitingCard" runat="server"></asp:Literal>
                                                </h1>
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="vertical-align: top;">
                                                <asp:Literal ID="litSelectLogo" runat="server"></asp:Literal>
                                            </th>
                                            <td style="vertical-align: top !important;">
                                                <div id='browse_file_grid'>
                                                    <asp:FileUpload ID="fuEmployeeLogo" runat="server" />
                                                    <asp:HiddenField ID="hdnUploadPhoto" runat="server" />
                                                </div>
                                                <span>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="fuEmployeeLogo"
                                                        SetFocusOnError="true" CssClass="rfv_ErrorStar" ValidationGroup="IsRequire" Display="Dynamic"
                                                        ErrorMessage="*" ValidationExpression="^.+(.jpg|JPG|.gif|.GIF|.png|.PNG)$"></asp:RegularExpressionValidator>
                                                </span>
                                            </td>
                                            <td colspan="2">
                                                <asp:Image ID="imgEmployee" runat="server" ImageUrl="~/images/BusinessCard.png" Width="200px" />
                                                <div style="padding-left: 80px; padding-top: 5px;">
                                                    <b>
                                                        <asp:LinkButton ID="lnkRemoveLogo" runat="server" Visible="false" OnClick="lnkRemoveLogo_OnClick"></asp:LinkButton>
                                                    </b>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <div style="float: right; width: auto; display: inline-block;">
                                                    <asp:Button ID="btnCancel" runat="server" CausesValidation="false" ImageUrl="~/images/cancle.png"
                                                        Style="float: right; margin-left: 5px;" OnClick="btnCancel_Click" />
                                                    <asp:Button ID="btnSave" runat="server" CausesValidation="true" ImageUrl="~/images/save.png"
                                                        Style="float: right; margin-left: 5px;" ValidationGroup="IsRequire" OnClick="btnSave_Click"
                                                        OnClientClick="return postbackButtonClick();" />
                                                    <asp:Button ID="btnBackToList" runat="server" CausesValidation="false" ImageUrl="~/images/cancle.png"
                                                        Style="float: right; margin-left: 5px;" OnClick="btnBackToList_Click" />
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
                    <div class="clear">
                        <%--<uc1:MsgBox ID="MessageBox" runat="server" />--%>
                    </div>
                </td>
            </tr>
        </table>
        <ajx:ModalPopupExtender ID="EmailNotification" runat="server" TargetControlID="hfEmailNotification"
            PopupControlID="pnlEmailNotification" BackgroundCssClass="mod_background" BehaviorID="EmailNotification">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hfEmailNotification" runat="server" />
        <asp:Panel ID="pnlEmailNotification" runat="server" Height="350px" Width="420px"
            Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="ltrHeaderEmailNotificationPopup" runat="server"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td align="center" style="padding: 15px;">
                                <asp:Literal ID="lblEmailNotification" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnSaveEmailNotification" Text="OK" OnClientClick="fnDisplayCatchErrorMessage();"
                                    runat="server" ImageUrl="~/images/save.png" Style="display: inline-block;" OnClick="btnSaveEmailNotification_Click" />
                                <asp:Button ID="btnCancelEmailNotification" Text="Cancel" runat="server" ImageUrl="~/images/cancle.png"
                                    Style="display: inline-block;" OnClick="btnCancelEmailNotification_Click" />
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
        <asp:PostBackTrigger ControlID="btnSave" />
    </Triggers>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updEmployee" ID="UpdateProgressEmployee"
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
