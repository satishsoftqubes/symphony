<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlItem.ascx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.Inventory.CtrlItem" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">
    function fnConfirmDelete(id) {

        document.getElementById('errormessage').style.display = "block";
        document.getElementById('<%= hdnConfirmDelete.ClientID %>').value = id;
        $find('mpeConfirmDelete').show();
        return false;
    }

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function ItemValidate() {
        if (Page_ClientValidate("IsRequireItem")) {
            document.getElementById('errormessage').style.display = "block";

            var isValid = false;
            var gridView = document.getElementById("<%= gvAvailability.ClientID %>");
            for (var i = 1; i < gridView.rows.length; i++) {

                var inputs = gridView.rows[i].getElementsByTagName('input');

                if (inputs != null) {
                    if (inputs[0].type == "checkbox") {
                        
                        if (inputs[0].checked) {
                            isValid = true;
                            if (inputs[1].value == "") {
                                $find('mpeCustomePopup').show();
                                return false;
                            }
                        }
                    }
                }
            }
        }
        else {
            return false;
        }

    }
        
</script>
<asp:UpdatePanel ID="upnlItem" runat="server">
    <ContentTemplate>
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
                            </td>
                            <td>
                                <div class="box_form">
                                    <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                        <tr>
                                            <td colspan="3">
                                                <%if (IsFeedbackMessage)
                                                  { %>
                                                <div class="message finalsuccess">
                                                    <p>
                                                        <strong>
                                                            <asp:Literal ID="litFeedbackMessage" runat="server"></asp:Literal></strong>
                                                    </p>
                                                </div>
                                                <%}%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <div style="float: right; padding-bottom: 5px;">
                                                    <b>
                                                        <asp:Literal ID="litGeneralMandartoryFiledMessage" runat="server"></asp:Literal>
                                                    </b>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="isrequire">
                                                <asp:Literal ID="litItemCodeItemName" runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCode" runat="server" SkinID="nowidth" Width="80px" MaxLength="7"></asp:TextBox>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rvfCode" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                        runat="server" ValidationGroup="IsRequire" Display="Dynamic" ControlToValidate="txtCode"></asp:RequiredFieldValidator></span>
                                                /
                                                <asp:TextBox ID="txtItemName" runat="server" MaxLength="67"></asp:TextBox>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rfvItemName" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                        runat="server" ValidationGroup="IsRequire" ControlToValidate="txtItemName"></asp:RequiredFieldValidator></span>
                                            </td>
                                            <td id="tdHeaderOtherInfo" runat="server" visible="false">
                                                <h1>
                                                    <asp:Literal ID="ltrHeaderOtherInformation" runat="server"></asp:Literal>
                                                </h1>
                                                <hr>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="isrequire">
                                                <asp:Literal ID="litItemType" runat="server"></asp:Literal>
                                            </td>
                                            <td width="390px">
                                                <asp:DropDownList ID="ddlItemType" runat="server">
                                                </asp:DropDownList>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rfvItemType" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                        runat="server" ValidationGroup="IsRequire" InitialValue="00000000-0000-0000-0000-000000000000"
                                                        ControlToValidate="ddlItemType"></asp:RequiredFieldValidator></span>
                                            </td>
                                            <td>
                                                &nbsp;<asp:LinkButton ID="lnkBtnUOMConversion" runat="server" Visible="false" OnClick="lnkBtnUOMConversion_OnClick"></asp:LinkButton>
                                            </td>
                                        </tr>
                                        <%--<tr>
                                            <td class="isrequire">
                                                <asp:Literal ID="litCategory" runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlCategory" runat="server">
                                                </asp:DropDownList>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rfvCategory" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                        runat="server" ValidationGroup="IsRequire" InitialValue="00000000-0000-0000-0000-000000000000"
                                                        ControlToValidate="ddlCategory"></asp:RequiredFieldValidator></span>
                                            </td>
                                            <td>
                                                &nbsp;<asp:LinkButton ID="lnkBtnStockHandler" runat="server" Visible="false" OnClick="lnkBtnStockHandler_OnClick"></asp:LinkButton>
                                            </td>
                                        </tr>--%>
                                        <tr>
                                            <td class="isrequire">
                                                <asp:Literal ID="litSalePrice" runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtSalePrice" runat="server" SkinID="nowidth" Width="100px" Style="text-align: right;"
                                                    MaxLength="24"></asp:TextBox>
                                                <ajx:FilteredTextBoxExtender ID="ftbSalePrice" runat="server" TargetControlID="txtSalePrice"
                                                    FilterMode="ValidChars" ValidChars="0123456789.">
                                                </ajx:FilteredTextBoxExtender>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rvfSalePrice" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                        runat="server" ValidationGroup="IsRequire" ControlToValidate="txtSalePrice"></asp:RequiredFieldValidator></span>
                                                <div>
                                                    <asp:RegularExpressionValidator Display="Dynamic" ID="regSalePrice" runat="server"
                                                        ForeColor="Red" ControlToValidate="txtSalePrice" SetFocusOnError="true" ValidationGroup="IsRequire">
                                                    </asp:RegularExpressionValidator>
                                                </div>
                                            </td>
                                            <td>
                                                &nbsp;<asp:LinkButton ID="lnkBtnStockHandler" runat="server" Visible="false" OnClick="lnkBtnStockHandler_OnClick"></asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="isrequire">
                                                <asp:Literal ID="litPurchasePrice" runat="server"></asp:Literal>
                                            </td>
                                            <td colspan="2">
                                                <asp:TextBox ID="txtPurchasePrice" runat="server" SkinID="nowidth" Width="100px"
                                                    Style="text-align: right;" MaxLength="24"></asp:TextBox>
                                                <ajx:FilteredTextBoxExtender ID="ftbPurchasePrice" runat="server" TargetControlID="txtPurchasePrice"
                                                    FilterMode="ValidChars" ValidChars="0123456789.">
                                                </ajx:FilteredTextBoxExtender>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rvfPurchasePrice" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                        runat="server" ValidationGroup="IsRequire" ControlToValidate="txtPurchasePrice"></asp:RequiredFieldValidator></span>
                                                <div>
                                                    <asp:RegularExpressionValidator Display="Dynamic" ID="regPurchasePrice" runat="server"
                                                        ForeColor="Red" ControlToValidate="txtPurchasePrice" SetFocusOnError="true" ValidationGroup="IsRequire">
                                                    </asp:RegularExpressionValidator>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="isrequire">
                                                <asp:Literal ID="ltrUnitOfMeasure" runat="server"></asp:Literal>
                                            </td>
                                            <td colspan="2">
                                                <asp:DropDownList ID="ddlUnitOfMeasure" runat="server">
                                                </asp:DropDownList>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rfvUnitOfMeasure" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                        runat="server" ValidationGroup="IsRequire" InitialValue="00000000-0000-0000-0000-000000000000"
                                                        ControlToValidate="ddlUnitOfMeasure"></asp:RequiredFieldValidator></span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                &nbsp;
                                            </th>
                                            <td class="checkbox_new" colspan="2">
                                                <asp:CheckBox ID="chkIsConsumable" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="50%">
                                                <h1>
                                                   <asp:Literal ID="litCategoryList" runat="server"></asp:Literal>
                                                </h1>
                                                <hr />
                                            </td>
                                            <td width="50%">
                                                <h1>
                                                 <asp:Literal ID="litHeaderTaxes" runat="server"></asp:Literal>
                                                   
                                                </h1>
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="min-height: 150px; overflow: auto; vertical-align: top; border-right:1px solid #CCCCCC;" width="65%">
                                                <%--<div class="box_head">
                                                    <span>
                                                        <asp:Literal ID="litGridCategoryList" runat="server"></asp:Literal>
                                                    </span>
                                                </div>--%>
                                                <div class="clear">
                                                </div>
                                                <div class="box_content">
                                                    <asp:GridView ID="gvCategories" runat="server" AutoGenerateColumns="False" Width="100%"
                                                        ShowHeader="true" OnRowDataBound="gvCategories_RowDataBound" SkinID="gvNoPaging"
                                                        DataKeyNames="CategoryID">
                                                        <Columns>
                                                            <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHrdNo" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrSelect" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chkSelectCategory" runat="server" OnCheckedChanged="chkSelectCategory_CheckedChanged"
                                                                        AutoPostBack="true" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrCategoryCode" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "CategoryCode")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrCategoryName" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCategoryName" runat="server"></asp:Label>
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
                                            <td valign="top" style="vertical-align: top;" class="content_checkbox" width="35%">
                                                <div style="height: 170px; overflow: auto;">
                                                    <div class="clear">
                                                    </div>
                                                    <div class="box_content">
                                                        <asp:GridView ID="gvTaxes" runat="server" AutoGenerateColumns="false" Width="100%"
                                                            ShowHeader="true" OnRowDataBound="gvTaxes_RowDataBound" SkinID="gvNoPaging" DataKeyNames="AcctID">
                                                            <Columns>
                                                                <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                    <HeaderTemplate>
                                                                        <asp:Literal ID="litGvHdrNumber" runat="server"></asp:Literal>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <%#Container.DataItemIndex+1 %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                    <HeaderTemplate>
                                                                        <asp:Literal ID="litGvHdrSelect" runat="server"></asp:Literal>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chkSelect" runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                    <HeaderTemplate>
                                                                        <asp:Literal ID="litGvHdrTax" runat="server"></asp:Literal>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTax" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "AcctName")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EmptyDataTemplate>
                                                                <div style="padding: 10px;">
                                                                    <b>
                                                                        <asp:Literal ID="litNoRecordFound" runat="server"></asp:Literal>
                                                                    </b>
                                                                </div>
                                                            </EmptyDataTemplate>
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="padding-top:8px;">
                                                <h1>
                                                     <asp:Literal ID="litHeaderAvailability" runat="server"></asp:Literal>
                                                </h1>
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" style="vertical-align: top;" class="content_checkbox">
                                                <div style="height: 170px; overflow: auto;">
                                                    <div class="clear">
                                                    </div>
                                                    <div class="box_content">
                                                        <asp:GridView ID="gvAvailability" runat="server" AutoGenerateColumns="false" Width="100%"
                                                            ShowHeader="true" SkinID="gvNoPaging" OnRowDataBound="gvAvailability_RowDataBound"
                                                            DataKeyNames="POSPointID,POSLocation_TermID,CategoryID">
                                                            <Columns>
                                                                <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                    <HeaderTemplate>
                                                                        <asp:Literal ID="litGvHdrNumber" runat="server"></asp:Literal>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <%#Container.DataItemIndex+1 %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                    <HeaderTemplate>
                                                                        <asp:Literal ID="litGvHdrSelect" runat="server"></asp:Literal>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chkSelect" runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <%--<asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                    <HeaderTemplate>
                                                                        <asp:Literal ID="litGvHdrPOSPoints" runat="server"></asp:Literal>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPOSPoints" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "PointDisplayName")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>--%>
                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                                    ItemStyle-Width="210px">
                                                                    <HeaderTemplate>
                                                                        <asp:Literal ID="litGvHdrPointDisplayName" runat="server"></asp:Literal>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblGvPointDisplayName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "PointDisplayName")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                                    ItemStyle-Width="210px">
                                                                    <HeaderTemplate>
                                                                        <asp:Literal ID="litGvHdrCategoryName" runat="server"></asp:Literal>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblGvCategoryName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CategoryName")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>                                                                
                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">                                                                    
                                                                    <HeaderTemplate>
                                                                        <asp:Literal ID="litGvHdrServiceRate" runat="server"></asp:Literal>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtGvServiceRate" runat="server" MaxLength="24" style="width:100px !important; text-align:right; border:1px solid #ccc;"></asp:TextBox>
                                                                        &nbsp;&nbsp;&nbsp;
                                                                        <asp:RegularExpressionValidator ID="revServiceRate" SetFocusOnError="True" runat="server"
                                                                            ValidationGroup="IsRequire" ControlToValidate="txtGvServiceRate"
                                                                            Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                                                                        <ajx:FilteredTextBoxExtender ID="ftServiceRate" runat="server" TargetControlID="txtGvServiceRate"
                                                                            FilterType="Custom, Numbers" ValidChars="." />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <%--<asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                                    ItemStyle-Width="180px">
                                                                    <HeaderTemplate>
                                                                        <asp:Literal ID="litGvHdrPOSLocation" runat="server" Text="Location"></asp:Literal>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPOSLocation" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "POSLocation")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>--%>
                                                            </Columns>
                                                            <EmptyDataTemplate>
                                                                <div style="padding: 10px;">
                                                                    <b>
                                                                        <asp:Literal ID="litNoRecordFound" runat="server"></asp:Literal>
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
                                                <div style="float: right; width: auto; display: inline-block;">
                                                    <asp:Button ID="btnCancel" Style="float: right; margin-left: 5px;" runat="server"
                                                        CausesValidation="false" OnClick="btnCancel_OnClick" />
                                                    <asp:Button ID="btnSave" Style="float: right; margin-left: 5px;" runat="server" ValidationGroup="IsRequire"
                                                        CausesValidation="true" OnClick="btnSave_OnClick" OnClientClick="return ItemValidate();" />
                                                    <asp:Button ID="btnBackToList" Style="float: right; margin-left: 5px;" runat="server"
                                                        CausesValidation="false" OnClick="btnBackToList_OnClick" />
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
                    <div>
                        <ajx:ModalPopupExtender ID="mpeStockHandler" runat="server" TargetControlID="hfStockHandler"
                            PopupControlID="pnlStockHandler" BackgroundCssClass="mod_background" CancelControlID="btnStockHandlerCancel">
                        </ajx:ModalPopupExtender>
                        <asp:HiddenField ID="hfStockHandler" runat="server" />
                        <asp:Panel ID="pnlStockHandler" runat="server" Width="500px" Style="display: none;">
                            <div class="box_col1">
                                <div class="box_head">
                                    <span>
                                        <asp:Literal ID="litHeaderPopupStockHandler" runat="server"></asp:Literal></span></div>
                                <div class="clear">
                                </div>
                                <div class="box_form">
                                    <div style="padding-top: 10px; padding-bottom: 10px; padding-left: 15px; padding-right: 25px;">
                                        <table cellpadding="2" cellspacing="2" width="100%">
                                            <tr>
                                                <td colspan="2">
                                                    <div style="float: right; padding-bottom: 5px;">
                                                        <b>
                                                            <asp:Literal ID="litGeneralMandartoryFiledMessageForStockHandler" runat="server"></asp:Literal>
                                                        </b>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="isrequire" align="left" style="padding-top: 2px; padding-bottom: 6px;">
                                                    <asp:Literal ID="litPreferredSupplier" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left" style="padding-top: 2px; padding-bottom: 6px;">
                                                    <asp:DropDownList ID="ddlPreferredSupplier" runat="server">
                                                        <asp:ListItem Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                        <asp:ListItem Text="Supplier One" Value="10000000-1000-1000-1000-100000000000"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <span>
                                                        <asp:RequiredFieldValidator ID="rfvPreferredSupplier" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                            runat="server" ValidationGroup="vgStockHandler" InitialValue="00000000-0000-0000-0000-000000000000"
                                                            ControlToValidate="ddlPreferredSupplier"></asp:RequiredFieldValidator></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="isrequire">
                                                    <asp:Literal ID="litMinMaxStock" runat="server"></asp:Literal>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtMinStock" runat="server" SkinID="nowidth" Style="text-align: right;"
                                                        MaxLength="24" Width="120px"></asp:TextBox>
                                                    <ajx:FilteredTextBoxExtender ID="fteMinStock" runat="server" TargetControlID="txtMinStock"
                                                        FilterMode="ValidChars" ValidChars="0123456789.">
                                                    </ajx:FilteredTextBoxExtender>
                                                    <span>
                                                        <asp:RequiredFieldValidator ID="rvfMinStock" runat="server" ControlToValidate="txtMinStock"
                                                            SetFocusOnError="true" Display="Dynamic" CssClass="input-notification error png_bg"
                                                            ValidationGroup="vgStockHandler"></asp:RequiredFieldValidator>
                                                    </span>/
                                                    <asp:TextBox ID="txtMaxStock" runat="server" SkinID="nowidth" Style="text-align: right;"
                                                        MaxLength="24" Width="120px"></asp:TextBox>
                                                    <ajx:FilteredTextBoxExtender ID="fteMaxStock" runat="server" TargetControlID="txtMaxStock"
                                                        FilterMode="ValidChars" ValidChars="0123456789.">
                                                    </ajx:FilteredTextBoxExtender>
                                                    <span>
                                                        <%--<asp:RequiredFieldValidator ID="rvfMaxStock" runat="server" ControlToValidate="txtMaxStock"
                                                        SetFocusOnError="true" Display="Dynamic" CssClass="input-notification error png_bg" ValidationGroup="vgStockHandler"></asp:RequiredFieldValidator>--%>
                                                    </span>
                                                    <div>
                                                        <div>
                                                            <asp:CompareValidator ID="cmpvMinMaxStock" runat="server" ControlToValidate="txtMinStock"
                                                                ControlToCompare="txtMaxStock" Operator="LessThanEqual" Type="Double" SetFocusOnError="true"
                                                                Display="Dynamic" ForeColor="Red" ValidationGroup="vgStockHandler"></asp:CompareValidator>
                                                        </div>
                                                        <div>
                                                            <asp:RegularExpressionValidator Display="Dynamic" ID="regMinStock" runat="server"
                                                                ForeColor="Red" ControlToValidate="txtMinStock" SetFocusOnError="true" ValidationGroup="vgStockHandler">
                                                            </asp:RegularExpressionValidator>
                                                        </div>
                                                        <div>
                                                            <asp:RegularExpressionValidator Display="Dynamic" ID="regMaxStock" runat="server"
                                                                ForeColor="Red" ControlToValidate="txtMaxStock" SetFocusOnError="true" ValidationGroup="vgStockHandler">
                                                            </asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="isrequire" align="left" style="padding-top: 2px; padding-bottom: 6px;">
                                                    <asp:Literal ID="litStockOnHand" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left" style="padding-top: 2px; padding-bottom: 6px;">
                                                    <asp:TextBox ID="txtStockOnHand" runat="server" Style="text-align: right;" SkinID="nowidth"
                                                        MaxLength="24" Width="120px"></asp:TextBox>
                                                    <ajx:FilteredTextBoxExtender ID="ftbStockOnHand" runat="server" TargetControlID="txtStockOnHand"
                                                        FilterMode="ValidChars" ValidChars="0123456789.">
                                                    </ajx:FilteredTextBoxExtender>
                                                    <span>
                                                        <asp:RequiredFieldValidator ID="rfvStockOnHand" runat="server" ControlToValidate="txtStockOnHand"
                                                            SetFocusOnError="true" Display="Dynamic" CssClass="input-notification error png_bg"
                                                            ValidationGroup="vgStockHandler"></asp:RequiredFieldValidator>
                                                    </span>
                                                    <div>
                                                        <asp:RegularExpressionValidator Display="Dynamic" ID="regStockOnHand" runat="server"
                                                            ForeColor="Red" ControlToValidate="txtStockOnHand" SetFocusOnError="true" ValidationGroup="vgStockHandler">
                                                        </asp:RegularExpressionValidator>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th align="left" style="padding-top: 2px; padding-bottom: 6px;">
                                                    <asp:Literal ID="litReOrderLevel" runat="server"></asp:Literal>
                                                </th>
                                                <td align="left" style="padding-top: 2px; padding-bottom: 6px;">
                                                    <asp:TextBox ID="txtReOrderLevel" runat="server" SkinID="nowidth" Style="text-align: right;"
                                                        MaxLength="24" Width="120px"></asp:TextBox>
                                                    <ajx:FilteredTextBoxExtender ID="ftbReOrderLevel" runat="server" TargetControlID="txtReOrderLevel"
                                                        FilterMode="ValidChars" ValidChars="0123456789.">
                                                    </ajx:FilteredTextBoxExtender>
                                                    <div>
                                                        <asp:RegularExpressionValidator Display="Dynamic" ID="regReOrderLevel" runat="server"
                                                            ForeColor="Red" ControlToValidate="txtReOrderLevel" SetFocusOnError="true" ValidationGroup="vgStockHandler">
                                                        </asp:RegularExpressionValidator>
                                                    </div>
                                                    <%--<span>
                                                    <asp:RequiredFieldValidator ID="rfvReOrderLevel" runat="server" ControlToValidate="txtReOrderLevel"
                                                        SetFocusOnError="true" Display="Dynamic" CssClass="input-notification error png_bg"
                                                        ValidationGroup="vgStockHandler"></asp:RequiredFieldValidator>
                                                </span>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th align="left" style="padding-bottom: 6px;">
                                                    <asp:Literal ID="litUOMStockHandler" runat="server"></asp:Literal>
                                                </th>
                                                <td style="padding-bottom: 6px;">
                                                    <asp:DropDownList ID="ddlUOMStockHandler" runat="server">
                                                    </asp:DropDownList>
                                                    <%--<span>
                                                    <asp:RequiredFieldValidator ID="rfvDiscountType" runat="server" ControlToValidate="ddlUOM"
                                                        InitialValue="00000000-0000-0000-0000-000000000000" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                        ValidationGroup="vgStockHandler"></asp:RequiredFieldValidator>
                                                </span>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2">
                                                    <table cellpadding="3" cellspacing="3" style="margin-left: 5px; margin-top: 15px;">
                                                        <tr>
                                                            <td>
                                                                <asp:Button ID="btnStockHandlerSave" runat="server" CausesValidation="true" ValidationGroup="vgStockHandler"
                                                                    OnClick="btnStockHandlerSave_Click" OnClientClick="fnDisplayCatchErrorMessage();" />
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnStockHandlerCancel" runat="server" CausesValidation="false" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                    <div>
                        <ajx:ModalPopupExtender ID="mpeUOM" runat="server" TargetControlID="hfUOM" PopupControlID="pnlUOM"
                            BackgroundCssClass="mod_background" CancelControlID="btnUOMCancel">
                        </ajx:ModalPopupExtender>
                        <asp:HiddenField ID="hfUOM" runat="server" />
                        <asp:Panel ID="pnlUOM" runat="server" Width="650px" Style="display: none;">
                            <div class="box_col1">
                                <div class="box_head">
                                    <span>
                                        <asp:Literal ID="litHeaderPopupUOM" runat="server"></asp:Literal></span></div>
                                <div class="clear">
                                </div>
                                <div class="box_form">
                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                        <tr>
                                            <td colspan="5">
                                                <%if (IsUOMPopupMessage)
                                                  { %>
                                                <div class="message finalsuccess">
                                                    <p>
                                                        <strong>
                                                            <asp:Literal ID="litMsgUOMPopup" runat="server"></asp:Literal></strong>
                                                    </p>
                                                </div>
                                                <%}%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="5">
                                                <div style="float: right; padding-bottom: 5px;">
                                                    <b>
                                                        <asp:Literal ID="litGeneralMandartoryFiledMessageForUOM" runat="server"></asp:Literal>
                                                    </b>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="font-weight: bold;" width="60px" class="lblsameasth">
                                                <asp:Literal ID="litFactor" runat="server"></asp:Literal>
                                            </td>
                                            <td align="left" width="170px">
                                                <asp:TextBox ID="txtFactor" runat="server" SkinID="nowidth" Style="text-align: right;"
                                                    MaxLength="24" Width="120px"></asp:TextBox>
                                                <ajx:FilteredTextBoxExtender ID="ftbFactor" runat="server" TargetControlID="txtFactor"
                                                    FilterMode="ValidChars" ValidChars="0123456789.">
                                                </ajx:FilteredTextBoxExtender>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rfvFactor" runat="server" ControlToValidate="txtFactor"
                                                        SetFocusOnError="true" Display="Dynamic" CssClass="input-notification error png_bg"
                                                        ValidationGroup="vgUOM"></asp:RequiredFieldValidator>
                                                </span>
                                            </td>
                                            <td style="font-weight: bold;" width="60px" class="lblsameasth">
                                                <asp:Literal ID="litUOM" runat="server"></asp:Literal>
                                            </td>
                                            <td width="200px">
                                                <asp:DropDownList ID="ddlUOM" runat="server" SkinID="nowidth" Width="170px">
                                                </asp:DropDownList>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rfvUOM" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                        runat="server" ValidationGroup="vgUOM" InitialValue="00000000-0000-0000-0000-000000000000"
                                                        ControlToValidate="ddlUOM"></asp:RequiredFieldValidator></span>
                                            </td>
                                            <td>
                                                <asp:Button ID="btnAddItemUOM" runat="server" CausesValidation="true" ValidationGroup="vgUOM"
                                                    OnClick="btnAddItemUOM_OnClick" OnClientClick="fnDisplayCatchErrorMessage();" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td colspan="4">
                                                <asp:RegularExpressionValidator Display="Dynamic" ID="regFactor" runat="server" ForeColor="Red"
                                                    ControlToValidate="txtFactor" SetFocusOnError="true" ValidationGroup="vgUOM">
                                                </asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="5" valign="top" style="vertical-align: top;">
                                                <div style="height: 170px; overflow: auto;">
                                                    <div class="clear">
                                                    </div>
                                                    <div class="box_content">
                                                        <asp:GridView ID="gvUOM" runat="server" AutoGenerateColumns="False" Width="100%"
                                                            OnPageIndexChanging="gvUOM_OnPageIndexChanging" CssClass="grid_content" OnRowCommand="gvUOM_RowCommand"
                                                            OnRowDataBound="gvUOM_RowDataBound">
                                                            <Columns>
                                                                <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                    <HeaderTemplate>
                                                                        <asp:Literal ID="litGvHdrNumber" runat="server"></asp:Literal>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <%#Container.DataItemIndex+1 %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                    <HeaderTemplate>
                                                                        <asp:Literal ID="litGvHdrUOMName" runat="server"></asp:Literal>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblUOMName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "UOMName")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                    <HeaderTemplate>
                                                                        <asp:Literal ID="litGvHdrUOMFactor" runat="server"></asp:Literal>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblFactor" runat="server"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="50px">
                                                                    <HeaderTemplate>
                                                                        <asp:Literal ID="litGvHdrActions" runat="server"></asp:Literal>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ItemUOMID")%>'
                                                                            CommandName="EDITDATA" OnClientClick="fnDisplayCatchErrorMessage();"><img src="../../images/file.png" /></asp:LinkButton>
                                                                        <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ItemUOMID")%>'
                                                                            CommandName="DELETEDATA" OnClientClick="fnDisplayCatchErrorMessage();"><img src="../../images/delete.png" /></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EmptyDataTemplate>
                                                                <div style="padding: 10px;">
                                                                    <b>
                                                                        <asp:Literal ID="litNoRecordFound" runat="server"></asp:Literal>
                                                                    </b>
                                                                </div>
                                                            </EmptyDataTemplate>
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="5">
                                                <asp:Button ID="btnUOMCancel" runat="server" CausesValidation="false" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </td>
            </tr>
        </table>
        <ajx:ModalPopupExtender ID="mpeConfirmDelete" runat="server" TargetControlID="hdnConfirmDelete"
            PopupControlID="pnlDeleteData" BackgroundCssClass="mod_background" CancelControlID="btnCancelDelete"
            BehaviorID="mpeConfirmDelete">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnConfirmDelete" runat="server" />
        <asp:Panel ID="pnlDeleteData" runat="server" Height="150px" Width="325px" Style="display: none;">
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

        <asp:HiddenField ID="hfPopupCustomeMessage" runat="server" />
        <ajx:ModalPopupExtender ID="mpeCustomePopup" runat="server" TargetControlID="hfPopupCustomeMessage"
            PopupControlID="pnlCustomeMessage" BackgroundCssClass="mod_background" CancelControlID="btnOKCustomeMsgPopup"
            DropShadow="true" BehaviorID="mpeCustomePopup">
        </ajx:ModalPopupExtender>
        <asp:Panel ID="pnlCustomeMessage" runat="server" Width="350px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="litHeaderCustomePopupMessage" runat="server" Text="Message"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td align="center" style="padding-bottom: 15px; color: Red;">
                                <asp:Literal ID="litCustomePopupMsg" runat="server" Text=""></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnOKCustomeMsgPopup" runat="server" Text="OK" Style="display: inline;
                                    padding-right: 10px;" />
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
<asp:UpdateProgress AssociatedUpdatePanelID="upnlItem" ID="upgrItem" runat="server">
    <ProgressTemplate>
        <div id="progressBackgroundFilter">
        </div>
        <div id="processMessage">
            <center>
                <img src="../../images/ajax-loader.gif" /></center>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
