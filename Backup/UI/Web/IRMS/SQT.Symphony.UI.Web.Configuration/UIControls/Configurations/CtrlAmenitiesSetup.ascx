<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlAmenitiesSetup.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.Configurations.CtrlAmenitiesSetup" %>
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
</script>
<script>
    function pageLoad(sender, args) {
        
        $(document).ready(function () {
            $("#<%= txtSearchAmeniteisName.ClientID %>").autocomplete('../Configurations/AmenitiesAutoComplete.ashx');
        });
    }
</script>
<asp:UpdatePanel ID="updAmenitiesList" runat="server">
    <ContentTemplate>
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
                                    <asp:MultiView ID="mvAmenities" runat="server">
                                        <asp:View ID="vAmenitiesList" runat="server">
                                            <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                <tr>
                                                    <th align="left">
                                                        <asp:Literal ID="ltrSearchAmeniteisName" runat="server"></asp:Literal>
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="txtSearchAmeniteisName" runat="server"></asp:TextBox>
                                                        <asp:ImageButton ID="btnSearchAmenities" CssClass="small_img" Style="border: 0px;
                                                            vertical-align: middle; margin: -4px 0 0 5px;" runat="server" ImageUrl="~/images/search-icon.png"
                                                            OnClick="btnSearch_Click" OnClientClick="fnDisplayCatchErrorMessage();" />
                                                        <asp:ImageButton ID="imgbtnClearSearch" runat="server" ImageUrl="~/images/clearsearch.png"
                                                            Style="border: 0px; vertical-align: middle; margin: -2px 0 0 10px;" OnClick="imgbtnClearSearch_Click"
                                                            OnClientClick="fnDisplayCatchErrorMessage();" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="right" valign="middle">
                                                        <asp:Button ID="btnAddTopAmenities" runat="server" OnClick="btnAddTopAmenities_Click"
                                                            OnClientClick="fnDisplayCatchErrorMessage();" Style="float: right;" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <div class="box_head">
                                                            <span>
                                                                <asp:Literal ID="ltrAmenitiesList" runat="server"></asp:Literal>
                                                            </span>
                                                        </div>
                                                        <div class="clear">
                                                        </div>
                                                        <div class="box_content">
                                                            <asp:GridView ID="gvAmenities" runat="server" AutoGenerateColumns="False" Width="100%"
                                                                OnPageIndexChanging="gvAmenities_OnPageIndexChanging" CssClass="grid_content"
                                                                OnRowDataBound="gvAmenities_RowDataBound" OnRowCommand="gvAmenities_RowCommand"
                                                                ShowHeader="true">
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
                                                                            <asp:Label ID="lblGvHdrAmenitiesCode" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvAmenitiesCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "AmenitiesCode")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrAmenitiesName" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvAmenitiesName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "AmenitiesName")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrAmenitiesFor" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblAmenitiesFor" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "AmenitiesFor")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrAction" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "AmenitiesID")%>'
                                                                                CommandName="EDITDATA" OnClientClick="fnDisplayCatchErrorMessage();"><img src="../../images/file.png" /></asp:LinkButton>
                                                                            <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "AmenitiesID")%>'
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
                                                        <asp:Button ID="btnAddBottomAmenities" runat="server" OnClick="btnAddTopAmenities_Click"
                                                            OnClientClick="fnDisplayCatchErrorMessage();" Style="float: right;" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                        <asp:View ID="vAddEditAmenities" runat="server">
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
                                                        <asp:Literal ID="ltrAmenitiesName" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtAmenitiesName" runat="server" MaxLength="150"></asp:TextBox>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rfvAmanitiesName" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                runat="server" ValidationGroup="IsRequire" ControlToValidate="txtAmenitiesName"></asp:RequiredFieldValidator></span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="isrequire">
                                                        <asp:Literal ID="ltrAmenitiesCode" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtAmenitiesCode" runat="server" MaxLength="7"></asp:TextBox>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rfvAmanitiesCode" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                runat="server" ValidationGroup="IsRequire" ControlToValidate="txtAmenitiesCode"></asp:RequiredFieldValidator></span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="isrequire">
                                                        <asp:Literal ID="ltrAmenitiesFor" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlAmenitiesFor" runat="server">
                                                        </asp:DropDownList>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rvfPropertyName" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                runat="server" InitialValue="00000000-0000-0000-0000-000000000000" ValidationGroup="IsRequire"
                                                                ControlToValidate="ddlAmenitiesFor"></asp:RequiredFieldValidator></span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th valign="top">
                                                        <asp:Literal ID="ltrDescription" runat="server"></asp:Literal>
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="txtDescription" SkinID="BigInput" TextMode="MultiLine" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <div style="float: right; width: auto; display: inline-block;">
                                                            <asp:Button ID="btnCancel" Style="float: right; margin-left: 5px;" runat="server"
                                                                ImageUrl="~/images/cancle.png" CausesValidation="false" OnClick="btnCancel_OnClick"
                                                                OnClientClick="fnDisplayCatchErrorMessage();" />
                                                            <asp:Button ID="btnSave" Style="float: right; margin-left: 5px;" runat="server" ImageUrl="~/images/save.png"
                                                                ValidationGroup="IsRequire" CausesValidation="true" OnClick="btnSave_OnClick"
                                                                OnClientClick="fnDisplayCatchErrorMessage();" />
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
