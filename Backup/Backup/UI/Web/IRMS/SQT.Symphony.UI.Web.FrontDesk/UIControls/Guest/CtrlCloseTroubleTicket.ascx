<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCloseTroubleTicket.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Guest.CtrlCloseTroubleTicket" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script src="../../Scripts/jquery-1.8.2.js"></script>
<script src="../../Scripts/jquery-ui.js"></script>
<script type="text/javascript" language="javascript">
    function pageLoad(sender, args) {
        var v1 = '<%=ConfigurationManager.AppSettings["IsUpperCase"].ToString() %>'
        if (v1 == "1") {
            $('input[type="text"],textarea').each(function () { $(this).css("text-transform", "uppercase") });
        }
    }
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }
</script>
<asp:UpdatePanel ID="updCloseTicket" runat="server">
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
                                <asp:Literal ID="litCloseTicket" runat="server" Text="Ticket List"></asp:Literal>
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
                                            <asp:Label ID="lblTicketMsg" runat="server"></asp:Label></div>
                                        <div style="height: 10px;">
                                        </div>
                                    </div>
                                    <% }%>
                                    <table cellpadding="2" cellspacing="2" width="100%">
                                        <tr>
                                            <td colspan="2">
                                                <asp:RadioButtonList ID="rblList" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                                                    OnSelectedIndexChanged="rblList_OnSelectedIndexChanged">
                                                    <asp:ListItem Selected="True" Text="Open" Value="Open"></asp:ListItem>
                                                    <asp:ListItem Text="Close" Value="Close"></asp:ListItem>
                                                    <asp:ListItem Text="All" Value="All"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td>
                                                <asp:Literal ID="litSearchTitle" runat="server" Text="Title"></asp:Literal>
                                            </td>
                                            <td colspan="5">
                                                <asp:TextBox ID="txtSearchTitle" runat="server"></asp:TextBox>
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
                                                <asp:Literal ID="litSearchDepartment" runat="server" Text="Department"></asp:Literal>
                                            </td>
                                            <td width="170px">
                                                <asp:DropDownList ID="ddlDepartment" Style="width: 140px !important;" runat="server">
                                                </asp:DropDownList>
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
                                                <asp:Literal ID="litSearchPriority" runat="server" Text="Priority"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlPriority" runat="server" Style="width: 120px !important;">
                                                </asp:DropDownList>
                                                <asp:ImageButton ID="btnSearch" runat="server" ToolTip="Search" ImageUrl="~/images/search-icon.png"
                                                    Style="border: 0px; margin: -4px 0 0 5px; vertical-align: middle;" OnClick="btnSearch_Click" />
                                                <asp:ImageButton ID="imgbtnClearSearch" runat="server" ToolTip="Clear" ImageUrl="~/images/clearsearch.png"
                                                    Style="border: 0px; vertical-align: middle; margin: 0 0 0 10px;" OnClick="imgbtnClearSearch_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="8">
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: top; height: 200px; overflow: auto;" colspan="8">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td style="vertical-align: top;">
                                                            <div class="box_head">
                                                                <span>
                                                                    <asp:Literal ID="Literal1" runat="server" Text="Ticket List"></asp:Literal>
                                                                </span>
                                                            </div>
                                                            <div class="clear">
                                                            </div>
                                                            <div class="box_content">
                                                                <asp:GridView ID="gvTicketList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                    Width="100%" OnRowCommand="gvTicketList_RowCommand" OnRowDataBound="gvTicketList_RowDataBound">
                                                                    <Columns>
                                                                        <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrTicketSrNo" runat="server" Text="No."></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <%# Container.DataItemIndex + 1 %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrTitle" runat="server" Text="Title"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkTitle" runat="server" CommandName="TICKET" CommandArgument='<%#Eval("TicketRequestBy") + "," +Eval("CreatedOn")+","+Eval("Description")%>'
                                                                                    Text=' <%#DataBinder.Eval(Container.DataItem, "Title")%>'></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
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
                                                                                <%#DataBinder.Eval(Container.DataItem, "GuestFullName")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrRoomNo" runat="server" Text="Room No."></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblGvRoomNo" runat="server" Text='<%#GetFormatedRoomNumber(Eval("RoomNo")) %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="110px" ItemStyle-HorizontalAlign="Left">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrDepartment" runat="server" Text="Department"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <%#DataBinder.Eval(Container.DataItem, "DepartmentName")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="55px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrPriority" runat="server" Text="Priority"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <%#DataBinder.Eval(Container.DataItem, "Priority")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="55px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrStatus" runat="server" Text="Status"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <%#DataBinder.Eval(Container.DataItem, "TicketStatus")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrClosedDate" runat="server" Text="Close date"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblGvClosedDate" runat="server"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblActions" runat="server" Text="Action"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPopUp" runat="server" Text="Actions"></asp:Label>
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
                                                                                                            <asp:LinkButton ID="lnkAction" Style="background: none !important; border: none;"
                                                                                                                runat="server" ToolTip="Close Ticket" CommandName="CLOSETICKET" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "TicketID")%>'><img src="../../images/file.png" /></asp:LinkButton>
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
                                                </table>
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
        <div id="errormessage" class="clear">
            <uc1:MsgBox ID="MessageBox" runat="server" />
        </div>
        <ajx:ModalPopupExtender ID="mpeCloseTicket" runat="server" TargetControlID="hdnCloseTicket"
            PopupControlID="pnlhdnCloseTicket" BackgroundCssClass="mod_background" CancelControlID="imgCloseTicketForpopup">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnCloseTicket" runat="server" />
        <asp:Panel ID="pnlhdnCloseTicket" runat="server" Width="600px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <div style="display: inline;">
                        <span>
                            <asp:Literal ID="lithdMassege" runat="server" Text="Close Ticket"></asp:Literal>
                        </span>
                    </div>
                    <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                        <asp:ImageButton ID="imgCloseTicketForpopup" runat="server" ImageUrl="~/images/closepopup.png"
                            Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;" />
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table border="0" cellpadding="2" cellspacing="2" width="100%">
                        <tr style="display: none;">
                            <td class="isrequire">
                                <asp:Literal ID="litCloseDate" runat="server" Text="Close date"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCloseDate" runat="server" onkeypress="return false;"></asp:TextBox>
                                <asp:Image ID="imgCloseDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                    Height="20px" Width="20px" />
                                <ajx:CalendarExtender ID="CalendarExtender1" PopupButtonID="imgCloseDate" TargetControlID="txtCloseDate"
                                    runat="server" Format="dd-MM-yyyy">
                                </ajx:CalendarExtender>
                                <img src="../../images/clear.png" id="imgDD" style="vertical-align: middle;" title="Clear Date"
                                    onclick="fnClearDate('<%= txtCloseDate.ClientID %>');" />
                                <span>
                                    <asp:RequiredFieldValidator ID="rfvCloseDate" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                        runat="server" ValidationGroup="IsRequire" ControlToValidate="txtCloseDate" Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="vertical-align: top;" class="isrequire">
                                <asp:Literal ID="litRemarks" runat="server" Text="Remarks"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtRemarks" Style="width: 420px; height: 74px;" runat="server" TextMode="MultiLine"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rvfMassege" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                        runat="server" ValidationGroup="IsRequireCloseTicket" ControlToValidate="txtRemarks"
                                        Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <div style="display: inline-block;">
                                    <asp:Button ID="btnCloseTicketSave" runat="server" CausesValidation="true" Text="Save"
                                        ImageUrl="~/images/save.png" Style="float: right; margin-left: 5px;" ValidationGroup="IsRequireCloseTicket"
                                        OnClick="btnCloseTicketSave_Click" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpeTicketInfo" runat="server" TargetControlID="hdnTicketinfo"
            PopupControlID="pnlTicketInfo" BackgroundCssClass="mod_background" CancelControlID="imgTicketInfoClose">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnTicketinfo" runat="server" />
        <asp:Panel ID="pnlTicketInfo" runat="server" Width="600px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <div style="display: inline;">
                        <span>
                            <asp:Literal ID="litTicketInfo" runat="server" Text="Ticket Information"></asp:Literal>
                        </span>
                    </div>
                    <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                        <asp:ImageButton ID="imgTicketInfoClose" runat="server" ImageUrl="~/images/closepopup.png"
                            Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;" />
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table border="0" cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td class="isrequire">
                                <asp:Literal ID="litTicketCreatedDate" runat="server" Text="Created Date"></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="litViewTicketCreatedDate" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td style="vertical-align: top;" class="isrequire">
                                <asp:Literal ID="litviewTicketDesc" runat="server" Text="Description"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtViewDesc" Style="width: 420px; height: 74px;" runat="server"
                                    TextMode="MultiLine" Enabled="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire">
                                <asp:Literal ID="litTicketReqby" runat="server" Text="Request By"></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="litViewTicketreqBy" runat="server"></asp:Literal>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdateProgress AssociatedUpdatePanelID="updCloseTicket" ID="UpdateCloseTicket"
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
