<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlDirectBillAndSettleInvoice.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.BackOffice.UIControls.AccountSetup.CtrlDirectBillAndSettleInvoice" %>
<%@ Register Src="~/MsgBox/MsgBx.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script>
    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }
</script>
<asp:UpdatePanel ID="updDirectBill" runat="server">
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
                                <asp:Literal ID="litMainHeading" runat="server" Text="Direct Bill & Settle Invoice"></asp:Literal>
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
                                    <table cellpadding="2" cellspacing="2" width="100%">
                                        <tr>
                                            <td colspan="2">
                                                <fieldset style="border: 1px solid #ccc !important;">
                                                    <legend>Bill To Company </legend>
                                                    <table cellpadding="2" cellspacing="2" width="100%">
                                                        <tr>
                                                            <td width="75px">
                                                                Name
                                                            </td>
                                                            <td width="150px">
                                                                <asp:Label ID="lblDisplayCompanyName" runat="server" Text="Infosys"></asp:Label>
                                                            </td>
                                                            <td width="100px">
                                                                Direct Bill A/C
                                                            </td>
                                                            <td width="150px">
                                                                <asp:Label ID="lblDisplayDirectBillAC" runat="server" Text="1250.00"></asp:Label>
                                                            </td>
                                                            <td width="100px">
                                                                CR LMT [Rs.]
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblDisplayCrLmt" runat="server" Text="-1400.00"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </fieldset>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: top; width: 45% !important; border-right: 1px solid Gray;">
                                                <table cellpadding="2" cellspacing="2" width="100%">
                                                    <tr>
                                                        <td class="isrequire" style="width: 60px;">
                                                            Date
                                                        </td>
                                                        <td style="width: 265px;">
                                                            <asp:TextBox ID="txtDate" runat="server" Style="width: 125px;" onkeypress="return false;"></asp:TextBox>
                                                            <asp:Image ID="imgDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                                Height="20px" Width="20px" />
                                                            <ajx:CalendarExtender ID="calDate" PopupButtonID="imgDate" TargetControlID="txtDate"
                                                                runat="server">
                                                            </ajx:CalendarExtender>
                                                            <img src="../../images/clear.png" id="imgED" style="vertical-align: middle;" title="Clear Date"
                                                                onclick="fnClearDate('<%= txtDate.ClientID %>');" />
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvDate" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                    runat="server" ValidationGroup="IsRequired" ControlToValidate="txtDate" Display="Dynamic">
                                                                </asp:RequiredFieldValidator>
                                                            </span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="isrequire" style="width: 75px;">
                                                            Amount
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtAmount" runat="server" Style="width: 125px;"></asp:TextBox>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rvfAmount" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                    runat="server" ValidationGroup="IsRequired" ControlToValidate="txtAmount" Display="Dynamic">
                                                                </asp:RequiredFieldValidator>
                                                            </span>
                                                            <ajx:FilteredTextBoxExtender ID="ftAmount" runat="server" TargetControlID="txtAmount"
                                                                FilterType="Custom, Numbers" ValidChars="." />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="isrequire" style="width: 75px;">
                                                            MOP
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlMOP" runat="server" Style="width: 127px;" AutoPostBack="true"
                                                                OnSelectedIndexChanged="ddlMOP_OnSelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvMOP" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                    ValidationGroup="IsRequired" ControlToValidate="ddlMOP" Display="Dynamic">
                                                                </asp:RequiredFieldValidator>
                                                            </span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="isrequire" style="width: 75px;">
                                                            Pay A/C
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlPayAC" runat="server" Style="width: 127px;">
                                                            </asp:DropDownList>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rvfPayAC" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                    ValidationGroup="IsRequired" ControlToValidate="ddlPayAC" Display="Dynamic">
                                                                </asp:RequiredFieldValidator>
                                                            </span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:RegularExpressionValidator ID="revAmount" SetFocusOnError="True" runat="server"
                                                                ValidationGroup="IsRequired" ControlToValidate="txtAmount" Display="Dynamic"
                                                                ForeColor="Red" ValidationExpression="^\d{0,18}(\.\d{0,2})?$" ErrorMessage="2 digits allowed after decimal point."></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td colspan="4" style="vertical-align: top; width: 55% !important;">
                                                <div class="box_head">
                                                    <span>
                                                        <asp:Literal ID="litAcctGroupList" runat="server"></asp:Literal></span></div>
                                                <div class="clear">
                                                </div>
                                                <div class="box_content">
                                                    <asp:GridView ID="gvInvoiceList" runat="server" AutoGenerateColumns="false" Width="100%"
                                                        ShowHeader="true" OnRowDataBound="gvInvoiceList_RowDataBound" ShowFooter="true">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="No." ItemStyle-Width="25px">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="25px">
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chkSelect" runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Literal ID="lblGvHdrInvoiceNo" runat="server" Text="Invoice No."></asp:Literal>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGvInvoiceNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "InvoiceNo")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Literal ID="lblGvHdrDate" runat="server" Text="Date"></asp:Literal>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGvDate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Date")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Literal ID="lblGvHdrName" runat="server" Text="Name"></asp:Literal>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGvName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Name")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                             <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Literal ID="lblGvHdrReservaionNo" runat="server" Text="Booking #"></asp:Literal>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGvReservaionNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ReservationNo")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                                                FooterStyle-HorizontalAlign="Right">
                                                                <HeaderTemplate>
                                                                    <asp:Literal ID="lblGvHdrAmount" runat="server" Text="Amount"></asp:Literal>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGvAmount" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Amount")%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:Label ID="lblGvFtAmount" runat="server"></asp:Label>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                                                FooterStyle-HorizontalAlign="Right">
                                                                <HeaderTemplate>
                                                                    <asp:Literal ID="lblGvHdrOStd" runat="server" Text="Out Standing"></asp:Literal>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGvOStd" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "OSTD")%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:Label ID="lblGvFtOStd" runat="server"></asp:Label>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                                                FooterStyle-HorizontalAlign="Right">
                                                                <HeaderTemplate>
                                                                    <asp:Literal ID="lblGvHdrPayment" runat="server" Text="Payment"></asp:Literal>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGvPayment" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Payment")%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:Label ID="lblGvFtPayment" runat="server"></asp:Label>
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
                                            <td>
                                            </td>
                                            <td>
                                                Notes<br />
                                                <asp:TextBox ID="txtNotes" runat="server" TextMode="MultiLine" Style="width: 725px;"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td align="center">
                                                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" Style="display: inline;
                                                    padding-right: 10px;" ValidationGroup="IsRequired" />
                                                <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Text="Clear" Style="display: inline;
                                                    padding-right: 10px;" />
                                                <asp:Button ID="btnGoToInvoice" runat="server" OnClick="btnGoToInvoice_Click" Text="Go To Invoice"
                                                    Style="display: inline;" />
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
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdateProgress AssociatedUpdatePanelID="updDirectBill" ID="UpdateProgressDirectBill"
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
