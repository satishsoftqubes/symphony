<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlInvestorProfile.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.InvestorSetUp.CtrlInvestorProfile" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function pageLoad(sender, args) {
        $(document).ready(function () {
            $("#<%=LitInvCCounty.ClientID%>").autocomplete('../SetUp/AutoComplete.ashx');
            $("#<%=LitCState.ClientID%>").autocomplete('../SetUp/StateAutoComplete.ashx');
            $("#<%=LitInvCCity.ClientID%>").autocomplete('../SetUp/CityAutoComplete.ashx');
        });

        $(function () {
            $("#tabs").tabs();
        });
    }
</script>
<script type="text/javascript">
    var updateProgress = null;

    function postbackButtonClick() {
        if (Page_ClientValidate("Configuration")) {
            document.getElementById('errormessage').style.display = "block";
            updateProgress = $find("<%= updPrgInvestorProfile.ClientID %>");
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
<table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td class="content" style="padding-left: 0px; width: 66.66%">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                <tr>
                    <td class="boxtopleft">
                        &nbsp;
                    </td>
                    <td class="boxtopcenter">
                        <%--FIRST OWNER<div class="boxtopcenter" style="float: right; padding-right: 290px;">
                            JOINT OWNER</div>--%>
                        INVESTOR
                    </td>
                    <td class="boxtopright">
                    </td>
                </tr>
                <tr>
                    <td class="boxleft">
                        &nbsp;
                    </td>
                    <td style="padding-top: 15px;">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="demo">
                                    <div id="tabs">
                                        <ul>
                                            <li><a href="#tabs-1">First Owner</a></li>
                                            <li><a href="#tabs-2">Joint Owner</a></li>
                                            <li><a href="#tabs-3">2nd Joint Owner</a></li>
                                        </ul>
                                        <div id="tabs-1">
                                            <table width="100%" cellpadding="3" cellspacing="3" border="0">
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
                                                                    <asp:Label ID="lblInvestorMsg" runat="server"></asp:Label></div>
                                                                <div style="height: 10px;">
                                                                </div>
                                                            </div>
                                                            <% }%>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 50%; border-right: 1px solid #ccccce;">
                                                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                            <tr>
                                                                <td style="width: 100px;">
                                                                    <asp:Literal ID="litSurName" runat="server" Text="Name"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:Literal ID="litInvFullName" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litEMail" runat="server" Text="EMail"></asp:Literal>
                                                                    <span class="erroraleart">
                                                                        <asp:RegularExpressionValidator ID="refEmail" Display="Dynamic" SetFocusOnError="True"
                                                                            ControlToValidate="txtInvEmail" ValidationGroup="Configuration" runat="server"
                                                                            ErrorMessage="*" CssClass="rfv_ErrorStar" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                                    </span>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:TextBox ID="txtInvEmail" runat="server" SkinID="nowidth" Width="165px"></asp:TextBox>
                                                                    <asp:HiddenField ID="hfOldEmial" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litMobileNo" runat="server" Text="Mobile No"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:TextBox ID="txtInvMobileCntNo" runat="server" MaxLength="4" Style="width: 45px;"></asp:TextBox>
                                                                    <ajx:FilteredTextBoxExtender ID="flttxtInvMobileCntNo" runat="server" TargetControlID="txtInvMobileCntNo"
                                                                        FilterMode="ValidChars" ValidChars="1234567890+" Enabled="True" />
                                                                    <asp:TextBox ID="litInvMobileNo" runat="server" MaxLength="10" Style="width: 115px;"></asp:TextBox>
                                                                    <ajx:FilteredTextBoxExtender ID="flttxtMobileNo" runat="server" TargetControlID="litInvMobileNo"
                                                                        FilterMode="ValidChars" ValidChars="1234567890" Enabled="True" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litDateOfBirth" runat="server" Text="Date of Birth"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:DropDownList ID="ddlDay" runat="server" Style="width: 65px;">
                                                                    </asp:DropDownList>
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
                                                                    <asp:DropDownList ID="ddlYear" runat="server" Style="width: 60px;">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td>
                                                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                            <tr>
                                                                <td style="width: 100px">
                                                                    <asp:Literal ID="litPANNo" runat="server" Text="PAN No"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:TextBox ID="txtPANNo" runat="server" MaxLength="15" style="background-color:#f3f3f5;" ReadOnly="true" SkinID="CmpTextbox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litBankName" runat="server" Text="Bank Name"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:TextBox ID="txtBankName" runat="server" MaxLength="25" ReadOnly="true" style="background-color:#f3f3f5;" SkinID="CmpTextbox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litAccNo" runat="server" Text="Bank Acc No"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:TextBox ID="txtBankAccNo" runat="server" MaxLength="20" ReadOnly="true" style="background-color:#f3f3f5;" SkinID="CmpTextbox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litAcctHolderName" runat="server" Text="Acct. Holder Name"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:TextBox ID="txtBankAcctHolderName" runat="server" MaxLength="250" ReadOnly="true" style="background-color:#f3f3f5;" SkinID="CmpTextbox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="Literal6" runat="server" Text="IFSC Code"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:TextBox ID="txtIFSCCode" runat="server" MaxLength="16" ReadOnly="true" style="background-color:#f3f3f5;" SkinID="CmpTextbox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" class="pagesubheader">
                                                        <asp:Literal ID="litRepresentativeDetails" runat="server" Text="POA / Local Representative Details"></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 50%; border-right: 1px solid #ccccce;">
                                                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                            <tr>
                                                                <td>
                                                                    Representative Name
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:TextBox ID="txtContactPersonName" runat="server" SkinID="nowidth" Width="170px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    Representative Relation
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:TextBox ID="txtRelationalName" runat="server" SkinID="nowidth" Width="170px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    Representative Email
                                                                    <span class="erroraleart">
                                                                <%--<asp:RegularExpressionValidator ID="rfvgtxtContactPersonEmail" Display="Dynamic"
                                                                    SetFocusOnError="True" ControlToValidate="txtContactPersonEmail" ValidationGroup="Configuration"
                                                                    runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>--%>
                                                            </span>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:TextBox ID="txtContactPersonEmail" runat="server" SkinID="nowidth" Width="170px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    Representative Contact
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:TextBox ID="txtContactPersonMobile" runat="server" MaxLength="15" SkinID="nowidth" Width="170px"></asp:TextBox>
                                                            <ajx:FilteredTextBoxExtender ID="flttxtContactPersonMobile" runat="server" TargetControlID="txtContactPersonMobile"
                                                                FilterType="Custom" ValidChars="+-0123456789" FilterMode="ValidChars" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td>
                                                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                            <tr>
                                                                <td style="width: 100px;">
                                                                    <asp:Literal ID="litPOAHolder" runat="server" Text="POA Holder"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:TextBox ID="txtPOAHolder" runat="server" MaxLength="100" SkinID="CmpTextbox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="pagesubheader">
                                                        <asp:Literal ID="Literal5" runat="server" Text="Agreement Address"></asp:Literal>
                                                    </td>
                                                    <td class="pagesubheader">
                                                        <asp:Literal ID="litCAddressInfo" runat="server" Text="Postal Address"></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 50%; border-right: 1px solid #ccccce;">
                                                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                            <tr>
                                                                <td style="width: 100px;">
                                                                    <asp:Literal ID="litAddressLine1" runat="server" Text="Address"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;" colspan="3">
                                                                    <asp:Literal ID="LitInvAddressLine1" runat="server"></asp:Literal>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litCity" runat="server" Text="City "></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:Literal ID="LitInvCity" runat="server"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litPostCode" runat="server" Text="ZipCode"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:Literal ID="LitInvPostCode" runat="server"></asp:Literal>
                                                                </td>
                                                                <td style="width: 100px;">
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litState" runat="server" Text="State"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:Literal ID="LitInvState" runat="server"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litCountry" runat="server" Text="Country"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:Literal ID="LitInvCountry" runat="server"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td>
                                                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                            <tr>
                                                                <td style="width: 100px;">
                                                                    <asp:Literal ID="litCAddress1" runat="server" Text="Address"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:TextBox ID="LitInvStreet" runat="server" TextMode="MultiLine" Style="width: 163px !important;"
                                                                        Height="60px" MaxLength="300"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litCCity" runat="server" Text="City "></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:TextBox ID="LitInvCCity" runat="server"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litCPostCode" runat="server" Text="ZipCode"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:TextBox ID="LitInvCPostCode" runat="server" MaxLength="6"></asp:TextBox>
                                                                    <ajx:FilteredTextBoxExtender ID="fltPostCode" runat="server" TargetControlID="LitInvCPostCode"
                                                                        FilterMode="ValidChars" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890">
                                                                    </ajx:FilteredTextBoxExtender>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litPst" runat="server" Text="State"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:TextBox ID="LitCState" runat="server"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litCCoutnry" runat="server" Text="Country"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:TextBox ID="LitInvCCounty" runat="server"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" class="pagesubheader" style="margin-left: 40px">
                                                        <asp:Literal ID="Literal4" runat="server" Text="Professional Information"></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 50%; border-right: 1px solid #ccccce;">
                                                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                            <tr>
                                                                <td style="width: 100px;">
                                                                    <asp:Literal ID="litOccupationTerm" runat="server" Text="Occupation"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:DropDownList ID="litInvOccupation" runat="server" Style="width: 167px;">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litDesignation" runat="server" Text="Designation"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:TextBox ID="litInvDesignation" runat="server" MaxLength="25"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td>
                                                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                            <tr>
                                                                <td style="width: 100px;">
                                                                    <asp:Literal ID="litCompanyName" runat="server" Text="Company Name"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:TextBox ID="litInvCompanyName" Style="width: 163px;" runat="server" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="pagesubheader">
                                                        <asp:Literal ID="Literal2" runat="server" Text="Relationship Management (Channel Partner)"></asp:Literal>
                                                    </td>
                                                    <td class="pagesubheader">
                                                        <asp:Literal ID="Literal3" runat="server" Text="Relationship Management (Uniworld)"></asp:Literal>
                                                    </td>
                                                </tr>
                                                <%--<tr>
                                                    <td colspan="2" class="pagesubheader">
                                                        <asp:Literal ID="Literal6" runat="server" Text="Relationship Management"></asp:Literal>
                                                    </td>
                                                </tr>--%>
                                                <tr>
                                                    <td style="width: 50%; border-right: 1px solid #ccccce;">
                                                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                            <tr>
                                                                <td style="width: 100px;">
                                                                    <asp:Literal ID="litRelationManagerID" runat="server" Text="Contact Person"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:Literal ID="litInvRelationManagerID" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litNameOfFirm" runat="server" Text="Name Of Firm"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:Literal ID="litInvNoOfFirm" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litManagerContactNo" runat="server" Text="Mobile No."></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:Literal ID="litInvManagerContactNo" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litManagerEmail" runat="server" Text="Email Id"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:Literal ID="litInvMangerEmail" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td>
                                                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                            <tr>
                                                                <td style="width: 125px;">
                                                                    <asp:Literal ID="litUniWorldPrime" runat="server" Text="Uniworld Exec."></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:Literal ID="litInvUniWorldPrime" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litPrimeMobileNo" runat="server" Text="Mobile No."></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:Literal ID="litInvPrimaryMobileNo" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litPrimeEmail" runat="server" Text="Email Id"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:Literal ID="litInvPrimeEmail" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" class="pagesubheader">
                                                        <asp:Literal ID="ltrInvestorVisitingCard" runat="server" Text="Visitng Card"></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 50%; border-right: 1px solid #ccccce;">
                                                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                            <tr>
                                                                <td style="width: 130px;">
                                                                    <asp:Literal ID="Literal1" runat="server" Text="Upload Visiting Card"></asp:Literal>
                                                                </td>
                                                                <td align="left" valign="top" colspan="3">
                                                                    <div id='browse_file_grid'>
                                                                        <asp:FileUpload ID="UplodFile" runat="server" Height="25px" size="18" ToolTip=".jpg|JPG|.gif|.GIF|.png|.PNG" /></div>
                                                                    <asp:HiddenField ID="hdnUploadPhoto" runat="server" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td>
                                                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Image ID="imgInvPhoto" runat="server" ImageUrl="~/UploadPhoto/BlankPhoto.jpg"
                                                                        Height="125px" Width="225px" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td align="center">
                                                        <b>
                                                            <asp:LinkButton ID="HypRemove" runat="server" Text="Remove" OnClick="HypRemove_Click"></asp:LinkButton></b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="text-align: right;">
                                                        <asp:Button ID="btnUpdate" runat="server" Text="Update" Style="float: right;" OnClick="btnUpdate_Click"
                                                            OnClientClick="return postbackButtonClick();" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="tabs-2">
                                            <table width="100%" cellpadding="3" cellspacing="3" border="0">
                                                <tr>
                                                    <td style="width: 50%; border-right: 1px solid #ccccce;">
                                                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                            <tr>
                                                                <td style="width: 100px;">
                                                                    <asp:Literal ID="litrf" runat="server" Text="Name"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:Literal ID="litRefFullName" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litsEmail" runat="server" Text="EMail"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:Literal ID="litRefEmail" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litMb" runat="server" Text="Mobile No"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:Literal ID="litRefMobileNo" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td >
                                                                    <asp:Literal ID="litag" runat="server" Text="Date of Birth"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <%--<asp:Literal ID="litRefDateOfBirth" runat="server"></asp:Literal>--%>
                                                                    <asp:DropDownList ID="ddlRefDay" runat="server" Style="width: 65px;">
                                                            </asp:DropDownList>
                                                            <asp:DropDownList ID="ddlRefMonth" runat="server" Style="width: 70px;">
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
                                                            <asp:DropDownList ID="ddlRefYear" runat="server" Style="width: 60px;">
                                                            </asp:DropDownList>
                                                            <div id="dvRefDateOfBirth" runat="server" class="rfv_ErrorStar" visible="false" style="float: right;">
                                                                Enter Valid Date</div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td>
                                                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                            
                                                            <tr>
                                                                <td style="width: 100px;">
                                                                    <asp:Literal ID="litrfpnno" runat="server" Text="PAN No"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <%--<asp:Literal ID="litRefPanNo" runat="server"></asp:Literal>--%>
                                                                    <asp:TextBox ID="txtRefPANNo" runat="server" ReadOnly="true" style="background-color:#f3f3f5;" SkinID="CmpTextbox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litRefPa" runat="server" Text="POA Holder"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <%--<asp:Literal ID="litRefPOAHolder" runat="server"></asp:Literal>--%>
                                                                    <asp:TextBox ID="txtRefPOAHolder" runat="server" MaxLength="100" ReadOnly="true" style="background-color:#f3f3f5;" SkinID="CmpTextbox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litRefBkNo" runat="server" Text="Bank Name"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <%--<asp:Literal ID="litRefBankName" runat="server"></asp:Literal>--%>
                                                                    <asp:TextBox ID="txtRefBankNo" runat="server" ReadOnly="true" style="background-color:#f3f3f5;" SkinID="CmpTextbox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litRfBankAccNo" runat="server" Text="Bank Acc No"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <%--<asp:Literal ID="litRefBankAccNo" runat="server"></asp:Literal>--%>
                                                                    <asp:TextBox ID="txtRefBankAccNo" runat="server" ReadOnly="true" MaxLength="20" style="background-color:#f3f3f5;" SkinID="CmpTextbox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litRefBankHolderName" runat="server" Text="Acct. Holder Name"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:TextBox ID="txtRefBankAcctHolderName" runat="server" ReadOnly="true" MaxLength="250" style="background-color:#f3f3f5;" SkinID="CmpTextbox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="Literal7" runat="server" Text="IFSC Code"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <%--<asp:Literal ID="litRefBankAccNo" runat="server"></asp:Literal>--%>
                                                                    <asp:TextBox ID="txtRefIFSCCode" runat="server" MaxLength="16" ReadOnly="true" style="background-color:#f3f3f5;" SkinID="CmpTextbox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="pagesubheader">
                                                        Agreement Address
                                                    </td>
                                                    <td class="pagesubheader">
                                                        Postal Address
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 50%; border-right: 1px solid #ccccce;">
                                                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                            <tr>
                                                                <td style="width: 100px;">
                                                                    <asp:Literal ID="litRefAdd" runat="server" Text="Address"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:Literal ID="litRefAddressLine1" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litRefCt" runat="server" Text="City "></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:Literal ID="litRefCity" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litpscd" runat="server" Text="ZipCode"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:Literal ID="litRefPostCode" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litRefSt" runat="server" Text="State"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:Literal ID="litRefState" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litRefCnt" runat="server" Text="Country"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:Literal ID="litRefCountry" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td>
                                                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                            <tr>
                                                                <td style="width: 100px;">
                                                                    <asp:Literal ID="litCAddres1" runat="server" Text="Address"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:Literal ID="litRefCAddressLine1" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litCCt" runat="server" Text="City "></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:Literal ID="litRefCCity" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litCpstCd" runat="server" Text="ZipCode"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:Literal ID="litRefCPostCode" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litCSt" runat="server" Text="State"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:Literal ID="litRefCState" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litCCnt" runat="server" Text="Country"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:Literal ID="litRefCCountry" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" class="pagesubheader">
                                                        Professional Information
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 50%; border-right: 1px solid #ccccce;">
                                                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                            <tr>
                                                                <td style="width: 100px;">
                                                                    <asp:Literal ID="litrfOcc" runat="server" Text="Occupation"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:Literal ID="litRefOccupation" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litCmpnam" runat="server" Text="Company Name"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:Literal ID="litRefCompanyName" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td>
                                                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                            <tr>
                                                                <td style="width: 100px;">
                                                                    <asp:Literal ID="litsDesignation" runat="server" Text="Designation"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:Literal ID="litRefDesignation" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="tabs-3">
                                            <table width="100%" cellpadding="3" cellspacing="3" border="0">
                                                <tr>
                                                    <td style="width: 50%; border-right: 1px solid #ccccce;">
                                                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                            <tr>
                                                                <td style="width: 100px;">
                                                                    <asp:Literal ID="lit2JOName" runat="server" Text="Name"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="litDisplay2JOName" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="lit2JOEMail" runat="server" Text="EMail"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:Literal ID="litDisplay2JOEMail" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="lit2JOMobileNo" runat="server" Text="Mobile No"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:Literal ID="litDisplay2JOMobileNo" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td >
                                                                    <asp:Literal ID="lit2JOAge" runat="server" Text="Date of Birth"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:DropDownList ID="ddl2JODay" runat="server" Style="width: 65px;">
                                                            </asp:DropDownList>
                                                            <asp:DropDownList ID="ddl2JOMonth" runat="server" Style="width: 70px;">
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
                                                            <asp:DropDownList ID="ddl2JOYear" runat="server" Style="width: 60px;">
                                                            </asp:DropDownList>
                                                            <div id="dv2JODateOfBirth" runat="server" class="rfv_ErrorStar" visible="false" style="float: right;">
                                                                Enter Valid Date</div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td>
                                                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                            <tr>
                                                                <td style="width: 100px;">
                                                                    <asp:Literal ID="lit2JOPANNo" runat="server" Text="PAN No"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <%--<asp:Literal ID="litDisplay2JOPANNo" runat="server"></asp:Literal>--%>
                                                                    <asp:TextBox ID="txt2JOPanNo" runat="server" ReadOnly="true" style="background-color:#f3f3f5;" SkinID="CmpTextbox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="lit2JOPOAHolder" runat="server" Text="POA Holder"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <%--<asp:Literal ID="litDisplay2JOPOAHolder" runat="server"></asp:Literal>--%>
                                                                    <asp:TextBox ID="txt2JOPOAHolder" runat="server" ReadOnly="true" MaxLength="100" style="background-color:#f3f3f5;" SkinID="CmpTextbox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="lit2JOBankName" runat="server" Text="Bank Name"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <%--<asp:Literal ID="litDisplay2JOBankName" runat="server"></asp:Literal>--%>
                                                                    <asp:TextBox ID="txt2JOBankName" runat="server" ReadOnly="true" style="background-color:#f3f3f5;" SkinID="CmpTextbox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="lit2JOBankAccNo" runat="server" Text="Bank Acc No"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <%--<asp:Literal ID="litDisplay2JOBankAccNo" runat="server"></asp:Literal>--%>
                                                                    <asp:TextBox ID="txt2JOBankAccountNo" runat="server" ReadOnly="true" style="background-color:#f3f3f5;" MaxLength="20" SkinID="CmpTextbox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="lit2JOAcctHolderName" runat="server" Text="Acct. Holder Name"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:TextBox ID="txt2JOBankAcctHolderName" runat="server" ReadOnly="true" style="background-color:#f3f3f5;" MaxLength="250" SkinID="CmpTextbox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="Literal8" runat="server" Text="IFSC Code"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:TextBox ID="txt2JOIFSCCode" runat="server" MaxLength="16" ReadOnly="true" style="background-color:#f3f3f5;" SkinID="CmpTextbox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="pagesubheader">
                                                        Agreement Address
                                                    </td>
                                                    <td class="pagesubheader">
                                                        Postal Address
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 50%; border-right: 1px solid #ccccce;">
                                                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                            <tr>
                                                                <td style="width: 100px;">
                                                                    <asp:Literal ID="lit2JOAAAddress" runat="server" Text="Address"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:Literal ID="litDisplay2JOAAAddress" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="lit2JOAACity" runat="server" Text="City"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:Literal ID="litDisplay2JOAACity" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="lit2JOAAZipCode" runat="server" Text="ZipCode"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:Literal ID="litDisplay2JOAAZipCode" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="lit2JOAAState" runat="server" Text="State"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:Literal ID="litDisplay2JOAAState" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="lit2JOAACountry" runat="server" Text="Country"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:Literal ID="litDisplay2JOAACountry" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td>
                                                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                            <tr>
                                                                <td style="width: 100px;">
                                                                    <asp:Literal ID="lit2JOPAAddress" runat="server" Text="Address"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:Literal ID="litDisplay2JOPAAddress" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="lit2JOPACity" runat="server" Text="City "></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:Literal ID="litDisplay2JOPACity" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="lit2JOPAZipCode" runat="server" Text="ZipCode"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:Literal ID="litDisplay2JOPAZipCode" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="lit2JOPAState" runat="server" Text="State"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:Literal ID="litDisplay2JOPAState" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="lit2JOPACountry" runat="server" Text="Country"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:Literal ID="litDisplay2JOPACountry" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" class="pagesubheader">
                                                        Professional Information
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 50%; border-right: 1px solid #ccccce;">
                                                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                            <tr>
                                                                <td style="width: 100px;">
                                                                    <asp:Literal ID="lit2JOOccupation" runat="server" Text="Occupation"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:Literal ID="litDisplay2JOOccupation" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="lit2JOCompanyName" runat="server" Text="Company Name"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:Literal ID="litDisplay2JOCompanyName" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td>
                                                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                            <tr>
                                                                <td style="width: 100px;">
                                                                    <asp:Literal ID="lit2JODesignation" runat="server" Text="Designation"></asp:Literal>
                                                                </td>
                                                                <td style="color: #A9A9A9;">
                                                                    <asp:Literal ID="litDisplay2JODesignation" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>
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
                                                        <asp:Label ID="lblEmailNotification" runat="server" Text="You have changed your Mail Id which is also your user name, Are you sure you want to proceed?"></asp:Label>
                                                    </div>
                                                    <table cellpadding="3" cellspacing="3" width="100%" style="margin-left: 5px; margin-top: 15px;">
                                                        <tr>
                                                            <td align="center" valign="middle">
                                                                <asp:Button ID="btnSendEmailNotification" Text="Yes" runat="server" ImageUrl="~/images/save.png"
                                                                    Style="display: inline-block;" OnClick="btnSendEmailNotification_Click" OnClientClick="return postbackButtonClick();" />
                                                                <asp:Button ID="btnCancelEmailNotification" Text="No" runat="server" ImageUrl="~/images/cancle.png"
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
                                <asp:PostBackTrigger ControlID="btnUpdate" />
                            </Triggers>
                        </asp:UpdatePanel>
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
            <div id="errormessage" class="clear" style="display: none;">
                <uc1:MsgBox ID="MessageBox" runat="server" />
            </div>
        </td>
    </tr>
</table>
<asp:UpdateProgress AssociatedUpdatePanelID="UpdatePanel1" ID="updPrgInvestorProfile"
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
