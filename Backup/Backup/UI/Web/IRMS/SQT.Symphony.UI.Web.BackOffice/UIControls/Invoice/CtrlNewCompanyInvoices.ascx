<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlNewCompanyInvoices.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.BackOffice.UIControls.Invoice.CtrlNewCompanyInvoices" %>
<%@ Register Src="~/MsgBox/MsgBx.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">

    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
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
                                <asp:Literal ID="litMainHeading" runat="server" Text="Company Invoices"></asp:Literal>
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
                                                <%if (IsListMessage)
                                                  { %>
                                                <div class="message finalsuccess">
                                                    <p>
                                                        <strong>
                                                            <asp:Literal ID="ltrListMessage" runat="server"></asp:Literal></strong>
                                                    </p>
                                                </div>
                                                <%}%>
                                            </td>
                                        </tr>
                                    </table>
                                    <table cellpadding="2" cellspacing="2" width="100%">
                                        <tr>
                                            <td colspan="2">
                                                <table cellpadding="5" cellspacing="5">
                                                    <tr>
                                                        <td width="75px">
                                                            Name
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDisplayCompanyName" runat="server"></asp:Label>
                                                        </td>
                                                        <%--<td width="100px">
                                                            Direct Bill A/C
                                                        </td>
                                                        <td width="150px">
                                                            <asp:Label ID="lblDisplayDirectBillAC" runat="server" Text="1250.00"></asp:Label>
                                                        </td>
                                                        <td width="100px">
                                                            CR LMT [Rs.]
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDisplayCrLmt" runat="server"></asp:Label>
                                                        </td>--%>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: top; width: 40% !important; border-right: 1px solid Gray;">
                                                <table cellpadding="2" cellspacing="2" width="100%">
                                                    <tr>
                                                        <td class="isrequire" style="width: 100px;">
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
                                                            <asp:TextBox ID="txtAmount" runat="server" OnTextChanged="txtAmount_OnTextChanged"
                                                                AutoPostBack="true" Style="width: 125px;"></asp:TextBox>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rvfAmount" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                    runat="server" ValidationGroup="IsRequired" ControlToValidate="txtAmount" Display="Dynamic">
                                                                </asp:RequiredFieldValidator>
                                                            </span>
                                                            <ajx:FilteredTextBoxExtender ID="ftAmount" runat="server" TargetControlID="txtAmount"
                                                                FilterMode="ValidChars" ValidChars=".0123456789" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            MOP
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlModeOfPayment" runat="server" Style="width: 127px;" OnSelectedIndexChanged="ddlModeOfPayment_OnSelectedIndexChanged"
                                                                AutoPostBack="true">
                                                            </asp:DropDownList>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvModeOfPayment" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                    ValidationGroup="IsRequired" ControlToValidate="ddlModeOfPayment" Display="Dynamic">
                                                                </asp:RequiredFieldValidator>
                                                            </span>
                                                        </td>
                                                    </tr>
                                                    <tr id="trLedgerAccount" runat="server" visible="false">
                                                        <td>
                                                            Ledger
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlLedgerAccount" runat="server" Style="width: 127px;">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr id="trChequeDD1" runat="server" visible="false">
                                                        <td>
                                                            Bank Name
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtBankName" runat="server" Style="width: 125px;"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr id="trChequeDD2" runat="server" visible="false">
                                                        <td>
                                                            Cheque/DD No.
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtChequeDDNo" runat="server" Style="width: 125px;"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr id="trCreditCard1" runat="server" visible="false">
                                                        <td>
                                                            Card Type
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlCreditCardType" runat="server" Style="width: 127px;">
                                                            </asp:DropDownList>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvCreditCardType" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" Enabled="false"
                                                                    runat="server" ValidationGroup="IsRequire" ControlToValidate="ddlCreditCardType"
                                                                    Display="Dynamic">
                                                                </asp:RequiredFieldValidator>
                                                            </span>
                                                        </td>
                                                    </tr>
                                                    <tr id="trCreditCard2" runat="server" visible="false">
                                                        <td>
                                                            Name on Card
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtNameOnCard" runat="server" Style="width: 125px;"></asp:TextBox>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvNameOnCreditCard" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                    Enabled="false" runat="server" ValidationGroup="IsRequire" ControlToValidate="txtNameOnCard"
                                                                    Display="Dynamic">
                                                                </asp:RequiredFieldValidator>
                                                            </span>
                                                        </td>
                                                    </tr>
                                                    <tr id="trCreditCard3" runat="server" visible="false">
                                                        <td>
                                                            Card Number
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCardNumber" runat="server" Style="width: 125px;" MaxLength="16"></asp:TextBox>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvCreditCardNumber" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                    Enabled="false" runat="server" ValidationGroup="IsRequire" ControlToValidate="txtCardNumber"
                                                                    Display="Dynamic">
                                                                </asp:RequiredFieldValidator>
                                                            </span>
                                                            <ajx:FilteredTextBoxExtender ID="fteCreditCardNumber" runat="server" TargetControlID="txtCardNumber"
                                                                FilterMode="ValidChars" ValidChars="0123456789">
                                                            </ajx:FilteredTextBoxExtender>
                                                            <asp:RegularExpressionValidator ID="regCreditCardNumber" runat="server" ControlToValidate="txtCardNumber"
                                                                ErrorMessage="Card No. must be 16 digits." ValidationGroup="IsRequire" ForeColor="Red"
                                                                ValidationExpression="^[0-9]{16}"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr id="trCVVNo" runat="server" visible="false">
                                                        <td>
                                                            CVV No.
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCVVNo" runat="server" Style="width: 125px;" MaxLength="4"></asp:TextBox>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvCVVNumber" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                    Enabled="false" runat="server" ValidationGroup="IsRequire" ControlToValidate="txtCVVNo"
                                                                    Display="Dynamic">
                                                                </asp:RequiredFieldValidator>
                                                            </span>
                                                            <ajx:FilteredTextBoxExtender ID="fteCVVNo" runat="server" TargetControlID="txtCVVNo"
                                                                FilterMode="ValidChars" ValidChars="0123456789">
                                                            </ajx:FilteredTextBoxExtender>
                                                        </td>
                                                    </tr>
                                                    <tr id="trCreditCard4" runat="server" visible="false">
                                                        <td>
                                                            Expiration Date
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlCardExpirationMonth" runat="server" SkinID="nowidth" Width="90px">
                                                                <asp:ListItem Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                                <asp:ListItem Text="January" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="February" Value="2"></asp:ListItem>
                                                                <asp:ListItem Text="March" Value="3"></asp:ListItem>
                                                                <asp:ListItem Text="April" Value="4"></asp:ListItem>
                                                                <asp:ListItem Text="May" Value="5"></asp:ListItem>
                                                                <asp:ListItem Text="June" Value="6"></asp:ListItem>
                                                                <asp:ListItem Text="July" Value="7"></asp:ListItem>
                                                                <asp:ListItem Text="August" Value="8"></asp:ListItem>
                                                                <asp:ListItem Text="September" Value="9"></asp:ListItem>
                                                                <asp:ListItem Text="October" Value="10"></asp:ListItem>
                                                                <asp:ListItem Text="November" Value="11"></asp:ListItem>
                                                                <asp:ListItem Text="December" Value="12"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvCardExpirationMonth" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" Enabled="false"
                                                                    runat="server" ValidationGroup="IsRequire" ControlToValidate="ddlCardExpirationMonth"
                                                                    Display="Static">
                                                                </asp:RequiredFieldValidator>
                                                            </span>
                                                            <asp:DropDownList ID="ddlCardExpirationYear" runat="server" SkinID="nowidth" Width="65px">
                                                            </asp:DropDownList>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvCardExpirationYear" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" Enabled="false"
                                                                    runat="server" ValidationGroup="IsRequire" ControlToValidate="ddlCardExpirationYear"
                                                                    Display="Dynamic">
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
                                            <td colspan="4" style="vertical-align: top; width: 60% !important;">
                                                <div class="box_head">
                                                    <span>
                                                        <asp:Literal ID="litAcctGroupList" runat="server" Text="Invoice List"></asp:Literal></span></div>
                                                <div class="clear">
                                                </div>
                                                <div class="box_content">
                                                    <asp:GridView ID="gvInvoiceList" runat="server" AutoGenerateColumns="false" Width="100%" SkinID=gvNoPaging
                                                        DataKeyNames="InvoiceID,PendingAmount" ShowHeader="true" OnRowDataBound="gvInvoiceList_RowDataBound"
                                                        ShowFooter="true">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="No." ItemStyle-Width="25px">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="25px">
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="true" OnCheckedChanged="chkSelect_OnCheckedChanged" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Literal ID="lblGvHdrInvoiceNo" runat="server" Text="Invoice No."></asp:Literal>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGvInvoiceNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "InvoiceNo")%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <b>Total</b>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Literal ID="lblGvHdrDate" runat="server" Text="Date"></asp:Literal>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGvDate" runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Literal ID="lblGvHdrName" runat="server" Text="Name"></asp:Literal>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGvName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "GuestFullName")%>'></asp:Label>
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
                                                                    <asp:Label ID="lblGvAmount" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Amt")%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <b>
                                                                        <asp:Label ID="lblGvFtAmount" runat="server"></asp:Label></b>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                                                FooterStyle-HorizontalAlign="Right">
                                                                <HeaderTemplate>
                                                                    <asp:Literal ID="lblGvHdrOStd" runat="server" Text="Out Standing"></asp:Literal>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGvOStdAmount" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "PendingAmount")%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <b>
                                                                        <asp:Label ID="lblGvFtOStd" runat="server"></asp:Label></b>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                                                FooterStyle-HorizontalAlign="Right">
                                                                <HeaderTemplate>
                                                                    <asp:Literal ID="lblGvHdrPayment" runat="server" Text="Payment"></asp:Literal>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGvPayment" runat="server" Text="0.00"></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <b>
                                                                        <asp:Label ID="lblGvFtPayment" runat="server"></asp:Label></b>
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
                                                    <div style="padding-top: 10px; color: Blue;">
                                                        <b>Pending Amount&nbsp;&nbsp;<asp:Literal ID="ltrPendingAmount" runat="server" Text="0.00"></asp:Literal></b>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                Note<br />
                                                <asp:TextBox ID="txtNotes" runat="server" TextMode="MultiLine" Style="width: 725px;"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td align="center">
                                                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" Style="display: inline;
                                                    padding-right: 10px;" ValidationGroup="IsRequired" />
                                                <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Text="Cancel" Style="display: inline;
                                                    padding-right: 10px;" />
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
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
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
