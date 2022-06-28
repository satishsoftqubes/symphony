<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCurrencySetup.ascx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.Configurations.CtrlCurrencySetup" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<asp:UpdatePanel ID="updCurrency" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="content" >
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
                                                <asp:Literal ID="ltrSrcName" runat="server"></asp:Literal>
                                            </th>
                                            <td>
                                                 <asp:TextBox ID="txtSrcCurrencyName" runat="server" MaxLength="35"></asp:TextBox>
                                            </td>
                                            <th >
                                                <asp:Literal ID="ltrSrcCode" runat="server"></asp:Literal>
                                            </th>
                                            <td>
                                                 <asp:TextBox ID="txtSrcCurrencyCode" runat="server" MaxLength="5"></asp:TextBox>
                                                  <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                    Style="border: 0px; vertical-align: middle; margin: -1px 0 0 5px;"
                                                    onclick="btnSearch_Click" />
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
                                                <asp:Button ID="btnAddTopCurrency" runat="server" Style="float: right;" OnClick="btnAddTopCurrency_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <div class="box_head">
                                                    <span>
                                                        <asp:Literal ID="ltrCurrencyList" runat="server"></asp:Literal></span></div>
                                                <div class="clear">
                                                </div>
                                                <div class="box_content">
                                                    <asp:GridView ID="gvCurrencyList" runat="server" AutoGenerateColumns="false" 
                                                        Width="100%" ShowHeader="true" onrowcommand="gvCurrencyList_RowCommand" 
                                                        onrowdatabound="gvCurrencyList_RowDataBound">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="No." ItemStyle-Width="25px">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Literal ID="ltrGvHdrCurrencyName" runat="server"></asp:Literal>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblgvCurrencyName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Name")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField  HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Literal ID="ltrGvHdrCurrencyCode" runat="server"></asp:Literal>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblgvCurrencyCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CurrencyCode")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Literal ID="ltrGvHdrRate" runat="server"></asp:Literal>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Rate")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="50px" >
                                                                <HeaderTemplate>
                                                                    <asp:Literal ID="lblGvHdrEditView" runat="server"></asp:Literal>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "CurrencyID")%>' CommandName="EDITDATA"><img src="../../images/file.png" /></asp:LinkButton>
                                                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "CurrencyID")%>' CommandName="DELETEDATA"><img src="../../images/delete.png" /></asp:LinkButton>
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
                                                <asp:Button ID="btnAddBottomCurrency" runat="server" Style="float: right;" OnClick="btnAddTopCurrency_Click"/>
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
        <ajx:ModalPopupExtender ID="mpeAddEditCurrency" runat="server" TargetControlID="hfCurrencyDate" PopupControlID="pnlCurrencyDate"
            BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hfCurrencyDate" runat="server" />
        <asp:Panel ID="pnlCurrencyDate" runat="server">
           <div class="box_col1">
                <div class="box_head">
                    <span><asp:Literal ID="ltrCurrencyHeading" runat="server"></asp:Literal></span></div>
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
                                <asp:Literal ID="ltrCurrency" runat="server"></asp:Literal>
                             </td>
                            <td>
                                <asp:TextBox ID="txtCurrency" runat="server" MaxLength="5"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rvfCurrency" runat="server" ControlToValidate="txtCurrency"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg"  ValidationGroup="IsRequire"></asp:RequiredFieldValidator></span>
                           
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire" style="width: 30%;" align="left" valign="top">
                                <asp:Literal ID="ltrCode" runat="server"></asp:Literal>
                             </td>
                            <td align="left" valign="top" style="width: 75%;">
                                 <asp:TextBox ID="txtCode" runat="server" MaxLength="35"></asp:TextBox>
                                   <span>
                                    <asp:RequiredFieldValidator ID="rvfCode" runat="server" ControlToValidate="txtCode"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire"></asp:RequiredFieldValidator>
                                </span>
                             </td>
                        </tr>
                         <tr>
                            <td class="isrequire">
                                <asp:Literal ID="litRate" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtRate" runat="server" MaxLength="24"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rvfRate" runat="server" ControlToValidate="txtRate"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg"  ValidationGroup="IsRequire"></asp:RequiredFieldValidator>
                                    
                                </span>
                                <ajx:FilteredTextBoxExtender ID="fltRate" TargetControlID="txtRate" runat="server" FilterMode="ValidChars" ValidChars="0123456789."></ajx:FilteredTextBoxExtender>
                            </td>
                        </tr>
                       <tr>
                        <th>&nbsp;
                        </th>
                        <td>    
                            <asp:RegularExpressionValidator Display="Dynamic" ID="regExpRate" runat="server"
                                ForeColor="Red" ControlToValidate="txtRate" SetFocusOnError="true" ValidationGroup="IsRequire">
                            </asp:RegularExpressionValidator>
                        </td>
                       </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <div>
                                    <asp:Button ID="btnSaveAndExit" runat="server" CausesValidation="true" ValidationGroup="IsRequire" onclick="btnSaveAndExit_Click" style="display:inline;"/>
                                    <asp:Button ID="btnSave" runat="server" CausesValidation="true" ValidationGroup="IsRequire" onclick="btnSave_Click" style="display:inline;"/>
                                    <asp:Button ID="btnCancel" runat="server" CausesValidation="false" style="display:inline;"/>
                                </div>
                            </td>
                        </tr>
                    </table>
               
               
                </div>
                <div class="clear">
                </div>
            </div>



        </asp:Panel>


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
                                <asp:Button ID="btnYes" runat="server" 
                                    OnClientClick="this.disabled = true; this.value = 'Processing...';" UseSubmitBehavior="false" Style="display: inline; padding-right: 10px;" onclick="btnYes_Click" />
                                <asp:Button ID="btnCancelDelete" runat="server" Style="display: inline;" 
                                    onclick="btnCancelDelete_Click"  />
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
<asp:UpdateProgress AssociatedUpdatePanelID="updCurrency" ID="UpdateProgressDepartment"
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