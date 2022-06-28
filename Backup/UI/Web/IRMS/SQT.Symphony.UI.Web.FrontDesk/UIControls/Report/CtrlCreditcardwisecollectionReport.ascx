<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCreditcardwisecollectionReport.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Report.CtrlCreditcardwisecollectionReport" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript" src="../../Scripts/jquery-1.4.2.min.js"></script>
<script type="text/javascript" src="../../Scripts/jquery-ui-1.8.5.custom.min.js"></script>
<script type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
    function stopKey(evt) {
        var evt = (evt) ? evt : ((event) ? event : null);
        var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
        if ((evt.keyCode == 8) && (node.type == "text")) { return false; }
        else if ((evt.keyCode == 9) && (node.type == "text")) { return true; }
        else if ((evt.keyCode == 46) && (node.type == "text")) { return false; }
        else { return false; }
    }
    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }
</script>
<asp:UpdatePanel ID="updCreditCardCollection" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="content">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                <asp:Literal ID="litMainHeader" runat="server" Text="Credit card wise Collection"></asp:Literal>
                            </td>
                            <td class="boxtopright">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="boxleft">
                                &nbsp;
                            </td>
                            <td align="left">
                                <div class="box_form">
                                    <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                        <tr>
                                            <td>
                                                <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                    <tr>
                                                        <td width="50px">
                                                            <asp:Literal ID="litSearchName" runat="server" Text="Name"></asp:Literal>
                                                        </td>
                                                        <td width="170px">
                                                            <asp:TextBox ID="txtSearchName" runat="server" Style="width: 140px !important;" SkinID="searchtextbox"></asp:TextBox>
                                                        </td>
                                                        <td width="50px">
                                                            <asp:Literal ID="litSearchCreditCard" runat="server" Text="Card No."></asp:Literal>
                                                        </td>
                                                        <td width="170px">
                                                            <asp:TextBox ID="txtSearchCreditCard" runat="server" Style="width: 140px !important;"
                                                                SkinID="searchtextbox"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 60px;">
                                                            <asp:Literal ID="litSearchStartDate" Text="Start Date" runat="server"></asp:Literal>
                                                        </td>
                                                        <td style="width: 176px;">
                                                            <asp:TextBox ID="txtSearchStartDate" Width="100px" runat="server" SkinID="nowidth"
                                                                onkeydown="return stopKey(event);"></asp:TextBox>
                                                            <asp:Image ID="imgCalInqStartDate" ToolTip="Choose Start Date" CssClass="small_img"
                                                                runat="server" ImageUrl="~/images/CalanderIcon.png" Height="20px" Width="20px" />
                                                            <ajx:CalendarExtender ID="calInqStartDate" PopupButtonID="imgCalInqStartDate" TargetControlID="txtSearchStartDate"
                                                                runat="server">
                                                            </ajx:CalendarExtender>
                                                            <img src="../../images/clear.png" title="Clear Date" id="imgClearDate" style="vertical-align: middle;"
                                                                onclick="fnClearDate('<%= txtSearchStartDate.ClientID %>');" />
                                                        </td>
                                                        <td style="width: 65px;">
                                                            <asp:Literal ID="litSearchEndDate" Text="End Date" runat="server"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtSearchSearchEndDate" runat="server" SkinID="nowidth" Width="100px"
                                                                onkeydown="return stopKey(event);"></asp:TextBox>
                                                            <asp:Image ID="imgCalSearchEndDate" ToolTip="Choose End Date" CssClass="small_img"
                                                                runat="server" ImageUrl="~/images/CalanderIcon.png" Height="20px" Width="20px" />
                                                            <ajx:CalendarExtender ID="calSearchInqGuestDeptDate" PopupButtonID="imgCalSearchEndDate"
                                                                TargetControlID="txtSearchSearchEndDate" runat="server">
                                                            </ajx:CalendarExtender>
                                                            <img src="../../images/clear.png" title="Clear Date" id="imgClearSearchInqGuestDeptDate"
                                                                style="vertical-align: middle;" onclick="fnClearDate('<%= txtSearchSearchEndDate.ClientID %>');" />
                                                            <asp:ImageButton ID="imtbtnSearchCreditCard" ToolTip="Search" runat="server" ImageUrl="~/images/search-icon.png"
                                                                Style="border: 0px; vertical-align: middle; display: inline" OnClick="imtbtnSearchCreditCard_Click"
                                                                ValidationGroup="IsSearchInq" OnClientClick="return fnCheckSearchDate();" />
                                                            <asp:ImageButton ID="imtbtnSearchClearCreditCard" ToolTip="Reset" runat="server"
                                                                ImageUrl="~/images/clearsearch.png" Style="border: 0px; vertical-align: middle;
                                                                margin: -2px 0 0 10px;" OnClientClick="fnDisplayCatchErrorMessage();" OnClick="imtbtnSearchClearCreditCard_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="8">
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div class="box_head">
                                                    <span>
                                                        <asp:Literal ID="litGuestList" runat="server" Text="Credit card wise Collection List"></asp:Literal>
                                                    </span>
                                                </div>
                                                <div class="clear">
                                                </div>
                                                <div class="box_content">
                                                    <asp:GridView ID="gvCreditCardCollection" runat="server" AutoGenerateColumns="false"
                                                        ShowHeader="true" Width="100%" OnRowCommand="gvCreditCardCollection_RowCommand"
                                                        OnPageIndexChanging="gvCreditCardCollection_PageIndexChanging" OnRowDataBound="gvCreditCardCollection_RowDatabound">
                                                        <Columns>
                                                            <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrTransDate" runat="server" Text="Date"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGvTransDeptlDate" runat="server"></asp:Label>
                                                                    <%--<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "TransDate")).ToString(clsSession.DateFormat)%>--%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrGuestName" runat="server" Text="Guest Name"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "GuestName")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="125px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrAcctName" runat="server" Text="Card No."></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "CardNo")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Right">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrTotalAmount" runat="server" Text="Total Amount"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "TotalAmount")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblActions" runat="server" Text="Action"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPopUp" runat="server" Text="Actions"></asp:Label>
                                                                    <ajx:HoverMenuExtender ID="hmeAction" runat="server" TargetControlID="lblPopUp" PopupControlID="pnlAction"
                                                                        PopupPosition="Left">
                                                                    </ajx:HoverMenuExtender>
                                                                    <asp:Panel ID="pnlAction" runat="server" Style="visibility: hidden; opacity: 100%">
                                                                        <div class="actionsbuttons_hovermenu">
                                                                            <table border="0" cellpadding="0" cellspacing="0" class="actionsbuttons_hover_lettmenu_table">
                                                                                <tr>
                                                                                    <td class="actionsbuttons_hover_lettmenu">
                                                                                    </td>
                                                                                    <td class="actionsbuttons_hover_centermenu">
                                                                                        <ul>
                                                                                            <li>
                                                                                                <asp:LinkButton ID="lnkViewDetailTransaction" Style="background: none !important;
                                                                                                    border: none;" runat="server" ToolTip="View Detail" CommandName="VIEWDETAILTRANSACTION"
                                                                                                    CommandArgument='<%#String.Concat(DataBinder.Eval(Container.DataItem, "GuestName"), "|", DataBinder.Eval(Container.DataItem, "TransDate"), "|", DataBinder.Eval(Container.DataItem, "AcctID"))%>'><img src="../../images/file.png" /></asp:LinkButton></li>
                                                                                        </ul>
                                                                                    </td>
                                                                                    <td class="actionsbuttons_hover_rightmenu">
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </asp:Panel>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <EmptyDataTemplate>
                                                            <div style="padding: 10px;">
                                                                <b>
                                                                    <asp:Label ID="lblNoRecordFound" runat="server" Text="No record Found"></asp:Label>
                                                                </b>
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
                            </td>
                        </tr>
                        <tr>
                            <td class="boxbottomleft">
                            </td>
                            <td class="boxbottomcenter">
                            </td>
                            <td class="boxbottomright">
                            </td>
                        </tr>
                    </table>
                    <div class="clear_divider">
                    </div>
                    <div class="clear">
                    </div>
                </td>
            </tr>
        </table>
        <ajx:ModalPopupExtender ID="mpeCreditCardDetailsTransaction" runat="server" TargetControlID="hfCreditCardDetailsTransaction"
            PopupControlID="pnlCreditCardDetailsTransaction" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hfCreditCardDetailsTransaction" runat="server" />
        <asp:Panel ID="pnlCreditCardDetailsTransaction" runat="server" Style="display: none;
            min-height: 150px; min-width: 350px;">
            <div class="box_col1">
                <div class="box_head">
                    <div style="display: inline;">
                        <span>
                            <asp:Literal ID="Literal25" runat="server" Text="Credit card Detail Transaction"></asp:Literal></span></div>
                    <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                        <asp:ImageButton ID="iBtnSuggestedAmountClosePopup" runat="server" ImageUrl="~/images/closepopup.png"
                            Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;" />
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%" style="margin-top: 0px;">
                        <tr>
                            <td style="padding-bottom: 15px;">
                                <div class="box_head">
                                    <span>
                                        <asp:Literal ID="Literal1" runat="server" Text="Credit card Detail Transaction List"></asp:Literal>
                                    </span>
                                </div>
                                <div class="clear">
                                </div>
                                <div class="box_content">
                                    <asp:GridView ID="gvCreditCardCollectionDetail" runat="server" AutoGenerateColumns="false"
                                        ShowHeader="true" Width="100%">
                                        <Columns>
                                            <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrTransNo" runat="server" Text="Trans#"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "BookNo")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Right">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrTotalAmount" runat="server" Text="Amount"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "TotalAmount")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <div style="padding: 10px;">
                                                <b>
                                                    <asp:Label ID="lblNoRecordFound" runat="server" Text="No record Found"></asp:Label>
                                                </b>
                                            </div>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </div>
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
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updCreditCardCollection" ID="UpdateProgressCheckInList"
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
