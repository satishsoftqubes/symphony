<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlAmendmentPolicy.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.Configurations.ctrlAmendmentPolicy" %>
<asp:UpdatePanel ID="updAmendmentPolicy" runat="server">
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
                                <asp:Literal ID="ltrMainHeader" Text="Amendment Policy" runat="server"></asp:Literal>
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
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td style="width: 225px;">
                                                <asp:Literal runat="server" Text="Pre Machor Checkout :" ID="litPerMachorCheckout"></asp:Literal>
                                            </td>
                                            <td colspan="2">
                                                <asp:RadioButtonList runat="server" ID="rblPerMachorCheckout" RepeatDirection="Horizontal"
                                                    RepeatColumns="2">
                                                    <asp:ListItem Text="Aplay Same Rate Card" Value="Aplay Same Rate Card"></asp:ListItem>
                                                    <asp:ListItem Text="Lower Rate Card" Value="Lower Rate Card"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal runat="server" Text="Change In Date" ID="litChangeInDate"></asp:Literal>
                                            </td>
                                            <td style="width: 105px;">
                                                <asp:TextBox ID="txtChangeInDate" MaxLength="15" runat="server" Style="width: 75px !important;"></asp:TextBox>
                                                <ajx:FilteredTextBoxExtender ID="fteChangeInDate" runat="server" FilterType="Custom, Numbers"
                                                    ValidChars="." TargetControlID="txtChangeInDate">
                                                </ajx:FilteredTextBoxExtender>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rfvChangeInDate" SetFocusOnError="True" CssClass="input-notification error png_bg"
                                                        runat="server" ControlToValidate="txtChangeInDate" Display="Static"></asp:RequiredFieldValidator></span>
                                            </td>
                                            <td>
                                                <asp:DropDownList AutoPostBack="true" ID="ddlChangeInDate" runat="server" Style="width: 75px !important;">
                                                    <asp:ListItem Selected="True" Value="%" Text="%"></asp:ListItem>
                                                    <asp:ListItem Value="Flat" Text="Flat"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal runat="server" Text="Change In Room Type(Lower to Higher)" ID="litChangeInRoomTypeLToH"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtChangeInRoomTypeLToH" MaxLength="15" runat="server" Style="width: 75px !important;"></asp:TextBox>
                                                <ajx:FilteredTextBoxExtender ID="fteChangeInRoomTypeLToH" runat="server" FilterType="Custom, Numbers"
                                                    ValidChars="." TargetControlID="txtChangeInRoomTypeLToH">
                                                </ajx:FilteredTextBoxExtender>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rfvChangeInRoomTypeLToH" SetFocusOnError="True" CssClass="input-notification error png_bg"
                                                        runat="server" ControlToValidate="txtChangeInRoomTypeLToH" Display="Static"></asp:RequiredFieldValidator></span>
                                            </td>
                                            <td>
                                                <asp:DropDownList AutoPostBack="true" ID="ddlChangeInRoomTypeLToH" runat="server"
                                                    Style="width: 75px !important;">
                                                    <asp:ListItem Selected="True" Value="%" Text="%"></asp:ListItem>
                                                    <asp:ListItem Value="Flat" Text="Flat"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal runat="server" Text="Change In Room Type(Higher To Lower)" ID="litChangeInRoomTypeHToL"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtChangeInRoomTypeHToL" MaxLength="15" runat="server" Style="width: 75px !important;"></asp:TextBox>
                                                <ajx:FilteredTextBoxExtender ID="fteChangeInRoomTypeHToL" runat="server" FilterType="Custom, Numbers"
                                                    ValidChars="." TargetControlID="txtChangeInRoomTypeHToL">
                                                </ajx:FilteredTextBoxExtender>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rvfChangeInRoomTypeHToL" SetFocusOnError="True" CssClass="input-notification error png_bg"
                                                        runat="server" ControlToValidate="txtChangeInRoomTypeHToL" Display="Static"></asp:RequiredFieldValidator></span>
                                            </td>
                                            <td>
                                                <asp:DropDownList AutoPostBack="true" ID="ddlChangeInRoomTypeHToL" runat="server"
                                                    Style="width: 75px !important;">
                                                    <asp:ListItem Selected="True" Value="%" Text="%"></asp:ListItem>
                                                    <asp:ListItem Value="Flat" Text="Flat"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal runat="server" Text="Change In Guest Name" ID="litChangeInGuestName"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtChangeInGuestName" MaxLength="15" runat="server" Style="width: 75px !important;"></asp:TextBox>
                                                <ajx:FilteredTextBoxExtender ID="fteChangeInGuestName" runat="server" FilterType="Custom, Numbers"
                                                    ValidChars="." TargetControlID="txtChangeInGuestName">
                                                </ajx:FilteredTextBoxExtender>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rfvChangeInGuestName" SetFocusOnError="True" CssClass="input-notification error png_bg"
                                                        runat="server" ControlToValidate="txtChangeInGuestName" Display="Static"></asp:RequiredFieldValidator></span>
                                            </td>
                                            <td>
                                                <asp:DropDownList AutoPostBack="true" ID="ddlChangeInGuestName" runat="server" Style="width: 75px !important;">
                                                    <asp:ListItem Selected="True" Value="%" Text="%"></asp:ListItem>
                                                    <asp:ListItem Value="Flat" Text="Flat"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal runat="server" Text="Change In No of Guest" ID="litChangeInNoofGuest"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtChangeInNoofGuest" MaxLength="15" runat="server" Style="width: 75px !important;"></asp:TextBox>
                                                <ajx:FilteredTextBoxExtender ID="fteChangeInNoofGuest" runat="server" FilterType="Custom, Numbers"
                                                    ValidChars="." TargetControlID="txtChangeInNoofGuest">
                                                </ajx:FilteredTextBoxExtender>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rfvChangeInNoofGuest" SetFocusOnError="True" CssClass="input-notification error png_bg"
                                                        runat="server" ControlToValidate="txtChangeInNoofGuest" Display="Static"></asp:RequiredFieldValidator></span>
                                            </td>
                                            <td>
                                                <asp:DropDownList AutoPostBack="true" ID="ddlChangeInNoofGuest" runat="server" Style="width: 75px !important;">
                                                    <asp:ListItem Selected="True" Value="%" Text="%"></asp:ListItem>
                                                    <asp:ListItem Value="Flat" Text="Flat"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <div style="float: right; width: auto; display: inline-block;">
                                                    <asp:Button runat="server" Text="Save" ID="btnSave" />
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
                        <%--<uc1:MsgBox ID="MessageBox" runat="server" />--%>
                    </div>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
