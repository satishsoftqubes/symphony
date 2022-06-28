<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlExchangeRate.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.Configurations.CtrlExchangeRate" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<asp:UpdatePanel ID="updCurrency" runat="server">
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
                                <asp:Literal ID="litMainHeading" runat="server"></asp:Literal>
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
                                            <td colspan="4">
                                                <%if (IsListMessage)
                                                  { %>
                                                <div class="message finalsuccess">
                                                    <p>
                                                        <strong>
                                                            <asp:Literal ID="ltrMsgList" runat="server"></asp:Literal></strong>
                                                    </p>
                                                </div>
                                                <%}%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                <asp:Literal ID="litSSourceCurrency" runat="server"></asp:Literal>
                                            </th>
                                            <td style="width: 260px">
                                                <asp:DropDownList ID="ddlSSourceCurrency" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 150px;">
                                                <asp:Literal ID="litSDesignationCurrency" runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlSDesignationCurrency" runat="server">
                                                </asp:DropDownList>
                                                <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                    Style="border: 0px; vertical-align: middle; margin: 0 0 0 5px;" OnClick="btnSearch_Click" />
                                                <asp:ImageButton ID="imgbtnClearSearch" runat="server" ImageUrl="~/images/clearsearch.png"
                                                    Style="border: 0px; vertical-align: middle; margin: 0 0 0 10px;" OnClick="imgbtnClearSearch_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <h1>
                                                </h1>
                                                <hr>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="right" valign="middle">
                                                <asp:Button ID="btnAddTopExchangeRate" runat="server" Style="float: right;" OnClick="btnAddTopExchangeRate_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <div class="box_head">
                                                    <span>
                                                        <asp:Literal ID="litExchangeRateList" runat="server"></asp:Literal></span></div>
                                                <div class="clear">
                                                </div>
                                                <div class="box_content">
                                                    <asp:GridView ID="gvExcahngeRateList" runat="server" AutoGenerateColumns="false"
                                                        Width="100%" ShowHeader="true" OnPageIndexChanging="gvExcahngeRateList_PageIndexChanging"
                                                        OnRowCommand="gvExcahngeRateList_RowCommand" OnRowDataBound="gvExcahngeRateList_RowDataBound">
                                                        <Columns>
                                                            <asp:TemplateField ItemStyle-Width="25px">
                                                                <HeaderTemplate>
                                                                    <asp:Literal ID="litGvrNo" runat="server"></asp:Literal>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Literal ID="litGvHdrSourceCurrency" runat="server"></asp:Literal>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblgvSourceCurrency" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "SourceCurrency")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Literal ID="litGvHdrDestinationCurrency" runat="server"></asp:Literal>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblgvDestinationCurrency" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "DesignationCurrency")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Literal ID="litGvHdrSourceValue" runat="server"></asp:Literal>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblgvSourceValue" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "SourceRate")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Literal ID="litGvHdrDestinationValue" runat="server"></asp:Literal>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblgvDestinationValue" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "DestinationRate")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Literal ID="ltrGvHdrRate" runat="server"></asp:Literal>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "MarginRateInPercentage")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="50px">
                                                                <HeaderTemplate>
                                                                    <asp:Literal ID="lblGvHdrEditView" runat="server"></asp:Literal>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ExchangeRateID")%>'
                                                                        CommandName="EDITDATA"><img src="../../images/file.png" /></asp:LinkButton>
                                                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ExchangeRateID")%>'
                                                                        CommandName="DELETEDATA"><img src="../../images/delete.png" /></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <EmptyDataTemplate>
                                                            <div style="padding: 10px;">
                                                                <b>
                                                                    <asp:Label ID="lblNoRecordFound" runat="server"></asp:Label>
                                                                </b>
                                                            </div>
                                                        </EmptyDataTemplate>
                                                    </asp:GridView>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="right" valign="middle">
                                                <asp:Button ID="btnAddBottomExchangeRate" runat="server" Style="float: right;" OnClick="btnAddTopExchangeRate_Click" />
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
                        <uc1:MsgBox ID="MessageBox" runat="server" />
                    </div>
                </td>
            </tr>
        </table>
        <ajx:ModalPopupExtender ID="mdeExchangeRate" runat="server" TargetControlID="hfExchangeRate"
            PopupControlID="pnlExchangeRate" BackgroundCssClass="mod_background" CancelControlID="btnClose">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hfExchangeRate" runat="server" />
        <asp:Panel ID="pnlExchangeRate" runat="server">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="litmdeExchangeRate" runat="server"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td colspan="2">
                                <%if (IsPopupMessage)
                                  { %>
                                <div class="message finalsuccess">
                                    <p>
                                        <strong>
                                            <asp:Literal ID="ltrMsgPopup" runat="server"></asp:Literal></strong>
                                    </p>
                                </div>
                                <%}%>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire">
                                <asp:Literal ID="litSourceCurrencyName" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSourceCurrency" runat="server" Style="width: 150px; display: inline;">
                                </asp:DropDownList>
                                <span>
                                    <asp:RequiredFieldValidator ID="rvfSourceCurrency" runat="server" ControlToValidate="ddlSourceCurrency"
                                        Display="Dynamic" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                        InitialValue="00000000-0000-0000-0000-000000000000" ValidationGroup="IsRequire"></asp:RequiredFieldValidator>
                                </span>
                                <asp:Label ID="litTo" runat="server" Style="width: 150px; display: inline;"></asp:Label>
                                <asp:DropDownList ID="ddlDestinationCurrency" runat="server" Style="width: 150px;
                                    display: inline;">
                                </asp:DropDownList>
                                <span>
                                    <asp:RequiredFieldValidator ID="rvfddlDestinationCurrency" runat="server" ControlToValidate="ddlDestinationCurrency"
                                        Display="Dynamic" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                        InitialValue="00000000-0000-0000-0000-000000000000" ValidationGroup="IsRequire"></asp:RequiredFieldValidator>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire">
                                <asp:Literal ID="litSourceCurrencyValue" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSourceCurrencyValue" runat="server" Style="width: 148px; display: inline;"></asp:TextBox>
                                <ajx:FilteredTextBoxExtender ID="fltSourceCurrencyValue" TargetControlID="txtSourceCurrencyValue"
                                    runat="server" FilterMode="ValidChars" ValidChars="0123456789.">
                                </ajx:FilteredTextBoxExtender>
                                <span>
                                    <asp:RequiredFieldValidator ID="rvfValue" runat="server" ControlToValidate="txtSourceCurrencyValue"
                                        Display="Dynamic" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                        ValidationGroup="IsRequire"></asp:RequiredFieldValidator></span>
                                <asp:Label ID="litToValue" runat="server" Style="width: 148px; display: inline;"></asp:Label>
                                <asp:TextBox ID="txtDesginationCurrecyValue" runat="server" Style="width: 148px;
                                    display: inline;"></asp:TextBox>
                                <ajx:FilteredTextBoxExtender ID="fltDesginationCurrecyValue" TargetControlID="txtDesginationCurrecyValue"
                                    runat="server" FilterMode="ValidChars" ValidChars="0123456789.">
                                </ajx:FilteredTextBoxExtender>
                                <span class="erroraleart">
                                    <asp:RequiredFieldValidator ID="rvftxtDesginationCurrecyValue" runat="server" ControlToValidate="txtDesginationCurrecyValue"
                                        Display="Dynamic" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                        ValidationGroup="IsRequire"></asp:RequiredFieldValidator></span>
                                <div>
                                    <asp:RegularExpressionValidator Display="Dynamic" ID="regSoruceValue" runat="server"
                                        ForeColor="Red" ControlToValidate="txtSourceCurrencyValue" SetFocusOnError="true"
                                        ValidationGroup="IsRequire">
                                    </asp:RegularExpressionValidator>
                                </div>
                                <div>
                                    <asp:RegularExpressionValidator Display="Dynamic" ID="regDesginationValue" runat="server"
                                        ForeColor="Red" ControlToValidate="txtDesginationCurrecyValue" SetFocusOnError="true"
                                        ValidationGroup="IsRequire">
                                    </asp:RegularExpressionValidator>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire">
                                <asp:Literal ID="litMarginRate" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMarginRate" runat="server" Style="width: 298px;"></asp:TextBox>
                                <strong>(%)</strong>
                                <ajx:FilteredTextBoxExtender ID="fteMarginRate" runat="server" TargetControlID="txtMarginRate"
                                    FilterMode="ValidChars" ValidChars="0123456789.">
                                </ajx:FilteredTextBoxExtender>
                                <span>
                                    <asp:RequiredFieldValidator ID="rvfMarginRate" runat="server" ControlToValidate="txtMarginRate"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire"></asp:RequiredFieldValidator></span>
                                <div>
                                    <asp:RegularExpressionValidator Display="Dynamic" ID="regMarginRate" runat="server"
                                        ForeColor="Red" ControlToValidate="txtMarginRate" SetFocusOnError="true" ValidationGroup="IsRequire">
                                    </asp:RegularExpressionValidator></div>
                                <div>
                                    <asp:RangeValidator ID="rgValidator" runat="server" ControlToValidate="txtMarginRate"
                                        SetFocusOnError="true" Type="Double" Display="Dynamic" ValidationGroup="IsRequire"
                                        MinimumValue="0" ForeColor="Red" MaximumValue="100"></asp:RangeValidator>
                                    <%--<asp:RangeValidator Display="Dynamic" ID="rgValidator" runat="server" ForeColor="Red"
                                    ControlToValidate="txtMarginRate" MinimumValue="0" MaximumValue="100" SetFocusOnError="true"
                                    ValidationGroup="IsRequire">
                                </asp:RangeValidator>--%>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <h1>
                                </h1>
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Button ID="btnSaveAndClose" runat="server" CausesValidation="true" ValidationGroup="IsRequire"
                                    Style="display: inline;" OnClick="btnSaveAndClose_Click" />
                                <asp:Button ID="btnSave" runat="server" CausesValidation="true" ValidationGroup="IsRequire"
                                    Style="display: inline;" OnClick="btnSave_Click" />
                                <asp:Button ID="btnClose" runat="server" CausesValidation="false" Style="display: inline;"
                                    OnClick="btnClose_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <!-- Delete Popup Control-->
        <ajx:ModalPopupExtender ID="mpeConfirmDelete" runat="server" TargetControlID="hdnConfirmDelete"
            PopupControlID="pnlDeleteData" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnConfirmDelete" runat="server" />
        <asp:Panel ID="pnlDeleteData" runat="server" Height="350px" Width="325px">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="ltrHeaderConfirmDeletePopup" runat="server"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td align="center" style="padding-bottom: 15px;">
                                <asp:Literal ID="ltrConfirmDeleteMsg" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnYes" runat="server" Style="display: inline; padding-right: 10px;"
                                    OnClientClick="this.disabled = true; this.value = 'Processing...';" UseSubmitBehavior="false" OnClick="btnYes_Click" />
                                <asp:Button ID="btnCancelDelete" runat="server" Style="display: inline;" OnClick="btnCancelDelete_Click" />
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
<asp:UpdateProgress AssociatedUpdatePanelID="updCurrency" ID="UpdateProgressExchangeRate"
    runat="server">
    <ProgressTemplate>
        <div id="progressBackgroundFilter">
        </div>
        <div id="processMessage">
            <center>
                <img src="../../images/ajax-loader.gif" />
            </center>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
