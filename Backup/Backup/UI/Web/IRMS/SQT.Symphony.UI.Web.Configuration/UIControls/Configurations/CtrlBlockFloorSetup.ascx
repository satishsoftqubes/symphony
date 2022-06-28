<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlBlockFloorSetup.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.Configurations.CtrlBlockFloorSetup" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">
    function fnConfirmBlockDelete(id) {
        document.getElementById('errormessage').style.display = "block";
        document.getElementById('<%= hdnConfirmDelete.ClientID %>').value = id;
        document.getElementById('<%= hdnProcessType.ClientID %>').value = 'Block';
        $find('mpeConfirmDelete').show();
        return false;
    }

    function fnConfirmFloorDelete(id) {
        document.getElementById('errormessage').style.display = "block";
        document.getElementById('<%= hdnConfirmDelete.ClientID %>').value = id;
        document.getElementById('<%= hdnProcessType.ClientID %>').value = 'Floor';
        $find('mpeConfirmDelete').show();
        return false;
    }

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }        
</script>
<script>
    function pageLoad(sender, args) {

        $(document).ready(function () {
            $("#<%= txtSearchBlockName.ClientID %>").autocomplete('../Configurations/BlockAutoComplete.ashx');
            $("#<%= txtSearchFloorName.ClientID %>").autocomplete('../Configurations/FloorAutoComplete.ashx');
        });
    }
</script>
<asp:UpdatePanel ID="updBlockList" runat="server">
    <ContentTemplate>
        <style type="text/css">
            .mainbox td
            {
                vertical-align: top;
            }
        </style>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td valign="top" style="padding-left: 0px; width: 33.33%; vertical-align: top;">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                <asp:Literal ID="ltrMainHeaderBlock" runat="server"></asp:Literal>
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
                                <div class="box_form" style="min-height: 350px;">
                                    <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                        <tr>
                                            <td>
                                                <%if (IsMessageBlock)
                                                  { %>
                                                <div class="message finalsuccess">
                                                    <p>
                                                        <strong>
                                                            <asp:Literal ID="litMsgListBlock" runat="server"></asp:Literal></strong>
                                                    </p>
                                                </div>
                                                <%}%>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:MultiView ID="mvBlock" runat="server">
                                        <asp:View ID="vBlockList" runat="server">
                                            <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                <tr>
                                                    <th align="left">
                                                        <asp:Literal runat="server" ID="litSearchBlockName"></asp:Literal>
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="txtSearchBlockName" runat="server"></asp:TextBox>
                                                        <asp:ImageButton ID="btnSearchBlock" CssClass="small_img" Style="border: 0px; vertical-align: middle;
                                                            margin: -4px 0 0 5px;" runat="server" ImageUrl="~/images/search-icon.png" OnClick="btnSearchBlock_Click"
                                                            OnClientClick="fnDisplayCatchErrorMessage();" />
                                                        <asp:ImageButton ID="imgbtnClearSearchBlock" runat="server" ImageUrl="~/images/clearsearch.png"
                                                            Style="border: 0px; vertical-align: middle; margin: -2px 0 0 10px;" OnClick="imgbtnClearSearchBlock_Click"
                                                            OnClientClick="fnDisplayCatchErrorMessage();" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="right" valign="middle">
                                                        <asp:Button ID="btnAddTopBlock" runat="server" OnClick="btnAddBlock_Click" Style="float: right;" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <div class="box_head">
                                                            <span>
                                                                <asp:Literal ID="litBlockList" runat="server"></asp:Literal></span></div>
                                                        <div class="clear">
                                                        </div>
                                                        <div class="box_content">
                                                            <asp:GridView ID="gvBlocks" runat="server" AutoGenerateColumns="False" Width="100%"
                                                                OnPageIndexChanging="gvBlocks_OnPageIndexChanging" CssClass="grid_content" OnRowDataBound="gvBlocks_RowDataBound"
                                                                OnRowCommand="gvBlocks_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHrdNo" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHrdWingNo" runat="server"></asp:Label>
                                                                        </HeaderTemplate>   
                                                                        <ItemTemplate>
                                                                            <%# Container.DataItemIndex + 1 %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrWingCode" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "WingCode")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrWingName" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "WingName")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrFloors" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "FloorCount")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrUnits" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "UnitCount")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrAction" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "WingID")%>'
                                                                                CommandName="EDITDATA" OnClientClick="fnDisplayCatchErrorMessage();"><img src="../../images/file.png" /></asp:LinkButton>
                                                                            <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "WingID")%>'
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
                                                    <td colspan="2" align="right" valign="middle">
                                                        <asp:Button ID="btnAddBlocks" runat="server" OnClick="btnAddBlock_Click" Style="float: right;" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                        <asp:View ID="vAddEditBlock" runat="server">
                                            <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                <tr>
                                                    <td colspan="2">
                                                        <div style="float: right; padding-bottom: 5px;">
                                                            <b>
                                                                <asp:Literal ID="litGeneralMandartoryFiledMessageForBlock" runat="server"></asp:Literal>
                                                            </b>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="isrequire">
                                                        <asp:Literal ID="ltrBlockName" runat="server"></asp:Literal>
                                                    </td>
                                                    <td style="width: 250px;">
                                                        <asp:TextBox ID="txtBlockName" runat="server" MaxLength="17"></asp:TextBox>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rfvBlockName" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                runat="server" ValidationGroup="IsRequireBlock" ControlToValidate="txtBlockName"></asp:RequiredFieldValidator></span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="isrequire">
                                                        <asp:Literal ID="ltrBlockCode" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtBlockCode" runat="server" MaxLength="3"></asp:TextBox>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rfvBlockCode" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                runat="server" ValidationGroup="IsRequireBlock" ControlToValidate="txtBlockCode"></asp:RequiredFieldValidator></span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <div style="float: right; width: auto; display: inline-block;">
                                                            <asp:Button ID="btnBlockCancel" Style="float: right; margin-left: 5px;" runat="server"
                                                                ImageUrl="~/images/cancle.png" CausesValidation="false" OnClick="btnBlockCancel_OnClick"
                                                                OnClientClick="fnDisplayCatchErrorMessage();" />
                                                            <asp:Button ID="btnBlockSave" Style="float: right; margin-left: 5px;" runat="server"
                                                                ImageUrl="~/images/save.png" ValidationGroup="IsRequireBlock" CausesValidation="true"
                                                                OnClick="btnBlockSave_OnClick" OnClientClick="fnDisplayCatchErrorMessage();" />
                                                            <asp:Button ID="btnBackToBlockList" Style="float: right; margin-left: 5px;" runat="server"
                                                                ImageUrl="~/images/save.png" CausesValidation="false"
                                                                OnClick="btnBackToBlockList_OnClick" OnClientClick="fnDisplayCatchErrorMessage();" />
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
                <td valign="top" style="padding-left: 10px; width: 33.33%">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                <asp:Literal ID="ltrMainHeaderFloor" runat="server"></asp:Literal>
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
                                <div class="box_form" style="min-height: 350px;">
                                    <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                        <tr>
                                            <td>
                                                <%if (IsMessageFloor)
                                                  { %>
                                                <div class="message finalsuccess">
                                                    <p>
                                                        <strong>
                                                            <asp:Literal ID="litMsgListFloor" runat="server"></asp:Literal></strong>
                                                    </p>
                                                </div>
                                                <%}%>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:MultiView ID="mvFloor" runat="server">
                                        <asp:View ID="vFloorList" runat="server">
                                            <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                <tr>
                                                    <th align="left">
                                                        <asp:Literal ID="litSearchFloorName" runat="server"></asp:Literal>
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="txtSearchFloorName" runat="server"></asp:TextBox>
                                                        <asp:ImageButton ID="btnSearchFloor" CssClass="small_img" Style="border: 0px; vertical-align: middle;
                                                            margin: -4px 0 0 5px;" runat="server" ImageUrl="~/images/search-icon.png" OnClick="btnSearchFloor_Click"
                                                            OnClientClick="fnDisplayCatchErrorMessage();" />
                                                        <asp:ImageButton ID="imgbtnClearSearchFloor" runat="server" ImageUrl="~/images/clearsearch.png"
                                                            Style="border: 0px; vertical-align: middle; margin: -2px 0 0 10px;" OnClick="imgbtnClearSearchFloor_Click"
                                                            OnClientClick="fnDisplayCatchErrorMessage();" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="right" valign="middle">
                                                        <asp:Button ID="btnAddTopFloor" runat="server" OnClick="btnAddFloor_Click" Style="float: right;" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <div class="box_head">
                                                            <span>
                                                                <asp:Literal ID="litFloorList" runat="server"></asp:Literal></span></div>
                                                        <div class="clear">
                                                        </div>
                                                        <div class="box_content">
                                                            <asp:GridView ID="gvFloors" runat="server" AutoGenerateColumns="False" Width="100%"
                                                                OnPageIndexChanging="gvFloors_OnPageIndexChanging" CssClass="grid_content" OnRowDataBound="gvFloors_RowDataBound"
                                                                OnRowCommand="gvFloors_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHrdFloorNo" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%# Container.DataItemIndex + 1 %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrFloorName" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "FloorName")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrAction" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkEditFloor" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "FloorID")%>'
                                                                                CommandName="EDITDATA" OnClientClick="fnDisplayCatchErrorMessage();"><img src="../../images/file.png" /></asp:LinkButton>
                                                                            <asp:LinkButton ID="lnkDeleteFloor" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "FloorID")%>'
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
                                                    <td colspan="2" align="right" valign="middle">
                                                        <asp:Button ID="BtnAddFloor" runat="server" OnClick="btnAddFloor_Click" Style="float: right;" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                        <asp:View ID="vAddEditFloor" runat="server">
                                            <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                <tr>
                                                    <td colspan="2">
                                                        <div style="float: right; padding-bottom: 5px;">
                                                            <b>
                                                                <asp:Literal ID="litGeneralMandartoryFiledMessageForFloor" runat="server"></asp:Literal>
                                                            </b>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="isrequire">
                                                        <asp:Literal ID="ltrFloor" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtFloor" runat="server" MaxLength="3"></asp:TextBox>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rfvFloor" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                runat="server" ValidationGroup="IsRequireFloor" ControlToValidate="txtFloor"></asp:RequiredFieldValidator></span>
                                                    </td>
                                                </tr>
                                                <tr id="trBlockList" runat="server" visible="false">
                                                    <th align="left" valign="top">
                                                        <asp:Literal ID="ltrFloorBlock" runat="server"></asp:Literal>
                                                    </th>
                                                    <td class="checkbox_new">
                                                        <div style="min-height: 25px; overflow: auto; height: 150px;">
                                                            <asp:CheckBoxList ID="chkLstBlocks" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"
                                                                Width="100%">
                                                            </asp:CheckBoxList>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <div style="float: right; width: auto; display: inline-block;">
                                                            <asp:Button ID="btnCancelFloor" Style="float: right; margin-left: 5px;" runat="server"
                                                                ImageUrl="~/images/cancle.png" CausesValidation="false" OnClick="btnCancelFloor_OnClick"
                                                                OnClientClick="fnDisplayCatchErrorMessage();" />
                                                            <asp:Button ID="btnSaveFloor" Style="float: right; margin-left: 5px;" runat="server"
                                                                ImageUrl="~/images/save.png" ValidationGroup="IsRequireFloor" CausesValidation="true"
                                                                OnClick="btnSaveFloor_OnClick" OnClientClick="fnDisplayCatchErrorMessage();" />
                                                            <asp:Button ID="btnBackToFloorList" Style="float: right; margin-left: 5px;" runat="server"
                                                                ImageUrl="~/images/cancle.png" CausesValidation="false" OnClick="btnBackToFloorList_OnClick"
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
                </td>
            </tr>
        </table>
        <ajx:ModalPopupExtender ID="mpeConfirmDelete" runat="server" TargetControlID="hdnConfirmDelete"
            PopupControlID="pnlDeleteData" BackgroundCssClass="mod_background" CancelControlID="btnNo"
            BehaviorID="mpeConfirmDelete">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnConfirmDelete" runat="server" />
        <asp:HiddenField ID="hdnProcessType" runat="server" />
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
    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updBlockList" ID="UpdateProgressBlockList"
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
