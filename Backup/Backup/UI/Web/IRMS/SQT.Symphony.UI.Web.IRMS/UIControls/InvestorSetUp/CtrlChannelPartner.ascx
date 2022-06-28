<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlChannelPartner.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.InvestorSetUp.CtrlChannelPartner" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<%@ Register Src="~/UIControls/IRMSCofiguration/CtrlAddress.ascx" TagName="CtrlAddress"
    TagPrefix="uc2" %>
<script language="javascript" type="text/javascript">

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function pageLoad(sender, args) {
        $(document).ready(function () {
            $("#<%=txtCountry.ClientID%>").autocomplete('../SetUp/AutoComplete.ashx');
            $("#<%=txtState.ClientID%>").autocomplete('../SetUp/StateAutoComplete.ashx');
            $("#<%=txtCity.ClientID%>").autocomplete('../SetUp/CityAutoComplete.ashx');

            $("#<%=txtSTermName.ClientID%>").autocomplete('ChannelPartnerAutoComplete.ashx');
            $("#<%=txtSLocation.ClientID%>").autocomplete('ChannelPartnerCompanyAutoComplete.ashx');

        });
    }

    function CopyName() {
        var title = document.getElementById('<%=ddlTitle.ClientID%>').value;
        var fname = document.getElementById('<%=txtFirstName.ClientID%>').value;
        var lname = document.getElementById('<%=txtLastName.ClientID%>').value;
        
        if (title == '00000000-0000-0000-0000-000000000000') {
            title = '';
        }

        if (title != '' && fname != '') {
            if (lname != '') {
                document.getElementById('<%=txtDisplayName.ClientID%>').value = title + ' ' + fname + ' ' + lname;
            }
            else {
                document.getElementById('<%=txtDisplayName.ClientID%>').value = title + ' ' + fname;
            }
        }
        else {
            document.getElementById('<%=txtDisplayName.ClientID%>').value = '';
        }
        return false
    }

    function CopyNameofFirm () {
        var CompanyName = document.getElementById('<%=txtCompanyName.ClientID%>').value;


        if (CompanyName != '') {
            document.getElementById('<%=txtDisplayNameoffirm.ClientID%>').value = CompanyName;
        }
        else {
            document.getElementById('<%=txtDisplayNameoffirm.ClientID%>').value = '';
        }
        return false
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
            updateProgress = $find("<%= UpdateProgressChannelPartner.ClientID %>");
            window.setTimeout("updateProgress.set_visible(true)", updateProgress.get_displayAfter());
            return true;
        }
        else {
            return false;
        }
    }
</script>
<asp:UpdatePanel ID="updtChannelPartner" runat="server">
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
                                CHANNEL PARTNER
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
                                                    display: inline;" Text="New" OnClick="btnNewUp_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                <asp:Button ID="btnSaveUp" Text="Save" Style="display: inline-block; margin-left: 5px;"
                                                    runat="server" ImageUrl="~/images/save.png" ValidationGroup="Configuration" CausesValidation="true"
                                                    OnClick="btnSaveUp_Click" OnClientClick="return postbackButtonClick();" />
                                                <asp:Button ID="btnCancelUp" Text="Cancel" Style="display: inline-block; margin-left: 5px;"
                                                    runat="server" ImageUrl="~/images/cancle.png" CausesValidation="false" OnClick="btnCancelUp_Click"
                                                    OnClientClick="fnDisplayCatchErrorMessage()" />
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 130px;">
                                            <asp:Label ID="litSurName" runat="server" Text="Name of Person" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart" style="float: right;">
                                                <asp:RequiredFieldValidator ID="rvfTitle" SetFocusOnError="True" ControlToValidate="ddlTitle"
                                                    ValidationGroup="Configuration" Display="Dynamic" InitialValue="00000000-0000-0000-0000-000000000000"
                                                    runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td style="vertical-align: top;">
                                            <asp:DropDownList ID="ddlTitle" runat="server" Style="width: 75px;">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvftxtFirstName" SetFocusOnError="True" ControlToValidate="txtFirstName"
                                                    ValidationGroup="Configuration" runat="server" Display="Dynamic" ErrorMessage="*"
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
                                            <asp:Label ID="littxtDisplayName" runat="server" Text="Display Name of Person" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvftxtDisplayName" SetFocusOnError="True" ControlToValidate="txtDisplayName"
                                                    ValidationGroup="Configuration" runat="server" Display="Dynamic" ErrorMessage="*"
                                                    CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDisplayName" runat="server" SkinID="CmpTextbox"></asp:TextBox>
                                            <a href="#" onclick="return CopyName();" style="color: #0067A4;">Copy as above</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="Literal4" runat="server" Text="Name of Firm"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCompanyName" runat="server" SkinID="CmpTextbox"></asp:TextBox>
                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="Literal2" runat="server" Text="Display Name of Firm"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDisplayNameoffirm" runat="server" SkinID="CmpTextbox"></asp:TextBox>
                                            <a href="#" onclick="return CopyNameofFirm();" style="color: #0067A4;">Copy as above</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litEMail" runat="server" Text="Email"></asp:Label>
                                            <asp:HiddenField ID="hfOldEmial" runat="server" />
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
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMobileCntNo" runat="server" MaxLength="4" Style="width: 45px;"></asp:TextBox>
                                            <ajx:FilteredTextBoxExtender ID="flttxtMobileCntNo" runat="server" TargetControlID="txtMobileCntNo"
                                                FilterMode="ValidChars" ValidChars="1234567890+" Enabled="True" />
                                            <asp:TextBox ID="txtMobileNo" runat="server" MaxLength="10" Style="width: 150px;"></asp:TextBox>
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
                                        <td colspan="2" class="pagesubheader">
                                            <asp:Literal ID="Literal5" runat="server" Text="Address"></asp:Literal>
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
                                                Height="60px" MaxLength="350"></asp:TextBox>
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
                                            <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="txtPostCode"
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
                                        <td colspan="2" class="pagesubheader">
                                            <asp:Literal ID="LitPhotoInfo" runat="server" Text="Visiting card"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="Literal1" runat="server" Text="Upload Visiting card"></asp:Literal>
                                            <span class="erroraleart">
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="UplodFile"
                                                    SetFocusOnError="true" CssClass="rfv_ErrorStar" ValidationGroup="Configuration"
                                                    Display="Dynamic" ErrorMessage="*" ValidationExpression="^.+(.jpg|JPG|.gif|.GIF|.png|.PNG)$"></asp:RegularExpressionValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <div id='browse_file_grid'>
                                                <asp:FileUpload ID="UplodFile" runat="server" Height="25px" size="18" ToolTip=".jpg|JPG|.gif|.GIF|.png|.PNG" />
                                                <asp:HiddenField ID="hdnUploadPhoto" runat="server" />
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="140px" align="left" valign="top">
                                            &nbsp;
                                        </td>
                                        <td align="center" valign="top">
                                            <asp:Image ID="imgInvPhoto" runat="server" ImageUrl="~/UploadPhoto/BlankPhoto.jpg"
                                                Height="125px" Width="200px" /><br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="140px" align="left" valign="top">
                                            &nbsp;
                                        </td>
                                        <td align="right" valign="top" style="padding-right: 145px;">
                                            <b>
                                                <asp:LinkButton ID="HypRemove" runat="server" Text="Remove" OnClick="HypRemove_Click"></asp:LinkButton></b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" colspan="2" style="text-align: right;">
                                            <div style="float: right; width: auto; display: inline-block;">
                                                <asp:Button ID="btnNew" runat="server" Style="display: inline-block; margin-left: 5px;
                                                    display: inline;" Text="New" OnClick="btnNew_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                <asp:Button ID="btnSave" Text="Save" Style="display: inline-block; margin-left: 5px;"
                                                    runat="server" ImageUrl="~/images/save.png" ValidationGroup="Configuration" CausesValidation="true"
                                                    OnClick="btnSave_Click" OnClientClick="return postbackButtonClick();" />
                                                <asp:Button ID="btnCancel" Text="Cancel" Style="display: inline-block; margin-left: 5px;"
                                                    runat="server" ImageUrl="~/images/cancle.png" CausesValidation="false" OnClick="btnCancel_Click"
                                                    OnClientClick="fnDisplayCatchErrorMessage()" />
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
                                                    Person Name
                                                </td>
                                                <td style="vertical-align: middle;">
                                                    <asp:TextBox ID="txtSTermName" runat="server" Style="width: 125px;"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="middle" style="vertical-align: middle; margin-top: 7px;">
                                                    Company Name
                                                </td>
                                                <td style="vertical-align: middle;">
                                                    <asp:TextBox ID="txtSLocation" runat="server" Width="100" SkinID="Search"></asp:TextBox>
                                                    <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                        Style="border: 0px; vertical-align: middle; margin: -4px 0 0 5px;" OnClick="btnSearch_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="leftmarginbox_content">
                                        <div style="height: 751px; overflow: auto;">
                                            <asp:GridView ID="grdChannelPartnerList" runat="server" ShowHeader="false" ShowFooter="false"
                                                SkinID="gvNoPaging" AutoGenerateColumns="false" Width="92%" OnRowCommand="grdChannelPartnerList_RowCommand"
                                                OnRowDataBound="grdChannelPartnerList_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <div class="rightmargin_grid">
                                                                <div class="leftmargin_contentarea" style="width: 137px !important;">
                                                                    <strong>
                                                                        <%#DataBinder.Eval(Container.DataItem, "DisplayName")%></strong><br />
                                                                    <%--<asp:Literal ID="litMobileNo" runat="server"></asp:Literal><br />
                                                                    <%#DataBinder.Eval(Container.DataItem, "Email")%><br />--%>
                                                                    <div style="width: 80px; float: left;">
                                                                        <table border="0" style="width: 200px;" cellpadding="0" cellspacing="0" runat="server"
                                                                            id="tblTotal">
                                                                            <tr>
                                                                                <td style="width: 40px;">
                                                                                    Investors:
                                                                                </td>
                                                                                <td style="width: 20px;">
                                                                                    <asp:Literal ID="lblTotaoInvestor" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "TotalInvestor")%>'></asp:Literal>
                                                                                </td>
                                                                                <td style="width: 20px;">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td style="width: 40px;">
                                                                                    Prospects:
                                                                                </td>
                                                                                <td style="width: 20px;">
                                                                                    <asp:Literal ID="lblTotalProspects" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "TotalProspects")%>'></asp:Literal>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                    <div class="clear">
                                                                    </div>
                                                                </div>
                                                                <div class="leftmargin_icons">
                                                                    <asp:ImageButton ID="btnEdit" ToolTip="Edit" CommandName="EDITCMD" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ChannelPartnerID")%>'
                                                                        runat="server" ImageUrl="~/images/edit.png" Style="border: 0px; vertical-align: middle;
                                                                        margin-top: 7px; margin-right: 7px;" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                                    <asp:ImageButton ID="btnDelete" ToolTip="Delete" CommandName="DELETECMD" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ChannelPartnerID")%>'
                                                                        runat="server" ImageUrl="~/images/delete_icon.png" Style="border: 0px; vertical-align: middle;
                                                                        margin-top: 7px; margin-right: 7px;" OnClientClick="fnDisplayCatchErrorMessage()" />
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
        <asp:Panel ID="pnlEmailNotification" runat="server">
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
                                <asp:Label ID="lblEmailNotification" runat="server" Text="You have changed your Mail Id .A new Id and Password will be generated for your  login  and will be sent on new  Mail Id"></asp:Label>
                            </div>
                            <table cellpadding="3" cellspacing="3" width="100%" style="margin-left: 5px; margin-top: 15px;">
                                <tr>
                                    <td align="center" valign="middle">
                                        <asp:Button ID="btnSaveEmailNotification" Text="OK" OnClientClick="fnDisplayCatchErrorMessage()"
                                            runat="server" ImageUrl="~/images/save.png" Style="display: inline-block;" OnClick="btnSaveEmailNotification_Click" />
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
        <asp:Panel ID="pnl" runat="server">
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
                                            OnClick="btnAddressSave_Click" Style="display: inline-block;" />
                                        <asp:Button ID="btnAddressCancel" Text="Cancel" runat="server" ImageUrl="~/images/cancle.png"
                                            OnClick="btnAddressCancel_Click" Style="display: inline-block;" />
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
<asp:UpdateProgress AssociatedUpdatePanelID="updtChannelPartner" ID="UpdateProgressChannelPartner"
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
