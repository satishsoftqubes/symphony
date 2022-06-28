<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlBanquetProposal.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Banquet.CtrlBanquetProposal" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript">
    function pageLoad(sender, args) {
        $('#<%=txtStartTime.ClientID %>').timepicker({ ampm: false });
        $('#<%=txtEndTime1.ClientID %>').timepicker({ ampm: false });
        $('#<%=txtLabourInfoEndTime.ClientID %>').timepicker({ ampm: false });
        $('#<%=txtLabourInfoStartTime.ClientID %>').timepicker({ ampm: false });

        $("#tabs").tabs();

        $('#tabs').tabs({
            select: function (event, ui) {
                window.location.hash = ui.tab.hash;
            }
        });

    }

    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
    $(document).ready(function () {

        $("#tabs").tabs();


        $('#tabs').tabs({
            select: function (event, ui) {
                window.location.hash = ui.tab.hash;
            }
        });
    });

    function validate() {

        if (Page_ClientValidate("IsRequire")) {
            if (document.getElementById("<%=ddlTitle.ClientID%>").selectedIndex == 0) {
                document.getElementById("<%=lblCustomePopupMsg.ClientID%>").innerHTML = "Please Select Title";
                $find('mpeCustomePopup').show();
                return false;
            }
            else if (document.getElementById("<%=txtFirstName.ClientID%>").value == '') {
                document.getElementById("<%=lblCustomePopupMsg.ClientID%>").innerHTML = "Please Enter Guest Name";
                document.getElementById("<%=txtFirstName.ClientID%>").focus();
                $find('mpeCustomePopup').show();
                return false;
            }
        }
    }

    
</script>
<asp:UpdatePanel ID="updBanquetProposal" runat="server">
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
                                <asp:Literal ID="litMainHeader" runat="server" Text="Banquet Proposal"></asp:Literal>
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
                                            <td align="left" style="padding-top: 10px; background-color: #fff !important;">
                                                <div class="demo">
                                                    <div class="demo">
                                                        <div id="tabs">
                                                            <ul>
                                                                <li><a href="#tabs-1">
                                                                    <asp:Literal ID="littabStayInfo" runat="server" Text="Booking Detail"></asp:Literal></a></li>
                                                                <li><a href="#tabs-2">
                                                                    <asp:Literal ID="littabGuestInfo" runat="server" Text="Labour Management"></asp:Literal></a></li>
                                                            </ul>
                                                            <div id="tabs-1">
                                                                <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                                    <tr>
                                                                        <td style="vertical-align: top; border-right: 1px solid #ccccce; padding: 7px; width: 55%;">
                                                                            <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                                                <tr>
                                                                                    <td colspan="2">
                                                                                        <h1>
                                                                                            <asp:Literal ID="Literal1" runat="server" Text="Stay Information"></asp:Literal></h1>
                                                                                        <hr>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="isrequire">
                                                                                        <asp:Literal ID="litArrivalDate" runat="server" Text="Check In"></asp:Literal>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="txtArrivalDate" runat="server" Style="width: 90px !important;" onkeypress="return false;"></asp:TextBox>
                                                                                        <asp:Image ID="imgArrivalDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                                                            Height="20px" Width="20px" />
                                                                                        <ajx:CalendarExtender ID="calArrivalDate" PopupButtonID="imgArrivalDate" TargetControlID="txtArrivalDate"
                                                                                            runat="server" Format="dd/MMM/yyyy">
                                                                                        </ajx:CalendarExtender>
                                                                                        <img src="../../images/clear.png" id="imgAD" style="vertical-align: middle;" title="Clear Date"
                                                                                            onclick="fnClearDate('<%= txtArrivalDate.ClientID %>');" />
                                                                                        <span>
                                                                                            <asp:RequiredFieldValidator ID="rfvArrivalDate" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                                                runat="server" ValidationGroup="IsRequire" ControlToValidate="txtArrivalDate"
                                                                                                Display="Dynamic">
                                                                                            </asp:RequiredFieldValidator>
                                                                                        </span>&nbsp;&nbsp;&nbsp;
                                                                                        <asp:DropDownList ID="ddlFrequency" runat="server" Style="width: 75px;">
                                                                                            <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                                                            <asp:ListItem Text="Daily" Value="Daily"></asp:ListItem>
                                                                                            <asp:ListItem Text="Weekly" Value="Weekly"></asp:ListItem>
                                                                                            <asp:ListItem Text="Monthly" Value="Monthly"></asp:ListItem>
                                                                                            <asp:ListItem Text="Quartrly" Value="Quartrly"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                        <span>
                                                                                            <asp:RequiredFieldValidator ID="rfvFrequency" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                                                SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                                                ValidationGroup="IsRequire" ControlToValidate="ddlFrequency" Display="Dynamic">
                                                                                            </asp:RequiredFieldValidator>
                                                                                        </span>&nbsp;&nbsp;&nbsp;
                                                                                        <asp:TextBox ID="txtNight" runat="server" MaxLength="3" Style="width: 40px !important;"
                                                                                            AutoPostBack="true"></asp:TextBox>
                                                                                        <span>
                                                                                            <asp:RequiredFieldValidator ID="rfvNight" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                                                runat="server" ValidationGroup="IsRequire" ControlToValidate="txtNight" Display="Dynamic">
                                                                                            </asp:RequiredFieldValidator>
                                                                                        </span>
                                                                                        <ajx:FilteredTextBoxExtender ID="ftNight" runat="server" TargetControlID="txtNight"
                                                                                            FilterType="Numbers" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="isrequire">
                                                                                        <asp:Literal ID="litDepatureDate" runat="server" Text="Check Out"></asp:Literal>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="txtDepatureDate" runat="server" onkeypress="return false;" Style="width: 107px"></asp:TextBox>
                                                                                        <asp:Image ID="imgDepatureDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                                                            Height="20px" Width="20px" />
                                                                                        <ajx:CalendarExtender ID="calDepatureDate" PopupButtonID="imgDepatureDate" TargetControlID="txtDepatureDate"
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
                                                                                        <asp:Literal ID="litBanquet" runat="server" Text="Banquet"></asp:Literal>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlBanquet" AutoPostBack="true" OnSelectedIndexChanged="ddlBanquet_OnSelectedIndexChanged"
                                                                                            runat="server" Style="width: 150px;">
                                                                                            <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                                                            <asp:ListItem Text="Barton" Value="Barton"></asp:ListItem>
                                                                                            <asp:ListItem Text="Hempton" Value="Hempton"></asp:ListItem>
                                                                                            <asp:ListItem Text="Rousham" Value="Rousham"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                        <span>
                                                                                            <asp:RequiredFieldValidator ID="rfvBanquet" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                                                SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                                                ValidationGroup="IsRequire" ControlToValidate="ddlBanquet" Display="Dynamic">
                                                                                            </asp:RequiredFieldValidator>
                                                                                        </span>&nbsp;&nbsp;&nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="isrequire">
                                                                                        <asp:Literal ID="litArrange" runat="server" Text="Arrange"></asp:Literal>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlArrange" runat="server" Style="width: 150px;">
                                                                                            <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                        <span>
                                                                                            <asp:RequiredFieldValidator ID="rfvArrange" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                                                SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                                                ValidationGroup="IsRequire" ControlToValidate="ddlArrange" Display="Dynamic">
                                                                                            </asp:RequiredFieldValidator>
                                                                                        </span>&nbsp;&nbsp;&nbsp;
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
                                                                                        <asp:Literal ID="litAgent" runat="server" Text="Agent"></asp:Literal>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlAgent" runat="server" Style="width: 150px;">
                                                                                            <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="isrequire">
                                                                                        <asp:Literal ID="litRateCard" runat="server" Text="Rate Card(s)"></asp:Literal>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlRateCard" runat="server" Style="width: 150px;">
                                                                                            <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                                                            <asp:ListItem Text="Room Rate Card" Value="Room Rate Card"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                        <span>
                                                                                            <asp:RequiredFieldValidator ID="rfvRateCard" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                                                SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                                                ValidationGroup="IsRequire" ControlToValidate="ddlRateCard" Display="Dynamic">
                                                                                            </asp:RequiredFieldValidator>
                                                                                        </span>&nbsp;&nbsp;&nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="isrequire">
                                                                                        <asp:Literal ID="litEvent" runat="server" Text="Event"></asp:Literal>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="txtEvent" runat="server" Style="width: 148px"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                                            runat="server" ValidationGroup="IsRequire" ControlToValidate="txtEvent" Display="Dynamic">
                                                                                        </asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Literal ID="litTheam" runat="server" Text="Theam"></asp:Literal>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlTheam" runat="server" Style="width: 150px;">
                                                                                            <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td>
                                                                            <table border="0" cellpadding="2" cellspacing="2">
                                                                                <tr>
                                                                                    <td colspan="2">
                                                                                        <h1>
                                                                                            <asp:Literal ID="litGuestInfo" runat="server" Text="Guest Information"></asp:Literal></h1>
                                                                                        <hr>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="isrequire" style="width: 80px !important;">
                                                                                        <asp:Literal ID="litName" runat="server" Text="Name"></asp:Literal>
                                                                                    </td>
                                                                                    <td>
                                                                                        <div style="float: left;">
                                                                                            <asp:DropDownList ID="ddlTitle" runat="server" Style="width: 50px; height: 25px;">
                                                                                                <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                                                                <asp:ListItem Text="Mr." Value="Mr."></asp:ListItem>
                                                                                                <asp:ListItem Text="Mrs." Value="Mrs."></asp:ListItem>
                                                                                                <asp:ListItem Text="Ms" Value="Ms"></asp:ListItem>
                                                                                            </asp:DropDownList>
                                                                                            <%--<span>
                                                                                                <asp:RequiredFieldValidator ID="rvfTitle" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                                                    ValidationGroup="IsRequire" ControlToValidate="ddlTitle" Display="Dynamic">
                                                                                                </asp:RequiredFieldValidator>
                                                                                            </span>--%>
                                                                                            <asp:TextBox ID="txtFirstName" runat="server" MaxLength="150" Style="width: 90px !important;"></asp:TextBox><ajx:TextBoxWatermarkExtender ID="txtwmeFirstName" runat="server" TargetControlID="txtFirstName"
                    WatermarkText="First Name">
                </ajx:TextBoxWatermarkExtender>
                                                                                            <%--<span>
                                                                                                <asp:RequiredFieldValidator ID="rvfFirstName" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                                                    runat="server" ValidationGroup="IsRequire" ControlToValidate="txtFirstName" Display="Dynamic">
                                                                                                </asp:RequiredFieldValidator>
                                                                                            </span>--%>
                                                                                            <asp:TextBox ID="txtLastName" runat="server" MaxLength="150" Style="width: 90px !important;"></asp:TextBox><ajx:TextBoxWatermarkExtender ID="txtwmeLastName" runat="server" TargetControlID="txtLastName"
                    WatermarkText="Last Name">
                </ajx:TextBoxWatermarkExtender>
                                                                                            &nbsp;&nbsp;&nbsp;
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
                                                                                    <td style="vertical-align: top;">
                                                                                        <asp:Literal ID="litAddress" runat="server" Text="Address"></asp:Literal>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Rows="2"></asp:TextBox>
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
                                                                                        <asp:Literal ID="litEmail" runat="server" Text="Email"></asp:Literal>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                                                                                        <span>
                                                                                            <asp:RegularExpressionValidator ID="refEmail" Display="Dynamic" SetFocusOnError="True"
                                                                                                ControlToValidate="txtEmail" runat="server" CssClass="input-notification error png_bg"
                                                                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                                                        </span>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Literal ID="litFaxNo" runat="server" Text="Fax No."></asp:Literal>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="txtFaxNo" runat="server"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" style="padding-top: 8px;" align="right">
                                                                            <div style="float: left; width: auto; display: inline-block;">
                                                                                <asp:Button ID="btnCalRate" runat="server" Style="float: left; margin-left: 5px;"
                                                                                    Text="Calculate Rate" ValidationGroup="IsRequire" OnClick="btnCalRate_Click" />
                                                                            </div>
                                                                            <asp:Button ID="btnSave" OnClientClick="return validate();" runat="server" Style="display: inline;
                                                                                padding-right: 10px;" ValidationGroup="IsRequire" Text="Save" />
                                                                            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_OnClick" Style="display: inline;"
                                                                                Text="Cancel" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">
                                                                            <table cellpadding="2" cellspacing="2" width="100%">
                                                                                <tr>
                                                                                    <td width="85%">
                                                                                        <div class="box_head">
                                                                                            <span>
                                                                                                <asp:Literal ID="litRoomReservationList" runat="server" Text="Room Reservation"></asp:Literal>
                                                                                            </span>
                                                                                        </div>
                                                                                        <div class="clear">
                                                                                        </div>
                                                                                        <div class="box_content">
                                                                                            <asp:GridView ID="gvRoomReservation" runat="server" AutoGenerateColumns="false" ShowHeader="true"
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
                                                                                                            <asp:Label ID="lblGvHdrRoomRate" runat="server" Text="Unit Rate"></asp:Label>
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
                                                                                                            <asp:Label ID="lblGvHdrUnitTaxes" runat="server" Text="Unit Taxes"></asp:Label>
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
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                            <div id="tabs-2">
                                                                <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                                    <tr>
                                                                        <td style="width: 40%; border-right: 1px solid #ccccce; vertical-align: top;">
                                                                            <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                                                <tr>
                                                                                    <td width="100%" style="height: 150px; overflow: auto; border-bottom: 1px solid #ccccce;
                                                                                        vertical-align: top;">
                                                                                        <div class="box_head">
                                                                                            <span>
                                                                                                <asp:Literal ID="litServiceList" runat="server" Text="Labour Task"></asp:Literal>
                                                                                            </span>
                                                                                        </div>
                                                                                        <div class="clear">
                                                                                        </div>
                                                                                        <div class="box_content">
                                                                                            <asp:GridView ID="gvLabourTask" runat="server" AutoGenerateColumns="false" Width="100%"
                                                                                                OnRowCommand="gvLabourTask_RowCommand">
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
                                                                                                            <asp:Label ID="lblGvHdrManager" runat="server" Text="Manager"></asp:Label>
                                                                                                        </HeaderTemplate>
                                                                                                        <ItemTemplate>
                                                                                                            <asp:LinkButton ID="lnkManager" Style="color: #0067A4;" runat="server" ToolTip="Manager"
                                                                                                                CommandName="Manager" Text='<%#DataBinder.Eval(Container.DataItem, "Manager")%>'></asp:LinkButton>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                        <HeaderTemplate>
                                                                                                            <asp:Label ID="lblGvHdrServiceArea" runat="server" Text="Service Area"></asp:Label>
                                                                                                        </HeaderTemplate>
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblServiceArea" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ServiceArea")%>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                        <HeaderTemplate>
                                                                                                            <asp:Label ID="lblGvHdrLabours" runat="server" Text="Labours"></asp:Label>
                                                                                                        </HeaderTemplate>
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblLabours" runat="server" Text=' <%#DataBinder.Eval(Container.DataItem, "Labours")%>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                        <HeaderTemplate>
                                                                                                            <asp:Label ID="lblGvHdrStart" runat="server" Text="Start"></asp:Label>
                                                                                                        </HeaderTemplate>
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblStart" Text='<%#DataBinder.Eval(Container.DataItem, "Start")%>'
                                                                                                                runat="server"></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                        <HeaderTemplate>
                                                                                                            <asp:Label ID="lblGvHdrEnd" runat="server" Text="End"></asp:Label>
                                                                                                        </HeaderTemplate>
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblEnd" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "End")%>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                                                        <HeaderTemplate>
                                                                                                            <asp:Label ID="lblGvHdrCharge" runat="server" Text="Charge"></asp:Label>
                                                                                                        </HeaderTemplate>
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblCharge" runat="server" Text=' <%#DataBinder.Eval(Container.DataItem, "Charge")%>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                </Columns>
                                                                                                <EmptyDataTemplate>
                                                                                                    <div style="padding: 10px;">
                                                                                                        <b>
                                                                                                            <asp:Label ID="lblNoRecordFoundForService" runat="server" Text="No Record Found."></asp:Label>
                                                                                                        </b>
                                                                                                    </div>
                                                                                                </EmptyDataTemplate>
                                                                                            </asp:GridView>
                                                                                        </div>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <table border="0" cellpadding="2" cellspacing="2">
                                                                                            <tr>
                                                                                                <td class="isrequire">
                                                                                                    <asp:Literal ID="litServiceArea" Text="Service Area" runat="server"></asp:Literal>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:DropDownList ID="ddlServiceArea" runat="server" Style="width: 150px; height: 25px;">
                                                                                                        <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                                                                        <asp:ListItem Text="Bartender" Value="Bartender"></asp:ListItem>
                                                                                                        <asp:ListItem Text="Entertainer" Value="Entertainer"></asp:ListItem>
                                                                                                    </asp:DropDownList>
                                                                                                    <span>
                                                                                                        <asp:RequiredFieldValidator ID="rvfServiceArea" ValidationGroup="IsRequire1" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                                                            SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                                                            ControlToValidate="ddlServiceArea" Display="Dynamic">
                                                                                                        </asp:RequiredFieldValidator>
                                                                                                    </span>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td class="isrequire">
                                                                                                    <asp:Literal ID="litManager" Text="Manager" runat="server"></asp:Literal>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:DropDownList ID="ddlManager" runat="server" Style="width: 150px; height: 25px;">
                                                                                                        <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                                                                        <asp:ListItem Text="Om Patel" Value="Om Patel"></asp:ListItem>
                                                                                                        <asp:ListItem Text="Raj Rao" Value="Raj Rao"></asp:ListItem>
                                                                                                    </asp:DropDownList>
                                                                                                    <span>
                                                                                                        <asp:RequiredFieldValidator ID="rvfManager" ValidationGroup="IsRequire1" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                                                            SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                                                            ControlToValidate="ddlManager" Display="Dynamic">
                                                                                                        </asp:RequiredFieldValidator>
                                                                                                    </span>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:Literal ID="litStartTime" runat="server" Text="Start Time"></asp:Literal>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="txtStartTime" runat="server" Style="width: 50px !important;" onkeypress="return false;"
                                                                                                        MaxLength="5"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:Literal ID="litEndTime" runat="server" Text="End Time"></asp:Literal>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="txtEndTime1" runat="server" Style="width: 50px !important;" onkeypress="return false;"
                                                                                                        MaxLength="5"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:Literal ID="litCharge" runat="server" Text="Charge"></asp:Literal>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="txtCharge" runat="server" Style="width: 150px;"></asp:TextBox>
                                                                                                    <ajx:FilteredTextBoxExtender ID="ftbCharge" runat="server" TargetControlID="txtCharge"
                                                                                                        FilterType="custom,Numbers" ValidChars="." />
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="vertical-align: top;">
                                                                                                    <asp:Literal ID="litChargeType" runat="server" Text="Charge Type"></asp:Literal>
                                                                                                </td>
                                                                                                <td style="vertical-align: top;">
                                                                                                    <asp:RadioButtonList runat="server" ID="rblChargeType" RepeatColumns="2" RepeatDirection="Horizontal">
                                                                                                        <asp:ListItem Text="Per Person" Value="Per Rerson"></asp:ListItem>
                                                                                                        <asp:ListItem Text="On Event" Value="On Event"></asp:ListItem>
                                                                                                        <asp:ListItem Text="Per Hourly" Value="Per Hourly"></asp:ListItem>
                                                                                                        <asp:ListItem Text="Per Day" Value="Per Day"></asp:ListItem>
                                                                                                    </asp:RadioButtonList>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:Literal ID="litLabours" runat="server" Text="Labours"></asp:Literal>
                                                                                                </td>
                                                                                                <td style="vertical-align: middle;" class="NumericDropdown">
                                                                                                    <asp:TextBox ID="txtLabours" runat="server" MaxLength="3"></asp:TextBox>
                                                                                                    <ajx:NumericUpDownExtender ID="nuptxtLabours" runat="server" TargetControlID="txtLabours"
                                                                                                        Width="60" Minimum="1" Maximum="999" />
                                                                                                    <ajx:FilteredTextBoxExtender ID="ftbtxtLabours" runat="server" TargetControlID="txtLabours"
                                                                                                        FilterType="Numbers" />
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="vertical-align: top;">
                                                                                                    <asp:Literal ID="litNotes" runat="server" Text="Notes"></asp:Literal>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="txtNotes" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="2" style="padding-top: 8px;" align="right">
                                                                                                    <asp:Button ID="btnAdd" runat="server" Style="display: inline; padding-right: 10px;"
                                                                                                        Text="Add" OnClick="btnAdd_OnClick" ValidationGroup="IsRequire1" />
                                                                                                    <asp:Button ID="btnClear" runat="server" Style="display: inline;" Text="Clear" OnClick="btnClear_OnClick" />
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td style="vertical-align: top; width: 60%;">
                                                                            <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                                                <tr>
                                                                                    <td width="100%" style="height: 150px; overflow: auto; border-bottom: 1px solid #ccccce;
                                                                                        vertical-align: top;">
                                                                                        <div class="box_head">
                                                                                            <span>
                                                                                                <asp:Literal ID="litLabourInfoList" runat="server" Text="Labour Information List"></asp:Literal>
                                                                                            </span>
                                                                                        </div>
                                                                                        <div class="clear">
                                                                                        </div>
                                                                                        <div class="box_content">
                                                                                            <asp:GridView ID="gvLabourInfo" runat="server" AutoGenerateColumns="false" Width="100%">
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
                                                                                                            <asp:Label ID="lblGvHdrLabourName" runat="server" Text="Labour Name"></asp:Label>
                                                                                                        </HeaderTemplate>
                                                                                                        <ItemTemplate>
                                                                                                            <%#DataBinder.Eval(Container.DataItem, "LabourName")%>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                        <HeaderTemplate>
                                                                                                            <asp:Label ID="lblGvHdrContacts" runat="server" Text="Contacts"></asp:Label>
                                                                                                        </HeaderTemplate>
                                                                                                        <ItemTemplate>
                                                                                                            <%#DataBinder.Eval(Container.DataItem, "Contacts")%>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                        <HeaderTemplate>
                                                                                                            <asp:Label ID="lblGvHdrJobDetail" runat="server" Text="JobDetail"></asp:Label>
                                                                                                        </HeaderTemplate>
                                                                                                        <ItemTemplate>
                                                                                                            <%#DataBinder.Eval(Container.DataItem, "JobDetail")%>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                        <HeaderTemplate>
                                                                                                            <asp:Label ID="lblGvHdrStart" runat="server" Text="Start"></asp:Label>
                                                                                                        </HeaderTemplate>
                                                                                                        <ItemTemplate>
                                                                                                            <%#DataBinder.Eval(Container.DataItem, "Start")%>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                        <HeaderTemplate>
                                                                                                            <asp:Label ID="lblGvHdrStart" runat="server" Text="End"></asp:Label>
                                                                                                        </HeaderTemplate>
                                                                                                        <ItemTemplate>
                                                                                                            <%#DataBinder.Eval(Container.DataItem, "End")%>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                        <HeaderTemplate>
                                                                                                            <asp:Label ID="lblGvHdrStart" runat="server" Text="Present"></asp:Label>
                                                                                                        </HeaderTemplate>
                                                                                                        <ItemTemplate>
                                                                                                            <%#DataBinder.Eval(Container.DataItem, "Present")%>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                </Columns>
                                                                                                <EmptyDataTemplate>
                                                                                                    <div style="padding: 10px;">
                                                                                                        <b>
                                                                                                            <asp:Label ID="lblNoRecordFoundForService" runat="server" Text="No Record Found."></asp:Label>
                                                                                                        </b>
                                                                                                    </div>
                                                                                                </EmptyDataTemplate>
                                                                                            </asp:GridView>
                                                                                        </div>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                                                            <tr>
                                                                                                <td colspan="2">
                                                                                                    <div class="box_head">
                                                                                                        <span>
                                                                                                            <asp:Literal ID="litLabourInfo" runat="server" Text="Labour Information"></asp:Literal>
                                                                                                        </span>
                                                                                                    </div>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td class="isrequire">
                                                                                                    <asp:Literal ID="litLabourInfoLabourName" runat="server" Text="Labour Name"></asp:Literal>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="txtLabourInfoLabourName" runat="server"></asp:TextBox>
                                                                                                    <span>
                                                                                                        <asp:RequiredFieldValidator ID="rvfLabourName" ValidationGroup="IsRequire2" SetFocusOnError="true"
                                                                                                            CssClass="input-notification error png_bg" runat="server" ControlToValidate="txtLabourInfoLabourName"
                                                                                                            Display="Dynamic">
                                                                                                        </asp:RequiredFieldValidator>
                                                                                                    </span>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:Literal ID="litLabourInfoContacts" runat="server" Text="Contacts"></asp:Literal>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="txtLabourInfoContacts" runat="server"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:Literal ID="litLabourInfoJobDetail" runat="server" Text="Job Detail"></asp:Literal>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="txtLabourInfoJobDetail" runat="server"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:Literal ID="litLabourInfoStartTime" runat="server" Text="Start Time"></asp:Literal>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="txtLabourInfoStartTime" runat="server" Style="width: 50px !important;"
                                                                                                        onkeypress="return false;" MaxLength="5"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:Literal ID="litLabourInfoEndTime" runat="server" Text="End Time"></asp:Literal>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="txtLabourInfoEndTime" runat="server" Style="width: 50px !important;"
                                                                                                        onkeypress="return false;" MaxLength="5"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:CheckBox ID="chkPresent" Text="Present" runat="server" />
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="2" style="padding-top: 8px;" align="right">
                                                                                                    <asp:Button ID="btnLabourInfoAdd" runat="server" Style="display: inline; padding-right: 10px;"
                                                                                                        Text="Add" ValidationGroup="IsRequire2" OnClick="btnLabourInfoAdd_OnClick" />
                                                                                                    <asp:Button ID="btnLabourInfoClear" runat="server" OnClick="btnLabourInfoClear_OnClick"
                                                                                                        Style="display: inline;" Text="Clear" />
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
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
                    </div>
                </td>
            </tr>
        </table>
        <asp:HiddenField ID="hfPopupCustomeMessage" runat="server" />
        <ajx:ModalPopupExtender ID="mpeCustomePopup" runat="server" TargetControlID="hfPopupCustomeMessage"
            PopupControlID="pnlCustomeMessage" BackgroundCssClass="mod_background" CancelControlID="btnOKCustomeMsgPopup"
            DropShadow="true" BehaviorID="mpeCustomePopup">
        </ajx:ModalPopupExtender>
        <asp:Panel ID="pnlCustomeMessage" runat="server" Width="350px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="litHeaderCustomePopupMessage" runat="server" Text="Message"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td align="center" style="padding-bottom: 15px; color: Red;">
                                <asp:Label ID="lblCustomePopupMsg" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnOKCustomeMsgPopup" runat="server" Text="OK" Style="display: inline;
                                    padding-right: 10px;" />
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
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updBanquetProposal" ID="UpdateProgressBanquetProposal"
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
