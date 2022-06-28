<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlPOSPoints.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.Configurations.CtrlPOSPoints" %>
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
            var isValid = false;
            var gridView = document.getElementById("<%= gvmpeItemList.ClientID %>");
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
<asp:UpdatePanel ID="updPOSPoints" runat="server">
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
                            <td align="left">
                                <div class="box_form">
                                    <asp:MultiView ID="mvPosPoints" runat="server">
                                        <asp:View ID="vPosPointsList" runat="server">
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
                                                        <asp:Literal ID="litSearchPOSPointsName" runat="server"></asp:Literal>
                                                    </th>
                                                    <td style="width: 250px">
                                                        <asp:TextBox ID="txtSPOSPointsName" runat="server"></asp:TextBox>
                                                    </td>
                                                    <th>
                                                        <asp:Literal ID="litSearchPOSLocation" runat="server"></asp:Literal>
                                                    </th>
                                                    <td>
                                                        <asp:DropDownList ID="ddlSPOSLocation" runat="server">
                                                        </asp:DropDownList>
                                                        <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                            OnClientClick="fnDisplayCatchErrorMessage();" OnClick="btnSearch_Click" Style="border: 0px;
                                                            vertical-align: middle; margin: 0px 0 0 5px" />
                                                        <asp:ImageButton ID="imgbtnClearSearch" runat="server" ImageUrl="~/images/clearsearch.png"
                                                            Style="border: 0px; vertical-align: middle; margin: -2px 0 0 10px;" OnClick="imgbtnClearSearch_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <hr>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" align="right" valign="middle">
                                                        <asp:Button ID="btnAddTopPOSPoints" runat="server" Style="float: right;" OnClick="btnAddTopPOSPoints_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <div class="box_head">
                                                            <span>
                                                                <asp:Literal ID="litPOSPoints" runat="server"></asp:Literal></span></div>
                                                        <div class="clear">
                                                        </div>
                                                        <div class="box_content">
                                                            <asp:GridView ID="gvPOSPoints" runat="server" AutoGenerateColumns="false" Width="100%"
                                                                ShowHeader="true" OnPageIndexChanging="gvPOSPoints_PageIndexChanging" OnRowCommand="gvPOSPoints_RowCommand"
                                                                OnRowDataBound="gvPOSPoints_RowDataBound">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrSrNo" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%# Container.DataItemIndex + 1 %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrPointName" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblPointName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "POSPointName")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="300px" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrDispalyName" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblDispalyName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "PointDisplayName")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                                        ItemStyle-Width="150px">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrLocation" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblLocation" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "DisplayTerm")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                                        ItemStyle-Width="150px">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrCounter" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblCounter" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CounterNo")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="60px">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrViewDelete" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "POSPointID")%>'
                                                                                CommandName="EDITDATA" OnClientClick="fnDisplayCatchErrorMessage();"><img src="../../images/file.png" /></asp:LinkButton>
                                                                            <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "POSPointID")%>'
                                                                                CommandName="DELETEDATA"><img src="../../images/delete.png" /></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <div class="pagecontent_info">
                                                                        <div class="NoItemsFound">
                                                                            <h2>
                                                                                <asp:Label ID="lblNoRecordFound" runat="server"></asp:Label>
                                                                            </h2>
                                                                        </div>
                                                                    </div>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" align="right" valign="middle">
                                                        <asp:Button ID="btnAddBottomPOSPoints" runat="server" Style="float: right;" OnClick="btnAddTopPOSPoints_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                        <asp:View ID="vAddPosPointsList" runat="server">
                                            <table cellpadding="2" cellspacing="2" width="100%">
                                                <tr>
                                                    <td colspan="4">
                                                        <%if (IsPopupMessage)
                                                          { %>
                                                        <div class="message finalsuccess">
                                                            <p>
                                                                <strong>
                                                                    <asp:Literal ID="litMsgPopup" runat="server"></asp:Literal></strong>
                                                            </p>
                                                        </div>
                                                        <%}%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <div style="float: right; padding-bottom: 5px;">
                                                            <b>
                                                                <asp:Literal ID="litGeneralMandartoryFiledMessage" runat="server"></asp:Literal>
                                                            </b>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" class="isrequire" style="width:100px !important;">
                                                        <asp:Literal ID="litPOSPointsName" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="left" valign="top">
                                                        <asp:TextBox ID="txtPOSPointsName" runat="server" MaxLength="65"></asp:TextBox>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rvfPOSPointsName" runat="server" ControlToValidate="txtPOSPointsName"
                                                                SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire"></asp:RequiredFieldValidator>
                                                        </span>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="litDefaultCounter" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlDefaultCounter" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="isrequire" style="width:100px !important;">
                                                        <asp:Literal ID="litDisplayName" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtDisplayName" runat="server" MaxLength="165"></asp:TextBox>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rvfDisplayName" runat="server" ControlToValidate="txtDisplayName"
                                                                InitialValue="" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                ValidationGroup="IsRequire"></asp:RequiredFieldValidator>
                                                        </span>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="litVendor" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlVendor" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="isrequire" style="width:100px !important;">
                                                        <asp:Literal ID="litLocation" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlLocation" runat="server">
                                                        </asp:DropDownList>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rvfLocation" runat="server" ControlToValidate="ddlLocation"
                                                                InitialValue="00000000-0000-0000-0000-000000000000" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                ValidationGroup="IsRequire"></asp:RequiredFieldValidator>
                                                        </span>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="litDefaultUser" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlDefaultUser" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>                                                                                                                                                
                                                <tr>
                                                    <th>
                                                    </th>
                                                    <td class="checkbox_new" colspan="3">
                                                        <asp:CheckBox ID="chkIsTouchScreenEnable" runat="server" />
                                                        <asp:CheckBox ID="chkIsActivityPOS" runat="server" />
                                                        <%--<asp:CheckBox ID="chkConsumablePOS" runat="server" />--%>
                                                    </td>
                                                </tr>                                               
                                                <tr>
                                                    <td colspan="2">
                                                        <h1>
                                                            <asp:Literal ID="litCategoryList" runat="server" Text="Category List"></asp:Literal>
                                                        </h1>
                                                        <hr />
                                                    </td>
                                                    <td colspan="2">
                                                        <h1>
                                                            <asp:Literal ID="litItemList" runat="server"></asp:Literal>
                                                        </h1>
                                                        <hr />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="min-height: 150px; overflow: auto; vertical-align: top; padding-right:5px; border-right:1px solid #CCCCCC;" colspan="2">
                                                        <div class="clear">
                                                        </div>
                                                        <div class="box_content">
                                                            <asp:GridView ID="gvCategories" runat="server" AutoGenerateColumns="False" Width="100%"
                                                                ShowHeader="true" OnRowCommand="gvCategories_RowCommand" OnRowDataBound="gvCategories_RowDataBound" SkinID="gvNoPaging"
                                                                DataKeyNames="CategoryID">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHrdNo" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%# Container.DataItemIndex + 1 %>
                                                                            <asp:HiddenField ID="hdnFromDB" runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrSelect" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="chkSelectCategory" Enabled="false" runat="server"/>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <%--<asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrCategoryCode" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "CategoryCode")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>--%>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrCategoryName" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblCategoryName" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>                                                                    
                                                                    <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">                                                                        
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkAddItem" runat="server" CommandName="ADDITEM" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "CategoryID")%>' Text="Add Item"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <div style="padding: 10px;">
                                                                        <b>
                                                                            <asp:Label ID="lblCategoriesNoRecordFound" runat="server"></asp:Label></b>
                                                                    </div>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </div>
                                                    </td>
                                                    <td style="min-height: 150px; overflow: auto; vertical-align: top;" colspan="2">
                                                        <div class="clear">
                                                        </div>
                                                        <div class="box_content">
                                                            <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="False" Width="100%"
                                                                ShowHeader="true" OnRowDataBound="gvItem_RowDataBound" SkinID="gvNoPaging" DataKeyNames="ItemID,CategoryID,ItemCategoryID">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHrdSrNo" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%# Container.DataItemIndex + 1 %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                   <%-- <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrSelectItem" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="chkSelectItem" runat="server"/>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>--%>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrItemName" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                        <asp:Label ID="lblGvItemName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ItemName")%>'></asp:Label>                                                                            
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="165px"  HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrCategoryName" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvCategoryName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CategoryName")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="100px"  HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrItemRate" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>                                                                            
                                                                            <asp:Label ID="lblItemRate" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <div style="padding: 10px;">
                                                                        <b>
                                                                            <asp:Label ID="lblItemNoRecordFound" runat="server"></asp:Label></b>
                                                                    </div>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </div>
                                                    </td>
                                                </tr>                                                                                       
                                                <tr>
                                                    <td align="right" colspan="4">
                                                        <div style="display: inline;">
                                                            <%--<asp:Button ID="btnSaveAndClose" runat="server" CausesValidation="true" ValidationGroup="IsRequire"
                                                                Style="display: inline;" OnClick="btnSaveAndClose_Click" OnClientClick="fnDisplayCatchErrorMessage();" />--%>
                                                            <asp:Button ID="btnSave" runat="server" CausesValidation="true" ValidationGroup="IsRequire"
                                                                Style="display: inline;" OnClick="btnSave_Click" OnClientClick="fnDisplayCatchErrorMessage();" />
                                                            <asp:Button ID="btnCancel" runat="server" CausesValidation="false" Style="display: inline;"
                                                                OnClick="btnCancel_Click" OnClientClick="fnDisplayCatchErrorMessage();" /></div>
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
                </td>
            </tr>
        </table>        
        <ajx:ModalPopupExtender ID="mpeConfirmDelete" runat="server" TargetControlID="hdnConfirmDelete"
            PopupControlID="pnlDeleteData" BackgroundCssClass="mod_background" CancelControlID="btnCancelDelete"
            BehaviorID="mpeConfirmDelete">
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

        <ajx:ModalPopupExtender ID="mpeItemList" runat="server" TargetControlID="hdnItemList"
            PopupControlID="pnlItemList" BackgroundCssClass="mod_background" CancelControlID="btnmpeClose">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnItemList" runat="server" />
        <asp:Panel ID="pnlItemList" runat="server" Height="400px" Width="650px" style="display:none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="litHeaderGvMsgItemList" runat="server" Text="Item List"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td align="left" style="padding-bottom: 15px;">                             
                                <div class="clear">
                                </div>
                                <div class="box_content" style="height: 250px; width:620px; overflow: auto;">
                                    <asp:GridView ID="gvmpeItemList" runat="server" AutoGenerateColumns="false" Width="100%"
                                        SkinID="gvNoPaging" ShowHeader="true" OnRowDataBound="gvmpeItemList_RowDataBound" DataKeyNames="ItemID,CategoryID,ItemCategoryID">
                                        <Columns>
                                    <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                            <HeaderTemplate>
                                                <asp:Label ID="lblGvHrmpedSrNo" runat="server"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                            <HeaderTemplate>
                                                <asp:Label ID="lblGvHdrmpeSelectItem" runat="server"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkmpeSelectItem" runat="server"/>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                            <HeaderTemplate>
                                                <asp:Label ID="lblGvHdrmpeItemName" runat="server"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                            <asp:Label ID="lblGvmpeItemName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ItemName")%>'></asp:Label>                                                                            
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                            <HeaderTemplate>
                                                <asp:Label ID="lblGvHdrmpeItemRate" runat="server"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtmpeItemRate" MaxLength="24" style="width:100px !important; text-align:right" runat="server"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="revmpeItemRate" SetFocusOnError="True" runat="server"
                                                    ValidationGroup="IsRequireItem" ControlToValidate="txtmpeItemRate"
                                                    Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                                                <ajx:FilteredTextBoxExtender ID="ftmpeItemRate" runat="server" TargetControlID="txtmpeItemRate"
                                                    FilterType="Custom, Numbers" ValidChars="." />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <div style="padding: 10px;">
                                                <b>
                                                    <asp:Label ID="lblGvmpeNoRecordFound" runat="server"></asp:Label>
                                                </b>
                                            </div>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnmpeSubmit" runat="server" Style="display: inline; padding-right: 10px;" ValidationGroup="IsRequireItem" OnClick="btnmpeSubmit_Click" OnClientClick="return ItemValidate();" />
                                <asp:Button ID="btnmpeClose" runat="server" Style="display: inline; padding-right: 10px;" />
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
<asp:UpdateProgress AssociatedUpdatePanelID="updPOSPoints" ID="UpdateProgressPOSPoints"
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
