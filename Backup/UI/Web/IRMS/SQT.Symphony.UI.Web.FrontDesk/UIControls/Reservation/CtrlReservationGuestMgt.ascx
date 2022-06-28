<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlReservationGuestMgt.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation.CtrlReservationGuestMgt" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<ajx:ModalPopupExtender ID="mpeAddGuestName" runat="server" TargetControlID="hdnGuestName"
    PopupControlID="pnlAddGuestName" BackgroundCssClass="mod_background">
</ajx:ModalPopupExtender>
<asp:HiddenField ID="hdnGuestName" runat="server" />
<asp:Panel ID="pnlAddGuestName" runat="server" Width="750px" Style="display: none;">
    <asp:MultiView ID="mvGuest" runat="server">
        <asp:View ID="vGuest" runat="server">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="Literal1" runat="server" Text="Reservation Guest Management(Reservation No.:- 100141 - Mr. Prakash Patel)"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" border="0" width="100%">
                        <%--<tr>
                            <td style="vertical-align: top;">
                                <table cellpadding="2" cellspacing="2" width="100%">
                                    <tr style="background-color: #F3F3F5;">
                                        <td width="30%" style="vertical-align: top; border: 1px solid #ccccce !important;">
                                            <table cellpadding="2" cellspacing="2" width="100%">
                                                <tr>
                                                    <th width="60px">
                                                        <asp:Literal ID="litGuestMgtReservationNo" runat="server" Text="Reservation No."></asp:Literal>
                                                    </th>
                                                    <td>
                                                        <asp:Literal ID="litGuestMgtDisplayReservationNo" runat="server" Text="100141"></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>
                                                        <asp:Literal ID="litGuestMgtUnitNo" runat="server" Text="Unit No."></asp:Literal>
                                                    </th>
                                                    <td>
                                                        <asp:Literal ID="litGuestMgtDisplayUnitNo" runat="server" Text="100133"></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>
                                                        <asp:Literal ID="litGuestMgtUnitType" runat="server" Text="Unit Type"></asp:Literal>
                                                    </th>
                                                    <td>
                                                        <asp:Literal ID="litGuestMgtDisplayUnitType" runat="server" Text="Double"></asp:Literal>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="30%" style="vertical-align: top; border: 1px solid #ccccce !important;">
                                            <table cellpadding="2" cellspacing="2" width="100%">
                                                <tr>
                                                    <th>
                                                        <asp:Literal ID="litGuestMgtArrivalDate" runat="server" Text="Arrival"></asp:Literal>
                                                    </th>
                                                    <td>
                                                        <asp:Literal ID="litGuestMgtDisplayArrivalDate" runat="server" Text="04/May/2012"></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>
                                                        <asp:Literal ID="litGuestMgtDepatureDate" runat="server" Text="Depature"></asp:Literal>
                                                    </th>
                                                    <td>
                                                        <asp:Literal ID="litGuestMgtDisplayDepatureDate" runat="server" Text="05/May/2012"></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>
                                                        <asp:Literal ID="litGuestMgtAdult" runat="server" Text="Adult"></asp:Literal>
                                                    </th>
                                                    <td>
                                                        <asp:Literal ID="litGuestMgtDisplayAdult" runat="server" Text="2"></asp:Literal>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="40%" style="vertical-align: top; border: 1px solid #ccccce !important;">
                                            <table cellpadding="2" cellspacing="2" width="100%">
                                                <tr>
                                                    <th>
                                                        <asp:Literal ID="litGuestMgtName" runat="server" Text="Name"></asp:Literal>
                                                    </th>
                                                    <td>
                                                        <asp:Literal ID="litGuestMgtDisplayName" runat="server" Text="Mr. Prakash Patel"></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="litGuestMgtRateCard" runat="server" Text="Rate Card"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="litGuestMgtDisplayRateCard" runat="server" Text="Conf. Rate Card">
                                                        </asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>
                                                        <asp:Literal ID="litGuestMgtChild" runat="server" Text="Child"></asp:Literal>
                                                    </th>
                                                    <td>
                                                        <div style="float: left; width: 50px;">
                                                            <asp:Literal ID="litGuestMgtDisplayChild" runat="server" Text="0"></asp:Literal>
                                                        </div>
                                                        <div style="float: left; width: 50px;">
                                                            <asp:Literal ID="litGuestMgtINF" runat="server" Text="INF"></asp:Literal>
                                                        </div>
                                                        <div style="float: left;">
                                                            <asp:Literal ID="litGuestMgtDisplayINF" runat="server" Text="0"></asp:Literal>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>--%>
                        <tr>
                            <td style="vertical-align: top;">
                                <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                    <tr>
                                        <td colspan="2">
                                            <asp:RadioButtonList ID="rbtSelectGuestType" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">
                                                <asp:ListItem Selected="True" Value="Adult" Text="Adult"></asp:ListItem>
                                                <asp:ListItem Value="Child" Text="Child"></asp:ListItem>
                                                <asp:ListItem Value="INF" Text="INF"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="litInputGuestMgtName" runat="server" Text="Name"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlGuestMgtTitle" runat="server" Style="width: 60px; height: 25px;">
                                                <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                <asp:ListItem Text="Mr." Value="Mr."></asp:ListItem>
                                                <asp:ListItem Text="Mrs." Value="Mrs."></asp:ListItem>
                                                <asp:ListItem Text="Ms" Value="Ms"></asp:ListItem>
                                            </asp:DropDownList>
                                            &nbsp;&nbsp; <span>
                                                <asp:RequiredFieldValidator ID="rfvGuestMgtTitle" InitialValue="00000000-0000-0000-0000-000000000000"
                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                    ValidationGroup="IsRequireGuestMgt" ControlToValidate="ddlGuestMgtTitle" Display="Dynamic">
                                                </asp:RequiredFieldValidator>
                                            </span>&nbsp;&nbsp;
                                            <asp:TextBox ID="txtGuestMgtFirstName" runat="server" MaxLength="150" Style="width: 150px !important;"></asp:TextBox>
                                            <ajx:TextBoxWatermarkExtender ID="txtwmeFirstName" runat="server" TargetControlID="txtGuestMgtFirstName"
                                                WatermarkText="First Name">
                                            </ajx:TextBoxWatermarkExtender>
                                            &nbsp;&nbsp; <span>
                                                <asp:RequiredFieldValidator ID="rfvGuestMgtFirstName" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                    runat="server" ValidationGroup="IsRequireGuestMgt" ControlToValidate="txtGuestMgtFirstName"
                                                    Display="Dynamic">
                                                </asp:RequiredFieldValidator>
                                            </span>&nbsp;&nbsp;
                                            <asp:TextBox ID="txtGuestMgtLastName" runat="server" MaxLength="150" Style="width: 150px !important;"></asp:TextBox>
                                            <ajx:TextBoxWatermarkExtender ID="txtwmeLastName" runat="server" TargetControlID="txtGuestMgtLastName"
                                                WatermarkText="Last Name">
                                            </ajx:TextBoxWatermarkExtender>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Button ID="btnGuestMgtAddGuest" runat="server" Text="Add Guest" Style="display: inline;
                                    padding-right: 10px;" ValidationGroup="IsRequireGuestMgt" />
                                <asp:Button ID="btnGuestMgtClear" runat="server" Text="Clear" Style="display: inline;
                                    padding-right: 10px;" />
                                <asp:Button ID="btnGuestMgtQuickPost" runat="server" Text="Quick Post" OnClick="btnGuestMgtQuickPost_Click"
                                    Style="display: inline; padding-right: 10px;" />
                                <asp:Button ID="btnGuestMgtCancel" runat="server" Text="Cancel" Style="display: inline;
                                    padding-right: 10px;" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 200px; overflow: auto; vertical-align: top;">
                                <div class="box_head">
                                    <span>
                                        <asp:Literal ID="litGuestMgtGuestList" runat="server" Text="Guest List"></asp:Literal>
                                    </span>
                                </div>
                                <div class="clear">
                                </div>
                                <div class="box_content">
                                    <asp:GridView ID="gvGuestMgtGuestList" runat="server" AutoGenerateColumns="false"
                                        ShowHeader="true" Width="100%">
                                        <Columns>
                                            <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrAutoAssignUnitSrNo" runat="server" Text="No."></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrGuestMgtGuestName" runat="server" Text="Guest Name"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "GuestName")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrGuestMgtArrival" runat="server" Text="Arrival"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "Arrival")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrGuestMgtDepature" runat="server" Text="Depature"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "Depature")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrGuestMgtNotes" runat="server" Text="Notes"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "Notes")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <div style="padding: 10px;">
                                                <b>
                                                    <asp:Label ID="lblGuestMgtNoRecordFound" runat="server" Text="No Record Found."></asp:Label>
                                                </b>
                                            </div>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 200px; overflow: auto; vertical-align: top;">
                                <div class="box_head">
                                    <span>
                                        <asp:Literal ID="litReservationList" runat="server" Text="Reservation List"></asp:Literal>
                                    </span>
                                </div>
                                <div class="clear">
                                </div>
                                <div class="box_content">
                                    <asp:GridView ID="gvGuestMgtReservation" runat="server" AutoGenerateColumns="false"
                                        ShowHeader="true" Width="100%">
                                        <Columns>
                                            <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkSelectGuestMgtReservation" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrGuestMgtSrNo" runat="server" Text="No."></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrGuestMgtReservationDate" runat="server" Text="Date"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "Date")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrGuestMgtReservationRate" runat="server" Text="Rate"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "Rate")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrGuestMgtReservationRoomRate" runat="server" Text="Unit Rate"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "RoomRate")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrGuestMgtReservationServices" runat="server" Text="Services"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "Services")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrGuestMgtReservationTotal" runat="server" Text="Total"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "Total")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <div style="padding: 10px;">
                                                <b>
                                                    <asp:Label ID="lblNoRecordFoundForGuestMgtReservation" runat="server" Text="No Record Found."></asp:Label>
                                                </b>
                                            </div>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; background-color: #DCDDDF; color: #0083CE; font-size: 15px;
                                font-weight: bold; padding: 9px;">
                                <asp:Literal ID="litGuestMgtReservationTotalAmount" runat="server" Text="0.00"></asp:Literal>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:View>
        <asp:View ID="vQuickPost" runat="server">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="litQuickPostHeader" runat="server" Text="Quick Post"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td>
                                <fieldset style="border: 1px solid #ccc !important; padding: 5px;">
                                    <div style="float: left; width: 75px;">
                                        <asp:Literal ID="litQuickPostFolioNo" runat="server" Text="Folio No."></asp:Literal>
                                    </div>
                                    <div style="float: left; width: 150px;">
                                        <asp:Literal ID="litDisplayQuickPostFolioNo" runat="server" Text="100141"></asp:Literal>
                                    </div>
                                    <div style="float: left; width: 75px;">
                                        <asp:Literal ID="litQuickPostUnitNo" runat="server" Text="Room No."></asp:Literal>
                                    </div>
                                    <div style="float: left;">
                                        <asp:Literal ID="litDisplayQuickPostUnitNo" runat="server" Text="100141"></asp:Literal>
                                    </div>
                                    <br />
                                    <div style="float: left; width: 75px;">
                                        <asp:Literal ID="litQuickPostName" runat="server" Text="Name"></asp:Literal>
                                    </div>
                                    <div style="float: left;">
                                        <asp:Literal ID="litDisplayQuickPostName" runat="server" Text="Mr. Prakash Patel"></asp:Literal>
                                    </div>
                                    <div style="float: right;">
                                        <asp:Literal ID="litQuickPostCreditLimit" runat="server" Text="Cr. Limit"></asp:Literal>&nbsp;&nbsp;&nbsp;
                                        <asp:Literal ID="litDisplayQuickPostCreditLimit" runat="server" Text="100.00"></asp:Literal>
                                    </div>
                                </fieldset>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <fieldset style="border: 1px solid #ccc !important;">
                                    <legend>
                                        <asp:Literal ID="litQuickPostPostCharges" runat="server" Text="Post Charges A/C. Info"></asp:Literal>
                                    </legend>
                                    <table cellpadding="2" cellspacing="2" width="100%">
                                        <tr>
                                            <td>
                                                <asp:Literal ID="litQuickPostPMT" runat="server" Text="Payment Mode"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal ID="litDisplayQuickPostPMT" runat="server" Text="BACS"></asp:Literal>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                <asp:RadioButtonList ID="rbtQuickPostAccount" runat="server" RepeatDirection="Horizontal"
                                                    RepeatColumns="2" AutoPostBack="true" OnSelectedIndexChanged="rbtQuickPostAccount_SelectedIndexChanged">
                                                    <asp:ListItem Selected="True" Value="Account" Text="Account"></asp:ListItem>
                                                    <asp:ListItem Value="Item" Text="Item"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="isrequire">
                                                <asp:Literal ID="litQuickPostAccount" runat="server" Text="Account/Item"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlQuickPostCharge" runat="server" Style="width: 200px !important;">
                                                    <asp:ListItem Selected="True" Value="00000000-0000-0000-0000-000000000000" Text="-Select-"></asp:ListItem>
                                                    <asp:ListItem Value="Conference Revenue" Text="Conference Revenue"></asp:ListItem>
                                                    <asp:ListItem Value="Room Revenue" Text="Room Revenue"></asp:ListItem>
                                                </asp:DropDownList>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rvfTitle" InitialValue="00000000-0000-0000-0000-000000000000"
                                                        SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                        ValidationGroup="AddQuickPost" ControlToValidate="ddlQuickPostCharge" Display="Dynamic">
                                                    </asp:RequiredFieldValidator>
                                                </span>
                                            </td>
                                            <td class="isrequire">
                                                <asp:Literal ID="litQuickPostAmount" runat="server" Text="Amount"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtQuickPostAmount" runat="server" Style="width: 200px !important;"></asp:TextBox>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rvfFirstName" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                        runat="server" ValidationGroup="AddQuickPost" ControlToValidate="txtQuickPostAmount"
                                                        Display="Dynamic">
                                                    </asp:RequiredFieldValidator>
                                                </span>
                                                <ajx:FilteredTextBoxExtender ID="ftQuickPostAmount" runat="server" TargetControlID="txtQuickPostQty"
                                                    FilterType="Custom, Numbers" ValidChars="." />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: top;">
                                                <asp:Literal ID="litQuickPostQty" runat="server" Text="Qty"></asp:Literal>
                                            </td>
                                            <td class="NumericDropdown" style="vertical-align: top;">
                                                <div style="float: left; width: 140px;">
                                                    <asp:TextBox ID="txtQuickPostQty" runat="server"></asp:TextBox>
                                                    <ajx:NumericUpDownExtender ID="QuickPostQtyNUDE" runat="server" TargetControlID="txtQuickPostQty"
                                                        Width="60" Minimum="1" Maximum="999" />
                                                    <ajx:FilteredTextBoxExtender ID="ftQuickPostQty" runat="server" TargetControlID="txtQuickPostQty"
                                                        FilterType="Numbers" />
                                                    <div style="float: right; display: inline-block; vertical-align: top; line-height: 25px;
                                                        padding-right: 7px;">
                                                        <asp:Literal ID="litQuickPostPayment" runat="server" Text="Payment"></asp:Literal>
                                                    </div>
                                                </div>
                                                <div style="float: left;">
                                                    <asp:DropDownList ID="ddlQuickPostPayment" runat="server" Style="width: 87px;">
                                                        <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                        <asp:ListItem Text="Cash" Value="Cash"></asp:ListItem>
                                                        <asp:ListItem Text="Card" Value="Card"></asp:ListItem>
                                                        <asp:ListItem Text="Cheque" Value="Cheque"></asp:ListItem>
                                                        <asp:ListItem Text="BACS" Value="BACS"></asp:ListItem>
                                                        <asp:ListItem Text="CAPS" Value="CAPS"></asp:ListItem>
                                                        <asp:ListItem Text="Direct Bill" Value="Direct Bill"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                            <td style="vertical-align: top;">
                                                <asp:Literal ID="litQuickPostVoucherNo" runat="server" Text="VOU/DOC NO."></asp:Literal>
                                            </td>
                                            <td style="vertical-align: top;">
                                                <asp:TextBox ID="txtQuickPostVoucherNo" runat="server" Style="width: 200px !important;"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: top;">
                                                <asp:Literal ID="litQuickPostNotes" runat="server" Text="Notes"></asp:Literal>
                                            </td>
                                            <td colspan="3">
                                                <div style="float: left; padding-right: 15px;">
                                                    <asp:TextBox ID="txtQuickPostNotes" Style="width: 510px !important;" TextMode="MultiLine"
                                                        runat="server"></asp:TextBox>
                                                </div>
                                                <div style="float: left;">
                                                    <asp:Button ID="btnQuickPostAdd" runat="server" Text="Add" />
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </fieldset>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 150px; overflow: auto;">
                                <div class="box_head">
                                    <span>
                                        <asp:Literal ID="litGroupReservationList" runat="server" Text="Quick Post List"></asp:Literal>
                                    </span>
                                </div>
                                <div class="clear">
                                </div>
                                <div class="box_content">
                                    <asp:GridView ID="gvQuickPostList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                        Width="100%" SkinID="gvNoPaging">
                                        <Columns>
                                            <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrQuickPostSrNo" runat="server" Text="No."></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrQuickPostItem" runat="server" Text="Account/Item"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "Item")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrQuickPostQty" runat="server" Text="Qty"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "Qty")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrQuickPostAmount" runat="server" Text="Amount"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "Amount")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrQuickPostAction" runat="server" Text="Action"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkQuickPostEdit" runat="server" ToolTip="Edit" CommandName="EDITDATA"><img src="../../images/file.png" /></asp:LinkButton>
                                                    <asp:LinkButton ID="lnkQuickPostDelete" runat="server" ToolTip="Cancel" CommandName="CANCELDATA"><img src="../../images/delete.png" /></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <div style="padding: 10px;">
                                                <b>
                                                    <asp:Label ID="lblQuickPostNoRecordFound" runat="server" Text="No Record Found."></asp:Label>
                                                </b>
                                            </div>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #DCDDDF; color: #0083CE; font-size: 15px; font-weight: bold;
                                padding: 9px; width: 100%;">
                                <asp:Label Style="float: right;" ID="lblDisplayQuickPostAmount" runat="server" Text="1005.00"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnQuickPostSave" runat="server" Style="display: inline; padding-right: 10px;"
                                    ValidationGroup="AddQuickPost" Text="Save" />
                                <%--<asp:Button ID="btnQuickPostCurrency" runat="server" Style="display: inline;" Text="Foreign Currency" />--%>
                                <asp:Button ID="btnQuickPostCardInfo" runat="server" Style="display: inline;" Text="Card Info."
                                    OnClick="btnQuickPostCardInfo_Click" />
                                <asp:Button ID="btnQuickPostCancel" runat="server" Style="display: inline;" Text="Cancel"
                                    OnClick="btnQuickPostCancel_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:View>
        <asp:View ID="vCardInof" runat="server">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="litCardInfo" runat="server" Text="Card Info"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td colspan="4" style="font-weight: bold; font-size: 13px; border: 1px solid grey;">
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
                                        ValidationGroup="AddCardDetails" ControlToValidate="ddlCardType" Display="Dynamic">
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
                                        Display="Dynamic">
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
                                        Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                </span>
                            </td>
                            <td>
                                <asp:Literal ID="litIssueDate" runat="server" Text="Issue Date"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtIssueDate" runat="server" Style="width: 198px;"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire">
                                <asp:Literal ID="litExpiryDate" runat="server" Text="Expiry Date"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtExpiryDate" runat="server" Style="width: 198px;"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rfvExpiryDate" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                        runat="server" ValidationGroup="AddCardDetails" ControlToValidate="txtExpiryDate"
                                        Display="Dynamic">
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
                                        Display="Dynamic">
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
                            <td colspan="4" width="100%" style="height: 150px; overflow: auto; vertical-align: top;">
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
                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
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
                                            <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrAction" runat="server" Text="Actions"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkEdit" runat="server" ToolTip="Edit" CommandName="EDITDATA"><img src="../../images/file.png" /></asp:LinkButton>
                                                    <asp:LinkButton ID="lnkDelete" runat="server" ToolTip="Delete" CommandName="DELETEDATA"><img src="../../images/delete.png" /></asp:LinkButton>
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
        </asp:View>
    </asp:MultiView>
</asp:Panel>
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
