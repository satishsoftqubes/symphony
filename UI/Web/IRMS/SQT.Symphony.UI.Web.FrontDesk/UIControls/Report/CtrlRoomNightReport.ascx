<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlRoomNightReport.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Report.CtrlRoomNightReport" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript">

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<asp:UpdatePanel ID="uPnlRoomNights" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="boxtopleft">
                    &nbsp;
                </td>
                <td class="boxtopcenter">
                    Room Night Report
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
                    <asp:MultiView ID="mvRoomNight" runat="server">
                        <asp:View ID="vList" runat="server">
                            <table width="100%" cellpadding="3" cellspacing="2" style="background-color: #fff;" border="0">
                                <tr>
                                    <td style="width: 50px; padding-top:15px;">
                                        <asp:Literal ID="litStartDate" runat="server" Text="From"></asp:Literal>
                                    </td>
                                    <td style="width: 220px; padding-top:15px;">
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
                                    <td style="width: 30px; padding-top:15px;">
                                        <asp:Literal ID="litEndDate" runat="server" Text="To"></asp:Literal>
                                    </td>
                                    <td style="padding-top:15px;">
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
                                        <asp:ImageButton ID="imtbtnSearch" ToolTip="Search" runat="server" ImageUrl="~/images/search-icon.png"
                                            Style="border: 0px; vertical-align: middle; display: inline" ValidationGroup="IsRequire"
                                            OnClick="imtbtnSearch_OnClick" />
                                        &nbsp;&nbsp;
                                        <asp:ImageButton ID="imgbtnXLSX" Text="" Style="vertical-align: middle; display: inline;"
                                            ValidationGroup="IsRequire" ToolTip="ExportToXLSX" runat="server" OnClick="imgbtnXLSX_OnClick"
                                            ImageUrl="~/images/report_xlsx.png" OnClientClick="fnDisplayCatchErrorMessage()" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="padding-top:15px;">
                                        <table width="50%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="vertical-align: top;">
                                                    <div class="box_head">
                                                        <span>
                                                            <asp:Literal ID="litRoomNights" runat="server" Text="Room Nights"></asp:Literal>
                                                        </span>
                                                    </div>
                                                    <div class="clear">
                                                    </div>
                                                    <div class="box_content">
                                                        <asp:GridView ID="gvRoomNights" runat="server" AutoGenerateColumns="false" ShowHeader="true" DataKeyNames="RateCardName,Nights"
                                                            Width="100%" OnRowCommand="gvRoomNights_RowCommand" OnPageIndexChanging="gvRoomNights_PageIndexChanging" >
                                                            <Columns>
                                                                <asp:TemplateField ItemStyle-Width="20px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblGvHdrInqSrNo" runat="server" Text="No."></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex + 1 %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="250px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblGvHdrRateCardName" runat="server" Text="Rate Card Name"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkRateCard" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "RateCardName")%>'
                                                                                CommandName="ROOMNIGHTDETAIL" CommandArgument='<%#Eval("RateID")%>'></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblGvHdrNoOfNights" runat="server" Text="Nights"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <%#DataBinder.Eval(Container.DataItem, "Nights")%>
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
                        </asp:View>
                        <asp:View ID="vDetail" runat="server">
                            <table width="100%" cellpadding="3" cellspacing="2" style="background-color: #fff;">
                                <tr>
                                    <td style="width: 100px; padding-top:15px; padding-left:5px;">
                                        <asp:Literal ID="Literal1" runat="server" Text="Rate Card Name :"></asp:Literal>
                                    </td>
                                    <td style="width: 200px; padding-top:15px;">
                                        <b><asp:Label ID="lblRateCardName" runat="server" ></asp:Label></b>
                                    </td>
                                    <td style="width: 85px; padding-top:15px;">
                                        <asp:Literal ID="Literal2" runat="server" Text="Room Nights :"></asp:Literal>
                                    </td>
                                    <td align="left" style="width: 50px; padding-top:15px;">
                                       <b><asp:Label ID="lblRoomNightsCount" runat="server" ></asp:Label></b>
                                    </td>
                                    <td align="right" style="padding-top:15px;">
                                        <asp:Button ID="btnDetailExcelExport" runat="server" Text="Export to Excel" OnClick="btnDetailExcelExport_OnClick" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5" style="padding-top:15px;">
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="vertical-align: top;">
                                                    <div class="box_head">
                                                        <span>
                                                            <asp:Literal ID="Literal3" runat="server" Text="Room Nights"></asp:Literal>
                                                        </span>
                                                    </div>
                                                    <div class="clear">
                                                    </div>
                                                    <div class="box_content">
                                                        <asp:GridView ID="gvRoomNightDetail" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                            Width="100%" OnPageIndexChanging="gvRoomNightDetail_PageIndexChanging">
                                                            <Columns>
                                                                <asp:TemplateField ItemStyle-Width="20px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblGvHdrInqSrNo" runat="server" Text="No."></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex + 1 %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="90px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblGvHdrReservationNo" runat="server" Text="Reservation No."></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <%#DataBinder.Eval(Container.DataItem, "ReservationNo")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="250px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblGvHdrGuestName" runat="server" Text="Guest Name"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <%#DataBinder.Eval(Container.DataItem, "GuestName")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblGvHdrCheckInDate" runat="server" Text="Checkin Date"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblGvCheckInDate" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "CheckInDate")).ToString(clsSession.DateFormat)%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblGvHdrCheckOutDate" runat="server" Text="Checkout Date"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblGvCheckOutDate" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "CheckOutDate")).ToString(clsSession.DateFormat)%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblGvHdrStartDate" runat="server" Text="Start Date"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblGvStartDate" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "ToCountStartDate")).ToString(clsSession.DateFormat)%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblGvHdrEndDate" runat="server" Text="End Date"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblGvEndDate" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "ToCountEndDate")).ToString(clsSession.DateFormat)%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblGvHdrNoOfNights" runat="server" Text="Nights"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <%#DataBinder.Eval(Container.DataItem, "Nights")%>
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
                                <tr>
                                    <td colspan="5" align="center">
                                        <asp:Button ID="btnBack2List" runat="server" Text="Back" OnClick="btnBack2List_OnClick" />
                                    </td>
                                </tr>
                            </table>
                            
                        </asp:View>
                    </asp:MultiView>
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
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="imgbtnXLSX" />
        <asp:PostBackTrigger ControlID="btnDetailExcelExport" />
    </Triggers>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="uPnlRoomNights" ID="UpdateProgressRoomNight"
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
