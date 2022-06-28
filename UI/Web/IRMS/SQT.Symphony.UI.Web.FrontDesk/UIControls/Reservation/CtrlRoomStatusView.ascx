<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlRoomStatusView.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation.CtrlRoomStatusView" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<asp:UpdatePanel ID="updRoomStatusView" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="content">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                <asp:Literal ID="litMainHeader" runat="server" Text="Room Status"></asp:Literal>
                            </td>
                            <td class="boxtopright">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="boxleft">
                                &nbsp;
                            </td>
                            <td align="left">
                                <div class="box_form">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td>
                                                <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                    <tr>
                                                        <td width="80px">
                                                            <asp:Literal ID="litSearchName" runat="server" Text="Room Type"></asp:Literal>
                                                        </td>
                                                        <td width="200px">
                                                            <asp:DropDownList ID="ddlRoomTypes" runat="server" SkinID="nowidth" Width="150px">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td width="40px">
                                                            <asp:Literal ID="litBlockType" runat="server" Text="Block"></asp:Literal>
                                                        </td>
                                                        <td width="150px">
                                                            <asp:DropDownList ID="ddlBlockType" runat="server" SkinID="nowidth" Width="100px">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td width="40px">
                                                            <asp:Literal ID="litFloorType" runat="server" Text="Floor"></asp:Literal>
                                                        </td>
                                                        <td width="150px">
                                                            <asp:DropDownList ID="ddlFloorType" runat="server" SkinID="nowidth" Width="100px">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="litPage" runat="server" Text="Page"></asp:Literal>
                                                            &nbsp;&nbsp; &nbsp;&nbsp;
                                                            <asp:DropDownList ID="ddlPage" AutoPostBack="true" OnSelectedIndexChanged="ddlPage_SelectedIndexChange"
                                                                runat="server" SkinID="nowidth" Width="100px">
                                                            </asp:DropDownList>
                                                            <asp:ImageButton ID="btnSearch" OnClick="btnSearch_OnClick" runat="server" ImageUrl="~/images/search-icon.png"
                                                                ToolTip="Search" Style="border: 0px; margin: -4px 0 0 5px; vertical-align: middle;" />
                                                            <asp:ImageButton ID="imgbtnClearSearch" OnClick="imgbtnClearSearch_OnClick" runat="server"
                                                                ToolTip="Reset" ImageUrl="~/images/clearsearch.png" Style="border: 0px; vertical-align: middle;
                                                                margin: -4px 0 0 5px;" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="border-bottom: 1px solid #CCCCCC;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            (i) Full Occupied:&nbsp;&nbsp;<b><asp:Literal ID="ltrCountFullOccupied" runat="server"></asp:Literal></b>
                                                        </td>
                                                        <td>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(ii) Partial Occupied:&nbsp;&nbsp;<b><asp:Literal
                                                                ID="ltrCountPartialOccupied" runat="server"></asp:Literal></b>
                                                        </td>
                                                        <td>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(iii) Total Occupied
                                                            <b>(i + ii):&nbsp;&nbsp;<asp:Literal ID="ltrCountTotalOccupied" runat="server"></asp:Literal></b>
                                                        </td>
                                                        <td>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(iv) Full Vaccant:&nbsp;&nbsp;<b><asp:Literal
                                                                ID="ltrCountFullVaccant" runat="server"></asp:Literal></b>
                                                        </td>
                                                        <td>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(v) Total Rooms <b>(iii
                                                                + iv):&nbsp;&nbsp;<asp:Literal ID="ltrCountTotalRooms" runat="server"></asp:Literal></b>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="border-bottom: 1px solid #CCCCCC;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div class="clear">
                                                </div>
                                                <div>
                                                    <asp:Label ID="lblNoRecordFound" runat="server"></asp:Label></div>
                                                <asp:DataList ID="dlRoomStatusView" runat="server" CellPadding="10" CellSpacing="10"
                                                    RepeatDirection="Horizontal" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="55" ItemStyle-BorderWidth="1" ItemStyle-BorderColor="Black"
                                                    ItemStyle-Height="30" RepeatColumns="14" OnItemDataBound="dlRoomStatusView_ItemDataBound">
                                                    <ItemTemplate>
                                                        <b>
                                                            <asp:Label ID="lblRooNo" runat="server" ForeColor="White"></asp:Label></b>
                                                        <%--<asp:Label ID="lblRoomId" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem, "RoomID")%>'></asp:Label>--%>
                                                        <ajx:HoverMenuExtender ID="hmeRoomstatusView" runat="server" TargetControlID="lblRooNo"
                                                            PopupControlID="pnlRoomStatusView" PopupPosition="Left">
                                                        </ajx:HoverMenuExtender>
                                                        <asp:Panel ID="pnlRoomStatusView" runat="server" Style="visibility: hidden; opacity: 100%">
                                                            <div class="actionsbuttons_hovermenu" id="divGuestInfo">
                                                                <table border="0" cellpadding="0" cellspacing="0" class="actionsbuttons_hover_lettmenu_table">
                                                                    <tr>
                                                                        <td class="actionsbuttons_hover_lettmenu">
                                                                        </td>
                                                                        <td class="actionsbuttons_hover_centermenu">
                                                                            <ul>
                                                                                <li>
                                                                                    <asp:Label ID="lblGuestInfo" runat="server"></asp:Label></b> </li>
                                                                            </ul>
                                                                        </td>
                                                                        <td class="actionsbuttons_hover_rightmenu">
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </asp:Panel>
                                                    </ItemTemplate>
                                                </asp:DataList>
                                            </td>
                                        </tr>
                                        <tr style="display: none;">
                                            <td style="text-align: center;">
                                                <asp:Button ID="btnfirst" runat="server" Font-Bold="true" Text="<<" Height="31px"
                                                    Width="43px" OnClick="btnfirst_Click" Style="display: inline;" />
                                                <asp:Button ID="btnprevious" runat="server" Font-Bold="true" Text="<" Height="31px"
                                                    Width="43px" OnClick="btnprevious_Click" Style="display: inline;" />
                                                <asp:Button ID="btnnext" runat="server" Font-Bold="true" Text=">" Height="31px" Width="43px"
                                                    OnClick="btnnext_Click" Style="display: inline;" />
                                                <asp:Button ID="btnlast" runat="server" Font-Bold="true" Text=">>" Height="31px"
                                                    Width="43px" OnClick="btnlast_Click" Style="display: inline;" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div style="float: left;">
                                                    <table width="380px">
                                                        <tr style="height: 25px;">
                                                            <td align="center" style="font-weight: bold; color: Black; background-color: #8d0000;">
                                                                Block
                                                            </td>
                                                            <td align="center" style="font-weight: bold; color: Black; background-color: Green;">
                                                                Vacant
                                                            </td>
                                                            <td align="center" style="font-weight: bold; color: Black; background-color: Red;">
                                                                Occupied
                                                            </td>
                                                            <td align="center" style="font-weight: bold; color: Black; background-color: Blue;">
                                                                Reservation Block
                                                            </td>
                                                            <td align="center" style="font-weight: bold; color: Black; background-color: Yellow;">
                                                                Hkp
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                            <td class="boxright">
                            </td>
                        </tr>
                        <tr>
                            <td class="boxbottomleft">
                            </td>
                            <td class="boxbottomcenter">
                            </td>
                            <td class="boxbottomright">
                            </td>
                        </tr>
                    </table>
                    <div class="clear_divider">
                    </div>
                    <div class="clear">
                    </div>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updRoomStatusView" ID="UpdateProgressRoomStatus"
    runat="server">
    <ProgressTemplate>
        <div id="progressBackgroundFilter">
        </div>
        <div id="processMessage">
            <center>
                <img src="../../images/ajax-loader.gif" /></center>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
