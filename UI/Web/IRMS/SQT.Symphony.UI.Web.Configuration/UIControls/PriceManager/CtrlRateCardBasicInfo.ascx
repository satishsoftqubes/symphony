<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlRateCardBasicInfo.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.PriceManager.CtrlRateCardBasicInfo" %>
<asp:UpdatePanel ID="upnlBasicInfo" runat="server">
    <ContentTemplate>
        <table cellpadding="2" cellspacing="2" width="100%">
            <tr id="tr1" runat="server" visible="false">
                <td class="isrequire">
                    <asp:Literal ID="litStayType" runat="server"></asp:Literal>
                </td>
                <td>
                    <asp:DropDownList ID="ddlStayType" runat="server" SkinID="nowidth" Width="195px">
                    </asp:DropDownList>
                    <span>
                        <asp:RequiredFieldValidator ID="rvfStayType" runat="server" ControlToValidate="ddlStayType"
                            SetFocusOnError="true" CssClass="input-notification error png_bg" InitialValue="00000000-0000-0000-0000-000000000000"
                            ValidationGroup="IsRequire"></asp:RequiredFieldValidator>
                    </span>
                </td>
            </tr>
            <tr>
                <td class="isrequire">
                    <asp:Literal ID="litRateCardName" runat="server"></asp:Literal>
                </td>
                <td>
                    <asp:TextBox ID="txtRateCardName" runat="server" MaxLength="65" SkinID="nowidth"
                        Width="193px"></asp:TextBox>
                    <span>
                        <asp:RequiredFieldValidator ID="rfvRateCardName" runat="server" ControlToValidate="txtRateCardName"
                            SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire"></asp:RequiredFieldValidator>
                    </span>
                </td>
            </tr>
            <tr id="trCode" runat="server" visible="false">
                <td class="isrequire">
                    <asp:Literal ID="litRateCardCode" runat="server"></asp:Literal>
                </td>
                <td>
                    <asp:TextBox ID="txtRateCardCode" runat="server" MaxLength="7" SkinID="nowidth" Width="193px"></asp:TextBox>
                    <span>
                        <asp:RequiredFieldValidator ID="rfvRateCardCode" runat="server" ControlToValidate="txtRateCardCode"
                            SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire"></asp:RequiredFieldValidator>
                    </span>
                </td>
            </tr>
            <tr>
                <td class="isrequire">
                    <asp:Literal ID="Literal1" runat="server" Text="Min. Stay(Days)"></asp:Literal>
                </td>
                <td>
                    <asp:TextBox ID="txtStayDuration" runat="server" OnTextChanged="txtStayDuration_textChanged"
                        AutoPostBack="true" MaxLength="3" SkinID="nowidth" Width="193px"></asp:TextBox>
                    <span>
                        <asp:RequiredFieldValidator ID="rfvStayDuration" runat="server" ControlToValidate="txtStayDuration"
                            SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire"></asp:RequiredFieldValidator>
                    </span>
                    <ajx:FilteredTextBoxExtender ID="ftbeStayDuration" runat="server" TargetControlID="txtStayDuration"
                        FilterMode="ValidChars" ValidChars="0123456789">
                    </ajx:FilteredTextBoxExtender>
                </td>
            </tr>
            <tr>
                <td class="isrequire">
                    <asp:Literal ID="litDateFrom" runat="server"></asp:Literal>
                </td>
                <td>
                    <asp:TextBox ID="txtDateFrom" runat="server" onkeydown="return stopKey(event);" SkinID="nowidth"
                        Width="140px"></asp:TextBox>
                    <ajx:CalendarExtender ID="calExtDateFrom" runat="server" Enabled="True" TargetControlID="txtDateFrom"
                        PopupButtonID="imgDateFrom">
                    </ajx:CalendarExtender>
                    <asp:Image ID="imgDateFrom" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                        Height="20px" Width="20px" />
                    <img id="imgClearDateFrom" style="vertical-align: middle;" height="14px" width="14px"
                        title="<%= strClearDateTooltip %>" alt="" onclick="fnCleardate('<%= txtDateFrom.ClientID %>');"
                        src="../../images/clear.png" />
                    <span>
                        <asp:RequiredFieldValidator ID="rfvDateFrom" runat="server" ControlToValidate="txtDateFrom"
                            SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire"></asp:RequiredFieldValidator>
                    </span>
                </td>
            </tr>
            <tr>
                <td class="isrequire">
                    <asp:Literal ID="litDateTo" runat="server"></asp:Literal>
                </td>
                <td>
                    <asp:TextBox ID="txtDateTo" runat="server" onkeydown="return stopKey(event);" SkinID="nowidth"
                        Width="140px"></asp:TextBox>
                    <ajx:CalendarExtender ID="calExtDateTo" runat="server" Enabled="True" TargetControlID="txtDateTo"
                        PopupButtonID="imgDateTo">
                    </ajx:CalendarExtender>
                    <asp:Image ID="imgDateTo" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                        Height="20px" Width="20px" />
                    <img id="imgClearDateTo" style="vertical-align: middle;" height="14px" width="14px"
                        title="<%= strClearDateTooltip %>" alt="" onclick="fnCleardate('<%= txtDateTo.ClientID %>');"
                        src="../../images/clear.png" />
                    <span>
                        <asp:RequiredFieldValidator ID="rfvDateTo" runat="server" ControlToValidate="txtDateTo"
                            SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire"></asp:RequiredFieldValidator>
                    </span>
                </td>
            </tr>
            <tr>
                <td class="isrequire">
                    <asp:Literal ID="Literal2" runat="server" Text="Cancellation Policy"></asp:Literal>
                </td>
                <td>
                    <asp:DropDownList ID="ddlCancelationPolicy" runat="server" SkinID="nowidth" Width="195px">
                    </asp:DropDownList>
                    <span>
                        <asp:RequiredFieldValidator ID="rfvCancellationPolicy" runat="server" ControlToValidate="ddlCancelationPolicy"
                            SetFocusOnError="true" CssClass="input-notification error png_bg" InitialValue="00000000-0000-0000-0000-000000000000"
                            ValidationGroup="IsRequire"></asp:RequiredFieldValidator>
                    </span>
                </td>
            </tr>
            <tr>
                <td class="isrequire">
                    <asp:Literal ID="litDisplayTermForRateCard" runat="server" Text="Display Term"></asp:Literal>
                </td>
                <td>
                    <asp:TextBox ID="txtRateCardDispNameForRateCard" runat="server" MaxLength="150" SkinID="nowidth"
                        Width="193px"></asp:TextBox>
                    <span>
                        <asp:RequiredFieldValidator ID="rfvDisplayTermForRateCard" runat="server" ControlToValidate="txtRateCardDispNameForRateCard"
                            SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire"></asp:RequiredFieldValidator>
                    </span>
                </td>
            </tr>
            <tr>
                <td class="isrequire">
                    <asp:Literal ID="litRetentionCharge" runat="server" Text="Retention Charge (%)"></asp:Literal>
                </td>
                <td>
                    <asp:TextBox ID="txtRetentionCharge" runat="server" MaxLength="3" SkinID="nowidth" Width="193px"></asp:TextBox>
                    <span>
                        <asp:RequiredFieldValidator ID="rfvRetentionCharge" runat="server" ControlToValidate="txtRetentionCharge"
                            SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire"></asp:RequiredFieldValidator>
                    </span>
                    <ajx:FilteredTextBoxExtender ID="ftbRetentionCharge" runat="server" TargetControlID="txtRetentionCharge"
                        FilterMode="ValidChars" ValidChars="0123456789">
                    </ajx:FilteredTextBoxExtender>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:CheckBox ID="chkIsPerRoom" runat="server" Text="Is Full Room" />
                </td>
            </tr>
            <tr id="tr2" runat="server" visible="false">
                <td class="isrequire">
                    <asp:Literal ID="litPostingFrequency" runat="server"></asp:Literal>
                </td>
                <td>
                    <asp:DropDownList ID="ddlPostingFrequency" runat="server" SkinID="nowidth" Width="195px">
                    </asp:DropDownList>
                    <span>
                        <asp:RequiredFieldValidator ID="rfvPostingFrequency" runat="server" ControlToValidate="ddlPostingFrequency"
                            SetFocusOnError="true" CssClass="input-notification error png_bg" InitialValue="00000000-0000-0000-0000-000000000000"
                            ValidationGroup="IsRequire"></asp:RequiredFieldValidator>
                    </span>
                </td>
            </tr>
            <tr id="trNoOfNights" runat="server" visible="false">
                <th align="left">
                    <asp:Literal ID="litNoOfNights" runat="server"></asp:Literal>
                </th>
                <td>
                    <asp:TextBox ID="txtNoOfNights" runat="server" SkinID="nowidth" Width="142px" Style="text-align: right;"
                        MaxLength="8"></asp:TextBox>
                    <ajx:FilteredTextBoxExtender ID="fteNoOfNights" runat="server" TargetControlID="txtNoOfNights"
                        FilterMode="ValidChars" ValidChars="0123456789">
                    </ajx:FilteredTextBoxExtender>
                </td>
            </tr>
            <tr id="trAllowedAdults" runat="server" visible="false">
                <th align="left">
                    <asp:Literal ID="litAllowedAdults" runat="server"></asp:Literal>
                </th>
                <td>
                    <asp:TextBox ID="txtAllowedAdults" runat="server" SkinID="nowidth" Width="142px"
                        Style="text-align: right;" MaxLength="8"></asp:TextBox>
                    <ajx:FilteredTextBoxExtender ID="ftbAllowedAdults" runat="server" TargetControlID="txtAllowedAdults"
                        FilterMode="ValidChars" ValidChars="0123456789">
                    </ajx:FilteredTextBoxExtender>
                </td>
            </tr>
            <tr id="tr3" runat="server" visible="false">
                <th align="left">
                    <asp:Literal ID="litAllowedChild" runat="server"></asp:Literal>
                </th>
                <td>
                    <asp:TextBox ID="txtAllowedChild" runat="server" SkinID="nowidth" Width="142px" Style="text-align: right;"
                        MaxLength="8"></asp:TextBox>
                    <ajx:FilteredTextBoxExtender ID="ftbAllowedChild" runat="server" TargetControlID="txtAllowedChild"
                        FilterMode="ValidChars" ValidChars="0123456789">
                    </ajx:FilteredTextBoxExtender>
                </td>
            </tr>
            <tr id="trRateCardType" runat="server" visible="false">
                <td>
                    Rate Card Type
                </td>
                <td style="padding: 0px;">
                    <asp:RadioButtonList ID="rdblRateCardType" runat="server" Style="padding: 0px;" RepeatColumns="2"
                        RepeatDirection="Horizontal">
                        <asp:ListItem Text="Standard" Value="STANDARD" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Special" Value="SPECIAL"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr id="trEnableDisable" runat="server" visible="false">
                <td>
                    Rate Card
                </td>
                <td style="padding: 0px;">
                    <asp:CheckBox ID="chkIsEnable" runat="server" Visible="false" />
                    <asp:RadioButtonList ID="rdblRateCardEnable" runat="server" Style="padding: 0px;"
                        RepeatColumns="2" RepeatDirection="Horizontal">
                        <asp:ListItem Text="Enable" Value="1" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Disable" Value="0"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdateProgress AssociatedUpdatePanelID="upnlBasicInfo" ID="upgrsBasicInfo" runat="server">
    <ProgressTemplate>
        <div id="progressBackgroundFilter">
        </div>
        <div id="processMessage">
            <center>
                <img src="../../images/ajax-loader.gif" /></center>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
