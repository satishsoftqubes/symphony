<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlRateCardList.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.PriceManager.CtrlRateCardList" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script src="../../Javascript/Common.js" type="text/javascript"></script>
<script>
    function pageLoad(sender, args) {

        $(document).ready(function () {
            $("#<%= txtSrchRateName.ClientID %>").autocomplete('../PriceManager/RateCardAutoComplete.ashx');
        });
    }
</script>
<script language="javascript" type="text/javascript">

    function fnConfirmDelete(id) {
        document.getElementById('errormessage').style.display = "block";
        document.getElementById('<%= hdnConfirmDelete.ClientID %>').value = id;
        $find('mpeConfirmDelete').show();
        return false;
    }

    function fnCheckTabKey(e) {
        if (e.charCode == 9) {
            return true
        }
        else {
            return false;
        }
    }

    function fnCheckDate() {

        document.getElementById('errormessage').style.display = "block";
        var varDateFrom = document.getElementById('<%= txtSrchDateFrom.ClientID %>').value;
        var varDateTo = document.getElementById('<%= txtSrchDateTo.ClientID %>').value;

        if (varDateFrom != '' && varDateTo != '') {

            while (varDateFrom.indexOf('-') > -1) {
                varDateFrom = varDateFrom.replace("-", "/")
            }

            while (varDateTo.indexOf('-') > -1) {
                varDateTo = varDateTo.replace("-", "/")
            }

            while (varDateFrom.indexOf('|') > -1) {
                varDateFrom = varDateFrom.replace("|", "/")
            }

            while (varDateTo.indexOf('|') > -1) {
                varDateTo = varDateTo.replace("|", "/")
            }

            var dateFrom = Date.parse(varDateFrom, 'MM/dd/yyyy');
            var dateTo = Date.parse(varDateTo, 'MM/dd/yyyy');

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


    function fnCheckDateNew() {

        document.getElementById('errormessage').style.display = "block";
        var varDateFrom = document.getElementById('<%= txtSrchDateFrom.ClientID %>').value;
        var varDateTo = document.getElementById('<%= txtSrchDateTo.ClientID %>').value;

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

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<asp:UpdatePanel ID="updRateCardList" runat="server">
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
                                <asp:Literal ID="ltrMainHeader" runat="server"></asp:Literal>
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
                                    <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                        <tr>
                                            <td colspan="7">
                                                <%if (IsMessage)
                                                  { %>
                                                <div class="message finalsuccess">
                                                    <p>
                                                        <strong>
                                                            <asp:Label ID="lblMessage" runat="server"></asp:Label></strong>
                                                    </p>
                                                </div>
                                                <%}%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="120px" class="lblsameasth">
                                                <asp:Literal ID="litSrchRateType" runat="server"></asp:Literal>
                                            </td>
                                            <td width="230px">
                                                <asp:DropDownList ID="ddlSrchRateType" runat="server" SkinID="searchddl">
                                                </asp:DropDownList>
                                            </td>
                                            <td width="120px" class="lblsameasth">
                                                <asp:Literal ID="litSrchRateName" runat="server"></asp:Literal>
                                            </td>
                                            <td width="230px">
                                                <asp:TextBox ID="txtSrchRateName" runat="server" SkinID="searchtextbox" MaxLength="65"></asp:TextBox>
                                            </td>
                                            <td style="display: none;" width="80px" class="lblsameasth">
                                                <asp:Literal ID="litSrchRateCode" runat="server"></asp:Literal>
                                            </td>
                                            <td style="display: none;">
                                                <asp:TextBox ID="txtSrchRateCode" runat="server" SkinID="searchtextbox" MaxLength="65"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="display: none;" class="lblsameasth">
                                                <asp:Literal ID="litSrchStayType" runat="server"></asp:Literal>
                                            </td>
                                            <td style="display: none;">
                                                <asp:DropDownList ID="ddlSrchStayType" runat="server" SkinID="searchddl">
                                                </asp:DropDownList>
                                            </td>
                                            <td class="lblsameasth">
                                                <asp:Literal ID="litSrchDateFrom" runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <%--<asp:TextBox ID="txtSrchDateFrom" runat="server" onkeypress="return fnCheckTabKey(event);" SkinID="nowidth"
                                                    Width="140px"></asp:TextBox>--%>
                                                <asp:TextBox ID="txtSrchDateFrom" runat="server" SkinID="nowidth" Width="140px" onkeydown="return stopKey(event);"></asp:TextBox>
                                                <ajx:CalendarExtender ID="calSrchDateFrom" runat="server" Enabled="True" TargetControlID="txtSrchDateFrom"
                                                    PopupButtonID="imgSrchDateFrom">
                                                </ajx:CalendarExtender>
                                                <asp:Image ID="imgSrchDateFrom" runat="server" CssClass="small_img" ImageUrl="~/images/CalanderIcon.png"
                                                    Height="20px" Width="20px" />
                                                <img id="imgDateFrom" style="vertical-align: middle; cursor: auto;" height="14px"
                                                    width="14px" alt="" onclick="fnCleardate('<%= txtSrchDateFrom.ClientID %>');"
                                                    title="<%= strClearDateTooltip %>" src="../../images/clear.png" />
                                            </td>
                                            <td class="lblsameasth">
                                                <asp:Literal ID="litSrchDateTo" runat="server"></asp:Literal>
                                            </td>
                                            <td width="260px">
                                                <asp:TextBox ID="txtSrchDateTo" runat="server" onkeydown="return stopKey(event);"
                                                    SkinID="nowidth" Width="140px"></asp:TextBox>
                                                <ajx:CalendarExtender ID="calSrchDateTo" runat="server" Enabled="True" TargetControlID="txtSrchDateTo"
                                                    PopupButtonID="imgSrchDateTo">
                                                </ajx:CalendarExtender>
                                                <asp:Image ID="imgSrchDateTo" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                    Height="20px" Width="20px" />
                                                <img id="imgClearDateTo" style="vertical-align: middle;" height="14px" width="14px"
                                                    title="<%= strClearDateTooltip %>" alt="" onclick="fnCleardate('<%= txtSrchDateTo.ClientID %>');"
                                                    src="../../images/clear.png" />
                                                <asp:ImageButton ID="btnSearch" runat="server" Style="border: 0px; margin: -4px 0 0 10px;
                                                    vertical-align: middle;" ImageUrl="~/images/search-icon.png" OnClientClick="return fnCheckDateNew();"
                                                    OnClick="btnSearch_Click" />
                                                <asp:ImageButton ID="imgbtnClearSearch" runat="server" ImageUrl="~/images/clearsearch.png"
                                                    Style="border: 0px; vertical-align: middle; margin: -2px 0 0 10px;" OnClick="imgbtnClearSearch_Click"
                                                    OnClientClick="fnDisplayCatchErrorMessage();" />
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="7">
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="7" align="right" valign="middle">
                                                <div style="float: right; display: inline; padding-right: 20px;">
                                                    <asp:Button ID="btnConference" runat="server" OnClick="btnConference_OnClick" Enabled="false"
                                                        Style="float: right;" />
                                                </div>
                                                <div style="float: right; display: inline; padding-right: 20px;">
                                                    <asp:Button ID="btnGDS" runat="server" Style="float: right;" Enabled="false" OnClick="btnGDS_OnClick" />
                                                </div>
                                                <div style="float: right; display: inline; padding-right: 20px;">
                                                    <asp:Button ID="btnPackage" runat="server" Style="float: right;" Enabled="false"
                                                        OnClick="btnPackage_OnClick" />
                                                </div>
                                                <div style="float: right; display: inline; padding-right: 20px;">
                                                    <asp:Button ID="btnCorporate" runat="server" Style="float: right;" OnClick="btnCorporate_OnClick" />
                                                </div>
                                                <div style="float: right; display: inline; padding-right: 20px;">
                                                    <asp:Button ID="btnRoom" runat="server" OnClick="btnRoom_OnClick" Style="float: right;" />
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="7">
                                                <div class="box_head">
                                                    <span>
                                                        <asp:Literal ID="litGridTitleRatecardList" runat="server"></asp:Literal></span></div>
                                                <div class="clear">
                                                </div>
                                                <div class="box_content">
                                                    <asp:GridView ID="gvRateCards" runat="server" AutoGenerateColumns="False" Width="100%"
                                                        OnPageIndexChanging="gvRateCards_OnPageIndexChanging" CssClass="grid_content"
                                                        DataKeyNames="RateID,RateTypeNameToCompare" OnRowDataBound="gvRateCards_RowDataBound"
                                                        OnRowCommand="gvRateCards_RowCommand">
                                                        <Columns>
                                                            <asp:TemplateField ItemStyle-Width="40px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="litGvHdrNumber" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#Container.DataItemIndex+1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrRateCardName" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRateCardName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "RateCardName")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrRateCardCode" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRateCardCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Code")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--<asp:TemplateField ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrRateCardNumber" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRateCardNumber" runat="server" Text=""></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                                                            <asp:TemplateField ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrRateType" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRateType" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "RateTypeName")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="90px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrDateFrom" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDateFrom" runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="90px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrDateTo" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDateTo" runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrDays" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblMinDaysRequired" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "MinimumDaysRequired")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrIsEnable" runat="server" Text="Enable"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="ChkIsEnable" OnCheckedChanged="ChkIsEnable_OnCheckedChanged" AutoPostBack="true"
                                                                        Checked='<%#Eval("IsEnable") %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="80px">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="litGvHdrActions" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%#Container.DataItemIndex %>' ToolTip="Edit"
                                                                        CommandName="EDITDATA"><img src="../../images/file.png" /></asp:LinkButton>
                                                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "RateID")%>' ToolTip="Delete"
                                                                        CommandName="DELETEDATA"><img src="../../images/delete.png" /></asp:LinkButton>
                                                                    <asp:LinkButton ID="lnkPOSCharge" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "RateID")%>' ToolTip="Set POS Charges"
                                                                        CommandName="POSCHARGE"><img src="../../images/file.png" /></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <EmptyDataTemplate>
                                                            <div style="padding: 10px;">
                                                                <b>
                                                                    <asp:Label ID="lblNoRecordFound" runat="server"></asp:Label></h2> </b>
                                                            </div>
                                                        </EmptyDataTemplate>
                                                    </asp:GridView>
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
        <ajx:ModalPopupExtender ID="mpeConfirmDelete" runat="server" TargetControlID="hdnConfirmDelete"
            PopupControlID="pnlDeleteData" BackgroundCssClass="mod_background" CancelControlID="btnCancelDelete"
            BehaviorID="mpeConfirmDelete">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnConfirmDelete" runat="server" />
        <asp:Panel ID="pnlDeleteData" runat="server" Height="350px" Width="325px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="litHeaderConfirmDeletePopup" runat="server"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td align="center" style="padding-bottom: 15px;">
                                <asp:Literal ID="litConfirmDeleteMsg" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnYes" runat="server" Style="display: inline; padding-right: 10px;"
                                    OnClientClick="fnDisplayCatchErrorMessage();" OnClick="btnYes_Click" />
                                <asp:Button ID="btnCancelDelete" runat="server" Style="display: inline;" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpeDateMessage" runat="server" TargetControlID="hfDateMessage"
            PopupControlID="pnlDateMessage" BackgroundCssClass="mod_background" CancelControlID="btnDateMessageOK"
            BehaviorID="mpeDateMessage">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hfDateMessage" runat="server" />
        <asp:Panel ID="pnlDateMessage" runat="server" Width="350px" Style="display: none;">
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
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updRateCardList" ID="UpdateProgressPropertyList"
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
