<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlPurchaseScheduleList.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.Configurations.CtrlPurchaseScheduleList" %>

<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<asp:UpdatePanel ID="updPurchaseScheduleList" runat="server">
    <ContentTemplate>
        <asp:Button ID="btnAddPurchaseSchedule" runat="server" Text="Add New" OnClick="btnAdd_Click" Style="float: right;" />
    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
