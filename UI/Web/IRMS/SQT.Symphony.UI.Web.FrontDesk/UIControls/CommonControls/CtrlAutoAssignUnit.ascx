<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlAutoAssignUnit.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls.CtrlAutoAssignUnit" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<ajx:ModalPopupExtender ID="mpeAutoAssignUnit" runat="server" TargetControlID="hdnAutoAssignUnit"
    PopupControlID="pnlAutoAssignUnit" BackgroundCssClass="mod_background" CancelControlID="imgCloseAutoAssign">
</ajx:ModalPopupExtender>
<asp:HiddenField ID="hdnAutoAssignUnit" runat="server" />
<asp:Panel ID="pnlAutoAssignUnit" runat="server" Width="500px" Style="display: none;">
    <div class="box_col1">
        <div class="box_head">
            <div style="display: inline;">
                <span>
                    <asp:Literal ID="litQuickPostHeader" runat="server" Text="Auto Assign Unit"></asp:Literal></span>
            </div>
            <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                <asp:ImageButton ID="imgCloseAutoAssign" runat="server" ImageUrl="~/images/closepopup.png"
                    Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;" />
            </div>
        </div>
        <div class="clear">
        </div>
        <div class="box_form">
            <table cellpadding="2" cellspacing="2" border="0" width="100%">
                <tr>
                    <td>
                        <asp:Literal ID="litAutoAssignUnitType" runat="server" Text="Unit Type"></asp:Literal>&nbsp;&nbsp;
                        - &nbsp;&nbsp;
                        <asp:Literal ID="litDisplayAutoAssignUnitType" runat="server" Text="Double"></asp:Literal>
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td style="height: 400px; overflow: auto; vertical-align: top;">
                        <div class="box_head">
                            <span>
                                <asp:Literal ID="litAutoAssignUnitList" runat="server" Text="Unit List"></asp:Literal>
                            </span>
                        </div>
                        <div class="clear">
                        </div>
                        <div class="box_content">
                            <asp:GridView ID="gvAutoAssignUnitList" runat="server" AutoGenerateColumns="false"
                                ShowHeader="true" Width="100%">
                                <Columns>
                                    <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblGvHdrAutoAssignUnitSrNo" runat="server" Text="No."></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblGvHdrAutoAssignUnitNo" runat="server" Text="Room No."></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkAutoAssingUnitNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "UnitNo")%>'><%#DataBinder.Eval(Container.DataItem, "UnitNo")%></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblGvHdrAutoAssignBlockFloor" runat="server" Text="Block/Floor"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "BlockFloor")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <div style="padding: 10px;">
                                        <b>
                                            <asp:Label ID="lblNoRecordFound" runat="server" Text="No Record Found."></asp:Label>
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
</asp:Panel>
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
