<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlPropertyInformation.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.Configurations.CtrlPropertyInformation" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
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
        z-index: 1000;
    }
    #processMessage
    {
        position: fixed;
        top: 50%;
        left: 50%;
        padding: 10px;
        width: 30px;
        border-radius: 10px;
        z-index: 1001;
        background-color: #fff;
        border: solid 1px #efefef;
    }
</style>
<asp:UpdatePanel ID="updSystemSetUp" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height: 473px;">
            <tr>
                <td class="content" style="padding-left: 0px; width: 66.66%">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                SYSTEM SETUP
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
                                <table cellpadding="2" cellspacing="3" border="0" width="100%">
                                    <tr>
                                        <td colspan="4">
                                            <div>
                                                <%if (IsInsert)
                                                  { %>
                                                <div class="ResetSuccessfully">
                                                    <div style="float: left; padding-top: 7px; width: 25px; height: 24px; margin-right: 10px;">
                                                        <img src="../../images/success.png" /></div>
                                                    <div>
                                                        <asp:Label ID="lblInsert" runat="server"></asp:Label></div>
                                                    <div style="height: 10px;">
                                                    </div>
                                                </div>
                                                <%}%>
                                                <%if (IsUpdate)
                                                  { %>
                                                <div class="ResetSuccessfully">
                                                    <div style="float: left; padding-top: 7px; width: 25px; height: 24px; margin-right: 10px;">
                                                        <img src="../../images/success.png" /></div>
                                                    <div>
                                                        <asp:Label ID="lblUpdate" runat="server"></asp:Label></div>
                                                    <div style="height: 10px;">
                                                    </div>
                                                </div>
                                                <%}%>
                                            </div>
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td style="width: 135px">
                                            <asp:Literal ID="litDateFormat" runat="server" Text="Date Format"></asp:Literal>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="frvddlDateFormat" SetFocusOnError="true" InitialValue="00000000-0000-0000-0000-000000000000"
                                                    CssClass="rfv_ErrorStar" runat="server" ValidationGroup="Configuration" ControlToValidate="ddlDateFormat"
                                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td style="width: 230px">
                                            <asp:DropDownList ID="ddlDateFormat" style="width:207px" runat="server">
                                            </asp:DropDownList>
                                            <ajx:BalloonPopupExtender ID="blnDateFormat" runat="server" TargetControlID="ddlDateFormat"
                                                BalloonPopupControlID="pnlDateFormat" Position="BottomRight" BalloonStyle="Cloud"
                                                BalloonSize="Small" UseShadow="false" DisplayOnClick="true" DisplayOnFocus="true" />
                                            <asp:Panel ID="pnlDateFormat" runat="server">
                                                Select Date Format eg. DD/mm/YYYY etc.
                                            </asp:Panel>
                                        </td>
                                        <td style="width: 146px">
                                            <asp:Literal ID="litTimeFomrat" runat="server" Text="Time Format"></asp:Literal>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rfvTimeFormat" SetFocusOnError="true" InitialValue="00000000-0000-0000-0000-000000000000"
                                                    CssClass="rfv_ErrorStar" runat="server" ValidationGroup="Configuration" ControlToValidate="ddlTimerFormat"
                                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlTimerFormat" style="width:207px" runat="server">
                                            </asp:DropDownList>
                                            <ajx:BalloonPopupExtender ID="blnTimeFormat" runat="server" TargetControlID="ddlTimerFormat"
                                                BalloonPopupControlID="pnlTimeFormat" Position="BottomRight" BalloonStyle="Cloud"
                                                BalloonSize="Small" UseShadow="false" DisplayOnClick="true" DisplayOnFocus="true" />
                                            <asp:Panel ID="pnlTimeFormat" runat="server">
                                                Select Time Format eg. MM:HH etc.
                                            </asp:Panel>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="litSMTPAddress" runat="server" Text="SMTP Address"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSMTPAddress" SkinID="CmpTextbox" runat="server" MaxLength="360"></asp:TextBox>
                                            <%--<ajx:BalloonPopupExtender ID="blnSMTPAddress" runat="server" TargetControlID="txtSMTPAddress"
                                                BalloonPopupControlID="pnlSMTPAddress" Position="BottomRight" BalloonStyle="Cloud"
                                                BalloonSize="Small" UseShadow="false" DisplayOnClick="true" DisplayOnFocus="true" />
                                            <asp:Panel ID="pnlSMTPAddress" runat="server">
                                                SMTP Address Line smtp:www.host.com
                                            </asp:Panel>--%>
                                        </td>
                                        <td>
                                            <asp:Literal ID="litDNSName" runat="server" Text="DNS Name"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDNSName" MaxLength="360" SkinID="CmpTextbox" runat="server"></asp:TextBox>
                                            <%--<ajx:BalloonPopupExtender ID="blnDsn" runat="server" TargetControlID="txtDNSName"
                                                BalloonPopupControlID="pnlDNSName" Position="BottomRight" BalloonStyle="Cloud"
                                                BalloonSize="Small" UseShadow="false" DisplayOnClick="true" DisplayOnFocus="true" />
                                            <asp:Panel ID="pnlDNSName" runat="server">
                                                Primary DNS like doamin etc..
                                            </asp:Panel>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="litPOP3Server" runat="server" Text="POP3 Server"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPOP3Server" SkinID="CmpTextbox" runat="server" MaxLength="360"></asp:TextBox>
                                            <%--<ajx:BalloonPopupExtender ID="blnPop3Address" runat="server" TargetControlID="txtPOP3Server"
                                                BalloonPopupControlID="pnlPOP3Server" Position="BottomRight" BalloonStyle="Cloud"
                                                BalloonSize="Small" UseShadow="false" DisplayOnClick="true" DisplayOnFocus="true" />
                                            <asp:Panel ID="pnlPOP3Server" runat="server">
                                                POP3 Address like pop.www.host.com
                                            </asp:Panel>--%>
                                        </td>
                                        <td>
                                            <asp:Literal ID="litPOP3OutGoingServer" runat="server" Text="POP3 OutGoing Server"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPOP3OutGoingServer" SkinID="CmpTextbox" runat="server" MaxLength="360"></asp:TextBox>
                                            <%--<ajx:BalloonPopupExtender ID="blnPop3OutGoingServer" runat="server" TargetControlID="txtPOP3OutGoingServer"
                                                BalloonPopupControlID="pnlPOP3serverOut" Position="BottomRight" BalloonStyle="Cloud"
                                                BalloonSize="Small" UseShadow="false" DisplayOnClick="true" DisplayOnFocus="true" />
                                            <asp:Panel ID="pnlPOP3serverOut" runat="server">
                                                POP3 Address like pop.www.host.com
                                            </asp:Panel>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="litUserName" runat="server" Text="User Name"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtUserName" SkinID="CmpTextbox" runat="server" MaxLength="360"></asp:TextBox>
                                            <%--<ajx:BalloonPopupExtender ID="blnUserName" runat="server" TargetControlID="txtUserName"
                                                BalloonPopupControlID="pnlUserName" Position="BottomRight" BalloonStyle="Cloud"
                                                BalloonSize="Small" UseShadow="false" DisplayOnClick="true" DisplayOnFocus="true" />
                                            <asp:Panel ID="pnlUserName" runat="server">
                                                UserName like 'smith'
                                            </asp:Panel>--%>
                                        </td>
                                        <td>
                                            <asp:Literal ID="litPassword" runat="server" Text="Password"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPassword" runat="server" SkinID="CmpTextbox" TextMode="Password"
                                                MaxLength="360"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="litPrimryEmail" runat="server" Text="Primary Email"></asp:Literal>
                                            <span class="erroraleart">
                                                <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="*" ControlToValidate="txtPrimoryEmail"
                                                    CssClass="rfv_ErrorStar" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                    ValidationGroup="Configuration"></asp:RegularExpressionValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPrimoryEmail" SkinID="CmpTextbox" runat="server" MaxLength="360"></asp:TextBox>
                                            <%-- <ajx:BalloonPopupExtender ID="defaultEmail" runat="server" TargetControlID="txtPrimoryEmail"
                                                BalloonPopupControlID="pnlPrimoryEmail" Position="BottomRight" BalloonStyle="Cloud"
                                                BalloonSize="Small" UseShadow="false" DisplayOnClick="true" DisplayOnFocus="true" />
                                            <asp:Panel ID="pnlPrimoryEmail" runat="server">
                                                Primary Email like 'doamin@domain.com
                                            </asp:Panel>--%>
                                        </td>
                                        <td>
                                            <asp:Literal ID="litPrimoryDomainName" runat="server" Text="Primary Domain Name"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPrimoryDomainName" SkinID="CmpTextbox" runat="server" MaxLength="360"></asp:TextBox>
                                            <%--<ajx:BalloonPopupExtender ID="blpriDomain" runat="server" TargetControlID="txtPrimoryDomainName"
                                                BalloonPopupControlID="pnltxtPrimoryDomainName" Position="BottomRight" BalloonStyle="Cloud"
                                                BalloonSize="Small" UseShadow="false" DisplayOnClick="true" DisplayOnFocus="true" />
                                            <asp:Panel ID="pnltxtPrimoryDomainName" runat="server">
                                                Primary Domain like 'www.primarydomain.com
                                            </asp:Panel>--%>
                                        </td>
                                    </tr>
                                    <tr style="display:none;">
                                        <td colspan="4" class="pagesubheader">
                                            <table>
                                                <tr>
                                                    <td style="padding-right: 12px; padding-left: 95px;">
                                                        <asp:Literal ID="Literal1" runat="server" Text="Mandatory"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="Literal2" runat="server" Text="Optional"></asp:Literal>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr style="display:none;">
                                        <td>
                                            Address
                                        </td>
                                        <td colspan="3" class="readiobuttonarea">
                                            <div style="float: left; padding: 0 50px 0 20px;">
                                                <asp:RadioButton ID="rbtAddressMandatory" runat="server" Checked="true" GroupName="Address" /></div>
                                            <div style="float: left;">
                                                <asp:RadioButton ID="rbtAddressOption" runat="server" Checked="true" GroupName="Address" /></div>
                                        </td>
                                    </tr>
                                    <tr style="display:none;">
                                        <td>
                                            ZipCode
                                        </td>
                                        <td colspan="3" class="readiobuttonarea">
                                            <div style="float: left; padding: 0 50px 0 20px;">
                                                <asp:RadioButton ID="rbtPostCodeMandatory" runat="server" Checked="true" GroupName="PostCode" />
                                            </div>
                                            <div style="float: left;">
                                                <asp:RadioButton ID="rbtPostCodeOption" runat="server" Checked="true" GroupName="PostCode" />
                                            </div>
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td>
                                            Contact No.
                                        </td>
                                        <td colspan="3" class="readiobuttonarea">
                                            <div style="float: left; padding: 0 50px 0 20px;">
                                                <asp:RadioButton ID="rbtContactMandatory" runat="server" Checked="true" GroupName="Contact" />
                                            </div>
                                            <div style="float: left;">
                                                <asp:RadioButton ID="rbtContactOption" runat="server" Checked="true" GroupName="Contact" />
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Email
                                        </td>
                                        <td colspan="3" class="readiobuttonarea">
                                            <div style="float: left; padding: 0 50px 0 20px;">
                                                <asp:RadioButton ID="rbtEmailMandatory" runat="server" Checked="true" GroupName="Email" />
                                            </div>
                                            <div style="float: left;">
                                                <asp:RadioButton ID="rbtEmailOption" runat="server" Checked="true" GroupName="Email" />
                                            </div>
                                        </td>
                                    </tr>                                  
                                    <tr>
                                        <td align="left" valign="top" colspan="4" class="pagecontent_info">
                                            <p class="pageInformation">
                                                <b>Fill Project Term Information have four different part</b><br />
                                                <br />
                                            </p>
                                            1) Manage Project Fix Term Information
                                        </td>
                                    </tr>--%>
                                </table>
                            </td>
                            <td class="boxright">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="boxleft">
                                &nbsp;
                            </td>
                            <td align="right">
                                <div style="float: right; width: auto; display: inline-block;">
                                    <asp:Button ID="btnCancel" Text="Cancel" Style="float: right; margin-left: 5px;"
                                        runat="server" ImageUrl="~/images/cancle.png" CausesValidation="false" OnClick="btnCancel_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                    <asp:Button ID="btnSave" Text="Save" Style="float: right; margin-left: 5px;" runat="server"
                                        ImageUrl="~/images/save.png" ValidationGroup="Configuration" CausesValidation="true"
                                        OnClick="btnSave_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
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
                    <%--<div class="clear">
                        <uc1:MsgBox ID="MessageBox" runat="server" />
                    </div>--%>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updSystemSetUp" ID="UpdateProgressSystemSetUp"
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
