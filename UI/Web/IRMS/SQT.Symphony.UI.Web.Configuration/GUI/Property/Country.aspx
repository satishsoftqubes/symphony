<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Country.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.Property.Country" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="125px">
                Country Name
            </td>
            <td style="padding-bottom: 15px;">
                <asp:TextBox ID="txtCountryName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvCountryName" runat="server" ValidationGroup="IsRequire"
                    ErrorMessage="*" ControlToValidate="txtCountryName" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnSave" runat="server" ValidationGroup="IsRequire" Text="Save" OnClick="btnSave_Click" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
