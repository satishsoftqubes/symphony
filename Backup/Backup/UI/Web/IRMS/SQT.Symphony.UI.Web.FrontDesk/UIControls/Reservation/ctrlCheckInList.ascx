<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlCheckInList.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation.ctrlCheckInList" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script src="../../Scripts/jquery-1.8.2.js"></script>
<script src="../../Scripts/jquery-ui.js"></script>
<style type="text/css">
    .container
    {
        margin: 0;
        width: 800px;
    }
    .item
    {
        float: left;
        width: 113px;
        height: 40px;
    }
    .clear
    {
        clear: both;
        width: 100%;
        height: 1px;
    }
</style>
<script type="text/javascript">
    function fnCheckStatus(checkbox, status) {

        var confirmed = document.getElementById('<%=chkConfirmed.ClientID %>');
        var provisional = document.getElementById('<%=chkProvisional.ClientID %>');
        var waitingList = document.getElementById('<%=chkWaitingList.ClientID %>');
        var all = document.getElementById('<%=chkAll.ClientID %>');

        if (status == 'ALL') {
            if (checkbox.checked) {
                confirmed.checked = provisional.checked = waitingList.checked = false;
            }
        }
        else if (status == 'CONFIRMED') {
            all.checked = false;
        }
        else if (status == 'PROVISIONAL') {
            all.checked = false;
        }
        else if (status == 'WAITINGLIST') {
            all.checked = false;
        }
    }
    function openReservationVoucher() {
        var hdnReservationID = document.getElementById('<%= hdnReservationID.ClientID %>').value;
        window.open("RegistrationVoucher.aspx?id=" + hdnReservationID + "&Operation=yes", "RegistrationVoucher", "height=600,width=750,status=1,toolbar=no,menubar=no,scrollbars=1,location=0");
    }
</script>
<asp:UpdatePanel ID="updCheckInList" runat="server">
    <ContentTemplate>
        <asp:HiddenField ID="hdnReservationID" runat="server" />
        <asp:MultiView ID="mvCheckInForm" runat="server">
            <asp:View ID="vCheckInList" runat="server">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="content">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="boxtopleft">
                                        &nbsp;
                                    </td>
                                    <td class="boxtopcenter">
                                        <asp:Literal ID="litCheckInMainHeader" runat="server" Text="Arrival List"></asp:Literal>
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
                                            <%if (IsMessage)
                                              { %>
                                            <div class="ResetSuccessfully">
                                                <div style="float: left; padding-top: 7px; width: 25px; height: 24px; margin-right: 10px;">
                                                    <img src="../../images/success.png" />
                                                </div>
                                                <div>
                                                    <asp:Label ID="lblEmailMsg" runat="server"></asp:Label></div>
                                                <div style="height: 10px;">
                                                </div>
                                            </div>
                                            <% }%>
                                            <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                <tr>
                                                    <td colspan="3">
                                                        <asp:RadioButtonList ID="rblList" runat="server" OnSelectedIndexChanged="rblList_OnSelectedIndexChanged"
                                                            AutoPostBack="true" RepeatDirection="Horizontal">
                                                            <asp:ListItem Selected="True" Text="Today" Value="Day"></asp:ListItem>
                                                            <asp:ListItem Text="Week" Value="Week"></asp:ListItem>
                                                            <asp:ListItem Text="Month" Value="Month"></asp:ListItem>
                                                            <asp:ListItem Text="All" Value="All"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                    <td colspan="3" style="display: none;">
                                                        <asp:CheckBox ID="chkConfirmed" runat="server" Text="Confirmed" onclick="fnCheckStatus(this,'CONFIRMED')" />&nbsp;&nbsp;
                                                        <asp:CheckBox ID="chkProvisional" runat="server" Checked="false" Text="Provisional"
                                                            onclick="fnCheckStatus(this,'PROVISIONAL')" />&nbsp;&nbsp;
                                                        <asp:CheckBox ID="chkWaitingList" runat="server" Checked="false" Text="Waiting List"
                                                            onclick="fnCheckStatus(this,'WAITINGLIST')" />&nbsp;&nbsp;
                                                        <asp:CheckBox ID="chkAll" runat="server" Text="All" Checked="true" onclick="fnCheckStatus(this,'ALL')" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10px">
                                                        <asp:Literal ID="litSearchName" runat="server" Text="Name"></asp:Literal>
                                                    </td>
                                                    <td width="170px">
                                                        <asp:TextBox ID="txtSearchName" runat="server" Style="width: 180px !important;" SkinID="searchtextbox"></asp:TextBox>
                                                    </td>
                                                    <td width="50px">
                                                        <asp:Literal ID="litSearchMobile" runat="server" Text="Mobile No."></asp:Literal>
                                                    </td>
                                                    <td width="170px">
                                                        <asp:TextBox ID="txtMobileNo" runat="server" Style="width: 140px !important;" SkinID="searchtextbox"></asp:TextBox>
                                                    </td>
                                                    <td width="50px">
                                                        <asp:Literal ID="litSearcReservationNo" runat="server" Text="Booking #"></asp:Literal>
                                                    </td>
                                                    <td width="170px">
                                                        <asp:TextBox ID="txtSearcReservationNo" runat="server" Style="width: 140px !important;"
                                                            SkinID="searchtextbox"></asp:TextBox>
                                                        <ajx:FilteredTextBoxExtender ID="fteSearcReservationNo" runat="server" TargetControlID="txtSearcReservationNo"
                                                            FilterMode="ValidChars" ValidChars="0123456789">
                                                        </ajx:FilteredTextBoxExtender>
                                                        <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                            ToolTip="Search" Style="border: 0px; margin: -4px 0 0 5px; vertical-align: middle;"
                                                            OnClick="btnSearch_Click" />
                                                        <asp:ImageButton ID="imgbtnClearSearch" runat="server" ImageUrl="~/images/clearsearch.png"
                                                            ToolTip="Reset" Style="border: 0px; vertical-align: middle; margin: -3px 0 0 10px;"
                                                            OnClick="imgbtnClearSearch_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="6">
                                                        <hr />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="8">
                                                        <div class="box_head">
                                                            <span>
                                                                <asp:Literal ID="litRoomReservationList" runat="server" Text="Reservations"></asp:Literal>
                                                            </span>
                                                        </div>
                                                        <div class="clear">
                                                        </div>
                                                        <div class="box_content">
                                                            <asp:GridView ID="gvRoomReservationList" runat="server" AutoGenerateColumns="false"
                                                                ShowHeader="true" Width="100%" OnRowCommand="gvRoomReservationList_RowCommand"
                                                                OnRowDataBound="gvRoomReservationList_RowDataBound" DataKeyNames="Email" OnPageIndexChanging="gvRoomReservationList_PageIndexChanging">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%# Container.DataItemIndex + 1 %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrReservationNo" runat="server" Text="Booking #"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkReservationNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ReservationNo")%>'
                                                                                CommandName="CHECKIN" CommandArgument='<%#Eval("ReservationID")%>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="40px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrStatus" runat="server" Text="Status"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Image ID="imgReservationStatus" runat="server" Style="height: 20px; width: 20px;" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrGuestName" runat="server" Text="Name"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkGuestName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "GuestFullName")%>'
                                                                                CommandName="CHECKIN" CommandArgument='<%#Eval("ReservationID")%>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrMobileNo" runat="server" Text="Mobile No."></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvPhone" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="140px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrCompany" runat="server" Text="Company"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "CompanyName")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrRateCardType" runat="server" Text="Rate Card"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "RateCardName")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <%--<asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrRateCardNo" runat="server" Text="RC No."></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "Code")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>--%>
                                                                    <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrUnitNo" runat="server" Text="Room No."></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvRoomNo" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="150px" Visible="false" HeaderStyle-HorizontalAlign="Left"
                                                                        ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrUnitType" runat="server" Text="Room Type"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "RoomTypeName")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrCheckIn" runat="server" Text="Check In"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvCheckInDate" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "CheckInDate")).ToString(clsSession.DateFormat)%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrCheckOut" runat="server" Text="Check Out"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvCheckOutDate" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "CheckOutDate")).ToString(clsSession.DateFormat)%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrSpecificNote" runat="server" Text="Note"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvSpecificNote" runat="server" Font-Bold="true" ForeColor="Blue"  Text='<%# DataBinder.Eval(Container.DataItem, "SpecificNote")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblActions" runat="server" Text="Action"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblPopUp" runat="server" Text="Actions"></asp:Label>
                                                                            <ajx:HoverMenuExtender ID="hmeAction" runat="server" TargetControlID="lblPopUp" PopupControlID="pnlAction"
                                                                                PopupPosition="Left">
                                                                            </ajx:HoverMenuExtender>
                                                                            <asp:Panel ID="pnlAction" runat="server" Style="visibility: hidden; opacity: 100%">
                                                                                <div class="actionsbuttons_hovermenu">
                                                                                    <table border="0" cellpadding="0" cellspacing="0" class="actionsbuttons_hover_lettmenu_table">
                                                                                        <tr>
                                                                                            <td class="actionsbuttons_hover_lettmenu">
                                                                                            </td>
                                                                                            <td class="actionsbuttons_hover_centermenu">
                                                                                                <ul>
                                                                                                    <li>
                                                                                                        <asp:LinkButton Style="background: none !important; border: none;" ID="lnkReprintVoucher"
                                                                                                            runat="server" ToolTip="Reprint reservation voucher" CommandName="REPRINTRESERVATIONVOUCHER"
                                                                                                            CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ReservationID")%>'><img src="../../images/file.png" /></asp:LinkButton>
                                                                                                        <asp:LinkButton Style="background: none !important; border: none;" ID="lnkMailToGuest"
                                                                                                            runat="server" ToolTip="Email To Guest" CommandName="EMAILTOGUEST" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ReservationID")%>'><img src="../../images/file.png" /></asp:LinkButton>
                                                                                                        <asp:LinkButton Style="background: none !important; border: none;" ID="lnkMailToIR"
                                                                                                            runat="server" ToolTip="Email To IR" CommandName="EMAILTOIR" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ReservationID")%>'><img src="../../images/file.png" /></asp:LinkButton>
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
                                                                    <%--<asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
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
                                                                                                        <asp:LinkButton Style="background: none !important; border: none;" ID="lnkCheckIn"
                                                                                                            runat="server" ToolTip="Check In" CommandName="CHECKIN"><img src="../../images/edit.png" /></asp:LinkButton>
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
                                                                    </asp:TemplateField>--%>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <div style="padding: 10px;">
                                                                        <b>
                                                                            <asp:Label ID="lblNoRecordFound" runat="server" Text="No record found."></asp:Label>
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
        </asp:MultiView>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="gvRoomReservationList" />
    </Triggers>
</asp:UpdatePanel>
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updCheckInList" ID="UpdateProgressCheckInList"
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
