<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlOldAddOnsServices.ascx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.PriceManager.CtrlOldAddOnsServices" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript" language="javascript">

    function fnConfirmDelete(id) {
        document.getElementById('errormessage').style.display = "block";
        document.getElementById('<%= hdnConfirmDelete.ClientID %>').value = id;
        $find('mpeConfirmDelete').show();
        return false;
    }

    function fnSetRowIndex(rowIndex) {
        document.getElementById('<%= hfRowIndex.ClientID %>').value = rowIndex;
    }

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    } 
</script>
<asp:UpdatePanel ID="updAddonsServices" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td valign="top" style="padding-left: 0px; width: 33.33%">
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
                                &nbsp;
                            </td>
                            <td>
                                <div class="box_form">
                                    <asp:MultiView ID="mvAddOnsServices" runat="server">
                                        <asp:View ID="vAddOnsServices" runat="server">
                                            <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                <tr>
                                                    <td colspan="5">
                                                        <%if (IsListMessage)
                                                          { %>
                                                        <div class="message finalsuccess">
                                                            <p>
                                                                <strong>
                                                                    <asp:Literal ID="litListMessage" runat="server"></asp:Literal></strong>
                                                            </p>
                                                        </div>
                                                        <%} %>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="70px" class="lblsameasth">
                                                        <asp:Literal ID="litSearchTitle" runat="server"></asp:Literal>
                                                    </td>
                                                    <td width="240px">
                                                        <asp:TextBox ID="txtSearchTitle" runat="server" SkinID="searchtextbox"></asp:TextBox>
                                                    </td>
                                                    <td width="100px" class="lblsameasth">
                                                        <asp:Literal ID="litSearchPostingFrequency" runat="server"></asp:Literal>
                                                    </td>
                                                    <td width="290px">
                                                        <asp:DropDownList ID="ddlSearchPostingFrequency" runat="server" SkinID="searchddl">
                                                        </asp:DropDownList>
                                                        <asp:ImageButton ID="btnSearchAddOnsServices" Style="border: 0px; margin: -1px 0 0 5px;
                                                            vertical-align: middle;" OnClientClick="fnDisplayCatchErrorMessage();" runat="server"
                                                            ImageUrl="~/images/search-icon.png" OnClick="btnSearchAddOnsServices_OnClick" />
                                                        <asp:ImageButton ID="imgbtnClearSearch" runat="server" ImageUrl="~/images/clearsearch.png"
                                                            Style="border: 0px; vertical-align: middle; margin: -2px 0 0 10px;" OnClick="imgbtnClearSearch_Click" />
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="5" align="right" valign="middle">
                                                        <asp:Button ID="btnAddTopAddOnsServices" runat="server" OnClick="btnAddTopAddOnsServices_OnClick"
                                                            Style="float: right;" OnClientClick="fnDisplayCatchErrorMessage();" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="5">
                                                        <div class="box_head">
                                                            <span>
                                                                <asp:Literal ID="litAddOnsServicesList" runat="server"></asp:Literal></span></div>
                                                        <div class="clear">
                                                        </div>
                                                        <div class="box_content">
                                                            <asp:GridView ID="gvAddOnsInformation" runat="server" AutoGenerateColumns="false"
                                                                Width="100%" ShowHeader="true" SkinID="gvNoPaging" OnPageIndexChanging="gvAddOnsInformation_PageIndexChanging"
                                                                OnRowCommand="gvAddOnsInformation_RowCommand" OnRowDataBound="gvAddOnsInformation_RowDataBound">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrNumber" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%# Container.DataItemIndex + 1 %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrTitle" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem,"AddOnTitle") %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrPostingFreq" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "PostingFrequency")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="60px">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrAction" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "AddOnID")%>'
                                                                                CommandName="EDITDATA" OnClientClick="fnDisplayCatchErrorMessage();"><img src="../../images/file.png" alt="" /></asp:LinkButton>
                                                                            <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "AddOnID")%>'
                                                                                CommandName="DELETEDATA"><img src="../../images/delete.png" alt=""/></asp:LinkButton>
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
                                                    <td colspan="5" align="right" valign="middle">
                                                        <asp:Button ID="btnAddBottomAddOnsServices" runat="server" OnClick="btnAddTopAddOnsServices_OnClick"
                                                            Style="float: right;" OnClientClick="fnDisplayCatchErrorMessage();" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                        <asp:View ID="vAddEditAddOnsServices" runat="server">
                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td colspan="2">
                                                        <%if (IsAddEditMessage)
                                                          { %>
                                                        <div class="message finalsuccess">
                                                            <p>
                                                                <strong>
                                                                    <asp:Literal ID="litAddEditMessage" runat="server"></asp:Literal></strong>
                                                            </p>
                                                        </div>
                                                        <%}%>
                                                    </td>
                                                </tr>
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
                                                    <td width="45%" style="vertical-align: top;" valign="top">
                                                        <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                            <tr>
                                                                <td class="isrequire" align="left" style="padding-top: 2px; padding-bottom: 6px;">
                                                                    <asp:Literal ID="litTitle" runat="server"></asp:Literal>
                                                                </td>
                                                                <td width="280px" align="left" style="padding-top: 2px; padding-bottom: 6px;">
                                                                    <asp:TextBox ID="txtAddOnsServicesTitle" runat="server" MaxLength="120"></asp:TextBox>
                                                                    <span>
                                                                        <asp:RequiredFieldValidator ID="rfvAddOnsServicesTitle" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                            runat="server" ValidationGroup="IsRequired" ControlToValidate="txtAddOnsServicesTitle"></asp:RequiredFieldValidator></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="isrequire">
                                                                    <asp:Literal ID="litPostingFreq" runat="server"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlAddOnsServicesPostingFreq" runat="server">
                                                                    </asp:DropDownList>
                                                                    <span>
                                                                        <asp:RequiredFieldValidator ID="rfvAddOnsServicesPostingFreq" SetFocusOnError="true"
                                                                            InitialValue="00000000-0000-0000-0000-000000000000" CssClass="input-notification error png_bg"
                                                                            runat="server" ValidationGroup="IsRequired" ControlToValidate="ddlAddOnsServicesPostingFreq"></asp:RequiredFieldValidator></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="isrequire">
                                                                    <asp:Literal ID="litBasePrice" runat="server"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtAddOnsServicesBasePrice" runat="server" Style="text-align: right;"
                                                                        MaxLength="24"></asp:TextBox>
                                                                    <ajx:FilteredTextBoxExtender ID="ftbBasePrice" runat="server" TargetControlID="txtAddOnsServicesBasePrice"
                                                                        FilterMode="ValidChars" ValidChars="0123456789.">
                                                                    </ajx:FilteredTextBoxExtender>
                                                                    <span>
                                                                        <asp:RequiredFieldValidator ID="rfvAddOnsServicesBasePrice" SetFocusOnError="true"
                                                                            CssClass="input-notification error png_bg" runat="server" ValidationGroup="IsRequired"
                                                                            ControlToValidate="txtAddOnsServicesBasePrice"></asp:RequiredFieldValidator></span>
                                                                    <div>
                                                                        <asp:RegularExpressionValidator Display="Dynamic" ID="regBasePrice" runat="server"
                                                                            ForeColor="Red" ControlToValidate="txtAddOnsServicesBasePrice" SetFocusOnError="true"
                                                                            ValidationGroup="IsRequire">
                                                                        </asp:RegularExpressionValidator>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="isrequire">
                                                                    <asp:Literal ID="litChargePer" runat="server"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlAddOnsServicesChargePer" runat="server">
                                                                    </asp:DropDownList>
                                                                    <span>
                                                                        <asp:RequiredFieldValidator ID="rfvAddOnsServicesChargePer" SetFocusOnError="true"
                                                                            InitialValue="00000000-0000-0000-0000-000000000000" CssClass="input-notification error png_bg"
                                                                            runat="server" ValidationGroup="IsRequired" ControlToValidate="ddlAddOnsServicesChargePer"></asp:RequiredFieldValidator></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th align="left">
                                                                    <asp:Literal ID="litAvailableOnPOS" runat="server"></asp:Literal>
                                                                </th>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlAvailableOnPOS" runat="server">
                                                                    </asp:DropDownList>
                                                                    <%--<span>
                                                                        <asp:RequiredFieldValidator ID="rfvAvailableOnPOS" SetFocusOnError="true"
                                                                            InitialValue="00000000-0000-0000-0000-000000000000" CssClass="input-notification error png_bg"
                                                                            runat="server" ValidationGroup="IsRequired" ControlToValidate="ddlAvailableOnPOS"></asp:RequiredFieldValidator></span>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>
                                                                </th>
                                                                <td class="checkbox_new">
                                                                    <asp:CheckBox ID="chkIsAvailableOnIRS" runat="server" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td width="55%" style="vertical-align: top;" valign="top">
                                                        <div>
                                                            <h1>
                                                                <asp:Literal ID="litHeaderServices" runat="server"></asp:Literal></h1>
                                                            <hr />
                                                        </div>
                                                        <div class="clear">
                                                        </div>
                                                        <div style="height: 180px; overflow: auto;" >
                                                            <div class="box_content">
                                                                <asp:HiddenField ID="hfRowIndex" runat="server" />
                                                                <asp:GridView ID="gvAddOnsServices" runat="server" AutoGenerateColumns="false" Width="100%"
                                                                    CssClass="grid_content" DataKeyNames="ItemID" OnRowDataBound="gvAddOnsServices_RowDataBound">
                                                                    <Columns>
                                                                        <asp:TemplateField ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrSelect" runat="server"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox ID="chkSelect" runat="server" OnCheckedChanged="chkSelect_OnCheckedChanged"
                                                                                    AutoPostBack="true" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrService" runat="server"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <%#DataBinder.Eval(Container.DataItem, "ItemName")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrQty" runat="server"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtQuentity" runat="server" SkinID="nowidth" Style="text-align: right;"
                                                                                    Enabled="false" Width="120px" MaxLength="24"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="rfvQuentity" Display="Dynamic" runat="server" SetFocusOnError="true"
                                                                                    CssClass="input-notification error png_bg" ValidationGroup="IsRequired" Enabled="false"
                                                                                    ControlToValidate="txtQuentity"></asp:RequiredFieldValidator>
                                                                                <asp:RegularExpressionValidator Display="Dynamic" ID="regQuentity" runat="server"
                                                                                    CssClass="input-notification error png_bg" ControlToValidate="txtQuentity" SetFocusOnError="true"
                                                                                    ValidationGroup="IsRequired">
                                                                                </asp:RegularExpressionValidator>
                                                                                <ajx:FilteredTextBoxExtender ID="ftbQuentity" runat="server" TargetControlID="txtQuentity"
                                                                                    FilterMode="ValidChars" ValidChars="0123456789.">
                                                                                </ajx:FilteredTextBoxExtender>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <EmptyDataTemplate>
                                                                        <div class="pagecontent_info">
                                                                            <div class="NoItemsFound">
                                                                                <h2>
                                                                                    <asp:Label ID="lblNoRecordFound" runat="server"></asp:Label></h2>
                                                                            </div>
                                                                        </div>
                                                                    </EmptyDataTemplate>
                                                                </asp:GridView>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th style="padding-left: 8px;" align="left">
                                                        <asp:Literal ID="litDetail" runat="server"></asp:Literal>
                                                    </th>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="padding-left: 8px;">
                                                        <asp:TextBox ID="txtDetail" runat="server" SkinID="nowidth" TextMode="MultiLine"
                                                            Width="800px" Height="70px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <div style="float: right; width: auto; display: inline-Block;">
                                                            <asp:Button ID="btnCancel" Style="float: right; margin-left: 5px;" runat="server"
                                                                ImageUrl="~/images/cancle.png" CausesValidation="false" OnClick="btnAddOnsServicesCancel_OnClick" />
                                                            <asp:Button ID="btnSave" Style="float: right; margin-left: 5px;" runat="server" ImageUrl="~/images/save.png"
                                                                ValidationGroup="IsRequired" OnClientClick="fnDisplayCatchErrorMessage();" OnClick="btnAddOnsServicesSave_OnClick"
                                                                CausesValidation="true" />
                                                            <asp:Button ID="btnBackToList" Style="float: right; margin-left: 5px;" runat="server"
                                                                ImageUrl="~/images/cancle.png" CausesValidation="false" OnClick="btnBackToList_OnClick" />
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
                        <ajx:ModalPopupExtender ID="mpeConfirmDelete" runat="server" TargetControlID="hdnConfirmDelete"
                            PopupControlID="pnlDeleteData" BackgroundCssClass="mod_background" CancelControlID="btnCancelDelete" BehaviorID="mpeConfirmDelete">
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
                                                    OnClientClick="fnDisplayCatchErrorMessage();" UseSubmitBehavior="false" OnClick="btnYes_Click" />
                                                <asp:Button ID="btnCancelDelete" runat="server" Style="display: inline;" />
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
    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updAddonsServices" ID="uprgAddOnServices"
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
