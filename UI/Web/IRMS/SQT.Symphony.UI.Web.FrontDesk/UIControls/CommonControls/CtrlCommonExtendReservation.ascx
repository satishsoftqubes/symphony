<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCommonExtendReservation.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls.CtrlCommonExtendReservation" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonCardInfo.ascx" TagName="CtrlERCommonCardInfo"
    TagPrefix="ucERCommonCardInfo" %>
<script type="text/javascript">
    function fnClearDate1(para1) {
        document.getElementById(para1).value = '';
    }
</script>
<%--<ajx:ModalPopupExtender ID="mpeExtendReservation" runat="server" TargetControlID="hdnExtendReservation"
    PopupControlID="pnlExtendReservation" BackgroundCssClass="mod_background" CancelControlID="btnCancelExtendReservation">
</ajx:ModalPopupExtender>
<asp:HiddenField ID="hdnExtendReservation" runat="server" />
<asp:Panel ID="pnlExtendReservation" runat="server" Width="750px" Style="display: none;">--%>
<div class="box_col1">
    <div class="box_head">
        <span>
            <asp:Literal ID="litExtendReservation" runat="server" Text="Extend Reservation"></asp:Literal></span></div>
    <div class="clear">
    </div>
    <div class="box_form">
        <table cellpadding="2" cellspacing="2" width="100%">
            <tr>
                <td colspan="2">
                    <div style="float: left;">
                        <asp:Literal ID="litBookingNo" runat="server" Text="Booking #"></asp:Literal>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Literal ID="litDisplayBookingNo" runat="server" Text="123456"></asp:Literal>
                    </div>
                    <div style="float: right;">
                        <asp:Literal ID="litDisplayName" runat="server" Text="Mr. Prakash Patel"></asp:Literal></div>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <hr />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <fieldset style="border: 1px solid #ccc !important;">
                        <legend>
                            <asp:Literal ID="litStayInfo" runat="server" Text="Stay Info"></asp:Literal>
                        </legend>
                        <table cellpadding="2" cellspacing="2" width="100%">
                            <tr>
                                <td width="55%" style="vertical-align: top; border-right: 1px solid #DCDDDF;">
                                    <table cellpadding="2" cellspacing="2" width="100%">
                                        <tr>
                                            <td class="isrequire" style="width:90px !important;">
                                                <asp:Literal ID="litERCheckInDate" runat="server" Text="Check In"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtERCheckInDate" runat="server" Style="width: 90px !important;"
                                                    Text="09-08-2012" onkeypress="return false;"></asp:TextBox>
                                                &nbsp;&nbsp;&nbsp;
                                                <asp:DropDownList ID="ddlERFrequency" runat="server" Style="width: 75px;">
                                                    <asp:ListItem Text="-SELECT-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                    <asp:ListItem Selected="True" Text="Daily" Value="Daily"></asp:ListItem>
                                                    <asp:ListItem Text="Weekly" Value="Weekly"></asp:ListItem>
                                                    <asp:ListItem Text="Monthly" Value="Monthly"></asp:ListItem>
                                                    <asp:ListItem Text="Quartrly" Value="Quartrly"></asp:ListItem>
                                                </asp:DropDownList>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rfvERFrequency" InitialValue="00000000-0000-0000-0000-000000000000"
                                                        SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                        ValidationGroup="AddExtendReservation" ControlToValidate="ddlERFrequency" Display="Dynamic">
                                                    </asp:RequiredFieldValidator>
                                                </span>&nbsp;&nbsp;&nbsp;
                                                <asp:TextBox ID="txtERNight" runat="server" MaxLength="3" Style="width: 40px !important;"
                                                    Text="2"></asp:TextBox>
                                                <%--OnTextChanged="txtERNight_TextChanged" AutoPostBack="true"--%>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rfvERNight" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                        runat="server" ValidationGroup="AddExtendReservation" ControlToValidate="txtERNight"
                                                        Display="Dynamic">
                                                    </asp:RequiredFieldValidator>
                                                </span>
                                                <ajx:FilteredTextBoxExtender ID="ftERNight" runat="server" TargetControlID="txtERNight"
                                                    FilterType="Numbers" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width:90px !important;" class="isrequire">
                                                <asp:Literal ID="litERCheckOutDate" runat="server" Text="Check Out"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtERCheckOutDate" runat="server" Style="width: 90px !important;"
                                                    Text="05/09/2012" onkeypress="return false;"></asp:TextBox>
                                                <asp:Image ID="imgERDepatureDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                    Height="20px" Width="20px" />
                                                <ajx:CalendarExtender ID="calERDepatureDate" PopupButtonID="imgERDepatureDate" TargetControlID="txtERCheckOutDate"
                                                    runat="server" Format="dd/MMM/yyyy">
                                                </ajx:CalendarExtender>
                                                <img src="../../images/clear.png" id="imgERDD" style="vertical-align: middle;" title="Clear Date"
                                                    onclick="fnClearDate1('<%= txtERCheckOutDate.ClientID %>');" />
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rfvERDepatureDate" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                        runat="server" ValidationGroup="AddExtendReservation" ControlToValidate="txtERCheckOutDate"
                                                        Display="Dynamic">
                                                    </asp:RequiredFieldValidator>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal ID="litERAdultChild" runat="server" Text="Adult/Child"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal ID="litDisplayERAdultChild" runat="server" Text="2/0"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal ID="litERDiscount" runat="server" Text="Discount"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal ID="litDisplayERDiscount" runat="server" Text="-"></asp:Literal>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="50%" style="vertical-align: top;">
                                    <table cellpadding="2" cellspacing="2" width="100%">
                                        <tr>
                                            <td>
                                                <asp:Literal ID="litERRoomType" runat="server" Text="Room Type"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal ID="litDisplayERRoomType" runat="server" Text="Standard"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal ID="litERRoomNo" runat="server" Text="Room No."></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal ID="litDisplayERRoomNo" runat="server" Text="2"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal ID="litERRateCard" runat="server" Text="Rate Card Type"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal ID="litDisplayERRateCard" runat="server" Text="Conference"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="isrequire">
                                                <asp:Literal ID="litCardType" runat="server" Text="Type"></asp:Literal>
                                            </td>
                                            <td>
                                                <div style="float: left; padding-right: 10px;">
                                                    <asp:DropDownList ID="ddlERCardType" runat="server" Style="width: 100px !important;">
                                                        <asp:ListItem Text="-SELECT-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                        <asp:ListItem Selected="True" Text="Cash" Value="Cash"></asp:ListItem>
                                                        <asp:ListItem Text="Card" Value="Card"></asp:ListItem>
                                                        <asp:ListItem Text="Cheque" Value="Cheque"></asp:ListItem>
                                                        <asp:ListItem Text="BACS" Value="BACS"></asp:ListItem>
                                                        <asp:ListItem Text="CAPS" Value="CAPS"></asp:ListItem>
                                                        <asp:ListItem Text="Direct Bill" Value="Direct Bill"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <span>
                                                        <asp:RequiredFieldValidator ID="rfvERCardType" InitialValue="00000000-0000-0000-0000-000000000000"
                                                            SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                            ValidationGroup="AddExtendReservation" ControlToValidate="ddlERCardType" Display="Dynamic">
                                                        </asp:RequiredFieldValidator>
                                                        <asp:RequiredFieldValidator ID="rfvCardTypeForAdd" InitialValue="00000000-0000-0000-0000-000000000000"
                                                            SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                            ValidationGroup="CardPopUp" ControlToValidate="ddlERCardType" Display="Dynamic">
                                                        </asp:RequiredFieldValidator>
                                                    </span>
                                                </div>
                                                <div style="float: left;">
                                                    <asp:Button ID="btnAddCardInfo" runat="server" Text="+" OnClick="btnAddCardInfo_Click"
                                                        ValidationGroup="CardPopUp" /></div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="btnERCalculateRates" runat="server" Text="Calculate Rates" />
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 200px; overflow: auto;">
                    <div class="box_head">
                        <span>
                            <asp:Literal ID="litExtendReservationList" runat="server" Text="Extend Reservation List"></asp:Literal>
                        </span>
                    </div>
                    <div class="clear">
                    </div>
                    <div class="box_content">
                        <asp:GridView ID="gvExtendReservationList" runat="server" AutoGenerateColumns="false"
                            ShowHeader="true" SkinID="gvNoPaging" Width="100%">
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
                                        <asp:Label ID="lblGvHdrERDate" runat="server" Text="Date"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%#DataBinder.Eval(Container.DataItem, "Date")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                    <HeaderTemplate>
                                        <asp:Label ID="lblGvHdrERRate" runat="server" Text="Rate"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%#DataBinder.Eval(Container.DataItem, "Rate")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                    <HeaderTemplate>
                                        <asp:Label ID="lblGvHdrERRoomRate" runat="server" Text="Room Rate"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%#DataBinder.Eval(Container.DataItem, "UnitRate")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                    <HeaderTemplate>
                                        <asp:Label ID="lblGvHdrERTax" runat="server" Text="Tax"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%#DataBinder.Eval(Container.DataItem, "Tax")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                    <HeaderTemplate>
                                        <asp:Label ID="lblGvHdrERDiscount" runat="server" Text="Discount"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%#DataBinder.Eval(Container.DataItem, "Discount")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                    <HeaderTemplate>
                                        <asp:Label ID="lblGvHdrERService" runat="server" Text="Service"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%#DataBinder.Eval(Container.DataItem, "Service")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                    <HeaderTemplate>
                                        <asp:Label ID="lblGvHdrERExtra" runat="server" Text="Extra"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%#DataBinder.Eval(Container.DataItem, "Extra")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                    <HeaderTemplate>
                                        <asp:Label ID="lblGvHdrERTotal" runat="server" Text="Total"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%#DataBinder.Eval(Container.DataItem, "Total")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                        <asp:Label ID="lblGvHdrAction" runat="server" Text="Actions"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkERDelete" runat="server" ToolTip="Delete" CommandName="DELETEDATA"><img src="../../images/delete.png" /></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                            </Columns>
                            <EmptyDataTemplate>
                                <div style="padding: 10px;">
                                    <b>
                                        <asp:Label ID="lblNoRecordFoundForER" runat="server" Text="No Record Found."></asp:Label>
                                    </b>
                                </div>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Button ID="btnSaveExtendReservation" runat="server" Style="display: inline;
                        padding-right: 10px;" ValidationGroup="AddExtendReservation" Text="Save" />
                    <asp:Button ID="btnCancelExtendReservation" runat="server" Style="display: inline;"
                        Text="Cancel" />
                </td>
                <td align="right" style="float: right; background-color: #DCDDDF; color: #0083CE;
                    font-size: 15px; font-weight: bold; padding: 9px; width: 250px;">
                    800.00
                </td>
            </tr>
        </table>
    </div>
    <div class="clear">
    </div>
</div>
<%--</asp:Panel>--%>
<ucERCommonCardInfo:CtrlERCommonCardInfo ID="CtrlERCommonCardInfo" runat="server" />
