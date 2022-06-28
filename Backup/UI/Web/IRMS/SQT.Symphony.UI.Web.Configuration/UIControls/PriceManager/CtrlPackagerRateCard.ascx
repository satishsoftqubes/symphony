<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlPackagerRateCard.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.PriceManager.CtrlPackagerRateCard" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<%@ Register Src="~/UIControls/PriceManager/CtrlRateCardBasicInfo.ascx" TagName="CtrlRateCardBasicInfo"
    TagPrefix="uc" %>
<%@ Register Src="~/UIControls/PriceManager/CtrlRateCardTaxes.ascx" TagName="CtrlRateCardTaxes"
    TagPrefix="uc" %>
<%@ Register Src="~/UIControls/PriceManager/CtrlRateCardServices.ascx" TagName="CtrlRateCardServices"
    TagPrefix="uc" %>
<%@ Register Src="~/UIControls/PriceManager/CtrlRateCardRoomTypes.ascx" TagName="CtrlRateCardRoomTypes"
    TagPrefix="uc" %>
<%@ Register Src="~/UIControls/PriceManager/CtrlRateCardTermsAndConditions.ascx"
    TagName="CtrlRateCardTermsAndConditions" TagPrefix="uc" %>
<%@ Register Src="~/UIControls/PriceManager/CtrlRateCardCheckInDays.ascx" TagName="CtrlRateCardCheckInDays"
    TagPrefix="uc" %>
<script src="../../Javascript/Common.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript">
    function pageLoad(sender, args) {
        $(function () {
            $("#tabs").tabs();
        });
    }

    function fnCheckDate() {
        if (Page_ClientValidate("IsRequire")) {

            document.getElementById('errormessage').style.display = "block";
            var varDateFrom = document.getElementById('ContentPlaceHolder1_ucPackagerRateCard_ucRateCardBasicInfo_txtDateFrom').value;
            var varDateTo = document.getElementById('ContentPlaceHolder1_ucPackagerRateCard_ucRateCardBasicInfo_txtDateTo').value;

            if (varDateFrom != '' && varDateTo != '') {
                var dateFormat = document.getElementById('<%= hfDateFormat.ClientID %>').value;
                var dateFrom = fnGetValidDateFormat(varDateFrom, dateFormat);
                var dateTo = fnGetValidDateFormat(varDateTo, dateFormat);

                dateFrom = Date.parse(dateFrom, 'MM/dd/yyyy');
                dateTo = Date.parse(dateTo, 'MM/dd/yyyy');

                if (dateFrom > dateTo) {
                    $find('mpeDateMessage').show();
                    return false;
                }
                else {
                    return true;
                }
            }
            else {
                return true;
            }
        }
        else {
            return false;
        }
    }

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<asp:UpdatePanel ID="updPropertyList" runat="server">
    <ContentTemplate>
        <asp:HiddenField ID="hfDateFormat" runat="server" />
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
                                &nbsp;
                            </td>
                            <td>
                                <div class="box_form">
                                    <div class="demo">
                                        <div id="tabs">
                                            <ul>
                                                <li><a href="#tabs-1">
                                                    <asp:Literal ID="litTabBasicInformation" runat="server"></asp:Literal></a></li>
                                                <li><a href="#tabs-2">
                                                    <asp:Literal ID="litTabTermsAndConditions" runat="server"></asp:Literal></a></li>
                                            </ul>
                                            <div id="tabs-1">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:UpdatePanel ID="uPnlMessage" runat="server">
                                                                <ContentTemplate>
                                                                    <%if (IsListMessage)
                                                                      { %>
                                                                    <div class="message finalsuccess">
                                                                        <p>
                                                                            <strong>
                                                                                <asp:Literal ID="litMsgList" runat="server"></asp:Literal></strong>
                                                                        </p>
                                                                    </div>
                                                                    <%}%>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <div style="float: right; padding-bottom: 5px;">
                                                                <b>
                                                                    <asp:Literal ID="litGeneralMandartoryFiledMessage" runat="server"></asp:Literal>
                                                                </b>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="38%" style="vertical-align: top;">
                                                            <uc:CtrlRateCardBasicInfo ID="ucRateCardBasicInfo" runat="server"></uc:CtrlRateCardBasicInfo>
                                                        </td>
                                                        <td width="62%" style="vertical-align: top;">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td width="40%" align="left" style="vertical-align: top;">
                                                                        <uc:CtrlRateCardTaxes ID="ucRateCardTaxes" runat="server"></uc:CtrlRateCardTaxes>
                                                                    </td>
                                                                    <td width="60%" align="left" style="vertical-align: top;">
                                                                        <uc:CtrlRateCardServices ID="ucRateCardServices" runat="server"></uc:CtrlRateCardServices>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" align="left" style="vertical-align: top; padding-top: 10px;">
                                                                        <uc:CtrlRateCardCheckInDays ID="ucRateCardCheckInDays" runat="server"></uc:CtrlRateCardCheckInDays>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <div class="content_checkbox">
                                                    <uc:CtrlRateCardRoomTypes ID="ucRateCardRoomTypes" runat="server" />
                                                </div>
                                                <div style="padding-top: 10px; margin-top: 15px; float: right; width: auto; display: inline-block;">
                                                    <asp:Button ID="btnCancel" Style="float: right; margin-left: 5px;" runat="server"
                                                        ImageUrl="~/images/cancle.png" CausesValidation="false" OnClick="btnCancel_OnClick" />
                                                    <asp:Button ID="btnSave" Style="float: right; margin-left: 5px;" runat="server" ImageUrl="~/images/save.png"
                                                        ValidationGroup="IsRequire" OnClientClick="return fnCheckDate();" CausesValidation="true"
                                                        OnClick="btnSave_OnClick" />
                                                    <asp:Button ID="btnBackToList" Style="float: right; margin-left: 5px;" runat="server"
                                                        ImageUrl="~/images/cancle.png" CausesValidation="false" OnClick="btnBackToList_OnClick" />
                                                </div>
                                                <ajx:ModalPopupExtender ID="mpeDateMessage" runat="server" TargetControlID="hfDateMessage"
                                                    PopupControlID="pnlDateMessage" BackgroundCssClass="mod_background" CancelControlID="btnDateMessageOK"
                                                    BehaviorID="mpeDateMessage">
                                                </ajx:ModalPopupExtender>
                                                <asp:HiddenField ID="hfDateMessage" runat="server" />
                                                <asp:Panel ID="pnlDateMessage" runat="server" Width="350px">
                                                    <div class="box_col1">
                                                        <div class="box_head">
                                                            <span>
                                                                <asp:Literal ID="ltrHeaderDateValidate" runat="server"></asp:Literal></span></div>
                                                        <div class="clear">
                                                        </div>
                                                        <div class="box_form">
                                                            <table cellpadding="2" cellspacing="2" width="100%">
                                                                <tr>
                                                                    <td align="center" style="padding-bottom: 15px;">
                                                                        <asp:Literal ID="ltrMsgDateValidate" runat="server"></asp:Literal>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center">
                                                                        <asp:Button ID="btnDateMessageOK" runat="server" Style="display: inline; padding-right: 10px;" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                        <div class="clear">
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                            </div>
                                            <div id="tabs-2">
                                                <uc:CtrlRateCardTermsAndConditions ID="ucTermsAndConditions" runat="server"></uc:CtrlRateCardTermsAndConditions>
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
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdateProgress AssociatedUpdatePanelID="updPropertyList" ID="UpdateProgressPropertyList"
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
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
