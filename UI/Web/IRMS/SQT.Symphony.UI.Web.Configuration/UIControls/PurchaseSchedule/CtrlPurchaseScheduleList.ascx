<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlPurchaseScheduleList.ascx.cs"
 Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.PurchaseSchedule.CtrlPurchaseScheduleList" %>

<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<asp:UpdatePanel ID="updPurchaseScheduleList" runat="server">
    <ContentTemplate>
        <asp:Button ID="btnAddPurchaseSchedule" runat="server" Text="Add New" OnClick="btnAdd_Click" Style="float: right;" />
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

