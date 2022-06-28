<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlWalkIn.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation.CtrlWalkIn" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }
</script>
<asp:UpdatePanel ID="updWalkIn" runat="server">
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
                                <asp:Literal ID="litMainHeader" runat="server" Text="Walk-In"></asp:Literal>
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
                                    <table cellpadding="2" border="0" cellspacing="2" width="100%">
                                        <tr>
                                            <td class="isrequire" width="100px">
                                                <asp:Literal ID="litSrchDepartureDate" runat="server" Text="Departure"></asp:Literal>
                                            </td>
                                            <td width="260px">
                                                <asp:TextBox ID="txtSrchDepartureDate" runat="server" Style="width: 115px !important;"
                                                    SkinID="searchtextbox" onkeypress="return false;"></asp:TextBox>
                                                <asp:Image ID="imgDepartureDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                    Height="20px" Width="20px" />
                                                <ajx:CalendarExtender ID="calDepartureDate" PopupButtonID="imgDepartureDate" TargetControlID="txtSrchDepartureDate"
                                                    runat="server">
                                                </ajx:CalendarExtender>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rfvSrchDepartureDate" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                        Display="Dynamic" runat="server" ValidationGroup="IsRequire" 
                                                        ControlToValidate="txtSrchDepartureDate"></asp:RequiredFieldValidator></span>
                                                <%--<img src="../../images/clear.png" id="imgclrDepartureDate" alt="" style="vertical-align: middle;"
                                                    title="Clear Date" onclick="fnClearDate('<%= txtSrchDepartureDate.ClientID %>');" />--%>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Ngts:- 1
                                            </td>
                                            <td colspan="2" width="150px">
                                                <b><asp:Literal ID="litSrchAdult" runat="server" Text="Adt"></asp:Literal></b>
                                                &nbsp;<asp:TextBox ID="txtSrchAdult" runat="server" SkinID="nowidth" Width="50px"
                                                    MaxLength="2"></asp:TextBox>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rfvAdult" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                        Display="Dynamic" runat="server" ValidationGroup="IsRequire" 
                                                        ControlToValidate="txtSrchAdult"></asp:RequiredFieldValidator></span>
                                                <ajx:FilteredTextBoxExtender ID="ftbeAdult" runat="server" TargetControlID="txtSrchAdult"
                                                    FilterMode="ValidChars" ValidChars="0123456789">
                                                </ajx:FilteredTextBoxExtender>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Literal ID="ltrSrchChild" runat="server"
                                                    Text="chd"></asp:Literal>
                                                &nbsp;<asp:TextBox ID="txtSrchChild" runat="server" SkinID="nowidth" Width="50px"
                                                    MaxLength="1"></asp:TextBox>
                                                <ajx:FilteredTextBoxExtender ID="ftbeChild" runat="server" TargetControlID="txtSrchChild"
                                                    FilterMode="ValidChars" ValidChars="0123456789">
                                                </ajx:FilteredTextBoxExtender>
                                            </td>
                                            <td width="100px">
                                                <asp:Literal ID="litSrchCorporate" runat="server" Text="Corporate"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlSrchCorporate" runat="server" Style="width: 142px;">
                                                    <asp:ListItem Selected="True" Text="-Select-" Value="-Select-"></asp:ListItem>
                                                    <asp:ListItem Text="AB Corp." Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="Ahuja Brothers" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="L&T" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="Relience Telecom" Value="3"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="isrequire">
                                                <asp:Literal ID="litSrchRateCard" runat="server" Text="Rate"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlSrchRateCard" runat="server" Style="width: 142px;">
                                                    <asp:ListItem Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                    <asp:ListItem Text="General Family" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Double Bedroom" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="Corporate Special" Value="3"></asp:ListItem>
                                                </asp:DropDownList>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rfvSrchRateCard" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                        Display="Dynamic" runat="server" ValidationGroup="IsRequire" InitialValue="00000000-0000-0000-0000-000000000000"
                                                        ControlToValidate="ddlSrchRateCard"></asp:RequiredFieldValidator></span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <div class="box_head">
                                                    <span>
                                                        <asp:Literal ID="litRoomReservationList" runat="server" Text="Room Types"></asp:Literal>
                                                    </span>
                                                </div>
                                                <div class="clear">
                                                </div>
                                                <div class="box_content">
                                                    <asp:GridView ID="gvRoomTypes" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                        Width="100%" OnRowCommand="gvRoomTypes_RowCommand">
                                                        <Columns>
                                                            <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrStatus" runat="server" Text="Room Type"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkbtnRoomType" Text='<%#DataBinder.Eval(Container.DataItem, "RoomType")%>'
                                                                        runat="server" ValidationGroup="IsRequire" CommandName="ROOMTYPE" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "RoomType")%>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="65px" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrVacant" runat="server" Text="Vacant"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkbtnVacant" Text='<%#DataBinder.Eval(Container.DataItem, "Vacant")%>'
                                                                        runat="server" ValidationGroup="IsRequire" CommandName="ROOMTYPE" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "RoomType")%>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="65px" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrAdult" runat="server" Text="Adult"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "Adult")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="65px" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrChild" runat="server" Text="Child"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "Child")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Right" ItemStyle-Width="75px" ItemStyle-HorizontalAlign="Right">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdr1stNight" runat="server" Text="1st Night"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "1stNight")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Right" ItemStyle-Width="75px" ItemStyle-HorizontalAlign="Right">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrEstCost" runat="server" Text="Est. Cost"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "EstCost")%>
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
                        <%--<uc1:MsgBox ID="MessageBox" runat="server" />--%>
                    </div>
                </td>
            </tr>
        </table>
        <ajx:ModalPopupExtender ID="mpeRoomType" runat="server" TargetControlID="hfRoomType"
            PopupControlID="pnlRoomType" BackgroundCssClass="mod_background" CancelControlID="btnCancel">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hfRoomType" runat="server" />
        <asp:Panel ID="pnlRoomType" runat="server" Style="display: none; width:650px;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="ltrHeaderRoomListTitle" runat="server" Text="Room List"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" border="0" width="100%">
                        <tr>
                            <td width="75px">
                                Departure
                            </td>
                            <td width="190px">
                                :&nbsp;&nbsp;<asp:Label ID="lblDepartureDate" runat="server"></asp:Label>
                            </td>
                            <td colspan="2">
                                Adt :&nbsp;&nbsp;
                                <asp:Label ID="lblAdult" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                Child :&nbsp;&nbsp;
                                <asp:Label ID="lblChild" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Agent
                            </td>
                            <td>
                                :&nbsp;&nbsp;
                            </td>
                            <td width="50px">
                                Rate
                            </td>
                            <td>
                                :&nbsp;&nbsp;General Family
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
                                        <asp:Literal ID="ltrRoomList" runat="server" Text="Room List"></asp:Literal>
                                    </span>
                                </div>
                                <div class="clear">
                                </div>
                                <div class="box_content">
                                    <asp:GridView ID="gvRooms" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                        Width="100%" OnRowCommand="gvRooms_RowCommand" OnRowDataBound="gvRooms_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSrNo" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrRoom" runat="server" Text="Room"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkbtnRoom" Text='<%#DataBinder.Eval(Container.DataItem, "Room")%>'
                                                        runat="server" OnClientClick="fnDisplayCatchErrorMessage()" CommandName="ROOM" CommandArgument='<%# Container.DataItemIndex %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrBed" runat="server" Text="Bed#"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBed" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Bed")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrWingFloor" runat="server" Text="Wing/Floor"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblWingFloor" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "WingFloor")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Right" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrAdult" runat="server" Text="Adult"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAdult" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Adult")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrChild" runat="server" Text="Child"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblChild" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Child")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Right" ItemStyle-Width="75px" ItemStyle-HorizontalAlign="Right">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrEstCost" runat="server" Text="Est. Cost"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEstCost" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "EstCost")%>'></asp:Label>
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
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                <asp:Button ID="btnCancel" runat="server" CausesValidation="false" Text="Cancel"
                                    Style="display: inline;" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpeConfirmDelete" runat="server" TargetControlID="hdnConfirmDelete"
            PopupControlID="pnlDeleteData" BackgroundCssClass="mod_background" CancelControlID="btnCancelDelete"
            BehaviorID="mpeConfirmDelete">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnConfirmDelete" runat="server" />
        <asp:Panel ID="pnlDeleteData" runat="server" Width="325px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="ltrHeaderConfirmDeletePopup" runat="server"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td align="center" style="padding-bottom: 15px;">
                                <asp:Literal ID="ltrConfirmDeleteMsg" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnYes" runat="server" Style="display: inline; padding-right: 10px;"
                                    OnClientClick="fnDisplayCatchErrorMessage();" />
                                <asp:Button ID="btnCancelDelete" runat="server" Style="display: inline;" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updWalkIn" ID="UpdPrgrsWalkIn" runat="server">
    <ProgressTemplate>
        <div id="progressBackgroundFilter">
        </div>
        <div id="processMessage">
            <center>
                <img src="../../images/ajax-loader.gif" /></center>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
