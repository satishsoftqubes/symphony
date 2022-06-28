<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCounterClose.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls.CtrlCounterClose" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCounterCloseHistoryOnThisMachine.ascx"
    TagName="CounterCloseHistoryOnThisMachine" TagPrefix="ucCounterCloseHistoryOnThisMachine" %>
<script type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<script language="javascript">

    function openViewer() {
        var Preview = '<%=IsPreview%>';
        window.open("../../ReportFiles/frmViewer.aspx?preview=" + Preview);
    }
</script>
<asp:UpdatePanel ID="updCounterClose" runat="server">
    <ContentTemplate>
        <asp:HiddenField ID="hdnPaidOutCash" runat="server" />
        <asp:MultiView ID="mvCloseCounter" runat="server">
            <asp:View ID="vCounterList" runat="server">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="content" style="padding-left: 0px; width: 66.66%">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="boxtopleft">
                                        &nbsp;
                                    </td>
                                    <td class="boxtopcenter">
                                        <asp:Literal ID="litMainHeaderCounterClose" runat="server" Text="Close Counter"></asp:Literal>
                                    </td>
                                    <td class="boxtopright">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="boxleft">
                                    </td>
                                    <td align="left"> 
                                        <div class="box_form">
                                            <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                <tr>
                                                    <td style="width: 55px;">
                                                        &nbsp;
                                                        <%--    <asp:Literal ID="litUser" runat="server" Text="User"></asp:Literal>--%>
                                                    </td>
                                                    <td style="width: 800px;">
                                                        &nbsp;
                                                        <%--<asp:DropDownList ID="ddlUser" Style="height: 25px; width: 170px;" runat="server">
                                                </asp:DropDownList>--%>
                                                    </td>
                                                    <td style="width: 65px;">
                                                        <asp:Literal ID="litCounter" runat="server" Text="Counter"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="litDisplayCounter" runat="server"></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <hr />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                            <tr>
                                                                <td width="60%" style="border-right: 1px solid #DCDDDF; vertical-align: top;">
                                                                    <div class="box_head">
                                                                        <span>
                                                                            <asp:Literal ID="litCounterDetails" runat="server" Text="Counter Details"></asp:Literal>
                                                                        </span>
                                                                    </div>
                                                                    <div class="clear">
                                                                    </div>
                                                                    <div class="box_content">
                                                                        <div style="height: 320px; overflow: auto;">
                                                                            <asp:GridView ID="gvCounterDetails" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                                Width="100%" OnRowCommand="gvCounterDetails_RowCommand" OnRowDataBound="gvCounterDetails_RowDataBound"
                                                                                DataKeyNames="PayType,Code,AcctID,isReadOnly,NewTransID,OldTransID,AdjustedAmount"
                                                                                SkinID="gvNoPaging">
                                                                                <Columns>
                                                                                    <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <%# Container.DataItemIndex + 1 %>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField FooterStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Left"
                                                                                        ItemStyle-HorizontalAlign="Left">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblGvHdrDescription" runat="server" Text="Particulars"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkPayments" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "PayType")%>'
                                                                                                CommandArgument='<%#DataBinder.Eval(Container.DataItem, "Code")%>' CommandName="SHOWHISTORY"></asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField ItemStyle-Width="125px" FooterStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right"
                                                                                        ItemStyle-HorizontalAlign="Right">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblGvHdrAmount" runat="server" Text="As per System"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblGvSystemAmount" runat="server"></asp:Label></b>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField ItemStyle-Width="150px" FooterStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right"
                                                                                        ItemStyle-HorizontalAlign="Right">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblGvHdrNetAmount" runat="server" Text="As per Physical"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:TextBox ID="txtGvNetAmount" AutoPostBack="true" OnTextChanged="txtGvNetAmount_TextChanged"
                                                                                                runat="server" Style="text-align: right; width: 100px;" MaxLength="15"></asp:TextBox>
                                                                                            <ajx:FilteredTextBoxExtender ID="ftGvNetAmount" runat="server" TargetControlID="txtGvNetAmount"
                                                                                                FilterType="Custom, Numbers" ValidChars="." />
                                                                                            <asp:RequiredFieldValidator ID="rvfNetAmount" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                                                runat="server" ValidationGroup="IsRequire" ControlToValidate="txtGvNetAmount"
                                                                                                Display="Static">
                                                                                            </asp:RequiredFieldValidator>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField ItemStyle-Width="125px" FooterStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right"
                                                                                        ItemStyle-HorizontalAlign="Right">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblGvHdrDifference" runat="server" Text="Difference"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblGvDifference" runat="server"></asp:Label></b>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                                <EmptyDataTemplate>
                                                                                    <div style="padding: 10px;">
                                                                                        <b>
                                                                                            <asp:Label ID="lblNoRecordFound" runat="server" Text="No Record Found."></asp:Label>
                                                                                        </b>
                                                                                    </div>
                                                                                </EmptyDataTemplate>
                                                                            </asp:GridView>
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                                <td style="vertical-align: top;">
                                                                    <div class="box_head">
                                                                        <span>
                                                                            <asp:Literal ID="Literal2" runat="server" Text="Denomination List"></asp:Literal>
                                                                        </span>
                                                                    </div>
                                                                    <div class="clear">
                                                                    </div>
                                                                    <div class="box_content">
                                                                        <div style="height: 320px; overflow: auto;">
                                                                            <asp:GridView ID="gvDenominationList" runat="server" AutoGenerateColumns="false"
                                                                                ShowHeader="true" Width="100%" OnRowDataBound="gvDenominationList_RowDataBound"
                                                                                DataKeyNames="CurrencyValue,CurrencyCode,CurrencyName" SkinID="gvNoPaging" ShowFooter="true">
                                                                                <Columns>
                                                                                    <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <%# Container.DataItemIndex + 1 %>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField FooterStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"
                                                                                        ItemStyle-HorizontalAlign="Left" Visible="false">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblGvHdrCURType" runat="server" Text="CUR Type"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblGvCurrencyType" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CurrencyType")%>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField ItemStyle-Width="100px" FooterStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"
                                                                                        ItemStyle-HorizontalAlign="Left">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblGvHdrValue" runat="server" Text="Value"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblGvValue" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CurrencyName")%>'></asp:Label></b>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField ItemStyle-Width="50px" FooterStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right"
                                                                                        ItemStyle-HorizontalAlign="Right">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblGvHdrQty" runat="server" Text="Qty"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:TextBox ID="txtGvQty" AutoPostBack="true" OnTextChanged="txtGvQty_TextChanged"
                                                                                                runat="server" Style="text-align: right; width: 40px;"></asp:TextBox>
                                                                                            <ajx:FilteredTextBoxExtender ID="ftQty" runat="server" TargetControlID="txtGvQty"
                                                                                                FilterType="Numbers" />
                                                                                        </ItemTemplate>
                                                                                        <FooterTemplate>
                                                                                            <b>Total:</b>
                                                                                        </FooterTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField ItemStyle-Width="125px" FooterStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right"
                                                                                        ItemStyle-HorizontalAlign="Right">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblGvHdrTotal" runat="server" Text="Total"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblGvTotal" runat="server" Style="text-align: right; width: 75px;"></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <FooterTemplate>
                                                                                            <b>
                                                                                                <asp:Label ID="lblGvFtrTotal" runat="server" Text="0.00"></asp:Label></b>
                                                                                        </FooterTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                                <EmptyDataTemplate>
                                                                                    <div style="padding: 10px;">
                                                                                        <b>
                                                                                            <asp:Label ID="lblNoRecordFound" runat="server" Text="No Record Found."></asp:Label>
                                                                                        </b>
                                                                                    </div>
                                                                                </EmptyDataTemplate>
                                                                            </asp:GridView>
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <br />
                                                        <b>Guneral Counter Information.</b>
                                                        <hr />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                            <tr>
                                                                <td style="width: 160px;">
                                                                    <asp:Literal ID="litBeginingAmount" Text="Opening Balance" runat="server"></asp:Literal>
                                                                </td>
                                                                <td style="width: 30px;">
                                                                    Rs.
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="litDspBeginingAmount" runat="server" Text="0.00"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litSuggestedAmount" Text="System Suggested Amount" runat="server"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    Rs.
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="litDspSuggestedAmount" Text="0.00" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litActualAmount" Text="Actual Amount" runat="server"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    Rs.
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="litDspActualAmount" Text="0.00" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litShortOverAmount" Text="Short/Over Amount" runat="server"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    Rs.
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="litDspShortOverAmount" Text="0.00" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="isrequire" valign="top">
                                                                    <asp:Literal ID="litReason" Text="Reason" runat="server"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtReason" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rvfReason" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                        runat="server" ValidationGroup="IsRequire" ControlToValidate="txtReason" Display="Dynamic">
                                                                    </asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litDroppedAmount" Text="Dropped Amount" runat="server"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    Rs.
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtDroppedAmount" Style="width: 90px;" runat="server" MaxLength="18"></asp:TextBox>
                                                                    <ajx:FilteredTextBoxExtender ID="ftDroppedAmount" runat="server" TargetControlID="txtDroppedAmount"
                                                                        FilterType="Custom, Numbers" ValidChars="." />
                                                                    <asp:RegularExpressionValidator ID="revDroppedAmount" runat="server" ForeColor="Red"
                                                                        ControlToValidate="txtDroppedAmount" Display="Dynamic" ValidationExpression="^\d{0,12}(\.\d{0,2})?$"
                                                                        SetFocusOnError="true" ValidationGroup="IsRequire" ErrorMessage="2 digits allowed after decimal point.">
                                                                    </asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="vertical-align: top;">
                                                                    <asp:Literal ID="litNote" Text="Note/Remarks" runat="server"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtNote" TextMode="MultiLine" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr id="trButtonEvent" runat="server">
                                                    <td align="right" colspan="4">
                                                        <div style="width: auto; display: inline-block; text-align: center;">
                                                            <asp:Button ID="btnPrint" runat="server" Text="Print" Style="float: right; margin-left: 5px;"
                                                                OnClick="btnPrint_Click" />
                                                            <asp:Button ID="btnCounterHistory" runat="server" Text="Counter History" Style="float: right;
                                                                margin-left: 5px;" OnClick="btnCounterHistory_Click" />
                                                            <asp:Button ID="btnCloseCounter" runat="server" Text="Close Counter" Style="float: right;
                                                                margin-left: 5px;" ValidationGroup="IsRequire" OnClick="btnCloseCounter_Click" />
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
                            </div>
                        </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="vCounterHistoryByPayType" runat="server">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="content" style="padding-left: 0px; width: 66.66%">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="boxtopleft">
                                        &nbsp;
                                    </td>
                                    <td class="boxtopcenter">
                                        <asp:Literal ID="Literal1" runat="server" Text="Close Counter"></asp:Literal>
                                    </td>
                                    <td class="boxtopright">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="boxleft">
                                    </td>
                                    <td align="left">
                                        <div class="box_form">
                                            <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                <tr>
                                                    <td>
                                                        <div class="box_head">
                                                            <span>
                                                                <asp:Literal ID="Literal4" runat="server" Text="Counter Details"></asp:Literal>
                                                            </span>
                                                        </div>
                                                        <div class="clear">
                                                        </div>
                                                        <div class="box_content">
                                                            <asp:GridView ID="gvCounterHistoryByPayType" runat="server" AutoGenerateColumns="false"
                                                                ShowHeader="true" Width="100%" OnRowDataBound="gvCounterHistoryByPayType_RowDataBound"
                                                                ShowFooter="true" OnPageIndexChanging="gvCounterHistoryByPayType_PageIndexChanging">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%# Container.DataItemIndex + 1 %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrCounterHistoryByPayTypeDate" runat="server" Text="Date"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvCounterHistoryByPayTypeDate" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "EntryDate")).ToString(clsSession.DateFormat)%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrCounterHistoryByPayTypeDescription" runat="server" Text="Description"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvCounterHistoryByPayTypeDescription" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Description")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrCounterHistoryByPayTypeResNo" runat="server" Text="Res No."></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "ReservationNo")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="125px" FooterStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Left"
                                                                        ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrCounterHistoryByPayTypeUserName" runat="server" Text="User Name"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "UserName")%>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <b>Total</b>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="125px" FooterStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right"
                                                                        ItemStyle-HorizontalAlign="Right">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrCounterHistoryByPayTypeAmount" runat="server" Text="Amount"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvCounterHistoryByPayTypeAmount" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <b>
                                                                                <asp:Label ID="lblGvFtTotalCounterHistoryByPayTypeAmount" runat="server"></asp:Label></b>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <div style="padding: 10px;">
                                                                        <b>
                                                                            <asp:Label ID="lblNoRecordFound" runat="server" Text="No Record Found."></asp:Label>
                                                                        </b>
                                                                    </div>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <div style="width: auto; display: inline-block; text-align: center;">
                                                            <asp:Button ID="btnCancelGridCounterHistory" runat="server" Text="Cancel" Style="float: right;
                                                                margin-left: 5px;" ValidationGroup="IsRequire" OnClick="btnCancelGridCounterHistory_Click" />
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
                            </div>
                        </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="vAllCounterHistory" runat="server">
                <%-- <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="content" style="padding-left: 0px; width: 66.66%">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="boxtopleft">
                                        &nbsp;
                                    </td>
                                    <td class="boxtopcenter">
                                        <asp:Literal ID="Literal2" runat="server" Text="Close Counter"></asp:Literal>
                                    </td>
                                    <td class="boxtopright">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="boxleft">
                                    </td>
                                    <td align="left">
                                        <div class="box_form">--%>
                <ucCounterCloseHistoryOnThisMachine:CounterCloseHistoryOnThisMachine ID="ctrlCommonCounterCloseHistoryOnThisMachine"
                    runat="server" OnbtnCounterCloseHistoryOnThisMachineCallParent_Click="btnCounterCloseHistoryOnThisMachineCallParent_Click" />
                <%--<table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                <tr>
                                                    <td>
                                                        Filter Rows
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtFilterRows" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <hr />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div class="box_head">
                                                            <span>
                                                                <asp:Literal ID="Literal3" runat="server" Text="Counter Details"></asp:Literal>
                                                            </span>
                                                        </div>
                                                        <div class="clear">
                                                        </div>
                                                        <div class="box_content">
                                                            <asp:GridView ID="gvAllCounterHistory" runat="server" AutoGenerateColumns="false"
                                                                ShowHeader="true" Width="100%" OnRowDataBound="gvAllCounterHistory_RowDataBound"
                                                                ShowFooter="true" OnPageIndexChanging="gvAllCounterHistory_PageIndexChanging">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%# Container.DataItemIndex + 1 %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField FooterStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Left"
                                                                        ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrPayments" runat="server" Text="Payments"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "Code")%>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <b>Total</b>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="125px" FooterStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right"
                                                                        ItemStyle-HorizontalAlign="Right">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrAllCounterHistoryAmount" runat="server" Text="Amount"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <b>
                                                                                <asp:Label ID="lblGvFtTotalAllCounterHistoryAmount" runat="server"></asp:Label></b>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="125px" FooterStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right"
                                                                        ItemStyle-HorizontalAlign="Right">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrAllCounterHistoryNetAmount" runat="server" Text="Net Amount"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvAllCounterHistoryNetAmount" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <b>
                                                                                <asp:Label ID="lblGvFtTotalCounterHistoryByPayTypeAmount" runat="server"></asp:Label></b>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <div style="padding: 10px;">
                                                                        <b>
                                                                            <asp:Label ID="lblNoRecordFound" runat="server" Text="No Record Found."></asp:Label>
                                                                        </b>
                                                                    </div>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </div>
                                                    </td>
                                                </tr>                                                
                                            </table>--%>
                <%-- </div>
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
                            </div>
                        </td>
                    </tr>
                </table>--%>
            </asp:View>
        </asp:MultiView>
        <ajx:ModalPopupExtender ID="mpeErrorMessage" runat="server" TargetControlID="hfDateMessage"
            PopupControlID="pnlErrorMessage" BackgroundCssClass="mod_background" CancelControlID="btnErrorMessageOK"
            BehaviorID="mpeErrorMessage">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hfDateMessage" runat="server" />
        <asp:Panel ID="pnlErrorMessage" runat="server" Width="350px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="ltrHeaderDateValidate" runat="server" Text="Message"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td align="center" style="padding-bottom: 15px;">
                                <asp:Label ID="lblErrorMessage" runat="server" Text="Please Select Counter"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnErrorMessageOK" Text="OK" runat="server" Style="display: inline;
                                    padding-right: 10px;" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpeConfirmMessage" runat="server" TargetControlID="hdnConfirmMessage"
            PopupControlID="pnlConfirmMessage" BackgroundCssClass="mod_background" CancelControlID="btnCancelDelete"
            BehaviorID="hdnConfirmMessage">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnConfirmMessage" runat="server" />
        <asp:Panel ID="pnlConfirmMessage" runat="server" Height="350px" Width="325px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="ltrHeaderConfirmDeletePopup" runat="server" Text="Message"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td align="center" style="padding-bottom: 15px;">
                                <asp:Literal ID="ltrConfirmDeleteMsg" runat="server" Text="Are You sure want to close counter ?"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnYes" runat="server" Style="display: inline; padding-right: 10px;"
                                    OnClick="btnYes_Click" Text="OK" />
                                <asp:Button ID="btnCancelDelete" runat="server" Style="display: inline;" Text="Cancel" />
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
        <asp:PostBackTrigger ControlID="btnPrint" />
    </Triggers>
</asp:UpdatePanel>
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updCounterClose" ID="UpdateProgressCounterClose"
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
