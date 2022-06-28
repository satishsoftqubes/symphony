<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlToDoStask.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Banquet.CtrlToDoStask" %>
    <%--<link type="text/css" href="../../Styles/jquery-ui-1.8.5.custom.css" rel="stylesheet" />
    <script type="text/javascript" src="../../Scripts/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery-ui-1.8.5.custom.min.js"></script>
    <link rel="stylesheet" href="../../Styles/jquery.ui.timepicker.css" type="text/css" />
    <script type="text/javascript" src="../../Scripts/jquery-ui-timepicker-addon.js"></script>--%>
<script type="text/javascript">
    function pageLoad(sender, args) {
        $('#<%=txtTime.ClientID %>').timepicker({ ampm: false });
    }

</script>
<table border="0" cellpadding="2" cellspacing="2" width="100%">
    <tr>
        <td style="width: 70px;" class="isrequire">
            <asp:Literal ID="litTime" runat="server" Text="Time"></asp:Literal>
        </td>
        <td>
            <asp:TextBox ID="txtTime" runat="server" Style="width: 50px !important;" onkeypress="return false;"
                MaxLength="5"></asp:TextBox><span>
                    <asp:RequiredFieldValidator ID="rfvTime" SetFocusOnError="true" CssClass="input-notification error png_bg"
                        runat="server" ValidationGroup="IsRequire" ControlToValidate="txtTime" Display="Dynamic">
                    </asp:RequiredFieldValidator></span>
        </td>
    </tr>
    <tr>
        <td class="isrequire">
            <asp:Literal ID="litTask" runat="server" Text="Task"></asp:Literal>
        </td>
        <td>
            <asp:TextBox ID="txtTask" runat="server"></asp:TextBox><span>
                <asp:RequiredFieldValidator ID="rfvTask" SetFocusOnError="true" CssClass="input-notification error png_bg"
                    runat="server" ValidationGroup="IsRequire" ControlToValidate="txtTask" Display="Dynamic">
                </asp:RequiredFieldValidator></span>
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
