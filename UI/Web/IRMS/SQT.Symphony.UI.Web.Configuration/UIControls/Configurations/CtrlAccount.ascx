<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlAccount.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.Configurations.CtrlAccount" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">
    function fnConfirmDelete(id) {
        document.getElementById('errormessage').style.display = "block";
        document.getElementById('<%= hdnConfirmDelete.ClientID %>').value = id;
        $find('mpeConfirmDelete').show();
        return false;
    }


    function fnConfirmDeleteRow(id) {
        document.getElementById('errormessage').style.display = "block";
        document.getElementById('<%= hdnDeleteRowOfDrid.ClientID %>').value = id;
        $find('mpeDeleteRowOfDrid').show();
        return false;
    }

    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    
</script>
<asp:UpdatePanel ID="updAmenitiesList" runat="server">
    <ContentTemplate>
        <asp:HiddenField ID="hfDateFormat" runat="server" />
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td valign="top" style="padding-left: 0px; width: 66.66%">
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
                                    <asp:MultiView ID="mvAccount" runat="server">
                                        <asp:View ID="vAccountList" runat="server">
                                            <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                <tr>
                                                    <th align="left">
                                                        <asp:Literal ID="litSearchTaxName" runat="server"></asp:Literal>
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="txtSearchTaxName" runat="server"></asp:TextBox>
                                                    </td>
                                                    <th align="left">
                                                        <asp:Literal ID="litSearchTaxCode" runat="server"></asp:Literal>
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="txtSearchTaxCode" runat="server"></asp:TextBox>
                                                        <asp:ImageButton ID="btnSearchAmenities" CssClass="small_img" Style="border: 0px;
                                                            vertical-align: middle; margin: -4px 0 0 5px;" runat="server" ImageUrl="~/images/search-icon.png"
                                                            OnClick="btnSearch_Click" OnClientClick="fnDisplayCatchErrorMessage();" />
                                                        <asp:ImageButton ID="imgbtnClearSearch" runat="server" ImageUrl="~/images/clearsearch.png"
                                                            Style="border: 0px; vertical-align: middle; margin: -2px 0 0 10px;" OnClick="imgbtnClearSearch_Click"
                                                            OnClientClick="fnDisplayCatchErrorMessage();" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <hr />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" align="right" valign="middle">
                                                        <asp:Button ID="btnAddTopTax" runat="server" OnClick="btnAddTopTax_Click" OnClientClick="fnDisplayCatchErrorMessage();"
                                                            Style="float: right;" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <div class="box_head">
                                                            <span>
                                                                <asp:Literal ID="litTaxList" runat="server"></asp:Literal>
                                                            </span>
                                                        </div>
                                                        <div class="clear">
                                                        </div>
                                                        <div class="box_content">
                                                            <asp:GridView ID="gvTaxList" runat="server" AutoGenerateColumns="False" Width="100%"
                                                                OnPageIndexChanging="gvTaxList_OnPageIndexChanging" OnRowDataBound="gvTaxList_RowDataBound"
                                                                OnRowCommand="gvTaxList_RowCommand" ShowHeader="true">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHrdNo" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%# Container.DataItemIndex + 1 %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrTaxCode" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "AcctNo")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrTaxName" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "AcctName")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrAction" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "AcctID")%>'
                                                                                CommandName="EDITDATA" OnClientClick="fnDisplayCatchErrorMessage();"><img src="../../images/file.png" /></asp:LinkButton>
                                                                            <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "AcctID")%>'
                                                                                CommandName="DELETEDATA"><img src="../../images/delete.png" /></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <div style="padding: 10px;">
                                                                        <b>
                                                                            <asp:Label ID="lblNoRecordFound" runat="server"></asp:Label></b>
                                                                    </div>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" align="right" valign="middle">
                                                        <asp:Button ID="btnAddBottomTax" runat="server" OnClick="btnAddTopTax_Click" OnClientClick="fnDisplayCatchErrorMessage();"
                                                            Style="float: right;" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                        <asp:View ID="vAddEditAccount" runat="server">
                                            <table cellpadding="2" cellspacing="2" border="0" width="100%">
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
                                                    <td class="isrequire">
                                                        <asp:Literal ID="litTaxName" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtTaxName" runat="server" MaxLength="150"></asp:TextBox>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rfvTaxName" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                runat="server" ValidationGroup="IsRequire" ControlToValidate="txtTaxName"></asp:RequiredFieldValidator></span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="isrequire">
                                                        <asp:Literal ID="litTaxCode" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtTaxCode" runat="server" MaxLength="7"></asp:TextBox>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rfvTaxCode" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                runat="server" ValidationGroup="IsRequire" ControlToValidate="txtTaxCode"></asp:RequiredFieldValidator></span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="isrequire">
                                                        <asp:Literal ID="litIsRefundable" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="chkIsRefundable" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="isrequire">
                                                        <asp:Literal ID="litAccountTaxType" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlAccountTaxType" OnSelectedIndexChanged="ddlAccountTaxType_OnSelectedIndexChanged"
                                                            AutoPostBack="true" runat="server" Style="float: left; width: 90px !important;">
                                                            <asp:ListItem Value="0" Text="%"></asp:ListItem>
                                                            <asp:ListItem Value="1" Text="Flat"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>                                                
                                                <tr>
                                                    <td class="isrequire">
                                                        <asp:Literal ID="litAccountTaxRate" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtAccountTaxRate" runat="server" MaxLength="18"></asp:TextBox>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                runat="server" ValidationGroup="IsRequire" ControlToValidate="txtAccountTaxRate"></asp:RequiredFieldValidator></span>
                                                        &nbsp;&nbsp;
                                                        <asp:RegularExpressionValidator ID="revAccountTaxRate" SetFocusOnError="True" runat="server"
                                                            ValidationGroup="IsRequire" ControlToValidate="txtAccountTaxRate" Display="Dynamic"
                                                            ForeColor="Red" ValidationExpression="^\d{0,18}(\.\d{0,2})?$"></asp:RegularExpressionValidator>
                                                        &nbsp;&nbsp;
                                                        <asp:RangeValidator ID="rvAccountTaxRate" Enabled="false" Display="Dynamic" runat="server"
                                                            MinimumValue="0" ControlToValidate="txtAccountTaxRate" SetFocusOnError="true" ValidationGroup="IsRequire"
                                                            ForeColor="Red" Type="Double"></asp:RangeValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="RefrenceTax" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList Style="height: 25px; float: left; width: 227px;" ID="ddlRefrenceTax"
                                                            runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="right">
                                                        <asp:Button ID="btnAddNewTaxRateCol" Style="float: right; margin-left: 5px;" runat="server"
                                                            ImageUrl="~/images/cancle.png" CausesValidation="false" OnClick="btnAddNewTaxRateCol_OnClick" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <hr />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <div class="box_head">
                                                            <span>
                                                                <asp:Literal ID="litGvhdrTaxService" runat="server"></asp:Literal>
                                                            </span>
                                                        </div>
                                                        <div class="clear">
                                                        </div>
                                                        <div class="box_content">
                                                            <asp:GridView ID="gvTaxRateList" runat="server" OnRowDataBound="gvTaxRateList_RowDataBound"
                                                                OnRowCommand="gvTaxRateList_RowCommand" AutoGenerateColumns="False" Width="100%"
                                                                ShowHeader="true">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHrdNo1" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%# Container.DataItemIndex + 1 %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrTaxRate1" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblTaxRateAmount" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "TaxRate")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrTaxType" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "TaxType")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="180px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrMinAmt" runat="server" Text="Min. Amount"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%--<asp:Literal ID="litGvStartDateDisplay" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "StartDate")).ToString(clsSession.DateFormat)%>'></asp:Literal>--%>
                                                                            <asp:Label ID="lblGvDisplayMinAmt" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "MinAmount")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="180px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrMaxAmt" runat="server" Text="Max. Amount"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%--<asp:Literal ID="litGvHdrEndDateDisplay" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "EndDate")).ToString(clsSession.DateFormat)%>'></asp:Literal>--%>
                                                                            <asp:Label ID="lblGvDisplayMaxAmt" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrAction1" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkEdit1" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "TaxSlabID")%>'
                                                                                CommandName="EDITDATA" OnClientClick="fnDisplayCatchErrorMessage();"><img src="../../images/file.png" /></asp:LinkButton>
                                                                            <asp:LinkButton ID="lnkDelete1" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "TaxSlabID")%>'
                                                                                CommandName="DELETEDATA"><img src="../../images/delete.png" /></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <div style="padding: 10px;">
                                                                        <b>
                                                                            <asp:Label ID="lblNoRecordFound" runat="server"></asp:Label></b>
                                                                    </div>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <%--<tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td class="checkbox_new">
                                                        <asp:CheckBox ID="chkIsRateCard" runat="server" />
                                                    </td>
                                                </tr>--%>
                                                <tr>
                                                    <td colspan="2">
                                                        <div style="float: right; width: auto; display: inline-block;">
                                                            <asp:Button ID="btnCancel" Visible="false" Style="float: right; margin-left: 5px;"
                                                                runat="server" ImageUrl="~/images/cancle.png" CausesValidation="false" OnClick="btnCancel_OnClick"
                                                                OnClientClick="fnDisplayCatchErrorMessage();" />
                                                            <asp:Button ID="btnSave" Style="float: right; margin-left: 5px;" runat="server" ImageUrl="~/images/save.png"
                                                                ValidationGroup="IsRequire" CausesValidation="true" OnClick="btnSave_OnClick"
                                                                OnClientClick="return fncheckTaxType();" />
                                                            <asp:Button ID="btnBackToList" Style="float: right; margin-left: 5px;" runat="server"
                                                                ImageUrl="~/images/cancle.png" CausesValidation="false" OnClick="btnBackToList_OnClick"
                                                                OnClientClick="fnDisplayCatchErrorMessage();" />
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                    </asp:MultiView>
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
            PopupControlID="pnlDeleteData" BackgroundCssClass="mod_background" CancelControlID="btnNo"
            BehaviorID="mpeConfirmDelete">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnConfirmDelete" runat="server" />
        <asp:Panel ID="pnlDeleteData" runat="server" Height="350px" Width="325px" Style="display: none;">
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
                                    OnClick="btnYes_Click" OnClientClick="fnDisplayCatchErrorMessage();" />
                                <asp:Button ID="btnNo" runat="server" Style="display: inline;" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpeDeleteRowOfDrid" runat="server" TargetControlID="hdnDeleteRowOfDrid"
            PopupControlID="pnlDeleteRowOfDrid" BackgroundCssClass="mod_background" CancelControlID="btnCalncel">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnDeleteRowOfDrid" runat="server" />
        <asp:Panel ID="pnlDeleteRowOfDrid" runat="server" Height="350px" Width="325px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="litRowDeleteMsg" runat="server"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td align="center" style="padding-bottom: 15px;">
                                <asp:Literal ID="litDeleteRow" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnDeleteRow" OnClick="btnDeleteRow_OnClick" runat="server" Style="display: inline;
                                    padding-right: 10px;" OnClientClick="fnDisplayCatchErrorMessage();" />
                                <asp:Button ID="btnCalncel" runat="server" Style="display: inline;" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpeAddTaxRate" runat="server" TargetControlID="hdnAddTaxRate"
            PopupControlID="pnlAddTaxRate" BackgroundCssClass="mod_background" CancelControlID="btnCalncelTaxRate">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnAddTaxRate" runat="server" />
        <asp:Panel ID="pnlAddTaxRate" runat="server" Height="400px" Width="385px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="litHeaderTaxRate" Text="Add Tax" runat="server"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td class="isrequire" style="width: 100px;">
                                <asp:Literal runat="server" ID="litAddTaxRate"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtGvTaxRate" runat="server" MaxLength="15" SkinID="nowidth" Style="text-align: right;"
                                    Width="120px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvGvTaxRate" Display="Dynamic" runat="server" SetFocusOnError="true"
                                    CssClass="input-notification error png_bg" ValidationGroup="IsRequireTaxRate"
                                    ControlToValidate="txtGvTaxRate"></asp:RequiredFieldValidator>
                                <ajx:FilteredTextBoxExtender ID="ftbGvTaxRate" runat="server" TargetControlID="txtGvTaxRate"
                                    FilterMode="ValidChars" ValidChars="0123456789.">
                                </ajx:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire">
                                <asp:Literal ID="litAddTaxType" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlGvTaxRate" OnSelectedIndexChanged="ddlGvTaxRate_OnSelectedIndexChanged"
                                    AutoPostBack="true" runat="server" Style="float: left; width: 90px !important;">
                                    <asp:ListItem Value="0" Text="%"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="Flat"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire">
                                <asp:Literal runat="server" ID="litAddMinAmount"></asp:Literal>
                            </td>
                            <td>
                                <%--<asp:TextBox ID="txtGvStartDate" onkeypress="return false;" runat="server" SkinID="nowidth"
                                    Style="text-align: right;" Width="120px" MaxLength="24"></asp:TextBox>
                                <asp:Image ID="imgGvStartDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                    Height="20px" Width="20px" />
                                <ajx:CalendarExtender ID="calGvStartDate" PopupButtonID="imgGvStartDate" TargetControlID="txtGvStartDate"
                                    runat="server">
                                </ajx:CalendarExtender>--%>
                                <asp:TextBox ID="txtMinAmount" runat="server" MaxLength="15" SkinID="nowidth" Width="120px"></asp:TextBox>
                                <ajx:FilteredTextBoxExtender ID="ftMinAmount" runat="server" TargetControlID="txtMinAmount"
                                    FilterMode="ValidChars" ValidChars="0123456789.">
                                </ajx:FilteredTextBoxExtender>
                                <asp:RequiredFieldValidator ID="rfvGvMinAmount" Display="Dynamic" runat="server"
                                    SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequireTaxRate"
                                    ControlToValidate="txtMinAmount"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal runat="server" ID="litAddmaxAmount"></asp:Literal>
                            </td>
                            <td>
                                <%--<asp:TextBox ID="txtGvEndDate" onkeypress="return false;" runat="server" SkinID="nowidth"
                                    Style="text-align: right;" Width="120px" MaxLength="24"></asp:TextBox>
                                <asp:Image ID="imgGvEndDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                    Height="20px" Width="20px" />
                                <ajx:CalendarExtender ID="calGvEndDate" PopupButtonID="imgGvEndDate" TargetControlID="txtGvEndDate"
                                    runat="server">
                                </ajx:CalendarExtender>--%>
                                <asp:TextBox ID="txtMaxAmount" MaxLength="15" runat="server" SkinID="nowidth" Width="120px"></asp:TextBox>
                                <ajx:FilteredTextBoxExtender ID="ftMaxAmount" runat="server" TargetControlID="txtMaxAmount"
                                    FilterMode="ValidChars" ValidChars="0123456789.">
                                </ajx:FilteredTextBoxExtender>
                                <%--<asp:RequiredFieldValidator ID="rfvGvMaxAmount" Display="Dynamic" runat="server"
                                    SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequireTaxRate"
                                    ControlToValidate="txtMaxAmount"></asp:RequiredFieldValidator>--%>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:RegularExpressionValidator ID="revGvTaxRate" SetFocusOnError="True" runat="server"
                                    ValidationGroup="IsRequireTaxRate" ControlToValidate="txtGvTaxRate" Display="Dynamic"
                                    ForeColor="Red" ValidationExpression="^\d{0,18}(\.\d{0,2})?$"></asp:RegularExpressionValidator>
                                <asp:RangeValidator ID="rvGvTaxRate" Enabled="false" Display="Dynamic" runat="server"
                                    MinimumValue="0" ControlToValidate="txtGvTaxRate" SetFocusOnError="true" ValidationGroup="IsRequireTaxRate"
                                    ForeColor="Red" Type="Double"></asp:RangeValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:RegularExpressionValidator ID="revMinAmount" SetFocusOnError="True" runat="server"
                                    ValidationGroup="IsRequireTaxRate" ControlToValidate="txtMinAmount" Display="Dynamic"
                                    ForeColor="Red" ValidationExpression="^\d{0,18}(\.\d{0,2})?$"></asp:RegularExpressionValidator><br />
                                <asp:RegularExpressionValidator ID="revMaxAmount" SetFocusOnError="True" runat="server"
                                    ValidationGroup="IsRequireTaxRate" ControlToValidate="txtMaxAmount" Display="Dynamic"
                                    ForeColor="Red" ValidationExpression="^\d{0,18}(\.\d{0,2})?$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lblDateValidateMsg" Style="color: Red;" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Button ID="btnSaveTaxRate" OnClick="btnSaveTaxRate_OnClick" ValidationGroup="IsRequireTaxRate"
                                    CausesValidation="true" runat="server" Style="display: inline; padding-right: 10px;"
                                    OnClientClick="return fnDisplayCatchErrorMessage();" />
                                <asp:Button ID="btnCalncelTaxRate" runat="server" Style="display: inline;" />
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
<asp:UpdateProgress AssociatedUpdatePanelID="updAmenitiesList" ID="UpdateProgressAmenitiesList"
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
