<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlTroubleTicket.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Guest.CtrlTroubleTicket" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script src="../../Scripts/jquery-1.8.2.js"></script>
<script src="../../Scripts/jquery-ui.js"></script>
<script type="text/javascript">
    function pageLoad(sender, args) {
        var v1 = '<%=ConfigurationManager.AppSettings["IsUpperCase"].ToString() %>'
        if (v1 == "1") {
            $('input[type="text"],textarea').each(function () { $(this).css("text-transform", "uppercase") });
        }
    }

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<asp:UpdatePanel ID="updTroubleTicket" runat="server">
    <ContentTemplate>
        <asp:MultiView ID="mvTicket" runat="server">
            <asp:View ID="vMessageList" runat="server">
                <div class="box_col1">
                    <div class="box_head">
                        <span>
                            <asp:Literal ID="litTroubleTicketHeader" runat="server" Text="Trouble Ticket"></asp:Literal></span></div>
                    <div class="clear">
                    </div>
                    <div class="box_form">
                        <table cellpadding="2" cellspacing="2" width="100%">
                            <tr>
                                <td>
                                    <asp:Literal ID="litSearchGuestName" runat="server" Text="Name"></asp:Literal>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSearchGuestName" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Literal ID="litSearchRoomNo" runat="server" Text="Room No."></asp:Literal>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSearchRoomNo" runat="server"></asp:TextBox>
                                    <asp:ImageButton ID="btnSearch" runat="server" ToolTip="Search" ImageUrl="~/images/search-icon.png"
                                        Style="border: 0px; margin: -4px 0 0 5px; vertical-align: middle;" OnClick="btnSearch_Click" />
                                    <asp:ImageButton ID="imgbtnClearSearch" runat="server" ToolTip="Clear" ImageUrl="~/images/clearsearch.png"
                                        Style="border: 0px; vertical-align: middle; margin: 0 0 0 10px;" OnClick="imgbtnClearSearch_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <hr />
                                </td>
                            </tr>
                            <tr>
                                <td style="vertical-align: top; height: 200px; overflow: auto;" colspan="4">
                                    <table width="100%" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="vertical-align: top;">
                                                <div class="box_head">
                                                    <span>
                                                        <asp:Literal ID="Literal1" runat="server" Text="Guest List"></asp:Literal>
                                                    </span>
                                                </div>
                                                <div class="clear">
                                                </div>
                                                <div class="box_content">
                                                    <asp:GridView ID="gvReservationList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                        Width="100%" OnRowCommand="gvReservationList_RowCommand" OnPageIndexChanging="gvReservationList_PageIndexChanging">
                                                        <Columns>
                                                            <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrMoveUnitSrNo" runat="server" Text="No."></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrBookingNo" runat="server" Text="Booking #"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkGuestName" runat="server" CommandName="TICKET" CommandArgument='<%#Eval("ReservationNo") + "," +Eval("GuestFullName")+","+Eval("ReservationID")+","+Eval("GuestID") +","+Eval("RoomID")%>'
                                                                        Text=' <%#DataBinder.Eval(Container.DataItem, "ReservationNo")%>'></asp:LinkButton>
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
                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrMobileNo" runat="server" Text="Mobile No."></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "Phone1")%>
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
                    <div class="clear">
                    </div>
                </div>
            </asp:View>
            <asp:View ID="vGenerateTicket" runat="server">
                <div class="box_col1">
                    <div class="box_head">
                        <span>
                            <asp:Literal ID="litMessageHeader" runat="server" Text="Generate Trouble Ticket"></asp:Literal></span></div>
                    <div class="clear">
                    </div>
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
                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                            <tr>
                                <td style="border: 1px solid #ccccce;">
                                    <table width="100%" cellpadding="2" cellspacing="2">
                                        <tr>
                                            <td width="60px">
                                                Booking #
                                            </td>
                                            <td width="150px">
                                                <asp:Literal ID="ltrChkPmtReservationNo" runat="server" Text="RES#323"></asp:Literal>
                                            </td>
                                            <td width="70px">
                                                Guest Name
                                            </td>
                                            <td width="150px">
                                                <asp:Literal ID="ltrChkPmtGuestName" runat="server" Text="MR. TEST TEST"></asp:Literal>
                                            </td>
                                            <td width="50px">
                                                Check In
                                            </td>
                                            <td width="100px">
                                                <asp:Literal ID="ltrChkPmtCheckInDate" runat="server" Text="16-03-2013"></asp:Literal>
                                            </td>
                                            <td width="50px">
                                                Check Out
                                            </td>
                                            <td width="100px">
                                                <asp:Literal ID="ltrChkPmtCheckOutDate" runat="server" Text="23-03-2013"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Rate Card
                                            </td>
                                            <td>
                                                <asp:Literal ID="ltrChkPmtRateCard" runat="server" Text="RC With Tax"></asp:Literal>
                                            </td>
                                            <td>
                                                Room Type
                                            </td>
                                            <td>
                                                <asp:Literal ID="ltrChkPmtRoomType" runat="server" Text="Standard-Double Share "></asp:Literal>
                                            </td>
                                            <td>
                                                Room No.
                                            </td>
                                            <td>
                                                <asp:Literal ID="ltrChkPmtRoomNo" runat="server" Text="A-001(i)"></asp:Literal>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <hr />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                        <tr>
                                            <td>
                                                <b><asp:Literal ID="litTicketTitle" runat="server" Text="Title"></asp:Literal></b>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTicketTitle" runat="server"></asp:TextBox>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rfvTicketTitle" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                        runat="server" ControlToValidate="txtTicketTitle" Display="Dynamic" ValidationGroup="GenerateTicket">
                                                    </asp:RequiredFieldValidator>
                                                </span>
                                            </td>
                                            <td style="display: none">
                                                <asp:Literal ID="litTicketType" runat="server" Text="Ticket Type"></asp:Literal>
                                            </td>
                                            <td style="display: none">
                                                <asp:DropDownList ID="ddlTicketType" runat="server">
                                                    <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                    <asp:ListItem Text="Type 1" Value="Type 1"></asp:ListItem>
                                                    <asp:ListItem Text="Type 2" Value="Type 2"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="isrequire">
                                                <asp:Literal ID="litPriority" runat="server" Text="Priority"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlPriority" runat="server">
                                                </asp:DropDownList>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" InitialValue="00000000-0000-0000-0000-000000000000"
                                                        SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                        ValidationGroup="GenerateTicket" ControlToValidate="ddlPriority" Display="Dynamic">
                                                    </asp:RequiredFieldValidator>
                                                </span>
                                            </td>
                                            <td class="isrequire">
                                                <asp:Literal ID="litTicketDepartment" runat="server" Text="Department"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlDepartment" runat="server">
                                                </asp:DropDownList>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rvfDepartment" InitialValue="00000000-0000-0000-0000-000000000000"
                                                        SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                        ValidationGroup="GenerateTicket" ControlToValidate="ddlDepartment" Display="Dynamic">
                                                    </asp:RequiredFieldValidator>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" class="isrequire">
                                                <asp:Literal ID="litMessage" runat="server" Text="Message"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTicketComplain" runat="server" TextMode="MultiLine" Style="width: 400px !important;"></asp:TextBox>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rfvMessage" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                        runat="server" ValidationGroup="GenerateTicket" ControlToValidate="txtTicketComplain"
                                                        Display="Dynamic">
                                                    </asp:RequiredFieldValidator>
                                                </span>
                                            </td>
                                            <td>
                                                <asp:Literal ID="litTicketReqby" runat="server" Text="Request By"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTicketRequestBy" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <div style="width: auto; display: inline-block; text-align: center;">
                                        <asp:Button ID="btnTicketCancel" runat="server" Text="Cancel" Style="float: right;
                                            margin-left: 5px;" OnClick="btnCloseTicketCancel_Click" />
                                        <asp:Button ID="btnTicketSave" runat="server" Text="Save" Style="float: right; margin-left: 5px;"
                                            ValidationGroup="GenerateTicket" OnClick="btnTicketSave_Click" />
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
    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updTroubleTicket" ID="UpdateProgressTroubleTicket"
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
