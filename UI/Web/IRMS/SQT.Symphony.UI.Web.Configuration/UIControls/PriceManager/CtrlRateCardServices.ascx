<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlRateCardServices.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.PriceManager.CtrlRateCardServices" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">
    function fnConfirmDelete(id) {
        document.getElementById('<%= hdnConfirmDelete.ClientID %>').value = id;
        $find('mpeConfirmDelete').show();
        return false;
    }

    function fnDisplayServiceCatchErrorMessage() {
        document.getElementById('serviceerrormessage').style.display = "block";
    }
</script>
<asp:UpdatePanel ID="uPnlRateCardServices" runat="server">
    <ContentTemplate>
        <div style="padding-bottom: 5px;">
            <h1>
                <asp:Literal ID="litHeaderServices" runat="server"></asp:Literal>
            </h1>
            <div style="float: right; margin-top: -23px;">
                <asp:Button ID="btnAddNewService" Style="float: right; margin-left: 5px;" runat="server" OnClientClick="fnDisplayServiceCatchErrorMessage();"
                    OnClick="btnAddNewService_OnClick" />
            </div>
            <hr />
        </div>
        <div style="height: 130px; overflow: auto; padding-top: 0px;">
            <div class="clear">
            </div>
            <div class="box_content">
                <asp:GridView ID="gvServices" runat="server" AutoGenerateColumns="false" Width="100%"
                    ShowHeader="true" SkinID="gvNoPaging" DataKeyNames="RateServiceID" OnRowCommand="gvServices_RowCommand"
                    OnRowDataBound="gvServices_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                            <HeaderTemplate>
                                <asp:Literal ID="litGvHdrServiceName" runat="server"></asp:Literal>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblServiceName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ItemName")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                            <HeaderTemplate>
                                <asp:Literal ID="litGvHdrPostingFrequency" runat="server"></asp:Literal>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblPostingFrequency" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "PostingFrequencyName")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                            <HeaderTemplate>
                                <asp:Literal ID="litGvHdrRate" runat="server"></asp:Literal>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblRate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ServiceRate")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="50px">
                            <HeaderTemplate>
                                <asp:Literal ID="litGvHdrActions" runat="server"></asp:Literal>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%# Container.DataItemIndex %>'
                                    CommandName="EDITDATA" OnClientClick="fnDisplayServiceCatchErrorMessage();"><img src="../../images/file.png" /></asp:LinkButton>
                                <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%# Container.DataItemIndex %>'
                                    CommandName="DELETEDATA">
                                    <img src="../../images/delete.png" /></asp:LinkButton>
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
        <div class="clear">
            <%--<uc1:MsgBox ID="MessageBox" runat="server" />--%>
        </div>
        <ajx:ModalPopupExtender ID="mpeAddEditService" runat="server" TargetControlID="hdnAddEditService"
            PopupControlID="pnlAddEditService" BackgroundCssClass="mod_background" CancelControlID="btnCancelAddEdit">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnAddEditService" runat="server" />
        <asp:Panel ID="pnlAddEditService" runat="server" Height="200px" Width="450px" style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="ltrHeaderAddEditService" runat="server"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td class="isrequire" width="120px">
                                <asp:Literal ID="ltrService" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlServices" runat="server" OnSelectedIndexChanged="ddlServices_OnSelectedIndexChanged"
                                    AutoPostBack="true">
                                </asp:DropDownList>
                                <span>
                                    <asp:RequiredFieldValidator ID="rfvServices" runat="server" ControlToValidate="ddlServices"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" InitialValue="00000000-0000-0000-0000-000000000000"
                                        ValidationGroup="IsRequireServices"></asp:RequiredFieldValidator>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire">
                                <asp:Literal ID="lblRate" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtRate" runat="server" SkinID="nowidth" Style="text-align: right;"
                                    Width="120px" MaxLength="18"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rfvRate" runat="server" ControlToValidate="txtRate"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequireServices"></asp:RequiredFieldValidator>
                                </span>
                                <div>
                                    <asp:RegularExpressionValidator Display="Dynamic" ID="regExpServiceRate" runat="server"
                                        ForeColor="Red" ControlToValidate="txtRate" SetFocusOnError="true" ValidationGroup="IsRequireServices">
                                    </asp:RegularExpressionValidator>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire">
                                <asp:Literal ID="ltrPostingFrequency" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlPostingFrequency" runat="server">
                                </asp:DropDownList>
                                <span>
                                    <asp:RequiredFieldValidator ID="rfvPostingFrequency" runat="server" ControlToValidate="ddlPostingFrequency"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" InitialValue="00000000-0000-0000-0000-000000000000"
                                        ValidationGroup="IsRequireServices"></asp:RequiredFieldValidator>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td class="checkbox_new">
                                <asp:CheckBox ID="chkIsChargePerPerson" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Button ID="btnAddService" Style="display: inline-block;" runat="server" ValidationGroup="IsRequireServices" OnClientClick="fnDisplayServiceCatchErrorMessage();"
                                    OnClick="btnAddService_OnClick" />
                                <asp:Button ID="btnCancelAddEdit" runat="server" Style="display: inline-block;" Text="Cancel" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpeConfirmDelete" runat="server" TargetControlID="hdnConfirmDelete"
            PopupControlID="pnlDeleteData" BackgroundCssClass="mod_background" CancelControlID="btnCancelDelete" BehaviorID="mpeConfirmDelete">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnConfirmDelete" runat="server" />
        <asp:Panel ID="pnlDeleteData" runat="server" Height="350px" Width="325px" style="display: none;">
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
                                    OnClientClick="fnDisplayServiceCatchErrorMessage();" UseSubmitBehavior="false"
                                    OnClick="btnYes_Click" />
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
<div id="serviceerrormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="uPnlRateCardServices" ID="uprgRateCardServices"
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
