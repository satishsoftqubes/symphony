<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlSMS.ascx.cs" 
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.Configurations.CtrlSMS" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<asp:UpdatePanel ID="updSMSTemplate" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td align="left" valign="top">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" >
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
                                                <h1>
                                                    <asp:Literal ID="ltrSearchArea" runat="server"></asp:Literal>
                                                </h1>
                                                <hr>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                <asp:Literal ID="ltrSearchTitle" runat="server"></asp:Literal>
                                            </th>
                                            <td style="width: 260px">
                                                 <asp:TextBox ID="txtsearchTitle" runat="server"></asp:TextBox>
                                            </td>
                                           
                                            <td align="left">
                                                <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                    Style="border: 0px; vertical-align: middle; margin: 2px 0 0 5px" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <h1>
                                                    <asp:Literal ID="ltrTitleList" runat="server"></asp:Literal>
                                                </h1>
                                                <hr>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="right" valign="middle">
                                                <asp:Button ID="btnAddTopSMS" runat="server" Style="float: right;" 
                                                    onclick="btnAddTopSMS_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <div class="box_head">
                                                    <span>
                                                        <asp:Literal ID="ltrSMSList" runat="server"></asp:Literal></span></div>
                                                <div class="clear">
                                                </div>
                                                <div class="box_content">
                                                    <asp:GridView ID="gvSMSList" runat="server" AutoGenerateColumns="false" Width="100%"
                                                        ShowHeader="true" OnRowCommand="gvSMSList_RowCommand" 
                                                        onrowdatabound="gvSMSList_RowDataBound"  >
                                                        <Columns>
                                                         <asp:TemplateField ItemStyle-Width="30%" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Literal ID="ltrGvHdrTitle" runat="server"></asp:Literal>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvTitle" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "TitleList")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField >
                                                            <HeaderTemplate>
                                                                <asp:Literal ID="ltrGvHdrDetails" runat="server"></asp:Literal>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvDetails" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Details")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                            <asp:TemplateField ItemStyle-Width="6%" >
                                                                <HeaderTemplate>
                                                                    <asp:Literal ID="ltrGvHdrEditView" runat="server"></asp:Literal>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkEdit" runat="server" Text="test" CommandArgument="123" CommandName="EDITDATA"><img src="../../images/file.png" /></asp:LinkButton>
                                                                    <asp:LinkButton ID="lnkDelete" runat="server" Text="test" CommandArgument="123" CommandName="DELETEDATA"><img src="../../images/delete.png" /></asp:LinkButton>
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
                                                <asp:Button ID="btnAddBottomSMS" runat="server" Style="float: right;" 
                                                    onclick="btnAddTopSMS_Click"  />
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
        <ajx:ModalPopupExtender ID="SMSData" runat="server" TargetControlID="hfMessage" PopupControlID="pnl"
            BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hfMessage" runat="server" />
        <asp:Panel ID="pnl" runat="server">
          
                <div class="box_col1">
                <div class="box_head">
                    <span> <asp:Literal ID="ltrSMSHeading" runat="server"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                       <table width="100%" cellpadding="2" cellspacing="2">
                                        <tr>
                                            <th style="width: 20%;" align="left" valign="top">
                                                <asp:Literal ID="ltrTitle" runat="server"></asp:Literal>
                                           </th>
                                            <td style="width: 70%;">
                                                <asp:TextBox ID="txtTitle" runat="server" SkinID="Long" style="width:170px;" MaxLength="20"></asp:TextBox>
                                                  <span>
                                                    <asp:RequiredFieldValidator ID="rvfTitle" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                        runat="server" ControlToValidate="txtTitle" ValidationGroup="IsRequire"></asp:RequiredFieldValidator>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="vertical-align:top;">
                                                <asp:Literal ID="ltrDetail"  runat="server" ></asp:Literal>
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtDetails" runat="server" TextMode="MultiLine" SkinID="Long" Height="100px"
                                                    MaxLength="160"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoIsOnUnitBooking" GroupName="SMSGroup" runat="server" /><br />
                                                <asp:RadioButton ID="rdoIsOnInvestorCreation" GroupName="SMSGroup" runat="server" /><br />
                                                <asp:RadioButton ID="rdoIsOnUnitPaymentReceived" GroupName="SMSGroup" runat="server" /><br />
                                                <asp:RadioButton ID="rdoIsOnUnitTaxReceived" GroupName="SMSGroup"  runat="server" /><br />
                                                <asp:RadioButton ID="rdoIsOnUnitInsuranceReceived" GroupName="SMSGroup" runat="server" /><br />
                                            </td>
                                        </tr>
                                      <tr>
                            <td align="center" colspan="2">
                                <table cellpadding="3" cellspacing="3" width="100%" style="margin-left: 5px; margin-top: 15px;">
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnSaveAndExit" runat="server" CausesValidation="true" ValidationGroup="IsRequire"/>
                                        </td>
                                        <td align="right" valign="middle">
                                            <asp:Button ID="btnSave" runat="server" CausesValidation="true" ValidationGroup="IsRequire"/>
                                        </td>
                                        <td align="left" valign="middle">
                                            <asp:Button ID="btnCancel" runat="server" CausesValidation="false"/>
                                        </td>
                                    </tr>
                                </table>
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
                                <asp:Button ID="btnYes" runat="server" OnClientClick="this.disabled = true; this.value = 'Processing...';" UseSubmitBehavior="false" Style="display: inline; padding-right: 10px;" />
                                 <asp:Button ID="btnCancelDelete" runat="server" Style="display: inline;"  />
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
<asp:UpdateProgress AssociatedUpdatePanelID="updSMSTemplate" ID="UpdateProgressSMSTemplate"
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
