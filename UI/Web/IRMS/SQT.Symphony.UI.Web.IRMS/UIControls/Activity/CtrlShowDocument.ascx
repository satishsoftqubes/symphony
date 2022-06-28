<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlShowDocument.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.Activity.CtrlShowDocument" %>
<table width="100%" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <asp:GridView ID="gvFirstGrid" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="" HeaderText="" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:GridView ID="" runat="server">
                                <Columns>
                                    <asp:BoundField DataField="" HeaderText="" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>
