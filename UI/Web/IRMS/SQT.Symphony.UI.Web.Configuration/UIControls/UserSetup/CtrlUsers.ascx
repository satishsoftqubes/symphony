<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlUsers.ascx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.UserSetup.CtrlUsers" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript">

    function fnConfirmDelete(id) {

        document.getElementById('errormessage').style.display = "block";
        document.getElementById('<%= hdnConfirmDelete.ClientID %>').value = id;
        $find('mpeConfirmDelete').show();
        return false;
    }

    function fnCheckDuplicateUser() {
        document.getElementById('lblshow').style.display = 'none';
        document.getElementById('<%= hfIsDuplicateUser.ClientID %>').value = '0'
        if (document.getElementById('<%= txtUserName.ClientID %>').value != '')
            PageMethods.GetUser(document.getElementById('<%= txtUserName.ClientID %>').value, document.getElementById('<%= hfUserIDToCheckDuplicate.ClientID %>').value, OnSucceeded);
    }

    function OnSucceeded(result, userContext, methodName) {
        if (result == "1") {
            document.getElementById('<%= hfIsDuplicateUser.ClientID %>').value = '1';
            document.getElementById('lblshow').style.display = 'block';
        }
    }

    function fnCustVlDuplicateUser(source, args) {
        if (document.getElementById('<%= hfIsDuplicateUser.ClientID %>').value == '1') {
            document.getElementById('lblshow').style.display = 'block';
            args.IsValid = false;
        }
        else {
            args.IsValid = true;
        }
    }

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<script type="text/javascript">
    function RoleValidate() {
        if (Page_ClientValidate("IsRequire")) {

            document.getElementById('errormessage').style.display = "block";
            var isChecked = false;
            var c = document.getElementsByTagName('input');
            for (var i = 1; i < c.length; i++) {
                if (c[i].type == 'checkbox') {
                    if (c[i].checked) {
                        isChecked = true;
                        break;
                    }
                }
            }

            if (isChecked == false) {
                $find('mpeCustomePopup').show();
                return false;
            }
        }
        else {
            return false;
        }
    }
</script>
<asp:UpdatePanel ID="updUsers" runat="server">
    <ContentTemplate>
        <asp:HiddenField ID="hfUserIDToCheckDuplicate" runat="server" />
        <asp:HiddenField ID="hfIsDuplicateUser" runat="server" />
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td valign="top" style="padding-left: 0px; width: 66.66%">
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
                                    <asp:MultiView ID="mvUser" runat="server">
                                        <asp:View ID="vUsersList" runat="server">
                                            <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                <tr>
                                                    <th align="left">
                                                        <asp:Literal ID="litSearchUserName" runat="server"></asp:Literal>
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="txtSearchUserName" runat="server"></asp:TextBox>
                                                    </td>
                                                    <th align="left">
                                                        <asp:Literal ID="litSearchDepartmentName" Text="Department" runat="server"></asp:Literal>
                                                    </th>
                                                    <td>
                                                        <asp:DropDownList ID="ddlSearchDepartmentName" runat="server">
                                                        </asp:DropDownList>
                                                        <asp:ImageButton ID="btnSearchUser" Style="border: 0px; vertical-align: middle; margin: -1px 0 0 5px;"
                                                            runat="server" ImageUrl="~/images/search-icon.png" OnClick="btnSearchUser_Click"
                                                            OnClientClick="fnDisplayCatchErrorMessage();" />
                                                        <asp:ImageButton ID="imgbtnClearSearch" CssClass="small_img" runat="server" ImageUrl="~/images/clearsearch.png"
                                                            Style="border: 0px; vertical-align: middle; margin: -1px 0 0 10px;" OnClick="imgbtnClearSearch_Click"
                                                            OnClientClick="fnDisplayCatchErrorMessage();" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" align="right" valign="middle">
                                                        <asp:Button ID="btnAddTopUser" runat="server" Style="float: right;" OnClick="btnAddTopUser_Click"
                                                            OnClientClick="fnDisplayCatchErrorMessage();" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <div class="box_head">
                                                            <span>
                                                                <asp:Literal ID="litUserList" runat="server"></asp:Literal>
                                                            </span>
                                                        </div>
                                                        <div class="clear">
                                                        </div>
                                                        <div class="box_content">
                                                            <asp:GridView ID="gvUser" runat="server" AutoGenerateColumns="False" Width="100%"
                                                                CssClass="grid_content" ShowHeader="true" OnPageIndexChanging="gvUser_PageIndexChanging"
                                                                OnRowCommand="gvUser_RowCommand" OnRowDataBound="gvUser_RowDataBound" DataKeyNames="IsBlock">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHrdNo" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%# Container.DataItemIndex + 1 %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHrdUserName" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "UserName")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHrdDisplayName" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "UserDisplayName")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHrdEmplyeeName" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "FullName")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHrdDepartmentName" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "DepartmentName")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="25px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHrdBlock" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkBlock" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "UsearID")%>'
                                                                                CommandName="BLOCKDATA">
                                                                                <asp:Image ID="imgBlock" runat="server" />
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrAction" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "UsearID")%>'
                                                                                CommandName="EDITDATA" OnClientClick="fnDisplayCatchErrorMessage();"><img src="../../images/file.png" /></asp:LinkButton>
                                                                            <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "UsearID")%>'
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
                                                        <asp:Button ID="btnAddBottomUser" runat="server" Style="float: right;" OnClick="btnAddTopUser_Click"
                                                            OnClientClick="fnDisplayCatchErrorMessage();" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                        <asp:View ID="vAddEditUser" runat="server">
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
                                                    <td class="isrequire" valign="top">
                                                        <asp:Literal ID="litEmployeeName" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlEmployeeName" runat="server" OnSelectedIndexChanged="ddlEmployeeName_SelectedIndexChanged"
                                                            AutoPostBack="true">
                                                        </asp:DropDownList>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rfvEmployeeName" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                runat="server" InitialValue="00000000-0000-0000-0000-000000000000" ValidationGroup="IsRequire"
                                                                ControlToValidate="ddlEmployeeName"></asp:RequiredFieldValidator></span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="isrequire">
                                                        <asp:Literal ID="litUserName" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtUserName" runat="server" MaxLength="180" Enabled="false"></asp:TextBox>
                                                        <asp:CustomValidator ID="cstvUserName" runat="server" ControlToValidate="txtUserName"
                                                            ErrorMessage="" Display="Dynamic" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                            ValidationGroup="User" ClientValidationFunction="fnCustVlDuplicateUser"></asp:CustomValidator>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rfvUserName" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                runat="server" ValidationGroup="IsRequire" ControlToValidate="txtUserName"></asp:RequiredFieldValidator></span>
                                                        <div id="lblshow" style="font-size: 11px; padding-top: 4px; padding-left: 5px; color: Red;
                                                            display: none;">
                                                            <asp:Label ID="lblUserMessage" runat="server"></asp:Label>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="isrequire">
                                                        <asp:Literal ID="litPassword" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPassword" runat="server" MaxLength="27" TextMode="Password"></asp:TextBox>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rfvPassword" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                runat="server" ValidationGroup="IsRequire" ControlToValidate="txtPassword"></asp:RequiredFieldValidator></span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="isrequire">
                                                        <asp:Literal ID="litConfirmPassword" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtConfirmPassword" runat="server" MaxLength="27" TextMode="Password"></asp:TextBox>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rvfConfirmPassword" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                runat="server" ValidationGroup="IsRequire" ControlToValidate="txtConfirmPassword"></asp:RequiredFieldValidator></span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:CompareValidator ID="cmpValidation" runat="server" ControlToValidate="txtConfirmPassword"
                                                            ValidationGroup="IsRequire" Display="Dynamic" ControlToCompare="txtPassword"
                                                            SetFocusOnError="true" ErrorMessage="Confirm Password not same as Password."
                                                            CssClass="rfv_ErrorStar"></asp:CompareValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="isrequire" valign="top">
                                                        <asp:Literal ID="litDisplayName" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtDisplayName" MaxLength="67" runat="server"></asp:TextBox>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rfvDisplayName" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                runat="server" ValidationGroup="IsRequire" ControlToValidate="txtDisplayName"></asp:RequiredFieldValidator></span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="isrequire" style="vertical-align: top;">
                                                        <asp:Literal ID="litRole" runat="server"></asp:Literal>
                                                    </td>
                                                    <td class="checkbox_new">
                                                        <div style="height: 150px; overflow: auto;">
                                                            <asp:CheckBoxList ID="chklstRole" runat="server" RepeatColumns="4" RepeatDirection="Horizontal">
                                                            </asp:CheckBoxList>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="isrequire" style="vertical-align: top;">
                                                        <asp:Literal ID="litIsFunctionalRole" runat="server"></asp:Literal>
                                                    </td>
                                                    <td class="checkbox_new">
                                                        <div style="height: 150px; overflow: auto;">
                                                            <asp:CheckBoxList ID="chkIsFunctionalRole" runat="server" RepeatColumns="4" RepeatDirection="Horizontal">
                                                            </asp:CheckBoxList>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <div style="float: right; width: auto; display: inline-block;">
                                                            <asp:Button ID="btnCancel" Style="float: right; margin-left: 5px;" runat="server"
                                                                ImageUrl="~/images/cancle.png" CausesValidation="false" OnClick="btnCancel_Click"
                                                                OnClientClick="fnDisplayCatchErrorMessage();" />
                                                            <asp:Button ID="btnSave" Style="float: right; margin-left: 5px;" runat="server" ImageUrl="~/images/save.png"
                                                                ValidationGroup="IsRequire" CausesValidation="true" OnClick="btnSave_Click" OnClientClick="return RoleValidate();" />
                                                            <asp:Button ID="btnBackToList" Style="float: right; margin-left: 5px;" runat="server"
                                                                ImageUrl="~/images/cancle.png" CausesValidation="false" OnClick="btnBackToList_Click"
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
                                <asp:Button ID="btnNo" runat="server" Style="display: inline;" />
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
<asp:UpdateProgress AssociatedUpdatePanelID="updUsers" ID="UpdateProgressUsers" runat="server">
    <ProgressTemplate>
        <div id="progressBackgroundFilter">
        </div>
        <div id="processMessage">
            <center>
                <img src="../../images/ajax-loader.gif" /></center>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
