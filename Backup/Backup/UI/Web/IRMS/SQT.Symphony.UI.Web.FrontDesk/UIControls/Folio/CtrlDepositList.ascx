<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlDepositList.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Folio.CtrlDepositList" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<%@ Register Src="~/UIControls/Folio/CtrlTransferDeposit.ascx" TagName="TransferDeposit"
    TagPrefix="ucTransferDeposit" %>
<%@ Register Src="~/UIControls/Folio/CtrlRefundDeposit.ascx" TagName="RefundDeposit"
    TagPrefix="ucRefundDeposit" %>
<script type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<div class="box_col1">
    <asp:MultiView ID="mvDepositList" runat="server">
        <asp:View ID="vDepositList" runat="server">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="litMainHeader" runat="server" Text="Deposits"></asp:Literal>
                    </span>
                </div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" border="0" width="100%">
                        <tr>
                            <td>
                                <div class="box_content">
                                    <div style="min-height: 230px;">
                                        <asp:GridView ID="gvDepositList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                            Width="100%">
                                            <Columns>
                                                <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrTransDate" runat="server" Text="Trans. Date"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#DataBinder.Eval(Container.DataItem, "TransDate")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrAuditDate" runat="server" Text="Audit Date"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#DataBinder.Eval(Container.DataItem, "AuditDate")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrDescription" runat="server" Text="Description"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#DataBinder.Eval(Container.DataItem, "Description")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrDeposit" runat="server" Text="Deposit"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#DataBinder.Eval(Container.DataItem, "Deposit")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrBalance" runat="server" Text="Balance"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#DataBinder.Eval(Container.DataItem, "Balance")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrVoid" runat="server" Text="Void"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#DataBinder.Eval(Container.DataItem, "Void")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <div style="padding: 10px;">
                                                    <b>
                                                        <asp:Label ID="lblNoRecordFound" runat="server"></asp:Label>
                                                    </b>
                                                </div>
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                    </div>
                                    <div style="text-align: center;">
                                        <asp:Button ID="btnNewDeposit" runat="server" Text="New Deposit" Style="display: inline;"
                                            OnClick="btnNewDeposit_OnClick" />
                                        <asp:Button ID="btnTransfer" runat="server" Text="Transfer" Style="display: inline;"
                                            OnClick="btnTransfer_OnClick" />
                                        <asp:Button ID="btnRefund" runat="server" Text="Refund" Style="display: inline;"
                                            OnClick="btnRefund_OnClick" />
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" Style="display: inline;"
                                            OnClick="btnCancel_OnClick" />
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </asp:View>
        <asp:View ID="vAddDeposit" runat="server">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="ltrHeaderNewDeposit" runat="server" Text="New Deposit"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" border="0" width="100%">
                        <tr>
                            <td style="width: 50%; vertical-align: top; border-right: 1px solid #ccccce; font-size: 13px;">
                                <div class="box_content">
                                    <asp:GridView ID="gvTempDeposit" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                        Width="100%">
                                        <Columns>
                                            <asp:TemplateField ItemStyle-Width="20px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrAVL" runat="server" Text="Receipt #"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "Receipt")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrAVL" runat="server" Text="Date"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "Date")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrAVL" runat="server" Text="Deposit"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "DepositAccount")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrAVL" runat="server" Text="Amount"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "Amount")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <div style="padding: 10px;">
                                                <b>
                                                    <asp:Label ID="lblNoRecordFoundForTempDeposit" runat="server" Text="No Record Found."></asp:Label>
                                                </b>
                                            </div>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </div>
                            </td>
                            <td style="width: 50%; vertical-align: top;">
                                <div class="box_content">
                                    <asp:GridView ID="gvDeposit" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                        Width="100%">
                                        <Columns>
                                            <asp:TemplateField ItemStyle-Width="20px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="20px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkAllDeposit" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrAVL" runat="server" Text="Deposit"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "Deposit")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrAVL" runat="server" Text="Amount"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "Amount")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <div style="padding: 10px;">
                                                <b>
                                                    <asp:Label ID="lblNoRecordFoundForDeposit" runat="server" Text="No Record Found."></asp:Label>
                                                </b>
                                            </div>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                    <tr>
                                        <td>
                                            <b>
                                                <asp:Literal ID="litDeposit" runat="server" Text="Deposit"></asp:Literal></b>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlDeposit" runat="server" Height="16px" Width="123px">
                                                <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                <asp:ListItem Text="Advance Deposit" Value="Advance Deposit"></asp:ListItem>
                                                <asp:ListItem Text="Room Deposit" Value="Room Deposit"></asp:ListItem>
                                            </asp:DropDownList>
                                            <span>
                                                <asp:RequiredFieldValidator ID="rfvDeposit" InitialValue="00000000-0000-0000-0000-000000000000"
                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                    ValidationGroup="IsRequire1" ControlToValidate="ddlDeposit" Display="Dynamic">
                                                </asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>
                                                <asp:Literal ID="litPayment" runat="server" Text="Payment"></asp:Literal></b>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlPayment" runat="server" Height="16px" Width="123px">
                                                <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                <asp:ListItem Text="Check In" Value="Check In"></asp:ListItem>
                                                <asp:ListItem Text="Check Out" Value="Check Out"></asp:ListItem>
                                                <asp:ListItem Text="Confirmed" Value="Confirmed"></asp:ListItem>
                                                <asp:ListItem Text="Guaranteed" Value="Guaranteed"></asp:ListItem>
                                                <asp:ListItem Text="In House" Value="In House"></asp:ListItem>
                                                <asp:ListItem Text="No Show" Value="No Show"></asp:ListItem>
                                                <asp:ListItem Text="Non Arrival" Value="Non Arrival"></asp:ListItem>
                                                <asp:ListItem Text="Unconfirmed" Value="Unconfirmed"></asp:ListItem>
                                                <asp:ListItem Text="Waiting List" Value="Waiting List"></asp:ListItem>
                                            </asp:DropDownList>
                                            <span>
                                                <asp:RequiredFieldValidator ID="rfvPayment" InitialValue="00000000-0000-0000-0000-000000000000"
                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                    ValidationGroup="IsRequire1" ControlToValidate="ddlPayment" Display="Dynamic">
                                                </asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>
                                                <asp:Literal ID="litAmount" runat="server" Text="Amount"></asp:Literal></b>
                                        </td>
                                        <td>
                                            <div style="float: left;">
                                                <asp:TextBox ID="txtAmount" runat="server" Width="123px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvAmount" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                    runat="server" ValidationGroup="IsRequire1" ControlToValidate="txtAmount" Display="Dynamic">
                                                </asp:RequiredFieldValidator>
                                            </div>
                                            <div style="float: left; padding-left: 20px;">
                                                <asp:Button ID="btnAdd" runat="server" CausesValidation="true" ValidationGroup="IsRequire1"
                                                    OnClick="btnAdd_OnClick" Text="+" />
                                            </div>
                                            <div style="float: left; padding-left: 20px;">
                                                <ajx:FilteredTextBoxExtender ID="ftAmount" runat="server" TargetControlID="txtAmount"
                                                    FilterType="Custom, Numbers" ValidChars="." />
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="litNote" runat="server" Text="Note"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNote" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div style="float: right; width: auto; display: inline-block;">
                                    <asp:Button ID="btnAddDepositCancel" runat="server" CausesValidation="false" ImageUrl="~/images/cancle.png"
                                        Style="float: right; margin-left: 5px;" Text="Cancel" OnClick="btnAddDepositCancel_OnClick" />
                                    <asp:Button ID="btnSaveDeposit" runat="server" Text="Save" ImageUrl="~/images/save.png"
                                        Style="float: right; margin-left: 5px;" ValidationGroup="IsRequire1" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:View>
        <asp:View ID="vTransfer" runat="server">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="litTransferDepositHeader" runat="server" Text="Transfer Deposit"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" border="0" width="100%">
                        <tr>
                            <td>
                                <asp:Literal ID="litTransferDepositBookingNo" runat="server" Text="Booking #"></asp:Literal>&nbsp;&nbsp;
                                - &nbsp;&nbsp;
                                <asp:Literal ID="litDisplayTransferDepositBookingNo" runat="server" Text="30414"></asp:Literal>
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 300px; overflow: auto; vertical-align: top;" class="chekcbox_new">
                                <div class="box_head">
                                    <span>
                                        <asp:Literal ID="litTransferDepositList" runat="server" Text="Transfer Deposit List"></asp:Literal>
                                    </span>
                                </div>
                                <div class="clear">
                                </div>
                                <div class="box_content">
                                    <asp:GridView ID="gvTransferDepositList" runat="server" AutoGenerateColumns="false"
                                        ShowHeader="true" Width="100%">
                                        <Columns>
                                            <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrTransferDepositSrNo" runat="server" Text="No."></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="chkSelectAllTransferDeposit" runat="server" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkSelectTransferDeposit" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrTransferDepositDeposit" runat="server" Text="Deposit"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "Deposit")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrTransferDepositTransferDate" runat="server" Text="Transfer Date"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "TransferDate")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrTransferDepositBalance" runat="server" Text="Balance"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "Balance")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrTransferDepositFolioNo" runat="server" Text="Folio No."></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlTransferDepositFolioNo" runat="server" Style="width: 130px !important;">
                                                        <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                        <asp:ListItem Text="1101" Value="1101"></asp:ListItem>
                                                        <asp:ListItem Text="1102" Value="1102"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrTransferDepositTransferAmount" runat="server" Text="Transfer Amount"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "TransferAmount")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <div style="padding: 10px;">
                                                <b>
                                                    <asp:Label ID="lblTransferDepositNoRecordFound" runat="server" Text="No Record Found."></asp:Label>
                                                </b>
                                            </div>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnTransferDepositSave" runat="server" Text="Save" Style="display: inline;" />
                                <asp:Button ID="btnTransferDepositCancel" runat="server" Style="display: inline;"
                                    Text="Cancel" OnClick="btnTransferDepositCancel_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:View>
        <asp:View ID="vRefundDeposit" runat="server">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="litRefundDepositHeader" runat="server" Text="Refund Deposit"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td>
                                <div style="float: left; width: 75px;">
                                    <asp:Literal ID="litQuickPostFolioNo" runat="server" Text="Folio No."></asp:Literal>
                                </div>
                                <div style="float: left; width: 100px;">
                                    <asp:Literal ID="litDisplayQuickPostFolioNo" runat="server" Text="100141"></asp:Literal>
                                </div>
                                <div style="float: left; width: 75px;">
                                    <asp:Literal ID="litQuickPostUnitNo" runat="server" Text="Room No."></asp:Literal>
                                </div>
                                <div style="float: left; width: 100px;">
                                    <asp:Literal ID="litDisplayQuickPostUnitNo" runat="server" Text="100141"></asp:Literal>
                                </div>
                                <div style="float: left; width: 75px;">
                                    <asp:Literal ID="litQuickPostName" runat="server" Text="Name"></asp:Literal>
                                </div>
                                <div style="float: left;">
                                    <asp:Literal ID="litDisplayQuickPostName" runat="server" Text="Mr. Prakash Patel"></asp:Literal>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 150px; overflow: auto;">
                                <div class="box_head">
                                    <span>
                                        <asp:Literal ID="litRefundDepositList" runat="server" Text="Refund Deposit List"></asp:Literal>
                                    </span>
                                </div>
                                <div class="clear">
                                </div>
                                <div class="box_content">
                                    <asp:GridView ID="gvRefundDepositList" runat="server" AutoGenerateColumns="false"
                                        ShowHeader="true" Width="100%" SkinID="gvNoPaging">
                                        <Columns>
                                            <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrQuickPostSrNo" runat="server" Text="No."></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="chkSelectAllRefundDeposit" runat="server" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkSelectRefundDeposit" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrRefundDepositDeposit" runat="server" Text="Deposit"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "Deposit")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrRefundDepositDate" runat="server" Text="Date"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "Date")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrRefundDepositPayBy" runat="server" Text="Pay By"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "PayBy")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrRefundDepositBalance" runat="server" Text="Balance"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "Balance")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrRefundDepositRefundAC" runat="server" Text="Refund A/C."></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlRefundDepositRefundAC" runat="server" Style="width: 130px !important;">
                                                        <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                        <asp:ListItem Text="BACS - 1202" Value="BACS - 1202"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrRefundDepositRefund" runat="server" Text="Refund"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "Refund")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrRefundDepositForfeited" runat="server" Text="Forfeited"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "Forfeited")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <div style="padding: 10px;">
                                                <b>
                                                    <asp:Label ID="lblRefundDepositNoRecordFound" runat="server" Text="No Record Found."></asp:Label>
                                                </b>
                                            </div>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnRefundDepositSave" runat="server" Style="display: inline; padding-right: 10px;"
                                    Text="Save" />
                                <asp:Button ID="btnRefundDepositCardInfo" runat="server" Style="display: inline;"
                                    Text="Card Info." OnClick="btnRefundDepositCardInfo_Click" />
                                <asp:Button ID="btnRefundDepositCancel" runat="server" Style="display: inline;" Text="Cancel"
                                    OnClick="btnRefundDepositCancel_Cancel" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:View>
        <asp:View ID="vCardInfo" runat="server">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="litCardInfo" runat="server" Text="Card Info"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td colspan="4" style="font-weight: bold; font-size: 13px; border: 1px solid grey;">
                                <asp:Literal ID="litDisplayCardHolderName" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire" style="width: 120px !important;">
                                <asp:Literal ID="litCardType" runat="server" Text="Type"></asp:Literal>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCardType" runat="server" Style="width: 200px;">
                                    <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                    <asp:ListItem Text="American Express" Value="American Express"></asp:ListItem>
                                    <asp:ListItem Text="Mastero" Value="Mastero"></asp:ListItem>
                                    <asp:ListItem Text="Mastercard" Value="Mastercard"></asp:ListItem>
                                    <asp:ListItem Text="Solo" Value="Solo"></asp:ListItem>
                                    <asp:ListItem Text="Visa" Value="Visa"></asp:ListItem>
                                </asp:DropDownList>
                                <span>
                                    <asp:RequiredFieldValidator ID="rfvCardType" InitialValue="00000000-0000-0000-0000-000000000000"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                        ValidationGroup="AddCardDetails" ControlToValidate="ddlCardType" Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                </span>
                            </td>
                            <td class="isrequire">
                                <asp:Literal ID="litCardNo" runat="server" Text="Card No."></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCardNo" runat="server" Style="width: 198px;"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rfvCardNo" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                        runat="server" ValidationGroup="AddCardDetails" ControlToValidate="txtCardNo"
                                        Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire">
                                <asp:Literal ID="litCardHolderName" runat="server" Text="Card Holder's Name"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCardHolderName" runat="server" Style="width: 198px;"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rfvCardHolderName" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                        runat="server" ValidationGroup="AddCardDetails" ControlToValidate="txtCardHolderName"
                                        Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                </span>
                            </td>
                            <td>
                                <asp:Literal ID="litIssueDate" runat="server" Text="Issue Date"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtIssueDate" runat="server" Style="width: 198px;"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire">
                                <asp:Literal ID="litExpiryDate" runat="server" Text="Expiry Date"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtExpiryDate" runat="server" Style="width: 198px;"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rfvExpiryDate" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                        runat="server" ValidationGroup="AddCardDetails" ControlToValidate="txtExpiryDate"
                                        Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                </span>
                            </td>
                            <td>
                                <asp:Literal ID="litIssueNo" runat="server" Text="Issue No."></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtIssueNo" runat="server" Style="width: 198px;"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire">
                                <asp:Literal ID="litSecurityCode" runat="server" Text="Security Code(CVC)"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSecurityCode" runat="server" Style="width: 198px;"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rfvSecurityCode" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                        runat="server" ValidationGroup="AddCardDetails" ControlToValidate="txtSecurityCode"
                                        Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                </span>
                            </td>
                            <td>
                                <asp:Literal ID="litAuthorizationCode" runat="server" Text="Authorization Code"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAuthorizationCode" runat="server" Style="width: 198px;"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="litAuthorizedAmount" runat="server" Text="Authorized Amount"></asp:Literal>
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="txtAuthorizedAmount" runat="server" Style="width: 198px;"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                <asp:Button ID="btnSaveCardDetails" runat="server" Style="display: inline; padding-right: 10px;"
                                    OnClientClick="fnDisplayCatchErrorMessage();" ValidationGroup="AddCardDetails"
                                    Text="Save" />
                                <asp:Button ID="btnCancelCardDetails" runat="server" Style="display: inline;" Text="Cancel"
                                    OnClick="btnCancelCardDetails_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" width="100%" style="height: 150px; overflow: auto; vertical-align: top;">
                                <div class="box_head">
                                    <span>
                                        <asp:Literal ID="litCardList" runat="server" Text="Card List"></asp:Literal>
                                    </span>
                                </div>
                                <div class="clear">
                                </div>
                                <div class="box_content">
                                    <asp:GridView ID="gvCardList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                        Width="100%">
                                        <Columns>
                                            <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrType" runat="server" Text="Type"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "Type")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrCardNo" runat="server" Text="Card No."></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "CardNo")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrName" runat="server" Text="Name"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "Name")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrServices" runat="server" Text="Expiry Date"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "ExpiryDate")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrUnitTaxes" runat="server" Text="Security Code"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "SecurityCode")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblActions" runat="server" Text="Action"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPopUp" runat="server" Text="Action"></asp:Label>
                                                    <ajx:HoverMenuExtender ID="HoverMenuExtender2" runat="server" TargetControlID="lblPopUp"
                                                        PopupControlID="Panel2" PopupPosition="Left">
                                                    </ajx:HoverMenuExtender>
                                                    <asp:Panel ID="Panel2" runat="server" Style="visibility: hidden; opacity: 100%">
                                                        <div class="actionsbuttons_hovermenu">
                                                            <table border="0" cellpadding="0" cellspacing="0" class="actionsbuttons_hover_lettmenu_table">
                                                                <tr>
                                                                    <td class="actionsbuttons_hover_lettmenu">
                                                                    </td>
                                                                    <td class="actionsbuttons_hover_centermenu">
                                                                        <ul>
                                                                            <li>
                                                                                <asp:LinkButton ID="lnkEdit" Style="background: none !important; border: none;" runat="server"
                                                                                    ToolTip="Edit" CommandName="EDITDATA"><img src="../../images/file.png" /></asp:LinkButton>
                                                                            </li>
                                                                            <li>
                                                                                <asp:LinkButton ID="lnkDelete" Style="background: none !important; border: none;"
                                                                                    runat="server" ToolTip="Delete" CommandName="DELETEDATA"><img src="../../images/delete.png" /></asp:LinkButton>
                                                                            </li>
                                                                        </ul>
                                                                    </td>
                                                                    <td class="actionsbuttons_hover_rightmenu">
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </asp:Panel>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <div style="padding: 10px;">
                                                <b>
                                                    <asp:Label ID="lblNoRecordFoundForCardList" runat="server" Text="No Record Found."></asp:Label>
                                                </b>
                                            </div>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:View>
    </asp:MultiView>
    <div id="errormessage" class="clear" style="display: none;">
        <uc1:MsgBox ID="MessageBox" runat="server" />
    </div>
</div>
