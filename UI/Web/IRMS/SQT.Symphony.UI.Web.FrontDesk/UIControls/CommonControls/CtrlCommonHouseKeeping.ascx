<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCommonHouseKeeping.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls.CtrlCommonHouseKeeping" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<ajx:ModalPopupExtender ID="mpeHouseKeeping" runat="server" TargetControlID="hdnHouseKeeping"
    PopupControlID="pnlHouseKeeping" BackgroundCssClass="mod_background" CancelControlID="btnHouseKeepingCancel">
</ajx:ModalPopupExtender>
<asp:HiddenField ID="hdnHouseKeeping" runat="server" />
<asp:Panel ID="pnlHouseKeeping" runat="server" Width="700px" Style="display: none;">
    <div class="box_col1">
        <div class="box_head">
            <span>
                <asp:Literal ID="litHouseKeepingHeader" runat="server" Text="Reservation HouseKeeping"></asp:Literal></span></div>
        <div class="clear">
        </div>
        <div class="box_form">
            <table cellpadding="2" cellspacing="2" border="0" width="100%">
                <tr>
                    <td>
                        <div style="float: left; width: 100px;">
                            <asp:Literal ID="litHouseKeepingReservationNo" runat="server" Text="Reservation No."></asp:Literal>
                        </div>
                        <div style="float: left; width: 100px;">
                            <asp:Literal ID="litDisplayHouseKeepingReservationNo" runat="server" Text="20043"></asp:Literal></div>
                        <div style="float: left; width: 100px;">
                            <asp:Literal ID="litHouseKeepingUnitNo" runat="server" Text="Room No."></asp:Literal></div>
                        <div style="float: left; width: 100px;">
                            <asp:Literal ID="litDisplayHouseKeepingUnitNo" runat="server" Text="101 - DBL"></asp:Literal></div>
                        <div style="float: left; width: 100px;">
                            <asp:Literal ID="litHouseKeepingGroupName" runat="server" Text="Group Name"></asp:Literal></div>
                        <div style="float: left; width: 100px;">
                            <asp:Literal ID="litDisplayHouseKeepingGroupName" runat="server" Text="Uniworld"></asp:Literal></div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td style="height: 300px; overflow: auto; vertical-align: top;" class="checkbox_new">
                        <div class="box_head">
                            <span>
                                <asp:Literal ID="litHouseKeepingList" runat="server" Text="Reservation HouseKeeping List"></asp:Literal>
                            </span>
                        </div>
                        <div class="clear">
                        </div>
                        <div class="box_content">
                            <asp:GridView ID="gvHouseKeepingList" runat="server" AutoGenerateColumns="false"
                                ShowHeader="true" Width="100%">
                                <Columns>
                                    <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelectHouseKeepint" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblGvHdrHouseKeepingSrNo" runat="server" Text="No."></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblGvHdrHouseKeepingDate" runat="server" Text="Date"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "Date")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="125px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblGvHdrHouseKeepingHouseKeepingType" runat="server" Text="HouseKeeping Type"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlHouseKeepingType" runat="server" Style="width: 90px !important;">
                                                <asp:ListItem Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                <asp:ListItem Selected="True" Text="Full" Value="Full"></asp:ListItem>
                                                <asp:ListItem Text="Minimal" Value="Minimal"></asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblGvHdrHouseKeepingNotes" runat="server" Text="Notes"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "Notes")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <div style="padding: 10px;">
                                        <b>
                                            <asp:Label ID="lblHouseKeepingNoRecordFound" runat="server" Text="No Record Found."></asp:Label>
                                        </b>
                                    </div>
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btnHouseKeepingSave" runat="server" Text="Save" Style="display: inline;" />
                        <asp:Button ID="btnHouseKeepingCancel" runat="server" Text="Cancel" Style="display: inline;" />
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
