<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlResourceFileAssignment.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.Configurations.CtrlResourceFileAssignment" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<asp:UpdatePanel ID="updPropertyList" runat="server">
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
                                <asp:Literal ID="ltrMainHeaderBlock" runat="server" Text="Resource file Assignment"></asp:Literal>
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
                                    <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                        <tr>
                                            <td colspan="2">
                                                <%if (IsMessage)
                                                  { %>
                                                <div class="ResetSuccessfully">
                                                    <div style="float: left; padding-top: 7px; width: 25px; height: 24px; margin-right: 10px;">
                                                        <img src="../../images/success.png" /></div>
                                                    <div>
                                                        <asp:Label ID="lblMessage" runat="server"></asp:Label></div>
                                                    <div style="height: 10px;">
                                                    </div>
                                                </div>
                                                <%}%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                <asp:Literal ID="ltrPropertyNameBlock" runat="server" Text="Property"></asp:Literal>
                                            </th>
                                            <td>
                                                <asp:DropDownList ID="ddlPropertyBlock" runat="server">
                                                    <asp:ListItem Text="-Select-" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="Property 1" Value="1"></asp:ListItem>
                                                </asp:DropDownList>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rvfPropertyName" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                        runat="server" InitialValue="0" ValidationGroup="IsRequire" ControlToValidate="ddlPropertyBlock"></asp:RequiredFieldValidator></span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                <asp:Literal ID="ltrLanguage" runat="server" Text="Language"></asp:Literal>
                                            </th>
                                            <td>
                                                <asp:DropDownList ID="ddlLanguage" runat="server">
                                                    <asp:ListItem Text="-Select-" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="English" Value="English"></asp:ListItem>
                                                </asp:DropDownList>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                        runat="server" InitialValue="0" ValidationGroup="IsRequire" ControlToValidate="ddlLanguage"></asp:RequiredFieldValidator></span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="padding-top: 10px;">
                                                <div style="float: right; width: auto; display: inline-block;">
                                                    <asp:Button ID="btnCancel" Style="float: right; margin-left: 5px;" runat="server"
                                                        ImageUrl="~/images/cancle.png" CausesValidation="false" Text="Cancel" OnClick="btnCancel_OnClick" />
                                                    <asp:Button ID="btnSave" Style="float: right; margin-left: 5px;" runat="server" Text="Create"
                                                        ImageUrl="~/images/save.png" ValidationGroup="IsRequire" CausesValidation="true"
                                                        OnClick="btnSave_OnClick" />
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 310px;">
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
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdateProgress AssociatedUpdatePanelID="updPropertyList" ID="UpdateProgressPropertyList"
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
