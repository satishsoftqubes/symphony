<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlPastGuestList.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation.CtrlPastGuestList" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript" src="../../Scripts/jquery-1.4.2.min.js"></script>
<script type="text/javascript" src="../../Scripts/jquery-ui-1.8.5.custom.min.js"></script>
<script type="text/javascript">

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<script type="text/javascript">
    function fnGuestListPrint() {
        window.open("GuestListPrint.aspx", "Check in Guest List", "height=600,width=1000,status=1,toolbar=no,menubar=no,scrollbars=1,location=0");
    }
</script>
<asp:UpdatePanel ID="updGuestList" runat="server">
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
                                <asp:Literal ID="litMainHeader" runat="server" Text="Past Guest List"></asp:Literal>
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
                                            <td>
                                                <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                    <tr>
                                                        <td style="width: 50px; padding-top: 15px;">
                                                            <asp:Literal ID="litStartDate" runat="server" Text="From"></asp:Literal>
                                                        </td>
                                                        <td style="width: 220px; padding-top: 15px;">
                                                            <asp:TextBox ID="txtStartDate" runat="server" onkeypress="return false;" SkinID="Search"></asp:TextBox>
                                                            <asp:Image ID="imgSColor" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                                Height="20px" Width="20px" />
                                                            <ajx:CalendarExtender ID="calStartDate" runat="server" TargetControlID="txtStartDate"
                                                                PopupButtonID="imgSColor">
                                                            </ajx:CalendarExtender>
                                                            <asp:RequiredFieldValidator ID="rfvStartDate" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                runat="server" ValidationGroup="IsRequire" ControlToValidate="txtStartDate" Display="Static">
                                                            </asp:RequiredFieldValidator>
                                                        </td>
                                                        <td style="width: 30px; padding-top: 15px;">
                                                            <asp:Literal ID="litEndDate" runat="server" Text="To"></asp:Literal>
                                                        </td>
                                                        <td style="padding-top: 15px;">
                                                            <asp:TextBox ID="txtEndDate" runat="server" onkeypress="return false;" SkinID="Search"></asp:TextBox>
                                                            <asp:Image ID="imgEColor" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                                Height="20px" Width="20px" />
                                                            <ajx:CalendarExtender ID="calEndDate" runat="server" TargetControlID="txtEndDate"
                                                                PopupButtonID="imgEColor">
                                                            </ajx:CalendarExtender>
                                                            <asp:RequiredFieldValidator ID="rfvEndDate" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                runat="server" ValidationGroup="IsRequire" ControlToValidate="txtEndDate" Display="Static">
                                                            </asp:RequiredFieldValidator>
                                                            &nbsp;
                                                            <asp:ImageButton ID="btnSearch" OnClick="btnSearch_OnClick" runat="server" ImageUrl="~/images/search-icon.png"
                                                                ToolTip="Search" Style="border: 0px; margin: -4px 0 0 5px; vertical-align: middle;" />
                                                        </td>
                                                        <td align="right">
                                                            <asp:Button ID="btnExportToExcel" runat="server" Text="Excel" OnClick="btnExportToExcel_OnClick"
                                                                Style="float: right; margin-left: 5px;" />
                                                            <asp:Button ID="btnPrintGuestList" runat="server" Text="Print" OnClick="btnPrintGuestList_OnClick"
                                                                Style="float: right; margin-left: 5px;" Visible="false" />
                                                        </td>
                                                    </tr>
                                                    <%--<tr>
                                                        <td width="50px">
                                                            <asp:Literal ID="litSearchName" runat="server" Text="Name"></asp:Literal>
                                                        </td>
                                                        <td width="170px">
                                                            <asp:TextBox ID="txtSearchName" runat="server" Style="width: 140px !important;" SkinID="searchtextbox"></asp:TextBox>
                                                        </td>
                                                        <td width="65px">
                                                            <asp:Literal ID="Literal2" runat="server" Text="Mobile No."></asp:Literal>
                                                        </td>
                                                        <td width="170px">
                                                            <asp:TextBox ID="txtSearchMobileNo" runat="server" Style="width: 140px !important;"
                                                                SkinID="searchtextbox"></asp:TextBox>
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
                                                            <asp:TextBox ID="txtSearchUnitNo" runat="server" Style="width: 120px !important;"
                                                                SkinID="searchtextbox"></asp:TextBox>
                                                            
                                                            <asp:ImageButton ID="imgbtnClearSearch" OnClick="imgbtnClearSearch_OnClick" runat="server"
                                                                        ToolTip="Reset" ImageUrl="~/images/clearsearch.png" Style="border: 0px; vertical-align: middle;
                                                                        margin: -4px 0 0 5px;" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litbillinginstruction" runat="server" Text="Billing instruction"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlbillinginstruction" runat="server" Style="width: 165px;">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="litOrderByList" runat="server" Text="Sort By"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlOrderByList" runat="server" Style="width: 165px;">
                                                                <asp:ListItem Selected="True" Text="Booking No" Value="Booking No"></asp:ListItem>
                                                                <asp:ListItem Text="Room No" Value="Room No"></asp:ListItem>
                                                                <asp:ListItem Text="Block name" Value="Block name"></asp:ListItem>
                                                                <asp:ListItem Text="Arrival Date" Value="Arrival Date"></asp:ListItem>
                                                                <asp:ListItem Text="Company Name" Value="Company Name"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        
                                                    </tr>--%>
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
                                                <div class="box_head">
                                                    <span>
                                                        <asp:Literal ID="litGuestList" runat="server" Text="Guest List"></asp:Literal>
                                                    </span>
                                                </div>
                                                <div class="clear">
                                                </div>
                                                <div class="box_content">
                                                    <asp:GridView ID="gvGuestList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                        Width="100%" OnRowCommand="gvGuestList_RowCommand" OnRowDataBound="gvGuestList_RowDataBound"
                                                        OnPageIndexChanging="gvGuestList_PageIndexChanging">
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
                                                                    <%--<asp:LinkButton ID="lnkReservationNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ReservationNo")%>'
                                                                        CommandName="GUESTPROFILE" CommandArgument='<%#Eval("ReservationID")%>'></asp:LinkButton>--%>
                                                                    <%#DataBinder.Eval(Container.DataItem, "ReservationNo")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrGuestName" runat="server" Text="Name"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%--<asp:LinkButton ID="lnkGuestName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "GuestFullName")%>'
                                                                        CommandName="GUESTPROFILE" CommandArgument='<%#Eval("ReservationID")%>'></asp:LinkButton>--%>
                                                                        <%#DataBinder.Eval(Container.DataItem, "GuestFullName")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrMobileNo" runat="server" Text="Mobile No."></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%-- <%#DataBinder.Eval(Container.DataItem, "Phone1")%>--%>
                                                                    <asp:Label ID="lblGvPhone" runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrCompany" runat="server" Text="Company"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "CompanyName")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="125px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrRateCardType" runat="server" Text="Rate Card"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "RateCardName")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrRateCardNo" runat="server" Text="RC No."></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "Code")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="130px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrUnitType" runat="server" Text="Room Type"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGvRoomTypeName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "RoomTypeName")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrUnitNo" runat="server" Text="Room No."></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%--<asp:Label ID="lblGvRoomNo" runat="server" Text='<%# GetFormatedRoomNumber(Eval("RoomNo")) %>'></asp:Label>--%>
                                                                    <%#DataBinder.Eval(Container.DataItem, "DisplayRoomNo")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrCheckIn" runat="server" Text="Check In"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "CheckInDate", "{0:dd-MM-yyyy}")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrCheckOut" runat="server" Text="Check Out"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "CheckOutDate", "{0:dd-MM-yyyy}")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="50px" Visible="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
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
                                                                                                <asp:LinkButton ID="lnkViewFolio" Style="background: none !important; border: none;"
                                                                                                    runat="server" ToolTip="View Folio" CommandName="VIEWFOLIO" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ReservationID")%>'><img src="../../images/file.png" /></asp:LinkButton></li>
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
    </ContentTemplate>
    <Triggers>
        <%--<asp:PostBackTrigger ControlID="btnPrintGuestList" />--%>
        <asp:PostBackTrigger ControlID="btnExportToExcel" />        
    </Triggers>
</asp:UpdatePanel>
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updGuestList" ID="UpdateProgressGuestList"
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
