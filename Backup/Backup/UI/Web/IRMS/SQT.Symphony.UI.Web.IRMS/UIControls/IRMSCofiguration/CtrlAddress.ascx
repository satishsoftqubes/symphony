<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlAddress.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.IRMSCofiguration.CtrlAddress" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <div style="background-color:#ffffff;">
                    <table width="100%" cellpadding="3" cellspacing="2" style="background-color:#fff;">
                        <tr>
                            <td align="left" valign="top" style="width: 125px;">
                                <asp:Literal ID="litAddressLine1" runat="server" Text="Address Line 1"></asp:Literal>
                            </td>
                            <td align="left" valign="top" style="width: 180px;">
                                <asp:TextBox ID="txtAddressLine1" runat="server"></asp:TextBox>
                            </td>
                            <td align="left" valign="top" style="width: 125px;">
                                <asp:Literal ID="litAddressLine2" runat="server" Text="Address Line 2"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAddressLine2" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="litAddressLine3" runat="server" Text="Address Line 3"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAddressLine3" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Literal ID="litZipCode" runat="server" Text="Zip Code"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtZipCode" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="litCountry" runat="server" Text="Select Country"></asp:Literal>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCounry" runat="server">
                                    <asp:ListItem Text="-ALL-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Literal ID="litState" runat="server" Text="Select State"></asp:Literal>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlState" runat="server">
                                    <asp:ListItem Text="-ALL-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="litCity" runat="server" Text="Select City"></asp:Literal>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCity" runat="server">
                                    <asp:ListItem Text="-ALL-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Literal ID="litAddressType" runat="server" Text="Address Type"></asp:Literal>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlAddressType" runat="server">
                                    <asp:ListItem Text="-ALL-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="litRefAddress" runat="server" Text="Ref Address"></asp:Literal>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlRefAddress" runat="server">
                                    <asp:ListItem Text="-ALL-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
