<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCommonMessage.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls.CtrlCommonMessage" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<%--<ajx:ModalPopupExtender ID="mpeMessage" runat="server" TargetControlID="hdnMessage"
    PopupControlID="pnlMessage" BackgroundCssClass="mod_background" CancelControlID="btnMessageCancel">
</ajx:ModalPopupExtender>
<asp:HiddenField ID="hdnMessage" runat="server" />
<asp:Panel ID="pnlMessage" runat="server" Width="650px" Style="display: none;">
--%>
<script>
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<asp:MultiView ID="mvMessage" runat="server">
    <asp:View ID="vMessageList" runat="server">
        <div class="box_col1">
            <div class="box_head">
                <span>
                    <asp:Literal ID="litMoveUnitHeader" runat="server" Text="Message"></asp:Literal></span></div>
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
                            <asp:ImageButton ID="btnSearch" runat="server" OnClick="btnSearch_OnClick" ToolTip="Search"
                                ImageUrl="~/images/search-icon.png" Style="border: 0px; margin: -4px 0 0 5px;
                                vertical-align: middle;" />
                            <asp:ImageButton ID="imgbtnClearSearch" runat="server" OnClick="imgbtnClearSearch_OnClick"
                                ToolTip="Clear" ImageUrl="~/images/clearsearch.png" Style="border: 0px; vertical-align: middle;
                                margin: 0 0 0 10px;" />
                        </td>
                    </tr>
                    <tr id="trSrchRow2" runat="server" visible="false">
                        <td>
                            <asp:Literal ID="litSearchRoomType" runat="server" Text="Room Type"></asp:Literal>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSearchRoomType" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Literal ID="litSearchBookingNo" runat="server" Text="Booking #"></asp:Literal>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSearchBookingNo" runat="server"></asp:TextBox>
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
                                    <td width="50%" style="vertical-align: top;">
                                        <div class="box_head">
                                            <span>
                                                <asp:Literal ID="Literal1" runat="server" Text="Guest List"></asp:Literal>
                                            </span>
                                        </div>
                                        <div class="clear">
                                        </div>
                                        <div class="box_content">
                                            <asp:GridView ID="gvGuestList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                Width="100%" OnRowCommand="gvGuestList_RowCommand" OnPageIndexChanging="gvGuestList_PageIndexChanging">
                                                <Columns>
                                                    <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblGvHdrMoveUnitSrNo" runat="server" Text="No."></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblGvHdrGuestName" runat="server" Text="Name"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkGuestName" runat="server" CommandName="MESSAGE" CommandArgument='<%#Eval("ReservationNo") + "," +Eval("GuestFullName")+","+Eval("ReservationID")+","+Eval("GuestID")%>'
                                                                Text=' <%#DataBinder.Eval(Container.DataItem, "GuestFullName")%>'></asp:LinkButton>
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
                                                    <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblGvHdrRoomNo" runat="server" Text="Room No."></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblGvRoomNo" runat="server" Text='<%#GetFormatedRoomNumber(Eval("RoomNo")) %>'></asp:Label>
                                                            <%-- <%#DataBinder.Eval(Container.DataItem, "RoomNo")%>--%>
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
                                    <td width="50%" valign="top" style="vertical-align: top;">
                                        <div class="box_head">
                                            <span>
                                                <asp:Literal ID="litReservationList" runat="server" Text="Reservation List"></asp:Literal>
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
                                                            <asp:LinkButton ID="lnkGuestName" runat="server" CommandName="MESSAGE" CommandArgument='<%#Eval("ReservationNo") + "," +Eval("GuestFullName")+","+Eval("ReservationID")+","+Eval("GuestID")%>'
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
                                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblGvHdrRoomNo" runat="server" Text="Mobile No."></asp:Label>
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
                    <tr id="trCancel" runat="server" visible="false">
                        <td style="vertical-align: top;" colspan="4" align="center">
                            <asp:Button ID="btnMessagePopupCancel" runat="server" Text="Cancel" />
                        </td>
                    </tr>
                </table>
            </div>
            <div class="clear">
            </div>
        </div>
    </asp:View>
    <asp:View ID="vMessage" runat="server">
        <div class="box_col1">
            <div class="box_head">
                <span>
                    <asp:Literal ID="litMessageHeader" runat="server" Text="New Message"></asp:Literal></span></div>
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
                        <asp:Label ID="lblGuestMsg" runat="server"></asp:Label></div>
                    <div style="height: 10px;">
                    </div>
                </div>
                <% }%>
                <table cellpadding="2" cellspacing="2" border="0" width="100%">
                    <tr>
                        <td style="border: 1px solid #ccccce;" colspan="2">
                            <table>
                                <tr>
                                    <td>
                                        <div style="float: left; width: 110px;">
                                            <asp:Literal ID="litBookingNo" runat="server" Text="Booking #"></asp:Literal>
                                        </div>
                                        <div style="float: left; width: 150px;">
                                            <asp:Literal ID="litDisplayBookingNo" runat="server" Text="20625"></asp:Literal>
                                        </div>
                                    </td>
                                    <td>
                                        <div style="float: left; width: 110px;">
                                            <asp:Literal ID="litGuestName" runat="server" Text="Name"></asp:Literal>
                                        </div>
                                        <div style="float: left;">
                                            <asp:Literal ID="litDisplayGuestName" runat="server"></asp:Literal>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <fieldset style="border: 1px solid #ccccce !important;">
                                <legend>
                                    <asp:Literal ID="litMessageInfo" Text="Message Info." runat="server"></asp:Literal>
                                </legend>
                                <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                    <tr>
                                        <td class="isrequire">
                                            <asp:Literal ID="litMessageSubject" runat="server" Text="Subject"></asp:Literal>
                                        </td>
                                        <td style="width: 430px;">
                                            <asp:TextBox ID="txtMessageSubject" runat="server"></asp:TextBox>
                                            <span>
                                                <asp:RequiredFieldValidator ID="rfvMessageSubject" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                    runat="server" ValidationGroup="IsRequireMessage" ControlToValidate="txtMessageSubject"
                                                    Display="Dynamic">
                                                </asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td class="isrequire">
                                            <asp:Literal ID="litMessageBy" runat="server" Text="MessageBy"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMessageBy" runat="server"></asp:TextBox>
                                            <span>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                    runat="server" ValidationGroup="IsRequireMessage" ControlToValidate="txtMessageBy"
                                                    Display="Dynamic">
                                                </asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td>
                                            <asp:Literal ID="litMessageDate" runat="server" Text="Date"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal ID="litDisplayMessageDate" runat="server"></asp:Literal>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="litMesageOptions" runat="server" Text="Message Options"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlMessageOption" runat="server">
                                                <%--<asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                <asp:ListItem Text="Call" Value="Call"></asp:ListItem>
                                                <asp:ListItem Text="InPerson" Value="InPerson"></asp:ListItem>--%>
                                            </asp:DropDownList>
                                        </td>
                                        <td class="isrequire">
                                            <asp:Literal ID="litMessagePriority" runat="server" Text="Priority"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlMessagePriority" runat="server">
                                                <%--<asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                <asp:ListItem Text="High" Value="High"></asp:ListItem>
                                                <asp:ListItem Text="Law" Value="Law"></asp:ListItem>--%>
                                            </asp:DropDownList>
                                            <span>
                                                <asp:RequiredFieldValidator ID="rfvMessagePriority" InitialValue="00000000-0000-0000-0000-000000000000"
                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                    ValidationGroup="IsRequireMessage" ControlToValidate="ddlMessagePriority" Display="Dynamic">
                                                </asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" class="isrequire">
                                            <asp:Literal ID="litMessage" runat="server" Text="Message"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" Style="width: 400px !important;"></asp:TextBox>
                                            <span>
                                                <asp:RequiredFieldValidator ID="rfvMessage" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                    runat="server" ValidationGroup="IsRequireMessage" ControlToValidate="txtMessage"
                                                    Display="Dynamic">
                                                </asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <div class="box_head">
                                                <span>
                                                    <asp:Literal ID="litMessages" runat="server" Text="Messages"></asp:Literal>
                                                </span>
                                            </div>
                                            <div class="clear">
                                            </div>
                                            <div class="box_content">
                                                <asp:GridView ID="gvMessages" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                    Width="100%" OnRowCommand="gvReservationList_RowCommand">
                                                    <Columns>
                                                        <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrMoveUnitSrNo" runat="server" Text="No."></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrName" runat="server" Text="Name"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%#DataBinder.Eval(Container.DataItem, "MessageFrom")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrDate" runat="server" Text="Date"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%#DataBinder.Eval(Container.DataItem, "Msg_DateTime", "{0:dd-MM-yyyy}")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrMessage" runat="server" Text="Message"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%#DataBinder.Eval(Container.DataItem, "Message")%>
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
                            </fieldset>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <div style="width: auto; display: inline-block; text-align: center;">
                                <asp:Button ID="btnMessageCancel" runat="server" Text="Cancel" Style="float: right;
                                    margin-left: 5px;" OnClick="btnMessageCancel_Click" />
                                <asp:Button ID="btnMessageSave" OnClick="btnMessageSave_OnClick" runat="server" Text="Save"
                                    Style="float: right; margin-left: 5px;" ValidationGroup="IsRequireMessage" />
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
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<%--</asp:Panel>--%>
