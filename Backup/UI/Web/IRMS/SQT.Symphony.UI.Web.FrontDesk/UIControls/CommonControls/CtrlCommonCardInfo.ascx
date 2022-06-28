<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCommonCardInfo.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls.CtrlCommonCardInfo" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<ajx:ModalPopupExtender ID="mpeAddCardDetails" runat="server" TargetControlID="hdnCardDetails"
    PopupControlID="pnlCardDetails" BackgroundCssClass="mod_background" CancelControlID="btnCancelCardDetails">
</ajx:ModalPopupExtender>
<asp:HiddenField ID="hdnCardDetails" runat="server" />
<asp:Panel ID="pnlCardDetails" runat="server" Width="855px">
    <%--<asp:Panel ID="pnlCardDetails" runat="server" Width="790px" Style="display: none; height: 550px !important;">--%>
    <div class="box_col1">
        <div class="box_head">
            <span>
                <asp:Literal ID="litCardInfo" runat="server" Text="Card Info"></asp:Literal></span></div>
        <div class="clear">
        </div>
        <div class="box_form">
            <table cellpadding="2" cellspacing="2" width="100%">
                <tr>
                    <td colspan="4" style="font-weight: bold; font-size: 13px; border: 1px solid #ccccce;">
                        <asp:Literal ID="litDisplayCardHolderName" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="isrequire" style="width: 120px !important;">
                        <asp:Literal ID="litCardType" runat="server" Text="Type"></asp:Literal>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCardType" runat="server" Style="width: 200px;">
                            <asp:ListItem Selected="True" Text="-SELECT-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                            <asp:ListItem Text="American Express" Value="American Express"></asp:ListItem>
                            <asp:ListItem Text="Mastero" Value="Mastero"></asp:ListItem>
                            <asp:ListItem Text="Mastercard" Value="Mastercard"></asp:ListItem>
                            <asp:ListItem Text="Solo" Value="Solo"></asp:ListItem>
                            <asp:ListItem Text="Visa" Value="Visa"></asp:ListItem>
                        </asp:DropDownList>
                        <span>
                            <asp:RequiredFieldValidator ID="rfvCardType" InitialValue="00000000-0000-0000-0000-000000000000"
                                SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                ValidationGroup="AddCardDetails" ControlToValidate="ddlCardType" Display="Static">
                            </asp:RequiredFieldValidator>
                        </span>
                    </td>
                    <td class="isrequire">
                        <asp:Literal ID="litCardNo" runat="server" Text="Card No."></asp:Literal>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCardNo" runat="server" Style="width: 198px;"></asp:TextBox>
                        <span>
                            <asp:RequiredFieldValidator ID="rfvCardNo" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                runat="server" ValidationGroup="AddCardDetails" ControlToValidate="txtCardNo"
                                Display="Static">
                            </asp:RequiredFieldValidator>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td class="isrequire">
                        <asp:Literal ID="litCardHolderName" runat="server" Text="Card Holder's Name"></asp:Literal>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCardHolderName" runat="server" Style="width: 198px;"></asp:TextBox>
                        <span>
                            <asp:RequiredFieldValidator ID="rfvCardHolderName" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                runat="server" ValidationGroup="AddCardDetails" ControlToValidate="txtCardHolderName"
                                Display="Static">
                            </asp:RequiredFieldValidator>
                        </span>
                    </td>
                    <td>
                        <asp:Literal ID="litIssueDate" runat="server" Text="Issue Date"></asp:Literal>
                    </td>
                    <td>
                        <asp:TextBox ID="txtIssueDate" runat="server" Style="width: 198px;" onkeypress="return false;"></asp:TextBox>
                        <asp:Image ID="imgIssueDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                            Height="20px" Width="20px" />
                        <ajx:CalendarExtender ID="calExtIssueDate" PopupButtonID="imgIssueDate" TargetControlID="txtIssueDate"
                            runat="server" Format="dd/MMM/yyyy">
                        </ajx:CalendarExtender>
                        <img src="../../images/clear.png" id="imgClrIssueDate" style="vertical-align: middle;"
                            title="Clear Date" onclick="fnClearDate('<%= txtIssueDate.ClientID %>');" />
                    </td>
                </tr>
                <tr>
                    <td class="isrequire">
                        <asp:Literal ID="litExpiryDate" runat="server" Text="Expiry Date"></asp:Literal>
                    </td>
                    <td>
                        <asp:TextBox ID="txtExpiryDate" runat="server" Style="width: 198px;" onkeypress="return false;"></asp:TextBox>
                        <asp:Image ID="imgExpiryDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                            Height="20px" Width="20px" />
                        <ajx:CalendarExtender ID="calExtExpiryDate" PopupButtonID="imgExpiryDate" TargetControlID="txtExpiryDate"
                            runat="server" Format="dd/MMM/yyyy">
                        </ajx:CalendarExtender>
                        <img src="../../images/clear.png" id="imgClearExpiryDate" style="vertical-align: middle;"
                            title="Clear Date" onclick="fnClearDate('<%= txtExpiryDate.ClientID %>');" />
                        <span>
                            <asp:RequiredFieldValidator ID="rfvExpiryDate" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                runat="server" ValidationGroup="AddCardDetails" ControlToValidate="txtExpiryDate"
                                Display="Static">
                            </asp:RequiredFieldValidator>
                        </span>
                    </td>
                    <td>
                        <asp:Literal ID="litIssueNo" runat="server" Text="Issue No."></asp:Literal>
                    </td>
                    <td>
                        <asp:TextBox ID="txtIssueNo" runat="server" Style="width: 198px;"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Literal ID="litSecurityCode" runat="server" Text="Security Code(CVC)"></asp:Literal>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSecurityCode" runat="server" Style="width: 198px;"></asp:TextBox>
                        <%--<span>
                            <asp:RequiredFieldValidator ID="rfvSecurityCode" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                runat="server" ValidationGroup="AddCardDetails" ControlToValidate="txtSecurityCode"
                                Display="Static">
                            </asp:RequiredFieldValidator>
                        </span>--%>
                    </td>
                    <%-- <td>
                        <asp:Literal ID="litAuthorizationCode" runat="server" Text="Authorization Code"></asp:Literal>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAuthorizationCode" runat="server" Style="width: 198px;"></asp:TextBox>
                    </td>--%>
                    <td>
                        <asp:Literal ID="litAuthorizedAmount" runat="server" Text="Authorized Amount"></asp:Literal>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAuthorizedAmount" runat="server" Style="width: 198px;"></asp:TextBox>
                    </td>
                </tr>
                <%--<tr>
                    <td>
                        <asp:Literal ID="litAuthorizedAmount" runat="server" Text="Authorized Amount"></asp:Literal>
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtAuthorizedAmount" runat="server" Style="width: 198px;"></asp:TextBox>
                    </td>
                </tr>--%>
                <tr>
                    <td colspan="4">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="4">
                        <asp:Button ID="btnSaveCardDetails" runat="server" Style="display: inline; padding-right: 10px;"
                            OnClientClick="fnDisplayCatchErrorMessage();" ValidationGroup="AddCardDetails"
                            Text="Save" />
                        <asp:Button ID="btnSaveAndExitCardDetails" runat="server" Style="display: inline;"
                            Text="Save And Close" ValidationGroup="AddCardDetails" />
                        <asp:Button ID="btnCancelCardDetails" runat="server" Style="display: inline;" Text="Cancel " />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" width="100%" style="height: 250px; overflow: auto; vertical-align: top;">
                        <div class="box_head">
                            <span>
                                <asp:Literal ID="litCardList" runat="server" Text="Card List"></asp:Literal>
                            </span>
                        </div>
                        <div class="clear">
                        </div>
                        <div class="box_content">
                            <asp:GridView ID="gvCardList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                Width="100%">
                                <Columns>
                                    <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblGvHdrType" runat="server" Text="Type"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "Type")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="125px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblGvHdrCardNo" runat="server" Text="Card No."></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "CardNo")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblGvHdrName" runat="server" Text="Name"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "Name")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblGvHdrServices" runat="server" Text="Expiry Date"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "ExpiryDate")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblGvHdrUnitTaxes" runat="server" Text="Security Code"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "SecurityCode")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblActions" runat="server" Text="Action"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblPopUp" runat="server" Text="Action"></asp:Label>
                                            <ajx:HoverMenuExtender ID="HoverMenuExtender2" runat="server" TargetControlID="lblPopUp"
                                                PopupControlID="Panel2" PopupPosition="Left">
                                            </ajx:HoverMenuExtender>
                                            <asp:Panel ID="Panel2" runat="server" Style="visibility: hidden; opacity: 100%">
                                                <div class="actionsbuttons_hovermenu">
                                                    <table border="0" cellpadding="0" cellspacing="0" class="actionsbuttons_hover_lettmenu_table">
                                                        <tr>
                                                            <td class="actionsbuttons_hover_lettmenu">
                                                            </td>
                                                            <td class="actionsbuttons_hover_centermenu">
                                                                <ul>
                                                                    <li>
                                                                        <asp:LinkButton Style="background: none !important; border: none;" ID="lnkEdit" runat="server"
                                                                            ToolTip="Edit" CommandName="EDITDATA"><img src="../../images/file.png" /></asp:LinkButton>
                                                                    </li>
                                                                    <li>
                                                                        <asp:LinkButton Style="background: none !important; border: none;" ID="lnkDelete"
                                                                            runat="server" ToolTip="Delete" CommandName="DELETEDATA"><img src="../../images/file.png" /></asp:LinkButton>
                                                                    </li>
                                                                </ul>
                                                            </td>
                                                            <td class="actionsbuttons_hover_rightmenu">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </asp:Panel>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <div style="padding: 10px;">
                                        <b>
                                            <asp:Label ID="lblNoRecordFoundForCardList" runat="server" Text="No Record Found."></asp:Label>
                                        </b>
                                    </div>
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <div class="clear">
        </div>
    </div>
</asp:Panel>
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
