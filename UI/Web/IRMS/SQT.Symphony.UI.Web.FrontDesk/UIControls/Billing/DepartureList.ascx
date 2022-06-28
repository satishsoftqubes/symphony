<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DepartureList.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Billing.DepartureList" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<link type="text/css" href="../../Styles/jquery-ui-1.8.5.custom.css" rel="stylesheet" />
<script type="text/javascript" src="../../Scripts/jquery-1.4.2.min.js"></script>
<script type="text/javascript" src="../../Scripts/jquery-ui-1.8.5.custom.min.js"></script>
<script type="text/javascript">
    function pageLoad(sender, args) {
        var v1 = '<%=ConfigurationManager.AppSettings["IsUpperCase"].ToString() %>'
        if (v1 == "1") {
            $('input[type="text"],textarea').each(function () { $(this).css("text-transform", "uppercase") });
        }
    }

    function fnConfirmDelete(id) {

        document.getElementById('errormessage').style.display = "block";
        document.getElementById('<%= hdnConfirmDelete.ClientID %>').value = id;
        $find('mpeConfirmDelete').show();
        return false;
    }
</script>
<asp:UpdatePanel ID="updDepatureList" runat="server">
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
                                <asp:Literal ID="litgvhdDepartureList" runat="server" Text="Departure List"></asp:Literal>
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
                                            <td colspan="8">
                                                <asp:RadioButtonList ID="rblList" runat="server" RepeatDirection="Horizontal" Width="30%">
                                                    <asp:ListItem Selected="True" Text="Today" Value="Day"></asp:ListItem>
                                                    <asp:ListItem Text="Week" Value="Week"></asp:ListItem>
                                                    <asp:ListItem Text="Month" Value="Month"></asp:ListItem>
                                                    <asp:ListItem Text="All" Value="All"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="50px">
                                                <asp:Literal ID="litSearchName" runat="server" Text="Name"></asp:Literal>
                                            </td>
                                            <td width="170px">
                                                <asp:TextBox ID="txtSearchName" runat="server" Style="width: 140px !important;" SkinID="searchtextbox"></asp:TextBox>
                                            </td>
                                            <td width="65px">
                                                <asp:Literal ID="litSearchMobile" runat="server" Text="Mobile No."></asp:Literal>
                                            </td>
                                            <td width="170px">
                                                <asp:TextBox ID="txtMobileNo" runat="server" Style="width: 140px !important;" SkinID="searchtextbox"></asp:TextBox>
                                            </td>
                                            <td width="65px">
                                                <asp:Literal ID="litSearcReservationNo" runat="server" Text="Booking #"></asp:Literal>
                                            </td>
                                            <td width="170px">
                                                <asp:TextBox ID="txtSearcReservationNo" runat="server" Style="width: 140px !important;"
                                                    SkinID="searchtextbox"></asp:TextBox>
                                                <ajx:FilteredTextBoxExtender ID="fteSearcReservationNo" runat="server" TargetControlID="txtSearcReservationNo"
                                                    FilterMode="ValidChars" ValidChars="0123456789">
                                                </ajx:FilteredTextBoxExtender>
                                            </td>
                                            <td width="65px">
                                                <asp:Literal ID="litSearchUnitNo" runat="server" Text="Room No."></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtSearchRoomNo" runat="server" Style="width: 120px !important;"
                                                    SkinID="searchtextbox"></asp:TextBox>
                                                <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                    ToolTip="Search" Style="border: 0px; margin: -4px 0 0 5px; vertical-align: middle;"
                                                    OnClick="btnSearch_Click" />
                                                <asp:ImageButton ID="imgbtnClearSearch" runat="server" ImageUrl="~/images/clearsearch.png"
                                                    ToolTip="Clear" Style="border: 0px; vertical-align: middle; margin: -2px 0 0 10px;"
                                                    OnClick="imgbtnClearSearch_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="8">
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="8">
                                                <div class="box_head">
                                                    <span>
                                                        <asp:Literal ID="litDepartureList" runat="server" Text="Departure List"></asp:Literal>
                                                    </span>
                                                </div>
                                                <div class="clear">
                                                </div>
                                                <div class="box_content">
                                                    <asp:GridView ID="gvDepartureList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                        Width="100%" OnRowCommand="gvDepartureList_RowCommand" OnRowDataBound="gvDepartureList_RowDataBound"
                                                        OnPageIndexChanging="gvDepartureList_PageIndexChanging">
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
                                                                        CommandName="CHECKOUT" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ReservationID")%>'></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrGuestName" runat="server" Text="Name"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkGuestName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "GuestFullName")%>'
                                                                        CommandName="CHECKOUT" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ReservationID")%>'></asp:LinkButton>
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
                                                            <asp:TemplateField ItemStyle-Width="125px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrRateCardType" runat="server" Text="Rate Card Name"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "RateCardName")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrUnitType" runat="server" Text="Room Type"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "RoomTypeName")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrUnitNo" runat="server" Text="Room No."></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGvRoomNo" runat="server"></asp:Label>
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
                                                            <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrBalance" runat="server" Text="Balance"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGvBalance" runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrCheckOutNote" runat="server" Text="Note"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGvCheckOutNote" runat="server" Font-Bold="true" ForeColor="Blue"
                                                                        Text='<%# DataBinder.Eval(Container.DataItem, "CheckOutNote")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <EmptyDataTemplate>
                                                            <div style="padding: 10px;">
                                                                <b>
                                                                    <asp:Label ID="lblNoRecordFoundForRoomReservation" runat="server" Text="No Record Found."></asp:Label>
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
        <ajx:ModalPopupExtender ID="mpeConfirmDelete" runat="server" TargetControlID="hdnConfirmDelete"
            PopupControlID="pnlDeleteData" BackgroundCssClass="mod_background" CancelControlID="btnCancelDelete"
            BehaviorID="mpeConfirmDelete">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnConfirmDelete" runat="server" />
        <asp:Panel ID="pnlDeleteData" runat="server" Height="350px" Width="325px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="ltrHeaderConfirmDeletePopup" runat="server" Text="Information"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td align="center" style="padding-bottom: 15px;">
                                <asp:Label ID="lblConfirmDeleteMessage" runat="server" Text="Please check out cash card before you going to check out the reservation."></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnYes" runat="server" Style="display: inline; padding-right: 10px;"
                                    OnClick="btnYes_Click" Text="Ok" />
                                <asp:Button ID="btnCancelDelete" runat="server" Style="display: inline;" Text="Cancel" />
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
<asp:UpdateProgress AssociatedUpdatePanelID="updDepatureList" ID="UpdateProgressDepatureList"
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
