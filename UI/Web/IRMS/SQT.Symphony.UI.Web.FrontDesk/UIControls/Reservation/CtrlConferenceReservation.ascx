<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlConferenceReservation.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation.CtrlConferenceReservation" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonAddServices.ascx" TagName="AddServices"
    TagPrefix="ucCtrlAddServices" %>
<link type="text/css" href="../../Styles/jquery-ui-1.8.5.custom.css" rel="stylesheet" />
<script type="text/javascript" src="../../Scripts/jquery-1.4.2.min.js"></script>
<script type="text/javascript" src="../../Scripts/jquery-ui-1.8.5.custom.min.js"></script>
<link rel="stylesheet" href="../../Styles/jquery.ui.timepicker.css" type="text/css" />
<script type="text/javascript" src="../../Scripts/jquery-ui-timepicker-addon.js"></script>
<script type="text/javascript" language="javascript">
    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<asp:UpdatePanel ID="updRoomReservation" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="content" style="padding-left: 0px; width: 66.66%">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                <asp:Literal ID="litMainHeader" runat="server" Text="Conference Reservation"></asp:Literal>
                            </td>
                            <td class="boxtopright">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="boxleft">
                            </td>
                            <td>
                                <div class="box_form">
                                    <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                        <tr>
                                            <td width="50%" style="vertical-align: top; border-right: 1px solid #ccccce;">
                                                <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                    <tr>
                                                        <td colspan="4">
                                                            <b>
                                                                <asp:Literal ID="litStayInformation" runat="server" Text="Stay Information"></asp:Literal></b>
                                                            <hr />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="isrequire">
                                                            <asp:Literal ID="ltrHoursDay" runat="server" Text="Hours/Day"></asp:Literal>
                                                        </td>
                                                        <td class="NumericDropdown">
                                                            <asp:DropDownList ID="ddlHoursDay" runat="server" Style="width: 75px;">
                                                                <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                                <asp:ListItem Text="Hours" Value="Hours"></asp:ListItem>
                                                                <asp:ListItem Text="Day" Value="Day"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvHoursDay" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                    ValidationGroup="IsRequire" ControlToValidate="ddlHoursDay" Display="Dynamic">
                                                                </asp:RequiredFieldValidator>
                                                            </span>&nbsp;&nbsp;&nbsp;
                                                            <asp:TextBox ID="txtHoursDay" runat="server" MaxLength="3"></asp:TextBox>
                                                            <ajx:NumericUpDownExtender ID="nudeHoursDay" runat="server" TargetControlID="txtHoursDay"
                                                                Width="60" Minimum="1" Maximum="999" />
                                                            <ajx:FilteredTextBoxExtender ID="ftbeHoursDay" runat="server" TargetControlID="txtHoursDay"
                                                                FilterType="Numbers" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="isrequire">
                                                            <asp:Literal ID="litArrivalDate" runat="server" Text="Arv"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtArrivalDate" runat="server" Style="width: 90px !important;"></asp:TextBox>
                                                            <asp:Image ID="imgArrivalDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                                Height="20px" Width="20px" />
                                                            <ajx:CalendarExtender ID="calReseravationDate" PopupButtonID="imgArrivalDate" TargetControlID="txtArrivalDate"
                                                                runat="server" Format="dd/MMM/yyyy">
                                                            </ajx:CalendarExtender>
                                                            <img src="../../images/clear.png" id="imgAD" style="vertical-align: middle;" title="Clear Date"
                                                                onclick="fnClearDate('<%= txtArrivalDate.ClientID %>');" />
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvArrivalDate" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                    runat="server" ValidationGroup="IsRequire" ControlToValidate="txtArrivalDate"
                                                                    Display="Dynamic">
                                                                </asp:RequiredFieldValidator>
                                                            </span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <b>
                                                                <asp:Literal ID="litDepatureDate" runat="server" Text="Dpt"></asp:Literal></b>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                            <asp:TextBox ID="txtDepatureDate" runat="server" Style="width: 90px !important;"></asp:TextBox>
                                                            <asp:Image ID="imgDepatureDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                                Height="20px" Width="20px" />
                                                            <ajx:CalendarExtender ID="CalendarExtender1" PopupButtonID="imgDepatureDate" TargetControlID="txtDepatureDate"
                                                                runat="server" Format="dd/MMM/yyyy">
                                                            </ajx:CalendarExtender>
                                                            <img src="../../images/clear.png" id="imgDD" style="vertical-align: middle;" title="Clear Date"
                                                                onclick="fnClearDate('<%= txtDepatureDate.ClientID %>');" />
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvDepatureDate" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                    runat="server" ValidationGroup="IsRequire" ControlToValidate="txtDepatureDate"
                                                                    Display="Dynamic">
                                                                </asp:RequiredFieldValidator>
                                                            </span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="isrequire">
                                                            <asp:Literal ID="litConference" runat="server" Text="Conference"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlConference" runat="server">
                                                                <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                                <asp:ListItem Text="Breed Conference" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="Byfross Conf." Value="2"></asp:ListItem>
                                                                <asp:ListItem Text="Natak Conference" Value="3"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvConference" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                    ValidationGroup="IsRequire" ControlToValidate="ddlConference" Display="Dynamic">
                                                                </asp:RequiredFieldValidator>
                                                            </span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="isrequire">
                                                            <asp:Literal ID="ltrArrangement" runat="server" Text="Arrange"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlArrangement" runat="server">
                                                                <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                                <asp:ListItem Text="Step-Up" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="Round" Value="2"></asp:ListItem>
                                                                <asp:ListItem Text="Opposite" Value="3"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                    ValidationGroup="IsRequire" ControlToValidate="ddlConference" Display="Dynamic">
                                                                </asp:RequiredFieldValidator>
                                                            </span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="isrequire">
                                                            <asp:Literal ID="litAdult" runat="server" Text="Adult"></asp:Literal>
                                                        </td>
                                                        <td style="vertical-align: middle;" class="NumericDropdown">
                                                            <asp:TextBox ID="txtAdult" runat="server" MaxLength="3"></asp:TextBox>
                                                            <ajx:NumericUpDownExtender ID="AdultNUDE" runat="server" TargetControlID="txtAdult"
                                                                Width="60" Minimum="1" Maximum="999" />
                                                            <ajx:FilteredTextBoxExtender ID="ftAdult" runat="server" TargetControlID="txtAdult"
                                                                FilterType="Numbers" />
                                                            &nbsp;&nbsp;&nbsp;
                                                            <asp:Literal ID="litChild" runat="server" Text="Child"></asp:Literal>&nbsp;&nbsp;&nbsp;
                                                            <asp:TextBox ID="txtChild" runat="server" MaxLength="3"></asp:TextBox>
                                                            <ajx:NumericUpDownExtender ID="ChildNUDE" runat="server" TargetControlID="txtChild"
                                                                Width="60" Minimum="0" Maximum="999" />
                                                            <ajx:FilteredTextBoxExtender ID="ftChild" runat="server" TargetControlID="txtChild"
                                                                FilterType="Numbers" />
                                                            &nbsp;&nbsp;&nbsp;
                                                            <asp:Literal ID="litInfo" runat="server" Text="Inf"></asp:Literal>&nbsp;&nbsp;&nbsp;
                                                            <asp:TextBox ID="txtInfo" runat="server" MaxLength="3"></asp:TextBox>
                                                            <ajx:NumericUpDownExtender ID="InfoNUDE" runat="server" TargetControlID="txtInfo"
                                                                Width="60" Minimum="0" Maximum="999" />
                                                            <ajx:FilteredTextBoxExtender ID="ftInfo" runat="server" TargetControlID="txtInfo"
                                                                FilterType="Numbers" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litAgent" runat="server" Text="Corporate"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlAgent" runat="server">
                                                                <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                                <asp:ListItem Text="Vatsal Shah" Value="Vatsal Shah"></asp:ListItem>
                                                                <asp:ListItem Text="Jayesh Patel" Value="Jayesh Patel"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="isrequire">
                                                            <asp:Literal ID="litRateCard" runat="server" Text="Rate Card"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlRateCard" runat="server">
                                                                <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                                <asp:ListItem Text="Corporate RateCard" Value="Corporate RateCard"></asp:ListItem>
                                                                <asp:ListItem Text="Room RateCard" Value="Room RateCard"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvRateCard" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                    ValidationGroup="IsRequire" ControlToValidate="ddlRateCard" Display="Dynamic">
                                                                </asp:RequiredFieldValidator>
                                                            </span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litDiscount" runat="server" Text="Discount"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlDiscount" runat="server">
                                                                <asp:ListItem Selected="True" Text="-Select-" Value="-Select-"></asp:ListItem>
                                                                <asp:ListItem Text="Diwali Discount" Value="Diwali Discount"></asp:ListItem>
                                                                <asp:ListItem Text="Christmas Discount" Value="Christmas Discount"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litEvent" runat="server" Text="Event"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtEvent" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="vertical-align: top;">
                                                <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                    <tr>
                                                        <td colspan="4">
                                                            <b>
                                                                <asp:Literal ID="litGuestInformation" runat="server" Text="Guest Information"></asp:Literal></b>
                                                            <hr />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="isrequire">
                                                            <asp:Literal ID="litName" runat="server" Text="Name"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <div style="float: left;">
                                                                <asp:DropDownList ID="ddlTitle" runat="server" Style="width: 60px; height: 25px;">
                                                                    <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                                    <asp:ListItem Text="Mr." Value="Mr."></asp:ListItem>
                                                                    <asp:ListItem Text="Mrs." Value="Mrs."></asp:ListItem>
                                                                    <asp:ListItem Text="Ms" Value="Ms"></asp:ListItem>
                                                                </asp:DropDownList>
                                                                <span>
                                                                    <asp:RequiredFieldValidator ID="rvfTitle" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                        SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                        ValidationGroup="IsRequire" ControlToValidate="ddlTitle" Display="Dynamic">
                                                                    </asp:RequiredFieldValidator>
                                                                    <asp:RequiredFieldValidator ID="rfvTitleCardDetails" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                        SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                        ValidationGroup="IsRequireForCardDetails" ControlToValidate="ddlTitle" Display="Dynamic">
                                                                    </asp:RequiredFieldValidator>
                                                                </span>
                                                                <asp:TextBox ID="txtFirstName" runat="server" MaxLength="150" Style="width: 100px !important;"></asp:TextBox><ajx:TextBoxWatermarkExtender
                                                                    ID="txtwmeFirstName" runat="server" TargetControlID="txtFirstName" WatermarkText="First Name">
                                                                </ajx:TextBoxWatermarkExtender>
                                                                <span>
                                                                    <asp:RequiredFieldValidator ID="rvfFirstName" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                        runat="server" ValidationGroup="IsRequire" ControlToValidate="txtFirstName" Display="Dynamic">
                                                                    </asp:RequiredFieldValidator>
                                                                    <asp:RequiredFieldValidator ID="rfvFirstNameForCardDetails" SetFocusOnError="true"
                                                                        CssClass="input-notification error png_bg" runat="server" ValidationGroup="IsRequireForCardDetails"
                                                                        ControlToValidate="txtFirstName" Display="Dynamic">
                                                                    </asp:RequiredFieldValidator>
                                                                </span>
                                                                <asp:TextBox ID="txtLastName" runat="server" MaxLength="150" Style="width: 100px !important;"></asp:TextBox><ajx:TextBoxWatermarkExtender
                                                                    ID="txtwmeLastName" runat="server" TargetControlID="txtLastName" WatermarkText="Last Name">
                                                                </ajx:TextBoxWatermarkExtender>
                                                                &nbsp;&nbsp;&nbsp;
                                                            </div>
                                                            <div style="float: left;">
                                                                <asp:Button ID="btnAddGuest" runat="server" Text="+" OnClick="btnAddGuest_Click" />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litContact" runat="server" Text="Contact"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtContact" runat="server"></asp:TextBox>
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
                                                    <tr>
                                                        <td class="isrequire">
                                                            <asp:Literal ID="litPMT" runat="server" Text="Payment Mode"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <div style="float: left; padding-right: 13px;">
                                                                <asp:DropDownList ID="ddlPMT" runat="server" onchange="fnChangPMT()">
                                                                    <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                                    <asp:ListItem Text="Cash" Value="Cash"></asp:ListItem>
                                                                    <asp:ListItem Text="Card" Value="Card"></asp:ListItem>
                                                                    <asp:ListItem Text="Cheque" Value="Cheque"></asp:ListItem>
                                                                    <asp:ListItem Text="BACS" Value="BACS"></asp:ListItem>
                                                                    <asp:ListItem Text="CAPS" Value="CAPS"></asp:ListItem>
                                                                    <asp:ListItem Text="Direct Bill" Value="Direct Bill"></asp:ListItem>
                                                                </asp:DropDownList>
                                                                <span>
                                                                    <asp:RequiredFieldValidator ID="rfvPMT" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                        SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                        ValidationGroup="IsRequire" ControlToValidate="ddlPMT" Display="Dynamic">
                                                                    </asp:RequiredFieldValidator>
                                                                    <asp:RequiredFieldValidator ID="rfvPMTForCardDetails" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                        SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                        ValidationGroup="IsRequireForCardDetails" ControlToValidate="ddlPMT" Display="Dynamic">
                                                                    </asp:RequiredFieldValidator>
                                                                </span>
                                                            </div>
                                                            <div style="float: left;">
                                                                <asp:Button ID="btnAddCardDetails" runat="server" Text="+" ValidationGroup="IsRequireForCardDetails"
                                                                    OnClick="btnAddCardDetails_Click" /></div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litStatus" runat="server" Text="Status"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlStatus" runat="server">
                                                                <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                                <asp:ListItem Text="Check In" Value="Check In"></asp:ListItem>
                                                                <asp:ListItem Text="Check Out" Value="Check Out"></asp:ListItem>
                                                                <asp:ListItem Text="Confirmed" Value="Confirmed"></asp:ListItem>
                                                                <asp:ListItem Text="Guaranteed" Value="Guaranteed"></asp:ListItem>
                                                                <asp:ListItem Text="In House" Value="In House"></asp:ListItem>
                                                                <asp:ListItem Text="No Show" Value="No Show"></asp:ListItem>
                                                                <asp:ListItem Text="Non Arrival" Value="Non Arrival"></asp:ListItem>
                                                                <asp:ListItem Text="Unconfirmed" Value="Unconfirmed"></asp:ListItem>
                                                                <asp:ListItem Text="Waiting List" Value="Waiting List"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <div style="float: right; width: auto; display: inline-block;">
                                                    <asp:Button ID="btnCancel" runat="server" CausesValidation="false" ImageUrl="~/images/cancle.png"
                                                        Style="float: right; margin-left: 5px;" Text="Cancel" OnClick="btnCancel_Click" />
                                                    <asp:Button ID="btnSave" runat="server" CausesValidation="true" Text="Save" ImageUrl="~/images/save.png"
                                                        Style="float: right; margin-left: 5px;" ValidationGroup="IsRequire" OnClick="btnSave_Click" />
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <table cellpadding="2" cellspacing="2" width="100%">
                                                    <tr>
                                                        <td width="85%">
                                                            <div class="box_head">
                                                                <span>
                                                                    <asp:Literal ID="litConferenceReservationList" runat="server" Text="Conference Reservation"></asp:Literal>
                                                                </span>
                                                            </div>
                                                            <div class="clear">
                                                            </div>
                                                            <div class="box_content">
                                                                <asp:GridView ID="gvConferenceReservation" runat="server" AutoGenerateColumns="false"
                                                                    ShowHeader="true" Width="100%">
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
                                                                                <asp:Label ID="lblGvHdrDate" runat="server" Text="Date"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <%#DataBinder.Eval(Container.DataItem, "Date")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrRate" runat="server" Text="Rate"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <%#DataBinder.Eval(Container.DataItem, "Rate")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrRoomRate" runat="server" Text="Conf. Rate"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <%#DataBinder.Eval(Container.DataItem, "RoomRate")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrServices" runat="server" Text="Services"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <%#DataBinder.Eval(Container.DataItem, "Services")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrUnitTaxes" runat="server" Text="Taxes"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <%#DataBinder.Eval(Container.DataItem, "UnitTaxes")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrUnitType" runat="server" Text="Extra"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <%#DataBinder.Eval(Container.DataItem, "Extra")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrDiscount" runat="server" Text="Discount"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <%#DataBinder.Eval(Container.DataItem, "Discount")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrTotal" runat="server" Text="Total"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <%#DataBinder.Eval(Container.DataItem, "Total")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <EmptyDataTemplate>
                                                                        <div style="padding: 10px;">
                                                                            <b>
                                                                                <asp:Label ID="lblNoRecordFoundForRoomReservation" runat="server" Text="No Record Found."></asp:Label>
                                                                            </b>
                                                                        </div>
                                                                    </EmptyDataTemplate>
                                                                </asp:GridView>
                                                            </div>
                                                        </td>
                                                        <td style="vertical-align: top;">
                                                            <asp:CheckBox ID="chkLockRate" runat="server" Text="Lock Rate" /><br />
                                                            <asp:CheckBox ID="chkPerAdult" runat="server" Text="Per Adult" /><br />
                                                            <asp:LinkButton ID="lnkRoomReservationServices" runat="server" OnClick="lnkRoomReservationServices_Click"><img src="../../images/ServiceStatus32x32.png" style="border:1px solid grey;" /></asp:LinkButton>
                                                            &nbsp;&nbsp;&nbsp;
                                                            <asp:LinkButton ID="lnkHouseKeeping" runat="server"><img src="../../images/HKP28x28.png" style="border:1px solid grey; height:32px; width:32px;" /></asp:LinkButton>
                                                            &nbsp;&nbsp;&nbsp;
                                                            <asp:LinkButton ID="lnkRefresh" runat="server"><img src="../../images/Refresh_F532x32.png" style="border:1px solid grey;" /></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </table>
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
                        <%--<uc1:MsgBox ID="MessageBox" runat="server" />--%>
                    </div>
                </td>
            </tr>
        </table>
        <ajx:ModalPopupExtender ID="mpeAddGuest" runat="server" TargetControlID="hdnGuestName"
            PopupControlID="pnlAddGuest" BackgroundCssClass="mod_background" CancelControlID="btnCancelGuest">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnGuestName" runat="server" />
        <asp:Panel ID="pnlAddGuest" runat="server" Width="800px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="ltrHeaderAddGuest" runat="server" Text="Add Guest"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" border="0" width="100%">
                        <tr>
                            <td width="80px">
                                <b>
                                    <asp:Literal ID="litGuestName" runat="server" Text="Name"></asp:Literal></b>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlGuestTitle" runat="server" Style="width: 80px; height: 25px;">
                                    <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                    <asp:ListItem Text="Mr." Value="Mr."></asp:ListItem>
                                    <asp:ListItem Text="Mrs." Value="Mrs."></asp:ListItem>
                                    <asp:ListItem Text="Ms" Value="Ms"></asp:ListItem>
                                </asp:DropDownList>
                                <span>
                                    <asp:RequiredFieldValidator ID="rfvGuestTitle" InitialValue="00000000-0000-0000-0000-000000000000"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                        ValidationGroup="AddGuest" ControlToValidate="ddlGuestTitle" Display="Static">
                                    </asp:RequiredFieldValidator>
                                </span>
                                <asp:TextBox ID="txtGuestFirstName" runat="server" MaxLength="150" Style="width: 80px !important;"></asp:TextBox>
                                <ajx:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtGuestFirstName"
                                    WatermarkText="First Name">
                                </ajx:TextBoxWatermarkExtender>
                                <span>
                                    <asp:RequiredFieldValidator ID="rfvGuestFirstName" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                        runat="server" ValidationGroup="AddGuest" ControlToValidate="txtGuestFirstName"
                                        Display="Static">
                                    </asp:RequiredFieldValidator>
                                </span>
                                <asp:TextBox ID="txtGuestLastName" runat="server" MaxLength="150" Style="width: 80px !important;"></asp:TextBox>
                                <ajx:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="txtGuestLastName"
                    WatermarkText="Last Name">
                </ajx:TextBoxWatermarkExtender>
                            </td>
                            <td>
                                <b>
                                    <asp:Literal ID="litMaritalStatus" runat="server" Text="Marital Status"></asp:Literal></b>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlMaritalStatus" runat="server" Style="width: 175px;">
                                    <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                    <asp:ListItem Text="Married" Value="Married"></asp:ListItem>
                                    <asp:ListItem Text="Single" Value="Single"></asp:ListItem>
                                </asp:DropDownList>
                                <span>
                                    <asp:RequiredFieldValidator ID="rfvMaritalStatus" InitialValue="00000000-0000-0000-0000-000000000000"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                        ValidationGroup="AddGuest" ControlToValidate="ddlMaritalStatus" Display="Static">
                                    </asp:RequiredFieldValidator>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>
                                    <asp:Literal ID="litIDType" runat="server" Text="ID Type"></asp:Literal></b>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlIDType" runat="server" Style="width: 175px;">
                                    <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                    <asp:ListItem Text="Licence No." Value="Licence No"></asp:ListItem>
                                    <asp:ListItem Text="Passport" Value="Passport"></asp:ListItem>
                                </asp:DropDownList>
                                <span>
                                    <asp:RequiredFieldValidator ID="rfvIDType" InitialValue="00000000-0000-0000-0000-000000000000"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                        ValidationGroup="AddGuest" ControlToValidate="ddlIDType" Display="Static">
                                    </asp:RequiredFieldValidator>
                                </span>
                            </td>
                            <td>
                                <b>
                                    <asp:Literal ID="litIDDetail" runat="server" Text="ID Detail"></asp:Literal></b>
                            </td>
                            <td>
                                <asp:TextBox ID="txtIDDetail" runat="server" Style="width: 173px;"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rfvIDDetail" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                        runat="server" ValidationGroup="AddGuest" ControlToValidate="txtIDDetail" Display="Static">
                                    </asp:RequiredFieldValidator>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>
                                    <asp:Literal ID="litDOB" runat="server" Text="DOB"></asp:Literal></b>
                            </td>
                            <td>
                                <asp:TextBox ID="txtGuestDOB" runat="server" Style="width: 173px;"></asp:TextBox>
                                <asp:Image ID="imgGuestDOB" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                    Height="20px" Width="20px" />
                                <ajx:CalendarExtender ID="calGuestDOB" PopupButtonID="imgGuestDOB" TargetControlID="txtGuestDOB"
                                    runat="server" Format="dd/MMM/yyyy">
                                </ajx:CalendarExtender>
                                <img src="../../images/clear.png" id="img1" style="vertical-align: middle;" title="Clear Date"
                                    onclick="fnClearDate('<%= txtGuestDOB.ClientID %>');" />
                                <span>
                                    <asp:RequiredFieldValidator ID="rfvGuestDOB" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                        runat="server" ValidationGroup="AddGuest" ControlToValidate="txtGuestDOB" Display="Static">
                                    </asp:RequiredFieldValidator>
                                </span>
                            </td>
                            <td>
                                <b>
                                    <asp:Literal ID="litNationality" runat="server" Text="Nationality"></asp:Literal></b>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlNationality" runat="server" Style="width: 175px;">
                                    <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                    <asp:ListItem Text="American" Value="American"></asp:ListItem>
                                    <asp:ListItem Text="Indian" Value="Indian"></asp:ListItem>
                                </asp:DropDownList>
                                <span>
                                    <asp:RequiredFieldValidator ID="rfvNationality" InitialValue="00000000-0000-0000-0000-000000000000"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                        ValidationGroup="AddGuest" ControlToValidate="ddlNationality" Display="Static">
                                    </asp:RequiredFieldValidator>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                <asp:Button ID="btnSaveGuest" runat="server" Style="display: inline; padding-right: 10px;"
                                    OnClientClick="fnDisplayCatchErrorMessage();" ValidationGroup="AddGuest" Text="Save" />
                                <asp:Button ID="btnCancelGuest" runat="server" Style="display: inline;" Text="Close" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpeAddCardDetails" runat="server" TargetControlID="hdnCardDetails"
            PopupControlID="pnlCardDetails" BackgroundCssClass="mod_background" CancelControlID="btnCancelCardDetails">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnCardDetails" runat="server" />
        <asp:Panel ID="pnlCardDetails" runat="server" Width="800px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="litCardInfo" runat="server" Text="Card Info"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td colspan="4" style="font-weight: bold; font-size: 13px; border: 1px solid #CCCCCC;">
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
                                        ValidationGroup="AddCardDetails" ControlToValidate="ddlGuestTitle" Display="Static">
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
                                <asp:TextBox ID="txtIssueDate" runat="server" Style="width: 198px;"></asp:TextBox>
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
                                <asp:TextBox ID="txtExpiryDate" runat="server" Style="width: 198px;"></asp:TextBox>
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
                                    OnClientClick="fnDisplayCatchErrorMessage();" ValidationGroup="AddCardDetails"
                                    Text="Save" />
                                <asp:Button ID="btnSaveAndExitCardDetails" runat="server" Style="display: inline;"
                                    Text="Save And Close" ValidationGroup="AddCardDetails" />
                                <asp:Button ID="btnCancelCardDetails" runat="server" Style="display: inline;" Text="Cancel " />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" width="100%" style="height: 150px; overflow: auto;">
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
        </asp:Panel>
        <ucCtrlAddServices:AddServices ID="ctrlCommonAddServices" runat="server" OnbtnAddServicesCallParent_Click="btnAddServicesCallParent_Click" />
    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updRoomReservation" ID="UpdateProgressRoomReservation"
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
