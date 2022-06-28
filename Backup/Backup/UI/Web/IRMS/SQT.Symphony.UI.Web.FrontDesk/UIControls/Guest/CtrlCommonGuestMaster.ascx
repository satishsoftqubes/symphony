<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCommonGuestMaster.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Guest.CtrlCommonGuestMaster" %>
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

        $("#tabs").tabs();

        $('#tabs').tabs({
            select: function (event, ui) {
                window.location.hash = ui.tab.hash;
            }
        });
    }
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<asp:UpdatePanel ID="updGuestmaster" runat="server">
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
                                <asp:Literal ID="litpageBoxTitle" runat="server" Text="Guest History"></asp:Literal>
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
                                    <table width="100%" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="75%" style="vertical-align: top;">
                                                <asp:MultiView ID="mvGuestMaster" runat="server">
                                                    <asp:View ID="vGuestList" runat="server">
                                                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                            <tr>
                                                                <td width="90px">
                                                                    <asp:Literal ID="litSearchName" runat="server" Text="Name"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtSrchName" runat="server" MaxLength="150" Style="width: 140px !important;"
                                                                        SkinID="searchtextbox"></asp:TextBox>
                                                                </td>
                                                                <td width="90px">
                                                                    <asp:Literal ID="litSearchMobileNo" runat="server" Text="Mobile No."></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtSrchMobileNo" MaxLength="14" runat="server" Style="width: 140px !important;"
                                                                        SkinID="searchtextbox"></asp:TextBox>
                                                                    <ajx:FilteredTextBoxExtender ID="ftSearchMobileNo" runat="server" TargetControlID="txtSrchMobileNo"
                                                                        ValidChars="0123456789-+">
                                                                    </ajx:FilteredTextBoxExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litSearchCompany" runat="server" Text="Company"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtSrchCompany" runat="server" MaxLength="150" Style="width: 140px !important;"
                                                                        SkinID="searchtextbox"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="litSearchNationality" runat="server" Text="Nationality"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtSrchNationality" runat="server" MaxLength="50" Style="width: 140px !important;"
                                                                        SkinID="searchtextbox"></asp:TextBox>
                                                                    <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                                        OnClick="btnSearch_OnClick" ToolTip="Search" Style="border: 0px; margin: 2px 0 0 5px; vertical-align: middle;" />
                                                                    <asp:ImageButton ID="imgbtnClearSearch" runat="server" ImageUrl="~/images/clearsearch.png"
                                                                        OnClick="imgbtnClearSearch_OnClick" ToolTip="Clear" Style="border: 0px; vertical-align: middle;
                                                                        margin: 2px 0 0 10px;" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <hr />
                                                        <div class="box_head">
                                                            <span>
                                                                <asp:Literal ID="litGuestList" runat="server" Text="Guest List"></asp:Literal>
                                                            </span>
                                                        </div>
                                                        <div class="clear">
                                                        </div>
                                                        <div class="box_content">
                                                            <asp:GridView ID="gvGuestList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                Width="100%" OnRowCommand="gvGuestList_RowCommand" OnPageIndexChanging="gvGuestList_OnPageIndexChanging">
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
                                                                            <asp:Label ID="lblGvHdrName" runat="server" Text="Name"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkGuest" runat="server" ToolTip='View Profile' CommandName="VIEWGUESTHISTORY"
                                                                                CommandArgument='<%#Eval("GuestID")%>' Text='<%#DataBinder.Eval(Container.DataItem, "GuestFullName")%>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="125px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrMobileNo" runat="server" Text="Mobile No."></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "Phone1")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="250px" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrEmail" runat="server" Text="Email"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "Email")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrAge" runat="server" Text="Age"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "Age")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="160px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrCompany" runat="server" Text="Company"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "CompanyName")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrDOB" runat="server" Text="Nationality"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "Nationality")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrCity" runat="server" Text="City"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "CityName")%>
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
                                                    </asp:View>
                                                    <asp:View ID="vGuestHistory" runat="server">
                                                        <div style="vertical-align: top; border: 1px solid #ccccce !important; background-color: #F3F3F5;">
                                                            <table cellpadding="3" cellspacing="2" width="100%" border="0">
                                                                <tr>
                                                                    <th style="width: 30px;">
                                                                        <asp:Label ID="lblStayHistoryGuestName" runat="server" Text="Name:"></asp:Label>
                                                                    </th>
                                                                    <td>
                                                                        <asp:Label ID="lblStayHistoryDisplayGuestName" runat="server"></asp:Label>
                                                                    </td>
                                                                    <th style="width:65px">
                                                                        <asp:Label ID="lblStayHistoryMobileNo" runat="server" Text="Mobile No.:"></asp:Label>
                                                                    </th>
                                                                    <td>
                                                                        <asp:Label ID="lblStayHistoryDisplayMobileNo" runat="server"></asp:Label>
                                                                    </td>
                                                                    <th style="width:60px">
                                                                        <asp:Label ID="lblStayHistoryEmail" runat="server" Text="Email:"></asp:Label>
                                                                    </th>
                                                                    <td>
                                                                        <asp:Label ID="lblStayHistoryDisplayEmail" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                        <br />
                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                            <tr>
                                                                <td>
                                                                    <div class="box_head">
                                                                        <span>
                                                                            <asp:Literal ID="litStayHistoryList" runat="server" Text="Stay History"></asp:Literal>
                                                                        </span>
                                                                    </div>
                                                                    <div class="clear">
                                                                    </div>
                                                                    <div class="box_content">
                                                                        <asp:GridView ID="gvGuestHistory" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                            Width="100%" OnRowCommand="gvGuestHistory_RowCommand" OnPageIndexChanging="gvGuestHistory_OnPageIndexChanging"
                                                                            OnRowDataBound="gvGuestHistory_RowDataBound" DataKeyNames="ReservationID,FolioID">
                                                                            <Columns>
                                                                                <asp:TemplateField ItemStyle-Width="30px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%# Container.DataItemIndex + 1 %>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrBookingNo" runat="server" Text="Booking #"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%--<%#DataBinder.Eval(Container.DataItem, "ReservationNo")%>--%>
                                                                                        <asp:LinkButton ID="lnkReservationNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ReservationNo")%>'
                                                                                            CommandName="VIEWFOLIODETAIL" CommandArgument='<%# Container.DataItemIndex %>'></asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrRoomCnf" runat="server" Text="Check In"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblGvCheckInDate" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "CheckInDate")).ToString(clsSession.DateFormat)%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrCheckInDate" runat="server" Text="Check Out"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblGvCheckOutDate" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "CheckOutDate")).ToString(clsSession.DateFormat)%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrCheckOutDate" runat="server" Text="Nights"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblGvNights" runat="server" Text='<%# Reservation_GetTotalDays(Eval("CheckInDate"),Eval("CheckOutDate")) %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="120px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrNights" runat="server" Text="Rate Card"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%#DataBinder.Eval(Container.DataItem, "RateCardName")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrRateCard" runat="server" Text="Room Type"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%#DataBinder.Eval(Container.DataItem, "RoomTypeName")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrInvoiceAmt" runat="server" Text="Room No."></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblGvRoomNo" runat="server" Text='<%# GetFormatedRoomNumber(Eval("RoomNo")) %>'></asp:Label>
                                                                                        <%--<%#DataBinder.Eval(Container.DataItem, "RoomNo")%>--%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrStatus" runat="server" Text="Invoice Amt."></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblGvInvoiceAmount" runat="server"></asp:Label>
                                                                                        <%-- <%#DataBinder.Eval(Container.DataItem, "Amt")%>--%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrFolioBalance" runat="server" Text="Folio Balance"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        0.00
                                                                                        <%-- <%#DataBinder.Eval(Container.DataItem, "Amt")%>--%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                            <EmptyDataTemplate>
                                                                                <div style="padding: 10px;">
                                                                                    <b>
                                                                                        <asp:Label ID="lblNoRecordFound" Text="No Record Found." runat="server"></asp:Label>
                                                                                    </b>
                                                                                </div>
                                                                            </EmptyDataTemplate>
                                                                        </asp:GridView>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" style="padding-top: 10px;">
                                                                    <asp:Button ID="btnBackFromStayHistory" runat="server" Text="Back" Style="display: inline;"
                                                                        OnClick="btnBackFromStayHistory_OnClick" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:View>
                                                    <asp:View ID="vFolioDetail" runat="server">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td>
                                                                    <asp:HiddenField ID="hdnAllCharges" runat="server" />
                                                                    <asp:HiddenField ID="hdnRentCharges" runat="server" />
                                                                    <asp:HiddenField ID="hdnMISC" runat="server" />
                                                                    <asp:HiddenField ID="hdnPayment" runat="server" />
                                                                    <asp:HiddenField ID="hdnDeposit" runat="server" />
                                                                    <asp:HiddenField ID="hdn_MasterFolioID" runat="server" />
                                                                    <table cellpadding="2" cellspacing="2" width="100%">
                                                                        <tr style="background-color: #F3F3F5;">
                                                                            <td width="33%" style="vertical-align: top; border: 1px solid #ccccce !important;">
                                                                                <table cellpadding="2" cellspacing="2" width="100%">
                                                                                    <tr>
                                                                                        <th style="width: 75px;" align="left">
                                                                                            <asp:Label ID="lblFolioDetailsGuestName" runat="server" Text="Name"></asp:Label>
                                                                                        </th>
                                                                                        <td>
                                                                                            <asp:Label ID="lblFolioDetailsDisplayGuestName" runat="server"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <th align="left">
                                                                                            <asp:Label ID="lblFolioDetailsMobileNo" runat="server" Text="Mobile No."></asp:Label>
                                                                                        </th>
                                                                                        <td>
                                                                                            <asp:Label ID="lblFolioDetailsDisplayMobileNo" runat="server"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <th align="left">
                                                                                            <asp:Label ID="lblFolioDetailsEmail" runat="server" Text="Email"></asp:Label>
                                                                                        </th>
                                                                                        <td>
                                                                                            <asp:Label ID="lblFolioDetailsDisplayEmail" runat="server"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                            <td width="33%" style="vertical-align: top; border: 1px solid #ccccce !important;">
                                                                                <table cellpadding="2" cellspacing="2" width="100%">
                                                                                    <tr>
                                                                                        <th style="width: 75px;" align="left">
                                                                                            <asp:Literal ID="litArrivalDate" runat="server" Text="Check In"></asp:Literal>
                                                                                        </th>
                                                                                        <td>
                                                                                            <asp:Literal ID="litDisplayArrivalDate" runat="server"></asp:Literal>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <th align="left">
                                                                                            <asp:Literal ID="litDepatureDate" runat="server" Text="Check Out"></asp:Literal>
                                                                                        </th>
                                                                                        <td>
                                                                                            <asp:Literal ID="litDisplayDepatureDate" runat="server"></asp:Literal>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <th align="left">
                                                                                            <asp:Literal ID="litFolioNo" runat="server" Text="Folio No."></asp:Literal>
                                                                                        </th>
                                                                                        <td>
                                                                                            <asp:Literal ID="litDisplayFolioNo" runat="server"></asp:Literal>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                            <td style="vertical-align: top; border: 1px solid #ccccce !important;">
                                                                                <table cellpadding="2" cellspacing="2" width="100%">
                                                                                    <tr>
                                                                                        <th style="width: 75px;" align="left">
                                                                                            <asp:Literal ID="litUnitNo" runat="server" Text="Room No."></asp:Literal>
                                                                                        </th>
                                                                                        <td>
                                                                                            <asp:Literal ID="litDisplayUnitNo" runat="server"></asp:Literal>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <th align="left">
                                                                                            <asp:Literal ID="litRoomType" runat="server" Text="Room Type"></asp:Literal>
                                                                                        </th>
                                                                                        <td>
                                                                                            <asp:Literal ID="litDisplayRoomType" runat="server"></asp:Literal>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <th align="left">
                                                                                            <asp:Literal ID="litRateCard" runat="server" Text="Rate Card"></asp:Literal>
                                                                                        </th>
                                                                                        <td>
                                                                                            <asp:Literal ID="litDisplayRateCard" runat="server"></asp:Literal>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <th align="left">
                                                                                            <asp:Literal ID="litCreditLimit" runat="server" Text="Folio Balance"></asp:Literal>
                                                                                        </th>
                                                                                        <td>
                                                                                            <asp:Literal ID="litDisplayCreditLimit" runat="server"></asp:Literal>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="3">
                                                                                <table cellpadding="2" cellspacing="2" width="100%">
                                                                                    <tr>
                                                                                        <td align="left" style="padding-top: 10px; background-color: #fff !important;">
                                                                                            <div class="demo">
                                                                                                <div id="tabs">
                                                                                                    <ul>
                                                                                                        <li><a href="#tabs-1">
                                                                                                            <asp:Label ID="lbltabAllCharges" runat="server"></asp:Label>
                                                                                                        </a></li>
                                                                                                        <li><a href="#tabs-2">
                                                                                                            <asp:Literal ID="littabRentCharge" runat="server"></asp:Literal></a></li>
                                                                                                        <li style="display: none;"><a href="#tabs-6">
                                                                                                            <asp:Literal ID="littabMISC" runat="server"></asp:Literal></a></li>
                                                                                                        <li><a href="#tabs-7">
                                                                                                            <asp:Literal ID="littabPayment" runat="server"></asp:Literal></a></li>
                                                                                                        <li><a href="#tabs-8">
                                                                                                            <asp:Label ID="lblTabDeposit" runat="server"></asp:Label>
                                                                                                        </a></li>
                                                                                                    </ul>
                                                                                                    <div id="tabs-1">
                                                                                                        <table cellpadding="2" cellspacing="2" width="100%">
                                                                                                            <tr>
                                                                                                                <td style="width: 50px;">
                                                                                                                    <asp:Literal ID="litStartDate" runat="server" Text="From"></asp:Literal>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:CheckBox ID="chkStartDate" runat="server" AutoPostBack="true" Text="" OnCheckedChanged="chkStartDate_CheckedChanged" />
                                                                                                                    <asp:TextBox ID="txtStartDate" runat="server" onkeypress="return false;" SkinID="Search"></asp:TextBox>
                                                                                                                    <asp:Image ID="imgSColor" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                                                                                        Height="20px" Width="20px" />
                                                                                                                    <ajx:CalendarExtender ID="calStartDate" runat="server" TargetControlID="txtStartDate"
                                                                                                                        PopupButtonID="imgSColor">
                                                                                                                    </ajx:CalendarExtender>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:Literal ID="litEndDate" runat="server" Text="To"></asp:Literal>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <div>
                                                                                                                        <asp:CheckBox ID="chkEndDate" runat="server" AutoPostBack="true" Text="" OnCheckedChanged="chkEndDate_CheckedChanged" />
                                                                                                                        <asp:TextBox ID="txtEndDate" runat="server" onkeypress="return false;" SkinID="Search"></asp:TextBox>
                                                                                                                        <asp:Image ID="imgEColor" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                                                                                            Height="20px" Width="20px" />
                                                                                                                        <ajx:CalendarExtender ID="calEndDate" runat="server" TargetControlID="txtEndDate"
                                                                                                                            PopupButtonID="imgEColor">
                                                                                                                        </ajx:CalendarExtender>
                                                                                                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/search-icon.png" ToolTip="Search"
                                                                                                                            Style="border: 0px; margin: 0 0 0 5px; vertical-align: middle;" OnClick="btnSearch_Click" />
                                                                                                                        <%--<span style="margin-left: auto; text-align: right;">
                                                                                                                                            <asp:RadioButton ID="rdoDetail" runat="server" Text="Detail" AutoPostBack="true"
                                                                                                                                                GroupName="ReportType" Style="margin: 0 0 0 50px;" OnCheckedChanged="rdoDetail_CheckedChanged" /></span>
                                                                                                                                        <span style="margin-left: 10px; text-align: right;">
                                                                                                                                            <asp:RadioButton ID="rdoSummary" runat="server" Text="Summary" AutoPostBack="true"
                                                                                                                                                GroupName="ReportType" OnCheckedChanged="rdoDetail_CheckedChanged" />
                                                                                                                                        </span>--%>
                                                                                                                    </div>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td colspan="4">
                                                                                                                    <div class="box_head">
                                                                                                                        <span>
                                                                                                                            <asp:Literal ID="litFolioDetails" runat="server" Text="Folio Details"></asp:Literal>
                                                                                                                        </span>
                                                                                                                    </div>
                                                                                                                    <div class="clear">
                                                                                                                    </div>
                                                                                                                    <div class="box_content">
                                                                                                                        <asp:GridView ID="gvFolioDetails" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                                                                            Width="100%" OnRowDataBound="gvFolioDetails_RowDataBound" OnPageIndexChanging="gvFolioDetails_PageIndexChanging"
                                                                                                                            DataKeyNames="GuestName,ReservationNo,FolioNo,EntryDate,DisplayAmount,IsVoid,RoomNo,BookID"
                                                                                                                            ShowFooter="true">
                                                                                                                            <Columns>
                                                                                                                                <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                                                    <HeaderTemplate>
                                                                                                                                        <asp:Label ID="lblGvHdrFolioDetailsDate" runat="server" Text="Date"></asp:Label>
                                                                                                                                    </HeaderTemplate>
                                                                                                                                    <ItemTemplate>
                                                                                                                                        <asp:Label ID="lblGvFolioDetailsDate" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "EntryDate")).ToString(clsSession.DateFormat)%>'></asp:Label>
                                                                                                                                    </ItemTemplate>
                                                                                                                                </asp:TemplateField>
                                                                                                                                <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                                                    <HeaderTemplate>
                                                                                                                                        <asp:Label ID="lblGvHdrFolioDetailsTransaction" runat="server" Text="Trans. #"></asp:Label>
                                                                                                                                    </HeaderTemplate>
                                                                                                                                    <ItemTemplate>
                                                                                                                                        <asp:Label ID="lblGvFolioDetailsBookNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "BookNo")%>'></asp:Label>
                                                                                                                                    </ItemTemplate>
                                                                                                                                </asp:TemplateField>
                                                                                                                                <asp:TemplateField ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                                                    <HeaderTemplate>
                                                                                                                                        <asp:Label ID="lblGvHdrFolioDetailsAccount" runat="server" Text="Ledger Account"></asp:Label>
                                                                                                                                    </HeaderTemplate>
                                                                                                                                    <ItemTemplate>
                                                                                                                                        <%#DataBinder.Eval(Container.DataItem, "Account")%>
                                                                                                                                    </ItemTemplate>
                                                                                                                                </asp:TemplateField>
                                                                                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" Visible="false" ItemStyle-HorizontalAlign="Left">
                                                                                                                                    <HeaderTemplate>
                                                                                                                                        <asp:Label ID="lblGvHdrFolioDetailsDescription" runat="server" Text="Description"></asp:Label>
                                                                                                                                    </HeaderTemplate>
                                                                                                                                    <ItemTemplate>
                                                                                                                                        <asp:Label ID="lblGvFolioDetailsDescription" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Narration")%>'></asp:Label>
                                                                                                                                    </ItemTemplate>
                                                                                                                                    <FooterTemplate>
                                                                                                                                        <b>Total</b>
                                                                                                                                    </FooterTemplate>
                                                                                                                                </asp:TemplateField>
                                                                                                                                <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                                                                                                                    FooterStyle-HorizontalAlign="Right">
                                                                                                                                    <HeaderTemplate>
                                                                                                                                        <asp:Label ID="lblGvHdrFolioDetailsCharges" runat="server" Text="Charge"></asp:Label>
                                                                                                                                    </HeaderTemplate>
                                                                                                                                    <ItemTemplate>
                                                                                                                                        <asp:Label ID="lblGvCharges" runat="server"></asp:Label>
                                                                                                                                    </ItemTemplate>
                                                                                                                                    <FooterTemplate>
                                                                                                                                        <b>
                                                                                                                                            <asp:Label ID="lblGvFtTotalCharge" runat="server"></asp:Label></b>
                                                                                                                                    </FooterTemplate>
                                                                                                                                </asp:TemplateField>
                                                                                                                                <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                                                                                                                    FooterStyle-HorizontalAlign="Right">
                                                                                                                                    <HeaderTemplate>
                                                                                                                                        <asp:Label ID="lblGvHdrFolioDetailsPayment" runat="server" Text="Credit"></asp:Label>
                                                                                                                                    </HeaderTemplate>
                                                                                                                                    <ItemTemplate>
                                                                                                                                        <asp:Label ID="lblGvPayment" runat="server"></asp:Label>
                                                                                                                                    </ItemTemplate>
                                                                                                                                    <FooterTemplate>
                                                                                                                                        <b>
                                                                                                                                            <asp:Label ID="lblGvFtTotalPayment" runat="server"></asp:Label></b>
                                                                                                                                    </FooterTemplate>
                                                                                                                                </asp:TemplateField>
                                                                                                                                <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                                                                                                                    FooterStyle-HorizontalAlign="Right">
                                                                                                                                    <HeaderTemplate>
                                                                                                                                        <asp:Label ID="lblGvHdrFolioDetailsBalance" runat="server" Text="Balance"></asp:Label>
                                                                                                                                    </HeaderTemplate>
                                                                                                                                    <ItemTemplate>
                                                                                                                                        <asp:Label ID="lblBalance" runat="server"></asp:Label>
                                                                                                                                    </ItemTemplate>
                                                                                                                                    <FooterTemplate>
                                                                                                                                        <b>
                                                                                                                                            <asp:Label ID="lblGvFtFinalBalance" runat="server"></asp:Label></b>
                                                                                                                                    </FooterTemplate>
                                                                                                                                </asp:TemplateField>
                                                                                                                            </Columns>
                                                                                                                            <EmptyDataTemplate>
                                                                                                                                <div style="padding: 10px;">
                                                                                                                                    <b>
                                                                                                                                        <asp:Label ID="lblFolioDetailsNoRecordFound" runat="server" Text="No Record Found."></asp:Label>
                                                                                                                                    </b>
                                                                                                                                </div>
                                                                                                                            </EmptyDataTemplate>
                                                                                                                        </asp:GridView>
                                                                                                                    </div>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <%--<tr>
                                                                                                                                <td colspan="4" align="center">
                                                                                                                                    <asp:Button ID="btnPrintStatement" runat="server" Text="Print" OnClick="btnPrintStatement_Click"
                                                                                                                                        Style="display: inline;" />
                                                                                                                                    <asp:Button ID="btnSubFolioCheckOut" runat="server" Text="Check Out" OnClick="btnSubFolioCheckOut_Click"
                                                                                                                                        Style="display: inline;" Visible="false" />
                                                                                                                                </td>
                                                                                                                            </tr>--%>
                                                                                                        </table>
                                                                                                    </div>
                                                                                                    <div id="tabs-2">
                                                                                                        <table cellpadding="2" cellspacing="2" width="100%">
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <div class="box_head">
                                                                                                                        <span>
                                                                                                                            <asp:Literal ID="litAccomodationDetails" runat="server" Text="Room Rent"></asp:Literal>
                                                                                                                        </span>
                                                                                                                    </div>
                                                                                                                    <div class="clear">
                                                                                                                    </div>
                                                                                                                    <div class="box_content">
                                                                                                                        <asp:GridView ID="gvAccommodationList" runat="server" AutoGenerateColumns="false"
                                                                                                                            ShowHeader="true" Width="100%" OnRowDataBound="gvAccommodationList_RowDataBound"
                                                                                                                            ShowFooter="true" OnPageIndexChanging="gvAccommodationList_PageIndexChanging"
                                                                                                                            DataKeyNames="GuestName,ReservationNo,FolioNo,EntryDate,DisplayAmount,IsVoid,BookID,GeneralIDType_Term">
                                                                                                                            <Columns>
                                                                                                                                <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                                                    <HeaderTemplate>
                                                                                                                                        <asp:Label ID="lblGvHdrAccommodationDate" runat="server" Text="Date"></asp:Label>
                                                                                                                                    </HeaderTemplate>
                                                                                                                                    <ItemTemplate>
                                                                                                                                        <asp:Label ID="lblGvAccommodationDate" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "EntryDate")).ToString(clsSession.DateFormat)%>'></asp:Label>
                                                                                                                                    </ItemTemplate>
                                                                                                                                </asp:TemplateField>
                                                                                                                                <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                                                    <HeaderTemplate>
                                                                                                                                        <asp:Label ID="lblGvHdrAccommodationTransaction" runat="server" Text="Trans. #"></asp:Label>
                                                                                                                                    </HeaderTemplate>
                                                                                                                                    <ItemTemplate>
                                                                                                                                        <asp:Label ID="lblGvAccommodationBookNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "BookNo")%>'></asp:Label>
                                                                                                                                    </ItemTemplate>
                                                                                                                                </asp:TemplateField>
                                                                                                                                <asp:TemplateField ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                                                    <HeaderTemplate>
                                                                                                                                        <asp:Label ID="lblGvHdrAccommodationAccount" runat="server" Text="Ledger Account"></asp:Label>
                                                                                                                                    </HeaderTemplate>
                                                                                                                                    <ItemTemplate>
                                                                                                                                        <%#DataBinder.Eval(Container.DataItem, "Account")%>
                                                                                                                                    </ItemTemplate>
                                                                                                                                </asp:TemplateField>
                                                                                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" Visible="false" ItemStyle-HorizontalAlign="Left">
                                                                                                                                    <HeaderTemplate>
                                                                                                                                        <asp:Label ID="lblGvHdrAccommodationDescription" runat="server" Text="Description"></asp:Label>
                                                                                                                                    </HeaderTemplate>
                                                                                                                                    <ItemTemplate>
                                                                                                                                        <asp:Label ID="lblGvAccommodationDescription" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Narration")%>'></asp:Label>
                                                                                                                                    </ItemTemplate>
                                                                                                                                    <FooterTemplate>
                                                                                                                                        <b>Total</b>
                                                                                                                                    </FooterTemplate>
                                                                                                                                </asp:TemplateField>
                                                                                                                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                                                                                                                    FooterStyle-HorizontalAlign="Right">
                                                                                                                                    <HeaderTemplate>
                                                                                                                                        <asp:Label ID="lblGvHdrAccommodationCharges" runat="server" Text="Charge"></asp:Label>
                                                                                                                                    </HeaderTemplate>
                                                                                                                                    <ItemTemplate>
                                                                                                                                        <asp:Label ID="lblGvAccommodationCharges" runat="server"></asp:Label>
                                                                                                                                    </ItemTemplate>
                                                                                                                                    <FooterTemplate>
                                                                                                                                        <b>
                                                                                                                                            <asp:Label ID="lblFtTotalAccommodationCharges" runat="server"></asp:Label>
                                                                                                                                        </b>
                                                                                                                                    </FooterTemplate>
                                                                                                                                </asp:TemplateField>
                                                                                                                            </Columns>
                                                                                                                            <EmptyDataTemplate>
                                                                                                                                <div style="padding: 10px;">
                                                                                                                                    <b>
                                                                                                                                        <asp:Label ID="lblNoRecordFoundForAccommodation" runat="server" Text="No Record Found."></asp:Label>
                                                                                                                                    </b>
                                                                                                                                </div>
                                                                                                                            </EmptyDataTemplate>
                                                                                                                        </asp:GridView>
                                                                                                                    </div>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </div>
                                                                                                    <div style="display: none;" id="tabs-6">
                                                                                                        <table cellpadding="2" cellspacing="2" width="100%">
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <div class="box_head">
                                                                                                                        <span>
                                                                                                                            <asp:Literal ID="litMISCDetails" runat="server" Text="Misc. Charges"></asp:Literal>
                                                                                                                        </span>
                                                                                                                    </div>
                                                                                                                    <div class="clear">
                                                                                                                    </div>
                                                                                                                    <div class="box_content">
                                                                                                                        <asp:GridView ID="gvMISCDetails" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                                                                            Width="100%" OnRowDataBound="gvMISCDetails_RowDataBound" OnPageIndexChanging="gvMISCDetails_PageIndexChanging"
                                                                                                                            DataKeyNames="GuestName,ReservationNo,FolioNo,EntryDate,DisplayAmount,IsVoid,BookID,GeneralIDType_Term"
                                                                                                                            ShowFooter="true">
                                                                                                                            <Columns>
                                                                                                                                <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                                                    <HeaderTemplate>
                                                                                                                                        <asp:Label ID="lblGvHdrMISCDate" runat="server" Text="Date"></asp:Label>
                                                                                                                                    </HeaderTemplate>
                                                                                                                                    <ItemTemplate>
                                                                                                                                        <asp:Label ID="lblGvMISCDate" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "EntryDate")).ToString(clsSession.DateFormat)%>'></asp:Label>
                                                                                                                                    </ItemTemplate>
                                                                                                                                </asp:TemplateField>
                                                                                                                                <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                                                    <HeaderTemplate>
                                                                                                                                        <asp:Label ID="lblGvHdrMISCTransaction" runat="server" Text="Trans. #"></asp:Label>
                                                                                                                                    </HeaderTemplate>
                                                                                                                                    <ItemTemplate>
                                                                                                                                        <asp:Label ID="lblGvMISCBookNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "BookNo")%>'></asp:Label>
                                                                                                                                    </ItemTemplate>
                                                                                                                                </asp:TemplateField>
                                                                                                                                <asp:TemplateField ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                                                    <HeaderTemplate>
                                                                                                                                        <asp:Label ID="lblGvHdrMISCAccount" runat="server" Text="Ledger Account"></asp:Label>
                                                                                                                                    </HeaderTemplate>
                                                                                                                                    <ItemTemplate>
                                                                                                                                        <asp:Label ID="lblGvMISCAccount" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Account")%>'></asp:Label>
                                                                                                                                    </ItemTemplate>
                                                                                                                                </asp:TemplateField>
                                                                                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" Visible="false" ItemStyle-HorizontalAlign="Left">
                                                                                                                                    <HeaderTemplate>
                                                                                                                                        <asp:Label ID="lblGvHdrMISCDescription" runat="server" Text="Description"></asp:Label>
                                                                                                                                    </HeaderTemplate>
                                                                                                                                    <ItemTemplate>
                                                                                                                                        <asp:Label ID="lblGvMISCDescription" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Narration")%>'></asp:Label>
                                                                                                                                    </ItemTemplate>
                                                                                                                                    <FooterTemplate>
                                                                                                                                        <b>Total</b>
                                                                                                                                    </FooterTemplate>
                                                                                                                                </asp:TemplateField>
                                                                                                                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                                                                                                                    FooterStyle-HorizontalAlign="Right">
                                                                                                                                    <HeaderTemplate>
                                                                                                                                        <asp:Label ID="lblGvHdrMISCCharges" runat="server" Text="Charge"></asp:Label>
                                                                                                                                    </HeaderTemplate>
                                                                                                                                    <ItemTemplate>
                                                                                                                                        <asp:Label ID="lblGvMISCCharges" runat="server"></asp:Label>
                                                                                                                                    </ItemTemplate>
                                                                                                                                    <FooterTemplate>
                                                                                                                                        <b>
                                                                                                                                            <asp:Label ID="lblFtTotalMISCCharges" runat="server"></asp:Label>
                                                                                                                                        </b>
                                                                                                                                    </FooterTemplate>
                                                                                                                                </asp:TemplateField>
                                                                                                                            </Columns>
                                                                                                                            <EmptyDataTemplate>
                                                                                                                                <div style="padding: 10px;">
                                                                                                                                    <b>
                                                                                                                                        <asp:Label ID="lblNoRecordFoundForMISC" runat="server" Text="No Record Found."></asp:Label>
                                                                                                                                    </b>
                                                                                                                                </div>
                                                                                                                            </EmptyDataTemplate>
                                                                                                                        </asp:GridView>
                                                                                                                    </div>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </div>
                                                                                                    <div id="tabs-7">
                                                                                                        <table cellpadding="2" cellspacing="2" width="100%">
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <div class="box_head">
                                                                                                                        <span>
                                                                                                                            <asp:Literal ID="litPaymentDetails" runat="server" Text="Credit"></asp:Literal>
                                                                                                                        </span>
                                                                                                                    </div>
                                                                                                                    <div class="clear">
                                                                                                                    </div>
                                                                                                                    <div class="box_content">
                                                                                                                        <asp:GridView ID="gvPaymentDetails" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                                                                            Width="100%" OnPageIndexChanging="gvPaymentDetails_PageIndexChanging" OnRowDataBound="gvPaymentDetails_RowDataBound"
                                                                                                                            ShowFooter="true">
                                                                                                                            <Columns>
                                                                                                                                <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                                                    <HeaderTemplate>
                                                                                                                                        <asp:Label ID="lblGvHdrPaymentDate" runat="server" Text="Date"></asp:Label>
                                                                                                                                    </HeaderTemplate>
                                                                                                                                    <ItemTemplate>
                                                                                                                                        <asp:Label ID="lblGvPaymentDate" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "EntryDate")).ToString(clsSession.DateFormat)%>'></asp:Label>
                                                                                                                                    </ItemTemplate>
                                                                                                                                </asp:TemplateField>
                                                                                                                                <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                                                    <HeaderTemplate>
                                                                                                                                        <asp:Label ID="lblGvHdrPaymentBookNo" runat="server" Text="Trans. #"></asp:Label>
                                                                                                                                    </HeaderTemplate>
                                                                                                                                    <ItemTemplate>
                                                                                                                                        <%#DataBinder.Eval(Container.DataItem, "BookNo")%>
                                                                                                                                    </ItemTemplate>
                                                                                                                                </asp:TemplateField>
                                                                                                                                <asp:TemplateField ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                                                    <HeaderTemplate>
                                                                                                                                        <asp:Label ID="lblGvHdrPaymentAccount" runat="server" Text="Ledger Account"></asp:Label>
                                                                                                                                    </HeaderTemplate>
                                                                                                                                    <ItemTemplate>
                                                                                                                                        <asp:Label ID="lblGvPaymentAccount" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Account")%>'></asp:Label>
                                                                                                                                    </ItemTemplate>
                                                                                                                                </asp:TemplateField>
                                                                                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" Visible="false" ItemStyle-HorizontalAlign="Left">
                                                                                                                                    <HeaderTemplate>
                                                                                                                                        <asp:Label ID="lblGvHdrPaymentDescription" runat="server" Text="Description"></asp:Label>
                                                                                                                                    </HeaderTemplate>
                                                                                                                                    <ItemTemplate>
                                                                                                                                        <asp:Label ID="lblGvPaymentDescription" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Narration")%>'></asp:Label>
                                                                                                                                    </ItemTemplate>
                                                                                                                                    <FooterTemplate>
                                                                                                                                        <b>Total</b>
                                                                                                                                    </FooterTemplate>
                                                                                                                                </asp:TemplateField>
                                                                                                                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                                                                                                                    FooterStyle-HorizontalAlign="Right">
                                                                                                                                    <HeaderTemplate>
                                                                                                                                        <asp:Label ID="lblGvHdrPaymentPayment" runat="server" Text="Credit"></asp:Label>
                                                                                                                                    </HeaderTemplate>
                                                                                                                                    <ItemTemplate>
                                                                                                                                        <asp:Label ID="lblGvPayment" runat="server"></asp:Label>
                                                                                                                                    </ItemTemplate>
                                                                                                                                    <FooterTemplate>
                                                                                                                                        <b>
                                                                                                                                            <asp:Label ID="lblGvFtTotalPayment" runat="server"></asp:Label>
                                                                                                                                        </b>
                                                                                                                                    </FooterTemplate>
                                                                                                                                </asp:TemplateField>
                                                                                                                            </Columns>
                                                                                                                            <EmptyDataTemplate>
                                                                                                                                <div style="padding: 10px;">
                                                                                                                                    <b>
                                                                                                                                        <asp:Label ID="lblNoRecordFoundForPayment" runat="server" Text="No Record Found."></asp:Label>
                                                                                                                                    </b>
                                                                                                                                </div>
                                                                                                                            </EmptyDataTemplate>
                                                                                                                        </asp:GridView>
                                                                                                                    </div>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </div>
                                                                                                    <div id="tabs-8">
                                                                                                        <table cellpadding="2" cellspacing="2" width="100%">
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <div class="box_head">
                                                                                                                        <span>
                                                                                                                            <asp:Literal ID="litDepositDetails" runat="server" Text="Deposit"></asp:Literal>
                                                                                                                        </span>
                                                                                                                    </div>
                                                                                                                    <div class="clear">
                                                                                                                    </div>
                                                                                                                    <div class="box_content">
                                                                                                                        <asp:GridView ID="gvDepositDetails" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                                                                            Width="100%" ShowFooter="true" OnPageIndexChanging="gvDepositDetails_PageIndexChanging"
                                                                                                                            OnRowDataBound="gvDepositDetails_RowDataBound" DataKeyNames="EntryDate,IsVoid,RoomID,BookID,ReservationNo">
                                                                                                                            <Columns>
                                                                                                                                <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                                                    <HeaderTemplate>
                                                                                                                                        <asp:Label ID="lblGvHdrDepositDate" runat="server" Text="Date"></asp:Label>
                                                                                                                                    </HeaderTemplate>
                                                                                                                                    <ItemTemplate>
                                                                                                                                        <asp:Label ID="lblGvDepositDate" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "EntryDate")).ToString(clsSession.DateFormat)%>'></asp:Label>
                                                                                                                                    </ItemTemplate>
                                                                                                                                </asp:TemplateField>
                                                                                                                                <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                                                    <HeaderTemplate>
                                                                                                                                        <asp:Label ID="lblGvHdrDepositBookNo" runat="server" Text="Trans. #"></asp:Label>
                                                                                                                                    </HeaderTemplate>
                                                                                                                                    <ItemTemplate>
                                                                                                                                        <asp:Label ID="lblGvDepositDetailsBookNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "BookNo")%>'></asp:Label>
                                                                                                                                    </ItemTemplate>
                                                                                                                                </asp:TemplateField>
                                                                                                                                <asp:TemplateField ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                                                    <HeaderTemplate>
                                                                                                                                        <asp:Label ID="lblGvHdrDepositAccount" runat="server" Text="Ledger Account"></asp:Label>
                                                                                                                                    </HeaderTemplate>
                                                                                                                                    <ItemTemplate>
                                                                                                                                        <asp:Label ID="lblGvDepositAccount" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Account")%>'></asp:Label>
                                                                                                                                    </ItemTemplate>
                                                                                                                                </asp:TemplateField>
                                                                                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" Visible="false" ItemStyle-HorizontalAlign="Left">
                                                                                                                                    <HeaderTemplate>
                                                                                                                                        <asp:Label ID="lblGvHdrDepositDescription" runat="server" Text="Description"></asp:Label>
                                                                                                                                    </HeaderTemplate>
                                                                                                                                    <ItemTemplate>
                                                                                                                                        <asp:Label ID="lblGvDepositDescription" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Narration")%>'></asp:Label>
                                                                                                                                    </ItemTemplate>
                                                                                                                                    <FooterTemplate>
                                                                                                                                        <b>Total</b>
                                                                                                                                    </FooterTemplate>
                                                                                                                                </asp:TemplateField>
                                                                                                                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                                                                                                                    FooterStyle-HorizontalAlign="Right">
                                                                                                                                    <HeaderTemplate>
                                                                                                                                        <asp:Label ID="lblGvHdrDepositDueAmount" runat="server" Text="Credit"></asp:Label>
                                                                                                                                    </HeaderTemplate>
                                                                                                                                    <ItemTemplate>
                                                                                                                                        <asp:Label ID="lblGvDepositDueAmount" runat="server"></asp:Label>
                                                                                                                                    </ItemTemplate>
                                                                                                                                    <FooterTemplate>
                                                                                                                                        <b>
                                                                                                                                            <asp:Label ID="lblGvFtTotalDepositDueAmount" runat="server"></asp:Label></b>
                                                                                                                                    </FooterTemplate>
                                                                                                                                </asp:TemplateField>
                                                                                                                            </Columns>
                                                                                                                            <EmptyDataTemplate>
                                                                                                                                <div style="padding: 10px;">
                                                                                                                                    <b>
                                                                                                                                        <asp:Label ID="lblNoRecordFoundForDueAmount" runat="server" Text="No Record Found."></asp:Label>
                                                                                                                                    </b>
                                                                                                                                </div>
                                                                                                                            </EmptyDataTemplate>
                                                                                                                        </asp:GridView>
                                                                                                                    </div>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="center" style="padding-top: 10px;">
                                                                                            <asp:Button ID="BtnBackFromFolioDetail" runat="server" Text="Back" Style="display: inline;"
                                                                                                OnClick="BtnBackFromFolioDetail_OnClick" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:View>
                                                </asp:MultiView>
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
<asp:UpdateProgress AssociatedUpdatePanelID="updGuestmaster" ID="UpdateProgressGuestMaster"
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
