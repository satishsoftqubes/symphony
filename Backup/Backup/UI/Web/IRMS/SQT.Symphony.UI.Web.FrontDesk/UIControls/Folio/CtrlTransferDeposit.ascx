<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlTransferDeposit.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Folio.CtrlTransferDeposit" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<%--<ajx:ModalPopupExtender ID="mpeTransferDeposit" runat="server" TargetControlID="hdnTransferDeposit"
    PopupControlID="pnlTransferDeposit" BackgroundCssClass="mod_background" CancelControlID="btnTransferDepositCancel">
</ajx:ModalPopupExtender>
<asp:HiddenField ID="hdnTransferDeposit" runat="server" />
<asp:Panel ID="pnlTransferDeposit" runat="server" Width="675px" Style="display: none;">--%>
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
                        <asp:Literal ID="litTransferDepositReservationNo" runat="server" Text="Reservation No."></asp:Literal>&nbsp;&nbsp;
                        - &nbsp;&nbsp;
                        <asp:Literal ID="litDisplayTransferDepositReservationNo" runat="server" Text="30414"></asp:Literal>
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
                                            <asp:CheckBox ID="chkSelectAllTransferDeposit" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelectTransferDeposit" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblGvHdrTransferDepositSrNo" runat="server" Text="No."></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
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
                            Text="Cancel" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="clear">
        </div>
    </div>
<%--</asp:Panel>--%>
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
