<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCommonFolioOverrideTransaction.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Folio.CtrlCommonFolioOverrideTransaction" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<ajx:ModalPopupExtender ID="mpeOverrideTransaction" runat="server" TargetControlID="hdnOverrideTransaction"
    PopupControlID="pnlOverrideTransaction" BackgroundCssClass="mod_background">
</ajx:ModalPopupExtender>
<asp:HiddenField ID="hdnOverrideTransaction" runat="server" />
<asp:Panel ID="pnlOverrideTransaction" runat="server" Width="800px" Style="display: none;">
    <asp:MultiView ID="mvOverrideTransaction" runat="server">
        <asp:View ID="vOverrideTransaction" runat="server">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="litOverrideTransactionHeader" runat="server" Text="Override Transaction"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" border="0" width="100%">
                        <tr style="background-color: #F3F3F5;">
                            <td style="vertical-align: top; border: 1px solid #ccccce !important;" colspan="4">
                                <table cellpadding="2" cellspacing="2" width="100%">
                                    <tr>
                                        <td width="100px">
                                            <asp:Literal ID="litOverrideTransactionReservationNo" runat="server" Text="Reservation No."></asp:Literal>
                                        </td>
                                        <td width="125px">
                                            <asp:Literal ID="litDisplayOverrideTransactionReservationNo" runat="server"></asp:Literal>
                                        </td>
                                        <td width="100px">
                                            <asp:Literal ID="litOverrideTransactionFolioNo" runat="server" Text="Folio No."></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal ID="litDisplayOverrideTransactionFolioNo" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="litOverrideTransactionUnitNo" runat="server" Text="Room No."></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal ID="litDisplayOverrideTransactionUnitNo" runat="server"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal ID="litOverrideTransactionGroupName" runat="server" Text="Group Name"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal ID="litDisplayOverrideTransactionGroupName" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="litOverrideTransactionName" runat="server" Text="Name"></asp:Literal>
                                        </td>
                                        <td colspan="3">
                                            <asp:Literal ID="litDisplayOverrideTransactionName" runat="server"></asp:Literal>
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
                            <td style="height: 200px; overflow: auto; vertical-align: top;">
                                <div class="box_head">
                                    <span>
                                        <asp:Literal ID="litOverrideTransactionList" runat="server" Text="Override Transaction"></asp:Literal>
                                    </span>
                                </div>
                                <div class="clear">
                                </div>
                                <div class="box_content">
                                    <div style="height: 250px; overflow: auto;">
                                        <asp:GridView ID="gvOverrideTransactionList" runat="server" AutoGenerateColumns="false"
                                            ShowHeader="true" Width="100%" OnRowDataBound="gvOverrideTransactionList_RowDataBound"
                                            DataKeyNames="BookID">
                                            <Columns>
                                                <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrOverrideTransactionSrNo" runat="server" Text="No."></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrOverrideTransactionTransactionNo" runat="server" Text="Book No."></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#DataBinder.Eval(Container.DataItem, "BookNo")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrOverrideTransactionAccount" runat="server" Text="Account"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGvOverrideTransactionAccount" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Account")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrOverrideTransactionDescription" runat="server" Text="Description"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGvOverrideTransactionNarration" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Narration")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="130px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrOverrideTransactionReason" runat="server" Text="Reason"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtGvOverrideTransactionReason" runat="server" Style="width: 100px;"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvReason" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                            runat="server" ValidationGroup="IsRequireOverrideTransaction" Display="Static"
                                                            ControlToValidate="txtGvOverrideTransactionReason"></asp:RequiredFieldValidator>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrOverrideTransactionAmount" runat="server" Text="Amount"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGvOverrideTransactionAmount" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrOverrideTransactionOVDAmount" runat="server" Text="OVD. Amount"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtOverrideTransactionOVDAmount" Style="width: 65px !important;
                                                            float: left; margin: 5px 0 0 0; text-align: right;" runat="server" AutoPostBack="true"
                                                            OnTextChanged="txtOverrideTransactionOVDAmount_TextChanged"></asp:TextBox>
                                                        <ajx:FilteredTextBoxExtender ID="ftOverrideTransactionOVDAmount" runat="server" TargetControlID="txtOverrideTransactionOVDAmount"
                                                            FilterType="Custom, Numbers" ValidChars="." />
                                                        <asp:RequiredFieldValidator ID="rfvTransactionDiscount" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                            runat="server" ValidationGroup="IsRequireOverrideTransaction" Display="Static"
                                                            ControlToValidate="txtOverrideTransactionOVDAmount"></asp:RequiredFieldValidator>
                                                        &nbsp;&nbsp;
                                                        <asp:RegularExpressionValidator ID="revTransactionDiscount" SetFocusOnError="True"
                                                            runat="server" ValidationGroup="IsRequireOverrideTransaction" ControlToValidate="txtOverrideTransactionOVDAmount"
                                                            Display="Static" ForeColor="Red" ValidationExpression="^\d{0,18}(\.\d{0,2})?$"
                                                            CssClass="input-notification error png_bg"></asp:RegularExpressionValidator>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <div style="padding: 10px;">
                                                    <b>
                                                        <asp:Label ID="lblOverrideTransactionNoRecordFound" runat="server" Text="No Record Found."></asp:Label>
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
                                    <asp:Button ID="btnOverrideTransactionSave" Style="margin-left: 5px; display: inline;"
                                        runat="server" CausesValidation="true" Text="Save" ValidationGroup="IsRequireOverrideTransaction"
                                        OnClick="btnOverrideTransactionSave_Click" />
                                    <asp:Button ID="btnOverrideTransactionViewOverride" Style="margin-left: 5px; display: inline;"
                                        runat="server" Text="Override History" OnClick="btnOverrideTransactionViewOverride_Click" />
                                    <asp:Button ID="btnOverrideTransactionCancel" Style="margin-left: 5px; display: inline;"
                                        runat="server" Text="Cancel" />
                                </div>
                                <div style="float: right;">
                                    <div style="float: left; width: 125px; margin-top: 10px;">
                                        <b>
                                            <asp:Literal ID="litOverrideTransactionAmount" runat="server" Text="Override Amount"></asp:Literal></b>
                                    </div>
                                    <div style="float: left; background-color: #DCDDDF; color: #0083CE; font-size: 15px;
                                        font-weight: bold; padding: 9px; width: 125px; text-align: right;">
                                        <b>
                                            <asp:Literal ID="litDisplayOverrideTransactionAmount" runat="server" Text="0.00"></asp:Literal></b>
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
        <asp:View ID="VViewOverrideTransaction" runat="server">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="litOverridedAmountOfTransaction" runat="server" Text="View Overrided Amount Of Transaction"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td>
                                <div style="float: left; width: 100px;">
                                    <asp:Literal ID="litViewOverridedTransactionReservationNo" runat="server" Text="Reservation No."></asp:Literal>
                                </div>
                                <div style="float: left; width: 100px;">
                                    <asp:Literal ID="litDisplayViewOverridedTransactionReservationNo" runat="server"></asp:Literal></div>
                                <div style="float: left; width: 70px;">
                                    <asp:Literal ID="litViewOverridedTransactionFolioNo" runat="server" Text="Folio No."></asp:Literal>
                                </div>
                                <div style="float: left; width: 100px;">
                                    <asp:Literal ID="litDisplayViewOverridedTransactionFolioNo" runat="server"></asp:Literal>
                                </div>
                                <div style="float: left; width: 70px;">
                                    <asp:Literal ID="litViewOverridedTransactionName" runat="server" Text="Name"></asp:Literal>
                                </div>
                                <div style="float: left;">
                                    <asp:Literal ID="litDisplayViewOverridedTransactionName" runat="server"></asp:Literal>
                                </div>
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
                                        <asp:Literal ID="litViewOverridedTransactionList" runat="server" Text="Overrided Amount Of Transaction List"></asp:Literal>
                                    </span>
                                </div>
                                <div class="clear">
                                </div>
                                <div class="box_content">
                                    <div style="height: 250px; overflow: auto;">
                                        <asp:GridView ID="gvViewOverrideTransactionList" runat="server" AutoGenerateColumns="false"
                                            ShowHeader="true" Width="100%" OnRowDataBound="gvViewOverrideTransactionList_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrViewOverridedTransactionSrNo" runat="server" Text="No."></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrViewOverridedTransactionTransactionNo" runat="server" Text="Book No."></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#DataBinder.Eval(Container.DataItem, "BookNo")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrViewOverridedTransactionDate" runat="server" Text="Date"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGvViewOverridedTransactionEntryDate" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "EntryDate")).ToString(clsSession.DateFormat)%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrViewOverridedTransactionReason" runat="server" Text="Reason"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGvViewOverridedTransactioOverrideReason" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "OverrideReason")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrViewOverridedTransactionDescription" runat="server" Text="Description"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGvViewOverridedTransactioNarration" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Narration")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrViewOverridedTransactionUser" runat="server" Text="User"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#DataBinder.Eval(Container.DataItem, "UserName")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrViewOverridedTransactionAmount" runat="server" Text="Amount"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGvViewOverridedTransactionAmount" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrViewOverridedTransaction" runat="server" Text="OVD. Amount"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGvViewOverridedTransactionOVDAmount" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <div style="padding: 10px;">
                                                    <b>
                                                        <asp:Label ID="lblViewOverridedTransactioNoRecordFound" runat="server" Text="No Record Found."></asp:Label>
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
                                    <asp:Button ID="btnViewOverridedTransactionPrint" Style="margin-left: 5px; display: inline;"
                                        runat="server" Text="Print" />
                                    <asp:Button ID="btnViewOverridedTransactionCancel" Style="margin-left: 5px; display: inline;"
                                        runat="server" Text="Cancel" OnClick="btnViewOverrideTransactioCancel_Click" />
                                </div>
                                <div style="float: right;">
                                    <div style="float: left; width: 125px; margin-top: 10px;">
                                        <b>
                                            <asp:Literal ID="litViewOverridedTransactionAmount" runat="server" Text="Overrided Amount"></asp:Literal></b>
                                    </div>
                                    <div style="float: left; background-color: #DCDDDF; color: #0083CE; font-size: 15px;
                                        font-weight: bold; padding: 9px; width: 125px; text-align: right;">
                                        <b>
                                            <asp:Literal ID="litDisplayViewOverridedTransactionAmount" runat="server" Text="0.00"></asp:Literal></b>
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
