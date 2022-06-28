<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlRoomBookingList.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.Activity.CtrlRoomBookingList" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<style type="text/css">
    #progressBackgroundFilter
    {
        position: fixed;
        top: 0px;
        width: 100%;
        height: 100%;
        bottom: 0px;
        left: 0px;
        right: 0px;
        overflow: hidden;
        padding: 0;
        margin: 0;
        background-color: #000;
        filter: alpha(opacity=50);
        opacity: 0.5;
        z-index: 1111111;
    }
    #processMessage
    {
        position: fixed;
        top: 50%;
        left: 50%;
        padding: 10px;
        width: 30px;
        border-radius: 10px;
        z-index: 1111112;
        background-color: #fff;
        border: solid 1px #efefef;
    }
</style>
<asp:UpdatePanel ID="updReservationVoucherList" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height: 473px;">
            <tr>
                <td class="content" style="padding-left: 0px; width: 66.66%">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                COMPLEMENTORY RESERVATION VOUCHER
                            </td>
                            <td class="boxtopright">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="boxleft">
                                &nbsp;
                            </td>
                            <td>
                                <table cellpadding="2" cellspacing="0" border="0" width="100%">
                                    <tr>
                                        <td>
                                            <%if (IsInsert)
                                              { %>
                                            <div class="ResetSuccessfully">
                                                <div style="float: left; padding-top: 7px; width: 25px; height: 24px; margin-right: 10px;">
                                                    <img src="../../images/success.png" />
                                                </div>
                                                <div>
                                                    <asp:Label ID="lblResVoucherMsg" runat="server"></asp:Label></div>
                                                <div style="height: 10px;">
                                                </div>
                                            </div>
                                            <% }%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top">
                                            <table cellpadding="2" cellspacing="2" width="100%">
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="litSInvList" runat="server" Text="Investors"></asp:Literal>&nbsp;&nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlInvestor" runat="server" Style="width: 203px;">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="Literal1" runat="server" Text="Status"></asp:Literal>
                                                    </td>
                                                    <td style="width: 233px;">
                                                        <asp:DropDownList ID="ddlStatus" runat="server" Style="width: 150px;">
                                                            <asp:ListItem Text="-ALL-" Value="ALL"></asp:ListItem>
                                                            <asp:ListItem Text="APPROVED" Value="APPROVED" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="CANCELLED" Value="CANCELLED"></asp:ListItem>
                                                            <asp:ListItem Text="PROVISIONAL" Value="PROVISIONAL"></asp:ListItem>
                                                            <asp:ListItem Text="NOT AVAILABLE" Value="NOT AVAILABLE"></asp:ListItem>
                                                            <asp:ListItem Text="CONFIRMED" Value="CONFIRMED"></asp:ListItem>
                                                            <asp:ListItem Text="UTILIZED" Value="UTILIZED"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:ImageButton ID="btnSearch" Style="border: 0px; vertical-align: middle; margin-top: 0px;
                                                            margin-left: 5px;" runat="server" ImageUrl="~/images/search-icon.png" OnClick="btnSearch_Click"
                                                            OnClientClick="fnDisplayCatchErrorMessage()" />
                                                    </td>
                                                </tr>
                                            </table>
                                            <div class="pageinfodivider">
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" valign="middle">
                                            <asp:Button ID="btnAddTop" runat="server" Text="Add New" OnClick="btnAdd_Click" Style="float: right;"
                                                OnClientClick="fnDisplayCatchErrorMessage()" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dTableBox" style="padding: 10px 0px;">
                                            <style>
                                                .dTableBox td
                                                {
                                                    padding: 0px 3px;
                                                }
                                            </style>
                                            <asp:GridView ID="gvReservationVoucherList" runat="server" AutoGenerateColumns="False"
                                                Width="100%" CssClass="grid_content" OnPageIndexChanging="gvReservationVoucherList_PageIndexChanging"
                                                OnRowDataBound="gvReservationVoucherList_RowDatabound" DataKeyNames="PropertyID"
                                                OnRowCommand="gvReservationVoucherList_RowCommand">
                                                <Columns>
                                                    <asp:TemplateField ItemStyle-Width="65px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblGvHdrVoucherNo" runat="server" Text="Vou No."></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkVoucherNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "VoucherNo")%>'
                                                                CommandName="VOUCHERDETAIL" CommandArgument='<%#Eval("ResVoucherID")%>'></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblGvHdrInvName" runat="server" Text="Investor name"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblGvInvName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "InvFullName")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblGvHdrCreatedDate" runat="server" Text="Vou Date"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblGvCreatedDate" runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblGvHdrCheckIn" runat="server" Text="Check In"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblGvCheckInDate" runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblGvHdrCheckOut" runat="server" Text="Check Out"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblGvCheckOutDate" runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="35px" ItemStyle-HorizontalAlign="Left">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblGvhrrNoOfDays" runat="server" Text="Days"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblGvNoOfDays" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "TotalNights")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Left">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblGvHdrStatus" runat="server" Text="Status"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblGvStatus" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Status_Term")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="15px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="imgCheckRoomavail" ToolTip="Check Room availability" CommandName="CHECKROOMAVAILABILITY"
                                                                CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ResVoucherID")%>' runat="server"
                                                                ImageUrl="~/images/Investor.png" Style="border: 0px; vertical-align: middle;
                                                                margin-top: 3px; margin-right: 7px;" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="15px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="imgCancelres" ToolTip="Cancel" CommandName="CANCELVOUCHER" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ResVoucherID")%>'
                                                                runat="server" ImageUrl="~/images/CancelReservation.png" Style="border: 0px;
                                                                vertical-align: middle; margin-top: 3px; margin-right: 7px;" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EmptyDataTemplate>
                                                    <div style="padding: 10px;">
                                                        <b>
                                                            <asp:Label ID="lblGRNoRecordFound" runat="server" Text="No Record Found."></asp:Label>
                                                        </b>
                                                    </div>
                                                </EmptyDataTemplate>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td class="boxright">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="boxbottomleft">
                                &nbsp;
                            </td>
                            <td class="boxbottomcenter">
                                &nbsp;
                            </td>
                            <td class="boxbottomright">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <div class="clear_divider">
                    </div>
                </td>
            </tr>
        </table>
        <asp:HiddenField ID="hfDeletesure" runat="server" />
        <ajx:ModalPopupExtender ID="msgDelete" runat="server" TargetControlID="hfDeletesure"
            PopupControlID="pnlDeleteSure" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:Panel ID="pnlDeleteSure" runat="server">
            <div style="width: 500px; height: 200px; margin-top: 25px;">
                <table border="0" cellspacing="0" cellpadding="0" class="modelpopup_box">
                    <tr>
                        <td class="modelpopup_boxtopleft">
                            &nbsp;
                        </td>
                        <td class="modelpopup_boxtopcenter">
                            &nbsp;
                        </td>
                        <td class="modelpopup_boxtopright">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="modelpopup_boxleft">
                            &nbsp;
                        </td>
                        <td class="modelpopup_box_bg">
                            <div style="width: 100px; float: left; margin-top: 10px;">
                                <asp:HyperLink ID="CloseModelPopup" runat="server">
                                    <asp:Image ImageUrl="~/images/error.png" AlternateText="" Height="75px" Width="75px"
                                        ID="btnImage" runat="server" />
                                </asp:HyperLink>
                            </div>
                            <div style="float: left; width: 225px; margin-top: 40px; margin-left: 10px;">
                                <asp:Label ID="lblSureDelete" runat="server" Text="Sure you want to cancel?"></asp:Label>
                            </div>
                            <table cellpadding="3" cellspacing="3" width="100%" style="margin-left: 5px; margin-top: 15px;">
                                <tr>
                                    <td align="center" valign="middle">
                                        <div>
                                            <asp:Button ID="btnYesdelete" Text="Yes" runat="server" ImageUrl="~/images/save.png"
                                                OnClick="btnYesdelete_Click" Style="display: inline-block;" OnClientClick="fnDisplayCatchErrorMessage()" />
                                            <asp:Button ID="btnCancelmsgdelete" Text="Cancel" runat="server" ImageUrl="~/images/cancle.png"
                                                OnClick="btnCancelmsgdelete_Click" Style="display: inline-block;" OnClientClick="fnDisplayCatchErrorMessage()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="modelpopup_boxright">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="modelpopup_boxbottomleft">
                            &nbsp;
                        </td>
                        <td class="modelpopup_boxbottomcenter">
                        </td>
                        <td class="modelpopup_boxbottomright">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
        <asp:HiddenField ID="hfnVouDetail" runat="server" />
        <ajx:ModalPopupExtender ID="mpeVouDetails" runat="server" TargetControlID="hfnVouDetail"
            PopupControlID="pnlVouDetails" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:Panel ID="pnlVouDetails" runat="server">
            <div style="width: 429px; height: 260px; margin-top: 25px;">
                <table border="0" cellspacing="0" cellpadding="0" class="modelpopup_box">
                    <tr>
                        <td class="modelpopup_boxtopleft">
                            &nbsp;
                        </td>
                        <td class="modelpopup_boxtopcenter">
                            <asp:Label ID="litVoucherDetails" runat="server" Text="Voucher Details"></asp:Label>
                            <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                                <asp:ImageButton ID="imgCancelAddServices" runat="server" ImageUrl="~/images/closepopup.png"
                                    Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;" />
                        </td>
                        <td class="modelpopup_boxtopright">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="modelpopup_boxleft">
                            &nbsp;
                        </td>
                        <td class="modelpopup_box_bg">
                            <%--<div style="width: 100px; float: left; margin-top: 10px;">
                                <asp:HyperLink ID="HyperLink1" runat="server">
                                    <asp:Image ImageUrl="~/images/error.png" AlternateText="" Height="75px" Width="75px"
                                        ID="Image1" runat="server" />
                                </asp:HyperLink>
                            </div>--%>
                            <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                <tr>
                                    <td style="width: 200px">
                                        <asp:Label ID="litNoOfRooms" Font-Bold="true" runat="server" Text="No.Of Rooms"></asp:Label>
                                    </td>
                                    <td style="text-align: left; vertical-align: top">
                                        <asp:Label ID="litDispNoOfRooms" runat="server" Text="-"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="litPropertyName" Font-Bold="true" runat="server" Text="Property Name"></asp:Label>
                                    </td>
                                    <td style="text-align: left; vertical-align: top">
                                        <asp:Label ID="litDispPropertyName" runat="server" Text="-"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="litInvestor" Font-Bold="true" runat="server" Text="Investor Name"></asp:Label>
                                    </td>
                                    <td style="text-align: left; vertical-align: top">
                                        <asp:Label ID="litDispInvestor" runat="server" Text="-"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblComplementoryDays" Font-Bold="true" runat="server" Text="No Of Complementory Days"></asp:Label>
                                    </td>
                                    <td style="text-align: left; vertical-align: top">
                                        <asp:Label ID="lblDispComplementoryDays" runat="server" Text="-"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblCheckInDate" Font-Bold="true" runat="server" Text="CheckIn Date"></asp:Label>
                                    </td>
                                    <td style="text-align: left; vertical-align: top">
                                        <asp:Label ID="lblDispCheckInDate" runat="server" Text="-"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblCheckOutDate" Font-Bold="true" runat="server" Text="Checkout Date"></asp:Label>
                                    </td>
                                    <td style="text-align: left; vertical-align: top">
                                        <asp:Label ID="lblDispCheckOutDate" runat="server" Text="-"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbltotalNoofDays" Font-Bold="true" runat="server" Text="No Of Days"></asp:Label>
                                    </td>
                                    <td style="text-align: left; vertical-align: top">
                                        <asp:Label ID="lblDisptotalNoofDays" runat="server" Text="-"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="litInvestorGuestName" Font-Bold="true" runat="server" Text="Guest Name"></asp:Label>
                                    </td>
                                    <td style="text-align: left; vertical-align: top">
                                        <asp:Label ID="litDispInvestorGuestName" runat="server" Text="-"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblTotalGuest" Font-Bold="true" runat="server" Text="Total Guest"></asp:Label>
                                    </td>
                                    <td style="text-align: left; vertical-align: top">
                                        <asp:Label ID="lblDispTotalGuest" runat="server" Text="-"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="litNoOfAdult" Font-Bold="true" runat="server" Text="No.Of Adult"></asp:Label>
                                    </td>
                                    <td style="text-align: left; vertical-align: top">
                                        <asp:Label ID="litDispNoOfAdult" runat="server" Text="-"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="litNoOfChild" Font-Bold="true" runat="server" Text="No.Of Child"></asp:Label>
                                    </td>
                                    <td style="text-align: left; vertical-align: top">
                                        <asp:Label ID="litDispNoOfChild" runat="server" Text="-"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblDispNotes" runat="server" Font-Bold="true" Text="Notes"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDispNotes" runat="server" SkinID="Medium" TextMode="MultiLine"
                                            Height="60px" MaxLength="500" Enabled="false"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="modelpopup_boxright">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="modelpopup_boxbottomleft">
                            &nbsp;
                        </td>
                        <td class="modelpopup_boxbottomcenter">
                        </td>
                        <td class="modelpopup_boxbottomright">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updReservationVoucherList" ID="UpdateProgressVoucherList"
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
