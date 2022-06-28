<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCommonSubFolioConfiguration.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Folio.CtrlCommonSubFolioConfiguration" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonCardInfo.ascx" TagName="CommonCardInfo"
    TagPrefix="ucCommonCardInfo" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<asp:MultiView ID="mvSubFolio" runat="server">
    <asp:View ID="vGuestInfo" runat="server">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="content">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td align="left">
                                <table cellpadding="2" cellspacing="2" width="100%">
                                    <tr>
                                        <td style="vertical-align: top;">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="100px">
                                                        <asp:Literal ID="litSubFolioBookingNo" runat="server" Text="Booking #"></asp:Literal>
                                                    </td>
                                                    <td width="125px">
                                                        <asp:Literal ID="litDisplaySubFolioBookingNo" runat="server" Text="30417"></asp:Literal>
                                                    </td>
                                                    <td width="75px">
                                                        <asp:Literal ID="litSubFolioRoomNo" runat="server" Text="Room No."></asp:Literal>
                                                    </td>
                                                    <td width="125px">
                                                        <asp:Literal ID="litDisplaySubFolioRoomNo" runat="server" Text="101 - Standard"></asp:Literal>
                                                    </td>
                                                    <td width="75px">
                                                        <asp:Literal ID="litSubFolioName" runat="server" Text="Name"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="litDisplaySubFolioName" runat="server" Text="Mr. Bharat Patel"></asp:Literal>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <hr />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="border: 1px solid #ccccce;">
                                            <div style="float: left; padding-right: 15px;">
                                                <asp:RadioButtonList ID="rbtGuest" RepeatColumns="2" RepeatDirection="Horizontal"
                                                    runat="server">
                                                    <asp:ListItem Selected="True" Text="Guest" Value="Guest"></asp:ListItem>
                                                    <asp:ListItem Text="Corporate" Value="Corporate"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                            <div style="float: left; margin-top: 5px;">
                                                <asp:DropDownList ID="ddlSubFolioGuestName" runat="server">
                                                    <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                    <asp:ListItem Text="Mr. Aniket Patel" Value="Mr. Aniket Patel"></asp:ListItem>
                                                    <asp:ListItem Text="Mr. Prakash Patel" Value="Mr. Prakash Patel"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <fieldset style="border: 1px solid #ccc !important;">
                                                <legend><b>
                                                    <asp:Literal ID="litGuestInformation" runat="server" Text="Guest Information"></asp:Literal></b>
                                                </legend>
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td class="isrequire">
                                                            <asp:Literal ID="litName" runat="server" Text="Name"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlTitle" runat="server" Style="width: 60px; height: 25px;">
                                                                <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                                <asp:ListItem Text="Mr." Value="Mr."></asp:ListItem>
                                                                <asp:ListItem Text="Mrs." Value="Mrs."></asp:ListItem>
                                                                <asp:ListItem Text="Ms" Value="Ms"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rvfTitle" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                    ValidationGroup="IsRequireForGuestInfo" ControlToValidate="ddlTitle" Display="Dynamic">
                                                                </asp:RequiredFieldValidator>
                                                                <asp:RequiredFieldValidator ID="rfvTitleCardDetails" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                    ValidationGroup="IsRequireForCardDetails" ControlToValidate="ddlTitle" Display="Dynamic">
                                                                </asp:RequiredFieldValidator>
                                                            </span>
                                                            <asp:TextBox ID="txtFirstName" runat="server" MaxLength="150" Style="width: 100px !important;"></asp:TextBox>
                                                            <ajx:TextBoxWatermarkExtender ID="txtwmeFirstName" runat="server" TargetControlID="txtFirstName"
                                                                WatermarkText="First Name">
                                                            </ajx:TextBoxWatermarkExtender>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rvfFirstName" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                    runat="server" ValidationGroup="IsRequireForGuestInfo" ControlToValidate="txtFirstName"
                                                                    Display="Dynamic">
                                                                </asp:RequiredFieldValidator>
                                                                <asp:RequiredFieldValidator ID="rfvFirstNameForCardDetails" SetFocusOnError="true"
                                                                    CssClass="input-notification error png_bg" runat="server" ValidationGroup="IsRequireForCardDetails"
                                                                    ControlToValidate="txtFirstName" Display="Dynamic">
                                                                </asp:RequiredFieldValidator>
                                                            </span>
                                                            <asp:TextBox ID="txtLastName" runat="server" MaxLength="150" Style="width: 100px !important;"></asp:TextBox>
                                                            <ajx:TextBoxWatermarkExtender ID="txtwmeLastName" runat="server" TargetControlID="txtLastName"
                                                                WatermarkText="Last Name">
                                                            </ajx:TextBoxWatermarkExtender>
                                                            &nbsp;&nbsp;&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litContact" runat="server" Text="Contact No."></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtContactNo" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litAddress" runat="server" Text="Address"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litCityName" runat="server" Text="City"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCityName" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litStateName" runat="server" Text="State"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtStateName" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litCountryName" runat="server" Text="Country"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCountryName" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litZipCode" runat="server" Text="ZipCode"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtZipCode" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </fieldset>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 150px; overflow: auto; vertical-align: top;">
                                            <div class="box_head">
                                                <span>
                                                    <asp:Literal ID="litSubFolioList" runat="server" Text="Sub Folio List"></asp:Literal>
                                                </span>
                                            </div>
                                            <div class="clear">
                                            </div>
                                            <div class="box_content">
                                                <asp:GridView ID="gvSubFolioList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                    Width="100%" SkinID="gvNoPaging">
                                                    <Columns>
                                                        <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrSubFolioSrNo" runat="server" Text="No."></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrSubFolioFolioNo" runat="server" Text="FolioNo"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%#DataBinder.Eval(Container.DataItem, "FolioNo")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrSubFolioGuestName" runat="server" Text="Name"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%#DataBinder.Eval(Container.DataItem, "GuestName")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrSubFolioCreatedOn" runat="server" Text="Created On"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%#DataBinder.Eval(Container.DataItem, "CreatedOn")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrSubFolioBalance" runat="server" Text="Balance"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%#DataBinder.Eval(Container.DataItem, "Balance")%>
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
                                                                                            <asp:LinkButton ID="lnkSubFolioEdit" Style="background: none !important; border: none;"
                                                                                                runat="server" ToolTip="Edit" CommandName="EDITDATA"><img src="../../images/file.png" /></asp:LinkButton>
                                                                                        </li>
                                                                                        <li>
                                                                                            <asp:LinkButton ID="lnkSubFolioDelete" Style="background: none !important; border: none;"
                                                                                                runat="server" ToolTip="Delete" CommandName="CANCELDATA"><img src="../../images/delete.png" /></asp:LinkButton>
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
                                                                <asp:Label ID="lblSubFolioNoRecordFound" runat="server" Text="No Record Found."></asp:Label>
                                                            </b>
                                                        </div>
                                                    </EmptyDataTemplate>
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:Button ID="btnSubFolioSave" Style="display: inline;" runat="server" Text="Save"
                                                ValidationGroup="IsRequireForGuestInfo" />
                                            <asp:Button ID="btnSubFolioCardInfo" Style="display: inline;" runat="server" Text="Card Info."
                                                OnClick="btnSubFolioCardInfo_Click" ValidationGroup="IsRequireForCardDetails" />
                                            <asp:Button ID="btnSubFolioCancel" Style="display: inline;" runat="server" Text="Cancel"
                                                OnClick="btnSubFolioCancel_Click" />
                                        </td>
                                    </tr>
                                </table>
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
    </asp:View>
    <asp:View ID="vCardInfo" runat="server">
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
                        <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
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
                    <asp:TextBox ID="txtIssueDate" runat="server" Style="width: 155px;" onkeypress="return false;"></asp:TextBox>
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
                    <asp:TextBox ID="txtExpiryDate" runat="server" Style="width: 155px;" onkeypress="return false;"></asp:TextBox>
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
                <td class="isrequire">
                    <asp:Literal ID="litSecurityCode" runat="server" Text="Security Code(CVC)"></asp:Literal>
                </td>
                <td>
                    <asp:TextBox ID="txtSecurityCode" runat="server" Style="width: 198px;"></asp:TextBox>
                    <span>
                        <asp:RequiredFieldValidator ID="rfvSecurityCode" SetFocusOnError="true" CssClass="input-notification error png_bg"
                            runat="server" ValidationGroup="AddCardDetails" ControlToValidate="txtSecurityCode"
                            Display="Static">
                        </asp:RequiredFieldValidator>
                    </span>
                </td>
                <td>
                    <asp:Literal ID="litAuthorizationCode" runat="server" Text="Authorization Code"></asp:Literal>
                </td>
                <td>
                    <asp:TextBox ID="txtAuthorizationCode" runat="server" Style="width: 198px;"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Literal ID="litAuthorizedAmount" runat="server" Text="Authorized Amount"></asp:Literal>
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txtAuthorizedAmount" runat="server" Style="width: 198px;"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <asp:Button ID="btnSaveCardDetails" runat="server" Style="display: inline; padding-right: 10px;"
                        ValidationGroup="AddCardDetails" Text="Save" />
                    <asp:Button ID="btnSaveAndExitCardDetails" runat="server" Style="display: inline;"
                        Text="Save And Close" ValidationGroup="AddCardDetails" />
                    <asp:Button ID="btnCancelCardDetails" runat="server" Style="display: inline;" Text="Cancel"
                        OnClick="btnCancelCardDetails_Click" />
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
                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                        <asp:Label ID="lblGvHdrType" runat="server" Text="Type"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%#DataBinder.Eval(Container.DataItem, "Type")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                        <asp:Label ID="lblGvHdrCardNo" runat="server" Text="Card No."></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%#DataBinder.Eval(Container.DataItem, "CardNo")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
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
                                                                    <asp:LinkButton ID="lnkCardEdit" Style="background: none !important; border: none;"
                                                                        runat="server" ToolTip="Edit" CommandName="EDITDATA"><img src="../../images/file.png" /></asp:LinkButton>
                                                                </li>
                                                                <li>
                                                                    <asp:LinkButton ID="lnkCardDelete" runat="server" Style="background: none !important;
                                                                        border: none;" ToolTip="Delete" CommandName="DELETEDATA"><img src="../../images/delete.png" /></asp:LinkButton>
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
    </asp:View>
</asp:MultiView>
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
