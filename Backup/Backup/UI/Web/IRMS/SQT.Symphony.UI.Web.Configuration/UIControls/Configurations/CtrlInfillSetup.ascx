<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlInfillSetup.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.Configurations.CtrlInfillSetup" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">
    function fnConfirmDelete(id) {
        document.getElementById('errormessage').style.display = "block";
        document.getElementById('<%= hdnInFillData.ClientID %>').value = id;
        $find('DeleteInFillData').show();
        return false;
    }

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }     
</script>
<asp:UpdatePanel ID="updProjectTerm" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td align="left" valign="top">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                <asp:Literal ID="ltrMainHeading" runat="server"></asp:Literal>
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
                                    <!-- Main Form Design-->
                                    <table cellpadding="2" cellspacing="2" width="100%">
                                        <tr>
                                            <td colspan="3">
                                                <%if (ListMessage)
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
                                            <th align="left">
                                                <asp:Literal ID="ltrName" runat="server"></asp:Literal>
                                            </th>
                                            <td>
                                                <asp:DropDownList ID="ddlLabel" runat="server">
                                                </asp:DropDownList>
                                                <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png" OnClientClick="fnDisplayCatchErrorMessage();"
                                                    Style="border: 0px; vertical-align: middle; margin: -1px 0 0 5px;" OnClick="btnSearch_Click" />
                                                <asp:ImageButton ID="imgbtnClearSearch" runat="server" ImageUrl="~/images/clearsearch.png"
                                                    Style="border: 0px; vertical-align: middle; margin: -2px 0 0 10px;" OnClick="imgbtnClearSearch_Click" />
                                            </td>
                                            <td align="left">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <hr>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" align="right" valign="middle">
                                                <asp:Button ID="btnAddTopInFill" runat="server" Style="float: right;" OnClientClick="fnDisplayCatchErrorMessage();" OnClick="btnAddTopInFill_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <div class="box_head">
                                                    <span>
                                                        <asp:Literal ID="ltrStatutoryList" runat="server" Text="Infill List"></asp:Literal></span></div>
                                                <div class="clear">
                                                </div>
                                                <div class="box_content">
                                                    <asp:GridView ID="gvInfillList" runat="server" AutoGenerateColumns="false" Width="100%"
                                                        ShowHeader="true" SkinID="gvMorePaging" OnRowCommand="gvInfillList_RowCommand"
                                                        OnRowDataBound="gvInfillList_RowDataBound" OnPageIndexChanging="gvInfillList_PageIndexChanging">
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
                                                                    <asp:Literal ID="ltrGvrLabelName" runat="server"></asp:Literal>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblTermName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "DisplayTerm")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Literal ID="ltrGvrInfillName" runat="server"></asp:Literal>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblLabelName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Category")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="50px">
                                                                <HeaderTemplate>
                                                                    <asp:Literal ID="litGvfViewDelete" runat="server"></asp:Literal>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "TermID")%>'
                                                                        CommandName="EDITDATA" OnClientClick="fnDisplayCatchErrorMessage();"><img src="../../images/file.png" /></asp:LinkButton>
                                                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "TermID")%>'
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
                                            <td colspan="3" align="right" valign="middle">
                                                <asp:Button ID="btnAddBottomInFill" runat="server" Style="float: right;" OnClientClick="fnDisplayCatchErrorMessage();" OnClick="btnAddTopInFill_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                    <!-- End Form Design-->
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
                </td>
            </tr>
        </table>
        <!-- Add/Edit Popup Box-->
        <ajx:ModalPopupExtender ID="InfillData" runat="server" TargetControlID="hfMessage"
            PopupControlID="Panel1" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hfMessage" runat="server" />
        <asp:Panel ID="Panel1" runat="server" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="ltrInfillHeading" runat="server"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td colspan="2">
                                <%if (Message)
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
                            <td colspan="2">
                                <div style="float: right; padding-bottom:5px;">
                                    <b>
                                    <asp:Literal ID="litGeneralMandartoryFiledMessage" runat="server"></asp:Literal>
                                    </b>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire" style="width: 25%;" align="left" valign="top">
                                <asp:Literal ID="ltrLabelName" runat="server"></asp:Literal>
                            </td>
                            <td align="left" valign="top" style="width: 75%;">
                                <asp:DropDownList ID="ddlLabelName" runat="server">
                                </asp:DropDownList>
                                <span>
                                    <asp:RequiredFieldValidator ID="rvfLabelName" runat="server" ControlToValidate="ddlLabelName"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire"
                                        InitialValue="00000000-0000-0000-0000-000000000000"></asp:RequiredFieldValidator>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire">
                                <asp:Literal ID="ltrInfillName" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtInfill" runat="server" MaxLength="137"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rvfInfillName" runat="server" ControlToValidate="txtInfill"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire"></asp:RequiredFieldValidator>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire">
                                <asp:Literal ID="ltrInfillCode" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtInfillCode" runat="server" MaxLength="7"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rvfInfillCode" runat="server" ControlToValidate="txtInfillCode"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire"></asp:RequiredFieldValidator>
                                </span>
                            </td>
                        </tr>
                        <tr style="display: none;">
                            <th>
                                <asp:Literal ID="ltrFontColor" runat="server"></asp:Literal>
                            </th>
                            <td>
                                <asp:TextBox ID="txtForeColor" runat="server" Text="FFFFFF" Enabled="false" MaxLength="180"></asp:TextBox>
                                <ajx:ColorPickerExtender ID="txtForeColor_ColorPickerExtender" runat="server" Enabled="True"
                                    TargetControlID="txtForeColor" PopupButtonID="imgColor">
                                </ajx:ColorPickerExtender>
                                <asp:Image ID="imgColor" CssClass="small_img" runat="server" ImageUrl="~/images/colorfill.png"
                                    Height="20px" Width="20px" />
                            </td>
                        </tr>
                        <tr style="display: none;">
                            <th>
                                <asp:Literal ID="ltrBackgroundColor" runat="server"></asp:Literal>
                            </th>
                            <td>
                                <asp:TextBox ID="txtBackColor" runat="server" Text="FFFFFF" Enabled="false" MaxLength="180"></asp:TextBox>
                                <ajx:ColorPickerExtender ID="clrBackColor" runat="server" Enabled="True" TargetControlID="txtBackColor"
                                    PopupButtonID="imgBackCOlor">
                                </ajx:ColorPickerExtender>
                                <asp:Image ID="imgBackCOlor" CssClass="small_img" runat="server" ImageUrl="~/images/colorfill.png"
                                    Height="20px" Width="20px" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <hr>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Button ID="btnSaveAndExit" runat="server" CausesValidation="true" ValidationGroup="IsRequire"
                                    Style="display: inline; padding-right: 5px;" OnClick="btnSaveAndExit_Click" OnClientClick="fnDisplayCatchErrorMessage();" />
                                <asp:Button ID="btnSave" runat="server" CausesValidation="true" ValidationGroup="IsRequire"
                                    Style="display: inline; padding-right: 5px;" OnClick="btnSave_Click" OnClientClick="fnDisplayCatchErrorMessage();" />
                                <asp:Button ID="btnCancel" runat="server" CausesValidation="false" Style="display: inline;
                                    padding-right: 5px;" OnClick="btnCancel_Click" OnClientClick="fnDisplayCatchErrorMessage();" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <!-- End Add/Edit Popup Box-->
        <!-- Delete Popup Box-->
        <ajx:ModalPopupExtender ID="DeleteInFillData" runat="server" TargetControlID="hdnInFillData"
            PopupControlID="pnlInFillData" BackgroundCssClass="mod_background" CancelControlID="btnNo"
            BehaviorID="DeleteInFillData">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnInFillData" runat="server" />
        <asp:Panel ID="pnlInFillData" runat="server" Height="350px" Width="325px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="litInFillDataHeader" runat="server"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td align="center" style="padding-bottom: 15px;">
                                <asp:Literal ID="litInFillDataMsg" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnYes" runat="server" Style="display: inline; padding-right: 10px;"
                                    OnClientClick="fnDisplayCatchErrorMessage();" UseSubmitBehavior="false"
                                    OnClick="btnYes_Click" />
                                <asp:Button ID="btnNo" runat="server" Style="display: inline;" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <!-- End Delete Popup Box-->
    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updProjectTerm" ID="UpdateProgressProjectTerm"
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
