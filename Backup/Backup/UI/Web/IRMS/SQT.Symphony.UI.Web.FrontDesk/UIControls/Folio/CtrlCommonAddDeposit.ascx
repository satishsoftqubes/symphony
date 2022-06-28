<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCommonAddDeposit.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Folio.CtrlCommonAddDeposit" %>
    <%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<asp:MultiView ID="mvDeposit" runat="server">
    <asp:View ID="vReservationList" runat="server">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="content">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                <asp:Literal ID="litMainHeader" runat="server" Text="Reservations"></asp:Literal>
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
                                    <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                        <tr>
                                            <td width="90px">
                                                <asp:Literal ID="litSearchName" runat="server" Text="Name"></asp:Literal>
                                            </td>
                                            <td width="240px">
                                                <asp:TextBox ID="txtSearchName" runat="server" Style="width: 140px !important;" SkinID="searchtextbox"></asp:TextBox>
                                            </td>
                                            <td width="90px">
                                                <asp:Literal ID="litSearcBookingNo" runat="server" Text="Booking #"></asp:Literal>
                                            </td>
                                            <td width="240px">
                                                <asp:TextBox ID="txtSearcBookingNo" runat="server" Style="width: 140px !important;"
                                                    SkinID="searchtextbox"></asp:TextBox>
                                            </td>
                                            <td width="90px">
                                                <asp:Literal ID="litSearchUnitNo" runat="server" Text="Room No."></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtSearchUnitNo" runat="server" Style="width: 120px !important;"
                                                    SkinID="searchtextbox"></asp:TextBox>
                                                <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                    Style="border: 0px; margin: -4px 0 0 5px; vertical-align: middle;" />
                                                <asp:ImageButton ID="imgbtnClearSearch" runat="server" ImageUrl="~/images/clearsearch.png"
                                                    Style="border: 0px; vertical-align: middle; margin: 0 0 0 10px;" />
                                                <%--<asp:ImageButton ID="imgbtnAdvanceSearch" runat="server" ToolTip="Advance Search"
                                                    ImageUrl="~/images/clearsearch.png" Style="border: 0px; vertical-align: middle;
                                                    margin: 0 0 0 10px;" />--%>
                                            </td>
                                        </tr>
                                    </table>                                    
                                    <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                        <tr>
                                            <td colspan="6">
                                                <hr />
                                            </td>
                                        </tr>                                        
                                        <tr>
                                            <td colspan="6">
                                                <div class="box_head">
                                                    <span>
                                                        <asp:Literal ID="litRoomReservationList" runat="server" Text="Reservations"></asp:Literal>
                                                    </span>
                                                </div>
                                                <div class="clear">
                                                </div>
                                                <div class="box_content">
                                                    <asp:GridView ID="gvRoomReservationList" runat="server" AutoGenerateColumns="false"
                                                        ShowHeader="true" Width="100%" OnRowCommand="gvRoomReservationList_RowCommand">
                                                        <Columns>
                                                            <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrStatus" runat="server" Text="Status"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "Status")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrBookingNo" runat="server" Text="Booking #"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "ReservationNo")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrGuestName" runat="server" Text="Name"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "GuestName")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrChildAdult" runat="server" Text="Child/Adult"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "Child")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrBlockName" runat="server" Text="Block Name"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "BlockName")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrUnitNo" runat="server" Text="Room No."></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "RoomNo")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrUnitType" runat="server" Text="Room Type"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "RoomType")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="180px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrArrivalDepature" runat="server" Text="Check In - Check Out"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "Date")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrPayment" runat="server" Text="Payment"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "Payment")%>
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
                                                                                                <asp:LinkButton style="background:none !important; border:none;" ID="lnkEdit" runat="server" ToolTip="Deposit" CommandName="DEPOSIT"><img src="../../images/edit.png" /></asp:LinkButton>
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
                    </div>
                </td>
            </tr>
        </table>
    </asp:View>
    <asp:View ID="vAddDeposit" runat="server">
        <div class="box_col1">
            <div class="box_head">
                <span>
                    <asp:Literal ID="ltrHeaderAddGuest" runat="server" Text="Add Deposit"></asp:Literal></span></div>
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
                                        <asp:Literal ID="litDeposit" runat="server" Text="Deposit"></asp:Literal>
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
                                        <asp:Literal ID="litPayment" runat="server" Text="Payment"></asp:Literal>
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
                                        <asp:Literal ID="litAmount" runat="server" Text="Amount"></asp:Literal>
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
                                            <%--<asp:RegularExpressionValidator ID="revVoucherNo" SetFocusOnError="True" runat="server"
                                ValidationGroup="IsRequire1" ControlToValidate="txtAmount" Display="Dynamic"
                                ForeColor="Red" ValidationExpression="\\d{0,24}.\\d{0,2}"  ErrorMessage="2 digits allow after decimal point."></asp:RegularExpressionValidator>--%>
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
                                <asp:Button ID="btnCancel" runat="server" CausesValidation="false" ImageUrl="~/images/cancle.png"
                                    Style="float: right; margin-left: 5px;" Text="Cancel" OnClick="btnCancel_OnClick" />
                                <asp:Button ID="btnSaveDeposit" runat="server" Text="Save" ImageUrl="~/images/save.png"
                                    Style="float: right; margin-left: 5px;" />
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
