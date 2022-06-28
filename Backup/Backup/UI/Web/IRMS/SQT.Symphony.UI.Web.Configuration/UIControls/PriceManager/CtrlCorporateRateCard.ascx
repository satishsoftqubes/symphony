<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCorporateRateCard.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.PriceManager.CtrlCorporateRateCard" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<%@ Register Src="~/UIControls/PriceManager/CtrlRateCardBasicInfo.ascx" TagName="CtrlRateCardBasicInfo"
    TagPrefix="uc" %>
<%@ Register Src="~/UIControls/PriceManager/CtrlRateCardTaxes.ascx" TagName="CtrlRateCardTaxes"
    TagPrefix="uc" %>
<%@ Register Src="~/UIControls/PriceManager/CtrlRateCardServices.ascx" TagName="CtrlRateCardServices"
    TagPrefix="uc" %>
<%@ Register Src="~/UIControls/PriceManager/CtrlRateCardCheckInDays.ascx" TagName="CtrlRateCardCheckInDays"
    TagPrefix="uc" %>
<%@ Register Src="~/UIControls/PriceManager/CtrlRateCardRoomTypes.ascx" TagName="CtrlRateCardRoomTypes"
    TagPrefix="uc" %>
<%@ Register Src="~/UIControls/PriceManager/CtrlRateCardCorporates.ascx" TagName="CtrlRateCardCorporates"
    TagPrefix="uc" %>
<%@ Register Src="~/UIControls/PriceManager/CtrlRateCardTermsAndConditions.ascx"
    TagName="CtrlRateCardTermsAndConditions" TagPrefix="uc" %>
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
            var varDateFrom = document.getElementById('ContentPlaceHolder1_ucCorporateRateCard_ucRateCardBasicInfo_txtDateFrom').value;
            var varDateTo = document.getElementById('ContentPlaceHolder1_ucCorporateRateCard_ucRateCardBasicInfo_txtDateTo').value;

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
                                                <td width="40%" align="left" style="vertical-align: top; border-right: 1px solid gray;">
                                                    <div style="float: right; width: auto; display: inline-block;">
                                                        <asp:LinkButton ID="lnkCalculateTax" runat="server" Style="color: #0067A4;" Text="Calculate Tax"
                                                            OnClick="lnkCalculateTax_Click"></asp:LinkButton>
                                                    </div>
                                                    <uc:CtrlRateCardTaxes ID="ucRateCardTaxes" runat="server"></uc:CtrlRateCardTaxes>
                                                </td>
                                                <td width="60%" align="left" style="vertical-align: top;">
                                                    <%--<uc:CtrlRateCardServices ID="ucRateCardServices" runat="server"></uc:CtrlRateCardServices>--%>
                                                    <asp:UpdatePanel ID="upnpnlforSD" runat="server">
                                                        <ContentTemplate>
                                                            <div style="padding-bottom: 5px;">
                                                                <table cellpadding="2" cellspacing="2" width="100%" border="0">
                                                                    <tr>
                                                                        <td>
                                                                            <div style="float: left;">
                                                                                <h1>
                                                                                    <asp:Literal ID="litHeaderSpecialDays" runat="server" Text="Special Days"></asp:Literal>
                                                                                </h1>
                                                                            </div>
                                                                            <div style="float: right;">
                                                                                <asp:Button ID="btnAddSpecialDays" runat="server" Text="Add" OnClick="btnAddSpecialDays_Click" /></div>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <hr />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <div style="height: 155px; overflow: auto;">
                                                                                <div class="clear">
                                                                                </div>
                                                                                <div class="box_content">
                                                                                    <asp:GridView ID="gvDispalySpecialDays" runat="server" AutoGenerateColumns="false"
                                                                                        Width="100%" ShowHeader="true" SkinID="gvNoPaging" DataKeyNames="EventDate" OnRowCommand="gvDispalySpecialDays_OnRowCommand">
                                                                                        <Columns>
                                                                                            <%-- <asp:TemplateField ItemStyle-Width="30px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                            <HeaderTemplate>
                                                                                                <asp:Literal ID="litGvHdrSpecialDaysNumber" runat="server" Text="No."></asp:Literal>
                                                                                            </HeaderTemplate>
                                                                                            <ItemTemplate>
                                                                                                <%#Container.DataItemIndex+1 %>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>--%>
                                                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                <HeaderTemplate>
                                                                                                    <asp:Literal ID="litGvHdrSpecialDaysDisplayDate" runat="server" Text="Title"></asp:Literal>
                                                                                                </HeaderTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblSpecialDaysDisplayTitle" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "EventName")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField ItemStyle-Width="85px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                <HeaderTemplate>
                                                                                                    <asp:Literal ID="litGvHdrDisplayTitle" runat="server" Text="Date"></asp:Literal>
                                                                                                </HeaderTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblSpecialDaysDisplayDate" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "EventDate")).ToString(clsSession.DateFormat)%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                <HeaderTemplate>
                                                                                                    <asp:Label ID="lblGvHdrAction" runat="server" Text="Actions"></asp:Label>
                                                                                                </HeaderTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <asp:LinkButton ID="lnkEditSpecialDays" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "EventDate")%>'
                                                                                                        CommandName="EDITDATA" OnClientClick="fnDisplayCatchErrorMessage();" ToolTip="Edit"><img src="../../images/file.png" /></asp:LinkButton>
                                                                                                    <asp:LinkButton ID="lnkDeleteSpecialDays" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "EventDate")%>'
                                                                                                        CommandName="DELETEDATA" ToolTip="Delete"><img src="../../images/delete.png" /></asp:LinkButton>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                        <EmptyDataTemplate>
                                                                                            <div style="padding: 10px;">
                                                                                                <b>
                                                                                                    <asp:Literal ID="litDisplaySpecialDaysNoRecordFound" runat="server" Text="No record found."></asp:Literal>
                                                                                                </b>
                                                                                            </div>
                                                                                        </EmptyDataTemplate>
                                                                                    </asp:GridView>
                                                                                </div>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                    <asp:UpdateProgress AssociatedUpdatePanelID="upnpnlforSD" ID="uprgforSD" runat="server">
                                                        <ProgressTemplate>
                                                            <div id="progressBackgroundFilter">
                                                            </div>
                                                            <div id="processMessage">
                                                                <center>
                                                                    <img src="../../images/ajax-loader.gif" /></center>
                                                            </div>
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="left" style="vertical-align: top; padding-top: 10px;">
                                                    <uc:CtrlRateCardCheckInDays ID="ucRateCardCheckInDays" runat="server" Visible="false">
                                                    </uc:CtrlRateCardCheckInDays>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <div class="content_checkbox">
                                <uc:CtrlRateCardRoomTypes ID="ucRateCardRoomTypes" runat="server"></uc:CtrlRateCardRoomTypes>
                            </div>
                            <div style="padding-top: 15px;" class="content_checkbox">
                                <uc:CtrlRateCardCorporates ID="ucRateCardCorporates" runat="server"></uc:CtrlRateCardCorporates>
                            </div>
                            <asp:UpdatePanel ID="updCorporateRateCard" runat="server">
                                <ContentTemplate>
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
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:UpdateProgress AssociatedUpdatePanelID="updCorporateRateCard" ID="uprgCorporateRateCard"
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
            <%--<div id="errormessage" class="clear" style="display: none;">
                <uc1:MsgBox ID="MessageBox" runat="server" />
            </div>--%>
        </td>
    </tr>
</table>
<asp:UpdatePanel ID="updAddEditSpecialDays" runat="server">
    <ContentTemplate>
        <ajx:ModalPopupExtender ID="mpeAddEditSpecialDays" runat="server" TargetControlID="hdnAddEditSpecialDays"
            PopupControlID="pnlAddEditSpecialDays" BackgroundCssClass="mod_background" CancelControlID="btnCloseSpecialDays">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnAddEditSpecialDays" runat="server" />
        <asp:Panel ID="pnlAddEditSpecialDays" runat="server" Height="500px" Width="700px"
            Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="ltrHeaderAddEditSpecialDays" runat="server" Text="Special Days"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%" border="0">
                        <tr>
                            <td>
                                <asp:Literal ID="litSpecialDaysTitle" runat="server" Text="Title"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSpecialDaysTitle" SkinID="searchtextbox" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rvfSpecialDaysTitel" runat="server" ControlToValidate="txtSpecialDaysTitle"
                                    SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequireSpecialDays"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:Literal ID="litSpecialDaysDate" runat="server" Text="Date"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSpecialDaysDate" SkinID="searchtextbox" onkeydown="return stopKey(event);"
                                    runat="server"></asp:TextBox>
                                <ajx:CalendarExtender ID="calDate" runat="server" Enabled="True" TargetControlID="txtSpecialDaysDate"
                                    PopupButtonID="imgDateFrom">
                                </ajx:CalendarExtender>
                                <asp:Image ID="imgDateFrom" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                    Height="20px" Width="20px" />
                                <img id="imgClearDate" style="vertical-align: middle;" height="14px" width="14px"
                                    title="<%= strClearDateTooltip %>" alt="" onclick="fnClearDate('<%= txtSpecialDaysDate.ClientID %>');"
                                    src="../../images/clear.png" />
                                <asp:RequiredFieldValidator ID="rfvSpecialDaysDate" runat="server" ControlToValidate="txtSpecialDaysDate"
                                    SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequireSpecialDays"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <div style="height: 250px; overflow: auto;">
                                    <div class="clear">
                                    </div>
                                    <div class="box_content">
                                        <asp:GridView ID="gvSpecialDays" runat="server" AutoGenerateColumns="false" Width="100%"
                                            ShowHeader="true" SkinID="gvNoPaging" DataKeyNames="RoomTypeID,EventDate" OnRowDataBound="gvSpecialDays_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField ItemStyle-Width="30px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Literal ID="litGvHdrNumber" runat="server" Text="No."></asp:Literal>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#Container.DataItemIndex+1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Literal ID="litGvHdrSpecialDaysRoomType" runat="server" Text="Room Type"></asp:Literal>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSpecialDaysRoomTypeName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "RoomTypeName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Literal ID="litGvHdrDiscountType" runat="server"></asp:Literal>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="ddlDiscountType" runat="server" Style="width: 125px;" SkinID="searchddl">
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Literal ID="litGvHdrDiscountCharges" runat="server" Text="Charges"></asp:Literal>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtDiscountCharges" runat="server" Text="0.00" SkinID="searchtextbox"
                                                            Style="text-align: right; width: 110px;" MaxLength="15"></asp:TextBox>
                                                        <ajx:FilteredTextBoxExtender ID="ftDiscountCharges" runat="server" TargetControlID="txtDiscountCharges"
                                                            FilterMode="ValidChars" ValidChars="-0123456789.">
                                                        </ajx:FilteredTextBoxExtender>
                                                        <asp:RequiredFieldValidator ID="rvfSpecialDaysTitel" runat="server" ControlToValidate="txtDiscountCharges"
                                                            SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequireSpecialDays"></asp:RequiredFieldValidator>
                                                        <%--<asp:RangeValidator ID="rngvDiscountCharges" runat="server" ControlToValidate="txtDiscountCharges"
                                                        SetFocusOnError="true" Type="Double" Display="Dynamic" ValidationGroup="IsRequireSpecialDays"
                                                        CssClass="input-notification error png_bg"></asp:RangeValidator>--%>
                                                        <%--<asp:RegularExpressionValidator ID="revDiscountCharges" SetFocusOnError="True" runat="server"
                                                        ValidationGroup="IsRequireSpecialDays" ControlToValidate="txtDiscountCharges"
                                                        ValidationExpression="^\d{0,18}(\.\d{0,2})?$" Display="Dynamic" CssClass="input-notification error png_bg"></asp:RegularExpressionValidator>--%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <div style="padding: 10px;">
                                                    <b>
                                                        <asp:Literal ID="litSpecialDaysNoRecordFound" runat="server" Text="No record found."></asp:Literal>
                                                    </b>
                                                </div>
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center">
                                <asp:Button ID="btnSaveSpecialDays" runat="server" ValidationGroup="IsRequireSpecialDays"
                                    Text="Save" CausesValidation="true" Style="display: inline; padding-left: 5px;"
                                    OnClick="btnSaveSpecialDays_Click" />
                                <asp:Button ID="btnCloseSpecialDays" runat="server" Text="Cancel" Style="display: inline;" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdateProgress AssociatedUpdatePanelID="updAddEditSpecialDays" ID="upgrsAddEditSpecialDays"
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
