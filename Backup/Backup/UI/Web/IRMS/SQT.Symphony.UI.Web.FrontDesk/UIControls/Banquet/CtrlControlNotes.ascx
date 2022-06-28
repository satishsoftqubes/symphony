<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlControlNotes.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Banquet.CtrlControlNotes" %>
<table border="0" cellpadding="2" cellspacing="2" width="100%">
    <tr>
        <td style="width: 70px;" class="isrequire">
            <asp:Literal ID="litNotes" runat="server" Text="Notes"></asp:Literal>
        </td>
        <td>
            <asp:TextBox ID="txtNotes" runat="server"></asp:TextBox><span>
                <asp:RequiredFieldValidator ID="rfvNotes" ValidationGroup="IsRequire"
                    SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                    ControlToValidate="txtNotes" Display="Dynamic">
                </asp:RequiredFieldValidator></span>
        </td>
    </tr>
    <tr>
        <td class="isrequire">
            <asp:Literal ID="litPriority" runat="server" Text="Priority"></asp:Literal>
        </td>
        <td>
            <asp:DropDownList ID="ddlPriority" runat="server" Style="width: 150px; height: 25px;">
                <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                <asp:ListItem Text="Low" Value="Low"></asp:ListItem>
                <asp:ListItem Text="Medium" Value="Medium"></asp:ListItem>
            </asp:DropDownList>
            <span>
                <asp:RequiredFieldValidator ID="rfvPriority" ValidationGroup="IsRequire" InitialValue="00000000-0000-0000-0000-000000000000"
                    SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                    ControlToValidate="ddlPriority" Display="Dynamic">
                </asp:RequiredFieldValidator>
            </span>
        </td>
    </tr>
    <tr>
        <td colspan="2" style="padding-top: 8px;" align="right">
            <asp:Button ID="btnSave" runat="server" Style="display: inline; padding-right: 10px;"
                ValidationGroup="IsRequire" Text="Save" />
            <asp:Button ID="btnCancel" runat="server" Style="display: inline;" Text="Cancel" OnClick="btnCancel_Click" />
        </td>
    </tr>
</table>
