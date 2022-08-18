<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlSalerPartner.ascx.cs" 
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.SalerPartner.CtrlSalerPartner" %>

<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<asp:UpdatePanel ID="updCtrlSalerPartner" runat="server">
    <ContentTemplate>
        <asp:Button ID="btnAddCtrlSalerPartner" runat="server" Text="Add New" OnClick="btnAdd_Click" Style="float: right;" />
        <table>
            <tr>
                <td>test</td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>