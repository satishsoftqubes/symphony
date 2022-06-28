<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCommonSearchGuest.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Card.CtrlCommonSearchGuest" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<table cellpadding="2" cellspacing="2" width="100%">
    <tr>
        <td width="75px">
            <asp:Literal ID="litSearchCardNo" runat="server" Text="Card No."></asp:Literal>
        </td>
        <td>
            <asp:TextBox ID="txtSearchCardNo" runat="server"></asp:TextBox>
        </td>
        <td width="100px">
            <asp:Literal ID="litSearchGuestName" runat="server" Text="Name"></asp:Literal>
        </td>
        <td>
            <asp:TextBox ID="txtSearchGuestName" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Literal ID="litSearchRoomNo" runat="server" Text="Room No."></asp:Literal>
        </td>
        <td>
            <asp:TextBox ID="txtSearchRoomNo" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:Literal ID="litSearchBookingNo" runat="server" Text="Booking #"></asp:Literal>
        </td>
        <td>
            <asp:TextBox ID="txtSearchReservationNo" runat="server"></asp:TextBox>
            <asp:ImageButton ID="btnSearch" runat="server" ToolTip="Search" ImageUrl="~/images/search-icon.png"
                Style="border: 0px; margin: -4px 0 0 5px; vertical-align: middle;" />
            <asp:ImageButton ID="imgbtnClearSearch" runat="server" ToolTip="Clear" ImageUrl="~/images/clearsearch.png"
                Style="border: 0px; vertical-align: middle; margin: 0 0 0 10px;" />
        </td>
    </tr>
    <tr>
        <td colspan="4">
            <hr />
        </td>
    </tr>
    <tr>
        <td colspan="4">
            <div class="box_head">
                <span>
                    <asp:Literal ID="litGuestList" runat="server" Text="Guest List"></asp:Literal>
                </span>
            </div>
            <div class="clear">
            </div>
            <div class="box_content">
                <asp:GridView ID="gvGuestList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                    Width="100%" OnRowCommand="gvGuestList_RowCommand" OnRowDataBound="gvGuestList_RowDataBound">
                    <Columns>
                        <asp:TemplateField ItemStyle-Width="25px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                            <HeaderTemplate>
                                <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="90px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                            <HeaderTemplate>
                                <asp:Label ID="lblGvHdrName" runat="server" Text="Card No."></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%#DataBinder.Eval(Container.DataItem, "CardNo")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="125px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                            <HeaderTemplate>
                                <asp:Label ID="lblGvHdrName" runat="server" Text="Name"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%#DataBinder.Eval(Container.DataItem, "GuestName")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                            <HeaderTemplate>
                                <asp:Label ID="lblGvHdrBookingNo" runat="server" Text="Booking #"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%#DataBinder.Eval(Container.DataItem, "ResNo")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                            <HeaderTemplate>
                                <asp:Label ID="lblGvHdrRoomNo" runat="server" Text="Room No."></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%#DataBinder.Eval(Container.DataItem, "RoomNo")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                            <HeaderTemplate>
                                <asp:Label ID="lblGvHdrCheckInDate" runat="server" Text="Check In"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%#DataBinder.Eval(Container.DataItem, "Arrival")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                            <HeaderTemplate>
                                <asp:Label ID="lblGvHdrCheckOutDate" runat="server" Text="Check Out"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%#DataBinder.Eval(Container.DataItem, "Depature")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="65px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                            <HeaderTemplate>
                                <asp:Label ID="lblGvHdrBalance" runat="server" Text="Balance"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%#DataBinder.Eval(Container.DataItem, "Balance")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                            <HeaderTemplate>
                                <asp:Label ID="lblGvHdrMobileNo" runat="server" Text="Mobile No."></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%#DataBinder.Eval(Container.DataItem, "MobileNo")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                            <HeaderTemplate>
                                <asp:Label ID="lblGvHdrEmail" runat="server" Text="Email"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%#DataBinder.Eval(Container.DataItem, "Email")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="40px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
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
                                                            <asp:LinkButton ID="lnkRecharge" runat="server" Style="background: none !important;
                                                                border: none;" ToolTip="Recharge" CommandName="RECHARGE" Text="Recharge"><img src="../../images/file.png" /></asp:LinkButton>
                                                        </li>
                                                        <li>
                                                            <asp:LinkButton ID="lnkPrintStatement" runat="server" Style="background: none !important;
                                                                border: none;" ToolTip="Print Statement" CommandName="PRINTSTATEMENT" Text="Print Statement"><img src="../../images/file.png" /></asp:LinkButton>
                                                        </li>
                                                        <li>
                                                            <asp:LinkButton ID="lnkLostCard" runat="server" Style="background: none !important;
                                                                border: none;" ToolTip="Lost/Cancel Card" CommandName="LOSTCARD" Text="Lost/Cancel Card"><img src="../../images/file.png" /></asp:LinkButton>
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
                                <asp:Label ID="lblNoRecordFound" runat="server" Text="No Record Found."></asp:Label>
                            </b>
                        </div>
                    </EmptyDataTemplate>
                </asp:GridView>
            </div>
        </td>
    </tr>
    <tr>
        <td colspan="4" style="padding-top: 10px;" align="right">
            <a href="#">
                <img src="../../images/Print32x32.png" title="Print" /></a>
        </td>
</table>
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
