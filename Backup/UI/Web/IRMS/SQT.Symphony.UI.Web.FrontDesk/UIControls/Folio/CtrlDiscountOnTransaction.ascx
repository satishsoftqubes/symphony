<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlDiscountOnTransaction.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Folio.CtrlDiscountOnTransaction" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<ajx:ModalPopupExtender ID="mpeTransactionDiscount" runat="server" TargetControlID="hdnTransactionDiscount"
    PopupControlID="pnlTransactionDiscount" BackgroundCssClass="mod_background">
</ajx:ModalPopupExtender>
<asp:HiddenField ID="hdnTransactionDiscount" runat="server" />
<asp:Panel ID="pnlTransactionDiscount" runat="server" Width="875px" Style="display: none;">
    <asp:MultiView ID="mvTransactionDiscount" runat="server">
        <asp:View ID="vTransactionDiscount" runat="server">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="litTransactionDiscountHeader" runat="server" Text="Transaction on Discount"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" border="0" width="100%">
                        <tr>
                            <td style="border: 1px solid #ccccce;">
                                <table cellpadding="2" cellspacing="2" width="100%">
                                    <tr>
                                        <td width="100px">
                                            <asp:Literal ID="litTransactionDiscountReservationNo" runat="server" Text="Reservation No."></asp:Literal>
                                        </td>
                                        <td width="150px">
                                            <asp:Literal ID="litDisplayTransactionDiscountReservationNo" runat="server"></asp:Literal>
                                        </td>
                                        <td width="100px">
                                            <asp:Literal ID="litTransactionDiscountName" runat="server" Text="Name"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal ID="litDisplayTransactionDiscountName" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="litTransactionDiscountFolioNo" runat="server" Text="Folio No."></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal ID="litDisplayTransactionDiscountFolioNo" runat="server"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal ID="litTransactionDiscountGroupName" runat="server" Text="Group Name"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal ID="litDisplayTransactionDiscountGroupName" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="litTransactionDiscountUnitNo" runat="server" Text="Room No."></asp:Literal>
                                        </td>
                                        <td colspan="3">
                                            <asp:Literal ID="litDisplayTransactionDiscountUnitNo" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td width="100%" style="height: 150px; overflow: auto; vertical-align: top;">
                                <div class="box_head">
                                    <span>
                                        <asp:Literal ID="litTransactionDiscountList" runat="server" Text="Transaction on Discount List"></asp:Literal>
                                    </span>
                                </div>
                                <div class="clear">
                                </div>
                                <div class="box_content">
                                    <div style="height: 250px; overflow: auto;">
                                        <asp:GridView ID="gvTransactionDiscountList" runat="server" AutoGenerateColumns="false"
                                            ShowHeader="true" Width="100%" OnRowDataBound="gvTransactionDiscountList_RowDataBound"
                                            SkinID="gvNoPaging" DataKeyNames="BookID">
                                            <Columns>
                                                <asp:TemplateField ItemStyle-Width="30px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrTransactionDiscountSrNo" runat="server" Text="No."></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrTransactionDiscountTransactionNo" runat="server" Text="Book No."></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGvTransactionDiscountBookNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "BookNo")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrTransactionDiscountDate" runat="server" Text="Date"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGvDate" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "EntryDate")).ToString(clsSession.DateFormat)%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="90px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrTransactionDiscountAccount" runat="server" Text="Account"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGvTransactionDiscountAccount" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Account")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrTransactionDiscountDescription" runat="server" Text="Description"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGvTransactionDiscountNarration" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Narration")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="130px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrTransactionDiscountReason" runat="server" Text="Reason"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtGvReason" runat="server" Style="width: 100px;"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvReason" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                            runat="server" ValidationGroup="IsRequireDiscount" Display="Static" ControlToValidate="txtGvReason"></asp:RequiredFieldValidator>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="65px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrTransactionDiscountAmount" runat="server" Text="Amount"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGvTransactionDiscountAmount" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrTransactionDiscountTotalDiscount" runat="server" Text="Total DISC"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGvTransactionDiscountTotalDiscount" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="130px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrTransactionDiscount" runat="server" Text="DISC"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%--<asp:DropDownList ID="ddlDiscountType" runat="server" Style="width: 50px !important;" AutoPostBack="true" OnSelectedIndexChanged="ddlDiscountType_SelectedIndexChanged">
                                                            <asp:ListItem Text="%" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Flat" Value="1"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        &nbsp;--%>
                                                        <asp:TextBox ID="txtTransactionDiscount" AutoPostBack="true" OnTextChanged="txtTransactionDiscount_TextChanged"
                                                            Style="width: 65px !important; text-align: right" runat="server" MaxLength="18"></asp:TextBox>&nbsp;&nbsp;%&nbsp;&nbsp;
                                                        <ajx:FilteredTextBoxExtender ID="ftTransactionDiscount" runat="server" TargetControlID="txtTransactionDiscount"
                                                            FilterType="Custom, Numbers" ValidChars="." />
                                                        <asp:RequiredFieldValidator ID="rfvTransactionDiscount" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                            runat="server" ValidationGroup="IsRequireDiscount" Display="Dynamic" ControlToValidate="txtTransactionDiscount"></asp:RequiredFieldValidator>
                                                        &nbsp;&nbsp;
                                                        <asp:RegularExpressionValidator ID="revTransactionDiscount" SetFocusOnError="True"
                                                            runat="server" ValidationGroup="IsRequireDiscount" ControlToValidate="txtTransactionDiscount"
                                                            Display="Static" ForeColor="Red" ValidationExpression="^\d{0,18}(\.\d{0,2})?$"
                                                            CssClass="input-notification error png_bg"></asp:RegularExpressionValidator>
                                                        <%--&nbsp;&nbsp;
                                                        <asp:RangeValidator ID="rvTransactionDiscount" Enabled="false" Display="Static" runat="server"
                                                            MinimumValue="0" ControlToValidate="txtTransactionDiscount" SetFocusOnError="true"
                                                            ValidationGroup="IsRequireDiscount" ForeColor="Red" Type="Double" CssClass="input-notification error png_bg"></asp:RangeValidator>--%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <div style="padding: 10px;">
                                                    <b>
                                                        <asp:Label ID="lblNoRecordFoundForTransactionDiscount" runat="server" Text="No Record Found."></asp:Label>
                                                    </b>
                                                </div>
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="float: left;">
                                    <asp:Button ID="btnTransactionDiscountSave" runat="server" Text="Save" Style="display: inline;"
                                        OnClick="btnTransactionDiscountSave_Click" ValidationGroup="IsRequireDiscount" />
                                    <asp:Button ID="btnTransactionDiscountViewDiscount" runat="server" Text="Discount History"
                                        Style="display: inline;" OnClick="btnTransactionDiscountViewDiscount_Click" />
                                    <asp:Button ID="btnTransactionDiscountCancel" runat="server" Text="Cancel" Style="display: inline;" /></div>
                                <div style="float: right;">
                                    <div style="float: left; width: 125px; margin-top: 10px;">
                                        <b>
                                            <asp:Literal ID="litDiscountAmount" runat="server" Text="Discount Amount"></asp:Literal></b>
                                    </div>
                                    <div style="float: left; background-color: #DCDDDF; color: #0083CE; font-size: 15px;
                                        font-weight: bold; padding: 9px; width: 125px; text-align: right;">
                                        <b>
                                            <asp:Literal ID="litDisplayDiscountAmount" runat="server" Text="0.00"></asp:Literal></b>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:View>
        <asp:View ID="vViewTransactionDiscount" runat="server">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="litHeaderViewDiscountList" runat="server" Text="View Discount of Transactions"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td>
                                <table cellpadding="2" cellspacing="2" width="100%">
                                    <tr>
                                        <td width="100px">
                                            <asp:Literal ID="litViewDiscountReservationNo" runat="server" Text="Reservation No."></asp:Literal>
                                        </td>
                                        <td width="100px">
                                            <asp:Literal ID="litDisplayViewDiscountReservationNo" runat="server"></asp:Literal>
                                        </td>
                                        <td width="60px">
                                            <asp:Literal ID="litViewDiscountFolioNo" runat="server" Text="Folio No."></asp:Literal>
                                        </td>
                                        <td width="100px">
                                            <asp:Literal ID="litDisplayViewDiscountFolioNo" runat="server"></asp:Literal>
                                        </td>
                                        <td width="60px">
                                            <asp:Literal ID="litViewDiscountName" runat="server" Text="Name"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal ID="litDisplayViewDiscountName" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td width="100%" style="height: 150px; overflow: auto; vertical-align: top;">
                                <div class="box_head">
                                    <span>
                                        <asp:Literal ID="litViewDiscountList" runat="server" Text="View Discount List"></asp:Literal>
                                    </span>
                                </div>
                                <div class="clear">
                                </div>
                                <div class="box_content">
                                    <div style="height: 250px; overflow: auto;">
                                        <asp:GridView ID="gvViewDiscountList" runat="server" AutoGenerateColumns="false"
                                            ShowHeader="true" Width="100%" SkinID="gvNoPaging" OnRowDataBound="gvViewDiscountList_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrViewDiscountSrNo" runat="server" Text="No."></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrViewDiscountTransactionNo" runat="server" Text="Book No."></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#DataBinder.Eval(Container.DataItem, "BookNo")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrViewDiscountDate" runat="server" Text="Date"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGvViewDiscEntryDate" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "EntryDate")).ToString(clsSession.DateFormat)%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrViewDiscountAccount" runat="server" Text="Account"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#DataBinder.Eval(Container.DataItem, "Account_Name")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrViewDiscountDescription" runat="server" Text="Description"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#DataBinder.Eval(Container.DataItem, "Narration")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrViewDiscountUser" runat="server" Text="User"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#DataBinder.Eval(Container.DataItem, "UserName")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrViewDiscountAmount" runat="server" Text="Amount"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGvViewDiscountAmount" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrViewDiscount" runat="server" Text="Discount"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGvViewDiscount" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <div style="padding: 10px;">
                                                    <b>
                                                        <asp:Label ID="lblNoRecordFoundForViewDiscount" runat="server" Text="No Record Found."></asp:Label>
                                                    </b>
                                                </div>
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="float: left;">
                                    <asp:Button ID="btnViewDiscountPrint" runat="server" Style="display: inline;" Text="Print" />
                                    <asp:Button ID="btnViewDiscoutnCancel" runat="server" Style="display: inline;" Text="Cancel"
                                        OnClick="btnViewDiscoutnCancel_Click" /></div>
                                <div style="float: right;">
                                    <div style="float: left; width: 125px; margin-top: 10px;">
                                        <b>
                                            <asp:Literal ID="litViewDiscountAmount" runat="server" Text="Discount Amount"></asp:Literal></b>
                                    </div>
                                    <div style="float: left; background-color: #DCDDDF; color: #0083CE; font-size: 15px;
                                        font-weight: bold; padding: 9px; width: 125px; text-align: right;">
                                        <b>
                                            <asp:Literal ID="litDisplayViewDiscountAmount" runat="server" Text="0.00"></asp:Literal></b>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:View>
    </asp:MultiView>
</asp:Panel>
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
